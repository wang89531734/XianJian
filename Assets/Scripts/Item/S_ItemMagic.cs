using System;
using System.Collections.Generic;

public class S_ItemMagic
{
	public int MaxLevel;

	public int PerCountExp;

	public int ExtraExp;

	public List<float> AttrEffect;

	public S_ItemMagic()
	{
		this.AttrEffect = new List<float>();
	}

	public void ParseData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 20; i++)
		{
			float item = 0f;
			string key = string.Format("AttrEffect_{0}", i);
			if (values.ContainsKey(key))
			{
				string s = values[key];
				float.TryParse(s, out item);
			}
			this.AttrEffect.Add(item);
		}
	}
}
