namespace ApplicationLayer.InitializationManager
{
    public class InitializationManager
    {
        private static InitializationManager _instance = new InitializationManager();
        public static InitializationManager Instance { get { return _instance; } }
        private InitializationManager() { }



    }
}