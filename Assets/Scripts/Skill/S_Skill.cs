using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int IconNo;

	public string Desc;

	public string Help;

	public ENUM_ItemSubType emItemType;

	public ENUM_SkillEffectType emSkillEffectType;

	public ENUM_SkillTriggerType emTriggerType;

	public int Group;

	public int LearnRole;

	public int UseLevel;

	public int UsePartner;

	public int CastHP;

	public int CastMP;

	public float CastCD;

	public List<int> CastBuffer;

	public int CastCallID;

	public int CastCallRate;

	public List<S_SkillCastCall> CastCallList;

	public int UseEffectID;

	public S_Skill()
	{
		this.CastBuffer = new List<int>();
		this.CastCallList = new List<S_SkillCastCall>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Skill))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.Help = GameDataDB.TransStringByLanguageType(this.Help);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 4; i++)
		{
			int num = 0;
			string key = string.Format("CastBuffer_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
				if (num > 0)
				{
					this.CastBuffer.Add(num);
				}
			}
		}
		for (int j = 0; j < 5; j++)
		{
			S_SkillCastCall s_SkillCastCall = new S_SkillCastCall();
			string key2 = string.Format("CastCallID_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillCastCall.CastCallID);
			}
			key2 = string.Format("CastCallRate_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_SkillCastCall.CastCallRate);
			}
			if (s_SkillCastCall.CastCallID > 0)
			{
				this.CastCallList.Add(s_SkillCastCall);
			}
		}
	}
}
