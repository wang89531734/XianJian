using System;
using System.Collections.Generic;

[Serializable]
public class S_BaseRoleData
{
	public int ID;

	public string FamilyName;

	public string Name;

	public int MaxHP;

	public int MaxMP;

	public int MaxAP;

	public int HP;

	public int MP;

	public int AP;

	public int Str;

	public int Mag;

	public int Sta;

	public int Air;

	public int Agi;

	public int Block;

	public int Luck;

	public int Critical;

	public int Mind;

	public ENUM_ElementType emElemntType;

	public int[] Element;

	public int[] EquipID;

	public int CosClothID;

	public int Level;

	public int TotalExp;

	public int[] SevenRingGrid;

	public int SevenRingExp;

	public int SevenRingLevel;

	public bool IsJoin;

	public bool IsFight;

	public bool IsDeath;

	public S_Favorability[] Favorability;

	public S_AutoFightAI[] AutoFightAI;

	public void init()
	{
		this.EquipID = new int[10];
		this.Element = new int[6];
		this.SevenRingGrid = new int[7];
		this.Favorability = new S_Favorability[4];
		for (int i = 0; i < 4; i++)
		{
			this.Favorability[i] = new S_Favorability();
		}
		this.AutoFightAI = new S_AutoFightAI[3];
		for (int j = 0; j < 3; j++)
		{
			this.AutoFightAI[j] = new S_AutoFightAI();
		}
	}

	public void SetStartData(S_StartRoleData startData, int roldId)
	{
		int id = (roldId - 1) * 150 + startData.Level;
		S_Level data = GameDataDB.LevelDB.GetData(id);
		this.HP = startData.HP;
		this.MP = startData.MP;
		this.AP = startData.AP;
		this.MaxHP = data.MaxHP;
		this.MaxMP = data.MaxMP;
		this.MaxAP = data.MaxAP;
		this.Str = data.Str;
		this.Mag = data.Mag;
		this.Sta = data.Sta;
		this.Air = data.Air;
		this.Agi = data.Agi;
		this.Block = data.Block;
		this.Luck = data.Luck;
		this.Critical = data.Critical;
		this.Mind = data.Mind;
		this.emElemntType = data.emElemntType;
		this.Element = data.Element;
		this.Level = startData.Level;
		this.TotalExp = startData.StartExp;
		this.IsJoin = false;
		this.IsFight = false;
		for (int i = 0; i < 10; i++)
		{
			this.EquipID[i] = startData.Equip[i];
			if (this.EquipID[i] > 0)
			{
				ItemData itemData = Swd6Application.instance.m_ItemSystem.AddItem(this.EquipID[i], 1, ENUM_ItemState.Old, false);
				itemData.Equip = true;
				itemData.EquipCount++;
				this.EquipID[i] = itemData.SerialID;
			}
		}
		for (int j = 0; j < startData.Skill.Count; j++)
		{
			Swd6Application.instance.m_SkillSystem.LearnSkill(roldId, startData.Skill[j]);
		}
		List<int> superSkillLearnList = Swd6Application.instance.m_SkillSystem.GetSuperSkillLearnList(roldId, this.Level);
		for (int k = 0; k < superSkillLearnList.Count; k++)
		{
			Swd6Application.instance.m_SkillSystem.LearnSuperSkillSlot(roldId, superSkillLearnList[k]);
		}
		for (int l = 0; l < startData.Favorability.Count; l++)
		{
			this.Favorability[l].ID = startData.Favorability[l].ID;
			this.Favorability[l].Value = startData.Favorability[l].Value;
		}
	}

	public void SetLevelData(int levelUp, bool autoSetExp)
	{
		S_Level data = GameDataDB.LevelDB.GetData((this.ID - 1) * 150 + this.Level);
		S_Level data2 = GameDataDB.LevelDB.GetData((this.ID - 1) * 150 + levelUp);
		if (data != null && data2 != null)
		{
			this.Level = levelUp;
			this.HP = (this.MaxHP += data2.MaxHP - data.MaxHP);
			this.MP = (this.MaxMP += data2.MaxMP - data.MaxMP);
			this.AP = (this.MaxAP += data2.MaxAP - data.MaxAP);
			this.Str += data2.Str - data.Str;
			this.Mag += data2.Mag - data.Mag;
			this.Sta += data2.Sta - data.Sta;
			this.Air += data2.Air - data.Air;
			this.Agi += data2.Agi - data.Agi;
			this.Block += data2.Block - data.Block;
			this.Luck += data2.Luck - data.Luck;
			this.Critical += data2.Critical - data.Critical;
			this.Mind += data2.Mind - data.Mind;
			for (int i = 0; i < 6; i++)
			{
				this.Element[i] += data2.Element[i] - data.Element[i];
			}
			if (autoSetExp)
			{
				data = GameDataDB.LevelDB.GetData(levelUp - 1);
				this.TotalExp = data.NextExp;
			}
		}
	}

	public void SetData(S_BaseRoleData data)
	{
		this.ID = data.ID;
		this.HP = data.HP;
		this.MP = data.MP;
		this.AP = data.AP;
		this.MaxHP = data.MaxHP;
		this.MaxMP = data.MaxMP;
		this.MaxAP = data.MaxAP;
		this.Str = data.Str;
		this.Mag = data.Mag;
		this.Sta = data.Sta;
		this.Air = data.Air;
		this.Agi = data.Agi;
		this.Block = data.Block;
		this.Luck = data.Luck;
		this.Critical = data.Critical;
		this.Mind = data.Mind;
		this.emElemntType = data.emElemntType;
		this.Level = data.Level;
		this.TotalExp = data.TotalExp;
		this.SevenRingExp = data.SevenRingExp;
		this.SevenRingLevel = data.SevenRingLevel;
		this.IsJoin = false;
		this.IsFight = false;
		this.IsDeath = false;
		for (int i = 0; i < data.Element.Length; i++)
		{
			this.Element[i] = data.Element[i];
		}
		for (int j = 0; j < data.EquipID.Length; j++)
		{
			this.EquipID[j] = data.EquipID[j];
		}
		for (int k = 0; k < data.Favorability.Length; k++)
		{
			this.Favorability[k].ID = data.Favorability[k].ID;
			this.Favorability[k].Value = data.Favorability[k].Value;
		}
		for (int l = 0; l < data.AutoFightAI.Length; l++)
		{
			this.AutoFightAI[l] = data.AutoFightAI[l];
		}
	}
}
