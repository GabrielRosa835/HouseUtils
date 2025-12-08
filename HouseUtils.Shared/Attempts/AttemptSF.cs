namespace HouseUtils.Shared.Attempts;

public abstract class Attempt<TSuccess, TFailure>
{
   public abstract TResult Either<TResult> (Func<TSuccess, TResult> onSuccess, Func<TFailure, TResult> onFailure);
   public bool IsSuccess => this is Success<TSuccess, TFailure>;
   public bool IsFailure => this is Failure<TSuccess, TFailure>;

   public static implicit operator Attempt<TSuccess, TFailure> (TSuccess value) => new Success<TSuccess, TFailure>(value);
   public static implicit operator Attempt<TSuccess, TFailure> (TFailure value) => new Failure<TSuccess, TFailure>(value);
   internal sealed class Success<TS, TF> (TS value) : Attempt<TS, TF>
   {
      public TS Value { get; } = value;
      public override TResult Either<TResult> (Func<TS, TResult> onSuccess, Func<TF, TResult> onFailure)
      {
         return onSuccess(Value);
      }
   }
   internal sealed class Failure<TS, TF> (TF value) : Attempt<TS, TF>
   {
      public TF Value { get; } = value;
      public override TResult Either<TResult> (Func<TS, TResult> onSuccess, Func<TF, TResult> onFailure)
      {
         return onFailure(Value);
      }
   }
}
