using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.IO.Data.Entities.Interfaces
{
    public interface IBaseEntity<TKey> : IMusicEntity
        where TKey : class
    {
        TKey? Id { get; set; }
    }

    public interface IBaseEntity : IBaseEntity<string>
    {

    }

}
