using HouseUtils.Shared.Extensions;

namespace HouseUtils.Application.DTOs;

public record PageDTO<T>
{
   public int PageIndex { get; init; }
   public int PageSize { get; init; }
   public int PageCount { get; init; }
   public int ItemCount { get; init; }
   public ICollection<T> Items { get; init; } = [];

   public static PageDTO<V> Of<V> (ICollection<V> items, int pageIndex, int pageSize) => new()
   {
      Items = items.Paging(pageIndex, pageSize).ToArray(),
      ItemCount = items.Count,
      PageIndex = pageIndex,
      PageSize = pageSize,
      PageCount = (int) Math.Ceiling((double) items.Count / pageSize),
   };
   public static PageDTO<V> Of<V> (ICollection<V> items, int pageIndex, int pageSize, int totalCount) => new()
   {
      Items = items.Paging(pageIndex, pageSize).ToArray(),
      ItemCount = items.Count,
      PageIndex = pageIndex,
      PageSize = pageSize,
      PageCount = (int) Math.Ceiling((double) totalCount / pageSize),
   };
}
