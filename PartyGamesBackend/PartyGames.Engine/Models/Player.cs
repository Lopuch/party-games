using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.Engine.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public Player(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
