﻿namespace PartyGames.API.DTOs.Player
{
    public class Player_LoginDto
    {
        public string Name { get; set; }

        public Player_LoginDto(string name)
        {
            Name = name;
        }
    }
}
