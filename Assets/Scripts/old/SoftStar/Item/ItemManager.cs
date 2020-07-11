using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SoftStar.Item
{
    public class ItemManager : ISaveInterface
    {
        private Dictionary<string, ItemGroup> mGroups;

        //		private static Func<uint, IItemType>[] mItemFactory;

        //		private uint emptyItemPos;

        //		// Token: 0x0400308F RID: 12431
        //		private List<IItem> mItems = new List<IItem>(1024);

        //		// Token: 0x04003090 RID: 12432
        //		private Dictionary<uint, ItemPackage> mPackages = new Dictionary<uint, ItemPackage>(8);

        //		// Token: 0x04003091 RID: 12433
        //		private bool mIsInitialized;

        private static ItemManager instance;

        //		private ItemManager()
        //		{
        //			//this.mGroups = new Dictionary<string, ItemGroup>(16);
        //			//base..ctor();
        //			//this.mIsInitialized = true;
        //		}

        //		static ItemManager()
        //		{
        //			//Func<uint, IItemType>[] array = new Func<uint, IItemType>[256];
        //			//array[0] = ((uint inID) => SimpleItemTypeCache.GetData(inID));
        //			//array[1] = ((uint inID) => WeaponItemTypeCache.GetData(inID));
        //			//array[2] = ((uint inID) => ClothItemTypeCache.GetData(inID));
        //			//array[3] = ((uint inID) => ShoesItemTypeCache.GetData(inID));
        //			//array[4] = ((uint inID) => OrnamentItemTypeCache.GetData(inID));
        //			//array[5] = ((uint inID) => FashionClothItemTypeCache.GetData(inID));
        //			//array[16] = ((uint inID) => NormalItemTypeCache.GetData(inID));
        //			//array[32] = ((uint inID) => SymbolNodeItemType.GetData(inID));
        //			//array[33] = ((uint inID) => SymbolPanelItemType.GetData(inID));
        //			ItemManager.mItemFactory = array;
        //			ItemManager.instance = new ItemManager();
        //		}

        public event Action<IItem> OnAfterAddItem;

        /// <summary>
        /// 移除物品之前
        /// </summary>
        public event Action<IItem> OnBeforeRemoveItem;

        public event Action<IItem[]> AfterCountChange;

        //		public void AddGroup(ItemGroup inGroup)
        //		{
        //			this.mGroups.Add(inGroup.ID, inGroup);
        //		}

        //		// Token: 0x060035D7 RID: 13783 RVA: 0x00186730 File Offset: 0x00184930
        //		public void RemoveGroup(string ID)
        //		{
        //			this.mGroups.Remove(ID);
        //		}

        //		// Token: 0x060035D8 RID: 13784 RVA: 0x00186740 File Offset: 0x00184940
        //		public ItemGroup GetGroup(string ID)
        //		{
        //			ItemGroup result;
        //			if (this.mGroups.TryGetValue(ID, out result))
        //			{
        //				return result;
        //			}
        //			return null;
        //		}

        //		// Token: 0x060035D9 RID: 13785 RVA: 0x00186764 File Offset: 0x00184964
        //		public ItemGroup GetOrCreateGroup(string ID)
        //		{
        //			return ItemGroup.GetOrCreateGroup(ID);
        //		}

        //		// Token: 0x060035DA RID: 13786 RVA: 0x0018676C File Offset: 0x0018496C
        //		public static IItemType GetItemType(uint inTypeID)
        //		{
        //			uint num = inTypeID >> 24;
        //			if ((ulong)num >= (ulong)((long)ItemManager.mItemFactory.Length))
        //			{
        //				Debug.LogError("item type factory = " + num.ToString());
        //				return null;
        //			}
        //			if (ItemManager.mItemFactory[(int)((UIntPtr)num)] == null)
        //			{
        //				return null;
        //			}
        //			return ItemManager.mItemFactory[(int)((UIntPtr)num)](inTypeID);
        //		}

        //		// Token: 0x060035DB RID: 13787 RVA: 0x001867C4 File Offset: 0x001849C4
        //		public IEnumerable<IItem> ForEachItem()
        //		{
        //			foreach (IItem curItem in this.mItems)
        //			{
        //				if (curItem != null)
        //				{
        //					yield return curItem;
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x060035DC RID: 13788 RVA: 0x001867E8 File Offset: 0x001849E8
        //		public uint GetItemEmptyID()
        //		{
        //			if ((ulong)this.emptyItemPos >= (ulong)((long)this.mItems.Count) || this.emptyItemPos < 1u)
        //			{
        //				this.emptyItemPos = 1u;
        //			}
        //			while ((ulong)this.emptyItemPos < (ulong)((long)this.mItems.Count) && this.mItems[(int)this.emptyItemPos] != null)
        //			{
        //				this.emptyItemPos += 1u;
        //			}
        //			if ((ulong)this.emptyItemPos == (ulong)((long)this.mItems.Count))
        //			{
        //				this.mItems.Add(null);
        //			}
        //			return this.emptyItemPos++;
        //		}

        //		// Token: 0x060035DD RID: 13789 RVA: 0x00186898 File Offset: 0x00184A98
        //		public void DoOnAfterAddItem(IItem obj)
        //		{
        //			if (this.OnAfterAddItem != null)
        //			{
        //				this.OnAfterAddItem(obj);
        //			}
        //		}

        //		// Token: 0x060035DE RID: 13790 RVA: 0x001868B4 File Offset: 0x00184AB4
        //		public void AddItem(IItem inItem)
        //		{
        //			if ((ulong)inItem.ID >= (ulong)((long)this.mItems.Count))
        //			{
        //				this.mItems.AddRange(new IItem[(ulong)(inItem.ID + 1u) - (ulong)((long)this.mItems.Count)]);
        //				this.mItems[(int)inItem.ID] = inItem;
        //			}
        //			else
        //			{
        //				if (this.mItems[(int)inItem.ID] != null)
        //				{
        //					LogManager.DebugLog("物品重复注册 " + inItem.ID);
        //					if (this.mItems[(int)inItem.ID] != inItem)
        //					{
        //						LogManager.DebugLog("编号对应的物品冲突 " + inItem.ID);
        //					}
        //					return;
        //				}
        //				this.mItems[(int)inItem.ID] = inItem;
        //			}
        //			if (this.OnAfterAddItem != null)
        //			{
        //				this.OnAfterAddItem(inItem);
        //			}
        //		}

        //		// Token: 0x060035DF RID: 13791 RVA: 0x001869A8 File Offset: 0x00184BA8
        //		public void AddItemWithoutEvent(IItem inItem)
        //		{
        //			if ((ulong)inItem.ID >= (ulong)((long)this.mItems.Count))
        //			{
        //				this.mItems.AddRange(new IItem[(ulong)(inItem.ID + 1u) - (ulong)((long)this.mItems.Count)]);
        //				this.mItems[(int)inItem.ID] = inItem;
        //			}
        //			else
        //			{
        //				if (this.mItems[(int)inItem.ID] != null)
        //				{
        //					LogManager.DebugLog("物品重复注册 " + inItem.ID);
        //					if (this.mItems[(int)inItem.ID] != inItem)
        //					{
        //						LogManager.DebugLog("编号对应的物品冲突 " + inItem.ID);
        //					}
        //					return;
        //				}
        //				this.mItems[(int)inItem.ID] = inItem;
        //			}
        //		}

        //		// Token: 0x060035E0 RID: 13792 RVA: 0x00186A84 File Offset: 0x00184C84
        //		public void RemoveItem(uint ID)
        //		{
        //			if ((ulong)ID >= (ulong)((long)this.mItems.Count))
        //			{
        //				return;
        //			}
        //			IItem item = this.mItems[(int)ID];
        //			if (item == null)
        //			{
        //				return;
        //			}
        //			if (this.OnBeforeRemoveItem != null)
        //			{
        //				this.OnBeforeRemoveItem(item);
        //			}
        //			if (item.OwnerPackage != null)
        //			{
        //				item.OwnerPackage.RemoveItem(item);
        //			}
        //			foreach (KeyValuePair<string, ItemGroup> keyValuePair in this.mGroups)
        //			{
        //				keyValuePair.Value.UnLink(item);
        //			}
        //			this.mItems[(int)ID] = null;
        //		}

        //		// Token: 0x060035E1 RID: 13793 RVA: 0x00186B54 File Offset: 0x00184D54
        //		public void RemoveItemWithoutEvent(uint ID)
        //		{
        //			if ((ulong)ID >= (ulong)((long)this.mItems.Count))
        //			{
        //				return;
        //			}
        //			IItem item = this.mItems[(int)ID];
        //			if (item == null)
        //			{
        //				return;
        //			}
        //			if (item.OwnerPackage != null)
        //			{
        //				item.OwnerPackage.RemoveItemWithoutEvent(item);
        //			}
        //			foreach (KeyValuePair<string, ItemGroup> keyValuePair in this.mGroups)
        //			{
        //				keyValuePair.Value.UnLink(item);
        //			}
        //			this.mItems[(int)ID] = null;
        //		}

        //		// Token: 0x060035E2 RID: 13794 RVA: 0x00186C0C File Offset: 0x00184E0C
        //		public IItem GetItem(uint ID)
        //		{
        //			if ((ulong)ID >= (ulong)((long)this.mItems.Count))
        //			{
        //				return null;
        //			}
        //			return this.mItems[(int)ID];
        //		}

        //		// Token: 0x060035E3 RID: 13795 RVA: 0x00186C30 File Offset: 0x00184E30
        //		public void DoAfterCountChange(IItem[] obj)
        //		{
        //			if (this.AfterCountChange != null)
        //			{
        //				this.AfterCountChange(obj);
        //			}
        //		}

        //		// Token: 0x060035E4 RID: 13796 RVA: 0x00186C4C File Offset: 0x00184E4C
        //		public static uint GetID(uint parent, uint child)
        //		{
        //			return parent << 24 | child;
        //		}

        //		// Token: 0x060035E5 RID: 13797 RVA: 0x00186C54 File Offset: 0x00184E54
        //		public void AddPackage(ItemPackage inPackage)
        //		{
        //			this.mPackages.Add(inPackage.ID, inPackage);
        //		}

        //		// Token: 0x060035E6 RID: 13798 RVA: 0x00186C68 File Offset: 0x00184E68
        //		public ItemPackage GetPackage(uint ID)
        //		{
        //			ItemPackage result;
        //			if (this.mPackages.TryGetValue(ID, out result))
        //			{
        //				return result;
        //			}
        //			return null;
        //		}

        //		// Token: 0x060035E7 RID: 13799 RVA: 0x00186C8C File Offset: 0x00184E8C
        //		public ItemPackage GetOrCreatePackage(uint ID)
        //		{
        //			return ItemPackage.GetOrCreatePackage(ID);
        //		}

        //		// Token: 0x060035E8 RID: 13800 RVA: 0x00186C94 File Offset: 0x00184E94
        //		public bool ForEachItemWithNoPackage(Func<IItem, bool> myfun)
        //		{
        //			foreach (IItem item in this.mItems)
        //			{
        //				if (item.OwnerPackage == null && !myfun(item))
        //				{
        //					return false;
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x060035E9 RID: 13801 RVA: 0x00186D14 File Offset: 0x00184F14
        //		public IEnumerator<T> ForEachItemWithNoPackage<T>() where T : class
        //		{
        //			foreach (IItem cur in this.mItems)
        //			{
        //				if (cur.OwnerPackage == null)
        //				{
        //					T curT = cur as T;
        //					if (curT != null)
        //					{
        //						yield return curT;
        //					}
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x060035EA RID: 13802 RVA: 0x00186D30 File Offset: 0x00184F30
        //		public void RemovePackage(uint ID)
        //		{
        //			ItemPackage itemPackage;
        //			if (!this.mPackages.TryGetValue(ID, out itemPackage))
        //			{
        //				return;
        //			}
        //			itemPackage.ForEachItemInPackage(delegate(IItem curItem)
        //			{
        //				curItem.OwnerPackage = null;
        //				return true;
        //			});
        //			this.mPackages.Remove(ID);
        //		}

        public void Save(BinaryWriter writer)
        {
            //int num = 0;
            //foreach (IItem item in this.mItems)
            //{
            //    if (item != null)
            //    {
            //        num++;
            //    }
            //}
            //writer.Write(num);
            //MemoryStream memoryStream = new MemoryStream(8);
            //BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            //foreach (IItem item2 in this.mItems)
            //{
            //    if (item2 != null)
            //    {
            //        writer.Write(item2.ItemType.TypeID);
            //        memoryStream.SetLength(0L);
            //        item2.ItemType.SaveUserData(binaryWriter, item2);
            //        StreamHelper.UserDefined_Save(binaryWriter, item2.UserDefinedData);
            //        StreamHelper.number_to_bytes((uint)memoryStream.Length, writer.BaseStream);
            //        writer.Write(memoryStream.ToArray());
            //    }
            //}
            //writer.Write(this.mGroups.Count);
            //foreach (KeyValuePair<string, ItemGroup> keyValuePair in this.mGroups)
            //{
            //    keyValuePair.Value.Save(writer);
            //}
            //List<ItemPackage> list = new List<ItemPackage>(this.mPackages.Count);
            //foreach (KeyValuePair<uint, ItemPackage> keyValuePair2 in this.mPackages)
            //{
            //    if (keyValuePair2.Value != null && keyValuePair2.Value.ID != 0u && keyValuePair2.Value.ItemsCount > 0)
            //    {
            //        list.Add(keyValuePair2.Value);
            //    }
            //}
            //writer.Write(list.Count);
            //foreach (ItemPackage itemPackage in list)
            //{
            //    if (itemPackage != null)
            //    {
            //        itemPackage.Save(writer);
            //    }
            //}
        }

        //		// Token: 0x17000405 RID: 1029
        //		// (get) Token: 0x060035EC RID: 13804 RVA: 0x0018702C File Offset: 0x0018522C
        //		public bool IsInitialized
        //		{
        //			get
        //			{
        //				return this.mIsInitialized;
        //			}
        //		}

        //		// Token: 0x060035ED RID: 13805 RVA: 0x00187034 File Offset: 0x00185234
        //		public void ClearData()
        //		{
        //			this.mIsInitialized = false;
        //			this.mItems.Clear();
        //			foreach (KeyValuePair<string, ItemGroup> keyValuePair in this.mGroups)
        //			{
        //				keyValuePair.Value.ClearForLoad();
        //			}
        //			foreach (KeyValuePair<uint, ItemPackage> keyValuePair2 in this.mPackages)
        //			{
        //				keyValuePair2.Value.ClearForLoad();
        //			}
        //			this.emptyItemPos = 0u;
        //			OrnamentItemTypeCache.ClearIsGet();
        //			FashionClothItemTypeCache.ClearIsGet();
        //		}

        public void Load(BinaryReader reader)
        {
            //this.ClearData();
            //uint num = reader.ReadUInt32();
            //MemoryStream memoryStream = new MemoryStream(8);
            //BinaryReader binaryReader = new BinaryReader(memoryStream);
            //while (num > 0u)
            //{
            //    uint inTypeID = reader.ReadUInt32();
            //    memoryStream.SetLength((long)((ulong)StreamHelper.bytes_to_uint32(reader.BaseStream)));
            //    memoryStream.Position = 0L;
            //    memoryStream.Write(reader.ReadBytes((int)memoryStream.Length), 0, (int)memoryStream.Length);
            //    if (!SaveManager.IsErZhouMu || SaveManager.inheritStruct.Item)
            //    {
            //        memoryStream.Position = 0L;
            //        try
            //        {
            //            IItemType itemType = ItemManager.GetItemType(inTypeID);
            //            if (itemType == null)
            //            {
            //                throw new Exception("read item error : " + inTypeID.ToString() + " not exist");
            //            }
            //            IItem item = itemType.Create(binaryReader);
            //            StreamHelper.UserDefined_Load(binaryReader, item.UserDefinedData);
            //        }
            //        catch (Exception ex)
            //        {
            //            Debug.LogError("read item error : " + ex.ToString());
            //        }
            //    }
            //    num -= 1u;
            //}
            //for (num = reader.ReadUInt32(); num > 0u; num -= 1u)
            //{
            //    ItemGroup.GetOrCreateGroup(reader.ReadString()).Load(reader);
            //}
            //for (num = reader.ReadUInt32(); num > 0u; num -= 1u)
            //{
            //    ItemPackage.GetOrCreatePackage(reader.ReadUInt32()).Load(reader);
            //}
            //this.GetItemEmptyID();
        }

        //		// Token: 0x060035EF RID: 13807 RVA: 0x00187288 File Offset: 0x00185488
        //		public IEnumerator Prepare()
        //		{
        //			List<IEnumerator> needPrepare = new List<IEnumerator>(this.mItems.Count);
        //			foreach (IItem cur in this.mItems)
        //			{
        //				if (cur != null)
        //				{
        //					needPrepare.Add(cur.Prepare());
        //				}
        //			}
        //			foreach (KeyValuePair<string, ItemGroup> cur2 in this.mGroups)
        //			{
        //				needPrepare.Add(cur2.Value.Prepare());
        //			}
        //			foreach (KeyValuePair<uint, ItemPackage> cur3 in this.mPackages)
        //			{
        //				needPrepare.Add(cur3.Value.Prepare());
        //			}
        //			while (needPrepare.Count > 0)
        //			{
        //				needPrepare.RemoveAll((IEnumerator curItem) => curItem == null || !curItem.MoveNext());
        //				yield return null;
        //			}
        //			foreach (KeyValuePair<uint, ItemPackage> cur4 in this.mPackages)
        //			{
        //				cur4.Value.ResetCountWatch();
        //			}
        //			this.mIsInitialized = true;
        //			yield break;
        //		}

        public static ItemManager GetInstance()
        {
            return ItemManager.instance;
        }
    }
}
