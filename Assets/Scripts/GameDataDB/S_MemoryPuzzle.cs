using System;
using System.Collections.Generic;
using System.Text;

public class S_MemoryPuzzle : I_BaseDBF
{
	public int GUID;

	public string PicName;

	public int GameTime;

	public int PreviewTime;

	public float ShowTime;

	public int Loose;

	public List<int> PicIDs = new List<int>();

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 9; i++)
		{
			string key = string.Format("PicID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int item;
				int.TryParse(s, out item);
				this.PicIDs.Add(item);
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("記憶拼圖資料:");
		stringBuilder.Append("\n PicName:" + this.PicName);
		stringBuilder.Append("\n GameTime:" + this.GameTime);
		stringBuilder.Append("\n PreviewTime:" + this.PreviewTime);
		stringBuilder.Append("\n ShowTime:" + this.ShowTime);
		stringBuilder.Append("\n Loose:" + this.Loose);
		stringBuilder.Append("\n PicIDs Size:" + this.PicIDs.Count);
		for (int i = 0; i < this.PicIDs.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n PicIDs[",
				i,
				"]:",
				this.PicIDs[i]
			}));
		}
		return stringBuilder.ToString();
	}
}
