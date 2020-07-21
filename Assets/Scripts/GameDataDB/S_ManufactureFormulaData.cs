using System;

public class S_ManufactureFormulaData : I_BaseDBF
{
	public int GUID;

	public int ProductID;

	public int RequireStudy;

	public int RequireLevel;

	public int Material1ID;

	public int Material1Number;

	public int Material2ID;

	public int Material2Number;

	public int Material3ID;

	public int Material3Number;

	public int Material4ID;

	public int Material4Number;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
