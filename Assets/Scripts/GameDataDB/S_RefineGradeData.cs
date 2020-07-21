using System;

public class S_RefineGradeData : I_BaseDBF
{
	public int GUID;

	public int emGradeType;

	public int AddAttack;

	public int AddDef;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
