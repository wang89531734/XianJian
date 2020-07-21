using System;

public class S_AnimationData : I_BaseDBF
{
	public int GUID;

	public string ClipName;

	public int LoadClip;

	public int FolderType;

	public string Help;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Help = GameDataDB.TransStringByLanguageType(this.Help);
	}
}
