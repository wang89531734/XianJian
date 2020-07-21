using System;
using UnityEngine;

public abstract class Buff_Base
{
	public M_Character m_SourceCharacter;

	public M_Character m_TargetCharacter;

	public S_BufferData m_BuffData;

	public GameObject m_BuffEffect;

	public float m_RemainingTime;

	public float m_ExecutionTimer;

	public Buff_Base(S_BufferData buffData)
	{
		this.m_BuffData = buffData;
		this.ResetRound();
	}

	public virtual void ResetRound()
	{
		if (this.m_BuffData == null)
		{
			return;
		}
		this.m_RemainingTime = this.m_BuffData.Time;
		this.m_ExecutionTimer = this.m_BuffData.Period;
	}

	public virtual void DoRoleAttrPlus(S_RoleAttr roleAttr)
	{
		S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(this.m_BuffData.RoleAttrPlusID);
		if (data == null)
		{
			return;
		}
		roleAttr.sAttrPlus += data.RoleAttr_Plus;
	}

	public virtual void SetCharacter(M_Character Source, M_Character Target)
	{
		this.m_SourceCharacter = Source;
		this.m_TargetCharacter = Target;
	}

	public virtual void Begin()
	{
		this.CreateBuffEffect();
	}

	protected void CreateBuffEffect()
	{
		if (this.m_BuffData.EffectName == null)
		{
			return;
		}
		this.m_BuffEffect = EffectSystem.Instance.CreateEffect(this.m_TargetCharacter.m_ModelTransform, this.m_BuffData.EffectPoint, this.m_BuffData.EffectName, true, true);
		if (this.m_BuffEffect == null)
		{
			return;
		}
		this.m_BuffEffect.name = this.m_BuffData.EffectName;
		TransformTool.SetLayerRecursively(this.m_BuffEffect.transform, 11);
	}

	protected void RemoveBuffEffect()
	{
		if (this.m_BuffEffect == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_BuffEffect);
	}

	public virtual void Update()
	{
		if (this.m_BuffData.Time > 0f)
		{
			this.m_RemainingTime -= Time.deltaTime;
		}
		this.m_ExecutionTimer -= Time.deltaTime;
		if (this.m_ExecutionTimer <= 0f)
		{
			this.Execute();
			this.m_ExecutionTimer += this.m_BuffData.Period;
		}
	}

	public virtual void Execute()
	{
		if (this.m_RemainingTime <= 0f && this.m_BuffData.Time > 0f)
		{
			this.Finish();
		}
	}

	public virtual void Finish()
	{
		this.RemoveBuffEffect();
		if (this.m_TargetCharacter != null && this.m_TargetCharacter.m_RoleModel.activeSelf)
		{
			this.m_TargetCharacter.StartCoroutine(this.m_TargetCharacter.RemoveBuff(this.m_BuffData.GroupID));
		}
		if (this.m_BuffData.EndCallID <= 0)
		{
			return;
		}
		int num = UnityEngine.Random.Range(1, 101);
		if (num > this.m_BuffData.EndCallRate)
		{
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(this.m_BuffData.EndCallID);
		if (data == null)
		{
			return;
		}
		S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
		if (data2 == null)
		{
			return;
		}
		M_Character m_Character = null;
		if (data2.emTarget == ENUM_UseTarget.Enemy)
		{
			if (this.m_SourceCharacter is M_Player || this.m_SourceCharacter is M_Guard)
			{
				if (this.m_TargetCharacter is M_Mob)
				{
					m_Character = this.m_TargetCharacter;
				}
			}
			else if (this.m_TargetCharacter is M_Player)
			{
				m_Character = this.m_TargetCharacter;
			}
		}
		else
		{
			m_Character = this.m_SourceCharacter;
		}
		if (m_Character == null)
		{
			return;
		}
		FightCommand fightCommand;
		if (data2.ActDataName == null || data2.ActDataName == "0")
		{
			fightCommand = new FightCommand_NoActDataSkill(this.m_SourceCharacter, m_Character, this.m_BuffData.EndCallID);
		}
		else
		{
			fightCommand = new FightCommand_EndCallSkill(this.m_SourceCharacter, m_Character, this.m_BuffData.EndCallID);
		}
		if (fightCommand != null)
		{
			this.m_SourceCharacter.DoCommand(fightCommand);
		}
	}

	public virtual void Relieve()
	{
		this.Finish();
	}

	public virtual void Remove()
	{
		this.RemoveBuffEffect();
		if (this.m_TargetCharacter != null && this.m_TargetCharacter.m_RoleModel.activeSelf)
		{
			this.m_TargetCharacter.StartCoroutine(this.m_TargetCharacter.RemoveBuff(this.m_BuffData.GroupID));
		}
	}
}
