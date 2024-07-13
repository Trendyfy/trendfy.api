using Infrastructure.Models.AI;
using MusicAssistentAI.Models.AI;

namespace Infrastructure.HttpClients.Interfaces
{
    public interface ISunoClient
    {
        Task<List<AIMusicTrackResponse>> GenerateSimpleTrackAsync(AIComposeSimple prompt, CancellationToken cancellationToken);
        Task<List<AIMusicTrackResponse>> GenerateCustomTrackAsync(AIComposeCustom prompt, CancellationToken cancellationToken);
        Task<AIMusicTrackResponse> GetMusicByIdAsync(string id, CancellationToken cancellationToken);
        Task<ChatCompletion> ComposeLyricAsync(string prompt, CancellationToken cancellationToken);

    }
}
