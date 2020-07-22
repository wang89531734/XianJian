using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    private float m_PlayerChangeDir;

    private float m_PlayMusicDelayTime;

    public float m_NoFightTime;

    public float m_NoFightCDTime;

    private float m_HitDamageDelayTime;

    private bool m_bUseActionSkill;

    public bool m_SetCemeraInfo;

    public float m_CameraXAngle;

    public float m_CameraYAngle;

    public float m_CameraDist;

    public float m_CameraMinDist;

    public float m_CameraMaxDist;

    public float m_CameraYMinLimit;

    public float m_CameraYMaxLimit;

    public int m_CameraIsphysics;

    public int m_CameraLock;

    public float m_ResourceUnLoadTime;

    public bool m_ResourceUnLoad;

    public bool m_Loading;

    public bool m_UpdateCosCloth;

    public bool m_PlayStory;

    public bool m_HideMapMob;

    public float m_OpenMenuTime;

    public float m_PrePosUpdateTime;

    public int m_AutoHideMapID;

    private GameObject m_TalkTarget;

    private GameObject m_ActionTarget;

    public GameObject m_GhostEffect;

    public GameObject m_ActionSTEffect;

    public GameObject m_ActionEffect;

    public GameObject m_ActionEDEffect;

    public GameObject m_ShootTarget;

    private string m_PlayerChangePoint = string.Empty;

    public Vector3 m_PrePlayerPos = Vector3.zero;

    private Vector3 m_PlayerChangePos = Vector3.zero;

    private Vector3 m_ReStartPos = Vector3.zero;

    private GameObject m_MainCameraGameObj;

    //private M_PlayerMouseOrbit m_PlayerMouseOrbit;

    private GameObject m_PlayerGameObj;

    private M_PlayerController m_PlyerController;

    public GameObject m_MoveTargetPoint;

    public GameObject m_RainEffect;

    //public List<S_GameObjData> m_GhostEyeObjList = new List<S_GameObjData>();

    public int m_EffectSerialID;

    public Dictionary<int, GameObject> m_EffectList = new Dictionary<int, GameObject>();

    private GameObject m_AmberPigGameObj;

    //private M_AmberPigController m_AmberPigController;

    public GameObject m_MapSoundEvent;

    public GameObject m_TalkEventObj;

    public Component m_TalkComponent;

    public GameObject m_DontRemoveObj;

    public bool m_SubTalk;

    public bool m_AutoSave;

    public bool m_UseNoFightItem;

    public bool m_RestorePlayer;

    public int m_HideMap;

    public float m_PlayerUpdateTime;

    public S_MapData m_MapData
    {
        get;
        private set;
    }

    public GameObject PlayerObj
    {
        get
        {
            return this.m_PlayerGameObj;
        }
        set
        {
            this.m_PlayerGameObj = value;
            if (this.m_PlayerGameObj == null)
            {
                return;
            }
            this.m_PlayerGameObj.tag = "Player";
            //this.m_PlyerController = this.m_PlayerGameObj.GetComponent<M_PlayerController>();
        }
    }

    public GameObject AmberPigObj
    {
        get
        {
            return this.m_AmberPigGameObj;
        }
        set
        {
            this.m_AmberPigGameObj = value;
            if (this.m_AmberPigGameObj != null)
            {
                //this.m_AmberPigController = this.m_AmberPigGameObj.GetComponent<M_AmberPigController>();
            }
        }
    }

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

    public bool LockPlayer
    {
        get
        {
            return this.m_bLockPlayer;
        }
        set
        {
            this.m_bLockPlayer = value;
            if (this.m_PlyerController != null)
            {
                this.m_PlyerController.LockControl = this.m_bLockPlayer;
            }
            if (!this.m_bLockPlayer)
            {
                if (GameEntry.Instance.m_QuestSystem != null)
                {
                    GameEntry.Instance.m_QuestSystem.Dirty();
                }
                this.TalkTarget = null;
            }
            else
            {
                //UI_ZoneMap.Instance.Hide();//区域地图
            }
            GameEntry.Input.Clear();
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
            if (value == null && this.m_TalkTarget && this.m_TalkTarget.GetComponent<M_GameRoleBase>() != null)
            {
                this.m_TalkTarget.GetComponent<M_GameRoleBase>().Talk = false;
            }
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

    public void Initialize()
    {

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
    //			this.m_MoveTargetPoint = ResourceManager.Instance.GetEffect("locus");
    //			if (this.m_MoveTargetPoint)
    //			{
    //				this.m_MoveTargetPoint.transform.position = targetPos;
    //				return this.m_MoveTargetPoint;
    //			}
    //		}
    //		return null;
    //	}

    //	public void TalkOver()
    //	{
    //		this.m_TalkEventObj = null;
    //		if (!this.m_SubTalk)
    //		{
    //			if (this.m_TalkComponent != null)
    //			{
    //				UnityEngine.Object.DestroyObject(this.m_TalkComponent);
    //				this.m_TalkComponent = null;
    //			}
    //			if (this.m_DontRemoveObj != null)
    //			{
    //				UnityEngine.Object.Destroy(this.m_DontRemoveObj);
    //				this.m_DontRemoveObj = null;
    //			}
    //		}
    //		if (this.PlayerController != null)
    //		{
    //			this.PlayerController.m_PickTarget = null;
    //		}
    //		this.m_SubTalk = false;
    //		this.ClearAllEffect();
    //	}

    public void Begin()
    {
        bool lockPlayer = this.LockPlayer;
        this.LoadMapDate();
        this.LoadEventPrefab();
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
        this.m_PlyerController.m_Controller.enabled = false;
        this.AmberPigObj = GameEntry.Instance.m_GameObjSystem.CreateAmberPigGameObj();
        //this.EnableMainCamera(true);
        //this.SetCameraLookTarget(true);
        //this.SetAmberPigTargetPos();
        //this.m_GameApp.m_GameObjSystem.LoadMapObj(this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
        //GameMapMobSystem.Instance.SetTarget(this.PlayerObj);
        //ExploreMiniMapSystem.Instance.CreateMapData(this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
        //this.m_GameApp.m_SaveloadSystem.m_Loading = false;
        //if (this.m_PlayMusicDelayTime <= 0f)
        //{
        //    this.PlayMusic();
        //}
        GameEntry.Input.Clear();
        this.m_HideMap = 0;
        this.m_RainEffect = null;
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
        this.LockPlayer = lockPlayer;
        //this.ClearBattleInfo();
        //this.SpecialSetting();
        //this.ChangeSky();
    }

    //	public void End()
    //	{
    //		UnityEngine.Debug.Log("EndExplore_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //		int mapID = this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID;
    //		if (this.m_MapData != null)
    //		{
    //			this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID = this.m_MapData.GUID;
    //		}
    //		if (!this.m_Loading)
    //		{
    //			UI_ZoneMap.Instance.SaveMapMask();
    //		}
    //		UI_ZoneMap.Instance.OpenMaskTexture();
    //		this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID = mapID;
    //		UI_ZoneMap.Instance.Close();
    //		UI_MiniMap.Instance.Close();
    //		GameMapMobSystem.Instance.Clear();
    //		GameInput.Clear();
    //		this.ClearAllEffect();
    //		this.ResetData();
    //		this.m_Loading = false;
    //		this.m_OpenMainMenu = false;
    //		this.AmberPigObj = null;
    //		this.m_GameApp.m_GameObjSystem.RemovePlayerGameObj();
    //	}

    //	public void Suspend()
    //	{
    //		this.EnableMainCamera(false);
    //		this.m_PlayerChangePos = this.PlayerController.Pos;
    //		this.m_PlayerChangeDir = this.PlayerController.Dir;
    //		UI_ZoneMap.Instance.Hide();
    //		UI_MiniMap.Instance.Hide();
    //		GameMapMobSystem.Instance.Pause();
    //		if (!this.m_OpenMainMenu)
    //		{
    //			GameMapMobSystem.Instance.Hide();
    //		}
    //		this.m_GameApp.m_GameObjSystem.PauseNpcObj();
    //		GameInput.Clear();
    //		this.ResumeMusic = false;
    //		this.LockPlayer = true;
    //		UnityEngine.Debug.Log("Suspend_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //	}

    //	public void Resume()
    //	{
    //		UnityEngine.Debug.Log("Resume_" + this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID);
    //		this.EnableMainCamera(true);
    //		this.ChangeSky();
    //		this.ClearBattleInfo();
    //		UI_MiniMap.Instance.Open();
    //		if (this.m_UpdateCosCloth)
    //		{
    //			this.m_UpdateCosCloth = false;
    //			this.SwitchPlayer();
    //		}
    //		if (this.m_PlayMusicDelayTime <= 0f && !this.ResumeMusic)
    //		{
    //			this.PlayMusic();
    //		}
    //		if (this.m_TalkComponent == null)
    //		{
    //			this.LockPlayer = false;
    //		}
    //		if (this.m_PlayerMouseOrbit != null)
    //		{
    //			this.m_PlayerMouseOrbit.m_RMosuePressTime = 0f;
    //		}
    //		GameInput.Clear();
    //		GameMapMobSystem.Instance.Resume();
    //		if (!this.m_OpenMainMenu)
    //		{
    //			GameMapMobSystem.Instance.Show();
    //		}
    //		this.m_GameApp.m_GameObjSystem.ResumeNpcObj();
    //		this.m_OpenMainMenu = false;
    //		this.m_Loading = false;
    //		this.m_AutoHideMapID = 0;
    //	}

    //	public void SpecialSetting()
    //	{
    //		if (this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID == 52)
    //		{
    //			GameObject gameObject = GameObject.Find("02_Occluder");
    //			if (gameObject != null)
    //			{
    //				TransformTool.SetLayerRecursively(gameObject.transform, 2);
    //			}
    //			gameObject = GameObject.Find("03_Occludee");
    //			if (gameObject != null)
    //			{
    //				TransformTool.SetLayerRecursively(gameObject.transform, 2);
    //			}
    //		}
    //	}

    public void ResetData()
    {
        GameEntry.Instance.m_GameDataSystem.FlagOFF(40);
        GameEntry.Instance.m_GameDataSystem.FlagOFF(41);
        this.m_NoFightTime = 0f;
        this.m_NoFightCDTime = 0f;
        //UI_Explore.Instance.HideBuffer();
    }

    public void LoadMapDate()
    {
        GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID = 1;
        this.m_MapData = GameDataDB.MapDB.GetData(GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
        if (this.m_MapData == null)
        {
            UnityEngine.Debug.Log("載入地圖dbf錯誤_" + GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
            return;
        }
        UnityEngine.Debug.Log(m_MapData.Name + "" + m_MapData.Desc);
        this.ResetData();
        if (this.m_MapData.emType == ENUM_MapType.Maze)
        {
            //this.m_GameApp.m_GameDataSystem.FlagON(41);
        }

        if (this.m_MapData.emType != ENUM_MapType.Maze)
        {
            //UI_Explore.Instance.SetActionSkill(this.m_GameApp.m_GameDataSystem.m_PlayerID);
        }
        else
        {
            //UI_Explore.Instance.SetActionSkill(this.m_GameApp.m_GameDataSystem.m_PlayerID);
        }
    }

    public void LoadEventPrefab()
    {
        if (this.m_MapData == null)
        {
            return;
        }
        string[] ignoreName = new string[]
        {
                "Extra_Mask_MAP78",
                "Extra_Mask_MAP66_01",
                "Extra_Mask_MAP59_01"
        };
        string name;
        for (int i = 1; i <= 5; i++)
        {
            name = this.m_MapData.Name + "_Event_" + i.ToString();
            GameObject mapEvent = ResourcesManager.Instance.GetMapEvent(name);
            if (mapEvent != null)
            {
                //TransformTool.SetLayerRecursively(mapEvent.transform, 2, ignoreName);
            }
        }

        name = this.m_MapData.Name + "_SoundEvent";
        if (this.m_MapSoundEvent != null)
        {
            UnityEngine.Object.Destroy(this.m_MapSoundEvent);
        }
        //this.m_MapSoundEvent = ResourcesManager.Instance.GetMapSoundEvent(name);
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
    //		string text = Application.dataPath + "/../Assetbundles/AstarData/" + this.m_MapData.Name + ".ast";
    //		UnityEngine.Debug.Log("AName_" + text);
    //		FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read);
    //		if (fileStream != null)
    //		{
    //			byte[] array = new byte[fileStream.Length];
    //			fileStream.Read(array, 0, (int)fileStream.Length);
    //			AstarPath.active.astarData.DeserializeGraphs(array);
    //			fileStream.Dispose();
    //		}
    //		return true;
    //	}

    //	public void PlayMusic()
    //	{
    //		if (MusicSystem.Instance.m_StoryMusicExtendMode == ENUM_MusicExtendMode.infinite)
    //		{
    //			MusicSystem.Instance.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
    //			return;
    //		}
    //		if (GameDataDB.MusicDB == null || this.m_MapData == null)
    //		{
    //			return;
    //		}
    //		S_MusicData data = GameDataDB.MusicDB.GetData(this.m_MapData.MusicID1);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusicData_" + this.m_MapData.MusicID1 + "不存在");
    //			return;
    //		}
    //		AudioClip music = ResourceManager.Instance.GetMusic(data.MusicName);
    //		if (music == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		data = GameDataDB.MusicDB.GetData(this.m_MapData.MusicID2);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusicData_" + this.m_MapData.MusicID2 + "不存在");
    //			return;
    //		}
    //		AudioClip music2 = ResourceManager.Instance.GetMusic(data.MusicName);
    //		if (music2 == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		if (this.m_MapData.emMusicMode == ENUM_MusicMode.ONCE)
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB(music, music2, 1f);
    //		}
    //		else if (this.m_MapData.emMusicMode == ENUM_MusicMode.CIRCLE)
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB_ABLoop(music, music2, 1f);
    //		}
    //		else
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB_BLoop(music, music2, 1f);
    //		}
    //	}

    //	public void PlayMapMusic(int music1, int music2, ENUM_MusicMode mode)
    //	{
    //		S_MusicData data = GameDataDB.MusicDB.GetData(music1);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusicData_" + this.m_MapData.MusicID1 + "不存在");
    //			return;
    //		}
    //		AudioClip music3 = ResourceManager.Instance.GetMusic(data.MusicName);
    //		if (music3 == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		data = GameDataDB.MusicDB.GetData(music2);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusicData_" + this.m_MapData.MusicID2 + "不存在");
    //			return;
    //		}
    //		AudioClip music4 = ResourceManager.Instance.GetMusic(data.MusicName);
    //		if (music4 == null)
    //		{
    //			UnityEngine.Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		if (mode == ENUM_MusicMode.ONCE)
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB(music3, music4, 1f);
    //		}
    //		else if (mode == ENUM_MusicMode.CIRCLE)
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB_ABLoop(music3, music4, 1f);
    //		}
    //		else
    //		{
    //			MusicSystem.Instance.PlayBackgroundMusicAB_BLoop(music3, music4, 1f);
    //		}
    //	}

    public void Update()
    {
        //this.UpdaeInput();
        //this.UpdateLoadPlayer();
        //this.UpdateCursor();
        //this.UpdaeReStartPos();
        //this.UpdaePlayMusic();
        //this.UpdaeNoFighCDTime();
        //this.UpdaeNoFighTime();
        //this.UpdateUnloadResource();
        //this.UpdateHideUI();
        //if (this.m_OpenMenuTime > 0f)
        //{
        //    this.m_OpenMenuTime -= Time.deltaTime;
        //    if (this.m_OpenMenuTime <= 0f)
        //    {
        //        this.m_OpenMenuTime = 0f;
        //    }
        //}
        //if (this.m_RainEffect != null)
        //{
        //    this.m_RainEffect.transform.position = this.PlayerObj.transform.position;
        //}
        //Swd6Application.instance.m_GameObjSystem.UpdateAllMapObj();
    }

    //	public void UpdateLoadPlayer()
    //	{
    //		if (this.m_PlayerUpdateTime > 0f)
    //		{
    //			this.m_PlayerUpdateTime -= Time.deltaTime;
    //			if (this.m_PlayerUpdateTime <= 0f)
    //			{
    //				this.m_PlayerUpdateTime = 0f;
    //				this.m_PlyerController.m_Controller.enabled = true;
    //				GameMath.CastObjectOnTerrain(this.PlayerObj, 0.5f);
    //				this.PlayerObj.transform.position += new Vector3(0f, 0.1f, 0f);
    //			}
    //		}
    //	}

    //	private void UpdateHideUI()
    //	{
    //		if (this.m_HideMap == 1)
    //		{
    //			this.m_HideMap = 0;
    //			UI_Explore.Instance.Hide();
    //			UI_MiniMap.Instance.Hide();
    //		}
    //		else if (this.m_HideMap == 2)
    //		{
    //			this.m_HideMap = 0;
    //			UI_Explore.Instance.Show();
    //			UI_MiniMap.Instance.Show();
    //		}
    //	}

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

    //	public void ClearNoFightData(bool clearAll)
    //	{
    //		this.m_UseNoFightItem = false;
    //		this.m_NoFightTime = 0f;
    //		this.m_NoFightCDTime = 0f;
    //		UI_Explore.Instance.HideBuffer();
    //		if (clearAll)
    //		{
    //			this.m_GameApp.m_GameObjSystem.ClearPlayer3MaterailData();
    //		}
    //	}

    //	public void RemoveNoFightEffect()
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.m_PlayerID != 3)
    //		{
    //			return;
    //		}
    //		if (this.m_NoFightTime == 0f)
    //		{
    //			return;
    //		}
    //		this.m_UseNoFightItem = false;
    //		this.m_NoFightTime = 0f;
    //		this.m_NoFightCDTime = 0f;
    //		UI_Explore.Instance.HideBuffer();
    //		Swd6Application.instance.m_GameObjSystem.RestorePlayer3Materail(this.PlayerObj);
    //	}

    //	private void UpdaeNoFighTime()
    //	{
    //		if (this.m_NoFightTime == 0f)
    //		{
    //			return;
    //		}
    //		if (this.m_OpenMainMenu)
    //		{
    //			return;
    //		}
    //		this.m_NoFightTime -= Time.deltaTime;
    //		if (this.m_NoFightTime <= 0f)
    //		{
    //			this.m_UseNoFightItem = false;
    //			this.m_NoFightTime = 0f;
    //			UI_Explore.Instance.HideBuffer();
    //			MusicSystem.Instance.PlaySound(203, 1);
    //			Swd6Application.instance.m_GameObjSystem.RestorePlayer3Materail(this.PlayerObj);
    //		}
    //	}

    //	private void UpdaeNoFighCDTime()
    //	{
    //		if (this.m_NoFightCDTime == 0f)
    //		{
    //			return;
    //		}
    //		this.m_NoFightCDTime -= Time.deltaTime;
    //		if (this.m_NoFightCDTime <= 0f)
    //		{
    //			this.m_NoFightCDTime = 0f;
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
    //				MusicSystem.Instance.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
    //				this.PlayMusic();
    //			}
    //		}
    //	}

    //	public void AutoSave()
    //	{
    //		if (this.m_PlayStory)
    //		{
    //			return;
    //		}
    //		if (this.PlayerController == null)
    //		{
    //			return;
    //		}
    //		this.m_AutoSave = true;
    //		this.m_GameApp.m_SaveloadSystem.AutoSave1(ENUM_AUTOSAVETYPE.Map);
    //		this.m_AutoSave = false;
    //	}

    //	private void UpdaeReStartPos()
    //	{
    //		if (!this.LockPlayer)
    //		{
    //			if (this.PlayerController == null)
    //			{
    //				return;
    //			}
    //			this.m_PrePosUpdateTime += Time.deltaTime;
    //			if (this.m_PrePosUpdateTime >= 1f)
    //			{
    //				this.m_PrePosUpdateTime = 0f;
    //				this.m_PrePlayerPos = this.PlayerController.Pos;
    //			}
    //		}
    //	}

    //	[DebuggerHidden]
    //	public IEnumerator QuickSave()
    //	{
    //		ExploreSystem.<QuickSave>c__Iterator884 <QuickSave>c__Iterator = new ExploreSystem.<QuickSave>c__Iterator884();
    //		<QuickSave>c__Iterator.<>f__this = this;
    //		return <QuickSave>c__Iterator;
    //	}

    //	private void UpdaeInput()
    //	{
    //		if (this.m_GameApp.gameStateService.getCurrentState().name != "ExploreState")
    //		{
    //			return;
    //		}
    //		if (this.PlayerController == null)
    //		{
    //			return;
    //		}
    //		if (this.PlayerController.IsJump())
    //		{
    //			return;
    //		}
    //		if (Input.GetKeyDown(KeyCode.H) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.LTrigger))
    //		{
    //			GameObject gameObject = GameObject.Find("Main Camera");
    //			if (gameObject == null)
    //			{
    //				gameObject = GameObject.FindWithTag("MainCamera");
    //			}
    //			M_PlayerMouseOrbit x = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //			if (x == null)
    //			{
    //				x = gameObject.AddComponent<M_PlayerMouseOrbit>();
    //			}
    //			if (UI_Explore.Instance.IsVisible())
    //			{
    //				UI_Explore.Instance.Hide();
    //				UI_MiniMap.Instance.Hide();
    //			}
    //			else
    //			{
    //				UI_Explore.Instance.Show();
    //				UI_MiniMap.Instance.Show();
    //			}
    //		}
    //		if (!this.LockPlayer)
    //		{
    //			if (GameInput.GetKeyActionDown(KEY_ACTION.QSAVE))
    //			{
    //				this.m_GameApp.m_GameObjSystem.PauseNpcObj();
    //				GameMapMobSystem.Instance.Pause();
    //				this.m_GameApp.StartCoroutine(this.QuickSave());
    //				this.LockPlayer = true;
    //			}
    //			if (GameInput.GetKeyActionDown(KEY_ACTION.QLOAD))
    //			{
    //				this.m_GameApp.m_GameObjSystem.PauseNpcObj();
    //				GameMapMobSystem.Instance.Pause();
    //				UI_GameSaveLoadMenu.Instance.OpenLoad();
    //				this.LockPlayer = true;
    //			}
    //		}
    //		if (!GameInput.GetKeyActionDown(KEY_ACTION.MENU))
    //		{
    //			if (GameInput.GetKeyActionDown(KEY_ACTION.MAP))
    //			{
    //				UI_ZoneMap.Instance.Open();
    //			}
    //			return;
    //		}
    //		if (UI_ZoneMap.Instance.IsVisible())
    //		{
    //			return;
    //		}
    //		if (UI_GameSaveLoadMenu.Instance.IsVisible())
    //		{
    //			return;
    //		}
    //		GameInput.KeyInput = true;
    //		this.OpenGameMainMenu();
    //	}

    //	private void GetAllItem()
    //	{
    //		int count = 99;
    //		int dataSize = GameDataDB.ItemDB.GetDataSize();
    //		GameDataDB.ItemDB.ResetByOrder();
    //		for (int i = 0; i < dataSize; i++)
    //		{
    //			S_Item dataByOrder = GameDataDB.ItemDB.GetDataByOrder();
    //			if (dataByOrder != null)
    //			{
    //				Swd6Application.instance.m_ItemSystem.AddItem(dataByOrder.GUID, count, ENUM_ItemState.New, false);
    //			}
    //		}
    //		UI_Message.Instance.ShowSysMsg(GameDataDB.StrID(9827), 3f);
    //	}

    //	private void LearnAllSkill()
    //	{
    //		GameDataDB.SkillDB.ResetByOrder();
    //		int dataSize = GameDataDB.SkillDB.GetDataSize();
    //		for (int i = 0; i < Swd6Application.instance.m_GameDataSystem.GetNumberRoleFromParty(); i++)
    //		{
    //			int partyRoleID = Swd6Application.instance.m_GameDataSystem.GetPartyRoleID(i);
    //			for (int j = 0; j < dataSize; j++)
    //			{
    //				S_Skill dataByOrder = GameDataDB.SkillDB.GetDataByOrder();
    //				if (dataByOrder != null && dataByOrder.LearnRole == partyRoleID)
    //				{
    //					Swd6Application.instance.m_SkillSystem.LearnSkill(partyRoleID, dataByOrder.GUID);
    //				}
    //			}
    //		}
    //		UI_Message.Instance.ShowSysMsg(GameDataDB.StrID(9834), 3f);
    //	}

    //	private void UpdaeDebugInput()
    //	{
    //		if (Input.GetKeyDown(KeyCode.J))
    //		{
    //			if (this.m_GameApp.m_GameObjSystem.IsHidePlayer())
    //			{
    //				this.m_GameApp.m_GameObjSystem.HidePlayer(false);
    //				this.LockPlayer = false;
    //				if (this.AmberPigObj)
    //				{
    //					this.AmberPigObj.GetComponent<M_AmberPigController>().SetRender(true);
    //				}
    //			}
    //			else
    //			{
    //				UnityEngine.Debug.Log("HidePlayer");
    //				this.m_GameApp.m_GameObjSystem.HidePlayer(true);
    //				this.LockPlayer = true;
    //				if (this.AmberPigObj)
    //				{
    //					this.AmberPigObj.GetComponent<M_AmberPigController>().SetRender(false);
    //				}
    //			}
    //		}
    //		if (Input.GetKeyDown(KeyCode.K))
    //		{
    //			if (!this.m_HideMapMob)
    //			{
    //				GameMapMobSystem.Instance.Hide();
    //			}
    //			else
    //			{
    //				GameMapMobSystem.Instance.Show();
    //			}
    //			this.m_HideMapMob = !this.m_HideMapMob;
    //		}
    //		if (Input.GetKeyDown(KeyCode.F4))
    //		{
    //		}
    //		if (Input.GetKeyDown(KeyCode.F5))
    //		{
    //			Swd6Application.instance.m_BigMapSystem.Open();
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
    //			UI_GameFlagMenu.Instance.Show();
    //			this.LockPlayer = true;
    //		}
    //		if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
    //		{
    //			this.LockPlayer = false;
    //		}
    //		if (Input.GetKeyDown(KeyCode.Q))
    //		{
    //		}
    //		if (Input.GetKeyDown(KeyCode.F1))
    //		{
    //		}
    //		if (Input.GetKeyDown(KeyCode.F2))
    //		{
    //		}
    //		if (Input.GetKeyDown(KeyCode.F3))
    //		{
    //		}
    //		if (Input.GetKeyDown(KeyCode.F4))
    //		{
    //		}
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
    //		if (this.m_GameApp.gameStateService.getCurrentState().name != "ExploreState")
    //		{
    //			return;
    //		}
    //		this.m_OpenMainMenu = true;
    //		MusicSystem.Instance.PlayUISound(13, 1);
    //		this.m_GameApp.StartCoroutine(this.m_GameApp.OpenGameMainMenu());
    //	}

    //	public void SetCameraLookTarget(bool bInit)
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
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogError("找不到Main Camera");
    //			return;
    //		}
    //		this.m_MainCameraGameObj = gameObject;
    //		Component component = gameObject.GetComponent("M_MiniMapCamera");
    //		if (component != null)
    //		{
    //			UnityEngine.Object.Destroy(component);
    //		}
    //		M_MouseOrbit component2 = gameObject.GetComponent<M_MouseOrbit>();
    //		if (component2 != null)
    //		{
    //			component2.enabled = false;
    //		}
    //		this.m_PlayerMouseOrbit = gameObject.GetComponent<M_PlayerMouseOrbit>();
    //		if (this.m_PlayerMouseOrbit == null)
    //		{
    //			this.m_PlayerMouseOrbit = gameObject.AddComponent<M_PlayerMouseOrbit>();
    //		}
    //		if (bInit)
    //		{
    //			this.m_PlayerMouseOrbit.Init();
    //			this.m_PlayerMouseOrbit.SetNormalMode();
    //		}
    //		DepthOfFieldScatter component3 = gameObject.GetComponent<DepthOfFieldScatter>();
    //		Transform[] componentsInChildren = this.m_GameApp.m_GameObjSystem.PlayerObj.transform.GetComponentsInChildren<Transform>();
    //		Transform[] array = componentsInChildren;
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			Transform transform = array[i];
    //			if (transform.name == "CamPos")
    //			{
    //				if (component3 != null)
    //				{
    //					component3.focalTransform = transform;
    //				}
    //				this.m_PlayerMouseOrbit.m_Target = transform;
    //				break;
    //			}
    //		}
    //		gameObject.camera.orthographic = false;
    //		int num = 198656;
    //		num = ~num;
    //		gameObject.camera.cullingMask = num;
    //		this.SetCameraDofEffectLookTarget(this.m_GameApp.m_GameObjSystem.PlayerObj);
    //	}

    //	public void SetAmberPigTargetPos()
    //	{
    //		if (this.m_GameApp.m_GameObjSystem.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		if (this.AmberPigObj == null)
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
    //				this.m_AmberPigController.m_Target = transform;
    //				break;
    //			}
    //		}
    //	}

    //	public void ChangeMainCamera(GameObject nextCamera)
    //	{
    //		if (this.m_MainCameraGameObj == null)
    //		{
    //			return;
    //		}
    //		if (nextCamera == null)
    //		{
    //			return;
    //		}
    //		if (nextCamera == this.m_MainCameraGameObj)
    //		{
    //			return;
    //		}
    //		nextCamera.transform.position = this.m_MainCameraGameObj.transform.position;
    //		nextCamera.transform.rotation = this.m_MainCameraGameObj.transform.rotation;
    //		nextCamera.camera.orthographic = this.m_MainCameraGameObj.camera.orthographic;
    //		nextCamera.camera.cullingMask = this.m_MainCameraGameObj.camera.cullingMask;
    //		nextCamera.camera.enabled = this.m_MainCameraGameObj.camera.enabled;
    //		M_PlayerMouseOrbit component = this.m_MainCameraGameObj.GetComponent<M_PlayerMouseOrbit>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		M_PlayerMouseOrbit m_PlayerMouseOrbit = nextCamera.GetComponent<M_PlayerMouseOrbit>();
    //		if (m_PlayerMouseOrbit == null)
    //		{
    //			m_PlayerMouseOrbit = nextCamera.AddComponent<M_PlayerMouseOrbit>();
    //		}
    //		m_PlayerMouseOrbit.m_Target = component.m_Target;
    //		m_PlayerMouseOrbit.m_Distance = component.m_Distance;
    //		m_PlayerMouseOrbit.m_XAngle = component.m_XAngle;
    //		m_PlayerMouseOrbit.m_YAngle = component.m_YAngle;
    //		m_PlayerMouseOrbit.m_DistanceMax = component.m_DistanceMax;
    //		m_PlayerMouseOrbit.m_DistanceMin = component.m_DistanceMin;
    //		m_PlayerMouseOrbit.m_DistanceByPhysics = component.m_DistanceByPhysics;
    //		AudioListener component2 = m_PlayerMouseOrbit.GetComponent<AudioListener>();
    //		if (component2 != null)
    //		{
    //			component2.enabled = false;
    //		}
    //		nextCamera.SetActive(true);
    //		this.m_MainCameraGameObj.SetActive(false);
    //		this.m_MainCameraGameObj = nextCamera;
    //		DepthOfFieldScatter component3 = this.m_MainCameraGameObj.GetComponent<DepthOfFieldScatter>();
    //		if (component3 != null)
    //		{
    //			foreach (Transform transform in this.m_GameApp.m_GameObjSystem.PlayerObj.transform)
    //			{
    //				if (transform.name == "CamPos")
    //				{
    //					component3.focalTransform = transform;
    //					break;
    //				}
    //			}
    //		}
    //	}

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
    //				break;
    //			}
    //		}
    //	}

    //	public void EnableMainCamera(bool enable)
    //	{
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		if (gameObject)
    //		{
    //			Camera component = gameObject.GetComponent<Camera>();
    //			if (component)
    //			{
    //				component.enabled = enable;
    //			}
    //			AudioListener component2 = gameObject.GetComponent<AudioListener>();
    //			if (component2)
    //			{
    //				UnityEngine.Object.Destroy(component2);
    //			}
    //			M_LayerCullDistance component3 = gameObject.GetComponent<M_LayerCullDistance>();
    //			if (component3 == null)
    //			{
    //				gameObject.AddComponent<M_LayerCullDistance>();
    //			}
    //		}
    //		GameObject playerObj = Swd6Application.instance.m_GameObjSystem.PlayerObj;
    //		if (playerObj)
    //		{
    //			AudioListener component4 = playerObj.GetComponent<AudioListener>();
    //			if (component4)
    //			{
    //				component4.enabled = enable;
    //			}
    //		}
    //	}

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
    //					if (transform.name == "CamPos")
    //					{
    //						component.focalTransform = transform;
    //						break;
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

    //	public void SetCameraCullingEffect(bool enabled)
    //	{
    //		GameObject gameObject = GameObject.Find("Main Camera");
    //		if (gameObject == null)
    //		{
    //			gameObject = GameObject.FindWithTag("MainCamera");
    //		}
    //		if (gameObject)
    //		{
    //			Camera component = gameObject.GetComponent<Camera>();
    //			if (component)
    //			{
    //				component.useOcclusionCulling = enabled;
    //			}
    //		}
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
    //		int num = 4;
    //		num = ~num;
    //		light.cullingMask = num;
    //		light.range = 10f;
    //		light.color = new Color(0.784313738f, 0.784313738f, 0.784313738f);
    //		light.intensity = 1.36f;
    //		light.enabled = enable;
    //		light.type = LightType.Point;
    //		gameObject.transform.parent = this.PlayerObj.transform;
    //		gameObject.transform.position = this.PlayerObj.transform.position + new Vector3(0f, 1f, 0f);
    //	}

    //	public void SetMapRainEffect()
    //	{
    //		if (this.m_RainEffect == null)
    //		{
    //			this.m_RainEffect = ResourceManager.Instance.GetEffect("Rain_Effect_02");
    //		}
    //	}

    //	public void RemoveMapRainEffect()
    //	{
    //		if (this.m_RainEffect != null)
    //		{
    //			UnityEngine.Object.Destroy(this.m_RainEffect);
    //			this.m_RainEffect = null;
    //		}
    //	}

    public void SwitchPlayer()
    {
        Vector3 position = this.PlayerObj.transform.position;
        float y = this.PlayerObj.transform.eulerAngles.y;
        //this.m_GameApp.m_GameObjSystem.RemovePlayerGameObj();
        //this.PlayerObj = this.m_GameApp.m_GameObjSystem.CreatePlayerGameObj(this.m_GameApp.m_GameDataSystem.m_PlayerID, position, y);
        //this.m_GameApp.m_GameObjSystem.ClearPlayer3MaterailData();
        //if (!this.m_UseNoFightItem)
        //{
        //    this.ClearNoFightData(true);
        //}
        //GameMath.CastObjectOnTerrain(this.PlayerObj, 0.5f);
        //this.PlayerObj.transform.position += new Vector3(0f, 0.1f, 0f);
        //this.SetCameraLookTarget(false);
        //this.SetAmberPigTargetPos();
        //GameMapMobSystem.Instance.SetTarget(this.PlayerObj);
        //if (this.m_GameApp.m_GameDataSystem.GetFlag(52))
        //{
        //    this.SetPlayerPointLight(true);
        //}
        //if (this.m_GameApp.m_GameDataSystem.m_MapInfo.MapID == 64 && !this.m_GameApp.m_GameDataSystem.GetFlag(56))
        //{
        //    this.SetMapRainEffect();
        //}
    }

    //	public void EnterFight(int battleId, bool bHit)
    //	{
    //		if (this.m_BattleID > 0)
    //		{
    //			return;
    //		}
    //		UnityEngine.Debug.LogWarning("EnterFight_" + battleId);
    //		this.m_GameApp.m_SaveloadSystem.AutoSave1(ENUM_AUTOSAVETYPE.Fight);
    //		S_BattleRate data = GameDataDB.BattleRateDB.GetData(battleId);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.LogWarning("EnterFight::讀取BattleRateDB表錯誤_" + battleId);
    //			return;
    //		}
    //		int fightPlayerID = 0;
    //		int num = 0;
    //		int num2 = 0;
    //		int num3 = 4;
    //		int num4 = UnityEngine.Random.Range(0, 100);
    //		if (data.Flag.Count > 0 && this.m_GameApp.m_GameDataSystem.GetFlag(data.Flag[0]))
    //		{
    //			num2 = 5;
    //			num3 = data.Group.Count;
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				UnityEngine.Debug.Log("EnterFight::Night_" + battleId);
    //			}
    //		}
    //		if (num3 > data.Group.Count)
    //		{
    //			num3 = data.Group.Count;
    //		}
    //		for (int i = num2; i < num3; i++)
    //		{
    //			if (data.Group[i].GroupID != 0)
    //			{
    //				num += data.Group[i].GroupRate;
    //				if (num4 <= num)
    //				{
    //					this.m_BattleID = data.Group[i].GroupID;
    //					if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //					{
    //						UnityEngine.Debug.Log(string.Concat(new object[]
    //						{
    //							"Rate_",
    //							num,
    //							"_",
    //							num4,
    //							"_",
    //							this.m_BattleID
    //						}));
    //					}
    //					if (bHit)
    //					{
    //						fightPlayerID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //					}
    //					FightSystem.Instance.Fight(this.m_BattleID, fightPlayerID);
    //					break;
    //				}
    //			}
    //		}
    //		this.LockPlayer = true;
    //		UI_ZoneMap.Instance.Hide();
    //	}

    //	public void ClearBattleInfo()
    //	{
    //		this.m_BattleID = 0;
    //	}

    //	public bool AvoidMob(float time, bool item)
    //	{
    //		if (!this.m_GameApp.m_GameDataSystem.GetFlag(41))
    //		{
    //			return false;
    //		}
    //		if (item)
    //		{
    //			Swd6Application.instance.m_GameObjSystem.RestorePlayer3Materail(this.PlayerObj);
    //			this.ClearNoFightData(false);
    //			this.m_UseNoFightItem = true;
    //		}
    //		if (this.m_NoFightCDTime > 0f)
    //		{
    //			return true;
    //		}
    //		this.m_NoFightTime = time;
    //		this.m_NoFightCDTime = 12f;
    //		this.BattleStep = 0f;
    //		UI_Explore.Instance.ShowBuffer();
    //		if (!item)
    //		{
    //			MusicSystem.Instance.PlaySound(202, 1);
    //			Swd6Application.instance.m_GameObjSystem.ChangePlayer3Materail(this.PlayerObj);
    //		}
    //		return true;
    //	}

    //	public bool IsAvoidMob()
    //	{
    //		return this.m_NoFightTime > 0f || this.m_NoFightCDTime > 0f;
    //	}

    //	public void UseActionSkill()
    //	{
    //		this.UpdateHitDamageDelayTime();
    //	}

    //	public void AddHitDamageDelayTime()
    //	{
    //		if (this.LockPlayer)
    //		{
    //			return;
    //		}
    //		this.m_HitDamageDelayTime = 0.25f;
    //		this.LockPlayer = true;
    //	}

    //	public void UpdateHitDamageDelayTime()
    //	{
    //		if (this.m_HitDamageDelayTime > 0f)
    //		{
    //		}
    //	}

    //	public void ReStartPos(List<Vector3> ResetPointList)
    //	{
    //		if (ResetPointList.Count > 0)
    //		{
    //			float num = 1E+08f;
    //			for (int i = 0; i < ResetPointList.Count; i++)
    //			{
    //				float num2 = Vector3.Distance(this.PlayerController.Pos, ResetPointList[i]);
    //				if (num2 < num)
    //				{
    //					num = num2;
    //					this.m_ReStartPos = ResetPointList[i];
    //				}
    //			}
    //		}
    //		RaycastHit raycastHit;
    //		bool flag = Physics.Raycast(this.m_ReStartPos + new Vector3(0f, 0.5f, 0f), Vector3.up * -1f, out raycastHit, 3f);
    //		if (flag)
    //		{
    //			this.m_ReStartPos = raycastHit.point;
    //		}
    //		this.BattleStep = 0f;
    //		this.m_bSetReStarPos = false;
    //		this.PlayerController.Pos = this.m_ReStartPos;
    //	}

    //	public void SetPlayMusicDelayTime(float delayTime)
    //	{
    //		this.m_PlayMusicDelayTime = delayTime;
    //	}

    //	public void GetSkill(int roleId)
    //	{
    //		GameDataDB.SkillDB.ResetByOrder();
    //		int dataSize = GameDataDB.SkillDB.GetDataSize();
    //		for (int i = 0; i < dataSize; i++)
    //		{
    //			S_Skill dataByOrder = GameDataDB.SkillDB.GetDataByOrder();
    //			if (dataByOrder != null && dataByOrder.emSkillEffectType == ENUM_SkillEffectType.Skill && dataByOrder.LearnRole == roleId)
    //			{
    //				Swd6Application.instance.m_SkillSystem.LearnSkill(roleId, dataByOrder.GUID);
    //			}
    //		}
    //	}

    //	private void ChangeSky()
    //	{
    //		MapSoundManager mapSoundManager = null;
    //		if (this.m_MapSoundEvent != null)
    //		{
    //			mapSoundManager = this.m_MapSoundEvent.GetComponent<MapSoundManager>();
    //		}
    //		if (this.m_MapData.SkyID == -1)
    //		{
    //			if (SkySystem.Instance.isDefaultSkyNow())
    //			{
    //				if (mapSoundManager != null)
    //				{
    //					mapSoundManager.ChangeSoundGroup(SkySystem.Instance.GetDefaultSkyID());
    //				}
    //				return;
    //			}
    //			SkySystem.Instance.ChangeToDefaultSky();
    //			if (mapSoundManager != null)
    //			{
    //				mapSoundManager.ChangeSoundGroup(SkySystem.Instance.GetDefaultSkyID());
    //			}
    //		}
    //		else
    //		{
    //			SkySystem.Instance.ChangeSky(this.m_MapData.SkyID, true);
    //			if (mapSoundManager != null)
    //			{
    //				mapSoundManager.ChangeSoundGroup(this.m_MapData.SkyID);
    //			}
    //		}
    //	}

    //	public int CreateEffect(Vector3 pos, string effectName)
    //	{
    //		GameObject effect = ResourceManager.Instance.GetEffect(effectName);
    //		if (effect == null)
    //		{
    //			return 0;
    //		}
    //		this.m_EffectSerialID++;
    //		this.m_EffectList.Add(this.m_EffectSerialID, effect);
    //		effect.transform.position = pos;
    //		return this.m_EffectSerialID;
    //	}

    //	public void RemoveEffect(int id)
    //	{
    //		if (this.m_EffectList.ContainsKey(id))
    //		{
    //			this.m_EffectList.Remove(id);
    //		}
    //	}

    //	public void ClearAllEffect()
    //	{
    //		foreach (GameObject current in this.m_EffectList.Values)
    //		{
    //			UnityEngine.Object.Destroy(current);
    //		}
    //		this.m_EffectSerialID = 0;
    //		this.m_EffectList.Clear();
    //	}
}
