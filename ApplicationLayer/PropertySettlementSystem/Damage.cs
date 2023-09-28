namespace ApplicationLayer.PropertySettlementSystem
{
    public class Damage
    {
        public double Value { get; set;}
        public DamageType Type { get; set;}
        public object Source { get; set;}
        
        public Damage(double value, DamageType type, object source)
        {
            Value = value;
            Type = type;
            Source = source;
        }

    }
}