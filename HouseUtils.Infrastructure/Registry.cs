using FluentValidation;

using HouseUtils.Application.Abstractions;
using HouseUtils.Application.Decorators;
using HouseUtils.Application.Persistence;
using HouseUtils.Application.Providers;
using HouseUtils.Infrastructure.Persistence;
using HouseUtils.Infrastructure.Providers;
using HouseUtils.Shared;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace HouseUtils.Presentation;

public static class Registry
{
   const string Logging_ServiceKey = "Logging";
   const string Validation_ServiceKey = "Validation";
   const string Handlers_ServiceKey = "Handlers";
   
   
   public static IServiceCollection AddHandlers (this IServiceCollection services)
   {
      Assembly assembly = Assembly.GetAssembly(typeof(IEventHandler)) 
         ?? throw new Exception($"Assembly with {nameof(IEventHandler)} could not be found");

      Type[] decorators = [typeof(LoggingDecorator), typeof(ValidationDecorator)];

      services.AddKeyedTransient(
         typeof(IQueryHandler<,>), Logging_ServiceKey, typeof(LoggingDecorator.QueryHandler<,>));
      
      services.FirstOrDefault(sd => sd.ImplementationType.GetGenericTypeDefinition())
      
      // var handlerTypes = assembly.GetTypes()
      //    .Where(t => t is { IsAbstract: false, IsInterface: false }
      //       && decorators.All(d => !d.IsAssignableFrom(t)))
      //    .Select(t => new {
      //       Implementation = t,
      //       Interface = t.GetInterfaces().FirstOrDefault(i => i.IsGenericType 
      //          && i.GetGenericTypeDefinition().IsAssignableTo(typeof(IEventHandler)))
      //    })
      //    .Where(t => t.Interface is not null);

      foreach (var handler in handlerTypes)
      {
         services.AddKeyedTransient(handler.Interface!, Handlers_ServiceKey, handler.Implementation);
      }
      
      foreach (Type type in assembly.GetTypes())
      {
         if (type.IsAssignableFrom(typeof(IQueryHandler<,>)))
         {
            services.AddTransient(type);
            services.AddKeyedTransient(type, LoggingDecorator.SERVICE_KEY, (provider, key) =>
            {
               return provider.GetRequiredKeyedService(typeof(LoggingDecorator.QueryHandler<,>), key);
            });
            services.AddKeyedTransient(type, ValidationDecorator.SERVICE_KEY, (provider, key) =>
            {
               return provider.GetRequiredKeyedService(typeof(ValidationDecorator.QueryHandler<,>), key);
            });
         }
      }
      return services;
   }

   private static void RegisterHandler (Type type, IServiceCollection services)
   {
      if (type is not { IsClass: true, IsAbstract: false } || !type.IsAssignableFrom(typeof(IEventHandler)))
      {
         return;
      }

      if (type.IsAssignableFrom(typeof(IQueryHandler<,>)))
      {
         services.AddTransient(type);
         services.AddKeyedTransient(type, LoggingDecorator.SERVICE_KEY, (provider, key) =>
         {
            return provider.GetRequiredKeyedService(typeof(LoggingDecorator.QueryHandler<,>), key);
         });
      }
      
      services.AddTransient(type);
   }
   
   
   public static IServiceCollection AddValidation (this IServiceCollection services)
   {
      return services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Registry)) 
         ?? throw new Exception("Assembly with Registry could not be found"));
   }

   public static IServiceCollection AddProviders (this IServiceCollection services) => services
      .AddSingleton<IDbProvider, IocDbProvider>()
      .AddSingleton<IHandlerProvider, IocHandlerProvider>();

   public static IServiceCollection AddPersistence (this IServiceCollection services) => services
      .AddTransient<IApplicationDbContext, ApplicationDbContext>()
      .AddTransient<ITransactionDbContext, TransactionDbContext>();
}
