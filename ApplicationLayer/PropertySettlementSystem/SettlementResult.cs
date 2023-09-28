namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// 结算结果,可反馈给其他系统。
    /// </summary>
    public class SettlementResult
    {
        public SettlementEvent SourceEvent;
        public SettlementState ResultState;

        public SettlementResult(SettlementEvent sourceEvent, SettlementState resultState)
        {
            SourceEvent = sourceEvent;
            ResultState = resultState;
        }
    
    }
}