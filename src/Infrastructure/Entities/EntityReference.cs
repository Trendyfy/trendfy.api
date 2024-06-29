using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Music.IO.Core.Misc;
using Music.IO.Data.Entities.Interfaces;

namespace Music.IO.Data.Entities
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
