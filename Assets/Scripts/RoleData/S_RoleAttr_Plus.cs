using System;

public class S_RoleAttr_Plus
{
	public int AddMaxHP;

	public int AddMaxRatioHP;

	public int AddMaxMP;

	public int AddMaxRatioMP;

	public int AddMaxAP;

	public int AddMaxRatioAP;

	public int AddAttack;

	public int AddRatioAttack;

	public int AddDef;

	public int AddRatioDef;

	public int AddStr;

	public int AddRatioStr;

	public int AddMag;

	public int AddRatioMag;

	public int AddSta;

	public int AddRatioSta;

	public int AddAir;

	public int AddRatioAir;

	public int AddMind;

	public int AddRatioMind;

	public int AddAgi;

	public int AddRatioAgi;

	public int AddBlock;

	public int AddLuck;

	public int AddCritical;

	public int[] Element;

	public int[] ElementRatio;

	public int[] AtkElement;

	public int[] AtkElementRatio;

	public S_RoleAttr_Plus()
	{
		this.Element = new int[6];
		this.ElementRatio = new int[6];
		this.AtkElement = new int[6];
		this.AtkElementRatio = new int[6];
	}

	public static S_RoleAttr_Plus operator +(S_RoleAttr_Plus a, S_RoleAttr_Plus b)
	{
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		s_RoleAttr_Plus.AddMaxHP = a.AddMaxHP + b.AddMaxHP;
		s_RoleAttr_Plus.AddMaxRatioHP = a.AddMaxRatioHP + b.AddMaxRatioHP;
		s_RoleAttr_Plus.AddMaxMP = a.AddMaxMP + b.AddMaxMP;
		s_RoleAttr_Plus.AddMaxRatioMP = a.AddMaxRatioMP + b.AddMaxRatioMP;
		s_RoleAttr_Plus.AddMaxAP = a.AddMaxAP + b.AddMaxAP;
		s_RoleAttr_Plus.AddMaxRatioAP = a.AddMaxRatioAP + b.AddMaxRatioAP;
		s_RoleAttr_Plus.AddStr = a.AddStr + b.AddStr;
		s_RoleAttr_Plus.AddRatioStr = a.AddRatioStr + b.AddRatioStr;
		s_RoleAttr_Plus.AddMag = a.AddMag + b.AddMag;
		s_RoleAttr_Plus.AddRatioMag = a.AddRatioMag + b.AddRatioMag;
		s_RoleAttr_Plus.AddSta = a.AddSta + b.AddSta;
		s_RoleAttr_Plus.AddRatioSta = a.AddRatioSta + b.AddRatioSta;
		s_RoleAttr_Plus.AddAir = a.AddAir + b.AddAir;
		s_RoleAttr_Plus.AddRatioAir = a.AddRatioAir + b.AddRatioAir;
		s_RoleAttr_Plus.AddMind = a.AddMind + b.AddMind;
		s_RoleAttr_Plus.AddRatioMind = a.AddRatioMind + b.AddRatioMind;
		s_RoleAttr_Plus.AddAgi = a.AddAgi + b.AddAgi;
		s_RoleAttr_Plus.AddRatioAgi = a.AddRatioAgi + b.AddRatioAgi;
		s_RoleAttr_Plus.AddBlock = a.AddBlock + b.AddBlock;
		s_RoleAttr_Plus.AddLuck = a.AddLuck + b.AddLuck;
		s_RoleAttr_Plus.AddCritical = a.AddCritical + b.AddCritical;
		for (int i = 0; i < 6; i++)
		{
			s_RoleAttr_Plus.Element[i] = a.Element[i] + b.Element[i];
			s_RoleAttr_Plus.ElementRatio[i] = a.ElementRatio[i] + b.ElementRatio[i];
			s_RoleAttr_Plus.AtkElement[i] = a.AtkElement[i] + b.AtkElement[i];
			s_RoleAttr_Plus.AtkElementRatio[i] = a.AtkElementRatio[i] + b.AtkElementRatio[i];
		}
		s_RoleAttr_Plus.AddAttack = a.AddAttack + b.AddAttack;
		s_RoleAttr_Plus.AddRatioAttack = a.AddRatioAttack + b.AddRatioAttack;
		s_RoleAttr_Plus.AddDef = a.AddDef + b.AddDef;
		s_RoleAttr_Plus.AddRatioDef = a.AddRatioDef + b.AddRatioDef;
		return s_RoleAttr_Plus;
	}

	public static S_RoleAttr_Plus operator -(S_RoleAttr_Plus a, S_RoleAttr_Plus b)
	{
		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
		s_RoleAttr_Plus.AddMaxHP = a.AddMaxHP - b.AddMaxHP;
		s_RoleAttr_Plus.AddMaxRatioHP = a.AddMaxRatioHP - b.AddMaxRatioHP;
		s_RoleAttr_Plus.AddMaxMP = a.AddMaxMP - b.AddMaxMP;
		s_RoleAttr_Plus.AddMaxRatioMP = a.AddMaxRatioMP - b.AddMaxRatioMP;
		s_RoleAttr_Plus.AddMaxAP = a.AddMaxAP - b.AddMaxAP;
		s_RoleAttr_Plus.AddMaxRatioAP = a.AddMaxRatioAP - b.AddMaxRatioAP;
		s_RoleAttr_Plus.AddStr = a.AddStr - b.AddStr;
		s_RoleAttr_Plus.AddRatioStr = a.AddRatioStr - b.AddRatioStr;
		s_RoleAttr_Plus.AddMag = a.AddMag - b.AddMag;
		s_RoleAttr_Plus.AddRatioMag = a.AddRatioMag - b.AddRatioMag;
		s_RoleAttr_Plus.AddSta = a.AddSta - b.AddSta;
		s_RoleAttr_Plus.AddRatioSta = a.AddRatioSta - b.AddRatioSta;
		s_RoleAttr_Plus.AddAir = a.AddAir - b.AddAir;
		s_RoleAttr_Plus.AddRatioAir = a.AddRatioAir - b.AddRatioAir;
		s_RoleAttr_Plus.AddMind = a.AddMind - b.AddMind;
		s_RoleAttr_Plus.AddRatioMind = a.AddRatioMind - b.AddRatioMind;
		s_RoleAttr_Plus.AddAgi = a.AddAgi - b.AddAgi;
		s_RoleAttr_Plus.AddRatioAgi = a.AddRatioAgi - b.AddRatioAgi;
		s_RoleAttr_Plus.AddBlock = a.AddBlock - b.AddBlock;
		s_RoleAttr_Plus.AddLuck = a.AddLuck - b.AddLuck;
		s_RoleAttr_Plus.AddCritical = a.AddCritical - b.AddCritical;
		for (int i = 0; i < 6; i++)
		{
			s_RoleAttr_Plus.Element[i] = a.Element[i] - b.Element[i];
			s_RoleAttr_Plus.ElementRatio[i] = a.ElementRatio[i] - b.ElementRatio[i];
			s_RoleAttr_Plus.AtkElement[i] = a.AtkElement[i] - b.AtkElement[i];
			s_RoleAttr_Plus.AtkElementRatio[i] = a.AtkElementRatio[i] - b.AtkElementRatio[i];
		}
		s_RoleAttr_Plus.AddAttack = a.AddAttack - b.AddAttack;
		s_RoleAttr_Plus.AddRatioAttack = a.AddRatioAttack - b.AddRatioAttack;
		s_RoleAttr_Plus.AddDef = a.AddDef - b.AddDef;
		s_RoleAttr_Plus.AddRatioDef = a.AddRatioDef - b.AddRatioDef;
		return s_RoleAttr_Plus;
	}
}
