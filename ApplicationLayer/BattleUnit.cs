







namespace ApplicationLayer
{
    public class BattleUnit{
        public Character character;
        public List<BattleUnit> enemyList;
        public List<BattleUnit> teamMateList;
        public BattleUnit? target;
        public string teamName = "NULL";
        public BaseBattleAI battleAI;
        public double actionValue = 0;
        public double actionSpeed ;
        public BattleUnitStage battleUnitStage;
        public delegate void OnBattleUnitDead(BattleUnit battleUnit);
        public event OnBattleUnitDead? OnBattleUnitDeadEvent;
        public BattleUnit(Character character){
            this.character = character;
            enemyList = new List<BattleUnit>();
            teamMateList = new List<BattleUnit>();
            battleUnitStage = BattleUnitStages.WaitFinishStage;
            battleAI = NormalBattleAI.Instance;
        }

        public void Action()
        {   
            battleAI.Action(this);
        }
        public void Dead()
        {   
            if(OnBattleUnitDeadEvent != null)
            {
                OnBattleUnitDeadEvent(this);
            }
        }


    }
    public class BattleUnitStage{
        public BattlePose battlePose;
        public ActionStage actionStage;
        public List<BattleUnitStage> nextBattleUnitStage;
        public BattleUnitStage(BattlePose battlePose,ActionStage actionStage){
            this.battlePose = battlePose;
            this.actionStage = actionStage;
            nextBattleUnitStage = new List<BattleUnitStage>();
        }
        public void AddNextBattleUnitStage(BattleUnitStage battleUnitStage){
            nextBattleUnitStage.Add(battleUnitStage) ;
        }
    }

    public class BattleUnitStages{
        public static BattleUnitStage AttackPrepareStage = GetAttackPrepareStage();
        private static BattleUnitStage GetAttackPrepareStage(){
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack,ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackExcuteStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }
        public static BattleUnitStage AttackExcuteStage = GetAttackExcuteStage();

        private static BattleUnitStage GetAttackExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack,ActionStage.Execution);
            tmpStage.AddNextBattleUnitStage(AttackFinishStage);
            return tmpStage;
        }

        public static BattleUnitStage AttackFinishStage = GetAttackFinishStage();

        private static BattleUnitStage GetAttackFinishStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Attack,ActionStage.Finish);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DefensePrepareStage = GetDefensePrepareStage();

        private static BattleUnitStage GetDefensePrepareStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Defense,ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefenseExcuteStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DefenseExcuteStage = GetDefenseExcuteStage();

        private static BattleUnitStage GetDefenseExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Defense,ActionStage.Preparation);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }

        public static BattleUnitStage DodgeExcuteStage = GetDodgeExcuteStage();

        private static BattleUnitStage GetDodgeExcuteStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Dodge,ActionStage.Execution);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            return tmpStage;
        }

        public static BattleUnitStage UnbalanceUncontrollStage = GetUnbalanceUncontrollStage();

        private static BattleUnitStage GetUnbalanceUncontrollStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Unbalance,ActionStage.Uncontroll);
            tmpStage.AddNextBattleUnitStage(UnbalanceRecoverStage);
            return tmpStage;
        }

        public static BattleUnitStage UnbalanceRecoverStage = GetUnbalanceRecoverStage();

        private static BattleUnitStage GetUnbalanceRecoverStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Unbalance,ActionStage.Recover);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }
    
        public static BattleUnitStage WaitFinishStage = GetWaitFinishStage();

        private static BattleUnitStage GetWaitFinishStage()
        {
            BattleUnitStage tmpStage = new BattleUnitStage(BattlePose.Wait,ActionStage.Finish);
            tmpStage.AddNextBattleUnitStage(AttackPrepareStage);
            tmpStage.AddNextBattleUnitStage(DefensePrepareStage);
            tmpStage.AddNextBattleUnitStage(DodgeExcuteStage);
            return tmpStage;
        }
    }    

    public enum ActionStage{
        Preparation,
        Execution,
        Finish ,
        Uncontroll,
        Recover
    }

    public enum BattlePose{
        Attack,
        Defense,
        Dodge,
        Unbalance,
        Wait
    }
}