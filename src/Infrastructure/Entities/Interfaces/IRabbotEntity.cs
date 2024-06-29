namespace Music.IO.Data.Entities.Interfaces
{
    public interface IMusicEntity
    {
        bool Active { get; set; }
        EntityAuditInfo AuditInfo { get; }
    }

}
