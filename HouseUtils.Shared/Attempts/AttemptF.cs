namespace HouseUtils.Shared.Attempts;

public abstract class Attempt<TFailure>
{
   public abstract TResult Either<TResult> (Func<TResult> onSuccess, Func<TFailure, TResult> onFailure);
   public bool IsSuccess => this is Success<TFailure>;
   public bool IsFailure => this is Failure<TFailure>;

   public static implicit operator Attempt<TFailure> (TFailure value) => new Failure<TFailure>(value);
   internal sealed class Success<TF> : Attempt<TF>
   {
      public override TResult Either<TResult> (Func<TResult> onSuccess, Func<TF, TResult> onFailure)
      {
         return onSuccess();
      }
   }
   internal sealed class Failure<TF> (TF value) : Attempt<TF>
   {
      public TF Value { get; } = value;
      public override TResult Either<TResult> (Func<TResult> onSuccess, Func<TF, TResult> onFailure)
      {
         return onFailure(Value);
      }
   }
}
