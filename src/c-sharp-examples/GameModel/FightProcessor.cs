using GameModel.Models;

namespace GameModel;

public interface IFightProcessor
{
    public Fight ProcessFight(Character attacker, Character defender);
}

public class FightProcessor : IFightProcessor
{
    public Fight ProcessFight(Character attacker, Character defender)
    {
        var fight = new ActiveFight(attacker, defender);

        do
        {
            fight.MakeTurn();
        } while (!fight.IsFinished);

        return fight.GetResult();
    }
    
    private class ActiveFight
    {
        public ActiveFight(Character attacker, Character defender)
        {
            AttackerHp = attacker.Hp;
            DefenderHp = defender.Hp;
            _attacker = attacker;
            _defender = defender;
        }

        private readonly Character _attacker;

        private readonly Character _defender;
        private long AttackerHp { get; set; }
        private long DefenderHp { get; set; }
        
        public bool IsFinished => AttackerHp <= 0 || DefenderHp <= 0;

        public Fight GetResult()
        {
            if (AttackerHp <= 0 && DefenderHp <= 0)
                return new Fight(_attacker, _defender, FightResult.Draw, DateTime.UtcNow);
            if (AttackerHp <= 0)
                return new Fight(_attacker, _defender, FightResult.FirstDead, DateTime.UtcNow);
            if (DefenderHp <= 0)
                return new Fight(_attacker, _defender, FightResult.SecondDead, DateTime.UtcNow);
            
            throw new Exception("unexpected");
        }
        
        public void MakeTurn()
        {
            DefenderHp -= CalcDamage(_attacker.Damage, _defender.Armour);
            AttackerHp -= CalcDamage(_defender.Damage, _attacker.Armour);
        }

        private long CalcDamage(uint baseDamage, uint armour) 
            => uint.Clamp(baseDamage - armour, 0, baseDamage);
    }
}