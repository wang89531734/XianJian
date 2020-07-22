using System;
using System.Collections.Generic;
using UnityEngine;

public class S_MapData : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string Desc;

	public string BigMapEvent;

	public List<string> MiniMap;

	public List<int> MaskClearCount;

	public ENUM_MapType emType;

	public ENUM_MoveType emMove;

	public ENUM_ActionSkill emActionSkill;

	public int MapMarkFlag;

	public int MapNewHintFlag;

	public int MapUnActiveFlag;

	public int DlcMapMarkFlag;

	public int AutoMove;

	public int SwitchRole;

	public int Fight;

	public int Save;

	public int SkyID;

	public int MusicID1;

	public int MusicID2;

	public ENUM_MusicMode emMusicMode;

	public int MinRandTalk;

	public int MaxRandTalk;

	public int FightAmbient_R;

	public int FightAmbient_G;

	public int FightAmbient_B;

	public string AssetBundleName;

	public string LoadBG;

	public string LoadInfo;

	public List<S_MapTeleport> Teleport;

	public S_MapData()
	{
		this.MiniMap = new List<string>();
		this.MaskClearCount = new List<int>();
		this.Teleport = new List<S_MapTeleport>();
		this.SkyID = -1;
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.LoadInfo = GameDataDB.TransStringByLanguageType(this.LoadInfo);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 10; i++)
		{
			string text = string.Empty;
			string key = string.Format("MiniMap_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				text = dictionary[key];
				if (text != string.Empty)
				{
					this.MiniMap.Add(text);
				}
			}
		}
		for (int j = 0; j < 10; j++)
		{
			string s = string.Empty;
			int item = 0;
			string key2 = string.Format("MaskClearCount_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				s = dictionary[key2];
				int.TryParse(s, out item);
			}
			this.MaskClearCount.Add(item);
		}
		for (int k = 0; k < 3; k++)
		{
			S_MapTeleport s_MapTeleport = new S_MapTeleport();
			string text2 = string.Empty;
			string key3 = string.Format("TeleportName_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				text2 = dictionary[key3];
				s_MapTeleport.Name = text2;
			}
			key3 = string.Format("TeleportDesc_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				text2 = dictionary[key3];
				s_MapTeleport.Desc = text2;
				s_MapTeleport.Desc = GameDataDB.TransStringByLanguageType(s_MapTeleport.Desc);
			}
			key3 = string.Format("TeleportFlag_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				text2 = dictionary[key3];
				int.TryParse(text2, out s_MapTeleport.Flag);
			}
			this.Teleport.Add(s_MapTeleport);
		}
	}
}
