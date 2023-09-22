namespace ApplicationLayer.EntitySystem
{
    public class EntitySystem
    {
        private static EntitySystem _instance = new EntitySystem();
        public static EntitySystem Instance { get { return _instance; } }
        private EntitySystem() { }
        
    }
}