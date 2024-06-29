using Rabbot.Jedi.Data.Entities.Interfaces;

namespace Rabbot.Jedi.Data.Entities
{
    public abstract class BaseEntityReference<TEntity, TKey> : IBaseReferenceEntity<TEntity, TKey>
        where TEntity : IBaseEntity
        where TKey : class
    {
        public TKey? Id { get; set; }

    }

    public abstract class EntityReference<TEntity, TKey> : IReferenceEntity<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : class
    {
        public TKey? Id { get; set; }
    }

}
