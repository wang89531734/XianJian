using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Item : I_BaseDBF
{
	public int GUID;

	public ENUM_ItemType emItemType;

	public ENUM_ItemSubType emSubItemType;

	public ENUM_MaterialType emMaterialTyep;

	public string Name;

	public int IconNo;

	public string StoryPrefabName;

	public string ShowPrefabName;

	public string Desc;

	public string Help;

	public int ItemLevel;

	public int UseLevel;

	public int UseDelete;

	public int UsePoint;

	public int MaxHeap;

	public int BuyCost;

	public int CanSell;

	public int CanDrop;

	public int CanSmithing;

	public int CanRefine;

	public int EquipShowVer;

	public int RoleAttrPlusID;

	public S_ItemNormal Normal;

	public S_ItemEquip Equip;

	public S_ItemMagic MItem;

	public S_MobData MobData;

	public int UseEffectID;

	public S_Item()
	{
		this.Normal = new S_ItemNormal();
		this.Equip = new S_ItemEquip();
		this.MItem = new S_ItemMagic();
		this.MobData = new S_MobData();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("Item_" + this.GUID);
		}
		if (!(Record is S_Item))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.Help = GameDataDB.TransStringByLanguageType(this.Help);
		if (this.Help != null)
		{
			this.Help = this.Help.Replace("\\n", "\n");
		}
		if (this.Desc != null)
		{
			this.Desc = this.Desc.Replace("\\n", "\n");
		}
		Dictionary<string, string> values = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		switch (this.emItemType)
		{
		case ENUM_ItemType.Normal:
			this.Normal = Converter.deserializeObject<S_ItemNormal>(JsonString);
			break;
		case ENUM_ItemType.Equip:
			this.Equip = Converter.deserializeObject<S_ItemEquip>(JsonString);
			this.Equip.ParseData(values);
			break;
		case ENUM_ItemType.MagicItem:
			this.Equip = Converter.deserializeObject<S_ItemEquip>(JsonString);
			this.Equip.ParseData(values);
			this.MItem = Converter.deserializeObject<S_ItemMagic>(JsonString);
			this.MItem.ParseData(values);
			break;
		case ENUM_ItemType.Mob:
			this.MobData = Converter.deserializeObject<S_MobData>(JsonString);
			this.ParseMobData(values);
			break;
		}
	}

	public void ParseMobData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 4; i++)
		{
			int num = 0;
			string key = string.Format("DefElement_{0}", i);
			if (values.ContainsKey(key))
			{
				string s = values[key];
				int.TryParse(s, out num);
			}
			this.MobData.DefElement[i] = num;
		}
		for (int j = 0; j < 3; j++)
		{
			int num2 = 0;
			string key2 = string.Format("Attack_{0}", j);
			if (values.ContainsKey(key2))
			{
				string s2 = values[key2];
				int.TryParse(s2, out num2);
			}
			if (j == 2 && num2 > 0)
			{
				this.MobData.CriticalEffect = num2;
			}
			else if (num2 > 0)
			{
				this.MobData.AttackEffect.Add(num2);
			}
		}
		for (int k = 0; k < 4; k++)
		{
			int num3 = 0;
			string key3 = string.Format("NormalSkillID_{0}", k);
			if (values.ContainsKey(key3))
			{
				string s3 = values[key3];
				int.TryParse(s3, out num3);
			}
			if (num3 > 0)
			{
				this.MobData.NormalSkillID.Add(num3);
			}
		}
		for (int l = 0; l < 4; l++)
		{
			int num4 = 0;
			string key4 = string.Format("NormalSkillRate_{0}", l);
			if (values.ContainsKey(key4))
			{
				string s4 = values[key4];
				int.TryParse(s4, out num4);
			}
			if (num4 >= 0)
			{
				this.MobData.NormalSkillRate.Add(num4);
			}
		}
		for (int m = 0; m < 2; m++)
		{
			int num5 = 0;
			string key5 = string.Format("StartSkillID_{0}", m);
			if (values.ContainsKey(key5))
			{
				string s5 = values[key5];
				int.TryParse(s5, out num5);
			}
			if (num5 > 0)
			{
				this.MobData.StartSkillID.Add(num5);
			}
		}
		for (int n = 0; n < 4; n++)
		{
			int num6 = 0;
			string key6 = string.Format("HpSkillID_{0}", n);
			if (values.ContainsKey(key6))
			{
				string s6 = values[key6];
				int.TryParse(s6, out num6);
			}
			if (num6 > 0)
			{
				this.MobData.HpSkillID.Add(num6);
			}
		}
		for (int num7 = 0; num7 < 4; num7++)
		{
			int num8 = 0;
			string key7 = string.Format("HpSkillHP_{0}", num7);
			if (values.ContainsKey(key7))
			{
				string s7 = values[key7];
				int.TryParse(s7, out num8);
			}
			if (num8 > 0)
			{
				this.MobData.HpSkillHP.Add(num8);
			}
		}
		for (int num9 = 0; num9 < 5; num9++)
		{
			S_DropItem s_DropItem = new S_DropItem();
			string key8 = string.Format("DropItemID_{0}", num9);
			if (values.ContainsKey(key8))
			{
				string s8 = values[key8];
				int.TryParse(s8, out s_DropItem.ID);
			}
			key8 = string.Format("DropCount_{0}", num9);
			if (values.ContainsKey(key8))
			{
				string s8 = values[key8];
				int.TryParse(s8, out s_DropItem.Count);
			}
			key8 = string.Format("DropRate_{0}", num9);
			if (values.ContainsKey(key8))
			{
				string s8 = values[key8];
				int.TryParse(s8, out s_DropItem.Rate);
			}
			if (s_DropItem.ID > 0)
			{
				this.MobData.DropItem.Add(s_DropItem);
			}
		}
	}
}
