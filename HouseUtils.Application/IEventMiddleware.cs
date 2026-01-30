using HouseUtils.Application.Abstractions;
using HouseUtils.Shared.UnionTypes;

namespace HouseUtils.Application;

public delegate Task<Attempt> HandlerDelegate();
public delegate Task<Attempt<TResult>> HandlerDelegate<TResult>();
public delegate Task<Attempt<TResult, TFailure>> HandlerDelegate<TResult, TFailure>();

public interface IEventMiddleware;

public interface IEventMiddleware<in TEvent> : IEventMiddleware where TEvent : IEvent
{
   Task<Attempt> HandleAsync(TEvent args, HandlerDelegate next);
}

public interface IEventMiddleware<in TEvent, TResult> : IEventMiddleware where TEvent : IEvent
{
   Task<Attempt<TResult>> HandleAsync(TEvent args, HandlerDelegate<TResult> next);
}

public interface IEventMiddleware<in TEvent, TResult, TFailure> : IEventMiddleware where TEvent : IEvent
{
   Task<Attempt<TResult, TFailure>> HandleAsync(TEvent args, HandlerDelegate<TResult, TFailure> next);
}