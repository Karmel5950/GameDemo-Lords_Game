namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// <para>一个结算状态抽象基类，状态中存储实体所使用的所有属性</para>
    /// <para>固定属性应创建新的子类存储，临时的增加的属性应该使用字典存储</para> 
    /// </summary>
    public abstract class SettlementState
    {
        public Dictionary<string,string> CustomProperties = new Dictionary<string, string>();
        
    }
}