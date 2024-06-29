
//using ComposerManager.Models;
//using MusicManager.Repository;

//namespace MusicManager.Services
//{
//    public class MusicService : IMusicService
//    {
//        private readonly IMusicRepository _musicRepository;

//        public MusicService(IMusicRepository musicRepository)
//        {
//            _musicRepository = musicRepository;
//        }

//        public Music GetMusicById(Guid id)
//        {
//            return _musicRepository.GetMusicById(id);
//        }

//        public IEnumerable<Music> GetAllMusics()
//        {
//            return _musicRepository.GetAllMusics();
//        }

//        public void CreateMusic(Music music)
//        {
//            music.MusicId = Guid.NewGuid();
//            music.UploadedAt = DateTime.Now;
//            _musicRepository.AddMusic(music);
//        }

//        public void UpdateMusic(Music music)
//        {
//            _musicRepository.UpdateMusic(music);
//        }

//        public void DeleteMusic(Guid id)
//        {
//            _musicRepository.DeleteMusic(id);
//        }
//    }
//}
