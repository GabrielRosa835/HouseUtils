namespace HouseUtils.Shared.UnionTypes;

public readonly struct Attempt<TSuccess, TFailure>
{
   private readonly TSuccess _successValue;
   private readonly TFailure _failureValue;
   private readonly bool _isSuccess;

   public bool IsSuccess => _isSuccess;
   public bool IsFailure => !IsSuccess;

   private Attempt (bool isSuccess, TSuccess successValue, TFailure failureValue)
   {
      _isSuccess = isSuccess;
      _successValue = successValue;
      _failureValue = failureValue;
   }

   public static Attempt<TSuccess, TFailure> Success (TSuccess success) => new(true, success, default!);
   public static Attempt<TSuccess, TFailure> Failure (TFailure failure) => new(false, default!, failure);

   public static implicit operator Attempt<TSuccess, TFailure> (TSuccess value) => Success(value);
   public static implicit operator Attempt<TSuccess, TFailure> (TFailure value) => Failure(value);
   public static implicit operator bool(Attempt<TSuccess, TFailure> attempt) => attempt.IsSuccess;
   
   public TResult Either<TResult> (Func<TSuccess, TResult> onSuccess, Func<TFailure, TResult> onFailure)
   {
      return _isSuccess ? onSuccess(_successValue) : onFailure(_failureValue);
   }
}