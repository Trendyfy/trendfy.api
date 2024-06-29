using Music.IO.Data.Entities.Interfaces;
using Music.IO.UserContext;
using System;

namespace Music.IO.Data.Entities
{
    public class EntityAuditInfo : IEntityAuditInfo
    {
        public EntityAuditData? Created { get; set; }
        public EntityAuditData? Updated { get; set; }
        public EntityAuditData? Deleted { get; set; }
    }
    public class EntityAuditData : IEntityAuditData
    {
        public EntityAuditData()
        {

        }
        public EntityAuditData(IUserContextAccessor accessor)
        {
            At = DateTime.Now.ToUniversalTime();
            By = $"{accessor.Name} <{accessor.Email}>";
            UserName = accessor.UserName;
        }
        public DateTime At { get; set; }
        public string By { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
