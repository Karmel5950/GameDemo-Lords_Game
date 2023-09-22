using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ApplicationLayer.BattleSystem;
using ApplicationLayer.EntitySystem;
using BaseLayer;
using GsUtil;

public class Start
{
	public static void Start_1()
	{
		RegisterSystem registerSystem = RegisterSystem.Instance;
		Func<RegisterSystem, bool> filter = x => x.GetTest() == 1;
		DateTime beforeDT = System.DateTime.Now;
		var results = registerSystem.QueryByCondition<RegisterSystem>("RegisterSystem", filter);
		DateTime afterDT = System.DateTime.Now;
		TimeSpan ts = afterDT.Subtract(beforeDT);
		Console.WriteLine("costed time for query function is: {0}ms", ts.TotalMilliseconds);
		foreach (var result in results)
		{
			System.Console.WriteLine(result.ToString());
		}
	}
	public static void Start_2()
	{
		Soldier soldier = new Soldier();
		if (CommonUtil.CheckInterfacesImplementation(soldier, typeof(IBattlable)))
		{
			System.Console.WriteLine("Soldier is IBattlable");
		}
		else
		{
			System.Console.WriteLine("Soldier is not IBattlable");
		}
	}
	public static void Start_3()
	{
		Soldier soldier1 = new Soldier();
		Soldier soldier2 = new Soldier();
		BattleTeam redTeam = new BattleTeam();
		BattleTeam blueTeam = new BattleTeam();
		redTeam.AddBattleUnit(new BattleUnit(soldier1));
		blueTeam.AddBattleUnit(new BattleUnit(soldier2));
		Battle newBattle = BattleSystem.Instance.CreateBattle();
		newBattle.AddNewTeam(redTeam);
		newBattle.AddNewTeam(blueTeam);

		newBattle.Start();
		while (newBattle.isFighting)
		{
			BattleSystem.Instance.RunningBattle();
		}

	}
}