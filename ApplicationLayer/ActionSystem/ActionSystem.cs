namespace ApplicationLayer.ActionSystem
{
    public class ActionManager
    {
        private static ActionManager? _instance = null;
        public Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        public static ActionManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new ActionManager();
                return _instance;
            }
        }
       
        public delegate void OnSystemInit();
        public event OnSystemInit? OnSystemInitEvent;

        private ActionManager(){
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