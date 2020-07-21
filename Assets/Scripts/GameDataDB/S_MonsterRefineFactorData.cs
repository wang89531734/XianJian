using System;

public class S_MonsterRefineFactorData : I_BaseDBF
{
	public int GUID;

	public int emRace;

	public float Factor;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
