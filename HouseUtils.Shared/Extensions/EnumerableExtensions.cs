namespace HouseUtils.Shared.Extensions;

public static class EnumerableExtensions
{
   public static IEnumerable<T> Paging<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
   {
      return source.Skip(pageIndex * pageSize).Take(pageSize);
   }
   public static void ForEach<T> (this IEnumerable<T> source, Action<T> action)
   {
      foreach (var item in source)
      {
         action(item);
      }
   }
   public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
   {
      foreach (var item in source)
      {
         action(item);
         yield return item;
      }
   }
   public static IEnumerable<(int Index, T Item)> Enumerate<T> (this IEnumerable<T> source)
   {
      return source.Select((item, index) => (index, item));
   }
   public static IEnumerable<(int Index, T Item, C Complement)> EnumerateWith<T, C> (this IEnumerable<T> source, Func<int, T, C> complementSupplier)
   {
      return source.Select((item, index) => (index, item, complementSupplier(index, item)));
   }
   public static IEnumerable<(int Index, T Item, C1 Complement1, C2 Complement2)> EnumerateWith<T, C1, C2> 
      (this IEnumerable<T> source, Func<int, T, C1> complement1Supplier, Func<int, T, C2> complement2Supplier)
   {
      return source.Select((item, index) => (index, item, complement1Supplier(index, item), complement2Supplier(index, item)));
   }
}
