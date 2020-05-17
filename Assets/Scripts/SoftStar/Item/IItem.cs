using System;
using System.Collections;
using System.Collections.Generic;

namespace SoftStar.Item
{
	public interface IItem
	{
        /// <summary>
        /// 所属背包
        /// </summary>
		ItemPackage OwnerPackage { get; set; }

        /// <summary>
        /// 所属组
        /// </summary>
        List<ItemGroup> OwnerGroup { get; }

        IItemType ItemType { get; }

		uint ID { get; }

		IEnumerator Prepare();

		Dictionary<string, byte[]> UserDefinedData { get; }

		bool IsInitialized { get; set; }
	}
}
