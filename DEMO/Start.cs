using System.Linq.Expressions;
using BaseLayer;

public class Start{
    static void Main() {
		RegisterSystem registerSystem = RegisterSystem.Instance;
		Func<RegisterSystem,bool> filter = x => x.GetTest() == 1;
		DateTime beforeDT = System.DateTime.Now;
		var results = registerSystem.QueryByCondition<RegisterSystem>("RegisterSystem", filter);
		DateTime afterDT = System.DateTime.Now;
		TimeSpan ts = afterDT.Subtract(beforeDT);
		Console.WriteLine("costed time for query function is: {0}ms",ts.TotalMilliseconds);
		foreach(var result in results){
			System.Console.WriteLine(result.ToString());
		}
	}
}