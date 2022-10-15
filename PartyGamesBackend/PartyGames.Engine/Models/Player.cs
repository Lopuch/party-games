using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    internal class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Player(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
