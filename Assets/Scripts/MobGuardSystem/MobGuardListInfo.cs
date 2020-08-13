using System;

public class MobGuardListInfo : IComparable<MobGuardListInfo>
{
	public int ID;

	public int SoulPoint;

	public int Match;

	public int Level;

	public int Attack;

	public int Def;

	public int Agi;

	public int CompareTo(MobGuardListInfo obj)
	{
		return this.ID.CompareTo(obj.ID);
	}

	public int CompareTo(MobGuardListInfo p, MobGuardSortFields field)
	{
		switch (field)
		{
		case MobGuardSortFields.ID:
			return this.ID.CompareTo(p.ID);
		case MobGuardSortFields.SOULPOINT:
			return this.SoulPoint.CompareTo(p.SoulPoint);
		case MobGuardSortFields.MATCH:
			return this.Match.CompareTo(p.Match);
		case MobGuardSortFields.LEVEL:
			return this.Level.CompareTo(p.Level);
		case MobGuardSortFields.ATTACK:
			return this.Attack.CompareTo(p.Attack);
		case MobGuardSortFields.DEF:
			return this.Def.CompareTo(p.Def);
		case MobGuardSortFields.AGI:
			return this.Agi.CompareTo(p.Agi);
		default:
			return this.ID.CompareTo(p.ID);
		}
	}
}
