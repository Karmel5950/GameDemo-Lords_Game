
using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.AISystem
{

    public class NormalBattleAI : BaseBattleAI
    {
        private static NormalBattleAI? _instance = null;
        public static NormalBattleAI Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new NormalBattleAI();
                return _instance;
            }
        }

        private NormalBattleAI()
        {

        }
        
        public void Action(BattleUnit battleUnit)
        {
            if (battleUnit.EnemyList.Count <= 0)
            {
                
            }
            
            ChangeTarget(battleUnit);

            if (battleUnit.ActionValue < SystemConstants.ActionValueMax)
            {
                battleUnit.ActionValue += battleUnit.ActionSpeed / SystemConstants.GameFramePerSecond;
            }
            else
            {
                battleUnit.Action();
                battleUnit.ActionValue = 0;
            }
        }

        public void ChangeTarget(BattleUnit battleUnit){
            if (battleUnit.Target == null)
            {
                battleUnit.Target = battleUnit.EnemyList[new System.Random().Next(0, battleUnit.EnemyList.Count)];
            }
        }

        public override void Action(object instance)
        {
            throw new NotImplementedException();
        }
    }



}