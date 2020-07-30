using System;
using System.Collections.Generic;
using UnityEngine;

public class S_MapData : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string Desc;

	public List<string> MiniMap;

	public List<int> MaskClearCount;

	public ENUM_MapType emType;

	public ENUM_MoveType emMove;

	public ENUM_ActionSkill emActionSkill;

	public int MapMarkFlag;

	public int DlcMapMarkFlag;

	public int AutoMove;

	public int SwitchRole;

	public int Fight;

	public int Save;

	public int MusicID1;

	public int MusicID2;

	public ENUM_MusicMode emMusicMode;

	public int MinRandTalk;

	public int MaxRandTalk;

	public int FightAmbient_R;

	public int FightAmbient_G;

	public int FightAmbient_B;

	public string AssetBundleName;

	public int ViewDistance;

	public S_MapData()
	{
		this.MiniMap = new List<string>();
		this.MaskClearCount = new List<int>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 10; i++)
		{
			string key = string.Format("MiniMap_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				if (text != "")
				{
					this.MiniMap.Add(text);
				}
			}
		}
		for (int j = 0; j < 6; j++)
		{
			int item = 0;
			string key2 = string.Format("MaskClearCount_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s = dictionary[key2];
				int.TryParse(s, out item);
			}
			this.MaskClearCount.Add(item);
		}
	}
}
