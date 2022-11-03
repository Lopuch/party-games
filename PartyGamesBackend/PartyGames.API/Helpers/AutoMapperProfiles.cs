using AutoMapper;
using PartyGames.API.DTOs;
using PartyGames.API.DTOs.Player;
using PartyGames.Engine.Models;

namespace PartyGames.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IGame, GameDto>()
                .ForMember(dest => dest.GameState, opts => opts.MapFrom(src => src.GetGameState()))
                .ForMember(dest => dest.Players, opts => opts.MapFrom(src=>src.GetPlayers()))
                .ForMember(dest => dest.Round, opts => opts.MapFrom(src => src.GetRound()))
                ;
            CreateMap<Round, RoundDto>();
            CreateMap<RoundTitle, RoundTitleDto>();
            CreateMap<RoundOption, RoundOptionDto>();
            CreateMap<Player, PlayerDto>();
        }
    }
}
