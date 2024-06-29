namespace Rabbot.Jedi.Data.Entities.Interfaces
{
    public interface IRabbotEntity
    {
        bool Active { get; set; }
        EntityAuditInfo AuditInfo { get; }
    }

}
