using HouseUtils.Shared.UnionTypes;

namespace HouseUtils.Application.Abstractions;

public interface IEventHandler;

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
{
   Task<Attempt> HandleAsync (TEvent args);
}

public interface IEventHandler<in TEvent, TResult> : IEventHandler where TEvent : IEvent
{
   Task<Attempt<TResult>> HandleAsync(TEvent args);
}

public interface IEventHandler<in TEvent, TResult, TFailure> : IEventHandler where TEvent : IEvent
{
   Task<Attempt<TResult, TFailure>> HandleAsync(TEvent args);
}