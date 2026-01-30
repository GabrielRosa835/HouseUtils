namespace HouseUtils.Application.Abstractions;

public interface ICommandHandler : IEventHandler;

public interface ICommandHandler<in TCommand> : ICommandHandler, IEventHandler<TCommand> where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResult> : ICommandHandler, IEventHandler<TCommand, TResult>
   where TCommand : ICommand;

public interface ICommandHandler<in TCommand, TResult, TFailure> : ICommandHandler,
   IEventHandler<TCommand, TResult, TFailure> where TCommand : ICommand;