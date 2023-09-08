namespace ApplicationLayer
{
    public abstract class BaseBattleAI
    {
        public abstract void Action(BattleUnit battleUnit);
    }

    public  class NormalBattleAI : BaseBattleAI
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

        private NormalBattleAI(){
            
        }

        public override void Action(BattleUnit battleUnit){
            if (battleUnit.target == null)
            {
                battleUnit.target = battleUnit.enemyList[new System.Random().Next(0, battleUnit.enemyList.Count)];
            }

            if (battleUnit.actionValue < SystemConstants.ActionValueMax)
            {
                battleUnit.actionValue += battleUnit.actionSpeed/SystemConstants.GameFramePerSecond;
            }else
            {
                battleUnit.Action();
                battleUnit.actionValue = 0;
            }
        }
    }



}