using ApplicationLayer.ActionSystem;
using ApplicationLayer.AISystem;

namespace ApplicationLayer.EntitySystem
{
    public abstract class BaseCharacter
    {
        public string Name = "Default";
        public bool IsAlive;
        public double HealthPoints = 100;

        public string GetName()
        {
            return Name;
        }
    }

}