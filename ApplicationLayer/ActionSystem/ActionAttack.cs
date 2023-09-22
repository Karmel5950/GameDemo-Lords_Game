using System.Diagnostics;
using ApplicationLayer.EntitySystem;

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

        private ActionAttack():base("Attack"){
            Description = "A Normal Attack";
            CoolDown = 0;
            PreparationDuration = 1000;
        }

        public override void Execute(ActionExcutor actionExcutor)
        {
            Debug.Print("Attack");
        }


        public override void InitActorNeededInterface()
        {
            ActorNeededInterfaces.Append(typeof(IBaseBattleCharacter));
        }

        public override void InitTargetNeededInterface()
        {
            throw new NotImplementedException();
        }
    }


}