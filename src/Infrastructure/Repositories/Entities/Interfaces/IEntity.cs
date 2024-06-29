using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbot.Jedi.Data.Entities.Interfaces
{

    public interface IEntity<TKey> : IRabbotEntity
        where TKey : class
    {
        TKey? Id { get; set; }
        TenantReference Tenant { get; }
    }

    public interface IEntity : IEntity<string>
    {
    }

}
