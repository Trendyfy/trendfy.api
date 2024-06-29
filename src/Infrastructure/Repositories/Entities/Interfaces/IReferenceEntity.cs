namespace Rabbot.Jedi.Data.Entities.Interfaces
{
    public interface IBaseReferenceEntity<TEntity, TKey>: IRabbotEntityReference
        where TEntity : IBaseEntity
        where TKey : class
    {
        TKey? Id { get; set; }
    }

    public interface IReferenceEntity<TEntity, TKey>: IRabbotEntityReference
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        TKey? Id { get; set; }
    }
}