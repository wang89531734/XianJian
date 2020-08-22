using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class M_Mob : M_Character
{
    public int m_MobGUID;

    public int m_IconNo = -1;

    public S_MobData m_MobData;

    public int m_MobSerialID;

    private M_Player m_LastAttackTarget;

    public FightRoleData m_BaseFihgtRoleData = new FightRoleData();

    public int m_DeadSkillID = -1;

    public Queue<int> m_StartSkill = new Queue<int>();

    public Dictionary<int, int> m_NormalSkill = new Dictionary<int, int>();

    public Dictionary<int, int> m_HpSkill = new Dictionary<int, int>();

    public string m_DebutPosStr = string.Empty;

    public Transform m_DebutTargetTransform;

    public int m_BonusDropRate;

    public static int State_Walk_Front = Animator.StringToHash("Base Layer.walk-front_B");

    public static int State_Walk_Back = Animator.StringToHash("Base Layer.walk-back_B");

    public static int State_Giddy = Animator.StringToHash("Base Layer.giddy_B");

    public bool m_bTurnAction = true;

    private bool m_bBeCaught;

    public bool m_bCanBeTarget = true;

    private int m_RagdollDestroyTime = 5;

    private string m_DeadInkEffectName = "same_repulse";

    private AudioSource m_HurtAudioSource;

    private void Start()
    {
        //float num = UnityEngine.Random.Range(-1f, 1f);
        ////this.m_ActionCDTimer = base.GetActionCD() + num;
        //this.m_HurtAudioSource = base.gameObject.AddComponent<AudioSource>();
    }

    public virtual void InitMob(int MobGUID)
    {
        UnityEngine.Debug.Log("执行InitMob");
        //this.m_emFight = M_Character.Enum_FightStatus.Idle;
        ////if (this.m_CharacterController != null)
        ////{
        ////    if (MobGUID >= 2048 && MobGUID <= 2051)
        ////    {
        ////        this.m_CharacterController.enabled = false;
        ////        this.m_EnableCharacterContoller = false;
        ////    }
        ////    else
        ////    {
        ////        this.m_CharacterController.enabled = true;
        ////        this.m_EnableCharacterContoller = true;
        ////    }
        ////}
        ////else
        ////{
        ////    UnityEngine.Debug.LogError("m_CharacterController == null");
        ////}
        //S_Item data = GameDataDB.ItemDB.GetData(MobGUID);
        //if (data == null || data.emItemType != ENUM_ItemType.Mob)
        //{
        //    UnityEngine.Debug.LogWarning("無法取得怪物資料 MobGUID:" + MobGUID);
        //    return;
        //}
        //this.m_MobGUID = MobGUID;
        //this.m_IconNo = data.IconNo;
        //this.m_MobData = data.MobData;
        ////this.ResetSkill();
        //this.InitFightRoleData();
        ////this.m_ActionCD = (float)(1000 - this.m_FightRoleData.Agi) / 100f;
        ////this.SkillSetting(data.MobData);
        //this.m_CharacterName = data.Name;
        ////this.UpdateBuffIconCallback = new M_Character.UpdateBuffIcon(this.UpdateUIBuffIcon);
        //this.SetStartUpdate(false);
    }

    //	public override void SetStartUpdate(bool bStart)
    //	{
    //		base.SetStartUpdate(bStart);
    //		if (bStart)
    //		{
    //			this.GenerateStartSkill(this.m_MobData.StartSkillID);
    //		}
    //	}

    //	private void GenerateStartSkill(List<int> startSkill)
    //	{
    //		for (int i = 0; i < startSkill.Count; i++)
    //		{
    //			S_Skill data = GameDataDB.SkillDB.GetData(startSkill[i]);
    //			if (data != null)
    //			{
    //				S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //				if (data2 != null)
    //				{
    //					if (data2.ActDataName == null || data2.ActDataName == "0")
    //					{
    //						if (data2.emTarget == ENUM_UseTarget.Self || data2.emTarget == ENUM_UseTarget.Partner)
    //						{
    //							this.m_CommandQueue.Add(new FightCommand_NoActDataSkill(this, this, startSkill[i]));
    //						}
    //						if (data2.emTarget == ENUM_UseTarget.Enemy)
    //						{
    //							this.m_CommandQueue.Add(new FightCommand_NoActDataSkill(this, this.ChooseAttackTarget_AI(), startSkill[i]));
    //						}
    //					}
    //					else
    //					{
    //						if (data2.emTarget == ENUM_UseTarget.Self || data2.emTarget == ENUM_UseTarget.Partner)
    //						{
    //							this.m_CommandQueue.Add(new FightCommand_Skill(this, this, startSkill[i]));
    //						}
    //						if (data2.emTarget == ENUM_UseTarget.Enemy)
    //						{
    //							this.m_CommandQueue.Add(new FightCommand_Skill(this, this.ChooseAttackTarget_AI(), startSkill[i]));
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public ENUM_ElementType GetMobDefElementType()
    //	{
    //		if (this.m_BuffList.ContainsKey(67))
    //		{
    //			return ENUM_ElementType.Wind;
    //		}
    //		if (this.m_BuffList.ContainsKey(70))
    //		{
    //			return ENUM_ElementType.Earth;
    //		}
    //		if (this.m_BuffList.ContainsKey(69))
    //		{
    //			return ENUM_ElementType.Water;
    //		}
    //		if (this.m_BuffList.ContainsKey(68))
    //		{
    //			return ENUM_ElementType.Fire;
    //		}
    //		return this.m_MobData.emElemnt;
    //	}

    //	public ENUM_ElementType GetMobOriginalElementType()
    //	{
    //		return this.m_MobData.emElemnt;
    //	}

    //	public override void Debut()
    //	{
    //		if (this.m_DebutTargetTransform == null)
    //		{
    //			base.Debut();
    //		}
    //		else
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Debut;
    //			this.m_CharacterController.enabled = false;
    //			this.UpdateDirection_Directly(this.m_DebutTargetTransform.position);
    //		}
    //	}

    //	private void Update()
    //	{
    //		base.ModelDropCheck();
    //		if (base.IsDead())
    //		{
    //			return;
    //		}
    //		if (this.m_FightSceneMgr.m_IsFightFinish)
    //		{
    //			if (this.m_emFight != M_Character.Enum_FightStatus.Finish)
    //			{
    //				this.SetFightFinish();
    //			}
    //			return;
    //		}
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Debut)
    //		{
    //			this.Update_Debut();
    //			return;
    //		}
    //		if (!this.m_bStartUpdate)
    //		{
    //			return;
    //		}
    //		if (this.m_bStoryMode)
    //		{
    //			this.Update_StoryMode();
    //		}
    //		else
    //		{
    //			this.Update_Movement();
    //		}
    //		if (this.m_bPause)
    //		{
    //			return;
    //		}
    //		base.Update_Buff();
    //		this.Update_AI();
    //	}

    //	public virtual void Update_AI()
    //	{
    //		if (this.m_bStoryMode)
    //		{
    //			return;
    //		}
    //		if (base.CannotUseAnyCommand())
    //		{
    //			return;
    //		}
    //		this.m_ActionCDTimer -= Time.deltaTime;
    //		if (this.m_ActionCDTimer <= 0f)
    //		{
    //			if (this.m_CommandQueue.Count == 0)
    //			{
    //				int num = this.RandNormalSkill();
    //				this.AddSkillCommand(num, this.ChooseTarget_AI(num));
    //			}
    //			int num2 = UnityEngine.Random.Range(((int)base.GetActionCD() - 1) * 2, ((int)base.GetActionCD() + 1) * 2);
    //			this.m_ActionCDTimer = (float)num2 / 2f;
    //		}
    //	}

    //	public override M_Character ChooseTarget_AI(int skillID)
    //	{
    //		S_Skill data = GameDataDB.SkillDB.GetData(skillID);
    //		if (data == null)
    //		{
    //			return null;
    //		}
    //		S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //		if (data2 == null)
    //		{
    //			return null;
    //		}
    //		if (data2.emTarget == ENUM_UseTarget.Self)
    //		{
    //			return this;
    //		}
    //		if (base.IsLoseHeart())
    //		{
    //			return this.ChooseLoseHeartTarget_AI(data2.emTarget);
    //		}
    //		switch (data2.emItemType)
    //		{
    //		case ENUM_ItemSubType.Attack:
    //			return this.ChooseAttackTarget_AI();
    //		case ENUM_ItemSubType.Assist:
    //			return this.ChooseAssistTarget_AI(data2.emTarget, data2.Buffer);
    //		case ENUM_ItemSubType.Heal:
    //			return this.ChooseHealTarget_AI();
    //		default:
    //			return null;
    //		}
    //	}

    //	public virtual M_Character ChooseAttackTarget_AI()
    //	{
    //		int num = 0;
    //		Dictionary<M_Player, int> allPlayerScore = this.m_FightSceneMgr.GetAllPlayerScore();
    //		if (this.m_LastAttackTarget != null && allPlayerScore.ContainsKey(this.m_LastAttackTarget))
    //		{
    //			Dictionary<M_Player, int> dictionary;
    //			Dictionary<M_Player, int> expr_31 = dictionary = allPlayerScore;
    //			M_Player lastAttackTarget;
    //			M_Player expr_3A = lastAttackTarget = this.m_LastAttackTarget;
    //			int num2 = dictionary[lastAttackTarget];
    //			expr_31[expr_3A] = num2 - 10;
    //		}
    //		foreach (KeyValuePair<M_Player, int> current in allPlayerScore)
    //		{
    //			num += current.Value;
    //		}
    //		int num3 = UnityEngine.Random.Range(1, num);
    //		foreach (KeyValuePair<M_Player, int> current2 in allPlayerScore)
    //		{
    //			if (num3 <= current2.Value)
    //			{
    //				return current2.Key;
    //			}
    //			num3 -= current2.Value;
    //		}
    //		return null;
    //	}

    //	public virtual M_Character ChooseHealTarget_AI()
    //	{
    //		List<M_Mob> list = new List<M_Mob>();
    //		foreach (KeyValuePair<int, M_Mob> current in this.m_FightSceneMgr.GetMobList())
    //		{
    //			if (!(current.Value == null) && !current.Value.IsDead())
    //			{
    //				if (current.Value.m_RoleModel.activeSelf)
    //				{
    //					if (current.Value.m_FightRoleData.HP < current.Value.m_FightRoleData.MaxHP)
    //					{
    //						list.Add(current.Value);
    //					}
    //				}
    //			}
    //		}
    //		if (list.Count == 0)
    //		{
    //			return this;
    //		}
    //		int num = UnityEngine.Random.Range(1, 101);
    //		int num2 = 100 / list.Count;
    //		num2 = num / num2;
    //		if (num2 >= list.Count)
    //		{
    //			num2 = list.Count - 1;
    //		}
    //		if (num2 < 0)
    //		{
    //			num2 = 0;
    //		}
    //		return list[num2];
    //	}

    //	public virtual M_Character ChooseAssistTarget_AI(ENUM_UseTarget emTarget, List<int> buff)
    //	{
    //		if (emTarget == ENUM_UseTarget.Enemy)
    //		{
    //			return this.ChooseAttackTarget_AI();
    //		}
    //		if (emTarget == ENUM_UseTarget.Self)
    //		{
    //			return this;
    //		}
    //		List<M_Mob> list = new List<M_Mob>();
    //		foreach (KeyValuePair<int, M_Mob> current in this.m_FightSceneMgr.GetMobList())
    //		{
    //			if (!(current.Value == null) && !current.Value.IsDead())
    //			{
    //				if (current.Value.m_RoleModel.activeSelf)
    //				{
    //					list.Add(current.Value);
    //				}
    //			}
    //		}
    //		if (list.Count == 0)
    //		{
    //			return this;
    //		}
    //		int num = UnityEngine.Random.Range(1, 101);
    //		int num2 = 100 / list.Count;
    //		num2 = num / num2;
    //		if (num2 >= list.Count)
    //		{
    //			num2 = list.Count - 1;
    //		}
    //		if (num2 < 0)
    //		{
    //			num2 = 0;
    //		}
    //		return list[num2];
    //	}

    //	public override void Update_Debut()
    //	{
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		float num = Vector3.Distance(this.m_DebutTargetTransform.position, this.GetModelPosition());
    //		if (num < 1f)
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //			this.m_CharacterController.enabled = this.m_EnableCharacterContoller;
    //			if (currentAnimatorStateInfo.nameHash != this.State_Standby && !this.m_Animator.IsInTransition(0))
    //			{
    //				base.PlayAnimationImmediately(this.State_Standby);
    //			}
    //			this.m_MoveTimer = 0f;
    //			this.m_IdleTimer = 0f;
    //			return;
    //		}
    //		if (currentAnimatorStateInfo.nameHash != M_Character.State_Sprint && !this.m_Animator.IsInTransition(0))
    //		{
    //			base.PlayAnimationImmediately(M_Character.State_Sprint);
    //		}
    //		this.UpdateDirection_Directly(this.m_DebutTargetTransform.position);
    //	}

    //	public override void Update_Idle()
    //	{
    //		this.CheckTarget();
    //		if (this.m_CommandQueue.Count > 0)
    //		{
    //			FightCommand fightCommand = this.m_CommandQueue[0];
    //			if (fightCommand is FightCommand_NoActDataSkill)
    //			{
    //				fightCommand.Execute();
    //				this.m_CommandQueue.Remove(fightCommand);
    //				return;
    //			}
    //			this.m_RunToTargetTimer = 0f;
    //			this.m_emFight = M_Character.Enum_FightStatus.MoveToAttack;
    //			this.m_bNoMoveAttack = true;
    //			return;
    //		}
    //		else
    //		{
    //			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //			if (currentAnimatorStateInfo.nameHash == M_Character.State_Hit || currentAnimatorStateInfo.nameHash == M_Character.State_Hit2)
    //			{
    //				return;
    //			}
    //			if (this.m_Animator.IsInTransition(0))
    //			{
    //				return;
    //			}
    //			if (this.m_MoveTimer > 0f)
    //			{
    //				this.m_MoveTimer -= Time.deltaTime;
    //				if (this.m_MoveTimer <= 0f)
    //				{
    //					this.m_MoveTimer = 0f;
    //				}
    //				return;
    //			}
    //			if (this.m_IdleTimer > 0f)
    //			{
    //				this.m_IdleTimer -= Time.deltaTime;
    //			}
    //			if (this.m_IdleTimer > 0f)
    //			{
    //				if (currentAnimatorStateInfo.nameHash != this.State_Standby)
    //				{
    //					this.CrossFadeAnimation(this.State_Standby, 0.5f);
    //				}
    //				return;
    //			}
    //			if (this.m_MobData.MoveTime == 0f)
    //			{
    //				if (currentAnimatorStateInfo.nameHash != this.State_Standby && !this.m_Animator.IsInTransition(0))
    //				{
    //					this.CrossFadeAnimation(this.State_Standby, 0.5f);
    //				}
    //				return;
    //			}
    //			int num = UnityEngine.Random.Range(1, 101);
    //			if (num <= 75)
    //			{
    //				if (this.m_bPause)
    //				{
    //					this.m_IdleTimer = UnityEngine.Random.Range(15f, 30f);
    //				}
    //				else
    //				{
    //					this.m_IdleTimer = UnityEngine.Random.Range(10f, 15f);
    //				}
    //				if (currentAnimatorStateInfo.nameHash != this.State_Standby && !this.m_Animator.IsInTransition(0))
    //				{
    //					this.CrossFadeAnimation(this.State_Standby, 0.5f);
    //				}
    //				return;
    //			}
    //			if (this.m_FaceToTarget == null || this.m_FaceToTarget == this)
    //			{
    //				return;
    //			}
    //			if (this.m_FaceToTarget.IsDead() || !this.m_FaceToTarget.m_RoleModel.activeSelf)
    //			{
    //				base.SetFaceToTarget(this.m_FightSceneMgr.GetMainTarget());
    //			}
    //			this.UpdateDirection_Directly(this.m_FaceToTarget.GetModelPosition());
    //			this.m_MoveTimer = this.m_MobData.MoveTime;
    //			float num2 = Vector3.Distance(this.m_FaceToTarget.GetModelPosition(), this.GetModelPosition()) - this.m_FaceToTarget.m_RoleRadius;
    //			int towardPosDirection = this.GetTowardPosDirection(this.m_FightSceneMgr.GetNearestMobIdlePos(this.GetModelPosition()));
    //			if (towardPosDirection == 0)
    //			{
    //				this.CrossFadeAnimation(M_Mob.State_Walk_Front, 0.5f);
    //			}
    //			else if (towardPosDirection == 1)
    //			{
    //				this.CrossFadeAnimation(M_Mob.State_Walk_Back, 0.5f);
    //			}
    //			return;
    //		}
    //	}

    //	public override void Update_AfterAttackMoveBack()
    //	{
    //		if (this.m_bNoMoveAttack)
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //			this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //		}
    //		else
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.JumpBack;
    //			this.CrossFadeAnimation(M_Character.State_BackJumpSmall, 0.1f);
    //		}
    //	}

    //	public override void Update_JumpBack()
    //	{
    //		if (this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash == this.State_Standby)
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //			this.m_MoveTimer = 1.5f;
    //			this.CrossFadeAnimation(M_Mob.State_Walk_Back, 0.1f);
    //		}
    //	}

    //	public override void SetCanNotActionStateAnimation(bool bCantAction)
    //	{
    //		if (base.IsDead())
    //		{
    //			return;
    //		}
    //		if (bCantAction)
    //		{
    //			if (base.CannotUseAnyCommand())
    //			{
    //				return;
    //			}
    //			this.CrossFadeAnimation(M_Character.State_Giddy_Cycle, 0.1f);
    //		}
    //		else
    //		{
    //			if (!base.CannotUseAnyCommand())
    //			{
    //				return;
    //			}
    //			this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //		}
    //	}

    //	public override void Update_CantActionState()
    //	{
    //		base.Update_CantActionState();
    //		if (this.m_Animator.IsInTransition(0))
    //		{
    //			return;
    //		}
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		if (currentAnimatorStateInfo.nameHash == M_Character.State_Giddy_Cycle)
    //		{
    //			return;
    //		}
    //		if (currentAnimatorStateInfo.nameHash == M_Character.State_Hit)
    //		{
    //			return;
    //		}
    //		if (currentAnimatorStateInfo.nameHash == M_Character.State_Hit2)
    //		{
    //			return;
    //		}
    //		this.CrossFadeAnimation(M_Character.State_Giddy_Cycle, 0.1f);
    //	}

    //	public override bool DoCommand(FightCommand skillCommand)
    //	{
    //		if (!base.DoCommand(skillCommand))
    //		{
    //			return false;
    //		}
    //		if (skillCommand.m_Target is M_Player)
    //		{
    //			this.m_LastAttackTarget = (skillCommand.m_Target as M_Player);
    //		}
    //		return true;
    //	}

    //	public virtual void CheckTarget()
    //	{
    //		FightCommand fightCommand = null;
    //		if (this.m_CommandQueue.Count > 0)
    //		{
    //			fightCommand = this.m_CommandQueue[0];
    //		}
    //		if (fightCommand != null)
    //		{
    //			M_Character target = fightCommand.m_Target;
    //			S_UseEffect data = GameDataDB.UseEffectDB.GetData(fightCommand.m_UseEffectID);
    //			if (data.DeBuffer.Contains(84))
    //			{
    //				return;
    //			}
    //			if (target == null || target.IsDead() || !target.m_RoleModel.activeSelf)
    //			{
    //				if (data != null)
    //				{
    //					if (data.emTarget == ENUM_UseTarget.Enemy)
    //					{
    //						fightCommand.m_Target = this.m_FightSceneMgr.GetFirstOrder_Role();
    //						if (fightCommand.m_Target == null)
    //						{
    //							this.m_CommandQueue.Remove(fightCommand);
    //							return;
    //						}
    //						this.m_ActionTargetModel = fightCommand.m_Target.m_RoleModel;
    //						if (fightCommand.m_Target is M_Player || base.IsLoseHeart())
    //						{
    //							base.SetFaceToTarget(fightCommand.m_Target);
    //						}
    //					}
    //					if (data.emTarget == ENUM_UseTarget.Partner)
    //					{
    //						fightCommand.m_Target = this.m_FightSceneMgr.GetFirstOrder_Mob();
    //						if (fightCommand.m_Target == null)
    //						{
    //							this.m_CommandQueue.Remove(fightCommand);
    //							return;
    //						}
    //					}
    //				}
    //			}
    //			else
    //			{
    //				this.m_ActionTargetModel = fightCommand.m_Target.m_RoleModel;
    //				if (fightCommand.m_Target is M_Player || base.IsLoseHeart())
    //				{
    //					base.SetFaceToTarget(fightCommand.m_Target);
    //				}
    //			}
    //		}
    //		if ((this.m_FaceToTarget == null || this.m_FaceToTarget.IsDead() || this.m_FaceToTarget is M_Mob) && this.m_FightSceneMgr.GetFirstOrder_Role() != null)
    //		{
    //			this.m_ActionTargetModel = this.m_FightSceneMgr.GetFirstOrder_Role().m_RoleModel;
    //			base.SetFaceToTarget(this.m_FightSceneMgr.GetFirstOrder_Role());
    //		}
    //	}

    //	private void ResetSkill()
    //	{
    //		this.m_DeadSkillID = -1;
    //		this.m_StartSkill.Clear();
    //		this.m_NormalSkill.Clear();
    //		this.m_HpSkill.Clear();
    //		this.ClearCommand();
    //	}

    //	public bool Command_NormalAttack()
    //	{
    //		if (this.m_ActionTargetModel == null)
    //		{
    //			return false;
    //		}
    //		int num = this.RandNormalSkill();
    //		return num > 0;
    //	}

    //	private void Command_TriggerSkill(int skillId, M_Character attacker)
    //	{
    //	}

    //	public override bool IsStandby()
    //	{
    //		return !(this.m_Animator == null) && this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash == this.State_Standby;
    //	}

    //	public bool IsIdle()
    //	{
    //		return this.m_emFight == M_Character.Enum_FightStatus.Idle;
    //	}

    //	public bool CanBeTarget()
    //	{
    //		return this.m_bCanBeTarget && !base.IsDead() && this.m_RoleModel.activeSelf;
    //	}

    //	public void SetCanBeTarget(bool bCan)
    //	{
    //		bool flag = this.m_bCanBeTarget != bCan;
    //		this.m_bCanBeTarget = bCan;
    //		if (flag)
    //		{
    //			this.m_FightSceneMgr.OnMobEnableUpdate(this, bCan);
    //		}
    //	}

    //	public void UpdateUIBuffIcon()
    //	{
    //		UI_Fight.Instance.UpdateMobBuffIcon(this.m_MobSerialID);
    //	}

    //	public override void UpdateDirection_Directly(Vector3 targetPos)
    //	{
    //		if (this.m_MobData.MoveTime <= 0f)
    //		{
    //			return;
    //		}
    //		base.UpdateDirection_Directly(targetPos);
    //	}

    //	public float GetDifficultyValueRate()
    //	{
    //		switch (NormalSettingSystem.Instance.GetNormalSetting().m_FightingDifficulty)
    //		{
    //		case Enum_FightingDifficulty.Easy:
    //			return 0.8f;
    //		case Enum_FightingDifficulty.Normal:
    //			return 1f;
    //		case Enum_FightingDifficulty.Hard:
    //			return 1.2f;
    //		default:
    //			return 1f;
    //		}
    //	}

    //	public override void InitFightRoleData()
    //	{
    //		this.m_FightRoleData.Level = this.m_MobData.Level;
    //		this.m_BaseFihgtRoleData.MaxHP = Mathf.RoundToInt((float)this.m_MobData.MaxHP * this.GetDifficultyValueRate() + 0.1f);
    //		this.m_FightRoleData.MaxHP = this.m_BaseFihgtRoleData.MaxHP;
    //		this.m_FightRoleData.HP = this.m_FightRoleData.MaxHP;
    //		this.m_FightRoleData.MaxMP = this.m_MobData.MaxMP;
    //		this.m_FightRoleData.MP = this.m_FightRoleData.MP;
    //		this.m_BaseFihgtRoleData.Atk = Mathf.RoundToInt((float)this.m_MobData.Attack * this.GetDifficultyValueRate() + 0.1f);
    //		this.m_FightRoleData.Atk = this.m_BaseFihgtRoleData.Atk;
    //		this.m_BaseFihgtRoleData.Def = Mathf.RoundToInt((float)this.m_MobData.Def * this.GetDifficultyValueRate() + 0.1f);
    //		this.m_FightRoleData.Def = this.m_BaseFihgtRoleData.Def;
    //		this.m_BaseFihgtRoleData.MagicAtk = Mathf.RoundToInt((float)this.m_MobData.MAtk * this.GetDifficultyValueRate() + 0.1f);
    //		this.m_FightRoleData.MagicAtk = this.m_BaseFihgtRoleData.MagicAtk;
    //		this.m_BaseFihgtRoleData.MagicDef = Mathf.RoundToInt((float)this.m_MobData.MDef * this.GetDifficultyValueRate() + 0.1f);
    //		this.m_FightRoleData.MagicDef = this.m_BaseFihgtRoleData.MagicDef;
    //		this.m_BaseFihgtRoleData.Agi = this.m_MobData.Agi;
    //		if (NormalSettingSystem.Instance.GetNormalSetting().m_FightingDifficulty == Enum_FightingDifficulty.Hard)
    //		{
    //			this.m_BaseFihgtRoleData.Agi += 100;
    //		}
    //		this.m_FightRoleData.Agi = this.m_BaseFihgtRoleData.Agi;
    //		this.m_BaseFihgtRoleData.Dodge = this.m_MobData.Dodge;
    //		this.m_BaseFihgtRoleData.Block = this.m_MobData.Block;
    //		this.m_BaseFihgtRoleData.Critical = this.m_MobData.Critical;
    //		this.m_FightRoleData.Dodge = this.m_MobData.Dodge;
    //		this.m_FightRoleData.Block = this.m_MobData.Block;
    //		this.m_FightRoleData.Critical = this.m_MobData.Critical;
    //		int[] atkElement = new int[4];
    //		this.m_FightRoleData.AtkElement = atkElement;
    //		int[] array = new int[4];
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			if (i < this.m_MobData.DefElement.Length)
    //			{
    //				array[i] = this.m_MobData.DefElement[i];
    //			}
    //			else
    //			{
    //				array[i] = 0;
    //			}
    //		}
    //		this.m_FightRoleData.DefElement = array;
    //	}

    //	public override void ChangeHP_Buff(int hp, M_Character sourceCharacter, Enum_FightHitType emType)
    //	{
    //		if (!this.m_bCanBeTarget)
    //		{
    //			return;
    //		}
    //		base.ChangeHP_Buff(hp, sourceCharacter, emType);
    //	}

    //	public override void UpdateFightRoleData()
    //	{
    //		S_RoleAttr_Plus s_RoleAttr_Plus = new S_RoleAttr_Plus();
    //		foreach (KeyValuePair<int, Buff_Base> current in this.m_BuffList)
    //		{
    //			S_RoleAttrPlus_Tmp data = GameDataDB.RoleAttrPlusDB.GetData(current.Value.m_BuffData.RoleAttrPlusID);
    //			if (data != null)
    //			{
    //				s_RoleAttr_Plus += data.RoleAttr_Plus;
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			Buff_Base buff_Base = this.m_NoRemoveBuffList[i];
    //			S_RoleAttrPlus_Tmp data2 = GameDataDB.RoleAttrPlusDB.GetData(buff_Base.m_BuffData.RoleAttrPlusID);
    //			if (data2 != null)
    //			{
    //				s_RoleAttr_Plus += data2.RoleAttr_Plus;
    //			}
    //		}
    //		this.m_FightRoleData.MaxHP = this.m_BaseFihgtRoleData.MaxHP + this.m_BaseFihgtRoleData.MaxHP * s_RoleAttr_Plus.AddMaxRatioHP / 100 + s_RoleAttr_Plus.AddMaxHP;
    //		this.m_FightRoleData.MaxMP = this.m_MobData.MaxMP + this.m_MobData.MaxMP * s_RoleAttr_Plus.AddMaxRatioMP / 100 + s_RoleAttr_Plus.AddMaxMP;
    //		this.m_FightRoleData.Atk = this.m_BaseFihgtRoleData.Atk + this.m_BaseFihgtRoleData.Atk * s_RoleAttr_Plus.AddRatioAttack / 100 + s_RoleAttr_Plus.AddAttack;
    //		this.m_FightRoleData.Def = this.m_BaseFihgtRoleData.Def + this.m_BaseFihgtRoleData.Def * s_RoleAttr_Plus.AddRatioDef / 100 + s_RoleAttr_Plus.AddDef;
    //		if (this.m_FightRoleData.Atk < 0)
    //		{
    //			this.m_FightRoleData.Atk = 0;
    //		}
    //		if (this.m_FightRoleData.Def < 0)
    //		{
    //			this.m_FightRoleData.Def = 0;
    //		}
    //		this.m_FightRoleData.MagicAtk = this.m_BaseFihgtRoleData.MagicAtk + this.m_BaseFihgtRoleData.MagicAtk * s_RoleAttr_Plus.AddRatioMAtk / 100 + s_RoleAttr_Plus.AddMAtk;
    //		this.m_FightRoleData.MagicDef = this.m_BaseFihgtRoleData.MagicDef + this.m_BaseFihgtRoleData.MagicDef * s_RoleAttr_Plus.AddRatioMDef / 100 + s_RoleAttr_Plus.AddMDef;
    //		if (this.m_FightRoleData.MagicAtk < 0)
    //		{
    //			this.m_FightRoleData.MagicAtk = 0;
    //		}
    //		if (this.m_FightRoleData.MagicDef < 0)
    //		{
    //			this.m_FightRoleData.MagicDef = 0;
    //		}
    //		this.m_FightRoleData.Agi = this.m_BaseFihgtRoleData.Agi + s_RoleAttr_Plus.AddAgi;
    //		this.m_FightRoleData.Dodge = this.m_BaseFihgtRoleData.Dodge + s_RoleAttr_Plus.AddDodge;
    //		this.m_FightRoleData.Block = this.m_BaseFihgtRoleData.Block + s_RoleAttr_Plus.AddBlock;
    //		this.m_FightRoleData.Critical = this.m_BaseFihgtRoleData.Critical + s_RoleAttr_Plus.AddCritical;
    //		for (int j = 0; j < 4; j++)
    //		{
    //			this.m_FightRoleData.AtkElement[j] = 0 + s_RoleAttr_Plus.AtkElement[j];
    //		}
    //		for (int k = 0; k < 4; k++)
    //		{
    //			this.m_FightRoleData.DefElement[k] = this.m_MobData.DefElement[k] + s_RoleAttr_Plus.Element[k];
    //		}
    //		base.CheckTransElementTypeBuff();
    //		if (this.m_BuffList.ContainsKey(78))
    //		{
    //			float num = (float)this.m_FightRoleData.Agi * 0.5f;
    //			this.m_FightRoleData.Agi = Mathf.RoundToInt(num + 0.1f);
    //		}
    //		this.m_ActionCD = (float)(1000 - this.m_FightRoleData.Agi) / 100f;
    //	}

    //	private void SkillSetting(S_MobData mobData)
    //	{
    //		if (mobData == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < mobData.NormalSkillID.Count; i++)
    //		{
    //			if (i >= mobData.NormalSkillRate.Count)
    //			{
    //				break;
    //			}
    //			if (this.m_NormalSkill.ContainsKey(mobData.NormalSkillID[i]))
    //			{
    //				Dictionary<int, int> normalSkill;
    //				Dictionary<int, int> expr_46 = normalSkill = this.m_NormalSkill;
    //				int num;
    //				int expr_54 = num = mobData.NormalSkillID[i];
    //				num = normalSkill[num];
    //				expr_46[expr_54] = num + mobData.NormalSkillRate[i];
    //			}
    //			else
    //			{
    //				this.m_NormalSkill.Add(mobData.NormalSkillID[i], mobData.NormalSkillRate[i]);
    //			}
    //		}
    //		for (int j = 0; j < mobData.StartSkillID.Count; j++)
    //		{
    //			this.m_StartSkill.Enqueue(mobData.StartSkillID[j]);
    //		}
    //		for (int k = 0; k < mobData.HpSkillID.Count; k++)
    //		{
    //			if (k >= mobData.HpSkillHP.Count)
    //			{
    //				break;
    //			}
    //			if (this.m_HpSkill.ContainsKey(mobData.HpSkillID[k]))
    //			{
    //				Dictionary<int, int> hpSkill;
    //				Dictionary<int, int> expr_124 = hpSkill = this.m_HpSkill;
    //				int num;
    //				int expr_133 = num = mobData.HpSkillID[k];
    //				num = hpSkill[num];
    //				expr_124[expr_133] = num + mobData.HpSkillHP[k];
    //			}
    //			else
    //			{
    //				this.m_HpSkill.Add(mobData.HpSkillID[k], mobData.HpSkillHP[k]);
    //			}
    //		}
    //		this.m_DeadSkillID = mobData.DeadSkillID;
    //	}

    //	public bool CanCatch()
    //	{
    //		return this.CanBeTarget() && this.m_MobData != null && this.m_MobData.CanCatch == 1;
    //	}

    //	public void SetBeCatchState(bool bCatch)
    //	{
    //		this.m_bBeCaught = bCatch;
    //	}

    //	public bool GetBeCatchState()
    //	{
    //		return this.m_bBeCaught;
    //	}

    //	public new int GetTowardPosDirection(Vector3 pos)
    //	{
    //		Vector3 lhs = pos - this.m_ModelTransform.position;
    //		List<float> list = new List<float>();
    //		list.Add(Vector3.Dot(lhs, this.m_ModelTransform.forward));
    //		list.Add(Vector3.Dot(lhs, -this.m_ModelTransform.forward));
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

    //	public int RandNormalSkill()
    //	{
    //		int num = UnityEngine.Random.Range(1, 101);
    //		foreach (KeyValuePair<int, int> current in this.m_NormalSkill)
    //		{
    //			if (num <= current.Value)
    //			{
    //				return current.Key;
    //			}
    //			num -= current.Value;
    //		}
    //		return -1;
    //	}

    //	public int HpSkill()
    //	{
    //		float num = (float)this.m_FightRoleData.HP / (float)this.m_FightRoleData.MaxHP;
    //		int num2 = 0;
    //		int num3 = -1;
    //		foreach (KeyValuePair<int, int> current in this.m_HpSkill)
    //		{
    //			if (num < (float)current.Value && current.Value > num2)
    //			{
    //				num3 = current.Key;
    //				num2 = current.Value;
    //			}
    //		}
    //		if (num3 > 0)
    //		{
    //			this.m_HpSkill.Remove(num3);
    //		}
    //		return num3;
    //	}

    //	public override void OnCommandFinish(FightCommand command)
    //	{
    //		if (!this.m_CommandQueue.Contains(command))
    //		{
    //			return;
    //		}
    //		if (this.m_CommandQueue.Count <= 0)
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.AfterAttackMoveBack;
    //			return;
    //		}
    //		this.m_CommandQueue.Remove(command);
    //		if (this.m_CommandQueue.Count > 0)
    //		{
    //			this.CheckTarget();
    //			this.m_emFight = M_Character.Enum_FightStatus.MoveToAttack;
    //			this.m_bNoMoveAttack = true;
    //			this.CrossFadeAnimation(M_Character.State_Sprint, 0.1f);
    //		}
    //		else
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.AfterAttackMoveBack;
    //		}
    //	}

    //	public override void OnHitAnimation(Enum_FightHitType hitType)
    //	{
    //		if (!this.CanBeTarget())
    //		{
    //			return;
    //		}
    //		bool flag = false;
    //		M_Character.Enum_FightStatus emFight = this.m_emFight;
    //		switch (emFight)
    //		{
    //		case M_Character.Enum_FightStatus.MoveToAttack:
    //		case M_Character.Enum_FightStatus.Attack:
    //		case M_Character.Enum_FightStatus.JumpBack:
    //			return;
    //		case M_Character.Enum_FightStatus.AfterAttackMoveBack:
    //		case M_Character.Enum_FightStatus.Dead:
    //		case M_Character.Enum_FightStatus.Revive:
    //			IL_35:
    //			switch (emFight)
    //			{
    //			case M_Character.Enum_FightStatus.Stun:
    //				flag = true;
    //				break;
    //			case M_Character.Enum_FightStatus.Freeze:
    //				return;
    //			}
    //			switch (hitType)
    //			{
    //			case Enum_FightHitType.DamageHP:
    //			case Enum_FightHitType.ReflexDamageHP:
    //			{
    //				if (this.m_ShroudInstance != null)
    //				{
    //					this.m_ShroudInstance.ReduceBlendWeight();
    //				}
    //				this.m_Animator.applyRootMotion = false;
    //				int num = UnityEngine.Random.Range(0, 100);
    //				if (num < 10)
    //				{
    //					this.m_Animator.Play(M_Character.State_Hit2, 0, 0f);
    //				}
    //				else
    //				{
    //					this.m_Animator.Play(M_Character.State_Hit, 0, 0f);
    //				}
    //				this.PlayHurtSound();
    //				this.m_MoveTimer = 0f;
    //				this.m_IdleTimer = 0f;
    //				if (!flag)
    //				{
    //					this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //				}
    //				break;
    //			}
    //			case Enum_FightHitType.Block:
    //				if (this.m_ShroudInstance != null)
    //				{
    //					this.m_ShroudInstance.ReduceBlendWeight();
    //				}
    //				this.m_Animator.applyRootMotion = false;
    //				this.m_Animator.Play(M_Character.State_Defense, 0, 0f);
    //				this.m_MoveTimer = 0f;
    //				this.m_IdleTimer = 0f;
    //				if (!flag)
    //				{
    //					this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //				}
    //				break;
    //			}
    //			return;
    //		}
    //		goto IL_35;
    //	}

    //	public override void OnHitDamage(Enum_FightHitType hitType, bool bCritical, bool bBlock, int value, M_Character actor)
    //	{
    //		if (!this.CanBeTarget())
    //		{
    //			return;
    //		}
    //		if (actor == null)
    //		{
    //			UnityEngine.Debug.Log("無法取得動作者");
    //			return;
    //		}
    //		this.HitDamageReCaculate_Buff_MagicItem(ref hitType, ref value, actor);
    //		FhightPopUpMsg.Instance.ShowFightPopUpMsg(hitType, bCritical, bBlock, value, this.m_HitTransform, false);
    //		switch (hitType)
    //		{
    //		case Enum_FightHitType.DamageHP:
    //		case Enum_FightHitType.ReflexDamageHP:
    //			if (value <= 0)
    //			{
    //				this.m_FightRoleData.HP += value;
    //			}
    //			break;
    //		case Enum_FightHitType.DamageMP:
    //		case Enum_FightHitType.ReflexDamageMP:
    //			if (value <= 0)
    //			{
    //				this.m_FightRoleData.MP += value;
    //			}
    //			break;
    //		case Enum_FightHitType.RestoreHP:
    //			if (value > 0)
    //			{
    //				this.m_FightRoleData.HP += value;
    //			}
    //			break;
    //		case Enum_FightHitType.RestoreMP:
    //			if (value > 0)
    //			{
    //				this.m_FightRoleData.MP += value;
    //			}
    //			break;
    //		}
    //		if (this.m_FightRoleData.HP < 0)
    //		{
    //			this.m_FightRoleData.HP = 0;
    //		}
    //		if (this.m_FightRoleData.MP < 0)
    //		{
    //			this.m_FightRoleData.MP = 0;
    //		}
    //		if (this.m_FightRoleData.HP > this.m_FightRoleData.MaxHP)
    //		{
    //			this.m_FightRoleData.HP = this.m_FightRoleData.MaxHP;
    //		}
    //		if (this.m_FightRoleData.MP > this.m_FightRoleData.MaxMP)
    //		{
    //			this.m_FightRoleData.MP = this.m_FightRoleData.MaxMP;
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
    //		int num = this.HpSkill();
    //		if (num > 0)
    //		{
    //			if (this.m_CommandQueue.Count >= 2)
    //			{
    //				this.m_CommandQueue.RemoveAt(1);
    //			}
    //			this.AddSkillCommand(num, this.ChooseTarget_AI(num));
    //		}
    //	}

    //	public override void Dead()
    //	{
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Dead)
    //		{
    //			return;
    //		}
    //		this.m_emFight = M_Character.Enum_FightStatus.Dead;
    //		this.m_FightRoleData.HP = 0;
    //		this.m_bCanBeTarget = false;
    //		if (this.m_BuffList.ContainsKey(90))
    //		{
    //			Buff_BonusDrop buff_BonusDrop = this.m_BuffList[90] as Buff_BonusDrop;
    //			this.m_BonusDropRate = buff_BonusDrop.m_BonusRate;
    //		}
    //		this.ClearCommand();
    //		this.DeadSkill();
    //		FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //		fightState.m_BuffSystem.AddBuff(999, null, this);
    //		if (this.m_FightSceneMgr.m_FightTalkControlMobDead)
    //		{
    //			this.CrossFadeAnimation(this.State_Standby, 0.3f);
    //		}
    //		else
    //		{
    //			GameObject characterModel_Fight = ResourceManager.Instance.GetCharacterModel_Fight(this.m_MobData.PrefName + "-R");
    //			if (characterModel_Fight != null)
    //			{
    //				TransformTool.CopyTransformsRecurse(this.m_ModelTransform, characterModel_Fight.transform);
    //				TransformTool.SetLayerRecursively(characterModel_Fight.transform, 18);
    //				this.m_RoleModel.SetActive(false);
    //			}
    //			else
    //			{
    //				this.CrossFadeAnimation(this.State_Dead, 0.3f);
    //				EffectSystem.Instance.CreateEffect(this.m_ModelTransform, string.Empty, this.m_FBXName + "_dead", false, true);
    //				AudioClip sound = ResourceManager.Instance.GetSound(this.m_FBXName + "_dead");
    //				if (sound != null)
    //				{
    //					MusicSystem.Instance.PlaySoundAtPos(sound, this.GetModelPosition());
    //				}
    //				if (this.m_MobData.emType == ENUM_MobType.Normal)
    //				{
    //					base.StartCoroutine(this.DisableDeadMob());
    //				}
    //			}
    //		}
    //		this.m_CharacterController.enabled = false;
    //		this.m_FightSceneMgr.OnMobDead(this);
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator DisableDeadMob()
    //	{
    //		M_Mob.<DisableDeadMob>c__Iterator887 <DisableDeadMob>c__Iterator = new M_Mob.<DisableDeadMob>c__Iterator887();
    //		<DisableDeadMob>c__Iterator.<>f__this = this;
    //		return <DisableDeadMob>c__Iterator;
    //	}

    //	public void Dead_SummonMob()
    //	{
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Dead)
    //		{
    //			return;
    //		}
    //		this.m_emFight = M_Character.Enum_FightStatus.Dead;
    //		this.m_FightRoleData.HP = 0;
    //		this.m_bCanBeTarget = false;
    //		this.ClearCommand();
    //		this.DeadSkill();
    //		FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //		fightState.m_BuffSystem.AddBuff(999, null, this);
    //		this.m_RoleModel.SetActive(false);
    //		this.m_CharacterController.enabled = false;
    //		this.m_FightSceneMgr.OnMobDead(this);
    //	}

    //	private void DeadSkill()
    //	{
    //		S_Skill data = GameDataDB.SkillDB.GetData(this.m_DeadSkillID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //		if (data2 == null)
    //		{
    //			return;
    //		}
    //		M_Character t = this.ChooseTarget_AI(this.m_DeadSkillID);
    //		if (data2.ActDataName.Length == 0 || data2.ActDataName == "0")
    //		{
    //			FightCommand_NoActDataSkill skillCommand = new FightCommand_NoActDataSkill(this, t, this.m_DeadSkillID);
    //			this.DoCommand(skillCommand);
    //		}
    //		else
    //		{
    //			FightCommand_DeadSkill skillCommand2 = new FightCommand_DeadSkill(this, t, this.m_DeadSkillID);
    //			this.DoCommand(skillCommand2);
    //		}
    //	}

    //	private void PlayHurtSound()
    //	{
    //		if (this.m_HurtAudioSource == null)
    //		{
    //			return;
    //		}
    //		if (this.m_HurtAudioSource.isPlaying)
    //		{
    //			return;
    //		}
    //		AudioClip sound = ResourceManager.Instance.GetSound(this.m_FBXName + "_hurt");
    //		if (sound == null)
    //		{
    //			return;
    //		}
    //		MusicSystem.Instance.PlaySound_AssignAudioSource(this.m_HurtAudioSource, sound);
    //	}
}
