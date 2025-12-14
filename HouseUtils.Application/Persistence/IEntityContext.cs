using HouseUtils.Domain;

namespace HouseUtils.Application.Persistence;

public interface IEntityContext<TEntity> : IApplicationDbContext where TEntity : class, IEntity
{
   public IQueryable<TEntity> Set { get; }
}
public interface IEntityContext<TEntity, TId> : IEntityContext<TEntity> 
   where TEntity : class, IEntity<TId> where TId : notnull
{
   public new IQueryable<TEntity> Set { get; }
}
public static class EntityContextExtensions
{
   public static IEntityContext<TEntity, TId> WithId<TEntity, TId>(this IEntityContext<TEntity> context) 
      where TEntity : class, IEntity<TId> where TId : notnull
   {
      return (IEntityContext<TEntity, TId>) context;
   }
}
