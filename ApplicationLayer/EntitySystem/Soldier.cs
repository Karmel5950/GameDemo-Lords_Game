using ApplicationLayer.AISystem;
using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.EntitySystem
{
    public class Soldier : BaseBattleCharacter
    {

        public Soldier():base()
        {
            HealthPoints = 10;
            AttackValue = 2;
        }
    }
}
