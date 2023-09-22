namespace ApplicationLayer.InitializationSystem
{
    public class InitializationSystem
    {
        private static InitializationSystem _instance = new InitializationSystem();
        public static InitializationSystem Instance { get { return _instance; } }
        private InitializationSystem() { }



    }
}