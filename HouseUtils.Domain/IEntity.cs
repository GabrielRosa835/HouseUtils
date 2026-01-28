namespace HouseUtils.Domain;

public interface IEntity
{
   object Pk { get; }
}

public interface IEntity<out TId> : IEntity where TId : notnull
{
    new TId Pk { get; }
    object IEntity.Pk => Pk;
}
