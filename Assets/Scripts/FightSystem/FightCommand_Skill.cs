using System;
using UnityEngine;

public class FightCommand_Skill : FightCommand
{
	public S_Skill m_SkillData;

	public FightCommand_Skill(M_Character a, M_Character t, int id) : base(a, t, id)
	{
        this.m_SkillData = GameDataDB.SkillDB.GetData(id);
        if (this.m_SkillData == null)
        {
            Debug.Log("找不到Skill 資料: " + id);
            return;
        }
        this.m_UseEffectID = this.m_SkillData.UseEffectID;
        this.m_UseEffect = GameDataDB.UseEffectDB.GetData(this.m_UseEffectID);
        if (this.m_UseEffect == null)
        {
            Debug.Log("找不到UseEffect : " + this.m_UseEffectID);
        }
    }

    /// <summary>
    /// 执行
    /// </summary>
	public override void Execute()
	{
        //if (this.m_UseEffect == null)
        //{
        //Debug.Log("找不到UseEffect : " + this.m_UseEffectID);
        //	this.OnAnimationFinish();
        //	return;
        //}
        base.ProcessActData(this.m_UseEffect.ActDataName);
        //bool bCritical = false;
        //this.m_HitDatas.Clear();
        foreach (M_Character current in this.m_Targets)
        {
            //FightDamageData fightDamageData = FightCalculate.DamageDataCalculte_Skill(this.m_Actor, current, this.m_UseEffect);
            //this.m_HitDatas.Add(current, fightDamageData);
            //if (fightDamageData.m_bCritical)
            //{
            //    bCritical = true;
            //}
        }
        //if (this.m_UseEffect.emUseSkillCamera == Enum_UseSkillCamera.Yes)
        //{
        //	FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
        //	if (fightState != null && fightState.m_FightSceneMgr != null)
        //	{
        //		fightState.m_FightSceneMgr.SetSkillCameraPath(this.m_Actor, this.m_UseEffect.SkillCameraData, bCritical);
        //	}
        //}
    }

    public override void OnAnimationFinish()
    {
        base.OnAnimationFinish();
        //this.EndSkill();
        //if (this.m_UseEffect == null || this.m_UseEffect.emItemType != ENUM_ItemSubType.Attack)
        //{
        //	return;
        //}
        //if (!(this.m_Actor is M_Player))
        //{
        //	return;
        //}
        //M_Player m_Player = this.m_Actor as M_Player;
        //if (m_Player.m_MagicItem_Passive != null && m_Player.m_MagicItem_Passive.m_EquipItem.ID == 719)
        //{
        //	if (!m_Player.m_MagicItem_Passive.IsTrigger())
        //	{
        //		return;
        //	}
        //	FightCommand_NoActDataSkill fightCommand_NoActDataSkill = new FightCommand_NoActDataSkill(this.m_Actor, this.m_Target, 719);
        //	if (fightCommand_NoActDataSkill == null)
        //	{
        //		return;
        //	}
        //	this.m_Actor.DoCommand(fightCommand_NoActDataSkill);
        //}
    }

    public virtual void EndSkill()
	{
		//if (this.m_SkillData == null)
		//{
		//	Debug.Log("OnAnimationFinish - 沒有 Skill 資料");
		//	return;
		//}
		//for (int i = 0; i < this.m_SkillData.CastCallList.Count; i++)
		//{
		//	S_SkillCastCall s_SkillCastCall = this.m_SkillData.CastCallList[i];
		//	if (s_SkillCastCall != null)
		//	{
		//		if (s_SkillCastCall.CastCallID != 0 && s_SkillCastCall.CastCallRate != 0)
		//		{
		//			int num = UnityEngine.Random.Range(1, 101);
		//			if (num <= s_SkillCastCall.CastCallRate)
		//			{
		//				S_Skill data = GameDataDB.SkillDB.GetData(s_SkillCastCall.CastCallID);
		//				if (data != null)
		//				{
		//					S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
		//					if (data2 != null)
		//					{
		//						if (this.m_Actor.CheckSkillCastBuff(data.CastBuffer))
		//						{
		//							M_Character m_Character = null;
		//							if (data2.emTarget == ENUM_UseTarget.Enemy)
		//							{
		//								if (this.m_Actor is M_Player || this.m_Actor is M_Guard)
		//								{
		//									if (this.m_Target is M_Mob)
		//									{
		//										m_Character = this.m_Target;
		//									}
		//								}
		//								else if (this.m_Actor is M_Player)
		//								{
		//									m_Character = this.m_Target;
		//								}
		//							}
		//							else
		//							{
		//								m_Character = this.m_Actor;
		//							}
		//							if (!(m_Character == null))
		//							{
		//								FightCommand fightCommand;
		//								if (data2.ActDataName == null || data2.ActDataName == "0")
		//								{
		//									fightCommand = new FightCommand_NoActDataSkill(this.m_Actor, m_Character, s_SkillCastCall.CastCallID);
		//								}
		//								else
		//								{
		//									fightCommand = new FightCommand_EndCallSkill(this.m_Actor, m_Character, s_SkillCastCall.CastCallID);
		//								}
		//								if (fightCommand != null)
		//								{
		//									this.m_Actor.DoCommand(fightCommand);
		//									break;
		//								}
		//							}
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}
		//}
	}
}
