using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class ItemSystem
{
    private static ItemSystem _instance;

    private Dictionary<int, ItemData> m_ItemData;

    private Dictionary<int, ItemData>.Enumerator m_Iter;

    public int m_SerialID;

    public static ItemSystem Instance
    {
        get
        {
            return ItemSystem._instance;
        }
    }

    public void Initialize()
    {
        this.m_ItemData = new Dictionary<int, ItemData>();
        this.m_ItemData.Clear();
    }

    public ItemData AddItem(int id, int count, ENUM_ItemState state, bool showMsg)
    {
        S_Item data = GameDataDB.ItemDB.GetData(id);
        ItemData itemData = new ItemData();
        itemData.Order = 0;
        itemData.ID = id;
        itemData.Count = count;
        itemData.GetTime = GameEntry.Instance.m_GameDataSystem.m_PlayTimes;
        itemData.New = true;
        if (state == ENUM_ItemState.Old)
        {
            itemData.New = false;
        }
        //itemData = this.AddItemByItemID(itemData);
        if (showMsg && data != null)
        {
            string msg = string.Concat(new object[]
            {
                GameDataDB.StrID(1000),
                count,
                GameDataDB.StrID(1006),
                data.Name
            });
            //UI_Explore.Instance.AddPopMsg(msg, id);
        }
        //if (data.emItemType == ENUM_ItemType.MagicItem)
        //{
        //    Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Talisman, 0f, 0);
        //}
        //else if (data.emItemType == ENUM_ItemType.Normal)
        //{
        //    Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Item, 100f, 0);
        //}
        //Swd6Application.instance.m_QuestSystem.Dirty();
        return itemData;
    }

    //	public void AddTreasureItem(int id, int count, ENUM_ItemState state, bool showMsg)
    //	{
    //		new ItemData();
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data.Equip.TreasureStone > 0)
    //		{
    //			this.AddRefineSoulItem(id, data.Equip.TreasureStone, state);
    //			if (showMsg)
    //			{
    //				data = GameDataDB.ItemDB.GetData(id);
    //				if (data != null)
    //				{
    //					string msg = string.Concat(new object[]
    //					{
    //						GameDataDB.StrID(1000),
    //						count,
    //						GameDataDB.StrID(1006),
    //						data.Name
    //					});
    //					UI_Explore.Instance.AddPopMsg(msg, id);
    //				}
    //			}
    //			Swd6Application.instance.m_QuestSystem.Dirty();
    //			return;
    //		}
    //		this.AddItem(id, count, state, showMsg);
    //	}

    //	public ItemData AddSmithingItem(int id, int count, ENUM_ItemState state)
    //	{
    //		ItemData itemData = new ItemData();
    //		itemData.SerialID = ++this.m_SerialID;
    //		itemData.ID = id;
    //		itemData.Count = count;
    //		itemData.GetTime = this.gameApplication.m_GameDataSystem.m_PlayTimes;
    //		itemData.New = true;
    //		itemData.Grade = ENUM_GradeType.Normal;
    //		if (state == ENUM_ItemState.Old)
    //		{
    //			itemData.New = false;
    //		}
    //		this.m_ItemData.Add(this.m_SerialID, itemData);
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data.emItemType == ENUM_ItemType.Equip)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Equipment, 100f, 0);
    //		}
    //		return itemData;
    //	}

    //	public void AddRefineSoulItem(int id, int soulCount, ENUM_ItemState state)
    //	{
    //		ItemData itemData = new ItemData();
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		itemData.MaxRefineSoul = soulCount;
    //		if (itemData.MaxRefineSoul > 0)
    //		{
    //			itemData.SerialID = ++this.m_SerialID;
    //			itemData.ID = id;
    //			itemData.Count = 1;
    //			itemData.GetTime = this.gameApplication.m_GameDataSystem.m_PlayTimes;
    //			itemData.New = true;
    //			itemData.Grade = ENUM_GradeType.None;
    //			if (state == ENUM_ItemState.Old)
    //			{
    //				itemData.New = false;
    //			}
    //			this.m_ItemData.Add(this.m_SerialID, itemData);
    //			if (data.emItemType == ENUM_ItemType.Equip)
    //			{
    //				Swd6Application.instance.m_IdentifySystem.AddIdentify(itemData.ID, ENUM_IdentifyType.Equipment, 100f, 0);
    //			}
    //		}
    //	}

    //	public ItemData CloneRefineSoulItem(int id, int count, int maxSoul, int[] soudId, ENUM_ItemState state)
    //	{
    //		ItemData itemData = new ItemData();
    //		itemData.SerialID = ++this.m_SerialID;
    //		itemData.ID = id;
    //		itemData.Count = count;
    //		itemData.GetTime = this.gameApplication.m_GameDataSystem.m_PlayTimes;
    //		itemData.New = true;
    //		itemData.Grade = ENUM_GradeType.None;
    //		itemData.MaxRefineSoul = maxSoul;
    //		itemData.RefineSoul = soudId;
    //		if (state == ENUM_ItemState.Old)
    //		{
    //			itemData.New = false;
    //		}
    //		this.m_ItemData.Add(this.m_SerialID, itemData);
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data.emItemType == ENUM_ItemType.Equip)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Equipment, 100f, 0);
    //		}
    //		return itemData;
    //	}

    //	public ItemData CloneSmithItem(int id, int count, ItemData cloneItemData, ENUM_ItemState state)
    //	{
    //		ItemData itemData = new ItemData();
    //		itemData.SerialID = ++this.m_SerialID;
    //		itemData.ID = id;
    //		itemData.Count = count;
    //		itemData.GetTime = this.gameApplication.m_GameDataSystem.m_PlayTimes;
    //		itemData.New = true;
    //		itemData.Grade = cloneItemData.Grade;
    //		itemData.GradeNumber = cloneItemData.GradeNumber;
    //		itemData.MaxRefineSoul = cloneItemData.MaxRefineSoul;
    //		itemData.RefineSoul = cloneItemData.RefineSoul;
    //		if (state == ENUM_ItemState.Old)
    //		{
    //			itemData.New = false;
    //		}
    //		this.m_ItemData.Add(this.m_SerialID, itemData);
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data.emItemType == ENUM_ItemType.Equip)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Equipment, 100f, 0);
    //		}
    //		return itemData;
    //	}

    //	public ItemData AddItemByItemID(ItemData data)
    //	{
    //		S_Item data2 = GameDataDB.ItemDB.GetData(data.ID);
    //		if (data2 == null)
    //		{
    //			return null;
    //		}
    //		ItemData itemData = this.GetDataByItemID(data.ID);
    //		if (itemData == null)
    //		{
    //			do
    //			{
    //				data.SerialID = ++this.m_SerialID;
    //			}
    //			while (this.GetDataBySerialID(this.m_SerialID) != null);
    //			if (data.Count > data2.MaxHeap)
    //			{
    //				data.Count = data2.MaxHeap;
    //			}
    //			this.m_ItemData.Add(data.SerialID, data);
    //			itemData = this.m_ItemData[data.SerialID];
    //		}
    //		else
    //		{
    //			itemData.New = data.New;
    //			itemData.GetTime = data.GetTime;
    //			itemData.Count += data.Count;
    //			if (itemData.Count > data2.MaxHeap)
    //			{
    //				itemData.Count = data2.MaxHeap;
    //			}
    //		}
    //		if (data2.emItemType == ENUM_ItemType.Equip)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddIdentify(data.ID, ENUM_IdentifyType.Equipment, 100f, 0);
    //		}
    //		return itemData;
    //	}

    //	public void AddItem(int serialID, ItemData itemData)
    //	{
    //		this.m_ItemData.Add(serialID, itemData);
    //	}

    //	public bool DeleteItem(int id, int count, bool isDelNewItem)
    //	{
    //		if (this.m_ItemData.ContainsKey(id))
    //		{
    //			if (this.m_ItemData[id].Count > 0)
    //			{
    //				if (count > this.m_ItemData[id].Count)
    //				{
    //					Debug.LogWarning(id + "_DeleteCount > CurrentCount!!");
    //					return false;
    //				}
    //				this.m_ItemData[id].Count -= count;
    //				Swd6Application.instance.m_QuestSystem.Dirty();
    //			}
    //			if (this.m_ItemData[id].Count == 0)
    //			{
    //				this.m_ItemData.Remove(id);
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool DeleteItemByItemID(int id, int count, bool isDelNewItem)
    //	{
    //		int itemTotalCount = this.GetItemTotalCount();
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder();
    //			if (dataByOrder != null && dataByOrder.ID == id && dataByOrder.Grade == ENUM_GradeType.None && dataByOrder.MaxRefineSoul == 0)
    //			{
    //				if (dataByOrder.Count > 0)
    //				{
    //					if (count > dataByOrder.Count)
    //					{
    //						Debug.LogWarning(id + "_DeleteCount > CurrentCount!!");
    //						return false;
    //					}
    //					dataByOrder.Count -= count;
    //				}
    //				Swd6Application.instance.m_QuestSystem.Dirty();
    //				if (dataByOrder.Count == 0)
    //				{
    //					this.m_ItemData.Remove(dataByOrder.SerialID);
    //					return true;
    //				}
    //			}
    //		}
    //		return false;
    //	}

    //	public bool RefineItemSoulData(int SerialID, int mobId)
    //	{
    //		if (!this.m_ItemData.ContainsKey(SerialID))
    //		{
    //			Debug.Log("RefineItemSoulData::找不到id_" + SerialID);
    //			return false;
    //		}
    //		ItemData itemData = this.m_ItemData[SerialID];
    //		for (int i = 0; i < itemData.MaxRefineSoul; i++)
    //		{
    //			if (itemData.RefineSoul[i] == 0)
    //			{
    //				itemData.RefineSoul[i] = mobId;
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public void ClearItemSoulData(int SerialID)
    //	{
    //		if (!this.m_ItemData.ContainsKey(SerialID))
    //		{
    //			Debug.Log("ClearItemSoulData::找不到id_" + SerialID);
    //			return;
    //		}
    //		ItemData itemData = this.m_ItemData[SerialID];
    //		for (int i = 0; i < itemData.MaxRefineSoul; i++)
    //		{
    //			itemData.RefineSoul[i] = 0;
    //		}
    //	}

    //	public void Clear()
    //	{
    //		this.m_ItemData.Clear();
    //	}

    //	public bool CheckItem(int id, int count)
    //	{
    //		ItemData dataByItemID = this.GetDataByItemID(id);
    //		return dataByItemID != null && dataByItemID.Count >= count;
    //	}

    //	public bool CheckItemBag(int id, int count)
    //	{
    //		ItemData dataByItemID = this.GetDataByItemID(id);
    //		return dataByItemID != null && dataByItemID.Count - dataByItemID.EquipCount >= count;
    //	}

    //	public bool CheckSmithItem(int id)
    //	{
    //		ItemData dataBySerialID = this.GetDataBySerialID(id);
    //		return dataBySerialID != null && (dataBySerialID.MaxRefineSoul > 0 || dataBySerialID.Grade != ENUM_GradeType.None);
    //	}

    //	public Dictionary<int, ItemData> GetItemList()
    //	{
    //		return this.m_ItemData;
    //	}

    //	public string GetItemName(int id)
    //	{
    //		ItemData dataBySerialID = this.GetDataBySerialID(id);
    //		if (dataBySerialID == null)
    //		{
    //			return null;
    //		}
    //		S_Item data = GameDataDB.ItemDB.GetData(dataBySerialID.ID);
    //		if (data == null)
    //		{
    //			return null;
    //		}
    //		string text = data.Name;
    //		if (dataBySerialID.Grade != ENUM_GradeType.None)
    //		{
    //			text = GameDataDB.StrID((int)(7400 + dataBySerialID.Grade)) + GameDataDB.StrID(7417) + text;
    //		}
    //		return text;
    //	}

    public ItemData GetDataBySerialID(int id)
    {
        if (this.m_ItemData.ContainsKey(id))
        {
            return this.m_ItemData[id];
        }
        return null;
    }

    //	public ItemData GetDataByItemID(int id)
    //	{
    //		int itemTotalCount = this.GetItemTotalCount();
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder();
    //			if (dataByOrder != null && dataByOrder.ID == id && dataByOrder.Grade == ENUM_GradeType.None && dataByOrder.MaxRefineSoul == 0)
    //			{
    //				return dataByOrder;
    //			}
    //		}
    //		return null;
    //	}

    //	public List<int> GetSmithItemListByItemID(int id)
    //	{
    //		List<int> list = new List<int>();
    //		int itemTotalCount = this.GetItemTotalCount();
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder();
    //			if (dataByOrder != null && dataByOrder.ID == id && (dataByOrder.Grade != ENUM_GradeType.None || dataByOrder.MaxRefineSoul > 0) && !dataByOrder.Equip)
    //			{
    //				list.Add(dataByOrder.SerialID);
    //			}
    //		}
    //		return list;
    //	}

    //	public int GetItemTotalCount()
    //	{
    //		return this.m_ItemData.Count;
    //	}

    //	public int GetTreasureItemCount(ENUM_ActionHint emType, bool all)
    //	{
    //		int num = 0;
    //		if (all)
    //		{
    //			GameDataDB.NpcDB.ResetByOrder();
    //			int dataSize = GameDataDB.NpcDB.GetDataSize();
    //			for (int i = 0; i < dataSize; i++)
    //			{
    //				S_NpcData dataByOrder = GameDataDB.NpcDB.GetDataByOrder();
    //				if (dataByOrder != null && dataByOrder.emType == ENUM_NpcType.Treasure)
    //				{
    //					num++;
    //				}
    //			}
    //		}
    //		else
    //		{
    //			GameDataDB.NpcDB.ResetByOrder();
    //			int dataSize2 = GameDataDB.NpcDB.GetDataSize();
    //			for (int j = 0; j < dataSize2; j++)
    //			{
    //				S_NpcData dataByOrder2 = GameDataDB.NpcDB.GetDataByOrder();
    //				if (dataByOrder2 != null && dataByOrder2.emType == ENUM_NpcType.Treasure)
    //				{
    //					if (emType == ENUM_ActionHint.Null)
    //					{
    //						if (dataByOrder2.Show == 0 && dataByOrder2.emActionHint == ENUM_ActionHint.Null)
    //						{
    //							num++;
    //						}
    //					}
    //					else if (dataByOrder2.emActionHint == emType)
    //					{
    //						num++;
    //					}
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetNewItemCount(ENUM_ItemType type, ENUM_ItemSubType subType)
    //	{
    //		int num = 0;
    //		int itemTotalCount = this.GetItemTotalCount();
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder(type, subType);
    //			if (dataByOrder != null && dataByOrder.New)
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetItemCount(int id)
    //	{
    //		ItemData dataByItemID = this.GetDataByItemID(id);
    //		if (dataByItemID != null)
    //		{
    //			return dataByItemID.Count;
    //		}
    //		return 0;
    //	}

    //	public int GetItemCount(ENUM_ItemType type, ENUM_ItemSubType subType)
    //	{
    //		int num = 0;
    //		int itemTotalCount = this.GetItemTotalCount();
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder(type, subType);
    //			if (dataByOrder != null)
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    //	public void ResetByOrder()
    //	{
    //		this.m_Iter = this.m_ItemData.GetEnumerator();
    //	}

    //	public ItemData GetDataByOrder()
    //	{
    //		if (!this.m_Iter.MoveNext())
    //		{
    //			return null;
    //		}
    //		KeyValuePair<int, ItemData> current = this.m_Iter.Current;
    //		return current.Value;
    //	}

    //	public ItemData GetDataByOrder(ENUM_ItemType type, ENUM_ItemSubType subType)
    //	{
    //		while (this.m_Iter.MoveNext())
    //		{
    //			if (type == ENUM_ItemType.Null && subType == ENUM_ItemSubType.Null)
    //			{
    //				KeyValuePair<int, ItemData> current = this.m_Iter.Current;
    //				if (current.Value.Count > 0)
    //				{
    //					KeyValuePair<int, ItemData> current2 = this.m_Iter.Current;
    //					return current2.Value;
    //				}
    //			}
    //			else
    //			{
    //				T_GameDB<S_Item> arg_61_0 = GameDataDB.ItemDB;
    //				KeyValuePair<int, ItemData> current3 = this.m_Iter.Current;
    //				S_Item data = arg_61_0.GetData(current3.Value.ID);
    //				if (data == null)
    //				{
    //					if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //					{
    //						object arg_9E_0 = "ItemID_";
    //						KeyValuePair<int, ItemData> current4 = this.m_Iter.Current;
    //						Debug.LogWarning(arg_9E_0 + current4.Value.ID + "Error");
    //					}
    //					return null;
    //				}
    //				if (subType == ENUM_ItemSubType.Null)
    //				{
    //					if (data.emItemType == type)
    //					{
    //						KeyValuePair<int, ItemData> current5 = this.m_Iter.Current;
    //						return current5.Value;
    //					}
    //				}
    //				else if (data.emSubItemType == subType)
    //				{
    //					KeyValuePair<int, ItemData> current6 = this.m_Iter.Current;
    //					return current6.Value;
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	public void ClearNewItemState(ENUM_ItemType selectType, ENUM_ItemSubType subType)
    //	{
    //		int itemCount = this.GetItemCount(selectType, subType);
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder(selectType, subType);
    //			if (dataByOrder != null)
    //			{
    //				dataByOrder.New = false;
    //				dataByOrder.GetTime = 0f;
    //			}
    //		}
    //	}

    //	public void SortByItemType(ENUM_ItemType selectType, ENUM_ItemSubType subType)
    //	{
    //		int itemCount = this.GetItemCount(selectType, subType);
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder(selectType, subType);
    //			if (dataByOrder != null)
    //			{
    //				dataByOrder.Order = 1;
    //			}
    //		}
    //		this.Sort();
    //		this.ResetByOrder();
    //		for (int j = 0; j < itemCount; j++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder(selectType, subType);
    //			if (dataByOrder != null)
    //			{
    //				dataByOrder.Order = 0;
    //			}
    //		}
    //	}

    //	public void ClearSort()
    //	{
    //		foreach (KeyValuePair<int, ItemData> current in this.m_ItemData)
    //		{
    //			current.Value.New = false;
    //			current.Value.GetTime = 0f;
    //		}
    //		this.Sort();
    //	}

    //	public void Sort()
    //	{
    //		List<KeyValuePair<int, ItemData>> list = new List<KeyValuePair<int, ItemData>>(this.m_ItemData);
    //		list.Sort(new Comparison<KeyValuePair<int, ItemData>>(ItemSystem.Compar));
    //		this.m_ItemData.Clear();
    //		foreach (KeyValuePair<int, ItemData> current in list)
    //		{
    //			this.m_ItemData.Add(current.Key, current.Value);
    //		}
    //	}

    //	private static int Compar(KeyValuePair<int, ItemData> item1, KeyValuePair<int, ItemData> item2)
    //	{
    //		if (item1.Value.Order > item2.Value.Order)
    //		{
    //			return -1;
    //		}
    //		if (item1.Value.Order < item2.Value.Order)
    //		{
    //			return 1;
    //		}
    //		if (item1.Value.GetTime > item2.Value.GetTime)
    //		{
    //			return -1;
    //		}
    //		if (item1.Value.GetTime < item2.Value.GetTime)
    //		{
    //			return 1;
    //		}
    //		if (item1.Value.ID > item2.Value.ID)
    //		{
    //			return 1;
    //		}
    //		if (item1.Value.ID < item2.Value.ID)
    //		{
    //			return -1;
    //		}
    //		return 0;
    //	}

    //	public void Save(GameFileStream stream)
    //	{
    //		int itemTotalCount = this.GetItemTotalCount();
    //		stream.WriteInt(this.m_SerialID);
    //		stream.WriteInt(itemTotalCount);
    //		this.ResetByOrder();
    //		for (int i = 0; i < itemTotalCount; i++)
    //		{
    //			ItemData dataByOrder = this.GetDataByOrder();
    //			stream.WriteObjData(dataByOrder);
    //		}
    //	}

    //	public void Load(GameFileStream stream)
    //	{
    //		this.m_SerialID = stream.ReadInt();
    //		int num = stream.ReadInt();
    //		this.Clear();
    //		for (int i = 0; i < num; i++)
    //		{
    //			ItemData itemData = new ItemData();
    //			object obj = itemData;
    //			stream.ReadObjData(out obj);
    //			itemData = (obj as ItemData);
    //			this.m_ItemData.Add(itemData.SerialID, itemData);
    //			this.CheckMItemIdentify(itemData.ID);
    //			if (itemData.SerialID > this.m_SerialID)
    //			{
    //				Debug.LogWarning(itemData.SerialID + "_物品序列ID > 目前最大序列ID_" + this.m_SerialID);
    //				this.m_SerialID = itemData.SerialID;
    //			}
    //			if (itemData.RefineSoul == null)
    //			{
    //				itemData.RefineSoul = new int[3];
    //			}
    //		}
    //	}

    //	public void CheckMItemIdentify(int id)
    //	{
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (data.emItemType == ENUM_ItemType.MagicItem && Swd6Application.instance.m_IdentifySystem.GetData(id) == null)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Talisman, 0f, 0);
    //		}
    //	}
}
