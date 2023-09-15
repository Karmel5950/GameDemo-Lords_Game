using System;

namespace GsUtil
{
    public class CommonUtil
    {
        public static bool CheckInterfacesImplementation(object instance, params Type[] interfaceTypes)
        {
            // 遍历每个接口类型
            foreach (Type type in interfaceTypes)
            {
                // 检查接口是否被实现
                if (!type.IsAssignableFrom(instance.GetType()))
                {
                    return false;
                }
            }
            return true;
        }

    }


}