using HouseUtils.Domain;

namespace HouseUtils.Application.Data;

public interface IEntityContext<TEntity> : IApplicationDbContext where TEntity : class, IEntity
{
   public IQueryable<TEntity> Set { get; }
}