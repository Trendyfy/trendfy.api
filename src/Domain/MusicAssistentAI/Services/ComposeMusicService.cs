using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.HttpClients.Interfaces;
using Infrastructure.Models.AI;
using Infrastructure.Repositories;
using MusicAssistentAI.Interfaces;
using MusicAssistentAI.Models.AI;
using MusicManager.Models;

namespace MusicAssistentAI.Services
{
    public class ComposeMusicService : IComposeMusicService
    {
        private readonly ISunoClient _sunoClient;
        private readonly IMusicRepository _musicRepository;
        private readonly IMapper _mapper;
        public ComposeMusicService(IMusicRepository musicRepository, ISunoClient sunoClient, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _sunoClient = sunoClient;
            _mapper = mapper;
        }

        public async Task<List<MusicResponse>> CreateMusicAsync(CreateMusicRequest music, CancellationToken cancellationToken)
        {
            var aiReponse = new List<AIMusicTrackResponse>();
            if (!music.CustomMusic)
            {
                var customSimple = _mapper.Map<AIComposeSimple>(music);
                aiReponse = await _sunoClient.GenerateSimpleTrackAsync(customSimple, cancellationToken);
            }
            else
            {
                var customCompose = _mapper.Map<AIComposeCustom>(music);
                customCompose.Title = music.Title;
                var genresString = string.Join(", ", music.Genre);
                customCompose.Tags = string.IsNullOrEmpty(music.Mood.ToString())
                    ? genresString
                    : $"{genresString}, {music.Mood}";

                aiReponse = await _sunoClient.GenerateCustomTrackAsync(customCompose, cancellationToken);
            }

            var responseMapped = _mapper.Map<List<MusicResponse>>(aiReponse);
            await IndexMusic(responseMapped, cancellationToken);
            return responseMapped;
        }
        public async Task<MusicResponse> GetMusicByIdAsync(string id, CancellationToken cancellationToken)
        {
            var music = await _sunoClient.GetMusicByIdAsync(id, cancellationToken);
            return _mapper.Map<MusicResponse>(music);
        }

        public Task<(IEnumerable<Music> Hits, Dictionary<string, Dictionary<string, long>> Facets)> SearchMusicTracksAsync(string query, CancellationToken cancellationToken)
        {
            return _musicRepository.SearchMusicTracksAsync(query, cancellationToken);
        }      
        private async Task IndexMusic(List<MusicResponse> musicResponses, CancellationToken cancellationToken)
        {
            var entityMapped = _mapper.Map<List<Music>>(musicResponses);
            Parallel.ForEach(entityMapped, async entity =>
            {
                await _musicRepository.AddAsync(entity, cancellationToken);
            });
        }
    }
}
