using HouseUtils.Domain;
using HouseUtils.Domain.Models;

namespace HouseUtils.Application.Data;

public interface IApplicationDbContext : IDisposable
{
   public IEntityContext<UnitOfMeasureType> UnitOfMeasureTypes { get; }
   public IEntityContext<UnitOfMeasure> UnitsOfMeasure { get; }
   public IEntityContext<RecipeStep> RecipeSteps { get; }
   public IEntityContext<Ingredient> Ingredients { get; }
   public IEntityContext<Resource> Resources { get; }
   public IEntityContext<Storage> Storage { get; }
   public IEntityContext<Recipe> Recipes { get; }
   public IEntityContext<Tag> Tags { get; }

   public int Save ();

   public void Add (IEntity entity);
   public void AddRange(IEnumerable<IEntity> entities);
   public void Remove (IEntity entity);
   public void RemoveRange(IEnumerable<IEntity> entities);
   public void Update (IEntity entity);
   public void UpdateRange (IEnumerable<IEntity> entities);
   public void Attach (IEntity entity);
   public void AttachRange(IEnumerable<IEntity> entities);
   public void Dettach (IEntity entity);
   public void DettachRange(IEnumerable<IEntity> entities);
}
