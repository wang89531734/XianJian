using System;
using System.Collections.Generic;
using UnityEngine;

public class S_NpcData : I_BaseDBF
{
	public int GUID;

	public int MapID;

	public string NickName;

	public string Name;

	public string PrefName;

	public string AnimatorController;

	public string RootName;

	public ENUM_NpcType emType;

	public ENUM_NpcShopType emShopType;

	public string ShopScript;

	public ENUM_GameObjFlag emState;

	public int Motion;

	public int FaceMotion;

	public int DataID;

	public int MapIconID;

	public string MapIcon;

	public string Talk;

	public string SneakTalk;

	public int AIMode;

	public float FarTalkRange;

	public float LookAtRange;

	public int TalkTurn;

	public float MouseTalkRange;

	public int Pick;

	public int ShowMapIcon;

	public int Show;

	public int Disable;

	public int NoCollider;

	public int Ground;

	public ENUM_ActionHint emActionHint;

	public List<int> BubbleTalk;

	public List<int> NormalTalk;

	public List<S_NpcMaterail> Materail;

	public List<string> DisableRenderer;

	public int Region;

	public string FaceFxFolder;

	public List<string> AnimFolderTypes;

	public S_NpcData()
	{
		this.BubbleTalk = new List<int>();
		this.NormalTalk = new List<int>();
		this.Materail = new List<S_NpcMaterail>();
		this.DisableRenderer = new List<string>();
		this.AnimFolderTypes = new List<string>();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_NpcData))
		{
			return;
		}
		this.NickName = GameDataDB.TransStringByLanguageType(this.NickName);
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 2; i++)
		{
			int item = 0;
			string key = string.Format("BubbleTalk_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out item);
				this.BubbleTalk.Add(item);
			}
		}
		for (int j = 0; j < 3; j++)
		{
			int item2 = 0;
			string key2 = string.Format("NormalTalk_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out item2);
				this.NormalTalk.Add(item2);
			}
		}
		for (int k = 0; k < 5; k++)
		{
			S_NpcMaterail s_NpcMaterail = new S_NpcMaterail();
			string key3 = string.Format("MeshName_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string text = dictionary[key3];
				s_NpcMaterail.MeshName = text;
			}
			key3 = string.Format("MaterailName_{0}", k);
			if (dictionary.ContainsKey(key3))
			{
				string text = dictionary[key3];
				s_NpcMaterail.MaterailName = text;
			}
			this.Materail.Add(s_NpcMaterail);
		}
		for (int l = 0; l < 2; l++)
		{
			string key4 = string.Format("DisableRenderer_{0}", l);
			if (dictionary.ContainsKey(key4))
			{
				string text2 = dictionary[key4];
				if (text2 != null)
				{
					this.DisableRenderer.Add(text2);
				}
			}
		}
		for (int m = 0; m < 3; m++)
		{
			string key5 = string.Format("AnimFolderType_{0}", m);
			if (dictionary.ContainsKey(key5))
			{
				string text3 = dictionary[key5];
				if (text3 != null)
				{
					this.AnimFolderTypes.Add(text3);
				}
			}
		}
	}
}
