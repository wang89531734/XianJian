//using SoftStarStatisticsSheet;
using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class M_Player : M_Character
{
    public int m_RoleID;

    public Dictionary<int, float> m_SkillCDList = new Dictionary<int, float>();

    public List<int> m_PassiveSkillTrigger = new List<int>();

    public List<int> m_PassiveSphereSkillTrigger = new List<int>();

    private List<int> m_AIReviveSkills_Single = new List<int>();

    private List<int> m_AIReviveSkills_All = new List<int>();

    private List<int> m_AIHealSkills_Single = new List<int>();

    private List<int> m_AIHealSkills_All = new List<int>();

    private List<int> m_AIAtkSkills = new List<int>();

    private List<int> m_AIAssistSkills = new List<int>();

    private List<int> m_AIHealBuffSkills_Single = new List<int>();

    private List<int> m_AIHealBuffSkills_All = new List<int>();

    private List<int> m_AIRestoreMPSkills_Single = new List<int>();

    private List<int> m_AIRestoreMPSkills_All = new List<int>();

    private List<int> m_AIDebuffSkills_1 = new List<int>();

    private List<int> m_AIDebuffSkills_2 = new List<int>();

    public C_RoleDataEx m_RoleDataEx;

    public FormationData m_FormationData;

    public int m_FormationUnitIdx;

    public ENUM_FormationActionType m_emFormationActionType;

    public ENUM_FormationAI m_emAIType;

    [SerializeField]
    public bool m_bIsControlCharacter;

    public bool m_bUseAI;

    public bool m_bIsLevelUp;

    //public FightLevelUpInfo m_BeforeLevelUpInfo;

    //public FightLevelUpInfo m_AfterLevelUpInfo;

    public S_LevelUpInfo m_LevelUpInfo;

    public int m_OriginalHP;

    public static int State_BackJumpBig = Animator.StringToHash("Base Layer.backjump-big");

    public new static int State_Dead = Animator.StringToHash("Base Layer.dead");

    public static int State_Catch = Animator.StringToHash("Base Layer.call");

    public static int State_Change = Animator.StringToHash("Base Layer.change");

    public static int State_UseItem = Animator.StringToHash("Base Layer.use");

    public static int State_Revive = Animator.StringToHash("Base Layer.revive");

    public static int State_Win = Animator.StringToHash("Base Layer.winner");

    public static int State_LevelUp = Animator.StringToHash("Base Layer.upgrade");

    public static int State_Walk_Front_Start = Animator.StringToHash("Base Layer.walk-front_A");

    public static int State_Walk_Front_Cycle = Animator.StringToHash("Base Layer.walk-front_B");

    public static int State_Walk_Back_Start = Animator.StringToHash("Base Layer.walk-back_A");

    public static int State_Walk_Back_Cycle = Animator.StringToHash("Base Layer.walk-back_B");

    public static int State_Walk_Right_Start = Animator.StringToHash("Base Layer.walk-right_A");

    public static int State_Walk_Right_Cycle = Animator.StringToHash("Base Layer.walk-right_B");

    public static int State_Walk_Left_Start = Animator.StringToHash("Base Layer.walk-left_A");

    public static int State_Walk_Left_Cycle = Animator.StringToHash("Base Layer.walk-left_B");

    public static int State_Giddy_Start = Animator.StringToHash("Base Layer.giddy_A");

    public static int State_Giddy_End = Animator.StringToHash("Base Layer.giddy_C");

    private float m_MoveBackTimer;

    public float m_AddActionCD;

    private float m_AIDelayTimer;

    public ENUM_ElementType m_emWeaponElemntType = ENUM_ElementType.Null;

    private ItemData m_MagicItem;

    //public MagicItem_Passive m_MagicItem_Passive;

    //public MagicItem_Active m_MagicItem_Active;

    //private M_Mob m_PrevAtkMob;

    private bool m_bTurnAction = true;

    private Vector3 m_InitPos;

    private void Start()
    {
    }

    public void InitRole(int roleID)
    {
        UnityEngine.Debug.Log("执行InitRole");
        this.m_emFight = M_Character.Enum_FightStatus.Idle;
        //this.m_CharacterController.enabled = true;
        //this.m_EnableCharacterContoller = true;
        //this.m_RoleID = roleID;
        ////this.m_SkillCDList.Clear();
        //for (int i = 0; i < 5; i++)
        //{
        //    //List<FightSkillHotKeyInfo> fightSkillHotkeyList = Swd6Application.instance.m_SkillSystem.GetFightSkillHotkeyList(this.m_RoleID, i);
        //    //for (int j = 0; j < fightSkillHotkeyList.Count; j++)
        //    //{
        //    //    S_Skill data = GameDataDB.SkillDB.GetData(fightSkillHotkeyList[j].ID);
        //    //    if (data != null)
        //    //    {
        //    //        if (this.m_SkillCDList.ContainsKey(fightSkillHotkeyList[j].ID))
        //    //        {
        //    //            this.m_SkillCDList[fightSkillHotkeyList[j].ID] = data.CastCD;
        //    //        }
        //    //        else
        //    //        {
        //    //            this.m_SkillCDList.Add(fightSkillHotkeyList[j].ID, data.CastCD);
        //    //        }
        //    //        if (fightSkillHotkeyList[j].AI)
        //    //        {
        //    //            this.SetAISkills(fightSkillHotkeyList[j].ID);
        //    //        }
        //    //    }
        //    //}
        //}
        ////this.m_AIReviveSkills_Single.Sort();
        ////this.m_AIReviveSkills_Single.Reverse();
        ////this.m_AIReviveSkills_All.Sort();
        ////this.m_AIReviveSkills_All.Reverse();
        ////this.m_AIHealSkills_Single.Sort();
        ////this.m_AIHealSkills_Single.Reverse();
        ////this.m_AIHealSkills_All.Sort();
        ////this.m_AIHealSkills_All.Reverse();
        ////this.m_AIHealBuffSkills_Single.Sort();
        ////this.m_AIHealBuffSkills_Single.Reverse();
        ////this.m_AIHealBuffSkills_All.Sort();
        ////this.m_AIHealBuffSkills_All.Reverse();
        ////this.m_AIRestoreMPSkills_Single.Sort();
        ////this.m_AIRestoreMPSkills_Single.Reverse();
        ////this.m_AIRestoreMPSkills_All.Sort();
        ////this.m_AIRestoreMPSkills_All.Reverse();
        ////this.m_AIDebuffSkills_1.Sort();
        ////this.m_AIDebuffSkills_1.Reverse();
        ////this.m_AIDebuffSkills_2.Sort();
        ////this.m_AIDebuffSkills_2.Reverse();
        //this.m_RoleDataEx = GameEntry.Instance.m_GameDataSystem.GetRoleData(this.m_RoleID);
        //if (this.m_RoleDataEx == null)
        //{
        //    Debug.LogWarning("m_RoleDataEx is Null m_RoleID = " + this.m_RoleID);
        //    return;
        //}
        ////ItemData equipItemData = this.m_RoleDataEx.GetEquipItemData(ENUM_EquipPosition.Weapon);
        ////this.m_emWeaponElemntType = this.m_RoleDataEx.BaseRoleData.emWeaponElemntType;
        ////this.m_MagicItem = this.m_RoleDataEx.GetEquipItemData(ENUM_EquipPosition.Talisman);
        ////if (this.m_MagicItem != null)
        ////{
        ////    S_Item data2 = GameDataDB.ItemDB.GetData(this.m_MagicItem.ID);
        ////    if (data2 != null && data2.emSubItemType == ENUM_ItemSubType.Talisman)
        ////    {
        ////        this.m_MagicItem_Passive = new MagicItem_Passive(this, this.m_MagicItem);
        ////    }
        ////    if (data2 != null && data2.emSubItemType == ENUM_ItemSubType.MagicArms)
        ////    {
        ////        this.m_MagicItem_Active = new MagicItem_Active(this, this.m_MagicItem);
        ////    }
        ////}
        //this.m_CharacterName = this.m_RoleDataEx.BaseRoleData.FamilyName + this.m_RoleDataEx.BaseRoleData.Name;
        ////this.m_BeforeLevelUpInfo = new FightLevelUpInfo(this.m_RoleDataEx);
        //this.InitFightRoleData();
        //this.SetPassiveSkill(roleID);
        //this.m_ActionCD = (float)(500 - this.m_FightRoleData.Agi) / 100f;
        //this.UpdateBuffIconCallback = new M_Character.UpdateBuffIcon(this.UpdateUIBuffIcon);
        //this.SetStartUpdate(false);
    }

    //	public ItemData GetEquipMagicItemData()
    //	{
    //		return this.m_MagicItem;
    //	}

    //	public void LevelUp()
    //	{
    //		base.PlayAnimationImmediately(M_Player.State_LevelUp);
    //		MusicSystem.Instance.PlaySound_Replace(16);
    //		M_WeaponTrail[] componentsInChildren = base.GetComponentsInChildren<M_WeaponTrail>();
    //		if (componentsInChildren == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			componentsInChildren[i].Emit = false;
    //		}
    //		RendererTool.EnableAllRenderers(this.m_RoleModel, true);
    //		ShroudInstance component = base.GetComponent<ShroudInstance>();
    //		if (component != null)
    //		{
    //			component.enabled = true;
    //		}
    //	}

    //	private void SetAISkills(int skillID)
    //	{
    //		bool flag = false;
    //		bool flag2 = false;
    //		bool flag3 = false;
    //		if ((skillID >= 2811 && skillID <= 2815) || (skillID >= 3611 && skillID <= 3615) || (skillID >= 4411 && skillID <= 4415) || (skillID >= 5211 && skillID <= 5215))
    //		{
    //			flag = true;
    //			flag2 = true;
    //			this.m_AIReviveSkills_Single.Add(skillID);
    //		}
    //		if ((skillID >= 2831 && skillID <= 2835) || (skillID >= 3631 && skillID <= 3635) || (skillID >= 4431 && skillID <= 4435) || (skillID >= 5231 && skillID <= 5235))
    //		{
    //			flag = true;
    //			flag2 = true;
    //			this.m_AIReviveSkills_All.Add(skillID);
    //		}
    //		if ((skillID >= 2801 && skillID <= 2805) || (skillID >= 3601 && skillID <= 3605) || (skillID >= 4401 && skillID <= 4405) || (skillID >= 5201 && skillID <= 5205))
    //		{
    //			flag = true;
    //			this.m_AIHealSkills_Single.Add(skillID);
    //		}
    //		if ((skillID >= 2821 && skillID <= 2825) || (skillID >= 3621 && skillID <= 3625) || (skillID >= 4421 && skillID <= 4425) || (skillID >= 5221 && skillID <= 5225))
    //		{
    //			flag = true;
    //			this.m_AIHealSkills_All.Add(skillID);
    //		}
    //		if ((skillID >= 2401 && skillID <= 2405) || (skillID >= 2601 && skillID <= 2605) || (skillID >= 3201 && skillID <= 3205) || (skillID >= 3401 && skillID <= 3405) || (skillID >= 4001 && skillID <= 4005) || (skillID >= 4201 && skillID <= 4205) || (skillID >= 4801 && skillID <= 4805) || (skillID >= 5001 && skillID <= 5005))
    //		{
    //			flag = true;
    //			this.m_AIHealBuffSkills_Single.Add(skillID);
    //		}
    //		if ((skillID >= 2421 && skillID <= 2425) || (skillID >= 2621 && skillID <= 2625) || (skillID >= 3221 && skillID <= 3225) || (skillID >= 3421 && skillID <= 3425) || (skillID >= 4021 && skillID <= 4025) || (skillID >= 4221 && skillID <= 4225) || (skillID >= 4821 && skillID <= 4825) || (skillID >= 5021 && skillID <= 5025))
    //		{
    //			flag = true;
    //			this.m_AIHealBuffSkills_All.Add(skillID);
    //		}
    //		if ((skillID >= 2611 && skillID <= 2615) || (skillID >= 3411 && skillID <= 3415) || (skillID >= 4211 && skillID <= 4215) || (skillID >= 5011 && skillID <= 5015))
    //		{
    //			flag = true;
    //			this.m_AIRestoreMPSkills_Single.Add(skillID);
    //		}
    //		if ((skillID >= 2641 && skillID <= 2645) || (skillID >= 3441 && skillID <= 3445) || (skillID >= 4241 && skillID <= 4245) || (skillID >= 5041 && skillID <= 5045))
    //		{
    //			flag = true;
    //			this.m_AIRestoreMPSkills_All.Add(skillID);
    //		}
    //		if ((skillID >= 2651 && skillID <= 2655) || (skillID >= 3451 && skillID <= 3455) || (skillID >= 4251 && skillID <= 4255) || (skillID >= 5051 && skillID <= 5055))
    //		{
    //			flag = true;
    //			flag3 = true;
    //			this.m_AIDebuffSkills_1.Add(skillID);
    //		}
    //		if ((skillID >= 2851 && skillID <= 2855) || (skillID >= 3651 && skillID <= 3655) || (skillID >= 4451 && skillID <= 4455) || (skillID >= 5251 && skillID <= 5255))
    //		{
    //			flag = true;
    //			flag3 = true;
    //			this.m_AIDebuffSkills_2.Add(skillID);
    //		}
    //		S_Skill data = GameDataDB.SkillDB.GetData(skillID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (data.emItemType == ENUM_ItemSubType.Attack)
    //		{
    //			this.m_AIAtkSkills.Add(skillID);
    //		}
    //		else if (data.emItemType == ENUM_ItemSubType.Assist)
    //		{
    //			if (!flag2 && !flag3)
    //			{
    //				this.m_AIAssistSkills.Add(skillID);
    //			}
    //		}
    //		else if (!flag)
    //		{
    //			Debug.Log("找不到適當分類\u3000技能id:" + skillID);
    //		}
    //	}

    //	private void SetPassiveSkill(int roleID)
    //	{
    //		List<int> passiveBuffSkillList = Swd6Application.instance.m_SkillSystem.GetPassiveBuffSkillList(roleID);
    //		FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //		if (passiveBuffSkillList != null)
    //		{
    //			for (int i = 0; i < passiveBuffSkillList.Count; i++)
    //			{
    //				S_Skill data = GameDataDB.SkillDB.GetData(passiveBuffSkillList[i]);
    //				if (data != null)
    //				{
    //					S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //					if (data2 != null)
    //					{
    //						switch (data.emTriggerType)
    //						{
    //						case ENUM_SkillTriggerType.Permanent:
    //							for (int j = 0; j < data2.Buffer.Count; j++)
    //							{
    //								if (fightState != null && fightState.m_BuffSystem != null)
    //								{
    //									fightState.m_BuffSystem.AddNoRemoveBuff(data2.Buffer[j], this, this);
    //								}
    //							}
    //							break;
    //						case ENUM_SkillTriggerType.Skill:
    //							this.m_PassiveSkillTrigger.Add(passiveBuffSkillList[i]);
    //							break;
    //						case ENUM_SkillTriggerType.SphereSkill:
    //							this.m_PassiveSphereSkillTrigger.Add(passiveBuffSkillList[i]);
    //							break;
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public override void Debut()
    //	{
    //		if (base.IsDead())
    //		{
    //			if (this.m_ShroudInstance != null)
    //			{
    //				this.m_ShroudInstance.ReduceBlendWeight();
    //			}
    //			this.m_Animator.Play(M_Player.State_Dead, 0, 1f);
    //		}
    //		else
    //		{
    //			base.PlayAnimationImmediately("Base Layer.debut");
    //		}
    //	}

    public void SetInitPos(Vector3 pos)
    {
        this.m_InitPos = pos;
    }

    //	public override bool IsStandby()
    //	{
    //		return !(this.m_Animator == null) && this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash == this.State_Standby;
    //	}

    //	public bool IsIdle()
    //	{
    //		return this.m_emFight == M_Character.Enum_FightStatus.Idle;
    //	}

    private void Update()
    {
        //base.ModelDropCheck();
        //if (base.IsDead())
        //{
        //    this.CheckDeadAnimation();
        //    return;
        //}
        //if (this.m_FightSceneMgr.m_IsFightFinish)
        //{
        //    if (this.m_emFight != M_Character.Enum_FightStatus.Finish)
        //    {
        //        if (this.m_FightSceneMgr.m_bWin)
        //        {
        //            this.Win();
        //        }
        //        else
        //        {
        //            this.Lose();
        //        }
        //    }
        //    if (this.m_Animator.speed != 1f)
        //    {
        //        base.SetAnimatorSpeed(1f);
        //    }
        //    return;
        //}
        //if (!this.m_bStartUpdate)
        //{
        //    return;
        //}
        //if (this.m_CommandQueue.Count < 2)
        //{
        //    if (base.IsLoseHeart())
        //    {
        //        this.Update_AI_LostHeart();
        //    }
        //    else if (this.m_bUseAI)
        //    {
        //        this.Update_AI();
        //    }
        //}
        //if (this.m_bIsControlCharacter)
        //{
        //    if (this.m_FightSceneMgr.m_bIsPauseMode)
        //    {
        //        if (this.m_CommandQueue.Count == 0 && this.m_ActionCDTimer <= 0f)
        //        {
        //            switch (this.m_emFight)
        //            {
        //                case M_Character.Enum_FightStatus.Stun:
        //                case M_Character.Enum_FightStatus.Sleep:
        //                case M_Character.Enum_FightStatus.Freeze:
        //                    this.m_FightSceneMgr.SetFightRolePause(false);
        //                    break;
        //                default:
        //                    this.m_FightSceneMgr.SetFightRolePause(true);
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            this.m_FightSceneMgr.SetFightRolePause(false);
        //        }
        //    }
        //    else
        //    {
        //        this.m_FightSceneMgr.SetFightRolePause(false);
        //    }
        //}
        //if (this.m_bStoryMode)
        //{
        //    this.Update_StoryMode();
        //}
        //else
        //{
        //    this.Update_Movement();
        //}
        //if (this.m_bPause)
        //{
        //    return;
        //}
        //base.Update_Buff();
        //if (this.m_MagicItem_Passive != null)
        //{
        //    if (this.m_MagicItem.ID == 714)
        //    {
        //        this.m_MagicItem_Passive.UpdateHP();
        //    }
        //    if (this.m_MagicItem.ID == 715)
        //    {
        //        this.m_MagicItem_Passive.UpdateMP();
        //    }
        //    this.m_MagicItem_Passive.UpdateReviveCD();
        //}
        //if (this.m_MagicItem_Active != null)
        //{
        //    this.m_MagicItem_Active.UpdateTimer();
        //}
        //if (this.m_bIsControlCharacter)
        //{
        //    if (this.m_FightSceneMgr.m_CatchMobCDTimer > 0f)
        //    {
        //        this.m_FightSceneMgr.m_CatchMobCDTimer -= Time.deltaTime;
        //    }
        //    if (this.m_FightSceneMgr.m_ChangeFormationCDTimer > 0f)
        //    {
        //        this.m_FightSceneMgr.m_ChangeFormationCDTimer -= Time.deltaTime;
        //    }
        //    if (!this.m_bStoryMode)
        //    {
        //        this.m_FightSceneMgr.m_FightTotalTime_RealFightCD += Time.deltaTime;
        //    }
        //}
        //if (this.m_ActionCDTimer < 0f)
        //{
        //    return;
        //}
        //this.m_ActionCDTimer -= Time.deltaTime;
        //if (this.m_ActionCDTimer < 0f)
        //{
        //    UI_Fight.Instance.UpdateSkillBtnEnable();
        //    UI_Fight.Instance.UpdateItemBtnEnableAndCount();
        //}
    }

    //	private void Update_AI_LostHeart()
    //	{
    //		if (this.m_bStoryMode)
    //		{
    //			return;
    //		}
    //		if (base.CannotUseAnyCommand())
    //		{
    //			return;
    //		}
    //		if (this.m_ActionCDTimer <= 0f)
    //		{
    //			this.m_AIDelayTimer -= Time.deltaTime;
    //			if (this.m_AIDelayTimer > 0f)
    //			{
    //				return;
    //			}
    //			List<int> list = new List<int>();
    //			for (int i = 0; i < this.m_AIHealSkills_Single.Count; i++)
    //			{
    //				if (this.CheckCanUseSkill(this.m_AIHealSkills_Single[i]))
    //				{
    //					list.Add(this.m_AIHealSkills_Single[i]);
    //				}
    //			}
    //			for (int j = 0; j < this.m_AIHealSkills_All.Count; j++)
    //			{
    //				if (this.CheckCanUseSkill(this.m_AIHealSkills_All[j]))
    //				{
    //					list.Add(this.m_AIHealSkills_All[j]);
    //				}
    //			}
    //			for (int k = 0; k < this.m_AIAtkSkills.Count; k++)
    //			{
    //				if (this.CheckCanUseSkill(this.m_AIAtkSkills[k]))
    //				{
    //					list.Add(this.m_AIAtkSkills[k]);
    //				}
    //			}
    //			for (int l = 0; l < this.m_AIAssistSkills.Count; l++)
    //			{
    //				if (this.CheckCanUseSkill(this.m_AIAssistSkills[l]))
    //				{
    //					list.Add(this.m_AIAssistSkills[l]);
    //				}
    //			}
    //			int num = -1;
    //			if (list.Count == 1)
    //			{
    //				num = list[0];
    //			}
    //			else if (list.Count > 1)
    //			{
    //				int index = UnityEngine.Random.Range(0, list.Count);
    //				num = list[index];
    //			}
    //			if (num > 0 && this.AddSkillCommand(num, this.ChooseTarget_AI(num)))
    //			{
    //				return;
    //			}
    //		}
    //	}

    //	private void Update_AI()
    //	{
    //		if (this.m_bStoryMode)
    //		{
    //			return;
    //		}
    //		if (base.CannotUseAnyCommand())
    //		{
    //			return;
    //		}
    //		if (this.m_ActionCDTimer <= 0f)
    //		{
    //			this.m_AIDelayTimer -= Time.deltaTime;
    //			if (this.m_AIDelayTimer > 0f)
    //			{
    //				return;
    //			}
    //			if (this.CheckRevive_AI())
    //			{
    //				return;
    //			}
    //			if (this.CheckHeal_AI())
    //			{
    //				return;
    //			}
    //			if (this.CheckRestoreMP_AI())
    //			{
    //				return;
    //			}
    //			if (this.CheckDebuff_AI())
    //			{
    //				return;
    //			}
    //			int num = UnityEngine.Random.Range(0, 100);
    //			int usableAtkAssistSkill;
    //			if (num < 70)
    //			{
    //				usableAtkAssistSkill = this.GetUsableAtkAssistSkill(this.m_AIAtkSkills);
    //				if (usableAtkAssistSkill <= 0)
    //				{
    //					usableAtkAssistSkill = this.GetUsableAtkAssistSkill(this.m_AIAssistSkills);
    //				}
    //			}
    //			else
    //			{
    //				usableAtkAssistSkill = this.GetUsableAtkAssistSkill(this.m_AIAssistSkills);
    //				if (usableAtkAssistSkill <= 0)
    //				{
    //					usableAtkAssistSkill = this.GetUsableAtkAssistSkill(this.m_AIAtkSkills);
    //				}
    //			}
    //			if (usableAtkAssistSkill > 0 && this.AddSkillCommand(usableAtkAssistSkill, this.ChooseTarget_AI(usableAtkAssistSkill)))
    //			{
    //				return;
    //			}
    //		}
    //	}

    //	private bool CheckRevive_AI()
    //	{
    //		List<M_Player> reviveTargets = this.GetReviveTargets();
    //		if (reviveTargets.Count == 0)
    //		{
    //			return false;
    //		}
    //		if (reviveTargets.Count > 1)
    //		{
    //			int usableSkill = this.GetUsableSkill(this.m_AIReviveSkills_All);
    //			if (usableSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableSkill, reviveTargets[0]);
    //			}
    //			usableSkill = this.GetUsableSkill(this.m_AIReviveSkills_Single);
    //			if (usableSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableSkill, reviveTargets[0]);
    //			}
    //		}
    //		else
    //		{
    //			int usableSkill = this.GetUsableSkill(this.m_AIReviveSkills_Single);
    //			if (usableSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableSkill, reviveTargets[0]);
    //			}
    //			usableSkill = this.GetUsableSkill(this.m_AIReviveSkills_All);
    //			if (usableSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableSkill, reviveTargets[0]);
    //			}
    //		}
    //		int usableReviveItem = this.m_FightSceneMgr.GetUsableReviveItem();
    //		return usableReviveItem > 0 && this.AddItemCommand(usableReviveItem, reviveTargets[0]);
    //	}

    //	private bool CheckHeal_AI()
    //	{
    //		M_Player m_Player = null;
    //		List<M_Player> list = new List<M_Player>();
    //		switch (this.m_emAIType)
    //		{
    //		case ENUM_FormationAI.Attack:
    //			m_Player = this.GetHPTarget(0.3f, list);
    //			break;
    //		case ENUM_FormationAI.Keep:
    //			m_Player = this.GetHPTarget(0.7f, list);
    //			break;
    //		case ENUM_FormationAI.Defence:
    //			m_Player = this.GetHPTarget(0.5f, list);
    //			break;
    //		}
    //		if (m_Player == null)
    //		{
    //			return false;
    //		}
    //		List<M_Player> list2 = new List<M_Player>();
    //		list2.Add(m_Player);
    //		int count = list.Count;
    //		if (count > 1)
    //		{
    //			int num = this.GetUsableSkill(this.m_AIHealSkills_All);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableHotSkill(this.m_AIHealBuffSkills_All, list);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableSkill(this.m_AIHealSkills_Single);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableHotSkill(this.m_AIHealBuffSkills_Single, list2);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			int num2 = this.m_FightSceneMgr.GetUsableHealItem_All();
    //			if (num2 > 0)
    //			{
    //				return this.AddItemCommand(num2, m_Player);
    //			}
    //			num2 = this.m_FightSceneMgr.GetUsableHealItem_Single();
    //			if (num2 > 0)
    //			{
    //				return this.AddItemCommand(num2, m_Player);
    //			}
    //		}
    //		else
    //		{
    //			int num = this.GetUsableSkill(this.m_AIHealSkills_Single);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableHotSkill(this.m_AIHealBuffSkills_Single, list2);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableSkill(this.m_AIHealSkills_All);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			num = this.GetUsableHotSkill(this.m_AIHealBuffSkills_All, list);
    //			if (num > 0)
    //			{
    //				return this.AddSkillCommand(num, m_Player);
    //			}
    //			int num2 = this.m_FightSceneMgr.GetUsableHealItem_Single();
    //			if (num2 > 0)
    //			{
    //				return this.AddItemCommand(num2, m_Player);
    //			}
    //			num2 = this.m_FightSceneMgr.GetUsableHealItem_All();
    //			if (num2 > 0)
    //			{
    //				return this.AddItemCommand(num2, m_Player);
    //			}
    //		}
    //		return false;
    //	}

    //	public bool CheckNoBuff(ENUM_BuffType emBuffType)
    //	{
    //		return !this.m_BuffList.ContainsKey((int)emBuffType);
    //	}

    //	public bool CheckNoBuff(List<M_Player> playerList, ENUM_BuffType emBuffType)
    //	{
    //		for (int i = 0; i < playerList.Count; i++)
    //		{
    //			if (playerList[i].CheckNoBuff(emBuffType))
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	private bool CheckRestoreMP_AI()
    //	{
    //		M_Player m_Player = null;
    //		List<M_Player> list = new List<M_Player>();
    //		switch (this.m_emAIType)
    //		{
    //		case ENUM_FormationAI.Attack:
    //			m_Player = this.GetMPTarget(0.3f, list);
    //			break;
    //		case ENUM_FormationAI.Keep:
    //			m_Player = this.GetMPTarget(0.7f, list);
    //			break;
    //		case ENUM_FormationAI.Defence:
    //			m_Player = this.GetMPTarget(0.5f, list);
    //			break;
    //		}
    //		if (m_Player == null)
    //		{
    //			return false;
    //		}
    //		List<M_Player> list2 = new List<M_Player>();
    //		list2.Add(m_Player);
    //		int count = list.Count;
    //		if (count > 1)
    //		{
    //			int usableHotSkill = this.GetUsableHotSkill(this.m_AIRestoreMPSkills_All, list);
    //			if (usableHotSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableHotSkill, m_Player);
    //			}
    //			usableHotSkill = this.GetUsableHotSkill(this.m_AIRestoreMPSkills_Single, list2);
    //			if (usableHotSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableHotSkill, m_Player);
    //			}
    //			int num = this.m_FightSceneMgr.GetUsableRestoreMPItem_All();
    //			if (num > 0)
    //			{
    //				return this.AddItemCommand(num, m_Player);
    //			}
    //			num = this.m_FightSceneMgr.GetUsableRestoreMPItem_Single();
    //			if (num > 0)
    //			{
    //				return this.AddItemCommand(num, m_Player);
    //			}
    //		}
    //		else
    //		{
    //			int usableHotSkill = this.GetUsableHotSkill(this.m_AIRestoreMPSkills_Single, list2);
    //			if (usableHotSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableHotSkill, m_Player);
    //			}
    //			usableHotSkill = this.GetUsableHotSkill(this.m_AIRestoreMPSkills_All, list);
    //			if (usableHotSkill > 0)
    //			{
    //				return this.AddSkillCommand(usableHotSkill, m_Player);
    //			}
    //			int num = this.m_FightSceneMgr.GetUsableRestoreMPItem_Single();
    //			if (num > 0)
    //			{
    //				return this.AddItemCommand(num, m_Player);
    //			}
    //			num = this.m_FightSceneMgr.GetUsableRestoreMPItem_All();
    //			if (num > 0)
    //			{
    //				return this.AddItemCommand(num, m_Player);
    //			}
    //		}
    //		return false;
    //	}

    //	private bool CheckDebuff_AI()
    //	{
    //		int usableDebuffItem = this.m_FightSceneMgr.GetUsableDebuffItem();
    //		for (int i = 1; i <= 4; i++)
    //		{
    //			M_Player role = this.m_FightSceneMgr.GetRole(i);
    //			if (!(role == null))
    //			{
    //				bool flag = false;
    //				if (!role.CheckNoBuff(ENUM_BuffType.Stun) || !role.CheckNoBuff(ENUM_BuffType.Sleep))
    //				{
    //					flag = true;
    //					int usableSkill = this.GetUsableSkill(this.m_AIDebuffSkills_1);
    //					if (usableSkill > 0)
    //					{
    //						return this.AddSkillCommand(usableSkill, role);
    //					}
    //				}
    //				if (!role.CheckNoBuff(ENUM_BuffType.Paralysis) || !role.CheckNoBuff(ENUM_BuffType.Freeze))
    //				{
    //					flag = true;
    //					int usableSkill = this.GetUsableSkill(this.m_AIDebuffSkills_1);
    //					if (usableSkill > 0)
    //					{
    //						return this.AddSkillCommand(usableSkill, role);
    //					}
    //				}
    //				if (flag && usableDebuffItem > 0)
    //				{
    //					return this.AddItemCommand(usableDebuffItem, role);
    //				}
    //			}
    //		}
    //		return false;
    //	}

    //	private int GetUsableSkill(List<int> skillList)
    //	{
    //		for (int i = 0; i < skillList.Count; i++)
    //		{
    //			if (this.CheckCanUseSkill(skillList[i]))
    //			{
    //				return skillList[i];
    //			}
    //		}
    //		return -1;
    //	}

    //	private int GetUsableHotSkill(List<int> skillList, List<M_Player> healList)
    //	{
    //		for (int i = 0; i < skillList.Count; i++)
    //		{
    //			if (this.CheckCanUseSkill(skillList[i]))
    //			{
    //				S_Skill data = GameDataDB.SkillDB.GetData(skillList[i]);
    //				if (data != null)
    //				{
    //					S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //					if (data2 != null)
    //					{
    //						for (int j = 0; j < data2.Buffer.Count; j++)
    //						{
    //							S_BufferData data3 = GameDataDB.BufferDB.GetData(data2.Buffer[i]);
    //							if (data3 != null)
    //							{
    //								if (this.CheckNoBuff(healList, data3.emBuffType))
    //								{
    //									return skillList[i];
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return -1;
    //	}

    //	private int GetUsableAtkAssistSkill(List<int> skillList)
    //	{
    //		List<int> list = new List<int>();
    //		for (int i = 0; i < skillList.Count; i++)
    //		{
    //			if (this.CheckCanUseSkill(skillList[i]))
    //			{
    //				list.Add(skillList[i]);
    //			}
    //		}
    //		if (list.Count == 0)
    //		{
    //			return -1;
    //		}
    //		if (list.Count == 1)
    //		{
    //			return list[0];
    //		}
    //		int index = UnityEngine.Random.Range(0, list.Count);
    //		return list[index];
    //	}

    //	private List<M_Player> GetReviveTargets()
    //	{
    //		List<M_Player> list = new List<M_Player>();
    //		FormationData nowFormation = this.m_FightSceneMgr.GetNowFormation();
    //		if (nowFormation == null)
    //		{
    //			return list;
    //		}
    //		for (int i = 0; i < nowFormation.Unit.Count; i++)
    //		{
    //			int roleID = nowFormation.Unit[i].RoleID;
    //			M_Player role = this.m_FightSceneMgr.GetRole(roleID);
    //			if (!(role == null))
    //			{
    //				if (role.m_RoleModel.activeSelf)
    //				{
    //					if (role.IsDead())
    //					{
    //						list.Add(role);
    //					}
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	private M_Player GetHPTarget(float hpRateLimit, List<M_Player> healList)
    //	{
    //		M_Player result = null;
    //		FormationData nowFormation = this.m_FightSceneMgr.GetNowFormation();
    //		if (nowFormation == null)
    //		{
    //			return result;
    //		}
    //		int num = 0;
    //		for (int i = 0; i < nowFormation.Unit.Count; i++)
    //		{
    //			int roleID = nowFormation.Unit[i].RoleID;
    //			M_Player role = this.m_FightSceneMgr.GetRole(roleID);
    //			if (!(role == null))
    //			{
    //				if (role.m_RoleModel.activeSelf)
    //				{
    //					int num2 = role.m_FightRoleData.MaxHP - role.m_FightRoleData.HP;
    //					if (num2 > 0)
    //					{
    //						float num3 = (float)role.m_FightRoleData.HP / (float)role.m_FightRoleData.MaxHP;
    //						if (num3 < hpRateLimit)
    //						{
    //							healList.Add(role);
    //							if (num2 > num)
    //							{
    //								num = num2;
    //								result = role;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	private M_Player GetMPTarget(float mpRateLimit, List<M_Player> healList)
    //	{
    //		M_Player result = null;
    //		FormationData nowFormation = this.m_FightSceneMgr.GetNowFormation();
    //		if (nowFormation == null)
    //		{
    //			return result;
    //		}
    //		int num = 0;
    //		for (int i = 0; i < nowFormation.Unit.Count; i++)
    //		{
    //			int roleID = nowFormation.Unit[i].RoleID;
    //			M_Player role = this.m_FightSceneMgr.GetRole(roleID);
    //			if (!(role == null))
    //			{
    //				if (role.m_RoleModel.activeSelf)
    //				{
    //					int num2 = role.m_FightRoleData.MaxMP - role.m_FightRoleData.MP;
    //					if (num2 > 0)
    //					{
    //						float num3 = (float)role.m_FightRoleData.MP / (float)role.m_FightRoleData.MaxMP;
    //						if (num3 < mpRateLimit)
    //						{
    //							healList.Add(role);
    //							if (num2 > num)
    //							{
    //								num = num2;
    //								result = role;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	private M_Character ChooseAttackTarget_AI()
    //	{
    //		if (this.m_bIsControlCharacter && this.m_FightSceneMgr.GetMainTarget() != null && this.m_FightSceneMgr.GetMainTarget().CanBeTarget())
    //		{
    //			return this.m_FightSceneMgr.GetMainTarget();
    //		}
    //		int num = 0;
    //		Dictionary<M_Mob, int> allMobScore = this.m_FightSceneMgr.GetAllMobScore();
    //		foreach (KeyValuePair<M_Mob, int> current in allMobScore)
    //		{
    //			num += current.Value;
    //		}
    //		int num2 = UnityEngine.Random.Range(1, num);
    //		foreach (KeyValuePair<M_Mob, int> current2 in allMobScore)
    //		{
    //			if (num2 <= current2.Value)
    //			{
    //				return current2.Key;
    //			}
    //			num2 -= current2.Value;
    //		}
    //		return null;
    //	}

    //	public float GetAddActionCD()
    //	{
    //		return this.m_AddActionCD;
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
    //			this.m_MoveTimer = 0f;
    //			this.CheckTarget();
    //			this.m_RunToTargetTimer = 0f;
    //			this.m_emFight = M_Character.Enum_FightStatus.MoveToAttack;
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
    //			int num;
    //			if (this.m_MoveBackTimer > 0f)
    //			{
    //				this.m_MoveBackTimer -= Time.deltaTime;
    //				if (this.m_MoveBackTimer <= 0f)
    //				{
    //					this.m_MoveBackTimer = 0f;
    //					num = UnityEngine.Random.Range(1, 101);
    //					if (num <= 60)
    //					{
    //						this.CrossFadeAnimation(M_Character.State_BackJumpSmall, 0.1f);
    //						this.m_emFight = M_Character.Enum_FightStatus.JumpBack;
    //					}
    //					else
    //					{
    //						this.CrossFadeAnimation(this.State_Standby, 0.1f);
    //					}
    //				}
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
    //			num = UnityEngine.Random.Range(1, 101);
    //			if (num % 2 == 0)
    //			{
    //				if (this.m_bPause)
    //				{
    //					this.m_IdleTimer = UnityEngine.Random.Range(15f, 20f);
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
    //			this.m_MoveTimer = 2.5f;
    //			int towardPosDirection = base.GetTowardPosDirection(this.m_InitPos);
    //			if (towardPosDirection == 0)
    //			{
    //				this.CrossFadeAnimation(M_Player.State_Walk_Front_Start, 0.5f);
    //			}
    //			else if (towardPosDirection == 1)
    //			{
    //				this.CrossFadeAnimation(M_Player.State_Walk_Back_Start, 0.5f);
    //			}
    //			else if (towardPosDirection == 2)
    //			{
    //				this.CrossFadeAnimation(M_Player.State_Walk_Left_Start, 0.5f);
    //			}
    //			else
    //			{
    //				this.CrossFadeAnimation(M_Player.State_Walk_Right_Start, 0.5f);
    //			}
    //			return;
    //		}
    //	}

    //	public override bool DoCommand(FightCommand skillCommand)
    //	{
    //		if (!base.DoCommand(skillCommand))
    //		{
    //			return false;
    //		}
    //		if (skillCommand.m_Target is M_Mob)
    //		{
    //			this.m_PrevAtkMob = (skillCommand.m_Target as M_Mob);
    //		}
    //		if (!(skillCommand is FightCommand_Skill))
    //		{
    //			return true;
    //		}
    //		FightCommand_Skill fightCommand_Skill = skillCommand as FightCommand_Skill;
    //		if (fightCommand_Skill.m_SkillData.emSkillEffectType == ENUM_SkillEffectType.Skill)
    //		{
    //			for (int i = 0; i < this.m_PassiveSkillTrigger.Count; i++)
    //			{
    //				S_Skill data = GameDataDB.SkillDB.GetData(this.m_PassiveSkillTrigger[i]);
    //				if (data != null)
    //				{
    //					S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //					if (data2 != null)
    //					{
    //						if (data2.ActDataName == null || data2.ActDataName == "0")
    //						{
    //							base.DoCommand(new FightCommand_NoActDataSkill(this, this, this.m_PassiveSkillTrigger[i]));
    //						}
    //						else
    //						{
    //							base.DoCommand(new FightCommand_EndCallSkill(this, this, this.m_PassiveSkillTrigger[i]));
    //						}
    //					}
    //				}
    //			}
    //		}
    //		if (fightCommand_Skill.m_SkillData.emSkillEffectType == ENUM_SkillEffectType.SphereSkill)
    //		{
    //			for (int j = 0; j < this.m_PassiveSphereSkillTrigger.Count; j++)
    //			{
    //				S_Skill data = GameDataDB.SkillDB.GetData(this.m_PassiveSphereSkillTrigger[j]);
    //				if (data != null)
    //				{
    //					S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //					if (data2 != null)
    //					{
    //						if (data2.ActDataName == null || data2.ActDataName == "0")
    //						{
    //							base.DoCommand(new FightCommand_NoActDataSkill(this, this, this.m_PassiveSphereSkillTrigger[j]));
    //						}
    //						else
    //						{
    //							base.DoCommand(new FightCommand_EndCallSkill(this, this, this.m_PassiveSphereSkillTrigger[j]));
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public override void Update_AfterAttackMoveBack()
    //	{
    //		this.AfterAttackRandomRotate();
    //		this.CrossFadeAnimation(M_Player.State_Walk_Back_Start, 0.1f);
    //		this.m_MoveBackTimer = 1f;
    //		this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //	}

    //	public override void Update_JumpBack()
    //	{
    //		if (this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash != this.State_Standby)
    //		{
    //			return;
    //		}
    //		if (this.m_FaceToTarget != this)
    //		{
    //			this.UpdateDirection_Directly(this.m_FaceToTarget.GetModelPosition());
    //		}
    //		this.CrossFadeAnimation(M_Player.State_Walk_Back_Start, 0.1f);
    //		int towardPosDirection = base.GetTowardPosDirection(this.m_InitPos);
    //		if (towardPosDirection == 0)
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Walk_Front_Start, 0.1f);
    //		}
    //		else if (towardPosDirection == 1)
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Walk_Back_Start, 0.1f);
    //		}
    //		else if (towardPosDirection == 2)
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Walk_Left_Start, 0.1f);
    //		}
    //		else
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Walk_Right_Start, 0.1f);
    //		}
    //		this.m_MoveTimer = 2.5f;
    //		this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //	}

    //	public override void Update_Revive()
    //	{
    //		if (this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash == this.State_Standby)
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
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
    //			this.CrossFadeAnimation(M_Player.State_Giddy_Start, 0.1f);
    //		}
    //		else
    //		{
    //			if (!base.CannotUseAnyCommand())
    //			{
    //				return;
    //			}
    //			this.CrossFadeAnimation(M_Player.State_Giddy_End, 0.1f);
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
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Freeze)
    //		{
    //			return;
    //		}
    //		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
    //		if (currentAnimatorStateInfo.nameHash == M_Player.State_Giddy_Start)
    //		{
    //			return;
    //		}
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
    //		this.CrossFadeAnimation(M_Player.State_Giddy_Start, 0.1f);
    //	}

    //	private void CheckTarget()
    //	{
    //		if (this.m_FightSceneMgr.m_IsFightFinish)
    //		{
    //			return;
    //		}
    //		FightCommand fightCommand = null;
    //		if (this.m_CommandQueue.Count > 0)
    //		{
    //			fightCommand = this.m_CommandQueue[0];
    //		}
    //		if (fightCommand != null)
    //		{
    //			M_Character target = fightCommand.m_Target;
    //			S_UseEffect data = GameDataDB.UseEffectDB.GetData(fightCommand.m_UseEffectID);
    //			if (data == null)
    //			{
    //				return;
    //			}
    //			if (data.DeBuffer.Contains(84))
    //			{
    //				return;
    //			}
    //			if (target == null || target.IsDead() || !target.m_RoleModel.activeSelf)
    //			{
    //				if (data.emTarget == ENUM_UseTarget.Enemy)
    //				{
    //					fightCommand.m_Target = this.m_FightSceneMgr.GetFirstOrder_Mob();
    //					if (fightCommand.m_Target == null)
    //					{
    //						this.m_CommandQueue.Remove(fightCommand);
    //						return;
    //					}
    //					this.m_ActionTargetModel = fightCommand.m_Target.m_RoleModel;
    //					if (fightCommand.m_Target is M_Mob || base.IsLoseHeart())
    //					{
    //						base.SetFaceToTarget(fightCommand.m_Target);
    //					}
    //				}
    //				if (data.emTarget == ENUM_UseTarget.Partner)
    //				{
    //					fightCommand.m_Target = this.m_FightSceneMgr.GetFirstOrder_Role();
    //					if (fightCommand.m_Target == null)
    //					{
    //						this.m_CommandQueue.Remove(fightCommand);
    //						return;
    //					}
    //				}
    //			}
    //			else
    //			{
    //				this.m_ActionTargetModel = fightCommand.m_Target.m_RoleModel;
    //				if (fightCommand.m_Target is M_Mob || base.IsLoseHeart())
    //				{
    //					base.SetFaceToTarget(fightCommand.m_Target);
    //				}
    //				if (base.IsLoseHeart())
    //				{
    //					base.SetFaceToTarget(fightCommand.m_Target);
    //				}
    //			}
    //		}
    //		if (this.m_FaceToTarget == null || this.m_FaceToTarget.IsDead())
    //		{
    //			if (base.IsLoseHeart())
    //			{
    //				return;
    //			}
    //			if ((this.m_FaceToTarget is M_Guard || this.m_FaceToTarget is M_Player) && this.m_FightSceneMgr.GetFirstOrder_Mob() != null)
    //			{
    //				this.m_ActionTargetModel = this.m_FightSceneMgr.GetFirstOrder_Mob().m_RoleModel;
    //				base.SetFaceToTarget(this.m_FightSceneMgr.GetFirstOrder_Mob());
    //			}
    //		}
    //	}

    //	private int CostDowbByBuff(ENUM_ElementType emElmentType, int castMP)
    //	{
    //		float num = (float)castMP;
    //		num += 0.1f;
    //		return Mathf.RoundToInt(num);
    //	}

    //	public override bool AddSkillCommand(int skillId, M_Character target)
    //	{
    //		S_Skill data = GameDataDB.SkillDB.GetData(skillId);
    //		if (data == null)
    //		{
    //			return false;
    //		}
    //		S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //		if (data2 == null)
    //		{
    //			return false;
    //		}
    //		if (target == null)
    //		{
    //			return false;
    //		}
    //		int skillCostMP = this.GetSkillCostMP(data2.emElementType, data.CastMP);
    //		if (this.m_FightRoleData.MP < skillCostMP)
    //		{
    //			return false;
    //		}
    //		bool flag = base.AddSkillCommand(skillId, target);
    //		if (flag)
    //		{
    //			this.m_FightRoleData.MP -= skillCostMP;
    //			Swd6Application.instance.m_UserBehavior.EventInfo.Counter(skillId, CounterType.Skill);
    //		}
    //		if (flag && this.m_SkillCDList.ContainsKey(skillId))
    //		{
    //			this.m_ActionCDTimer += this.m_SkillCDList[skillId];
    //			if (this.m_bUseAI)
    //			{
    //				int num = UnityEngine.Random.Range(6, 12);
    //				this.m_AIDelayTimer = (0.55f - (float)(this.m_FightRoleData.Level / 10) * 0.05f) * (float)num;
    //			}
    //			this.m_AddActionCD = this.m_ActionCDTimer;
    //		}
    //		if (flag && this.m_bIsControlCharacter)
    //		{
    //			UI_Fight.Instance.UpdateSkillBtnEnable();
    //			UI_Fight.Instance.UpdateItemBtnEnableAndCount();
    //		}
    //		return flag;
    //	}

    //	private int GetSkillCostMP(ENUM_ElementType emType, int originalMP)
    //	{
    //		float num = (float)originalMP;
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (emType == ENUM_ElementType.Null || emType == ENUM_ElementType.Physical)
    //			{
    //				break;
    //			}
    //			bool flag = false;
    //			if (emType == ENUM_ElementType.Wind && this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.WindCostDown)
    //			{
    //				flag = true;
    //			}
    //			if (emType == ENUM_ElementType.Earth && this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.EarthCostDown)
    //			{
    //				flag = true;
    //			}
    //			if (emType == ENUM_ElementType.Water && this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.WaterCostDown)
    //			{
    //				flag = true;
    //			}
    //			if (emType == ENUM_ElementType.Fire && this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.FireCostDown)
    //			{
    //				flag = true;
    //			}
    //			if (flag)
    //			{
    //				num = num * (float)(100 - this.m_NoRemoveBuffList[i].m_BuffData.CostDown) / 100f;
    //			}
    //		}
    //		if (this.m_MagicItem_Passive != null && ((emType == ENUM_ElementType.Wind && this.m_MagicItem.ID == 710) || (emType == ENUM_ElementType.Earth && this.m_MagicItem.ID == 711) || (emType == ENUM_ElementType.Water && this.m_MagicItem.ID == 712) || (emType == ENUM_ElementType.Fire && this.m_MagicItem.ID == 713)))
    //		{
    //			num = this.m_MagicItem_Passive.GetReducedCastMP(num);
    //		}
    //		num += 0.1f;
    //		return Mathf.FloorToInt(num);
    //	}

    //	public bool AddItemCommand_UI(int itemID, M_Character target)
    //	{
    //		return !this.m_bStoryMode && this.AddItemCommand(itemID, target);
    //	}

    //	public bool AddItemCommand(int itemID, M_Character target)
    //	{
    //		if (this.m_bStoryMode)
    //		{
    //			return false;
    //		}
    //		if (this.m_CommandQueue.Count >= 2)
    //		{
    //			return false;
    //		}
    //		S_Item data = GameDataDB.ItemDB.GetData(itemID);
    //		if (data == null)
    //		{
    //			return false;
    //		}
    //		S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //		if (data2 == null)
    //		{
    //			return false;
    //		}
    //		if (target == null)
    //		{
    //			return false;
    //		}
    //		if (!base.CheckCommandTarget(this, target, data2))
    //		{
    //			return false;
    //		}
    //		ItemData dataByItemID = Swd6Application.instance.m_ItemSystem.GetDataByItemID(itemID);
    //		if (dataByItemID == null)
    //		{
    //			Debug.Log("無此道具");
    //			return false;
    //		}
    //		if (dataByItemID.Count <= 0)
    //		{
    //			return false;
    //		}
    //		this.m_CommandQueue.Add(new FightCommand_Item(this, target, itemID));
    //		this.m_ActionCDTimer = base.GetActionCD();
    //		if (!this.m_bIsControlCharacter)
    //		{
    //			int num = UnityEngine.Random.Range(6, 12);
    //			this.m_AIDelayTimer = (0.55f - (float)(this.m_FightRoleData.Level / 10) * 0.05f) * (float)num;
    //		}
    //		this.m_AddActionCD = this.m_ActionCDTimer;
    //		Swd6Application.instance.m_ItemSystem.DeleteItemByItemID(itemID, 1, false);
    //		Swd6Application.instance.m_UserBehavior.EventInfo.Counter(itemID, CounterType.Item);
    //		if (this.m_FightSceneMgr.m_UsedItemList.ContainsKey(dataByItemID))
    //		{
    //			Dictionary<ItemData, int> usedItemList;
    //			Dictionary<ItemData, int> expr_149 = usedItemList = this.m_FightSceneMgr.m_UsedItemList;
    //			ItemData key;
    //			ItemData expr_14D = key = dataByItemID;
    //			int num2 = usedItemList[key];
    //			expr_149[expr_14D] = num2 + 1;
    //		}
    //		else
    //		{
    //			this.m_FightSceneMgr.m_UsedItemList.Add(dataByItemID, 1);
    //		}
    //		UI_Fight.Instance.UpdateSkillBtnEnable();
    //		UI_Fight.Instance.UpdateItemBtnEnableAndCount();
    //		return true;
    //	}

    //	public M_Mob GetPrevAtkMob()
    //	{
    //		return this.m_PrevAtkMob;
    //	}

    //	public int[] GetCommandQueue()
    //	{
    //		int[] array = new int[this.m_CommandQueue.Count];
    //		for (int i = 0; i < this.m_CommandQueue.Count; i++)
    //		{
    //			array[i] = this.m_CommandQueue.ToArray()[i].m_UseEffectID;
    //		}
    //		return array;
    //	}

    public void SetIsControlCharacter(bool bIsControlCharacter)
    {
        this.m_bIsControlCharacter = bIsControlCharacter;
    }

    //	public void SetFormationData(FormationData fData, int unitIdx)
    //	{
    //		this.m_FormationData = fData;
    //		this.m_FormationUnitIdx = unitIdx;
    //		this.m_emFormationActionType = fData.Unit[unitIdx].emActionType;
    //		this.m_emAIType = fData.Unit[unitIdx].emAI;
    //	}

    public override void InitFightRoleData()
    {
        //this.m_FightRoleData.Level = this.m_RoleDataEx.GetLevel();
        //this.m_FightRoleData.MaxHP = this.m_RoleDataEx.RoleAttr.sFinial.MaxHP;
        //this.m_FightRoleData.HP = this.m_RoleDataEx.GetHP();
        //this.m_OriginalHP = this.m_RoleDataEx.GetHP();
        //this.m_FightRoleData.MaxMP = this.m_RoleDataEx.RoleAttr.sFinial.MaxMP;
        //this.m_FightRoleData.MP = this.m_RoleDataEx.GetMP();
        //this.m_FightRoleData.Atk = this.m_RoleDataEx.RoleAttr.sFinial.Attack;
        //this.m_FightRoleData.Def = this.m_RoleDataEx.RoleAttr.sFinial.Def;
        //this.m_FightRoleData.MagicAtk = this.m_RoleDataEx.RoleAttr.sFinial.MAttack;
        //this.m_FightRoleData.MagicDef = this.m_RoleDataEx.RoleAttr.sFinial.MDef;
        //this.m_FightRoleData.Agi = this.m_RoleDataEx.RoleAttr.sFinial.Agi;
        //this.m_FightRoleData.Dodge = this.m_RoleDataEx.RoleAttr.sFinial.Dodge;
        //this.m_FightRoleData.Block = this.m_RoleDataEx.RoleAttr.sFinial.Block;
        //this.m_FightRoleData.Critical = this.m_RoleDataEx.RoleAttr.sFinial.Critical;
        //int[] array = new int[4];
        //for (int i = 0; i < array.Length; i++)
        //{
        //    if (i < this.m_RoleDataEx.RoleAttr.sFinial.AtkElement.Length)
        //    {
        //        array[i] = this.m_RoleDataEx.RoleAttr.sFinial.AtkElement[i];
        //    }
        //    else
        //    {
        //        array[i] = 0;
        //    }
        //}
        //int[] array2 = new int[4];
        //for (int j = 0; j < array2.Length; j++)
        //{
        //    if (j < this.m_RoleDataEx.RoleAttr.sFinial.Element.Length)
        //    {
        //        array2[j] = this.m_RoleDataEx.RoleAttr.sFinial.Element[j];
        //    }
        //    else
        //    {
        //        array2[j] = 0;
        //    }
        //}
        //this.m_FightRoleData.DefElement = array2;
    }

    //	public void ResetHP_Refight()
    //	{
    //		this.m_RoleDataEx.SetHP(this.m_OriginalHP);
    //	}

    //	public override void UpdateFightRoleData()
    //	{
    //		if (base.IsDead())
    //		{
    //			this.m_RoleDataEx.SetBuffs(this.m_BuffList, null);
    //		}
    //		else
    //		{
    //			this.m_RoleDataEx.SetBuffs(this.m_BuffList, this.m_NoRemoveBuffList);
    //		}
    //		this.m_RoleDataEx.SetFormationInfo(this.m_FormationData, this.m_FormationUnitIdx);
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Finish)
    //		{
    //			this.m_RoleDataEx.CalRoleAttr();
    //		}
    //		else
    //		{
    //			this.m_RoleDataEx.CalRoleAttr_Fight();
    //		}
    //		this.m_FightRoleData.Level = this.m_RoleDataEx.GetLevel();
    //		this.m_FightRoleData.MaxHP = this.m_RoleDataEx.RoleAttr.sFinial.MaxHP;
    //		this.m_FightRoleData.MaxMP = this.m_RoleDataEx.RoleAttr.sFinial.MaxMP;
    //		this.m_FightRoleData.Atk = this.m_RoleDataEx.RoleAttr.sFinial.Attack;
    //		this.m_FightRoleData.Def = this.m_RoleDataEx.RoleAttr.sFinial.Def;
    //		this.m_FightRoleData.MagicAtk = this.m_RoleDataEx.RoleAttr.sFinial.MAttack;
    //		this.m_FightRoleData.MagicDef = this.m_RoleDataEx.RoleAttr.sFinial.MDef;
    //		this.m_FightRoleData.Agi = this.m_RoleDataEx.RoleAttr.sFinial.Agi;
    //		this.m_FightRoleData.Dodge = this.m_RoleDataEx.RoleAttr.sFinial.Dodge;
    //		this.m_FightRoleData.Block = this.m_RoleDataEx.RoleAttr.sFinial.Block;
    //		this.m_FightRoleData.Critical = this.m_RoleDataEx.RoleAttr.sFinial.Critical;
    //		int[] array = new int[4];
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			if (i < this.m_RoleDataEx.RoleAttr.sFinial.AtkElement.Length)
    //			{
    //				array[i] = this.m_RoleDataEx.RoleAttr.sFinial.AtkElement[i];
    //			}
    //			else
    //			{
    //				array[i] = 0;
    //			}
    //		}
    //		this.m_FightRoleData.AtkElement = array;
    //		int[] array2 = new int[4];
    //		for (int j = 0; j < array2.Length; j++)
    //		{
    //			if (j < this.m_RoleDataEx.RoleAttr.sFinial.Element.Length)
    //			{
    //				array2[j] = this.m_RoleDataEx.RoleAttr.sFinial.Element[j];
    //			}
    //			else
    //			{
    //				array2[j] = 0;
    //			}
    //		}
    //		this.m_FightRoleData.DefElement = array2;
    //		base.CheckTransElementTypeBuff();
    //		if (this.m_BuffList.ContainsKey(78))
    //		{
    //			float num = (float)this.m_FightRoleData.Agi * 0.5f;
    //			this.m_FightRoleData.Agi = Mathf.RoundToInt(num + 0.1f);
    //		}
    //		this.m_ActionCD = (float)(500 - this.m_FightRoleData.Agi) / 100f;
    //	}

    //	public override int GetBeingTargetScore()
    //	{
    //		if (base.IsDead())
    //		{
    //			return -1;
    //		}
    //		float num = -1f;
    //		switch (this.m_emFormationActionType)
    //		{
    //		case ENUM_FormationActionType.Leader:
    //			if (this.m_FormationData.emElement == ENUM_ElementType.Wind)
    //			{
    //				num = 30f;
    //			}
    //			if (this.m_FormationData.emElement == ENUM_ElementType.Earth)
    //			{
    //				num = 55f;
    //			}
    //			if (this.m_FormationData.emElement == ENUM_ElementType.Water)
    //			{
    //				num = 15f;
    //			}
    //			if (this.m_FormationData.emElement == ENUM_ElementType.Fire)
    //			{
    //				num = 30f;
    //			}
    //			break;
    //		case ENUM_FormationActionType.Attack:
    //			num = 30f;
    //			break;
    //		case ENUM_FormationActionType.Defence:
    //			num = 55f;
    //			break;
    //		case ENUM_FormationActionType.Support:
    //			num = 15f;
    //			break;
    //		}
    //		if (num < 0f)
    //		{
    //			return -1;
    //		}
    //		float num2 = 1f;
    //		if (this.m_BuffList.ContainsKey(22))
    //		{
    //			if (this.m_MagicItem_Active != null)
    //			{
    //				num2 = this.m_MagicItem_Active.GetAttrEffectValue();
    //			}
    //		}
    //		else if (this.m_BuffList.ContainsKey(83) && this.m_MagicItem_Active != null)
    //		{
    //			num2 = this.m_MagicItem_Active.GetAttrEffectValue();
    //		}
    //		num *= num2;
    //		return Mathf.RoundToInt(num + 0.1f);
    //	}

    //	public void UpdateUIBuffIcon()
    //	{
    //		UI_Fight.Instance.UpdatePlayerBuffIcon(this.m_RoleID, base.GetShowBuffs());
    //		UI_Fight.Instance.UpdateSkillBtnEnable();
    //	}

    //	public void Win()
    //	{
    //		this.ClearCommand();
    //		this.SetFightFinish();
    //		if (!base.IsDead())
    //		{
    //			base.SetAnimatorSpeed(1f);
    //			this.CrossFadeAnimation(M_Player.State_Win, 0.3f);
    //		}
    //	}

    //	public void Lose()
    //	{
    //		this.ClearCommand();
    //		this.SetFightFinish();
    //	}

    //	public override void ChangeMP_Buff(int mp, Enum_FightHitType emType)
    //	{
    //		base.ChangeMP_Buff(mp, emType);
    //		if (this.m_bIsControlCharacter)
    //		{
    //			UI_Fight.Instance.UpdateSkillBtnEnable();
    //		}
    //	}

    //	public void CheckDeadAnimation()
    //	{
    //		if (!this.m_bStartUpdate)
    //		{
    //			return;
    //		}
    //		if (this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash != M_Player.State_Dead && !this.m_Animator.IsInTransition(0))
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Dead, 0.1f);
    //		}
    //	}

    //	public void SetUseAI(bool bUseAI)
    //	{
    //		this.m_bUseAI = bUseAI;
    //	}

    //	public void OverwriteRoleData()
    //	{
    //		this.m_RoleDataEx.CleanBuffs();
    //		this.m_RoleDataEx.ResetFormationData();
    //		this.m_RoleDataEx.CalRoleAttr();
    //		this.m_RoleDataEx.SetHP(this.m_FightRoleData.HP);
    //		this.m_RoleDataEx.SetMP(this.m_FightRoleData.MP);
    //		if (this.m_FightRoleData.HP <= 0)
    //		{
    //			this.m_RoleDataEx.SetHP(1);
    //			this.m_RoleDataEx.BaseRoleData.IsDeath = false;
    //		}
    //	}

    //	public void UseMagicItem()
    //	{
    //		if (this.m_MagicItem_Active == null)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionCDTimer > 0f)
    //		{
    //			return;
    //		}
    //		bool flag = false;
    //		if (this.m_MagicItem_Active.m_EquipItem.ID >= 731 && this.m_MagicItem_Active.m_EquipItem.ID <= 734)
    //		{
    //			if (this.m_FightSceneMgr.GetMainTarget() == null)
    //			{
    //				return;
    //			}
    //			FightCommand_MagicItem item = new FightCommand_MagicItem(this, this.m_FightSceneMgr.GetMainTarget(), this.m_MagicItem_Active.m_EquipItem.ID);
    //			this.m_CommandQueue.Add(item);
    //			this.m_ActionCDTimer = base.GetActionCD();
    //			this.m_AddActionCD = this.m_ActionCDTimer;
    //			flag = true;
    //		}
    //		if (this.m_MagicItem_Active.m_EquipItem.ID == 738 || this.m_MagicItem_Active.m_EquipItem.ID == 739)
    //		{
    //			FightCommand_MagicItem item2 = new FightCommand_MagicItem(this, this, this.m_MagicItem_Active.m_EquipItem.ID);
    //			this.m_CommandQueue.Add(item2);
    //			this.m_ActionCDTimer = base.GetActionCD();
    //			this.m_AddActionCD = this.m_ActionCDTimer;
    //			flag = true;
    //		}
    //		if (this.m_MagicItem_Active.m_EquipItem.ID == 735)
    //		{
    //			flag = this.m_MagicItem_Active.UseMouseHammer(this.m_FightSceneMgr.GetMainTarget());
    //		}
    //		if (this.m_MagicItem_Active.m_EquipItem.ID == 736)
    //		{
    //			flag = this.m_MagicItem_Active.UseDragonFlag(this.m_FightSceneMgr.GetMainTarget());
    //		}
    //		if (this.m_MagicItem_Active.m_EquipItem.ID == 737)
    //		{
    //			flag = this.m_MagicItem_Active.UseBonusDrop(this.m_FightSceneMgr.GetMainTarget());
    //		}
    //		if (flag && this.m_bIsControlCharacter)
    //		{
    //			UI_Fight.Instance.UpdateSkillBtnEnable();
    //			UI_Fight.Instance.UpdateItemBtnEnableAndCount();
    //			this.m_MagicItem_Active.AddExp();
    //		}
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
    //		}
    //		else if (base.CheckCommandNeedMove(command.m_UseEffectID))
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.AfterAttackMoveBack;
    //		}
    //		else
    //		{
    //			this.m_emFight = M_Character.Enum_FightStatus.Idle;
    //		}
    //	}

    //	public override void OnHitAnimation(Enum_FightHitType hitType)
    //	{
    //		if (base.IsDead())
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
    //			case Enum_FightHitType.DamageMP:
    //			case Enum_FightHitType.ReflexDamageHP:
    //			case Enum_FightHitType.ReflexDamageMP:
    //			{
    //				if (this.m_ShroudInstance != null)
    //				{
    //					this.m_ShroudInstance.ReduceBlendWeight();
    //				}
    //				this.m_Animator.applyRootMotion = false;
    //				if (this.m_ShroudInstance != null)
    //				{
    //					this.m_ShroudInstance.ReduceBlendWeight();
    //				}
    //				int num = UnityEngine.Random.Range(0, 100);
    //				if (num < 10)
    //				{
    //					this.m_Animator.Play(M_Character.State_Hit2, 0, 0f);
    //				}
    //				else
    //				{
    //					this.m_Animator.Play(M_Character.State_Hit, 0, 0f);
    //				}
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
    //		if (base.IsDead())
    //		{
    //			return;
    //		}
    //		this.HitDamageReCaculate_Buff_MagicItem(ref hitType, ref value, actor);
    //		FhightPopUpMsg.Instance.ShowFightPopUpMsg(hitType, bCritical, bBlock, value, this.m_HitTransform, true);
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
    //			if (this.m_bIsControlCharacter)
    //			{
    //				UI_Fight.Instance.UpdateSkillBtnEnable();
    //			}
    //			break;
    //		case Enum_FightHitType.RestoreHP:
    //		case Enum_FightHitType.DrainLife:
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
    //			if (this.m_bIsControlCharacter)
    //			{
    //				UI_Fight.Instance.UpdateSkillBtnEnable();
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
    //		if (this.m_BuffList.ContainsKey(23))
    //		{
    //			Buff_Berserker buff_Berserker = this.m_BuffList[23] as Buff_Berserker;
    //			buff_Berserker.UpdateBuffRoleAttrPlusID();
    //			this.UpdateFightRoleData();
    //		}
    //	}

    //	public override void DmgReduce(ref int dmgValue)
    //	{
    //		base.DmgReduce(ref dmgValue);
    //	}

    //	public override void DmgAbsorb(ref Enum_FightHitType hitType, ref int dmgValue)
    //	{
    //		if (this.m_MagicItem_Passive != null && this.m_MagicItem_Passive.m_ItemInfo.GetGUID() == 723)
    //		{
    //			dmgValue = this.m_MagicItem_Passive.Absorb_HP(dmgValue);
    //			if (dmgValue == 0)
    //			{
    //				hitType = Enum_FightHitType.Absort;
    //				return;
    //			}
    //		}
    //		if (this.m_MagicItem_Passive != null && this.m_MagicItem_Passive.m_ItemInfo.GetGUID() == 729 && this.m_MagicItem_Passive.MoneyGuard(dmgValue))
    //		{
    //			dmgValue = 0;
    //			hitType = Enum_FightHitType.Absort;
    //			return;
    //		}
    //		base.DmgAbsorb(ref hitType, ref dmgValue);
    //	}

    //	public override void CheckRelfexDamage(Enum_FightHitType emHitType, int hitValue, M_Character actor)
    //	{
    //		if (this.m_MagicItem_Passive != null && this.m_MagicItem_Passive.m_ItemInfo.GetGUID() == 722)
    //		{
    //			this.m_MagicItem_Passive.Reflex(hitValue, actor);
    //		}
    //		base.CheckRelfexDamage(emHitType, hitValue, actor);
    //	}

    //	public override void Dead()
    //	{
    //		if (this.m_emFight == M_Character.Enum_FightStatus.Dead)
    //		{
    //			return;
    //		}
    //		if (this.m_MagicItem_Passive != null && this.m_MagicItem_Passive.m_ItemInfo.GUID == 721 && this.m_MagicItem_Passive.Revive())
    //		{
    //			return;
    //		}
    //		this.m_FightRoleData.HP = 0;
    //		this.RedemptionBuff();
    //		this.ClearCommand();
    //		if (this.m_bStartUpdate)
    //		{
    //			this.CrossFadeAnimation(M_Player.State_Dead, 0.1f);
    //			AudioClip sound = ResourceManager.Instance.GetSound("p0" + this.m_RoleID.ToString() + "1_dead");
    //			if (sound != null)
    //			{
    //				MusicSystem.Instance.PlaySoundAtPos(sound, this.GetModelPosition());
    //			}
    //		}
    //		this.m_FightSceneMgr.OnRoleDead(this);
    //		this.m_emFight = M_Character.Enum_FightStatus.Dead;
    //	}

    //	private void RedemptionBuff()
    //	{
    //		if (this.m_BuffList.ContainsKey(26))
    //		{
    //			int num = this.m_BuffList[26].m_BuffData.Level * 20;
    //			Dictionary<int, M_Player> roleList = this.m_FightSceneMgr.GetRoleList();
    //			if (roleList != null)
    //			{
    //				foreach (KeyValuePair<int, M_Player> current in roleList)
    //				{
    //					if (!(current.Value == this))
    //					{
    //						if (!current.Value.IsDead())
    //						{
    //							current.Value.ChangeHP_Percentage_Buff((float)num, this, Enum_FightHitType.RestoreHP);
    //						}
    //					}
    //				}
    //			}
    //		}
    //		for (int i = 0; i < this.m_NoRemoveBuffList.Count; i++)
    //		{
    //			if (this.m_NoRemoveBuffList[i].m_BuffData.emBuffType == ENUM_BuffType.Redemption)
    //			{
    //				int num2 = this.m_NoRemoveBuffList[i].m_BuffData.Level * 20;
    //				Dictionary<int, M_Player> roleList2 = this.m_FightSceneMgr.GetRoleList();
    //				if (roleList2 != null)
    //				{
    //					foreach (KeyValuePair<int, M_Player> current2 in roleList2)
    //					{
    //						if (!(current2.Value == this))
    //						{
    //							if (!current2.Value.IsDead())
    //							{
    //								current2.Value.ChangeHP_Percentage_Buff((float)num2, this, Enum_FightHitType.RestoreHP);
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public override void Revive()
    //	{
    //		base.Revive();
    //		this.CrossFadeAnimation(M_Player.State_Revive, 0.3f);
    //	}

    //	public void CheckPlayerDead()
    //	{
    //		if (this.m_FightRoleData.HP <= 0)
    //		{
    //			this.Dead();
    //		}
    //	}

    //	public bool CheckCanUseSkill(int skillID)
    //	{
    //		if (this.m_ActionCDTimer > 0f)
    //		{
    //			return false;
    //		}
    //		S_Skill data = GameDataDB.SkillDB.GetData(skillID);
    //		return data != null && this.m_FightRoleData.MP >= data.CastMP && !base.CannotUseAnyCommand() && base.CheckSkillCastBuff(data.CastBuffer);
    //	}

    //	private void AfterAttackRandomRotate()
    //	{
    //		int num = UnityEngine.Random.Range(1, 101);
    //		int num2 = UnityEngine.Random.Range(10, 31);
    //		Vector3 vector = this.m_FightPosition.transform.position - this.GetModelPosition();
    //		if (num % 2 > 0)
    //		{
    //			base.transform.Rotate(Vector3.up, (float)(-(float)num2));
    //		}
    //		else
    //		{
    //			base.transform.Rotate(Vector3.up, (float)num2);
    //		}
    //	}

    //	public override void AddStatisticsValue(Enum_FightStatisticsType emType, int value)
    //	{
    //		base.AddStatisticsValue(emType, value);
    //		switch (emType)
    //		{
    //		case Enum_FightStatisticsType.Attack:
    //			UI_GameGMFightStatistics.Instance.SetRoleInfo(emType, this.m_RoleID, this.m_TotalAttack);
    //			break;
    //		case Enum_FightStatisticsType.Damage:
    //			UI_GameGMFightStatistics.Instance.SetRoleInfo(emType, this.m_RoleID, this.m_TotalDamage);
    //			break;
    //		case Enum_FightStatisticsType.Heal:
    //			UI_GameGMFightStatistics.Instance.SetRoleInfo(emType, this.m_RoleID, this.m_TotalHeal);
    //			break;
    //		case Enum_FightStatisticsType.BeHealed:
    //			UI_GameGMFightStatistics.Instance.SetRoleInfo(emType, this.m_RoleID, this.m_TotalBeHealed);
    //			break;
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

    //	public M_Character ChooseHealTarget_AI()
    //	{
    //		List<M_Player> list = new List<M_Player>();
    //		foreach (KeyValuePair<int, M_Player> current in this.m_FightSceneMgr.GetRoleList())
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

    //	public M_Character ChooseAssistTarget_AI(ENUM_UseTarget emTarget, List<int> buff)
    //	{
    //		if (emTarget == ENUM_UseTarget.Enemy)
    //		{
    //			return this.ChooseAttackTarget_AI();
    //		}
    //		if (emTarget == ENUM_UseTarget.Self)
    //		{
    //			return this;
    //		}
    //		List<M_Player> list = new List<M_Player>();
    //		foreach (KeyValuePair<int, M_Player> current in this.m_FightSceneMgr.GetRoleList())
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
}
