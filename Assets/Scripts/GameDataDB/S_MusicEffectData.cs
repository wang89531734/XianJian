using System;

public class S_MusicEffectData : I_BaseDBF
{
	public int GUID;

	public string MusicEffectName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
