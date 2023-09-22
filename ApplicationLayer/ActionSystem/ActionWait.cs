using System.Diagnostics;
using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.ActionSystem
{
    public class ActionWait : Action
    {
        private static ActionWait? _instance = null;
        public static ActionWait Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new ActionWait();
                return _instance;
            }
        }

        private ActionWait():base("Wait"){
            Description = "Waitting";
            CoolDown = 0;
            PreparationDuration = 0;
        }

        public override void Execute(ActionExcutor actionExcutor)
        {
            Debug.Print(actionExcutor.Actor.GetName() + " is waiting");
        }


        public override void InitActorNeededInterface()
        {
            
        }

        public override void InitTargetNeededInterface()
        {
            
        }
    }


}