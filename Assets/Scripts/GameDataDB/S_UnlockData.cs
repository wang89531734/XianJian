using System;
using System.Collections.Generic;
using System.Text;

public class S_UnlockData : I_BaseDBF
{
	public int GUID;

	public int Time;

	public int Loose;

	public List<int> CodeIDs = new List<int>();

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 4; i++)
		{
			string key = string.Format("Code_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int item;
				int.TryParse(s, out item);
				this.CodeIDs.Add(item);
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("解鎖密碼設定:");
		stringBuilder.Append("\n GUID:" + this.GUID);
		stringBuilder.Append("\n Time:" + this.Time);
		stringBuilder.Append("\n Loose:" + this.Loose);
		stringBuilder.Append("\n CodeIDs Size:" + this.CodeIDs.Count);
		for (int i = 0; i < this.CodeIDs.Count; i++)
		{
			stringBuilder.Append(string.Concat(new object[]
			{
				"\n CodeIDs[",
				i,
				"]:",
				this.CodeIDs[i]
			}));
		}
		return stringBuilder.ToString();
	}
}
