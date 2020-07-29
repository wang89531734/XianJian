using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string IconNo;

	public string Desc;

	public string Help;

	public ENUM_ItemSubType emItemType;

	public ENUM_SkillEffectType emSkillEffectType;

	public int SpellTransferSwitch;

	public int LearnRole;

	public int UseComboCode;

	public int UseLevel;

	public int UsePoint;

	public int UsePartner;

	public int CastHP;

	public int CastMP;

	public int CastAP;

	public List<int> CastBuffer;

	public int CastCallID;

	public int CastCallRate;

	public S_UseEffect UseEffect;

	public S_Skill()
	{
		this.CastBuffer = new List<int>();
		this.UseEffect = new S_UseEffect();
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
		this.UseEffect = Converter.deserializeObject<S_UseEffect>(JsonString);
		this.UseEffect.ParseData(dictionary);
		for (int i = 0; i < 6; i++)
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
	}
}
