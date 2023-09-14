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

        private ActionWait(){
            Name = "Wait";
            Description = "Waitting";
            CoolDown = 0;
            ExecuteNeedTime = 0;
        }

        public override void Execute(IActionable actionExcutor)
        {
            throw new NotImplementedException();
        }
    }


}