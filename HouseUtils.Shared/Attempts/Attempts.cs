using HouseUtils.Shared.Exceptions;

namespace HouseUtils.Shared.Attempts;

public static class Attempts
{
   public static Attempt<TS, TF> Success<TS, TF> (TS value) => value;
   public static Attempt<TS, TF> Failure<TS, TF> (TF value) => value;
   public static Attempt<TF> Success<TF> () => new Attempt<TF>.Success<TF>();
   public static Attempt<TF> Failure<TF> (TF value) => value;
   public static Attempt Success() => new Attempt.Success();
   public static Attempt Failure() => new Attempt.Failure();

   public static TS GetSuccess<TS, TF>(this Attempt<TS, TF> attempt)
   {
      if (attempt is Attempt<TS, TF>.Success<TS, TF> success)
      {
         return success.Value;
      }
      throw new AttemptException("Attempt is not a success.");
   }
   public static TS GetSuccessOrDefault<TS, TF> (this Attempt<TS, TF> attempt)
   {
      if (attempt is Attempt<TS, TF>.Success<TS, TF> success)
      {
         return success.Value;
      }
      return default!;
   }
   public static TF GetFailure<TS, TF>(this Attempt<TS, TF> attempt)
   {
      if (attempt is Attempt<TS, TF>.Failure<TS, TF> failure)
      {
         return failure.Value;
      }
      throw new AttemptException("Attempt is not a failure.");
   }
   public static TF GetFailureOrDefault<TS, TF> (this Attempt<TS, TF> attempt)
   {
      if (attempt is Attempt<TS, TF>.Failure<TS, TF> failure)
      {
         return failure.Value;
      }
      return default!;
   }
   public static TF GetFailure<TF>(this Attempt<TF> attempt)
   {
      if (attempt is Attempt<TF>.Failure<TF> failure)
      {
         return failure.Value;
      }
      throw new AttemptException("Attempt is not a failure.");
   }
   public static TF GetFailureOrDefault<TF> (this Attempt<TF> attempt)
   {
      if (attempt is Attempt<TF>.Failure<TF> failure)
      {
         return failure.Value;
      }
      return default!;
   }

   public static Attempt<TS, Exception> Try<TS> (Func<TS> func)
   {
      try
      {
         return Success<TS, Exception>(func());
      }
      catch (Exception ex)
      {
         return Failure<TS, Exception>(ex);
      }
   }
   public static Attempt<TS, TF> Try<TS, TF> (Func<TS> func, Func<Exception, TF> onException)
   {
      try
      {
         return Success<TS, TF>(func());
      }
      catch (Exception ex)
      {
         return Failure<TS, TF>(onException(ex));
      }
   }
   public static Attempt<Exception> Try (Action action)
   {
      try
      {
         action();
         return Success<Exception>();
      }
      catch (Exception ex)
      {
         return Failure(ex);
      }
   }
   public static Attempt<TF> Try<TF> (Action action, Func<Exception, TF> onException)
   {
      try
      {
         action();
         return Success<TF>();
      }
      catch (Exception ex)
      {
         return Failure(onException(ex));
      }
   }
   public static Attempt TryVoid (Action action)
   {
      try
      {
         action();
         return Success();
      }
      catch (Exception)
      {
         return Failure();
      }
   }
}
