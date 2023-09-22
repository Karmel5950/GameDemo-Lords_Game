using ApplicationLayer.ActionSystem;
using ApplicationLayer.AISystem;
using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.EntitySystem
{
    public class BaseBattleCharacter : BaseCharacter, IBaseBattleCharacter
    {
        public BattleUnit battleUnit;
        public ActionExcutor actionExcutor;
        public double ActionSpeed = 1;
        public double AttackValue = 1;
        public BaseBattleAI battleAI = NormalBattleAI.Instance;
        public BaseBattleCharacter()
        {
            battleUnit = new BattleUnit(this);
            actionExcutor = new ActionExcutor(this);
        }

        public ActionExcutor GetActionExcutor()
        {
            return actionExcutor;
        }

        public double GetActionSpeed()
        {
            return ActionSpeed;
        }

        public double GetAttackValue()
        {
           return AttackValue;
        }

        public BaseBattleAI GetBattleAI()
        {
            return battleAI;
        }

        public BattleUnit GetBattleUnit()
        {
            return battleUnit;
        }

        public double GetHealthPoint()
        {
            return HealthPoints;
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