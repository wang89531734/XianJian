using System;

public class S_MovieSubtitleData : I_BaseDBF
{
	public int GUID;

	public int GroupID;

	public int OSID;

	public int Min;

	public int Sec;

	public int DisplayTime;

	public int Pos;

	public string Subtitle;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
