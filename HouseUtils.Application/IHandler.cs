namespace HouseUtils.Shared;

public interface IHandler;

public interface INullHandler
{
   public void Handle();
}

public interface IHandler<TResult> : IHandler
{
   public TResult Handle ();
}
public interface IResultArgumentHandler<TResult, TArguments> : IHandler
{
   public TResult Handle(TArguments arguments);
}