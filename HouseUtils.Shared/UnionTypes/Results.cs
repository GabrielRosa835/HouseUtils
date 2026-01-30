namespace HouseUtils.Shared.UnionTypes;

public static class Results
{
   public static Attempt Success () => Attempt.Success();
   public static Attempt Failure () => Attempt.Failure();
   public static Attempt Failure (Exception e) => Attempt.Failure(e);

   public static Attempt<TSuccess> Success<TSuccess> (TSuccess value) => Attempt<TSuccess>.Success(value);
   public static Attempt<TSuccess> Failure<TSuccess> (Exception value) => Attempt<TSuccess>.Failure(value);
   public static Attempt<TSuccess> Failure<TSuccess> () => Attempt<TSuccess>.Failure();

   public static Attempt<TSuccess, TFailure> Success<TSuccess, TFailure> (TSuccess value) =>
      Attempt<TSuccess, TFailure>.Success(value);

   public static Attempt<TSuccess, TFailure> Failure<TSuccess, TFailure> (TFailure value) =>
      Attempt<TSuccess, TFailure>.Failure(value);

   public static Maybe<TValue> Present<TValue> (TValue value) => Maybe<TValue>.Present(value);
   public static Maybe<TValue> Empty<TValue> () => Maybe<TValue>.Empty();
   public static Maybe<TValue> Of<TValue> (TValue? value) => Maybe<TValue>.Of(value);
}