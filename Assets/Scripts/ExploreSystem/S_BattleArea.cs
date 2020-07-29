using System;
using System.Collections.Generic;

public class S_BattleArea : I_BaseDBF
{
	public int GUID;

	public int MapID;

	public string TriggerName;

	public List<int> Flag;

	public List<S_BattleEncounter> Encounter;

	public List<int> Group;

	public S_BattleArea()
	{
		this.Flag = new List<int>();
		this.Group = new List<int>();
		this.Encounter = new List<S_BattleEncounter>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_BattleArea))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 5; i++)
		{
			S_BattleEncounter s_BattleEncounter = new S_BattleEncounter();
			string key = string.Format("Step_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_BattleEncounter.Step);
			}
			key = string.Format("Chance_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_BattleEncounter.Chance);
			}
			this.Encounter.Add(s_BattleEncounter);
		}
		for (int j = 0; j < 5; j++)
		{
			int num = 0;
			string key2 = string.Format("Flag_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out num);
				if (num > 0)
				{
					this.Flag.Add(num);
				}
			}
		}
		for (int k = 0; k < 10; k++)
		{
			int item = 0;
			string key3 = string.Format("Group_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string s3 = dictionary[key3];
				int.TryParse(s3, out item);
				this.Group.Add(item);
			}
		}
	}
}
