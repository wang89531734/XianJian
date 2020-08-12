using System;
using System.Collections.Generic;

public class S_MobData
{
	public string PrefName;

	public string ShowName;

	public string ScriptName;

	public int Level;

	public ENUM_MobRace emRace;

	public ENUM_MobType emType;

	public int Job;

	public int Sex;

	public int CanCatch;

	public int CanShow;

	public int CanSteal;

	public int ShowFlag;

	public ENUM_ElementType emElemnt;

	public int DieAway;

	public float MoveTime;

	public int AttackRang;

	public int MaxHP;

	public int MaxMP;

	public int Attack;

	public int Def;

	public int MAtk;

	public int MDef;

	public int Block;

	public int Dodge;

	public int Critical;

	public int Agi;

	public ENUM_ElementType emAtkElemnt;

	public int AI;

	public int AttrPlugID;

	public int FormationAttrPlugID;

	public int Figure;

	public int[] DefElement;

	public List<int> AttackEffect;

	public int CriticalEffect;

	public List<int> NormalSkillID;

	public List<int> NormalSkillRate;

	public List<int> StartSkillID;

	public List<int> HpSkillID;

	public List<int> HpSkillHP;

	public int DeadSkillID;

	public int HitSkillID;

	public int HitSkillRate;

	public int HitSkillCount;

	public List<S_DropItem> DropItem;

	public int GetExp;

	public int GetMoney;

	public S_MobData()
	{
		this.DefElement = new int[4];
		this.AttackEffect = new List<int>();
		this.DropItem = new List<S_DropItem>();
		this.NormalSkillID = new List<int>();
		this.NormalSkillRate = new List<int>();
		this.StartSkillID = new List<int>();
		this.HpSkillID = new List<int>();
		this.HpSkillHP = new List<int>();
	}
}
