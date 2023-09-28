using System.Runtime.CompilerServices;

namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// 一个实现战斗需要的基础结算状态
    /// </summary>
    public class BaseBattleSettlementState
    {
        /// <summary>
        /// 最大生命值
        /// </summary>
        public virtual double MaxHealthPoint
        {
            get { return MaxHealthPoint; }
            set
            {
                if (value < 0)
                {
                    MaxHealthPoint = 0;
                }
                else
                {
                    MaxHealthPoint = value;
                }
            }
        }
        /// <summary>
        /// 当前生命值
        /// </summary>
        public virtual double CurrentHealthPoint
        {
            get { return CurrentHealthPoint; }
            set
            {
                if (value > MaxHealthPoint)
                {
                    CurrentHealthPoint = MaxHealthPoint;
                }
                else
                {
                    CurrentHealthPoint = value;
                }
            }
        }
        /// <summary>
        /// 是否存活标志
        /// </summary>
        public virtual bool IsAlive { get { return CurrentHealthPoint > 0; } }
        /// <summary>
        /// 防御力
        /// </summary>
        public virtual double DefensePoint { get { return DefensePoint; } set { DefensePoint = value; UpdateBaseDamageReduceRate(); } }
        /// <summary>
        /// 防御力带来的基础减伤率，默认公式为：防御力/(防御力+100)
        /// </summary>
        public virtual double BaseDamageReduceRate { get { return BaseDamageReduceRate; } set { BaseDamageReduceRate = value; UpdateFinalDamageReduceRate(); } }
        /// <summary>
        /// 额外减伤率，通常由装备属性，buff和技能提供
        /// </summary>
        public virtual double AdditionDamageReduceRate { get { return AdditionDamageReduceRate; } set { AdditionDamageReduceRate = value; UpdateFinalDamageReduceRate(); } }
        /// <summary>
        /// 最终减伤率，实际参与减伤计算的减伤率
        /// </summary>
        public virtual double FinalDamageReduceRate { get { return FinalDamageReduceRate; } set { FinalDamageReduceRate = value; } }
        /// <summary>
        /// 基础攻击力
        /// </summary>
        public virtual double BaseAttackPoint { get { return BaseAttackPoint; } set { BaseAttackPoint = value;UpdateFinalAttackPoint(); } }
        /// <summary>
        /// 额外攻击力
        /// </summary>
        public virtual double AdditionAttackPoint { get { return AdditionAttackPoint; } set { AdditionAttackPoint = value;UpdateFinalAttackPoint(); } }
        /// <summary>
        /// 最终攻击力
        /// </summary>
        public virtual double FinalAttackPoint { get { return FinalAttackPoint; } set { FinalAttackPoint = value; } }
        /// <summary>
        /// 更新基础减伤率的方法，更改防御力时调用
        /// </summary>
        public void UpdateBaseDamageReduceRate()
        {
            BaseDamageReduceRate = SettlementProcessor.ClassicDamageReduceRateFunction(DefensePoint);
        }
        /// <summary>
        /// 更新最终减伤率的方法，默认最终减伤率由基础减伤率和额外减伤率相加组成
        /// </summary>
        public void UpdateFinalDamageReduceRate()
        {
            FinalDamageReduceRate = BaseDamageReduceRate + FinalDamageReduceRate;
        }
        /// <summary>
        /// 更新基础攻击力的方法
        /// </summary>
        public void UpdateBaseAttackPoint()
        {

        }
        /// <summary>
        /// 更新最终攻击力的方法
        /// </summary>
        public void UpdateFinalAttackPoint()
        {
            FinalAttackPoint = BaseAttackPoint + AdditionAttackPoint;
        }
    }
}