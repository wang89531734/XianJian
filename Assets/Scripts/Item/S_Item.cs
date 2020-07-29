using System;
using System.Collections.Generic;
using UnityEngine;

public class S_Item : I_BaseDBF
{
	public int GUID;

	public ENUM_ItemType emItemType;

	public ENUM_ItemSubType emSubItemType;

	public string Name;

	public string IconNo;

	public string StoryPrefabName;

	public string Desc;

	public string Help;

	public int ItemLevel;

	public int ItemRank;

	public int UseLevel;

	public int UseDelete;

	public int UsePoint;

	public int MaxHeap;

	public int BuyCost;

	public int CanSell;

	public int CanDrop;

	public int CanSmithing;

	public int CanRefine;

	public int CanThrowing;

	public int RoleAttrPlusID;

	public S_ItemNormal Normal;

	public S_ItemEquip Equip;

	public S_ItemMagic MItem;

	public S_MobData MobData;

	public S_UseEffect UseEffect;

	public S_Item()
	{
		this.Normal = new S_ItemNormal();
		this.Equip = new S_ItemEquip();
		this.MItem = new S_ItemMagic();
		this.MobData = new S_MobData();
		this.UseEffect = new S_UseEffect();
	}

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_Item))
		{
			return;
		}
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Desc = GameDataDB.TransStringByLanguageType(this.Desc);
		this.Help = GameDataDB.TransStringByLanguageType(this.Help);
		Dictionary<string, string> values = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		switch (this.emItemType)
		{
		case ENUM_ItemType.Normal:
			this.Normal = Converter.deserializeObject<S_ItemNormal>(JsonString);
			this.UseEffect = Converter.deserializeObject<S_UseEffect>(JsonString);
			this.UseEffect.ParseData(values);
			return;
		case ENUM_ItemType.Equip:
			this.Equip = Converter.deserializeObject<S_ItemEquip>(JsonString);
			this.Equip.ParseData(values);
			this.UseEffect = Converter.deserializeObject<S_UseEffect>(JsonString);
			this.UseEffect.ParseData(values);
			return;
		case ENUM_ItemType.MagicItem:
			this.Equip = Converter.deserializeObject<S_ItemEquip>(JsonString);
			this.Equip.ParseData(values);
			this.MItem = Converter.deserializeObject<S_ItemMagic>(JsonString);
			this.MItem.ParseData(values);
			return;
		case ENUM_ItemType.Mob:
			this.MobData = Converter.deserializeObject<S_MobData>(JsonString);
			this.ParseMobData(values);
			return;
		default:
			return;
		}
	}

	public void ParseMobData(Dictionary<string, string> values)
	{
		for (int i = 0; i < 6; i++)
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
		for (int k = 0; k < 10; k++)
		{
			int num3 = 0;
			string key3 = string.Format("Skill_{0}", k);
			if (values.ContainsKey(key3))
			{
				string s3 = values[key3];
				int.TryParse(s3, out num3);
			}
			if (num3 > 0)
			{
				this.MobData.Skill.Add(num3);
			}
		}
		for (int l = 0; l < 10; l++)
		{
			int num4 = 0;
			string key4 = string.Format("SkillRate_{0}", l);
			if (values.ContainsKey(key4))
			{
				string s4 = values[key4];
				int.TryParse(s4, out num4);
			}
			if (num4 > 0)
			{
				this.MobData.SkillRate.Add(num4);
			}
		}
		for (int m = 0; m < 10; m++)
		{
			int item = 0;
			string key5 = string.Format("SkillLastHP_{0}", m);
			if (values.ContainsKey(key5))
			{
				string s5 = values[key5];
				int.TryParse(s5, out item);
			}
			this.MobData.SkillLastHP.Add(item);
		}
		for (int n = 0; n < 10; n++)
		{
			int item2 = 0;
			string key6 = string.Format("SkillCount_{0}", n);
			if (values.ContainsKey(key6))
			{
				string s6 = values[key6];
				int.TryParse(s6, out item2);
			}
			this.MobData.SkillCount.Add(item2);
		}
		for (int num5 = 0; num5 < 5; num5++)
		{
			S_DropItem s_DropItem = new S_DropItem();
			string key7 = string.Format("DropItemID_{0}", num5);
			if (values.ContainsKey(key7))
			{
				string s7 = values[key7];
				int.TryParse(s7, out s_DropItem.ID);
			}
			key7 = string.Format("DropCount_{0}", num5);
			if (values.ContainsKey(key7))
			{
				string s7 = values[key7];
				int.TryParse(s7, out s_DropItem.Count);
			}
			key7 = string.Format("DropRate_{0}", num5);
			if (values.ContainsKey(key7))
			{
				string s7 = values[key7];
				int.TryParse(s7, out s_DropItem.Rate);
			}
			if (s_DropItem.ID > 0)
			{
				this.MobData.DropItem.Add(s_DropItem);
			}
		}
	}
}
