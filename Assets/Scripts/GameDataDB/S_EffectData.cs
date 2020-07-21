using System;

public class S_EffectData : I_BaseDBF
{
	public int GUID;

	public string EffectName;

	public string Help;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
