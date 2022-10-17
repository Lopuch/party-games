using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login([FromBody]string name)
        {
            return Ok(_playerService.Login(name));
        }
    }
}
