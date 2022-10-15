using AutoMapper;
using PartyGames.Engine.DTOs;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Helpers
{
    internal class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Player, PlayerDto>();
        }
    }
}
