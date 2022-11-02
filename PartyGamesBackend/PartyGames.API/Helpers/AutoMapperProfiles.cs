﻿using AutoMapper;
using PartyGames.API.DTOs;
using PartyGames.API.DTOs.Player;
using PartyGames.Engine.Models;

namespace PartyGames.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IGame, GameDto>();
            CreateMap<Round, RoundDto>();
            CreateMap<RoundTitle, RoundTitleDto>();
            CreateMap<RoundOption, RoundOptionDto>();
            CreateMap<Player, PlayerDto>();
        }
    }
}
