
using ApplicationLayer.ActionSystem;
using ApplicationLayer.AISystem;

namespace ApplicationLayer.BattleSystem
{
    public class BattleUnit
    {
        public IBattlable BattleCharacter;
        public List<BattleUnit> EnemyList;
        public List<BattleUnit> TeamMateList;
        public BattleUnit? Target;
        public BattleTeam? Team;
        public BaseBattleAI BattleAI;
        public double ActionSpeed;
        public bool IsAlive{get{return BattleCharacter.IsAlive();}}
        public BattleUnitStage BattleUnitStage;
        public delegate void OnBattleUnitDead(BattleUnit battleUnit);
        public event OnBattleUnitDead? OnBattleUnitDeadEvent;
        public BattleUnit(IBattlable character)
        {
            BattleCharacter = character;
            EnemyList = new List<BattleUnit>();
            TeamMateList = new List<BattleUnit>();
            BattleUnitStage = BattleUnitStages.WaitFinishStage;
            BattleAI = character.GetBattleAI();
        }

        
        public void Action()
        {
            BattleAI.Action(this);
        }
        public void Dead()
        {
            if (OnBattleUnitDeadEvent != null)
            {
                OnBattleUnitDeadEvent(this);
            }
        }

        public void InitTeamMateList()
        {
            if (Team == null)
            {
                return;
            }
            foreach (BattleUnit teamMate in Team.BattleUnitsList)
            {
                if (teamMate != this)
                {
                    TeamMateList.Add(teamMate);
                }
            }
        }

        public void InitEnemyList()
        {
            if (Team == null)
            {
                return;
            }
            foreach (var team in Team.EnemyTeamList)
            {
                foreach (BattleUnit enemy in team.BattleUnitsList)
                {
                    EnemyList.Add(enemy);
                }
            }
        }

    
    }


    public class BattleUnitStage
    {
        public BattlePose battlePose;
        public ActionStage actionStage;
        public List<BattleUnitStage> nextBattleUnitStage;
        public BattleUnitStage(BattlePose battlePose, ActionStage actionStage)
        {
            this.battlePose = battlePose;
            this.actionStage = actionStage;
            nextBattleUnitStage = new List<BattleUnitStage>();
        }
        public void AddNextBattleUnitStage(BattleUnitStage battleUnitStage)
        {
            nextBattleUnitStage.Add(battleUnitStage);
        }
    }

    public class BattleUnitStages
    {
        public static BattleUnitStage AttackPrepareStage = GetAttackPrepareStage();
        private static BattleUnitStage GetAttackPrepareStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack, ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackExcuteStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }
        public static BattleUnitStage AttackExcuteStage = GetAttackExcuteStage();

        private static BattleUnitStage GetAttackExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack, ActionStage.Execution);
            tmpStage.AddNextBattleUnitStage(AttackFinishStage);
            return tmpStage;
        }

        public static BattleUnitStage AttackFinishStage = GetAttackFinishStage();

        private static BattleUnitStage GetAttackFinishStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack, ActionStage.Finish);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DefensePrepareStage = GetDefensePrepareStage();

        private static BattleUnitStage GetDefensePrepareStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Defense, ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefenseExcuteStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DefenseExcuteStage = GetDefenseExcuteStage();

        private static BattleUnitStage GetDefenseExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Defense, ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DodgeExcuteStage = GetDodgeExcuteStage();

        private static BattleUnitStage GetDodgeExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Dodge, ActionStage.Execution);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            return tmpStage;
        }

        public static BattleUnitStage UnbalanceUncontrollStage = GetUnbalanceUncontrollStage();

        private static BattleUnitStage GetUnbalanceUncontrollStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Unbalance, ActionStage.Uncontroll);
            tmpStage.AddNextBattleUnitStage(UnbalanceRecoverStage);
            return tmpStage;
        }

        public static BattleUnitStage UnbalanceRecoverStage = GetUnbalanceRecoverStage();

        private static BattleUnitStage GetUnbalanceRecoverStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Unbalance, ActionStage.Recover);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage WaitFinishStage = GetWaitFinishStage();

        private static BattleUnitStage GetWaitFinishStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Wait, ActionStage.Finish);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }
    }

    public enum ActionStage
    {
        Preparation,
        Execution,
        Finish,
        Uncontroll,
        Recover
    }

    public enum BattlePose
    {
        Attack,
        Defense,
        Dodge,
        Unbalance,
        Wait
    }
}