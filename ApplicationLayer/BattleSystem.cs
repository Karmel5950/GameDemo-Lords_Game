

using System.ComponentModel;

namespace ApplicationLayer
{
    public class BattleSystem{
        private static BattleSystem? _instance = null;
        public List<Battle> battleList;
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

        private BattleSystem(){
            battleList = new List<Battle>();
            for(int i = 1;i<=initBattleCount;i++){
                battleList.Add(new Battle());
            }
        }

        public Battle CreateBattle(){
            foreach (Battle battle in battleList)
            {
                if (battle.isFighting == false)
                {
                    battle.isFighting = true;
                    return battle;
                }
            }
            Battle newBattle = new Battle();
            battleList.Add(newBattle);
            return newBattle;
        }



    }

    public class Battle{
        private Dictionary<string,List<BattleUnit>> teamDictionary;
        private Dictionary<string,List<BattleUnit>> liveList;
        private Dictionary<string,List<BattleUnit>> deadList;
        public bool isFighting = false;


        public Battle()
        {
            teamDictionary = new Dictionary<string, List<BattleUnit>>();
            liveList = new Dictionary<string, List<BattleUnit>>();
            deadList = new Dictionary<string, List<BattleUnit>>();
        }

        public Battle AddNewTeam(string teamName){
            if(teamDictionary.ContainsKey(teamName)){
                return this;
            }
            teamDictionary.Add(teamName,new List<BattleUnit>());
            return this;
        }

        public Battle AddNewTeamMember(string teamName,BattleUnit battleUnit){
            if(!teamDictionary.ContainsKey(teamName)){
                return this;
            }
            if (teamDictionary[teamName].Contains(battleUnit))
            {
                return this;
            }
            battleUnit.teamName = teamName;
            teamDictionary[teamName].Add(battleUnit);
            return this;
        }   

        public void Start()
        {
            Init();
            isFighting = true;
            BattleSystem.Instance.BattleRunningEvent += Running;
        }

        private void Init()
        {
            liveList = new Dictionary<string, List<BattleUnit>>(teamDictionary);
            deadList = new Dictionary<string, List<BattleUnit>>(teamDictionary);
            foreach(var team in deadList.Values)
            {
                team.Clear();
            }
            foreach(var team in teamDictionary.Values)
            {
                foreach (var battleUnit in team)
                {
                    battleUnit.OnBattleUnitDeadEvent += OnBattleUnitDead;
                    InitTeamMateList(battleUnit);
                    InitEnemyList(battleUnit);
                }
            }
        }

        private void InitTeamMateList(BattleUnit battleUnit)
        {
            foreach(BattleUnit teamMate in teamDictionary[battleUnit.teamName])
            {
                if(teamMate != battleUnit)
                {
                    battleUnit.teamMateList.Add(teamMate);
                }
            }
        }

        private void InitEnemyList(BattleUnit battleUnit)
        {
            foreach (var (teamName,team) in teamDictionary)
            {
                if(teamName != battleUnit.teamName)
                {
                    foreach(BattleUnit enemy in team)
                    {
                        battleUnit.enemyList.Add(enemy);
                    }
                }
            }
        }

        public void Stop()
        {
            isFighting = false;
            BattleSystem.Instance.BattleRunningEvent -= Running;
        }

        private void Running()
        {
            if(isFighting)
            {
                foreach(var team in liveList.Values)
                {
                    foreach(var battleUnit in team)
                    {
                        battleUnit.Action();
                    }
                }

            }
        }

        public void OnBattleUnitDead(BattleUnit battleUnit)
        {
            battleUnit.OnBattleUnitDeadEvent -= OnBattleUnitDead;
            deadList[battleUnit.teamName].Add(battleUnit);
            liveList[battleUnit.teamName].Remove(battleUnit);
            if (liveList[battleUnit.teamName].Count == 0)
            {
                liveList.Remove(battleUnit.teamName);
            }

            if(liveList.Count == 1)
            {
                Stop();
            }
        }

    }
}