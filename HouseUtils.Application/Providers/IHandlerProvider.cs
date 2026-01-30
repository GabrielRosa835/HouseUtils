using HouseUtils.Application.Abstractions;

namespace HouseUtils.Application.Providers;

public interface IHandlerProvider
{
   T Get<T> () where T : IEventHandler;
}
