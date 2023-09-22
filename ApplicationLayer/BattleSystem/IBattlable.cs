using ApplicationLayer.ActionSystem;
using ApplicationLayer.AISystem;

namespace ApplicationLayer.BattleSystem
{
    public interface IBattlable:IActionable
    {
        public BattleUnit GetBattleUnit();
        public BaseBattleAI GetBattleAI();
        public bool IsAlive(); 
    
    }
}