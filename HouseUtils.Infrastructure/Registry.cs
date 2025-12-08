using FluentValidation;

using HouseUtils.Application.Data;
using HouseUtils.Application.Providers;
using HouseUtils.Infrastructure.Persistence;
using HouseUtils.Infrastructure.Providers;
using HouseUtils.Shared;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace HouseUtils.Presentation;

public static class Registry
{
   public static IServiceCollection AddHandlers (this IServiceCollection services)
   {
      Assembly assembly = Assembly.GetAssembly(typeof(IHandler)) 
         ?? throw new Exception("Assembly with IHandler could not be found");
      foreach (Type type in assembly.GetTypes())
      {
         if (type.IsClass && !type.IsAbstract && typeof(IHandler).IsAssignableFrom(type))
         {
            services.AddTransient(type);
         }
      }
      return services;
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
