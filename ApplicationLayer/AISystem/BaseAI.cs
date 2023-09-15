using GsUtil;

namespace ApplicationLayer.AISystem
{
    public abstract class BaseAI
    {
        public Type[] interfaceTypes = new Type[0];
        public bool CheckInterfaces(object instance)
        {
            return CommonUtil.CheckInterfacesImplementation(instance,interfaceTypes);
        }

        public abstract void Action(object instance);

    }
}