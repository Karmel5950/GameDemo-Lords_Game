namespace ApplicationLayer.CampSystem
{
    public class CampManager
    {
        public List<Camp> CampList { get; private set; }
        private static CampManager? _instance = null;
        public static CampManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new CampManager();
                return _instance;
            }
        }

        private CampManager()
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