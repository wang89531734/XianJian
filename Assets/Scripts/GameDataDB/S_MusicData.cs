using System;

public class S_MusicData : I_BaseDBF
{
	public int GUID;

	public string MusicName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
