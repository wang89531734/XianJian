using System;

public class S_BufferData : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int IconNo;

	public string EffectName;

	public string EffectPoint;

	public int GroupID;

	public ENUM_BuffType emBuffType;

	public ENUM_BuffCalTime emCalTime;

	public ENUM_BuffRemove emBuffRemove;

	public ENUM_ElementType emElementType;

	public ENUM_BuffIncreased emBuffIncreased;

	public int Level;

	public float Time;

	public float Period;

	public ENUM_RefValue emRefValue;

	public int AbsortDmg;

	public int ReflexDmg;

	public int TransferDmg;

	public int TransferDmgToMP;

	public int ReduceDmg;

	public int AddHP;

	public int AddMP;

	public int AddAP;

	public int CostDown;

	public int AddDodgeRate;

	public int AddHitRate;

	public int EndCallID;

	public int EndCallRate;

	public int RoleAttrPlusID;

	public string Tip;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
		this.Tip = GameDataDB.TransStringByLanguageType(this.Tip);
	}
}
