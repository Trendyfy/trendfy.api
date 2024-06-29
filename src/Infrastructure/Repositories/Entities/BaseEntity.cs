using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rabbot.Jedi.Data.Entities.Interfaces;

namespace Rabbot.Jedi.Data.Entities
{
    public abstract class BaseEntity<TKey> : RabbotEntity, IBaseEntity<TKey> 
        where TKey : class
    {
        public TKey? Id { get; set; }
    }

    public abstract class BaseEntity : RabbotEntity, IBaseEntity<string>
    {
        public string? Id { get; set; }
    }

}
