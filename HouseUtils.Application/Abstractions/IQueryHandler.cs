namespace HouseUtils.Application.Abstractions;

public interface IQueryHandler : IEventHandler;

public interface IQueryHandler<in TQuery, TResult> : IQueryHandler, IEventHandler<TQuery, TResult> where TQuery : IQuery;

public interface IQueryHandler<in TQuery, TResult, TFailure> : IQueryHandler, IEventHandler<TQuery, TResult, TFailure>
   where TQuery : IQuery;