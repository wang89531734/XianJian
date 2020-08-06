using System;
using System.Collections.Generic;

public class S_SkillPlate : I_BaseDBF
{
	public int GUID;

	public ENUM_ElementType emElement;

	public int BaseSkillID;

	public int LearnPoint;

	public int LearnTime;

	public List<S_SkillLearnData> SunSkill;

	public List<S_SkillLearnData> MoonSkill;

	public S_SkillPlate()
	{
		this.SunSkill = new List<S_SkillLearnData>();
		this.MoonSkill = new List<S_SkillLearnData>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_SkillPlate))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 8; i++)
		{
			S_SkillLearnData s_SkillLearnData = new S_SkillLearnData();
			string key = string.Format("SunPreSkill_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_SkillLearnData.PreSkillID);
			}
			key = string.Format("SunSkill_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_SkillLearnData.SkillID);
			}
			key = string.Format("SunSkillLearnPoint_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_SkillLearnData.LearnPoint);
			}
			key = string.Format("SunSkillLearnTime_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_SkillLearnData.LearnTime);
			}
			key = string.Format("SunSkillActivePoint_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_SkillLearnData.ActivePoint);
			}
			this.SunSkill.Add(s_SkillLearnData);
		}
		for (int j = 0; j < 8; j++)
		{
			S_SkillLearnData s_SkillLearnData2 = new S_SkillLearnData();
			string key2 = string.Format("MoonPreSkill_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillLearnData2.PreSkillID);
			}
			key2 = string.Format("MoonSkill_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillLearnData2.SkillID);
			}
			key2 = string.Format("MoonSkillLearnPoint_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillLearnData2.LearnPoint);
			}
			key2 = string.Format("MoonSkillLearnTime_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillLearnData2.LearnTime);
			}
			key2 = string.Format("MoonSkillActivePoint_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillLearnData2.ActivePoint);
			}
			this.MoonSkill.Add(s_SkillLearnData2);
		}
	}
}
