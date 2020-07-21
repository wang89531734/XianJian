using System;
using System.Collections.Generic;

public class S_MapConnect : I_BaseDBF
{
	public int GUID;

	public List<MapConnectNode> ConnectNode;

	public S_MapConnect()
	{
		this.ConnectNode = new List<MapConnectNode>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_MapConnect))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 30; i++)
		{
			MapConnectNode mapConnectNode = new MapConnectNode();
			string key = string.Format("TP_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				mapConnectNode.Name = dictionary[key];
			}
			key = string.Format("MapID_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out mapConnectNode.MapID);
			}
			key = string.Format("MapID1_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out mapConnectNode.MapID1);
			}
			key = string.Format("MapID2_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out mapConnectNode.MapID2);
			}
			key = string.Format("Group_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out mapConnectNode.Group);
			}
			if (mapConnectNode.MapID > 0)
			{
				this.ConnectNode.Add(mapConnectNode);
			}
		}
	}
}
