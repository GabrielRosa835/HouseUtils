using HouseUtils.Domain;

namespace HouseUtils.Application.Persistence;

public static class EntityRepository
{
   public static TEntity? Find<TEntity, TId>(this IEntityContext<TEntity, TId> context, TId pk) 
      where TEntity : class, IEntity<TId> where TId : notnull
   {
      return context.Set.FirstOrDefault(e => e.Pk.Equals(pk));
   }
   public static ICollection<TEntity> FindRange<TEntity, TId> (this IEntityContext<TEntity, TId> context, ICollection<TId> pks)
      where TEntity : class, IEntity<TId> where TId : notnull
   {
      return context.Set.Where(e => pks.Contains(e.Pk)).ToList();
   }
}