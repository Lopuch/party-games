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
                //.ForMember(dest => dest.Results, opts => opts.MapFrom(src => src.GetResults()))
                .ForMember(dest => dest.LastResults, opts => opts.MapFrom(src => src.GetLastResults()))
                .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.GetGameType()))
                ;
            CreateMap<Round, RoundDto>();
            CreateMap<RoundTitle, RoundTitleDto>();
            CreateMap<RoundOption, RoundOptionDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Result, ResultDto>()
                .ForMember(dest => dest.PlayerName, opts => opts.MapFrom(src => src.Player.Name))
                ;
        }
    }
}
