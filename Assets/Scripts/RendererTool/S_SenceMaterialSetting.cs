using System;
using System.Collections.Generic;

public class S_SenceMaterialSetting : I_BaseDBF
{
	public int GUID;

	public Dictionary<string, S_MaterialSetting> Settings;

	public S_SenceMaterialSetting()
	{
		this.Settings = new Dictionary<string, S_MaterialSetting>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 18; i++)
		{
			S_MaterialSetting s_MaterialSetting = new S_MaterialSetting();
			string text = string.Empty;
			string key = string.Format("ID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				text = dictionary[key];
				if (!string.IsNullOrEmpty(text))
				{
					this.Settings.Add(text, s_MaterialSetting);
				}
			}
			key = string.Format("IBL_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				text = dictionary[key];
				float.TryParse(text, out s_MaterialSetting.IBL);
			}
			key = string.Format("Saturation_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				text = dictionary[key];
				float.TryParse(text, out s_MaterialSetting.Saturation);
			}
		}
	}
}
