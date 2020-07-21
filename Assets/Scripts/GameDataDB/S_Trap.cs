using System;
using UnityEngine;

public class S_Trap : I_BaseDBF
{
	public int GUID;

	public ENUM_TrapType emType;

	public string SpawnName;

	public string MoveEndName;

	public float SpawnTime;

	public float LifeTime;

	public float MoveSpeed;

	public float MoveDistance;

	public float TurnAngle;

	public float TurnAngleTime;

	public int MsgID;

	public float TriggerTime;

	public int Avoid;

	public int AvoidItemID;

	public int Move;

	public int CostHP;

	public int CostMoney;

	public float CostPerSecond;

	public int SlowMove;

	public int Reverse;

	public int Dark;

	public int HealAll;

	public int ShootTargetID;

	public float HSliderSpeed;

	public float VSliderSpeed;

	public int FailTime;

	public int FinishFlag;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		
	}
}
