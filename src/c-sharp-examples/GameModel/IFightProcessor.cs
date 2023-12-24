using GameModel.Models;

namespace GameModel;

public interface IFightProcessor
{
    public Fight ProcessFight(Character attacker, Character defender);
}