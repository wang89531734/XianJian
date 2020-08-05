using System;

public class S_RoleAttr_Plus
{
	public int AddMaxHP;

	public int AddMaxRatioHP;

	public int AddMaxMP;

	public int AddMaxRatioMP;

	public int AddAttack;

	public int AddRatioAttack;

	public int AddDef;

	public int AddRatioDef;

	public int AddMAtk;

	public int AddRatioMAtk;

	public int AddMDef;

	public int AddRatioMDef;

	public int AddAgi;

	public int AddBlock;

	public int AddDodge;

	public int AddCritical;

	public int[] Element;

	public int[] AtkElement;

	public S_RoleAttr_Plus()
	{
		this.Element = new int[4];
		this.AtkElement = new int[4];
	}

	public static S_RoleAttr_Plus operator +(S_RoleAttr_Plus a, S_RoleAttr_Plus b)
	{
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		s_RoleAttr_Plus.AddMaxHP = a.AddMaxHP + b.AddMaxHP;
		s_RoleAttr_Plus.AddMaxRatioHP = a.AddMaxRatioHP + b.AddMaxRatioHP;
		s_RoleAttr_Plus.AddMaxMP = a.AddMaxMP + b.AddMaxMP;
		s_RoleAttr_Plus.AddMaxRatioMP = a.AddMaxRatioMP + b.AddMaxRatioMP;
		s_RoleAttr_Plus.AddAttack = a.AddAttack + b.AddAttack;
		s_RoleAttr_Plus.AddRatioAttack = a.AddRatioAttack + b.AddRatioAttack;
		s_RoleAttr_Plus.AddDef = a.AddDef + b.AddDef;
		s_RoleAttr_Plus.AddRatioDef = a.AddRatioDef + b.AddRatioDef;
		s_RoleAttr_Plus.AddMAtk = a.AddMAtk + b.AddMAtk;
		s_RoleAttr_Plus.AddRatioMAtk = a.AddRatioMAtk + b.AddRatioMAtk;
		s_RoleAttr_Plus.AddMDef = a.AddMDef + b.AddMDef;
		s_RoleAttr_Plus.AddRatioMDef = a.AddRatioMDef + b.AddRatioMDef;
		s_RoleAttr_Plus.AddAgi = a.AddAgi + b.AddAgi;
		s_RoleAttr_Plus.AddBlock = a.AddBlock + b.AddBlock;
		s_RoleAttr_Plus.AddDodge = a.AddDodge + b.AddDodge;
		s_RoleAttr_Plus.AddCritical = a.AddCritical + b.AddCritical;
		for (int i = 0; i < 4; i++)
		{
			s_RoleAttr_Plus.Element[i] = a.Element[i] + b.Element[i];
			s_RoleAttr_Plus.AtkElement[i] = a.AtkElement[i] + b.AtkElement[i];
		}
		return s_RoleAttr_Plus;
	}

	public static S_RoleAttr_Plus operator -(S_RoleAttr_Plus a, S_RoleAttr_Plus b)
	{
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		s_RoleAttr_Plus.AddMaxHP = a.AddMaxHP - b.AddMaxHP;
		s_RoleAttr_Plus.AddMaxRatioHP = a.AddMaxRatioHP - b.AddMaxRatioHP;
		s_RoleAttr_Plus.AddMaxMP = a.AddMaxMP - b.AddMaxMP;
		s_RoleAttr_Plus.AddMaxRatioMP = a.AddMaxRatioMP - b.AddMaxRatioMP;
		s_RoleAttr_Plus.AddAttack = a.AddAttack - b.AddAttack;
		s_RoleAttr_Plus.AddRatioAttack = a.AddRatioAttack - b.AddRatioAttack;
		s_RoleAttr_Plus.AddDef = a.AddDef - b.AddDef;
		s_RoleAttr_Plus.AddRatioDef = a.AddRatioDef - b.AddRatioDef;
		s_RoleAttr_Plus.AddMAtk = a.AddMAtk - b.AddMAtk;
		s_RoleAttr_Plus.AddRatioMAtk = a.AddRatioMAtk - b.AddRatioMAtk;
		s_RoleAttr_Plus.AddMDef = a.AddMDef - b.AddMDef;
		s_RoleAttr_Plus.AddRatioMDef = a.AddRatioMDef - b.AddRatioMDef;
		s_RoleAttr_Plus.AddAgi = a.AddAgi - b.AddAgi;
		s_RoleAttr_Plus.AddBlock = a.AddBlock - b.AddBlock;
		s_RoleAttr_Plus.AddDodge = a.AddDodge - b.AddDodge;
		s_RoleAttr_Plus.AddCritical = a.AddCritical - b.AddCritical;
		for (int i = 0; i < 4; i++)
		{
			s_RoleAttr_Plus.Element[i] = a.Element[i] - b.Element[i];
			s_RoleAttr_Plus.AtkElement[i] = a.AtkElement[i] - b.AtkElement[i];
		}
		return s_RoleAttr_Plus;
	}
}
