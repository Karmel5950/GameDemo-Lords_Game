namespace ApplicationLayer{
    public abstract class Action
    {
        public string name = "DEFUALT";
        public string description = "DEFUALT";
        public double CoolDown = 0;




        public abstract BattleUnitStage GetStartStage();
        public abstract void Execute(BattleUnit battleUnit);
        
    }

    public class Attack : Action
    {
        private static Attack? _instance = null;
        public static Attack Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new Attack();
                return _instance;
            }
        }

        private Attack(){
            this.name = "Attack";
            this.description = "A Normal Attack";
            this.CoolDown = 0;
        }

        public override BattleUnitStage GetStartStage()
        {
            throw new NotImplementedException();
        }

        public override void Execute(BattleUnit battleUnit)
        {
            throw new NotImplementedException();
        }
    }


}