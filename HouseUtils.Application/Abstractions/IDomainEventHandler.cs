namespace HouseUtils.Application.Abstractions;

public interface IDomainEventHandler : IEventHandler;

public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler, IEventHandler<TDomainEvent>
   where TDomainEvent : IDomainEvent;

public interface IDomainEventHandler<in TDomainEvent, TResult> : IDomainEventHandler, IEventHandler<TDomainEvent, TResult>
   where TDomainEvent : IDomainEvent;

public interface IDomainEventHandler<in TDomainEvent, TResult, TFailure> : IDomainEventHandler, 
   IEventHandler<TDomainEvent, TResult, TFailure>
   where TDomainEvent : IDomainEvent;