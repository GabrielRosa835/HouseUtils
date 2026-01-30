using HouseUtils.Application;
using HouseUtils.Application.Abstractions;
using HouseUtils.Shared.UnionTypes;

public static class Canva
{
    
}

public class EventDispatcher //: IEventDispatcher<TEvent> where TEvent : IEvent
{
   private readonly IEnumerable<IEventMiddleware> _middlewares;
   
   
   
   public Task<Attempt> ExecuteAsync<TEvent, TEventHandler> (TEvent args, TEventHandler handler)
      where TEvent : IEvent
      where TEventHandler : IEventHandler<TEvent>
   {
      
   }
   
   // public Task<Attempt<TResult, TFailure>> ExecuteAsync (TEvent args)
   // {
   //    HandlerDelegate<Attempt<TResult, TFailure>> next = () => _handler.HandleAsync(args);
   //
   //    foreach (var middleware in _middlewares.Reverse())
   //    {
   //       var previousNext = next;
   //       next = () => middleware.HandleAsync(args, previousNext);
   //    }
   //
   //    return next();
   // }

   // public Task<Attempt<TResult>> ExecuteAsync<TResult> (TEvent args)
   // {
   //    throw new NotImplementedException();
   // }
   //
   // public Task<Attempt<TResult, TFailure>> ExecuteAsync<TResult, TFailure> (TEvent args)
   // {
   //    HandlerDelegate<Attempt<TResult, TFailure>> next = () => _handler.HandleAsync(args);
   //
   //    foreach (var middleware in _middlewares.Reverse())
   //    {
   //       var previousNext = next;
   //       next = () => middleware.HandleAsync(args, previousNext);
   //    }
   //
   //    return next();
   // }
   //
   // Task<Attempt> IEventDispatcher<TEvent>.ExecuteAsync (TEvent args)
   // {
   //    throw new NotImplementedException();
   // }
}