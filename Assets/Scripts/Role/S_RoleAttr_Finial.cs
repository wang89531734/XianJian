using System;

public class S_RoleAttr_Finial
{
	public int MaxHP;

	public int MaxMP;

	public int Attack;

	public int Def;

	public int MAttack;

	public int MDef;

	public int Agi;

	public int Block;

	public int Dodge;

	public int Critical;

	public int[] Element;

	public int[] AtkElement;

	public S_RoleAttr_Finial()
	{
		this.Element = new int[4];
		this.AtkElement = new int[4];
	}

	public static S_RoleAttr_Finial operator +(S_RoleAttr_Finial a, S_RoleAttr_Finial b)
	{
		S_RoleAttr_Finial s_RoleAttr_Finial = new S_RoleAttr_Finial();
		s_RoleAttr_Finial.MaxHP = a.MaxHP + b.MaxHP;
		s_RoleAttr_Finial.MaxMP = a.MaxMP + b.MaxMP;
		s_RoleAttr_Finial.Attack = a.Attack + b.Attack;
		s_RoleAttr_Finial.Def = a.Def + b.Def;
		s_RoleAttr_Finial.MAttack = a.MAttack + b.MAttack;
		s_RoleAttr_Finial.MDef = a.MDef + b.MDef;
		s_RoleAttr_Finial.Agi = a.Agi + b.Agi;
		s_RoleAttr_Finial.Block = a.Block + b.Block;
		s_RoleAttr_Finial.Dodge = a.Dodge + b.Dodge;
		s_RoleAttr_Finial.Critical = a.Critical + b.Critical;
		for (int i = 0; i < 4; i++)
		{
			s_RoleAttr_Finial.Element[i] = a.Element[i] + b.Element[i];
			s_RoleAttr_Finial.AtkElement[i] = a.AtkElement[i] + b.AtkElement[i];
		}
		return s_RoleAttr_Finial;
	}

	public static S_RoleAttr_Finial operator -(S_RoleAttr_Finial a, S_RoleAttr_Finial b)
	{
		S_RoleAttr_Finial s_RoleAttr_Finial = new S_RoleAttr_Finial();
		s_RoleAttr_Finial.MaxHP = a.MaxHP - b.MaxHP;
		s_RoleAttr_Finial.MaxMP = a.MaxMP - b.MaxMP;
		s_RoleAttr_Finial.Attack = a.Attack - b.Attack;
		s_RoleAttr_Finial.Def = a.Def - b.Def;
		s_RoleAttr_Finial.MAttack = a.MAttack - b.MAttack;
		s_RoleAttr_Finial.MDef = a.MDef - b.MDef;
		s_RoleAttr_Finial.Agi = a.Agi - b.Agi;
		s_RoleAttr_Finial.Block = a.Block - b.Block;
		s_RoleAttr_Finial.Dodge = a.Dodge - b.Dodge;
		s_RoleAttr_Finial.Critical = a.Critical - b.Critical;
		for (int i = 0; i < 4; i++)
		{
			s_RoleAttr_Finial.Element[i] = a.Element[i] - b.Element[i];
			s_RoleAttr_Finial.AtkElement[i] = a.AtkElement[i] - b.AtkElement[i];
		}
		return s_RoleAttr_Finial;
	}
}
