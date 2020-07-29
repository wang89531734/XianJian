using System;

public class SkillInfo : IComparable<SkillInfo>
{
	public int GUID
	{
		get;
		set;
	}

	public int ID
	{
		get;
		set;
	}

	public int Level
	{
		get;
		set;
	}

	public int CompareTo(SkillInfo obj)
	{
		return this.ID.CompareTo(obj.ID);
	}

	public int CompareTo(SkillInfo p, SkillSortFields field)
	{
		switch (field)
		{
		case SkillSortFields.ID:
			return this.ID.CompareTo(p.ID);
		case SkillSortFields.LEVEL:
			return this.Level.CompareTo(p.Level);
		default:
			return this.ID.CompareTo(p.ID);
		}
	}
}
