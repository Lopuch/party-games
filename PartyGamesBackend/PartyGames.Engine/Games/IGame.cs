using PartyGames.Engine.DTOs;
using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Games
{
    internal interface IGame
    {
        string Name { get; }
        List<PlayerDto> GetPlayers();
    }
}
