using HouseUtils.Application.Persistence;
using HouseUtils.Domain;
using HouseUtils.Domain.Models;
using HouseUtils.Infrastructure.Persistence.Tables;
using HouseUtils.Shared.Extensions;

using Microsoft.EntityFrameworkCore;

namespace HouseUtils.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, 
   IApplicationDbContext,
   IEntityContext<UnitOfMeasureType>,
   IEntityContext<UnitOfMeasure>,
   IEntityContext<RecipeStep>,
   IEntityContext<Ingredient>,
   IEntityContext<Resource>,
   IEntityContext<Storage>,
   IEntityContext<Recipe>,
   IEntityContext<Tag>
{
   protected override void OnModelCreating (ModelBuilder builder)
   {
      builder.ApplyConfiguration(new UnitOfMeasureTypeTable());
      builder.ApplyConfiguration(new UnitOfMeasureTable());
      builder.ApplyConfiguration(new RecipeStepTable());
      builder.ApplyConfiguration(new IngredientTable());
      builder.ApplyConfiguration(new ResourceTable());
      builder.ApplyConfiguration(new StorageTable());
      builder.ApplyConfiguration(new RecipeTable());
      builder.ApplyConfiguration(new TagTable());
      base.OnModelCreating(builder);
   }
   protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlite("Data Source=houseutils.db");
      base.OnConfiguring(optionsBuilder);
   }

   public override int SaveChanges ()
   {
      int changes = base.SaveChanges();
      DettachAll();
      return changes;
   }

   private void DettachAll()
   {
      foreach(var entry in ChangeTracker.Entries())
      {
         entry.State = EntityState.Detached;
      }
   }

   #region Implementations
   int IApplicationDbContext.Save () => base.SaveChanges();
   public void Add (IEntity entity) => base.Add(entity);
   public void AddRange (IEnumerable<IEntity> entities) => base.AddRange(entities);
   public void Remove (IEntity entity) => base.Remove(entity);
   public void RemoveRange (IEnumerable<IEntity> entities) => base.RemoveRange(entities);
   public void Update (IEntity entity) => base.Update(entity);
   public void UpdateRange (IEnumerable<IEntity> entities) => base.UpdateRange(entities);
   public void Attach (IEntity entity) => base.Attach(entity);
   public void AttachRange (IEnumerable<IEntity> entities) => base.AttachRange(entities);
   public void Dettach (IEntity entity) => Entry(entity).State = EntityState.Detached;
   public void DettachRange (IEnumerable<IEntity> entities) => entities.ForEach(Dettach);
   #endregion

   #region Contexts
   public IEntityContext<UnitOfMeasureType> UnitOfMeasureTypes => this;
   public IEntityContext<UnitOfMeasure> UnitsOfMeasure => this;
   public IEntityContext<RecipeStep> RecipeSteps => this;
   public IEntityContext<Ingredient> Ingredients => this;
   public IEntityContext<Resource> Resources => this;
   public IEntityContext<Storage> Storage => this;
   public IEntityContext<Recipe> Recipes => this;
   public IEntityContext<Tag> Tags => this;
   #endregion

   #region Sets
   IQueryable<UnitOfMeasureType> IEntityContext<UnitOfMeasureType>.Set => Set<UnitOfMeasureType>().AsNoTracking();
   IQueryable<UnitOfMeasure> IEntityContext<UnitOfMeasure>.Set => Set<UnitOfMeasure>().AsNoTracking();
   IQueryable<RecipeStep> IEntityContext<RecipeStep>.Set => Set<RecipeStep>().AsNoTracking();
   IQueryable<Ingredient> IEntityContext<Ingredient>.Set => Set<Ingredient>().AsNoTracking();
   IQueryable<Resource> IEntityContext<Resource>.Set => Set<Resource>().AsNoTracking();
   IQueryable<Storage> IEntityContext<Storage>.Set => Set<Storage>().AsNoTracking();
   IQueryable<Recipe> IEntityContext<Recipe>.Set => Set<Recipe>().AsNoTracking();
   IQueryable<Tag> IEntityContext<Tag>.Set => Set<Tag>().AsNoTracking();
   #endregion
}
