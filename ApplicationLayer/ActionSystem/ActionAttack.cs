namespace ApplicationLayer.ActionSystem
{
    public class ActionAttack : Action
    {
        private static ActionAttack? _instance = null;
        public static ActionAttack Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new ActionAttack();
                return _instance;
            }
        }

        private ActionAttack(){
            Name = "Attack";
            Description = "A Normal Attack";
            CoolDown = 0;
            ExecuteNeedTime = 1000;
        }

        public override void Execute(IActionable actionExcutor)
        {
            throw new NotImplementedException();
        }
    }


}