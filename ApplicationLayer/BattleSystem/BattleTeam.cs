namespace ApplicationLayer.BattleSystem
{
    public class BattleTeam
    {
        public List<BattleUnit> BattleUnitsList;
        public List<BattleTeam> EnemyTeamList;
        public List<BattleUnit> LiveList;
        public List<BattleUnit> DeadList;
        public bool IsTeamAlive{
            get
            {
                if (LiveList.Count>0)
                {
                    return true;
                }
                return false;
            }
        }
        public BattleTeam()
        {
            BattleUnitsList = new List<BattleUnit>();
            EnemyTeamList = new List<BattleTeam>();
            LiveList = new List<BattleUnit>();
            DeadList = new List<BattleUnit>();
        }
        public BattleTeam(List<BattleUnit> battleUnits):this()
        {
            AddBattleUnitByList(battleUnits);
            InitLiveList();
        }

        public void AddBattleUnit(BattleUnit battleUnit)
        {
            if (BattleUnitsList.Contains(battleUnit))
            {
                return;
            }
            BattleUnitsList.Add(battleUnit);
            battleUnit.Team = this;
        }
        public void RemoveBattleUnit(BattleUnit battleUnit)
        {
            if (BattleUnitsList.Contains(battleUnit))
            {
                BattleUnitsList.Remove(battleUnit);
            }
            battleUnit.Team = null;
        }

        public void AddEnemyTeam(BattleTeam battleTeam)
        {
            if (EnemyTeamList.Contains(battleTeam))
            {
                return;
            }
            EnemyTeamList.Add(battleTeam);
        }
        public void RemoveEnemyTeam(BattleTeam battleTeam)
        {
            if (EnemyTeamList.Contains(battleTeam))
            {
                EnemyTeamList.Remove(battleTeam);
            }
        }

        public void InitLiveList()
        {
            LiveList.Clear();
            foreach (var battleUnit in BattleUnitsList)
            {
                if (battleUnit.IsAlive)
                {
                    LiveList.Add(battleUnit);
                }
            } 
        }

        public void AddBattleUnitByList(List<BattleUnit> battleUnits)
        {
            foreach (var battleUnit in battleUnits)
            {
                AddBattleUnit(battleUnit);
            }
        } 
    }
}