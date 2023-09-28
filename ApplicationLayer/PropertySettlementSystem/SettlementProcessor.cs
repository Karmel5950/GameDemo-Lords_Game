namespace ApplicationLayer.PropertySettlementSystem
{
    /// <summary>
    /// 进行实际数值计算的组件,动作组合其方法对属性值进行修改。
    /// </summary>
    class SettlementProcessor 
    {

        /// <summary>
        /// 减少生命值的方法，会计算减伤率
        /// </summary>
        /// <param name="state"></param>
        /// <param name="reduceValue"></param>
        /// <returns></returns>
        public static BaseBattleSettlementState ReduceHealthPoint(BaseBattleSettlementState state,double reduceValue)
        {   
            state.CurrentHealthPoint -= reduceValue * (1- state.FinalDamageReduceRate);
            return state; 
        }
        /// <summary>
        /// 减少生命值的方法，无视减伤率
        /// </summary>
        /// <param name="state"></param>
        /// <param name="reduceValue"></param>
        /// <returns></returns>
        public static BaseBattleSettlementState ReduceHealthPointWithOutDamageReduceRate(BaseBattleSettlementState state,double reduceValue)
        {   
            state.CurrentHealthPoint -= reduceValue;
            return state; 
        }
        /// <summary>
        /// 经典防御力转换减伤率的公式，减伤率 = 防御力/(防御力 + 100)
        /// </summary>
        /// <param name="defensePoint"></param>
        /// <returns></returns>
        public static double ClassicDamageReduceRateFunction(double defensePoint)
        {
            return defensePoint/(defensePoint + 100);
        }
    }

}