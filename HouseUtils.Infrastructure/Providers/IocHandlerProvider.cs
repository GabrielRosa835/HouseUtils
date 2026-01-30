using HouseUtils.Application.Abstractions;
using HouseUtils.Application.Providers;
using HouseUtils.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace HouseUtils.Infrastructure.Providers;

public sealed class IocHandlerProvider : IHandlerProvider
{
   private readonly IServiceProvider _serviceProvider;
   public IocHandlerProvider (IServiceProvider serviceProvider)
   {
      _serviceProvider = serviceProvider;
   }
   
   public T Get<T> () where T : IEventHandler
   {
      
      
      return _serviceProvider.GetRequiredService<T>();
   }
}
