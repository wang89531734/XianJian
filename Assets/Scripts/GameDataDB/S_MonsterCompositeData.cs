using System;

public class S_MonsterCompositeData : I_BaseDBF
{
	public int GUID;

	public string A;

	public string B;

	public string C;

	public string D;

	public string E;

	public string F;

	public string G;

	public string H;

	public string I;

	public string J;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
