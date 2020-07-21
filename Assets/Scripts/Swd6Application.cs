//using DLCData;
//using mset;
//using Nini.Config;
//using SoftStarStatisticsSheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Swd6Application : GameApplication
{
    [HideInInspector]
    public bool GamePause;

    [HideInInspector]
    public bool m_Is64BitOS = true;

    public bool m_IsStoryTest = true;

    public bool m_DBFLog;

    public bool m_Password;

    public int m_ChapID = 100;

    private byte[] m_CaptureImageData;

    private Texture2D m_CaptureTexture;

    private bool m_CaptureScale;

    private float m_UpdateResizeTime;

    private float m_UpdateCkTime;

   // public UIRoot m_UIRoot;

    public GameObject m_ShroudMgr;

    //public Sky m_MainMenuSky;

   // private S_GameFlag m_DLCFlag = new S_GameFlag();

    [HideInInspector]
    public bool m_InitializeOK;

    public Transform _SonySecurityPrefab;

    //private SonySecurity _SonySecurity;

    private float _firstAssetsCheckStartTime = 1f;

    private float _repeatAssetsCheckEverySeconds = 10f;

    private float _pastedAssetsCheckTime;

    private bool _updatePastedAssetsCheckTime;

    private float _timeToGoThroughAllChecksOnce;

    private float _pastedTimeToGoThroughAllChecksOnce;

    private bool _allChecksGoneThroughOnce;

    private bool _showAllChecksGoneThroughMsgBox = true;

    private static bool _crackDetected;

    private Resolution[] m_DefaultResolutions;

    private Resolution[] m_Resolutions;

    public static Swd6Application instance
    {
        get
        {
            return GameApplication._instance as Swd6Application;
        }
    }

    //public GameObjSystem m_GameObjSystem
    //{
    //    get;
    //    private set;
    //}

    public GameDataSystem m_GameDataSystem
    {
        get;
        private set;
    }

    //	public ExploreSystem m_ExploreSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public GameMenuSystem m_GameMenuSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public QuestSystem m_QuestSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public ItemSystem m_ItemSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public IdentifySystem m_IdentifySystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public SaveloadSystem m_SaveloadSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public SkillSystem m_SkillSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public MobGuardSystem m_MobGuardSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public AchievementSystem m_AchievementSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public WOPSystem m_WOPSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public InheritSystem m_InheritSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public MapPathSystem m_MapPathSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public FormationSystem m_FormationSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public BigMapSystem m_BigMapSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public SmallTrapGameSystem m_SmallTrapGameSystem
    //	{
    //		get;
    //		private set;
    //	}

    public StorySystem m_StorySystem
    {
        get;
        private set;
    }

    //	public MusicSystem m_MusicControlSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public QualitySettingSystem m_QualitySettingSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public MovieSystem m_MovieSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public NormalSettingSystem m_NormalSettingSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public SoundSettingSystem m_SoundSettingSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public ControlSettingSystem m_ControlSettingSystem
    //	{
    //		get;
    //		private set;
    //	}

    //	public UserBehavior m_UserBehavior
    //	{
    //		get;
    //		private set;
    //	}

    //	private void OnDisable()
    //	{
    //		dss_api.CrackDetected = (dss_api.CrackDetectedDelegate)Delegate.Remove(dss_api.CrackDetected, new dss_api.CrackDetectedDelegate(Swd6Application.CrackDetectedCallback));
    //	}

    //	protected virtual void OnApplicationQuit()
    //	{
    //		MovieSystem.Instance.StopMovie();
    //		Application.CancelQuit();
    //		Process.GetCurrentProcess().Kill();
    //	}

    //	protected virtual void OnLevelWasLoaded(int level)
    //	{
    //		this.m_QualitySettingSystem.UpdateSceneQuality();
    //	}

    //	public bool CheckDLC()
    //	{
    //		float num = float.Parse("1.04");
    //		return num >= 1.04f;
    //	}

    public override void Update()
    {
        if (this.GamePause)
        {
            return;
        }
        base.Update();
        if (this.m_InitializeOK)
        {
            //if (this.m_ResourceType == ENUM_ResourceType.Runtime)
            //{
            //    this.UpdateSonySystem();
            //    this.UpdateCK();
            //}

            if (this.m_GameDataSystem != null)
            {
                this.m_GameDataSystem.Update();
            }

            //if (this.m_QuestSystem != null)
            //{
            //    this.m_QuestSystem.Update();
            //}
            //if (this.m_AchievementSystem != null)
            //{
            //    this.m_AchievementSystem.Update();
            //}
            GameInput.Update();
            //GameCursor.Update();
            //if (this.m_UpdateResizeTime > 0f)
            //{
            //    this.m_UpdateResizeTime -= Time.deltaTime;
            //    if (this.m_UpdateResizeTime <= 0f)
            //    {
            //        this.m_UpdateResizeTime = 0f;
            //    }
            //}
        }
    }

    //	private void UpdateSonySystem()
    //	{
    //		if (Time.time > this._firstAssetsCheckStartTime && !this._updatePastedAssetsCheckTime)
    //		{
    //			this.CheckSonySecurityExistance();
    //			this._updatePastedAssetsCheckTime = true;
    //			this._timeToGoThroughAllChecksOnce = this._firstAssetsCheckStartTime;
    //			if (this._SonySecurity.FirstDataDirectoryCheckStartTime > this._timeToGoThroughAllChecksOnce)
    //			{
    //				this._timeToGoThroughAllChecksOnce = this._SonySecurity.FirstDataDirectoryCheckStartTime;
    //			}
    //			if (this._SonySecurity.FirstCompareImageSizeCheckStartTime > this._timeToGoThroughAllChecksOnce)
    //			{
    //				this._timeToGoThroughAllChecksOnce = this._SonySecurity.FirstCompareImageSizeCheckStartTime;
    //			}
    //			if (this._SonySecurity.FirstHiddenSectionCheckTime > this._timeToGoThroughAllChecksOnce)
    //			{
    //				this._timeToGoThroughAllChecksOnce = this._SonySecurity.FirstHiddenSectionCheckTime;
    //			}
    //			if (this._SonySecurity.FirstLicenceCheckStartTime > this._timeToGoThroughAllChecksOnce)
    //			{
    //				this._timeToGoThroughAllChecksOnce = this._SonySecurity.FirstLicenceCheckStartTime;
    //			}
    //		}
    //		if (this._pastedAssetsCheckTime > this._repeatAssetsCheckEverySeconds)
    //		{
    //			this.CheckSonySecurityExistance();
    //			this._pastedAssetsCheckTime = 0f;
    //		}
    //		if (this._updatePastedAssetsCheckTime)
    //		{
    //			this._pastedAssetsCheckTime += Time.deltaTime;
    //		}
    //		if (!this._allChecksGoneThroughOnce && this._SonySecurity != null)
    //		{
    //			if (this._pastedTimeToGoThroughAllChecksOnce > this._timeToGoThroughAllChecksOnce - this._firstAssetsCheckStartTime + 0.2f)
    //			{
    //				this._allChecksGoneThroughOnce = true;
    //			}
    //			else
    //			{
    //				this._pastedTimeToGoThroughAllChecksOnce += Time.deltaTime;
    //			}
    //		}
    //	}

    //	private SonySecurity CheckSonySecurityExistance()
    //	{
    //		this._SonySecurity = (SonySecurity)UnityEngine.Object.FindObjectOfType(typeof(SonySecurity));
    //		if (this._SonySecurity == null)
    //		{
    //			if (this._SonySecurityPrefab == null)
    //			{
    //				dss_api.AssetsFailed();
    //			}
    //			else
    //			{
    //				Transform transform = UnityEngine.Object.Instantiate(this._SonySecurityPrefab) as Transform;
    //				transform.name = this._SonySecurityPrefab.name;
    //				this._SonySecurity = transform.GetComponent<SonySecurity>();
    //				if (this._SonySecurity == null)
    //				{
    //					dss_api.AssetsFailed();
    //				}
    //			}
    //		}
    //		return this._SonySecurity;
    //	}

    //	public static void CrackDetectedCallback(dss_api.FailReason failReason, int id)
    //	{
    //		string path = Application.dataPath + "/../SWD6E.exe";
    //		try
    //		{
    //			FileStream fileStream = File.OpenRead(path);
    //			if (fileStream != null && fileStream.Length > 17400000L && fileStream.Length < 17800000L)
    //			{
    //				return;
    //			}
    //		}
    //		catch
    //		{
    //		}
    //		Swd6Application.instance.SetCK(id);
    //	}

    //	public void SetCK(int id)
    //	{
    //		if (this.m_UpdateCkTime != 0f)
    //		{
    //			return;
    //		}
    //		this.m_UpdateCkTime = (float)UnityEngine.Random.Range(180, 240);
    //		UnityEngine.Debug.LogWarning("CD " + id);
    //	}

    //	public void UpdateCK()
    //	{
    //		if (this.m_UpdateCkTime == 0f)
    //		{
    //			return;
    //		}
    //		this.m_UpdateCkTime -= Time.deltaTime;
    //		if (this.m_UpdateCkTime <= 0f)
    //		{
    //			this.ShowCrackDetected = true;
    //			this.m_UpdateCkTime = 0f;
    //			switch (UnityEngine.Random.Range(0, 6))
    //			{
    //			case 0:
    //				this.m_GameDataSystem = null;
    //				this.m_SaveloadSystem = null;
    //				break;
    //			case 1:
    //				this.m_GameDataSystem = null;
    //				this.m_GameObjSystem = null;
    //				break;
    //			case 2:
    //				this.m_GameDataSystem = null;
    //				this.m_ExploreSystem = null;
    //				break;
    //			case 3:
    //				this.m_GameDataSystem = null;
    //				this.m_ItemSystem = null;
    //				this.m_QuestSystem = null;
    //				break;
    //			case 4:
    //				this.m_GameDataSystem = null;
    //				this.m_SkillSystem = null;
    //				this.m_StorySystem = null;
    //				break;
    //			case 5:
    //				this.m_GameDataSystem = null;
    //				this.m_BigMapSystem = null;
    //				this.m_SaveloadSystem = null;
    //				break;
    //			}
    //		}
    //	}

    protected override void initialize()
    {
        base.StartCoroutine(this.InitializeNormalGame());
    }

    /// <summary>
    /// 初始化系统设置
    /// </summary>
    protected void InitSystemSettings()
    {
        GameInput.Initialize();
        //this.m_QualitySettingSystem = new QualitySettingSystem();
        //this.m_QualitySettingSystem.Initialize();
        //this.m_NormalSettingSystem = new NormalSettingSystem();
        //this.m_NormalSettingSystem.Initialize();
        //this.m_SoundSettingSystem = new SoundSettingSystem();
        //this.m_SoundSettingSystem.Initialize();
        //this.m_ControlSettingSystem = new ControlSettingSystem();
        //this.m_ControlSettingSystem.Initialize();
        //this.LoadSettings();
        //this.m_QualitySettingSystem.SetFirstGameQuality();
        //this.m_ControlSettingSystem.UpdateControlSetting();
        //this.SaveSettings(false);
    }

    private IEnumerator InitializeNormalGame()
    {
        this.InitSystemSettings();
        yield return null;
        //GameCursor.Init();
        this.ReadGameDB();
        this.InitGameSystem();
        this.InitGameState();
        this.InitRequiredObject();
        this.m_InitializeOK = true;
        this.SwitchState("MenuState");

        UnityEngine.Debug.Log("初始化完成!!");
        yield break;
    }

    protected virtual void ReadGameDB()
    {
        string mapBlockPath = Application.dataPath + "/../DBF/";
        string dbf_Path = Application.dataPath + "/../DBF/";
        string languagePath = Application.dataPath + "/../DBF/";
        GameDataDB.SetConevrt(new SwdJsonCovertor());
        //GameDataDB.Initialize(mapBlockPath, dbf_Path, languagePath);
        //GameDataDB.LoadDBF();
        //GameDataDB.LoadLanguage();
    }

    protected virtual void InitGameState()
    {
        //base.AddGameState(new LoadingState("LoadingState", "Loading", this));
        base.AddGameState(new MenuState("MenuState", "Main", this));
        //base.AddGameState(new ExploreState("ExploreState", string.Empty, this));
        //base.AddGameState(new StoryState("StoryState", string.Empty, this));
        //base.AddGameState(new FightState("FightState", string.Empty, this));
        //base.AddGameState(new BigMapState("BigMapState", string.Empty, this));
        //base.AddGameState(new GameMenuState("GameMenuState", string.Empty, this));
        //base.AddGameState(new GameEndState("GameEndState", string.Empty, this));
        //base.AddGameState(new SmallTrapGameState("SmallTrapGameState", string.Empty, this));
    }

    protected virtual void InitGameSystem()
    {
        //this.m_GameObjSystem = new GameObjSystem();
        //this.m_GameObjSystem.Initialize();
        this.m_GameDataSystem = new GameDataSystem();
        this.m_GameDataSystem.Initialize();
        //this.m_ExploreSystem = new ExploreSystem();
        //this.m_ExploreSystem.Initialize(this);
        //this.m_GameMenuSystem = new GameMenuSystem();
        //this.m_GameMenuSystem.Initialize(this);
        //this.m_QuestSystem = new QuestSystem();
        //this.m_QuestSystem.Initialize(this);
        //this.m_IdentifySystem = new IdentifySystem();
        //this.m_IdentifySystem.Initialize(this);
        //this.m_ItemSystem = new ItemSystem();
        //this.m_ItemSystem.Initialize(this);
        //this.m_SaveloadSystem = new SaveloadSystem();
        //this.m_SaveloadSystem.Initialize();
        //this.m_SkillSystem = new SkillSystem();
        //this.m_SkillSystem.Initialize();
        //this.m_MobGuardSystem = new MobGuardSystem();
        //this.m_MobGuardSystem.Initialize();
        //this.m_AchievementSystem = new AchievementSystem();
        //this.m_AchievementSystem.Initialize();
        //this.m_InheritSystem = new InheritSystem();
        //this.m_InheritSystem.Initialize(this);
        //this.m_MapPathSystem = new MapPathSystem();
        //this.m_MapPathSystem.Initialize();
        //this.m_FormationSystem = new FormationSystem();
        //this.m_FormationSystem.Initialize();
        //this.m_BigMapSystem = new BigMapSystem();
        //this.m_BigMapSystem.Initialize();
        //this.m_SmallTrapGameSystem = new SmallTrapGameSystem();
        //this.m_WOPSystem = new WOPSystem();
        //this.m_WOPSystem.Initialize();
        //if (this.m_WOPSystem.IsDebug())
        //{
        //    this.m_WOPSystem.InitForNewGame();
        //}
        this.m_StorySystem = new StorySystem();
        this.m_StorySystem.Initialize();
        //this.m_MusicControlSystem = new MusicSystem();
        //this.m_MovieSystem = new MovieSystem();
        //this.m_UserBehavior = new UserBehavior();
        //this.m_UserBehavior.DirectoryPath = Application.dataPath + "/../Launcher/UBData/";
        //if (this.m_NormalSettingSystem.GetNormalSetting().m_IsDlC)
        //{
        //    this.m_ChapID = 101;
        //}
        //else
        //{
        //    this.m_ChapID = 100;
        //}
        //this.InitChapterData(this.m_ChapID);
        //this.InitDLCItem();
        //this.SetGameEnviromentInfo();
    }

    //	protected void InitDLCItem()
    //	{
    //		string text = Application.dataPath + "/../Launcher/DCData/dc.dat";
    //		string path = Application.dataPath + "/../Launcher/DCData/key.txt";
    //		string text2 = Application.dataPath + "/../Launcher/DCData/key.dat";
    //		string text3 = base.name + "txt";
    //		string cDKey = string.Empty;
    //		if (!File.Exists(text))
    //		{
    //			return;
    //		}
    //		if (File.Exists(path))
    //		{
    //			StreamReader streamReader = File.OpenText(path);
    //			if (streamReader != null)
    //			{
    //				cDKey = streamReader.ReadLine();
    //				streamReader.Close();
    //			}
    //			Dictionary<string, int> items = DLCFileReader.GetItems(text, cDKey);
    //			if (items != null && items.Count > 0 && items.ContainsKey("DLC1"))
    //			{
    //				this.m_DLCFlag.ON(100);
    //			}
    //		}
    //		else if (File.Exists(text2))
    //		{
    //			Dictionary<string, int> itemsByFile = DLCFileReader.GetItemsByFile(text, text2);
    //			if (itemsByFile != null && itemsByFile.Count > 0 && itemsByFile.ContainsKey("DLC1"))
    //			{
    //				this.m_DLCFlag.ON(100);
    //			}
    //		}
    //	}

    //	public bool CheckDLCItem(int id)
    //	{
    //		return this.m_DLCFlag.Get(id);
    //	}

    //	protected void SetGameEnviromentInfo()
    //	{
    //		this.m_UserBehavior.EnviromentInfo.SetEquipmentInfo(new object[]
    //		{
    //			SystemInfo.processorType,
    //			SystemInfo.systemMemorySize.ToString(),
    //			SystemInfo.operatingSystem,
    //			SystemInfo.graphicsDeviceName
    //		});
    //		NormalSetting normalSetting = this.m_NormalSettingSystem.GetNormalSetting();
    //		this.m_UserBehavior.EnviromentInfo.SetNormalSetting(normalSetting);
    //		QualitySetting qualitySetting = this.m_QualitySettingSystem.GetQualitySetting();
    //		this.m_UserBehavior.EnviromentInfo.SetQualitySetting(qualitySetting);
    //		SoundSetting soundSetting = this.m_SoundSettingSystem.GetSoundSetting();
    //		this.m_UserBehavior.EnviromentInfo.SetSoundSetting(soundSetting);
    //		Dictionary<KEY_ACTION, KeyCode> keyList = this.m_ControlSettingSystem.GetKeyList();
    //		this.m_UserBehavior.EnviromentInfo.SetOperationSetting(keyList);
    //		this.m_UserBehavior.Save();
    //	} 

    protected virtual void InitRequiredObject()
    {
        //this.m_ShroudMgr = ResourceManager.Instance.GetOther("ShroudMgr");
        //if (this.m_ShroudMgr != null)
        //{
        //    UnityEngine.Object.DontDestroyOnLoad(this.m_ShroudMgr);
        //}
        //GameObject other = ResourceManager.Instance.GetOther("MainMenuSky");
        //if (other != null)
        //{
        //    this.m_MainMenuSky = other.GetComponent<Sky>();
        //    if (this.m_MainMenuSky != null)
        //    {
        //        UnityEngine.Object.DontDestroyOnLoad(other);
        //    }
        //}
    }

    //	public void changeStateByLoading(string stateName)
    //	{
    //		SceneState sceneState = base.GetGameStateByName(stateName) as SceneState;
    //		string sceneName = sceneState.getSceneName();
    //		this.ChangeStateByLoading(stateName, sceneName);
    //	}

    //	public void ChangeStateByLoading(string stateName, string sceneName)
    //	{
    //		LoadingState loadingState = base.GetGameStateByName("LoadingState") as LoadingState;
    //		loadingState.setNextSceneState(stateName, sceneName);
    //		base.StartCoroutine(this.SwitchToLoading());
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator SwitchToLoading()
    //	{
    //		Swd6Application.<SwitchToLoading>c__Iterator874 <SwitchToLoading>c__Iterator = new Swd6Application.<SwitchToLoading>c__Iterator874();
    //		<SwitchToLoading>c__Iterator.<>f__this = this;
    //		return <SwitchToLoading>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public IEnumerator WaiteStateByLoading()
    //	{
    //		Swd6Application.<WaiteStateByLoading>c__Iterator875 <WaiteStateByLoading>c__Iterator = new Swd6Application.<WaiteStateByLoading>c__Iterator875();
    //		<WaiteStateByLoading>c__Iterator.<>f__this = this;
    //		return <WaiteStateByLoading>c__Iterator;
    //	}

    //	public void ChangeMap(string stateName, int mapid, float x, float y, float z, float dir)
    //	{
    //		this.m_ExploreSystem.AutoSave();
    //		if (this.m_ExploreSystem.m_TalkEventObj != null)
    //		{
    //			this.m_ExploreSystem.m_DontRemoveObj = this.m_ExploreSystem.m_TalkEventObj;
    //			if (this.m_ExploreSystem.m_DontRemoveObj != null)
    //			{
    //				UnityEngine.Object.DontDestroyOnLoad(this.m_ExploreSystem.m_DontRemoveObj);
    //			}
    //			this.m_ExploreSystem.m_DontRemoveObj.transform.parent = base.gameObject.transform;
    //		}
    //		S_MapData mapData = this.m_GameDataSystem.GetMapData(mapid);
    //		if (mapData != null)
    //		{
    //			this.m_GameDataSystem.m_MapInfo.MapID = mapid;
    //			this.m_ExploreSystem.PlayerChangePos = new Vector3(x, y, z);
    //			this.m_ExploreSystem.PlayerChangeDir = dir;
    //			this.m_ExploreSystem.PlayerController = null;
    //			this.ChangeStateByLoading(stateName, mapData.Name);
    //		}
    //		else
    //		{
    //			UnityEngine.Debug.LogWarning("Map_" + mapid + " Load Error!!");
    //		}
    //	}

    //	public void ChangeMap(string stateName, int mapid, string pointName)
    //	{
    //		this.m_ExploreSystem.AutoSave();
    //		if (this.m_ExploreSystem.m_TalkEventObj != null)
    //		{
    //			this.m_ExploreSystem.m_DontRemoveObj = this.m_ExploreSystem.m_TalkEventObj;
    //			if (this.m_ExploreSystem.m_DontRemoveObj != null)
    //			{
    //				UnityEngine.Object.DontDestroyOnLoad(this.m_ExploreSystem.m_DontRemoveObj);
    //			}
    //			this.m_ExploreSystem.m_DontRemoveObj.transform.parent = base.gameObject.transform;
    //		}
    //		S_MapData mapData = this.m_GameDataSystem.GetMapData(mapid);
    //		if (mapData != null)
    //		{
    //			this.m_GameDataSystem.m_MapInfo.MapID = mapid;
    //			this.m_ExploreSystem.PlayerChangePoint = pointName;
    //			this.m_ExploreSystem.PlayerController = null;
    //			this.ChangeStateByLoading(stateName, mapData.Name);
    //		}
    //		else
    //		{
    //			UnityEngine.Debug.LogWarning("Map_" + mapid + " Load Error!!");
    //		}
    //	}

    //	public void ChangeToExploreState(int mapid, float x, float y, float z, float dir)
    //	{
    //		if (mapid == this.m_GameDataSystem.m_MapInfo.MapID)
    //		{
    //			this.m_GameDataSystem.m_MapInfo.MapID = mapid;
    //			this.m_ExploreSystem.PlayerChangePos = new Vector3(x, y, z);
    //			this.m_ExploreSystem.PlayerChangeDir = dir;
    //			if (base.gameStateService.getActiveStatesCount() <= 1)
    //			{
    //				this.SwitchState("ExploreState");
    //				if (!Swd6Application.instance.m_ExploreSystem.m_PlayStory)
    //				{
    //					UI_Fade.Instance.FadeTo(0f, 1f);
    //				}
    //			}
    //			else
    //			{
    //				this.FadeAndPopState(1f);
    //			}
    //		}
    //		else
    //		{
    //			this.ChangeMap("ExploreState", mapid, x, y, z, dir);
    //		}
    //	}

    //	public void ChangeToExploreState(int mapid, string pointName)
    //	{
    //		if (mapid == this.m_GameDataSystem.m_MapInfo.MapID)
    //		{
    //			this.m_GameDataSystem.m_MapInfo.MapID = mapid;
    //			GameObject gameObject = GameObject.Find(pointName);
    //			if (gameObject != null)
    //			{
    //				this.m_ExploreSystem.PlayerChangePos = gameObject.transform.position;
    //				this.m_ExploreSystem.PlayerChangeDir = gameObject.transform.eulerAngles.y;
    //			}
    //			else
    //			{
    //				this.m_ExploreSystem.PlayerChangePoint = pointName;
    //			}
    //			if (base.gameStateService.getActiveStatesCount() <= 1)
    //			{
    //				this.SwitchState("ExploreState");
    //				if (!Swd6Application.instance.m_ExploreSystem.m_PlayStory)
    //				{
    //					UI_Fade.Instance.FadeTo(0f, 1f);
    //				}
    //			}
    //			else
    //			{
    //				this.FadeAndPopState(1f);
    //			}
    //		}
    //		else
    //		{
    //			this.ChangeMap("ExploreState", mapid, pointName);
    //		}
    //	}

    public void ChangeToStoryState(int mapID, string storyName)
    {
        string text = "StoryState";
        //StoryState storyState = base.GetGameStateByName(text) as StoryState;
        //if (storyState == null)
        //{
        //    UnityEngine.Debug.LogError("Can not get StoryState");
        //    return;
        //}
        GameState currentGameState = base.GetCurrentGameState();
        if (currentGameState == null)
        {
            UnityEngine.Debug.LogError("Can not get currentGameState");
            return;
        }
       // storyState.SetStoryName(storyName);
        //if (mapID == 100 && currentGameState is MenuState)
        //{
        //    base.StartCoroutine(base.PushState(text));
        //}
        //else if (mapID == this.m_GameDataSystem.m_MapInfo.MapID)
        //{
        //    if (currentGameState is StoryState)
        //    {
        //        storyState.CreateNewStory();
        //    }
        //    else if (currentGameState is ExploreState)
        //    {
        //        base.StartCoroutine(base.PushState(text));
        //    }
        //    else if (currentGameState is FightState)
        //    {
        //        this.SwitchState(text);
        //    }
        //    else if (currentGameState is MenuState)
        //    {
        //        base.StartCoroutine(base.PushState(text));
        //    }
        //}
        //else
        //{
        //    //this.ChangeMap(text, mapID, 0f, 0f, 0f, 0f);
        //}
    }

    //	public void GameEnd()
    //	{
    //		base.StartCoroutine(base.ChangeState("GameEndState"));
    //	}

    //	public void ChangeToFightState()
    //	{
    //		base.StartCoroutine(base.PushState("FightState"));
    //	}

    //	public void ChangeToUTFightState()
    //	{
    //		base.StartCoroutine(base.PushState("UTFightState"));
    //	}

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="stateName"></param>
    public void SwitchState(string stateName)
    {
        base.StartCoroutine(base.ChangeState(stateName));
    }

    //	public void FadeAndPopState(float time)
    //	{
    //		base.StartCoroutine(this.DoFadeAndPopState(time, -1f));
    //	}

    //	public void FadeAndPopState2(float fadeIntime, float fadeOutTime)
    //	{
    //		base.StartCoroutine(this.DoFadeAndPopState(fadeIntime, fadeOutTime));
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator DoFadeAndPopState(float fadeIntime, float fadeOutTime)
    //	{
    //		Swd6Application.<DoFadeAndPopState>c__Iterator876 <DoFadeAndPopState>c__Iterator = new Swd6Application.<DoFadeAndPopState>c__Iterator876();
    //		<DoFadeAndPopState>c__Iterator.fadeIntime = fadeIntime;
    //		<DoFadeAndPopState>c__Iterator.fadeOutTime = fadeOutTime;
    //		<DoFadeAndPopState>c__Iterator.<$>fadeIntime = fadeIntime;
    //		<DoFadeAndPopState>c__Iterator.<$>fadeOutTime = fadeOutTime;
    //		<DoFadeAndPopState>c__Iterator.<>f__this = this;
    //		return <DoFadeAndPopState>c__Iterator;
    //	}

    //	public void ChangeToOtherRealm(int mapId, float x, float y, float z)
    //	{
    //		base.StartCoroutine(this.DoChangeToOtherRealm(mapId, x, y, z));
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator DoChangeToOtherRealm(int mapId, float x, float y, float z)
    //	{
    //		Swd6Application.<DoChangeToOtherRealm>c__Iterator877 <DoChangeToOtherRealm>c__Iterator = new Swd6Application.<DoChangeToOtherRealm>c__Iterator877();
    //		<DoChangeToOtherRealm>c__Iterator.mapId = mapId;
    //		<DoChangeToOtherRealm>c__Iterator.x = x;
    //		<DoChangeToOtherRealm>c__Iterator.y = y;
    //		<DoChangeToOtherRealm>c__Iterator.z = z;
    //		<DoChangeToOtherRealm>c__Iterator.<$>mapId = mapId;
    //		<DoChangeToOtherRealm>c__Iterator.<$>x = x;
    //		<DoChangeToOtherRealm>c__Iterator.<$>y = y;
    //		<DoChangeToOtherRealm>c__Iterator.<$>z = z;
    //		<DoChangeToOtherRealm>c__Iterator.<>f__this = this;
    //		return <DoChangeToOtherRealm>c__Iterator;
    //	}

    //	public void ChangeToMapTeleport(int mapId, string teleportName)
    //	{
    //		base.StartCoroutine(this.DoChangeToMapTeleport(mapId, teleportName));
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator DoChangeToMapTeleport(int mapId, string teleportName)
    //	{
    //		Swd6Application.<DoChangeToMapTeleport>c__Iterator878 <DoChangeToMapTeleport>c__Iterator = new Swd6Application.<DoChangeToMapTeleport>c__Iterator878();
    //		<DoChangeToMapTeleport>c__Iterator.teleportName = teleportName;
    //		<DoChangeToMapTeleport>c__Iterator.<$>teleportName = teleportName;
    //		<DoChangeToMapTeleport>c__Iterator.<>f__this = this;
    //		return <DoChangeToMapTeleport>c__Iterator;
    //	}

    //	public void ReloadObjc()
    //	{
    //		GameDataDB.LoadDBF();
    //		GameDataDB.LoadLanguage();
    //		this.m_GameDataSystem.ReLoadObjData();
    //		this.m_GameObjSystem.ReLoadMapObjData();
    //		this.m_GameObjSystem.ReAttackMapObjScript();
    //	}

    //	public void LoadMapMask(string name)
    //	{
    //	}

    //	public void InitNewGame()
    //	{
    //		this.m_GameObjSystem.Clear();
    //		this.m_QuestSystem.Clear();
    //		this.m_SkillSystem.Clear();
    //		this.m_ItemSystem.Clear();
    //		this.m_MobGuardSystem.Clear();
    //		this.m_AchievementSystem.InitForNewGame();
    //		this.m_WOPSystem.InitForNewGame();
    //		this.m_FormationSystem.ClearFormation();
    //		this.m_GameObjSystem.Initialize();
    //	}

    //	public void InitChapterData(int chapId)
    //	{
    //		this.m_ChapID = chapId;
    //		if (chapId != 100)
    //		{
    //			if (chapId == 101)
    //			{
    //				this.m_AchievementSystem.m_Enable = false;
    //			}
    //		}
    //		else
    //		{
    //			this.m_AchievementSystem.m_Enable = false;
    //		}
    //		this.m_GameDataSystem.InitTeamRoleList(chapId);
    //		this.m_SaveloadSystem.SwitchSaveDirectory(chapId);
    //		this.m_GameDataSystem.InitRoleData(chapId);
    //	}

    public void StartNewGame()
    {
        GameObject gameObject = GameObject.Find("NewGameObject");
        //this.m_GameDataSystem.InitRoleData(this.m_ChapID);
        if (gameObject != null)
        {
            gameObject.SendMessage("DoTalk", SendMessageOptions.DontRequireReceiver);
        }
        //this.NewGameRecord();
    }

    //	public void NewGameRecord()
    //	{
    //		SoftStarStatisticsSheet.NewGame newGameInfo = this.m_UserBehavior.NewGameInfo;
    //		DateTime dateTime = default(DateTime);
    //		dateTime = DateTime.Now;
    //		string newGameTime = string.Concat(new object[]
    //		{
    //			dateTime.Year,
    //			"-",
    //			dateTime.Month,
    //			"-",
    //			dateTime.Day
    //		});
    //		newGameInfo.SetNewGameTime(newGameTime);
    //	}

    //	public void StartExNewGame()
    //	{
    //		GameObject gameObject = GameObject.Find("NewGameObject");
    //		this.m_InheritSystem.PrepareInheritData();
    //		this.m_GameDataSystem.InitExRoleData(100);
    //		if (gameObject != null)
    //		{
    //			gameObject.SendMessage("DoTalk", SendMessageOptions.DontRequireReceiver);
    //		}
    //		this.NewGameRecord();
    //	}

    //	public void ReturnToStartMenu()
    //	{
    //		base.StartCoroutine(this.ReturnToStartMenuCoroutine());
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator ReturnToStartMenuCoroutine()
    //	{
    //		Swd6Application.<ReturnToStartMenuCoroutine>c__Iterator879 <ReturnToStartMenuCoroutine>c__Iterator = new Swd6Application.<ReturnToStartMenuCoroutine>c__Iterator879();
    //		<ReturnToStartMenuCoroutine>c__Iterator.<>f__this = this;
    //		return <ReturnToStartMenuCoroutine>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public IEnumerator OpenGameMainMenu()
    //	{
    //		Swd6Application.<OpenGameMainMenu>c__Iterator87A <OpenGameMainMenu>c__Iterator87A = new Swd6Application.<OpenGameMainMenu>c__Iterator87A();
    //		<OpenGameMainMenu>c__Iterator87A.<>f__this = this;
    //		return <OpenGameMainMenu>c__Iterator87A;
    //	}

    //	public void ChangeToBigMapState()
    //	{
    //		base.StartCoroutine(base.PushState("BigMapState"));
    //	}

    //	public void ChangeToSmallTrapGameState()
    //	{
    //		base.StartCoroutine(base.PushState("SmallTrapGameState"));
    //	}

    //	[DebuggerHidden]
    //	public IEnumerator BeginScreenShot(bool scale)
    //	{
    //		Swd6Application.<BeginScreenShot>c__Iterator87B <BeginScreenShot>c__Iterator87B = new Swd6Application.<BeginScreenShot>c__Iterator87B();
    //		<BeginScreenShot>c__Iterator87B.scale = scale;
    //		<BeginScreenShot>c__Iterator87B.<$>scale = scale;
    //		<BeginScreenShot>c__Iterator87B.<>f__this = this;
    //		return <BeginScreenShot>c__Iterator87B;
    //	}

    //	[DebuggerHidden]
    //	public IEnumerator ResizeScreenShot()
    //	{
    //		Swd6Application.<ResizeScreenShot>c__Iterator87C <ResizeScreenShot>c__Iterator87C = new Swd6Application.<ResizeScreenShot>c__Iterator87C();
    //		<ResizeScreenShot>c__Iterator87C.<>f__this = this;
    //		return <ResizeScreenShot>c__Iterator87C;
    //	}

    //	public void SaveScreenShot(string filename)
    //	{
    //		if (this.m_CaptureImageData == null && this.m_CaptureTexture != null)
    //		{
    //			this.m_CaptureTexture.Apply();
    //			Texture2D texture2D = new Texture2D(Screen.width, this.m_CaptureTexture.height, TextureFormat.RGB24, false, true);
    //			texture2D.name = "SaveScreenShot";
    //			texture2D.SetPixels32(this.m_CaptureTexture.GetPixels32());
    //			texture2D.Apply();
    //			if (this.m_CaptureScale)
    //			{
    //				TextureScale.Point(texture2D, 342, 256);
    //			}
    //			this.m_CaptureImageData = texture2D.EncodeToPNG();
    //			UnityEngine.Object.Destroy(texture2D);
    //		}
    //		if (this.m_CaptureImageData != null)
    //		{
    //			File.WriteAllBytes(filename, this.m_CaptureImageData);
    //		}
    //	}

    //	public void SaveScreenShot(string filename, string smallFilename)
    //	{
    //		if (this.m_CaptureTexture == null)
    //		{
    //			return;
    //		}
    //		this.m_CaptureTexture.Apply();
    //		this.m_CaptureImageData = this.m_CaptureTexture.EncodeToPNG();
    //		File.WriteAllBytes(filename, this.m_CaptureImageData);
    //		Texture2D texture2D = new Texture2D(Screen.width, this.m_CaptureTexture.height, TextureFormat.RGB24, false, true);
    //		texture2D.name = "SaveScreenShot";
    //		texture2D.SetPixels32(this.m_CaptureTexture.GetPixels32());
    //		texture2D.Apply();
    //		TextureScale.Point(texture2D, 342, 256);
    //		this.m_CaptureImageData = texture2D.EncodeToPNG();
    //		UnityEngine.Object.Destroy(texture2D);
    //		if (this.m_CaptureImageData == null)
    //		{
    //			return;
    //		}
    //		File.WriteAllBytes(smallFilename, this.m_CaptureImageData);
    //	}

    //	public void ClearScreenShot()
    //	{
    //		this.m_CaptureImageData = null;
    //		GC.Collect();
    //	}

    //	public void ReSize()
    //	{
    //		if (this.m_CaptureTexture != null)
    //		{
    //			UnityEngine.Object.Destroy(this.m_CaptureTexture);
    //			this.m_CaptureTexture = null;
    //		}
    //		this.m_UpdateResizeTime = 2f;
    //	}

    //	private void InitDefaultResolutions()
    //	{
    //		this.m_DefaultResolutions = new Resolution[13];
    //		this.m_DefaultResolutions[0].width = 1024;
    //		this.m_DefaultResolutions[0].height = 768;
    //		this.m_DefaultResolutions[1].width = 1152;
    //		this.m_DefaultResolutions[1].height = 684;
    //		this.m_DefaultResolutions[2].width = 1280;
    //		this.m_DefaultResolutions[2].height = 720;
    //		this.m_DefaultResolutions[3].width = 1280;
    //		this.m_DefaultResolutions[3].height = 768;
    //		this.m_DefaultResolutions[4].width = 1280;
    //		this.m_DefaultResolutions[4].height = 800;
    //		this.m_DefaultResolutions[5].width = 1280;
    //		this.m_DefaultResolutions[5].height = 960;
    //		this.m_DefaultResolutions[6].width = 1280;
    //		this.m_DefaultResolutions[6].height = 1024;
    //		this.m_DefaultResolutions[7].width = 1366;
    //		this.m_DefaultResolutions[7].height = 768;
    //		this.m_DefaultResolutions[8].width = 1440;
    //		this.m_DefaultResolutions[8].height = 900;
    //		this.m_DefaultResolutions[9].width = 1600;
    //		this.m_DefaultResolutions[9].height = 900;
    //		this.m_DefaultResolutions[10].width = 1680;
    //		this.m_DefaultResolutions[10].height = 1050;
    //		this.m_DefaultResolutions[11].width = 1920;
    //		this.m_DefaultResolutions[11].height = 1080;
    //		this.m_DefaultResolutions[12].width = 1920;
    //		this.m_DefaultResolutions[12].height = 1200;
    //		Resolution[] resolutions = Screen.resolutions;
    //		List<Resolution> list = new List<Resolution>();
    //		for (int i = 0; i < resolutions.Length; i++)
    //		{
    //			Resolution[] defaultResolutions = this.m_DefaultResolutions;
    //			for (int j = 0; j < defaultResolutions.Length; j++)
    //			{
    //				Resolution resolution = defaultResolutions[j];
    //				if (resolutions[i].width == resolution.width && resolutions[i].height == resolution.height)
    //				{
    //					list.Add(resolutions[i]);
    //					break;
    //				}
    //			}
    //		}
    //		if (list.Count > 0)
    //		{
    //			this.m_Resolutions = list.ToArray();
    //		}
    //		else
    //		{
    //			list.Add(new Resolution
    //			{
    //				width = 1024,
    //				height = 768
    //			});
    //			this.m_Resolutions = list.ToArray();
    //		}
    //	}

    //	private bool IsValidResolution(int width, int height)
    //	{
    //		return width <= 1920 && width >= 1024 && height <= 1200 && height >= 684;
    //	}

    //	public void LoadSettings()
    //	{
    //		this.InitDefaultResolutions();
    //		if (!File.Exists(Application.dataPath + "/../settings.ini"))
    //		{
    //			this.SaveSettings(true);
    //		}
    //		try
    //		{
    //			IConfigSource configSource = new IniConfigSource(Application.dataPath + "/../settings.ini");
    //			IConfig config = configSource.Configs["Video"];
    //			QualitySetting qualitySetting = this.m_QualitySettingSystem.GetQualitySetting();
    //			qualitySetting.m_ResolutionWidth = config.GetInt("ResolutionWidth", 1280);
    //			qualitySetting.m_ResolutionHeight = config.GetInt("ResolutionHeight", 720);
    //			qualitySetting.m_EnableFullScreen = config.GetBoolean("FullScreen", false);
    //			if (!this.IsValidResolution(qualitySetting.m_ResolutionWidth, qualitySetting.m_ResolutionHeight))
    //			{
    //				qualitySetting.m_ResolutionWidth = 1280;
    //				qualitySetting.m_ResolutionHeight = 720;
    //				qualitySetting.m_EnableFullScreen = false;
    //			}
    //			qualitySetting.m_QuilitySetting = (Enum_QuilitySettingType)config.GetInt("QuickQuality", 2);
    //			if (qualitySetting.m_QuilitySetting < Enum_QuilitySettingType.Fastest || qualitySetting.m_QuilitySetting > Enum_QuilitySettingType.Customize)
    //			{
    //				this.CreateNewSetting();
    //			}
    //			else
    //			{
    //				qualitySetting.m_TextureQuality = (Enum_TextureQuality)config.GetInt("TextureQuality", 2);
    //				if (qualitySetting.m_TextureQuality < Enum_TextureQuality.Low || qualitySetting.m_TextureQuality > Enum_TextureQuality.High)
    //				{
    //					this.CreateNewSetting();
    //				}
    //				else
    //				{
    //					qualitySetting.m_LayerCull = (Enum_LayerCull)config.GetInt("LayerCulling", 2);
    //					if (qualitySetting.m_LayerCull < Enum_LayerCull.Low || qualitySetting.m_LayerCull > Enum_LayerCull.High)
    //					{
    //						this.CreateNewSetting();
    //					}
    //					else
    //					{
    //						qualitySetting.m_ShadowQuality = (Enum_ShadowQuality)config.GetInt("ShadowQuality", 2);
    //						if (qualitySetting.m_ShadowQuality < Enum_ShadowQuality.Low || qualitySetting.m_ShadowQuality > Enum_ShadowQuality.High)
    //						{
    //							this.CreateNewSetting();
    //						}
    //						else
    //						{
    //							qualitySetting.m_EnableShadow = config.GetBoolean("Shadow", true);
    //							qualitySetting.m_EnableVsync = config.GetBoolean("Vsync", false);
    //							qualitySetting.m_EnableAA = config.GetBoolean("AntiAliasing", false);
    //							qualitySetting.m_ShadowDistance = (Enum_ShadowDistance)config.GetInt("ShadowDistance", 2);
    //							if (qualitySetting.m_ShadowDistance < Enum_ShadowDistance.Low || qualitySetting.m_ShadowDistance > Enum_ShadowDistance.High)
    //							{
    //								this.CreateNewSetting();
    //							}
    //							else
    //							{
    //								qualitySetting.m_EnableDOF = config.GetBoolean("DOF", true);
    //								qualitySetting.m_EnableBloom = config.GetBoolean("Bloom", true);
    //								qualitySetting.m_EnableSunShaft = config.GetBoolean("SunShaft", true);
    //								qualitySetting.m_EnableSSAO = config.GetBoolean("SSAO", true);
    //								qualitySetting.m_EnableTonemapping = config.GetBoolean("Tonemapping", true);
    //								qualitySetting.m_RecommendQuality = config.GetInt("RecommendQuality", 5);
    //								if (qualitySetting.m_RecommendQuality < 0 || qualitySetting.m_RecommendQuality > 2)
    //								{
    //									qualitySetting.m_RecommendQuality = 5;
    //								}
    //								IConfig config2 = configSource.Configs["Settings"];
    //								if (config2 == null)
    //								{
    //									config2 = configSource.Configs.Add("Settings");
    //									config2.Set("Version", 1);
    //									configSource.Save();
    //								}
    //								int @int = config2.GetInt("Version", 1);
    //								IConfig config3 = configSource.Configs["Game"];
    //								NormalSetting normalSetting = this.m_NormalSettingSystem.GetNormalSetting();
    //								normalSetting.m_bEnableMovieMode = config3.GetBoolean("MovieMode", true);
    //								normalSetting.m_bEnableTextFrameInStory = config3.GetBoolean("TextFrameInStory", false);
    //								normalSetting.m_bEnableFightStop = config3.GetBoolean("FightStop", false);
    //								normalSetting.m_bEnableFightingVoice = config3.GetBoolean("FightingVoice", true);
    //								normalSetting.m_FightingDifficulty = (Enum_FightingDifficulty)config3.GetInt("FightingDifficulty", 1);
    //								if (normalSetting.m_FightingDifficulty < Enum_FightingDifficulty.Easy || normalSetting.m_FightingDifficulty > Enum_FightingDifficulty.Hard)
    //								{
    //									this.CreateNewSetting();
    //								}
    //								else
    //								{
    //									normalSetting.m_emCharacterStyle = (Enum_CharacterStyle)config3.GetInt("CharacterStyle", 0);
    //									if (normalSetting.m_emCharacterStyle < Enum_CharacterStyle.Enum_CharacterStyle_Beauty || normalSetting.m_emCharacterStyle > Enum_CharacterStyle.Enum_CharacterStyle_Real)
    //									{
    //										this.CreateNewSetting();
    //									}
    //									else
    //									{
    //										normalSetting.m_bEnableName = config3.GetBoolean("Naming", false);
    //										normalSetting.m_bEnableQuestHint = config3.GetBoolean("QuestHint", true);
    //										normalSetting.m_bEnableTeach = config3.GetBoolean("Teach", true);
    //										normalSetting.m_bEnableJoystick = config3.GetBoolean("Joystick", true);
    //										normalSetting.m_bEnableMazeClickMove = config3.GetBoolean("MazeClickMove", true);
    //										GameInput.JoyStick = normalSetting.m_bEnableJoystick;
    //										normalSetting.m_IsDlC = config3.GetBoolean("IsDLC", false);
    //										IConfig config4 = configSource.Configs["Sound"];
    //										SoundSetting soundSetting = this.m_SoundSettingSystem.GetSoundSetting();
    //										soundSetting.m_MusicVolumeRate = config4.GetInt("MusicVolumeRate", 70);
    //										if (soundSetting.m_MusicVolumeRate < 0 || soundSetting.m_MusicVolumeRate > 100)
    //										{
    //											this.CreateNewSetting();
    //										}
    //										else
    //										{
    //											soundSetting.m_EffectVolumeRate = config4.GetInt("EffectVolumeRate", 100);
    //											if (soundSetting.m_EffectVolumeRate < 0 || soundSetting.m_EffectVolumeRate > 100)
    //											{
    //												this.CreateNewSetting();
    //											}
    //											else
    //											{
    //												soundSetting.m_SpeechVolumeRate = config4.GetInt("SpeechVolumeRate", 100);
    //												if (soundSetting.m_SpeechVolumeRate < 0 || soundSetting.m_SpeechVolumeRate > 100)
    //												{
    //													this.CreateNewSetting();
    //												}
    //												else
    //												{
    //													soundSetting.m_EnvironmentVolumeRate = config4.GetInt("EnvironmentVolumeRate", 100);
    //													if (soundSetting.m_EnvironmentVolumeRate < 0 || soundSetting.m_EnvironmentVolumeRate > 100)
    //													{
    //														this.CreateNewSetting();
    //													}
    //													else
    //													{
    //														soundSetting.m_MenuVolumeRate = config4.GetInt("MenuVolumeRate", 70);
    //														if (soundSetting.m_MenuVolumeRate < 0 || soundSetting.m_MenuVolumeRate > 100)
    //														{
    //															this.CreateNewSetting();
    //														}
    //														else
    //														{
    //															IConfig config5 = configSource.Configs["Control"];
    //															Dictionary<KEY_ACTION, KeyCode> keyList = this.m_ControlSettingSystem.GetKeyList();
    //															keyList[KEY_ACTION.UP] = (KeyCode)config5.GetInt("UP", 119);
    //															keyList[KEY_ACTION.DOWN] = (KeyCode)config5.GetInt("DOWN", 115);
    //															keyList[KEY_ACTION.LEFT] = (KeyCode)config5.GetInt("LEFT", 97);
    //															keyList[KEY_ACTION.RIGHT] = (KeyCode)config5.GetInt("RIGHT", 100);
    //															keyList[KEY_ACTION.CAMERA_UP] = (KeyCode)config5.GetInt("CAMERA_UP", 61);
    //															keyList[KEY_ACTION.CAMERA_DOWN] = (KeyCode)config5.GetInt("CAMERA_DOWN", 45);
    //															keyList[KEY_ACTION.CAMERA_LEFT] = (KeyCode)config5.GetInt("CAMERA_LEFT", 113);
    //															keyList[KEY_ACTION.CAMERA_RIGHT] = (KeyCode)config5.GetInt("CAMERA_RIGHT", 101);
    //															keyList[KEY_ACTION.CAMERA_IN] = (KeyCode)config5.GetInt("CAMERA_IN", 93);
    //															keyList[KEY_ACTION.CAMERA_OUT] = (KeyCode)config5.GetInt("CAMERA_OUT", 91);
    //															keyList[KEY_ACTION.CONFIRM] = (KeyCode)config5.GetInt("CONFIRM", 13);
    //															keyList[KEY_ACTION.TAB] = (KeyCode)config5.GetInt("TAB", 9);
    //															keyList[KEY_ACTION.ACTION] = (KeyCode)config5.GetInt("ACTION", 102);
    //															keyList[KEY_ACTION.ROLE_LEFT] = (KeyCode)config5.GetInt("ROLE_LEFT", 44);
    //															keyList[KEY_ACTION.ROLE_RIGHT] = (KeyCode)config5.GetInt("ROLE_RIGHT", 46);
    //															keyList[KEY_ACTION.MAP] = (KeyCode)config5.GetInt("MAP", 109);
    //														}
    //													}
    //												}
    //											}
    //										}
    //									}
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		catch (Exception var_11_71D)
    //		{
    //			this.CreateNewSetting();
    //		}
    //	}

    //	private void CreateNewSetting()
    //	{
    //		UnityEngine.Debug.Log("產生新的Setting檔");
    //		QualitySettingSystem.Instance.Initialize();
    //		NormalSettingSystem.Instance.Initialize();
    //		SoundSettingSystem.Instance.Initialize();
    //		ControlSettingSystem.Instance.Initialize();
    //		this.SaveSettings(true);
    //		this.LoadSettings();
    //	}

    //	public void SaveSettings(bool isNewSettings)
    //	{
    //		IniConfigSource iniConfigSource = new IniConfigSource();
    //		if (!isNewSettings)
    //		{
    //			iniConfigSource.Load(Application.dataPath + "/../settings.ini");
    //		}
    //		else
    //		{
    //			iniConfigSource.Configs.Add("Settings");
    //			iniConfigSource.Configs.Add("Video");
    //			iniConfigSource.Configs.Add("Game");
    //			iniConfigSource.Configs.Add("Sound");
    //			iniConfigSource.Configs.Add("Control");
    //		}
    //		IConfig config = iniConfigSource.Configs["Video"];
    //		QualitySetting qualitySetting = this.m_QualitySettingSystem.GetQualitySetting();
    //		config.Set("ResolutionWidth", qualitySetting.m_ResolutionWidth);
    //		config.Set("ResolutionHeight", qualitySetting.m_ResolutionHeight);
    //		config.Set("FullScreen", qualitySetting.m_EnableFullScreen);
    //		config.Set("QuickQuality", (int)qualitySetting.m_QuilitySetting);
    //		config.Set("Shadow", qualitySetting.m_EnableShadow);
    //		config.Set("TextureQuality", (int)qualitySetting.m_TextureQuality);
    //		config.Set("LayerCulling", (int)qualitySetting.m_LayerCull);
    //		config.Set("ShadowQuality", (int)qualitySetting.m_ShadowQuality);
    //		config.Set("Vsync", qualitySetting.m_EnableVsync);
    //		config.Set("AntiAliasing", qualitySetting.m_EnableAA);
    //		config.Set("ShadowDistance", (int)qualitySetting.m_ShadowDistance);
    //		config.Set("DOF", qualitySetting.m_EnableDOF);
    //		config.Set("Bloom", qualitySetting.m_EnableBloom);
    //		config.Set("SunShaft", qualitySetting.m_EnableSunShaft);
    //		config.Set("Tonemapping", qualitySetting.m_EnableTonemapping);
    //		config.Set("SSAO", qualitySetting.m_EnableSSAO);
    //		if (isNewSettings)
    //		{
    //			config.Set("RecommendQuality", 5);
    //		}
    //		IConfig config2 = iniConfigSource.Configs["Game"];
    //		NormalSetting normalSetting = this.m_NormalSettingSystem.GetNormalSetting();
    //		config2.Set("MovieMode", normalSetting.m_bEnableMovieMode);
    //		config2.Set("TextFrameInStory", normalSetting.m_bEnableTextFrameInStory);
    //		config2.Set("FightStop", normalSetting.m_bEnableFightStop);
    //		config2.Set("FightingVoice", normalSetting.m_bEnableFightingVoice);
    //		config2.Set("FightingDifficulty", (int)normalSetting.m_FightingDifficulty);
    //		config2.Set("CharacterStyle", (int)normalSetting.m_emCharacterStyle);
    //		config2.Set("Naming", normalSetting.m_bEnableName);
    //		config2.Set("QuestHint", normalSetting.m_bEnableQuestHint);
    //		config2.Set("Teach", normalSetting.m_bEnableTeach);
    //		config2.Set("Joystick", normalSetting.m_bEnableJoystick);
    //		config2.Set("MazeClickMove", normalSetting.m_bEnableMazeClickMove);
    //		config2.Set("IsDLC", normalSetting.m_IsDlC);
    //		IConfig config3 = iniConfigSource.Configs["Sound"];
    //		SoundSetting soundSetting = this.m_SoundSettingSystem.GetSoundSetting();
    //		config3.Set("MusicVolumeRate", soundSetting.m_MusicVolumeRate);
    //		config3.Set("EffectVolumeRate", soundSetting.m_EffectVolumeRate);
    //		config3.Set("SpeechVolumeRate", soundSetting.m_SpeechVolumeRate);
    //		config3.Set("EnvironmentVolumeRate", soundSetting.m_EnvironmentVolumeRate);
    //		config3.Set("MenuVolumeRate", soundSetting.m_MenuVolumeRate);
    //		IConfig config4 = iniConfigSource.Configs["Control"];
    //		Dictionary<KEY_ACTION, KeyCode> keyList = this.m_ControlSettingSystem.GetKeyList();
    //		config4.Set("UP", (int)keyList[KEY_ACTION.UP]);
    //		config4.Set("DOWN", (int)keyList[KEY_ACTION.DOWN]);
    //		config4.Set("LEFT", (int)keyList[KEY_ACTION.LEFT]);
    //		config4.Set("RIGHT", (int)keyList[KEY_ACTION.RIGHT]);
    //		config4.Set("CAMERA_UP", (int)keyList[KEY_ACTION.CAMERA_UP]);
    //		config4.Set("CAMERA_DOWN", (int)keyList[KEY_ACTION.CAMERA_DOWN]);
    //		config4.Set("CAMERA_LEFT", (int)keyList[KEY_ACTION.CAMERA_LEFT]);
    //		config4.Set("CAMERA_RIGHT", (int)keyList[KEY_ACTION.CAMERA_RIGHT]);
    //		config4.Set("CAMERA_IN", (int)keyList[KEY_ACTION.CAMERA_IN]);
    //		config4.Set("CAMERA_OUT", (int)keyList[KEY_ACTION.CAMERA_OUT]);
    //		config4.Set("CONFIRM", (int)keyList[KEY_ACTION.CONFIRM]);
    //		config4.Set("TAB", (int)keyList[KEY_ACTION.TAB]);
    //		config4.Set("ACTION", (int)keyList[KEY_ACTION.ACTION]);
    //		config4.Set("ROLE_LEFT", (int)keyList[KEY_ACTION.ROLE_LEFT]);
    //		config4.Set("ROLE_RIGHT", (int)keyList[KEY_ACTION.ROLE_RIGHT]);
    //		config4.Set("MAP", (int)keyList[KEY_ACTION.MAP]);
    //		if (isNewSettings)
    //		{
    //			iniConfigSource.Save(Application.dataPath + "/../settings.ini");
    //		}
    //		else
    //		{
    //			iniConfigSource.Save();
    //		}
    //	}
}
