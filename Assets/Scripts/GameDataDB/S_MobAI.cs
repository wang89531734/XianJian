using System;

public class S_MobAI : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int AttackProb;

	public int SkillProb;

	public int DefenceProb;

	public int EscapeProb;

	public int Match;

	public string Tip;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Tip = GameDataDB.TransStringByLanguageType(this.Tip);
	}
}
