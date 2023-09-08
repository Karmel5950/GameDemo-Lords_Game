namespace CodeTemplate{
    class Singlton{
        private static Singlton? _instance = null;
        public static Singlton Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new Singlton();
                return _instance;
            }
        }

        private Singlton(){
            
        }


    }




}