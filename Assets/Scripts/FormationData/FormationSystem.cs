using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class FormationSystem
{
	private static FormationSystem _instance;

	private int m_DefaultFormation;

	private List<FormationData> m_FormationDataList = new List<FormationData>();

	private List<int> m_FightItem = new List<int>();

	private Dictionary<int, List<int>> m_FightSkill = new Dictionary<int, List<int>>();

	public static FormationSystem Instance
	{
		get
		{
			return FormationSystem._instance;
		}
	}

	public int DefaultFormation
	{
		get
		{
			return this.m_DefaultFormation;
		}
		set
		{
			this.m_DefaultFormation = value;
		}
	}

	public FormationSystem()
	{
		FormationSystem._instance = this;
	}

	public void Initialize()
	{
		for (int i = 0; i < 4; i++)
		{
			S_FormationData data = GameDataDB.FormationDB.GetData(i + 1);
			if (data == null)
			{
				break;
			}
			FormationData formationData = new FormationData();
			formationData.LeaderID = 0;
			formationData.Enable = false;
			formationData.emElement = data.emElement;
			if (i == 0)
			{
				formationData.Enable = true;
			}
			FormationUnit formationUnit;
			for (int j = 0; j < data.emActionType.Count; j++)
			{
				formationUnit = new FormationUnit();
				formationUnit.IsLeader = false;
				formationUnit.IsMob = false;
				formationUnit.RoleID = 0;
				formationUnit.emAI = data.emAI[j];
				formationUnit.emActionType = data.emActionType[j];
				if (j == 0)
				{
					formationUnit.IsLeader = true;
					formationUnit.IsController = true;
				}
				formationData.Unit.Add(formationUnit);
			}
			formationUnit = new FormationUnit();
			formationUnit.IsLeader = false;
			formationUnit.IsController = false;
			formationUnit.IsMob = true;
			formationUnit.RoleID = 0;
			formationData.Unit.Add(formationUnit);
			this.m_FormationDataList.Add(formationData);
		}
		for (int k = 0; k < 5; k++)
		{
			this.m_FightItem.Add(0);
		}
		for (int l = 0; l < 4; l++)
		{
			List<int> list = new List<int>();
			for (int m = 0; m < 10; m++)
			{
				list.Add(0);
			}
			this.m_FightSkill.Add(l + 1, list);
		}
	}

	public void ClearFormation()
	{
		for (int i = 0; i < 4; i++)
		{
			S_FormationData data = GameDataDB.FormationDB.GetData(i + 1);
			if (data != null)
			{
				this.m_FormationDataList[i].LeaderID = 0;
				this.m_FormationDataList[i].Enable = false;
				if (i == 0)
				{
					this.m_FormationDataList[i].Enable = true;
				}
				for (int j = 0; j < this.m_FormationDataList[i].Unit.Count; j++)
				{
					this.m_FormationDataList[i].Unit[j].IsLeader = false;
					this.m_FormationDataList[i].Unit[j].IsController = false;
					this.m_FormationDataList[i].Unit[j].IsMob = false;
					this.m_FormationDataList[i].Unit[j].RoleID = 0;
					if (j < data.emAI.Count)
					{
						this.m_FormationDataList[i].Unit[j].emAI = data.emAI[j];
					}
					else
					{
						this.m_FormationDataList[i].Unit[j].emAI = ENUM_FormationAI.Attack;
					}
					if (j == 0)
					{
						this.m_FormationDataList[i].Unit[j].IsLeader = true;
						this.m_FormationDataList[i].Unit[j].IsController = true;
					}
				}
			}
		}
		this.DefaultFormation = 0;
	}

	public void ClearFightItem()
	{
		this.m_FightItem.Clear();
	}

	public void ClearFightSkill()
	{
		for (int i = 0; i < 4; i++)
		{
			this.m_FightSkill[i + 1].Clear();
		}
	}

	public void UnlockFormation(int index)
	{
		this.m_FormationDataList[index - 1].Enable = true;
	}

	public void ShowFormationData()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.m_FormationDataList[i].Enable)
			{
				for (int j = 0; j < this.m_FormationDataList[i].Unit.Count; j++)
				{
					Debug.Log(i + "_Formation_" + this.m_FormationDataList[i].Unit[j].RoleID);
				}
			}
		}
	}

	public void AutoSetUnitData()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.m_FormationDataList[i].Enable)
			{
                for (int j = 0; j < GameEntry.Instance.m_GameDataSystem.GetNumberRoleFromParty(); j++)
                {
                    int partyRoleID = GameEntry.Instance.m_GameDataSystem.GetPartyRoleID(j);
                    if (!this.CheckUnit(i, partyRoleID))
                    {
                        this.AutoSetUnit(i, partyRoleID);
                    }
                }
            }
		}
	}

	public void AutoClearUnitData(int roleId)
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.m_FormationDataList[i].Enable)
			{
				for (int j = 0; j < this.m_FormationDataList[i].Unit.Count; j++)
				{
					if (this.m_FormationDataList[i].Unit[j].RoleID == roleId)
					{
						this.m_FormationDataList[i].Unit[j].RoleID = 0;
						break;
					}
				}
			}
		}
	}

	public bool CheckUnit(int index, int roleId)
	{
		if (!this.m_FormationDataList[index].Enable)
		{
			return false;
		}
		for (int i = 0; i < this.m_FormationDataList[index].Unit.Count; i++)
		{
			if (this.m_FormationDataList[index].Unit[i].RoleID == roleId)
			{
				return true;
			}
		}
		return false;
	}

	public void AutoSetUnit(int index, int roleId)
	{
		if (!this.m_FormationDataList[index].Enable)
		{
			return;
		}
		for (int i = 0; i < this.m_FormationDataList[index].Unit.Count; i++)
		{
			if (this.m_FormationDataList[index].Unit[i].RoleID == 0)
			{
				this.m_FormationDataList[index].Unit[i].RoleID = roleId;
				break;
			}
		}
	}

	public void SetUnitRoleID(int formationIndex, int unitIndex, int roleId)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("SetUnitRoleID::formationIndex超出範圍!!_" + formationIndex);
			return;
		}
		if (unitIndex < 0 || unitIndex >= this.m_FormationDataList[formationIndex].Unit.Count)
		{
			Debug.LogWarning("SetUnitRoleID::unitIndex超出範圍!!_" + unitIndex);
			return;
		}
		this.m_FormationDataList[formationIndex].Unit[unitIndex].RoleID = roleId;
		if (this.m_FormationDataList[formationIndex].Unit[unitIndex].IsMob)
		{
			this.m_FormationDataList[formationIndex].MobID = roleId;
		}
	}

	public void SetLeaderUnit(int formationIndex, int unitIndex)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("SetLeaderUnit::formationIndex超出範圍!!_" + formationIndex);
			return;
		}
		if (unitIndex < 0 || unitIndex >= this.m_FormationDataList[formationIndex].Unit.Count)
		{
			Debug.LogWarning("SetLeaderUnit::unitIndex超出範圍!!_" + unitIndex);
			return;
		}
		for (int i = 0; i < this.m_FormationDataList[this.m_DefaultFormation].Unit.Count; i++)
		{
			this.m_FormationDataList[formationIndex].Unit[i].IsLeader = false;
		}
		this.m_FormationDataList[formationIndex].LeaderID = this.m_FormationDataList[formationIndex].Unit[unitIndex].RoleID;
		this.m_FormationDataList[formationIndex].Unit[unitIndex].IsLeader = true;
	}

	public void SetControllerUnit(int formationIndex, int unitIndex)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("SetControllerUnit::formationIndex超出範圍!!_" + formationIndex);
			return;
		}
		if (unitIndex < 0 || unitIndex >= this.m_FormationDataList[formationIndex].Unit.Count)
		{
			Debug.LogWarning("SetControllerUnit::unitIndex超出範圍!!_" + unitIndex);
			return;
		}
		for (int i = 0; i < this.m_FormationDataList[this.m_DefaultFormation].Unit.Count; i++)
		{
			this.m_FormationDataList[formationIndex].Unit[i].IsController = false;
		}
		this.m_FormationDataList[formationIndex].ControllerID = this.m_FormationDataList[formationIndex].Unit[unitIndex].RoleID;
		this.m_FormationDataList[formationIndex].Unit[unitIndex].IsController = true;
	}

	public void SetUnitAI(int formationIndex, int unitIndex, ENUM_FormationAI ai)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("SetUnitAI::formationIndex超出範圍!!_" + formationIndex);
			return;
		}
		if (unitIndex < 0 || unitIndex >= this.m_FormationDataList[formationIndex].Unit.Count)
		{
			Debug.LogWarning("SetUnitAI::unitIndex超出範圍!!_" + unitIndex);
			return;
		}
		this.m_FormationDataList[formationIndex].Unit[unitIndex].emAI = ai;
	}

	public void EnableFormation(int formationIndex, bool enable)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("EnableFormation::formationIndex超出範圍!!_" + formationIndex);
			return;
		}
		this.m_FormationDataList[formationIndex].Enable = enable;
	}

	public FormationUnit GetUnitonData(int formationIndex, int unitIndex)
	{
		if (formationIndex < 0 || formationIndex >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("GetUnitonData::formationIndex超出範圍!!_" + formationIndex);
			return null;
		}
		if (unitIndex < 0 || unitIndex >= this.m_FormationDataList[formationIndex].Unit.Count)
		{
			Debug.LogWarning("GetUnitonData::unitIndex超出範圍!!_" + unitIndex);
			return null;
		}
		return this.m_FormationDataList[formationIndex].Unit[unitIndex];
	}

	public FormationData GetFormationData(int index)
	{
		if (index < 0 || index >= this.m_FormationDataList.Count)
		{
			Debug.LogWarning("GetFormationData::formationIndex超出範圍!!_" + index);
			return null;
		}
		return this.m_FormationDataList[index];
	}

	public FormationData GetDefaultFormationData()
	{
		return this.m_FormationDataList[this.DefaultFormation];
	}

	public void SetFightItem(int index, int ItemId)
	{
		if (index < 0 || index >= this.m_FightItem.Count)
		{
			Debug.LogWarning("SetFightItem::index超出範圍!!_" + index);
			return;
		}
		this.m_FightItem[index] = ItemId;
	}

	public List<int> GetFightItemData()
	{
		return this.m_FightItem;
	}

	public void SetFightSkill(int roleId, int index, int skillId)
	{
		if (!this.m_FightSkill.ContainsKey(roleId))
		{
			Debug.LogWarning("SetFightSkill::roleId超出範圍!!_" + roleId);
			return;
		}
		List<int> list = this.m_FightSkill[roleId];
		if (index < 0 || index >= list.Count)
		{
			Debug.LogWarning("SetFightSkill::index超出範圍!!_" + index);
			return;
		}
		this.m_FightSkill[roleId][index] = skillId;
	}

	public List<int> GetFightSkillData(int roleId)
	{
		if (!this.m_FightSkill.ContainsKey(roleId))
		{
			Debug.LogWarning("GetFightSkillData::roleId超出範圍!!_" + roleId);
			return null;
		}
		return this.m_FightSkill[roleId];
	}

	public void Save(GameFileStream stream)
	{
		stream.WriteInt(this.m_FormationDataList.Count);
		stream.WriteInt(this.m_FormationDataList[0].Unit.Count);
		stream.WriteInt(this.DefaultFormation);
		for (int i = 0; i < this.m_FormationDataList.Count; i++)
		{
			FormationData formationData = this.m_FormationDataList[i];
			stream.WriteInt(formationData.LeaderID);
			stream.WriteInt(formationData.ControllerID);
			stream.WriteInt(formationData.MobID);
			stream.WriteBool(formationData.Enable);
			for (int j = 0; j < formationData.Unit.Count; j++)
			{
				FormationUnit formationUnit = formationData.Unit[j];
				stream.WriteInt(formationUnit.RoleID);
				stream.WriteBool(formationUnit.IsLeader);
				stream.WriteBool(formationUnit.IsController);
				stream.WriteInt((int)formationUnit.emAI);
			}
		}
	}

	public void Load(GameFileStream stream)
	{
		if (stream.IsEnd())
		{
			return;
		}
		int num = stream.ReadInt();
		int num2 = stream.ReadInt();
		float num3 = float.Parse("0.05");
		//if (GameEntry.Instance.m_SaveloadSystem.m_Version >= num3)
		//{
		//	this.DefaultFormation = stream.ReadInt();
		//}
		for (int i = 0; i < num; i++)
		{
			FormationData formationData = this.GetFormationData(i);
			formationData.LeaderID = stream.ReadInt();
			formationData.ControllerID = stream.ReadInt();
			formationData.MobID = stream.ReadInt();
			formationData.Enable = stream.ReadBool();
			for (int j = 0; j < num2; j++)
			{
				FormationUnit unitonData = this.GetUnitonData(i, j);
				unitonData.RoleID = stream.ReadInt();
				unitonData.IsLeader = stream.ReadBool();
				unitonData.IsController = stream.ReadBool();
				unitonData.emAI = (ENUM_FormationAI)stream.ReadInt();
			}
		}
	}
}
