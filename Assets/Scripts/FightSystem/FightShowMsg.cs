using System;
using UnityEngine;

public class FightShowMsg
{
	public Enum_FightHitType m_emMsgType;

	public int m_MsgValue;

	public void SetValue(float value)
	{
		value += 0.1f;
		this.m_MsgValue = Mathf.RoundToInt(value);
	}
}
