using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyGames.API.DTOs;
using PartyGames.Engine.Services;

namespace PartyGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LobbyService _lobbyService;

        public GameController(IMapper mapper, LobbyService lobbyService)
        {
            _mapper = mapper;
            _lobbyService = lobbyService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string gameName)
        {
            _lobbyService.CreateGame(gameName);

            return Ok();
        }

        [HttpPost("join")]
        public async Task<IActionResult> Join(Guid gameId, Guid playerId)
        {
            _lobbyService.JoinGame(gameId, playerId);

            return Ok();
        }

        [HttpGet("getGames")]
        public async Task<IActionResult> GetGames()
        {
            return Ok(
                _mapper.Map<List<GameDto>>(_lobbyService.GetGames())
                );
        }

        [HttpGet("getGame/{gameId}")]
        public async Task<IActionResult> GetGame(Guid gameId)
        {
            return Ok(
                _lobbyService.GetGameById(gameId)
                );
        }
    }
}
