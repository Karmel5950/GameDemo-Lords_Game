namespace ApplicationLayer.PropertySettlementSystem
{
    interface IActionCommand
    {
        void Execute(SettlementState state);
    }
}