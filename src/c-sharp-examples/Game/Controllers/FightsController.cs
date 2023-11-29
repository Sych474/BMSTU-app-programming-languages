using GameModel;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FightsController : ControllerBase
{
    private readonly IGameRepository _gameRepository;
    private readonly IFightProcessor _processor;

    public FightsController(IGameRepository gameRepository, IFightProcessor processor)
    {
        _gameRepository = gameRepository;
        _processor = processor;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetFights([FromQuery] int? attackerId, [FromQuery] int? defenderId)
    {
        var fights = await _gameRepository.GetFightsWithFiltersAsync(attackerId, defenderId);
        return Ok(fights);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> StartFight([FromBody] StartFightDto dto)
    {
        var attacker = await _gameRepository.GetCharacterByIdAsync(dto.AttackerId);
        if (attacker is null)
            return NotFound(dto.AttackerId);
        var defender = await _gameRepository.GetCharacterByIdAsync(dto.DefenderId);
        if (defender is null)
            return NotFound(dto.DefenderId);

        var fight = _processor.ProcessFight(attacker, defender);

        return Ok(await _gameRepository.AddFightAsync(fight));
    }
}