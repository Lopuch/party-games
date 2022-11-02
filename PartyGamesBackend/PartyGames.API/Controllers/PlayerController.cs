using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyGames.API.DTOs.Player;
using PartyGames.Engine.Services;

namespace PartyGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PlayerService _playerService;

        public PlayerController(IMapper mapper, PlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Player_LoginDto playerLogin)
        {
            return Ok(
                _mapper.Map<PlayerDto>(
                    _playerService.Login(playerLogin.Name)
                    ));
        }

        [HttpPost("relogin")]
        public async Task<IActionResult> Relogin(Player_ReloginDto dto)
        {
            return Ok(
                _mapper.Map<PlayerDto>(
                    _playerService.ReLogin(dto.Name, dto.Id)
                    ));
        }
    }
}
