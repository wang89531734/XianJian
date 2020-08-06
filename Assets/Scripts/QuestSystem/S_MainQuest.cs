using System;
using System.Collections.Generic;

public class S_MainQuest : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int Chapter;

	public string SubChapter;

	public string Desc;

	public string ChapterName;

	public string ChapterSubName;

	public string Hint;

	public List<int> MapIDList;

	public S_MainQuest()
	{
		this.MapIDList = new List<int>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.ChapterName = GameDataDB.TransStringByLanguageType(this.ChapterName);
		this.ChapterSubName = GameDataDB.TransStringByLanguageType(this.ChapterSubName);
		this.Hint = GameDataDB.TransStringByLanguageType(this.Hint);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 2; i++)
		{
			int item = 0;
			string key = string.Format("MapID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out item);
			}
			this.MapIDList.Add(item);
		}
	}
}
