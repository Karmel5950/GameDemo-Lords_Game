namespace ApplicationLayer.ActionSystem
{
    public class ActionExcutor
    {
        public Action action;
        public double ExcuteProgressValue;
        public double ExcuteProgressMax;
        
        public ActionExcutor()
        {
            action = ActionWait.Instance;
        }

        public void Excute()
        {
            
        }




    }
}