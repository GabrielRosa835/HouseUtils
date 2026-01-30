using HouseUtils.Shared.UnionTypes;

namespace HouseUtils.Application;

public interface IEventDispatcher;

public interface IEventDispatcher<in TEvent> : IEventDispatcher
{
   Task<Attempt> ExecuteAsync (TEvent args);
}

public interface IEventDispatcher<in TEvent, TResult> : IEventDispatcher
{
   Task<Attempt<TResult>> ExecuteAsync (TEvent args);
}

public interface IEventDispatcher<in TEvent, TResult, TFailure> : IEventDispatcher
{
   Task<Attempt<TResult, TFailure>> ExecuteAsync (TEvent args);
}