using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class C_RoleDataEx : S_RoleData
{
	private Dictionary<int, Buff_Base> m_Buffs;

	private List<Buff_Base> m_NoRemoveBuffs;

	private FormationData m_FormationData;

	private int m_FormationUnitIdx;

	public void SetLevel(int Value)
	{
		this.BaseRoleData.Level = Value;
	}

	public int GetLevel()
	{
		return this.BaseRoleData.Level;
	}

	public void SetHP(int Value)
	{
		int maxHP = this.RoleAttr.sFinial.MaxHP;
		if (Value > maxHP)
		{
			Value = maxHP;
		}
		if (Value < 0)
		{
			Value = 0;
		}
		this.BaseRoleData.HP = Value;
	}

	public void AddHP(int Value)
	{
		this.BaseRoleData.HP += Value;
		int maxHP = this.RoleAttr.sFinial.MaxHP;
		if (this.BaseRoleData.HP > maxHP)
		{
			this.BaseRoleData.HP = maxHP;
		}
		if (this.BaseRoleData.HP < 0)
		{
			this.BaseRoleData.HP = 0;
		}
	}

	public void AddHP(float Percent)
	{
		int num = (int)((float)this.RoleAttr.sFinial.MaxHP * Percent) / 100;
		this.BaseRoleData.HP += num;
		int maxHP = this.RoleAttr.sFinial.MaxHP;
		if (this.BaseRoleData.HP > maxHP)
		{
			this.BaseRoleData.HP = maxHP;
		}
		if (this.BaseRoleData.HP < 0)
		{
			this.BaseRoleData.HP = 0;
		}
	}

	public int GetHP()
	{
		return this.BaseRoleData.HP;
	}

	public void SetMP(int Value)
	{
		int maxMP = this.RoleAttr.sFinial.MaxMP;
		if (Value > maxMP)
		{
			Value = maxMP;
		}
		if (Value < 0)
		{
			Value = 0;
		}
		this.BaseRoleData.MP = Value;
	}

	public void AddMP(int Value)
	{
		this.BaseRoleData.MP += Value;
		int maxMP = this.RoleAttr.sFinial.MaxMP;
		if (this.BaseRoleData.MP > maxMP)
		{
			this.BaseRoleData.MP = maxMP;
		}
		if (this.BaseRoleData.MP < 0)
		{
			this.BaseRoleData.MP = 0;
		}
	}

	public void AddMP(float Percent)
	{
		int num = (int)((float)this.RoleAttr.sFinial.MaxMP * Percent) / 100;
		this.BaseRoleData.MP += num;
		int maxMP = this.RoleAttr.sFinial.MaxMP;
		if (this.BaseRoleData.MP > maxMP)
		{
			this.BaseRoleData.MP = maxMP;
		}
		if (this.BaseRoleData.MP < 0)
		{
			this.BaseRoleData.MP = 0;
		}
	}

	public int GetMP()
	{
		return this.BaseRoleData.MP;
	}

	public void SetFullHP()
	{
		this.BaseRoleData.HP = this.RoleAttr.sFinial.MaxHP;
	}

	public void SetFullMP()
	{
		this.BaseRoleData.MP = this.RoleAttr.sFinial.MaxMP;
	}

	public void AddUpBaseRoleAttr(int id, bool showmsg)
	{
		S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(id);
		if (data == null)
		{
			Debug.LogWarning("能力加成表讀取失敗_" + id);
			return;
		}
		string msg = string.Empty;
		if (data.RoleAttr_Plus.AddMaxHP > 0)
		{
			this.BaseRoleData.MaxHP += data.RoleAttr_Plus.AddMaxHP;
			msg = string.Format(GameDataDB.StrID(7450), data.RoleAttr_Plus.AddMaxHP);
		}
		if (data.RoleAttr_Plus.AddMaxMP > 0)
		{
			this.BaseRoleData.MaxMP += data.RoleAttr_Plus.AddMaxMP;
			msg = string.Format(GameDataDB.StrID(7451), data.RoleAttr_Plus.AddMaxMP);
		}
		if (data.RoleAttr_Plus.AddAttack > 0)
		{
			this.BaseRoleData.Atk += data.RoleAttr_Plus.AddAttack;
			msg = string.Format(GameDataDB.StrID(7452), data.RoleAttr_Plus.AddAttack);
		}
		if (data.RoleAttr_Plus.AddMAtk > 0)
		{
			this.BaseRoleData.MAtk += data.RoleAttr_Plus.AddMAtk;
			msg = string.Format(GameDataDB.StrID(7463), data.RoleAttr_Plus.AddMAtk);
		}
		if (data.RoleAttr_Plus.AddDef > 0)
		{
			this.BaseRoleData.Def += data.RoleAttr_Plus.AddDef;
			msg = string.Format(GameDataDB.StrID(7453), data.RoleAttr_Plus.AddDef);
		}
		if (data.RoleAttr_Plus.AddMDef > 0)
		{
			this.BaseRoleData.MDef += data.RoleAttr_Plus.AddMDef;
			msg = string.Format(GameDataDB.StrID(7464), data.RoleAttr_Plus.AddMDef);
		}
		if (data.RoleAttr_Plus.AddAgi > 0)
		{
			this.BaseRoleData.Agi += data.RoleAttr_Plus.AddAgi;
			msg = string.Format(GameDataDB.StrID(7454), data.RoleAttr_Plus.AddAgi);
		}
		if (data.RoleAttr_Plus.AddBlock > 0)
		{
			this.BaseRoleData.Block += data.RoleAttr_Plus.AddBlock;
			msg = string.Format(GameDataDB.StrID(7455), data.RoleAttr_Plus.AddBlock);
		}
		if (data.RoleAttr_Plus.AddDodge > 0)
		{
			this.BaseRoleData.Dodge += data.RoleAttr_Plus.AddDodge;
			msg = string.Format(GameDataDB.StrID(7465), data.RoleAttr_Plus.AddDodge);
		}
		if (data.RoleAttr_Plus.AddCritical > 0)
		{
			this.BaseRoleData.Critical += data.RoleAttr_Plus.AddCritical;
			msg = string.Format(GameDataDB.StrID(7456), data.RoleAttr_Plus.AddCritical);
		}
		for (int i = 0; i < 4; i++)
		{
			if (data.RoleAttr_Plus.Element[i] > 0)
			{
				this.BaseRoleData.Element[i] += data.RoleAttr_Plus.Element[i];
				msg = string.Format(GameDataDB.StrID(7610 + i) + GameDataDB.StrID(7470) + "+{0}", data.RoleAttr_Plus.Element[i]);
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (data.RoleAttr_Plus.AtkElement[j] > 0)
			{
				this.BaseRoleData.AtkElement[j] += data.RoleAttr_Plus.AtkElement[j];
				msg = string.Format(GameDataDB.StrID(7614 + j) + GameDataDB.StrID(7471) + "+{0}", data.RoleAttr_Plus.AtkElement[j]);
			}
		}
		this.CalRoleAttr();
		if (showmsg)
		{
			//UI_Message.Instance.ClearSysMsg();
			//UI_Message.Instance.AddSysMsg(msg, 3f);
		}
	}

    /// <summary>
    /// 计算角色属性
    /// </summary>
	public void CalRoleAttr()
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		S_RoleAttr s_RoleAttr2 = new S_RoleAttr();
		S_RoleAttr s_RoleAttr3 = new S_RoleAttr();
        this.CalRoleAttrPlus_OnEquip(s_RoleAttr);
        this.CalRoleAttr_Finial(s_RoleAttr);
        //this.CalRoleAttrPlus_OnPassiveSkill(s_RoleAttr2);//被动技能
        //this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr2);
        //this.CalRoleAttrPlus_OnMItem(s_RoleAttr3);//物品
        //this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr3);
        s_RoleAttr.sAttrPlus += s_RoleAttr2.sAttrPlus;
        s_RoleAttr.sAttrPlus += s_RoleAttr3.sAttrPlus;
        this.RoleAttr.sAttrPlus = s_RoleAttr.sAttrPlus;
        this.RoleAttr.sFinial = s_RoleAttr.sFinial;
    }

	public void CalRoleAttr_Fight()
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		S_RoleAttr s_RoleAttr2 = new S_RoleAttr();
		S_RoleAttr s_RoleAttr3 = new S_RoleAttr();
		this.CalRoleAttrPlus_OnEquip(s_RoleAttr);
		this.CalRoleAttrPlus_OnFormation(s_RoleAttr);
		this.CalRoleAttrPlus_OnBuff(s_RoleAttr);
		this.CalRoleAttr_Finial(s_RoleAttr);
		this.CalRoleAttrPlus_OnPassiveSkill(s_RoleAttr2);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr2);
		this.CalRoleAttrPlus_OnMItem(s_RoleAttr3);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr3);
		s_RoleAttr.sAttrPlus += s_RoleAttr2.sAttrPlus;
		s_RoleAttr.sAttrPlus += s_RoleAttr3.sAttrPlus;
		this.RoleAttr.sAttrPlus = s_RoleAttr.sAttrPlus;
		this.RoleAttr.sFinial = s_RoleAttr.sFinial;
	}

	private void CalRoleAttrPlus_OnEquip(S_RoleAttr roleAttr)
	{
		this.BaseRoleData.emWeaponElemntType = ENUM_ElementType.Physical;
		int num = 7;
		for (int i = 0; i < num; i++)
		{
			ItemData equipItemData = this.GetEquipItemData((ENUM_EquipPosition)i);
			if (equipItemData != null)
			{
				S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
				if (data != null)
				{
					if (data.emItemType != ENUM_ItemType.MagicItem)
					{
						if (data.emItemType == ENUM_ItemType.Equip)
						{
							this.DoRoleAttrPlus(roleAttr, data.RoleAttrPlusID);
							for (int j = 0; j < 3; j++)
							{
								if (equipItemData.RefineSoul[j] != 0)
								{
									S_Item data2 = GameDataDB.ItemDB.GetData(equipItemData.RefineSoul[j]);
									if (data2 != null)
									{
										this.DoRoleAttrPlus(roleAttr, data2.MobData.AttrPlugID);
										if (data.emSubItemType == ENUM_ItemSubType.Weapon)
										{
											this.DoWeaponElement(roleAttr, data2.MobData.AttrPlugID);
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	private void CalRoleAttrPlus_OnMItem(S_RoleAttr roleAttr)
	{
		ItemData equipItemData = this.GetEquipItemData(ENUM_EquipPosition.Talisman);
		if (equipItemData == null)
		{
			return;
		}
		S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
		if (data == null)
		{
			return;
		}
		if (data.emItemType == ENUM_ItemType.MagicItem)
		{
			this.DoMitemAttrPlus(roleAttr, data.RoleAttrPlusID, equipItemData);
		}
	}

	private void CalRoleAttrPlus_OnEquipByDBF(S_RoleAttr roleAttr, ENUM_EquipPosition position)
	{
		int num = 7;
		int i = 0;
		while (i < num)
		{
			ItemData itemData = null;
			S_Item s_Item;
			if (i != (int)position)
			{
				itemData = this.GetEquipItemData((ENUM_EquipPosition)i);
				if (itemData != null)
				{
					s_Item = GameDataDB.ItemDB.GetData(itemData.ID);
					if (s_Item != null)
					{
						goto IL_5D;
					}
				}
			}
			else
			{
				s_Item = this.GetItemEquip((ENUM_EquipPosition)i);
				if (s_Item != null)
				{
					goto IL_5D;
				}
			}
			IL_EF:
			i++;
			continue;
			IL_5D:
			if (s_Item.emItemType == ENUM_ItemType.MagicItem)
			{
				goto IL_EF;
			}
			if (s_Item.emItemType != ENUM_ItemType.Equip)
			{
				goto IL_EF;
			}
			this.DoRoleAttrPlus(roleAttr, s_Item.RoleAttrPlusID);
			if (itemData != null)
			{
				for (int j = 0; j < 3; j++)
				{
					if (itemData.RefineSoul[j] != 0)
					{
						S_Item data = GameDataDB.ItemDB.GetData(itemData.RefineSoul[j]);
						if (data != null)
						{
							this.DoRoleAttrPlus(roleAttr, data.MobData.AttrPlugID);
						}
					}
				}
				goto IL_EF;
			}
			goto IL_EF;
		}
	}

	private void CalRoleAttrPlus_OnPassiveSkill(S_RoleAttr roleAttr)
	{
        //List<int> passiveSkillList = GameEntry.Instance.m_SkillSystem.GetPassiveSkillList(this.BaseRoleData.ID);
        //for (int i = 0; i < passiveSkillList.Count; i++)
        //{
        //    S_Skill data = GameDataDB.SkillDB.GetData(passiveSkillList[i]);
        //    if (data != null && data.emItemType == ENUM_ItemSubType.Passive)
        //    {
        //        S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
        //        if (data2 != null && data2.SpecialID > 0)
        //        {
        //            this.DoRoleAttrPlus(roleAttr, data2.SpecialID);
        //        }
        //    }
        //}
    }

	public void SetBuffs(Dictionary<int, Buff_Base> buffs, List<Buff_Base> noRemoveBuffs)
	{
		this.m_Buffs = buffs;
		this.m_NoRemoveBuffs = noRemoveBuffs;
	}

	public void CleanBuffs()
	{
		if (this.m_Buffs != null)
		{
			this.m_Buffs.Clear();
		}
		this.m_Buffs = null;
		if (this.m_NoRemoveBuffs != null)
		{
			this.m_NoRemoveBuffs.Clear();
		}
		this.m_NoRemoveBuffs = null;
	}

	private void CalRoleAttrPlus_OnBuff(S_RoleAttr roleAttr)
	{
		if (this.m_Buffs != null)
		{
			foreach (Buff_Base current in this.m_Buffs.Values)
			{
				if (current != null)
				{
					current.DoRoleAttrPlus(roleAttr);
				}
			}
		}
		if (this.m_NoRemoveBuffs != null)
		{
			foreach (Buff_Base current2 in this.m_NoRemoveBuffs)
			{
				if (current2 != null)
				{
					current2.DoRoleAttrPlus(roleAttr);
				}
			}
		}
	}

	public void SetFormationInfo(FormationData data, int unitIdx)
	{
		this.m_FormationData = data;
		this.m_FormationUnitIdx = unitIdx;
	}

	//public void ResetFormationData()
	//{
	//	this.m_FormationData = Swd6Application.instance.m_FormationSystem.GetDefaultFormationData();
	//	this.m_FormationUnitIdx = -1;
	//}

	private void CalRoleAttrPlus_OnFormation(S_RoleAttr roleAttr)
	{
		if (this.m_FormationData == null)
		{
			return;
		}
		//S_FormationData data = GameDataDB.FormationDB.GetData((int)this.m_FormationData.emElement);
		//if (data == null)
		//{
		//	return;
		//}
		//this.DoRoleAttrPlus(roleAttr, data.BaseAttr);
		//if (this.m_FormationUnitIdx < 0 || this.m_FormationUnitIdx >= data.RoleAttr.Count)
		//{
		//	return;
		//}
		//this.DoRoleAttrPlus(roleAttr, data.RoleAttr[this.m_FormationUnitIdx]);
	}

	private void DoRoleAttrPlus(S_RoleAttr roleAttr, int RoleAttrPlusID)
	{
		S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(RoleAttrPlusID);
		if (data == null)
		{
			Debug.LogWarning("能力加成表讀取失敗_" + RoleAttrPlusID);
			return;
		}
		roleAttr.sAttrPlus += data.RoleAttr_Plus;
	}

	private void DoWeaponElement(S_RoleAttr roleAttr, int RoleAttrPlusID)
	{
		S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(RoleAttrPlusID);
		if (data == null)
		{
			Debug.LogWarning("能力加成表讀取失敗_" + RoleAttrPlusID);
			return;
		}
		if (data.RoleAttr_Plus.AtkElement[0] > 0)
		{
			//this.BaseRoleData.emWeaponElemntType = ENUM_ElementType.Wind;
		}
		if (data.RoleAttr_Plus.AtkElement[1] > 0)
		{
			this.BaseRoleData.emWeaponElemntType = ENUM_ElementType.Earth;
		}
		if (data.RoleAttr_Plus.AtkElement[2] > 0)
		{
			this.BaseRoleData.emWeaponElemntType = ENUM_ElementType.Water;
		}
		if (data.RoleAttr_Plus.AtkElement[3] > 0)
		{
			this.BaseRoleData.emWeaponElemntType = ENUM_ElementType.Fire;
		}
	}

	private void DoMitemAttrPlus(S_RoleAttr roleAttr, int AttrPlusID, ItemData itemData)
	{
		//S_Item data = GameDataDB.ItemDB.GetData(itemData.ID);
		//IdentifyData data2 = Swd6Application.instance.m_IdentifySystem.GetData(itemData.ID);
		//if (data2 == null)
		//{
		//	return;
		//}
		//roleAttr.sAttrPlus.AddMaxRatioHP = 0;
		//roleAttr.sAttrPlus.AddMaxRatioMP = 0;
		//roleAttr.sAttrPlus.AddRatioAttack = 0;
		//roleAttr.sAttrPlus.AddRatioDef = 0;
		//roleAttr.sAttrPlus.AddRatioMAtk = 0;
		//roleAttr.sAttrPlus.AddRatioMDef = 0;
		//roleAttr.sAttrPlus.AddAgi = 0;
		//roleAttr.sAttrPlus.AddBlock = 0;
		//roleAttr.sAttrPlus.AddCritical = 0;
		//for (int i = 0; i < 4; i++)
		//{
		//	roleAttr.sAttrPlus.Element[i] = 0;
		//}
		//int gUID = data.GUID;
		//switch (gUID)
		//{
		//case 701:
		//	roleAttr.sAttrPlus.AddMaxRatioHP += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 702:
		//	roleAttr.sAttrPlus.AddMaxRatioMP += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 703:
		//	roleAttr.sAttrPlus.AddRatioAttack += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 704:
		//	roleAttr.sAttrPlus.AddRatioDef += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 705:
		//	roleAttr.sAttrPlus.AddRatioMAtk += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 706:
		//	roleAttr.sAttrPlus.AddRatioMDef += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 707:
		//	roleAttr.sAttrPlus.AddAgi += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 708:
		//	roleAttr.sAttrPlus.AddBlock += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 709:
		//	roleAttr.sAttrPlus.AddCritical += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	return;
		//case 710:
		//case 711:
		//case 712:
		//case 713:
		//case 714:
		//case 715:
		//	IL_113:
		//	if (gUID != 726)
		//	{
		//		return;
		//	}
		//	for (int j = 0; j < 4; j++)
		//	{
		//		roleAttr.sAttrPlus.Element[j] += (int)data.MItem.AttrEffect[data2.Level - 1];
		//	}
		//	return;
		//case 716:
		//{
		//	int currentMapOpenTreasuerCount = Swd6Application.instance.m_GameObjSystem.GetCurrentMapOpenTreasuerCount();
		//	int currentMapTreasuerCount = Swd6Application.instance.m_GameObjSystem.GetCurrentMapTreasuerCount();
		//	if (currentMapTreasuerCount > 0)
		//	{
		//		float num = (float)currentMapOpenTreasuerCount / (float)currentMapTreasuerCount;
		//		num = data.MItem.AttrEffect[data2.Level - 1] * num;
		//		roleAttr.sAttrPlus.AddRatioAttack += (int)num;
		//		roleAttr.sAttrPlus.AddRatioMAtk += (int)num;
		//	}
		//	return;
		//}
		//case 717:
		//{
		//	int currentMapOpenTreasuerCount2 = Swd6Application.instance.m_GameObjSystem.GetCurrentMapOpenTreasuerCount();
		//	int currentMapTreasuerCount2 = Swd6Application.instance.m_GameObjSystem.GetCurrentMapTreasuerCount();
		//	if (currentMapTreasuerCount2 > 0)
		//	{
		//		float num2 = (float)currentMapOpenTreasuerCount2 / (float)currentMapTreasuerCount2;
		//		num2 = data.MItem.AttrEffect[data2.Level - 1] * num2;
		//		roleAttr.sAttrPlus.AddRatioDef += (int)num2;
		//		roleAttr.sAttrPlus.AddRatioMDef += (int)num2;
		//	}
		//	return;
		//}
		//}
		//goto IL_113;
	}

	private void CalRoleAttr_Finial(S_RoleAttr roleAttr)
	{
		float num = 1f + (float)this.BaseRoleData.Level / 100f;
		roleAttr.sFinial.MaxHP = this.BaseRoleData.MaxHP + this.BaseRoleData.MaxHP * roleAttr.sAttrPlus.AddMaxRatioHP / 100 + roleAttr.sAttrPlus.AddMaxHP;
		roleAttr.sFinial.MaxMP = this.BaseRoleData.MaxMP + this.BaseRoleData.MaxMP * roleAttr.sAttrPlus.AddMaxRatioMP / 100 + roleAttr.sAttrPlus.AddMaxMP;
		roleAttr.sFinial.Attack = this.BaseRoleData.Atk + this.BaseRoleData.Atk * roleAttr.sAttrPlus.AddRatioAttack / 100 + roleAttr.sAttrPlus.AddAttack;
		if (roleAttr.sFinial.Attack < 0)
		{
			roleAttr.sFinial.Attack = 0;
		}
		roleAttr.sFinial.Def = this.BaseRoleData.Def + this.BaseRoleData.Def * roleAttr.sAttrPlus.AddRatioDef / 100 + roleAttr.sAttrPlus.AddDef;
		if (roleAttr.sFinial.Def < 0)
		{
			roleAttr.sFinial.Def = 0;
		}
        roleAttr.sFinial.MAttack = this.BaseRoleData.MAtk + this.BaseRoleData.MAtk * roleAttr.sAttrPlus.AddRatioMAtk / 100 + roleAttr.sAttrPlus.AddMAtk;
        if (roleAttr.sFinial.MAttack < 0)
        {
            roleAttr.sFinial.MAttack = 0;
        }
        roleAttr.sFinial.MDef = this.BaseRoleData.MDef + this.BaseRoleData.MDef * roleAttr.sAttrPlus.AddRatioMDef / 100 + roleAttr.sAttrPlus.AddMDef;
        if (roleAttr.sFinial.MDef < 0)
        {
            roleAttr.sFinial.MDef = 0;
        }
        roleAttr.sFinial.Agi = this.BaseRoleData.Agi + roleAttr.sAttrPlus.AddAgi;
        roleAttr.sFinial.Block = this.BaseRoleData.Block + roleAttr.sAttrPlus.AddBlock;
        roleAttr.sFinial.Dodge = this.BaseRoleData.Dodge + roleAttr.sAttrPlus.AddDodge;
        roleAttr.sFinial.Critical = this.BaseRoleData.Critical + roleAttr.sAttrPlus.AddCritical;
		for (int i = 0; i < 4; i++)
		{
			roleAttr.sFinial.Element[i] += roleAttr.sAttrPlus.Element[i];
			roleAttr.sFinial.AtkElement[i] += roleAttr.sAttrPlus.AtkElement[i];
		}
		if (roleAttr.sFinial.MaxMP < 1)
		{
			roleAttr.sFinial.MaxMP = 1;
			this.BaseRoleData.MP = 1;
		}
		if (this.BaseRoleData.HP > roleAttr.sFinial.MaxHP)
		{
			this.BaseRoleData.HP = roleAttr.sFinial.MaxHP;
		}
		if (this.BaseRoleData.MP > roleAttr.sFinial.MaxMP)
		{
			this.BaseRoleData.MP = roleAttr.sFinial.MaxMP;
		}
	}

	private void CalRoleAttr_Finial2(S_RoleAttr roleAttr, S_RoleAttr mItemAttr)
	{
		float num = 1f + (float)this.BaseRoleData.Level / 100f;
		roleAttr.sFinial.MaxHP = roleAttr.sFinial.MaxHP + roleAttr.sFinial.MaxHP * mItemAttr.sAttrPlus.AddMaxRatioHP / 100 + mItemAttr.sAttrPlus.AddMaxHP;
		roleAttr.sFinial.MaxMP = roleAttr.sFinial.MaxMP + roleAttr.sFinial.MaxMP * mItemAttr.sAttrPlus.AddMaxRatioMP / 100 + mItemAttr.sAttrPlus.AddMaxMP;
		roleAttr.sFinial.Attack = roleAttr.sFinial.Attack + roleAttr.sFinial.Attack * mItemAttr.sAttrPlus.AddRatioAttack / 100 + mItemAttr.sAttrPlus.AddAttack;
		if (roleAttr.sFinial.Attack < 0)
		{
			roleAttr.sFinial.Attack = 0;
		}
		roleAttr.sFinial.Def = roleAttr.sFinial.Def + roleAttr.sFinial.Def * mItemAttr.sAttrPlus.AddRatioDef / 100 + mItemAttr.sAttrPlus.AddDef;
		if (roleAttr.sFinial.Def < 0)
		{
			roleAttr.sFinial.Def = 0;
		}
		//roleAttr.sFinial.MAttack = roleAttr.sFinial.MAttack + roleAttr.sFinial.MAttack * mItemAttr.sAttrPlus.AddRatioMAtk / 100 + mItemAttr.sAttrPlus.AddMAtk;
		//if (roleAttr.sFinial.MAttack < 0)
		//{
		//	roleAttr.sFinial.MAttack = 0;
		//}
		//roleAttr.sFinial.MDef = roleAttr.sFinial.MDef + roleAttr.sFinial.MDef * mItemAttr.sAttrPlus.AddRatioMDef / 100 + mItemAttr.sAttrPlus.AddMDef;
		//if (roleAttr.sFinial.MDef < 0)
		//{
		//	roleAttr.sFinial.MDef = 0;
		//}
		roleAttr.sFinial.Agi = roleAttr.sFinial.Agi + mItemAttr.sAttrPlus.AddAgi;
		roleAttr.sFinial.Block = roleAttr.sFinial.Block + mItemAttr.sAttrPlus.AddBlock;
		//roleAttr.sFinial.Dodge = roleAttr.sFinial.Dodge + mItemAttr.sAttrPlus.AddDodge;
		roleAttr.sFinial.Critical = roleAttr.sFinial.Critical + mItemAttr.sAttrPlus.AddCritical;
		for (int i = 0; i < 4; i++)
		{
			roleAttr.sFinial.Element[i] += mItemAttr.sAttrPlus.Element[i];
			roleAttr.sFinial.AtkElement[i] += mItemAttr.sAttrPlus.AtkElement[i];
		}
		if (roleAttr.sFinial.MaxMP < 1)
		{
			roleAttr.sFinial.MaxMP = 1;
			this.BaseRoleData.MP = 1;
		}
		if (this.BaseRoleData.HP > roleAttr.sFinial.MaxHP)
		{
			this.BaseRoleData.HP = roleAttr.sFinial.MaxHP;
		}
		if (this.BaseRoleData.MP > roleAttr.sFinial.MaxMP)
		{
			this.BaseRoleData.MP = roleAttr.sFinial.MaxMP;
		}
	}

	public int GetRoleAttr_IntValue(ENUM_RoleAttr emRoleAttr)
	{
		switch (emRoleAttr)
		{
		case ENUM_RoleAttr.MaxHP:
			return this.RoleAttr.sFinial.MaxHP;
		case ENUM_RoleAttr.MaxMP:
			return this.RoleAttr.sFinial.MaxMP;
		case ENUM_RoleAttr.Str:
			return this.RoleAttr.sFinial.Attack;
		case ENUM_RoleAttr.Mag:
			//return this.RoleAttr.sFinial.MAttack;
		case ENUM_RoleAttr.Sta:
			//return this.RoleAttr.sFinial.Def;
		case ENUM_RoleAttr.Air:
			//return this.RoleAttr.sFinial.MDef;
		default:
			return 0;
		}
	}

	public S_RoleAttr CompareEquipData(ENUM_EquipPosition pos, int id)
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		S_RoleAttr s_RoleAttr2 = new S_RoleAttr();
		S_RoleAttr s_RoleAttr3 = new S_RoleAttr();
		if (pos == ENUM_EquipPosition.Null)
		{
			return null;
		}
		int num = this.BaseRoleData.EquipID[(int)pos];
		this.BaseRoleData.EquipID[(int)pos] = id;
		this.CalRoleAttrPlus_OnEquip(s_RoleAttr);
		this.CalRoleAttr_Finial(s_RoleAttr);
		this.CalRoleAttrPlus_OnPassiveSkill(s_RoleAttr2);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr2);
		this.CalRoleAttrPlus_OnMItem(s_RoleAttr3);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr3);
		s_RoleAttr.sAttrPlus += s_RoleAttr2.sAttrPlus;
		s_RoleAttr.sAttrPlus += s_RoleAttr3.sAttrPlus;
		s_RoleAttr.sFinial -= this.RoleAttr.sFinial;
		this.BaseRoleData.EquipID[(int)pos] = num;
		return s_RoleAttr;
	}

	public S_RoleAttr CompareEquipDataByItemID(ENUM_EquipPosition pos, int itemId)
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		S_RoleAttr s_RoleAttr2 = new S_RoleAttr();
		S_RoleAttr s_RoleAttr3 = new S_RoleAttr();
		if (pos == ENUM_EquipPosition.Null)
		{
			return null;
		}
		int num = this.BaseRoleData.EquipID[(int)pos];
		this.BaseRoleData.EquipID[(int)pos] = itemId;
		this.CalRoleAttrPlus_OnEquipByDBF(s_RoleAttr, pos);
		this.CalRoleAttr_Finial(s_RoleAttr);
		this.CalRoleAttrPlus_OnPassiveSkill(s_RoleAttr2);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr2);
		this.CalRoleAttrPlus_OnMItem(s_RoleAttr3);
		this.CalRoleAttr_Finial2(s_RoleAttr, s_RoleAttr3);
		s_RoleAttr.sAttrPlus += s_RoleAttr2.sAttrPlus;
		s_RoleAttr.sAttrPlus += s_RoleAttr3.sAttrPlus;
		s_RoleAttr.sFinial -= this.RoleAttr.sFinial;
		this.BaseRoleData.EquipID[(int)pos] = num;
		return s_RoleAttr;
	}

	public bool CanEquip(int id)
	{
		S_Item data = GameDataDB.ItemDB.GetData(id);
		if (data == null)
		{
			Debug.Log("CanEquip Read Item error!!_" + id);
			return false;
		}
		ENUM_EquipChar equipChar = (ENUM_EquipChar)data.Equip.EquipChar;
		return ((equipChar & ENUM_EquipChar.Player1) == ENUM_EquipChar.Player1 && this.BaseRoleData.ID == 1) || ((equipChar & ENUM_EquipChar.Player2) == ENUM_EquipChar.Player2 && this.BaseRoleData.ID == 2) || ((equipChar & ENUM_EquipChar.Player3) == ENUM_EquipChar.Player3 && this.BaseRoleData.ID == 3) || ((equipChar & ENUM_EquipChar.Player4) == ENUM_EquipChar.Player4 && this.BaseRoleData.ID == 4) || ((equipChar & ENUM_EquipChar.Player5) == ENUM_EquipChar.Player5 && this.BaseRoleData.ID == 5) || ((equipChar & ENUM_EquipChar.Player6) == ENUM_EquipChar.Player6 && this.BaseRoleData.ID == 6) || ((equipChar & ENUM_EquipChar.Player7) == ENUM_EquipChar.Player7 && this.BaseRoleData.ID == 7);
	}

	public ItemData GetEquipItemData(ENUM_EquipPosition Pos)
	{
        if (this.BaseRoleData.EquipID[(int)Pos] > 0)
        {
            return GameEntry.Instance.m_ItemSystem.GetDataBySerialID(this.BaseRoleData.EquipID[(int)Pos]);
        }
        return null;
    }

	public S_Item GetItemEquip(ENUM_EquipPosition Pos)
	{
		if (this.BaseRoleData.EquipID[(int)Pos] > 0)
		{
			return GameDataDB.ItemDB.GetData(this.BaseRoleData.EquipID[(int)Pos]);
		}
		return null;
	}

	public ENUM_EquipPosition GetEquipPosition(ENUM_ItemSubType type)
	{
		ENUM_EquipPosition result = ENUM_EquipPosition.Null;
		if (type == ENUM_ItemSubType.Weapon)
		{
			result = ENUM_EquipPosition.Weapon;
		}
		if (type == ENUM_ItemSubType.Head)
		{
			result = ENUM_EquipPosition.Head;
		}
		if (type == ENUM_ItemSubType.Armor)
		{
			result = ENUM_EquipPosition.Armor;
		}
		if (type == ENUM_ItemSubType.Hand)
		{
			result = ENUM_EquipPosition.Hand;
		}
		if (type == ENUM_ItemSubType.Shoes)
		{
			result = ENUM_EquipPosition.Shoes;
		}
		if (type == ENUM_ItemSubType.Accessories)
		{
			result = ENUM_EquipPosition.Accessories;
		}
		if (type == ENUM_ItemSubType.Talisman || type == ENUM_ItemSubType.MagicArms)
		{
			result = ENUM_EquipPosition.Talisman;
		}
		if (type == ENUM_ItemSubType.CosCloth)
		{
			result = ENUM_EquipPosition.CosCloth;
		}
		return result;
	}

	public bool CheckEquipItem(int itemId)
	{
		int num = 8;
		for (int i = 0; i < num; i++)
		{
			ItemData equipItemData = this.GetEquipItemData((ENUM_EquipPosition)i);
			if (equipItemData != null)
			{
				if (equipItemData.ID == itemId)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void InitBuffer()
	{
		for (int i = 0; i < 10; i++)
		{
			this.BuffSlot.Add(new S_BuffInfo());
		}
	}

	public int GetBuffSlotSize()
	{
		return this.BuffSlot.Count;
	}

	public S_BuffInfo GetBuff(int Index)
	{
		int count = this.BuffSlot.Count;
		if (Index < 0 || Index >= count)
		{
			return null;
		}
		return this.BuffSlot[Index];
	}

	public void SetBuff(int Index, S_BuffInfo BuffInfo)
	{
		int count = this.BuffSlot.Count;
		if (Index < 0 || Index >= count)
		{
			return;
		}
		if (BuffInfo == null)
		{
			return;
		}
		this.BuffSlot[Index] = BuffInfo;
	}

	public void ClearBuff(int Index)
	{
		int count = this.BuffSlot.Count;
		if (Index < 0 || Index >= count)
		{
			return;
		}
		this.BuffSlot[Index].Reset();
	}
}
