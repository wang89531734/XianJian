using System;

public class S_RoleAttr_Finial
{
	public int MaxHP;

	public int MaxMP;

	public int MaxAP;

	public int Str;

	public int Mag;

	public int Sta;

	public int Air;

	public int Agi;

	public int Block;

	public int Luck;

	public int Critical;

	public int Mind;

	public int[] Element;

	public int[] AtkElement;

	public int Attack;

	public int Def;

	public S_RoleAttr_Finial()
	{
		this.Element = new int[6];
		this.AtkElement = new int[6];
	}

	public static S_RoleAttr_Finial operator +(S_RoleAttr_Finial a, S_RoleAttr_Finial b)
	{
		S_RoleAttr_Finial s_RoleAttr_Finial = new S_RoleAttr_Finial();
		s_RoleAttr_Finial.MaxHP = a.MaxHP + b.MaxHP;
		s_RoleAttr_Finial.MaxMP = a.MaxMP + b.MaxMP;
		s_RoleAttr_Finial.MaxAP = a.MaxAP + b.MaxAP;
		s_RoleAttr_Finial.Str = a.Str + b.Str;
		s_RoleAttr_Finial.Mag = a.Mag + b.Mag;
		s_RoleAttr_Finial.Sta = a.Sta + b.Sta;
		s_RoleAttr_Finial.Air = a.Air + b.Air;
		s_RoleAttr_Finial.Mind = a.Mind + b.Mind;
		s_RoleAttr_Finial.Agi = a.Agi + b.Agi;
		s_RoleAttr_Finial.Block = a.Block + b.Block;
		s_RoleAttr_Finial.Luck = a.Luck + b.Luck;
		s_RoleAttr_Finial.Critical = a.Critical + b.Critical;
		for (int i = 0; i < 6; i++)
		{
			s_RoleAttr_Finial.Element[i] = a.Element[i] + b.Element[i];
			s_RoleAttr_Finial.AtkElement[i] = a.AtkElement[i] + b.AtkElement[i];
		}
		s_RoleAttr_Finial.Attack = a.Attack + b.Attack;
		s_RoleAttr_Finial.Def = a.Def + b.Def;
		return s_RoleAttr_Finial;
	}

	public static S_RoleAttr_Finial operator -(S_RoleAttr_Finial a, S_RoleAttr_Finial b)
	{
		S_RoleAttr_Finial s_RoleAttr_Finial = new S_RoleAttr_Finial();
		s_RoleAttr_Finial.MaxHP = a.MaxHP - b.MaxHP;
		s_RoleAttr_Finial.MaxMP = a.MaxMP - b.MaxMP;
		s_RoleAttr_Finial.MaxAP = a.MaxAP - b.MaxAP;
		s_RoleAttr_Finial.Str = a.Str - b.Str;
		s_RoleAttr_Finial.Mag = a.Mag - b.Mag;
		s_RoleAttr_Finial.Sta = a.Sta - b.Sta;
		s_RoleAttr_Finial.Air = a.Air - b.Air;
		s_RoleAttr_Finial.Mind = a.Mind - b.Mind;
		s_RoleAttr_Finial.Agi = a.Agi - b.Agi;
		s_RoleAttr_Finial.Block = a.Block - b.Block;
		s_RoleAttr_Finial.Luck = a.Luck - b.Luck;
		s_RoleAttr_Finial.Critical = a.Critical - b.Critical;
		for (int i = 0; i < 6; i++)
		{
			s_RoleAttr_Finial.Element[i] = a.Element[i] - b.Element[i];
			s_RoleAttr_Finial.AtkElement[i] = a.AtkElement[i] - b.AtkElement[i];
		}
		s_RoleAttr_Finial.Attack = a.Attack - b.Attack;
		s_RoleAttr_Finial.Def = a.Def - b.Def;
		return s_RoleAttr_Finial;
	}
}
