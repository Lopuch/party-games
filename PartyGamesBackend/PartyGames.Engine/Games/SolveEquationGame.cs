using AutoMapper;
using PartyGames.Engine.DTOs;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Games
{
    internal class SolveEquationGame : IGame
    {
        private readonly Mapper _mapper;

        public string Name { get; private set; }

        private List<Player> Players { get; set; } = new List<Player>();

        public SolveEquationGame(Mapper mapper, string name)
        {
            _mapper = mapper;
            Name = name;
        }

        public List<PlayerDto> GetPlayers()
        {
            return _mapper.Map<List<PlayerDto>>(Players);
        }
    }
}
