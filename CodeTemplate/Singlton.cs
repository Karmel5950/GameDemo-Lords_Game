namespace CodeTemplate
{
    public sealed class SingletonLazy
    {
        private static volatile SingletonLazy? instance = null;
        private static readonly object locker = new object();

        private SingletonLazy() { }

        public static SingletonLazy GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLazy();
                    }
                }
            }
            return instance;
        }
    }

    public sealed class SingletonHungry
    {
        private static SingletonHungry _instance = new SingletonHungry();
        public static SingletonHungry Instance { get { return _instance; } }
        private SingletonHungry() { }
    }

}