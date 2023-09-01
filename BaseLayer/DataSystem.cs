using System;
using BaseLayer;
namespace BaseLayer
{
/*数据系统
功能:
1.持有全部的对象
2.提供按照条件快速高效搜索对象的方法
3.线程安全的数据修改接口
4.持有全部的计算结果
*/
    public class DataSystem
    {
        //实现单例模式
        private static DataSystem? _instance = null;
        public static DataSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new DataSystem();
                return _instance;
            }
        }
        private RegisterSystem registerSystem; 
        private DataSystem()
        {
            registerSystem = RegisterSystem.Instance;
        }


        public List<object> GetObjectsByCondition(string className,Func<object, bool> condition)
        {

            return registerSystem.QueryByCondition(className, condition).ToList();
        
        }
    }
}