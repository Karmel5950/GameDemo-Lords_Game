namespace ApplicationLayer.ActionSystem
{
    public abstract class Action
    {
        public string Name = "DEFUALT";
        public string Description = "DEFUALT";
        public double CoolDown = 0;
        //时间单位为毫秒
        public double ExecuteNeedTime = 0;

        public abstract void Execute(IActionable actionExcutor);

    }


}