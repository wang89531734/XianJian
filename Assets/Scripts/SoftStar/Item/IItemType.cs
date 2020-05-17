using System;
using System.IO;

namespace SoftStar.Item
{
	public interface IItemType
	{
		uint TypeID { get; }

		Type InstanceType { get; }

		IItem Create();

		IItem Create(BinaryReader reader);

		IItem CloneWithoutEvent(IItem source);

		void SaveUserData(BinaryWriter writer, IItem target);
	}
}
