using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class M_Character : MonoBehaviour
{
    /// <summary>
    /// 战斗状态
    /// </summary>
    public enum Enum_FightStatus
    {
        Debut,
        Idle,
        MoveToAttack,
        Attack,
        AfterAttackMoveBack,
        Dead,
        Revive,
        JumpBack,
        Pause,
        Finish,
        Stun,
        Sleep,
        Freeze
    }

    public delegate void UpdateBuffIcon();

    public M_Character.UpdateBuffIcon UpdateBuffIconCallback;

    public string m_CharacterName;

    public string m_ModelName;

    public string m_FBXName;

    public string m_HitPointName = RefPointType.point04.ToString();

    public GameObject m_FightPosition;

    public Animator m_Animator;

    public CharacterController m_CharacterController;

    public Transform m_HitTransform;

    public float m_RoleHeight;

    public float m_RoleRadius;

    public float m_DoAttackRange=2f;

    //public ShroudInstance m_ShroudInstance;

    public FightSceneManager m_FightSceneMgr;

    public M_Character.Enum_FightStatus m_emFight = M_Character.Enum_FightStatus.Idle;

    public static int State_Debut = Animator.StringToHash("Base Layer.debut");

    public int State_Standby = Animator.StringToHash("Base Layer.standby");

    public static int State_Sprint = Animator.StringToHash("Base Layer.sprint");

    public static int State_BackJumpSmall = Animator.StringToHash("Base Layer.backjump-small");

    public static int State_Hit = Animator.StringToHash("Base Layer.hit1");

    public static int State_Hit2 = Animator.StringToHash("Base Layer.hit2");

    public static int State_Defense = Animator.StringToHash("Base Layer.defense");

    public int State_Dead = Animator.StringToHash("Base Layer.dead");

    public static int State_Giddy_Cycle = Animator.StringToHash("Base Layer.giddy_B");

    public FightRoleData m_FightRoleData = new FightRoleData();

    public GameObject m_ActionTargetModel;

    public float m_ActionCD;

    public float m_ActionCDTimer;

    public List<FightCommand> m_CommandQueue = new List<FightCommand>();

    public Dictionary<int, Buff_Base> m_BuffList = new Dictionary<int, Buff_Base>();

    public List<Buff_Base> m_NoRemoveBuffList = new List<Buff_Base>();

    public M_Character m_FaceToTarget;

    public float m_MoveTimer;

    public float m_IdleTimer;

    public float m_RunToTargetTimer;

    public ENUM_FightActionType m_emLastActionType;

    public bool m_bNoMoveAttack = true;

    public bool m_EnableCharacterContoller = true;

    public bool m_bStoryMode;

    public bool m_bStartUpdate;

    public bool m_bPause = true;

    private float m_DropCheckTimer;

    public int m_TotalAttack;

    public int m_TotalDamage;

    public int m_TotalHeal;

    public int m_TotalBeHealed;

    public GameObject m_RoleModel;

    public Transform m_ModelTransform;

    public int currentTimeCount;

    /// <summary>
    /// 是否玩家角色
    /// </summary>
    public bool IsPlayerCharacter;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void Awake()
    {
        this.Initialize();
    }

    public virtual void Initialize()
    {
        UnityEngine.Debug.Log("执行M_Character Initialize");
        this.m_RoleModel = base.gameObject;
        this.m_ModelTransform = base.transform;
        //this.m_HitTransform = TransformTool.FindChild(base.transform, this.m_HitPointName);
        //if (this.m_HitTransform == null)
        //{
        //    UnityEngine.Debug.LogWarning("Character Initialize, Cant Get HitPoint Reference.");
        //    this.m_HitTransform = base.transform;
        //}
        //this.m_Animator = base.GetComponent<Animator>();
        //this.ClearCommand();
        //this.m_CharacterController = base.GetComponent<CharacterController>();
        //if (this.m_CharacterController != null)
        //{
        //    this.m_RoleRadius = this.m_CharacterController.radius * 1.5f;
        //    this.m_RoleHeight = this.m_CharacterController.height;
        //    this.m_CharacterController.enabled = false;
        //    if (this is M_Player)
        //    {
        //        this.m_RoleRadius = 1f;
        //    }
        //    this.m_CharacterController.slopeLimit = 5f;
        //    this.m_CharacterController.stepOffset = 0.05f;
        //    if (this.m_CharacterController.height < 10f)
        //    {
        //        this.m_CharacterController.height = 10f;
        //        this.m_CharacterController.center = new Vector3(this.m_CharacterController.center.x, 5.08f, this.m_CharacterController.center.z);
        //    }
        //}
        //else
        //{
        //    UnityEngine.Debug.LogError("m_CharacterController is NULL!!");
        //}
        //CapsuleCollider component = base.GetComponent<CapsuleCollider>();
        //if (component != null)
        //{
        //    BoxCollider component2 = base.GetComponent<BoxCollider>();
        //    if (component2 != null)
        //    {
        //        component2.isTrigger = true;
        //        UnityEngine.Object.Destroy(component);
        //    }
        //    else
        //    {
        //        component.isTrigger = true;
        //        component.enabled = true;
        //    }
        //}
        //SphereCollider component3 = base.GetComponent<SphereCollider>();
        //if (component3 != null)
        //{
        //    this.m_DoAttackRange = component3.radius;
        //    UnityEngine.Object.Destroy(component3);
        //}
        //else
        //{
        //    UnityEngine.Debug.Log("sphereCol == null, can't set m_DoAttackRange.");
        //}
        //this.m_ShroudInstance = base.GetComponent<ShroudInstance>();
        //FaceFXControllerScript component4 = base.GetComponent<FaceFXControllerScript>();
        //if (component4 != null)
        //{
        //    UnityEngine.Object.Destroy(component4);
        //}
        //Animation component5 = base.GetComponent<Animation>();
        //if (component5 != null)
        //{
        //    UnityEngine.Object.Destroy(component5);
        //}
        //this.m_emLastActionType = ENUM_FightActionType.Null;
    }

    /// <summary>
    /// 模型下坠
    /// </summary>
    public void ModelDropCheck()
    {
        if (this.m_DropCheckTimer > 0f)
        {
            this.m_DropCheckTimer -= Time.deltaTime;
        }
        else
        {
            float num = this.m_FightSceneMgr.m_BattlePoint.position.y - this.m_ModelTransform.position.y;
            if (num > 2f)
            {
                Vector3 position = new Vector3(this.m_ModelTransform.position.x, this.m_FightSceneMgr.m_BattlePoint.position.y + 0.05f, this.m_ModelTransform.position.z);
                this.m_ModelTransform.position = position;
            }
            this.m_DropCheckTimer = 1f;
        }
    }

    public bool IsLoseHeart()
    {
        if (this.m_BuffList.ContainsKey(76))
        {
            return true;
        }
        //for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
        //{
        //    if (this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.LoseHeart)
        //    {
        //        return true;
        //    }
        //}
        return false;
    }

    public virtual void Update_Movement()
    {
        switch (this.m_emFight)
        {
            case M_Character.Enum_FightStatus.Idle:
                this.Update_Idle();
                break;
            case M_Character.Enum_FightStatus.MoveToAttack:
                this.Update_MoveToAttack();
                break;
            case M_Character.Enum_FightStatus.Attack:
                //this.Update_Attack();
                break;
            case M_Character.Enum_FightStatus.AfterAttackMoveBack:
                //this.Update_AfterAttackMoveBack();
                break;
            case M_Character.Enum_FightStatus.Revive:
                //this.Update_Revive();
                break;
            case M_Character.Enum_FightStatus.JumpBack:
                //this.Update_JumpBack();
                break;
            case M_Character.Enum_FightStatus.Pause:
                //this.Update_Pause();
                break;
            case M_Character.Enum_FightStatus.Finish:
                //this.Update_Finish();
                break;
            case M_Character.Enum_FightStatus.Stun:
            case M_Character.Enum_FightStatus.Sleep:
            case M_Character.Enum_FightStatus.Freeze:
                //this.Update_CantActionState();
                break;
        }
    }

    //	public virtual void Update_StoryMode()
    //	{
    //		switch (this.m_emFight)
    //		{
    //		case M_Character.Enum_FightStatus.Idle:
    //			this.Update_Idle_StoryMode();
    //			break;
    //		case M_Character.Enum_FightStatus.MoveToAttack:
    //			this.Update_MoveToAttack();
    //			break;
    //		case M_Character.Enum_FightStatus.Attack:
    //			this.Update_Attack();
    //			break;
    //		case M_Character.Enum_FightStatus.AfterAttackMoveBack:
    //			this.Update_AfterAttackMoveBack();
    //			break;
    //		case M_Character.Enum_FightStatus.Revive:
    //			this.Update_Revive();
    //			break;
    //		case M_Character.Enum_FightStatus.JumpBack:
    //			this.Update_JumpBack();
    //			break;
    //		case M_Character.Enum_FightStatus.Pause:
    //			this.Update_Pause();
    //			break;
    //		case M_Character.Enum_FightStatus.Finish:
    //			this.Update_Finish();
    //			break;
    //		case M_Character.Enum_FightStatus.Stun:
    //		case M_Character.Enum_FightStatus.Sleep:
    //		case M_Character.Enum_FightStatus.Freeze:
    //			this.Update_CantActionState();
    //			break;
    //		}
    //	}

    //	public virtual void Update_Debut()
    //	{
    //	}

    public virtual void Update_Idle()
    {
    }

    //	public virtual void Update_Idle_StoryMode()
    //	{
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		if (currentAnimatorStateInfo.nameHash == M_Character.State_Hit || currentAnimatorStateInfo.nameHash == M_Character.State_Hit2)
    //		{
    //			return;
    //		}
    //		if (this.m_Animator.IsInTransition(0))
    //		{
    //			return;
    //		}
    //		if (currentAnimatorStateInfo.nameHash != this.State_Standby && !this.m_Animator.IsInTransition(0))
    //		{
    //			this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //			this.m_MoveTimer = 0f;
    //			this.m_IdleTimer = 0f;
    //		}
    //	}

    public virtual void Update_MoveToAttack()
    {
        //if (this.m_CommandQueue.Count <= 0)
        //{
        //    this.CrossFadeAnimation(this.State_Standby, 0.1f);
        //    this.m_emFight = M_Character.Enum_FightStatus.Idle;
        //    return;
        //}
        FightCommand fightCommand = this.m_CommandQueue[0];
        this.m_RunToTargetTimer += Time.deltaTime;
        if (this.m_FaceToTarget != this)
        {
            this.UpdateDirection_Directly(this.m_FaceToTarget.GetModelPosition());
        }
        float num = Vector3.Distance(this.m_FaceToTarget.GetModelPosition(), this.GetModelPosition()) - this.m_FaceToTarget.m_RoleRadius;
        if (this.m_RunToTargetTimer > 1.5f)
        {     
            float d = num - this.m_DoAttackRange;
            Vector3 b = (this.m_FaceToTarget.GetModelPosition() - this.GetModelPosition()).normalized * d;
            this.m_ModelTransform.position += b;
            num = this.m_DoAttackRange;
        }
        if (num <= this.m_DoAttackRange)//|| !this.CheckCommandNeedMove(fightCommand.m_UseEffectID)
        {
            UnityEngine.Debug.Log("执行DoCommand");
            this.m_emFight = M_Character.Enum_FightStatus.Attack;
            //this.m_CharacterController.enabled = this.m_EnableCharacterContoller;
            //this.CrossFadeAnimation(this.State_Standby, 0.1f);
            this.DoCommand(fightCommand);
            this.m_RunToTargetTimer = 0f;
            return;
        }
        //if (this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash != M_Character.State_Sprint && !this.m_Animator.IsInTransition(0))
        //{
        //    this.CrossFadeAnimation(M_Character.State_Sprint, 0.1f);
        //    this.m_bNoMoveAttack = false;
        //    this.m_CharacterController.enabled = false;
        //}
    }

    //	public virtual void Update_Attack()
    //	{
    //		if (this.m_FaceToTarget != this)
    //		{
    //			this.UpdateDirection_Directly(this.m_FaceToTarget.GetModelPosition());
    //		}
    //	}

    //	public virtual void Update_AfterAttackMoveBack()
    //	{
    //	}

    //	public virtual void Update_JumpBack()
    //	{
    //	}

    //	public virtual void Update_Pause()
    //	{
    //	}

    //	public virtual void Update_Revive()
    //	{
    //	}

    //	public float GetActionCD()
    //	{
    //		return this.m_ActionCD;
    //	}

    //	public virtual void SetCanNotActionStateAnimation(bool bCantAction)
    //	{
    //	}

    //	public virtual void Update_CantActionState()
    //	{
    //		if (this.m_CommandQueue.Count > 0)
    //		{
    //			this.m_CommandQueue.Clear();
    //		}
    //		if (this.m_ActionCDTimer > 0f)
    //		{
    //			this.m_ActionCDTimer = this.GetActionCD();
    //			if (this is M_Player)
    //			{
    //				M_Player m_Player = this as M_Player;
    //				m_Player.m_AddActionCD = this.m_ActionCDTimer;
    //			}
    //		}
    //	}

    //	public virtual void Update_Finish()
    //	{
    //	}

    //	public void ResetStateToIdle()
    //	{
    //		this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //		this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //	}

    public virtual void ClearCommand()
    {
        for (int i = 0; i < this.m_CommandQueue.Count; i++)
        {
            this.m_CommandQueue[i].Clear();
        }
        this.m_CommandQueue.Clear();
    }

    public virtual Vector3 GetModelPosition()
    {
        return this.m_ModelTransform.position;
    }

    //	public virtual int GetBeingTargetScore()
    //	{
    //		return 0;
    //	}

    public virtual bool DoCommand(FightCommand skillCommand)
    {
        //if (skillCommand is FightCommand_MagicItem)
        //{
        //    skillCommand.Execute();
        //    return true;
        //}
        //S_UseEffect data = GameDataDB.UseEffectDB.GetData(skillCommand.m_UseEffectID);
        //if (data == null)
        //{
        //    return false;
        //}
        //skillCommand.m_Targets.Clear();
        //if (data.emRange == ENUM_UseRange.All)
        //{
        //    skillCommand.m_Targets = this.m_FightSceneMgr.GetAllTargetCharacterList(data, skillCommand.m_Actor);
        //}
        //else
        //{
        //    skillCommand.m_Targets.Add(skillCommand.m_Target);
        //}
        //bool flag = false;
        //if (this.m_BuffList.ContainsKey(24))
        //{
        //    Buff_Execute buff_Execute = this.m_BuffList[24] as Buff_Execute;
        //    buff_Execute.UpdateAtkTarget(skillCommand.m_Target);
        //    flag = true;
        //}
        //for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
        //{
        //    if (this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.Execute)
        //    {
        //        Buff_Execute buff_Execute2 = this.m_NoRemoveBuffList[i] as Buff_Execute;
        //        buff_Execute2.UpdateAtkTarget(skillCommand.m_Target);
        //        flag = true;
        //    }
        //}
        //if (flag)
        //{
        //    this.UpdateFightRoleData();
        //}
        skillCommand.Execute();
        return true;
    }

    public virtual void UpdateFightRoleData()
    {
    }

    //	public List<Buff_Base> GetShowBuffs()
    //	{
    //		List<Buff_Base> list = new List<Buff_Base>();
    //		foreach (Buff_Base current in this.m_BuffList.Values)
    //		{
    //			if (current.m_BuffData.emBuffType != ENUM_BuffType.Vision)
    //			{
    //				if (current.m_BuffData.emBuffType != ENUM_BuffType.Combo && current.m_BuffData.emBuffType != ENUM_BuffType.Combo2 && current.m_BuffData.emBuffType != ENUM_BuffType.Combo3)
    //				{
    //					list.Add(current);
    //				}
    //			}
    //		}
    //		list.Sort((Buff_Base x, Buff_Base y) => x.m_RemainingTime.CompareTo(y.m_RemainingTime));
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (this.m_NoRemoveBuffList[i].m_BuffData.Time == -2f)
    //			{
    //				list.Insert(0, this.m_NoRemoveBuffList[i]);
    //			}
    //		}
    //		return list;
    //	}

    //	public void CheckTransElementTypeBuff()
    //	{
    //		if (this.m_BuffList.ContainsKey(67))
    //		{
    //			this.m_FightRoleData.DefElement[0] = 50;
    //			this.m_FightRoleData.DefElement[1] = 0;
    //			this.m_FightRoleData.DefElement[2] = 0;
    //			this.m_FightRoleData.DefElement[3] = -50;
    //		}
    //		if (this.m_BuffList.ContainsKey(70))
    //		{
    //			this.m_FightRoleData.DefElement[0] = -50;
    //			this.m_FightRoleData.DefElement[1] = 50;
    //			this.m_FightRoleData.DefElement[2] = 0;
    //			this.m_FightRoleData.DefElement[3] = 0;
    //		}
    //		if (this.m_BuffList.ContainsKey(69))
    //		{
    //			this.m_FightRoleData.DefElement[0] = 0;
    //			this.m_FightRoleData.DefElement[1] = -50;
    //			this.m_FightRoleData.DefElement[2] = 50;
    //			this.m_FightRoleData.DefElement[3] = 0;
    //		}
    //		if (this.m_BuffList.ContainsKey(68))
    //		{
    //			this.m_FightRoleData.DefElement[0] = 0;
    //			this.m_FightRoleData.DefElement[1] = 0;
    //			this.m_FightRoleData.DefElement[2] = -50;
    //			this.m_FightRoleData.DefElement[3] = 50;
    //		}
    //	}

    //	public void Update_Buff()
    //	{
    //		if (this.m_bPause || this.m_bStoryMode)
    //		{
    //			return;
    //		}
    //		if (!this.m_bStartUpdate)
    //		{
    //			return;
    //		}
    //		foreach (KeyValuePair<int, Buff_Base> current in this.m_BuffList)
    //		{
    //			current.Value.Update();
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			this.m_NoRemoveBuffList[i].Update();
    //		}
    //	}

    //	public virtual void AddNoRemoveBuff(Buff_Base buff)
    //	{
    //		this.m_NoRemoveBuffList.Add(buff);
    //		if (this.UpdateBuffIconCallback != null)
    //		{
    //			this.UpdateBuffIconCallback();
    //		}
    //		buff.Begin();
    //		if (!this.m_bStartUpdate)
    //		{
    //			return;
    //		}
    //		this.UpdateFightRoleData();
    //	}

    //	public virtual void DelNoRemoveBuff(int buffID)
    //	{
    //		List<Buff_Base> list = new List<Buff_Base>();
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (this.m_NoRemoveBuffList[i].m_BuffData.GUID == buffID)
    //			{
    //				list.Add(this.m_NoRemoveBuffList[i]);
    //			}
    //		}
    //		for (int j = 0; j < list.Count; j++)
    //		{
    //			this.m_NoRemoveBuffList.Remove(list[j]);
    //		}
    //		this.UpdateFightRoleData();
    //	}

    //	[DebuggerHidden]
    //	public virtual IEnumerator AddBuff(int buffGroupID, Buff_Base buff)
    //	{
    //		M_Character.<AddBuff>c__Iterator885 <AddBuff>c__Iterator = new M_Character.<AddBuff>c__Iterator885();
    //		<AddBuff>c__Iterator.buff = buff;
    //		<AddBuff>c__Iterator.buffGroupID = buffGroupID;
    //		<AddBuff>c__Iterator.<$>buff = buff;
    //		<AddBuff>c__Iterator.<$>buffGroupID = buffGroupID;
    //		<AddBuff>c__Iterator.<>f__this = this;
    //		return <AddBuff>c__Iterator;
    //	}

    //	public virtual void Debuff(int buffGroupID)
    //	{
    //		if (this.m_BuffList.ContainsKey(buffGroupID))
    //		{
    //			this.m_BuffList[buffGroupID].Relieve();
    //		}
    //	}

    //	[DebuggerHidden]
    //	public virtual IEnumerator RemoveBuff(int buffGroupID)
    //	{
    //		M_Character.<RemoveBuff>c__Iterator886 <RemoveBuff>c__Iterator = new M_Character.<RemoveBuff>c__Iterator886();
    //		<RemoveBuff>c__Iterator.buffGroupID = buffGroupID;
    //		<RemoveBuff>c__Iterator.<$>buffGroupID = buffGroupID;
    //		<RemoveBuff>c__Iterator.<>f__this = this;
    //		return <RemoveBuff>c__Iterator;
    //	}

    //	public void RemoveAllBuff()
    //	{
    //		foreach (Buff_Base current in this.m_BuffList.Values)
    //		{
    //			if (!(current is Buff_Dead))
    //			{
    //				current.Remove();
    //			}
    //		}
    //		foreach (Buff_Base current2 in this.m_NoRemoveBuffList)
    //		{
    //			current2.Remove();
    //		}
    //		this.m_NoRemoveBuffList.Clear();
    //		this.UpdateFightRoleData();
    //		if (this.UpdateBuffIconCallback != null)
    //		{
    //			this.UpdateBuffIconCallback();
    //		}
    //	}

    //	public virtual void ChangeHP_Percentage_Buff(float percentage, M_Character sourceCharacter, Enum_FightHitType emType)
    //	{
    //		float num = (float)this.m_FightRoleData.MaxHP * percentage / 100f;
    //		num += 0.1f;
    //		this.ChangeHP_Buff(Mathf.RoundToInt(num), sourceCharacter, emType);
    //	}

    //	public virtual void ChangeHP_Buff(int hp, M_Character sourceCharacter, Enum_FightHitType emType)
    //	{
    //		if (this.IsDead())
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.HP += hp;
    //		if (this.m_FightRoleData.HP > this.m_FightRoleData.MaxHP)
    //		{
    //			this.m_FightRoleData.HP = this.m_FightRoleData.MaxHP;
    //		}
    //		if (this.m_FightRoleData.HP < 0)
    //		{
    //			this.m_FightRoleData.HP = 0;
    //		}
    //		bool bPlayer = this is M_Player;
    //		if (emType == Enum_FightHitType.RestoreHP)
    //		{
    //			FhightPopUpMsg.Instance.ShowFightPopUpMsg(Enum_FightHitType.RestoreHP, false, false, hp, this.m_HitTransform, bPlayer);
    //		}
    //		if (emType == Enum_FightHitType.DamageHP)
    //		{
    //			FhightPopUpMsg.Instance.ShowFightPopUpMsg(Enum_FightHitType.DamageHP, false, false, hp, this.m_HitTransform, bPlayer);
    //		}
    //		if (emType == Enum_FightHitType.RestoreHP)
    //		{
    //			if (this is M_Player)
    //			{
    //				this.m_TotalBeHealed += hp;
    //			}
    //			if (sourceCharacter is M_Player)
    //			{
    //				sourceCharacter.m_TotalHeal += hp;
    //			}
    //		}
    //		if (emType == Enum_FightHitType.DamageHP)
    //		{
    //			if (this is M_Player)
    //			{
    //				this.m_TotalDamage += hp;
    //			}
    //			if (sourceCharacter is M_Player)
    //			{
    //				sourceCharacter.m_TotalAttack += hp;
    //			}
    //		}
    //		if (this.m_FightRoleData.HP <= 0)
    //		{
    //			if (!this.m_BuffList.ContainsKey(25) && !this.m_BuffList.ContainsKey(28))
    //			{
    //				this.Dead();
    //				return;
    //			}
    //			this.m_FightRoleData.HP = 1;
    //		}
    //	}

    //	public virtual void ChangeMP_Percentage_Buff(float percentage, Enum_FightHitType emType)
    //	{
    //		float num = (float)this.m_FightRoleData.MaxMP * percentage / 100f;
    //		num += 0.1f;
    //		this.ChangeMP_Buff(Mathf.RoundToInt(num), emType);
    //	}

    //	public virtual void ChangeMP_Buff(int mp, Enum_FightHitType emType)
    //	{
    //		if (this.IsDead())
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.MP += mp;
    //		if (this.m_FightRoleData.MP > this.m_FightRoleData.MaxMP)
    //		{
    //			this.m_FightRoleData.MP = this.m_FightRoleData.MaxMP;
    //		}
    //		if (this.m_FightRoleData.MP < 0)
    //		{
    //			this.m_FightRoleData.MP = 0;
    //		}
    //		bool bPlayer = this is M_Player;
    //		if (emType == Enum_FightHitType.RestoreMP)
    //		{
    //			FhightPopUpMsg.Instance.ShowFightPopUpMsg(Enum_FightHitType.RestoreMP, false, false, mp, this.m_HitTransform, bPlayer);
    //		}
    //		if (emType == Enum_FightHitType.DamageMP)
    //		{
    //			FhightPopUpMsg.Instance.ShowFightPopUpMsg(Enum_FightHitType.DamageMP, false, false, mp, this.m_HitTransform, bPlayer);
    //		}
    //	}

    public virtual bool AddSkillCommand(int skillId, M_Character target)
    {
        //if (this.m_bStoryMode)
        //{
        //    return false;
        //}
        //if (this is M_Player && this.m_CommandQueue.Count >= 2)
        //{
        //    return false;
        //}
        //if (this.m_ActionCDTimer > 0f)
        //{
        //    return false;
        //}
        //if (target == null)
        //{
        //    return false;
        //}
        S_Skill data = GameDataDB.SkillDB.GetData(skillId);
        //if (data == null)
        //{
        //    return false;
        //}
        S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
        if (data2 == null)
        {
            return false;
        }
        //if (!this.CheckSkillCastBuff(data.CastBuffer))
        //{
        //    return false;
        //}
        //if (!this.CheckCommandTarget(this, target, data2))
        //{
        //    return false;
        //}
        this.m_ActionCDTimer = 0f;
        if (data2.ActDataName == null || data2.ActDataName == "0")
        {
            UnityEngine.Debug.Log("执行data2.ActDataName == null" + target + "" + skillId);
            //FightCommand_NoActDataSkill fightCommand_NoActDataSkill = new FightCommand_NoActDataSkill(this, target, skillId);
            //if (fightCommand_NoActDataSkill != null)
            //{
            //    this.DoCommand(fightCommand_NoActDataSkill);
            //}
            return true;
        }

        this.m_CommandQueue.Add(new FightCommand_Skill(this, target, skillId));
        //this.m_ActionCDTimer = this.GetActionCD();
        return true;
    }

    //	public bool CheckSkillCastBuff(List<int> needCastBuffList)
    //	{
    //		if (needCastBuffList == null)
    //		{
    //			return true;
    //		}
    //		if (needCastBuffList.Count == 0)
    //		{
    //			return true;
    //		}
    //		for (int i = 0; i < needCastBuffList.Count; i++)
    //		{
    //			if (this.m_BuffList.ContainsKey(needCastBuffList[i]))
    //			{
    //				return true;
    //			}
    //		}
    //		foreach (Buff_Base current in this.m_NoRemoveBuffList)
    //		{
    //			for (int j = 0; j < needCastBuffList.Count; j++)
    //			{
    //				if (current.m_BuffData.GroupID == needCastBuffList[j])
    //				{
    //					return true;
    //				}
    //			}
    //		}
    //		return false;
    //	}

    //	public void PlayAnimation(string name)
    //	{
    //		int iHash = Animator.StringToHash(name);
    //		this.CrossFadeAnimation(iHash, 0.3f);
    //	}

    //	public void PlayAnimation(string name, float tDuration)
    //	{
    //		int iHash = Animator.StringToHash(name);
    //		this.CrossFadeAnimation(iHash, tDuration);
    //	}

    //	public void PlayAnimationImmediately(string name)
    //	{
    //		int iHash = Animator.StringToHash(name);
    //		this.PlayAnimationImmediately(iHash);
    //	}

    //	public void PlayAnimationImmediately(int iHash)
    //	{
    //		if (this.m_Animator == null)
    //		{
    //			UnityEngine.Debug.Log("m_Animator == null");
    //			return;
    //		}
    //		if (this.m_ShroudInstance != null)
    //		{
    //			this.m_ShroudInstance.ReduceBlendWeight();
    //		}
    //		this.m_Animator.Play(iHash);
    //	}

    //	public virtual void CrossFadeAnimation(int iHash, float tDuration)
    //	{
    //		if (this.m_Animator == null)
    //		{
    //			return;
    //		}
    //		if (this.m_ShroudInstance != null)
    //		{
    //			this.m_ShroudInstance.ReduceBlendWeight();
    //		}
    //		if (tDuration < 0.3f)
    //		{
    //			tDuration = 0.3f;
    //		}
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		float num;
    //		if (currentAnimatorStateInfo.length <= 0f)
    //		{
    //			num = 0f;
    //		}
    //		else
    //		{
    //			num = tDuration / currentAnimatorStateInfo.length;
    //		}
    //		if (num > 1f)
    //		{
    //			num = 1f;
    //		}
    //		if (num < 0f)
    //		{
    //			num = 0f;
    //		}
    //		this.CheckCharacterController(iHash);
    //		this.m_Animator.applyRootMotion = true;
    //		this.m_Animator.CrossFade(iHash, num);
    //	}

    //	public virtual void CheckCharacterController(int iHash)
    //	{
    //		if (iHash == M_Character.State_Sprint)
    //		{
    //			this.m_CharacterController.enabled = false;
    //		}
    //		else
    //		{
    //			this.m_CharacterController.enabled = this.m_EnableCharacterContoller;
    //		}
    //	}

    //	public bool CannotUseAnyCommand()
    //	{
    //		return this.IsDead() || this.m_BuffList.ContainsKey(77) || this.m_BuffList.ContainsKey(79) || this.m_BuffList.ContainsKey(80);
    //	}

    public void SetFaceToTarget(M_Character target)
    {
        //if (target == null || target == this)
        //{
        //    return;
        //}
        //if (target != this && this.m_bStartUpdate)
        //{
        //    this.UpdateDirection_Directly(target.GetModelPosition());
        //}
        this.m_FaceToTarget = target;
    }

    public virtual void UpdateDirection_Directly(Vector3 targetPos)
    {
        Vector3 forward = targetPos - this.GetModelPosition();
        forward.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(forward);
        base.transform.rotation = rotation;
    }

    //	public virtual void SetFightFinish()
    //	{
    //		this.RemoveAllBuff();
    //		if (!this.IsDead())
    //		{
    //			this.SetAnimatorSpeed(1f);
    //			this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //		}
    //		this.m_emFight = M_Character.Enum_FightStatus.Finish;
    //	}

    //	public bool CheckCommandNeedMove(int useEffectID)
    //	{
    //		S_UseEffect data = GameDataDB.UseEffectDB.GetData(useEffectID);
    //		return data != null && data.emDistance != ENUM_Distance.Far;
    //	}

    //	public int GetTowardPosDirection(Vector3 pos)
    //	{
    //		Vector3 lhs = pos - this.m_ModelTransform.position;
    //		List<float> list = new List<float>();
    //		list.Add(Vector3.Dot(lhs, this.m_ModelTransform.forward));
    //		list.Add(Vector3.Dot(lhs, -this.m_ModelTransform.forward));
    //		list.Add(Vector3.Dot(lhs, -this.m_ModelTransform.right));
    //		list.Add(Vector3.Dot(lhs, this.m_ModelTransform.right));
    //		float num = list[0];
    //		int result = 0;
    //		for (int i = 0; i < list.Count; i++)
    //		{
    //			if (num < 0f)
    //			{
    //				num = list[i];
    //				result = i;
    //			}
    //			else if (list[i] >= 0f)
    //			{
    //				if (num < list[i])
    //				{
    //					num = list[i];
    //					result = i;
    //				}
    //			}
    //		}
    //		return result;
    //	}

    public virtual void InitFightRoleData()
    {
    }

    public bool IsDead()
    {
        return this.m_FightRoleData == null || this.m_FightRoleData.HP <= 0;
    }

    //	public virtual bool IsStandby()
    //	{
    //		return true;
    //	}

    //	public virtual bool IsReady()
    //	{
    //		if (this.m_Animator == null)
    //		{
    //			return false;
    //		}
    //		if (this.m_Animator.speed == 0f)
    //		{
    //			return true;
    //		}
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		return currentAnimatorStateInfo.nameHash == this.State_Standby || currentAnimatorStateInfo.nameHash == M_Character.State_Giddy_Cycle || currentAnimatorStateInfo.nameHash == this.State_Dead;
    //	}

    //	public bool IsNowAnimationFinish()
    //	{
    //		return !this.m_Animator.IsInTransition(0) && this.m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
    //	}

    //	public virtual void Dead()
    //	{
    //	}

    //	public virtual void Revive()
    //	{
    //		if (this.m_FightRoleData.HP <= 0)
    //		{
    //			this.m_FightRoleData.HP = 1;
    //		}
    //		this.m_emFight = M_Character.Enum_FightStatus.Revive;
    //	}

    //	public void SetPause(bool bPause)
    //	{
    //		this.m_bPause = bPause;
    //	}

    //	public virtual void SetStartUpdate(bool bStart)
    //	{
    //		this.m_bStartUpdate = bStart;
    //		this.UpdateFightRoleData();
    //	}

    //	public void SetStoryMode(bool bStoryMode)
    //	{
    //		this.m_bStoryMode = bStoryMode;
    //	}

    //	public void SetRoleHP(int hp)
    //	{
    //		if (hp > this.m_FightRoleData.MaxHP)
    //		{
    //			hp = this.m_FightRoleData.MaxHP;
    //		}
    //		this.m_FightRoleData.HP = hp;
    //	}

    //	public void SetRoleMP(int mp)
    //	{
    //		if (mp > this.m_FightRoleData.MaxMP)
    //		{
    //			mp = this.m_FightRoleData.MaxMP;
    //		}
    //		this.m_FightRoleData.MP = mp;
    //	}

    //	public void SetAnimatorSpeed(float fSpeed)
    //	{
    //		this.m_Animator.speed = fSpeed;
    //	}

    //	public bool CheckCommandTarget(M_Character actor, M_Character target, S_UseEffect useEffectData)
    //	{
    //		if (actor == null || target == null || useEffectData == null)
    //		{
    //			return false;
    //		}
    //		if (this.IsLoseHeart())
    //		{
    //			return !useEffectData.DeBuffer.Contains(84) || (target is M_Player && target.IsDead());
    //		}
    //		switch (useEffectData.emTarget)
    //		{
    //		case ENUM_UseTarget.Partner:
    //			if (actor is M_Player && target is M_Mob)
    //			{
    //				return false;
    //			}
    //			if (actor is M_Mob && target is M_Player)
    //			{
    //				return false;
    //			}
    //			if (useEffectData.emItemType == ENUM_ItemSubType.Attack)
    //			{
    //				return false;
    //			}
    //			if (useEffectData.emItemType == ENUM_ItemSubType.Heal && target.IsDead())
    //			{
    //				return false;
    //			}
    //			if (useEffectData.DeBuffer.Contains(84) && !target.IsDead())
    //			{
    //				return false;
    //			}
    //			break;
    //		case ENUM_UseTarget.Enemy:
    //			if (actor is M_Player && target is M_Player)
    //			{
    //				return false;
    //			}
    //			if (actor is M_Mob && target is M_Mob)
    //			{
    //				return false;
    //			}
    //			if (useEffectData.emItemType == ENUM_ItemSubType.Heal)
    //			{
    //				return false;
    //			}
    //			if (target.IsDead())
    //			{
    //				return false;
    //			}
    //			break;
    //		case ENUM_UseTarget.Self:
    //			if (actor != target)
    //			{
    //				return false;
    //			}
    //			break;
    //		default:
    //			return false;
    //		}
    //		return true;
    //	}

    //	public virtual M_Character ChooseTarget_AI(int skillID)
    //	{
    //		return null;
    //	}

    //	public virtual M_Character ChooseLoseHeartTarget_AI(ENUM_UseTarget emTarget)
    //	{
    //		List<M_Character> list = new List<M_Character>();
    //		if (((this is M_Player || this is M_Guard) && emTarget == ENUM_UseTarget.Enemy) || (this is M_Mob && emTarget == ENUM_UseTarget.Partner))
    //		{
    //			foreach (M_Player current in this.m_FightSceneMgr.GetRoleList().Values)
    //			{
    //				if (!current.IsDead() && current.m_RoleModel.activeSelf)
    //				{
    //					list.Add(current);
    //				}
    //			}
    //		}
    //		if (((this is M_Player || this is M_Guard) && emTarget == ENUM_UseTarget.Partner) || (this is M_Mob && emTarget == ENUM_UseTarget.Enemy))
    //		{
    //			foreach (M_Mob current2 in this.m_FightSceneMgr.GetMobList().Values)
    //			{
    //				if (!current2.IsDead() && current2.m_RoleModel.activeSelf)
    //				{
    //					list.Add(current2);
    //				}
    //			}
    //		}
    //		if (emTarget == ENUM_UseTarget.Enemy)
    //		{
    //			list.Remove(this);
    //		}
    //		if (list.Count == 0)
    //		{
    //			if (this is M_Player || this is M_Guard)
    //			{
    //				foreach (M_Mob current3 in this.m_FightSceneMgr.GetMobList().Values)
    //				{
    //					if (!current3.IsDead() && current3.m_RoleModel.activeSelf)
    //					{
    //						list.Add(current3);
    //					}
    //				}
    //			}
    //			else
    //			{
    //				foreach (M_Player current4 in this.m_FightSceneMgr.GetRoleList().Values)
    //				{
    //					if (!current4.IsDead() && current4.m_RoleModel.activeSelf)
    //					{
    //						list.Add(current4);
    //					}
    //				}
    //			}
    //		}
    //		int num = UnityEngine.Random.Range(0, list.Count);
    //		if (num < 0 || num >= list.Count)
    //		{
    //			return null;
    //		}
    //		return list[num];
    //	}

    //	public virtual void Debut()
    //	{
    //		this.PlayAnimationImmediately("Base Layer.debut");
    //	}

    //	public virtual void CheckRelfexDamage(Enum_FightHitType emHitType, int hitValue, M_Character actor)
    //	{
    //		if (this.m_BuffList.ContainsKey(20))
    //		{
    //			float num = (float)(hitValue * this.m_BuffList[20].m_BuffData.ReflexDmg) / 100f;
    //			int num2 = Mathf.FloorToInt(num + 0.1f);
    //			if (emHitType == Enum_FightHitType.DamageHP && num2 <= -1)
    //			{
    //				actor.ChangeHP_Buff(num2, this, Enum_FightHitType.DamageHP);
    //			}
    //			if (emHitType == Enum_FightHitType.DamageMP && num2 <= -1)
    //			{
    //				actor.ChangeMP_Buff(num2, Enum_FightHitType.DamageMP);
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.Reflex)
    //			{
    //				float num = (float)(hitValue * this.m_NoRemoveBuffList[i].m_BuffData.ReflexDmg) / 100f;
    //				int num2 = Mathf.FloorToInt(num + 0.1f);
    //				if (emHitType == Enum_FightHitType.DamageHP && num2 <= -1)
    //				{
    //					actor.ChangeHP_Buff(num2, this, Enum_FightHitType.DamageHP);
    //				}
    //				if (emHitType == Enum_FightHitType.DamageMP && num2 <= -1)
    //				{
    //					actor.ChangeMP_Buff(num2, Enum_FightHitType.DamageMP);
    //				}
    //			}
    //		}
    //	}

    //	public void CheckDrainLifeDamage(int hitValue, M_Character actor)
    //	{
    //		if (actor.m_BuffList.ContainsKey(32))
    //		{
    //			Buff_Base buff_Base = actor.m_BuffList[32];
    //			float num = (float)(hitValue * buff_Base.m_BuffData.TransferDmg) / 100f;
    //			if (num < 0f)
    //			{
    //				num = -num;
    //			}
    //			num += 0.1f;
    //			actor.OnHitDamage(Enum_FightHitType.DrainLife, false, false, Mathf.RoundToInt(num), this);
    //		}
    //		for (int i = 0; i < actor.m_NoRemoveBuffList.Count; i++)
    //		{
    //			Buff_Base buff_Base = actor.m_NoRemoveBuffList[i];
    //			if (buff_Base.m_BuffData.emBuffType == ENUM_BuffType.DrainLife)
    //			{
    //				float num = (float)(hitValue * buff_Base.m_BuffData.TransferDmg) / 100f;
    //				if (num < 0f)
    //				{
    //					num = -num;
    //				}
    //				num += 0.1f;
    //				actor.OnHitDamage(Enum_FightHitType.DrainLife, false, false, Mathf.RoundToInt(num), this);
    //			}
    //		}
    //	}

    //	public virtual void OnCommandFinish(FightCommand command)
    //	{
    //	}

    //	public virtual void OnHitAnimation(Enum_FightHitType hitType)
    //	{
    //	}

    //	public virtual void OnHitDamage(Enum_FightHitType hitType, bool bCritical, bool bBlock, int value, M_Character actor)
    //	{
    //	}

    //	public virtual void HitDamageReCaculate_Buff_MagicItem(ref Enum_FightHitType hitType, ref int value, M_Character actor)
    //	{
    //		if (hitType == Enum_FightHitType.DamageHP || hitType == Enum_FightHitType.DamageMP)
    //		{
    //			this.DmgReduceAbsorb(ref hitType, ref value);
    //			if (this.m_BuffList.ContainsKey(79))
    //			{
    //				this.RemoveBuff(79);
    //			}
    //			if (hitType != Enum_FightHitType.DamageHP && hitType != Enum_FightHitType.DamageMP)
    //			{
    //				return;
    //			}
    //			if (actor == null)
    //			{
    //				return;
    //			}
    //			this.CheckRelfexDamage(hitType, value, actor);
    //			this.CheckDrainLifeDamage(value, actor);
    //			if (actor is M_Player)
    //			{
    //				M_Player m_Player = actor as M_Player;
    //				if (m_Player.m_MagicItem_Passive != null)
    //				{
    //					if (m_Player.m_MagicItem_Passive.m_ItemInfo.GUID == 724)
    //					{
    //						m_Player.m_MagicItem_Passive.AbsorbAtk_HP(value);
    //					}
    //					if (m_Player.m_MagicItem_Passive.m_ItemInfo.GUID == 725)
    //					{
    //						m_Player.m_MagicItem_Passive.AbsorbAtk_MP(value);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public virtual void OnLastHit(List<Buff_Base> hitBuffs, GameObject actor)
    //	{
    //	}

    //	public void DmgReduceAbsorb(ref Enum_FightHitType hitType, ref int dmgValue)
    //	{
    //		foreach (KeyValuePair<int, Buff_Base> current in this.m_BuffList)
    //		{
    //			if (current.Value.m_BuffData.emBuffType == ENUM_BuffType.Fearless)
    //			{
    //				dmgValue = 0;
    //				return;
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.Fearless)
    //			{
    //				dmgValue = 0;
    //				return;
    //			}
    //		}
    //		this.DmgReduce(ref dmgValue);
    //		this.DmgAbsorb(ref hitType, ref dmgValue);
    //	}

    //	public virtual void DmgReduce(ref int dmgValue)
    //	{
    //		foreach (KeyValuePair<int, Buff_Base> current in this.m_BuffList)
    //		{
    //			if (current.Value.m_BuffData.emBuffType == ENUM_BuffType.ReduceDmg)
    //			{
    //				this.Buff_ReduceDmg(current.Value, ref dmgValue);
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			Buff_Base buff_Base = this.m_NoRemoveBuffList[i];
    //			if (buff_Base.m_BuffData.emBuffType == ENUM_BuffType.ReduceDmg)
    //			{
    //				this.Buff_ReduceDmg(buff_Base, ref dmgValue);
    //			}
    //		}
    //		if (dmgValue == 0)
    //		{
    //			dmgValue = -1;
    //		}
    //	}

    //	public virtual void DmgAbsorb(ref Enum_FightHitType hitType, ref int dmgValue)
    //	{
    //		foreach (KeyValuePair<int, Buff_Base> current in this.m_BuffList)
    //		{
    //			if (current.Value.m_BuffData.emBuffType == ENUM_BuffType.AbsorbShield)
    //			{
    //				this.Buff_AbsortDmg(ref hitType, current.Value, ref dmgValue);
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			Buff_Base buff_Base = this.m_NoRemoveBuffList[i];
    //			if (buff_Base.m_BuffData.emBuffType == ENUM_BuffType.AbsorbShield)
    //			{
    //				this.Buff_AbsortDmg(ref hitType, buff_Base, ref dmgValue);
    //			}
    //		}
    //		if (hitType != Enum_FightHitType.DamageHP)
    //		{
    //			return;
    //		}
    //		if (this is M_Player)
    //		{
    //			M_Player m_Player = this as M_Player;
    //			if (m_Player.m_MagicItem_Passive != null && m_Player.m_MagicItem_Passive.m_ItemInfo.GUID == 741)
    //			{
    //				int num = m_Player.m_MagicItem_Passive.SmallMush(dmgValue);
    //				dmgValue = num;
    //				if (dmgValue == 0)
    //				{
    //					hitType = Enum_FightHitType.None;
    //				}
    //			}
    //		}
    //	}

    //	public void Buff_ReduceDmg(Buff_Base buff, ref int dmgValue)
    //	{
    //		if (!(buff is Buff_ReduceDmg) || dmgValue == 0)
    //		{
    //			return;
    //		}
    //		float num = (float)dmgValue * (float)(100 - buff.m_BuffData.ReduceDmg) / 100f;
    //		num += 0.1f;
    //		dmgValue = Mathf.RoundToInt(num);
    //	}

    //	public void Buff_AbsortDmg(ref Enum_FightHitType hitType, Buff_Base buff, ref int dmgValue)
    //	{
    //		if (!(buff is Buff_AbsorbShield) || dmgValue >= 0)
    //		{
    //			return;
    //		}
    //		Buff_AbsorbShield buff_AbsorbShield = buff as Buff_AbsorbShield;
    //		if (buff_AbsorbShield.m_AbsortValue >= -dmgValue)
    //		{
    //			dmgValue = 0;
    //			buff_AbsorbShield.m_AbsortValue += dmgValue;
    //			hitType = Enum_FightHitType.Absort;
    //		}
    //		else
    //		{
    //			dmgValue += buff_AbsorbShield.m_AbsortValue;
    //			buff_AbsorbShield.m_AbsortValue = 0;
    //		}
    //	}

    //	public virtual void AddStatisticsValue(Enum_FightStatisticsType emType, int value)
    //	{
    //		switch (emType)
    //		{
    //		case Enum_FightStatisticsType.Attack:
    //			this.m_TotalAttack += value;
    //			break;
    //		case Enum_FightStatisticsType.Damage:
    //			this.m_TotalDamage += value;
    //			break;
    //		case Enum_FightStatisticsType.Heal:
    //			this.m_TotalHeal += value;
    //			break;
    //		case Enum_FightStatisticsType.BeHealed:
    //			this.m_TotalBeHealed += value;
    //			break;
    //		}
    //	}

    public void NotifyEndAction()
    {
        m_FightSceneMgr.NotifyEndAction(this);
    }

    public bool SetAction(int action)
    {
        //if (action == ACTION_ATTACK || (action >= 0 && action < Skills.Count))
        //{
        //    Action = action;
        //    Manager.ShowTargetScopesOrDoAction(this);
        //    return true;
        //}
        return false;
    }
}
