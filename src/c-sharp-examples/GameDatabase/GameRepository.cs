using GameDatabase.DbModels;
using GameModel;
using GameModel.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDatabase;

public class GameRepository : IGameRepository
{
    private readonly GameDbContext _dbContext;

    public GameRepository(GameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddFightAsync(Fight fight)
    {
        var db = fight.ToDb();
        await _dbContext.Fights.AddAsync(db);
        await _dbContext.SaveChangesAsync();

        return db.Id;
    }

    public async Task<int> AddCharacterAsync(Character character)
    {
        var db = character.ToDb();
        await _dbContext.Characters.AddAsync(db);
        await _dbContext.SaveChangesAsync();

        return db.Id;    
    }

    public async Task DeleteCharacterAsync(int characterId)
    {
        var character = _dbContext.Characters.FirstOrDefault(x => x.Id == characterId);
        if (character != null)
        {
            _dbContext.Characters.Remove(character);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return (await _dbContext.Characters.FirstOrDefaultAsync(x => x.Id == id))?.ToModel();
    }

    public Task<List<Character>> GetAllCharactersAsync()
    {
        return _dbContext.Characters
            .Select(x => x.ToModel())
            .ToListAsync();
    }

    public Task<List<Fight>> GetFightsWithFiltersAsync(int? attackerId = null, int? defenderId = null)
    {
        var fights = _dbContext.Fights.AsQueryable();
        if (attackerId != null)
            fights = fights.Where(x => x.AttackerId == attackerId);
        if (defenderId != null)
            fights = fights.Where(x => x.DefenderId == defenderId);

        return fights
            .Include(x => x.Attacker)
            .Include(x => x.Defender)
            .Select(x => x.ToModel())
            .ToListAsync();
    }
    
}

public static class CharacterExtensions
{
    public static Character ToModel(this CharacterDbModel dbModel) =>
        new(dbModel.Id, dbModel.Name, dbModel.Hp, dbModel.Armor, dbModel.Damage);

    public static CharacterDbModel ToDb(this Character character)
        => new()
        {
            Id = character.Id,
            Name = character.Name, 
            Armor = character.Armour, 
            Hp = character.Hp, 
            Damage = character.Damage
        };
}

public static class FightsExtensions
{
    public static Fight ToModel(this FightDbModel dbModel)
        => new(dbModel.Id, dbModel.Attacker.ToModel(), dbModel.Defender.ToModel(), dbModel.Result, dbModel.Time);

    public static FightDbModel ToDb(this Fight fight)
        => new()
        {
            Id = fight.Id,
            AttackerId = fight.Attacker.Id,
            DefenderId = fight.Defender.Id,
            Time = fight.Time,
            Result = fight.Result
        };
}