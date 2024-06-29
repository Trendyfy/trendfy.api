using System;
using System.Collections.Generic;
using System.Text;

namespace Music.IO.Data.Entities.Interfaces
{
    public interface ITenant : IBaseEntity
    {
        string Name { get; set; }
        int? LegacyId { get; set; }
    }
}
