using AutoMapper;
using PartyGames.API.DTOs;
using PartyGames.Engine.Models;

namespace PartyGames.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IGame, GameDto>();
        }
    }
}
