using System;
using System.Collections.Generic;
using YouYou;

public class MobGuardSystem
{
	private static MobGuardSystem _instance;

	private List<S_MobGuard> m_MobGuard;

	private Dictionary<int, MobGuardListInfo> m_MobGuardListData;

	private List<MobGuardListInfo> m_MobGuardList;

	public static MobGuardSystem Instance
	{
		get
		{
			return MobGuardSystem._instance;
		}
	}

	public void Initialize()
	{
		this.m_MobGuard = new List<S_MobGuard>();
		for (int i = 0; i < 6; i++)
		{
			S_MobGuard item = new S_MobGuard();
			this.m_MobGuard.Add(item);
		}
		this.m_MobGuardList = new List<MobGuardListInfo>();
		this.m_MobGuardListData = new Dictionary<int, MobGuardListInfo>();
	}

	public void Clear()
	{
		for (int i = 0; i < 6; i++)
		{
			this.ClearDataByIndex(i, true);
		}
	}

	public S_MobGuard GetData(int index)
	{
		if (index >= 6)
		{
			return null;
		}
		return this.m_MobGuard[index];
	}

	public void ClearDataByIndex(int index, bool clearAll)
	{
		this.m_MobGuard[index].ID = 0;
		if (clearAll)
		{
			for (int i = 0; i < 5; i++)
			{
				this.m_MobGuard[index].AI[i] = 0;
			}
		}
	}

	public void ClearDataByID(int ID)
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.m_MobGuard[i].ID == ID)
			{
				for (int j = 0; j < 5; j++)
				{
					this.m_MobGuard[i].AI[j] = 0;
				}
				break;
			}
		}
	}

	public void SetMobGuardID(int index, int ID)
	{
		if (index >= 6)
		{
			return;
		}
		this.m_MobGuard[index].ID = ID;
	}

	public void SetMobGuardAI(int index, int aiIndex, int ID)
	{
		if (index >= 6)
		{
			return;
		}
		this.m_MobGuard[index].AI[aiIndex] = ID;
	}

	public void SetMobGuardData(int index, S_MobGuard data)
	{
		if (index >= 6)
		{
			return;
		}
		this.m_MobGuard[index] = data;
	}

	public int GetID(int index)
	{
		if (index >= 6)
		{
			return 0;
		}
		return this.m_MobGuard[index].ID;
	}

	public int GetAI(int index, int aiIndex)
	{
		if (index >= 6)
		{
			return 0;
		}
		if (aiIndex >= 5)
		{
			return 0;
		}
		return this.m_MobGuard[index].AI[aiIndex];
	}

	public bool CheckID(int id)
	{
		for (int i = 0; i < 6; i++)
		{
			if (id == this.m_MobGuard[i].ID)
			{
				return true;
			}
		}
		return false;
	}

	public List<S_MobGuard> GetMobGuardData()
	{
		return this.m_MobGuard;
	}

	public void AutoSetFightMobGuard()
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.m_MobGuard[i].ID > 0)
			{
				S_Item data = GameDataDB.ItemDB.GetData(this.m_MobGuard[i].ID);
			}
		}
	}

	public void InitMobGuardList()
	{
		this.m_MobGuardList.Clear();
		this.m_MobGuardListData.Clear();
		int totalCount = GameEntry.Instance.m_IdentifySystem.GetTotalCount();
        GameEntry.Instance.m_IdentifySystem.ResetByOrder();
		for (int i = 0; i < totalCount; i++)
		{
			IdentifyData dataByOrder = GameEntry.Instance.m_IdentifySystem.GetDataByOrder();
			if (dataByOrder != null)
			{
				if (dataByOrder.Type == ENUM_IdentifyType.Mob)
				{
					if (dataByOrder.Percent + dataByOrder.MobPercent >= 50f)
					{
						S_Item data = GameDataDB.ItemDB.GetData(dataByOrder.ID);
						if (data != null)
						{
							MobGuardListInfo mobGuardListInfo = new MobGuardListInfo();
							mobGuardListInfo.ID = dataByOrder.ID;
							mobGuardListInfo.Match = (int)(dataByOrder.Percent + dataByOrder.MobPercent);
							mobGuardListInfo.Level = data.MobData.Level;
							mobGuardListInfo.Attack = data.MobData.Attack;
							mobGuardListInfo.Def = data.MobData.Def;
							this.m_MobGuardList.Add(mobGuardListInfo);
							this.m_MobGuardListData.Add(dataByOrder.ID, mobGuardListInfo);
						}
					}
				}
			}
		}
	}

	public int GetTotalListCount()
	{
		return this.m_MobGuardList.Count;
	}

	public MobGuardListInfo GetListData(int index)
	{
		if (index >= this.m_MobGuardList.Count)
		{
			return null;
		}
		return this.m_MobGuardList[index];
	}

	public MobGuardListInfo GetListDataByID(int id)
	{
		if (this.m_MobGuardListData.ContainsKey(id))
		{
			return this.m_MobGuardListData[id];
		}
		return null;
	}

	public void Sort(MobGuardSortFields field, MobGuardSortOrder order)
	{
		this.m_MobGuardList.Sort(new MobGuardListInfoComparer(field, order));
	}

	public void Save(GameFileStream stream)
	{
		int count = this.m_MobGuard.Count;
		stream.WriteInt(count);
		for (int i = 0; i < count; i++)
		{
			S_MobGuard data = this.m_MobGuard[i];
			stream.WriteObjData(data);
		}
	}

	public void Load(GameFileStream stream)
	{
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			S_MobGuard s_MobGuard = new S_MobGuard();
			object obj = s_MobGuard;
			stream.ReadObjData(out obj);
			s_MobGuard = (obj as S_MobGuard);
			this.SetMobGuardData(i, s_MobGuard);
			if (GameEntry.Instance.m_IdentifySystem.GetData(s_MobGuard.ID) == null)
			{
				this.ClearDataByIndex(i, false);
			}
		}
	}
}
