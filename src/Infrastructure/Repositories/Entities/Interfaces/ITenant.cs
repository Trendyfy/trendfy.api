using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbot.Jedi.Data.Entities.Interfaces
{
    public interface ITenant : IBaseEntity
    {
        string Name { get; set; }
        int? LegacyId { get; set; }
    }
}
