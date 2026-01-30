namespace HouseUtils.Shared.UnionTypes;

public readonly struct Attempt<TSuccess>
{
   private readonly TSuccess _successValue;
   private readonly Exception _failureValue;
   private readonly bool _isSuccess;

   public bool IsSuccess => _isSuccess;
   public bool IsFailure => !IsSuccess;

   private Attempt (bool isSuccess, TSuccess successValue, Exception failureValue)
   {
      _isSuccess = isSuccess;
      _successValue = successValue;
      _failureValue = failureValue;
   }

   public static Attempt<TSuccess> Success (TSuccess success) => new(true, success, null!);
   public static Attempt<TSuccess> Failure (Exception exception) => new(false, default!, exception);
   public static Attempt<TSuccess> Failure () => new(false, default!, new Exception());
   
   public static implicit operator Attempt<TSuccess> (TSuccess value) => Success(value);
   public static implicit operator Attempt<TSuccess> (Exception value) => Failure(value);
   public static implicit operator bool(Attempt<TSuccess> attempt) => attempt.IsSuccess;

   public TResult Either<TResult> (Func<TSuccess, TResult> onSuccess, Func<Exception, TResult> onFailure)
   {
      return _isSuccess ? onSuccess(_successValue) : onFailure(_failureValue);
   }
}
