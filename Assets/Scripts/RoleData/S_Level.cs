using System;
using System.Collections.Generic;

public class S_Level : I_BaseDBF
{
	public int GUID;

	public int Level;

	public int NextExp;

	public int MaxHP;

	public int MaxMP;

	public int MaxAP;

	public int Str;

	public int Mag;

	public int Sta;

	public int Air;

	public int Agi;

	public int Block;

	public int Luck;

	public int Critical;

	public int Mind;

	public ENUM_ElementType emElemntType;

	public int[] Element;

	public S_Level()
	{
		this.Element = new int[6];
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Level))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 6; i++)
		{
			int num = 0;
			string key = string.Format("Element_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out num);
			}
			this.Element[i] = num;
		}
	}
}
