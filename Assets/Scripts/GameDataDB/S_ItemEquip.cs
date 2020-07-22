using System;
using System.Collections.Generic;

public class S_ItemEquip
{
	public int EquipChar;

	public string WeaponModelName;

	public string WeaponModelPoint;

	public List<string> WeaponTrail;

	public int TreasureStone;

	public int RefineStone;

	public int FightStone;

	public int MeshAvatar;

	public List<S_NpcMaterail> Materail;

	public S_ItemEquip()
	{
		this.WeaponTrail = new List<string>();
		this.Materail = new List<S_NpcMaterail>();
	}

	public void ParseData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 5; i++)
		{
			string item = string.Empty;
			string key = string.Format("WeaponTrail_{0}", i);
			if (values.ContainsKey(key))
			{
				item = values[key];
			}
			this.WeaponTrail.Add(item);
		}
		for (int j = 0; j < 3; j++)
		{
			S_NpcMaterail s_NpcMaterail = new S_NpcMaterail();
			string key2 = string.Format("MeshName_{0}", j);
			if (values.ContainsKey(key2))
			{
				string text = values[key2];
				s_NpcMaterail.MeshName = text;
			}
			key2 = string.Format("MaterailName_{0}", j);
			if (values.ContainsKey(key2))
			{
				string text = values[key2];
				s_NpcMaterail.MaterailName = text;
			}
			this.Materail.Add(s_NpcMaterail);
		}
	}
}
