using System;
using System.Collections.Generic;

public class S_ItemEquip
{
	public int EquipChar;

	public int AttackEffectID;

	public string WeaponModelName_1;

	public string WeaponModelPoint_1;

	public string WeaponModelName_2;

	public string WeaponModelPoint_2;

	public string WeaponModelName_3;

	public string WeaponModelPoint_3;

	public int TreasureStone;

	public int RefineStone;

	public int FightStone;

	public int MeshAvatar;

	public List<S_NpcMaterail> Materail;

	public S_ItemEquip()
	{
		this.Materail = new List<S_NpcMaterail>();
	}

	public void ParseData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 3; i++)
		{
			S_NpcMaterail s_NpcMaterail = new S_NpcMaterail();
			string key = string.Format("MeshName_{0}", i);
			if (values.ContainsKey(key))
			{
				string text = values[key];
				s_NpcMaterail.MeshName = text;
			}
			key = string.Format("MaterailName_{0}", i);
			if (values.ContainsKey(key))
			{
				string text = values[key];
				s_NpcMaterail.MaterailName = text;
			}
			this.Materail.Add(s_NpcMaterail);
		}
	}
}
