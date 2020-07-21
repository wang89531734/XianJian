using System;
using System.Collections.Generic;
using UnityEngine;

public class S_PartnerTalk : I_BaseDBF
{
	public int GUID;

	public int GroupID;

	public int FinishFlag;

	public int MapID;

	public int QuestID;

	public List<S_Flag> Flag;

	public int ItemID;

	public int PartyRoleID;

	public int TalkRoleID;

	public int EMotionID;

	public int VoiceID;

	public string TalkMsg;

	public S_PartnerTalk()
	{
		this.Flag = new List<S_Flag>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_PartnerTalk))
		{
			return;
		}
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("PartnerTalk_" + this.GUID);
		}
		this.TalkMsg = GameDataDB.TransStringByLanguageType(this.TalkMsg);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 5; i++)
		{
			S_Flag s_Flag = new S_Flag();
			s_Flag.Flag = 0;
			s_Flag.FlagON = 0;
			string key = string.Format("FlagID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_Flag.Flag);
			}
			key = string.Format("FlagON_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_Flag.FlagON);
			}
			this.Flag.Add(s_Flag);
		}
	}
}
