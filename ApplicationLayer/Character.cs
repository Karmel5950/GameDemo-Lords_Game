using ApplicationLayer.AISystem;

namespace ApplicationLayer{
    public abstract class Character{
        public bool IsAlive;
        public BaseBattleAI battleAI = NormalBattleAI.Instance;



    }

}