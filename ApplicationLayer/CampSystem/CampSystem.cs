namespace ApplicationLayer.CampSystem
{
    public class CampSystem
    {
        public List<Camp> CampList { get; private set; }
        private static CampSystem? _instance = null;
        public static CampSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new CampSystem();
                return _instance;
            }
        }

        private CampSystem()
        {
            CampList = new List<Camp>();
        }

        public void AddCamp(Camp camp)
        {
            if (CampList.Contains(camp))
            {
                return;
            }
            CampList.Add(camp);
        }

        public static CampRelationshipStatus TurnCampRelationshipValueToStatus(double value)
        {
            if (value < -50)
            {
                return CampRelationshipStatus.HOSTILE;
            }
            if (value >= -50 && value <= 50)
            {
                return CampRelationshipStatus.NEUTRAL;
            }
            if (value > 50)
            {
                return CampRelationshipStatus.ALLIANCE;
            }
            return CampRelationshipStatus.NEUTRAL;
        }

    }

    public enum CampRelationshipStatus
    {
        HOSTILE,
        NEUTRAL,
        ALLIANCE
    }


}