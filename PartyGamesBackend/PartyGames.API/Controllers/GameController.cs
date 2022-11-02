using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyGames.API.DTOs;
using PartyGames.API.DTOs.Game;
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
        public async Task<IActionResult> Create(Game_CreateDto gameDto)
        {
            return Ok(
                _mapper.Map<GameDto>(_lobbyService.CreateGame(gameDto.Name))
                );
        }

        [HttpPost("join")]
        public async Task<IActionResult> Join(Game_JoinDto gameDto)
        {
            _lobbyService.JoinGame(gameDto.GameId, gameDto.PlayerId);

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
                _mapper.Map<GameDto>(
                    _lobbyService.GetGameById(gameId)
                    )
                );
        }

        [HttpPost("startGame")]
        public async Task<IActionResult> StartGame(Game_StartDto dto)
        {
            _lobbyService.StartGame(dto.GameId, dto.PlayerId);

            return Ok();
        }
    }
}
