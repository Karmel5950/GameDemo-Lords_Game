namespace ApplicationLayer.PropertySettlementSystem
{
    interface IDamageable
    {
        double GetCurrentHealthPoint();
        double GetMaxHealthPoint();
        void TakeDamage(double damage);
        void Heal(double heal);
    }
}