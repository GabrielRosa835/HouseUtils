namespace HouseUtils.Domain;

public interface IEntity
{
   object Pk { get; }
}

public interface IEntity<TId> : IEntity
{
    new TId Pk { get; }
}
