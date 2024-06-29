using Rabbot.Jedi.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbot.Jedi.Data.Entities
{
    public abstract class RabbotEntity : IRabbotEntity
    {
        public bool Active { get; set; } = true;
        public EntityAuditInfo AuditInfo { get; set; } = new EntityAuditInfo();
    }
}
