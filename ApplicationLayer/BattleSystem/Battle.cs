
using System.Diagnostics;

namespace ApplicationLayer.BattleSystem
{
      public class Battle
    {
        public List<BattleTeam> TeamList;
       
        public bool isFighting = false;


        public Battle()
        {
            TeamList = new List<BattleTeam>();
        }

        public Battle AddNewTeam(BattleTeam team)
        {
            if (TeamList.Contains(team))
            {
                return this;
            }
            TeamList.Add(team);
            return this;
        }

        public void Start()
        {
            Init();
            isFighting = true;
            BattleSystem.Instance.BattleRunningEvent += Running;
            Debug.Print("Start Battle");
        }

        private void Init()
        {
            foreach (var team in TeamList)
            {
                foreach (var battleUnit in team.BattleUnitsList)
                {
                    battleUnit.OnBattleUnitDeadEvent += OnBattleUnitDead;
                    battleUnit.InitTeamMateList();
                    battleUnit.InitEnemyList();
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
            if (isFighting)
            {
                foreach (var team in TeamList)
                {
                    foreach (var battleUnit in team.LiveList)
                    {
                        battleUnit.Action();
                    }
                }
            }
        }

        public void OnBattleUnitDead(BattleUnit battleUnit)
        {
            battleUnit.OnBattleUnitDeadEvent -= OnBattleUnitDead;
            foreach (var team in TeamList)
            {
                foreach (var enemyTeam in team.EnemyTeamList)
                {
                    if (enemyTeam.IsTeamAlive)
                    {
                        return;
                    }
                }
            }
            Stop();
        }

    }
}