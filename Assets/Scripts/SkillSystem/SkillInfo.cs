using System;

[Serializable]
public class SkillInfo : IComparable<SkillInfo>
{
	public int ID;

	public int PreID;

	public int LearnTime;

	public int MaxLearnTime;

	public int LearnPoint;

	public int ActivePoint;

	public int Group;

	public SphereType Type;

	public int CompareTo(SkillInfo obj)
	{
		return this.ID.CompareTo(obj.ID);
	}

	public int CompareTo(SkillInfo p, SkillSortFields field)
	{
		if (field != SkillSortFields.ID)
		{
			return this.ID.CompareTo(p.ID);
		}
		return this.ID.CompareTo(p.ID);
	}
}
