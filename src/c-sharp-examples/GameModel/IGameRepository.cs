using GameModel.Models;

namespace GameModel;

public interface IGameRepository
{
    Task<int> AddFightAsync(Fight fight);
    Task<int> AddCharacterAsync(Character character);
    Task DeleteCharacterAsync(int characterId);
    Task<Character?> GetCharacterByIdAsync(int id);
    Task<List<Character>> GetAllCharactersAsync();
    Task<List<Fight>> GetFightsWithFiltersAsync(int? attackerId = null, int? defenderId = null);
}