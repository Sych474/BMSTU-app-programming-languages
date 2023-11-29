using GameModel;
using GameModel.Models;

namespace GameDatabase.DbModels;

public class CharacterDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public uint Hp { get; set; }
    public uint Armor { get; set; }
    public uint Damage { get; set; }
}