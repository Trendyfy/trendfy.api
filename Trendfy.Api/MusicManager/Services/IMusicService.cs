using ComposerManager.Models;

namespace MusicManager.Services
{
    public interface IMusicService
    {
        Music GetMusicById(Guid id);
        IEnumerable<Music> GetAllMusics();
        void CreateMusic(Music music);
        void UpdateMusic(Music music);
        void DeleteMusic(Guid id);
    }
}
