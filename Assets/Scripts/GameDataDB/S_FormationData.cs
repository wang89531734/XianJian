using System;
using System.Collections.Generic;
using UnityEngine;

public class S_FormationData : I_BaseDBF
{
	public int GUID;

	public string Name;

	public ENUM_ElementType emElement;

	public List<ENUM_FormationRange> emRange;

	public List<ENUM_FormationActionType> emActionType;

	public List<int> RoleAttr;

	public List<ENUM_FormationAI> emAI;

	public int BaseAttr;

	public string Desc;

	public S_FormationData()
	{
		this.emRange = new List<ENUM_FormationRange>();
		this.emActionType = new List<ENUM_FormationActionType>();
		this.RoleAttr = new List<int>();
		this.emAI = new List<ENUM_FormationAI>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 4; i++)
		{
			string s = string.Empty;
			string key = string.Format("emActionType_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				s = dictionary[key];
				int item;
				int.TryParse(s, out item);
				this.emActionType.Add((ENUM_FormationActionType)item);
			}
		}
		for (int j = 0; j < 4; j++)
		{
			string s2 = string.Empty;
			string key2 = string.Format("RoleAttr_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				s2 = dictionary[key2];
				int item2;
				int.TryParse(s2, out item2);
				this.RoleAttr.Add(item2);
			}
		}
		for (int k = 0; k < 4; k++)
		{
			string s3 = string.Empty;
			string key3 = string.Format("emAI_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				s3 = dictionary[key3];
				int item3;
				int.TryParse(s3, out item3);
				this.emAI.Add((ENUM_FormationAI)item3);
			}
		}
	}
}
