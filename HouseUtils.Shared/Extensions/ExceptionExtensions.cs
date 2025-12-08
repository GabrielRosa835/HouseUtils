using System.Text;

namespace HouseUtils.Shared.Extensions;

public static class ExceptionExtensions
{
   public static string GetNameAndMessage (this Exception e) =>
      $"[{e.GetType().Name}] {e.Message}";

   public static string GetFullMessage(this Exception e, string separator = "\n", StringBuilder? builder = null)
   {
      builder ??= new StringBuilder();

      for (Exception? inner = e ; inner is not null ; inner = inner?.InnerException)
      {
         if (inner is null) continue;

         if (e is AggregateException a)
         {
            foreach (Exception ae in a.InnerExceptions)
            {
               for (Exception inner2 = a ; inner2 is not null ; inner2 = inner2.InnerException!)
               {
                  builder.Append(separator).Append(inner.Message);
               }
            }
         }
         else
         {
            builder.Append(separator).Append(inner.Message);
         }
      }
      return builder.ToString();
   }

   public static string GetNameAndFullMessage (this Exception e, string separator = "\n")
   {
      StringBuilder builder = new StringBuilder($"[{e.GetType().Name}]");
      return GetFullMessage(e, separator, builder);
   }
}
