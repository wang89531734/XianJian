using System;
using UnityEngine;

public class S_TalkString : I_BaseDBF
{
	public int GUID;

	public string Str;

	public int OSID;

	public int FaceFXID;

	public int FacePart;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("TalkString_" + this.GUID);
		}
		this.Str = GameDataDB.TransStringByLanguageType(this.Str);
		if (this.Str != null)
		{
			this.Str = this.Str.Replace("\\n", "\n");
		}
	}
}
