using System;
using System.Collections.Generic;

public class S_SkillSlot : I_BaseDBF
{
	public int GUID;

	public int SkillID;

	public ENUM_SkillType emSkillType;

	public ENUM_SkillGroup emGroup;

	public int LearnRole;

	public int Level;

	public List<int> PreSkill;

	public int PrePartner;

	public int PreItem;

	public List<S_Flag> PreFlag;

	public S_SkillSlot()
	{
		this.PreSkill = new List<int>();
		this.PreFlag = new List<S_Flag>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_SkillSlot))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 4; i++)
		{
			int num = 0;
			string key = string.Format("PreSkill_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
				if (num > 0)
				{
					this.PreSkill.Add(num);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			S_Flag s_Flag = new S_Flag();
			s_Flag.Flag = 0;
			s_Flag.FlagON = 0;
			string key2 = string.Format("PreFlag_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_Flag.Flag);
			}
			key2 = string.Format("PreFlagON_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_Flag.FlagON);
			}
			this.PreFlag.Add(s_Flag);
		}
	}
}
