using System;

namespace BaseLayer
{
    public class InstanceBase{
        public string ID = "NULL";
        public void RegisterThis()
        {
            RegisterSystem.Instance.Register(this);
        }
    }
}