using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SoftStar.Item
{
    public class ItemGroup //: IComparable<ItemGroup>
    {
        //		// Token: 0x06003010 RID: 12304 RVA: 0x0015F8A4 File Offset: 0x0015DAA4
        //		private ItemGroup(string inID)
        //		{
        //			this.mID = inID;
        //			ItemManager.GetInstance().AddGroup(this);
        //			this.mIsInitialized = true;
        //		}

        //		// Token: 0x06003011 RID: 12305 RVA: 0x0015F8DC File Offset: 0x0015DADC
        //		public int CompareTo(ItemGroup other)
        //		{
        //			return this.mID.CompareTo(other.mID);
        //		}

        //		// Token: 0x17000347 RID: 839
        //		// (get) Token: 0x06003012 RID: 12306 RVA: 0x0015F8F0 File Offset: 0x0015DAF0
        //		public string ID
        //		{
        //			get
        //			{
        //				return this.mID;
        //			}
        //		}

        //		// Token: 0x17000348 RID: 840
        //		// (get) Token: 0x06003013 RID: 12307 RVA: 0x0015F8F8 File Offset: 0x0015DAF8
        //		public int ItemCount
        //		{
        //			get
        //			{
        //				return this.mItems.Count;
        //			}
        //		}

        //		// Token: 0x17000349 RID: 841
        //		// (get) Token: 0x06003014 RID: 12308 RVA: 0x0015F908 File Offset: 0x0015DB08
        //		public bool IsInitialized
        //		{
        //			get
        //			{
        //				return this.mIsInitialized;
        //			}
        //		}

        //		// Token: 0x06003015 RID: 12309 RVA: 0x0015F910 File Offset: 0x0015DB10
        //		public static ItemGroup GetOrCreateGroup(string inID)
        //		{
        //			ItemGroup itemGroup = ItemManager.GetInstance().GetGroup(inID);
        //			if (itemGroup == null)
        //			{
        //				itemGroup = new ItemGroup(inID);
        //			}
        //			return itemGroup;
        //		}

        //		// Token: 0x06003016 RID: 12310 RVA: 0x0015F938 File Offset: 0x0015DB38
        //		public void ClearForLoad()
        //		{
        //			this.mIsInitialized = false;
        //			this.mItems.Clear();
        //		}

        //		// Token: 0x06003017 RID: 12311 RVA: 0x0015F94C File Offset: 0x0015DB4C
        //		public void Load(BinaryReader source)
        //		{
        //			this.mIsInitialized = false;
        //			this.mLoadData = new uint[source.ReadInt32()];
        //			for (int i = 0; i < this.mLoadData.Length; i++)
        //			{
        //				this.mLoadData[i] = source.ReadUInt32();
        //			}
        //		}

        //		// Token: 0x06003018 RID: 12312 RVA: 0x0015F998 File Offset: 0x0015DB98
        //		public IEnumerator Prepare()
        //		{
        //			if (this.mLoadData == null)
        //			{
        //				yield break;
        //			}
        //			for (int pos = 0; pos < this.mLoadData.Length; pos++)
        //			{
        //				IItem curItem = ItemManager.GetInstance().GetItem(this.mLoadData[pos]);
        //				if (curItem != null)
        //				{
        //					curItem = ItemManager.GetInstance().GetItem(this.mLoadData[pos]);
        //					this.Link(curItem);
        //				}
        //				else
        //				{
        //					Debug.LogError("ItemGroup error : " + this.mLoadData[pos].ToString() + " not exist");
        //				}
        //			}
        //			this.mIsInitialized = true;
        //			yield break;
        //		}

        //		// Token: 0x06003019 RID: 12313 RVA: 0x0015F9B4 File Offset: 0x0015DBB4
        //		public bool ForEachItemInGroup(Func<IItem, bool> myfun)
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

        //		// Token: 0x0600301A RID: 12314 RVA: 0x0015FA30 File Offset: 0x0015DC30
        //		public bool IsInGroup(IItem curItem)
        //		{
        //			return this.mItems.ContainsKey(curItem.ID);
        //		}

        //		// Token: 0x0600301B RID: 12315 RVA: 0x0015FA4C File Offset: 0x0015DC4C
        //		public void Link(IItem curItem)
        //		{
        //			this.mItems[curItem.ID] = curItem;
        //			int num = curItem.OwnerGroup.BinarySearch(this);
        //			if (num < 0)
        //			{
        //				curItem.OwnerGroup.Insert(~num, this);
        //			}
        //		}

        //		// Token: 0x0600301C RID: 12316 RVA: 0x0015FA90 File Offset: 0x0015DC90
        //		public void UnLink(IItem curItem)
        //		{
        //			this.mItems.Remove(curItem.ID);
        //			int num = curItem.OwnerGroup.BinarySearch(this);
        //			if (num >= 0)
        //			{
        //				curItem.OwnerGroup.RemoveAt(num);
        //			}
        //		}

        //		// Token: 0x0600301D RID: 12317 RVA: 0x0015FAD0 File Offset: 0x0015DCD0
        //		public void Save(BinaryWriter writer)
        //		{
        //			writer.Write(this.mID);
        //			writer.Write(this.mItems.Count);
        //			foreach (KeyValuePair<uint, IItem> keyValuePair in this.mItems)
        //			{
        //				writer.Write(keyValuePair.Value.ID);
        //			}
        //		}

        //		// Token: 0x0600301E RID: 12318 RVA: 0x0015FB60 File Offset: 0x0015DD60
        //		public void RemoveAll()
        //		{
        //			IItem[] array = new IItem[this.mItems.Count];
        //			int num = 0;
        //			foreach (KeyValuePair<uint, IItem> keyValuePair in this.mItems)
        //			{
        //				array[num] = keyValuePair.Value;
        //				num++;
        //			}
        //			foreach (IItem curItem in array)
        //			{
        //				this.UnLink(curItem);
        //			}
        //		}

        //		// Token: 0x04002BB5 RID: 11189
        //		private readonly string mID;

        //		// Token: 0x04002BB6 RID: 11190
        //		private Dictionary<uint, IItem> mItems = new Dictionary<uint, IItem>();

        //		// Token: 0x04002BB7 RID: 11191
        //		private uint[] mLoadData;

        //		// Token: 0x04002BB8 RID: 11192
        //		private bool mIsInitialized;
    }
}
