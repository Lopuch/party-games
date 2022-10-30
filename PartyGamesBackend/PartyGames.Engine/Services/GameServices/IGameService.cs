using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Services.GameServices
{
    public interface IGameService
    {
        Round GenerateNextRound();
    }
}
