namespace ApplicationLayer.ActionSystem
{
    public class ActionExcutor
    {
        public Action action;
        public ActionStage stage = ActionStage.PREPARATION;
        public double ExcuteProgressValue;
        public double ExcuteProgressMax;
        public IActionable Actor; 
        public object? Target;

        public ActionExcutor(IActionable actionable)
        {
            action = ActionWait.Instance;
            Actor = actionable;
        }

        public void Excute()
        {
            if (ExcuteProgressValue < ExcuteProgressMax)
            {
                ExcuteProgressValue += Actor.GetActionSpeed() / SystemConstants.GameFramePerSecond;
            }
            else
            {
                action.Execute(this);
                ExcuteProgressValue = 0;
            }
        }

        public void SetAction(Action action)
        {
            if (action.CheckActorNeededInterface(Actor))
            {
                this.action = action;
                ExcuteProgressValue = 0;
                ExcuteProgressMax = action.PreparationDuration;
            }
        }


    }
}