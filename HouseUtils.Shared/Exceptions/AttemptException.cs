namespace HouseUtils.Shared.Exceptions;

public class AttemptException : Exception
{
   public AttemptException (){}
   public AttemptException (string? message) : base(message){}
   public AttemptException (string? message, Exception? innerException) : base(message, innerException){}
}
