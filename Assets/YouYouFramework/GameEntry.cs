using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YouYou
{
    public class GameEntry : MonoBehaviour
    {
        [FoldoutGroup("ParamsSettings")]
        [SerializeField]
        private ParamsSettings.DeviceGrade m_CurrDeviceGrade;

        [FoldoutGroup("ParamsSettings")]
        [SerializeField]
        private ParamsSettings m_ParamsSettings;

        [FoldoutGroup("ParamsSettings")]
        [SerializeField]
        private YouYouLanguage m_CurrLanguage;

        [FoldoutGroup("ResourceGroup")]
        [Header("游戏物体对象池父物体")]
        public Transform PoolParent;

        [FoldoutGroup("ResourceGroup")]
        /// <summary>
        /// 游戏物体对象池分组
        /// </summary>
        [SerializeField]
        public GameObjectPoolEntity[] GameObjectPoolGroups;

        [FoldoutGroup("ResourceGroup")]
        [Header("锁定的资源包")]
        /// <summary>
        /// 锁定的资源包（不会释放）
        /// </summary>
        public string[] LockedAssetBundle;

        [FoldoutGroup("UIGroup")]
        [Header("标准分辨率宽度")]
        [SerializeField]
        public int StandardWidth = 1280;

        [FoldoutGroup("UIGroup")]
        [Header("标准分辨率高度")]
        [SerializeField]
        public int StandardHeight = 720;

        [FoldoutGroup("UIGroup")]
        [Header("UI摄像机")]
        public Camera UICamera;

        [FoldoutGroup("UIGroup")]
        [Header("根画布")]
        [SerializeField]
        public Canvas UIRootCanvas;

        [FoldoutGroup("UIGroup")]
        [Header("根画布的缩放")]
        [SerializeField]
        public CanvasScaler UIRootCanvasScaler;

        [FoldoutGroup("UIGroup")]
        [Header("UI分组")]
        [SerializeField]
        public UIGroup[] UIGroups;

        [HideInInspector]
        public bool m_InitializeOK;

        #region 时间缩放
        [CustomValueDrawer("SetTimeScale")]
        public float timeScale;

#if UNITY_EDITOR
        [ButtonGroup]
        [LabelText("0")]
        private void timeScale0()
        {
            timeScale = 0;
        }

        [ButtonGroup]
        [LabelText("0.5")]
        private void timeScale05()
        {
            timeScale = 0.5f;
        }

        [ButtonGroup]
        [LabelText("1")]
        private void timeScale1()
        {
            timeScale = 1;
        }

        [ButtonGroup]
        [LabelText("2")]
        private void timeScale2()
        {
            timeScale = 2;
        }

        [ButtonGroup]
        [LabelText("3")]
        private void timeScale3()
        {
            timeScale = 3;
        }

        private float SetTimeScale(float value, GUIContent label)
        {
            float ret = UnityEditor.EditorGUILayout.Slider(label, value, 0f, 3);
            UnityEngine.Time.timeScale = ret;
            return ret;
        }
#endif
        #endregion

        #region 管理器属性
        /// <summary>
        /// 日志管理器
        /// </summary>
        public static LoggerManager Logger
        {
            get;
            private set;
        }

        /// <summary>
        /// 事件管理器
        /// </summary>
        public static EventManager Event
        {
            get;
            private set;
        }

        /// <summary>
        /// 时间管理器
        /// </summary>
        public static TimeManager Time
        {
            get;
            private set;
        }

        /// <summary>
        /// 状态机管理器
        /// </summary>
        public static FsmManager Fsm
        {
            get;
            private set;
        }

        /// <summary>
        /// 流程管理器
        /// </summary>
        public static ProcedureManager Procedure
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据表管理器
        /// </summary>
        public static DataTableManager DataTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据管理器
        /// </summary>
        public static DataManager Data
        {
            get;
            private set;
        }

        /// <summary>
        /// 本地化管理器
        /// </summary>
        public static LocalizationManager Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// 对象池管理器
        /// </summary>
        public static PoolManager Pool
        {
            get;
            private set;
        }

        /// <summary>
        /// 场景管理器
        /// </summary>
        public static YouYouSceneManager Scene
        {
            get;
            private set;
        }

        /// <summary>
        /// 可寻址资源管理器
        /// </summary>
        public static AddressableManager Resource
        {
            get;
            private set;
        }

        /// <summary>
        /// UI管理器
        /// </summary>
        public static YouYouUIManager UI
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色管理器
        /// </summary>
        public static RoleManager Role
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色管理器
        /// </summary>
        public static GameInputManager Input
        {
            get;
            private set;
        }
        #endregion

        #region InitManagers 初始化管理器
        /// <summary>
        /// 初始化管理器
        /// </summary>
        private static void InitManagers()
        {
            Logger = new LoggerManager();
            Event = new EventManager();
            Time = new TimeManager();
            Fsm = new FsmManager();
            Procedure = new ProcedureManager();
            DataTable = new DataTableManager();
            Data = new DataManager();
            Localization = new LocalizationManager();
            Pool = new PoolManager();
            Scene = new YouYouSceneManager();
            Resource = new AddressableManager();
            UI = new YouYouUIManager();
            Role = new RoleManager();
            Input = new GameInputManager();

            Logger.Init();
            Event.Init();
            Time.Init();
            Fsm.Init();
            Procedure.Init();
            DataTable.Init();
            Data.Init();
            Localization.Init();
            Pool.Init();
            Scene.Init();
            Resource.Init();
            UI.Init();
            Role.Init();
            Input.Init();
            //进入第一个流程

            new ResourcesManager();
            Procedure.ChangeState(ProcedureState.Preload);
        }
        #endregion

        #region 更新组件管理
        /// <summary>
        /// 更新组件列表
        /// </summary>
        private static readonly LinkedList<IUpdateComponent> m_UpdateComponentList = new LinkedList<IUpdateComponent>();

        #region RegisterUpdateComponent 注册更新组件
        /// <summary>
        /// 注册更新组件
        /// </summary>
        /// <param name="component"></param>
        public static void RegisterUpdateComponent(IUpdateComponent component)
        {
            m_UpdateComponentList.AddLast(component);
        }
        #endregion

        #region RemoveUpdateComponent 移除更新组件
        /// <summary>
        /// 移除更新组件
        /// </summary>
        /// <param name="component"></param>
        public static void RemoveUpdateComponent(IUpdateComponent component)
        {
            m_UpdateComponentList.Remove(component);
        }
        #endregion


        #endregion

        public static bool isPause;

        /// <summary>
        /// 单例
        /// </summary>
        public static GameEntry Instance;

        /// <summary>
        /// 全局参数设置
        /// </summary>
        public static ParamsSettings ParamsSettings
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前设备等级
        /// </summary>
        public static ParamsSettings.DeviceGrade CurrDeviceGrade
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前语言（要和本地化表的语言字段 一致）
        /// </summary>
        public static YouYouLanguage CurrLanguage
        {
            get;
            set;
        }

        private void Awake()
        {
            Instance = this;

            //此处以后判断如果不是编辑器模式 要根据设备信息判断等级
            CurrDeviceGrade = m_CurrDeviceGrade;
            ParamsSettings = m_ParamsSettings;
            CurrLanguage = m_CurrLanguage;
        }

        void Start()
        {
            InitManagers();     
            
            ReadGameDB();
            //this.InitRequiredObject();
            InitGameSystem();
            this.m_InitializeOK = true;

            UnityEngine.Time.timeScale = timeScale = 1;
            Application.targetFrameRate = ParamsSettings.GetGradeParamData(ConstDefine.targetFrameRate, CurrDeviceGrade);
        }

        void Update()
        {
            //循环更新组件
            for (LinkedListNode<IUpdateComponent> curr = m_UpdateComponentList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate();
            }

            Time.OnUpdate();
            Procedure.OnUpdate();
            Pool.OnUpdate();
            Scene.OnUpdate();
            Resource.OnUpdate();
            UI.OnUpdate();
        }

        /// <summary>
        /// 销毁
        /// </summary>
        private void OnDestroy()
        {
            Logger.SyncLog();
            Logger.Dispose();
            Event.Dispose();
            Time.Dispose();
            Fsm.Dispose();
            Procedure.Dispose();
            DataTable.Dispose();  
            Data.Dispose();
            Localization.Dispose();
            Pool.Dispose();
            Scene.Dispose();
            Resource.Dispose();
            UI.Dispose();
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="message"></param>
        public static void Log(LogCategory catetory, string message, params object[] args)
        {
            switch (catetory)
            {
                default:
                case LogCategory.Normal:
#if DEBUG_LOG_NORMAL && DEBUG_MODEL
                    Debug.Log("[youyou]" + (args.Length == 0 ? message : string.Format(message, args)));

#endif
                    break;
                case LogCategory.Procedure:
#if DEBUG_LOG_PROCEDURE && DEBUG_MODEL
                    Debug.Log("[youyou]" + string.Format("<color=#ffffff>{0}</color>", args.Length == 0 ? message : string.Format(message, args)));
#endif
                    break;
                case LogCategory.Resource:
#if DEBUG_LOG_RESOURCE && DEBUG_MODEL
                    Debug.Log("[youyou]" + string.Format("<color=#ace44a>{0}</color>", args.Length == 0 ? message : string.Format(message, args)));
#endif
                    break;
                case LogCategory.Proto:
#if DEBUG_LOG_PROTO && DEBUG_MODEL
                    Debug.Log("[youyou]" + (args.Length == 0 ? message : string.Format(message, args)));
#endif
                    break;
            }
        }

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void LogError(string message, params object[] args)
        {
#if DEBUG_LOG_ERROR && DEBUG_MODEL
            Debug.LogError("[youyou]" + (args.Length == 0 ? message : string.Format(message, args)));
#endif
        }

        public void ReadGameDB()
        {
            string mapBlockPath = Application.dataPath + "/../DBF/";
            string dbf_Path = Application.dataPath + "/../DBF/";
            string languagePath = Application.dataPath + "/../DBF/";
            GameDataDB.SetConevrt(new SwdJsonCovertor());
            GameDataDB.Initialize(mapBlockPath, dbf_Path, languagePath);
            GameDataDB.LoadDBF();
            GameDataDB.LoadLanguage();
        }

        public GameObject m_ShroudMgr;

        //protected virtual void InitRequiredObject()
        //{
        //    this.m_ShroudMgr = ResourcesManager.Instance.GetOther("ShroudMgr");
        //    if (this.m_ShroudMgr != null)
        //    {
        //        UnityEngine.Object.DontDestroyOnLoad(this.m_ShroudMgr);
        //    }
        //    GameObject other = ResourcesManager.Instance.GetOther("MainMenuSky");
        //    if (other != null)
        //    {
        //        //this.m_MainMenuSky = other.GetComponent<Sky>();
        //        //if (this.m_MainMenuSky != null)
        //        //{
        //        //    UnityEngine.Object.DontDestroyOnLoad(other);
        //        //}
        //    }
        //}

        public GameDataSystem m_GameDataSystem { get; private set; }

        public ItemSystem m_ItemSystem { get; private set; }

        public QuestSystem m_QuestSystem { get; private set; }

        public SkillSystem m_SkillSystem { get; private set; }

        public IdentifySystem m_IdentifySystem { get; private set; }

        public ExploreSystem m_ExploreSystem { get; private set; }

        public GameObjSystem m_GameObjSystem { get; private set; }

        public StorySystem m_StorySystem { get; private set; }

        private void InitGameSystem()
        {
            this.m_GameObjSystem = new GameObjSystem();
            this.m_GameObjSystem.Initialize();
            this.m_GameDataSystem = new GameDataSystem();
            this.m_GameDataSystem.Initialize();
            this.m_ExploreSystem = new ExploreSystem();
            this.m_ExploreSystem.Initialize();
            //this.m_GameMenuSystem = new GameMenuSystem();
            //this.m_GameMenuSystem.Initialize(this);
            this.m_QuestSystem = new QuestSystem();
            this.m_QuestSystem.Initialize();
            this.m_IdentifySystem = new IdentifySystem();
            this.m_IdentifySystem.Initialize();
            this.m_ItemSystem = new ItemSystem();
            this.m_ItemSystem.Initialize();
            //this.m_SaveloadSystem = new SaveloadSystem();
            //this.m_SaveloadSystem.Initialize();
            this.m_SkillSystem = new SkillSystem();
            this.m_SkillSystem.Initialize();
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
            //this.m_UserBehavior = new UserBehavior();
            //this.m_UserBehavior.DirectoryPath = Application.dataPath + "/../Launcher/UBData/";      
            //this.InitChapterData(this.m_ChapID);
            //this.InitDLCItem();
            //this.SetGameEnviromentInfo();
        }

        public void StartNewGame()
        {
            this.m_GameDataSystem.InitRoleData();
            base.StartCoroutine(DoTalk());
        }

        public IEnumerator DoTalk()
        {
            //GameTalk.StartTalk(true);
            //yield return base.StartCoroutine(GameTalk.WaitFadeTime(1f, 2f));
            //GameTalk.AddItem(901, 3, false);
            //GameTalk.AddItem(921, 3, false);
            //GameTalk.AddMoney(200, false);
            //GameTalk.FlagOFF(61);
            //GameTalk.FlagOFF(62);
            //GameTalk.FlagOFF(63);
            //GameTalk.FlagOFF(64);
            //GameObject listener = GameObject.Find("Menu Listener");
            //if (listener != null && listener.GetComponent<AudioListener>() != null)
            //{
            //    listener.GetComponent<AudioListener>().enabled = false;
            //}
            //if (!GameTalk.GetFlag(1001))
            //{
            //    GameTalk.FlagON(1001);
            //}
            //GameTalk.StartTalk(false);
            GameTalk.HideAllNpc(1);
            GameTalk.PlayStory(100, "ME0000");
            //yield return base.StartCoroutine(GameTalk.IsPlayStoryEnd());
            yield return null;
            yield break;
        }

        public void InitNewGame()
        {
            this.m_GameObjSystem.Clear();
            this.m_QuestSystem.Clear();
            this.m_SkillSystem.Clear();
            this.m_ItemSystem.Clear();
            //this.m_MobGuardSystem.Clear();
            //this.m_AchievementSystem.InitForNewGame();
            //this.m_WOPSystem.InitForNewGame();
            //this.m_FormationSystem.ClearFormation();
            //this.m_GameObjSystem.Initialize();
        }

        /// <summary>
        /// 切换到剧情流程
        /// </summary>
        /// <param name="mapID"></param>
        /// <param name="storyName"></param>
        public void ChangeToStoryState(int mapID, string storyName)
        {
            GameEntry.Procedure.SetData("m_StoryName", storyName);
            if (GameEntry.Scene.m_CurrLoadSceneId != mapID && mapID!=100)
            {
                Debug.Log("切换状态");
                //要加载场景
                //this.ChangeMap(text, mapID, 0f, 0f, 0f, 0f);
            }
            else if(GameEntry.Procedure.CurrProcedureState != ProcedureState.SelectRole)
            {
                //切换状态
                Debug.Log("切换状态");
                GameEntry.Procedure.ChangeState(ProcedureState.SelectRole);
            }
            else
            {
                Debug.Log("执行剧情");
                //开始
                //storyState.CreateNewStory();
            }
        }
    }
}