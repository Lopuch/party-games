using PartyGames.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine
{

    public class PartyGamesEngine
    {
        internal List<IGame> Games { get; set; } = new List<IGame>();

        public PartyGamesEngine()
        {

        }
    }
}
    