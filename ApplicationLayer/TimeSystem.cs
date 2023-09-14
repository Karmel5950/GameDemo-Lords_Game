namespace ApplicationLayer
{
    public class TimeSystem
    {
        private static TimeSystem? _instance = null;
        public static TimeSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new TimeSystem();
                return _instance;
            }
        }
        public double TimeScale { get; set; } = 1;
        public double GameTime { get; set; } = 0;
        private TimeSystem()
        {

        }

    }
}