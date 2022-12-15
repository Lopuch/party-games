using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.API.DTOs.Player
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
    }
}
