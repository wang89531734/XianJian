using System;
using System.Collections.Generic;

public class S_Level : I_BaseDBF
{
	public int GUID;

	public int Level;

	public int NextExp;

	public int MaxHP;

	public int MaxMP;

	public int Atk;

	public int Def;

	public int MAtk;

	public int MDef;

	public int Agi;

	public int Block;

	public int Dodage;

	public int Critical;

	public int LearnSkillID;

	public int SkillPoint;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Level))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
	}
}
