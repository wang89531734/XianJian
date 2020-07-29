using System;

[Serializable]
public class ItemData
{
	public int Order;

	public int SerialID;

	public int ID;

	public int Count;

	public bool New;

	public float GetTime;

	public ENUM_GradeType Grade;

	public int GradeNumber;

	public bool Equip;

	public int EquipCount;

	public int MaxRefineSoul;

	public int[] RefineSoul;

	public ItemData()
	{
		this.RefineSoul = new int[3];
	}
}
