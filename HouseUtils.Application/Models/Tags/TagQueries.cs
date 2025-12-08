using HouseUtils.Application.Data;
using HouseUtils.Domain.Models;

namespace HouseUtils.Application.Models.Tags;

public static class TagQueries
{
   public static Tag? FindById(this IEntityContext<Tag> context, int id)
   {
      return context.Set.SingleOrDefault(t => t.Id == id);
   }
   public static bool ExistsByName(this IEntityContext<Tag> context, string name)
   {
      return context.Set.Any(t => t.Name == name);
   }
}
