using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyGames.API.DTOs
{
    public class GameDto
    {
        public string? Name { get; set; }
        public Guid Id { get; set; }
    }
}
