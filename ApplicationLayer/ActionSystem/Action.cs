using GsUtil;

namespace ApplicationLayer.ActionSystem
{
    public abstract class Action
    {
        public string Name = "DEFUALT";
        public string Description = "DEFUALT";
        public double CoolDown = 0;
        public bool InterruptionAllowedDuringPreparationStage = false;
        public bool InterruptionAllowedDuringExecutionStage = false;
        public bool InterruptionAllowedDuringCompletionStage = false;
        //时间单位为毫秒
        public double PreparationDuration = 0;
        public double ExecutionDuration = 0;
        public double CompletionDuration = 0;
        public Type[] ActorNeededInterfaces { get; } = new Type[0];
        public Type[] TargetNeededInterfaces { get; } = new Type[0];
        public Action(string name)
        {
            Name = name;
            InitActorNeededInterface();
            Register();
        }

        public void Register()
        {
            ActionSystem.Instance.Actions.Add(Name, this);
        }

        public abstract void Execute(ActionExcutor actionExcutor);
        public abstract void InitActorNeededInterface();
        public bool CheckActorNeededInterface(IActionable actor)
        {
            return CommonUtil.CheckInterfacesImplementation(actor, ActorNeededInterfaces);
        }
        public bool CheckActorNeededInterface(ActionExcutor actionExcutor)
        {
            return CheckActorNeededInterface(actionExcutor.Actor);
        }

        public abstract void InitTargetNeededInterface();
        public bool CheckTargetNeededInterface(IActionable actor)
        {
            return CommonUtil.CheckInterfacesImplementation(actor, TargetNeededInterfaces);
        }
        public bool CheckTargetNeededInterface(ActionExcutor actionExcutor)
        {
            return CheckActorNeededInterface(actionExcutor.Actor);
        }
    }

    public enum ActionStage
    {
        PREPARATION,
        EXECUTION,
        COMPLETION
    }

}