namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// 结算动作的抽象基类,每个结算动作实现对一个属性的具体结算逻辑。
    /// </summary>
    public abstract class SettlementAction
    {
        public abstract void Execute(SettlementEvent settlementEvent);
    }
}