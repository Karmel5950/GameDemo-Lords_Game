using ApplicationLayer.BattleSystem;

namespace ApplicationLayer.EntitySystem
{
    public interface IBaseBattleCharacter:IBattlable
    {
        
        public double GetHealthPoint();
        public double GetAttackValue();
    }
}