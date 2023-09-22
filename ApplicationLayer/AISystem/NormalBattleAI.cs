
using ApplicationLayer.ActionSystem;
using ApplicationLayer.BattleSystem;
using ApplicationLayer.EntitySystem;

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
            //interfaceTypes.Append<Type>(IBaseBattleCharacter.Type);
        }
        
        private void Action(BattleUnit battleUnit)
        {
            ActionExcutor ae = battleUnit.BattleCharacter.GetActionExcutor();
            if (battleUnit.EnemyList.Count <= 0)
            {
                ae.SetAction(ActionWait.Instance);
                return;
            }
            
            ChangeTarget(battleUnit);

            if (ae.action == ActionWait.Instance)
            {
                ae.SetAction(ActionAttack.Instance);
            }
            
            ae.Excute();
        }

        public void ChangeTarget(BattleUnit battleUnit){
            ActionExcutor ae = battleUnit.BattleCharacter.GetActionExcutor();
            if (ae.Target == null)
            {
                ae.Target = battleUnit.EnemyList[new System.Random().Next(0, battleUnit.EnemyList.Count)];
            }
        }

        public override void Action(object instance)
        {
            throw new NotImplementedException();
        }
    }



}