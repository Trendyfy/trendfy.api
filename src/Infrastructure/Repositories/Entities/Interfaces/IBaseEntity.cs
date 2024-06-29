using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbot.Jedi.Data.Entities.Interfaces
{
    public interface IBaseEntity<TKey> : IRabbotEntity
        where TKey : class
    {
        TKey? Id { get; set; }
    }

    public interface IBaseEntity : IBaseEntity<string>
    {

    }

}
