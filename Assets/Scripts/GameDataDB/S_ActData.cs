using System;

public class S_ActData : I_BaseDBF
{
	public int GUID;

	public string ActName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
