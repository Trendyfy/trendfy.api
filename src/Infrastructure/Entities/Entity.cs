using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.IO.Data.Entities.Interfaces;

namespace Music.IO.Data.Entities
{
    public abstract class Entity<TKey> : MusicEntity, IEntity<TKey>
        where TKey : class
    {
        public TKey? Id { get; set; }
        public TenantReference Tenant { get; set; } = new TenantReference();
    }

    public abstract class Entity : MusicEntity, IEntity<string>
    {
        public Entity()
        {
        }
        public string? Id { get; set; }
        public TenantReference Tenant { get; set; } = new TenantReference();
    }
}
