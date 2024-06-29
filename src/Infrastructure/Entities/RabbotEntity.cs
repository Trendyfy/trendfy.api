using Music.IO.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music.IO.Data.Entities
{
    public abstract class MusicEntity : IMusicEntity
    {
        public bool Active { get; set; } = true;
        public EntityAuditInfo AuditInfo { get; set; } = new EntityAuditInfo();
    }
}
