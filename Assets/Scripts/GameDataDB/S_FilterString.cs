using System;

public class S_FilterString : I_BaseDBF
{
	public int GUID;

	public string Str;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Str = GameDataDB.TransStringByLanguageType(this.Str);
	}
}
