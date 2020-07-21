using System;

public class S_OSData : I_BaseDBF
{
	public int GUID;

	public string OSName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
