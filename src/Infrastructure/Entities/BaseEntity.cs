using Music.IO.Data.Entities.Interfaces;

namespace Music.IO.Data.Entities
{
    public abstract class BaseEntity<TKey> : MusicEntity, IBaseEntity<TKey>
        where TKey : class
    {
        public TKey? Id { get; set; }
    }

    public abstract class BaseEntity : MusicEntity, IBaseEntity<string>
    {
        public string? Id { get; set; }
    }

}
