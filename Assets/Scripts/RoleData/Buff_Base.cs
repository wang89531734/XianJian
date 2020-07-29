using System;
using UnityEngine;

public abstract class Buff_Base
{
	public M_Character m_SourceCharacter;

	public M_Character m_TargetCharacter;

	public S_BufferData m_BuffData;

	public GameObject m_BuffEffect;

	public int m_RemainingRound;

	public Enum_BuffEffectStatus m_BuffEffectStatus;

	public Buff_Base(S_BufferData buffData)
	{
		this.m_BuffData = buffData;
		this.ResetRound();
	}

	public virtual Texture2D GetBuffIcon()
	{
		return ImageGenerator.CreateImage("Skin/03_other/", this.m_BuffData.IconNo);
	}

	public virtual void ResetRound()
	{
		if (this.m_BuffData == null)
		{
			return;
		}
		this.m_RemainingRound = this.m_BuffData.Round;
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

	public void SetCharacter(M_Character Source, M_Character Target)
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
		this.m_BuffEffect = EffectGenerator.CreateEffectGameObject(this.m_BuffData.EffectName);
		if (this.m_BuffEffect == null)
		{
			return;
		}
		this.m_BuffEffect.name = this.m_BuffData.EffectName;
		Transform transform = TransformTool.SearchHierarchyForBone(this.m_TargetCharacter.m_ModelTransform, this.m_BuffData.EffectPoint);
		if (transform == null)
		{
			this.m_BuffEffect.transform.position = this.m_TargetCharacter.m_ModelTransform.position;
			this.m_BuffEffect.transform.parent = this.m_TargetCharacter.m_ModelTransform;
		}
		else
		{
			this.m_BuffEffect.transform.position = transform.position;
			this.m_BuffEffect.transform.parent = transform;
		}
		TransformTool.SetLayerRecursively(this.m_BuffEffect.transform, 14);
	}

	protected void RemoveBuffEffect()
	{
		if (this.m_BuffEffect == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_BuffEffect);
	}

	public virtual void ExecutePerRound()
	{
		this.m_RemainingRound--;
		if (this.m_RemainingRound == 0)
		{
			this.Finish();
		}
	}

	public virtual void Finish()
	{
		UI_Fight.Instance.HideBuffTip();
		this.RemoveBuffEffect();
		this.m_TargetCharacter.StartCoroutine(this.m_TargetCharacter.RemoveBuff(this.m_BuffData.GroupID));
		if (this.m_BuffData.EndCallID <= 0)
		{
			return;
		}
		if (UnityEngine.Random.Range(1, 101) > this.m_BuffData.EndCallRate)
		{
			return;
		}
		S_Skill data = GameDataDB.SkillDB.GetData(this.m_BuffData.EndCallID);
		if (data == null)
		{
			return;
		}
		if (this.m_TargetCharacter.m_FightCommands.Count > 0)
		{
			this.m_TargetCharacter.selfCommandIndex = this.m_TargetCharacter.m_FightCommands.Peek().selfIndex;
			this.m_TargetCharacter.m_FightCommands.Clear();
		}
		if (data.emSkillEffectType == ENUM_SkillEffectType.SuperSkill && this.m_TargetCharacter is M_Player)
		{
			FightCommand fightCommand = new Command_SuperSkill(this.m_BuffData.EndCallID);
			fightCommand.SetActor(this.m_TargetCharacter);
			if (data.UseEffect.emRange == ENUM_UseRange.One)
			{
				if (data.UseEffect.emTarget == ENUM_UseTarget.Enemy)
				{
					fightCommand.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Monster());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Partner)
				{
					fightCommand.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Player());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Self)
				{
					fightCommand.SetTarget(this.m_TargetCharacter);
				}
			}
			this.m_TargetCharacter.AddCommand(fightCommand);
		}
		if (data.emSkillEffectType == ENUM_SkillEffectType.Skill && this.m_TargetCharacter is M_Player)
		{
			FightCommand fightCommand2 = new Command_Skill(this.m_BuffData.EndCallID);
			fightCommand2.SetActor(this.m_TargetCharacter);
			if (data.UseEffect.emRange == ENUM_UseRange.One)
			{
				if (data.UseEffect.emTarget == ENUM_UseTarget.Enemy)
				{
					fightCommand2.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Monster());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Partner)
				{
					fightCommand2.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Player());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Self)
				{
					fightCommand2.SetTarget(this.m_TargetCharacter);
				}
			}
			this.m_TargetCharacter.AddCommand(fightCommand2);
		}
		if (data.emSkillEffectType == ENUM_SkillEffectType.Skill && this.m_TargetCharacter is M_Monster)
		{
			FightCommand fightCommand3 = new Command_Skill(this.m_BuffData.EndCallID);
			fightCommand3.SetActor(this.m_TargetCharacter);
			if (data.UseEffect.emRange == ENUM_UseRange.One)
			{
				if (data.UseEffect.emTarget == ENUM_UseTarget.Enemy)
				{
					fightCommand3.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Player());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Partner)
				{
					fightCommand3.SetTarget(UI_Fight.Instance.m_FightSceneManager.GetTarget_Monster());
				}
				else if (data.UseEffect.emTarget == ENUM_UseTarget.Self)
				{
					fightCommand3.SetTarget(this.m_TargetCharacter);
				}
			}
			this.m_TargetCharacter.AddCommand(fightCommand3);
		}
	}

	public virtual void Relieve()
	{
		UI_Fight.Instance.HideBuffTip();
		this.RemoveBuffEffect();
		this.m_TargetCharacter.StartCoroutine(this.m_TargetCharacter.RemoveBuff(this.m_BuffData.GroupID));
	}

	public virtual void Replaced()
	{
		UI_Fight.Instance.HideBuffTip();
		this.RemoveBuffEffect();
	}
}
