using System;

public class S_Atlas : I_BaseDBF
{
	public int GUID;

	public string AtlasName;

	public int Index;

	public string SpriteName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
