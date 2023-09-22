namespace ApplicationLayer.ActionSystem
{
    public interface IActionable
    {
        public ActionExcutor GetActionExcutor();
        public string GetName();

        public double GetActionSpeed();

    }
}