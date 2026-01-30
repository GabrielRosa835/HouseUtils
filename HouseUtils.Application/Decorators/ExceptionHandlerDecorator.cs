using HouseUtils.Application.Abstractions;
using HouseUtils.Shared.UnionTypes;

namespace HouseUtils.Application.Decorators;

// public class ExceptionHandlerDecorator<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
// {
//    private readonly IEventHandler<TEvent> _handler;
//
//    public ExceptionHandlerDecorator(IEventHandler<TEvent> handler)
//    {
//       _handler = handler;
//    }
//
//    public Attempt Handle (TEvent args)
//    {
//       try
//       {
//          return _handler.HandleAsync(args);
//       }
//       catch (Exception e)
//       {
//          return Results.Failure(e);
//       }
//    }
// }