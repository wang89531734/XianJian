using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem
{
	private static SkillSystem _instance;

	private Dictionary<int, List<SkillInfo>>[] m_SkillPlateData;

	private List<int>[] m_RoleSkill;

	private Dictionary<int, List<FightSkillHotKeyInfo>>[] m_FightSkill;

	public static SkillSystem Instance
	{
		get
		{
			return SkillSystem._instance;
		}
	}

	public void Initialize()
	{
		this.m_SkillPlateData = new Dictionary<int, List<SkillInfo>>[10];
		for (int i = 0; i < 10; i++)
		{
			this.m_SkillPlateData[i] = new Dictionary<int, List<SkillInfo>>();
		}
		this.m_RoleSkill = new List<int>[10];
		for (int j = 0; j < 10; j++)
		{
			this.m_RoleSkill[j] = new List<int>();
		}
		this.m_FightSkill = new Dictionary<int, List<FightSkillHotKeyInfo>>[10];
		for (int k = 0; k < 10; k++)
		{
			this.m_FightSkill[k] = new Dictionary<int, List<FightSkillHotKeyInfo>>();
			for (int l = 0; l < 5; l++)
			{
				List<FightSkillHotKeyInfo> list = new List<FightSkillHotKeyInfo>();
				for (int m = 0; m < 10; m++)
				{
					FightSkillHotKeyInfo item = new FightSkillHotKeyInfo();
					list.Add(item);
				}
				this.m_FightSkill[k].Add(l, list);
			}
		}
		this.InitSkillPoolData();
	}

	public void InitDefaultHotKeySkill()
	{
		for (int i = 0; i < 10; i++)
		{
			if (i > 0)
			{
				this.ResetSkillHotkey(i, ResetSkillType.ALL);
				this.SetDefaultHotKeySkill(i, true);
			}
		}
	}

	public void ResetAllHotkey()
	{
		for (int i = 0; i < 10; i++)
		{
			if (i > 0)
			{
				this.ResetSkillHotkey(i, ResetSkillType.ALL);
			}
		}
	}

	public void Clear()
	{
		for (int i = 0; i < 10; i++)
		{
			this.m_RoleSkill[i].Clear();
			if (i > 0)
			{
				this.ResetAllSpherSkill(i);
			}
		}
	}

	public void ResetSkillHotkey(int roleId, ResetSkillType type)
	{
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> fightSkillHotkeyList = this.GetFightSkillHotkeyList(roleId, i);
			for (int j = 0; j < fightSkillHotkeyList.Count; j++)
			{
				if (fightSkillHotkeyList[j].ID != 0)
				{
					S_Skill data = GameDataDB.SkillDB.GetData(fightSkillHotkeyList[j].ID);
					if (data != null)
					{
						if (type == ResetSkillType.SKILL)
						{
							if (data.emSkillEffectType != ENUM_SkillEffectType.Skill)
							{
								goto IL_99;
							}
						}
						else if (type == ResetSkillType.SPHERESKILL && data.emSkillEffectType != ENUM_SkillEffectType.SphereSkill)
						{
							goto IL_99;
						}
					}
					fightSkillHotkeyList[j].ID = 0;
					fightSkillHotkeyList[j].AI = false;
				}
				IL_99:;
			}
		}
	}

	private void InitSkillPoolData()
	{
		for (int i = 0; i < 10; i++)
		{
			if (i != 0)
			{
				GameDataDB.SkillPlateDB.ResetByOrder();
				int dataSize = GameDataDB.SkillPlateDB.GetDataSize();
				int num = (i - 1) * 4 + 1;
				int num2 = num + 4;
				for (int j = num; j < num2; j++)
				{
					S_SkillPlate data = GameDataDB.SkillPlateDB.GetData(j);
					if (data != null)
					{
						this.AddSkillSlot(i, data);
					}
				}
			}
		}
	}

	private void AddSkillSlot(int roldID, S_SkillPlate skillSlot)
	{
		if (skillSlot == null)
		{
			Debug.Log("AddSkillSlot Error!!");
			return;
		}
		int emElement = (int)skillSlot.emElement;
		SkillInfo skillInfo = new SkillInfo();
		List<SkillInfo> list = new List<SkillInfo>();
		if (this.m_SkillPlateData[roldID].ContainsKey(emElement))
		{
			list = this.m_SkillPlateData[roldID][emElement];
			skillInfo.ID = skillSlot.BaseSkillID;
			skillInfo.LearnPoint = skillSlot.LearnPoint;
			skillInfo.LearnTime = 0;
			skillInfo.ActivePoint = 0;
			skillInfo.MaxLearnTime = skillSlot.LearnTime;
			skillInfo.Type = SphereType.Base;
			list.Add(skillInfo);
		}
		else
		{
			skillInfo.ID = skillSlot.BaseSkillID;
			skillInfo.LearnPoint = skillSlot.LearnPoint;
			skillInfo.LearnTime = 0;
			skillInfo.ActivePoint = 0;
			skillInfo.MaxLearnTime = skillSlot.LearnTime;
			skillInfo.Type = SphereType.Base;
			list.Add(skillInfo);
			this.m_SkillPlateData[roldID].Add(emElement, list);
		}
		for (int i = 0; i < skillSlot.SunSkill.Count; i++)
		{
			int skillID = skillSlot.SunSkill[i].SkillID;
			if (skillID > 0)
			{
				skillInfo = new SkillInfo();
				skillInfo.ID = skillID;
				skillInfo.PreID = skillSlot.SunSkill[i].PreSkillID;
				skillInfo.LearnTime = 0;
				skillInfo.LearnPoint = skillSlot.SunSkill[i].LearnPoint;
				skillInfo.ActivePoint = skillSlot.SunSkill[i].ActivePoint;
				skillInfo.MaxLearnTime = skillSlot.SunSkill[i].LearnTime;
				skillInfo.Type = SphereType.Sun;
				skillInfo.Group = 0;
				if (i >= 4)
				{
					skillInfo.Group = 1;
				}
				list.Add(skillInfo);
			}
		}
		for (int j = 0; j < skillSlot.MoonSkill.Count; j++)
		{
			int skillID = skillSlot.MoonSkill[j].SkillID;
			if (skillID > 0)
			{
				skillInfo = new SkillInfo();
				skillInfo.ID = skillID;
				skillInfo.PreID = skillSlot.MoonSkill[j].PreSkillID;
				skillInfo.LearnTime = 0;
				skillInfo.LearnPoint = skillSlot.MoonSkill[j].LearnPoint;
				skillInfo.ActivePoint = skillSlot.MoonSkill[j].ActivePoint;
				skillInfo.MaxLearnTime = skillSlot.MoonSkill[j].LearnTime;
				skillInfo.Type = SphereType.Moon;
				skillInfo.Group = 0;
				if (j >= 4)
				{
					skillInfo.Group = 1;
				}
				list.Add(skillInfo);
			}
		}
	}

	public List<SkillInfo> GetSkillPlateSlotListData(int id, int type)
	{
		if (this.m_SkillPlateData[id].ContainsKey(type))
		{
			return this.m_SkillPlateData[id][type];
		}
		return null;
	}

	public List<int> GetSkillLearnList(int roleId, int currentLevel, int newlevel)
	{
		List<int> list = new List<int>();
		int num = 0;
		for (int i = currentLevel; i <= newlevel; i++)
		{
			S_Level levelData = Swd6Application.instance.m_GameDataSystem.GetLevelData(roleId, i);
			if (levelData.LearnSkillID != 0)
			{
				if (!this.CheckSkill(roleId, levelData.LearnSkillID))
				{
					this.LearnSkill(roleId, levelData.LearnSkillID);
					num = levelData.LearnSkillID;
				}
			}
		}
		if (num > 0)
		{
			list.Add(num);
		}
		return list;
	}

	public void SetDefaultHotKeySkill(int roleId, bool all)
	{
		List<int> skillList = this.GetSkillList(roleId);
		for (int i = 0; i < skillList.Count; i++)
		{
			S_Skill data = GameDataDB.SkillDB.GetData(skillList[i]);
			if (data != null)
			{
				if (this.CheckFightSkillHotkeyID(roleId, skillList[i]) && !all)
				{
					break;
				}
				if (data.emSkillEffectType == ENUM_SkillEffectType.Skill)
				{
					this.AutoSetFightSkillHotkeyID(roleId, skillList[i]);
					if (!all)
					{
						break;
					}
				}
				else
				{
					List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, roleId);
					this.AutoSetFightSphereSkillHotkeyID(roleId, skillPlateSlotListData[0]);
					if (!all)
					{
						break;
					}
				}
			}
		}
	}

	public int LearnSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnSkill Id error!!");
			return 0;
		}
		if (this.CheckSkill(roleId, skillId))
		{
			return 0;
		}
		this.ReplaceGroupSkill(roleId, skillId);
		this.m_RoleSkill[roleId - 1].Add(skillId);
		this.AutoSetFightSkillHotkeyID(roleId, skillId);
		return skillId;
	}

	public void LearnAllSphereSkill(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnAllSphereSkill Id error!!");
			return;
		}
		List<int> list = new List<int>();
		List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, roleId);
		if (skillPlateSlotListData == null)
		{
			return;
		}
		for (int i = 0; i < skillPlateSlotListData.Count; i++)
		{
			skillPlateSlotListData[i].LearnTime = skillPlateSlotListData[i].MaxLearnTime;
		}
	}

	public bool CheckSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return false;
		}
		List<int> skillList = this.GetSkillList(roleId);
		return skillList.Contains(skillId);
	}

	public void ReplaceGroupSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("RemoveGroupSkill Id error!!");
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(skillId);
		List<int> list = new List<int>();
		if (data == null)
		{
			Debug.LogError("讀取技能表錯誤::" + skillId);
			return;
		}
		List<int> skillList = this.GetSkillList(roleId);
		for (int i = 0; i < skillList.Count; i++)
		{
			S_Skill data2 = GameDataDB.SkillDB.GetData(skillList[i]);
			if (data2 == null)
			{
				Debug.LogError("讀取技能表錯誤::" + skillList[i]);
			}
			else if (data.Group == data2.Group)
			{
				list.Add(data2.GUID);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			this.RemoveSkill(roleId, list[j]);
		}
	}

	public bool RemoveSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return false;
		}
		if (this.m_RoleSkill[roleId - 1].Contains(skillId))
		{
			this.RemoveFightSkillHotkeyID(roleId, skillId);
			this.m_RoleSkill[roleId - 1].Remove(skillId);
			return true;
		}
		return false;
	}

	public List<int> GetSkillList(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetSkillList Id error!!");
			return null;
		}
		List<int> list = new List<int>();
		for (int i = 1; i <= 4; i++)
		{
			List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, i);
			if (skillPlateSlotListData != null)
			{
				for (int j = 0; j < skillPlateSlotListData.Count; j++)
				{
					if (skillPlateSlotListData[j].LearnTime > 0)
					{
						list.Add(skillPlateSlotListData[j].ID + skillPlateSlotListData[j].LearnTime - 1);
					}
				}
			}
		}
		for (int k = 0; k < this.m_RoleSkill[roleId - 1].Count; k++)
		{
			list.Add(this.m_RoleSkill[roleId - 1][k]);
		}
		list.Sort();
		return list;
	}

	public List<int> GetPassiveSkillList(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetSkillList Id error!!");
			return null;
		}
		List<int> list = new List<int>();
		for (int i = 1; i <= 4; i++)
		{
			List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, i);
			if (skillPlateSlotListData != null)
			{
				for (int j = 0; j < skillPlateSlotListData.Count; j++)
				{
					if (skillPlateSlotListData[j].LearnTime != 0)
					{
						int num = skillPlateSlotListData[j].ID + skillPlateSlotListData[j].LearnTime - 1;
						S_Skill data = GameDataDB.SkillDB.GetData(num);
						if (data != null && data.emItemType == ENUM_ItemSubType.Passive)
						{
							S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
							if (data2 != null && data2.SpecialID > 0)
							{
								list.Add(num);
							}
						}
					}
				}
			}
		}
		list.Sort();
		return list;
	}

	public List<int> GetPassiveBuffSkillList(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetPassiveBuffSkillList Id error!!");
			return null;
		}
		List<int> list = new List<int>();
		for (int i = 1; i <= 4; i++)
		{
			List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, i);
			if (skillPlateSlotListData != null)
			{
				for (int j = 0; j < skillPlateSlotListData.Count; j++)
				{
					if (skillPlateSlotListData[j].LearnTime != 0)
					{
						int num = skillPlateSlotListData[j].ID + skillPlateSlotListData[j].LearnTime - 1;
						S_Skill data = GameDataDB.SkillDB.GetData(num);
						if (data != null && data.emItemType == ENUM_ItemSubType.Passive)
						{
							S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
							if (data2 != null && (data2.Buffer.Count > 0 || data2.DeBuffer.Count > 0))
							{
								list.Add(num);
							}
						}
					}
				}
			}
		}
		list.Sort();
		return list;
	}

	public List<SkillInfo> GetSphereSkillList(int roleId, int type, SphereType sType, int group)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetSphereSkillList Id error!!");
			return null;
		}
		List<SkillInfo> list = new List<SkillInfo>();
		List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, type);
		if (skillPlateSlotListData == null)
		{
			return list;
		}
		for (int i = 0; i < skillPlateSlotListData.Count; i++)
		{
			if (skillPlateSlotListData[i].Type == sType)
			{
				if (skillPlateSlotListData[i].Group == group)
				{
					list.Add(skillPlateSlotListData[i]);
				}
			}
			else if (skillPlateSlotListData[i].Type == SphereType.Base)
			{
				list.Add(skillPlateSlotListData[i]);
			}
		}
		list.Sort();
		return list;
	}

	public int GetSphereSkillId(SkillInfo skillInfo)
	{
		if (skillInfo.LearnTime > 0)
		{
			return skillInfo.ID + skillInfo.LearnTime - 1;
		}
		return skillInfo.ID;
	}

	public void SetSkillPlateSlotData(int roleId, int type, int skillId, int learnTime)
	{
		if (roleId > 10)
		{
			Debug.LogError("SetSkillPlateSlotData roldId error!!");
			return;
		}
		List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(roleId, type);
		if (skillPlateSlotListData == null)
		{
			return;
		}
		for (int i = 0; i < skillPlateSlotListData.Count; i++)
		{
			if (skillPlateSlotListData[i].ID == skillId)
			{
				skillPlateSlotListData[i].LearnTime = learnTime;
				break;
			}
		}
	}

	public int LearnDefaultSphereSkill(int roleId, int type)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnDefaultSphereSkill Id error!!");
			return 0;
		}
		if (!this.m_SkillPlateData[roleId].ContainsKey(type))
		{
			return 0;
		}
		List<SkillInfo> list = this.m_SkillPlateData[roleId][type];
		if (list == null)
		{
			return 0;
		}
		list[0].LearnTime = 1;
		list[0].LearnPoint = 1;
		this.AutoSetFightSphereSkillHotkeyID(roleId, list[0]);
		return list[0].LearnPoint;
	}

	public bool CheckPreSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckPreSkill Id error!!");
			return false;
		}
		if (skillId == 0)
		{
			return true;
		}
		foreach (List<SkillInfo> current in this.m_SkillPlateData[roleId].Values)
		{
			for (int i = 0; i < current.Count; i++)
			{
				if (current[i].ID == skillId && current[i].LearnTime > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool CheckPreLearnPoint(int roleId, SkillInfo skillInfo)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckPreSkill Id error!!");
			return false;
		}
		if (skillInfo.ActivePoint == 0)
		{
			return true;
		}
		List<SkillInfo> sphereSkillList = this.GetSphereSkillList(roleId, roleId, skillInfo.Type, skillInfo.Group);
		if (sphereSkillList.Count == 0)
		{
			return false;
		}
		if (skillInfo.PreID == 0)
		{
			return true;
		}
		SkillInfo skillInfo2 = null;
		for (int i = 0; i < sphereSkillList.Count; i++)
		{
			if (sphereSkillList[i].ID == skillInfo.PreID)
			{
				skillInfo2 = sphereSkillList[i];
				break;
			}
		}
		if (skillInfo2 == null)
		{
			return false;
		}
		int learnTime = skillInfo2.LearnTime;
		return learnTime >= skillInfo.ActivePoint;
	}

	public void ResetSpherSkill(int roleId, int type)
	{
		if (roleId > 10)
		{
			Debug.LogError("ResetSpherSkill Id error!!");
			return;
		}
		if (!this.m_SkillPlateData[roleId].ContainsKey(type))
		{
			return;
		}
		List<SkillInfo> list = this.m_SkillPlateData[roleId][type];
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].LearnTime = 0;
		}
	}

	public void ResetAllSpherSkill(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("ResetAllSpherSkill Id error!!");
			return;
		}
		for (int i = 1; i <= 4; i++)
		{
			this.ResetSpherSkill(roleId, i);
		}
		this.ResetSkillHotkey(roleId, ResetSkillType.SPHERESKILL);
	}

	public int CheckSpherSkillCostPoint(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("ResetAllSpherSkill Id error!!");
			return 0;
		}
		int num = 0;
		for (int i = 1; i <= 4; i++)
		{
			if (this.m_SkillPlateData[roleId].ContainsKey(i))
			{
				List<SkillInfo> list = this.m_SkillPlateData[roleId][i];
				if (list != null)
				{
					for (int j = 0; j < list.Count; j++)
					{
						num += list[j].LearnTime * list[j].LearnPoint;
					}
				}
			}
		}
		return num;
	}

	public void ClearAllSkillList()
	{
		for (int i = 0; i < 10; i++)
		{
			this.m_RoleSkill[i].Clear();
		}
	}

	public void ClearRoleSkillList(int roleId)
	{
		for (int i = 0; i < this.m_RoleSkill[roleId - 1].Count; i++)
		{
			this.RemoveFightSkillHotkeyID(roleId, this.m_RoleSkill[roleId - 1][i]);
		}
		this.m_RoleSkill[roleId - 1].Clear();
		this.ResetAllSpherSkill(roleId);
	}

	public void SetFightSkillHotkeyID(int roleId, int page, int index, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("SetFightSkillHotkeyID roldId error!!");
			return;
		}
		if (this.m_FightSkill[roleId].ContainsKey(page))
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][page];
			list[index].ID = skillId;
		}
	}

	public void SetFightSkillHotkeyAIState(int roleId, int page, int index, bool AI)
	{
		if (roleId > 10)
		{
			Debug.LogError("SetFightSkillHotkeyAIState roldId error!!");
			return;
		}
		if (this.m_FightSkill[roleId].ContainsKey(page))
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][page];
			list[index].AI = AI;
		}
	}

	public void SetFightSkillHotkeyData(int roleId, int page, int index, int skillId, bool AI)
	{
		if (roleId > 10)
		{
			Debug.LogError("SetFightSkillHotkeyAIState roldId error!!");
			return;
		}
		if (this.m_FightSkill[roleId].ContainsKey(page))
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][page];
			list[index].ID = skillId;
			list[index].AI = AI;
		}
	}

	public bool CheckFightSkillHotkeyID(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckFightSkillHotkeyID roleId error!!");
			return false;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(skillId);
		if (data == null)
		{
			return false;
		}
		if (data.emItemType == ENUM_ItemSubType.Passive)
		{
			return false;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].ID == skillId)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void RemoveFightSkillHotkeyID(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("AutoSetFightSkillHotkeyID roldId error!!");
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(skillId);
		if (data == null)
		{
			return;
		}
		if (data.emItemType == ENUM_ItemSubType.Passive)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].ID == skillId)
				{
					list[j].ID = 0;
					list[j].AI = false;
					return;
				}
			}
		}
	}

	public void AutoSetFightSkillHotkeyID(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("AutoSetFightSkillHotkeyID roldId error!!");
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(skillId);
		if (data == null)
		{
			return;
		}
		if (data.emItemType == ENUM_ItemSubType.Passive)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].ID == 0)
				{
					list[j].ID = skillId;
					list[j].AI = true;
					return;
				}
			}
		}
	}

	public void AutoSetFightSphereSkillHotkeyID(int roleId, SkillInfo skillInfo)
	{
		if (roleId > 10)
		{
			Debug.LogError("AutoSetFightSphereSkillHotkeyID roldId error!!");
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(skillInfo.ID);
		if (data == null)
		{
			return;
		}
		if (data.emItemType == ENUM_ItemSubType.Passive)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][i];
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < skillInfo.LearnTime; k++)
				{
					int num = skillInfo.ID + k;
					if (list[j].ID == num)
					{
						list[j].ID = skillInfo.ID + skillInfo.LearnTime - 1;
						list[j].AI = true;
						return;
					}
				}
			}
		}
		for (int l = 0; l < 5; l++)
		{
			List<FightSkillHotKeyInfo> list2 = this.m_FightSkill[roleId][l];
			for (int m = 0; m < list2.Count; m++)
			{
				if (list2[m].ID == 0)
				{
					list2[m].ID = skillInfo.ID + skillInfo.LearnTime - 1;
					list2[m].AI = true;
					return;
				}
			}
		}
	}

	public List<FightSkillHotKeyInfo> GetFightSkillHotkeyList(int roleId, int page)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetFightSkillHotkeyList roldId error!!");
			return null;
		}
		if (this.m_FightSkill[roleId].ContainsKey(page))
		{
			return this.m_FightSkill[roleId][page];
		}
		return null;
	}

	public FightSkillHotKeyInfo GetFightSkillHotkey(int roleId, int page, int skillSlot)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetFightSkillHotkey roldId error!!");
			return null;
		}
		if (this.m_FightSkill[roleId].ContainsKey(page))
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][page];
			return list[skillSlot];
		}
		return null;
	}

	public FightSkillHotKeyInfo GetFightSkillHotkey(int roldId, int skillId)
	{
		if (skillId <= 0 || roldId <= 0)
		{
			return null;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> fightSkillHotkeyList = this.GetFightSkillHotkeyList(roldId, i);
			for (int j = 0; j < fightSkillHotkeyList.Count; j++)
			{
				if (fightSkillHotkeyList[j].ID == skillId)
				{
					return fightSkillHotkeyList[j];
				}
			}
		}
		return null;
	}

	public void SwapFightSkillHotkey(int roleId, int srcItemId, int targetItemId)
	{
		int num = -1;
		int index = -1;
		FightSkillHotKeyInfo fightSkillHotKeyInfo = null;
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> fightSkillHotkeyList = this.GetFightSkillHotkeyList(roleId, i);
			for (int j = 0; j < fightSkillHotkeyList.Count; j++)
			{
				if (fightSkillHotkeyList[j].ID == srcItemId)
				{
					num = i;
					index = j;
					fightSkillHotKeyInfo = fightSkillHotkeyList[j];
					break;
				}
			}
			if (num >= 0)
			{
				break;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			List<FightSkillHotKeyInfo> fightSkillHotkeyList2 = this.GetFightSkillHotkeyList(roleId, k);
			for (int l = 0; l < fightSkillHotkeyList2.Count; l++)
			{
				if (fightSkillHotkeyList2[l].ID == targetItemId)
				{
					this.SetFightSkillHotkeyData(roleId, num, index, targetItemId, fightSkillHotkeyList2[l].AI);
					this.SetFightSkillHotkeyData(roleId, k, l, srcItemId, fightSkillHotKeyInfo.AI);
					return;
				}
			}
		}
	}

	public bool IsFightSkillHotkeyAllEmpty(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("IsFightSkillHotkeyAllEmpty roldId error!!");
			return false;
		}
		for (int i = 0; i < 5; i++)
		{
			List<FightSkillHotKeyInfo> list = this.m_FightSkill[roleId][i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].ID > 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void Save(GameFileStream stream)
	{
		stream.WriteInt(10);
		int num;
		for (int i = 0; i < 10; i++)
		{
			num = this.m_RoleSkill[i].Count;
			stream.WriteInt(num);
			for (int j = 0; j < num; j++)
			{
				stream.WriteInt(this.m_RoleSkill[i][j]);
			}
		}
		num = 5;
		stream.WriteInt(num);
		num = 10;
		stream.WriteInt(num);
		for (int k = 0; k < 10; k++)
		{
			for (int l = 0; l < 5; l++)
			{
				List<FightSkillHotKeyInfo> fightSkillHotkeyList = this.GetFightSkillHotkeyList(k, l);
				for (int m = 0; m < fightSkillHotkeyList.Count; m++)
				{
					stream.WriteInt(fightSkillHotkeyList[m].ID);
					stream.WriteBool(fightSkillHotkeyList[m].AI);
				}
			}
		}
		for (int n = 0; n < 10; n++)
		{
			for (int num2 = 1; num2 <= 4; num2++)
			{
				List<SkillInfo> skillPlateSlotListData = this.GetSkillPlateSlotListData(n, num2);
				if (skillPlateSlotListData == null)
				{
					stream.WriteInt(0);
				}
				else
				{
					stream.WriteInt(skillPlateSlotListData.Count);
					for (int num3 = 0; num3 < skillPlateSlotListData.Count; num3++)
					{
						stream.WriteInt(skillPlateSlotListData[num3].ID);
						stream.WriteInt(skillPlateSlotListData[num3].LearnTime);
					}
				}
			}
		}
	}

	public void Load(GameFileStream stream)
	{
		this.Clear();
		if (stream.IsEnd())
		{
			Debug.Log("Skill::Load已到end!!");
			return;
		}
		int num = stream.ReadInt();
		if (num > 10)
		{
			Debug.Log("讀取技能資料錯誤!!角色數量值超過_" + num);
			return;
		}
		int num2;
		for (int i = 0; i < num; i++)
		{
			num2 = stream.ReadInt();
			for (int j = 0; j < num2; j++)
			{
				int num3 = stream.ReadInt();
				this.m_RoleSkill[i].Add(num3);
			}
		}
		num2 = stream.ReadInt();
		int num4 = stream.ReadInt();
		for (int k = 0; k < num; k++)
		{
			for (int l = 0; l < num2; l++)
			{
				for (int m = 0; m < num4; m++)
				{
					int num3 = stream.ReadInt();
					bool aI = stream.ReadBool();
					this.SetFightSkillHotkeyID(k, l, m, num3);
					this.SetFightSkillHotkeyAIState(k, l, m, aI);
				}
			}
			if (k > 0)
			{
				this.SetDefaultHotKeySkill(k, false);
			}
		}
		float num5 = float.Parse("0.02");
		if (Swd6Application.instance.m_SaveloadSystem.m_Version >= num5)
		{
			for (int n = 0; n < num; n++)
			{
				for (int num6 = 1; num6 <= 4; num6++)
				{
					num4 = stream.ReadInt();
					for (int num7 = 0; num7 < num4; num7++)
					{
						int num3 = stream.ReadInt();
						int learnTime = stream.ReadInt();
						this.SetSkillPlateSlotData(n, num6, num3, learnTime);
					}
				}
			}
		}
	}
}
