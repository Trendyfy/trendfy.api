using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbot.Jedi.Data.Entities.Interfaces;

namespace Rabbot.Jedi.Data.Entities
{
    public abstract class Entity<TKey> : RabbotEntity, IEntity<TKey>
        where TKey : class
    {
        public TKey? Id { get; set; }
        public TenantReference Tenant { get; set; } = new TenantReference();
    }

    public abstract class Entity : RabbotEntity, IEntity<string>
    {
        public Entity()
        {
        }
        public string? Id { get; set; }
        public TenantReference Tenant { get; set; } = new TenantReference();
    }
}
