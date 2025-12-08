using HouseUtils.Shared;

namespace HouseUtils.Application.Providers;

public interface IHandlerProvider
{
   T Get<T> () where T : IHandler;
}
