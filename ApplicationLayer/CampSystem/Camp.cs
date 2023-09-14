using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.CampSystem
{
    public class Camp{
        public string Name;
        public Dictionary<Camp,double> CampRelationship;
        public List<BattleUnit> BattleUnitList;
        public List<CampRelationshipChangeEvent> RelationshipChangeHistory;
        private const double relationshipDecayRate = -0.1;
        public Camp(string name){
            Name = name;
            CampRelationship=new Dictionary<Camp, double>();
            BattleUnitList=new List<BattleUnit>();
            RelationshipChangeHistory = new List<CampRelationshipChangeEvent>();
        }
        public void UpdateAllCampRelationship(){
            foreach (var camp in CampRelationship.Keys)
            {
                CampRelationship[camp]= 0;
            }
            foreach (var e in RelationshipChangeHistory)
            {
                if (!CampRelationship.ContainsKey(e.FromCamp))
                {
                    CampRelationship[e.FromCamp] = 0;
                }
                CampRelationship[e.FromCamp] += e.RelationshipChangeValue * Math.Exp((TimeSystem.Instance.GameTime - e.Time) * relationshipDecayRate) ;
            }
        }
        public void UpdateSingleCampRelationship(Camp camp){
            if (!CampRelationship.ContainsKey(camp))
            {
                CampRelationship[camp] = 0;
            }
            foreach (var e in RelationshipChangeHistory)
            {
                if (e.FromCamp == camp)
                {
                    CampRelationship[camp] += e.RelationshipChangeValue * Math.Exp((TimeSystem.Instance.GameTime - e.Time) * relationshipDecayRate) ;
                }
            }
        }
        public double GetCampRelationship(Camp camp){
            if (!CampRelationship.ContainsKey(camp))
            {
                return 0;
            }
            return CampRelationship[camp];
        }
    }

    public class CampRelationshipChangeEvent{
        public string Name;
        public Camp FromCamp;
        public double RelationshipChangeValue;
        public string EventDescribe;
        public double Time;
        public  CampRelationshipChangeEvent(string eventName,Camp fromCamp,double relationshipChangeValue,string eventDescribe){
            Name = eventName;
            FromCamp = fromCamp;
            RelationshipChangeValue = relationshipChangeValue;
            EventDescribe = eventDescribe;
            Time = TimeSystem.Instance.GameTime;
        }
    }

}