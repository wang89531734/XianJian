using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Treasure : I_BaseDBF
{
	public int GUID;

	public ENUM_TreasureType emType;

	public int Gold;

	public int Exp;

	public int CostHP;

	public int CostMP;

	public int Flag;

	public int ReBirth;

	public int ReBirthRadiu;

	public int BreakGetItem;

	public int BreakGetItemCount;

	public int UnlockID;

	public List<S_GetItem> Item;

	public S_Treasure()
	{
		this.Item = new List<S_GetItem>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("Treasure_" + this.GUID);
		}
		if (!(Record is S_Treasure))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 3; i++)
		{
			S_GetItem s_GetItem = new S_GetItem();
			string key = string.Format("ItemID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_GetItem.ID);
			}
			key = string.Format("ItemCount_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_GetItem.Count);
			}
			key = string.Format("ItemRate_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_GetItem.Rate);
			}
			if (s_GetItem.ID > 0)
			{
				this.Item.Add(s_GetItem);
			}
		}
	}
}
