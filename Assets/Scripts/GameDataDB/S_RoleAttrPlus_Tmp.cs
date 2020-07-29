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
		for (int i = 0; i < 6; i++)
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
		for (int j = 0; j < 6; j++)
		{
			int num2 = 0;
			string key2 = string.Format("ElementRatio_{0}", j);
			if (values.ContainsKey(key2))
			{
				string s2 = values[key2];
				int.TryParse(s2, out num2);
			}
			this.RoleAttr_Plus.ElementRatio[j] = num2;
		}
		for (int k = 0; k < 6; k++)
		{
			int num3 = 0;
			string key3 = string.Format("AtkElement_{0}", k);
			if (values.ContainsKey(key3))
			{
				string s3 = values[key3];
				int.TryParse(s3, out num3);
			}
			this.RoleAttr_Plus.AtkElement[k] = num3;
		}
		for (int l = 0; l < 6; l++)
		{
			int num4 = 0;
			string key4 = string.Format("AtkElementRatio_{0}", l);
			if (values.ContainsKey(key4))
			{
				string s4 = values[key4];
				int.TryParse(s4, out num4);
			}
			this.RoleAttr_Plus.AtkElementRatio[l] = num4;
		}
	}
}
