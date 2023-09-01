
using System.Linq.Expressions;
using System;
namespace BaseLayer
{
    internal class RegisterSystem{
        private static RegisterSystem? _instance = null;
        public Dictionary<string,Dictionary<string,object>> registerDictionary{get;}
        private IDManager? idManager;
        private RegisterSystem()
        {
            registerDictionary = new Dictionary<string,Dictionary<string,object>>();
        }
        public static RegisterSystem Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new RegisterSystem();
                _instance.idManager = IDManager.Instance;
                RegisterSystem.Instance.Register(_instance.idManager);
                RegisterSystem.Instance.Register(_instance);
                return _instance;
            }
        }
        public void Register(object instance)
        {
            string className = instance.GetType().Name;
            
            if(!registerDictionary.ContainsKey(className))
            {
                registerDictionary[className] = new Dictionary<string,object>();
            }
            registerDictionary[className][idManager.GetID(className)] = instance;
        }

        public IEnumerable<T> QueryByCondition<T>(string className,Func<T, bool> filter)  
        {
            // 查找匹配的实例
            var results = registerDictionary[className].Values.OfType<T>();
            return results.Where(x => filter((T)x)); 
        }
        public object QueryByID(string className,string ID)  
        {
            return registerDictionary[className][ID];
        }

        public int GetTest(){
            return 1;
        }

    }

    internal class IDManager:object{
        private static IDManager? _instance;
        public static IDManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IDManager();
                }
                return _instance;
            }
        }
        private Dictionary<string,string> idDictionary;
        private IDManager()
        {
            idDictionary = new Dictionary<string,string>();
        }

        public string GetID(string className)
        {
            if (idDictionary.ContainsKey(className))
            {
                return (Convert.ToInt32(idDictionary[className]) + 1).ToString();
            }
            idDictionary[className] = "1";
            return idDictionary[className];
        }
    }
}