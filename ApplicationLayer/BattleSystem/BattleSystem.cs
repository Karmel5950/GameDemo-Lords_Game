
namespace ApplicationLayer.BattleSystem
{
    public class BattleSystem
    {
        private static BattleSystem? _instance = null;
        public List<Battle> BattleList;
        private int initBattleCount = 10;
        public delegate void BattleRunning();
        public event BattleRunning? BattleRunningEvent;
        public static BattleSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new BattleSystem();
                return _instance;
            }
        }

        private BattleSystem()
        {
            BattleList = new List<Battle>();
            for (int i = initBattleCount; i >= 1; i--)
            {
                BattleList.Add(new Battle());
            }
        }

        public Battle CreateBattle()
        {
            foreach (Battle battle in BattleList)
            {
                if (battle.isFighting == false)
                {
                    battle.isFighting = true;
                    return battle;
                }
            }
            Battle newBattle = new Battle();
            BattleList.Add(newBattle);
            return newBattle;
        }

        
    }

      
}