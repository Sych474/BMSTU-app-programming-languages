using GameModel;
using GameModel.Models;

namespace GameDatabase.DbModels;

public class FightDbModel
{
    public int Id { get; set; }
    public int AttackerId { get; set; }
    public int DefenderId { get; set; }
    public CharacterDbModel? Attacker { get; set; }
    public CharacterDbModel? Defender { get; set; }
    public FightResult Result { get; set; }
    
    public DateTime Time { get; set; }
}