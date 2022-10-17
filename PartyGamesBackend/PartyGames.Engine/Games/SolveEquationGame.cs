using AutoMapper;
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

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private List<Player> Players { get; set; } = new List<Player>();

        public SolveEquationGame(string name)
        {
            Id = new Guid();
            Name = name;
        }

        public List<Player> GetPlayers()
        {
            return Players.ToList();
        }

        public void AddPlayer(Player player)
        {
            if(Players.Contains(player))
            {
                throw new ArgumentException("The game already contains this player");
            }

            Players.Add(player);
        }
    }
}
