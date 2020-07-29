using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem
{
	private static SkillSystem _instance;

	private bool m_ShowMsg;

	private Dictionary<int, List<SkillInfo>>[] m_SkillData;

	private List<int>[] m_RoleSkill;

	private List<int>[] m_MobSkill;

	private Dictionary<int, List<SkillInfo>>[] m_SuperSkillData;

	private List<int>[] m_RoleSuperSkillSlot;

	private Dictionary<int, SuperSkillInfo>[] m_RoleSuperSkill;

	private Dictionary<int, List<int>> m_SuperSkillList;

	private List<int>[] m_ActiveSuperSkill;

	public static SkillSystem Instance
	{
		get
		{
			return SkillSystem._instance;
		}
	}

	public void Initialize()
	{
		this.m_SkillData = new Dictionary<int, List<SkillInfo>>[11];
		for (int i = 0; i < 11; i++)
		{
			this.m_SkillData[i] = new Dictionary<int, List<SkillInfo>>();
		}
		this.m_MobSkill = new List<int>[10];
		for (int j = 0; j < 10; j++)
		{
			this.m_MobSkill[j] = new List<int>();
		}
		this.m_RoleSkill = new List<int>[10];
		for (int k = 0; k < 10; k++)
		{
			this.m_RoleSkill[k] = new List<int>();
		}
		this.m_SuperSkillData = new Dictionary<int, List<SkillInfo>>[11];
		for (int l = 0; l < 11; l++)
		{
			this.m_SuperSkillData[l] = new Dictionary<int, List<SkillInfo>>();
		}
		this.m_RoleSuperSkillSlot = new List<int>[10];
		for (int m = 0; m < 10; m++)
		{
			this.m_RoleSuperSkillSlot[m] = new List<int>();
		}
		this.m_RoleSuperSkill = new Dictionary<int, SuperSkillInfo>[10];
		for (int n = 0; n < 10; n++)
		{
			this.m_RoleSuperSkill[n] = new Dictionary<int, SuperSkillInfo>();
		}
		this.m_ActiveSuperSkill = new List<int>[10];
		for (int num = 0; num < 10; num++)
		{
			this.m_ActiveSuperSkill[num] = new List<int>();
			for (int num2 = 0; num2 < 9; num2++)
			{
				this.m_ActiveSuperSkill[num].Add(0);
			}
		}
		this.m_SuperSkillList = new Dictionary<int, List<int>>();
		this.InitSkillPoolData();
		this.InitSuperSkillPoolData();
		this.InitSuperSkillListData();
	}

	public void Clear()
	{
		this.m_ShowMsg = false;
		for (int i = 0; i < 10; i++)
		{
			this.m_RoleSkill[i].Clear();
		}
		for (int j = 0; j < 10; j++)
		{
			this.m_MobSkill[j].Clear();
		}
		for (int k = 0; k < 10; k++)
		{
			this.m_RoleSuperSkillSlot[k].Clear();
		}
		for (int l = 0; l < 10; l++)
		{
			this.m_RoleSuperSkill[l].Clear();
		}
		for (int m = 0; m < 10; m++)
		{
			for (int n = 0; n < 9; n++)
			{
				this.m_ActiveSuperSkill[m][n] = 0;
			}
		}
	}

	private void InitSkillPoolData()
	{
		GameDataDB.SkillPoolDB.ResetByOrder();
		int dataSize = GameDataDB.SkillPoolDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_SkillSlot dataByOrder = GameDataDB.SkillPoolDB.GetDataByOrder();
			if (dataByOrder != null)
			{
				this.AddSkillSlot(dataByOrder);
			}
		}
		for (int j = 0; j < 11; j++)
		{
			for (int k = 0; k < this.m_SkillData[j].Count; k++)
			{
				foreach (List<SkillInfo> current in this.m_SkillData[j].Values)
				{
					//current.Sort(new SkillInfoComparer(SkillSortFields.LEVEL, SortOrder.Ascending));
				}
			}
		}
	}

	private void AddSkillSlot(S_SkillSlot skillSlot)
	{
		if (skillSlot == null)
		{
			Debug.Log("AddSkillSlot Error!!");
			return;
		}
		int learnRole = skillSlot.LearnRole;
		int emGroup = (int)skillSlot.emGroup;
		if (this.m_SkillData[learnRole].ContainsKey(emGroup))
		{
			List<SkillInfo> list = this.m_SkillData[learnRole][emGroup];
			list.Add(new SkillInfo
			{
				GUID = skillSlot.GUID,
				ID = skillSlot.SkillID,
				Level = skillSlot.Level
			});
			return;
		}
		List<SkillInfo> list2 = new List<SkillInfo>();
		list2.Add(new SkillInfo
		{
			GUID = skillSlot.GUID,
			ID = skillSlot.SkillID,
			Level = skillSlot.Level
		});
		this.m_SkillData[learnRole].Add(emGroup, list2);
	}

	public List<SkillInfo> GetSkillSlotData(int id, int group)
	{
		if (this.m_SkillData[id].ContainsKey(group))
		{
			return this.m_SkillData[id][group];
		}
		return null;
	}

	public void CheckSkillLearnState(bool showMsg)
	{
		List<int> list = new List<int>();
		this.m_ShowMsg = showMsg;
		//for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
		//{
		//	S_RoleData roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
		//	if (roleData != null)
		//	{
		//		for (int j = 1; j <= 5; j++)
		//		{
		//			List<SkillInfo> superSkillSlotData = this.GetSuperSkillSlotData(i, j);
		//			if (superSkillSlotData != null)
		//			{
		//				this.CheckCanLearnSuperSkillSlot(i, roleData.BaseRoleData.Level, superSkillSlotData, ref list);
		//			}
		//		}
		//	}
		//}
	}

	public List<int> GetSkillLearnList(int roleId, int level)
	{
		List<int> list = new List<int>();
		for (int i = 1; i <= 5; i++)
		{
			List<SkillInfo> skillSlotData = this.GetSkillSlotData(roleId, i);
			if (skillSlotData != null)
			{
				this.CheckCanLearnSkill(roleId, level, skillSlotData, ref list);
			}
		}
		list.Sort();
		return list;
	}

	public List<int> GetSuperSkillLearnList(int roleId, int level)
	{
		List<int> list = new List<int>();
		for (int i = 1; i <= 5; i++)
		{
			List<SkillInfo> superSkillSlotData = this.GetSuperSkillSlotData(roleId, i);
			if (superSkillSlotData != null)
			{
				this.CheckCanLearnSuperSkillSlot(roleId, level, superSkillSlotData, ref list);
			}
		}
		list.Sort();
		return list;
	}

	private void CheckCanLearnSkill(int roleId, int level, List<SkillInfo> skillList, ref List<int> learnList)
	{
		//Swd6Application.instance.m_GameDataSystem.GetRoleData(roleId);
		for (int i = 0; i < skillList.Count; i++)
		{
			if (level >= skillList[i].Level)
			{
				S_SkillSlot data = GameDataDB.SkillPoolDB.GetData(skillList[i].GUID);
				if (skillList != null && this.CheckLearnSkillMatch(roleId, data))
				{
					int num = this.LearnSkill(roleId, skillList[i].ID);
					if (num > 0)
					{
						learnList.Add(num);
					}
				}
			}
		}
	}

	private bool CheckLearnSkillMatch(int roleId, S_SkillSlot skillSlot)
	{
		for (int i = 0; i < skillSlot.PreSkill.Count; i++)
		{
			if (!this.CheckSkill(roleId, skillSlot.PreSkill[i]))
			{
				return false;
			}
		}
		//if (skillSlot.PreItem > 0 && !Swd6Application.instance.m_ItemSystem.CheckItem(skillSlot.PreItem, 1))
		//{
		//	return false;
		//}
		//if (skillSlot.PrePartner > 0 && !Swd6Application.instance.m_GameDataSystem.GetFlag(skillSlot.PrePartner))
		//{
		//	return false;
		//}
		//for (int j = 0; j < 4; j++)
		//{
		//	if (skillSlot.PreFlag[j].Flag > 0)
		//	{
		//		bool flag = Swd6Application.instance.m_GameDataSystem.GetFlag(skillSlot.PreFlag[j].Flag);
		//		if (skillSlot.PreFlag[j].FlagON == 0)
		//		{
		//			if (flag)
		//			{
		//				return false;
		//			}
		//		}
		//		else if (!flag)
		//		{
		//			return false;
		//		}
		//	}
		//}
		return true;
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
		this.m_RoleSkill[roleId - 1].Add(skillId);
		return skillId;
	}

	public bool CheckSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return false;
		}
		return this.m_RoleSkill[roleId - 1].Contains(skillId);
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
		return this.m_RoleSkill[roleId - 1];
	}

	public void ClearAllSkillList()
	{
		for (int i = 0; i < 10; i++)
		{
			this.m_RoleSkill[i].Clear();
		}
	}

	public bool LearnMobSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnMobSkill Id error!!");
			return false;
		}
		if (this.CheckMobSkill(roleId, skillId))
		{
			return false;
		}
		this.m_MobSkill[roleId - 1].Add(skillId);
		return true;
	}

	public bool CheckMobSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckMobSkill Id error!!");
			return false;
		}
		return this.m_MobSkill[roleId - 1].Contains(skillId);
	}

	public bool RemoveMobSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("RemoveMobSkill Id error!!");
			return false;
		}
		if (this.m_MobSkill[roleId - 1].Contains(skillId))
		{
			this.m_MobSkill[roleId - 1].Remove(skillId);
			return true;
		}
		return false;
	}

	public bool ReplaceMobSkill(int roleId, int oldSkillId, int newSkillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("ReplaceMobSkill roleId error!!");
			return false;
		}
		if (this.m_MobSkill[roleId - 1].Contains(newSkillId))
		{
			return false;
		}
		for (int i = 0; i < this.m_MobSkill[roleId - 1].Count; i++)
		{
			int num = this.m_MobSkill[roleId - 1][i];
			if (num == oldSkillId)
			{
				this.m_MobSkill[roleId - 1][i] = newSkillId;
				return true;
			}
		}
		return false;
	}

	public List<int> GetMobSkillList(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetMobSkillList Id error!!");
			return null;
		}
		return this.m_MobSkill[roleId - 1];
	}

	public void ClearAllMobSkillList()
	{
		for (int i = 0; i < 10; i++)
		{
			this.m_MobSkill[i].Clear();
		}
	}

	private void InitSuperSkillPoolData()
	{
		GameDataDB.SuperSkillDB.ResetByOrder();
		int dataSize = GameDataDB.SuperSkillDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_SuperSkillSlot dataByOrder = GameDataDB.SuperSkillDB.GetDataByOrder();
			if (dataByOrder != null)
			{
				this.AddSuperSkillSlot(dataByOrder);
			}
		}
		for (int j = 0; j < 11; j++)
		{
			for (int k = 0; k < this.m_SuperSkillData[j].Count; k++)
			{
				foreach (List<SkillInfo> current in this.m_SuperSkillData[j].Values)
				{
					//current.Sort(new SkillInfoComparer(SkillSortFields.LEVEL, SortOrder.Ascending));
				}
			}
		}
	}

	private void InitSuperSkillListData()
	{
		GameDataDB.SkillDB.ResetByOrder();
		int dataSize = GameDataDB.SkillDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_Skill dataByOrder = GameDataDB.SkillDB.GetDataByOrder();
			if (dataByOrder != null && dataByOrder.UseComboCode != 0)
			{
				if (this.m_SuperSkillList.ContainsKey(dataByOrder.LearnRole))
				{
					this.m_SuperSkillList[dataByOrder.LearnRole].Add(dataByOrder.GUID);
				}
				else
				{
					List<int> list = new List<int>();
					list.Add(dataByOrder.GUID);
					this.m_SuperSkillList.Add(dataByOrder.LearnRole, list);
				}
			}
		}
	}

	private void AddSuperSkillSlot(S_SuperSkillSlot skillSlot)
	{
		int learnRole = skillSlot.LearnRole;
		int emCombo = (int)skillSlot.emCombo;
		if (this.m_SuperSkillData[learnRole].ContainsKey(emCombo))
		{
			List<SkillInfo> list = this.m_SuperSkillData[learnRole][emCombo];
			list.Add(new SkillInfo
			{
				GUID = skillSlot.GUID,
				ID = skillSlot.GUID,
				Level = skillSlot.Level
			});
			return;
		}
		List<SkillInfo> list2 = new List<SkillInfo>();
		list2.Add(new SkillInfo
		{
			GUID = skillSlot.GUID,
			ID = skillSlot.GUID,
			Level = skillSlot.Level
		});
		this.m_SuperSkillData[learnRole].Add(emCombo, list2);
	}

	public List<SkillInfo> GetSuperSkillSlotData(int id, int combo)
	{
		if (this.m_SuperSkillData[id].ContainsKey(combo))
		{
			return this.m_SuperSkillData[id][combo];
		}
		return null;
	}

	private void CheckCanLearnSuperSkillSlot(int roleId, int level, List<SkillInfo> skillList, ref List<int> learnList)
	{
		//Swd6Application.instance.m_GameDataSystem.GetRoleData(roleId);
		for (int i = 0; i < skillList.Count; i++)
		{
			if (level >= skillList[i].Level)
			{
				GameDataDB.SkillPoolDB.GetData(skillList[i].GUID);
				if (skillList != null)
				{
					int num = this.LearnSuperSkillSlot(roleId, skillList[i].GUID);
					if (num > 0)
					{
						learnList.Add(num);
					}
				}
			}
		}
	}

	public int LearnSuperSkillSlot(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnSkill Id error!!");
			return 0;
		}
		if (this.CheckSuperSkillSlot(roleId, skillId))
		{
			return 0;
		}
		this.m_RoleSuperSkillSlot[roleId - 1].Add(skillId);
		return skillId;
	}

	public bool CheckSuperSkillSlot(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return false;
		}
		return this.m_RoleSuperSkillSlot[roleId - 1].Contains(skillId);
	}

	public int CheckCanLearnSuperSkill(int roleId, int comboCode)
	{
		if (!this.m_SuperSkillList.ContainsKey(roleId))
		{
			Debug.Log("CheckCanLearnSuperSkill::取不到奧義列表!!_" + roleId);
			return 0;
		}
		for (int i = 0; i < this.m_SuperSkillList[roleId].Count; i++)
		{
			S_Skill data = GameDataDB.SkillDB.GetData(this.m_SuperSkillList[roleId][i]);
			if (data != null && data.UseComboCode == comboCode)
			{
				return data.GUID;
			}
		}
		return 0;
	}

	public void LearnSuperSkill(int roleId, int skillId, string name)
	{
		if (roleId > 10)
		{
			Debug.LogError("LearnSkill Id error!!");
			return;
		}
		SuperSkillInfo superSkillInfo = new SuperSkillInfo();
		superSkillInfo.ID = skillId;
		superSkillInfo.Name = name;
		if (!this.CheckSuperSkill(roleId, skillId))
		{
			this.m_RoleSuperSkill[roleId - 1].Add(skillId, superSkillInfo);
			//Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.SuperSkill, roleId, 0, 0, 1);
		}
	}

	public bool CheckSuperSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return false;
		}
		return this.m_RoleSuperSkill[roleId - 1].ContainsKey(skillId);
	}

	public int GetSuperSkillCount(int roleId)
	{
		if (!this.m_SuperSkillList.ContainsKey(roleId))
		{
			Debug.Log("CheckCanLearnSuperSkill::取不到奧義列表!!_" + roleId);
			return 0;
		}
		return this.m_SuperSkillList[roleId].Count;
	}

	public Dictionary<int, SuperSkillInfo> GetSuperSkillListData(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return null;
		}
		return this.m_RoleSuperSkill[roleId - 1];
	}

	public SuperSkillInfo GetSuperSkillData(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckSkill Id error!!");
			return null;
		}
		if (!this.CheckSuperSkill(roleId, skillId))
		{
			return null;
		}
		return this.m_RoleSuperSkill[roleId - 1][skillId];
	}

	public void SetActiveSuperSkill(int roleId, int index, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("SetActiveSuperSkill roldId error!!");
			return;
		}
		if (index >= this.m_ActiveSuperSkill[roleId - 1].Count)
		{
			Debug.LogError("SetActiveSuperSkill index error!!");
			return;
		}
		this.m_ActiveSuperSkill[roleId - 1][index] = skillId;
	}

	public List<int> GetActiveSuperSkill(int roleId)
	{
		if (roleId > 10)
		{
			Debug.LogError("GetActiveSuperSkill roldId error!!");
			return null;
		}
		return this.m_ActiveSuperSkill[roleId - 1];
	}

	public bool CheckActiveSuperSkill(int roleId, int skillId)
	{
		if (roleId > 10)
		{
			Debug.LogError("CheckActiveSuperSkill roldId error!!");
			return false;
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.m_ActiveSuperSkill[roleId - 1][i] == skillId)
			{
				return true;
			}
		}
		return false;
	}

	public void Save(GameFileStream stream)
	{
		stream.WriteInt(10);
		for (int i = 0; i < 10; i++)
		{
			int count = this.m_RoleSkill[i].Count;
			stream.WriteInt(count);
			for (int j = 0; j < count; j++)
			{
				stream.WriteInt(this.m_RoleSkill[i][j]);
			}
		}
		for (int k = 0; k < 10; k++)
		{
			int count = this.m_RoleSuperSkill[k].Count;
			stream.WriteInt(count);
			foreach (SuperSkillInfo current in this.m_RoleSuperSkill[k].Values)
			{
				stream.WriteObjData(current);
			}
		}
		for (int l = 0; l < 10; l++)
		{
			int count = this.m_ActiveSuperSkill[l].Count;
			stream.WriteInt(count);
			for (int m = 0; m < count; m++)
			{
				stream.WriteInt(this.m_ActiveSuperSkill[l][m]);
			}
		}
		for (int n = 0; n < 10; n++)
		{
			int count = this.m_MobSkill[n].Count;
			stream.WriteInt(count);
			for (int num = 0; num < count; num++)
			{
				stream.WriteInt(this.m_MobSkill[n][num]);
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
		for (int i = 0; i < num; i++)
		{
			int num2 = stream.ReadInt();
			for (int j = 0; j < num2; j++)
			{
				int num3 = stream.ReadInt();
				this.m_RoleSkill[i].Add(num3);
			}
		}
		for (int k = 0; k < num; k++)
		{
			int num2 = stream.ReadInt();
			for (int l = 0; l < num2; l++)
			{
				SuperSkillInfo superSkillInfo = new SuperSkillInfo();
				object obj = superSkillInfo;
				stream.ReadObjData(out obj);
				superSkillInfo = (obj as SuperSkillInfo);
				if (superSkillInfo.Name.Length > 7)
				{
					superSkillInfo.Name = superSkillInfo.Name.Remove(superSkillInfo.Name.Length - 1, 1);
				}
				this.m_RoleSuperSkill[k].Add(superSkillInfo.ID, superSkillInfo);
			}
		}
		for (int m = 0; m < num; m++)
		{
			int num2 = stream.ReadInt();
			for (int n = 0; n < num2; n++)
			{
				int num3 = stream.ReadInt();
				this.m_ActiveSuperSkill[m][n] = num3;
			}
		}
		float num4 = float.Parse("0.0005");
		//if (Swd6Application.instance.m_SaveloadSystem.m_Version >= num4)
		//{
		//	for (int num5 = 0; num5 < num; num5++)
		//	{
		//		int num2 = stream.ReadInt();
		//		for (int num6 = 0; num6 < num2; num6++)
		//		{
		//			int num3 = stream.ReadInt();
		//			this.m_MobSkill[num5].Add(num3);
		//		}
		//	}
		//}
	}
}
