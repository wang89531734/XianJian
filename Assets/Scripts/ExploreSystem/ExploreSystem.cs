using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YouYou;

public class ExploreSystem
{
    private float m_BattleStepCount;

    private int m_BattleID;

    private bool m_bLockPlayer;

    private bool m_bSetReStarPos;

    private bool m_bResumeMusic;

    private bool m_bNavMesh;

    private bool m_bAutoPath;

    private bool m_OpenMainMenu;

    private bool m_IsRun = true;

    private float m_BattelTriggerTime;

    private float m_MaxBattleStep;

    private string m_TriggerName;

    private int m_CostStamina = 25;

    private int m_ShootFailTime;

    private float m_PlayerChangeDir;

    private float m_PlayMusicDelayTime;

    private float m_NoFightTime;

    private float m_HitDamageDelayTime;

    private float m_ActionSkillTime;

    private int m_ActionSkillStep;

    private bool m_bUseActionSkill;

    private bool m_bBeginShoot;

    private bool m_BeginDispell;

    private bool m_BeginBreak;

    private bool m_BeginSuperJump;

    public bool m_SetCemeraInfo;

    public float m_CameraXAngle;

    public float m_CameraYAngle;

    public float m_CameraDist;

    public float m_ResourceUnLoadTime;

    public bool m_ResourceUnLoad;

    public bool m_UpdateCosCloth;

    public bool m_PlayStory;

    public float m_OpenMenuTime;

    private GameObject m_TalkTarget;

    private GameObject m_ActionTarget;

    public GameObject m_GhostEffect;

    public GameObject m_ActionSTEffect;

    public GameObject m_ActionEffect;

    public GameObject m_ActionEDEffect;

    public GameObject m_ShootTarget;

    private Vector3 m_ShootOffset = Vector3.zero;

    /// <summary>
    /// 之前的玩家位置
    /// </summary>
    private Vector3 m_PrePlayerPos = Vector3.zero;

    private Vector3 m_PlayerChangePos = Vector3.zero;

    private Vector3 m_FloatingStartPos = Vector3.zero;

    private Vector3 m_ReStartPos = Vector3.zero;

    private GameObject m_PlayerGameObj;

    private M_PlayerController m_PlyerController;

    private GameObject m_RidePetGameObj;

   // private M_RidePetController m_RidePetController;

    private GameObject m_AmberGameObj;

   // private M_AmberController m_AmberController;

    public GameObject m_MoveTargetPoint;

    private List<S_BattleArea> m_BattleArea;

    //private UI_GameFlagMenu m_UI_GameFlagMenu;

    //public List<S_GameObjData> m_GhostEyeObjList = new List<S_GameObjData>();

    public GameObject m_MapSoundEvent;

    private string m_PlayerChangePoint = string.Empty;

    public float m_PrePosUpdateTime;

    public float m_PlayerUpdateTime;

    private GameObject m_MainCameraGameObj;

    private M_PlayerMouseOrbit m_PlayerMouseOrbit;

    public S_MapData m_MapData
    {
        get;
        private set;
    }

    /// <summary>
    /// 玩家物体
    /// </summary>
    public GameObject PlayerObj
    {
        get
        {
            return this.m_PlayerGameObj;
        }
        set
        {
            this.m_PlayerGameObj = value;
            this.m_PlayerGameObj.tag = "Player";
            this.m_PlyerController = this.m_PlayerGameObj.GetComponent<M_PlayerController>();
        }
    }

    public GameObject AmberObj
    {
        get
        {
            return this.m_AmberGameObj;
        }
        set
        {
            this.m_AmberGameObj = value;
            if (this.m_AmberGameObj != null)
            {
                //this.m_AmberController = this.m_AmberGameObj.GetComponent<M_AmberController>();
            }
        }
    }

    public GameObject RidePetObj
    {
        get
        {
            return this.m_RidePetGameObj;
        }
        set
        {
            this.m_RidePetGameObj = value;
            this.m_RidePetGameObj.tag = "Player";
        }
    }

    //public M_RidePetController RidePetController
    //{
    //    get
    //    {
    //        return this.m_RidePetController;
    //    }
    //}

    public bool IsUseActionSkill
    {
        get
        {
            return this.m_bUseActionSkill;
        }
    }

    public M_PlayerController PlayerController
    {
        get
        {
            return this.m_PlyerController;
        }
        set
        {
            this.m_PlyerController = value;
        }
    }

    public float BattleStep
    {
        get
        {
            return this.m_BattleStepCount;
        }
        set
        {
            this.m_BattleStepCount = value;
        }
    }

    public int BattleID
    {
        get
        {
            return this.m_BattleID;
        }
        set
        {
            this.m_BattleID = value;
        }
    }

    public Vector3 PlayerChangePos
    {
        get
        {
            return this.m_PlayerChangePos;
        }
        set
        {
            this.m_PlayerChangePos = value;
        }
    }

    public float PlayerChangeDir
    {
        get
        {
            return this.m_PlayerChangeDir;
        }
        set
        {
            this.m_PlayerChangeDir = value;
        }
    }

    public bool LockPlayer
    {
        get
        {
            return this.m_bLockPlayer;
        }
        set
        {
            this.m_bLockPlayer = value;
            //if (this.m_PlyerController != null)
            //{
            //    this.m_PlyerController.LockControl = this.m_bLockPlayer;
            //}
            //if (this.m_RidePetGameObj != null)
            //{
            //    M_RidePetController component = this.m_RidePetGameObj.GetComponent<M_RidePetController>();
            //    component.LockControl = this.m_bLockPlayer;
            //}
            //if (!this.m_bLockPlayer)
            //{
            //    if (Swd6Application.instance.m_QuestSystem != null)
            //    {
            //        Swd6Application.instance.m_QuestSystem.Dirty();
            //    }
            //    this.TalkTarget = null;
            //    UI_PartnerTalkDialog.Instance.Resume();
            //    Swd6Application.instance.m_SkillSystem.CheckSkillLearnState(false);
            //}
            //else
            //{
            //    UI_PartnerTalkDialog.Instance.Stop();
            //    UI_ZoneMap.Instance.Hide();
            //}
            GameInput.Clear();
        }
    }

    public GameObject TalkTarget
    {
        get
        {
            return this.m_TalkTarget;
        }
        set
        {
            //if (value == null && this.m_TalkTarget && this.m_TalkTarget.GetComponent<M_GameRoleBase>() != null)
            //{
            //    this.m_TalkTarget.GetComponent<M_GameRoleBase>().Talk = false;
            //}
            this.m_TalkTarget = value;
        }
    }

    public GameObject ActionTarget
    {
        get
        {
            return this.m_ActionTarget;
        }
        set
        {
            this.m_ActionTarget = value;
        }
    }

    public bool ResumeMusic
    {
        get
        {
            return this.m_bResumeMusic;
        }
        set
        {
            this.m_bResumeMusic = value;
        }
    }

    public bool NavMesh
    {
        get
        {
            return this.m_bNavMesh;
        }
        set
        {
            this.m_bNavMesh = value;
        }
    }

    public bool AutoPath
    {
        get
        {
            return this.m_bAutoPath;
        }
        set
        {
            this.m_bAutoPath = value;
        }
    }

    public bool Run
    {
        get
        {
            return this.m_IsRun;
        }
        set
        {
            this.m_IsRun = value;
        }
    }

    public bool OpenMainMenu
    {
        get
        {
            return this.m_OpenMainMenu;
        }
        set
        {
            this.m_OpenMainMenu = value;
        }
    }

    public string PlayerChangePoint
    {
        get
        {
            return this.m_PlayerChangePoint;
        }
        set
        {
            this.m_PlayerChangePoint = value;
        }
    }

    public void Initialize()
    {
        this.m_BattleArea = new List<S_BattleArea>();
    }

    //	public GameObject ShowMoveTarget(bool show, Vector3 targetPos)
    //	{
    //		if (this.m_MoveTargetPoint)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_MoveTargetPoint);
    //			this.m_MoveTargetPoint = null;
    //		}
    //		if (targetPos == Vector3.zero)
    //		{
    //			return null;
    //		}
    //		if (show)
    //		{
    //			this.m_MoveTargetPoint = OtherElementGenerator.CreateOtherGameObject("MoveTargetPoint");
    //			if (this.m_MoveTargetPoint)
    //			{
    //				this.m_MoveTargetPoint.transform.position = targetPos;
    //				return this.m_MoveTargetPoint;
    //			}
    //		}
    //		return null;
    //	}

    public void Begin()
    {
        //bool lockPlayer = this.LockPlayer;
        this.LoadMapDate();
        //this.LoadEventPrefab();
        if (this.PlayerChangePoint != string.Empty)
        {
            GameObject gameObject2 = GameObject.Find(this.PlayerChangePoint);
            if (gameObject2 != null)
            {
                this.PlayerChangePos = gameObject2.transform.position;
                this.PlayerChangeDir = gameObject2.transform.eulerAngles.y;
            }
            this.PlayerChangePoint = string.Empty;
        }
        this.PlayerObj = GameEntry.Instance.m_GameObjSystem.CreatePlayerGameObj(GameEntry.Instance.m_GameDataSystem.m_PlayerID, this.PlayerChangePos, this.PlayerChangeDir);
        this.m_PrePlayerPos = this.PlayerController.Pos;
        this.m_PrePosUpdateTime = 0f;
        this.m_PlayerUpdateTime = 1f;
        this.PlayerController.m_NoJump = false;
        ////this.AmberPigObj = this.m_GameApp.m_GameObjSystem.CreateAmberPigGameObj();
        //this.EnableMainCamera(true);
        this.SetCameraLookTarget(true);
        ////this.SetAmberPigTargetPos();
        ///GameEntry.Instance.m_GameObjSystem.LoadMapObj(GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
        //GameMapMobSystem.Instance.SetTarget(this.PlayerObj);
        //ExploreMiniMapSystem.Instance.CreateMapData(this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
        //this.m_GameApp.m_SaveloadSystem.m_Loading = false;
        //if (this.m_PlayMusicDelayTime <= 0f)
        //{
        //    this.PlayMusic();
        //}
        GameInput.Clear();
        //this.m_HideMap = 0;
        //this.m_RainEffect = null;
        //this.ClearNoFightData(true);
        //this.m_GameApp.m_GameDataSystem.ReLoadObjData();
        //if (this.m_GameApp.m_GameDataSystem.GetFlag(52))
        //{
        //    this.SetPlayerPointLight(true);
        //}
        //if (this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID == 64 && !this.m_GameApp.m_GameDataSystem.GetFlag(56))
        //{
        //    this.SetMapRainEffect();
        //}
        //this.LockPlayer = lockPlayer;
        //this.ClearBattleInfo();
        //this.SpecialSetting();//特别设置
        //this.ChangeSky();
    }

    public void LoadEventPrefab()
    {
        if (this.m_MapData == null)
        {
            return;
        }
        //string[] ignoreName = new string[]
        //{
        //    "Extra_Mask_MAP78",
        //    "Extra_Mask_MAP66_01",
        //    "Extra_Mask_MAP59_01"
        //};
        string name;
        for (int i = 1; i <= 5; i++)
        {
            name = this.m_MapData.Name + "_Event_" + i.ToString();
            GameObject mapEvent = ResourcesManager.Instance.GetMapEvent(name);
            //if (mapEvent != null)
            //{
            //    TransformTool.SetLayerRecursively(mapEvent.transform, 2, ignoreName);
            //}
        }
        //name = this.m_MapData.Name + "_SoundEvent";
        //if (this.m_MapSoundEvent != null)
        //{
        //    UnityEngine.Object.Destroy(this.m_MapSoundEvent);
        //}
        //this.m_MapSoundEvent = ResourcesManager.Instance.GetMapSoundEvent(name);
    }

    //	public void End()
    //	{
    //		Debug.Log("EndExplore_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //		int mapID = this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID;
    //		this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID = this.m_MapData.GUID;
    //		UI_ZoneMap.Instance.SaveMapMask();
    //		this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID = mapID;
    //		UI_PartnerTalkDialog.Instance.Break();
    //		UI_ZoneMap.Instance.Close();
    //		UI_SmallMap.Instance.Close();
    //		UI_BigMap.Instance.Close();
    //		GameInput.Clear();
    //		this.ExitBattleArea(null);
    //		this.ResetData();
    //		this.m_ShootFailTime = 0;
    //		this.m_OpenMainMenu = false;
    //		if (this.AmberObj)
    //		{
    //			this.AmberObj.GetComponent<M_AmberController>().SetRender(false);
    //		}
    //	}

    //	public void Suspend()
    //	{
    //		if (this.m_GameApp.gameStateService.getCurrentState().name == "StoryState")
    //		{
    //			this.EnableMainCamera(false);
    //		}
    //		this.m_PlayerChangePos = this.PlayerController.Pos;
    //		this.m_PlayerChangeDir = this.PlayerController.Dir;
    //		UI_ZoneMap.Instance.Hide();
    //		UI_SmallMap.Instance.Hide();
    //		UI_BigMap.Instance.Close();
    //		GameInput.Clear();
    //		this.ResumeMusic = false;
    //		this.LockPlayer = true;
    //		Debug.Log("Suspend_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //	}

    //	public void Resume()
    //	{
    //		this.EnableMainCamera(true);
    //		UI_SmallMap.Instance.Open();
    //		if (this.m_UpdateCosCloth && this.RidePetObj == null)
    //		{
    //			this.m_UpdateCosCloth = false;
    //			this.SwitchPlayer();
    //		}
    //		this.PlayerController.Pos = this.m_PlayerChangePos;
    //		this.PlayerController.Dir = this.m_PlayerChangeDir;
    //		if (this.m_GameApp.m_GameObjSystem.IsHidePlayer())
    //		{
    //			this.m_GameApp.m_GameObjSystem.HidePlayer(false);
    //		}
    //		this.LockPlayer = false;
    //		if (this.m_PlayMusicDelayTime <= 0f && !this.ResumeMusic)
    //		{
    //			this.PlayMusic(1f);
    //		}
    //		GameInput.Clear();
    //		this.m_OpenMainMenu = false;
    //		Debug.Log("Resume_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //	}

    public void ResetData()
    {
        GameEntry.Instance.m_GameDataSystem.FlagOFF(40);
        GameEntry.Instance.m_GameDataSystem.FlagOFF(41);
    }

    public void LoadMapDate()
    {
        GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID = 51;
        this.m_MapData = GameDataDB.MapDB.GetData(GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
        if (this.m_MapData == null)
        {
            Debug.Log("載入地圖dbf錯誤_" + GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
            return;
        }
        this.ResetData();
        if (this.m_MapData.emType == ENUM_MapType.Maze)
        {
            GameEntry.Instance.m_GameDataSystem.FlagON(41);
        }

        if (this.m_MapData.emType != ENUM_MapType.Maze)
        {
            GameEntry.Instance.m_GameDataSystem.m_PlayerID = GameEntry.Instance.m_GameDataSystem.m_DefaultPlayerID;
            // UI_Explore.Instance.SetActionSkill(this.m_GameApp.m_GameDataSystem.m_PlayerID);
        }
        else
        {
            // UI_Explore.Instance.SetActionSkill(this.m_GameApp.m_GameDataSystem.m_PlayerID);
        }
        //UI_Explore.Instance.SetActionSkillUIState();
    }

    //	public void ResetMapSoundVolume()
    //	{
    //		if (this.m_MapSoundEvent == null)
    //		{
    //			return;
    //		}
    //		MapSoundData[] componentsInChildren = this.m_MapSoundEvent.GetComponentsInChildren<MapSoundData>();
    //		MapSoundData[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			MapSoundData mapSoundData = array[i];
    //			mapSoundData.ResetVolume();
    //		}
    //	}

    //	public void ResetMapSoundVolume(float volume)
    //	{
    //		if (this.m_MapSoundEvent == null)
    //		{
    //			return;
    //		}
    //		MapSoundData[] componentsInChildren = this.m_MapSoundEvent.GetComponentsInChildren<MapSoundData>();
    //		MapSoundData[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			MapSoundData mapSoundData = array[i];
    //			mapSoundData.ResetVolume(volume);
    //		}
    //	}

    //	public bool CheckNavMesh()
    //	{
    //		this.AutoPath = false;
    //		this.NavMesh = false;
    //		if (this.m_MapData == null)
    //		{
    //			return false;
    //		}
    //		if (this.m_GameApp.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			string text = string.Concat(new string[]
    //			{
    //				Application.dataPath,
    //				"/./Art/Scenes/",
    //				this.m_MapData.Name,
    //				"/",
    //				this.m_MapData.Name,
    //				"/NavMesh.asset"
    //			});
    //			if (File.Exists(text))
    //			{
    //				this.NavMesh = true;
    //				this.AutoPath = true;
    //			}
    //			else
    //			{
    //				Debug.Log("無路徑資料_" + text);
    //			}
    //		}
    //		else
    //		{
    //			this.NavMesh = true;
    //			this.AutoPath = true;
    //		}
    //		if (this.m_MapData.AutoMove == 1)
    //		{
    //			this.NavMesh = true;
    //			this.AutoPath = true;
    //		}
    //		if (this.m_GameApp.m_GameDataSystem.GetFlag(41) || this.m_MapData.emType == ENUM_MapType.Field)
    //		{
    //			this.AutoPath = false;
    //		}
    //		return true;
    //	}

    //	public void PlayMusic(float fadeTime)
    //	{
    //		if (MusicControlSystem.m_StoryMusicExtendMode == ENUM_MusicExtendMode.infinite)
    //		{
    //			MusicControlSystem.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
    //			return;
    //		}
    //		S_MusicData data = GameDataDB.MusicDB.GetData(this.m_MapData.MusicID1);
    //		if (data == null)
    //		{
    //			Debug.Log("LoadMusicData_" + this.m_MapData.MusicID1 + "不存在");
    //			return;
    //		}
    //		AudioClip audioClip = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip == null)
    //		{
    //			Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		data = GameDataDB.MusicDB.GetData(this.m_MapData.MusicID2);
    //		if (data == null)
    //		{
    //			Debug.Log("LoadMusicData_" + this.m_MapData.MusicID2 + "不存在");
    //			return;
    //		}
    //		AudioClip audioClip2 = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip2 == null)
    //		{
    //			Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		if (this.m_MapData.emMusicMode == ENUM_MusicMode.ONCE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB(audioClip, audioClip2, 0.5f, fadeTime);
    //			return;
    //		}
    //		if (this.m_MapData.emMusicMode == ENUM_MusicMode.CIRCLE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB_ABLoop(audioClip, audioClip2, 0.5f, fadeTime);
    //			return;
    //		}
    //		MusicControlSystem.Fade_PlayBackgroundMusicAB_BLoop(audioClip, audioClip2, 0.5f, fadeTime);
    //	}

    //	public void PlayMapMusic(int music1, int music2, ENUM_MusicMode mode)
    //	{
    //		S_MusicData data = GameDataDB.MusicDB.GetData(music1);
    //		if (data == null)
    //		{
    //			Debug.Log("LoadMusicData_" + this.m_MapData.MusicID1 + "不存在");
    //			return;
    //		}
    //		AudioClip audioClip = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip == null)
    //		{
    //			Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		data = GameDataDB.MusicDB.GetData(music2);
    //		if (data == null)
    //		{
    //			Debug.Log("LoadMusicData_" + this.m_MapData.MusicID2 + "不存在");
    //			return;
    //		}
    //		AudioClip audioClip2 = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip2 == null)
    //		{
    //			Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		if (mode == ENUM_MusicMode.ONCE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB(audioClip, audioClip2, 0.5f, 0.5f);
    //			return;
    //		}
    //		if (mode == ENUM_MusicMode.CIRCLE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB_ABLoop(audioClip, audioClip2, 0.5f, 0.5f);
    //			return;
    //		}
    //		MusicControlSystem.Fade_PlayBackgroundMusicAB_BLoop(audioClip, audioClip2, 0.5f, 0.5f);
    //	}

    public void Update()
    {
        this.UpdaeInput();
        //this.UpdateCursor();
        //this.UpdateFollowPet();
        //this.UpdaeReStartPos();
        //this.UpdaePlayMusic();
        //this.UpdaeNoFighTime();
        //this.UpdateUnloadResource();
        //if (this.m_OpenMenuTime > 0f)
        //{
        //    this.m_OpenMenuTime -= Time.deltaTime;
        //    if (this.m_OpenMenuTime <= 0f)
        //    {
        //        this.m_OpenMenuTime = 0f;
        //    }
        //}
        //Swd6Application.instance.m_GameObjSystem.UpdateAllMapObj();
        //if (this.m_GameApp.gameStateService.getCurrentState().name == "ExploreState")
        //{
        //    UI_PartnerTalkDialog.Instance.UpdateTalk();
        //}
    }

    //	private void UpdateUnloadResource()
    //	{
    //		if (this.m_ResourceUnLoadTime == 0f)
    //		{
    //			return;
    //		}
    //		this.m_ResourceUnLoadTime -= Time.deltaTime;
    //		if (this.m_ResourceUnLoadTime <= 0f)
    //		{
    //			this.m_ResourceUnLoad = false;
    //			this.m_ResourceUnLoadTime = 0f;
    //		}
    //	}

    //	private void UpdaeNoFighTime()
    //	{
    //		if (this.m_NoFightTime == 0f)
    //		{
    //			return;
    //		}
    //		this.m_NoFightTime -= Time.deltaTime;
    //		if (this.m_NoFightTime <= 0f)
    //		{
    //			this.m_NoFightTime = 0f;
    //		}
    //	}

    //	private void UpdaePlayMusic()
    //	{
    //		if (this.m_PlayMusicDelayTime > 0f)
    //		{
    //			this.m_PlayMusicDelayTime -= Time.deltaTime;
    //			if (this.m_PlayMusicDelayTime <= 0f)
    //			{
    //				this.m_PlayMusicDelayTime = 0f;
    //				MusicControlSystem.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
    //				this.PlayMusic(1f);
    //			}
    //		}
    //	}

    //	private void UpdaeReStartPos()
    //	{
    //		if (!this.LockPlayer)
    //		{
    //			if (this.PlayerController == null)
    //			{
    //				return;
    //			}
    //			if (this.PlayerController.IsGround() && !this.m_bSetReStarPos)
    //			{
    //				this.m_ReStartPos = this.PlayerController.Pos;
    //				Vector3 vector = this.PlayerController.transform.forward.normalized;
    //				vector.y = 0f;
    //				vector *= -0.5f;
    //				this.m_ReStartPos += vector;
    //				this.m_ReStartPos.y = this.m_ReStartPos.y + 0.3f;
    //			}
    //			if (this.PlayerController.IsJump() && !this.m_bSetReStarPos)
    //			{
    //				this.m_bSetReStarPos = true;
    //				this.m_ReStartPos = this.PlayerController.Pos;
    //				Vector3 vector2 = this.PlayerController.transform.forward.normalized;
    //				vector2.y = 0f;
    //				vector2 *= -0.5f;
    //				this.m_ReStartPos += vector2;
    //				this.m_ReStartPos.y = this.m_ReStartPos.y + 0.3f;
    //				return;
    //			}
    //			if (!this.PlayerController.IsJump())
    //			{
    //				this.m_bSetReStarPos = false;
    //			}
    //		}
    //	}

    //	public IEnumerator QuickSave()
    //	{
    //		this.LockPlayer = true;
    //		yield return this.m_GameApp.StartCoroutine(this.m_GameApp.BeginScreenShot(true));
    //		UI_GameSaveLoadMenu.Instance.OpenSave(0);
    //		yield return null;
    //		yield break;
    //	}

    private void UpdaeInput()
    {
        //if (this.m_GameApp.gameStateService.getCurrentState().name != "ExploreState")
        //{
        //    return;
        //}
        //if (this.LockPlayer)
        //{
        //    if (Input.GetKeyDown(KeyCode.H))
        //    {
        //        bool flag = this.PlayerController.HideRole;
        //        if (this.m_RidePetController != null)
        //        {
        //            flag = this.m_RidePetController.Hide;
        //            if (this.m_RidePetController.m_BeginDown || this.m_RidePetController.m_BeginRise)
        //            {
        //                return;
        //            }
        //        }
        //        if (!UI_Explore.Instance.IsVisible() && flag)
        //        {
        //            this.SetCameraDOFEffect(true);
        //            GameInput.m_IsDelayPress = true;
        //            UI_SmallMap.Instance.Show();
        //            UI_Explore.Instance.Show();
        //            this.LockPlayer = false;
        //            if (this.m_RidePetController != null)
        //            {
        //                this.m_RidePetController.Hide = false;
        //                return;
        //            }
        //            this.PlayerController.HideRole = false;
        //            if (this.AmberObj)
        //            {
        //                this.AmberObj.GetComponent<M_AmberController>().SetRender(true);
        //            }
        //        }
        //    }
        //    return;
        //}
        //if (this.PlayerController.IsJump())
        //{
        //    return;
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    GameObject gameObject = GameObject.Find("Main Camera");
        //    if (gameObject == null)
        //    {
        //        gameObject = GameObject.FindWithTag("MainCamera");
        //    }
        //    M_PlayerMouseOrbit x = gameObject.GetComponent<M_PlayerMouseOrbit>();
        //    if (x == null)
        //    {
        //        x = gameObject.AddComponent<M_PlayerMouseOrbit>();
        //    }
        //    bool flag2 = this.PlayerController.HideRole;
        //    if (this.m_RidePetController != null)
        //    {
        //        flag2 = this.m_RidePetController.Hide;
        //        if (this.m_RidePetController.m_BeginDown || this.m_RidePetController.m_BeginRise)
        //        {
        //            return;
        //        }
        //    }
        //    if (UI_Explore.Instance.IsVisible())
        //    {
        //        this.SetCameraDOFEffect(false);
        //        GameInput.m_IsDelayPress = false;
        //        UI_SmallMap.Instance.Hide();
        //        UI_Explore.Instance.Hide();
        //        UI_ZoneMap.Instance.Hide();
        //    }
        //    else if (!flag2)
        //    {
        //        this.PlayerController.HideRole = true;
        //        if (this.m_RidePetController != null)
        //        {
        //            this.m_RidePetController.Hide = true;
        //        }
        //        this.SetCameraDOFEffect(true);
        //        GameInput.m_IsDelayPress = true;
        //        this.LockPlayer = true;
        //        if (this.AmberObj)
        //        {
        //            this.AmberObj.GetComponent<M_AmberController>().SetRender(false);
        //        }
        //    }
        //    else
        //    {
        //        this.SetCameraDOFEffect(true);
        //        GameInput.m_IsDelayPress = true;
        //        UI_SmallMap.Instance.Show();
        //        UI_Explore.Instance.Show();
        //        if (this.m_RidePetController != null)
        //        {
        //            this.m_RidePetController.Hide = false;
        //        }
        //        else
        //        {
        //            this.PlayerController.HideRole = false;
        //        }
        //        if (this.AmberObj)
        //        {
        //            this.AmberObj.GetComponent<M_AmberController>().SetRender(true);
        //        }
        //        this.LockPlayer = false;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.F9) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.R3))
        //{
        //    this.m_GameApp.StartCoroutine(this.QuickSave());
        //}
        //if (Input.GetKeyDown(KeyCode.F10) | GameInput.GetJoyKeyDown(JOYSTICK_KEY.L3))
        //{
        //    this.LockPlayer = true;
        //    UI_GameSaveLoadMenu.Instance.OpenLoad();
        //}
        //if (!GameInput.GetKeyActionDown(KEY_ACTION.MENU))
        //{
        //    if (GameInput.GetKeyActionDown(KEY_ACTION.MAP))
        //    {
        //        if (this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID == 1000)
        //        {
        //            UI_BigMap.Instance.Open();
        //        }
        //        else
        //        {
        //            UI_ZoneMap.Instance.Open();
        //        }
        //        MusicControlSystem.PlayUISound(4017, 1);
        //    }
        //    return;
        //}
        //if (UI_ZoneMap.Instance.IsVisible())
        //{
        //    return;
        //}
        //if (UI_BigMap.Instance.IsVisible())
        //{
        //    return;
        //}
        //if (UI_GameSaveLoadMenu.Instance.IsVisible())
        //{
        //    return;
        //}
        //GameInput.KeyInput = true;
        //this.OpenGameMainMenu();
    }

    //	private void UpdaeDebugInput()
    //	{
    //		Input.GetKeyDown(KeyCode.F4);
    //		if (Input.GetKeyDown(KeyCode.F5))
    //		{
    //			this.m_GameApp.ReloadObjc();
    //			Debug.Log("ReloadObjc!!");
    //		}
    //		if (Input.GetKeyDown(KeyCode.F6) && !this.LockPlayer)
    //		{
    //			UI_GameGMMenu.Instance.Open();
    //			this.LockPlayer = true;
    //		}
    //		if (Input.GetKeyDown(KeyCode.F7) && !this.LockPlayer)
    //		{
    //			UI_GameNpcListMenu.Instance.Show();
    //			this.LockPlayer = true;
    //		}
    //		if (Input.GetKeyDown(KeyCode.F8) && !this.LockPlayer)
    //		{
    //			UI_GameChangeZoneMenu.Instance.Show();
    //			this.LockPlayer = true;
    //		}
    //		if (Input.GetKeyDown(KeyCode.F11) && !this.LockPlayer)
    //		{
    //			this.m_UI_GameFlagMenu = (GUIManager.instance.GetGUI(typeof(UI_GameFlagMenu).Name) as UI_GameFlagMenu);
    //			this.m_UI_GameFlagMenu.Open();
    //			this.LockPlayer = true;
    //		}
    //		Input.GetKeyDown(KeyCode.Q);
    //	}

    //	public void UpdateCursor()
    //	{
    //	}

    //	public void OpenGameMainMenu()
    //	{
    //		if (this.LockPlayer)
    //		{
    //			return;
    //		}
    //		if (this.PlayerController.IsJump())
    //		{
    //			return;
    //		}
    //		if (this.m_OpenMainMenu)
    //		{
    //			return;
    //		}
    //		if (this.m_OpenMenuTime > 0f)
    //		{
    //			return;
    //		}
    //		this.m_OpenMainMenu = true;
    //		if (this.m_GameApp.gameStateService.getCurrentState().name != "ExploreState")
    //		{
    //			return;
    //		}
    //		MusicControlSystem.PlayUISound(4023, 1);
    //		this.m_GameApp.StartCoroutine(this.m_GameApp.OpenGameMainMenu());
    //	}

    public void SetCharacterCollisionController()
    {
        //if ((this.m_MapData.emType == ENUM_MapType.Town || this.m_MapData.emType == ENUM_MapType.House) && (this.m_GameApp.m_GameDataSystem.m_PlayerID == 1 || this.m_GameApp.m_GameDataSystem.m_PlayerID == 6))
        //{
        //    this.PlayerObj.AddComponent<M_CharacterCollisionController>();
        //}
    }

    public void SetCameraLookTarget(bool bInit)
    {
        if (GameEntry.Instance.m_GameObjSystem.PlayerObj == null)
        {
            return;
        }
        GameObject gameObject = GameObject.Find("Main Camera");
        if (gameObject == null)
        {
            gameObject = GameObject.FindWithTag("MainCamera");
        }
        if (gameObject == null)
        {
            Debug.LogError("找不到Main Camera");
            return;
        }
        this.m_MainCameraGameObj = gameObject;
        //Component component = gameObject.GetComponent("M_MiniMapCamera");
        //if (component != null)
        //{
        //    UnityEngine.Object.Destroy(component);
        //}
        //M_MouseOrbit component2 = gameObject.GetComponent<M_MouseOrbit>();
        //if (component2 != null)
        //{
        //    component2.enabled = false;
        //}
        this.m_PlayerMouseOrbit = gameObject.GetComponent<M_PlayerMouseOrbit>();
        if (this.m_PlayerMouseOrbit == null)
        {
            this.m_PlayerMouseOrbit = gameObject.AddComponent<M_PlayerMouseOrbit>();
        }
        if (bInit)
        {
            this.m_PlayerMouseOrbit.Init();
            this.m_PlayerMouseOrbit.SetNormalMode();
        }
        //DepthOfFieldScatter component3 = gameObject.GetComponent<DepthOfFieldScatter>();
        Transform[] componentsInChildren = GameEntry.Instance.m_GameObjSystem.PlayerObj.transform.GetComponentsInChildren<Transform>();
        foreach (Transform transform in componentsInChildren)
        {
            if (transform.name == "CamPos")
            {
                //if (component3 != null)
                //{
                //    component3.focalTransform = transform;
                //}
                this.m_PlayerMouseOrbit.m_Target = transform;
                break;
            }
        }
        Camera m_Camera=gameObject.GetComponent<Camera>();
        m_Camera.orthographic = false;
        int num = 198656;
        num = ~num;
        m_Camera.cullingMask = num;
        //this.SetCameraDofEffectLookTarget(this.m_GameApp.m_GameObjSystem.PlayerObj);
    }

    //	public void SetCameraLookShootTarget()
    //	{
    //		if (this.m_GameApp.m_GameObjSystem.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		M_PlayerMouseOrbit m_PlayerMouseOrbit = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //		if (m_PlayerMouseOrbit == null)
    //		{
    //			m_PlayerMouseOrbit = gameObject.AddComponent<M_PlayerMouseOrbit>();
    //		}
    //		Transform[] componentsInChildren = this.m_GameApp.m_GameObjSystem.PlayerObj.transform.GetComponentsInChildren<Transform>();
    //		Transform[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			Transform transform = array[i];
    //			if (transform.name == "shoot point")
    //			{
    //				m_PlayerMouseOrbit.m_Target = transform;
    //				return;
    //			}
    //		}
    //	}

    //	public void SetCameraLookRidePetTarget(GameObject RidePetObj)
    //	{
    //		if (RidePetObj == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		M_PlayerMouseOrbit m_PlayerMouseOrbit = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //		if (m_PlayerMouseOrbit == null)
    //		{
    //			m_PlayerMouseOrbit = gameObject.AddComponent<M_PlayerMouseOrbit>();
    //		}
    //		Transform[] componentsInChildren = RidePetObj.transform.GetComponentsInChildren<Transform>();
    //		Transform[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			Transform transform = array[i];
    //			if (transform.name == "camera view point")
    //			{
    //				m_PlayerMouseOrbit.m_Target = transform;
    //				break;
    //			}
    //		}
    //		if (this.m_MapData.emType == ENUM_MapType.World)
    //		{
    //			m_PlayerMouseOrbit.SetFlyMode();
    //		}
    //		this.SetCameraDofEffectLookTarget(RidePetObj);
    //	}

    /// <summary>
    /// 激活主摄像机
    /// </summary>
    /// <param name="enable"></param>
    public void EnableMainCamera(bool enable)
    {
        GameObject gameObject = GameObject.Find("Main Camera");
        if (gameObject == null)
        {
            gameObject = GameObject.FindWithTag("MainCamera");
        }
        if (gameObject)
        {
            Camera component = gameObject.GetComponent<Camera>();
            if (component)
            {
                component.enabled = enable;
            }
            //AudioListener component2 = gameObject.GetComponent<AudioListener>();
            //if (component2)
            //{
            //    UnityEngine.Object.Destroy(component2);
            //}
        }
    }

    //	public void SetCameraDofEffectLookTarget(GameObject targetObj)
    //	{
    //		if (targetObj == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		if (gameObject)
    //		{
    //			DepthOfFieldScatter component = gameObject.GetComponent<DepthOfFieldScatter>();
    //			if (component != null)
    //			{
    //				Transform[] componentsInChildren = targetObj.transform.GetComponentsInChildren<Transform>();
    //				Transform[] array = componentsInChildren;
    //				for (int i = 0; i < array.Length; i++)
    //				{
    //					Transform transform = array[i];
    //					if (transform.name == "camera view point")
    //					{
    //						component.focalTransform = transform;
    //						return;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void SetCameraDOFEffect(bool enabled)
    //	{
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		if (gameObject)
    //		{
    //			DepthOfFieldScatter component = gameObject.GetComponent<DepthOfFieldScatter>();
    //			if (component != null)
    //			{
    //				component.enabled = enabled;
    //			}
    //		}
    //	}

    //	public void SetAmberTargetPos()
    //	{
    //		if (this.m_GameApp.m_GameObjSystem.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		if (this.AmberObj == null)
    //		{
    //			return;
    //		}
    //		Transform[] componentsInChildren = this.m_GameApp.m_GameObjSystem.PlayerObj.transform.GetComponentsInChildren<Transform>();
    //		Transform[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			Transform transform = array[i];
    //			if (transform.name == "pet point")
    //			{
    //				this.m_AmberController.m_Target = transform;
    //				break;
    //			}
    //		}
    //		this.m_AmberController.SetRender(true);
    //	}

    //	public void SetPlayerPointLight(bool enable)
    //	{
    //		if (this.m_GameApp.m_GameObjSystem.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = GameObject.Find("PlayerPointLight");
    //		if (gameObject == null)
    //		{
    //			gameObject = new GameObject("PlayerPointLight");
    //		}
    //		Light light = gameObject.GetComponent<Light>();
    //		if (light == null)
    //		{
    //			light = gameObject.AddComponent<Light>();
    //		}
    //		int num = 256;
    //		num = ~num;
    //		light.cullingMask = num;
    //		light.range = 13.5f;
    //		light.color = new Color(0.992156863f, 0.8039216f, 0.423529416f);
    //		light.intensity = 0.5f;
    //		light.enabled = enable;
    //		light.type = LightType.Point;
    //		gameObject.transform.parent = this.PlayerObj.transform;
    //		gameObject.transform.position = this.PlayerObj.transform.position + new Vector3(0f, 2f, 0f);
    //	}

    //	public void SwitchPlayer()
    //	{
    //		this.EndActionSkill();
    //		Vector3 position = this.PlayerObj.transform.position;
    //		float y = this.PlayerObj.transform.eulerAngles.y;
    //		this.m_GameApp.m_GameObjSystem.RemovePlayerGameObj();
    //		position.y += 0.01f;
    //		this.PlayerObj = this.m_GameApp.m_GameObjSystem.CreatePlayerGameObj(this.m_GameApp.m_GameDataSystem.m_PlayerID, position, y);
    //		TransformTool.SetLayerRecursively(this.PlayerObj.transform, 8);
    //		this.SetCameraLookTarget();
    //		this.SetAmberTargetPos();
    //		if (this.m_GameApp.m_GameDataSystem.GetFlag(52))
    //		{
    //			this.SetPlayerPointLight(true);
    //		}
    //	}

    //private void m_BattleArea(int mapID)
    //{
    //    this.BattleStep = 0f;
    //    this.m_MaxBattleStep = 0f;
    //    this.m_BattelTriggerTime = 0f;
    //    this.m_TriggerName = null;
    //    //this.m_BattleArea.Clear();
    //    //GameDataDB.BattleAreaDB.ResetByOrder();
    //    //int dataSize = GameDataDB.BattleAreaDB.GetDataSize();
    //    //for (int i = 0; i < dataSize; i++)
    //    //{
    //    //    S_BattleArea dataByOrder = GameDataDB.BattleAreaDB.GetDataByOrder();
    //    //    if (dataByOrder != null && dataByOrder.MapID == mapID)
    //    //    {
    //    //        this.m_BattleArea.Add(dataByOrder);
    //    //    }
    //    //}
    //    //if (this.m_AmberController != null)
    //    //{
    //    //    this.m_AmberController.SetFightWarring(false);
    //    //}
    //}

    //	public void AddBattleStep()
    //	{
    //		if (this.m_TriggerName == null)
    //		{
    //			return;
    //		}
    //		if (this.m_MaxBattleStep == 0f)
    //		{
    //			return;
    //		}
    //		if (this.LockPlayer)
    //		{
    //			return;
    //		}
    //		if (this.m_GameApp.gameStateService.getCurrentState().name != "ExploreState")
    //		{
    //			return;
    //		}
    //		if (this.m_NoFightTime > 0f)
    //		{
    //			return;
    //		}
    //		this.m_BattelTriggerTime += Time.deltaTime;
    //		if (this.m_OpenMainMenu)
    //		{
    //			return;
    //		}
    //		float num;
    //		if (this.PlayerController.m_IsDash)
    //		{
    //			num = 1f;
    //		}
    //		else
    //		{
    //			num = 1.5f;
    //		}
    //		if (this.m_BattelTriggerTime >= num)
    //		{
    //			Vector3 prePlayerPos = this.m_PrePlayerPos;
    //			Vector3 pos = this.PlayerController.Pos;
    //			prePlayerPos.y = 0f;
    //			pos.y = 0f;
    //			float distXZ = GameMath.GetDistXZ(prePlayerPos, pos);
    //			if (distXZ <= 10f)
    //			{
    //				this.m_BattleStepCount += distXZ;
    //			}
    //			this.m_PrePlayerPos = this.PlayerController.Pos;
    //			this.m_BattelTriggerTime = 0f;
    //			this.ChanceOfBattle(this.m_TriggerName);
    //		}
    //		if (this.m_BattleID > 0 && !this.PlayerController.IsJump())
    //		{
    //			this.EnterFight();
    //		}
    //	}

    public void EnterFight(int battleId, bool bHit)
    {
        if (this.m_BattleID > 0)
        {
            return;
        }

        //this.m_GameApp.m_SaveloadSystem.AutoSave1(ENUM_AUTOSAVETYPE.Fight);
        S_BattleRate data = GameDataDB.BattleRateDB.GetData(battleId);
        if (data == null)
        {
            Debug.Log("EnterFight::讀取BattleRateDB表錯誤_" + battleId);
            return;
        }
        int fightPlayerID = 0;
        int num = 0;
        int num2 = 0;
        int num3 = 4;
        int num4 = UnityEngine.Random.Range(0, 100);
        if (data.Flag.Count > 0 && GameEntry.Instance.m_GameDataSystem.GetFlag(data.Flag[0]))
        {
            num2 = 5;
            num3 = data.Group.Count;
        }
        if (num3 > data.Group.Count)
        {
            num3 = data.Group.Count;
        }
        for (int i = num2; i < num3; i++)
        {
            if (data.Group[i].GroupID != 0)
            {
                num += data.Group[i].GroupRate;
                if (num4 <= num)
                {
                    this.m_BattleID = data.Group[i].GroupID;
                    //if (bHit)
                    //{
                    //    fightPlayerID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
                    //}
                    FightSystem.Instance.Fight(this.m_BattleID, fightPlayerID);
                    break;
                }
            }
        }
        this.LockPlayer = true;
        //UI_ZoneMap.Instance.Hide();
    }

    public void SetBattleAreaState(string triggerName)
    {
        Debug.Log("进入战斗");
        //if (GameEntry.Instance.m_GameDataSystem.GetFlag(21))
        //{
        //    return;
        //}
        //this.m_MaxBattleStep = 0f;
        //if (triggerName == null)
        //{
        //    return;
        //}
        //this.m_TriggerName = triggerName;
        foreach (S_BattleArea current in this.m_BattleArea)
        {
            if (current.TriggerName == triggerName)
            {
                for (int i = 0; i < 4; i++)
                {
                    S_BattleEncounter s_BattleEncounter = current.Encounter[i];
                    if (s_BattleEncounter.Step > 100)
                    {
                        this.m_MaxBattleStep += 100f;
                    }
                    else
                    {
                        this.m_MaxBattleStep += (float)s_BattleEncounter.Step;
                    }
                }
                //if (!GameEntry.Instance.m_GameDataSystem.GetFlag(23) && this.m_AmberController != null)
                //{
                //    this.m_AmberController.SetFightWarring(true);
                //}
                return;
            }
        }
        //if (this.m_AmberController != null)
        //{
        //    this.m_AmberController.SetFightWarring(false);
        //}
    }

    //	public void ExitBattleArea(string triggerName)
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(21))
    //		{
    //			return;
    //		}
    //		if (this.m_TriggerName == triggerName || triggerName == null)
    //		{
    //			this.ClearBattleInfo();
    //			if (this.m_AmberController != null)
    //			{
    //				this.m_AmberController.SetFightWarring(false);
    //			}
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				Debug.Log("離開戰鬥區域_" + triggerName);
    //			}
    //		}
    //	}

    //	public void ClearBattleInfo()
    //	{
    //		this.m_BattleID = 0;
    //		this.m_MaxBattleStep = 0f;
    //		this.m_TriggerName = null;
    //	}

    //	public void ChanceOfBattle(string triggerName)
    //	{
    //		int max = 2000;
    //		int num = 0;
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(21))
    //		{
    //			return;
    //		}
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.SetFightWarring(true);
    //		}
    //		foreach (S_BattleArea current in this.m_BattleArea)
    //		{
    //			if (current.TriggerName == triggerName)
    //			{
    //				if (current.Flag.Count > 0)
    //				{
    //					bool flag = false;
    //					for (int i = 0; i < current.Flag.Count; i++)
    //					{
    //						if (!Swd6Application.instance.m_GameDataSystem.GetFlag(current.Flag[i]))
    //						{
    //							flag = true;
    //							break;
    //						}
    //					}
    //					if (flag)
    //					{
    //						continue;
    //					}
    //				}
    //				int j = 0;
    //				while (j < 5)
    //				{
    //					S_BattleEncounter s_BattleEncounter = current.Encounter[j];
    //					num += s_BattleEncounter.Step;
    //					if (this.BattleStep < (float)num)
    //					{
    //						if (s_BattleEncounter.Chance == 0)
    //						{
    //							break;
    //						}
    //						if (this.m_AmberController)
    //						{
    //							max = this.m_AmberController.m_Rand;
    //						}
    //						int num2 = UnityEngine.Random.Range(0, max);
    //						if (num2 >= s_BattleEncounter.Chance)
    //						{
    //							break;
    //						}
    //						int index = UnityEngine.Random.Range(0, current.Group.Count);
    //						if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //						{
    //							Debug.Log("戰鬥觸發步數_" + this.BattleStep);
    //							Debug.Log("戰鬥觸發機率_" + num2);
    //							Debug.Log("戰鬥觸發機率1_" + s_BattleEncounter.Chance);
    //							Debug.Log("戰鬥觸發編號_" + current.Group[index]);
    //						}
    //						this.m_BattleID = current.Group[index];
    //						if (!this.PlayerController.IsJump())
    //						{
    //							this.EnterFight();
    //							break;
    //						}
    //						break;
    //					}
    //					else
    //					{
    //						j++;
    //					}
    //				}
    //				break;
    //			}
    //		}
    //	}

    //	public void BeginNoFight(float time)
    //	{
    //		this.m_NoFightTime = time;
    //		this.BattleStep = 0f;
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.SetFightWarring(false);
    //		}
    //	}

    //	public bool ExpendStaminaBar(bool costImmediate)
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(22))
    //		{
    //			return true;
    //		}
    //		if (!Swd6Application.instance.m_GameDataSystem.GetFlag(41) && this.m_MapData.emType != ENUM_MapType.World)
    //		{
    //			return true;
    //		}
    //		if (!UI_Explore.Instance.ExpendStaminaBar(this.m_CostStamina, costImmediate))
    //		{
    //			this.EndActionSkill();
    //			return false;
    //		}
    //		return true;
    //	}

    //	public void RestoreStaminaBar()
    //	{
    //		if (this.m_bUseActionSkill)
    //		{
    //			return;
    //		}
    //		if (this.PlayerController.IsJump())
    //		{
    //			return;
    //		}
    //		UI_Explore.Instance.RestoreStaminaBar();
    //	}

    //	public void UseActionSkill()
    //	{
    //		this.UpdateHitDamageDelayTime();
    //		this.UpdateGhostEye();
    //		this.UpdateSuperJump();
    //		this.UpdateDespell();
    //		this.UpdateBreak();
    //		this.UpdateShoot();
    //	}

    //	public void AddHitDamageDelayTime()
    //	{
    //		if (this.LockPlayer)
    //		{
    //			return;
    //		}
    //		this.m_HitDamageDelayTime = 0.25f;
    //		this.LockPlayer = true;
    //		this.PlayerController.SetRenderColor(new Color(1f, 0f, 0f));
    //	}

    //	public void UpdateHitDamageDelayTime()
    //	{
    //		if (this.m_HitDamageDelayTime > 0f)
    //		{
    //			if (UnityEngine.Random.Range(0, 2) == 0)
    //			{
    //				this.PlayerController.SetRenderColor(new Color(1f, 0f, 0f));
    //			}
    //			else
    //			{
    //				this.PlayerController.SetRenderColor(new Color(1f, 1f, 1f));
    //			}
    //			this.m_HitDamageDelayTime -= Time.deltaTime;
    //			if (this.m_HitDamageDelayTime <= 0f)
    //			{
    //				this.PlayerController.SetRenderColor(new Color(1f, 1f, 1f));
    //				this.m_HitDamageDelayTime = 0f;
    //				this.LockPlayer = false;
    //			}
    //		}
    //	}

    //	public void UpdateSuperJump()
    //	{
    //		if (!this.m_BeginSuperJump)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 0 && !this.PlayerController.IsJump())
    //		{
    //			JumpAndIdle component = this.PlayerObj.GetComponent<JumpAndIdle>();
    //			component.enabled = true;
    //			this.m_BeginSuperJump = false;
    //			this.m_ActionSkillStep = 1;
    //			this.PlayerController.PlayIdleMotion();
    //		}
    //	}

    //	public void UpdateDespell()
    //	{
    //		if (!this.m_BeginDispell)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 0)
    //		{
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController.IsMotionFinished(709))
    //			{
    //				this.m_ActionEffect = EffectGenerator.CreateEffectGameObject("ep04_innate_B");
    //				this.m_ActionEffect.transform.position = this.ActionTarget.transform.position;
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(710);
    //				UI_Explore.Instance.OpenUnlockHUD();
    //				this.m_ActionSkillStep++;
    //				return;
    //			}
    //		}
    //		else
    //		{
    //			int arg_96_0 = this.m_ActionSkillStep;
    //		}
    //	}

    //	public void UpdateShoot()
    //	{
    //		if (!this.m_bBeginShoot)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 0)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionSkillStep > 0 && this.ActionTarget && this.m_ActionSkillTime > 0f)
    //		{
    //			this.m_ActionSkillTime -= Time.deltaTime;
    //			if (this.m_ActionSkillTime <= 0f)
    //			{
    //				this.m_ActionSkillTime = 0f;
    //				this.m_ActionEDEffect = EffectGenerator.CreateEffectGameObject("ep03_innate_B");
    //				Vector3 b = Vector3.zero;
    //				if (this.m_ActionSkillStep != 1)
    //				{
    //					b = this.m_ShootOffset;
    //				}
    //				this.m_ActionEDEffect.transform.position = this.m_ShootTarget.transform.position + b;
    //				UnityEngine.Object.Destroy(this.m_ActionEDEffect, 1f);
    //				UI_Explore.Instance.SetCanShoot();
    //				if (this.m_ActionSkillStep == 3)
    //				{
    //					this.m_ActionSkillStep = 0;
    //				}
    //			}
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 1)
    //		{
    //			this.ClearShootState();
    //			M_GameRoleBase component = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				component.Invalid = true;
    //				S_NpcData data = GameDataDB.NpcDB.GetData(component.RoleID);
    //				if (data != null)
    //				{
    //					if (data.emActionHint != ENUM_ActionHint.Shoot)
    //					{
    //						return;
    //					}
    //					S_Trap data2 = GameDataDB.TrapDB.GetData(data.DataID);
    //					if (data2 != null && data2.FinishFlag > 0)
    //					{
    //						this.m_GameApp.m_GameDataSystem.FlagON(data2.FinishFlag);
    //					}
    //				}
    //			}
    //			UI_Explore.Instance.ShowActionHint(this.ActionTarget, ENUM_ActionHint.Null, false);
    //			this.m_ShootTarget.SendMessage("DoTalk", SendMessageOptions.DontRequireReceiver);
    //			this.m_ShootTarget = null;
    //		}
    //		this.m_ActionSkillStep = 0;
    //		this.m_ActionSkillTime = 0f;
    //		this.ActionTarget = null;
    //	}

    //	public void UpdateBreak()
    //	{
    //		if (!this.m_BeginBreak)
    //		{
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 0)
    //		{
    //			if (this.m_ActionSkillTime > 0f)
    //			{
    //				this.m_ActionSkillTime -= Time.deltaTime;
    //				if (this.m_ActionSkillTime <= 0f)
    //				{
    //					this.m_ActionSkillTime = 0f;
    //					Transform transform = this.m_PlayerGameObj.transform.Find("p05-01-cloth-map-f");
    //					if (transform)
    //					{
    //						transform.gameObject.SetActive(true);
    //					}
    //					transform = this.m_PlayerGameObj.transform.Find("p05-01-meta-map-f");
    //					if (transform)
    //					{
    //						transform.gameObject.SetActive(true);
    //					}
    //					transform = this.m_PlayerGameObj.transform.Find("p05-01-weap-map-f");
    //					if (transform)
    //					{
    //						transform.gameObject.SetActive(true);
    //					}
    //					transform = this.m_PlayerGameObj.transform.Find("p05-01-cloth-map");
    //					if (transform)
    //					{
    //						transform.gameObject.SetActive(false);
    //					}
    //					transform = this.m_PlayerGameObj.transform.Find("p05-01-skin-map");
    //					if (transform)
    //					{
    //						transform.gameObject.SetActive(false);
    //					}
    //				}
    //			}
    //			if (this.PlayerController.IsMotionFinished(716))
    //			{
    //				if (this.m_GameApp.m_GameDataSystem.m_PlayerID == 4)
    //				{
    //					this.m_ActionEffect = EffectGenerator.CreateEffectGameObject("ep05_innate_B");
    //					this.m_ActionEffect.transform.position = this.PlayerController.Pos;
    //				}
    //				this.PlayerController.PlayMotion(717);
    //				UI_Explore.Instance.OpenDamageHUD();
    //				this.m_ActionSkillStep++;
    //				return;
    //			}
    //		}
    //		else if (this.m_ActionSkillStep == 1)
    //		{
    //			float breakDamage = UI_Explore.Instance.GetBreakDamage();
    //			float speed = 1f + breakDamage / 100f * this.PlayerController.m_BreakSpeed;
    //			this.PlayerController.SetMotionSpeed(717, speed);
    //			float num = 0.5f - breakDamage / 100f * 0.25f;
    //			this.m_ActionSkillTime += Time.deltaTime;
    //			if (this.m_ActionSkillTime >= num)
    //			{
    //				this.m_ActionSkillTime = 0f;
    //				if (this.m_GameApp.m_GameDataSystem.m_PlayerID == 4)
    //				{
    //					this.m_ActionEDEffect = EffectGenerator.CreateEffectGameObject("ep05_innate_C");
    //				}
    //				else
    //				{
    //					this.m_ActionEDEffect = EffectGenerator.CreateEffectGameObject("ep06_innate_B");
    //				}
    //				Transform transform2 = TransformTool.SearchHierarchyForBone(this.m_ActionTarget.transform, "breakeffect");
    //				if (transform2 == null)
    //				{
    //					transform2 = TransformTool.SearchHierarchyForBone(this.m_PlayerGameObj.transform, "1006");
    //				}
    //				this.SetCastEffect(transform2, this.m_ActionEDEffect, this.m_PlayerGameObj.transform.forward);
    //				if (UnityEngine.Random.Range(0, 2) == 0)
    //				{
    //					MusicControlSystem.PlaySound(4040, 1);
    //				}
    //				else
    //				{
    //					MusicControlSystem.PlaySound(4047, 1);
    //				}
    //			}
    //			if (GameInput.GetKeyActionDown(KEY_ACTION.ACTION) || GameInput.IsPressAllConfirmKey())
    //			{
    //				UI_Explore.Instance.AddBreakDamage();
    //				breakDamage = UI_Explore.Instance.GetBreakDamage();
    //				if (breakDamage >= 100f)
    //				{
    //					this.m_ActionSkillStep = 2;
    //					this.PlayerController.PlayMotion(718);
    //					this.PlayerController.SetMotionSpeed(718, this.PlayerController.m_BreakSlowTime);
    //					return;
    //				}
    //			}
    //		}
    //		else if (this.m_ActionSkillStep == 2)
    //		{
    //			this.m_ActionSkillTime += Time.deltaTime;
    //			if (this.m_ActionSkillTime >= this.PlayerController.m_BreakSlowWaitTime)
    //			{
    //				this.m_ActionSkillTime = 0f;
    //				this.m_ActionSkillStep = 3;
    //				this.PlayerController.SetMotionSpeed(718, 1f);
    //				return;
    //			}
    //		}
    //		else if (this.m_ActionSkillStep == 3)
    //		{
    //			this.m_ActionSkillTime += Time.deltaTime;
    //			if (this.m_ActionSkillTime >= 0.5f)
    //			{
    //				this.m_ActionEDEffect = null;
    //				if (this.m_GameApp.m_GameDataSystem.m_PlayerID == 4)
    //				{
    //					this.m_ActionEDEffect = EffectGenerator.CreateEffectGameObject("ep05_innate_C");
    //				}
    //				else
    //				{
    //					this.m_ActionEDEffect = EffectGenerator.CreateEffectGameObject("ep06_innate_C");
    //				}
    //				Transform transform3 = TransformTool.SearchHierarchyForBone(this.m_ActionTarget.transform, "breakeffect");
    //				if (transform3 == null)
    //				{
    //					transform3 = TransformTool.SearchHierarchyForBone(this.m_PlayerGameObj.transform, "1006");
    //				}
    //				this.SetCastEffect(transform3, this.m_ActionEDEffect, this.m_PlayerGameObj.transform.forward);
    //				this.m_ActionSkillTime = 0f;
    //				this.BreakOver(true);
    //			}
    //		}
    //	}

    //	public void SetCastEffect(Transform sourceObj, GameObject effectObj, Vector3 dir)
    //	{
    //		if (sourceObj)
    //		{
    //			effectObj.transform.position = sourceObj.position;
    //			return;
    //		}
    //		effectObj.transform.position = this.PlayerController.Pos;
    //	}

    //	public bool CheckCanUseActionSkill()
    //	{
    //		return this.m_GameApp.m_GameDataSystem.GetFlag(41) && (Swd6Application.instance.IsDLC() || this.m_GameApp.m_GameDataSystem.GetFlag(30 + this.m_GameApp.m_GameDataSystem.m_PlayerID)) && (this.m_GameApp.m_GameDataSystem.m_PlayerID != 1 || this.m_GameApp.m_GameDataSystem.m_Stamina >= 30) && (this.m_GameApp.m_GameDataSystem.m_PlayerID != 2 || this.m_GameApp.m_GameDataSystem.m_Stamina >= 120) && (this.m_GameApp.m_GameDataSystem.m_PlayerID != 3 || this.m_GameApp.m_GameDataSystem.m_Stamina >= 90) && (this.m_GameApp.m_GameDataSystem.m_PlayerID != 4 || this.m_GameApp.m_GameDataSystem.m_Stamina >= 150) && (this.m_GameApp.m_GameDataSystem.m_PlayerID != 5 || this.m_GameApp.m_GameDataSystem.m_Stamina >= 60);
    //	}

    //	public void EndActionSkill()
    //	{
    //		if (this.m_bUseActionSkill)
    //		{
    //			MusicControlSystem.StopSound(4032);
    //			MusicControlSystem.PlaySound(4033, 1);
    //		}
    //		this.m_ActionSkillStep = 0;
    //		this.m_bUseActionSkill = false;
    //		this.m_CostStamina = 25;
    //		if (this.m_ActionEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionEffect);
    //			this.m_ActionEffect = null;
    //		}
    //		if (this.m_GhostEffect != null)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_GhostEffect);
    //			this.m_GhostEffect = null;
    //		}
    //	}

    //	public void UpdateGhostEye()
    //	{
    //		if (!this.m_bUseActionSkill)
    //		{
    //			return;
    //		}
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 30)
    //		{
    //			this.EndActionSkill();
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 0)
    //		{
    //			if (this.m_ActionSkillTime > 0f)
    //			{
    //				this.m_ActionSkillTime -= Time.deltaTime;
    //				if (this.m_ActionSkillTime <= 0f)
    //				{
    //					this.m_ActionSkillTime = 0f;
    //					this.m_ActionEffect = OtherElementGenerator.CreateOtherGameObject("GhostEffect");
    //					if (this.m_ActionEffect != null)
    //					{
    //						this.m_ActionEffect.transform.position = this.PlayerObj.transform.position;
    //						iTween.ScaleTo(this.m_ActionEffect, new Vector3(30f, 30f, 30f), 3f);
    //					}
    //				}
    //			}
    //			if (this.PlayerController.IsMotionFinished(707))
    //			{
    //				this.PlayerController.PlayIdleMotion();
    //				this.m_GhostEyeObjList.Clear();
    //				this.LockPlayer = false;
    //				this.m_ActionSkillStep++;
    //				this.m_ActionSkillTime = 1f;
    //				if (this.m_ActionSTEffect)
    //				{
    //					UnityEngine.Object.DestroyObject(this.m_ActionSTEffect);
    //					this.m_ActionSTEffect = null;
    //				}
    //			}
    //			return;
    //		}
    //		if (this.m_ActionSkillStep == 1)
    //		{
    //			if (this.m_ActionSkillTime > 0f)
    //			{
    //				this.m_ActionSkillTime -= Time.deltaTime;
    //				if (this.m_ActionSkillTime <= 0f)
    //				{
    //					this.m_GhostEffect = OtherElementGenerator.CreateOtherGameObject("Ghostring");
    //					if (this.m_GhostEffect != null)
    //					{
    //						this.m_GhostEffect.transform.position = this.PlayerObj.transform.position;
    //					}
    //					this.m_ActionSkillTime = 0f;
    //					this.m_ActionSkillStep++;
    //					MusicControlSystem.PlayLoopSound(4032);
    //				}
    //			}
    //			return;
    //		}
    //		if (this.m_ActionEffect)
    //		{
    //			this.m_ActionEffect.transform.position = this.PlayerObj.transform.position;
    //		}
    //		if (this.m_GhostEffect != null)
    //		{
    //			Transform transform = TransformTool.SearchHierarchyForBone(this.PlayerObj.transform, "1010");
    //			if (transform)
    //			{
    //				this.m_GhostEffect.transform.position = transform.transform.position;
    //			}
    //			else
    //			{
    //				this.m_GhostEffect.transform.position = this.PlayerObj.transform.position + new Vector3(0f, 0.2f, 0f);
    //			}
    //		}
    //		List<S_GameObjData> mapObjData = this.m_GameApp.m_GameObjSystem.GetMapObjData();
    //		foreach (S_GameObjData current in mapObjData)
    //		{
    //			if (!(current.GameObj == null) && !current.State.Test(ENUM_GameObjFlag.Disable) && current.State.Test(ENUM_GameObjFlag.Hide) && Vector3.Distance(current.GameObj.transform.position, this.PlayerObj.transform.position) <= 7f)
    //			{
    //				S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //				if (data != null && data.emActionHint == ENUM_ActionHint.GhostEye)
    //				{
    //					current.RoleBase.NoCollider = false;
    //					current.RoleBase.FadeOut = false;
    //					current.RoleBase.HideRole = false;
    //					UI_SmallMap.Instance.ShowTreasureIcon(current.Id);
    //					MusicControlSystem.PlayUISound(4005, 1);
    //					if (!this.m_GhostEyeObjList.Contains(current))
    //					{
    //						this.m_GhostEyeObjList.Add(current);
    //					}
    //				}
    //			}
    //		}
    //		this.m_CostStamina = 30;
    //		this.ExpendStaminaBar(false);
    //	}

    //	public void ResetGhostEyeBox()
    //	{
    //		List<S_GameObjData> mapObjData = this.m_GameApp.m_GameObjSystem.GetMapObjData();
    //		foreach (S_GameObjData current in mapObjData)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //			if (data != null && data.emActionHint == ENUM_ActionHint.GhostEye)
    //			{
    //				current.RoleBase.HideRole = true;
    //				current.RoleBase.NoCollider = true;
    //				current.RoleBase.SetShader("Chickenlord/FX/Forcefield Rim");
    //			}
    //		}
    //	}

    //	public void UseActionSkill_GhostEye()
    //	{
    //		if (this.m_bUseActionSkill)
    //		{
    //			if (!this.LockPlayer)
    //			{
    //				this.EndActionSkill();
    //			}
    //			return;
    //		}
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 30)
    //		{
    //			return;
    //		}
    //		this.m_ActionSkillTime = 1f;
    //		this.m_ActionSkillStep = 0;
    //		this.LockPlayer = true;
    //		this.m_bUseActionSkill = true;
    //		Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(707);
    //		this.m_ActionSTEffect = EffectGenerator.CreateEffectGameObject("ep01_innate");
    //		this.m_ActionSTEffect.transform.position = this.PlayerController.Pos;
    //		MusicControlSystem.PlaySound(4031, 1);
    //		Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill1, 0, 0, 0, 1);
    //		this.PlayerController.DisableDash();
    //	}

    //	public void UseActionSkill_Floating()
    //	{
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 90)
    //		{
    //			return;
    //		}
    //		this.PlayerController.Jump(true);
    //		this.m_CostStamina = 90;
    //		this.ExpendStaminaBar(true);
    //		MusicControlSystem.PlaySound(4038, 1);
    //		Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill3, 0, 0, 0, 1);
    //	}

    //	public void UseActionSkill_Shoot()
    //	{
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		M_PlayerMouseOrbit component = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_bBeginShoot)
    //		{
    //			if (this.m_GameApp.m_GameDataSystem.m_Stamina < 60)
    //			{
    //				return;
    //			}
    //			if (this.ActionTarget)
    //			{
    //				M_GameRoleBase component2 = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //				if (component2)
    //				{
    //					if (component2.Invalid)
    //					{
    //						return;
    //					}
    //					S_NpcData data = GameDataDB.NpcDB.GetData(component2.RoleID);
    //					if (data != null)
    //					{
    //						if (data.emActionHint != ENUM_ActionHint.Shoot)
    //						{
    //							return;
    //						}
    //						S_Trap data2 = GameDataDB.TrapDB.GetData(data.DataID);
    //						if (data2 == null)
    //						{
    //							Debug.Log("UseActionSkill_Shoot_機關資料錯誤!!_" + data.DataID);
    //							return;
    //						}
    //						S_GameObjData objData = this.m_GameApp.m_GameObjSystem.GetObjData(data2.ShootTargetID);
    //						if (objData == null)
    //						{
    //							return;
    //						}
    //						component.m_Distance = 1f;
    //						component.m_DistanceMin = 1f;
    //						component.m_ShootMode = true;
    //						this.m_bBeginShoot = true;
    //						this.LockPlayer = true;
    //						this.m_ShootTarget = objData.GameObj;
    //						this.SetCameraLookShootTarget();
    //						UI_Explore.Instance.ShowShootHUD(true, objData.GameObj, data.DataID);
    //						if (this.m_AmberController != null)
    //						{
    //							this.m_AmberController.SetRender(false);
    //						}
    //						this.PlayerController.PlayMotion(719);
    //						M_PlayerWeapon m_PlayerWeapon = this.PlayerObj.GetComponent<M_PlayerWeapon>();
    //						if (m_PlayerWeapon == null)
    //						{
    //							m_PlayerWeapon = this.PlayerObj.AddComponent<M_PlayerWeapon>();
    //						}
    //						if (m_PlayerWeapon)
    //						{
    //							C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(Swd6Application.instance.m_GameDataSystem.m_PlayerID);
    //							ItemData dataBySerialID = Swd6Application.instance.m_ItemSystem.GetDataBySerialID(roleData.BaseRoleData.EquipID[0]);
    //							if (dataBySerialID != null)
    //							{
    //								m_PlayerWeapon.SetWeapon(dataBySerialID.ID);
    //							}
    //						}
    //						MusicControlSystem.PlaySound(4043, 1);
    //						return;
    //					}
    //				}
    //			}
    //		}
    //		else
    //		{
    //			this.ClearShootState();
    //		}
    //	}

    //	public void PlayShootEffect(GameObject target, float missRangeX, float missRangeY, bool hit)
    //	{
    //		this.m_ActionSkillTime = 0.8f;
    //		this.m_ActionSkillStep = 3;
    //		this.PlayerController.PlayMotion(720);
    //		this.m_ActionEffect = EffectGenerator.CreateEffectGameObject("ep03_innate_A");
    //		Transform transform = TransformTool.SearchHierarchyForBone(this.m_PlayerGameObj.transform, "1007");
    //		this.m_ActionEffect.transform.position = transform.transform.position;
    //		MusicControlSystem.PlaySound(4044, 1);
    //		if (hit)
    //		{
    //			this.m_ShootOffset = Vector3.zero;
    //		}
    //		else
    //		{
    //			MusicControlSystem.PlaySound(4046, 1);
    //			this.m_ShootOffset = this.PlayerObj.transform.right * missRangeX;
    //			this.m_ShootOffset.y = this.m_ShootOffset.y + missRangeY;
    //		}
    //		Vector3 vector = target.transform.position + this.m_ShootOffset;
    //		iTween.MoveTo(this.m_ActionEffect, iTween.Hash(new object[]
    //		{
    //			"position",
    //			vector,
    //			"time",
    //			0.5f,
    //			"easetype",
    //			iTween.EaseType.linear,
    //			"orienttopath",
    //			true
    //		}));
    //		UnityEngine.Object.Destroy(this.m_ActionEffect, 0.5f);
    //	}

    //	public void ShootOver(bool isHit, GameObject target)
    //	{
    //		UI_Explore.Instance.ShowShootHUD(false, null, 0);
    //		this.m_ActionSkillTime = 0.8f;
    //		if (isHit)
    //		{
    //			Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill5, 0, 0, 0, 1);
    //			this.m_ActionSkillStep = 1;
    //			return;
    //		}
    //		if (this.m_bBeginShoot)
    //		{
    //			this.m_ActionSkillStep = 2;
    //		}
    //	}

    //	public void ClearShootState()
    //	{
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		M_PlayerMouseOrbit component = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //		this.m_bBeginShoot = false;
    //		this.LockPlayer = false;
    //		this.m_ShootOffset = Vector3.zero;
    //		component.m_Distance = 5f;
    //		component.m_DistanceMin = 0.5f;
    //		component.m_YAngle = 0f;
    //		component.m_ShootMode = false;
    //		this.PlayerController.StopMoveToTarget();
    //		this.PlayerController.StopMove();
    //		this.PlayerController.PlayIdleMotion();
    //		this.SetCameraLookTarget();
    //		UI_Explore.Instance.ShowShootHUD(false, null, 0);
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.SetRender(true);
    //		}
    //		if (this.m_ActionEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionEffect);
    //			this.m_ActionEffect = null;
    //		}
    //		if (this.m_ActionSTEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionSTEffect);
    //			this.m_ActionSTEffect = null;
    //		}
    //		M_PlayerWeapon component2 = this.PlayerObj.GetComponent<M_PlayerWeapon>();
    //		if (component2)
    //		{
    //			component2.SetWeapon(-1);
    //		}
    //	}

    //	public bool ExpendStaminaBarByShoot(GameObject target)
    //	{
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 60)
    //		{
    //			UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1122), 3f);
    //			this.UseActionSkill_Shoot();
    //			return false;
    //		}
    //		this.m_CostStamina = 60;
    //		this.ExpendStaminaBar(true);
    //		return true;
    //	}

    //	public bool AddShootFailTime(int maxFailTime)
    //	{
    //		if (maxFailTime <= 0)
    //		{
    //			return false;
    //		}
    //		this.m_ShootFailTime++;
    //		if (this.m_ShootFailTime >= maxFailTime)
    //		{
    //			Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill5, 0, 0, 0, 1);
    //			this.m_ShootFailTime = 0;
    //			return true;
    //		}
    //		return false;
    //	}

    //	public void UseActionSkill_Dispel()
    //	{
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 120)
    //		{
    //			return;
    //		}
    //		if (this.m_BeginDispell)
    //		{
    //			return;
    //		}
    //		if (this.ActionTarget)
    //		{
    //			M_GameRoleBase component = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				if (component.Invalid)
    //				{
    //					return;
    //				}
    //				S_NpcData data = GameDataDB.NpcDB.GetData(component.RoleID);
    //				if (data != null && data.emActionHint == ENUM_ActionHint.Dispel)
    //				{
    //					this.m_BeginDispell = true;
    //					this.m_ActionSkillStep = 0;
    //					this.LockPlayer = true;
    //					this.m_CostStamina = 120;
    //					this.ExpendStaminaBar(true);
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.MoveTarget = this.ActionTarget;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(709);
    //					this.m_ActionSTEffect = EffectGenerator.CreateEffectGameObject("ep04_innate_A");
    //					this.m_ActionSTEffect.transform.position = this.ActionTarget.transform.position;
    //					MusicControlSystem.PlaySound(4034, 1);
    //				}
    //			}
    //		}
    //	}

    //	public void DispelOver(bool isHit)
    //	{
    //		this.m_BeginDispell = false;
    //		this.LockPlayer = false;
    //		this.m_CostStamina = 25;
    //		if (this.ActionTarget && isHit)
    //		{
    //			MusicControlSystem.PlaySound(4035, 1);
    //			M_GameRoleBase component = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				if (component.Invalid)
    //				{
    //					return;
    //				}
    //				S_NpcData data = GameDataDB.NpcDB.GetData(component.RoleID);
    //				if (data != null)
    //				{
    //					if (data.emType == ENUM_NpcType.Treasure)
    //					{
    //						M_GameTreasure component2 = this.ActionTarget.GetComponent<M_GameTreasure>();
    //						component2.OpenLockTreasuer();
    //					}
    //					else
    //					{
    //						component.SetMotion(2032);
    //						component.SetMotionQueued(2033);
    //						component.Invalid = true;
    //						component.NoCollider = true;
    //						MusicControlSystem.PlaySound(2095, 1);
    //						this.m_PlyerController.EnterTalk = false;
    //					}
    //					Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill2, 0, 0, 0, 1);
    //				}
    //			}
    //			this.m_PlyerController.EnterTalk = false;
    //			this.ActionTarget = null;
    //			UI_Explore.Instance.ShowActionHint(null, ENUM_ActionHint.Null, false);
    //		}
    //		else
    //		{
    //			MusicControlSystem.PlaySound(4037, 1);
    //		}
    //		if (this.m_ActionEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionEffect);
    //			this.m_ActionEffect = null;
    //		}
    //		if (this.m_ActionSTEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionSTEffect);
    //			this.m_ActionSTEffect = null;
    //		}
    //		Swd6Application.instance.m_ExploreSystem.PlayerController.PlayIdleMotion();
    //	}

    //	public void UseActionSkill_Break()
    //	{
    //		if (this.m_GameApp.m_GameDataSystem.m_Stamina < 150)
    //		{
    //			return;
    //		}
    //		if (this.m_BeginBreak)
    //		{
    //			return;
    //		}
    //		if (this.ActionTarget)
    //		{
    //			M_GameRoleBase component = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				if (component.Invalid)
    //				{
    //					return;
    //				}
    //				S_NpcData data = GameDataDB.NpcDB.GetData(component.RoleID);
    //				if (data != null && data.emActionHint == ENUM_ActionHint.Break)
    //				{
    //					this.m_ActionSkillStep = 0;
    //					this.m_ActionSkillTime = 1.25f;
    //					this.m_BeginBreak = true;
    //					this.LockPlayer = true;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.MoveTarget = this.ActionTarget;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(716);
    //					if (this.m_GameApp.m_GameDataSystem.m_PlayerID == 4)
    //					{
    //						this.m_ActionSTEffect = EffectGenerator.CreateEffectGameObject("ep05_innate_A");
    //						MusicControlSystem.PlaySound(4039, 1);
    //					}
    //					else
    //					{
    //						this.m_ActionSTEffect = EffectGenerator.CreateEffectGameObject("ep06_innate_A");
    //						MusicControlSystem.PlaySound(4064, 1);
    //					}
    //					this.m_ActionSTEffect.transform.position = this.PlayerController.Pos;
    //				}
    //			}
    //		}
    //	}

    //	public void BreakOver(bool isHit)
    //	{
    //		this.m_BeginBreak = false;
    //		this.LockPlayer = false;
    //		this.m_CostStamina = 150;
    //		this.ExpendStaminaBar(true);
    //		UI_Explore.Instance.CloseDamageHUD();
    //		if (this.ActionTarget && isHit)
    //		{
    //			MusicControlSystem.PlaySound(4041, 1);
    //			M_GameRoleBase component = this.ActionTarget.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				if (component.Invalid)
    //				{
    //					return;
    //				}
    //				S_NpcData data = GameDataDB.NpcDB.GetData(component.RoleID);
    //				if (data != null && data.emActionHint == ENUM_ActionHint.Break)
    //				{
    //					component.SetMotion(2030);
    //					component.SetMotionQueued(2031);
    //					component.Invalid = true;
    //					if (data.Talk != null)
    //					{
    //						this.ActionTarget.SendMessage("DoTalk", SendMessageOptions.DontRequireReceiver);
    //					}
    //					Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.ActionSkill4, 0, 0, 0, 1);
    //				}
    //			}
    //		}
    //		else
    //		{
    //			MusicControlSystem.PlaySound(4042, 1);
    //		}
    //		this.m_CostStamina = 25;
    //		this.m_PlyerController.EnterTalk = false;
    //		this.ActionTarget = null;
    //		UI_Explore.Instance.ShowActionHint(null, ENUM_ActionHint.Null, false);
    //		if (this.m_ActionEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionEffect);
    //			this.m_ActionEffect = null;
    //		}
    //		if (this.m_ActionSTEffect)
    //		{
    //			UnityEngine.Object.DestroyObject(this.m_ActionSTEffect);
    //			this.m_ActionSTEffect = null;
    //		}
    //		Transform transform = this.m_PlayerGameObj.transform.Find("p05-01-cloth-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-meta-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-weap-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-cloth-map");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(true);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-skin-map");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(true);
    //		}
    //		Swd6Application.instance.m_ExploreSystem.PlayerController.PlayIdleMotion();
    //	}

    //	public void UpdateFollowPet()
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(23))
    //		{
    //			return;
    //		}
    //		if (this.m_NoFightTime > 0f)
    //		{
    //			return;
    //		}
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.UpdateFightWarring(this.BattleStep, this.m_MaxBattleStep);
    //		}
    //	}

    //	public void SetLiftBrand(ENUM_ActionHint ActionHint, bool show)
    //	{
    //		if (this.AmberObj == null)
    //		{
    //			return;
    //		}
    //		int num = (int)ActionHint;
    //		if (num >= 2)
    //		{
    //			num--;
    //		}
    //		if (this.m_AmberController != null)
    //		{
    //			if (show)
    //			{
    //				this.m_AmberController.BeginLiftBrand(num);
    //				return;
    //			}
    //			this.m_AmberController.EndLiftBrand();
    //		}
    //	}

    //	public void ReStartPos(Transform targer)
    //	{
    //		if (targer)
    //		{
    //			this.m_ReStartPos = targer.transform.position;
    //		}
    //		this.BattleStep = 0f;
    //		this.m_bSetReStarPos = false;
    //		this.PlayerController.Pos = this.m_ReStartPos;
    //		this.PlayerController.PlayIdleMotion();
    //	}

    //	public bool CreateRidePet(int index, bool check)
    //	{
    //		if (this.RidePetObj == null)
    //		{
    //			bool fly = false;
    //			string name;
    //			if (index == 4)
    //			{
    //				if (check && !this.CheckCanRide())
    //				{
    //					UI_OkCancelBox.Instance.ClearSysMsg();
    //					UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1124), 3f);
    //					return false;
    //				}
    //				name = "RidePet3";
    //			}
    //			else if (index < 2)
    //			{
    //				if (check && !this.CheckCanRide())
    //				{
    //					UI_OkCancelBox.Instance.ClearSysMsg();
    //					UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1124), 3f);
    //					return false;
    //				}
    //				name = "RidePet";
    //				if (index == 1)
    //				{
    //					name = "RidePet2";
    //				}
    //			}
    //			else
    //			{
    //				name = "FlyPet";
    //				if (index == 3)
    //				{
    //					name = "FlyPet2";
    //				}
    //				fly = true;
    //			}
    //			this.RidePetObj = PlayerGenerator.CreatePlayerGameObject(name);
    //			if (this.RidePetObj)
    //			{
    //				this.RidePetObj.transform.position = this.PlayerController.Pos;
    //				this.RidePetObj.transform.eulerAngles = new Vector3(0f, this.PlayerController.transform.eulerAngles.y, 0f);
    //				this.PlayerController.enabled = false;
    //				this.PlayerController.NoCollider = true;
    //				this.PlayerController.HideRole = true;
    //				this.m_RidePetController = this.m_RidePetGameObj.AddComponent<M_RidePetController>();
    //				if (this.m_RidePetController != null)
    //				{
    //					this.m_RidePetController.Init(this.PlayerObj, 601, fly);
    //					this.SetCameraLookRidePetTarget(this.m_RidePetGameObj);
    //				}
    //			}
    //		}
    //		else if (this.m_RidePetController != null && !this.m_RidePetController.BeginDown())
    //		{
    //			return false;
    //		}
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.SetRender(false);
    //		}
    //		return true;
    //	}

    //	public bool CheckCanRide()
    //	{
    //		int layerMask = 512;
    //		return !Physics.CheckSphere(this.PlayerController.Pos, 1f, layerMask);
    //	}

    //	public bool DownRidePet()
    //	{
    //		return !(this.m_RidePetController == null) && this.m_RidePetController.BeginDown();
    //	}

    //	public bool IsRidePetLockControl()
    //	{
    //		return !(this.m_RidePetController == null) && this.m_RidePetController.LockControl;
    //	}

    //	public void DestroyRidePet()
    //	{
    //		if (this.m_RidePetGameObj == null)
    //		{
    //			return;
    //		}
    //		if (this.PlayerController)
    //		{
    //			this.PlayerController.m_WalkInWater = false;
    //			this.PlayerController.enabled = true;
    //			this.PlayerController.NoCollider = false;
    //			this.PlayerController.HideRole = false;
    //			this.PlayerController.Pos = this.m_RidePetGameObj.transform.position;
    //			this.PlayerController.SetDir(this.m_RidePetGameObj.transform.eulerAngles.y);
    //			this.PlayerController.StopMove();
    //		}
    //		UnityEngine.Object.DestroyObject(this.m_RidePetGameObj);
    //		this.m_RidePetGameObj = null;
    //		this.SetCameraLookTarget();
    //		if (this.m_AmberController != null)
    //		{
    //			this.m_AmberController.SetRender(true);
    //		}
    //		if (this.m_UpdateCosCloth)
    //		{
    //			this.m_UpdateCosCloth = false;
    //			this.SwitchPlayer();
    //		}
    //	}

    //	public void SetPlayMusicDelayTime(float delayTime)
    //	{
    //		this.m_PlayMusicDelayTime = delayTime;
    //	}
}
