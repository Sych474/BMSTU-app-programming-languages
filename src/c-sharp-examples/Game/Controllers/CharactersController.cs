using GameModel;
using GameModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public CharactersController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetCharacters()
    {
        var characters = await _gameRepository.GetAllCharactersAsync();
        return Ok(characters);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddCharacter([FromBody] Character character)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var id = await _gameRepository.AddCharacterAsync(character);
        return Ok(id);
    }
}