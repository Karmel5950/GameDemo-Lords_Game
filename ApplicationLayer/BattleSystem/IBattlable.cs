using ApplicationLayer.AISystem;

namespace ApplicationLayer.BattleSystem
{
    public interface IBattlable
    {
        public BattleUnit GetBattleUnit();
        public BaseBattleAI GetBattleAI();
        public bool IsAlive(); 
    
    }
}