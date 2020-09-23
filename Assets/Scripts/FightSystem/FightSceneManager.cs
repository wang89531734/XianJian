using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using YouYou;

public class FightSceneManager
{
    public ProcedureGameLevel m_FihgtState;

    private int m_MobSerialID;

    private int m_GuardSerialID;

    //public M_CatchMob m_CatchMobPet;

    /// <summary>
    /// 玩家列表
    /// </summary>
    public Dictionary<int, M_Player> m_PlayerList = new Dictionary<int, M_Player>();

    public List<M_Player> PlayerList = new List<M_Player>();

    //public Dictionary<int, M_Guard> m_GuardList = new Dictionary<int, M_Guard>();

    public Dictionary<int, M_Mob> m_MobList = new Dictionary<int, M_Mob>();

    public List<M_Mob> MobList = new List<M_Mob>();

    public Dictionary<int, int> m_CatchMobList = new Dictionary<int, int>();

    public List<int> m_CatchMobKeyIDList = new List<int>();

    private List<S_FinishMob> m_DeadMobList = new List<S_FinishMob>();

    public Dictionary<string, M_Mob> m_SummonMobRecordList = new Dictionary<string, M_Mob>();

    /// <summary>
    /// 奖励列表
    /// </summary>
    public List<M_Mob> m_MobRewardList = new List<M_Mob>();

    public Dictionary<int, int> m_BonusDropItemList = new Dictionary<int, int>();

    private List<int> m_AIReviveItems = new List<int>();

    private List<int> m_AIHealItems_Single = new List<int>();

    private List<int> m_AIHealItems_All = new List<int>();

    private List<int> m_AIRestoreMPItems_Single = new List<int>();

    private List<int> m_AIRestoreMPItems_All = new List<int>();

    private List<int> m_AIDebuffItems = new List<int>();

    private int m_NowFormationIdx;

    private FormationData m_NowFormation;

    /// <summary>
    /// 守卫索引
    /// </summary>
    private int m_GuardIdx;

    /// <summary>
    /// 主角
    /// </summary>
    private M_Player m_MainPlayer;

    /// <summary>
    /// 主要目标
    /// </summary>
    private M_Mob m_MainTarget;

    /// <summary>
    /// 控制角色ID
    /// </summary>
    public int m_ControlledRoleID = -1;

    public int m_TargetMobKeyID;

    public Transform m_BattlePoint;

    public GameObject m_FightPosition;

    /// <summary>
    /// 战斗摄像机
    /// </summary>
    public GameObject m_FightCamera;

    public GameObject m_NowTargetEffect;

    public GameObject m_NowControlledEffect;

    public Dictionary<int, GameObject> m_GuardMobEffect = new Dictionary<int, GameObject>();

    public List<Transform> m_MobIdlePoint = new List<Transform>();

    public Dictionary<ItemData, int> m_UsedItemList = new Dictionary<ItemData, int>();

    public int m_BattleGroupGUID;

    /// <summary>
    /// 战斗组实体
    /// </summary>
    public S_BattleGroup m_BattleGroup;

    public bool m_bParcticeFight;

    private int m_PracticeFightExp;

    /// <summary>
    /// 战斗是否完成
    /// </summary>
    public bool m_IsFightFinish;

    /// <summary>
    /// 战斗是否开始
    /// </summary>
    public bool m_IsFightStart;

    public bool m_bIsPauseMode;

    public bool m_bIsStoryMode;

    public bool m_bWin;

    public float m_CatchMobCDTimer;

    public float m_ChangeFormationCDTimer;

    private float m_FightTotalTime;

    public float m_FightTotalTime_RealFightCD;

    //public BuffSystem m_BuffSystem;

    public M_FightCameraController m_FightCameraController;

    private GameObject m_AppearCamPath;

    private GameObject m_LevelUpCamPath;

    private bool m_IsAppearFinish;

    //public M_FightTalk m_FightTalk;

    public bool m_FightTalkControlWin;

    public bool m_FightTalkControlMobDead;

    private int m_FightTalkMoney;

    private int m_FightTalkExp;

    private Dictionary<int, int> m_FightTalkItemList = new Dictionary<int, int>();

    private UIFightForm FightUIForm;

    public int CurrentWave { get; private set; }

    public M_Character ActiveCharacter { get; private set; }

    public FightSceneManager()
    {
        CurrentWave = 0;
        this.m_GuardIdx = 0;
        this.m_MobSerialID = 0;
        this.m_ControlledRoleID = -1;
        this.m_MainPlayer = null;
        this.m_IsFightFinish = false;
        this.m_bWin = false;
        //this.SetPauseMode(NormalSettingSystem.Instance.GetNormalSetting().m_bEnableFightStop);//暂停模型
        //UI_FinishFight.Instance.m_FightSceneMgr = this;
        GameEntry.UI.OpenUIForm(UIFormId.UI_Fight, null, (UIFormBase trans2) =>
        {
            FightUIForm = trans2.gameObject.GetComponent<UIFightForm>();
            FightUIForm.m_FightSceneMgr = this;
            this.Initialize();
        });
    }

    public void Update()
    {
        //if (this.m_IsFightFinish)
        //{
        //    return;
        //}
        //if (this.m_IsFightStart)
        //{
        //    this.m_FightTotalTime += Time.deltaTime;
        //}
        //if (this.IsAllMobDead())
        //{
        //    if (!this.m_FightTalkControlWin)
        //    {
        //        this.Win();
        //    }
        //    return;
        //}
        //if (this.IsAllPlayerDead())
        //{
        //    this.Lose();
        //    return;
        //}
    }

    //	private void TargetEffectCheck()
    //	{
    //		int num = 0;
    //		foreach (M_Mob current in this.m_MobList.Values)
    //		{
    //			if (!current.IsDead() && current.m_RoleModel.activeSelf && current.CanBeTarget())
    //			{
    //				num++;
    //			}
    //		}
    //		this.m_NowTargetEffect.SetActive(num > 1);
    //	}

    public void Initialize()
    {
        this.InitBattleGroup();
        //this.InitFightMusic();
        this.InitFightEffect();
        this.InitFightPosition();
        this.InitFightCamera();
        this.CreateCharacters();
        this.InitFightSetting();
        ////UI_GameGMFightStatistics.Instance.InitRole(this.m_PlayerList);//统计数据
        //this.PlayAppearCameraPath();
        //this.InitFightTalk();
        //NextWave();
        NewTurn();
    }

    /// <summary>
    /// 初始化战斗组
    /// </summary>
    private void InitBattleGroup()
    {
        this.m_BattleGroupGUID = FightSystem.Instance.m_BattleGroupID;
        this.m_BattleGroup = GameDataDB.BattleGroupDB.GetData(this.m_BattleGroupGUID);
    }

    //	private void InitFightMusic()
    //	{
    //		if (this.m_BattleGroup == null)
    //		{
    //			return;
    //		}
    //		MusicSystem.Instance.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
    //		S_MusicData data = GameDataDB.MusicDB.GetData(this.m_BattleGroup.FightMusic);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		AudioClip music = ResourceManager.Instance.GetMusic(data.MusicName);
    //		if (music == null)
    //		{
    //			return;
    //		}
    //		MusicSystem.Instance.PlayBackgroundMusic(music, 1f, true);
    //	}

    /// <summary>
    /// 初始化战争特效
    /// </summary>
    private void InitFightEffect()
    {
        GameEntry.Pool.GameObjectSpawn(1001, (Transform trans2) =>
        {
            m_NowControlledEffect = trans2.gameObject;
            m_NowControlledEffect.SetActive(false);
        });

        GameEntry.Pool.GameObjectSpawn(1002, (Transform trans2) =>
        {
            m_NowTargetEffect = trans2.gameObject;
            m_NowTargetEffect.SetActive(false);
        });

        //this.m_GuardMobEffect.Clear();
        //for (int i = 1; i <= 2; i++)
        //{
        //    GameObject effect_Fight = ResourcesManager.Instance.GetEffect_Fight("select_escort");
        //    this.m_GuardMobEffect.Add(i, effect_Fight);
        //    effect_Fight.SetActive(false);
        //}
    }

    /// <summary>
    /// 初始化战斗位置
    /// </summary>
    private void InitFightPosition()
    {
        this.m_FightPosition = ResourcesManager.Instance.GetFightObject("FightPosition");
        GameObject gameObject = GameObject.Find(this.m_BattleGroup.BattleCenterPoint);
        if (gameObject != null)
        {
            this.m_FightPosition.transform.position = gameObject.transform.position + new Vector3(0f, 0.05f, 0f);
            this.m_FightPosition.transform.rotation = gameObject.transform.rotation;
            this.m_BattlePoint = gameObject.transform;
        }      

        for (int i = 1; i <= 8; i++)
        {
            string name = "T" + i;
            Transform transform = TransformTool.FindChild(this.m_FightPosition.transform, name);
            if (transform != null)
            {
                this.m_MobIdlePoint.Add(transform);
            }
        }
    }

    /// <summary>
    /// 初始化战斗摄像机
    /// </summary>
    private void InitFightCamera()
    {
        M_PlayerMouseOrbit PlayerMouseOrbit = GameEntry.Instance.m_MainCamera.GetComponent<M_PlayerMouseOrbit>();
        if (PlayerMouseOrbit != null)
        {
            GameObject.Destroy(PlayerMouseOrbit);
        }

        M_FightCameraController_Black FightCameraController_BlackrMouseOrbit = GameEntry.Instance.m_MainCamera.GetComponent<M_FightCameraController_Black>();
        if (FightCameraController_BlackrMouseOrbit == null)
        {
            FightCameraController_BlackrMouseOrbit=GameEntry.Instance.m_MainCamera.gameObject.AddComponent<M_FightCameraController_Black>();
            FightCameraController_BlackrMouseOrbit.m_FollowSpeed = 5f;
            FightCameraController_BlackrMouseOrbit.m_FollowPos = new Vector3(1.5f,2.5f,-6f);
            FightCameraController_BlackrMouseOrbit.m_RotateSpeed = 10f;
            FightCameraController_BlackrMouseOrbit.m_MouseSpeedX = 0.2f;
        }
        this.m_FightCamera = GameEntry.Instance.m_MainCamera.gameObject;
        this.m_FightCameraController = this.m_FightCamera.GetComponent<M_FightCameraController>();
        if (this.m_FightCameraController == null)
        {
            this.m_FightCameraController = this.m_FightCamera.AddComponent<M_FightCameraController>();
        }
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    public void CreateCharacters()
    {
        this.CreatePlayer();
        //this.CreateGuards();
        this.CreateMobs();
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    private void CreatePlayer()
    {
        this.m_ControlledRoleID = -1;
        this.m_MainPlayer = null;
        string text = string.Empty;
        FormationData defaultFormationData = GameEntry.Instance.m_FormationSystem.GetDefaultFormationData();
        List<int> list = new List<int>();
        for (int i = 0; i < defaultFormationData.Unit.Count; i++)
        {
            if (defaultFormationData.Unit[i].RoleID > 0)
            {
                list.Add(defaultFormationData.Unit[i].RoleID);
            }
        }
        list.Sort();
        this.m_PlayerList.Clear();
        GameObject gameObject=null;
        for (int j = 0; j < list.Count; j++)
        {
            int num = list[j];
            if (num > 0)
            {
                if (!this.m_PlayerList.ContainsKey(num))
                {
                    if (GameEntry.Instance.m_GameDataSystem.GetFlag(num))
                    {
                        text = "Player" + num.ToString();
                        GameEntry.Pool.GameObjectSpawn(1, (Transform trans2) =>
                        {
                            gameObject = trans2.gameObject;
                        });

                        M_Player m_Player = gameObject.AddComponent<M_Player>();
                        m_Player.m_ModelName = text;
                        this.m_PlayerList.Add(num, m_Player);
                        this.PlayerList.Add(m_Player);
                        m_Player.m_FightPosition = this.m_FightPosition;
                        m_Player.m_FightSceneMgr = this;
                        m_Player.IsPlayerCharacter = true;
                        m_Player.InitRole(num);
                        // ItemData equipItemData = m_Player.m_RoleDataEx.GetEquipItemData(ENUM_EquipPosition.Weapon);
                        // if (equipItemData != null)
                        // {
                        //     S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
                        //     if (data != null)
                        //     {
                        //         int num2 = (int)m_Player.m_RoleDataEx.BaseRoleData.emWeaponElemntType;
                        //         num2 = ((num2 > 0) ? num2 : 0);
                        //         //GameObject weapon = AvatarTool.GetWeapon(gameObject, data.Equip.WeaponModelName, data.Equip.WeaponModelPoint, data.Equip.WeaponTrail[num2]);
                        //         //M_WeaponTrail[] componentsInChildren = weapon.GetComponentsInChildren<M_WeaponTrail>();
                        //         //if (componentsInChildren != null)
                        //         //{
                        //         //    for (int k = 0; k < componentsInChildren.Length; k++)
                        //         //    {
                        //         //        componentsInChildren[k].Emit = false;
                        //         //    }
                        //         //}
                        //     }
                        // }
                        //TransformTool.SetLayerRecursively(m_Player.m_ModelTransform, 18);//设置层级
                        FightUIForm.CreateRoleSlots(m_Player);
                    }
                }
            }
        }
    }

    private void CreateGuards()
    {
        //List<S_MobGuard> mobGuardData = Swd6Application.instance.m_MobGuardSystem.GetMobGuardData();
        //int num = 1;
        //if (this.m_BattleGroupGUID == 7005)
        //{
        //    M_Guard x = this.CreateGuard(3116, num);
        //    if (x == null)
        //    {
        //        UnityEngine.Debug.Log("Create guard == null, ID:3116");
        //    }
        //    num++;
        //}
        //for (int i = 0; i < mobGuardData.Count; i++)
        //{
        //    if (num == 3)
        //    {
        //        break;
        //    }
        //    if (mobGuardData[i].ID > 0)
        //    {
        //        M_Guard x2 = this.CreateGuard(mobGuardData[i].ID, num);
        //        if (x2 == null)
        //        {
        //            UnityEngine.Debug.Log("Create guard == null, ID:" + mobGuardData[i].ID);
        //        }
        //        else
        //        {
        //            num++;
        //            this.m_GuardIdx = i;
        //        }
        //    }
        //}
    }

    //	public M_Guard CreateGuard(int mobGUID, int posID)
    //	{
    //		string text = "GuardStart" + posID;
    //		Transform transform = TransformTool.FindChild(this.m_FightPosition.transform, text);
    //		if (transform == null)
    //		{
    //			UnityEngine.Debug.Log("cant find fihgtPosition, posName:" + text);
    //			return null;
    //		}
    //		S_Item data = GameDataDB.ItemDB.GetData(mobGUID);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.Log("cant find S_Item data, ID:" + mobGUID);
    //			return null;
    //		}
    //		if (data.emItemType != ENUM_ItemType.Mob)
    //		{
    //			return null;
    //		}
    //		string prefName = data.MobData.PrefName;
    //		GameObject characterModel_Fight = ResourceManager.Instance.GetCharacterModel_Fight(prefName);
    //		if (characterModel_Fight == null)
    //		{
    //			UnityEngine.Debug.LogWarning("cat load model:" + prefName);
    //			return null;
    //		}
    //		RendererTool.ChangeSenceMaterialSetting(prefName, characterModel_Fight);
    //		M_Guard m_Guard = characterModel_Fight.AddComponent<M_Guard>();
    //		string name = prefName;
    //		if (data.MobData.emType != ENUM_MobType.Boss)
    //		{
    //			string[] array = prefName.Split(new char[]
    //			{
    //				'-'
    //			});
    //			name = array[0];
    //		}
    //		RuntimeAnimatorController animatorController_Fight = ResourceManager.Instance.GetAnimatorController_Fight(name);
    //		if (animatorController_Fight != null)
    //		{
    //			Animator component = characterModel_Fight.GetComponent<Animator>();
    //			if (component != null)
    //			{
    //				component.runtimeAnimatorController = animatorController_Fight;
    //			}
    //		}
    //		characterModel_Fight.transform.position = transform.position;
    //		characterModel_Fight.transform.rotation = transform.rotation;
    //		m_Guard.m_DebutPosID = posID;
    //		this.m_GuardSerialID++;
    //		this.m_GuardList.Add(this.m_GuardSerialID, m_Guard);
    //		m_Guard.InitGuard(mobGUID);
    //		m_Guard.m_FightPosition = this.m_FightPosition;
    //		m_Guard.m_FightSceneMgr = this;
    //		m_Guard.m_ModelName = prefName;
    //		m_Guard.m_GuardSerialID = this.m_GuardSerialID;
    //		if (this.m_GuardMobEffect.ContainsKey(posID))
    //		{
    //			this.m_GuardMobEffect[posID].transform.position = m_Guard.GetModelPosition();
    //			this.m_GuardMobEffect[posID].transform.rotation = m_Guard.m_ModelTransform.rotation;
    //			this.m_GuardMobEffect[posID].transform.parent = m_Guard.m_ModelTransform;
    //		}
    //		else
    //		{
    //			UnityEngine.Debug.Log("Cant find GuardMobEffect, keyPosID:" + posID);
    //		}
    //		TransformTool.SetLayerRecursively(m_Guard.m_ModelTransform, 18);
    //		return m_Guard;
    //	}

    /// <summary>
    /// 创建怪物
    /// </summary>
    private void CreateMobs()
    {
        int num = -1;
        for (int i = 0; i < this.m_BattleGroup.BattleMob.Count; i++)
        {
            S_BattleMobData s_BattleMobData = this.m_BattleGroup.BattleMob[i];
            if (s_BattleMobData != null)
            {        
                M_Mob m_Mob = this.CreateMob(s_BattleMobData);
                FightUIForm.CreateMobSlots(m_Mob);
                m_Mob.IsPlayerCharacter = false;
                if (m_Mob == null)
                {
                    UnityEngine.Debug.Log("Create mob == null, ID:" + this.m_BattleGroup.BattleMob[i].GUID);
                }
                else
                {
                    this.m_MobRewardList.Add(m_Mob);
                    if (num <= 0)
                    {
                        num = m_Mob.m_MobSerialID;
                    }
                    //for (int j = 0; j < m_Mob.m_MobData.DropItem.Count; j++)
                    //{
                    //    S_DropItem s_DropItem = m_Mob.m_MobData.DropItem[j];
                    //    if (s_DropItem == null)
                    //    {
                    //        UnityEngine.Debug.Log("無掉落品資訊");
                    //    }
                    //    else if ((this.m_BattleGroupGUID < 7001 || this.m_BattleGroupGUID > 7200) && FightSystem.Instance.m_FightPlayerID == 2 && s_DropItem.Rate == 0)
                    //    {
                    //        if (this.m_BonusDropItemList.ContainsKey(s_DropItem.ID))
                    //        {
                    //            Dictionary<int, int> bonusDropItemList;
                    //            Dictionary<int, int> expr_124 = bonusDropItemList = this.m_BonusDropItemList;
                    //            int num2;
                    //            int expr_12E = num2 = s_DropItem.ID;
                    //            num2 = bonusDropItemList[num2];
                    //            expr_124[expr_12E] = num2 + s_DropItem.Count;
                    //        }
                    //        else
                    //        {
                    //            this.m_BonusDropItemList.Add(s_DropItem.ID, s_DropItem.Count);
                    //        }
                    //    }
                    //}
                }
                if (num > 0)
                {
                    this.ChangeTargetMob(num);
                }
            }
        }
    }

    //	public void SummonMob(int iMobGUID, string strStartPos, string strTargetPos)
    //	{
    //		if (this.m_SummonMobRecordList.ContainsKey(strTargetPos))
    //		{
    //			return;
    //		}
    //		M_Mob m_Mob = this.CreateMob(new S_BattleMobData
    //		{
    //			GUID = iMobGUID,
    //			TargetPosName = strStartPos
    //		});
    //		if (m_Mob == null)
    //		{
    //			UnityEngine.Debug.LogWarning("SummonMob Error");
    //			return;
    //		}
    //		Transform transform = TransformTool.FindChild(this.m_FightPosition.transform, strTargetPos);
    //		if (transform == null)
    //		{
    //			UnityEngine.Debug.Log("cant find fihgtPosition, posName:" + strTargetPos);
    //			return;
    //		}
    //		m_Mob.m_DebutPosStr = strTargetPos;
    //		m_Mob.m_DebutTargetTransform = transform;
    //		if (this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
    //		{
    //			m_Mob.m_ActionTargetModel = this.m_PlayerList[this.m_ControlledRoleID].m_RoleModel;
    //			m_Mob.SetFaceToTarget(this.m_PlayerList[this.m_ControlledRoleID]);
    //		}
    //		this.m_SummonMobRecordList.Add(strTargetPos, m_Mob);
    //		this.EnableFightRole(Enum_FightRoleType.Mob, m_Mob.m_MobSerialID, true);
    //		m_Mob.SetStartUpdate(this.m_IsFightStart);
    //		m_Mob.SetStoryMode(this.m_bIsStoryMode);
    //		m_Mob.SetPause(this.m_bIsPauseMode);
    //		m_Mob.Debut();
    //	}

    public M_Mob CreateMob(S_BattleMobData data)
    {
        if (data == null)
        {
            UnityEngine.Debug.Log("S_BattleMobData == null");
            return null;
        }
        Transform transform = TransformTool.FindChild(this.m_FightPosition.transform, data.TargetPosName);
        if (transform == null)
        {
            UnityEngine.Debug.Log("cant find fihgtPosition, data.TargetPosName:" + data.TargetPosName);
            return null;
        }
        return this.CreateMob(data.GUID, transform.position, transform.rotation);
    }

    /// <summary>
    /// 创建怪物模型
    /// </summary>
    /// <param name="mobGUID"></param>
    /// <param name="pos"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public M_Mob CreateMob(int mobGUID, Vector3 pos, Quaternion rotation)
    {
        S_Item data = GameDataDB.ItemDB.GetData(mobGUID);
        if (data == null)
        {
            UnityEngine.Debug.LogWarning("tmpItem == null, mobGUID:" + mobGUID);
            return null;
        }
        if (data.emItemType != ENUM_ItemType.Mob)
        {
            return null;
        }
        string prefName = data.MobData.PrefName;
        GameObject characterModel_Fight = null;

        GameEntry.Pool.GameObjectSpawn(2, (Transform trans2) =>
        {
            characterModel_Fight = trans2.gameObject;
        });

        if (characterModel_Fight == null)
        {
            UnityEngine.Debug.LogWarning("cat load model:" + prefName);
            return null;
        }
        //RendererTool.ChangeSenceMaterialSetting(prefName, characterModel_Fight);
        M_Mob m_Mob;      
        m_Mob = characterModel_Fight.AddComponent<M_Mob>();
       
        string text = prefName;
        if (data.MobData.emType != ENUM_MobType.Boss)
        {
            string[] array = prefName.Split(new char[]
            {
                    '-'
            });
            text = array[0];
        }
        //添加动画
        //RuntimeAnimatorController animatorController_Fight = ResourcesManager.Instance.GetAnimatorController_Fight(text);
        //if (animatorController_Fight != null)
        //{
        //    Animator component = characterModel_Fight.GetComponent<Animator>();
        //    if (component != null)
        //    {
        //        component.runtimeAnimatorController = animatorController_Fight;
        //    }
        //}
        //else
        //{
        //    UnityEngine.Debug.LogError("找不到contoller:" + data.Name + ", contollerName:" + text);
        //}
        characterModel_Fight.transform.position = pos;
        characterModel_Fight.transform.rotation = rotation;
        this.m_MobSerialID++;
        this.m_MobList.Add(this.m_MobSerialID, m_Mob);
        this.MobList.Add(m_Mob);
        m_Mob.InitMob(mobGUID);
        m_Mob.m_FightPosition = this.m_FightPosition;
        m_Mob.m_FightSceneMgr = this;
        m_Mob.m_ModelName = prefName;
        m_Mob.m_FBXName = text;
        m_Mob.m_MobSerialID = this.m_MobSerialID;
        //TransformTool.SetLayerRecursively(m_Mob.m_ModelTransform, 18);
        return m_Mob;
    }

    /// <summary>
    /// 初始化战斗设置
    /// </summary>
    private void InitFightSetting()
    {
        FormationData defaultFormationData = GameEntry.Instance.m_FormationSystem.GetDefaultFormationData();
        if (defaultFormationData != null)
        {
            this.ChangeFormation(GameEntry.Instance.m_FormationSystem.DefaultFormation);
            int fightPlayerID = GameEntry.Instance.m_GameDataSystem.m_FightPlayerID;
            //if (this.GetRole(fightPlayerID) != null)
            //{
            //    this.ChangeControlCharacter(GameEntry.Instance.m_GameDataSystem.m_FightPlayerID, false);
            //}
            //else
            //{
            //    this.ChangeControlCharacter(1, false);
            //}
            //int flag = 60 + this.m_ControlledRoleID;
            //M_Player role = this.GetRole(this.m_ControlledRoleID);
            ////if (role != null)//设置是否自动战斗
            //{
            //    //role.SetUseAI(Swd6Application.instance.m_GameDataSystem.GetFlag(flag));
            //    //UI_Fight.Instance.UpdateRoleAICheckBox(this.m_ControlledRoleID);
            //}
        }

        this.InitPlayerGuardPos(defaultFormationData);
        this.InitFightTarget();
        this.m_FightCameraController.SetFollower(this.m_PlayerList[1]);
        //for (int i = 0; i < 5; i++)//设置战斗物品
        //{
        //    List<FightItemHotKeyInfo> fightItemHotkeyList = Swd6Application.instance.m_ItemSystem.GetFightItemHotkeyList(i);
        //    for (int j = 0; j < fightItemHotkeyList.Count; j++)
        //    {
        //        if (fightItemHotkeyList[j].AI)
        //        {
        //            this.SetAIFightItems(fightItemHotkeyList[j].ID);
        //        }
        //    }
        //}
        //this.m_AIReviveItems.Sort();
        //this.m_AIHealItems_Single.Sort();
        //this.m_AIHealItems_Single.Reverse();
        //this.m_AIHealItems_All.Sort();
        //this.m_AIHealItems_All.Reverse();
        //this.m_AIRestoreMPItems_Single.Sort();
        //this.m_AIRestoreMPItems_Single.Reverse();
        //this.m_AIRestoreMPItems_All.Sort();
        //this.m_AIRestoreMPItems_All.Reverse();
    }

    //	private void SetAIFightItems(int itemID)
    //	{
    //		if (itemID == 944 || itemID == 945)
    //		{
    //			this.m_AIReviveItems.Add(itemID);
    //		}
    //		if (itemID >= 901 && itemID <= 904)
    //		{
    //			this.m_AIHealItems_Single.Add(itemID);
    //		}
    //		if ((itemID >= 905 && itemID <= 907) || itemID == 941)
    //		{
    //			this.m_AIHealItems_All.Add(itemID);
    //		}
    //		if (itemID >= 921 && itemID <= 924)
    //		{
    //			this.m_AIRestoreMPItems_Single.Add(itemID);
    //		}
    //		if ((itemID >= 925 && itemID <= 927) || itemID == 941)
    //		{
    //			this.m_AIRestoreMPItems_All.Add(itemID);
    //		}
    //		if (itemID == 943)
    //		{
    //			this.m_AIDebuffItems.Add(itemID);
    //		}
    //	}

    private void InitPlayerGuardPos(FormationData fData)
    {
        if (fData == null)
        {
            return;
        }
        if (fData.emElement == ENUM_ElementType.Null || fData.emElement == ENUM_ElementType.Physical)
        {
            UnityEngine.Debug.LogWarning("陣型資料有誤 陣型屬性:" + fData.emElement);
            return;
        }
        string text = "PlayerGroup" + (int)fData.emElement;
        Transform current = TransformTool.FindChild(this.m_FightPosition.transform, "Player");
        current = TransformTool.FindChild(current, text);
        for (int i = 0; i < fData.Unit.Count; i++)
        {
            FormationUnit formationUnit = fData.Unit[i];
            int num = i + 1;
            if (this.m_PlayerList.ContainsKey(formationUnit.RoleID))
            {
                text = "Player" + (int)fData.emElement + num.ToString();
                Transform transform = TransformTool.FindChild(current, text);
                if (transform != null)
                {
                    this.m_PlayerList[formationUnit.RoleID].transform.position = transform.position;
                    this.m_PlayerList[formationUnit.RoleID].transform.rotation = transform.rotation;
                    this.m_PlayerList[formationUnit.RoleID].SetInitPos(transform.position);
                }
                else
                {
                    UnityEngine.Debug.LogWarning("Cant fing pos:" + text);
                }
            }
        }
        //foreach (M_Guard current2 in this.m_GuardList.Values)
        //{
        //    string text2 = "Guard" + (int)fData.emElement + current2.m_DebutPosID.ToString();
        //    Transform transform2 = TransformTool.FindChild(current, text2);
        //    if (transform2 == null)
        //    {
        //        UnityEngine.Debug.Log("cant find fihgtPosition, posName:" + text2);
        //    }
        //    else
        //    {
        //        current2.m_DebutTargetTransform = transform2;
        //    }
        //}
    }

    //	private void FightRoleBuffSetting()
    //	{
    //		if (this.m_BattleGroupGUID >= 7001 && this.m_BattleGroupGUID <= 7200)
    //		{
    //			return;
    //		}
    //		if (FightSystem.Instance.m_FightPlayerID == 1)
    //		{
    //			M_Player role = this.GetRole(1);
    //			foreach (M_Mob current in this.m_MobList.Values)
    //			{
    //				if (current.CanBeTarget())
    //				{
    //					if (current.m_MobData.emType != ENUM_MobType.Boss)
    //					{
    //						this.m_BuffSystem.AddBuff(2001, role, current);
    //					}
    //				}
    //			}
    //		}
    //		if (FightSystem.Instance.m_FightPlayerID == 4)
    //		{
    //			int num = 100 - UnityEngine.Random.Range(3, 8) * 10;
    //			foreach (M_Mob current2 in this.m_MobList.Values)
    //			{
    //				if (current2.CanBeTarget())
    //				{
    //					current2.m_FightRoleData.HP = current2.m_FightRoleData.MaxHP * num / 100;
    //				}
    //			}
    //		}
    //	}

    //	public void ClearFightObjs()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (!(current == null))
    //			{
    //				current.StopAllCoroutines();
    //				UnityEngine.Object.DestroyImmediate(current.m_RoleModel);
    //			}
    //		}
    //		this.m_PlayerList.Clear();
    //		foreach (M_Guard current2 in this.m_GuardList.Values)
    //		{
    //			if (!(current2 == null))
    //			{
    //				current2.StopAllCoroutines();
    //				UnityEngine.Object.DestroyImmediate(current2.m_RoleModel);
    //			}
    //		}
    //		this.m_GuardList.Clear();
    //		foreach (M_Mob current3 in this.m_MobList.Values)
    //		{
    //			if (!(current3 == null))
    //			{
    //				current3.StopAllCoroutines();
    //				UnityEngine.Object.DestroyImmediate(current3.m_RoleModel);
    //			}
    //		}
    //		this.m_MobList.Clear();
    //		UnityEngine.Object.DestroyImmediate(this.m_CatchMobPet.m_RoleModel);
    //		this.m_CatchMobList.Clear();
    //		UnityEngine.Object.Destroy(this.m_FightPosition);
    //		UnityEngine.Object.Destroy(this.m_FightCamera);
    //		UnityEngine.Object.Destroy(this.m_LevelUpCamPath);
    //		foreach (GameObject current4 in this.m_GuardMobEffect.Values)
    //		{
    //			UnityEngine.Object.DestroyImmediate(current4);
    //		}
    //		this.m_GuardMobEffect.Clear();
    //	}

    //	public void FinishFight(bool bWin)
    //	{
    //		UI_GameGMFightStatistics.Instance.CountAverage(this.m_FightTotalTime);
    //		if (this.m_BattleGroupGUID == 7040 && bWin)
    //		{
    //			FightSystem.Instance.FightEnd();
    //			return;
    //		}
    //		UI_FinishFight.Instance.SetResult(bWin);
    //		UI_FinishFight.Instance.Show();
    //	}

    public bool AddPlayerSkillCommand(int skillId, M_Character target)
    {
        return this.m_PlayerList.ContainsKey(this.m_ControlledRoleID) && this.m_PlayerList[this.m_ControlledRoleID].AddSkillCommand(skillId, target);
    }

    //	public bool AddPlayerItemCommand(int itemID, M_Character target)
    //	{
    //		return this.m_PlayerList.ContainsKey(this.m_ControlledRoleID) && this.m_PlayerList[this.m_ControlledRoleID].AddItemCommand_UI(itemID, target);
    //	}

    //	public float GetControlledPlayerGCD()
    //	{
    //		if (this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
    //		{
    //			return this.m_PlayerList[this.m_ControlledRoleID].GetActionCD();
    //		}
    //		return -1f;
    //	}

    //	public float GetControlledPlayerGCDTimer()
    //	{
    //		if (this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
    //		{
    //			return this.m_PlayerList[this.m_ControlledRoleID].m_ActionCDTimer;
    //		}
    //		return -1f;
    //	}

    public List<FightSkillHotKeyInfo> GetControlledPlayerSkillList(int page)
    {
        if (!this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
        {
            return null;
        }
        return GameEntry.Instance.m_SkillSystem.GetFightSkillHotkeyList(this.m_PlayerList[this.m_ControlledRoleID].m_RoleID, page);
    }

    //	public int[] GetControlledPlayerCommandQueue()
    //	{
    //		if (this.m_PlayerList == null)
    //		{
    //			UnityEngine.Debug.Log("m_PlayerList == null");
    //			return null;
    //		}
    //		if (!this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
    //		{
    //			UnityEngine.Debug.Log("m_PlayerList.ContainsKey(m_ControlledKeyID) == false, m_ControlledKeyID:" + this.m_ControlledRoleID);
    //			return null;
    //		}
    //		if (this.m_PlayerList[this.m_ControlledRoleID] == null)
    //		{
    //			UnityEngine.Debug.Log("=== m_PlayerList[m_ControlledKeyID] == null ====");
    //			return null;
    //		}
    //		return this.m_PlayerList[this.m_ControlledRoleID].GetCommandQueue();
    //	}

    //	private void GetCanBeTargetList(List<M_Character> targetList, bool bIsMob, bool bRevive)
    //	{
    //		if (bIsMob)
    //		{
    //			foreach (M_Mob current in this.m_MobList.Values)
    //			{
    //				if (bRevive)
    //				{
    //					if (current.IsDead())
    //					{
    //						targetList.Add(current);
    //					}
    //				}
    //				else if (current.CanBeTarget())
    //				{
    //					targetList.Add(current);
    //				}
    //			}
    //		}
    //		else
    //		{
    //			foreach (M_Player current2 in this.m_PlayerList.Values)
    //			{
    //				if (bRevive)
    //				{
    //					if (current2.IsDead())
    //					{
    //						targetList.Add(current2);
    //					}
    //				}
    //				else if (!current2.IsDead())
    //				{
    //					targetList.Add(current2);
    //				}
    //			}
    //			foreach (M_Guard current3 in this.m_GuardList.Values)
    //			{
    //				if (bRevive)
    //				{
    //					break;
    //				}
    //				if (!current3.IsDead())
    //				{
    //					targetList.Add(current3);
    //				}
    //			}
    //		}
    //	}

    //	public List<M_Character> GetAllTargetCharacterList(S_UseEffect tmpUseEffect, M_Character actor)
    //	{
    //		if (tmpUseEffect == null)
    //		{
    //			return null;
    //		}
    //		ENUM_UseTarget emTarget = tmpUseEffect.emTarget;
    //		List<M_Character> list = new List<M_Character>();
    //		if (actor == null)
    //		{
    //			return list;
    //		}
    //		if (((actor is M_Player || actor is M_Guard) && emTarget == ENUM_UseTarget.Partner) || (actor is M_Mob && emTarget == ENUM_UseTarget.Enemy))
    //		{
    //			if (actor.IsLoseHeart())
    //			{
    //				this.GetCanBeTargetList(list, true, tmpUseEffect.DeBuffer.Contains(84));
    //			}
    //			else
    //			{
    //				this.GetCanBeTargetList(list, false, tmpUseEffect.DeBuffer.Contains(84));
    //			}
    //		}
    //		if (((actor is M_Player || actor is M_Guard) && emTarget == ENUM_UseTarget.Enemy) || (actor is M_Mob && emTarget == ENUM_UseTarget.Partner))
    //		{
    //			if (actor.IsLoseHeart())
    //			{
    //				this.GetCanBeTargetList(list, false, tmpUseEffect.DeBuffer.Contains(84));
    //			}
    //			else
    //			{
    //				this.GetCanBeTargetList(list, true, tmpUseEffect.DeBuffer.Contains(84));
    //			}
    //		}
    //		return list;
    //	}

    //	public M_Character GetCharacter(Enum_FightRoleType emType, int id)
    //	{
    //		switch (emType)
    //		{
    //		case Enum_FightRoleType.Player:
    //			if (this.m_PlayerList.ContainsKey(id))
    //			{
    //				return this.m_PlayerList[id];
    //			}
    //			break;
    //		case Enum_FightRoleType.Mob:
    //			if (this.m_MobList.ContainsKey(id))
    //			{
    //				return this.m_MobList[id];
    //			}
    //			break;
    //		case Enum_FightRoleType.Guard:
    //			return this.GetAliveGuard(id);
    //		}
    //		return null;
    //	}

    //	public int GetRandomTargetID(Enum_FightRoleType emType)
    //	{
    //		List<int> list = null;
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				list = this.GetAliveMobIDList();
    //			}
    //		}
    //		else
    //		{
    //			list = this.GetAliveRoleIDList();
    //		}
    //		if (list == null || list.Count == 0)
    //		{
    //			return -1;
    //		}
    //		int index = UnityEngine.Random.Range(0, list.Count);
    //		return list[index];
    //	}

    //	public int GetRoleLevel(Enum_FightRoleType emType, int id)
    //	{
    //		int result = 0;
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					result = this.m_MobList[id].m_FightRoleData.Level;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			result = this.m_PlayerList[id].m_FightRoleData.Level;
    //		}
    //		return result;
    //	}

    //	public int GetRoleHP(Enum_FightRoleType emType, int id)
    //	{
    //		int result = 0;
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					result = this.m_MobList[id].m_FightRoleData.HP;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			result = this.m_PlayerList[id].m_FightRoleData.HP;
    //		}
    //		return result;
    //	}

    //	public float GetRoleHP_Percentage(Enum_FightRoleType emType, int id)
    //	{
    //		float num = 0f;
    //		float num2 = 0f;
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					num = (float)this.m_MobList[id].m_FightRoleData.HP;
    //					num2 = (float)this.m_MobList[id].m_FightRoleData.MaxHP;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			num = (float)this.m_PlayerList[id].m_FightRoleData.HP;
    //			num2 = (float)this.m_PlayerList[id].m_FightRoleData.MaxHP;
    //		}
    //		if (num2 == 0f)
    //		{
    //			return 0f;
    //		}
    //		return num / num2;
    //	}

    //	public int GetRoleMP(Enum_FightRoleType emType, int id)
    //	{
    //		int result = 0;
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					result = this.m_MobList[id].m_FightRoleData.MP;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			result = this.m_PlayerList[id].m_FightRoleData.MP;
    //		}
    //		return result;
    //	}

    //	public void SetRoleHP(Enum_FightRoleType emType, int id, int hp)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].SetRoleHP(hp);
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].SetRoleHP(hp);
    //		}
    //	}

    //	public void SetRoleHP_Percentage(Enum_FightRoleType emType, int id, float percentage)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					float num = (float)this.m_MobList[id].m_FightRoleData.MaxHP * Mathf.Clamp01(percentage);
    //					this.m_MobList[id].m_FightRoleData.HP = (int)num;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			float num = (float)this.m_PlayerList[id].m_FightRoleData.MaxHP * Mathf.Clamp01(percentage);
    //			this.m_PlayerList[id].m_FightRoleData.HP = (int)num;
    //		}
    //	}

    //	public void SetRoleMP(Enum_FightRoleType emType, int id, int mp)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].SetRoleMP(mp);
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].SetRoleMP(mp);
    //		}
    //	}

    //	public void SetRoleDead(Enum_FightRoleType emType, int id)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].Dead();
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].Dead();
    //		}
    //	}

    //	public void PlayRoleAnimation(Enum_FightRoleType emType, int id, string name, bool bCrossFade)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					if (bCrossFade)
    //					{
    //						this.m_MobList[id].PlayAnimation(name);
    //					}
    //					else
    //					{
    //						this.m_MobList[id].PlayAnimationImmediately(name);
    //					}
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			if (bCrossFade)
    //			{
    //				this.m_PlayerList[id].PlayAnimation(name);
    //			}
    //			else
    //			{
    //				this.m_PlayerList[id].PlayAnimationImmediately(name);
    //			}
    //		}
    //	}

    //	public bool IsFightRoleExist(Enum_FightRoleType emType, int id)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					return true;
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			return true;
    //		}
    //		UnityEngine.Debug.Log(string.Concat(new object[]
    //		{
    //			"沒有指定角色 emType:",
    //			emType,
    //			" id:",
    //			id
    //		}));
    //		return false;
    //	}

    //	public bool IsFightRoleDead(Enum_FightRoleType emType, int id)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					return this.m_MobList[id].IsDead();
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			return this.m_PlayerList[id].IsDead();
    //		}
    //		UnityEngine.Debug.Log(string.Concat(new object[]
    //		{
    //			"沒有指定角色 emType:",
    //			emType,
    //			" id:",
    //			id
    //		}));
    //		return false;
    //	}

    //	public bool IsFightRoleNowAnimationFinish(Enum_FightRoleType emType, int id)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					return this.m_MobList[id].IsNowAnimationFinish();
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			return this.m_PlayerList[id].IsNowAnimationFinish();
    //		}
    //		UnityEngine.Debug.Log(string.Concat(new object[]
    //		{
    //			"沒有指定角色 emType:",
    //			emType,
    //			" id:",
    //			id
    //		}));
    //		return false;
    //	}

    //	public void FightRoleUseSkillCommand(Enum_FightRoleType emType, int id, int skillID)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].ResetStateToIdle();
    //					this.m_MobList[id].ClearCommand();
    //					FightCommand_EndCallSkill skillCommand = new FightCommand_EndCallSkill(this.m_MobList[id], this.m_MobList[id].ChooseTarget_AI(skillID), skillID);
    //					this.m_MobList[id].DoCommand(skillCommand);
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].ResetStateToIdle();
    //			this.m_PlayerList[id].ClearCommand();
    //			FightCommand_EndCallSkill skillCommand = new FightCommand_EndCallSkill(this.m_PlayerList[id], this.m_PlayerList[id].ChooseTarget_AI(skillID), skillID);
    //			this.m_PlayerList[id].DoCommand(skillCommand);
    //		}
    //	}

    //	public void EnableFightRole(Enum_FightRoleType emType, int id, bool bEnable)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].m_RoleModel.SetActive(bEnable);
    //					this.OnMobEnableUpdate(this.m_MobList[id], bEnable);
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].m_RoleModel.SetActive(bEnable);
    //			this.CheckSelectRole();
    //			UI_Fight.Instance.UpdateSelectRole();
    //		}
    //	}

    //	public Vector3 GetNearestMobIdlePos(Vector3 pos)
    //	{
    //		Transform transform = null;
    //		float num = 0f;
    //		for (int i = 0; i < this.m_MobIdlePoint.Count; i++)
    //		{
    //			float num2 = Vector3.Distance(this.m_MobIdlePoint[i].position, pos);
    //			if (transform == null)
    //			{
    //				num = num2;
    //				transform = this.m_MobIdlePoint[i];
    //			}
    //			else if (num2 < num)
    //			{
    //				num = num2;
    //				transform = this.m_MobIdlePoint[i];
    //			}
    //		}
    //		return transform.position;
    //	}

    //	public int GetNowFormationIdx()
    //	{
    //		return this.m_NowFormationIdx;
    //	}

    //	public Dictionary<M_Player, int> GetAllPlayerScore()
    //	{
    //		Dictionary<M_Player, int> dictionary = new Dictionary<M_Player, int>();
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			int beingTargetScore = current.GetBeingTargetScore();
    //			if (beingTargetScore > 0)
    //			{
    //				dictionary.Add(current, beingTargetScore);
    //			}
    //		}
    //		return dictionary;
    //	}

    //	public Dictionary<M_Mob, int> GetAllMobScore()
    //	{
    //		Dictionary<M_Mob, int> dictionary = new Dictionary<M_Mob, int>();
    //		int num = 0;
    //		foreach (M_Mob current in this.m_MobList.Values)
    //		{
    //			if (!current.IsDead() && current.m_RoleModel.activeSelf)
    //			{
    //				if (!current.GetBeCatchState())
    //				{
    //					if (current.CanBeTarget())
    //					{
    //						num++;
    //					}
    //				}
    //			}
    //		}
    //		int num2 = 60;
    //		M_Mob prevAtkMob = this.GetControlledPlayer().GetPrevAtkMob();
    //		if (prevAtkMob != null && prevAtkMob.CanBeTarget() && !prevAtkMob.GetBeCatchState())
    //		{
    //			dictionary.Add(prevAtkMob, num2);
    //			num--;
    //		}
    //		if (num > 0)
    //		{
    //			int value = (100 - num2) / num;
    //			foreach (M_Mob current2 in this.m_MobList.Values)
    //			{
    //				if (!current2.IsDead() && current2.m_RoleModel.activeSelf)
    //				{
    //					if (!current2.GetBeCatchState())
    //					{
    //						if (!(current2 == prevAtkMob))
    //						{
    //							if (current2.CanBeTarget())
    //							{
    //								dictionary.Add(current2, value);
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return dictionary;
    //	}

    //	public Dictionary<int, M_Player> GetRoleList()
    //	{
    //		return this.m_PlayerList;
    //	}

    public M_Player GetRole(int roleID)
    {
        if (this.m_PlayerList.ContainsKey(roleID))
        {
            return this.m_PlayerList[roleID];
        }
        return null;
    }

    //	public List<int> GetAliveRoleIDList()
    //	{
    //		List<int> list = new List<int>();
    //		foreach (KeyValuePair<int, M_Player> current in this.m_PlayerList)
    //		{
    //			if (!(current.Value == null))
    //			{
    //				if (!current.Value.IsDead() && current.Value.m_RoleModel.activeSelf)
    //				{
    //					list.Add(current.Key);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	public Dictionary<int, M_Mob> GetMobList()
    //	{
    //		return this.m_MobList;
    //	}

    //	public int GetAliveMobCount()
    //	{
    //		return this.GetAliveMobIDList().Count;
    //	}

    //	public List<int> GetAliveMobIDList()
    //	{
    //		List<int> list = new List<int>();
    //		foreach (KeyValuePair<int, M_Mob> current in this.m_MobList)
    //		{
    //			if (!(current.Value == null))
    //			{
    //				if (!current.Value.IsDead() && current.Value.CanBeTarget())
    //				{
    //					if (current.Value.m_RoleModel.activeSelf)
    //					{
    //						list.Add(current.Key);
    //					}
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	public M_Mob GetMob(int seiralID)
    //	{
    //		if (this.m_MobList.ContainsKey(seiralID))
    //		{
    //			return this.m_MobList[seiralID];
    //		}
    //		return null;
    //	}

    //	public List<M_Mob> GetAliveSummonMobList()
    //	{
    //		List<M_Mob> list = new List<M_Mob>();
    //		foreach (KeyValuePair<string, M_Mob> current in this.m_SummonMobRecordList)
    //		{
    //			list.Add(current.Value);
    //		}
    //		return list;
    //	}

    //	public Dictionary<int, M_Guard> GetGuardList()
    //	{
    //		return this.m_GuardList;
    //	}

    /// <summary>
    /// 改变控制角色
    /// </summary>
    /// <param name="key"></param>
    /// <param name="bDead"></param>
    public void ChangeControlCharacter(int key, bool bDead)
    {
        //M_Player role = this.GetRole(key);
        //if (role == null || role.IsDead())
        //{
        //    return;
        //}
        foreach (KeyValuePair<int, M_Player> current in this.m_PlayerList)
        {
            if (current.Key == key)
            {
                current.Value.SetIsControlCharacter(true);
            }
            else
            {
                current.Value.SetIsControlCharacter(false);
            }
        }
        this.m_NowControlledEffect.transform.position = this.m_PlayerList[key].GetModelPosition();
        this.m_NowControlledEffect.transform.rotation = this.m_PlayerList[key].m_ModelTransform.rotation;

        if (this.m_ControlledRoleID == key)
        {
            return;
        }
        //bool useAI = false;
        //if (bDead)
        //{
        //    //useAI = this.GetControlledPlayer().m_bUseAI;
        //}
        this.m_ControlledRoleID = key;
        if (this.m_PlayerList.ContainsKey(key))
        {
            this.m_MainPlayer = this.m_PlayerList[key];
        }
        else
        {
            this.m_MainPlayer = null;
        }
        //this.SetFightCameraController();
        FightUIForm.UpdateSelectRole();
        //foreach (KeyValuePair<int, M_Player> current2 in this.m_PlayerList)
        //{
        //    if (current2.Key == key)
        //    {
        //        //current2.Value.SetUseAI(useAI);
        //    }
        //    else
        //    {
        //        //current2.Value.SetUseAI(true);
        //    }
        //    //UI_Fight.Instance.UpdateRoleAICheckBox(current2.Key);
        //}
    }

    public bool ChangeTargetMob(int key)
    {
        //if (!this.m_MobList.ContainsKey(key))
        //{
        //    return false;
        //}
        //if (this.m_MobList[key].IsDead())
        //{
        //    return false;
        //}
        //if (!this.m_MobList[key].m_RoleModel.activeSelf)
        //{
        //    return false;
        //}
        this.m_MainTarget = this.m_MobList[key];
        this.m_TargetMobKeyID = key;
        //this.m_NowTargetEffect.transform.position = this.m_MainTarget.GetModelPosition();
        //this.m_NowTargetEffect.transform.rotation = this.m_MainTarget.m_ModelTransform.rotation;
        //this.m_NowTargetEffect.transform.parent = this.m_MainTarget.m_ModelTransform;
        //UI_Fight.Instance.SetTargetMob(this.m_MainTarget);
        return true;
    }

    //	public FormationData GetNowFormation()
    //	{
    //		return this.m_NowFormation;
    //	}

    /// <summary>
    /// 改变阵型
    /// </summary>
    /// <param name="idx"></param>
    public void ChangeFormation(int idx)
    {
        if (this.m_ChangeFormationCDTimer > 0f)
        {
            return;
        }
        FormationData formationData = GameEntry.Instance.m_FormationSystem.GetFormationData(idx);
        if (formationData == null)
        {
            UnityEngine.Debug.LogWarning("FormationData == null");
            return;
        }
        this.m_NowFormationIdx = idx;
        this.m_NowFormation = formationData;
        for (int i = 0; i < formationData.Unit.Count; i++)
        {
            FormationUnit formationUnit = formationData.Unit[i];
            if (formationUnit != null)
            {
                if (this.m_PlayerList.ContainsKey(formationUnit.RoleID))
                {
                    if (GameEntry.Instance.m_GameDataSystem.GetFlag(formationUnit.RoleID))
                    {
                        this.m_PlayerList[formationUnit.RoleID].SetFormationData(formationData, i);
                    }
                }
            }
        }
        foreach (M_Player current in this.m_PlayerList.Values)
        {
            current.UpdateFightRoleData();
        }
        this.ChangeInitPos(formationData);
        //this.CreateChangeFormationEffect(idx + ENUM_ElementType.Wind);
        this.m_ChangeFormationCDTimer = 10f;
        GameEntry.Instance.m_FormationSystem.DefaultFormation = idx;
        this.ChangeFormationCameraPath();
        //UI_Fight.Instance.UpdateNowFormation();
    }

    //	private void CreateChangeFormationEffect(ENUM_ElementType emType)
    //	{
    //		string text = string.Empty;
    //		switch (emType)
    //		{
    //		case ENUM_ElementType.Wind:
    //			text = "change_wind";
    //			break;
    //		case ENUM_ElementType.Earth:
    //			text = "change_earth";
    //			break;
    //		case ENUM_ElementType.Water:
    //			text = "change_water";
    //			break;
    //		case ENUM_ElementType.Fire:
    //			text = "change_fire";
    //			break;
    //		default:
    //			return;
    //		}
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			EffectSystem.Instance.CreateEffect(current.m_ModelTransform, string.Empty, text, false, true);
    //		}
    //		M_Player controlledPlayer = this.GetControlledPlayer();
    //		if (controlledPlayer != null)
    //		{
    //			text += "_All";
    //			EffectSystem.Instance.CreateEffect(controlledPlayer.m_ModelTransform, string.Empty, text, false, true);
    //		}
    //	}

    private void ChangeInitPos(FormationData fData)
    {
        if (fData == null)
        {
            return;
        }
        if (fData.emElement == ENUM_ElementType.Null || fData.emElement == ENUM_ElementType.Physical)
        {
            UnityEngine.Debug.LogWarning("陣型資料有誤 陣型屬性:" + fData.emElement);
            return;
        }
        string text = "PlayerGroup" + (int)fData.emElement;
        Transform current = TransformTool.FindChild(this.m_FightPosition.transform, "Player");
        current = TransformTool.FindChild(current, text);
        for (int i = 0; i < fData.Unit.Count; i++)
        {
            FormationUnit formationUnit = fData.Unit[i];
            int num = i + 1;
            if (this.m_PlayerList.ContainsKey(formationUnit.RoleID))
            {
                text = "Player" + (int)fData.emElement + num.ToString();
                Transform transform = TransformTool.FindChild(current, text);
                if (transform != null)
                {
                    this.m_PlayerList[formationUnit.RoleID].SetInitPos(transform.position);
                }
                else
                {
                    UnityEngine.Debug.LogWarning("Cant find pos:" + text);
                }
            }
        }
        //foreach (M_Guard current2 in this.m_GuardList.Values)
        //{
        //    string text2 = "Guard" + (int)fData.emElement + current2.m_DebutPosID.ToString();
        //    Transform transform2 = TransformTool.FindChild(current, text2);
        //    if (transform2 == null)
        //    {
        //        UnityEngine.Debug.Log("cant find fihgtPosition, posName:" + text2);
        //    }
        //    else
        //    {
        //        current2.m_DebutTargetTransform = transform2;
        //    }
        //}
    }

    public M_Mob GetMainTarget()
    {
        return this.m_MainTarget;
    }

    public M_Player GetControlledPlayer()
    {
        if (!this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
        {
            return null;
        }
        return this.m_PlayerList[this.m_ControlledRoleID];
    }

    //	public int GetControlledPlayerRoleID()
    //	{
    //		return this.m_ControlledRoleID;
    //	}

    /// <summary>
    /// 初始化战斗目标
    /// </summary>
    public void InitFightTarget()
    {
        foreach (M_Player current in this.m_PlayerList.Values)
        {
            current.m_ActionTargetModel = this.m_MainTarget.m_RoleModel;
            current.SetFaceToTarget(this.m_MainTarget);
        }
        //foreach (M_Guard current2 in this.m_GuardList.Values)
        //{
        //    current2.m_ActionTargetModel = this.m_MainTarget.m_RoleModel;
        //    current2.SetFaceToTarget(this.m_MainTarget);
        //}
        foreach (M_Mob current3 in this.m_MobList.Values)
        {
            if (!this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
            {
                break;
            }
            //if (current3.CanBeTarget())
            //{
            //    current3.m_ActionTargetModel = this.m_PlayerList[this.m_ControlledRoleID].m_RoleModel;
            //    current3.SetFaceToTarget(this.m_PlayerList[this.m_ControlledRoleID]);
            //}
        }
        //foreach (M_Player current4 in this.m_PlayerList.Values)
        //{
        //    current4.CheckPlayerDead();
        //}
    }

    //	public void SetFightRolePause(bool bPause)
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.SetPause(bPause);
    //		}
    //		foreach (M_Guard current2 in this.m_GuardList.Values)
    //		{
    //			current2.SetPause(bPause);
    //		}
    //		foreach (M_Mob current3 in this.m_MobList.Values)
    //		{
    //			current3.SetPause(bPause);
    //		}
    //		this.m_CatchMobPet.SetPause(bPause);
    //	}

    //	private void SetDebutAnimtaion()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.Debut();
    //		}
    //		foreach (M_Guard current2 in this.m_GuardList.Values)
    //		{
    //			current2.Debut();
    //		}
    //		foreach (M_Mob current3 in this.m_MobList.Values)
    //		{
    //			current3.Debut();
    //		}
    //	}

    //	public void SetFightStart(bool bStartUpdate)
    //	{
    //		this.m_IsFightStart = bStartUpdate;
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.SetStartUpdate(bStartUpdate);
    //		}
    //		foreach (M_Guard current2 in this.m_GuardList.Values)
    //		{
    //			current2.SetStartUpdate(bStartUpdate);
    //		}
    //		foreach (M_Mob current3 in this.m_MobList.Values)
    //		{
    //			current3.SetStartUpdate(bStartUpdate);
    //		}
    //		this.m_CatchMobPet.SetStartUpdate(bStartUpdate);
    //		this.FightRoleBuffSetting();
    //		this.m_ChangeFormationCDTimer = 0f;
    //	}

    public void SetPauseMode(bool bEnabled)
    {
        //this.m_bIsPauseMode = bEnabled;
        //M_Player controlledPlayer = this.GetControlledPlayer();
        //if (controlledPlayer != null && controlledPlayer.m_bUseAI && bEnabled && UI_Fight.Instance.IsVisible())
        //{
        //    controlledPlayer.SetUseAI(false);
        //    //UI_Fight.Instance.UpdateRoleAICheckBox(controlledPlayer.m_RoleID);
        //}
        //NormalSettingSystem.Instance.GetNormalSetting().m_bEnableFightStop = this.m_bIsPauseMode;
    }

    //	public void SetStoryMode(bool bStory)
    //	{
    //		this.m_bIsStoryMode = bStory;
    //		UI_Fight.Instance.SetStoryMode(bStory);
    //		if (this.m_FightCameraController)
    //		{
    //			this.m_FightCameraController.SetStoryMode(bStory);
    //		}
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.SetStoryMode(bStory);
    //		}
    //		foreach (M_Guard current2 in this.m_GuardList.Values)
    //		{
    //			current2.SetStoryMode(bStory);
    //		}
    //		foreach (M_Mob current3 in this.m_MobList.Values)
    //		{
    //			current3.SetStoryMode(bStory);
    //		}
    //	}

    //	private void SetFightFinish(bool bWin)
    //	{
    //		if (this.m_FightTalk)
    //		{
    //			this.m_FightTalk.Stop();
    //			UnityEngine.Object.Destroy(this.m_FightTalk.gameObject);
    //		}
    //		this.m_IsFightFinish = true;
    //		this.SetFightRolePause(true);
    //		if (this.m_FightCameraController != null)
    //		{
    //			this.m_FightCameraController.m_CurrentState = M_FightCameraController.Enum_CameraState.Finish;
    //		}
    //		if (this.m_AppearCamPath != null)
    //		{
    //			UnityEngine.Object.Destroy(this.m_AppearCamPath);
    //		}
    //		foreach (M_Mob current in this.m_MobList.Values)
    //		{
    //			current.SetFightFinish();
    //		}
    //		foreach (KeyValuePair<int, M_Player> current2 in this.m_PlayerList)
    //		{
    //			if (bWin)
    //			{
    //				current2.Value.Win();
    //			}
    //			else
    //			{
    //				current2.Value.Lose();
    //			}
    //		}
    //		foreach (M_Guard current3 in this.m_GuardList.Values)
    //		{
    //			current3.SetFightFinish();
    //		}
    //		this.m_CatchMobPet.SetFightFinish();
    //		Swd6Application.instance.SaveSettings(false);
    //		MusicSystem.Instance.Fade_StopBackgroundMusic(3f);
    //	}

    //	public void SetFightResult_Immediately(bool bWin)
    //	{
    //		if (bWin)
    //		{
    //			this.Win();
    //		}
    //		else
    //		{
    //			this.Lose();
    //		}
    //	}

    //	public bool IsAllPlayerDead()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (!current.IsDead() && current.m_RoleModel.activeSelf)
    //			{
    //				return false;
    //			}
    //		}
    //		return true;
    //	}

    //	public bool IsAllMobDead()
    //	{
    //		foreach (M_Mob current in this.m_MobList.Values)
    //		{
    //			if (!current.IsDead())
    //			{
    //				if (!this.m_CatchMobKeyIDList.Contains(current.m_MobSerialID))
    //				{
    //					return false;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public bool IsAllCharacterReady()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (current.m_RoleModel.activeSelf && !current.IsDead())
    //			{
    //				if (!current.IsReady())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		foreach (M_Mob current2 in this.m_MobList.Values)
    //		{
    //			if (current2.m_RoleModel.activeSelf)
    //			{
    //				if (!current2.IsReady())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		foreach (M_Guard current3 in this.m_GuardList.Values)
    //		{
    //			if (current3.m_RoleModel.activeSelf)
    //			{
    //				if (!current3.IsReady())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		return !this.m_CatchMobPet.m_RoleModel.activeSelf || this.m_CatchMobPet.IsReady();
    //	}

    //	public bool IsAllCharacterStandby()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (current.m_RoleModel.activeSelf && !current.IsDead())
    //			{
    //				if (!current.IsStandby())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		foreach (M_Mob current2 in this.m_MobList.Values)
    //		{
    //			if (current2.m_RoleModel.activeSelf)
    //			{
    //				if (!current2.IsStandby())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		foreach (M_Guard current3 in this.m_GuardList.Values)
    //		{
    //			if (current3.m_RoleModel.activeSelf)
    //			{
    //				if (!current3.IsStandby())
    //				{
    //					bool result = false;
    //					return result;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public bool IsAllPlayerStandby()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (current.m_RoleModel.activeSelf)
    //			{
    //				if (!current.IsDead())
    //				{
    //					if (!current.IsStandby())
    //					{
    //						return false;
    //					}
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public bool IsAllPlayerAnimationFinish()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (current.m_RoleModel.activeSelf)
    //			{
    //				if (!current.IsDead())
    //				{
    //					if (!this.IsFightRoleNowAnimationFinish(Enum_FightRoleType.Player, current.m_RoleID))
    //					{
    //						return false;
    //					}
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	public void Win()
    //	{
    //		UI_FinishFight.Instance.Reset();
    //		this.m_bWin = true;
    //		this.SetFightFinish(true);
    //		int num = 0;
    //		int num2 = 0;
    //		Dictionary<int, int> dictionary = new Dictionary<int, int>();
    //		for (int i = 0; i < this.m_MobRewardList.Count; i++)
    //		{
    //			num += this.m_MobRewardList[i].m_MobData.GetExp;
    //			num2 += this.m_MobRewardList[i].m_MobData.GetMoney;
    //			for (int j = 0; j < this.m_MobRewardList[i].m_MobData.DropItem.Count; j++)
    //			{
    //				S_DropItem s_DropItem = this.m_MobRewardList[i].m_MobData.DropItem[j];
    //				if (s_DropItem == null)
    //				{
    //					UnityEngine.Debug.Log("無掉落品資訊");
    //				}
    //				else
    //				{
    //					int num3 = s_DropItem.Rate;
    //					if (s_DropItem.Rate == 0 && FightSystem.Instance.m_FightPlayerID != 2)
    //					{
    //						foreach (KeyValuePair<int, M_Player> current in this.m_PlayerList)
    //						{
    //							ItemData equipMagicItemData = current.Value.GetEquipMagicItemData();
    //							if (equipMagicItemData != null && equipMagicItemData.ID == 730)
    //							{
    //								S_Item data = GameDataDB.ItemDB.GetData(equipMagicItemData.ID);
    //								if (data != null)
    //								{
    //									IdentifyData data2 = Swd6Application.instance.m_IdentifySystem.GetData(equipMagicItemData.ID);
    //									if (data2 != null)
    //									{
    //										if (data2.Level - 1 >= 0 && data2.Level - 1 < data.MItem.AttrEffect.Count)
    //										{
    //											num3 += (int)data.MItem.AttrEffect[data2.Level - 1];
    //										}
    //									}
    //								}
    //							}
    //						}
    //					}
    //					else
    //					{
    //						num3 += this.m_MobRewardList[i].m_BonusDropRate;
    //					}
    //					int num4 = UnityEngine.Random.Range(1, 101);
    //					if (num4 <= num3)
    //					{
    //						if (dictionary.ContainsKey(s_DropItem.ID))
    //						{
    //							Dictionary<int, int> dictionary2;
    //							Dictionary<int, int> expr_1FD = dictionary2 = dictionary;
    //							int num5;
    //							int expr_207 = num5 = s_DropItem.ID;
    //							num5 = dictionary2[num5];
    //							expr_1FD[expr_207] = num5 + s_DropItem.Count;
    //						}
    //						else
    //						{
    //							dictionary.Add(s_DropItem.ID, s_DropItem.Count);
    //						}
    //					}
    //				}
    //			}
    //		}
    //		num2 += this.m_FightTalkMoney;
    //		num += this.m_FightTalkExp;
    //		foreach (KeyValuePair<int, int> current2 in this.m_FightTalkItemList)
    //		{
    //			if (dictionary.ContainsKey(current2.Key))
    //			{
    //				Dictionary<int, int> dictionary3;
    //				Dictionary<int, int> expr_2BE = dictionary3 = dictionary;
    //				int num5;
    //				int expr_2C8 = num5 = current2.Key;
    //				num5 = dictionary3[num5];
    //				expr_2BE[expr_2C8] = num5 + current2.Value;
    //			}
    //			else
    //			{
    //				dictionary.Add(current2.Key, current2.Value);
    //			}
    //		}
    //		UI_FinishFight.Instance.SetReward(num, num2, dictionary, this.m_BonusDropItemList, this.m_CatchMobList);
    //		this.UpdateRoleDataEx();
    //		foreach (M_Player current3 in this.m_PlayerList.Values)
    //		{
    //			if (!current3.IsDead() || !current3.m_RoleModel.activeSelf)
    //			{
    //				S_LevelUpInfo levelUpInfo = new S_LevelUpInfo();
    //				current3.m_bIsLevelUp = Swd6Application.instance.m_GameDataSystem.AddRoleExp(current3.m_RoleID, num, ref levelUpInfo);
    //				if (current3.m_bIsLevelUp)
    //				{
    //					current3.m_AfterLevelUpInfo = new FightLevelUpInfo(current3.m_RoleDataEx);
    //					current3.m_LevelUpInfo = levelUpInfo;
    //					current3.m_bIsLevelUp = true;
    //					UI_FinishFight.Instance.AddLevelUpRole(current3);
    //				}
    //				if (current3.m_MagicItem_Passive != null && current3.m_MagicItem_Passive.m_IdentifyData.Level < 20)
    //				{
    //					Swd6Application.instance.m_IdentifySystem.AddIdentify(current3.m_MagicItem_Passive.m_EquipItem.ID, ENUM_IdentifyType.Talisman, 0f, current3.m_MagicItem_Passive.GetAddExp());
    //				}
    //				if (current3.m_MagicItem_Active != null && current3.m_MagicItem_Active.m_IdentifyData.Level < 20)
    //				{
    //					Swd6Application.instance.m_IdentifySystem.AddIdentify(current3.m_MagicItem_Active.m_EquipItem.ID, ENUM_IdentifyType.Talisman, 0f, current3.m_MagicItem_Active.GetAddExp());
    //				}
    //			}
    //		}
    //		Swd6Application.instance.m_GameDataSystem.Money += num2;
    //		foreach (KeyValuePair<int, int> current4 in this.m_BonusDropItemList)
    //		{
    //			Swd6Application.instance.m_ItemSystem.AddItem(current4.Key, current4.Value, ENUM_ItemState.New, false);
    //		}
    //		foreach (KeyValuePair<int, int> current5 in dictionary)
    //		{
    //			Swd6Application.instance.m_ItemSystem.AddItem(current5.Key, current5.Value, ENUM_ItemState.New, false);
    //		}
    //		foreach (KeyValuePair<int, int> current6 in this.m_CatchMobList)
    //		{
    //			Swd6Application.instance.m_ItemSystem.AddItem(current6.Key, current6.Value, ENUM_ItemState.New, false);
    //		}
    //		Swd6Application.instance.m_QuestSystem.AddWantMobList(this.m_DeadMobList);
    //		for (int k = 0; k < this.m_BattleGroup.BattleMob.Count; k++)
    //		{
    //			Swd6Application.instance.m_IdentifySystem.AddMobIdentify(this.m_BattleGroup.BattleMob[k].GUID, ENUM_MobIdentifyType.Encount);
    //		}
    //		UI_Fight.Instance.Hide();
    //		UI_TalkDialog.Instance.Close();
    //		Swd6Application.instance.m_GameDataSystem.m_FightPlayerID = this.m_ControlledRoleID;
    //		this.RecordPlayerAutoSetting();
    //		Swd6Application.instance.StartCoroutine(this.WaitWinPerformFinish());
    //	}

    //	private void RecordPlayerAutoSetting()
    //	{
    //		foreach (KeyValuePair<int, M_Player> current in this.m_PlayerList)
    //		{
    //			int flag = 60 + current.Key;
    //			if (current.Value.m_bUseAI && this.m_ControlledRoleID == current.Key)
    //			{
    //				Swd6Application.instance.m_GameDataSystem.FlagON(flag);
    //			}
    //			else
    //			{
    //				Swd6Application.instance.m_GameDataSystem.FlagOFF(flag);
    //			}
    //		}
    //	}

    //	public void Lose()
    //	{
    //		Shader shader = Shader.Find("Hidden/Grayscale Effect");
    //		if (shader != null)
    //		{
    //			GrayscaleEffect grayscaleEffect = this.m_FightCamera.AddComponent<GrayscaleEffect>();
    //			grayscaleEffect.shader = shader;
    //		}
    //		UI_FinishFight.Instance.Reset();
    //		this.m_bWin = false;
    //		this.SetFightFinish(false);
    //		UI_Fight.Instance.Hide();
    //		UI_TalkDialog.Instance.Close();
    //		this.FinishFight(false);
    //	}

    //	public void Refight_ReturnUserdItem()
    //	{
    //		if (this.m_UsedItemList == null)
    //		{
    //			return;
    //		}
    //		foreach (KeyValuePair<ItemData, int> current in this.m_UsedItemList)
    //		{
    //			if (current.Key != null)
    //			{
    //				if (current.Key.New)
    //				{
    //					Swd6Application.instance.m_ItemSystem.AddItem(current.Key.ID, current.Value, ENUM_ItemState.New, false);
    //				}
    //				else
    //				{
    //					Swd6Application.instance.m_ItemSystem.AddItem(current.Key.ID, current.Value, ENUM_ItemState.Old, false);
    //				}
    //			}
    //		}
    //	}

    //	public void Refight_ResetRoleHP()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.ResetHP_Refight();
    //		}
    //	}

    //	public void Escape()
    //	{
    //		bool flag = true;
    //		if (this.IsBossFight())
    //		{
    //			flag = false;
    //		}
    //		if (flag)
    //		{
    //			int num = UnityEngine.Random.Range(0, 100);
    //			int num2 = 0;
    //			foreach (M_Player current in this.m_PlayerList.Values)
    //			{
    //				if (current.m_MagicItem_Passive != null && current.m_MagicItem_Passive.m_EquipItem.ID == 740)
    //				{
    //					num2 = (int)current.m_MagicItem_Passive.GetAttrEffectValue();
    //					break;
    //				}
    //			}
    //			if (num >= 25 + num2)
    //			{
    //				flag = false;
    //			}
    //		}
    //		if (!flag)
    //		{
    //			M_Player controlledPlayer = this.GetControlledPlayer();
    //			if (controlledPlayer != null && controlledPlayer.m_ActionCDTimer < 3f)
    //			{
    //				controlledPlayer.m_ActionCDTimer = 5f;
    //				controlledPlayer.m_AddActionCD = controlledPlayer.m_ActionCDTimer;
    //			}
    //			UI_Fight.Instance.ShowEscapeFail();
    //			return;
    //		}
    //		this.SetFightFinish(false);
    //		this.UpdateRoleDataEx();
    //		UI_Fight.Instance.Hide();
    //		UI_TalkDialog.Instance.Close();
    //		FightSystem.Instance.FightEnd();
    //	}

    //	public M_Player GetFirstOrder_Role()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (!current.IsDead() && current.m_RoleModel.activeSelf)
    //			{
    //				return current;
    //			}
    //		}
    //		return null;
    //	}

    //	public M_Player GetOneDeadRole()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (current.IsDead())
    //			{
    //				return current;
    //			}
    //		}
    //		return null;
    //	}

    //	public M_Mob GetFirstOrder_Mob()
    //	{
    //		foreach (M_Mob current in this.m_MobList.Values)
    //		{
    //			if (current.CanBeTarget())
    //			{
    //				return current;
    //			}
    //		}
    //		return null;
    //	}

    //	private void UpdateRoleDataEx()
    //	{
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			current.OverwriteRoleData();
    //		}
    //	}

    //	public int GetManualPlayerCount()
    //	{
    //		int num = 0;
    //		foreach (KeyValuePair<int, M_Player> current in this.m_PlayerList)
    //		{
    //			if (!current.Value.m_bUseAI)
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetUsableReviveItem()
    //	{
    //		return this.GetUsableItem(this.m_AIReviveItems);
    //	}

    //	public int GetUsableHealItem_Single()
    //	{
    //		return this.GetUsableItem(this.m_AIHealItems_Single);
    //	}

    //	public int GetUsableHealItem_All()
    //	{
    //		return this.GetUsableItem(this.m_AIHealItems_All);
    //	}

    //	public int GetUsableRestoreMPItem_Single()
    //	{
    //		return this.GetUsableItem(this.m_AIRestoreMPItems_Single);
    //	}

    //	public int GetUsableRestoreMPItem_All()
    //	{
    //		return this.GetUsableItem(this.m_AIRestoreMPItems_All);
    //	}

    //	public int GetUsableDebuffItem()
    //	{
    //		return this.GetUsableItem(this.m_AIDebuffItems);
    //	}

    //	private int GetUsableItem(List<int> itemList)
    //	{
    //		for (int i = 0; i < itemList.Count; i++)
    //		{
    //			ItemData dataByItemID = Swd6Application.instance.m_ItemSystem.GetDataByItemID(itemList[i]);
    //			if (dataByItemID != null && dataByItemID.Count > 0)
    //			{
    //				return itemList[i];
    //			}
    //		}
    //		return -1;
    //	}

    //	private void CheckSelectRole()
    //	{
    //		M_Player controlledPlayer = this.GetControlledPlayer();
    //		if (controlledPlayer == null || controlledPlayer.IsDead() || !controlledPlayer.m_RoleModel.activeSelf)
    //		{
    //			foreach (M_Player current in this.m_PlayerList.Values)
    //			{
    //				if (!current.IsDead() && current.m_RoleModel.activeSelf)
    //				{
    //					this.ChangeControlCharacter(current.m_RoleID, true);
    //					break;
    //				}
    //			}
    //		}
    //	}

    //	public void OnRoleDead(M_Player deadPlayer)
    //	{
    //		FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //		fightState.m_BuffSystem.AddBuff(999, null, deadPlayer);
    //		this.CheckSelectRole();
    //	}

    //	public bool CheckAliveGuard(int guardID)
    //	{
    //		foreach (M_Guard current in this.m_GuardList.Values)
    //		{
    //			if (!current.IsDead())
    //			{
    //				if (current.m_MobGUID == guardID)
    //				{
    //					return true;
    //				}
    //			}
    //		}
    //		return false;
    //	}

    //	public M_Guard GetAliveGuard(int guardID)
    //	{
    //		foreach (M_Guard current in this.m_GuardList.Values)
    //		{
    //			if (!current.IsDead())
    //			{
    //				if (current.m_MobGUID == guardID)
    //				{
    //					return current;
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	public void OnGuardDead(M_Guard deadGuard)
    //	{
    //		if (this.m_GuardMobEffect.ContainsKey(deadGuard.m_DebutPosID))
    //		{
    //			this.m_GuardMobEffect[deadGuard.m_DebutPosID].SetActive(false);
    //		}
    //		int num = this.m_GuardList.Count;
    //		if (this.m_BattleGroupGUID == 7005)
    //		{
    //			num--;
    //		}
    //		if (num < 6)
    //		{
    //			S_MobGuard data = Swd6Application.instance.m_MobGuardSystem.GetData(this.m_GuardIdx + 1);
    //			if (data != null)
    //			{
    //				this.m_GuardIdx++;
    //				M_Guard m_Guard = this.CreateGuard(data.ID, deadGuard.m_DebutPosID);
    //				if (m_Guard == null)
    //				{
    //					UnityEngine.Debug.Log("Create guard == null, ID:" + data.ID);
    //				}
    //				else
    //				{
    //					m_Guard.m_DebutTargetTransform = deadGuard.m_DebutTargetTransform;
    //					m_Guard.Debut();
    //					m_Guard.m_ActionTargetModel = this.m_MainTarget.m_RoleModel;
    //					m_Guard.SetFaceToTarget(this.m_MainTarget);
    //					m_Guard.SetStartUpdate(true);
    //				}
    //			}
    //		}
    //		UI_Fight.Instance.SetGuardSlot();
    //	}

    //	private void AddQuestDeadMobCount(int mobGUID)
    //	{
    //		for (int i = 0; i < this.m_DeadMobList.Count; i++)
    //		{
    //			if (this.m_DeadMobList[i].ID == mobGUID)
    //			{
    //				this.m_DeadMobList[i].Count++;
    //				return;
    //			}
    //		}
    //		S_FinishMob s_FinishMob = new S_FinishMob();
    //		s_FinishMob.ID = mobGUID;
    //		s_FinishMob.Count = 1;
    //		this.m_DeadMobList.Add(s_FinishMob);
    //	}

    //	private void CheckTargetMob()
    //	{
    //		M_Mob mainTarget = this.GetMainTarget();
    //		if (mainTarget == null || mainTarget.IsDead() || !mainTarget.m_RoleModel.activeSelf || !mainTarget.CanBeTarget())
    //		{
    //			foreach (KeyValuePair<int, M_Mob> current in this.m_MobList)
    //			{
    //				if (current.Value.CanBeTarget())
    //				{
    //					this.ChangeTargetMob(current.Key);
    //					break;
    //				}
    //			}
    //		}
    //	}

    //	public void OnMobDead(M_Mob deadMob)
    //	{
    //		if (this.m_SummonMobRecordList.ContainsKey(deadMob.m_DebutPosStr))
    //		{
    //			this.m_SummonMobRecordList.Remove(deadMob.m_DebutPosStr);
    //		}
    //		else
    //		{
    //			this.AddQuestDeadMobCount(deadMob.m_MobGUID);
    //		}
    //		this.OnMobEnableUpdate(deadMob, false);
    //	}

    //	public void OnMobEnableUpdate(M_Mob mob, bool bEnable)
    //	{
    //		this.CheckTargetMob();
    //		UI_Fight.Instance.OnMobEnableUpdate(mob, bEnable);
    //		this.TargetEffectCheck();
    //	}

    //	public void CatchMob(int roleID, int mobKeyID)
    //	{
    //		M_Player role = this.GetRole(roleID);
    //		M_Mob mob = this.GetMob(mobKeyID);
    //		if (role == null || mob == null)
    //		{
    //			return;
    //		}
    //		this.m_CatchMobCDTimer = 10f;
    //		M_Mob targetMob = this.m_CatchMobPet.GetTargetMob();
    //		if (!(mob == targetMob))
    //		{
    //			if (targetMob != null)
    //			{
    //				targetMob.SetBeCatchState(false);
    //				UI_Fight.Instance.SetMobBeCaught(targetMob.m_MobSerialID, false);
    //			}
    //			this.m_CatchMobPet.SetCatchInfo(role, mob);
    //			mob.SetBeCatchState(true);
    //			UI_Fight.Instance.SetMobBeCaught(mob.m_MobSerialID, true);
    //			if (!this.m_CatchMobPet.m_RoleModel.activeSelf)
    //			{
    //				this.m_CatchMobPet.Debut();
    //			}
    //			return;
    //		}
    //		if (this.m_BattleGroupGUID == 7041)
    //		{
    //			return;
    //		}
    //		mob.SetBeCatchState(false);
    //		this.m_CatchMobPet.CancelCatch();
    //		UI_Fight.Instance.SetMobBeCaught(mob.m_MobSerialID, false);
    //	}

    //	public void CatchMobSuccess(M_Mob mob)
    //	{
    //		this.EnableFightRole(Enum_FightRoleType.Mob, mob.m_MobSerialID, false);
    //		this.m_MobRewardList.Remove(mob);
    //		int mobGUID = mob.m_MobGUID;
    //		if (this.m_CatchMobList.ContainsKey(mobGUID))
    //		{
    //			Dictionary<int, int> catchMobList;
    //			Dictionary<int, int> expr_39 = catchMobList = this.m_CatchMobList;
    //			int num;
    //			int expr_3C = num = mobGUID;
    //			num = catchMobList[num];
    //			expr_39[expr_3C] = num + 1;
    //		}
    //		else
    //		{
    //			this.m_CatchMobList.Add(mobGUID, 1);
    //		}
    //		this.m_CatchMobKeyIDList.Add(mob.m_MobSerialID);
    //		Swd6Application.instance.m_IdentifySystem.AddMobIdentify(mobGUID, ENUM_MobIdentifyType.Catch);
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator WaitWinPerformFinish()
    //	{
    //		FightSceneManager.<WaitWinPerformFinish>c__Iterator88B <WaitWinPerformFinish>c__Iterator88B = new FightSceneManager.<WaitWinPerformFinish>c__Iterator88B();
    //		<WaitWinPerformFinish>c__Iterator88B.<>f__this = this;
    //		return <WaitWinPerformFinish>c__Iterator88B;
    //	}

    //	public void SetRoleUseAI_UI(int roleID, bool bUseAI)
    //	{
    //		if (this.m_PlayerList.ContainsKey(roleID))
    //		{
    //			this.m_PlayerList[roleID].SetUseAI(bUseAI);
    //		}
    //	}

    //	public void UseMagicItem_UI(int roleID)
    //	{
    //		M_Player role = this.GetRole(roleID);
    //		if (role != null)
    //		{
    //			role.UseMagicItem();
    //		}
    //	}

    //	public void DelFightRoleNoRemoveBuff(Enum_FightRoleType emType, int id, int buffID)
    //	{
    //		if (emType != Enum_FightRoleType.Player)
    //		{
    //			if (emType == Enum_FightRoleType.Mob)
    //			{
    //				if (this.m_MobList.ContainsKey(id))
    //				{
    //					this.m_MobList[id].DelNoRemoveBuff(buffID);
    //				}
    //			}
    //		}
    //		else if (this.m_PlayerList.ContainsKey(id))
    //		{
    //			this.m_PlayerList[id].DelNoRemoveBuff(buffID);
    //		}
    //	}

    //	public void DebugMsg()
    //	{
    //		for (int i = 1; i <= 4; i++)
    //		{
    //			C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //			if (roleData != null)
    //			{
    //				UnityEngine.Debug.Log(roleData.BaseRoleData.Name);
    //				for (int j = 0; j < roleData.RoleAttr.sFinial.AtkElement.Length; j++)
    //				{
    //					UnityEngine.Debug.Log(string.Concat(new object[]
    //					{
    //						"AtkElement[",
    //						j,
    //						"]:",
    //						roleData.RoleAttr.sFinial.AtkElement[j]
    //					}));
    //				}
    //				for (int k = 0; k < roleData.RoleAttr.sFinial.Element.Length; k++)
    //				{
    //					UnityEngine.Debug.Log(string.Concat(new object[]
    //					{
    //						"Element[",
    //						k,
    //						"]:",
    //						roleData.RoleAttr.sFinial.Element[k]
    //					}));
    //				}
    //			}
    //		}
    //	}

    //	public void LevelUpCameraPath(M_Player player)
    //	{
    //		if (this.m_LevelUpCamPath != null)
    //		{
    //			UnityEngine.Object.Destroy(this.m_LevelUpCamPath);
    //		}
    //		this.m_LevelUpCamPath = ResourceManager.Instance.GetFightObject("LevelUpCameraPath_" + player.m_RoleID);
    //		if (this.m_LevelUpCamPath == null)
    //		{
    //			return;
    //		}
    //		this.m_LevelUpCamPath.transform.position = player.m_ModelTransform.position;
    //		this.m_LevelUpCamPath.transform.rotation = player.m_ModelTransform.rotation;
    //		CameraPathBezierAnimator component = this.m_LevelUpCamPath.GetComponent<CameraPathBezierAnimator>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		if (this.m_FightCamera == null)
    //		{
    //			return;
    //		}
    //		component.Stop();
    //		component.animationTarget = this.m_FightCamera.transform;
    //		component.Play();
    //	}

    public void PlayAppearCameraPath()
    {
        //FightSystem.Instance.FightEffectIn(false);
        //FightSystem.Instance.FightEffectOut(true);
        if (this.m_BattleGroup == null)
        {
            return;
        }
        string text = this.m_BattleGroup.FightCameraPath;
        if (text == null || text == string.Empty)
        {
            text = "AppearCameraPath_1";
        }
        this.m_AppearCamPath = ResourcesManager.Instance.GetFightObject(text);
        if (this.m_AppearCamPath == null)
        {
            return;
        }
        //this.m_AppearCamPath.transform.position = this.m_PlayerList[this.m_ControlledRoleID].m_ModelTransform.position;
        //this.m_AppearCamPath.transform.rotation = this.m_PlayerList[this.m_ControlledRoleID].m_ModelTransform.rotation;
        //CameraPathBezierAnimator component = this.m_AppearCamPath.GetComponent<CameraPathBezierAnimator>();
        //if (component == null)
        //{
        //    return;
        //}
        //if (this.m_FightCamera == null)
        //{
        //    return;
        //}
        //CameraPathBezierControlPoint[] componentsInChildren = this.m_AppearCamPath.GetComponentsInChildren<CameraPathBezierControlPoint>();
        //for (int i = 0; i < componentsInChildren.Length; i++)
        //{
        //    if (componentsInChildren[i] != null)
        //    {
        //        componentsInChildren[i].FOV = FightSystem.Instance.m_FightCameraFOV;
        //    }
        //    if (i == componentsInChildren.Length - 1 && this.m_FightCameraController as M_FightCameraController_Black != null)
        //    {
        //        componentsInChildren[i].transform.localPosition = (this.m_FightCameraController as M_FightCameraController_Black).m_FollowPos + new Vector3(FightSystem.Instance.m_FightCameraMouseX, 0f, 0f);
        //        (this.m_FightCameraController as M_FightCameraController_Black).m_MouseX = FightSystem.Instance.m_FightCameraMouseX;
        //    }
        //}
        //component.animationTarget = this.m_FightCamera.transform;
        //component.Play();
        //component.AnimationFinished += new CameraPathBezierAnimator.AnimationFinishedEventHandler(this.AppearCameraPathFinished);
        //this.SetDebutAnimtaion();
    }

    //	private void AppearCameraPathFinished()
    //	{
    //		Swd6Application.instance.StartCoroutine(this.WaitAllCharacterStanby());
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator WaitAllCharacterStanby()
    //	{
    //		FightSceneManager.<WaitAllCharacterStanby>c__Iterator88C <WaitAllCharacterStanby>c__Iterator88C = new FightSceneManager.<WaitAllCharacterStanby>c__Iterator88C();
    //		<WaitAllCharacterStanby>c__Iterator88C.<>f__this = this;
    //		return <WaitAllCharacterStanby>c__Iterator88C;
    //	}

    private void SetFightCameraController()
    {
        if (this.m_PlayerList.ContainsKey(this.m_ControlledRoleID))
        {
            this.m_FightCameraController.SetFollower(this.m_PlayerList[this.m_ControlledRoleID]);
        }
    }

    //	public Vector3 GetAllCharacterCenter()
    //	{
    //		Vector3 a = Vector3.zero;
    //		float num = 0f;
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (!current.IsDead())
    //			{
    //				a += current.GetModelPosition();
    //				num += 1f;
    //			}
    //		}
    //		foreach (M_Mob current2 in this.m_MobList.Values)
    //		{
    //			if (!current2.IsDead())
    //			{
    //				a += current2.GetModelPosition();
    //				num += 1f;
    //			}
    //		}
    //		return a / num;
    //	}

    //	public float GetAllCharacterMaxDistance()
    //	{
    //		float num = 0f;
    //		foreach (M_Player current in this.m_PlayerList.Values)
    //		{
    //			if (!current.IsDead())
    //			{
    //				foreach (M_Mob current2 in this.m_MobList.Values)
    //				{
    //					if (!current2.IsDead())
    //					{
    //						float num2 = Vector3.Distance(current.GetModelPosition(), current2.GetModelPosition());
    //						if (num < num2)
    //						{
    //							num = num2;
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	public void ShakeCamera(M_Character character)
    //	{
    //		if (this.m_FightCameraController == null)
    //		{
    //			return;
    //		}
    //		this.m_FightCameraController.Shake(character);
    //	}

    //	public void SetSkillCameraPath(M_Character character, S_SkillCameraData skillCameraData, bool bCritical)
    //	{
    //		if (this.m_FightCameraController == null)
    //		{
    //			return;
    //		}
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		this.m_FightCameraController.SkillShotCharacter(character, skillCameraData, bCritical);
    //	}

    //	public void SetCatchMobCameraPath(M_CatchMob character)
    //	{
    //		if (this.m_FightCameraController == null)
    //		{
    //			return;
    //		}
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		this.m_FightCameraController.CatchMobShotCharacter(character);
    //	}

    //	public void SetCatchSuccessCameraPath(M_CatchMob character)
    //	{
    //		if (this.m_FightCameraController == null)
    //		{
    //			return;
    //		}
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		this.m_FightCameraController.CatchSuccessShotCharacter(character);
    //	}

    public void ChangeFormationCameraPath()
    {
        //if (this.m_FightCameraController == null)
        //{
        //    return;
        //}
        //this.m_FightCameraController.ChangeFormation();
    }

    private void InitFightTalk()
    {
        if (this.m_BattleGroup == null)
        {
            UnityEngine.Debug.LogWarning("m_BattleGroup = Null");
            return;
        }
        if (this.m_BattleGroup.FightTalk != null)
        {
            //GameObject gameObject = new GameObject("FightTalkMgrObj");
            //this.m_FightTalk = (gameObject.AddComponent(this.m_BattleGroup.FightTalk) as M_FightTalk);
            //if (this.m_FightTalk != null)
            //{
            //    this.m_FightTalk.m_FightSceneManager = this;
            //    this.m_FightTalk.Play();
            //}
            //else
            //{
            //    UnityEngine.Debug.Log("找不到戰鬥劇情Script : " + this.m_BattleGroup.FightTalk);
            //    UnityEngine.Object.Destroy(gameObject);
            //}
        }
    }

    //	public void SetFightTalkMoney(int money)
    //	{
    //		this.m_FightTalkMoney = money;
    //	}

    //	public void SetFightTalkExp(int exp)
    //	{
    //		this.m_FightTalkExp = exp;
    //	}

    //	public void SetFightTalkItem(int itemID, int count)
    //	{
    //		if (this.m_FightTalkItemList.ContainsKey(itemID))
    //		{
    //			this.m_FightTalkItemList[itemID] = this.m_FightTalkItemList[itemID] + count;
    //		}
    //		else
    //		{
    //			this.m_FightTalkItemList.Add(itemID, count);
    //		}
    //	}

    //	public void ShotCharacter(Enum_FightRoleType emType, int id, Vector3 pos, Vector3 rot)
    //	{
    //		M_Character character = this.GetCharacter(emType, id);
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		this.m_FightCameraController.StoryShotCharacter(character, pos, rot);
    //	}

    //	public void CharacterUseSkill_StoryMode(Enum_FightRoleType emType, int id, int skillID)
    //	{
    //		M_Character character = this.GetCharacter(emType, id);
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		M_Character m_Character = character.ChooseTarget_AI(skillID);
    //		if (m_Character == null)
    //		{
    //			return;
    //		}
    //		FightCommand item = new FightCommand_Skill(character, m_Character, skillID);
    //		character.ClearCommand();
    //		character.m_CommandQueue.Add(item);
    //		character.m_emFight = M_Character.Enum_FightStatus.MoveToAttack;
    //	}

    //	public void CharacterUseSkill_StoryMode(Enum_FightRoleType emType, int id, int skillID, M_Character target)
    //	{
    //		M_Character character = this.GetCharacter(emType, id);
    //		if (character == null)
    //		{
    //			return;
    //		}
    //		if (target == null)
    //		{
    //			return;
    //		}
    //		FightCommand item = new FightCommand_Skill(character, target, skillID);
    //		character.ClearCommand();
    //		character.m_CommandQueue.Add(item);
    //		character.m_emFight = M_Character.Enum_FightStatus.MoveToAttack;
    //	}

    //	public void Escape_StoryMode()
    //	{
    //		UI_Fight.Instance.SetStoryMode(false);
    //		this.SetFightFinish(false);
    //		this.UpdateRoleDataEx();
    //		UI_Fight.Instance.Hide();
    //		UI_TalkDialog.Instance.Close();
    //		FightSystem.Instance.FightEnd();
    //	}

    //	public bool IsBossFight()
    //	{
    //		return this.m_BattleGroupGUID >= 7001 && this.m_BattleGroupGUID <= 7100;
    //	}

    /// <summary>
    /// 下一场战斗
    /// </summary>
    public void NextWave()
    {
        //PlayerItem[] characters;
        //StageFoe[] foes;
        //var wave = CastedStage.waves[CurrentWave];
        //if (!wave.useRandomFoes && wave.foes.Length > 0)
        //    foes = wave.foes;
        //else
        //    foes = CastedStage.RandomFoes().foes;

        //characters = new PlayerItem[foes.Length];
        //for (var i = 0; i < characters.Length; ++i)
        //{
        //    var foe = foes[i];
        //    if (foe != null && foe.character != null)
        //    {
        //        var character = PlayerItem.CreateActorItemWithLevel(foe.character, foe.level);
        //        characters[i] = character;
        //    }
        //}

        //if (characters.Length == 0)
        //    Debug.LogError("Missing Foes Data");

        //foeFormation.SetCharacters(characters);
        //foeFormation.Revive();
        //++CurrentWave;
    }

    /// <summary>
    /// 下一回合
    /// </summary>
    public void NewTurn()
    {
        if (ActiveCharacter != null)
        {
            ActiveCharacter.currentTimeCount = 0;
        }

        M_Character activatingCharacter = null;
        var maxTime = int.MinValue;
        List<M_Character> characters = new List<M_Character>();
        characters.AddRange(PlayerList);
        characters.AddRange(MobList);
        for (int i = 0; i < characters.Count; ++i)
        {
            M_Character character = characters[i] as M_Character;
            if (character != null)
            {
                if (character.m_FightRoleData.HP > 0)
                {
                    int spd = (int)character.m_FightRoleData.Agi;
                    if (spd <= 0)
                    {
                        spd = 1;
                    }
                    character.currentTimeCount += spd;
                    if (character.currentTimeCount > maxTime)
                    {
                        UnityEngine.Debug.Log("执行");
                        maxTime = character.currentTimeCount;
                        activatingCharacter = character;
                    }
                }
                else//后期删除HP小于0直接删除
                {
                    character.currentTimeCount = 0;
                }
            }
        }
        ActiveCharacter = activatingCharacter;
        //ChangeControlCharacter(1, false);
        //ActiveCharacter.DecreaseBuffsTurn();
        //ActiveCharacter.DecreaseSkillsTurn();
        //ActiveCharacter.ResetStates();

        if (ActiveCharacter.m_FightRoleData.HP > 0)
        {

            if (ActiveCharacter.IsPlayerCharacter)
            {
                //this.InitFightTarget();
                //if (IsAutoPlay)
                //{
                //    ActiveCharacter.RandomAction();
                //}
                //else
                //{
                FightUIForm.uiCharacterActionManager.Show();
                m_NowControlledEffect.SetActive(true);
                this.m_NowControlledEffect.transform.position = ActiveCharacter.GetModelPosition();
                this.m_NowControlledEffect.transform.rotation = ActiveCharacter.m_ModelTransform.rotation;
                //}
            }
            else
            {

                UnityEngine.Debug.Log("怪物先手");
                //ActiveCharacter.RandomAction();
            }
        }
        else
        {
            //ActiveCharacter.NotifyEndAction();
        }
    }

    public void NotifyEndAction(M_Character character)
    {
        //if (character != ActiveCharacter)
        //    return;

        //if (!playerFormation.IsAnyCharacterAlive())
        //{
        //    ActiveCharacter = null;
        //    StartCoroutine(LoseGameRoutine());
        //}
        //else if (!foeFormation.IsAnyCharacterAlive())
        //{
        //    ActiveCharacter = null;
        //    if (CurrentWave >= CastedStage.waves.Length)
        //    {
        //        StartCoroutine(WinGameRoutine());
        //        return;
        //    }
        //    StartCoroutine(MoveToNextWave());
        //}
        //else
        //{
        //    NewTurn();
        //}
    }
}
