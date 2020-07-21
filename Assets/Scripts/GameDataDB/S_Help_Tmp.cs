using System;
using System.Collections.Generic;
using System.Text;

public class S_Help_Tmp : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int PrevGUID;

	public int ContentCount;

	public List<S_HelpInfo> Infos = new List<S_HelpInfo>();

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < this.ContentCount; i++)
		{
			if (this.PrevGUID < 0)
			{
				this.ContentCount = 0;
				break;
			}
			S_HelpInfo s_HelpInfo = new S_HelpInfo();
			string key = string.Format("InfoImg_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				s_HelpInfo.InfoImg = text;
			}
			key = string.Format("InfoStr_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				text = GameDataDB.TransStringByLanguageType(text);
				string[] separator = new string[]
				{
					"[P]"
				};
				s_HelpInfo.InfoStr = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				if (s_HelpInfo.InfoStr != null)
				{
					for (int j = 0; j < s_HelpInfo.InfoStr.Length; j++)
					{
						s_HelpInfo.InfoStr[j] = s_HelpInfo.InfoStr[j].Replace("\\n", "\n");
					}
				}
			}
			key = string.Format("Animation_w_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				float animation_w;
				float.TryParse(text, out animation_w);
				s_HelpInfo.Animation_w = animation_w;
			}
			key = string.Format("Animation_h_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				float animation_h;
				float.TryParse(text, out animation_h);
				s_HelpInfo.Animation_h = animation_h;
			}
			key = string.Format("Animation_x_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				float animation_x;
				float.TryParse(text, out animation_x);
				s_HelpInfo.Animation_x = animation_x;
			}
			key = string.Format("Animation_y_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				float animation_y;
				float.TryParse(text, out animation_y);
				s_HelpInfo.Animation_y = animation_y;
			}
			key = string.Format("Title_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string text = dictionary[key];
				s_HelpInfo.Title = GameDataDB.TransStringByLanguageType(text);
			}
			this.Infos.Add(s_HelpInfo);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("小幫手:");
		stringBuilder.Append("\n Name:" + this.Name);
		stringBuilder.Append("\n PrevGUID:" + this.PrevGUID);
		stringBuilder.Append("\n ContentCount:" + this.ContentCount);
		stringBuilder.Append("\n Infos Size:" + this.Infos.Count);
		for (int i = 0; i < this.Infos.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].InfoImg:",
				this.Infos[i].InfoImg
			}));
			for (int j = 0; j < this.Infos[i].InfoStr.Length; j++)
			{
				stringBuilder.Append(string.Concat(new object[]
				{
					"\n CodeIDs[",
					i,
					"].InfoStr[",
					j,
					"]:",
					this.Infos[i].InfoStr[j]
				}));
			}
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].Animation_w:",
				this.Infos[i].Animation_w
			}));
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].Animation_h:",
				this.Infos[i].Animation_h
			}));
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].Animation_x:",
				this.Infos[i].Animation_x
			}));
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].Animation_y:",
				this.Infos[i].Animation_y
			}));
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"].Title:",
				this.Infos[i].Title
			}));
		}
		return stringBuilder.ToString();
	}
}
