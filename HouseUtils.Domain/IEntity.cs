namespace HouseUtils.Domain;

public interface IEntity
{
   object Pk { get; }
}

public interface IEntity<TId> : IEntity where TId : notnull
{
    new TId Pk { get; }
}
