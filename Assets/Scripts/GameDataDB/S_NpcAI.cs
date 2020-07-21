using System;
using System.Collections.Generic;
using UnityEngine;

public class S_NpcAI : I_BaseDBF
{
	public int GUID;

	public float MoveSpeed;

	public int MoveMotion;

	public int TurnMotion;

	public float StartIdleTime;

	public float EndIdleTime;

	public List<S_IdleMotion> IdleMotion = new List<S_IdleMotion>();

	public int emTalkMotion;

	public int emAutoTalkMotion;

	public int TalkOverMotion;

	public int RandWalk;

	public float RandWalkRange;

	public float RandWalkTime;

	public float AlertAngle;

	public float AlertMinRange;

	public float AlertMaxRange;

	public float FollowMinTime;

	public float FollowMaxTime;

	public int Follow;

	public int FollowMotion;

	public float FollowSpeed;

	public float RebornMaxTime;

	public int BattleID;

	public int Loop;

	public string MovePrefab;

	public int WaitMoveTime;

	public List<S_WayPoint> WayPoint = new List<S_WayPoint>();

	public List<int> WaitMotion = new List<int>();

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (Swd6Application.instance != null && Swd6Application.instance.m_DBFLog)
		{
			Debug.Log("NpcAI_" + this.GUID);
		}
		if (!(Record is S_NpcAI))
		{
			return;
		}
		Dictionary<string, string> dictionary = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		for (int i = 0; i < 2; i++)
		{
			S_IdleMotion s_IdleMotion = new S_IdleMotion();
			string key = string.Format("StartMotion_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_IdleMotion.StartMotion);
			}
			key = string.Format("EndMotion_{0}", i);
			if (dictionary.ContainsKey(key))
			{
				string s = dictionary[key];
				int.TryParse(s, out s_IdleMotion.EndMotion);
			}
			this.IdleMotion.Add(s_IdleMotion);
		}
		for (int j = 0; j < 3; j++)
		{
			int num = 0;
			string key2 = string.Format("WaitMotion_{0}", j);
			if (dictionary.ContainsKey(key2))
			{
				string s2 = dictionary[key2];
				int.TryParse(s2, out num);
			}
			if (num > 0)
			{
				this.WaitMotion.Add(num);
			}
		}
	}
}
