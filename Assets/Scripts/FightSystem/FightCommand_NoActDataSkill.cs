using System;
using System.Collections.Generic;
using UnityEngine;

public class FightCommand_NoActDataSkill : FightCommand_Skill
{
	public FightCommand_NoActDataSkill(M_Character a, M_Character t, int id) : base(a, t, id)
	{
	}

	public override void Execute()
	{
		if (this.m_UseEffect == null)
		{
			Debug.Log("找不到UseEffect : " + this.m_UseEffectID);
			this.OnAnimationFinish();
			return;
		}
		this.m_HitDatas.Clear();
		foreach (M_Character current in this.m_Targets)
		{
			//FightDamageData value = FightCalculate.DamageDataCalculte_Skill(this.m_Actor, current, this.m_UseEffect);
			//this.m_HitDatas.Add(current, value);
		}
		this.OnHitDamage();
		this.OnAnimationFinish();
	}

	public override void OnHitDamage()
	{
		foreach (KeyValuePair<M_Character, FightDamageData> current in this.m_HitDatas)
		{
			FightDamageData value = current.Value;
			if (value != null)
			{
				M_Character key = current.Key;
				if (!(key == null))
				{
					if (key.gameObject.activeInHierarchy)
					{
						for (int i = 0; i < value.m_HitList.Count; i++)
						{
							//current.Key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
							//if (value.m_DoubleDmg)
							//{
							//	current.Key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
							//}
						}
					}
				}
			}
		}
		//this.OnLastHit();
	}

	public override void OnAnimationFinish()
	{
		this.EndSkill();
	}
}
