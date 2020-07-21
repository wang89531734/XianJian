using System;
using System.Collections.Generic;

public class S_ReviewStory : I_BaseDBF
{
	public int GUID;

	public int Play;

	public int MapID;

	public int Chapter;

	public List<int> Flag;

	public int MainFlag;

	public string Name;

	public string Desc;

	public S_ReviewStory()
	{
		this.Flag = new List<int>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 10; i++)
		{
			int num = 0;
			string key = string.Format("Flag_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
			}
			if (num > 0)
			{
				this.Flag.Add(num);
			}
		}
	}
}
