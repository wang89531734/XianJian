using System;
using System.Collections.Generic;
using UnityEngine;

public class S_RoleAttrPlus_Tmp : I_BaseDBF
{
	public int GUID;

	public string Name;

	public S_RoleAttr_Plus RoleAttr_Plus;

	public S_RoleAttrPlus_Tmp()
	{
		this.RoleAttr_Plus = new S_RoleAttr_Plus();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_RoleAttrPlus_Tmp))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.RoleAttr_Plus = Converter.deserializeObject<S_RoleAttr_Plus>(JsonString);
		Dictionary<string, string> values = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		this.ParseData(values);
	}

	public void ParseData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = 0;
			string key = string.Format("Element_{0}", i);
			if (values.ContainsKey(key))
			{
				string s = values[key];
				int.TryParse(s, out num);
			}
			this.RoleAttr_Plus.Element[i] = num;
		}
		for (int j = 0; j < 4; j++)
		{
			int num2 = 0;
			string key2 = string.Format("AtkElement_{0}", j);
			if (values.ContainsKey(key2))
			{
				string s2 = values[key2];
				int.TryParse(s2, out num2);
			}
			this.RoleAttr_Plus.AtkElement[j] = num2;
		}
	}
}
