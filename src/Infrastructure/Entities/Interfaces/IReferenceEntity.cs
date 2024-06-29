namespace Music.IO.Data.Entities.Interfaces
{
    public interface IBaseReferenceEntity<TEntity, TKey>: IMusicEntityReference
        where TEntity : IBaseEntity
        where TKey : class
    {
        TKey? Id { get; set; }
    }

    public interface IReferenceEntity<TEntity, TKey>: IMusicEntityReference
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        TKey? Id { get; set; }
    }
}