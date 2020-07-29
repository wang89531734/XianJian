using System;
using System.Collections.Generic;

public class S_MobData
{
	public string PrefName;

	public string ShowName;

	public int Level;

	public ENUM_MobRace emRace;

	public ENUM_MobType emType;

	public int Job;

	public int Sex;

	public int CanCatch;

	public int CanShow;

	public int CanSteal;

	public int ShowFlag;

	public int CostSoulPoint;

	public ENUM_ElementType emElemnt;

	public int DieAway;

	public int AttackRang;

	public int MaxHP;

	public int MaxMP;

	public int Attack;

	public int Def;

	public int Agi;

	public int Block;

	public int Stable;

	public int Critical;

	public int Weak;

	public int Luck;

	public int Mind;

	public ENUM_ElementType emAtkElemnt;

	public int AI;

	public int AttrPlugID;

	public int Figure;

	public int[] DefElement;

	public List<int> AttackEffect;

	public int CriticalEffect;

	public List<int> Skill;

	public List<int> SkillRate;

	public List<int> SkillLastHP;

	public List<int> SkillCount;

	public List<S_DropItem> DropItem;

	public int GetExp;

	public int GetMoney;

	public S_MobData()
	{
		this.DefElement = new int[6];
		this.AttackEffect = new List<int>();
		this.Skill = new List<int>();
		this.SkillRate = new List<int>();
		this.SkillLastHP = new List<int>();
		this.SkillCount = new List<int>();
		this.DropItem = new List<S_DropItem>();
	}
}
