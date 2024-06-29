namespace Music.IO.Data.Repository
{
    public interface IDataContext
    {
        string ConnectionString { get; }
        bool CheckConnection();
    }
}
