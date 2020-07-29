using System;
using System.Collections.Generic;
using UnityEngine;

public class C_RoleDataEx : S_RoleData
{
	protected int StaPlus;

	protected int MagPlus;

	protected int AirPlus;

	private Dictionary<int, Buff_Base> m_Buffs;

	private List<Buff_Base> m_NoRemoveBuffs;

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

	public void SetAP(int Value)
	{
		int maxAP = this.RoleAttr.sFinial.MaxAP;
		if (Value > maxAP)
		{
			Value = maxAP;
		}
		if (Value < 0)
		{
			Value = 0;
		}
		this.BaseRoleData.AP = Value;
	}

	public void AddAP(int Value)
	{
		this.BaseRoleData.AP += Value;
		int maxAP = this.RoleAttr.sFinial.MaxAP;
		if (this.BaseRoleData.AP > maxAP)
		{
			this.BaseRoleData.AP = maxAP;
		}
		if (this.BaseRoleData.AP < 0)
		{
			this.BaseRoleData.AP = 0;
		}
	}

	public void AddAP(float Percent)
	{
		int num = (int)((float)this.RoleAttr.sFinial.MaxAP * Percent) / 100;
		this.BaseRoleData.AP += num;
		int maxAP = this.RoleAttr.sFinial.MaxAP;
		if (this.BaseRoleData.AP > maxAP)
		{
			this.BaseRoleData.AP = maxAP;
		}
		if (this.BaseRoleData.AP < 0)
		{
			this.BaseRoleData.AP = 0;
		}
	}

	public int GetAP()
	{
		return this.BaseRoleData.AP;
	}

	public void SetFullHP()
	{
		this.BaseRoleData.HP = this.RoleAttr.sFinial.MaxHP;
	}

	public void SetFullMP()
	{
		this.BaseRoleData.MP = this.RoleAttr.sFinial.MaxMP;
	}

	public void SetFullAP()
	{
		this.BaseRoleData.AP = this.RoleAttr.sFinial.MaxAP;
	}

	public void AddUpBaseRoleAttr(int id, bool showmsg)
	{
		S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(id);
		if (data == null)
		{
			Debug.LogWarning("能力加成表讀取失敗_" + id);
			return;
		}
		string msg = "";
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
		if (data.RoleAttr_Plus.AddMaxAP > 0)
		{
			this.BaseRoleData.MaxAP += data.RoleAttr_Plus.AddMaxAP;
			msg = string.Format(GameDataDB.StrID(7452), data.RoleAttr_Plus.AddMaxAP);
		}
		if (data.RoleAttr_Plus.AddStr > 0)
		{
			this.BaseRoleData.Str += data.RoleAttr_Plus.AddStr;
			msg = string.Format(GameDataDB.StrID(7455), data.RoleAttr_Plus.AddStr);
		}
		if (data.RoleAttr_Plus.AddMag > 0)
		{
			this.BaseRoleData.Mag += data.RoleAttr_Plus.AddMag;
			msg = string.Format(GameDataDB.StrID(7456), data.RoleAttr_Plus.AddMag);
		}
		if (data.RoleAttr_Plus.AddSta > 0)
		{
			this.BaseRoleData.Sta += data.RoleAttr_Plus.AddSta;
			msg = string.Format(GameDataDB.StrID(7457), data.RoleAttr_Plus.AddSta);
		}
		if (data.RoleAttr_Plus.AddAir > 0)
		{
			this.BaseRoleData.Air += data.RoleAttr_Plus.AddAir;
			msg = string.Format(GameDataDB.StrID(7458), data.RoleAttr_Plus.AddAir);
		}
		if (data.RoleAttr_Plus.AddMind > 0)
		{
			this.BaseRoleData.Mind += data.RoleAttr_Plus.AddMind;
			msg = string.Format(GameDataDB.StrID(7459), data.RoleAttr_Plus.AddMind);
		}
		if (data.RoleAttr_Plus.AddAgi > 0)
		{
			this.BaseRoleData.Agi += data.RoleAttr_Plus.AddAgi;
			msg = string.Format(GameDataDB.StrID(7460), data.RoleAttr_Plus.AddAgi);
		}
		if (data.RoleAttr_Plus.AddBlock > 0)
		{
			this.BaseRoleData.Block += data.RoleAttr_Plus.AddBlock;
			msg = string.Format(GameDataDB.StrID(7461), data.RoleAttr_Plus.AddBlock);
		}
		if (data.RoleAttr_Plus.AddLuck > 0)
		{
			this.BaseRoleData.Luck += data.RoleAttr_Plus.AddLuck;
			msg = string.Format(GameDataDB.StrID(7462), data.RoleAttr_Plus.AddLuck);
		}
		if (data.RoleAttr_Plus.AddCritical > 0)
		{
			this.BaseRoleData.Critical += data.RoleAttr_Plus.AddCritical;
			msg = string.Format(GameDataDB.StrID(7463), data.RoleAttr_Plus.AddCritical);
		}
		for (int i = 0; i < 6; i++)
		{
			if (data.RoleAttr_Plus.Element[i] > 0)
			{
				this.BaseRoleData.Element[i] += data.RoleAttr_Plus.Element[i];
				msg = string.Format(GameDataDB.StrID(7464 + i) + GameDataDB.StrID(7470) + "+{0}", data.RoleAttr_Plus.Element[i]);
			}
		}
		this.CalRoleAttr();
		if (showmsg)
		{
			UI_OkCancelBox.Instance.ClearSysMsg();
			UI_OkCancelBox.Instance.AddSysMsg(msg, 3f);
		}
	}

	public void CalRoleAttr()
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		this.StaPlus = 0;
		this.MagPlus = 0;
		this.AirPlus = 0;
		this.CalRoleAttrPlus_OnEquip(s_RoleAttr);
		this.CalRoleAttrPlus_OnBuff(s_RoleAttr);
		this.CalRoleAttrPlus_OnSevenRing(s_RoleAttr);
		this.CalRoleAttr_Finial(s_RoleAttr);
		this.RoleAttr.sAttrPlus = s_RoleAttr.sAttrPlus;
		this.RoleAttr.sFinial = s_RoleAttr.sFinial;
	}

	private void CalRoleAttrPlus_OnEquip(S_RoleAttr roleAttr)
	{
		int num = 9;
		for (int i = 0; i < num; i++)
		{
			ItemData equipItemData = this.GetEquipItemData((ENUM_EquipPosition)i);
			if (equipItemData != null)
			{
				S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
				if (data != null)
				{
					if (data.emItemType == ENUM_ItemType.MagicItem)
					{
						this.DoMitemAttrPlus(roleAttr, data.RoleAttrPlusID, equipItemData);
					}
					else if (data.emItemType == ENUM_ItemType.Equip)
					{
						this.DoRoleAttrPlus(roleAttr, data.RoleAttrPlusID);
						this.DoSmithItemAttrPlus(roleAttr, equipItemData);
						for (int j = 0; j < equipItemData.MaxRefineSoul; j++)
						{
							if (equipItemData.RefineSoul[j] != 0)
							{
								S_Item data2 = GameDataDB.ItemDB.GetData(equipItemData.RefineSoul[j]);
								if (data2 != null)
								{
									this.DoRoleAttrPlus(roleAttr, data2.MobData.AttrPlugID);
								}
							}
						}
					}
				}
			}
		}
	}

	private void CalRoleAttrPlus_OnEquipByDBF(S_RoleAttr roleAttr, ENUM_EquipPosition position)
	{
		int num = 9;
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
						goto IL_49;
					}
				}
			}
			else
			{
				s_Item = this.GetItemEquip((ENUM_EquipPosition)i);
				if (s_Item != null)
				{
					goto IL_49;
				}
			}
			IL_CF:
			i++;
			continue;
			IL_49:
			if (s_Item.emItemType == ENUM_ItemType.MagicItem)
			{
				this.DoMitemAttrPlus(roleAttr, s_Item.RoleAttrPlusID, itemData);
				goto IL_CF;
			}
			if (s_Item.emItemType != ENUM_ItemType.Equip)
			{
				goto IL_CF;
			}
			this.DoRoleAttrPlus(roleAttr, s_Item.RoleAttrPlusID);
			if (itemData != null)
			{
				this.DoSmithItemAttrPlus(roleAttr, itemData);
				for (int j = 0; j < itemData.MaxRefineSoul; j++)
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
				goto IL_CF;
			}
			goto IL_CF;
		}
	}

	public void SetBuffs(Dictionary<int, Buff_Base> buffs, List<Buff_Base> noRemoveBuffs)
	{
		this.m_Buffs = buffs;
		this.m_NoRemoveBuffs = noRemoveBuffs;
	}

	public void CleanBuffs()
	{
		this.m_Buffs.Clear();
		this.m_Buffs = null;
		this.m_NoRemoveBuffs.Clear();
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

	private void CalRoleAttrPlus_OnSevenRing(S_RoleAttr roleAttr)
	{
		if (Swd6Application.instance.m_ChapID == 101)
		{
			this.CalRoleAttrPlus_OnThousand(roleAttr);
			return;
		}
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		double num = Math.Round((double)(this.BaseRoleData.MaxHP * this.BaseRoleData.SevenRingGrid[0]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMaxHP = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Mag * this.BaseRoleData.SevenRingGrid[1]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMag = (int)num;
		num = Math.Round((double)(this.BaseRoleData.MaxAP * this.BaseRoleData.SevenRingGrid[2]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMaxAP = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Air * this.BaseRoleData.SevenRingGrid[3]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddAir = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Str * this.BaseRoleData.SevenRingGrid[4]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddStr = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Sta * this.BaseRoleData.SevenRingGrid[5]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddSta = (int)num;
		num = Math.Round((double)(this.BaseRoleData.MaxMP * this.BaseRoleData.SevenRingGrid[6]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMaxMP = (int)num;
		roleAttr.sAttrPlus += s_RoleAttr_Plus;
	}

	private void CalRoleAttrPlus_OnThousand(S_RoleAttr roleAttr)
	{
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		double num = Math.Round((double)(this.BaseRoleData.Str * this.BaseRoleData.SevenRingGrid[0]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddStr = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Sta * this.BaseRoleData.SevenRingGrid[1]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddSta = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Mag * this.BaseRoleData.SevenRingGrid[2]) / 10.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMag = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Block * this.BaseRoleData.SevenRingGrid[3]) / 20.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddBlock = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Luck * this.BaseRoleData.SevenRingGrid[4]) / 20.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddLuck = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Critical * this.BaseRoleData.SevenRingGrid[5]) / 20.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddCritical = (int)num;
		num = Math.Round((double)(this.BaseRoleData.Mind * this.BaseRoleData.SevenRingGrid[6]) / 20.0, 0, MidpointRounding.AwayFromZero);
		s_RoleAttr_Plus.AddMind = (int)num;
		roleAttr.sAttrPlus += s_RoleAttr_Plus;
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

	private void DoSmithItemAttrPlus(S_RoleAttr roleAttr, ItemData itemData)
	{
		S_Item data = GameDataDB.ItemDB.GetData(itemData.ID);
		if (data.emSubItemType == ENUM_ItemSubType.Weapon)
		{
			roleAttr.sAttrPlus.AddAttack += itemData.GradeNumber;
			return;
		}
		roleAttr.sAttrPlus.AddDef += itemData.GradeNumber;
	}

	private void DoMitemAttrPlus(S_RoleAttr roleAttr, int AttrPlusID, ItemData itemData)
	{
		S_Item data = GameDataDB.ItemDB.GetData(itemData.ID);
		IdentifyData data2 = Swd6Application.instance.m_IdentifySystem.GetData(itemData.ID);
		if (data2 == null)
		{
			return;
		}
		int gUID = data.GUID;
		switch (gUID)
		{
		case 701:
			roleAttr.sAttrPlus.AddMaxHP += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 702:
			roleAttr.sAttrPlus.AddMaxMP += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 703:
			roleAttr.sAttrPlus.AddMaxAP += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 704:
			roleAttr.sAttrPlus.AddAttack += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 705:
			roleAttr.sAttrPlus.AddDef += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 706:
			roleAttr.sAttrPlus.AddBlock += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 707:
			roleAttr.sAttrPlus.AddAgi += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 708:
			roleAttr.sAttrPlus.AddCritical += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 709:
			roleAttr.sAttrPlus.AddLuck += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 710:
		{
			int currentMapOpenTreasuerCount = Swd6Application.instance.m_GameObjSystem.GetCurrentMapOpenTreasuerCount();
			int currentMapTreasuerCount = Swd6Application.instance.m_GameObjSystem.GetCurrentMapTreasuerCount();
			if (currentMapTreasuerCount > 0)
			{
				float num = (float)currentMapOpenTreasuerCount / (float)currentMapTreasuerCount;
				num = (float)data.MItem.AttrEffect[data2.Level - 1] * num;
				roleAttr.sAttrPlus.AddAttack += (int)num;
				return;
			}
			break;
		}
		case 711:
		{
			int currentMapOpenTreasuerCount2 = Swd6Application.instance.m_GameObjSystem.GetCurrentMapOpenTreasuerCount();
			int currentMapTreasuerCount2 = Swd6Application.instance.m_GameObjSystem.GetCurrentMapTreasuerCount();
			if (currentMapTreasuerCount2 > 0)
			{
				float num2 = (float)currentMapOpenTreasuerCount2 / (float)currentMapTreasuerCount2;
				num2 = (float)data.MItem.AttrEffect[data2.Level - 1] * num2;
				roleAttr.sAttrPlus.AddDef += (int)num2;
			}
			break;
		}
		case 712:
		case 713:
		case 714:
		case 715:
		case 717:
		case 718:
		case 719:
		case 721:
		case 722:
		case 723:
		case 724:
		case 725:
		case 731:
		case 732:
		case 733:
		case 734:
		case 735:
		case 736:
			break;
		case 716:
			roleAttr.sAttrPlus.AddAgi += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 720:
			roleAttr.sAttrPlus.AddMind += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 726:
			roleAttr.sAttrPlus.AtkElement[1] += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 727:
			roleAttr.sAttrPlus.AtkElement[2] += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 728:
			roleAttr.sAttrPlus.AtkElement[0] += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 729:
			roleAttr.sAttrPlus.AtkElement[3] += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 730:
			roleAttr.sAttrPlus.AtkElement[4] += data.MItem.AttrEffect[data2.Level - 1];
			return;
		case 737:
			for (int i = 0; i < 6; i++)
			{
				roleAttr.sAttrPlus.Element[i] += data.MItem.AttrEffect[data2.Level - 1];
			}
			return;
		default:
			if (gUID != 768)
			{
				return;
			}
			roleAttr.sAttrPlus.AddAttack += 999;
			roleAttr.sAttrPlus.AddMaxHP += 3333;
			return;
		}
	}

	private void CalRoleAttr_Finial(S_RoleAttr roleAttr)
	{
		float num = 1f + (float)this.BaseRoleData.Level / 100f;
		roleAttr.sFinial.MaxHP = this.BaseRoleData.MaxHP + this.BaseRoleData.MaxHP * roleAttr.sAttrPlus.AddMaxRatioHP / 100 + roleAttr.sAttrPlus.AddMaxHP;
		roleAttr.sFinial.MaxMP = this.BaseRoleData.MaxMP + this.BaseRoleData.MaxMP * roleAttr.sAttrPlus.AddMaxRatioMP / 100 + roleAttr.sAttrPlus.AddMaxMP;
		roleAttr.sFinial.MaxAP = this.BaseRoleData.MaxAP + this.BaseRoleData.MaxAP * roleAttr.sAttrPlus.AddMaxRatioAP / 100 + roleAttr.sAttrPlus.AddMaxAP;
		roleAttr.sFinial.Str = this.BaseRoleData.Str + this.BaseRoleData.Str * roleAttr.sAttrPlus.AddRatioStr / 100 + roleAttr.sAttrPlus.AddStr;
		if (roleAttr.sFinial.Str < 0)
		{
			roleAttr.sFinial.Str = 0;
		}
		roleAttr.sFinial.Sta = this.BaseRoleData.Sta + this.BaseRoleData.Sta * roleAttr.sAttrPlus.AddRatioSta / 100 + roleAttr.sAttrPlus.AddSta;
		if (roleAttr.sFinial.Sta < 0)
		{
			roleAttr.sFinial.Sta = 0;
		}
		roleAttr.sFinial.Air = this.BaseRoleData.Air + this.BaseRoleData.Air * roleAttr.sAttrPlus.AddRatioAir / 100 + roleAttr.sAttrPlus.AddAir;
		if (roleAttr.sFinial.Air < 0)
		{
			roleAttr.sFinial.Air = 0;
		}
		roleAttr.sFinial.Mag = this.BaseRoleData.Mag + this.BaseRoleData.Mag * roleAttr.sAttrPlus.AddRatioMag / 100 + roleAttr.sAttrPlus.AddMag;
		if (roleAttr.sFinial.Mag < 0)
		{
			roleAttr.sFinial.Mag = 0;
		}
		roleAttr.sFinial.Agi = this.BaseRoleData.Agi + this.BaseRoleData.Agi * roleAttr.sAttrPlus.AddRatioAgi / 100 + roleAttr.sAttrPlus.AddAgi;
		roleAttr.sFinial.Block = this.BaseRoleData.Block + roleAttr.sAttrPlus.AddBlock;
		roleAttr.sFinial.Luck = this.BaseRoleData.Luck + roleAttr.sAttrPlus.AddLuck;
		roleAttr.sFinial.Critical = this.BaseRoleData.Critical + roleAttr.sAttrPlus.AddCritical;
		roleAttr.sFinial.Mind = this.BaseRoleData.Mind + this.BaseRoleData.Mind * roleAttr.sAttrPlus.AddRatioMind / 100 + roleAttr.sAttrPlus.AddMind;
		int num2 = (int)Math.Round((double)((float)roleAttr.sFinial.Str * num), 0, MidpointRounding.AwayFromZero);
		roleAttr.sFinial.Attack = num2 + roleAttr.sAttrPlus.AddAttack;
		roleAttr.sFinial.Attack += roleAttr.sFinial.Attack * roleAttr.sAttrPlus.AddRatioAttack / 100;
		if (roleAttr.sFinial.Attack < 0)
		{
			roleAttr.sFinial.Attack = 0;
		}
		int num3 = (int)Math.Round((double)((float)roleAttr.sFinial.Sta * num), 0, MidpointRounding.AwayFromZero);
		roleAttr.sFinial.Def = num3 + roleAttr.sAttrPlus.AddDef;
		roleAttr.sFinial.Def += roleAttr.sFinial.Def * roleAttr.sAttrPlus.AddRatioDef / 100;
		if (roleAttr.sFinial.Def < 0)
		{
			roleAttr.sFinial.Def = 0;
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.BaseRoleData.Element[i] == 0 && roleAttr.sAttrPlus.ElementRatio[i] < 0)
			{
				roleAttr.sFinial.Element[i] = 300 * roleAttr.sAttrPlus.ElementRatio[i] / 100 + roleAttr.sAttrPlus.Element[i];
			}
			else
			{
				roleAttr.sFinial.Element[i] = this.BaseRoleData.Element[i] + this.BaseRoleData.Element[i] * roleAttr.sAttrPlus.ElementRatio[i] / 100 + roleAttr.sAttrPlus.Element[i];
			}
			roleAttr.sFinial.AtkElement[i] = roleAttr.sAttrPlus.AtkElement[i];
		}
		num = 4f * ((float)this.BaseRoleData.Level / 99f);
		this.StaPlus = (int)Math.Round((double)((float)roleAttr.sFinial.Sta * num), 0, MidpointRounding.AwayFromZero);
		this.MagPlus = (int)Math.Round((double)((float)roleAttr.sFinial.Mag * num), 0, MidpointRounding.AwayFromZero);
		this.AirPlus = (int)Math.Round((double)((float)roleAttr.sFinial.Air * num), 0, MidpointRounding.AwayFromZero);
		roleAttr.sFinial.MaxHP += this.StaPlus;
		roleAttr.sFinial.MaxMP += this.MagPlus;
		roleAttr.sFinial.MaxAP += this.AirPlus;
		if (roleAttr.sFinial.MaxMP < 1)
		{
			roleAttr.sFinial.MaxMP = 1;
			this.BaseRoleData.MP = 1;
		}
		if (roleAttr.sFinial.MaxAP < 1)
		{
			roleAttr.sFinial.MaxAP = 1;
			this.BaseRoleData.AP = 1;
		}
		if (this.BaseRoleData.HP > roleAttr.sFinial.MaxHP)
		{
			this.BaseRoleData.HP = roleAttr.sFinial.MaxHP;
		}
		if (this.BaseRoleData.MP > roleAttr.sFinial.MaxMP)
		{
			this.BaseRoleData.MP = roleAttr.sFinial.MaxMP;
		}
		if (this.BaseRoleData.AP > roleAttr.sFinial.MaxAP)
		{
			this.BaseRoleData.AP = roleAttr.sFinial.MaxAP;
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
		case ENUM_RoleAttr.MaxAP:
			return this.RoleAttr.sFinial.MaxAP;
		case ENUM_RoleAttr.Str:
			return this.RoleAttr.sFinial.Str;
		case ENUM_RoleAttr.Mag:
			return this.RoleAttr.sFinial.Mag;
		case ENUM_RoleAttr.Sta:
			return this.RoleAttr.sFinial.Sta;
		case ENUM_RoleAttr.Air:
			return this.RoleAttr.sFinial.Air;
		default:
			return 0;
		}
	}

	public S_RoleAttr CompareEquipData(ENUM_EquipPosition pos, int id)
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		if (pos == ENUM_EquipPosition.Null)
		{
			return null;
		}
		int num = this.BaseRoleData.EquipID[(int)pos];
		this.BaseRoleData.EquipID[(int)pos] = id;
		this.CalRoleAttrPlus_OnEquip(s_RoleAttr);
		this.CalRoleAttrPlus_OnSevenRing(s_RoleAttr);
		this.CalRoleAttr_Finial(s_RoleAttr);
		s_RoleAttr.sFinial -= this.RoleAttr.sFinial;
		this.BaseRoleData.EquipID[(int)pos] = num;
		return s_RoleAttr;
	}

	public S_RoleAttr CompareEquipDataByItemID(ENUM_EquipPosition pos, int itemId)
	{
		S_RoleAttr s_RoleAttr = new S_RoleAttr();
		new S_RoleAttr();
		if (pos == ENUM_EquipPosition.Null)
		{
			return null;
		}
		int num = this.BaseRoleData.EquipID[(int)pos];
		this.BaseRoleData.EquipID[(int)pos] = itemId;
		this.CalRoleAttrPlus_OnEquipByDBF(s_RoleAttr, pos);
		this.CalRoleAttrPlus_OnSevenRing(s_RoleAttr);
		this.CalRoleAttr_Finial(s_RoleAttr);
		s_RoleAttr.sFinial -= this.RoleAttr.sFinial;
		this.BaseRoleData.EquipID[(int)pos] = num;
		return s_RoleAttr;
	}

	public bool CanEquip(int id)
	{
		S_Item data = GameDataDB.ItemDB.GetData(id);
		if (data == null)
		{
			Debug.Log("CanEquip Read Item error!!");
			return false;
		}
		if (data.emSubItemType == ENUM_ItemSubType.Story)
		{
			return data.UseEffect.emTarget != ENUM_UseTarget.NoTarget;
		}
		ENUM_EquipChar equipChar = (ENUM_EquipChar)data.Equip.EquipChar;
		return ((equipChar & ENUM_EquipChar.Player1) == ENUM_EquipChar.Player1 && this.BaseRoleData.ID == 1) || ((equipChar & ENUM_EquipChar.Player2) == ENUM_EquipChar.Player2 && this.BaseRoleData.ID == 2) || ((equipChar & ENUM_EquipChar.Player3) == ENUM_EquipChar.Player3 && this.BaseRoleData.ID == 3) || ((equipChar & ENUM_EquipChar.Player4) == ENUM_EquipChar.Player4 && this.BaseRoleData.ID == 4) || ((equipChar & ENUM_EquipChar.Player5) == ENUM_EquipChar.Player5 && this.BaseRoleData.ID == 5) || ((equipChar & ENUM_EquipChar.Player6) == ENUM_EquipChar.Player6 && this.BaseRoleData.ID == 6) || ((equipChar & ENUM_EquipChar.Player7) == ENUM_EquipChar.Player7 && this.BaseRoleData.ID == 7);
	}

	public ItemData GetEquipItemData(ENUM_EquipPosition Pos)
	{
		if (this.BaseRoleData.EquipID[(int)Pos] > 0)
		{
			return Swd6Application.instance.m_ItemSystem.GetDataBySerialID(this.BaseRoleData.EquipID[(int)Pos]);
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
		if (type == ENUM_ItemSubType.MagicArms)
		{
			result = ENUM_EquipPosition.MagicArms;
		}
		if (type == ENUM_ItemSubType.Talisman)
		{
			result = ENUM_EquipPosition.Talisman;
		}
		if (type == ENUM_ItemSubType.Story)
		{
			result = ENUM_EquipPosition.Story;
		}
		if (type == ENUM_ItemSubType.CosCloth)
		{
			result = ENUM_EquipPosition.CosCloth;
		}
		return result;
	}

	public bool CheckEquipItem(int itemId)
	{
		int num = 10;
		for (int i = 0; i < num; i++)
		{
			ItemData equipItemData = this.GetEquipItemData((ENUM_EquipPosition)i);
			if (equipItemData != null && equipItemData.ID == itemId)
			{
				return true;
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
