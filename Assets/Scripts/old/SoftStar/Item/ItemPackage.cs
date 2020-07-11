using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SoftStar.Pal6;
using UnityEngine;

namespace SoftStar.Item
{
    public class ItemPackage
    {
        //		private ItemPackage(uint inID)
        //		{
        //			this.mID = inID;
        //			if (this.mID == 0u)
        //			{
        //				LogManager.DebugLog("禁止获取0号包裹！");
        //			}
        //			ItemManager.GetInstance().AddPackage(this);
        //			this.ResetCountWatch();
        //			this.mIsInitialized = true;
        //		}

        //		// Token: 0x1400001B RID: 27
        //		// (add) Token: 0x06003021 RID: 12321 RVA: 0x0015FC70 File Offset: 0x0015DE70
        //		// (remove) Token: 0x06003022 RID: 12322 RVA: 0x0015FC8C File Offset: 0x0015DE8C
        //		public event Action<IItem> OnItemRemoving;

        //		// Token: 0x1400001C RID: 28
        //		// (add) Token: 0x06003023 RID: 12323 RVA: 0x0015FCA8 File Offset: 0x0015DEA8
        //		// (remove) Token: 0x06003024 RID: 12324 RVA: 0x0015FCC4 File Offset: 0x0015DEC4
        //		public event Action<IItem> OnItemAdded;

        //		// Token: 0x1400001D RID: 29
        //		// (add) Token: 0x06003025 RID: 12325 RVA: 0x0015FCE0 File Offset: 0x0015DEE0
        //		// (remove) Token: 0x06003026 RID: 12326 RVA: 0x0015FCFC File Offset: 0x0015DEFC
        //		public event Action<uint, int> OnItemTypeCountRealChanged;

        //		// Token: 0x1700034A RID: 842
        //		// (get) Token: 0x06003027 RID: 12327 RVA: 0x0015FD18 File Offset: 0x0015DF18
        //		public virtual uint ID
        //		{
        //			get
        //			{
        //				return this.mID;
        //			}
        //		}

        //		// Token: 0x1700034B RID: 843
        //		// (get) Token: 0x06003028 RID: 12328 RVA: 0x0015FD20 File Offset: 0x0015DF20
        //		public bool IsInitialized
        //		{
        //			get
        //			{
        //				return this.mIsInitialized;
        //			}
        //		}

        //		// Token: 0x06003029 RID: 12329 RVA: 0x0015FD28 File Offset: 0x0015DF28
        //		public static ItemPackage GetOrCreatePackage(uint inID)
        //		{
        //			if (inID == 0u)
        //			{
        //				LogManager.DebugLog("禁止获取0号包裹！");
        //			}
        //			ItemPackage itemPackage = ItemManager.GetInstance().GetPackage(inID);
        //			if (itemPackage == null)
        //			{
        //				itemPackage = new ItemPackage(inID);
        //			}
        //			return itemPackage;
        //		}

        //		// Token: 0x0600302A RID: 12330 RVA: 0x0015FD60 File Offset: 0x0015DF60
        //		public void ClearForLoad()
        //		{
        //			this.mIsInitialized = false;
        //			this.mItems.Clear();
        //		}

        //		// Token: 0x0600302B RID: 12331 RVA: 0x0015FD74 File Offset: 0x0015DF74
        //		public void Load(BinaryReader source)
        //		{
        //			this.mIsInitialized = false;
        //			this.mLoadData = new uint[source.ReadInt32()];
        //			for (int i = 0; i < this.mLoadData.Length; i++)
        //			{
        //				this.mLoadData[i] = source.ReadUInt32();
        //			}
        //		}

        //		// Token: 0x0600302C RID: 12332 RVA: 0x0015FDC0 File Offset: 0x0015DFC0
        //		public IEnumerator Prepare()
        //		{
        //			if (this.mLoadData == null)
        //			{
        //				this.ResetCountWatch();
        //				yield break;
        //			}
        //			for (int pos = 0; pos < this.mLoadData.Length; pos++)
        //			{
        //				IItem curItem = ItemManager.GetInstance().GetItem(this.mLoadData[pos]);
        //				if (curItem != null)
        //				{
        //					this.SetInPackageWithoutEvent(curItem);
        //				}
        //				else
        //				{
        //					Debug.LogError("ItemPackage error : " + this.mLoadData[pos].ToString() + " not exist");
        //				}
        //			}
        //			this.ResetCountWatch();
        //			this.mIsInitialized = true;
        //			yield break;
        //		}

        //		// Token: 0x0600302D RID: 12333 RVA: 0x0015FDDC File Offset: 0x0015DFDC
        //		public bool ForEachItemInPackage(Func<IItem, bool> myfun)
        //		{
        //			foreach (KeyValuePair<uint, IItem> keyValuePair in this.mItems)
        //			{
        //				if (!myfun(keyValuePair.Value))
        //				{
        //					return false;
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x0600302E RID: 12334 RVA: 0x0015FE58 File Offset: 0x0015E058
        //		public IEnumerable<IItem> ForEachItemInPackage()
        //		{
        //			foreach (KeyValuePair<uint, IItem> cur in this.mItems)
        //			{
        //				yield return cur.Value;
        //			}
        //			yield break;
        //		}

        //		// Token: 0x0600302F RID: 12335 RVA: 0x0015FE7C File Offset: 0x0015E07C
        //		public IEnumerable<T> ForEachItemInPackage<T>() where T : class
        //		{
        //			foreach (KeyValuePair<uint, IItem> cur in this.mItems)
        //			{
        //				T curT = cur.Value as T;
        //				if (curT != null)
        //				{
        //					yield return curT;
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x06003030 RID: 12336 RVA: 0x0015FEA0 File Offset: 0x0015E0A0
        //		public void RemoveItem(IItem curItem)
        //		{
        //			if (this.OnItemRemoving != null)
        //			{
        //				this.OnItemRemoving(curItem);
        //			}
        //			this.mItems.Remove(curItem.ID);
        //			curItem.OwnerPackage = null;
        //		}

        //		// Token: 0x06003031 RID: 12337 RVA: 0x0015FEE0 File Offset: 0x0015E0E0
        //		public void RemoveItemWithoutEvent(IItem curItem)
        //		{
        //			this.mItems.Remove(curItem.ID);
        //			curItem.OwnerPackage = null;
        //		}

        //		// Token: 0x06003032 RID: 12338 RVA: 0x0015FEFC File Offset: 0x0015E0FC
        //		public void DoOnItemAdded(IItem obj)
        //		{
        //			if (this.OnItemAdded != null)
        //			{
        //				this.OnItemAdded(obj);
        //			}
        //		}

        //		// Token: 0x06003033 RID: 12339 RVA: 0x0015FF18 File Offset: 0x0015E118
        //		public void SetInPackageWithoutEvent(IItem curItem)
        //		{
        //			if (curItem.OwnerPackage != null)
        //			{
        //				if (curItem.OwnerPackage == this)
        //				{
        //					return;
        //				}
        //				curItem.OwnerPackage.RemoveItem(curItem);
        //			}
        //			if (!this.mItems.ContainsKey(curItem.ID))
        //			{
        //				this.mItems.Add(curItem.ID, curItem);
        //			}
        //			curItem.OwnerPackage = this;
        //		}

        //		// Token: 0x06003034 RID: 12340 RVA: 0x0015FF80 File Offset: 0x0015E180
        //		public void SetInPackage(IItem curItem)
        //		{
        //			if (curItem.OwnerPackage != null)
        //			{
        //				if (curItem.OwnerPackage == this)
        //				{
        //					return;
        //				}
        //				curItem.OwnerPackage.RemoveItem(curItem);
        //			}
        //			if (!this.mItems.ContainsKey(curItem.ID))
        //			{
        //				this.mItems.Add(curItem.ID, curItem);
        //				curItem.OwnerPackage = this;
        //				if (this.OnItemAdded != null)
        //				{
        //					this.OnItemAdded(curItem);
        //				}
        //			}
        //			else
        //			{
        //				curItem.OwnerPackage = this;
        //			}
        //		}

        //		// Token: 0x06003035 RID: 12341 RVA: 0x00160004 File Offset: 0x0015E204
        //		public void Save(BinaryWriter writer)
        //		{
        //			writer.Write(this.mID);
        //			writer.Write(this.mItems.Count);
        //			foreach (KeyValuePair<uint, IItem> keyValuePair in this.mItems)
        //			{
        //				writer.Write(keyValuePair.Value.ID);
        //			}
        //		}

        //		// Token: 0x06003036 RID: 12342 RVA: 0x00160094 File Offset: 0x0015E294
        //		public void ResetCountWatch()
        //		{
        //			this.mCountWatch.Clear();
        //			KeyValuePair<uint, IItem> curItem;
        //			foreach (KeyValuePair<uint, IItem> curItem2 in this.mItems)
        //			{
        //				curItem = curItem2;
        //				uint typeID = curItem.Value.ItemType.TypeID;
        //				ItemPackage.ItemCountWatch itemCountWatch;
        //				if (!this.mCountWatch.TryGetValue(typeID, out itemCountWatch))
        //				{
        //					itemCountWatch = new ItemPackage.ItemCountWatch();
        //					this.mCountWatch.Add(typeID, itemCountWatch);
        //				}
        //				if (itemCountWatch.Items.Find((ItemWatcher obj) => obj.Target == curItem.Value) == null)
        //				{
        //					itemCountWatch.Items.Add(new ItemWatcher(curItem.Value));
        //				}
        //			}
        //			foreach (KeyValuePair<uint, ItemPackage.ItemCountWatch> keyValuePair in this.mCountWatch)
        //			{
        //				keyValuePair.Value.OldCount = keyValuePair.Value.GetNewCount();
        //			}
        //			this.OnItemAdded = (Action<IItem>)Delegate.Remove(this.OnItemAdded, new Action<IItem>(this.CountWatch_Add));
        //			this.OnItemAdded = (Action<IItem>)Delegate.Combine(this.OnItemAdded, new Action<IItem>(this.CountWatch_Add));
        //			this.OnItemRemoving = (Action<IItem>)Delegate.Remove(this.OnItemRemoving, new Action<IItem>(this.CountWatch_Remove));
        //			this.OnItemRemoving = (Action<IItem>)Delegate.Combine(this.OnItemRemoving, new Action<IItem>(this.CountWatch_Remove));
        //			ItemManager.GetInstance().AfterCountChange -= this.OnItemCountChange;
        //			ItemManager.GetInstance().AfterCountChange += this.OnItemCountChange;
        //		}

        //		// Token: 0x06003037 RID: 12343 RVA: 0x001602A0 File Offset: 0x0015E4A0
        //		public ItemWatcher[] GetItemsByItemType(uint typeid)
        //		{
        //			ItemPackage.ItemCountWatch itemCountWatch;
        //			if (!this.mCountWatch.TryGetValue(typeid, out itemCountWatch))
        //			{
        //				return new ItemWatcher[0];
        //			}
        //			itemCountWatch.Items.RemoveAll((ItemWatcher obj) => obj.Target == null);
        //			return itemCountWatch.Items.ToArray();
        //		}

        //		// Token: 0x06003038 RID: 12344 RVA: 0x001602FC File Offset: 0x0015E4FC
        //		public IEnumerable<IItem[]> ForEachItemArrayInPackage()
        //		{
        //			foreach (KeyValuePair<uint, ItemPackage.ItemCountWatch> cur in this.mCountWatch)
        //			{
        //				yield return cur.Value.ToArray();
        //			}
        //			yield break;
        //		}

        //		// Token: 0x06003039 RID: 12345 RVA: 0x00160320 File Offset: 0x0015E520
        //		public int GetCountByItemType(uint typeid)
        //		{
        //			ItemPackage.ItemCountWatch itemCountWatch;
        //			if (!this.mCountWatch.TryGetValue(typeid, out itemCountWatch))
        //			{
        //				return 0;
        //			}
        //			int result = 0;
        //			itemCountWatch.Items.RemoveAll(delegate(ItemWatcher obj)
        //			{
        //				IItem target = obj.Target;
        //				if (target == null)
        //				{
        //					return true;
        //				}
        //				result += ItemMergerHelper.GetCount(target);
        //				return false;
        //			});
        //			return result;
        //		}

        //		// Token: 0x0600303A RID: 12346 RVA: 0x00160370 File Offset: 0x0015E570
        //		private void CountWatch_Add(IItem curItem)
        //		{
        //			uint typeID = curItem.ItemType.TypeID;
        //			ItemPackage.ItemCountWatch itemCountWatch;
        //			if (!this.mCountWatch.TryGetValue(typeID, out itemCountWatch))
        //			{
        //				itemCountWatch = new ItemPackage.ItemCountWatch();
        //				this.mCountWatch.Add(typeID, itemCountWatch);
        //			}
        //			if (itemCountWatch.Items.Find((ItemWatcher obj) => obj.Target == curItem) == null)
        //			{
        //				itemCountWatch.Items.Add(new ItemWatcher(curItem));
        //			}
        //			int newCount = itemCountWatch.GetNewCount();
        //			if (newCount != itemCountWatch.OldCount)
        //			{
        //				if (this.OnItemTypeCountRealChanged != null)
        //				{
        //					this.OnItemTypeCountRealChanged(typeID, itemCountWatch.OldCount);
        //				}
        //				itemCountWatch.OldCount = newCount;
        //			}
        //		}

        //		// Token: 0x0600303B RID: 12347 RVA: 0x0016042C File Offset: 0x0015E62C
        //		private void CountWatch_Remove(IItem curItem)
        //		{
        //			uint typeID = curItem.ItemType.TypeID;
        //			ItemPackage.ItemCountWatch itemCountWatch;
        //			if (!this.mCountWatch.TryGetValue(typeID, out itemCountWatch))
        //			{
        //				return;
        //			}
        //			itemCountWatch.Items.RemoveAll((ItemWatcher obj) => obj.Target == curItem);
        //			int newCount = itemCountWatch.GetNewCount();
        //			if (newCount != itemCountWatch.OldCount)
        //			{
        //				if (this.OnItemTypeCountRealChanged != null)
        //				{
        //					this.OnItemTypeCountRealChanged(typeID, itemCountWatch.OldCount);
        //				}
        //				itemCountWatch.OldCount = newCount;
        //			}
        //		}

        //		// Token: 0x0600303C RID: 12348 RVA: 0x001604BC File Offset: 0x0015E6BC
        //		private void OnItemCountChange(IItem[] curItems)
        //		{
        //			List<uint> list = new List<uint>();
        //			foreach (IItem item in curItems)
        //			{
        //				if (list.IndexOf(item.ItemType.TypeID) < 0)
        //				{
        //					list.Add(item.ItemType.TypeID);
        //				}
        //			}
        //			foreach (uint num in list)
        //			{
        //				ItemPackage.ItemCountWatch itemCountWatch;
        //				if (this.mCountWatch.TryGetValue(num, out itemCountWatch))
        //				{
        //					int newCount = itemCountWatch.GetNewCount();
        //					if (newCount != itemCountWatch.OldCount)
        //					{
        //						if (this.OnItemTypeCountRealChanged != null)
        //						{
        //							this.OnItemTypeCountRealChanged(num, itemCountWatch.OldCount);
        //						}
        //						itemCountWatch.OldCount = newCount;
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x1700034C RID: 844
        //		// (get) Token: 0x0600303D RID: 12349 RVA: 0x001605BC File Offset: 0x0015E7BC
        //		private static bool[] MarkNew
        //		{
        //			get
        //			{
        //				if (ItemPackage.mMarkNew == null)
        //				{
        //					ItemPackage.mMarkNew = new bool[256];
        //					ItemPackage.mMarkNew[16] = true;
        //					ItemPackage.mMarkNew[32] = true;
        //					ItemPackage.mMarkNew[33] = true;
        //				}
        //				return ItemPackage.mMarkNew;
        //			}
        //		}

        //		// Token: 0x0600303E RID: 12350 RVA: 0x001605F8 File Offset: 0x0015E7F8
        //		public void AddNewItem(uint typeID, int count)
        //		{
        //			if (count <= 0)
        //			{
        //				return;
        //			}
        //			IItemType itemType = ItemManager.GetItemType(typeID);
        //			if (itemType == null)
        //			{
        //				return;
        //			}
        //			ItemGroup orCreateGroup = ItemManager.GetInstance().GetOrCreateGroup("NewItem");
        //			if (itemType.InstanceType.GetInterface(typeof(IItemMerger).FullName) != null)
        //			{
        //				IItem curItem = itemType.Create();
        //				IItemMerger itemMerger = curItem as IItemMerger;
        //				itemMerger.Count = count;
        //				if (ItemPackage.MarkNew[(int)((UIntPtr)(typeID >> 24))])
        //				{
        //					orCreateGroup.Link(curItem);
        //				}
        //				this.SetInPackage(curItem);
        //				List<IItem> items = new List<IItem>();
        //				this.ForEachItemInPackage(delegate(IItem arg)
        //				{
        //					if (arg.ItemType == curItem.ItemType)
        //					{
        //						items.Add(arg);
        //					}
        //					return true;
        //				});
        //				ItemMergerHelper.Merger(items);
        //			}
        //			else if (ItemPackage.MarkNew[(int)((UIntPtr)(typeID >> 24))])
        //			{
        //				for (int i = 0; i < count; i++)
        //				{
        //					IItem item = itemType.Create();
        //					orCreateGroup.Link(item);
        //					this.SetInPackage(item);
        //				}
        //			}
        //			else
        //			{
        //				for (int j = 0; j < count; j++)
        //				{
        //					IItem inPackage = itemType.Create();
        //					this.SetInPackage(inPackage);
        //				}
        //			}
        //		}

        //		// Token: 0x0600303F RID: 12351 RVA: 0x00160734 File Offset: 0x0015E934
        //		public void AddNewItem_Limit(uint typeID, int count)
        //		{
        //			if (count <= 0)
        //			{
        //				return;
        //			}
        //			if (ItemManager.GetItemType(typeID) == null)
        //			{
        //				return;
        //			}
        //			int countByItemType = this.GetCountByItemType(typeID);
        //			if (countByItemType >= 99)
        //			{
        //				return;
        //			}
        //			if (countByItemType + count > 99)
        //			{
        //				count = 99 - countByItemType;
        //			}
        //			this.AddNewItem(typeID, count);
        //		}

        //		// Token: 0x06003040 RID: 12352 RVA: 0x00160780 File Offset: 0x0015E980
        //		public void MergerItemType(uint typeID)
        //		{
        //			List<IItem> items = new List<IItem>();
        //			this.ForEachItemInPackage(delegate(IItem arg)
        //			{
        //				if (arg.ItemType.TypeID == typeID)
        //				{
        //					items.Add(arg);
        //				}
        //				return true;
        //			});
        //			ItemMergerHelper.Merger(items);
        //		}

        //		// Token: 0x1700034D RID: 845
        //		// (get) Token: 0x06003041 RID: 12353 RVA: 0x001607C4 File Offset: 0x0015E9C4
        //		public int ItemsCount
        //		{
        //			get
        //			{
        //				return this.mItems.Count;
        //			}
        //		}

        //		// Token: 0x06003042 RID: 12354 RVA: 0x001607D4 File Offset: 0x0015E9D4
        //		public void GetItemsCanUseByMission(uint typeID, List<IItem> result)
        //		{
        //			ItemPackage.ItemCountWatch itemCountWatch;
        //			if (!this.mCountWatch.TryGetValue(typeID, out itemCountWatch))
        //			{
        //				return;
        //			}
        //			itemCountWatch.Items.RemoveAll(delegate(ItemWatcher obj)
        //			{
        //				IItem target = obj.Target;
        //				if (target == null)
        //				{
        //					return true;
        //				}
        //				IItemAssemble<PalNPC> itemAssemble = target as IItemAssemble<PalNPC>;
        //				if (itemAssemble != null && itemAssemble.GetOwner() != null)
        //				{
        //					return false;
        //				}
        //				IItemAssemble<SymbolPanelItem> itemAssemble2 = target as IItemAssemble<SymbolPanelItem>;
        //				if (itemAssemble2 != null && itemAssemble2.GetOwner() != null)
        //				{
        //					return false;
        //				}
        //				WeaponItem weaponItem = target as WeaponItem;
        //				if (weaponItem != null && weaponItem.ItemType != weaponItem.Change)
        //				{
        //					return false;
        //				}
        //				result.Add(target);
        //				return false;
        //			});
        //		}

        //		// Token: 0x06003043 RID: 12355 RVA: 0x0016081C File Offset: 0x0015EA1C
        //		public bool RemoveItems(List<IItem> Items, int Number)
        //		{
        //			if (Number <= 0)
        //			{
        //				return false;
        //			}
        //			int num = 0;
        //			foreach (IItem curitem in Items)
        //			{
        //				num += ItemMergerHelper.GetCount(curitem);
        //			}
        //			if (num < Number)
        //			{
        //				return false;
        //			}
        //			foreach (IItem item in Items)
        //			{
        //				int count = ItemMergerHelper.GetCount(item);
        //				if (count < Number)
        //				{
        //					item.OwnerPackage.RemoveItem(item);
        //					Number -= count;
        //				}
        //				else
        //				{
        //					if (count == Number)
        //					{
        //						item.OwnerPackage.RemoveItem(item);
        //						return true;
        //					}
        //					(item as IItemMerger).Count -= Number;
        //					return true;
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x06003044 RID: 12356 RVA: 0x00160940 File Offset: 0x0015EB40
        //		public static int GetPrice(IItemType s)
        //		{
        //			FieldInfo field = s.GetType().GetField("Price");
        //			if (field == null)
        //			{
        //				return 0;
        //			}
        //			return (int)field.GetValue(s);
        //		}

        //		// Token: 0x06003045 RID: 12357 RVA: 0x00160974 File Offset: 0x0015EB74
        //		public static bool GetCanTrade(IItemType s)
        //		{
        //			FieldInfo field = s.GetType().GetField("CanTrade");
        //			return field != null && (bool)field.GetValue(s);
        //		}

        //		// Token: 0x06003046 RID: 12358 RVA: 0x001609A8 File Offset: 0x0015EBA8
        //		public static int GetRenownType(IItemType s)
        //		{
        //			FieldInfo field = s.GetType().GetField("RenownType");
        //			if (field == null)
        //			{
        //				return -1;
        //			}
        //			return (int)field.GetValue(s);
        //		}

        //		// Token: 0x06003047 RID: 12359 RVA: 0x001609DC File Offset: 0x0015EBDC
        //		public static int GetRenownNeed(IItemType s)
        //		{
        //			FieldInfo field = s.GetType().GetField("RenownNeed");
        //			if (field == null)
        //			{
        //				return 0;
        //			}
        //			return (int)field.GetValue(s);
        //		}

        //		// Token: 0x04002BB9 RID: 11193
        //		private readonly uint mID;

        //		// Token: 0x04002BBA RID: 11194
        //		private Dictionary<uint, IItem> mItems = new Dictionary<uint, IItem>();

        //		// Token: 0x04002BBB RID: 11195
        //		private Dictionary<uint, ItemPackage.ItemCountWatch> mCountWatch = new Dictionary<uint, ItemPackage.ItemCountWatch>();

        //		// Token: 0x04002BBC RID: 11196
        //		private uint[] mLoadData;

        //		// Token: 0x04002BBD RID: 11197
        //		private bool mIsInitialized;

        //		// Token: 0x04002BBE RID: 11198
        //		private static bool[] mMarkNew;

        //		// Token: 0x020006DC RID: 1756
        //		private class ItemCountWatch
        //		{
        //			// Token: 0x0600304A RID: 12362 RVA: 0x00160A44 File Offset: 0x0015EC44
        //			public int GetNewCount()
        //			{
        //				int result = 0;
        //				this.Items.RemoveAll(delegate(ItemWatcher obj)
        //				{
        //					IItem target = obj.Target;
        //					if (target == null)
        //					{
        //						return true;
        //					}
        //					result += ItemMergerHelper.GetCount(target);
        //					return false;
        //				});
        //				return result;
        //			}

        //			// Token: 0x0600304B RID: 12363 RVA: 0x00160A7C File Offset: 0x0015EC7C
        //			public IItem[] ToArray()
        //			{
        //				List<IItem> list = new List<IItem>(this.Items.Count);
        //				foreach (ItemWatcher itemWatcher in this.Items)
        //				{
        //					if (itemWatcher != null && itemWatcher.Target != null)
        //					{
        //						list.Add(itemWatcher.Target);
        //					}
        //				}
        //				return list.ToArray();
        //			}

        //			// Token: 0x04002BC3 RID: 11203
        //			public List<ItemWatcher> Items = new List<ItemWatcher>();

        //			// Token: 0x04002BC4 RID: 11204
        //			public int OldCount;
        //		}
    }
}
