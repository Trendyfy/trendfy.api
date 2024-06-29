using System;

namespace Rabbot.Jedi.Data.Entities.Interfaces
{
    public interface IEntityAuditInfo
    {
        EntityAuditData? Created { get; set; }
        EntityAuditData? Updated { get; set; }
        EntityAuditData? Deleted { get; set; }
    }
    public interface IEntityAuditData
    {
        DateTime At { get; set; }
        string By { get; set; }
        string UserName { get; set; }
    }
}