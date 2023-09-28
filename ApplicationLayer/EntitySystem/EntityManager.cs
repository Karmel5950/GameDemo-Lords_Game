namespace ApplicationLayer.EntitySystem
{
    public class EntityManager
    {
        private static EntityManager _instance = new EntityManager();
        public static EntityManager Instance { get { return _instance; } }
        private EntityManager() { }
        public List<Entity> Entities = new List<Entity>();
        public delegate void OnRegisterEntity(Entity entity);
        public event OnRegisterEntity? OnRegisterEntityEvent;
        public void RegisterEntity(Entity entity)
        {
            if (!Entities.Contains(entity))
            {
                Entities.Add(entity);
                OnRegisterEntityEvent?.Invoke(entity);
            }
        }
    }
}