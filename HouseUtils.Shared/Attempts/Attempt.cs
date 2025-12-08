namespace HouseUtils.Shared.Attempts;

public abstract class Attempt
{
   public abstract TResult Either<TResult> (Func<TResult> onSuccess, Func<TResult> onFailure);
   public bool IsSuccess => this is Success;
   public bool IsFailure => this is Failure;

   internal sealed class Success : Attempt
   {
      public override TResult Either<TResult> (Func<TResult> onSuccess, Func<TResult> onFailure)
      {
         return onSuccess();
      }
   }
   internal sealed class Failure : Attempt
   {
      public override TResult Either<TResult> (Func<TResult> onSuccess, Func<TResult> onFailure)
      {
         return onFailure();
      }
   }
}
