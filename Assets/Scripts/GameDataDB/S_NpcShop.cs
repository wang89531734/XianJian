using System;
using System.Collections.Generic;
using UnityEngine;

public class S_NpcShop : I_BaseDBF
{
	public int GUID;

	public List<int> SellItem;

	public List<S_ChangeItem> ChangeItem;

	public List<string> VIPTalk;

	public S_NpcShop()
	{
		this.SellItem = new List<int>();
		this.ChangeItem = new List<S_ChangeItem>();
		this.VIPTalk = new List<string>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("NpcShop_" + this.GUID);
		}
		if (!(Record is S_NpcShop))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 50; i++)
		{
			int num = 0;
			string key = string.Format("Item_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
			}
			if (num > 0)
			{
				this.SellItem.Add(num);
			}
		}
		for (int j = 0; j < 20; j++)
		{
			S_ChangeItem s_ChangeItem = new S_ChangeItem();
			s_ChangeItem.ID = 0;
			string key2 = string.Format("ChangeItem_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_ChangeItem.ID);
			}
			key2 = string.Format("ChangeItemVIP_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_ChangeItem.VIPLevel);
			}
			if (s_ChangeItem.ID > 0)
			{
				this.ChangeItem.Add(s_ChangeItem);
			}
		}
		for (int k = 0; k < 6; k++)
		{
			string text = string.Empty;
			string key3 = string.Format("VIPTalk_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				text = dictionary[key3];
			}
			text = GameDataDB.TransStringByLanguageType(text);
			this.VIPTalk.Add(text);
		}
	}
}
