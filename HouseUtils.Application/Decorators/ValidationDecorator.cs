using HouseUtils.Application.Abstractions;
using HouseUtils.Shared.UnionTypes;

using Microsoft.Extensions.DependencyInjection;

namespace HouseUtils.Application.Decorators;

public static class ValidationDecorator
{
   public const string SERVICE_KEY = nameof(ValidationDecorator);
   
   public sealed class EventHandler<TEvent, TResult> : IEventHandler<TEvent, TResult> where TEvent : IQuery
   {
      private readonly IEventHandler<TEvent, TResult> _handler;

      public EventHandler(IEventHandler<TEvent, TResult> handler)
      {
         _handler = handler;
      }

      public Task<Attempt<TResult>> HandleAsync (TEvent args)
      {
         return _handler.HandleAsync(args);
      }
   }
}