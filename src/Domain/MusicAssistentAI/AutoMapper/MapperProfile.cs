using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models.AI;
using MusicAssistentAI.Models.AI;
using MusicManager.Models;

namespace MusicAssistentAI.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateMusicRequest, AIComposeSimple>().ReverseMap();
            CreateMap<CreateMusicRequest, AIComposeCustom>().ReverseMap();

            CreateMap<MusicResponse, AIMusicTrackResponse>().ReverseMap();

            CreateMap<MusicResponse, Music>().ReverseMap();
        }
    }
}
