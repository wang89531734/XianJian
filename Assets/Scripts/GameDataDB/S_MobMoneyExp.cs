using System;

public class S_MobMoneyExp : I_BaseDBF
{
	public int GUID;

	public int Basic;

	public int Reference;

	public float Count;

	public float Ratio;

	public int IntervalExp;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
