namespace ApplicationLayer.ActionSystem
{
    public class ActionSystem
    {
        private static ActionSystem? _instance = null;
        public Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        public static ActionSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new ActionSystem();
                return _instance;
            }
        }
       
        public delegate void OnSystemInit();
        public event OnSystemInit? OnSystemInitEvent;

        private ActionSystem(){
            Init();
        }

        private void Init(){
            if (OnSystemInitEvent != null)
            {
                OnSystemInitEvent();
            }
        }

    }
}