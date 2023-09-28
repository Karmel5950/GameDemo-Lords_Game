namespace ApplicationLayer.PropertySettlementSystem
{
    // - 生成SettlementEvent事件,包含实体、属性、动作等信息。
    // - SettlementManager接收事件,查找匹配的SettlementAction进行结算。
    // - SettlementAction通过SettlementProcessor计算修改结果。
    // - 返回SettlementResult作为结算结果。
    public class SettlementManager
    {
        private static SettlementManager _instance = new SettlementManager();
        public static SettlementManager Instance { get { return _instance; } }
        private SettlementManager() { }

        public SettlementResult HandleEvent(SettlementEvent settlementEvent)
        {
            foreach (var item in settlementEvent.Actions)
            {
                item.Execute(settlementEvent);
            }

            return new SettlementResult(settlementEvent,settlementEvent.TargetState);
        }
    }
}