namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// 封装一次结算的详细信息,如对哪个实体的哪些属性进行何种结算。
    /// </summary>
    public abstract class SettlementEvent
    {
        public ISettlementStateContainer TargetContainer;
        public ISettlementStateContainer SourceContainer;
        public SettlementState TargetState { get { return TargetContainer.GetState(); } }
        public SettlementState SourcetState { get { return SourceContainer.GetState(); } }

        public List<SettlementAction> Actions = new List<SettlementAction>();
        public SettlementEvent(ISettlementStateContainer targetContainer, ISettlementStateContainer sourceContainer)
        {
            TargetContainer = targetContainer;
            SourceContainer = sourceContainer;
            InitActions();
        }
        public void InitActions()
        {

        }
    }
}