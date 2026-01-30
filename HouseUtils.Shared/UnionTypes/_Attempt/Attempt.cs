namespace HouseUtils.Shared.UnionTypes;

public readonly struct Attempt
{
   private readonly bool _isSuccess;
   private readonly Exception _failureValue;

   public bool IsSuccess => _isSuccess;
   public bool IsFailure => !_isSuccess;

   private Attempt (bool isSuccess, Exception failureValue)
   {
      _isSuccess = isSuccess;
      _failureValue = failureValue;
   }

   public static Attempt Success() => new(true, default!);
   public static Attempt Failure (Exception exception) => new(false, exception);
   public static Attempt Failure () => new(false, new Exception());
   
   public static implicit operator bool(Attempt value) => value.IsSuccess;

   public TResult Either<TResult> (Func<TResult> onSuccess, Func<Exception, TResult> onFailure)
   {
      return _isSuccess ? onSuccess() : onFailure(_failureValue);
   }
}
