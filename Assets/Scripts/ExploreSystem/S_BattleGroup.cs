using System;
using System.Collections.Generic;

public class S_BattleGroup : I_BaseDBF
{
	public int GUID;

	public string BattleCenterPoint;

	public string FightCamera;

	public string FightCameraPoint;

	public string FightCameraPath;

	public int FightMusic;

	public string FightTalk;

	public List<S_BattleMobData> BattleMob = new List<S_BattleMobData>();

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_BattleGroup))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 6; i++)
		{
			S_BattleMobData s_BattleMobData = new S_BattleMobData();
			string key = string.Format("MobID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				int.TryParse(text, out s_BattleMobData.GUID);
            }
			key = string.Format("MobTargetPos_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				s_BattleMobData.TargetPosName = text;
			}
			if (s_BattleMobData.GUID > 0)
			{
				this.BattleMob.Add(s_BattleMobData);
			}
		}
	}
}
