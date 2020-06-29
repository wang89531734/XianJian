using System;

namespace SoftStar.Item
{
    /// <summary>
    /// 物品ID
    /// </summary>
	[Serializable]
	public class ItemD
	{
        /// <summary>
        /// 母物体ID
        /// </summary>
		public int ParentID;

        /// <summary>
        /// 子物体ID
        /// </summary>
		public int ChildID;

        /// <summary>
        /// 数量
        /// </summary>
		public int Number;
	}
}
