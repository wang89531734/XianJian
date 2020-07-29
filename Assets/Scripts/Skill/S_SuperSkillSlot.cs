using System;

public class S_SuperSkillSlot : I_BaseDBF
{
	public int GUID;

	public ENUM_SuperSkillCombo emCombo;

	public int ComboCode;

	public int Level;

	public int LearnRole;

	public int Motion;

	public string Name;

	public string IconNo;

	public string Desc;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
	}
}
