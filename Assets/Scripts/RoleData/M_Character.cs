using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class M_Character : MonoBehaviour
{
    public delegate void UpdateBuffIcon();

    //	public enum Enum_CharacterStatus
    //	{
    //		None,
    //		Appear,
    //		StandBy,
    //		Attack,
    //		Critical,
    //		Defense,
    //		Hit,
    //		Exclude,
    //		Dodge,
    //		Assist,
    //		BeAssisted,
    //		StrikeBack,
    //		Block,
    //		Dead,
    //		Escape,
    //		TryEscape,
    //		Catch,
    //		Revive,
    //		Move
    //	}

    //	public enum Enum_SelectStatus
    //	{
    //		None,
    //		WaitSeclect,
    //		Selected,
    //		Lock
    //	}

    //	public M_Character.UpdateBuffIcon UpdateBuffIconCallback;

    //	public Queue<ShowDamageData> ShowDamageDataQueue = new Queue<ShowDamageData>();

    //	public int m_PositionID;

    //	public int m_RoleID;

    //	public string m_CharacterName;

    //	public FightSceneManager m_FightSceneManager;

    //	public FightCommandManager m_FightCommandManager;

    //	public HitPointDirection m_MiddleHitPointDirection;

    //	public HitPointDirection m_RightHitPointDirection;

    //	public HitPointDirection m_LeftHitPointDirection;

    //	public FightRoleData m_FightRoleData = new FightRoleData();

    //	public GameObject m_BornPoint;

    //	public Transform m_BornPointTransform;

    //	public float m_Energy;

    //	public float m_EnergyRate;

    //	private M_Character.Enum_CharacterStatus _characterStatus;

    //	public GameObject m_Model;

    //	public GameObject m_BodyRagdoll;

    //	public Transform m_ModelTransform;

    //	public Animation m_Animation;

    //	public M_Character m_AssistPartner;

    //	public M_Character m_LastTarget;

    //	public Dictionary<int, Buff_Base> m_Buffs;

    //	public List<Buff_Base> m_NoRemoveBuffs;

    //	public Queue<FightCommand> m_FightCommands;

    //	public int m_AttackEffectID;

    //	public int m_LastAttackeDamage;

    //	public int m_BeAttackedCount;

    //	private GameObject m_SelectEffect;

    //	public bool m_IsFight;

    //	public int selfCommandIndex;

    //	public GameObject m_DefenseEffect;

    //	public string SkillName = "";

    //	[SerializeField]
    //	public M_Character.Enum_CharacterStatus CharacterStatus
    //	{
    //		get
    //		{
    //			return this._characterStatus;
    //		}
    //		set
    //		{
    //			if (this._characterStatus != M_Character.Enum_CharacterStatus.Dead)
    //			{
    //				this._characterStatus = value;
    //			}
    //		}
    //	}

    //	public int GetSelfCommandIndex()
    //	{
    //		this.selfCommandIndex++;
    //		if (this.selfCommandIndex > 100000)
    //		{
    //			this.selfCommandIndex = 0;
    //		}
    //		return this.selfCommandIndex;
    //	}

    //	private void Awake()
    //	{
    //		this.m_Buffs = new Dictionary<int, Buff_Base>();
    //		this.m_NoRemoveBuffs = new List<Buff_Base>();
    //	}

    //	private void Start()
    //	{
    //		base.InvokeRepeating("ProcessShowDamageDataQueue", 0f, 0.3f);
    //	}

    //	public void Selected(bool isSelected)
    //	{
    //		if (isSelected)
    //		{
    //			if (!(this.m_SelectEffect == null))
    //			{
    //				this.m_SelectEffect.SetActive(isSelected);
    //				return;
    //			}
    //			this.m_SelectEffect = EffectGenerator.CreateEffectGameObject("common_14_select");
    //			if (this.m_SelectEffect != null)
    //			{
    //				this.m_SelectEffect.transform.position = this.m_BornPointTransform.position;
    //				return;
    //			}
    //		}
    //		else if (this.m_SelectEffect != null)
    //		{
    //			this.m_SelectEffect.SetActive(isSelected);
    //		}
    //	}

    //	public List<M_Character> GetPartners()
    //	{
    //		if (this.m_FightSceneManager == null)
    //		{
    //			return null;
    //		}
    //		return this.m_FightSceneManager.GetPartners(this);
    //	}

    //	public bool IsFearless()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (current != null && current is Buff_Fearless)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool IsLoseHeart()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (current != null && current is Buff_LoseHeart)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool CannotUseAnyCommand()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (current != null && current.m_BuffEffectStatus == Enum_BuffEffectStatus.CannotUseAnyCommand)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool CannotUseSkillCommand()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (current != null && current.m_BuffEffectStatus == Enum_BuffEffectStatus.CannotUseSkillCommand)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool CannotUseSuperSkillCommand()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (current != null && current.m_BuffEffectStatus == Enum_BuffEffectStatus.CannotUseSuperSkillCommand)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public void ShowModel()
    //	{
    //		RendererTool.EnableAllRenderers(this.m_Model, true);
    //	}

    //	public void HideModel()
    //	{
    //		RendererTool.EnableAllRenderers(this.m_Model, false);
    //	}

    //	public void DestroyModel()
    //	{
    //		UnityEngine.Object.Destroy(this.m_BodyRagdoll);
    //		UnityEngine.Object.Destroy(this.m_Model);
    //		UnityEngine.Object.Destroy(this.m_SelectEffect);
    //		UnityEngine.Object.Destroy(this.m_DefenseEffect);
    //	}

    //	public virtual void AddCommand(FightCommand command)
    //	{
    //		command.DeductUsePoint();
    //		if (this.m_FightCommandManager == null)
    //		{
    //			FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //			this.m_FightCommandManager = fightState.m_FightCommandManager;
    //		}
    //		command.totalIndex = this.m_FightCommandManager.GetIndex();
    //		command.selfIndex = this.GetSelfCommandIndex();
    //		this.m_FightCommands.Enqueue(command);
    //	}

    //	protected virtual void ProcessShowDamageDataQueue()
    //	{
    //		if (this.ShowDamageDataQueue.Count == 0)
    //		{
    //			return;
    //		}
    //		ShowDamageData showDamageData = this.ShowDamageDataQueue.Dequeue();
    //		if (showDamageData == null)
    //		{
    //			return;
    //		}
    //		switch (showDamageData.Type)
    //		{
    //		case Enum_ShowDamageType.AttackDamage:
    //			FightSystem.Instance.ShowDamage(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		case Enum_ShowDamageType.CriticalDamage:
    //			FightSystem.Instance.ShowDamage(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		case Enum_ShowDamageType.SkillDamage:
    //			FightSystem.Instance.ShowSkillDamage(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		case Enum_ShowDamageType.RestoreHP:
    //			FightSystem.Instance.ShowHP(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		case Enum_ShowDamageType.RestoreMP:
    //			FightSystem.Instance.ShowMP(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		case Enum_ShowDamageType.RestoreAP:
    //			FightSystem.Instance.ShowAP(this.m_ModelTransform, showDamageData.Value, showDamageData.Count);
    //			return;
    //		default:
    //			return;
    //		}
    //	}

    //	public virtual IEnumerator RemoveAllBuff()
    //	{
    //		yield return 0;
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (!(current is Buff_Dead))
    //			{
    //				current.Relieve();
    //			}
    //		}
    //		foreach (Buff_Base current2 in this.m_NoRemoveBuffs)
    //		{
    //			current2.Relieve();
    //		}
    //		this.m_NoRemoveBuffs.Clear();
    //		this.SetBuffRoleData();
    //		if (this.UpdateBuffIconCallback != null)
    //		{
    //			this.UpdateBuffIconCallback();
    //		}
    //		yield break;
    //	}

    //	public virtual IEnumerator RemoveBuff(int buffGrope)
    //	{
    //		if (this.m_Buffs.ContainsKey(buffGrope))
    //		{
    //			yield return 0;
    //			this.m_Buffs.Remove(buffGrope);
    //			this.SetBuffRoleData();
    //			if (this.UpdateBuffIconCallback != null)
    //			{
    //				this.UpdateBuffIconCallback();
    //			}
    //		}
    //		yield break;
    //	}

    //	public virtual void AddNoRemoveBuff(Buff_Base buff)
    //	{
    //		this.m_NoRemoveBuffs.Add(buff);
    //		this.SetBuffRoleData();
    //	}

    //	public virtual IEnumerator AddBuff(int buffGrope, Buff_Base buff)
    //	{
    //		yield return 0;
    //		if (this.m_Buffs.ContainsKey(buffGrope))
    //		{
    //			if (this.m_Buffs[buffGrope].m_BuffData.Level > buff.m_BuffData.Level)
    //			{
    //				this.m_Buffs[buffGrope].ResetRound();
    //				goto IL_12F;
    //			}
    //			this.m_Buffs[buffGrope].Replaced();
    //			this.m_Buffs[buffGrope] = buff;
    //		}
    //		else
    //		{
    //			this.m_Buffs.Add(buffGrope, buff);
    //		}
    //		this.SetBuffRoleData();
    //		if (this.UpdateBuffIconCallback != null)
    //		{
    //			this.UpdateBuffIconCallback();
    //		}
    //		buff.Begin();
    //		IL_12F:
    //		yield break;
    //	}

    //	public virtual void UpdateBuffPerRound()
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			current.ExecutePerRound();
    //		}
    //	}

    //	public virtual void SetFightRoleData()
    //	{
    //	}

    //	public virtual void SetBuffRoleData()
    //	{
    //	}

    //	public virtual int GetAir()
    //	{
    //		return this.m_FightRoleData.Air;
    //	}

    //	public virtual int GetMag()
    //	{
    //		return this.m_FightRoleData.Mag;
    //	}

    //	public virtual int GetStr()
    //	{
    //		return this.m_FightRoleData.Str;
    //	}

    //	public virtual int GetSta()
    //	{
    //		return this.m_FightRoleData.Sta;
    //	}

    //	public virtual int GetAgi()
    //	{
    //		return this.m_FightRoleData.Agi;
    //	}

    //	public virtual int GetLuck()
    //	{
    //		return this.m_FightRoleData.Luck;
    //	}

    //	public virtual int GetMaxHP()
    //	{
    //		return this.m_FightRoleData.MaxHP;
    //	}

    //	public virtual int GetHP()
    //	{
    //		return this.m_FightRoleData.HP;
    //	}

    //	public virtual int GetMP()
    //	{
    //		return this.m_FightRoleData.MP;
    //	}

    //	public virtual int GetAP()
    //	{
    //		return this.m_FightRoleData.AP;
    //	}

    //	public virtual int GetAtk()
    //	{
    //		return this.m_FightRoleData.Attack;
    //	}

    //	public virtual int GetDef()
    //	{
    //		return this.m_FightRoleData.Def;
    //	}

    //	public virtual int GetLevel()
    //	{
    //		return this.m_FightRoleData.Level;
    //	}

    //	public float GetDodgeRate()
    //	{
    //		return (float)this.m_FightRoleData.Agi / 750f * 100f + (float)this.m_FightRoleData.BaseDodgeRate;
    //	}

    //	public float GetCriticalRate()
    //	{
    //		return (float)this.m_FightRoleData.Critical;
    //	}

    //	public float GetStrikeBackRate()
    //	{
    //		return (float)this.m_FightRoleData.Luck * 0.1f + this.GetDodgeRate();
    //	}

    //	public float GetExcludeRate()
    //	{
    //		return (float)this.m_FightRoleData.Level / 99f * 30f;
    //	}

    //	public float GetBlockRate()
    //	{
    //		return (float)this.m_FightRoleData.Luck * 0.1f + (float)this.m_FightRoleData.Block;
    //	}

    //	public virtual float GetEscapeRate()
    //	{
    //		return (float)this.m_FightRoleData.Agi / 300f * 30f + (float)this.m_FightRoleData.Luck;
    //	}

    //	public virtual IEnumerator Escape_Story()
    //	{
    //		if (AnimationControlSystem.GetClip(this.m_Model, "return"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "return");
    //			Vector3 position = this.m_BornPointTransform.position - this.m_BornPointTransform.forward * 2.5f;
    //			MovementControlSystem.MoveAndRotateTo(this.m_Model, position, this.m_Animation["return"].length);
    //			yield return new WaitForSeconds(this.m_Animation["return"].length);
    //		}
    //		this.HideModel();
    //		yield break;
    //	}

    //	public virtual void Escape()
    //	{
    //		this.CharacterStatus = M_Character.Enum_CharacterStatus.Escape;
    //		this.HideModel();
    //	}

    //	public virtual void CatchMob()
    //	{
    //	}

    //	public virtual void ChangeHP_Buff(int hp)
    //	{
    //		if (hp == 0)
    //		{
    //			return;
    //		}
    //		if (hp < 0 && this.IsFearless())
    //		{
    //			return;
    //		}
    //		if (this.isDead())
    //		{
    //			return;
    //		}
    //		if (this.m_FightRoleData.HP + hp <= 0)
    //		{
    //			hp = 1 - this.m_FightRoleData.HP;
    //		}
    //		this.m_FightRoleData.HP += hp;
    //		this.Heal();
    //		this.m_FightRoleData.HP = Mathf.Clamp(this.m_FightRoleData.HP, 0, this.m_FightRoleData.MaxHP);
    //		if (hp > 0)
    //		{
    //			ShowDamageData item = new ShowDamageData(this.m_Model, Enum_ShowDamageType.RestoreHP, hp, 1);
    //			this.ShowDamageDataQueue.Enqueue(item);
    //			return;
    //		}
    //		new ShowDamageData(this.m_Model, Enum_ShowDamageType.SkillDamage, hp, 1);
    //		FightSystem.Instance.ShowDamage(this.m_ModelTransform, hp, 1);
    //	}

    //	public virtual int ChangeHP(int hp)
    //	{
    //		if (hp == 0)
    //		{
    //			return 0;
    //		}
    //		if (hp < 0)
    //		{
    //			if (this.IsFearless())
    //			{
    //				return 0;
    //			}
    //			hp = this.ProcessBuff_AbsorbShield(hp);
    //		}
    //		if (this.isDead())
    //		{
    //			return hp;
    //		}
    //		this.m_FightRoleData.HP += hp;
    //		this.m_FightRoleData.HP = Mathf.Clamp(this.m_FightRoleData.HP, 0, this.m_FightRoleData.MaxHP);
    //		this.Heal();
    //		return hp;
    //	}

    //	public virtual void ChangeMP_Buff(int mp)
    //	{
    //		if (mp == 0)
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.MP += mp;
    //		this.m_FightRoleData.MP = Mathf.Clamp(this.m_FightRoleData.MP, 0, this.m_FightRoleData.MaxMP);
    //		ShowDamageData item = new ShowDamageData(this.m_Model, Enum_ShowDamageType.RestoreMP, mp, 1);
    //		this.ShowDamageDataQueue.Enqueue(item);
    //	}

    //	public virtual void ChangeMP(int mp)
    //	{
    //		if (mp == 0)
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.MP += mp;
    //		this.m_FightRoleData.MP = Mathf.Clamp(this.m_FightRoleData.MP, 0, this.m_FightRoleData.MaxMP);
    //	}

    //	public virtual void ChangeAP_Buff(int ap)
    //	{
    //		if (ap == 0)
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.AP += ap;
    //		this.m_FightRoleData.AP = Mathf.Clamp(this.m_FightRoleData.AP, 0, this.m_FightRoleData.MaxAP);
    //		ShowDamageData item = new ShowDamageData(this.m_Model, Enum_ShowDamageType.RestoreAP, ap, 1);
    //		this.ShowDamageDataQueue.Enqueue(item);
    //	}

    //	public virtual void ChangeAP(int ap)
    //	{
    //		if (ap == 0)
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.AP += ap;
    //		this.m_FightRoleData.AP = Mathf.Clamp(this.m_FightRoleData.AP, 0, this.m_FightRoleData.MaxAP);
    //	}

    //	public virtual void ChangeEnergy(int energy)
    //	{
    //		if (energy == 0)
    //		{
    //			return;
    //		}
    //		this.m_Energy += (float)energy;
    //		this.m_Energy = Mathf.Clamp(this.m_Energy, 0f, 100f);
    //	}

    //	public virtual void SetEnergy(int energy)
    //	{
    //		this.m_Energy = (float)energy;
    //		this.m_Energy = Mathf.Clamp(this.m_Energy, 0f, 100f);
    //	}

    //	public virtual void SetHP(int hp)
    //	{
    //		this.m_FightRoleData.HP = hp;
    //		this.m_FightRoleData.HP = Mathf.Clamp(this.m_FightRoleData.HP, 0, this.m_FightRoleData.MaxHP);
    //	}

    //	public virtual void SetMP(int mp)
    //	{
    //		this.m_FightRoleData.MP = mp;
    //		this.m_FightRoleData.MP = Mathf.Clamp(this.m_FightRoleData.MP, 0, this.m_FightRoleData.MaxMP);
    //	}

    //	public virtual void SetAP(int ap)
    //	{
    //		this.m_FightRoleData.AP = ap;
    //		this.m_FightRoleData.AP = Mathf.Clamp(this.m_FightRoleData.AP, 0, this.m_FightRoleData.MaxAP);
    //	}

    //	public bool isDead()
    //	{
    //		return this.m_FightRoleData.HP <= 0;
    //	}

    //	public bool CanAttack()
    //	{
    //		return (this.CharacterStatus == M_Character.Enum_CharacterStatus.StandBy || this.CharacterStatus == M_Character.Enum_CharacterStatus.Defense) && this.m_BeAttackedCount == 0;
    //	}

    //	public bool CanBeAttacked()
    //	{
    //		return this.CharacterStatus != M_Character.Enum_CharacterStatus.Appear && this.CharacterStatus != M_Character.Enum_CharacterStatus.Attack && this.CharacterStatus != M_Character.Enum_CharacterStatus.Critical && this.CharacterStatus != M_Character.Enum_CharacterStatus.Dead && this.CharacterStatus != M_Character.Enum_CharacterStatus.Assist && this.CharacterStatus != M_Character.Enum_CharacterStatus.BeAssisted && this.CharacterStatus != M_Character.Enum_CharacterStatus.Escape && this.CharacterStatus != M_Character.Enum_CharacterStatus.TryEscape && this.CharacterStatus != M_Character.Enum_CharacterStatus.StrikeBack && this.CharacterStatus != M_Character.Enum_CharacterStatus.Catch && this.CharacterStatus != M_Character.Enum_CharacterStatus.Move && !this.IsAllHitPointDirectionOccupied();
    //	}

    //	public bool CanExceptionalAttack()
    //	{
    //		return this.CharacterStatus != M_Character.Enum_CharacterStatus.Block && this.CharacterStatus != M_Character.Enum_CharacterStatus.Dodge && this.CharacterStatus != M_Character.Enum_CharacterStatus.Exclude && this.CharacterStatus != M_Character.Enum_CharacterStatus.StrikeBack && this.CharacterStatus != M_Character.Enum_CharacterStatus.Catch && this.CharacterStatus != M_Character.Enum_CharacterStatus.Move && this.CharacterStatus != M_Character.Enum_CharacterStatus.TryEscape;
    //	}

    //	public bool CanAssist()
    //	{
    //		return this.CharacterStatus == M_Character.Enum_CharacterStatus.StandBy;
    //	}

    //	public bool IsAllHitPointDirectionOccupied()
    //	{
    //		return this.m_MiddleHitPointDirection.m_isOccupied && this.m_RightHitPointDirection.m_isOccupied && this.m_LeftHitPointDirection.m_isOccupied;
    //	}

    //	public void CalculateHitPoint()
    //	{
    //		float num = 60f;
    //		this.m_MiddleHitPointDirection = new HitPointDirection(this.m_BornPointTransform.forward);
    //		Vector3 direction = new Vector3(this.m_BornPointTransform.forward.x * Mathf.Cos(-num * 0.0174532924f) - this.m_BornPointTransform.forward.z * Mathf.Sin(-num * 0.0174532924f), this.m_BornPointTransform.forward.y, this.m_BornPointTransform.forward.x * Mathf.Sin(-num * 0.0174532924f) + this.m_BornPointTransform.forward.z * Mathf.Cos(-num * 0.0174532924f));
    //		this.m_RightHitPointDirection = new HitPointDirection(direction);
    //		direction = new Vector3(this.m_BornPointTransform.forward.x * Mathf.Cos(num * 0.0174532924f) - this.m_BornPointTransform.forward.z * Mathf.Sin(num * 0.0174532924f), this.m_BornPointTransform.forward.y, this.m_BornPointTransform.forward.x * Mathf.Sin(num * 0.0174532924f) + this.m_BornPointTransform.forward.z * Mathf.Cos(num * 0.0174532924f));
    //		this.m_LeftHitPointDirection = new HitPointDirection(direction);
    //	}

    //	public void PlayCrossMotion(int id)
    //	{
    //		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (this.m_Animation == null)
    //		{
    //			return;
    //		}
    //		if (AnimationControlSystem.GetClip(this.m_Model, data.ClipName))
    //		{
    //			AnimationControlSystem.CrossFadeAnimation(this.m_Model, data.ClipName);
    //		}
    //	}

    //	public bool WaitPlayMotion(int id)
    //	{
    //		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
    //		if (data == null)
    //		{
    //			return true;
    //		}
    //		if (this.m_Animation == null)
    //		{
    //			return true;
    //		}
    //		AnimationState animationState = this.m_Animation[data.ClipName];
    //		return animationState == null || animationState.time >= animationState.length || !this.m_Animation.IsPlaying(data.ClipName);
    //	}

    //	public void SetMotionMode(int id, int mode)
    //	{
    //		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (this.m_Animation == null)
    //		{
    //			return;
    //		}
    //		AnimationState animationState = this.m_Animation[data.ClipName];
    //		if (animationState == null)
    //		{
    //			return;
    //		}
    //		animationState.wrapMode = (WrapMode)mode;
    //	}

    //	public virtual void StandBy()
    //	{
    //	}

    //	public virtual void Heal()
    //	{
    //	}

    //	public virtual void Hit(float waitTime)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoHit(waitTime));
    //	}

    //	private IEnumerator DoHit(float waitTime)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		if (this.m_IsFight && (this.CharacterStatus == M_Character.Enum_CharacterStatus.StandBy || this.CharacterStatus == M_Character.Enum_CharacterStatus.Hit))
    //		{
    //			this.CharacterStatus = M_Character.Enum_CharacterStatus.Hit;
    //			if (AnimationControlSystem.GetClip(this.m_Model, "hit1"))
    //			{
    //				AnimationControlSystem.PlayAnimation(this.m_Model, "hit1");
    //				yield return new WaitForSeconds(this.m_Animation["hit1"].length);
    //			}
    //			this.StandBy();
    //		}
    //		yield break;
    //	}

    //	public void Block()
    //	{
    //		this.CharacterStatus = M_Character.Enum_CharacterStatus.Block;
    //		if (AnimationControlSystem.GetClip(this.m_Model, "defense"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "defense");
    //		}
    //	}

    //	public void Defense()
    //	{
    //		this.CharacterStatus = M_Character.Enum_CharacterStatus.Defense;
    //		if (AnimationControlSystem.GetClip(this.m_Model, "defense"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "defense");
    //		}
    //		this.ShowDefenseEffect(true);
    //	}

    //	public virtual void ShowDefenseEffect(bool enabled)
    //	{
    //		if (!enabled)
    //		{
    //			UnityEngine.Object.Destroy(this.m_DefenseEffect);
    //			return;
    //		}
    //		UnityEngine.Object.Destroy(this.m_DefenseEffect);
    //		this.m_DefenseEffect = EffectGenerator.CreateEffectGameObject("common_16_defense");
    //		if (this.m_DefenseEffect == null)
    //		{
    //			return;
    //		}
    //		Transform transform = TransformTool.SearchHierarchyForBone(this.m_ModelTransform, "1012");
    //		if (transform == null)
    //		{
    //			transform = this.m_ModelTransform;
    //		}
    //		this.m_DefenseEffect.transform.position = transform.position;
    //		this.m_DefenseEffect.transform.rotation = this.m_BornPointTransform.rotation;
    //		TransformTool.SetLayerRecursively(this.m_DefenseEffect.transform, 14);
    //	}

    //	public void DodgeAndMove(float waitBackTime, float waitForwardTime)
    //	{
    //		waitBackTime *= 0.001f;
    //		base.StartCoroutine(this.DoDodgeAndMove(waitBackTime, waitForwardTime));
    //	}

    //	private IEnumerator DoDodgeAndMove(float waitBackTime, float waitForwardTime)
    //	{
    //		yield return new WaitForSeconds(waitBackTime);
    //		Vector3 vector = this.m_BornPointTransform.position - this.m_BornPointTransform.forward * 2.5f;
    //		iTween.MoveTo(this.m_Model, iTween.Hash(new object[]
    //		{
    //			"position",
    //			vector,
    //			"time",
    //			0.1f,
    //			"easetype",
    //			iTween.EaseType.linear
    //		}));
    //		yield return new WaitForSeconds(waitForwardTime);
    //		if (AnimationControlSystem.GetClip(this.m_Model, "return"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "return");
    //			iTween.MoveTo(this.m_Model, iTween.Hash(new object[]
    //			{
    //				"position",
    //				this.m_BornPointTransform,
    //				"time",
    //				this.m_Animation["return"].length,
    //				"easetype",
    //				iTween.EaseType.linear
    //			}));
    //			yield return new WaitForSeconds(this.m_Animation["return"].length);
    //		}
    //		else
    //		{
    //			iTween.MoveTo(this.m_Model, iTween.Hash(new object[]
    //			{
    //				"position",
    //				this.m_BornPointTransform,
    //				"time",
    //				0,
    //				"easetype",
    //				iTween.EaseType.linear
    //			}));
    //		}
    //		this.m_AssistPartner = null;
    //		this.StandBy();
    //		yield break;
    //	}

    //	public void Dodge(float waitBackTime)
    //	{
    //		waitBackTime *= 0.001f;
    //		base.StartCoroutine(this.DoDodge(waitBackTime));
    //	}

    //	private IEnumerator DoDodge(float waitBackTime)
    //	{
    //		yield return new WaitForSeconds(waitBackTime);
    //		if (AnimationControlSystem.GetClip(this.m_Model, "dodge"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "dodge");
    //			yield return new WaitForSeconds(this.m_Animation["dodge"].length);
    //		}
    //		this.StandBy();
    //		yield break;
    //	}

    //	public void DefenseHitBack(float waitTime)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoDefenseHitBack(waitTime));
    //	}

    //	private IEnumerator DoDefenseHitBack(float waitTime)
    //	{
    //		yield return new WaitForSeconds(waitTime + 0.08f);
    //		if (this.CharacterStatus == M_Character.Enum_CharacterStatus.Defense)
    //		{
    //			Vector3 vector = this.m_ModelTransform.position - this.m_ModelTransform.forward;
    //			iTween.MoveTo(this.m_Model, iTween.Hash(new object[]
    //			{
    //				"position",
    //				vector,
    //				"time",
    //				0.05f,
    //				"easetype",
    //				iTween.EaseType.easeInExpo
    //			}));
    //			yield return new WaitForSeconds(0.05f);
    //			iTween.MoveTo(this.m_Model, iTween.Hash(new object[]
    //			{
    //				"position",
    //				this.m_BornPointTransform,
    //				"time",
    //				0.05f,
    //				"easetype",
    //				iTween.EaseType.easeOutExpo
    //			}));
    //		}
    //		yield break;
    //	}

    //	public void AssistExclude(float waitTime, Vector3 destination)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoAssistExclude(waitTime, destination));
    //	}

    //	private IEnumerator DoAssistExclude(float waitTime, Vector3 destination)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		if (AnimationControlSystem.GetClip(this.m_Model, "exclude"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "exclude");
    //			this.m_ModelTransform.position = destination;
    //			yield return new WaitForSeconds(this.m_Animation["exclude"].length);
    //		}
    //		this.m_ModelTransform.position = this.m_BornPointTransform.position;
    //		this.StandBy();
    //		yield break;
    //	}

    //	public void AssistDefense(float waitTime, float keepTime, Vector3 destination)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoAssistDefense(waitTime, keepTime, destination));
    //	}

    //	private IEnumerator DoAssistDefense(float waitTime, float keepTime, Vector3 destination)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		if (AnimationControlSystem.GetClip(this.m_Model, "defense"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "defense");
    //		}
    //		this.m_ModelTransform.position = destination;
    //		this.ShowDefenseEffect(true);
    //		yield return new WaitForSeconds(keepTime);
    //		this.ShowDefenseEffect(false);
    //		this.m_ModelTransform.position = this.m_BornPointTransform.position;
    //		this.StandBy();
    //		yield break;
    //	}

    //	public void Exclude(float waitTime)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoExclude(waitTime));
    //	}

    //	private IEnumerator DoExclude(float waitTime)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		this.ShowDefenseEffect(false);
    //		if (AnimationControlSystem.GetClip_NoAlarm(this.m_Model, "exclude"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "exclude");
    //			yield return new WaitForSeconds(this.m_Animation["exclude"].length);
    //		}
    //		else if (AnimationControlSystem.GetClip(this.m_Model, "defense"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "defense");
    //			yield return new WaitForSeconds(this.m_Animation["defense"].length);
    //		}
    //		this.StandBy();
    //		yield break;
    //	}

    //	public void Hit_or_Dead(float waitTime)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoHit_or_Dead(waitTime));
    //	}

    //	private IEnumerator DoHit_or_Dead(float waitTime)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		if (this.CharacterStatus != M_Character.Enum_CharacterStatus.Dead && !(this.m_Model == null))
    //		{
    //			if (this.GetHP() > 0)
    //			{
    //				if (this.CharacterStatus == M_Character.Enum_CharacterStatus.StandBy || this.CharacterStatus == M_Character.Enum_CharacterStatus.Hit)
    //				{
    //					this.CharacterStatus = M_Character.Enum_CharacterStatus.Hit;
    //					if (AnimationControlSystem.GetClip(this.m_Model, "hit1"))
    //					{
    //						AnimationControlSystem.PlayAnimation(this.m_Model, "hit1");
    //						yield return new WaitForSeconds(this.m_Animation["hit1"].length);
    //					}
    //					this.StandBy();
    //				}
    //			}
    //			else
    //			{
    //				this.Dead(0f);
    //			}
    //		}
    //		yield break;
    //	}

    //	public virtual void Buff_Dead()
    //	{
    //	}

    //	public virtual void Dead(float waitTime)
    //	{
    //	}

    //	public virtual IEnumerator Revive()
    //	{
    //		if (this.m_FightRoleData.HP <= 0)
    //		{
    //			this.m_FightRoleData.HP = 1;
    //		}
    //		this.m_IsFight = true;
    //		this._characterStatus = M_Character.Enum_CharacterStatus.Revive;
    //		if (AnimationControlSystem.GetClip(this.m_Model, "revive"))
    //		{
    //			this.CreateEffect("revive");
    //			AudioClip audioClip = MusicEffectGenerator.GetAudioClip(this.GetReviveSound(this.m_RoleID));
    //			if (audioClip != null)
    //			{
    //				MusicControlSystem.PlaySound(audioClip, 1);
    //			}
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "revive");
    //			yield return new WaitForSeconds(this.m_Animation["revive"].length);
    //		}
    //		this.StandBy();
    //		yield break;
    //	}

    //	private string GetReviveSound(int roleID)
    //	{
    //		string result = "";
    //		switch (roleID)
    //		{
    //		case 1:
    //			result = "ep01_revive";
    //			break;
    //		case 2:
    //			result = "ep04_revive";
    //			break;
    //		case 3:
    //			result = "ep02_revive";
    //			break;
    //		case 4:
    //			result = "ep05_revive";
    //			break;
    //		case 5:
    //			result = "ep03_revive";
    //			break;
    //		case 6:
    //			result = "ep06_revive";
    //			break;
    //		case 7:
    //			result = "ep07_revive";
    //			break;
    //		}
    //		return result;
    //	}

    //	public void CreateEffect(string type)
    //	{
    //		string name = "";
    //		switch (this.m_RoleID)
    //		{
    //		case 1:
    //			name = "ep01_" + type;
    //			break;
    //		case 2:
    //			name = "ep04_" + type;
    //			break;
    //		case 3:
    //			name = "ep02_" + type;
    //			break;
    //		case 4:
    //			name = "ep05_" + type;
    //			break;
    //		case 5:
    //			name = "ep03_" + type;
    //			break;
    //		case 6:
    //			name = "ep06_" + type;
    //			break;
    //		case 7:
    //			name = "ep07_" + type;
    //			break;
    //		}
    //		GameObject gameObject = EffectGenerator.CreateEffectGameObject(name);
    //		if (gameObject != null)
    //		{
    //			gameObject.transform.position = this.m_ModelTransform.position;
    //			gameObject.transform.rotation = this.m_ModelTransform.rotation;
    //		}
    //	}

    //	public void PlayerStrikeBack(float waitTime)
    //	{
    //		waitTime *= 0.001f;
    //		base.StartCoroutine(this.DoPlayerStrikeBack(waitTime));
    //	}

    //	private IEnumerator DoPlayerStrikeBack(float waitTime)
    //	{
    //		yield return new WaitForSeconds(waitTime);
    //		AudioClip audioClip = MusicEffectGenerator.GetAudioClip(this.GetFightBackSound(this.m_RoleID));
    //		if (audioClip != null)
    //		{
    //			MusicControlSystem.PlaySound(audioClip, 1);
    //		}
    //		if (AnimationControlSystem.GetClip(this.m_Model, "fightback"))
    //		{
    //			AnimationControlSystem.PlayAnimation(this.m_Model, "fightback");
    //			yield return new WaitForSeconds(this.m_Animation["fightback"].length);
    //		}
    //		this.StandBy();
    //		yield break;
    //	}

    //	private string GetFightBackSound(int roleID)
    //	{
    //		string result = "";
    //		switch (roleID)
    //		{
    //		case 1:
    //			result = "ep01_fightback";
    //			break;
    //		case 2:
    //			result = "ep04_fightback";
    //			break;
    //		case 3:
    //			result = "ep02_fightback";
    //			break;
    //		case 4:
    //			result = "ep05_fightback";
    //			break;
    //		case 5:
    //			result = "ep03_fightback";
    //			break;
    //		case 6:
    //			result = "ep06_fightback";
    //			break;
    //		case 7:
    //			result = "ep07_fightback";
    //			break;
    //		}
    //		return result;
    //	}

    //	public void CalculateEnergyRate()
    //	{
    //		this.m_EnergyRate = FightFormulaTool.CalculateEnergyRate((float)this.m_FightRoleData.Agi);
    //		NormalSettingSystem.Instance.GetNormalSetting().m_FightingSpeed = Mathf.Clamp(NormalSettingSystem.Instance.GetNormalSetting().m_FightingSpeed, -3, 6);
    //		this.m_EnergyRate += (float)NormalSettingSystem.Instance.GetNormalSetting().m_FightingSpeed;
    //		if (this.m_EnergyRate < 1f)
    //		{
    //			this.m_EnergyRate = 1f;
    //		}
    //	}

    //	protected int ProcessBuff_AbsorbShield(int hp)
    //	{
    //		foreach (Buff_Base current in this.m_Buffs.Values)
    //		{
    //			if (hp >= 0)
    //			{
    //				break;
    //			}
    //			if (current.m_BuffData.emBuffType == ENUM_BuffType.AbsorbShield)
    //			{
    //				Buff_AbsorbShield buff_AbsorbShield = current as Buff_AbsorbShield;
    //				if (buff_AbsorbShield != null)
    //				{
    //					hp = buff_AbsorbShield.GetAbsorbDmg(hp);
    //				}
    //			}
    //		}
    //		return hp;
    //	}

    //	private void OnGUI()
    //	{
    //		if (!UI_Fight.Instance.ShowDebugMessage)
    //		{
    //			return;
    //		}
    //		if (!this.m_IsFight)
    //		{
    //			return;
    //		}
    //		if (this.isDead())
    //		{
    //			return;
    //		}
    //		Vector3 position = this.m_ModelTransform.position;
    //		Vector3 vector = Camera.main.WorldToScreenPoint(position);
    //		Vector2 vector2 = new Vector2(vector.x, (float)Screen.height - vector.y);
    //		GUI.Label(new Rect(vector2.x, vector2.y - 30f, 100f, 30f), this.SkillName);
    //		GUI.Label(new Rect(vector2.x, vector2.y, 100f, 30f), this.selfCommandIndex.ToString());
    //		if (this.m_FightCommands.Count > 0)
    //		{
    //			GUI.Label(new Rect(vector2.x, vector2.y + 30f, 100f, 30f), this.m_FightCommands.Peek().selfIndex.ToString());
    //		}
    //	}
}
