using System;
using System.Collections.Generic;

public class IdentifySystem
{
	private Dictionary<int, IdentifyData> m_IdentifyData;

	private Dictionary<int, IdentifyData>.Enumerator m_Iter;

	private Dictionary<ENUM_MobRace, List<int>> m_MobList;

	private Dictionary<ENUM_ItemSubType, List<int>> m_EquipList;

	private int[] m_MItemLevelExp = new int[]
	{
		7600,
		19633,
		34833,
		53833,
		77266,
		105766,
		139333,
		177966,
		223566,
		276133,
		338833,
		411666,
		494633,
		587733,
		690966,
		804333,
		931633,
		1072866,
		1228033,
		1228033
	};

	public void Initialize()
	{
		this.m_IdentifyData = new Dictionary<int, IdentifyData>();
		this.m_IdentifyData.Clear();
		this.m_MobList = new Dictionary<ENUM_MobRace, List<int>>();
		this.m_EquipList = new Dictionary<ENUM_ItemSubType, List<int>>();
		this.InitMobListData();
		this.InitEquipListData();
	}

	private void InitEquipListData()
	{
		GameDataDB.ItemDB.ResetByOrder();
		int dataSize = GameDataDB.ItemDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_Item dataByOrder = GameDataDB.ItemDB.GetDataByOrder();
			if (dataByOrder != null && dataByOrder.emSubItemType >= ENUM_ItemSubType.Weapon && dataByOrder.emSubItemType <= ENUM_ItemSubType.Accessories)
			{
				if (this.m_EquipList.ContainsKey(dataByOrder.emSubItemType))
				{
					this.m_EquipList[dataByOrder.emSubItemType].Add(dataByOrder.GUID);
				}
				else
				{
					List<int> list = new List<int>();
					list.Add(dataByOrder.GUID);
					this.m_EquipList.Add(dataByOrder.emSubItemType, list);
				}
			}
		}
	}

	private void InitMobListData()
	{
		GameDataDB.ItemDB.ResetByOrder();
		int dataSize = GameDataDB.ItemDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_Item dataByOrder = GameDataDB.ItemDB.GetDataByOrder();
			if (dataByOrder != null)
			{
				if (this.m_MobList.ContainsKey(dataByOrder.MobData.emRace))
				{
					this.m_MobList[dataByOrder.MobData.emRace].Add(dataByOrder.GUID);
				}
				else
				{
					List<int> list = new List<int>();
					list.Add(dataByOrder.GUID);
					this.m_MobList.Add(dataByOrder.MobData.emRace, list);
				}
			}
		}
	}

	public bool AddIdentify(int id, ENUM_IdentifyType type, float percent, int exp)
	{
		return this.AddIdentify(new IdentifyData
		{
			ID = id,
			Type = type,
			Percent = percent,
			Exp = exp
		});
	}

	public void AddMobIdentify(int id, ENUM_MobIdentifyType type)
	{
		S_Item data = GameDataDB.ItemDB.GetData(id);
		float num = 0f;
		float num2 = 0f;
		if (type == ENUM_MobIdentifyType.Encount)
		{
			num2 = 25f;
			if (data.MobData.emRace == ENUM_MobRace.AlienMan)
			{
				num2 = 100f;
			}
		}
		if (type == ENUM_MobIdentifyType.Catch)
		{
			num2 = 50f;
		}
		if (type == ENUM_MobIdentifyType.Refine)
		{
			num = 50f;
		}
		if (data.MobData.emType == ENUM_MobType.Boss)
		{
			num = 0f;
			num2 = 100f;
		}
		if (id == 2106 || id == 2101)
		{
			num2 = 100f;
		}
		IdentifyData identifyData = this.GetData(id);
		if (identifyData == null)
		{
			identifyData = new IdentifyData();
			identifyData.ID = id;
			identifyData.Type = ENUM_IdentifyType.Mob;
			identifyData.New = true;
			if (num > identifyData.MobPercent)
			{
				identifyData.MobPercent = num;
			}
			if (num2 > identifyData.Percent)
			{
				identifyData.Percent = num2;
			}
			this.m_IdentifyData.Add(id, identifyData);
		}
		else
		{
			if (num > identifyData.MobPercent)
			{
				identifyData.MobPercent = num;
			}
			if (num2 > identifyData.Percent)
			{
				identifyData.Percent = num2;
			}
		}
	}

	public bool AddIdentify(IdentifyData data)
	{
		S_Item data2 = GameDataDB.ItemDB.GetData(data.ID);
		bool result = false;
		int num = 100;
		IdentifyData data3 = this.GetData(data.ID);
		if (data3 == null)
		{
			data.Level = 1;
			if (data.Percent > (float)num)
			{
				data.Percent = (float)num;
			}
			data.New = true;
			this.m_IdentifyData.Add(data.ID, data);
		}
		else
		{
			data3.Percent += data.Percent;
			if (data3.Percent > (float)num)
			{
				data3.Percent = (float)num;
			}
			if (data3.Level < data2.MItem.MaxLevel)
			{
				data3.Exp += data.Exp;
				if (data3.Exp >= this.m_MItemLevelExp[data3.Level - 1])
				{
					data3.Level++;
					//Swd6Application.instance.m_GameDataSystem.ReLoadObjData();
					if (data3.Level >= data2.MItem.MaxLevel)
					{
						data3.Level = data2.MItem.MaxLevel;
						data3.Exp = this.m_MItemLevelExp[data3.Level - 1];
					}
					result = true;
				}
			}
		}
		return result;
	}

	public void AddAllIdentifyByType(ENUM_IdentifyType type)
	{
		ENUM_ItemType eNUM_ItemType = ENUM_ItemType.Null;
		if (type == ENUM_IdentifyType.Equipment)
		{
			eNUM_ItemType = ENUM_ItemType.Equip;
		}
		if (type == ENUM_IdentifyType.Talisman)
		{
			eNUM_ItemType = ENUM_ItemType.MagicItem;
		}
		if (type == ENUM_IdentifyType.Mob)
		{
			eNUM_ItemType = ENUM_ItemType.Mob;
		}
		GameDataDB.ItemDB.ResetByOrder();
		int dataSize = GameDataDB.ItemDB.GetDataSize();
		for (int i = 0; i < dataSize; i++)
		{
			S_Item dataByOrder = GameDataDB.ItemDB.GetDataByOrder();
			if (dataByOrder != null && eNUM_ItemType == dataByOrder.emItemType)
			{
				if (type != ENUM_IdentifyType.Equipment || (dataByOrder.emSubItemType >= ENUM_ItemSubType.Weapon && dataByOrder.emSubItemType <= ENUM_ItemSubType.Accessories))
				{
					float percent = 100f;
					if (type == ENUM_IdentifyType.Mob)
					{
						if (dataByOrder.MobData.emRace != ENUM_MobRace.AlienMan)
						{
							percent = 50f;
							this.AddMobIdentify(dataByOrder.GUID, ENUM_MobIdentifyType.Refine);
						}
					}
					else if (type == ENUM_IdentifyType.Talisman)
					{
						this.SetMItemMaxLevel(dataByOrder.GUID);
					}
					this.AddIdentify(dataByOrder.GUID, type, percent, 0);
				}
			}
		}
	}

	public void SetMItemMaxLevel(int id)
	{
		IdentifyData data = this.GetData(id);
		if (data == null)
		{
			this.AddIdentify(id, ENUM_IdentifyType.Talisman, 100f, 0);
			data = this.GetData(id);
		}
		S_Item data2 = GameDataDB.ItemDB.GetData(id);
		data.Level = data2.MItem.MaxLevel;
	}

	public void Clear()
	{
		this.m_IdentifyData.Clear();
	}

	public void ClearData(int id)
	{
		if (this.m_IdentifyData.ContainsKey(id))
		{
			this.m_IdentifyData.Remove(id);
		}
	}

	public void ClearData(ENUM_IdentifyType type)
	{
		bool flag;
		do
		{
			flag = false;
			int totalCount = this.GetTotalCount();
			this.ResetByOrder();
			for (int i = 0; i < totalCount; i++)
			{
				IdentifyData dataByOrder = this.GetDataByOrder();
				if (dataByOrder.Type == type)
				{
					this.ClearData(dataByOrder.ID);
					flag = true;
					break;
				}
			}
		}
		while (flag);
	}

	public IdentifyData GetData(int id)
	{
		if (this.m_IdentifyData.ContainsKey(id))
		{
			return this.m_IdentifyData[id];
		}
		return null;
	}

	public int GetTotalCount()
	{
		return this.m_IdentifyData.Count;
	}

	public int GetLevelExp(int level)
	{
		if (level < 1 || level > 20)
		{
			return 0;
		}
		return this.m_MItemLevelExp[level - 1];
	}

	public int GetMItemEffect(int id)
	{
		if (!this.m_IdentifyData.ContainsKey(id))
		{
			return 0;
		}
		S_Item data = GameDataDB.ItemDB.GetData(id);
		if (data == null)
		{
			return 0;
		}
		return (int)data.MItem.AttrEffect[this.m_IdentifyData[id].Level - 1];
	}

	public int GetDataCount(ENUM_IdentifyType type, ENUM_MobRace mobRace, ENUM_ItemSubType itemSubType)
	{
		int num = 0;
		int totalCount = this.GetTotalCount();
		this.ResetByOrder();
		for (int i = 0; i < totalCount; i++)
		{
			IdentifyData dataByOrder = this.GetDataByOrder(type, mobRace, itemSubType);
			if (dataByOrder != null)
			{
				num++;
			}
		}
		return num;
	}

	public void ResetByOrder()
	{
		this.m_Iter = this.m_IdentifyData.GetEnumerator();
	}

	public IdentifyData GetDataByOrder()
	{
		if (!this.m_Iter.MoveNext())
		{
			return null;
		}
		KeyValuePair<int, IdentifyData> current = this.m_Iter.Current;
		return current.Value;
	}

	public IdentifyData GetDataByOrder(ENUM_IdentifyType type, ENUM_MobRace mobRace, ENUM_ItemSubType itemSubType)
	{
		while (this.m_Iter.MoveNext())
		{
			if (type == ENUM_IdentifyType.Mob)
			{
				KeyValuePair<int, IdentifyData> current = this.m_Iter.Current;
				if (current.Value.Type == type)
				{
					T_GameDB<S_Item> arg_53_0 = GameDataDB.ItemDB;
					KeyValuePair<int, IdentifyData> current2 = this.m_Iter.Current;
					S_Item data = arg_53_0.GetData(current2.Value.ID);
					if (data != null && data.MobData.emRace == mobRace)
					{
						KeyValuePair<int, IdentifyData> current3 = this.m_Iter.Current;
						return current3.Value;
					}
				}
			}
			else if (type == ENUM_IdentifyType.Equipment)
			{
				KeyValuePair<int, IdentifyData> current4 = this.m_Iter.Current;
				if (current4.Value.Type == type)
				{
					T_GameDB<S_Item> arg_CD_0 = GameDataDB.ItemDB;
					KeyValuePair<int, IdentifyData> current5 = this.m_Iter.Current;
					S_Item data = arg_CD_0.GetData(current5.Value.ID);
					if (data != null && data.emSubItemType == itemSubType)
					{
						KeyValuePair<int, IdentifyData> current6 = this.m_Iter.Current;
						return current6.Value;
					}
				}
			}
			else if (type == ENUM_IdentifyType.Item)
			{
				KeyValuePair<int, IdentifyData> current7 = this.m_Iter.Current;
				if (current7.Value.Type == type)
				{
					T_GameDB<S_Item> arg_143_0 = GameDataDB.ItemDB;
					KeyValuePair<int, IdentifyData> current8 = this.m_Iter.Current;
					S_Item data = arg_143_0.GetData(current8.Value.ID);
					if (data != null && data.emSubItemType == itemSubType)
					{
						KeyValuePair<int, IdentifyData> current9 = this.m_Iter.Current;
						return current9.Value;
					}
				}
			}
			else if (type == ENUM_IdentifyType.Talisman)
			{
			}
		}
		return null;
	}

	public List<int> GetMobList(ENUM_MobRace race)
	{
		if (this.m_MobList.ContainsKey(race))
		{
			return this.m_MobList[race];
		}
		return null;
	}

	public List<int> GetEquipList(ENUM_ItemSubType type)
	{
		if (this.m_EquipList.ContainsKey(type))
		{
			return this.m_EquipList[type];
		}
		return null;
	}

	public int GetNewMobCount(ENUM_MobRace race)
	{
		int num = 0;
		List<int> mobList = this.GetMobList(race);
		for (int i = 0; i < mobList.Count; i++)
		{
			//IdentifyData data = Swd6Application.instance.m_IdentifySystem.GetData(mobList[i]);
			//if (data != null)
			//{
			//	S_Item data2 = GameDataDB.ItemDB.GetData(data.ID);
			//	if (data2.MobData.CanShow != 0)
			//	{
			//		if (data.New)
			//		{
			//			num++;
			//		}
			//	}
			//}
		}
		return num;
	}

	public int GetNewEquipCount(ENUM_ItemSubType type)
	{
		int num = 0;
		List<int> equipList = this.GetEquipList(type);
		for (int i = 0; i < equipList.Count; i++)
		{
			//IdentifyData data = Swd6Application.instance.m_IdentifySystem.GetData(equipList[i]);
			//if (data != null)
			//{
			//	S_Item data2 = GameDataDB.ItemDB.GetData(data.ID);
			//	if (Swd6Application.instance.CheckDLC())
			//	{
			//		if (data2.EquipShowVer == 0)
			//		{
			//			goto IL_8A;
			//		}
			//	}
			//	else if (data2.EquipShowVer != 1)
			//	{
			//		goto IL_8A;
			//	}
			//	if (data.New)
			//	{
			//		num++;
			//	}
			//}
			//IL_8A:;
		}
		return num;
	}

	public bool CheckFinishMobIdentify()
	{
		List<int> list = new List<int>();
		for (int i = 1; i <= 10; i++)
		{
			list = this.GetMobList((ENUM_MobRace)i);
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					IdentifyData data = this.GetData(list[j]);
					if (data == null)
					{
						return false;
					}
					if (data.Percent + data.MobPercent < 100f)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public int GetEquipItemTotalCount(int version)
	{
		int num = 0;
		foreach (KeyValuePair<ENUM_ItemSubType, List<int>> current in this.m_EquipList)
		{
			for (int i = 0; i < current.Value.Count; i++)
			{
				S_Item data = GameDataDB.ItemDB.GetData(current.Value[i]);
				if (data != null)
				{
					//if (data.EquipShowVer != 0)
					//{
					//	if (Swd6Application.instance.CheckDLC())
					//	{
					//		if (version > 0 && data.EquipShowVer != version)
					//		{
					//			goto IL_98;
					//		}
					//	}
					//	else if (data.EquipShowVer != 1)
					//	{
					//		goto IL_98;
					//	}
					//	num++;
					//}
				}
				IL_98:;
			}
		}
		return num;
	}

	public int GetEquipItemRecordCount(int version)
	{
		int num = 0;
		foreach (KeyValuePair<ENUM_ItemSubType, List<int>> current in this.m_EquipList)
		{
			for (int i = 0; i < current.Value.Count; i++)
			{
				IdentifyData data = this.GetData(current.Value[i]);
				if (data != null)
				{
					S_Item data2 = GameDataDB.ItemDB.GetData(data.ID);
					if (data2 != null)
					{
						//if (data2.EquipShowVer != 0)
						//{
						//	if (Swd6Application.instance.CheckDLC())
						//	{
						//		if (version > 0 && data2.EquipShowVer != version)
						//		{
						//			goto IL_AC;
						//		}
						//	}
						//	else if (data2.EquipShowVer != 1)
						//	{
						//		goto IL_AC;
						//	}
						//	num++;
						//}
					}
				}
				IL_AC:;
			}
		}
		return num;
	}

	public int GetNormalItemTotalCount()
	{
		GameDataDB.ItemDB.ResetByOrder();
		int dataSize = GameDataDB.ItemDB.GetDataSize();
		int num = 0;
		for (int i = 0; i < dataSize; i++)
		{
			S_Item dataByOrder = GameDataDB.ItemDB.GetDataByOrder();
			if (dataByOrder != null && dataByOrder.emItemType != ENUM_ItemType.Mob)
			{
				if (dataByOrder.emSubItemType < ENUM_ItemSubType.CosCloth)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetNormalItemRecordCount()
	{
		int num = 0;
		this.ResetByOrder();
		for (int i = 0; i < this.GetTotalCount(); i++)
		{
			IdentifyData dataByOrder = this.GetDataByOrder();
			if (dataByOrder != null && dataByOrder.Type != ENUM_IdentifyType.Mob)
			{
				S_Item data = GameDataDB.ItemDB.GetData(dataByOrder.ID);
				if (data.emSubItemType < ENUM_ItemSubType.CosCloth)
				{
					num++;
				}
			}
		}
		return num;
	}

	public void Sort()
	{
		List<KeyValuePair<int, IdentifyData>> list = new List<KeyValuePair<int, IdentifyData>>(this.m_IdentifyData);
		list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByID));
		this.m_IdentifyData.Clear();
		foreach (KeyValuePair<int, IdentifyData> current in list)
		{
			this.m_IdentifyData.Add(current.Key, current.Value);
		}
	}

	private static int ComparByID(KeyValuePair<int, IdentifyData> item1, KeyValuePair<int, IdentifyData> item2)
	{
		if (item1.Value.ID > item2.Value.ID)
		{
			return 1;
		}
		if (item1.Value.ID < item2.Value.ID)
		{
			return -1;
		}
		return 0;
	}

	public void Save(GameFileStream stream)
	{
		int totalCount = this.GetTotalCount();
		stream.WriteInt(totalCount);
		this.ResetByOrder();
		for (int i = 0; i < totalCount; i++)
		{
			IdentifyData dataByOrder = this.GetDataByOrder();
			stream.WriteObjData(dataByOrder);
		}
	}

	public void Load(GameFileStream stream)
	{
		int num = stream.ReadInt();
		this.Clear();
		for (int i = 0; i < num; i++)
		{
			IdentifyData identifyData = new IdentifyData();
			object obj = identifyData;
			stream.ReadObjData(out obj);
			identifyData = (obj as IdentifyData);
			S_Item data = GameDataDB.ItemDB.GetData(identifyData.ID);
			if (data != null)
			{
				if (data.MobData.emRace == ENUM_MobRace.AlienMan && data.MobData.emType != ENUM_MobType.Boss && identifyData.Percent > 0f && identifyData.Percent < 100f)
				{
					identifyData.Percent = 100f;
					identifyData.MobPercent = 0f;
				}
				if ((identifyData.ID == 2106 || identifyData.ID == 2101) && identifyData.Percent > 0f && identifyData.Percent < 100f)
				{
					identifyData.Percent = 100f;
					identifyData.MobPercent = 0f;
				}
			}
			this.m_IdentifyData.Add(identifyData.ID, identifyData);
		}
	}

	public void SortBy(ENUM_IdentifySortType SortType)
	{
		List<KeyValuePair<int, IdentifyData>> list = new List<KeyValuePair<int, IdentifyData>>(this.m_IdentifyData);
		switch (SortType)
		{
		case ENUM_IdentifySortType.ID:
			list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByID));
			break;
		case ENUM_IdentifySortType.Level:
			list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByLevel));
			break;
		case ENUM_IdentifySortType.Race:
			list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByRace));
			break;
		case ENUM_IdentifySortType.Attack:
			list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByAttack));
			break;
		case ENUM_IdentifySortType.Defense:
			list.Sort(new Comparison<KeyValuePair<int, IdentifyData>>(IdentifySystem.ComparByDefense));
			break;
		}
		this.m_IdentifyData.Clear();
		foreach (KeyValuePair<int, IdentifyData> current in list)
		{
			this.m_IdentifyData.Add(current.Key, current.Value);
		}
	}

	private static int ComparByLevel(KeyValuePair<int, IdentifyData> item1, KeyValuePair<int, IdentifyData> item2)
	{
		S_Item data = GameDataDB.ItemDB.GetData(item1.Value.ID);
		if (data == null)
		{
			return 0;
		}
		S_Item data2 = GameDataDB.ItemDB.GetData(item2.Value.ID);
		if (data2 == null)
		{
			return 0;
		}
		if (data.MobData.Level < data2.MobData.Level)
		{
			return 1;
		}
		if (data.MobData.Level > data2.MobData.Level)
		{
			return -1;
		}
		return 0;
	}

	private static int ComparByRace(KeyValuePair<int, IdentifyData> item1, KeyValuePair<int, IdentifyData> item2)
	{
		S_Item data = GameDataDB.ItemDB.GetData(item1.Value.ID);
		if (data == null)
		{
			return 0;
		}
		S_Item data2 = GameDataDB.ItemDB.GetData(item2.Value.ID);
		if (data2 == null)
		{
			return 0;
		}
		int num;
		switch (data.MobData.emRace)
		{
		case ENUM_MobRace.God:
			num = 10;
			break;
		case ENUM_MobRace.Deamon:
			num = 9;
			break;
		case ENUM_MobRace.HolyBeast:
			num = 6;
			break;
		case ENUM_MobRace.EvilBeast:
			num = 5;
			break;
		case ENUM_MobRace.HolySpirit:
			num = 7;
			break;
		case ENUM_MobRace.EvilSpirit:
			num = 3;
			break;
		case ENUM_MobRace.Spirit:
			num = 4;
			break;
		case ENUM_MobRace.Monster:
			num = 8;
			break;
		case ENUM_MobRace.Zombie:
			num = 2;
			break;
		case ENUM_MobRace.AlienMan:
			num = 1;
			break;
		default:
			num = 0;
			break;
		}
		int num2;
		switch (data2.MobData.emRace)
		{
		case ENUM_MobRace.God:
			num2 = 10;
			break;
		case ENUM_MobRace.Deamon:
			num2 = 9;
			break;
		case ENUM_MobRace.HolyBeast:
			num2 = 6;
			break;
		case ENUM_MobRace.EvilBeast:
			num2 = 5;
			break;
		case ENUM_MobRace.HolySpirit:
			num2 = 7;
			break;
		case ENUM_MobRace.EvilSpirit:
			num2 = 3;
			break;
		case ENUM_MobRace.Spirit:
			num2 = 4;
			break;
		case ENUM_MobRace.Monster:
			num2 = 8;
			break;
		case ENUM_MobRace.Zombie:
			num2 = 2;
			break;
		case ENUM_MobRace.AlienMan:
			num2 = 1;
			break;
		default:
			num2 = 0;
			break;
		}
		if (num < num2)
		{
			return 1;
		}
		if (num > num2)
		{
			return -1;
		}
		return 0;
	}

	private static int ComparByAttack(KeyValuePair<int, IdentifyData> item1, KeyValuePair<int, IdentifyData> item2)
	{
		S_Item data = GameDataDB.ItemDB.GetData(item1.Value.ID);
		if (data == null)
		{
			return 0;
		}
		S_Item data2 = GameDataDB.ItemDB.GetData(item2.Value.ID);
		if (data2 == null)
		{
			return 0;
		}
		if (data.MobData.Attack < data2.MobData.Attack)
		{
			return 1;
		}
		if (data.MobData.Attack > data2.MobData.Attack)
		{
			return -1;
		}
		return 0;
	}

	private static int ComparByDefense(KeyValuePair<int, IdentifyData> item1, KeyValuePair<int, IdentifyData> item2)
	{
		S_Item data = GameDataDB.ItemDB.GetData(item1.Value.ID);
		if (data == null)
		{
			return 0;
		}
		S_Item data2 = GameDataDB.ItemDB.GetData(item2.Value.ID);
		if (data2 == null)
		{
			return 0;
		}
		if (data.MobData.Def < data2.MobData.Def)
		{
			return 1;
		}
		if (data.MobData.Def > data2.MobData.Def)
		{
			return -1;
		}
		return 0;
	}
}
