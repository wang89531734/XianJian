using System;
using System.Collections.Generic;
using YouYou;

[Serializable]
public class S_BaseRoleData
{
	public int ID;

	public string FamilyName;

	public string Name;

	public int MaxHP;

	public int MaxMP;

	public int HP;

	public int MP;

	public int Atk;

	public int MAtk;

	public int Def;

	public int MDef;

	public int Agi;

	public int Block;

	public int Dodge;

	public int Critical;

	public ENUM_ElementType emElemntType;

	public ENUM_ElementType emWeaponElemntType;

	public int[] Element;

	public int[] AtkElement;

	public int[] EquipID;

	public int Level;

	public int TotalExp;

	public int TotalSkillPoint;

	public int CostSkillPoint;

	public bool IsJoin;

	public bool IsFight;

	public bool IsDeath;

	public void init()
	{
		this.EquipID = new int[8];
		this.Element = new int[4];
		this.AtkElement = new int[4];
	}

	public void SetStartData(S_StartRoleData startData, int roldId, bool setEquip)
	{
		int id = (roldId - 1) * 150 + startData.Level;
		S_Level data = GameDataDB.LevelDB.GetData(id);
		this.HP = startData.HP;
		this.MP = startData.MP;
		this.MaxHP = data.MaxHP;
		this.MaxMP = data.MaxMP;
		this.Atk = data.Atk;
		this.MAtk = data.MAtk;
		this.Def = data.Def;
		this.MDef = data.MDef;
		this.Agi = data.Agi;
		this.Block = data.Block;
		this.Dodge = data.Dodage;
		this.Critical = data.Critical;
		this.emElemntType = startData.emElemntType;
		this.Level = startData.Level;
		this.TotalExp = startData.StartExp;
		this.TotalSkillPoint = data.SkillPoint;
		this.CostSkillPoint = 0;
		this.IsJoin = false;
		this.IsFight = false;
		if (setEquip)
		{
			for (int i = 0; i < 8; i++)
			{
				this.EquipID[i] = startData.Equip[i];
				if (this.EquipID[i] > 0)
				{
					ItemData itemData = GameEntry.Instance.m_ItemSystem.AddItem(this.EquipID[i], 1, ENUM_ItemState.Old, false);
					if (itemData != null)
					{
						itemData.Equip = true;
						itemData.EquipCount++;
						this.EquipID[i] = itemData.SerialID;
					}
				}
			}
		}
        GameEntry.Instance.m_SkillSystem.ResetAllHotkey();
		for (int j = 0; j < startData.Skill.Count; j++)
		{
            GameEntry.Instance.m_SkillSystem.LearnSkill(roldId, startData.Skill[j]);
		}
		this.CostSkillPoint = GameEntry.Instance.m_SkillSystem.LearnDefaultSphereSkill(roldId, (int)this.emElemntType);
	}

	public void SetLevelUpData(int levelUp, bool autoSetExp, ref S_LevelUpInfo levelUpInfo)
	{
		S_Level data = GameDataDB.LevelDB.GetData((this.ID - 1) * 150 + this.Level);
		S_Level data2 = GameDataDB.LevelDB.GetData((this.ID - 1) * 150 + levelUp);
		if (data != null && data2 != null)
		{
			List<int> skillLearnList = GameEntry.Instance.m_SkillSystem.GetSkillLearnList(this.ID, this.Level + 1, levelUp);
			if (skillLearnList.Count > 0)
			{
				levelUpInfo.LearnSkillList.Clear();
				for (int i = 0; i < skillLearnList.Count; i++)
				{
					levelUpInfo.LearnSkillList.Add(skillLearnList[i]);
				}
			}
			this.Level = levelUp;
			this.HP = (this.MaxHP += data2.MaxHP - data.MaxHP);
			this.MP = (this.MaxMP += data2.MaxMP - data.MaxMP);
			this.Atk += data2.Atk - data.Atk;
			this.MAtk += data2.MAtk - data.MAtk;
			this.Def += data2.Def - data.Def;
			this.MDef += data2.MDef - data.MDef;
			this.Agi += data2.Agi - data.Agi;
			this.Block += data2.Block - data.Block;
			this.Dodge += data2.Dodage - data.Dodage;
			this.Critical += data2.Critical - data.Critical;
			this.TotalSkillPoint += data2.SkillPoint;
			if (data2.SkillPoint > 0)
			{
				levelUpInfo.SkillPoint += data2.SkillPoint;
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
		this.MaxHP = data.MaxHP;
		this.MaxMP = data.MaxMP;
		this.Atk = data.Atk;
		this.MAtk = data.MAtk;
		this.Def = data.Def;
		this.MDef = data.MDef;
		this.Agi = data.Agi;
		this.Block = data.Block;
		this.Dodge = data.Dodge;
		this.Critical = data.Critical;
		this.emElemntType = data.emElemntType;
		this.Level = data.Level;
		this.TotalExp = data.TotalExp;
		this.TotalSkillPoint = data.TotalSkillPoint;
		this.CostSkillPoint = data.CostSkillPoint;
		this.IsJoin = false;
		this.IsFight = false;
		this.IsDeath = false;
		for (int i = 0; i < data.Element.Length; i++)
		{
			this.Element[i] = data.Element[i];
		}
		for (int j = 0; j < data.AtkElement.Length; j++)
		{
			this.AtkElement[j] = data.AtkElement[j];
		}
		for (int k = 0; k < data.EquipID.Length; k++)
		{
			this.EquipID[k] = data.EquipID[k];
		}
	}
}
