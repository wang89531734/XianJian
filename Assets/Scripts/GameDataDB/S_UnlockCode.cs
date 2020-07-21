using System;

public class S_UnlockCode : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string Hint;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Hint = GameDataDB.TransStringByLanguageType(this.Hint);
	}
}
