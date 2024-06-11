using ComposerManager.Models;

namespace MusicManager.Repository
{
    public interface IMusicRepository
    {
        Music GetMusicById(Guid id);
        IEnumerable<Music> GetAllMusics();
        void AddMusic(Music music);
        void UpdateMusic(Music music);
        void DeleteMusic(Guid id);
        void UploadMusic(Music music);
    }
}
