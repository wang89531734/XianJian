using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Quest : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string RoleGroupName;

	public ENUM_QuestType emType;

	public int Chapter;

	public int Group;

	public int Role;

	public int GiveMap;

	public string Talk;

	public int GiveNpc;

	public int PlayTimes;

	public List<S_Flag> PreFlag;

	public int PreQuest;

	public List<S_TmpItem> PreItem;

	public int PrePartner;

	public int RunNpc;

	public List<S_TmpItem> GiveItem;

	public List<S_TmpItem> FinishItem;

	public List<S_FinishMob> FinishMob;

	public List<S_Flag> ReportFlag;

	public int ReportNpc;

	public int FinishFlag;

	public int FailFlag;

	public int RewardMoney;

	public List<S_TmpItem> RewardItem;

	public int RewardAchievement;

	public int RewardSkill;

	public int RewardExp;

	public int RewardSystem;

	public string Desc;

	public string Hint;

	public string FinishHint;

	public S_Quest()
	{
		this.PreFlag = new List<S_Flag>();
		this.ReportFlag = new List<S_Flag>();
		this.PreItem = new List<S_TmpItem>();
		this.GiveItem = new List<S_TmpItem>();
		this.FinishItem = new List<S_TmpItem>();
		this.FinishMob = new List<S_FinishMob>();
		this.RewardItem = new List<S_TmpItem>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Quest))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.Hint = GameDataDB.TransStringByLanguageType(this.Hint);
		this.RoleGroupName = GameDataDB.TransStringByLanguageType(this.RoleGroupName);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 5; i++)
		{
			S_Flag s_Flag = new S_Flag();
			s_Flag.Flag = 0;
			s_Flag.FlagON = 0;
			string key = string.Format("PreFlag_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_Flag.Flag);
			}
			key = string.Format("PreFlagON_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_Flag.FlagON);
			}
			this.PreFlag.Add(s_Flag);
		}
		for (int j = 0; j < 3; j++)
		{
			S_TmpItem s_TmpItem = new S_TmpItem();
			s_TmpItem.ID = 0;
			string key2 = string.Format("PreItem_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_TmpItem.ID);
			}
			key2 = string.Format("PreItemCount_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out s_TmpItem.Count);
			}
			if (s_TmpItem.ID > 0)
			{
				this.PreItem.Add(s_TmpItem);
			}
		}
		for (int k = 0; k < 3; k++)
		{
			S_TmpItem s_TmpItem2 = new S_TmpItem();
			s_TmpItem2.ID = 0;
			string key3 = string.Format("GiveItem_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string s3 = dictionary[key3];
				int.TryParse(s3, out s_TmpItem2.ID);
			}
			key3 = string.Format("GiveItemCount_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string s3 = dictionary[key3];
				int.TryParse(s3, out s_TmpItem2.Count);
			}
			if (s_TmpItem2.ID > 0)
			{
				this.GiveItem.Add(s_TmpItem2);
			}
		}
		for (int l = 0; l < 3; l++)
		{
			S_TmpItem s_TmpItem3 = new S_TmpItem();
			s_TmpItem3.ID = 0;
			string key4 = string.Format("FinishItem_{0}", l);
			if (dictionary.ContainsKey(key4))
			{
				string s4 = dictionary[key4];
				int.TryParse(s4, out s_TmpItem3.ID);
			}
			key4 = string.Format("FinishItemCount_{0}", l);
			if (dictionary.ContainsKey(key4))
			{
				string s4 = dictionary[key4];
				int.TryParse(s4, out s_TmpItem3.Count);
			}
			if (s_TmpItem3.ID > 0)
			{
				this.FinishItem.Add(s_TmpItem3);
			}
		}
		for (int m = 0; m < 3; m++)
		{
			S_FinishMob s_FinishMob = new S_FinishMob();
			s_FinishMob.ID = 0;
			string key5 = string.Format("FinishMob_{0}", m);
			if (dictionary.ContainsKey(key5))
			{
				string s5 = dictionary[key5];
				int.TryParse(s5, out s_FinishMob.ID);
			}
			key5 = string.Format("FinishMobCount_{0}", m);
			if (dictionary.ContainsKey(key5))
			{
				string s5 = dictionary[key5];
				int.TryParse(s5, out s_FinishMob.Count);
			}
			if (s_FinishMob.ID > 0)
			{
				this.FinishMob.Add(s_FinishMob);
			}
		}
		for (int n = 0; n < 5; n++)
		{
			S_Flag s_Flag2 = new S_Flag();
			s_Flag2.Flag = 0;
			s_Flag2.FlagON = 0;
			string key6 = string.Format("Flag_{0}", n);
			if (dictionary.ContainsKey(key6))
			{
				string s6 = dictionary[key6];
				int.TryParse(s6, out s_Flag2.Flag);
			}
			key6 = string.Format("FlagOn_{0}", n);
			if (dictionary.ContainsKey(key6))
			{
				string s6 = dictionary[key6];
				int.TryParse(s6, out s_Flag2.FlagON);
			}
			this.ReportFlag.Add(s_Flag2);
		}
		for (int num = 0; num < 5; num++)
		{
			S_TmpItem s_TmpItem4 = new S_TmpItem();
			s_TmpItem4.ID = 0;
			string key7 = string.Format("RewardItem_{0}", num);
			if (dictionary.ContainsKey(key7))
			{
				string s7 = dictionary[key7];
				int.TryParse(s7, out s_TmpItem4.ID);
			}
			key7 = string.Format("RewardItemCount_{0}", num);
			if (dictionary.ContainsKey(key7))
			{
				string s7 = dictionary[key7];
				int.TryParse(s7, out s_TmpItem4.Count);
			}
			if (s_TmpItem4.ID > 0)
			{
				this.RewardItem.Add(s_TmpItem4);
			}
		}
	}
}
