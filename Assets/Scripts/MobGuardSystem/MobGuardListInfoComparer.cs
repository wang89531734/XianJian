using System;
using System.Collections.Generic;

public class MobGuardListInfoComparer : IComparer<MobGuardListInfo>
{
	public MobGuardSortFields Field
	{
		get;
		set;
	}

	public MobGuardSortOrder Order
	{
		get;
		set;
	}

	public MobGuardListInfoComparer(MobGuardSortFields field, MobGuardSortOrder order)
	{
		this.Field = field;
		this.Order = order;
	}

	public int Compare(MobGuardListInfo p1, MobGuardListInfo p2)
	{
		if (this.Order == MobGuardSortOrder.Ascending)
		{
			return p1.CompareTo(p2, this.Field);
		}
		return p2.CompareTo(p1, this.Field);
	}
}
