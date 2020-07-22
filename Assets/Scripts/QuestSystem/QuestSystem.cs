using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

/// <summary>
/// 任务系统
/// </summary>
public class QuestSystem
{
    private static QuestSystem _instance;

    private bool m_Dirty;

    private Dictionary<int, QuestRecord> m_QuestRecord = new Dictionary<int, QuestRecord>();

    private Dictionary<int, List<int>> m_GiveQuestList = new Dictionary<int, List<int>>();

    private Dictionary<int, List<int>> m_RunQuestList = new Dictionary<int, List<int>>();

    private Dictionary<int, List<int>> m_ReportQuestList = new Dictionary<int, List<int>>();

    private Dictionary<int, List<int>>[] m_QuestGroupList;

    private Dictionary<int, S_FinishMob> m_WantMob = new Dictionary<int, S_FinishMob>();

    public static QuestSystem Instance
    {
        get
        {
            return QuestSystem._instance;
        }
    }

    public void Initialize()
    {
        this.m_QuestGroupList = new Dictionary<int, List<int>>[32];
        for (int i = 0; i < 32; i++)
        {
            this.m_QuestGroupList[i] = new Dictionary<int, List<int>>();
        }
        //this.InitQuestData();
    }

    //private void InitQuestData()
    //{
    //    GameDataDB.QuestDB.ResetByOrder();
    //    int dataSize = GameDataDB.QuestDB.GetDataSize();
    //    for (int i = 0; i < dataSize; i++)
    //    {
    //        S_Quest dataByOrder = GameDataDB.QuestDB.GetDataByOrder();
    //        if (dataByOrder != null)
    //        {
    //            this.AddQuestData(this.m_GiveQuestList, dataByOrder.GiveNpc, dataByOrder.GUID);
    //            this.AddQuestData(this.m_RunQuestList, dataByOrder.RunNpc, dataByOrder.GUID);
    //            this.AddQuestData(this.m_ReportQuestList, dataByOrder.ReportNpc, dataByOrder.GUID);
    //            this.AddQuestGroupData(dataByOrder);
    //        }
    //    }
    //}

    //	private void AddQuestGroupData(S_Quest quest)
    //	{
    //		if (this.m_QuestGroupList[quest.Chapter].ContainsKey(quest.Group))
    //		{
    //			List<int> list = this.m_QuestGroupList[quest.Chapter][quest.Group];
    //			list.Add(quest.GUID);
    //		}
    //		else
    //		{
    //			List<int> list2 = new List<int>();
    //			list2.Add(quest.GUID);
    //			this.m_QuestGroupList[quest.Chapter].Add(quest.Group, list2);
    //		}
    //	}

    //	public Dictionary<int, List<int>> GetQuestGroupData(int chapter)
    //	{
    //		return this.m_QuestGroupList[chapter];
    //	}

    public void Clear()
    {
        this.m_QuestRecord.Clear();
    }

    //	public QuestRecord GetQuestRecord(int id)
    //	{
    //		if (this.m_QuestRecord.ContainsKey(id))
    //		{
    //			return this.m_QuestRecord[id];
    //		}
    //		return null;
    //	}

    //	public void ClearQuestRecord(int id)
    //	{
    //		if (this.m_QuestRecord.ContainsKey(id))
    //		{
    //			this.m_QuestRecord.Remove(id);
    //		}
    //	}

    //	public void AddQuestRecord(QuestRecord questData)
    //	{
    //		if (this.m_QuestRecord.ContainsKey(questData.ID))
    //		{
    //			this.m_QuestRecord[questData.ID] = questData;
    //		}
    //		else
    //		{
    //			this.m_QuestRecord.Add(questData.ID, questData);
    //		}
    //	}

    //	private void AddQuestData(Dictionary<int, List<int>> QuestList, int id, int questId)
    //	{
    //		if (QuestList.ContainsKey(id))
    //		{
    //			QuestList[id].Add(questId);
    //		}
    //		else
    //		{
    //			QuestList.Add(id, new List<int>
    //			{
    //				questId
    //			});
    //		}
    //	}

    //	public List<int> GetGiveQuestData(int NpcID)
    //	{
    //		if (this.m_GiveQuestList.ContainsKey(NpcID))
    //		{
    //			return this.m_GiveQuestList[NpcID];
    //		}
    //		return null;
    //	}

    //	public List<int> GetReportQuestData(int NpcID)
    //	{
    //		if (this.m_ReportQuestList.ContainsKey(NpcID))
    //		{
    //			return this.m_ReportQuestList[NpcID];
    //		}
    //		return null;
    //	}

    //	public List<int> GetRunQuestData(int NpcID)
    //	{
    //		if (this.m_RunQuestList.ContainsKey(NpcID))
    //		{
    //			return this.m_RunQuestList[NpcID];
    //		}
    //		return null;
    //	}

    public void Dirty()
    {
        if (GameEntry.Instance.m_ExploreSystem.PlayerObj == null)
        {
            return;
        }
        this.m_Dirty = true;
    }

    //	public void Update()
    //	{
    //		if (this.m_Dirty)
    //		{
    //			this.RefreshQuestHint();
    //		}
    //	}

    //	public void RefreshQuestHint()
    //	{
    //		if (!this.gameApplication.m_ExploreSystem.LockPlayer)
    //		{
    //			this.RefreshAllQuestState();
    //			List<S_GameObjData> mapObjData = this.gameApplication.m_GameObjSystem.GetMapObjData();
    //			foreach (S_GameObjData current in mapObjData)
    //			{
    //				if (!current.State.Test(ENUM_GameObjFlag.Disable))
    //				{
    //					if (!(current.GameObj == null))
    //					{
    //						this.UpdateWantMobQuestState();
    //						M_GameRoleBase component = current.GameObj.GetComponent<M_GameRoleBase>();
    //						if (component)
    //						{
    //							component.CheckQuestState();
    //						}
    //					}
    //				}
    //			}
    //			this.m_Dirty = false;
    //		}
    //	}

    //	public int CheckNpctGiveState(int npcId, ref bool canGiveQuest)
    //	{
    //		List<int> giveQuestData = this.GetGiveQuestData(npcId);
    //		if (giveQuestData == null)
    //		{
    //			return 0;
    //		}
    //		int count = giveQuestData.Count;
    //		if (count == 0)
    //		{
    //			return 0;
    //		}
    //		int result = 0;
    //		for (int i = 0; i < count; i++)
    //		{
    //			S_Quest data = GameDataDB.QuestDB.GetData(giveQuestData[i]);
    //			if (data != null)
    //			{
    //				QuestRecord questRecord = this.GetQuestRecord(data.GUID);
    //				if (questRecord != null && questRecord.State != ENUM_QuestState.Active)
    //				{
    //					result = data.GUID;
    //				}
    //				else if (npcId == data.GiveNpc)
    //				{
    //					if (this.CheckGiveQuestMatch(data))
    //					{
    //						canGiveQuest = true;
    //						return data.GUID;
    //					}
    //					if (questRecord != null && questRecord.State == ENUM_QuestState.Active)
    //					{
    //						this.ClearQuestRecord(data.GUID);
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	public int CheckNpctRunState(int npcId)
    //	{
    //		List<int> runQuestData = this.GetRunQuestData(npcId);
    //		if (runQuestData == null)
    //		{
    //			return 0;
    //		}
    //		int count = runQuestData.Count;
    //		if (count == 0)
    //		{
    //			return 0;
    //		}
    //		int result = 0;
    //		for (int i = 0; i < count; i++)
    //		{
    //			S_Quest data = GameDataDB.QuestDB.GetData(runQuestData[i]);
    //			if (data != null)
    //			{
    //				QuestRecord questRecord = this.GetQuestRecord(data.GUID);
    //				if (questRecord != null)
    //				{
    //					if (questRecord.State == ENUM_QuestState.Normal || questRecord.State == ENUM_QuestState.Report)
    //					{
    //						if (npcId == data.RunNpc)
    //						{
    //							if (!this.CheckReportQuestMatch(data))
    //							{
    //								return data.GUID;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	public int CheckNpctFinishState(int npcId, ref bool canReportQuest)
    //	{
    //		List<int> reportQuestData = this.GetReportQuestData(npcId);
    //		if (reportQuestData == null)
    //		{
    //			return 0;
    //		}
    //		int count = reportQuestData.Count;
    //		if (count == 0)
    //		{
    //			return 0;
    //		}
    //		int result = 0;
    //		for (int i = 0; i < count; i++)
    //		{
    //			S_Quest data = GameDataDB.QuestDB.GetData(reportQuestData[i]);
    //			if (data != null)
    //			{
    //				QuestRecord questRecord = this.GetQuestRecord(data.GUID);
    //				if (questRecord != null)
    //				{
    //					if (questRecord.State == ENUM_QuestState.Report || questRecord.State == ENUM_QuestState.Normal)
    //					{
    //						result = data.GUID;
    //						if (npcId == data.ReportNpc)
    //						{
    //							if (this.CheckReportQuestMatch(data))
    //							{
    //								canReportQuest = true;
    //								return data.GUID;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	public bool CheckGiveQuestMatch(S_Quest quest)
    //	{
    //		if (quest.PlayTimes > 0 && Swd6Application.instance.m_GameDataSystem.m_PlayGameCount < quest.PlayTimes)
    //		{
    //			return false;
    //		}
    //		for (int i = 0; i < quest.PreFlag.Count; i++)
    //		{
    //			if (quest.PreFlag[i].Flag > 0)
    //			{
    //				bool flag = Swd6Application.instance.m_GameDataSystem.GetFlag(quest.PreFlag[i].Flag);
    //				if (quest.PreFlag[i].FlagON == 0)
    //				{
    //					if (flag)
    //					{
    //						return false;
    //					}
    //				}
    //				else if (!flag)
    //				{
    //					return false;
    //				}
    //			}
    //		}
    //		if (quest.PreQuest > 0)
    //		{
    //			QuestRecord questRecord = this.GetQuestRecord(quest.PreQuest);
    //			if (questRecord == null)
    //			{
    //				return false;
    //			}
    //			if (questRecord.State != ENUM_QuestState.Finish)
    //			{
    //				return false;
    //			}
    //		}
    //		for (int j = 0; j < quest.PreItem.Count; j++)
    //		{
    //			if (quest.PreItem[j].ID > 0 && !Swd6Application.instance.m_ItemSystem.CheckItemBag(quest.PreItem[j].ID, quest.PreItem[j].Count))
    //			{
    //				return false;
    //			}
    //		}
    //		return quest.PrePartner <= 0 || Swd6Application.instance.m_GameDataSystem.CheckPartyRole(quest.PrePartner);
    //	}

    //	public bool CheckReportQuestMatch(S_Quest quest)
    //	{
    //		for (int i = 0; i < quest.FinishItem.Count; i++)
    //		{
    //			if (quest.FinishItem[i].ID > 0 && !Swd6Application.instance.m_ItemSystem.CheckItemBag(quest.FinishItem[i].ID, quest.FinishItem[i].Count))
    //			{
    //				return false;
    //			}
    //		}
    //		for (int j = 0; j < quest.ReportFlag.Count; j++)
    //		{
    //			if (quest.ReportFlag[j].Flag > 0)
    //			{
    //				bool flag = Swd6Application.instance.m_GameDataSystem.GetFlag(quest.ReportFlag[j].Flag);
    //				if (quest.ReportFlag[j].FlagON == 0)
    //				{
    //					if (flag)
    //					{
    //						return false;
    //					}
    //				}
    //				else if (!flag)
    //				{
    //					return false;
    //				}
    //			}
    //		}
    //		for (int k = 0; k < quest.FinishMob.Count; k++)
    //		{
    //			if (quest.FinishMob[k].ID > 0)
    //			{
    //				QuestRecord questRecord = this.GetQuestRecord(quest.GUID);
    //				if (!questRecord.FinishMob.ContainsKey(quest.FinishMob[k].ID))
    //				{
    //					return false;
    //				}
    //				S_FinishMob s_FinishMob = questRecord.FinishMob[quest.FinishMob[k].ID];
    //				if (s_FinishMob.Count < quest.FinishMob[k].Count)
    //				{
    //					return false;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public void GiveItemFromAddQuest(int id)
    //	{
    //		S_Quest data = GameDataDB.QuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < data.GiveItem.Count; i++)
    //		{
    //			if (data.GiveItem[i].ID > 0)
    //			{
    //				Swd6Application.instance.m_ItemSystem.AddItem(data.GiveItem[i].ID, data.GiveItem[i].Count, ENUM_ItemState.New, false);
    //				S_Item data2 = GameDataDB.ItemDB.GetData(data.GiveItem[i].ID);
    //				if (data2 != null)
    //				{
    //					string msg = GameDataDB.StrID(1000) + data2.Name + data.GiveItem[i].Count.ToString() + GameDataDB.StrID(1006);
    //					UI_Message.Instance.AddSysMsg(msg, 3f);
    //				}
    //			}
    //		}
    //	}

    //	public void ActiveQuestRecord(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord != null)
    //		{
    //			questRecord.State = ENUM_QuestState.Active;
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				Debug.Log("可接取任務_" + id);
    //			}
    //			return;
    //		}
    //		this.AddQuestRecord(new QuestRecord
    //		{
    //			ID = id,
    //			State = ENUM_QuestState.Active
    //		});
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("可接取任務_" + id);
    //		}
    //	}

    //	public void AddQuestRecord(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord == null)
    //		{
    //			questRecord = new QuestRecord();
    //			questRecord.ID = id;
    //		}
    //		questRecord.State = ENUM_QuestState.Normal;
    //		this.GiveItemFromAddQuest(id);
    //		this.AddQuestRecord(questRecord);
    //		this.Dirty();
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("已接取任務_" + id);
    //		}
    //	}

    //	public void ReportQuestRecord(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord != null)
    //		{
    //			questRecord.State = ENUM_QuestState.Report;
    //		}
    //		this.Dirty();
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("可回報任務_" + id);
    //		}
    //	}

    //	public void FinishQuestRecord(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord == null)
    //		{
    //			this.AddQuestRecord(id);
    //			questRecord = this.GetQuestRecord(id);
    //		}
    //		S_Quest data = GameDataDB.QuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			Debug.Log("FinishQuestRecord_取得任務樣板錯誤_" + id);
    //			return;
    //		}
    //		if (data.FailFlag > 0 && this.gameApplication.m_GameDataSystem.GetFlag(data.FailFlag))
    //		{
    //			questRecord.State = ENUM_QuestState.Fail;
    //			this.Dirty();
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				Debug.Log("任務失敗_" + id);
    //			}
    //			return;
    //		}
    //		if (questRecord.State == ENUM_QuestState.Finish)
    //		{
    //			return;
    //		}
    //		questRecord.State = ENUM_QuestState.Finish;
    //		if (data.FinishFlag > 0)
    //		{
    //			this.gameApplication.m_GameDataSystem.FlagON(data.FinishFlag);
    //		}
    //		string msg = string.Empty;
    //		for (int i = 0; i < data.FinishItem.Count; i++)
    //		{
    //			if (data.FinishItem[i].ID > 0)
    //			{
    //				Swd6Application.instance.m_ItemSystem.DeleteItemByItemID(data.FinishItem[i].ID, data.FinishItem[i].Count, true);
    //				S_Item data2 = GameDataDB.ItemDB.GetData(data.FinishItem[i].ID);
    //				msg = GameDataDB.StrID(1001) + data.FinishItem[i].Count.ToString() + GameDataDB.StrID(1006) + data2.Name;
    //				UI_Message.Instance.AddSysMsg(msg, 3f);
    //			}
    //		}
    //		if (data.RewardMoney > 0)
    //		{
    //			msg = GameDataDB.StrID(1000) + data.RewardMoney + GameDataDB.StrID(1005);
    //			UI_Message.Instance.AddSysMsg(msg, 3f);
    //			Swd6Application.instance.m_GameDataSystem.Money += data.RewardMoney;
    //		}
    //		if (data.RewardExp > 0)
    //		{
    //			msg = GameDataDB.StrID(2017) + data.RewardExp;
    //			UI_Message.Instance.AddSysMsg(msg, 3f);
    //			Swd6Application.instance.m_GameDataSystem.AddPartyExp(data.RewardExp);
    //		}
    //		for (int j = 0; j < data.RewardItem.Count; j++)
    //		{
    //			if (data.RewardItem[j].ID > 0)
    //			{
    //				Swd6Application.instance.m_ItemSystem.AddItem(data.RewardItem[j].ID, data.RewardItem[j].Count, ENUM_ItemState.New, false);
    //				S_Item data3 = GameDataDB.ItemDB.GetData(data.RewardItem[j].ID);
    //				if (data3 != null)
    //				{
    //					msg = GameDataDB.StrID(1000) + data3.Name + data.RewardItem[j].Count.ToString() + GameDataDB.StrID(1006);
    //					UI_Message.Instance.AddSysMsg(msg, 3f);
    //				}
    //			}
    //		}
    //		if (data.RewardAchievement > 0)
    //		{
    //			Swd6Application.instance.m_AchievementSystem.FinishAchievement(data.RewardAchievement);
    //		}
    //		if (data.RewardSkill > 0)
    //		{
    //			S_Skill data4 = GameDataDB.SkillDB.GetData(data.RewardSkill);
    //			if (data4 != null)
    //			{
    //				Swd6Application.instance.m_SkillSystem.LearnSkill(data4.LearnRole, data.RewardSkill);
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(data4.LearnRole);
    //				msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1002) + data4.Name;
    //				UI_Message.Instance.AddSysMsg(msg, 3f);
    //			}
    //		}
    //		if (data.RewardSystem > 0)
    //		{
    //		}
    //		this.Dirty();
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("已完成任務_" + id);
    //		}
    //	}

    //	public void RefreshAllQuestState()
    //	{
    //		GameDataDB.QuestDB.ResetByOrder();
    //		int dataSize = GameDataDB.QuestDB.GetDataSize();
    //		for (int i = 0; i < dataSize; i++)
    //		{
    //			S_Quest dataByOrder = GameDataDB.QuestDB.GetDataByOrder();
    //			if (dataByOrder != null)
    //			{
    //				this.RefreshQuestState(dataByOrder.GUID);
    //			}
    //		}
    //	}

    //	public void RefreshQuestState(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord != null && (questRecord.State == ENUM_QuestState.Finish || questRecord.State == ENUM_QuestState.Fail))
    //		{
    //			return;
    //		}
    //		S_Quest data = GameDataDB.QuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			Debug.Log("RefreshQuestState取得任務樣板錯誤_" + id);
    //			return;
    //		}
    //		int giveNpc = data.GiveNpc;
    //		bool flag = false;
    //		bool flag2 = false;
    //		S_GameObjData objData = this.gameApplication.m_GameObjSystem.GetObjData(giveNpc);
    //		if (objData == null)
    //		{
    //			return;
    //		}
    //		int num = Swd6Application.instance.m_QuestSystem.CheckNpctFinishState(giveNpc, ref flag2);
    //		if (num > 0 && flag2)
    //		{
    //			objData.QuestState = ENUM_QuestState.Report;
    //			Swd6Application.instance.m_QuestSystem.ReportQuestRecord(num);
    //			return;
    //		}
    //		if (questRecord != null && questRecord.State == ENUM_QuestState.Normal)
    //		{
    //			return;
    //		}
    //		num = Swd6Application.instance.m_QuestSystem.CheckNpctRunState(giveNpc);
    //		if (num > 0)
    //		{
    //			objData.QuestState = ENUM_QuestState.Normal;
    //			return;
    //		}
    //		num = Swd6Application.instance.m_QuestSystem.CheckNpctGiveState(giveNpc, ref flag);
    //		if (num > 0 && flag)
    //		{
    //			this.ActiveQuestRecord(num);
    //			objData.QuestState = ENUM_QuestState.Active;
    //			return;
    //		}
    //	}

    //	public void FailQuestRecord(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord == null)
    //		{
    //			this.AddQuestRecord(id);
    //			questRecord = this.GetQuestRecord(id);
    //		}
    //		S_Quest data = GameDataDB.QuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			Debug.Log("FailQuestRecord_取得任務樣板錯誤_" + id);
    //			return;
    //		}
    //		if (data.FailFlag > 0)
    //		{
    //			this.gameApplication.m_GameDataSystem.FlagON(data.FailFlag);
    //		}
    //		questRecord.State = ENUM_QuestState.Fail;
    //		this.Dirty();
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("失敗任務_" + id);
    //		}
    //	}

    //	public ENUM_QuestState GetQuestState(int id)
    //	{
    //		QuestRecord questRecord = this.GetQuestRecord(id);
    //		if (questRecord == null)
    //		{
    //			return ENUM_QuestState.Null;
    //		}
    //		return questRecord.State;
    //	}

    //	public void ClearFinishQuestState(int id)
    //	{
    //		if (this.GetQuestRecord(id) == null)
    //		{
    //			Debug.Log("ClearFinishQuestFlag == null" + id);
    //			return;
    //		}
    //		S_Quest data = GameDataDB.QuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			Debug.Log("ClearFinishQuestFlag 取得任務樣板錯誤_" + id);
    //			return;
    //		}
    //		if (data.FinishFlag > 0)
    //		{
    //			this.gameApplication.m_GameDataSystem.FlagOFF(data.FinishFlag);
    //		}
    //		this.ClearQuestRecord(id);
    //	}

    //	public void SetGiveQuestState(int questId)
    //	{
    //		int playGameCount = Swd6Application.instance.m_GameDataSystem.m_PlayGameCount;
    //		S_Quest data = GameDataDB.QuestDB.GetData(questId);
    //		if (data == null)
    //		{
    //			Debug.Log("SetGiveQuestState 取得任務樣板錯誤_" + questId);
    //			return;
    //		}
    //		this.ActiveQuestRecord(questId);
    //		if (data.PlayTimes > 0)
    //		{
    //			Swd6Application.instance.m_GameDataSystem.m_PlayGameCount = data.PlayTimes;
    //		}
    //		for (int i = 0; i < data.PreFlag.Count; i++)
    //		{
    //			if (data.PreFlag[i].Flag > 0)
    //			{
    //				if (data.PreFlag[i].FlagON > 0)
    //				{
    //					Swd6Application.instance.m_GameDataSystem.FlagON(data.PreFlag[i].Flag);
    //				}
    //				else
    //				{
    //					Swd6Application.instance.m_GameDataSystem.FlagOFF(data.PreFlag[i].Flag);
    //				}
    //			}
    //		}
    //		if (data.PreQuest > 0)
    //		{
    //			if (this.GetQuestRecord(data.PreQuest) == null)
    //			{
    //				this.AddQuestRecord(questId);
    //			}
    //			this.FinishQuestRecord(questId);
    //		}
    //		for (int j = 0; j < data.PreItem.Count; j++)
    //		{
    //			if (data.PreItem[j].ID > 0)
    //			{
    //				Swd6Application.instance.m_ItemSystem.AddItem(data.PreItem[j].ID, data.PreItem[j].Count, ENUM_ItemState.New, false);
    //			}
    //		}
    //		if (data.PrePartner > 0)
    //		{
    //			Swd6Application.instance.m_GameDataSystem.CheckRoleToAddParty(data.PrePartner);
    //		}
    //		this.Dirty();
    //	}

    //	public void SetReportQuestState(int questId)
    //	{
    //		S_Quest data = GameDataDB.QuestDB.GetData(questId);
    //		if (data == null)
    //		{
    //			Debug.Log("SetReportQuestState 取得任務樣板錯誤_" + questId);
    //			return;
    //		}
    //		this.ReportQuestRecord(questId);
    //		for (int i = 0; i < data.FinishItem.Count; i++)
    //		{
    //			if (data.FinishItem[i].ID > 0)
    //			{
    //				Swd6Application.instance.m_ItemSystem.AddItem(data.FinishItem[i].ID, data.FinishItem[i].Count, ENUM_ItemState.New, false);
    //			}
    //		}
    //		for (int j = 0; j < data.ReportFlag.Count; j++)
    //		{
    //			if (data.ReportFlag[j].Flag > 0)
    //			{
    //				if (data.ReportFlag[j].FlagON > 0)
    //				{
    //					Swd6Application.instance.m_GameDataSystem.FlagON(data.ReportFlag[j].Flag);
    //				}
    //				else
    //				{
    //					Swd6Application.instance.m_GameDataSystem.FlagOFF(data.ReportFlag[j].Flag);
    //				}
    //			}
    //		}
    //		this.Dirty();
    //	}

    //	public void Save(GameFileStream stream)
    //	{
    //		int count = this.m_QuestRecord.Count;
    //		stream.WriteInt(count);
    //		foreach (QuestRecord current in this.m_QuestRecord.Values)
    //		{
    //			stream.WriteInt(current.ID);
    //			stream.WriteInt((int)current.State);
    //		}
    //	}

    //	public void Load(GameFileStream stream)
    //	{
    //		this.Clear();
    //		int num = stream.ReadInt();
    //		for (int i = 0; i < num; i++)
    //		{
    //			this.AddQuestRecord(new QuestRecord
    //			{
    //				ID = stream.ReadInt(),
    //				State = (ENUM_QuestState)stream.ReadInt()
    //			});
    //		}
    //	}

    //	public void DebugLog()
    //	{
    //		int count = this.m_QuestRecord.Count;
    //		foreach (QuestRecord current in this.m_QuestRecord.Values)
    //		{
    //			Debug.Log(string.Concat(new object[]
    //			{
    //				"Quest_",
    //				current.ID,
    //				"_",
    //				current.State
    //			}));
    //		}
    //	}

    //	public string GetMainQuest()
    //	{
    //		string result = string.Empty;
    //		GameDataDB.MainQuestDB.ResetByOrder();
    //		int dataSize = GameDataDB.MainQuestDB.GetDataSize();
    //		for (int i = 0; i < dataSize; i++)
    //		{
    //			S_MainQuest dataByOrder = GameDataDB.MainQuestDB.GetDataByOrder();
    //			if (dataByOrder != null)
    //			{
    //				if (Swd6Application.instance.m_GameDataSystem.GetFlag(dataByOrder.GUID))
    //				{
    //					if (!Swd6Application.instance.m_GameDataSystem.GetFlag(dataByOrder.GUID + 500))
    //					{
    //						result = dataByOrder.Name;
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	public void AddWantMobList(List<S_FinishMob> wantMob)
    //	{
    //		this.m_WantMob.Clear();
    //		for (int i = 0; i < wantMob.Count; i++)
    //		{
    //			this.m_WantMob.Add(wantMob[i].ID, wantMob[i]);
    //		}
    //		this.m_Dirty = true;
    //	}

    //	public void UpdateWantMobQuestState()
    //	{
    //		if (this.m_WantMob.Count == 0)
    //		{
    //			return;
    //		}
    //		foreach (List<int> current in this.m_RunQuestList.Values)
    //		{
    //			for (int i = 0; i < current.Count; i++)
    //			{
    //				S_Quest data = GameDataDB.QuestDB.GetData(current[i]);
    //				if (data != null)
    //				{
    //					QuestRecord questRecord = this.GetQuestRecord(data.GUID);
    //					if (questRecord != null)
    //					{
    //						if (questRecord.State == ENUM_QuestState.Normal)
    //						{
    //							for (int j = 0; j < data.FinishMob.Count; j++)
    //							{
    //								int iD = data.FinishMob[j].ID;
    //								if (this.m_WantMob.ContainsKey(iD))
    //								{
    //									S_FinishMob s_FinishMob = this.m_WantMob[iD];
    //									if (questRecord.FinishMob.ContainsKey(iD))
    //									{
    //										questRecord.FinishMob[iD].Count += s_FinishMob.Count;
    //									}
    //									else
    //									{
    //										S_FinishMob s_FinishMob2 = new S_FinishMob();
    //										s_FinishMob2.ID = s_FinishMob.ID;
    //										s_FinishMob2.Count = s_FinishMob.Count;
    //										questRecord.FinishMob.Add(iD, s_FinishMob2);
    //									}
    //									if (questRecord.FinishMob[iD].Count > data.FinishMob[j].Count)
    //									{
    //										questRecord.FinishMob[iD].Count = data.FinishMob[j].Count;
    //									}
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		this.m_WantMob.Clear();
    //	}
}
