using ApplicationLayer.AISystem;
using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.DataSystem
{
    public class BaseBattleCharacter : BaseCharacter, IBattlable
    {
        public BattleUnit battleUnit;
        public BaseBattleAI battleAI = NormalBattleAI.Instance;
        public BaseBattleCharacter()
        {
            battleUnit = new BattleUnit(this);
        }

        public BaseBattleAI GetBattleAI()
        {
            return battleAI;
        }

        public BattleUnit GetBattleUnit()
        {
            return battleUnit;
        }

        bool IBattlable.IsAlive()
        {
            if (HealthPoints <= 0)
            {
                return false;
            }
            return true;
        }
    }
}