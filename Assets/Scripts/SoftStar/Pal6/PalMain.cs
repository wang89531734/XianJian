using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using Funfia.File;
//using Glow11;
//using SoftStar.BuffDebuff;
using SoftStar.Item;
//using SoftStar.Pal6.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using YouYou;
//using UnityStandardAssets.ImageEffects;

namespace SoftStar.Pal6
{
    public class PalMain : MonoBehaviour
    {
        //		public const int MoneyFlag = 2;

        //		// Token: 0x04003112 RID: 12562
        //		private bool m_skillPreloading;

        //		// Token: 0x04003113 RID: 12563
        //		private static float m_loadingValue = 0f;

        //		// Token: 0x04003114 RID: 12564
        //		public static bool mIsDLC = false;

        //		// Token: 0x04003115 RID: 12565
        //		private static uint _MoneyID = 0u;

        /// <summary>
        /// 游戏难度
        /// </summary>
        public static int GameDifficulty = 0;

        //		// Token: 0x04003117 RID: 12567
        //		public static int MapOffset = 4194304;

        //		// Token: 0x04003118 RID: 12568
        //		public static float dyingRate = 0.1f;

        //		// Token: 0x04003119 RID: 12569
        //		public static string dyingZhanLi = string.Empty;

        //		// Token: 0x0400311A RID: 12570
        //		public static string normalZhanli = string.Empty;

        //		// Token: 0x0400311B RID: 12571
        //		public static int IgnoreLayer = 2;

        //		// Token: 0x0400311C RID: 12572
        //		public static int IgnoreMaskValue = (int)Mathf.Pow(2f, (float)PalMain.IgnoreLayer);

        //		// Token: 0x0400311D RID: 12573
        //		public static List<string> dialogue = new List<string>();

        //		// Token: 0x0400311E RID: 12574
        //		public BattleFormationManager CurBattleFormationManager = new BattleFormationManager();

        /// <summary>
        /// 游戏开始事件
        /// </summary>
        [NonSerialized]
        public static float GameBeginTime;

        [NonSerialized]
        public static float GameTotleTime;

        //[SerializeField]
        //private PalMain.WatchType mCurWatchType;

        public static string PlayerName = "Default";

        //		// Token: 0x04003123 RID: 12579
        //		public static List<Landmark> landMarks = new List<Landmark>();

        //		// Token: 0x04003124 RID: 12580
        //		public static string mapInfoPrefix = "/Resources/MapData/";

        //		// Token: 0x04003125 RID: 12581
        //		public static GameObject mapinfo = null;

        //		// Token: 0x04003126 RID: 12582
        //		public static Dictionary<int, int> ItemCount = new Dictionary<int, int>();

        //		// Token: 0x04003127 RID: 12583
        //		public static Dictionary<int, List<IItem>> SceneItems = new Dictionary<int, List<IItem>>();

        //		// Token: 0x04003128 RID: 12584
        //		public float minFPS = 10f;

        //		// Token: 0x04003129 RID: 12585
        //		public static float MinFPS = 10f;

        //		// Token: 0x0400312A RID: 12586
        //		public static float MinDeltaTime;

        //		// Token: 0x0400312B RID: 12587
        //		public bool m_bIgnoreEnemy;

        //public static BackgroundAudio backgroundAudio;

        //		// Token: 0x0400312D RID: 12589
        //		public bool m_bVoiceBlance;

        //		// Token: 0x0400312E RID: 12590
        //		private static GameObject mMainObj = null;

        //		// Token: 0x0400312F RID: 12591
        //		private static GameObject m_MainCamera = null;

        //		// Token: 0x04003130 RID: 12592
        //		public static Transform MainCameraTF = null;

        private static PalMain instance = null;

        //		// Token: 0x04003132 RID: 12594
        //		public static bool IsXP = false;

        //		// Token: 0x04003133 RID: 12595
        //		public static bool IsWin32 = false;

        //		// Token: 0x04003134 RID: 12596
        //		public static bool ForceLow = false;

        //		// Token: 0x04003136 RID: 12598
        //		public bool bPlayBeginMovie = true;

        //		// Token: 0x04003137 RID: 12599
        //		private DateTime mLastConfigSave = DateTime.Now.AddSeconds(1.0);

        //		// Token: 0x04003138 RID: 12600
        //		private static float CameraOptDistance = 60f;

        //		// Token: 0x04003139 RID: 12601
        //		public static Action LoadOverEvent = null;

        //		// Token: 0x0400313A RID: 12602
        //		private static Transform tempGameLayer = null;

        //		// Token: 0x0400313B RID: 12603
        //		public QTEManager m_QTEManager = new QTEManager();

        //		// Token: 0x0400313C RID: 12604
        //		private List<object> mTempObjects = new List<object>();

        //		// Token: 0x0400313D RID: 12605
        //		private int mTempPosition;

        //		// Token: 0x0400313E RID: 12606
        //		[NonSerialized]
        //		public float MoneyRate = 1f;

        //		// Token: 0x0400313F RID: 12607
        //		[NonSerialized]
        //		public float DropAddRate;

        //		// Token: 0x04003140 RID: 12608
        //		[NonSerialized]
        //		public float DPRate = 1f;

        //		// Token: 0x04003141 RID: 12609
        //		public static PalMain.DISTANCE_CULL m_DistCull = PalMain.DISTANCE_CULL.RESTORE;

        //		// Token: 0x04003142 RID: 12610
        //		public static PalMain.POST_CAM m_PostCam = PalMain.POST_CAM.FULL;

        //		// Token: 0x04003143 RID: 12611
        //		public static PalMain.LIGHT m_Light = PalMain.LIGHT.FULL;

        //		// Token: 0x04003144 RID: 12612
        //		private List<Behaviour> m_CamPosts = new List<Behaviour>();

        //		// Token: 0x04003145 RID: 12613
        //		private List<Light> m_Lights = new List<Light>();

        //		// Token: 0x04003146 RID: 12614
        //		private List<Light> m_LightsShadow = new List<Light>();

        //		// Token: 0x04003147 RID: 12615
        //		private List<Camera> m_Cams = new List<Camera>();

        //		// Token: 0x04003148 RID: 12616
        //		public float m_FarClipPlane;

        //		// Token: 0x04003149 RID: 12617
        //		public bool m_bFog;

        //		// Token: 0x0400314A RID: 12618
        //		public float m_FogStartDistance;

        //		// Token: 0x0400314B RID: 12619
        //		public float m_FogEndDistance;

        //		// Token: 0x0400314C RID: 12620
        //		public float m_FogDensity;

        //		// Token: 0x0400314D RID: 12621
        //		public float m_TreeDistance;

        //		// Token: 0x0400314E RID: 12622
        //		public float m_DetailObjectDistance;

        //		// Token: 0x0400314F RID: 12623
        //		public float m_HeightmapPixelError;

        //		// Token: 0x04003150 RID: 12624
        //		public float m_BasemapDistance;

        //		// Token: 0x04003151 RID: 12625
        //		private float m_DualOffset = 0.2f;

        //		// Token: 0x04003152 RID: 12626
        //		private int m_bDualCam;

        //		// Token: 0x04003153 RID: 12627
        //		public Dictionary<int, PalMain.SceneOptiDistFogParams> m_LevelCullOpParams = new Dictionary<int, PalMain.SceneOptiDistFogParams>();

        //		// Token: 0x04003154 RID: 12628
        //		private bool m_bIsIntel;

        //		// Token: 0x04003155 RID: 12629
        //		private bool m_bIsGDI;

        //		// Token: 0x04003156 RID: 12630
        //		public GameState m_lastGameState = GameState.None;

        //		// Token: 0x04003157 RID: 12631
        //		public Camera m_SkyCam;

        //		// Token: 0x04003158 RID: 12632
        //		private static PalMain.PLAYER_RECOMMANDATION m_PlayerRecommandation;

        //		// Token: 0x04003159 RID: 12633
        //		public bool m_bZhuYuGame;

        //		// Token: 0x0400315A RID: 12634
        //		public bool m_bGuHanJiang;

        //		// Token: 0x0400315B RID: 12635
        //		public static PalMain.UNLOADPROIR m_CurPrior = PalMain.UNLOADPROIR.LONG;

        //		// Token: 0x0400315C RID: 12636
        //		public static float m_CurUnloadTime = 0f;

        //		// Token: 0x0400315D RID: 12637
        //		public static float m_FixImmediateTime = 1f;

        //		// Token: 0x0400315E RID: 12638
        //		public static float m_FixShortTime = 5f;

        //		// Token: 0x0400315F RID: 12639
        //		public static float m_FixLongTime = 15f;

        //		// Token: 0x04003160 RID: 12640
        //		public static float m_FixVeryLongTime = 30f;

        //		// Token: 0x04003161 RID: 12641
        //		public static bool m_bHasUnload = false;

        //		// Token: 0x04003162 RID: 12642
        //		private static bool s_waitForActiveUserWarning = false;

        //		// Token: 0x04003163 RID: 12643
        //		private static bool s_noControllerWarning = false;

        //		// Token: 0x04003164 RID: 12644
        //		private static float s_noControllerTimeCounter = 0f;

        //		// Token: 0x04003165 RID: 12645
        //		public int FOCUS_WAIT_FRAMES = 3;

        //		// Token: 0x04003166 RID: 12646
        //		private int shouldRenewFrames;

        //		// Token: 0x14000025 RID: 37
        //		// (add) Token: 0x06003691 RID: 13969 RVA: 0x00189D90 File Offset: 0x00187F90
        //		// (remove) Token: 0x06003692 RID: 13970 RVA: 0x00189DAC File Offset: 0x00187FAC
        //		public event PalMain.void_func_float_float updateHandles;

        //		// Token: 0x14000026 RID: 38
        //		// (add) Token: 0x06003693 RID: 13971 RVA: 0x00189DC8 File Offset: 0x00187FC8
        //		// (remove) Token: 0x06003694 RID: 13972 RVA: 0x00189DE4 File Offset: 0x00187FE4
        //		public event PalMain.void_func_void onInputHandles;

        //		// Token: 0x14000027 RID: 39
        //		// (add) Token: 0x06003695 RID: 13973 RVA: 0x00189E00 File Offset: 0x00188000
        //		// (remove) Token: 0x06003696 RID: 13974 RVA: 0x00189E1C File Offset: 0x0018801C
        //		public event PalMain.void_func_void onGUIHandles;

        //		// Token: 0x17000428 RID: 1064
        //		// (get) Token: 0x06003697 RID: 13975 RVA: 0x00189E38 File Offset: 0x00188038
        //		public bool IsSkillPreloading
        //		{
        //			get
        //			{
        //				return this.m_skillPreloading;
        //			}
        //		}

        //		// Token: 0x17000429 RID: 1065
        //		// (get) Token: 0x06003698 RID: 13976 RVA: 0x00189E40 File Offset: 0x00188040
        //		// (set) Token: 0x06003699 RID: 13977 RVA: 0x00189E48 File Offset: 0x00188048
        //		public static float LoadingValue
        //		{
        //			get
        //			{
        //				return PalMain.m_loadingValue;
        //			}
        //			set
        //			{
        //				PalMain.m_loadingValue = value;
        //			}
        //		}

        public float CurVersion
        {
            get
            {
                return 2f;
            }
        }

        //		// Token: 0x1700042B RID: 1067
        //		// (get) Token: 0x0600369C RID: 13980 RVA: 0x00189E7C File Offset: 0x0018807C
        //		// (set) Token: 0x0600369B RID: 13979 RVA: 0x00189E58 File Offset: 0x00188058
        //		public static bool IsDLC
        //		{
        //			get
        //			{
        //				return PalMain.IsBranch();
        //			}
        //			set
        //			{
        //				if (value)
        //				{
        //					PalMain.ActiveBranch();
        //					PalMain.mIsDLC = true;
        //				}
        //				else
        //				{
        //					PalMain.InActiveBranch();
        //					PalMain.mIsDLC = false;
        //				}
        //			}
        //		}

        //		// Token: 0x1700042C RID: 1068
        //		// (get) Token: 0x0600369D RID: 13981 RVA: 0x00189E84 File Offset: 0x00188084
        //		public static uint MoneyID
        //		{
        //			get
        //			{
        //				if (PalMain._MoneyID == 0u)
        //				{
        //					PalMain._MoneyID = ItemManager.GetID(16u, 777u);
        //				}
        //				return PalMain._MoneyID;
        //			}
        //		}

        //		// Token: 0x0600369E RID: 13982 RVA: 0x00189EB4 File Offset: 0x001880B4
        //		public void ResetWatch()
        //		{
        //			Transform transform = UtilFun.GetMainCamera().transform;
        //			FirstPersonEyesEffect component = transform.GetComponent<FirstPersonEyesEffect>();
        //			SmoothFollow2 component2 = transform.GetComponent<SmoothFollow2>();
        //			PalMain.WatchType watchType = this.mCurWatchType;
        //			if (watchType != PalMain.WatchType.FirstPerson)
        //			{
        //				if (watchType == PalMain.WatchType.ThirdPerson)
        //				{
        //					transform.parent = null;
        //					if (component != null)
        //					{
        //						component.enabled = false;
        //					}
        //					if (component2 != null)
        //					{
        //						component2.enabled = true;
        //					}
        //				}
        //			}
        //			else if (PlayersManager.Player)
        //			{
        //				transform.parent = GameObjectPath.GetHeadObj(PlayerCtrlManager.agentObj.transform);
        //				transform.localPosition = GameObjectPath.GetFirstPersonCamera(GameObjectPath.GetEyeObjs(PlayerCtrlManager.agentObj.transform));
        //				transform.localRotation = Quaternion.LookRotation(Vector3.up, -Vector3.right);
        //				if (component != null)
        //				{
        //					component.enabled = true;
        //				}
        //				if (component2 != null)
        //				{
        //					component2.enabled = false;
        //				}
        //			}
        //		}

        //		// Token: 0x1700042D RID: 1069
        //		// (get) Token: 0x0600369F RID: 13983 RVA: 0x00189FA8 File Offset: 0x001881A8
        //		// (set) Token: 0x060036A0 RID: 13984 RVA: 0x00189FB0 File Offset: 0x001881B0
        //		public PalMain.WatchType CurWatchType
        //		{
        //			get
        //			{
        //				return this.mCurWatchType;
        //			}
        //			set
        //			{
        //				if (this.mCurWatchType != value)
        //				{
        //					this.mCurWatchType = value;
        //					this.ResetWatch();
        //				}
        //			}
        //		}

        //		// Token: 0x1700042E RID: 1070
        //		// (get) Token: 0x060036A1 RID: 13985 RVA: 0x00189FCC File Offset: 0x001881CC
        //		public static GameObject MapInfo
        //		{
        //			get
        //			{
        //				if (PalMain.mapinfo == null)
        //				{
        //					PalMain.mapinfo = GameObject.FindGameObjectWithTag("MapInfo");
        //					if (PalMain.mapinfo == null && SceneManager.GetActiveScene().name.ToLower() != "empty")
        //					{
        //						MapData data = MapData.GetData(UtilFun.GetPalMapLevel(SceneManager.GetActiveScene().buildIndex));
        //						if (data != null)
        //						{
        //							PalMain.mapinfo = FileLoader.LoadObjectFromFile<GameObject>((PalMain.mapInfoPrefix + data.MapInfoPath).ToAssetBundlePath(), true, true);
        //						}
        //					}
        //					if (PalMain.mapinfo == null && SceneManager.GetActiveScene().name.ToLower() != "empty")
        //					{
        //						UnityEngine.Debug.LogError("没有找到MapInfo，请在 地图csv中设置其相关路径");
        //						PalMain.mapinfo = new GameObject("MapInfo");
        //						PalMain.mapinfo.tag = "MapInfo";
        //					}
        //				}
        //				return PalMain.mapinfo;
        //			}
        //		}

        //		// Token: 0x1700042F RID: 1071
        //		// (get) Token: 0x060036A2 RID: 13986 RVA: 0x0018A0C8 File Offset: 0x001882C8
        //		public static GameObject MainObj
        //		{
        //			get
        //			{
        //				if (PalMain.mMainObj == null)
        //				{
        //					PalMain.mMainObj = GameObject.Find("/Main");
        //					if (PalMain.mMainObj == null)
        //					{
        //						PalMain.mMainObj = new GameObject("Main");
        //					}
        //				}
        //				return PalMain.mMainObj;
        //			}
        //		}

        //		// Token: 0x17000430 RID: 1072
        //		// (get) Token: 0x060036A3 RID: 13987 RVA: 0x0018A118 File Offset: 0x00188318
        //		// (set) Token: 0x060036A4 RID: 13988 RVA: 0x0018A19C File Offset: 0x0018839C
        //		public static GameObject MainCamera
        //		{
        //			get
        //			{
        //				if (PalMain.m_MainCamera == null)
        //				{
        //					GameObject gameObject = GameObject.Find("/Main Camera Pal");
        //					if (gameObject != null)
        //					{
        //						PalMain.m_MainCamera = gameObject;
        //					}
        //					else if (UtilFun.GetMainCamera() != null)
        //					{
        //						PalMain.m_MainCamera = UtilFun.GetMainCamera().gameObject;
        //					}
        //					if (PalMain.m_MainCamera != null)
        //					{
        //						PalMain.MainCameraTF = PalMain.m_MainCamera.transform;
        //					}
        //				}
        //				return PalMain.m_MainCamera;
        //			}
        //			set
        //			{
        //				PalMain.m_MainCamera = value;
        //				if (PalMain.m_MainCamera != null)
        //				{
        //					PalMain.MainCameraTF = PalMain.m_MainCamera.transform;
        //				}
        //			}
        //		}

        //		// Token: 0x060036A5 RID: 13989 RVA: 0x0018A1C4 File Offset: 0x001883C4
        //		public void ReStart()
        //		{
        //			UIManager.Instance.DoNotOpenMainMenu = false;
        //			PalMain.IsDLC = false;
        //			PlayerTeam.ReStart();
        //			PlayersManager.Restart();
        //			PlayerCtrlManager.Reset();
        //			PalMain.Instance.CurBattleFormationManager.Clear();
        //			BattleFormationManager.BattleFormationData battleFormationData = new BattleFormationManager.BattleFormationData();
        //			battleFormationData.m_InFormationCharaDatas.AddRange(new BattleFormationManager.InFormationCharaData[9]);
        //			PalMain.Instance.CurBattleFormationManager.AddFormation(battleFormationData);
        //			PalBattleManager.Instance().Restart();
        //			FlagManager.InitFlags();
        //			ItemManager.GetInstance().ClearData();
        //			for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
        //			{
        //				try
        //				{
        //					PalNPC component = PlayersManager.AllPlayers[i].GetComponent<PalNPC>();
        //					if (component != null && component.Data != null && component.m_SkillIDs != null)
        //					{
        //						PlayersManager.AllPlayers[i].GetComponent<PalNPC>().Data.Exp = 0;
        //						PlayersManager.AllPlayers[i].GetComponent<PalNPC>().Data.Soul = 0;
        //						PlayersManager.AllPlayers[i].GetComponent<PalNPC>().m_SkillIDs.Clear();
        //						if (i < PlayersManager.AllPlayers.Count)
        //						{
        //							component = PlayersManager.AllPlayers[i].GetComponent<PalNPC>();
        //							if (component != null)
        //							{
        //								BuffDebuffManager.BuffDebuffOwner buffDebuffData = PlayersManager.AllPlayers[i].GetComponent<PalNPC>().BuffDebuffData;
        //								if (buffDebuffData != null)
        //								{
        //									buffDebuffData.ClearData();
        //								}
        //							}
        //						}
        //					}
        //				}
        //				catch
        //				{
        //				}
        //			}
        //			OrnamentItemTypeCache.ClearIsGet();
        //			FashionClothItemTypeCache.ClearIsGet();
        //			MonsterProperty.HideAll();
        //			UIInformation_Help_Item.ReStart();
        //			UIInformation_StrangeNews_Item.ReStart();
        //			MissionManager.Restart();
        //			RenownManager.Reset();
        //			HuanHuaManager.Instance.Reset();
        //			DynamicObjsDataManager.Instance.Clear();
        //		}

        //		// Token: 0x060036A6 RID: 13990 RVA: 0x0018A38C File Offset: 0x0018858C
        //		public static bool GetPersonCtrl()
        //		{
        //			return PlayerCtrlManager.bControl;
        //		}

        //		// Token: 0x060036A7 RID: 13991 RVA: 0x0018A394 File Offset: 0x00188594
        //		public static void CheckLottery(out int result, out string outString)
        //		{
        //			result = 1;
        //			outString = null;
        //			StringBuilder stringBuilder = null;
        //			result = (int)SelfExtern.Lottery(out stringBuilder);
        //			outString = stringBuilder.ToString();
        //		}

        //		// Token: 0x060036A8 RID: 13992 RVA: 0x0018A3BC File Offset: 0x001885BC
        //		public static void SpawnLottery()
        //		{
        //			List<PalGameObjectBase> monsters = CharactersManager.Instance.Monsters;
        //			PalGameObjectBase palGameObjectBase = null;
        //			int i = monsters.Count;
        //			while (i > 0)
        //			{
        //				i--;
        //				int index = UnityEngine.Random.Range(0, monsters.Count - 1);
        //				PalGameObjectBase palGameObjectBase2 = monsters[index];
        //				if (palGameObjectBase2 != null)
        //				{
        //					palGameObjectBase = palGameObjectBase2;
        //					break;
        //				}
        //			}
        //			if (palGameObjectBase == null)
        //			{
        //				UnityEngine.Debug.LogError("没有找到怪物，SpawnLottery失败");
        //				return;
        //			}
        //			palGameObjectBase.gameObject.SetActive(false);
        //			GameObject gameObject = new GameObject("Lottery");
        //			Transform transform = gameObject.transform;
        //			transform.position = palGameObjectBase.transform.position;
        //			transform.parent = palGameObjectBase.transform.parent;
        //			if (Console.showConsole)
        //			{
        //				string text = "Log : 乐动宝箱的位置为 " + transform.position.ToString();
        //				UnityEngine.Debug.Log(text);
        //				Console.Log(text);
        //			}
        //			PalLottery palLottery = gameObject.AddComponent<PalLottery>();
        //			palLottery.PickItemID = UnityEngine.Random.Range(1008, 1020);
        //			palLottery.SetModelResourcePath("Character/Props/EXPH_SQ_baoxiang_jin.prefab", 1);
        //			Interact interact = gameObject.AddComponent<Interact>();
        //			interact.ActionClassName = "baoxiang_Lottery";
        //		}

        //		// Token: 0x060036A9 RID: 13993 RVA: 0x0018A4EC File Offset: 0x001886EC
        //		public static void SetGameState(GameState newState)
        //		{
        //			GameStateManager.CurGameState = newState;
        //		}

        //		// Token: 0x060036AA RID: 13994 RVA: 0x0018A4F4 File Offset: 0x001886F4
        //		public static void ChangeModel(int ID, GameObject newGo)
        //		{
        //			GameObject gameObject = PlayersManager.FindMainChar(ID, true);
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("没有找到此人");
        //				return;
        //			}
        //			ModelChangeScript component = gameObject.GetComponent<ModelChangeScript>();
        //			if (component != null)
        //			{
        //				if (component.curMode == ModelChangeScript.Mode.Another)
        //				{
        //					component.curMode = ModelChangeScript.Mode.Original;
        //				}
        //				else
        //				{
        //					component.curMode = ModelChangeScript.Mode.Another;
        //				}
        //			}
        //			else
        //			{
        //				UnityEngine.Debug.LogError(ID.ToString() + "没有找到ModelChangeScript,直接调用了PalNPC里面的函数ChangeModel");
        //				PalNPC component2 = gameObject.GetComponent<PalNPC>();
        //				component2.ChangeModel(newGo, true);
        //			}
        //		}

        //		// Token: 0x060036AB RID: 13995 RVA: 0x0018A57C File Offset: 0x0018877C
        //		public static void AddRenownValue(int ID, int AddValue)
        //		{
        //			RenownManager.AddRenownValue(ID, AddValue);
        //		}

        //		// Token: 0x060036AC RID: 13996 RVA: 0x0018A588 File Offset: 0x00188788
        //		public static Renown.Manner GetRenownManner(int ID)
        //		{
        //			return RenownManager.GetRenownManner(ID);
        //		}

        //		public static GameObject GetPlayer(bool bAgent)
        //		{
        //			GameObject result;
        //			if (bAgent)
        //			{
        //				result = PlayerCtrlManager.agentObj.gameObject;
        //			}
        //			else
        //			{
        //				result = PlayersManager.Player;
        //			}
        //			return result;
        //		}

        //		// Token: 0x060036AE RID: 13998 RVA: 0x0018A5BC File Offset: 0x001887BC
        //		public static int GetPlayerID()
        //		{
        //			string name = PlayersManager.Player.name;
        //			return int.Parse(name);
        //		}

        //		// Token: 0x060036AF RID: 13999 RVA: 0x0018A5DC File Offset: 0x001887DC
        //		public static bool ExistInTeam(int id)
        //		{
        //			GameObject player = PlayersManager.GetPlayer(id);
        //			return player != null;
        //		}

        //		// Token: 0x060036B0 RID: 14000 RVA: 0x0018A5F8 File Offset: 0x001887F8
        //		public static GameObject GetModelObj(GameObject go)
        //		{
        //			GameObject gameObject = null;
        //			PalGameObjectBase component = go.GetComponent<PalGameObjectBase>();
        //			if (component != null)
        //			{
        //				gameObject = component.model;
        //			}
        //			if (gameObject == null)
        //			{
        //				gameObject = go;
        //			}
        //			return gameObject;
        //		}

        //		// Token: 0x060036B1 RID: 14001 RVA: 0x0018A630 File Offset: 0x00188830
        //		public static GameObject AddPlayer(int ID)
        //		{
        //			return PlayersManager.AddPlayer(ID, true);
        //		}

        //		// Token: 0x060036B2 RID: 14002 RVA: 0x0018A63C File Offset: 0x0018883C
        //		public static void SetPlayer(int Index)
        //		{
        //			PlayersManager.SetPlayer(Index, true);
        //		}

        public static PalMain GameMain
        {
            get
            {               
                return PalMain.instance;
            }
        }

        public static PalMain Instance
        {
            get
            {
                return PalMain.instance;
            }
        }

        //		// Token: 0x060036B6 RID: 14006 RVA: 0x0018A71C File Offset: 0x0018891C
        //		public static bool Exist()
        //		{
        //			return PalMain.instance != null;
        //		}

        //		// Token: 0x17000433 RID: 1075
        //		// (get) Token: 0x060036B7 RID: 14007 RVA: 0x0018A72C File Offset: 0x0018892C
        //		public static bool IsLow
        //		{
        //			get
        //			{
        //				bool result = false;
        //				if (PalMain.ForceLow)
        //				{
        //					result = true;
        //				}
        //				else if (SystemInfo.graphicsMemorySize < 900)
        //				{
        //					result = true;
        //				}
        //				else if (PalMain.IsWin32)
        //				{
        //					result = true;
        //				}
        //				return result;
        //			}
        //		}

        //		// Token: 0x17000434 RID: 1076
        //		// (get) Token: 0x060036B8 RID: 14008 RVA: 0x0018A770 File Offset: 0x00188970
        //		public static bool MemoryLack
        //		{
        //			get
        //			{
        //				return false;
        //			}
        //		}

        private void Awake()
        {
            this.Initialize();
        }

        //		// Token: 0x060036BB RID: 14011 RVA: 0x0018A7B8 File Offset: 0x001889B8
        //		public static void LoadOneLangueUIAtlas(string subname)
        //		{
        //			string path = subname.ToLanguagePath();
        //			UIAtlas uiatlas = FileLoader.LoadComponentFromFile<UIAtlas>(path, false);
        //			FileLoader.SetNoUnload(path, true);
        //			string path2 = ("AssetBundles/UI/" + subname + "_Empty").ToAssetBundlePath();
        //			UIAtlas uiatlas2 = FileLoader.LoadComponentFromFile<UIAtlas>(path2, false);
        //			FileLoader.SetNoUnload(path2, true);
        //			uiatlas2.gameObject.name = subname + "_Empty";
        //			NGUITools.SetCacheAtlas(subname, uiatlas);
        //			NGUITools.SetCacheAtlas(subname + "_Empty", uiatlas2);
        //			uiatlas2.replacement = uiatlas;
        //		}

        //		// Token: 0x060036BC RID: 14012 RVA: 0x0018A838 File Offset: 0x00188A38
        //		public static void ReleaseLangueUIAtlas(string subname)
        //		{
        //			string path = subname.ToLanguagePath();
        //			FileLoader.SetNoUnload(path, false);
        //			FileLoader.UnloadAssetBundle(path);
        //			NGUITools.RemoveCacheAtlas(subname);
        //		}

        //		// Token: 0x060036BD RID: 14013 RVA: 0x0018A860 File Offset: 0x00188A60
        //		public static void ReloadLangueUIAtlas(string subname)
        //		{
        //			string path = subname.ToLanguagePath();
        //			UIAtlas uiatlas = FileLoader.LoadComponentFromFile<UIAtlas>(path, false);
        //			FileLoader.SetNoUnload(path, true);
        //			string name = subname + "_Empty";
        //			UIAtlas cacheAtlas = NGUITools.GetCacheAtlas(name);
        //			NGUITools.SetCacheAtlas(subname, uiatlas);
        //			cacheAtlas.replacement = uiatlas;
        //		}

        private void Initialize()
        {
            //try
            //{
            //    if (ConfigManager.ReadWritePath == null)
            //    {
            //        UnityEngine.Debug.LogError("Read or write fail 0x2204.");
            //        UtilFun.WinMessageBox("read or write fail", "error", 8708);
            //        Application.Quit();
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UnityEngine.Debug.Log(ex.ToString() + " 0x2204.");
            //    UtilFun.WinMessageBox(ex.ToString(), "error", 8708);
            //    Application.Quit();
            //    return;
            //}

            int num = QualitySettings.names.Length - 1;
            num = Mathf.Clamp(num, 0, 10);
            QualitySettings.SetQualityLevel(num);
            //OptionConfig optionConfig = OptionConfig.GetInstance();
            //if (!ConfigManager.IsFileExist())
            //{
            //    optionConfig.SetAllQualityFirstTime(PalMain.FirstTimeLaunch103());
            //    optionConfig.Save();
            //}
            //optionConfig.Use_Start();
            //optionConfig.Use_Other();

            Physics.gravity = new Vector3(0f, -20f, 0f);//重力设置
            Physics2D.queriesHitTriggers = false;//关闭2D碰撞
            //QualitySettings.blendWeights = BlendWeights.FourBones;
            //string operatingSystem = SystemInfo.operatingSystem;
            //PalMain.IsXP = operatingSystem.Contains("Windows XP");
            //PalMain.IsWin32 = !operatingSystem.Contains("64bit");
            //if (!PalMain.IsXP)
            //{
            //    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
            //    QualitySettings.shadowProjection = ShadowProjection.StableFit;
            //}

            PalMain.instance = this;

            //ItemManager.GetInstance().OnBeforeRemoveItem += this.PutOffItem;
            //			ItemPackage orCreatePackage = ItemManager.GetInstance().GetOrCreatePackage(1u);
            //			orCreatePackage.OnItemAdded += delegate(IItem obj)
            //			{
            //				SymbolNodeItemType symbolNodeItemType = obj.ItemType as SymbolNodeItemType;
            //				if (symbolNodeItemType != null)
            //				{
            //					SymbolNodeItemType.SetState(symbolNodeItemType.TypeID & 255u, true);
            //				}
            //				SymbolPanelItemType symbolPanelItemType = obj.ItemType as SymbolPanelItemType;
            //				if (symbolPanelItemType != null)
            //				{
            //					SymbolPanelItemType.SetState(symbolPanelItemType.TypeID & 255u, true);
            //				}
            //				AchievementManager.SingleAchievement[] achievements = PalBattleManager.Instance().m_Achievement.m_Achievements;
            //				OrnamentItemTypeCache.SetIsGet(obj.ItemType.TypeID, true);
            //				achievements[190].m_CurrentNum = ((OrnamentItemTypeCache.IsGetRate() < 1f) ? 0 : 1);
            //				FashionClothItemTypeCache.SetIsGet(obj.ItemType.TypeID, true);
            //				achievements[189].m_CurrentNum = ((FashionClothItemTypeCache.IsGetRate() < 1f) ? 0 : 1);
            //			};

            //			MouseEventManager.Initialize();
            //			ShaderPropertyIDManager.Initialize();
            //			MessageProcess.Initialize();
            //			SetActiveByFlagManager.Initialize();
            //ScenesManager.Initialize();
            //			FlagManager.Initialize();
            //			DistanceCullManager.Initialize();
            //			MoviesManager.Initialize();
            //			CharactersManager.Initialize();
            //			InputManager.Initialize();
            PlayerCtrlManager.Initialize();
            //PalBattleManager.Initialize();
            //			EntityManager.Initialize();
            //			MissionTick.Initialize();
            PlayersManager.Initialize();
            //			RenownManager.Initialize();
            //			AnimWithoutClothSet.Initialize();
            //			SlowLoopAnimSet.Initialize();
            //			WaterEffectTrigger.Initialize();
            //			CompoundItemList.CreateWatch();
            //			SaveManager.OnLoadOver += delegate()
            //			{
            //				try
            //				{
            //					int num2 = 0;
            //					List<IEnumerator> list = new List<IEnumerator>(8);
            //					foreach (GameObject gameObject in PlayersManager.AllPlayers)
            //					{
            //						if (gameObject != null)
            //						{
            //							PalNPC component = gameObject.GetComponent<PalNPC>();
            //							if (component != null)
            //							{
            //								list.Add(component.Prepare());
            //							}
            //						}
            //					}
            //					list.Add(ItemManager.GetInstance().Prepare());
            //					list.Add(BuffDebuffManager.GetInstance().Prepare());
            //					while (list.Count > 0)
            //					{
            //						list.RemoveAll((IEnumerator curManager) => curManager == null || !curManager.MoveNext());
            //						num2++;
            //						if (num2 > 32)
            //						{
            //							UnityEngine.Debug.LogError("加载进程可能陷入了死循环");
            //							foreach (IEnumerator enumerator3 in list)
            //							{
            //								UnityEngine.Debug.LogError(enumerator3.ToString());
            //							}
            //							break;
            //						}
            //					}
            //					CompoundItemList.CreateWatch();
            //					foreach (SoulStarData soulStarData in SoulDataManager.GetDatasFromFile())
            //					{
            //						if (SoulDataManager.Instance != null)
            //						{
            //							if (soulStarData != null)
            //							{
            //								if (SoulDataManager.Instance.IsSoulOpen(soulStarData.NodeID))
            //								{
            //									soulStarData.OpenScriptFun();
            //								}
            //							}
            //						}
            //					}
            //					foreach (GameObject gameObject2 in PlayersManager.AllPlayers)
            //					{
            //						PalNPC component2 = gameObject2.GetComponent<PalNPC>();
            //						if (component2.Data.HPMPDP != null)
            //						{
            //							component2.Data.HPMPDP.SetWithoutEvents(component2.Data.LoadHP, component2.Data.LoadMP, component2.Data.LoadDP);
            //						}
            //					}
            //					try
            //					{
            //						if (ItemManager.GetInstance() != null)
            //						{
            //							ItemPackage orCreatePackage2 = ItemManager.GetInstance().GetOrCreatePackage(1u);
            //							if (orCreatePackage2 != null)
            //							{
            //								foreach (IItem[] array in ItemManager.GetInstance().GetOrCreatePackage(1u).ForEachItemArrayInPackage())
            //								{
            //									if (array != null && array.Length >= 0 && array[0] != null)
            //									{
            //										if (0 < array.Length && array[0].ItemType != null)
            //										{
            //											CompoundItemList.ReCheck(array[0].ItemType.TypeID);
            //										}
            //									}
            //								}
            //								int hadCreateCount = CompoundItemList.HadCreateCount;
            //								AchievementManager.SingleAchievement[] achievements = PalBattleManager.Instance().m_Achievement.m_Achievements;
            //								achievements[7].m_CurrentNum = hadCreateCount;
            //								achievements[8].m_CurrentNum = hadCreateCount;
            //								achievements[9].m_CurrentNum = hadCreateCount;
            //							}
            //						}
            //					}
            //					catch (Exception exception)
            //					{
            //						UnityEngine.Debug.LogException(exception);
            //					}
            //					try
            //					{
            //						for (int j = 0; j < 6; j++)
            //						{
            //							bool flag = true;
            //							int num3 = j * 84;
            //							for (int k = 0; k < 84; k++)
            //							{
            //								if (SoulDataManager.GetData(num3 + k) != null)
            //								{
            //									if (!SoulDataManager.Instance.IsSoulOpen(num3 + k))
            //									{
            //										flag = false;
            //										break;
            //									}
            //								}
            //							}
            //							if (flag)
            //							{
            //								PalBattleManager.Instance().m_Achievement.m_Achievements[21].m_CurrentNum = ((!flag) ? 0 : 262143);
            //								break;
            //							}
            //						}
            //					}
            //					catch (Exception exception2)
            //					{
            //						UnityEngine.Debug.LogException(exception2);
            //					}
            //					try
            //					{
            //						foreach (GameObject gameObject3 in PlayersManager.AllPlayers)
            //						{
            //							if (!(gameObject3 == null))
            //							{
            //								PalNPC component3 = gameObject3.GetComponent<PalNPC>();
            //								if (!(component3 == null) && component3.Data != null)
            //								{
            //									if (component3.Data.CharacterID >= 0 && component3.Data.CharacterID <= 5)
            //									{
            //										IItem item = component3.GetSlot(EquipSlotEnum.Weapon);
            //										if (item == null)
            //										{
            //											foreach (IItem[] array2 in ItemManager.GetInstance().GetOrCreatePackage(1u).ForEachItemArrayInPackage())
            //											{
            //												if (array2 != null && array2.Length > 0)
            //												{
            //													if (array2[0] is WeaponItem)
            //													{
            //														foreach (IItem item2 in array2)
            //														{
            //															if (item2 != null)
            //															{
            //																WeaponItem weaponItem = item2 as WeaponItem;
            //																if (weaponItem != null && !(weaponItem.GetOwner() != null))
            //																{
            //																	WeaponItemType weaponItemType = weaponItem.ItemType as WeaponItemType;
            //																	if (weaponItemType != null)
            //																	{
            //																		if (((ulong)weaponItemType.CharacterMark & (ulong)(1L << (component3.Data.CharacterID & 31))) != 0UL)
            //																		{
            //																			if (item == null)
            //																			{
            //																				item = weaponItem;
            //																			}
            //																			else if (ShowWeaponItemComparer.GetInstance().Compare(item, weaponItem) > 0)
            //																			{
            //																				item = weaponItem;
            //																			}
            //																			break;
            //																		}
            //																	}
            //																}
            //															}
            //														}
            //													}
            //												}
            //											}
            //											if (item != null)
            //											{
            //												component3.PutOnEquip(item as WeaponItem);
            //											}
            //										}
            //									}
            //								}
            //							}
            //						}
            //					}
            //					catch (Exception exception3)
            //					{
            //						UnityEngine.Debug.LogException(exception3);
            //					}
            //				}
            //				catch (Exception exception4)
            //				{
            //					UnityEngine.Debug.LogException(exception4);
            //				}
            //			};
            //			PlayersManager.OnAddPlayer = (Action<int>)Delegate.Combine(PlayersManager.OnAddPlayer, new Action<int>(delegate(int playerid)
            //			{
            //				if (PalMain.Instance.CurBattleFormationManager.m_Formations.Count <= 0)
            //				{
            //					BattleFormationManager.BattleFormationData battleFormationData = new BattleFormationManager.BattleFormationData();
            //					PalMain.Instance.CurBattleFormationManager.AddFormation(battleFormationData);
            //					foreach (GameObject go in PlayersManager.ActivePlayers)
            //					{
            //						battleFormationData.AddOrChangeCharacter(go.GetCharacterID(), 0);
            //					}
            //					while (battleFormationData.m_InFormationCharaDatas.Count < 9)
            //					{
            //						battleFormationData.m_InFormationCharaDatas.Add(null);
            //					}
            //				}
            //				else
            //				{
            //					BattleFormationManager.BattleFormationData battleFormationData = PalMain.Instance.CurBattleFormationManager.m_Formations[0];
            //					while (battleFormationData.m_InFormationCharaDatas.Count < 9)
            //					{
            //						battleFormationData.m_InFormationCharaDatas.Add(null);
            //					}
            //					if (battleFormationData.GetPlayer(playerid) == null)
            //					{
            //						for (int i = 0; i < 9; i++)
            //						{
            //							if (battleFormationData.m_InFormationCharaDatas[i] == null)
            //							{
            //								battleFormationData.m_InFormationCharaDatas[i] = new BattleFormationManager.InFormationCharaData(playerid, 0);
            //								break;
            //							}
            //						}
            //					}
            //				}
            //			}));
            //			PlayersManager.OnRemovePlayer += delegate(int playerid)
            //			{
            //				if (PalMain.Instance.CurBattleFormationManager.m_Formations.Count <= 0)
            //				{
            //					return;
            //				}
            //				BattleFormationManager.BattleFormationData battleFormationData = PalMain.Instance.CurBattleFormationManager.m_Formations[0];
            //				if (battleFormationData == null)
            //				{
            //					return;
            //				}
            //				if (battleFormationData.m_InFormationCharaDatas[0] != null && battleFormationData.m_InFormationCharaDatas[0].m_CharacterID != playerid)
            //				{
            //					return;
            //				}
            //				while (battleFormationData.m_InFormationCharaDatas.Count < 9)
            //				{
            //					battleFormationData.m_InFormationCharaDatas.Add(null);
            //				}
            //				for (int i = 1; i < 9; i++)
            //				{
            //					BattleFormationManager.InFormationCharaData inFormationCharaData = battleFormationData.m_InFormationCharaDatas[i];
            //					if (inFormationCharaData != null)
            //					{
            //						if (!(PlayersManager.GetPlayer(inFormationCharaData.m_CharacterID) == null))
            //						{
            //							battleFormationData.m_InFormationCharaDatas[i] = battleFormationData.m_InFormationCharaDatas[0];
            //							battleFormationData.m_InFormationCharaDatas[0] = inFormationCharaData;
            //							break;
            //						}
            //					}
            //				}
            //			};
            //			UIManager.Instance.Initialize();
            //			EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOver, new EntityManager.void_fun(MiniMap.Instance.OnLoadOver));
            //			MissionManager.Initialize();
            //			HuanHuaManager.Instance.Initialize();
            //			PanelFaceManager.Initialize();
            //			PanelPositonManager.Initialize();
            //			Cutscene2DManager.Initialize();
            //			ScenesManager.Instance.RandomFlash();
            //			TimeManager.Initialize();
            //			SaveManager.OnLoadOver -= SceneFall2.SetLastPointOnLoadOver;
            //			SaveManager.OnLoadOver += SceneFall2.SetLastPointOnLoadOver;
            //			PalMain.MinFPS = this.minFPS;
            //			PalMain.MinDeltaTime = 1f / this.minFPS;
            //			PalMain.backgroundAudio = base.gameObject.GetComponent<BackgroundAudio>();
            //			if (PalMain.backgroundAudio == null)
            //			{
            //				PalMain.backgroundAudio = base.gameObject.AddComponent<BackgroundAudio>();
            //			}
            //			OptionConfig.GetInstance().Use_CharacterEmission();
            //SaveManager.LoadGlobalData();
            //			FunfiaSteamManager funfiaSteamManager = FunfiaSteamManager.Instance;
            //			if (SkillSEPreloader.s_preloadEnable && SkillSEPreloader.Instance == null)
            //			{
            //				SkillSEPreloader.Initialize();
            //			}
        }

        private void PutOffItem(IItem inItem)
        {
            //IItemAssemble<SymbolPanelItem> itemAssemble = inItem as IItemAssemble<SymbolPanelItem>;
            //if (itemAssemble != null)
            //{
            //    SymbolPanelItem owner = itemAssemble.GetOwner();
            //    if (owner != null)
            //    {
            //        owner.RemoveNode(itemAssemble as SymbolNodeItem);
            //    }
            //}
            //IItemAssemble<PalNPC> itemAssemble2 = inItem as IItemAssemble<PalNPC>;
            //if (itemAssemble2 != null)
            //{
            //    PalNPC owner2 = itemAssemble2.GetOwner();
            //    if (owner2 != null)
            //    {
            //        owner2.PutOffEquip(inItem);
            //    }
            //}
        }

        //		// Token: 0x060036C1 RID: 14017 RVA: 0x0018ADE4 File Offset: 0x00188FE4
        //		public void InitPlayBeginMovie()
        //		{
        //			if (SceneManager.GetActiveScene().buildIndex == 0)
        //			{
        //				this.updateHandles = (PalMain.void_func_float_float)Delegate.Combine(this.updateHandles, new PalMain.void_func_float_float(this.PlayBeginMovie));
        //			}
        //		}

        //		// Token: 0x060036C2 RID: 14018 RVA: 0x0018AE28 File Offset: 0x00189028
        //		private void PlayBeginMovie(float d, float a)
        //		{
        //			if (StartInit.Instance == null)
        //			{
        //				UnityEngine.Debug.LogError("StartInit.Instance==null 无法播放健康公告");
        //			}
        //			else
        //			{
        //				StartInit.Instance.ShowCore();
        //			}
        //			this.updateHandles = (PalMain.void_func_float_float)Delegate.Remove(this.updateHandles, new PalMain.void_func_float_float(this.PlayBeginMovie));
        //		}

        //		// Token: 0x060036C3 RID: 14019 RVA: 0x0018AE80 File Offset: 0x00189080
        //		private void Start()
        //		{
        //			this.m_LevelCullOpParams.Add(0, new PalMain.SceneOptiDistFogParams(0, -1f, 305f, 305f));
        //			this.m_LevelCullOpParams.Add(1, new PalMain.SceneOptiDistFogParams(1, -1f, 200f, 105f));
        //			this.m_LevelCullOpParams.Add(2, new PalMain.SceneOptiDistFogParams(2, -1f, 145f, 145f));
        //			this.m_LevelCullOpParams.Add(3, new PalMain.SceneOptiDistFogParams(3, -1f, 150f, 75f));
        //			this.m_LevelCullOpParams.Add(4, new PalMain.SceneOptiDistFogParams(4, -1f, 150f, 75f));
        //			this.m_LevelCullOpParams.Add(5, new PalMain.SceneOptiDistFogParams(5, -1f, 200f, 75f));
        //			this.m_LevelCullOpParams.Add(6, new PalMain.SceneOptiDistFogParams(6, -1f, 70f, 45f));
        //			this.m_LevelCullOpParams.Add(7, new PalMain.SceneOptiDistFogParams(7, -1f, 150f, 95f));
        //			this.m_LevelCullOpParams.Add(8, new PalMain.SceneOptiDistFogParams(8, -1f, 200f, 105f));
        //			this.m_LevelCullOpParams.Add(9, new PalMain.SceneOptiDistFogParams(9, -1f, 100f, 65f));
        //			this.m_LevelCullOpParams.Add(10, new PalMain.SceneOptiDistFogParams(10, -1f, 120f, 85f));
        //			this.m_LevelCullOpParams.Add(11, new PalMain.SceneOptiDistFogParams(11, -1f, 70f, 35f));
        //			this.m_LevelCullOpParams.Add(12, new PalMain.SceneOptiDistFogParams(12, -1f, 80f, 105f));
        //			this.m_LevelCullOpParams.Add(13, new PalMain.SceneOptiDistFogParams(13, -1f, 150f, 75f));
        //			this.m_LevelCullOpParams.Add(14, new PalMain.SceneOptiDistFogParams(14, -1f, 140f, 85f));
        //			this.m_LevelCullOpParams.Add(15, new PalMain.SceneOptiDistFogParams(15, -1f, 100f, 75f));
        //			this.m_LevelCullOpParams.Add(16, new PalMain.SceneOptiDistFogParams(16, -1f, 200f, 205f));
        //			this.m_LevelCullOpParams.Add(17, new PalMain.SceneOptiDistFogParams(17, -1f, 140f, 75f));
        //			this.m_LevelCullOpParams.Add(18, new PalMain.SceneOptiDistFogParams(18, -1f, 200f, 205f));
        //			this.m_LevelCullOpParams.Add(19, new PalMain.SceneOptiDistFogParams(19, -1f, 250f, 155f));
        //			this.m_LevelCullOpParams.Add(20, new PalMain.SceneOptiDistFogParams(20, -1f, 150f, 85f));
        //			this.m_LevelCullOpParams.Add(21, new PalMain.SceneOptiDistFogParams(21, -1f, 300f, 305f));
        //			this.m_LevelCullOpParams.Add(22, new PalMain.SceneOptiDistFogParams(22, -1f, 150f, 55f));
        //			this.m_LevelCullOpParams.Add(23, new PalMain.SceneOptiDistFogParams(23, -1f, 120f, 55f));
        //			this.m_LevelCullOpParams.Add(24, new PalMain.SceneOptiDistFogParams(24, -1f, 100f, 105f));
        //			this.m_LevelCullOpParams.Add(25, new PalMain.SceneOptiDistFogParams(25, -1f, 120f, 45f));
        //			this.m_LevelCullOpParams.Add(26, new PalMain.SceneOptiDistFogParams(26, -1f, 75f, 75f));
        //			this.m_LevelCullOpParams.Add(27, new PalMain.SceneOptiDistFogParams(27, -1f, 200f, 75f));
        //			this.m_LevelCullOpParams.Add(28, new PalMain.SceneOptiDistFogParams(28, -1f, 200f, 75f));
        //			this.m_LevelCullOpParams.Add(29, new PalMain.SceneOptiDistFogParams(29, -1f, 105f, 105f));
        //			this.m_LevelCullOpParams.Add(30, new PalMain.SceneOptiDistFogParams(30, -1f, 105f, 105f));
        //			this.m_LevelCullOpParams.Add(31, new PalMain.SceneOptiDistFogParams(31, -1f, 150f, 75f));
        //			this.m_LevelCullOpParams.Add(32, new PalMain.SceneOptiDistFogParams(32, -1f, 105f, 105f));
        //			this.m_LevelCullOpParams.Add(33, new PalMain.SceneOptiDistFogParams(33, -1f, 200f, 105f));
        //			this.m_LevelCullOpParams.Add(34, new PalMain.SceneOptiDistFogParams(34, -1f, 905f, 905f));
        //			string text = SystemInfo.graphicsDeviceName;
        //			string text2 = SystemInfo.graphicsDeviceVendor;
        //			UnityEngine.Debug.Log(string.Format("[Info] : Graphics Device Name={0}, Vender={1}", text, text2));
        //			text = text.ToLower();
        //			text2 = text2.ToLower();
        //			if (text.Contains("intel"))
        //			{
        //				this.m_bIsIntel = true;
        //			}
        //			if (text2.Contains("intel"))
        //			{
        //				this.m_bIsIntel = true;
        //			}
        //			if (text.Contains("gdi"))
        //			{
        //				this.m_bIsGDI = true;
        //			}
        //			if (text2.Contains("gdi"))
        //			{
        //				this.m_bIsGDI = true;
        //			}
        //			int systemMemorySize = SystemInfo.systemMemorySize;
        //			if (base.GetComponent<LoadFont>() == null)
        //			{
        //				base.gameObject.AddComponent<LoadFont>();
        //			}
        //			if (base.GetComponent<AudioSource>() == null)
        //			{
        //				base.gameObject.AddComponent<AudioSource>();
        //			}
        //			PalMain.backgroundAudio = base.GetComponent<BackgroundAudio>();
        //			if (PalMain.backgroundAudio == null)
        //			{
        //				PalMain.backgroundAudio = base.gameObject.AddComponent<BackgroundAudio>();
        //			}
        //		}

        //		// Token: 0x060036C4 RID: 14020 RVA: 0x0018B438 File Offset: 0x00189638
        //		public static void RefreshAllLandMarks()
        //		{
        //			PalMain.landMarks.Clear();
        //			Landmark[] collection = (Landmark[])UnityEngine.Object.FindObjectsOfType(typeof(Landmark));
        //			PalMain.landMarks.AddRange(collection);
        //		}

        //		// Token: 0x060036C5 RID: 14021 RVA: 0x0018B470 File Offset: 0x00189670
        //		private void UpdateMinFPS()
        //		{
        //			if (PalMain.MinFPS != this.minFPS)
        //			{
        //				PalMain.MinFPS = this.minFPS;
        //				PalMain.MinDeltaTime = 1f / this.minFPS;
        //			}
        //		}

        //		// Token: 0x060036C6 RID: 14022 RVA: 0x0018B4AC File Offset: 0x001896AC
        //		private void Update()
        //		{
        //			this.UpdateMinFPS();
        //			if (this.onInputHandles != null)
        //			{
        //				this.onInputHandles();
        //			}
        //			if (this.updateHandles != null)
        //			{
        //				this.updateHandles(Time.time, Time.deltaTime);
        //			}
        //			this.m_QTEManager.Update();
        //			if (ScenesManager.IsChanging || ShowLoading.Instance != null)
        //			{
        //				return;
        //			}
        //			this.UpdateOpCull();
        //			PalMain.UpdateCheckUnload();
        //			this.UpdateSpecialIssueForNonFocus();
        //			if (WaitForSonyCheck.Instance == null)
        //			{
        //			}
        //			FileLoader.Instance.Update();
        //		}

        //		// Token: 0x060036C7 RID: 14023 RVA: 0x0018B548 File Offset: 0x00189748
        //		private void FixedUpdate()
        //		{
        //			BuffDebuffManager.GetInstance().FixedUpdate(Time.fixedTime);
        //			if (DateTime.Now > this.mLastConfigSave)
        //			{
        //				this.mLastConfigSave = DateTime.Now.AddSeconds(1.0);
        //				bool flag = false;
        //				OptionConfig optionConfig = OptionConfig.GetInstance();
        //				if (optionConfig.IsDirty)
        //				{
        //					optionConfig.Save();
        //					flag = true;
        //				}
        //				if (flag)
        //				{
        //					SaveManager.SaveGlobalData();
        //				}
        //			}
        //		}

        //		// Token: 0x060036C8 RID: 14024 RVA: 0x0018B5BC File Offset: 0x001897BC
        //		private void OnGUI()
        //		{
        //			if (this.onGUIHandles != null)
        //			{
        //				this.onGUIHandles();
        //			}
        //		}

        //		// Token: 0x060036C9 RID: 14025 RVA: 0x0018B5D4 File Offset: 0x001897D4
        //		private void ReplaceMeshColliderFor7()
        //		{
        //			GameObject gameObject = GameObject.Find("/jianzhu");
        //			if (gameObject != null)
        //			{
        //				foreach (MeshCollider meshCollider in gameObject.GetComponentsInChildren<MeshCollider>())
        //				{
        //					if (!(meshCollider.name == "jz_ymh_shitou12") && !(meshCollider.name == "jz_fyy_st01") && !(meshCollider.name == "jz_fyy_st02") && !(meshCollider.name == "jz_fyy_st03") && !(meshCollider.name == "jz_fyy_st04") && !(meshCollider.name == "jz_fyy_shitou07") && !(meshCollider.name == "jz_fyy_shitou05") && !(meshCollider.name == "Object566") && !(meshCollider.name == "Object567") && !(meshCollider.name == "Object572") && !(meshCollider.name == "Object574") && !(meshCollider.name == "Object575") && !(meshCollider.name == "Object576"))
        //					{
        //						meshCollider.enabled = false;
        //					}
        //				}
        //			}
        //			FileLoader.LoadObjectFromFile<UnityEngine.Object>("Collider/pengzhuang7".ToAssetBundlePath(), true, true);
        //		}

        //		// Token: 0x060036CA RID: 14026 RVA: 0x0018B748 File Offset: 0x00189948
        //		private void ReplaceMapElementFor25()
        //		{
        //			GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>("LevelParticles/EXPH_huanjing_PUBU_B".ToAssetBundlePath(), true, true);
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("Error : 没有找到 LevelParticles/EXPH_huanjing_PUBU_B");
        //				return;
        //			}
        //			string str = "/texiao/PUBU";
        //			for (int i = 1; i < 5; i++)
        //			{
        //				string name = str + i.ToString();
        //				GameObject gameObject2 = GameObject.Find(name);
        //				if (gameObject2 != null)
        //				{
        //					Transform[] componentsInChildren = gameObject2.GetComponentsInChildren<Transform>();
        //					foreach (Transform transform in componentsInChildren)
        //					{
        //						if (transform.name == "EXPH_huanjing_PUBU_B")
        //						{
        //							transform.gameObject.SetActive(false);
        //							GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
        //							Transform transform2 = gameObject3.transform;
        //							transform2.parent = transform.parent;
        //							transform2.position = transform.position;
        //							transform2.localScale = transform.localScale;
        //							transform2.localRotation = transform.localRotation;
        //						}
        //					}
        //				}
        //			}
        //			UnityEngine.Object.Destroy(gameObject);
        //		}

        //		// Token: 0x060036CB RID: 14027 RVA: 0x0018B858 File Offset: 0x00189A58
        //		public static void SetForOpt(bool bActive)
        //		{
        //			PalMain.SetEnableWaterReflect("/shui", !bActive);
        //			PalMain.SetEnableMeshCollide("/shitou", !bActive);
        //		}

        //		// Token: 0x060036CC RID: 14028 RVA: 0x0018B878 File Offset: 0x00189A78
        //		public static void SetEnableWaterReflect(string path, bool bEnable)
        //		{
        //			GameObject gameObject = GameObject.Find(path);
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("Error : SetEnableWaterReflect 没有找到 " + path);
        //				return;
        //			}
        //			foreach (PalMirrorReflection palMirrorReflection in gameObject.GetComponentsInChildren<PalMirrorReflection>())
        //			{
        //				palMirrorReflection.enabled = bEnable;
        //			}
        //		}

        //		// Token: 0x060036CD RID: 14029 RVA: 0x0018B8D0 File Offset: 0x00189AD0
        //		public static void SetEnableMeshCollide(string path, bool bEnable)
        //		{
        //			GameObject gameObject = GameObject.Find(path);
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("Error : SetEnableMeshCollide 没有找到 " + path);
        //				return;
        //			}
        //			foreach (MeshCollider meshCollider in gameObject.GetComponentsInChildren<MeshCollider>())
        //			{
        //				meshCollider.enabled = bEnable;
        //			}
        //		}

        //		// Token: 0x060036CE RID: 14030 RVA: 0x0018B928 File Offset: 0x00189B28
        //		public void SpecialProcessForLevel(int level)
        //		{
        //			Terrain activeTerrain = Terrain.activeTerrain;
        //			if (level == 11)
        //			{
        //				FlagManager.SetFlag(8, 0, false);
        //			}
        //			switch (level)
        //			{
        //			case 1:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 100f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 119f;
        //					activeTerrain.treeCrossFadeLength = 12f;
        //				}
        //				break;
        //			case 3:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 33f;
        //					activeTerrain.basemapDistance = 130f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 95f;
        //					activeTerrain.treeCrossFadeLength = 76f;
        //				}
        //				break;
        //			case 4:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 40f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 31f;
        //				}
        //				break;
        //			case 5:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 63f;
        //					activeTerrain.basemapDistance = 117f;
        //					activeTerrain.treeBillboardDistance = 103f;
        //					activeTerrain.treeCrossFadeLength = 35f;
        //				}
        //				break;
        //			case 6:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 44f;
        //					activeTerrain.basemapDistance = 128f;
        //					activeTerrain.castShadows = false;
        //				}
        //				if (PalShroudObjectManager.Instance != null)
        //				{
        //					Vector3 windDir = new Vector3(0.2f, 0f, -0.64f);
        //					PalShroudObjectManager.Instance.WindDir = windDir;
        //				}
        //				break;
        //			case 7:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 60f;
        //					activeTerrain.basemapDistance = 160f;
        //					activeTerrain.castShadows = false;
        //				}
        //				break;
        //			case 8:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 56f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeDistance = 291f;
        //					activeTerrain.treeBillboardDistance = 150f;
        //					activeTerrain.treeCrossFadeLength = 45f;
        //				}
        //				break;
        //			case 10:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 18f;
        //					activeTerrain.basemapDistance = 97f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 90f;
        //					activeTerrain.treeCrossFadeLength = 50f;
        //				}
        //				break;
        //			case 12:
        //			{
        //				GameObject gameObject = GameObject.Find("/texiao/EXPH_P_JQ44_HUNYU02");
        //				if (gameObject != null)
        //				{
        //					UtilFun.SetActive(gameObject, false);
        //				}
        //				break;
        //			}
        //			case 13:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 100f;
        //					activeTerrain.basemapDistance = 38f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 67f;
        //					activeTerrain.treeCrossFadeLength = 28f;
        //				}
        //				break;
        //			case 14:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 44f;
        //					activeTerrain.basemapDistance = 114f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 60f;
        //					activeTerrain.treeCrossFadeLength = 25f;
        //				}
        //				break;
        //			case 15:
        //			{
        //				RenderSettings.skybox = null;
        //				Camera mainCamera = UtilFun.GetMainCamera();
        //				if (mainCamera != null)
        //				{
        //					mainCamera.backgroundColor = Color.black;
        //				}
        //				break;
        //			}
        //			case 17:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 16f;
        //					activeTerrain.basemapDistance = 159f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 155f;
        //					activeTerrain.treeCrossFadeLength = 32f;
        //				}
        //				break;
        //			case 20:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 28f;
        //					activeTerrain.basemapDistance = 129f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 116f;
        //					activeTerrain.treeCrossFadeLength = 44f;
        //				}
        //				break;
        //			case 21:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 626f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 341f;
        //					activeTerrain.treeCrossFadeLength = 44f;
        //				}
        //				break;
        //			case 22:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 37f;
        //					activeTerrain.basemapDistance = 113f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 128f;
        //					activeTerrain.treeCrossFadeLength = 23f;
        //				}
        //				break;
        //			case 23:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 93f;
        //					activeTerrain.treeCrossFadeLength = 22f;
        //				}
        //				break;
        //			case 25:
        //			{
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 263f;
        //					activeTerrain.castShadows = false;
        //				}
        //				this.ReplaceMapElementFor25();
        //				GameObject gameObject2 = GameObject.Find("/Move_fuban");
        //				if (gameObject2 != null)
        //				{
        //					SetActiveByGameState.AddSetActiveByGameState(gameObject2, GameState.Battle, false);
        //				}
        //				break;
        //			}
        //			case 28:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 50f;
        //					activeTerrain.basemapDistance = 213f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeDistance = 366f;
        //					activeTerrain.treeBillboardDistance = 200f;
        //					activeTerrain.treeCrossFadeLength = 52.8f;
        //				}
        //				break;
        //			case 31:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.heightmapPixelError = 100f;
        //					activeTerrain.basemapDistance = 81f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 320f;
        //					activeTerrain.treeCrossFadeLength = 32f;
        //				}
        //				break;
        //			case 33:
        //				if (activeTerrain != null)
        //				{
        //					activeTerrain.basemapDistance = 86f;
        //					activeTerrain.castShadows = false;
        //					activeTerrain.treeBillboardDistance = 119f;
        //					activeTerrain.treeCrossFadeLength = 12f;
        //				}
        //				break;
        //			}
        //		}

        public static void OnLevelLoaded()
        {
            //PlayerCtrlManager.OnLevelLoaded(1);
            PalMain.OnReadySpawn();
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLevelWasLoaded(level);
            //OptionConfig.GetInstance().Use_OnLevelLoaded();
            //OptionConfig.GetInstance().Use_CharacterEmission();
            //MapWatch.Instance.SetMap();
        }

        //		// Token: 0x060036D0 RID: 14032 RVA: 0x0018BF80 File Offset: 0x0018A180
        //		public static IEnumerator Quit(float time)
        //		{
        //			Console.Log("Game will quit in " + time.ToString() + " seconds");
        //			yield return new WaitForSeconds(time);
        //			Application.Quit();
        //			yield break;
        //		}

        //		// Token: 0x060036D1 RID: 14033 RVA: 0x0018BFA4 File Offset: 0x0018A1A4
        //		public static void LoadLevel(int LevelIndex)
        //		{
        //			SceneManager.LoadSceneAsync(LevelIndex);
        //		}

        //		// Token: 0x060036D2 RID: 14034 RVA: 0x0018BFB0 File Offset: 0x0018A1B0
        //		public static void LoadLevel(string levelName)
        //		{
        //			SceneManager.LoadSceneAsync(levelName);
        //		}

        //		// Token: 0x060036D3 RID: 14035 RVA: 0x0018BFBC File Offset: 0x0018A1BC
        //		public static void ToSuitablePlace(GameObject o)
        //		{
        //			if (UtilFun.GetMainCamera() == null)
        //			{
        //				return;
        //			}
        //			if (o == null && UtilFun.GetMainCamera() == null)
        //			{
        //				return;
        //			}
        //			RaycastHit raycastHit = default(RaycastHit);
        //			Ray ray = UtilFun.GetMainCamera().ScreenPointToRay(new Vector2((float)UtilFun.GetMainCamera().pixelWidth * 0.5f, (float)UtilFun.GetMainCamera().pixelHeight * 0.5f));
        //			if (Physics.Raycast(ray, out raycastHit))
        //			{
        //				UtilFun.SetPosition(o.transform, raycastHit.point);
        //			}
        //			else
        //			{
        //				Plane plane = new Plane(Vector3.up, Vector3.zero);
        //				float distance;
        //				if (plane.Raycast(ray, out distance))
        //				{
        //					o.transform.position = ray.GetPoint(distance);
        //				}
        //				else
        //				{
        //					UtilFun.SetPosition(o.transform, ray.GetPoint(0f));
        //				}
        //			}
        //		}

        //		// Token: 0x060036D4 RID: 14036 RVA: 0x0018C0AC File Offset: 0x0018A2AC
        //		public static GameObject ABInstantiateToUscript(string path)
        //		{
        //			return FileLoader.LoadObjectFromFile<GameObject>(path.ToAssetBundlePath(), true, true);
        //		}

        //		// Token: 0x060036D5 RID: 14037 RVA: 0x0018C0C8 File Offset: 0x0018A2C8
        //		public static void SetBianLuoHuanState()
        //		{
        //			UIManager.Instance.EndState_Normal();
        //			PlayerCtrlManager.bCanTab = false;
        //			PlayerCtrlManager.bCtrlOther = true;
        //			TimeManager.Initialize().selfUpdate -= TimeManager.Initialize().AutoSave;
        //		}

        //		// Token: 0x060036D6 RID: 14038 RVA: 0x0018C108 File Offset: 0x0018A308
        //		public static void EndNPCWeatherInteract(GameObject npc)
        //		{
        //			NPCWeatherInteract component = npc.GetComponent<NPCWeatherInteract>();
        //			if (component != null)
        //			{
        //				component.EndActive();
        //			}
        //		}

        //		// Token: 0x060036D7 RID: 14039 RVA: 0x0018C130 File Offset: 0x0018A330
        //		public static void SetFlyMapBtnEnabled(bool enabled)
        //		{
        //			UtilFun.SetFlyMapBtnEnabled(enabled);
        //		}

        //		// Token: 0x060036D8 RID: 14040 RVA: 0x0018C138 File Offset: 0x0018A338
        //		public static void TeamRecoverHPAndMP()
        //		{
        //			UtilFun.TeamRecoverHPAndMP();
        //		}

        //		// Token: 0x060036D9 RID: 14041 RVA: 0x0018C140 File Offset: 0x0018A340
        //		public static void ActiveBranch()
        //		{
        //			FlagManager.SetFlag(MissionManager.BranchLineToggleFlag, 1, true);
        //		}

        //		// Token: 0x060036DA RID: 14042 RVA: 0x0018C150 File Offset: 0x0018A350
        //		public static void InActiveBranch()
        //		{
        //			FlagManager.SetFlag(MissionManager.BranchLineToggleFlag, 0, true);
        //		}

        //		// Token: 0x060036DB RID: 14043 RVA: 0x0018C160 File Offset: 0x0018A360
        //		public static bool IsBranch()
        //		{
        //			int flag = FlagManager.GetFlag(MissionManager.BranchLineToggleFlag);
        //			return flag > 0;
        //		}

        public static void SetFlag(int idx, int value)
        {
            FlagManager.SetFlag(idx, value, true);
        }

        //		// Token: 0x060036DD RID: 14045 RVA: 0x0018C188 File Offset: 0x0018A388
        //		public static int GetFlag(int idx)
        //		{
        //			return FlagManager.GetFlag(idx);
        //		}

        //		// Token: 0x060036DE RID: 14046 RVA: 0x0018C190 File Offset: 0x0018A390
        //		public static void ChangeFlag(int idx, int value)
        //		{
        //			int flag = FlagManager.GetFlag(idx);
        //			FlagManager.SetFlag(idx, flag + value, true);
        //		}

        //		// Token: 0x060036DF RID: 14047 RVA: 0x0018C1B0 File Offset: 0x0018A3B0
        //		public static void ChangeMoney(int difmoney)
        //		{
        //			int num = PalMain.GetMoney();
        //			num += difmoney;
        //			PalMain.SetFlag(2, num);
        //		}

        //		// Token: 0x060036E0 RID: 14048 RVA: 0x0018C1D0 File Offset: 0x0018A3D0
        //		public static int GetMoney()
        //		{
        //			return PalMain.GetFlag(2);
        //		}

        /// <summary>
        /// 设置金钱  金钱是2
        /// </summary>
        /// <param name="money"></param>
        public static void SetMoney(int money)
        {
            PalMain.SetFlag(2, money);
        }

        //		public static void SetCameraDistanceForPot()
        //		{
        //			Camera mainCamera = UtilFun.GetMainCamera();
        //			mainCamera.layerCullSpherical = true;
        //			float[] array = new float[32];
        //			int num = LayerMask.NameToLayer("DistanceCull");
        //			if (num < 0 || num > array.Length - 1)
        //			{
        //				UnityEngine.Debug.LogError("请更新工程的ProjectSettings文件夹");
        //				return;
        //			}
        //			array[num] = PalMain.CameraOptDistance;
        //			mainCamera.layerCullDistances = array;
        //		}

        //		// Token: 0x060036E3 RID: 14051 RVA: 0x0018C240 File Offset: 0x0018A440
        //		private static void AddGlowCamera()
        //		{
        //		}

        //		// Token: 0x060036E4 RID: 14052 RVA: 0x0018C244 File Offset: 0x0018A444
        //		public static void KeepCameraOnly()
        //		{
        //			if (PalMain.MainCamera == null && UtilFun.GetMainCamera() != null)
        //			{
        //				PalMain.MainCamera = UtilFun.GetMainCamera().gameObject;
        //			}
        //			if (PalMain.MainCamera == null)
        //			{
        //				UnityEngine.Debug.Log("PalMain.KeepCameraOnly: MainCamera == null");
        //				return;
        //			}
        //			if (!PalMain.MainCamera.activeSelf)
        //			{
        //				UtilFun.SetActive(PalMain.MainCamera, true);
        //			}
        //			GameObject[] array = GameObject.FindGameObjectsWithTag("MainCamera");
        //			if (array.Length > 1)
        //			{
        //				foreach (GameObject gameObject in array)
        //				{
        //					if (PalMain.MainCamera != gameObject)
        //					{
        //						gameObject.SetActive(false);
        //						UnityEngine.Object.Destroy(gameObject);
        //					}
        //				}
        //			}
        //			DontDestroyOnLevelChange[] components = UtilFun.GetMainCamera().GetComponents<DontDestroyOnLevelChange>();
        //			if (components.Length > 0)
        //			{
        //				foreach (DontDestroyOnLevelChange obj in components)
        //				{
        //					UnityEngine.Object.Destroy(obj);
        //				}
        //			}
        //		}

        //		// Token: 0x060036E5 RID: 14053 RVA: 0x0018C344 File Offset: 0x0018A544
        //		public static void SetMainCamera(GameObject go)
        //		{
        //			go = go.GetModelObj(false);
        //			AudioReverbZoneTrigger.Owner = go;
        //			PalMain.KeepCameraOnly();
        //			PalMain.SetCameraDistanceForPot();
        //			PalMain.AddGlowCamera();
        //			if (UtilFun.GetMainCamera())
        //			{
        //				SmoothFollow2 orAddComponent = UtilFun.GetMainCamera().gameObject.GetOrAddComponent<SmoothFollow2>();
        //				orAddComponent.Init(go);
        //			}
        //			UtilFun.GetMainCamera().cullingMask = (-67108865 & UtilFun.GetMainCamera().cullingMask);
        //		}

        //		// Token: 0x060036E6 RID: 14054 RVA: 0x0018C3B0 File Offset: 0x0018A5B0
        //		private void OnDrawGizmos()
        //		{
        //			if (PalBattleManager.Instance() != null)
        //			{
        //				PalBattleManager.Instance().DrawGizmos();
        //			}
        //		}

        //		// Token: 0x060036E7 RID: 14055 RVA: 0x0018C3C8 File Offset: 0x0018A5C8
        //		public static void ClearManagerData()
        //		{
        //			GameObject gameObject = GameObject.Find("/FootMarks");
        //			if (gameObject != null)
        //			{
        //				UnityEngine.Object.Destroy(gameObject);
        //			}
        //			SetActiveByFlagManager.Clear();
        //			AnimCtrlScript.ClearAnimClipsDic();
        //			PalMain.mapinfo = null;
        //			DistanceCullManager.Instance.ClearMats();
        //			CharactersManager.Clear();
        //			DynamicObjsDataManager.Instance.ClearLayers();
        //			Footmark.Clear();
        //		}


        public static void LoadScene(int sceneId, bool PlayDefaultAudio = true, bool SaveDynamicObjs = true)
        {
            GameEntry.UI.CloseAllUIForm();//关闭所有UI

            Time.timeScale = 1f;

            //PalBattleManager.Instance().OnSceneChangeClear();
            //if (ScenesManager.CurLoadedLevel == 11 && LevelIndex != 11)
            //{
            //    FlagManager.SetFlag(8, 1, false);
            //}
            //if (Cutscene.current != null && (Cutscene.current.isPlaying || Cutscene.current.isPause))
            //{
            //    Cutscene.current.End(false);
            //}
            //Transform transform = UtilFun.GetMainCamera().transform;
            //if (transform != null)
            //{
            //    transform.parent = null;
            //}
            //UtilFun.GetMainCamera().cullingMask = 0;
            //if (ScenesManager.IsChanging)
            //{
            //    return;
            //}
            //PlayersManager.RestoreLayer(true);
            //PlayersManager.ChangeHairShader(false);
            //if (SaveDynamicObjs)
            //{
            //    DynamicObjsDataManager.Instance.SaveCurObjsDataToMemory();
            //}
            //PalMain.ClearManagerData();
            //ScenesManager.IsChanging = true;
            //if (PalMain.backgroundAudio != null)
            //{
            //    PalMain.backgroundAudio.PlayDefaultAudio = PlayDefaultAudio;
            //}
            //else
            //{
            //    UnityEngine.Debug.LogError("PalMain.backgroundAudio==null");
            //}
            //if (SkillSEPreloader.s_preloadEnable)
            //{
            //    SkillSEPreloader.Instance.unLoadAllSkillSE();
            //}
            //ScenesManager.Instance.ChangeMap(DestName, LevelIndex, new Action<int>(PalMain.Instance.OnLevelLoaded));
            GameEntry.Scene.LoadScene(sceneId);
        }

        /// <summary>
        /// 读取出生点
        /// </summary>
        public static void OnReadySpawn()
        {
            //if (PlayersManager.Player == null)
            //{
            //    PlayersManager.SpawnPlayer(null, null, false);
            //}
            //PlayersManager.SetPlayerPosByDestObj(ScenesManager.Instance.NextDestObjName);
            //if (PlayersManager.Player != null)
            //{
            //    //PalMain.SetMainCamera(PlayersManager.Player);
            //}
        }

        public static void OnLoadOver()
        {
            UnityEngine.Debug.Log("加载完毕");
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //PalMain.RefreshAllLandMarks();
            //DynamicObjsDataManager.Instance.LoadCurObjsDataFromMemory();
            //GameStateManager.CurGameState = GameState.Normal;
            //PalMain.Instance.SpecialProcessForLevel(ScenesManager.CurLoadedLevel);
            //PalMain.ShowMemory();
            //if (PalMain.LoadOverEvent != null)
            //{
            //    PalMain.LoadOverEvent();
            //}
        }

        //		// Token: 0x060036EB RID: 14059 RVA: 0x0018C63C File Offset: 0x0018A83C
        //		public static void ShowMemory()
        //		{
        //			string value = "PalMain.ShowMemory: Current scene = " + SceneManager.GetActiveScene().buildIndex.ToString();
        //			Console.WriteLine(value);
        //		}

        //		// Token: 0x060036ED RID: 14061 RVA: 0x0018C6BC File Offset: 0x0018A8BC
        //		public static GameObject CreatePermanentObject<T>(string path, bool bRelative)
        //		{
        //			Type typeFromHandle = typeof(T);
        //			UnityEngine.Object @object = UnityEngine.Object.FindObjectOfType(typeFromHandle);
        //			GameObject gameObject;
        //			if (@object == null)
        //			{
        //				UnityEngine.Object object2 = Resources.Load(path);
        //				if (object2 == null)
        //				{
        //					UnityEngine.Debug.LogError("没有找到" + path + "，建议更新所属文件夹");
        //					return null;
        //				}
        //				gameObject = (UnityEngine.Object.Instantiate(object2) as GameObject);
        //			}
        //			else
        //			{
        //				Component component = @object as Component;
        //				if (component == null)
        //				{
        //					UnityEngine.Debug.LogError(typeFromHandle.Name + "不是 Component");
        //					return null;
        //				}
        //				gameObject = component.gameObject;
        //			}
        //			if (gameObject != null && !gameObject.GetComponent<DontDestroyOnLevelChange>())
        //			{
        //				gameObject.AddComponent<DontDestroyOnLevelChange>();
        //			}
        //			return gameObject;
        //		}

        //		// Token: 0x17000435 RID: 1077
        //		// (get) Token: 0x060036EE RID: 14062 RVA: 0x0018C77C File Offset: 0x0018A97C
        //		public static Transform TempGameLayer
        //		{
        //			get
        //			{
        //				if (PalMain.tempGameLayer == null)
        //				{
        //					GameObject gameObject = GameObject.Find(SaveManager.TempGameLayerName);
        //					if (gameObject != null)
        //					{
        //						PalMain.tempGameLayer = gameObject.transform;
        //					}
        //					else
        //					{
        //						gameObject = new GameObject(SaveManager.TempGameLayerName);
        //						UtilFun.SetPosition(gameObject.transform, Vector3.zero);
        //						gameObject.transform.rotation = Quaternion.identity;
        //						PalMain.tempGameLayer = gameObject.transform;
        //					}
        //				}
        //				return PalMain.tempGameLayer;
        //			}
        //		}

        //		// Token: 0x060036EF RID: 14063 RVA: 0x0018C7FC File Offset: 0x0018A9FC
        //		public static void SetCtrlModel(GameObject go)
        //		{
        //			PlayerCtrlManager.SetCtrlModel(go);
        //		}

        //		// Token: 0x060036F0 RID: 14064 RVA: 0x0018C804 File Offset: 0x0018AA04
        //		public static void RestoreModel()
        //		{
        //			PlayerCtrlManager.bCtrlOther = false;
        //			PlayerCtrlManager.RestoreModel();
        //		}

        //		// Token: 0x060036F1 RID: 14065 RVA: 0x0018C814 File Offset: 0x0018AA14
        //		public static void SetYanZhaoActive(int ID, bool bActive)
        //		{
        //			GameObject gameObject = PlayersManager.FindMainChar(ID, true);
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("SetYanZhaoActive 没有找到 " + ID.ToString());
        //				return;
        //			}
        //			if (gameObject == null)
        //			{
        //				UnityEngine.Debug.LogError("SetYanZhaoActive 没有找到 " + ID.ToString() + " 的模型");
        //				return;
        //			}
        //			SetActiveChildByFlag component = gameObject.GetComponent<SetActiveChildByFlag>();
        //			if (component != null)
        //			{
        //				component.SetActive(bActive);
        //			}
        //			else
        //			{
        //				UnityEngine.Debug.LogError("Error :" + gameObject.name + "没有找到 SetActiveChildByFlag");
        //			}
        //		}

        //		// Token: 0x060036F2 RID: 14066 RVA: 0x0018C8B0 File Offset: 0x0018AAB0
        //		public static void SetActiveWeapon(GameObject go, bool bActive, bool bAssort)
        //		{
        //			PalNPC component = go.GetComponent<PalNPC>();
        //			if (component == null)
        //			{
        //				UnityEngine.Debug.LogError(go.name + " 没有PalNPC");
        //				return;
        //			}
        //			component.SetActiveWeaponAndAssort(bActive, bAssort, true);
        //		}

        //		// Token: 0x060036F3 RID: 14067 RVA: 0x0018C8F0 File Offset: 0x0018AAF0
        //		public static GameObject GetChild(GameObject go, string path)
        //		{
        //			if (go == null)
        //			{
        //				UnityEngine.Debug.LogError("GetChild 里面go为 null");
        //				return null;
        //			}
        //			Transform transform = go.transform.Find(path);
        //			return (!(transform != null)) ? null : transform.gameObject;
        //		}

        //		// Token: 0x060036F4 RID: 14068 RVA: 0x0018C93C File Offset: 0x0018AB3C
        //		public static void ToggleCtrl(bool bCon)
        //		{
        //			PlayerCtrlManager.bControl = bCon;
        //		}

        //		// Token: 0x060036F5 RID: 14069 RVA: 0x0018C944 File Offset: 0x0018AB44
        //		public static void BeginMoveToMap()
        //		{
        //			if (!BigMap.Instance.OnMap)
        //			{
        //				BigMap.Instance.BeginMoveToMap(true);
        //			}
        //		}

        //		// Token: 0x060036F6 RID: 14070 RVA: 0x0018C960 File Offset: 0x0018AB60
        //		public static void BeginMoveToGround()
        //		{
        //			if (BigMap.Instance.OnMap)
        //			{
        //				BigMap.Instance.BeginMoveToGround();
        //			}
        //		}

        //		// Token: 0x060036F7 RID: 14071 RVA: 0x0018C97C File Offset: 0x0018AB7C
        //		public static void BackToStart()
        //		{
        //			PalMain.ChangeMap(null, 0, true, true);
        //		}

        //		// Token: 0x060036F8 RID: 14072 RVA: 0x0018C988 File Offset: 0x0018AB88
        //		public int CreateNewTempObjects(object newO)
        //		{
        //			while (this.mTempPosition < this.mTempObjects.Count && this.mTempObjects[this.mTempPosition] != null)
        //			{
        //				this.mTempPosition++;
        //			}
        //			if (this.mTempPosition >= this.mTempObjects.Count)
        //			{
        //				this.mTempObjects.Add(newO);
        //				this.mTempPosition = this.mTempObjects.Count;
        //				return this.mTempPosition - 1;
        //			}
        //			this.mTempObjects[this.mTempPosition] = newO;
        //			return this.mTempPosition++;
        //		}

        //		// Token: 0x060036F9 RID: 14073 RVA: 0x0018CA38 File Offset: 0x0018AC38
        //		public object GetTempObject(int pos)
        //		{
        //			return this.mTempObjects[pos];
        //		}

        //		// Token: 0x060036FA RID: 14074 RVA: 0x0018CA48 File Offset: 0x0018AC48
        //		public void RemoveTempObject(int pos)
        //		{
        //			if (pos < 0 || pos >= this.mTempObjects.Count)
        //			{
        //				return;
        //			}
        //			if (this.mTempObjects[pos] == null && pos < this.mTempPosition)
        //			{
        //				this.mTempPosition = pos;
        //			}
        //			this.mTempObjects[pos] = null;
        //		}

        //		// Token: 0x060036FB RID: 14075 RVA: 0x0018CAA0 File Offset: 0x0018ACA0
        //		public static void CreateCircleFile()
        //		{
        //		}

        //		// Token: 0x060036FC RID: 14076 RVA: 0x0018CAA4 File Offset: 0x0018ACA4
        //		public static void SaveCircleFile()
        //		{
        //			SaveManager.Save("100");
        //			SaveManager.GlobalData.mCircle = true;
        //			SaveManager.SaveGlobalData();
        //		}

        //		// Token: 0x060036FD RID: 14077 RVA: 0x0018CAC4 File Offset: 0x0018ACC4
        //		public static void PutOffSlot(int ID, EquipSlotEnum slot)
        //		{
        //			GameObject gameObject = PlayersManager.FindMainChar(ID, true);
        //			PalNPC component = gameObject.GetComponent<PalNPC>();
        //			component.PutOffEquip(slot);
        //		}

        //		// Token: 0x060036FE RID: 14078 RVA: 0x0018CAE8 File Offset: 0x0018ACE8
        //		public static void ActiveSSAO(bool bActiveSSAO)
        //		{
        //			if (UtilFun.GetMainCamera() != null)
        //			{
        //				ScreenSpaceAmbientOcclusion component = UtilFun.GetMainCamera().GetComponent<ScreenSpaceAmbientOcclusion>();
        //				if (component != null)
        //				{
        //					component.enabled = bActiveSSAO;
        //				}
        //			}
        //		}

        //		// Token: 0x060036FF RID: 14079 RVA: 0x0018CB24 File Offset: 0x0018AD24
        //		public static void SetDoReturnButtonEnabled(bool v)
        //		{
        //			UIConfig.DoReturnButtonEnabled = v;
        //		}

        //		// Token: 0x06003700 RID: 14080 RVA: 0x0018CB2C File Offset: 0x0018AD2C
        //		public static void SetVisible(GameObject go, bool bVisible)
        //		{
        //			if (go == null)
        //			{
        //				UnityEngine.Debug.LogError("Error : SetVisible go == null");
        //				return;
        //			}
        //			go.SetVisible(bVisible);
        //		}

        //		// Token: 0x06003701 RID: 14081 RVA: 0x0018CB4C File Offset: 0x0018AD4C
        //		public static void ChangeHairShader(bool bUseAlpha, string[] paths)
        //		{
        //			PlayersManager.ChangeHairShader(bUseAlpha);
        //			UtilFun.ChangeHairShader(bUseAlpha, paths);
        //		}

        //		// Token: 0x06003702 RID: 14082 RVA: 0x0018CB5C File Offset: 0x0018AD5C
        //		public void SaveDistCull()
        //		{
        //			this.m_lastGameState = GameState.None;
        //			Camera mainCamera = UtilFun.GetMainCamera();
        //			Terrain activeTerrain = Terrain.activeTerrain;
        //			this.m_FarClipPlane = mainCamera.farClipPlane;
        //			this.m_bFog = RenderSettings.fog;
        //			this.m_FogStartDistance = RenderSettings.fogStartDistance;
        //			this.m_FogEndDistance = RenderSettings.fogEndDistance;
        //			this.m_FogDensity = RenderSettings.fogDensity;
        //			if (activeTerrain != null)
        //			{
        //				this.m_TreeDistance = activeTerrain.treeDistance;
        //				this.m_DetailObjectDistance = activeTerrain.detailObjectDistance;
        //				this.m_HeightmapPixelError = activeTerrain.heightmapPixelError;
        //				this.m_BasemapDistance = activeTerrain.basemapDistance;
        //			}
        //			this.CreateSkyCamera();
        //		}

        //		// Token: 0x06003703 RID: 14083 RVA: 0x0018CBF8 File Offset: 0x0018ADF8
        //		public void SetLayer(Transform tr, int layer)
        //		{
        //			tr.gameObject.layer = layer;
        //			for (int i = 0; i < tr.childCount; i++)
        //			{
        //				this.SetLayer(tr.GetChild(i), layer);
        //			}
        //		}

        //		// Token: 0x06003704 RID: 14084 RVA: 0x0018CC38 File Offset: 0x0018AE38
        //		public void SetDistCull(PalMain.DISTANCE_CULL dc, bool bFromInit, bool bNoSet = false)
        //		{
        //			if (!bFromInit)
        //			{
        //				Camera mainCamera = UtilFun.GetMainCamera();
        //				Terrain activeTerrain = Terrain.activeTerrain;
        //				if (dc == PalMain.DISTANCE_CULL.FULL)
        //				{
        //					if (GameStateManager.CurGameState == GameState.uScript)
        //					{
        //						bNoSet = true;
        //					}
        //					else
        //					{
        //						if (this.m_FarClipPlane <= 0f)
        //						{
        //							UnityEngine.Debug.LogWarning("m_FarClipPlane <= 0");
        //							this.m_FarClipPlane = 300f;
        //						}
        //						mainCamera.farClipPlane = this.m_FarClipPlane;
        //						RenderSettings.fog = this.m_bFog;
        //						RenderSettings.fogStartDistance = this.m_FogStartDistance;
        //						RenderSettings.fogDensity = this.m_FogDensity;
        //						RenderSettings.fogEndDistance = this.m_FogEndDistance;
        //						if (activeTerrain != null)
        //						{
        //							activeTerrain.treeDistance = this.m_TreeDistance;
        //							activeTerrain.detailObjectDistance = this.m_DetailObjectDistance;
        //						}
        //						if (this.m_SkyCam != null)
        //						{
        //							SkyCameraSync component = this.m_SkyCam.gameObject.GetComponent<SkyCameraSync>();
        //							if (component != null && component.m_Quad.activeSelf)
        //							{
        //								component.m_Quad.SetActive(false);
        //							}
        //							if (component.m_Sky != null)
        //							{
        //								this.SetLayer(component.m_Sky.transform, 0);
        //							}
        //							this.m_SkyCam.enabled = false;
        //						}
        //					}
        //				}
        //				else
        //				{
        //					if (this.m_SkyCam == null)
        //					{
        //						this.CreateSkyCamera();
        //					}
        //					if (this.m_SkyCam != null)
        //					{
        //						SkyCameraSync component2 = this.m_SkyCam.gameObject.GetComponent<SkyCameraSync>();
        //						if (component2 != null && !component2.m_Quad.activeSelf)
        //						{
        //							component2.m_Quad.SetActive(true);
        //						}
        //						if (component2.m_Sky != null)
        //						{
        //							this.SetLayer(component2.m_Sky.transform, 20);
        //						}
        //						this.m_SkyCam.enabled = true;
        //					}
        //					float num = 70f;
        //					PalMain.SceneOptiDistFogParams sceneOptiDistFogParams;
        //					if (this.m_LevelCullOpParams.TryGetValue(Application.loadedLevel, out sceneOptiDistFogParams))
        //					{
        //						if (dc == PalMain.DISTANCE_CULL.FULL)
        //						{
        //							if (sceneOptiDistFogParams.m_CullDist_Hi > 0f)
        //							{
        //								num = sceneOptiDistFogParams.m_CullDist_Hi;
        //							}
        //							else
        //							{
        //								num = this.m_FarClipPlane;
        //							}
        //						}
        //						else if (dc == PalMain.DISTANCE_CULL.LOW)
        //						{
        //							num = sceneOptiDistFogParams.m_CullDist_Low;
        //						}
        //						else if (dc == PalMain.DISTANCE_CULL.MID)
        //						{
        //							num = sceneOptiDistFogParams.m_CullDist_Mid;
        //						}
        //					}
        //					else if (dc == PalMain.DISTANCE_CULL.LOW)
        //					{
        //						num = 70f;
        //					}
        //					else if (dc == PalMain.DISTANCE_CULL.MID)
        //					{
        //						num = 140f;
        //					}
        //					else if (dc == PalMain.DISTANCE_CULL.FULL)
        //					{
        //						num = 300f;
        //					}
        //					mainCamera.farClipPlane = num;
        //					RenderSettings.fog = true;
        //					RenderSettings.fogStartDistance = num * 0.5f;
        //					RenderSettings.fogDensity = 1f;
        //					RenderSettings.fogMode = FogMode.Linear;
        //					RenderSettings.fogEndDistance = num * 0.8f;
        //					activeTerrain = Terrain.activeTerrain;
        //					if (activeTerrain != null)
        //					{
        //					}
        //				}
        //			}
        //			if (!bNoSet)
        //			{
        //				PalMain.m_DistCull = dc;
        //			}
        //		}

        //		// Token: 0x06003705 RID: 14085 RVA: 0x0018CF04 File Offset: 0x0018B104
        //		public void SavePostCam()
        //		{
        //			this.m_CamPosts.Clear();
        //			Camera mainCamera = UtilFun.GetMainCamera();
        //			Behaviour behaviour;
        //			if (Application.loadedLevel != 11)
        //			{
        //				behaviour = (Behaviour)mainCamera.GetComponent("SunShafts");
        //				if (!(behaviour != null) || behaviour.enabled)
        //				{
        //				}
        //			}
        //			else
        //			{
        //				behaviour = (Behaviour)mainCamera.GetComponent("SunShafts");
        //				if (behaviour != null && behaviour.enabled)
        //				{
        //					behaviour.enabled = false;
        //				}
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("Bloom");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("ScreenSpaceAmbientOcclusion");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("TiltShift");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("GlowEffect");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("Vignetting");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("ContrastEnhance");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("ColorCorrectionCurves");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("GlobalFog");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			behaviour = (Behaviour)mainCamera.GetComponent("GlobalFog");
        //			if (behaviour != null && behaviour.enabled)
        //			{
        //				this.m_CamPosts.Add(behaviour);
        //			}
        //			Glow11 component = mainCamera.GetComponent<Glow11>();
        //			if (component != null && component.enabled)
        //			{
        //				this.m_CamPosts.Add(component);
        //			}
        //		}

        //		// Token: 0x06003706 RID: 14086 RVA: 0x0018D18C File Offset: 0x0018B38C
        //		public void SetPostCam(PalMain.POST_CAM pc, bool bFromInit)
        //		{
        //			if (!bFromInit)
        //			{
        //				if (pc == PalMain.POST_CAM.FULL)
        //				{
        //					for (int i = 0; i < this.m_CamPosts.Count; i++)
        //					{
        //						if (this.m_CamPosts[i] != null)
        //						{
        //							this.m_CamPosts[i].enabled = true;
        //						}
        //					}
        //					Camera mainCamera = UtilFun.GetMainCamera();
        //					Behaviour behaviour = (Behaviour)mainCamera.GetComponent("GlowEffect");
        //					if (behaviour != null)
        //					{
        //						behaviour.enabled = false;
        //					}
        //				}
        //				else if (pc == PalMain.POST_CAM.MID)
        //				{
        //					for (int j = 0; j < this.m_CamPosts.Count; j++)
        //					{
        //						if (this.m_CamPosts[j] != null)
        //						{
        //							this.m_CamPosts[j].enabled = true;
        //						}
        //					}
        //					Camera mainCamera2 = UtilFun.GetMainCamera();
        //					Behaviour behaviour2 = (Behaviour)mainCamera2.GetComponent("ScreenSpaceAmbientOcclusion");
        //					if (behaviour2 != null)
        //					{
        //						behaviour2.enabled = false;
        //					}
        //					behaviour2 = (Behaviour)mainCamera2.GetComponent("TiltShift");
        //					if (behaviour2 != null)
        //					{
        //						behaviour2.enabled = false;
        //					}
        //					behaviour2 = (Behaviour)mainCamera2.GetComponent("GlowEffect");
        //					if (behaviour2 != null)
        //					{
        //						behaviour2.enabled = false;
        //					}
        //				}
        //				else
        //				{
        //					Camera mainCamera3 = UtilFun.GetMainCamera();
        //					Behaviour behaviour3 = (Behaviour)mainCamera3.GetComponent("Bloom");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("ScreenSpaceAmbientOcclusion");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("TiltShift");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("GlowEffect");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("Vignetting");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("HSL");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("ContrastEnhance");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("ColorCorrectionCurves");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("GlobalFog");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					behaviour3 = (Behaviour)mainCamera3.GetComponent("GlobalFog");
        //					if (behaviour3 != null)
        //					{
        //						behaviour3.enabled = false;
        //					}
        //					Glow11 component = mainCamera3.GetComponent<Glow11>();
        //					if (component != null)
        //					{
        //						component.enabled = false;
        //					}
        //				}
        //			}
        //			PalMain.m_PostCam = pc;
        //		}

        //		// Token: 0x06003707 RID: 14087 RVA: 0x0018D4B0 File Offset: 0x0018B6B0
        //		public void SaveLight()
        //		{
        //			this.m_Lights.Clear();
        //			this.m_LightsShadow.Clear();
        //			Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
        //			for (int i = 0; i < array.Length; i++)
        //			{
        //				if (array[i].type != LightType.Directional)
        //				{
        //					if (array[i].enabled)
        //					{
        //						if (this.FindParentIsMainActor(array[i].gameObject.transform))
        //						{
        //							goto IL_92;
        //						}
        //						this.m_Lights.Add(array[i]);
        //					}
        //					array[i].shadows = LightShadows.None;
        //				}
        //				else if (array[i].shadows != LightShadows.None)
        //				{
        //					this.m_LightsShadow.Add(array[i]);
        //				}
        //				IL_92:;
        //			}
        //			this.m_Cams.Clear();
        //			Camera[] array2 = UnityEngine.Object.FindObjectsOfType<Camera>();
        //			for (int j = 0; j < array2.Length; j++)
        //			{
        //				UICamera component = array2[j].GetComponent<UICamera>();
        //				if (array2[j].tag != "MainCamera")
        //				{
        //					array2[j].useOcclusionCulling = false;
        //				}
        //				if (array2[j].tag != "MainCamera" && component == null && array2[j].name != "SkyCam")
        //				{
        //					array2[j].farClipPlane = 1000f;
        //				}
        //				if (array2[j].name == "MidCamera")
        //				{
        //					array2[j].gameObject.SetActive(false);
        //				}
        //			}
        //		}

        //		// Token: 0x06003708 RID: 14088 RVA: 0x0018D618 File Offset: 0x0018B818
        //		public void SetLight(PalMain.LIGHT lt, bool bFromInit)
        //		{
        //			if (!bFromInit)
        //			{
        //				if (lt == PalMain.LIGHT.FULL)
        //				{
        //					for (int i = 0; i < this.m_Lights.Count; i++)
        //					{
        //						if (this.m_Lights[i] != null)
        //						{
        //							this.m_Lights[i].enabled = true;
        //						}
        //					}
        //					for (int j = 0; j < this.m_LightsShadow.Count; j++)
        //					{
        //						if (this.m_LightsShadow[j] != null)
        //						{
        //							this.m_LightsShadow[j].shadows = LightShadows.Soft;
        //						}
        //					}
        //					for (int k = 0; k < this.m_Cams.Count; k++)
        //					{
        //						if (this.m_Cams[k] != null)
        //						{
        //							this.m_Cams[k].gameObject.SetActive(true);
        //						}
        //					}
        //				}
        //				else
        //				{
        //					Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
        //					for (int l = 0; l < array.Length; l++)
        //					{
        //						if (array[l].type != LightType.Directional)
        //						{
        //							if (array[l].enabled)
        //							{
        //								array[l].enabled = false;
        //							}
        //						}
        //						else if (array[l].shadows != LightShadows.None)
        //						{
        //							array[l].shadows = LightShadows.None;
        //						}
        //					}
        //					Camera[] array2 = UnityEngine.Object.FindObjectsOfType<Camera>();
        //					for (int m = 0; m < array2.Length; m++)
        //					{
        //						UICamera component = array2[m].GetComponent<UICamera>();
        //						if (array2[m].tag != "MainCamera")
        //						{
        //							array2[m].useOcclusionCulling = false;
        //						}
        //						if (array2[m].tag != "MainCamera" && component == null && array2[m].name != "SkyCam")
        //						{
        //							array2[m].farClipPlane = 1000f;
        //						}
        //					}
        //				}
        //			}
        //			PalMain.m_Light = lt;
        //		}

        //		// Token: 0x06003709 RID: 14089 RVA: 0x0018D814 File Offset: 0x0018BA14
        //		public void UpdateOpCull()
        //		{
        //			if (PalMain.m_DistCull == PalMain.DISTANCE_CULL.RESTORE)
        //			{
        //				if (GameStateManager.CurGameState != this.m_lastGameState)
        //				{
        //					if (GameStateManager.CurGameState == GameState.Battle && this.m_lastGameState != GameState.Battle)
        //					{
        //						if (PalMain.m_DistCull != PalMain.DISTANCE_CULL.FULL)
        //						{
        //							this.SetDistCull(PalMain.DISTANCE_CULL.MID, false, true);
        //						}
        //					}
        //					else if (GameStateManager.CurGameState != GameState.Cutscene)
        //					{
        //						this.SetDistCull(PalMain.DISTANCE_CULL.MID, false, false);
        //					}
        //				}
        //			}
        //			else if (GameStateManager.CurGameState != this.m_lastGameState)
        //			{
        //				if (GameStateManager.CurGameState == GameState.Cutscene && this.m_lastGameState != GameState.Cutscene && !this.m_bZhuYuGame && !this.m_bGuHanJiang)
        //				{
        //					this.SetDistCull(PalMain.DISTANCE_CULL.FULL, false, true);
        //				}
        //				if (GameStateManager.CurGameState != GameState.Prompt || this.m_lastGameState == GameState.Prompt || this.m_lastGameState == GameState.uScript)
        //				{
        //					if (GameStateManager.CurGameState == GameState.SmallGame && this.m_lastGameState != GameState.SmallGame && !this.m_bZhuYuGame && !this.m_bGuHanJiang)
        //					{
        //						if (SceneManager.GetActiveScene().buildIndex == 25 && Fly_YuJieShu.fly_flag == 1)
        //						{
        //							this.SetDistCull(PalMain.DISTANCE_CULL.FULL, false, true);
        //						}
        //						else
        //						{
        //							this.SetDistCull(PalMain.DISTANCE_CULL.MID, false, true);
        //						}
        //					}
        //					else if (GameStateManager.CurGameState == GameState.Battle && this.m_lastGameState != GameState.Battle)
        //					{
        //						if (PalMain.m_DistCull == PalMain.DISTANCE_CULL.MID)
        //						{
        //							this.SetDistCull(PalMain.DISTANCE_CULL.MID, false, true);
        //						}
        //						else if (PalMain.m_DistCull == PalMain.DISTANCE_CULL.MID)
        //						{
        //							this.SetDistCull(PalMain.DISTANCE_CULL.LOW, false, true);
        //						}
        //					}
        //					else if (GameStateManager.CurGameState != GameState.Cutscene && GameStateManager.CurGameState != GameState.uScript)
        //					{
        //						this.SetDistCull(PalMain.m_DistCull, false, false);
        //					}
        //				}
        //			}
        //			this.m_lastGameState = GameStateManager.CurGameState;
        //		}

        //		// Token: 0x0600370A RID: 14090 RVA: 0x0018D9D4 File Offset: 0x0018BBD4
        //		public void UpdateDualCamera()
        //		{
        //			if (SceneManager.GetActiveScene().buildIndex == 0)
        //			{
        //				return;
        //			}
        //			if (this.m_bDualCam != 0)
        //			{
        //				DualCamera dualCamera = UtilFun.GetMainCamera().gameObject.GetComponent<DualCamera>();
        //				if (dualCamera == null)
        //				{
        //					dualCamera = UtilFun.GetMainCamera().gameObject.AddComponent<DualCamera>();
        //				}
        //				if (this.m_bDualCam == 1)
        //				{
        //					dualCamera.SetDualCamera(true, this.m_DualOffset, 0);
        //				}
        //				else
        //				{
        //					dualCamera.SetDualCamera(true, this.m_DualOffset, 1);
        //				}
        //			}
        //		}

        //		// Token: 0x0600370B RID: 14091 RVA: 0x0018DA58 File Offset: 0x0018BC58
        //		public bool GetDualCam()
        //		{
        //			return this.m_bDualCam != 0;
        //		}

        //		// Token: 0x0600370C RID: 14092 RVA: 0x0018DA68 File Offset: 0x0018BC68
        //		public bool IsIntelGraphicCard()
        //		{
        //			return this.m_bIsIntel;
        //		}

        //		// Token: 0x0600370D RID: 14093 RVA: 0x0018DA70 File Offset: 0x0018BC70
        //		public bool IsGDI()
        //		{
        //			return this.m_bIsGDI;
        //		}

        //		// Token: 0x0600370E RID: 14094 RVA: 0x0018DA78 File Offset: 0x0018BC78
        //		public void CreateSkyCamera()
        //		{
        //			GameObject gameObject = GameObject.Find("/palUniStorm1.6v");
        //			if (gameObject == null)
        //			{
        //				gameObject = GameObject.Find("/PalUniStorm");
        //			}
        //			if (gameObject == null)
        //			{
        //				gameObject = GameObject.Find("/palUniStorm1.6v_ljc");
        //			}
        //			if (gameObject != null)
        //			{
        //				this.SetLayer(gameObject.transform, 20);
        //			}
        //			Camera component = PalMain.MainCamera.GetComponent<Camera>();
        //			if (component != null)
        //			{
        //				int num = -1048577;
        //				component.cullingMask &= num;
        //				Transform transform = component.transform.FindChild("SkyCam");
        //				GameObject gameObject2;
        //				Camera camera;
        //				if (transform == null)
        //				{
        //					gameObject2 = new GameObject("SkyCam");
        //					camera = gameObject2.AddComponent<Camera>();
        //					this.m_SkyCam = camera;
        //				}
        //				else
        //				{
        //					gameObject2 = transform.gameObject;
        //					camera = gameObject2.GetComponent<Camera>();
        //					if (camera == null)
        //					{
        //						camera = gameObject2.AddComponent<Camera>();
        //					}
        //					this.m_SkyCam = camera;
        //				}
        //				camera.renderingPath = RenderingPath.Forward;
        //				camera.useOcclusionCulling = false;
        //				camera.farClipPlane = 20000f;
        //				camera.cullingMask = 1048576;
        //				camera.clearFlags = CameraClearFlags.Skybox;
        //				camera.fieldOfView = component.fieldOfView;
        //				camera.transform.parent = component.gameObject.transform;
        //				camera.transform.localPosition = Vector3.zero;
        //				camera.transform.localRotation = Quaternion.identity;
        //				camera.depth = -2f;
        //				camera.backgroundColor = Color.black;
        //				gameObject2.SetActive(true);
        //				transform = component.transform.FindChild("Quad");
        //				GameObject gameObject3;
        //				if (transform == null)
        //				{
        //					string path = "SEObjects/SkyQuad".ToAssetBundlePath();
        //					gameObject3 = FileLoader.LoadObjectFromFile<GameObject>(path, true, true);
        //					FileLoader.UnloadAssetBundle(path);
        //				}
        //				else
        //				{
        //					gameObject3 = transform.gameObject;
        //				}
        //				if (gameObject3 != null)
        //				{
        //					gameObject3.name = "Quad";
        //				}
        //				else
        //				{
        //					UnityEngine.Debug.LogError("Quad is null");
        //				}
        //				gameObject3.transform.parent = component.gameObject.transform;
        //				gameObject3.transform.localPosition = Vector3.zero;
        //				gameObject3.transform.localRotation = Quaternion.identity;
        //				if (SceneManager.GetActiveScene().buildIndex == 18)
        //				{
        //					Renderer component2 = gameObject3.GetComponent<Renderer>();
        //					if (component2 != null)
        //					{
        //						SkyQuadScript component3 = gameObject3.GetComponent<SkyQuadScript>();
        //						if (component3 != null)
        //						{
        //							component2.material = component3.m_Diffuse;
        //						}
        //					}
        //				}
        //				else if (SceneManager.GetActiveScene().buildIndex == 15)
        //				{
        //					Renderer component4 = gameObject3.GetComponent<Renderer>();
        //					if (component4 != null)
        //					{
        //						SkyQuadScript component5 = gameObject3.GetComponent<SkyQuadScript>();
        //						if (component5 != null)
        //						{
        //							component4.material = component5.m_Diffuse;
        //						}
        //					}
        //				}
        //				Vector3 zero = Vector3.zero;
        //				zero.z = 1999f;
        //				gameObject3.transform.localPosition = zero;
        //				float num2 = UtilFun.GetMainCamera().fieldOfView / 2f;
        //				float num3 = Mathf.Tan(0.017453292f * num2) * zero.z;
        //				float num4 = (float)Screen.width / (float)Screen.height;
        //				gameObject3.transform.localScale = new Vector3(num3 * 2f * num4, num3 * 2f, 1f);
        //				Renderer component6 = gameObject3.GetComponent<Renderer>();
        //				if (component6 != null)
        //				{
        //					camera.targetTexture = (RenderTexture)component6.sharedMaterial.mainTexture;
        //				}
        //				else
        //				{
        //					UnityEngine.Debug.LogError("r is null");
        //				}
        //				SkyCameraSync skyCameraSync = camera.gameObject.AddComponent<SkyCameraSync>();
        //				skyCameraSync.m_Quad = gameObject3;
        //				skyCameraSync.m_Sky = gameObject;
        //			}
        //		}

        //		// Token: 0x0600370F RID: 14095 RVA: 0x0018DE24 File Offset: 0x0018C024
        //		public void SaveDynamicLight()
        //		{
        //			Light[] array = UnityEngine.Object.FindObjectsOfType<Light>();
        //			for (int i = 0; i < array.Length; i++)
        //			{
        //				if (array[i].type != LightType.Directional)
        //				{
        //					if (!this.FindParentIsMainActor(array[i].gameObject.transform))
        //					{
        //						if (SceneManager.GetActiveScene().buildIndex != 19 || array[i].type != LightType.Spot)
        //						{
        //							if (SceneManager.GetActiveScene().buildIndex == 15 && array[i].type == LightType.Spot)
        //							{
        //								array[i].shadows = LightShadows.Hard;
        //							}
        //							else if (array[i].gameObject.GetComponent<PointLightOptimizer>() == null)
        //							{
        //								array[i].gameObject.AddComponent<PointLightOptimizer>();
        //							}
        //						}
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06003710 RID: 14096 RVA: 0x0018DEF4 File Offset: 0x0018C0F4
        //		private bool FindParentIsMainActor(Transform obj)
        //		{
        //			while (obj != null)
        //			{
        //				PalNPC component = obj.GetComponent<PalNPC>();
        //				if (component != null)
        //				{
        //					if (component.Data != null && component.Data.CharacterID <= 6)
        //					{
        //						return true;
        //					}
        //					obj = obj.parent;
        //				}
        //				else
        //				{
        //					obj = obj.parent;
        //				}
        //			}
        //			return false;
        //		}

        //		// Token: 0x06003711 RID: 14097 RVA: 0x0018DF5C File Offset: 0x0018C15C
        //		public void UpdateDynamicLight()
        //		{
        //		}

        //		// Token: 0x06003712 RID: 14098 RVA: 0x0018DF60 File Offset: 0x0018C160
        //		public static PalMain.PLAYER_RECOMMANDATION GetPlayerRecommandation()
        //		{
        //			return PalMain.m_PlayerRecommandation;
        //		}

        //		// Token: 0x06003713 RID: 14099 RVA: 0x0018DF68 File Offset: 0x0018C168
        //		public static void SetPlayerRecommandation(PalMain.PLAYER_RECOMMANDATION rec)
        //		{
        //			PalMain.m_PlayerRecommandation = rec;
        //		}

        //		// Token: 0x06003714 RID: 14100 RVA: 0x0018DF70 File Offset: 0x0018C170
        //		public static PalMain.PLAYER_RECOMMANDATION DetectMachine()
        //		{
        //			string operatingSystem = SystemInfo.operatingSystem;
        //			bool flag = operatingSystem.Contains("Windows XP");
        //			bool flag2 = !operatingSystem.Contains("64bit");
        //			PalMain.PLAYER_RECOMMANDATION result;
        //			if (SystemInfo.graphicsMemorySize <= 512 || SystemInfo.maxTextureSize < 1800 || (flag && flag2) || SystemInfo.systemMemorySize < 3500)
        //			{
        //				result = PalMain.PLAYER_RECOMMANDATION.LOW;
        //			}
        //			else if (SystemInfo.graphicsMemorySize < 1500)
        //			{
        //				result = PalMain.PLAYER_RECOMMANDATION.MID;
        //			}
        //			else
        //			{
        //				result = PalMain.PLAYER_RECOMMANDATION.HIGH;
        //			}
        //			return result;
        //		}

        //		// Token: 0x06003715 RID: 14101 RVA: 0x0018DFFC File Offset: 0x0018C1FC
        //		public static PalMain.PlayerConfigs GetSettingsByLevel(PalMain.PLAYER_RECOMMANDATION rec)
        //		{
        //			PalMain.PlayerConfigs playerConfigs = new PalMain.PlayerConfigs();
        //			if (rec == PalMain.PLAYER_RECOMMANDATION.HIGH)
        //			{
        //				playerConfigs.m_Settings[0] = 2;
        //				playerConfigs.m_Settings[1] = 3;
        //				playerConfigs.m_Settings[2] = 1;
        //				playerConfigs.m_Settings[3] = 1;
        //				playerConfigs.m_Settings[4] = 0;
        //				playerConfigs.m_Settings[5] = 0;
        //				playerConfigs.m_Settings[6] = 1;
        //				playerConfigs.m_Settings[7] = 2;
        //				playerConfigs.m_Settings[8] = 2;
        //				playerConfigs.m_Settings[9] = 2;
        //				playerConfigs.m_Settings[10] = 1;
        //				playerConfigs.m_Settings[11] = 1;
        //				playerConfigs.m_Settings[12] = 1;
        //				return playerConfigs;
        //			}
        //			if (rec == PalMain.PLAYER_RECOMMANDATION.MID)
        //			{
        //				playerConfigs.m_Settings[0] = 1;
        //				playerConfigs.m_Settings[1] = 1;
        //				playerConfigs.m_Settings[2] = 1;
        //				playerConfigs.m_Settings[3] = 1;
        //				playerConfigs.m_Settings[4] = 1;
        //				playerConfigs.m_Settings[5] = 0;
        //				playerConfigs.m_Settings[6] = 1;
        //				playerConfigs.m_Settings[7] = 2;
        //				playerConfigs.m_Settings[8] = 1;
        //				playerConfigs.m_Settings[9] = 1;
        //				playerConfigs.m_Settings[10] = 1;
        //				playerConfigs.m_Settings[11] = 0;
        //				playerConfigs.m_Settings[12] = 1;
        //				return playerConfigs;
        //			}
        //			playerConfigs.m_Settings[0] = 0;
        //			playerConfigs.m_Settings[1] = 0;
        //			playerConfigs.m_Settings[2] = 0;
        //			playerConfigs.m_Settings[3] = 0;
        //			playerConfigs.m_Settings[4] = 3;
        //			playerConfigs.m_Settings[5] = 0;
        //			playerConfigs.m_Settings[6] = 0;
        //			playerConfigs.m_Settings[7] = 0;
        //			playerConfigs.m_Settings[8] = 0;
        //			playerConfigs.m_Settings[9] = 0;
        //			playerConfigs.m_Settings[10] = 1;
        //			playerConfigs.m_Settings[11] = 0;
        //			playerConfigs.m_Settings[12] = 0;
        //			return playerConfigs;
        //		}

        //		// Token: 0x06003716 RID: 14102 RVA: 0x0018E190 File Offset: 0x0018C390
        //		public static PalMain.PlayerConfigs FirstTimeLaunch103()
        //		{
        //			return PalMain.GetSettingsByLevel(PalMain.DetectMachine());
        //		}

        //		// Token: 0x06003717 RID: 14103 RVA: 0x0018E19C File Offset: 0x0018C39C
        //		public static bool CheckNeedRiaseWarnning(PalMain.SETTING_ENUM setting, int value)
        //		{
        //			PalMain.PlayerConfigs settingsByLevel = PalMain.GetSettingsByLevel(PalMain.DetectMachine());
        //			if (setting == PalMain.SETTING_ENUM.TIE_TU_JING_DU)
        //			{
        //				return settingsByLevel.m_Settings[(int)setting] >= value;
        //			}
        //			return settingsByLevel.m_Settings[(int)setting] < value;
        //		}

        //		// Token: 0x06003718 RID: 14104 RVA: 0x0018E1DC File Offset: 0x0018C3DC
        //		public static void UpdateCheckUnload()
        //		{
        //			PalMain.m_CurUnloadTime += Time.unscaledDeltaTime;
        //			float num = 0f;
        //			switch (PalMain.m_CurPrior)
        //			{
        //			case PalMain.UNLOADPROIR.IMMEDIATE:
        //				num = PalMain.m_FixImmediateTime;
        //				break;
        //			case PalMain.UNLOADPROIR.SHORT:
        //				num = PalMain.m_FixShortTime;
        //				break;
        //			case PalMain.UNLOADPROIR.LONG:
        //				num = PalMain.m_FixLongTime;
        //				break;
        //			case PalMain.UNLOADPROIR.VERYLONG:
        //				num = PalMain.m_FixVeryLongTime;
        //				break;
        //			}
        //			if (PalMain.m_CurUnloadTime > num)
        //			{
        //				PalMain.m_CurUnloadTime = 0f;
        //				if (PalMain.m_bHasUnload)
        //				{
        //					Resources.UnloadUnusedAssets();
        //					PalMain.m_bHasUnload = false;
        //				}
        //			}
        //		}

        //		// Token: 0x06003719 RID: 14105 RVA: 0x0018E278 File Offset: 0x0018C478
        //		public static void UnloadUnusedAssets(PalMain.UNLOADPROIR proir = PalMain.UNLOADPROIR.LONG)
        //		{
        //			Resources.UnloadUnusedAssets();
        //		}

        //		// Token: 0x0600371A RID: 14106 RVA: 0x0018E280 File Offset: 0x0018C480
        //		public static void AddFlagValue(int idx, [DefaultValue(1)] int AddValue = 1)
        //		{
        //			int num = FlagManager.GetFlag(idx);
        //			num += AddValue;
        //			FlagManager.SetFlag(idx, num, false);
        //		}

        //		// Token: 0x0600371B RID: 14107 RVA: 0x0018E2A0 File Offset: 0x0018C4A0
        //		public static void SetPosition(GameObject go, Vector3 pos)
        //		{
        //			NavMeshAgent componentInChildren = go.GetComponentInChildren<NavMeshAgent>();
        //			if (componentInChildren != null)
        //			{
        //				componentInChildren.updatePosition = false;
        //				componentInChildren.updateRotation = false;
        //			}
        //			UtilFun.SetPosition(go.transform, pos);
        //		}

        //		// Token: 0x0600371C RID: 14108 RVA: 0x0018E2DC File Offset: 0x0018C4DC
        //		public static string GetLangueStr(string str0, string str1)
        //		{
        //			uint curLangue = Langue.CurLangue;
        //			return (curLangue >= 1u) ? str1 : str0;
        //		}

        //		// Token: 0x0600371D RID: 14109 RVA: 0x0018E300 File Offset: 0x0018C500
        //		public static void NoActiveUserWarning(bool backToTitle = false)
        //		{
        //			if (PalMain.s_waitForActiveUserWarning)
        //			{
        //				return;
        //			}
        //			PalMain.s_waitForActiveUserWarning = true;
        //			string info;
        //			if (backToTitle)
        //			{
        //				info = ((Langue.CurLangue != 0u) ? "無使用者登入，確認後返回開頭" : "无使用者登入，确认后返回开头");
        //			}
        //			else
        //			{
        //				info = ((Langue.CurLangue != 0u) ? "請登入一名使用者，否則將無法讀存檔案" : "请登入一名使用者，否则将无法读存档案");
        //			}
        //			UIDialogManager.Instance.ShowInfoDialog(info, UIDialogManager.ButtonEnum.Yes, delegate()
        //			{
        //				if ((int)UIDialogManager.Instance.Result == 2 && backToTitle)
        //				{
        //					PalMain.BackToStart();
        //				}
        //				PalMain.s_waitForActiveUserWarning = false;
        //				InputManager.LockThisFrame();
        //			});
        //		}

        //		// Token: 0x0600371E RID: 14110 RVA: 0x0018E390 File Offset: 0x0018C590
        //		public static void NoControllerWarning()
        //		{
        //			if (PalMain.s_noControllerWarning)
        //			{
        //				return;
        //			}
        //			PalMain.s_noControllerWarning = true;
        //			string text = "Warning, no controller connected.";
        //			UIDialogManager.Instance.ShowTopWarnInfo(text, delegate
        //			{
        //				PalMain.s_noControllerWarning = false;
        //				InputManager.LockThisFrame();
        //			});
        //		}

        //		// Token: 0x0600371F RID: 14111 RVA: 0x0018E3DC File Offset: 0x0018C5DC
        //		public IEnumerator waitSkillPreload(Action _action, int level)
        //		{
        //			if (SkillSEPreloader.Instance != null)
        //			{
        //				if (SkillSEPreloader.Instance.m_preloadThisScene)
        //				{
        //					this.m_skillPreloading = true;
        //					float loadingValue = 0.1f / (float)PlayersManager.ActivePlayers.Count;
        //					foreach (GameObject player in PlayersManager.ActivePlayers)
        //					{
        //						Console.WriteLine(string.Format("[Player] : name = {0}", player.ToString()));
        //						PalNPC npc = player.gameObject.GetComponent<PalNPC>();
        //						for (int i = 0; i < npc.m_SkillIDs.Count; i++)
        //						{
        //							Console.WriteLine(string.Format("[PreLoad Skill] : npc={0}, skillID={1}", npc.gameObject.ToString(), npc.m_SkillIDs[i].m_ID));
        //							SkillSEPreloader.Instance.loadSkillSE(npc.m_SkillIDs[i].m_ID);
        //							yield return null;
        //						}
        //						FightProperty fight = npc.Data.Fight;
        //						if (fight != null)
        //						{
        //							int scriptID = -1;
        //							int.TryParse(fight.BattleAIScript, out scriptID);
        //							if (SkillSEPreloader.s_battleAISkillDic.ContainsKey(scriptID))
        //							{
        //								List<int> skillList = SkillSEPreloader.s_battleAISkillDic[scriptID];
        //								for (int j = 0; j < skillList.Count; j++)
        //								{
        //									Console.WriteLine(string.Format("[PreLoad Skill] : npc={0}, scriptID={1}, skillID={2}", npc.gameObject.ToString(), scriptID, skillList[j]));
        //									SkillSEPreloader.Instance.loadSkillSE(skillList[j]);
        //									yield return null;
        //								}
        //							}
        //						}
        //						PalMain.LoadingValue += loadingValue;
        //					}
        //				}
        //				this.m_skillPreloading = false;
        //				SkillSEPreloader.Instance.m_preloadThisScene = false;
        //			}
        //			_action();
        //			yield return null;
        //			yield break;
        //		}

        //		// Token: 0x06003720 RID: 14112 RVA: 0x0018E408 File Offset: 0x0018C608
        //		private void OnApplicationFocus(bool hasFocus)
        //		{
        //			if (hasFocus)
        //			{
        //				this.shouldRenewFrames = this.FOCUS_WAIT_FRAMES;
        //			}
        //		}

        //		// Token: 0x06003721 RID: 14113 RVA: 0x0018E41C File Offset: 0x0018C61C
        //		public void ForceRenew()
        //		{
        //			this.shouldRenewFrames = this.FOCUS_WAIT_FRAMES;
        //		}

        //		// Token: 0x06003722 RID: 14114 RVA: 0x0018E42C File Offset: 0x0018C62C
        //		private void UpdateSpecialIssueForNonFocus()
        //		{
        //			if (this.shouldRenewFrames > 0)
        //			{
        //				this.shouldRenewFrames--;
        //				if (this.shouldRenewFrames == 0)
        //				{
        //					Terrain activeTerrain = Terrain.activeTerrain;
        //					if (activeTerrain != null)
        //					{
        //						activeTerrain.gameObject.SetActive(false);
        //						activeTerrain.gameObject.SetActive(true);
        //					}
        //					GameObject uiroot = UIManager.Instance.UIRoot;
        //					if (uiroot != null)
        //					{
        //						uiroot.SetActive(false);
        //						uiroot.SetActive(true);
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06003723 RID: 14115 RVA: 0x0018E4B0 File Offset: 0x0018C6B0
        //		public void ChangeLanguage(uint next)
        //		{
        //			Langue.ClearLanguageDictionary();
        //			PalMain.ReleaseLangueUIAtlas("StringImage0");
        //			Langue.CurLangue = next;
        //			PalBattleManager.Instance().GetMonsterSkillDataManager().ReParseLanguageData();
        //			PalBattleManager.Instance().GetStatusDataManager().ReParseLanguageData();
        //			PalMain.ReloadLangueUIAtlas("StringImage0");
        //			foreach (NicknameBuffDebuffType nicknameBuffDebuffType in NicknameBuffDebuffTypeCache.GetDatasFromFile())
        //			{
        //				if (nicknameBuffDebuffType != null)
        //				{
        //					nicknameBuffDebuffType.mName.ReLoad();
        //					nicknameBuffDebuffType.mHistoryDesc.ReLoad();
        //					nicknameBuffDebuffType.mFunctionDesc.ReLoad();
        //				}
        //			}
        //			foreach (ClothDecal clothDecal in ClothDecal.GetDatasFromFile())
        //			{
        //				if (clothDecal != null)
        //				{
        //					clothDecal.TextureName.ReLoad();
        //				}
        //			}
        //			foreach (ClothTexture clothTexture in ClothTexture.GetDatasFromFile())
        //			{
        //				if (clothTexture != null)
        //				{
        //					clothTexture.ColorName.ReLoad();
        //				}
        //			}
        //			foreach (SymbolNodeItemType symbolNodeItemType in SymbolNodeItemType.GetDatasFromFile())
        //			{
        //				if (symbolNodeItemType != null)
        //				{
        //					symbolNodeItemType.mName.ReLoad();
        //					symbolNodeItemType.mDesc.ReLoad();
        //				}
        //			}
        //			foreach (SymbolPanelItemType symbolPanelItemType in SymbolPanelItemType.GetDatasFromFile())
        //			{
        //				if (symbolPanelItemType != null)
        //				{
        //					symbolPanelItemType.mName.ReLoad();
        //					symbolPanelItemType.mDesc.ReLoad();
        //				}
        //			}
        //			foreach (MapData mapData in MapData.GetDatasFromFile())
        //			{
        //				if (mapData != null)
        //				{
        //					mapData.Name.ReLoad();
        //				}
        //			}
        //			foreach (MusicData musicData in MusicData.GetDatasFromFile())
        //			{
        //				if (musicData != null)
        //				{
        //					musicData.Name.ReLoad();
        //				}
        //			}
        //			foreach (PlayerProperty.StaticData staticData in PlayerProperty.StaticData.GetDatasFromFile())
        //			{
        //				if (staticData != null)
        //				{
        //					staticData.SkillGroupName0.ReLoad();
        //					staticData.SkillGroupName1.ReLoad();
        //				}
        //			}
        //			foreach (SoulStarData soulStarData in SoulDataManager.GetDatasFromFile())
        //			{
        //				if (soulStarData != null)
        //				{
        //					soulStarData.NodeName.ReLoad();
        //					soulStarData.NodeDesc.ReLoad();
        //				}
        //			}
        //			foreach (UIInformation_Help_Item.ItemClass itemClass in UIInformation_Help_Item.Items)
        //			{
        //				itemClass.TitleLangue.ReLoad();
        //				foreach (UIInformation_Help_Item.ItemClass itemClass2 in itemClass.SubItems)
        //				{
        //					itemClass2.TitleLangue.ReLoad();
        //				}
        //			}
        //			foreach (UIInformation_StrangeNews_Item.TypeData typeData in UIInformation_StrangeNews_Item.Items)
        //			{
        //				typeData.TextLangue.ReLoad();
        //				foreach (UIInformation_StrangeNews_Item.TitleData titleData in typeData.TitleDatas)
        //				{
        //					titleData.TextLangue.ReLoad();
        //					foreach (UIInformation_StrangeNews_Item.ItemData itemData in titleData.ItemDatas)
        //					{
        //						itemData.TextLangue.ReLoad();
        //					}
        //				}
        //			}
        //			foreach (KeyValuePair<uint, CharacterProperty.StaticData> keyValuePair in CharacterProperty.StaticData.GetDatasFromFile())
        //			{
        //				keyValuePair.Value.ShowName.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, ClothItemType> keyValuePair2 in ClothItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair2.Value.mName.ReLoad();
        //				keyValuePair2.Value.mHistoryDesc.ReLoad();
        //				keyValuePair2.Value.mFunctionDesc.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, FashionClothItemType> keyValuePair3 in FashionClothItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair3.Value.mName.ReLoad();
        //				keyValuePair3.Value.mHistoryDesc.ReLoad();
        //				keyValuePair3.Value.mFunctionDesc.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, NormalItemType> keyValuePair4 in NormalItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair4.Value.mName.ReLoad();
        //				keyValuePair4.Value.mHistoryDesc.ReLoad();
        //				keyValuePair4.Value.mFunctionDesc.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, OrnamentItemType> keyValuePair5 in OrnamentItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair5.Value.mName.ReLoad();
        //				keyValuePair5.Value.mHistoryDesc.ReLoad();
        //				keyValuePair5.Value.mFunctionDesc.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, ShoesItemType> keyValuePair6 in ShoesItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair6.Value.mName.ReLoad();
        //				keyValuePair6.Value.mHistoryDesc.ReLoad();
        //				keyValuePair6.Value.mFunctionDesc.ReLoad();
        //			}
        //			foreach (KeyValuePair<uint, WeaponItemType> keyValuePair7 in WeaponItemTypeCache.GetDatasFromFile())
        //			{
        //				keyValuePair7.Value.mName.ReLoad();
        //				keyValuePair7.Value.mHistoryDesc.ReLoad();
        //				keyValuePair7.Value.mFunctionDesc.ReLoad();
        //			}
        //		}

        //		// Token: 0x020007A3 RID: 1955
        //		public class SceneOptiDistFogParams
        //		{
        //			// Token: 0x0600372A RID: 14122 RVA: 0x0018F5C4 File Offset: 0x0018D7C4
        //			public SceneOptiDistFogParams(int id, float hi, float mid, float low)
        //			{
        //				this.m_LevelID = id;
        //				this.m_CullDist_Hi = hi;
        //				this.m_CullDist_Mid = mid;
        //				this.m_CullDist_Low = low;
        //			}

        //			// Token: 0x04003170 RID: 12656
        //			public int m_LevelID;

        //			// Token: 0x04003171 RID: 12657
        //			public float m_CullDist_Hi;

        //			// Token: 0x04003172 RID: 12658
        //			public float m_CullDist_Mid;

        //			// Token: 0x04003173 RID: 12659
        //			public float m_CullDist_Low;
        //		}

        //		// Token: 0x020007A4 RID: 1956
        //		public enum PLAYER_RECOMMANDATION
        //		{
        //			// Token: 0x04003175 RID: 12661
        //			LOW,
        //			// Token: 0x04003176 RID: 12662
        //			MID,
        //			// Token: 0x04003177 RID: 12663
        //			HIGH
        //		}

        //		// Token: 0x020007A5 RID: 1957
        //		public enum SETTING_ENUM
        //		{
        //			// Token: 0x04003179 RID: 12665
        //			SHI_YE,
        //			// Token: 0x0400317A RID: 12666
        //			YIN_YING,
        //			// Token: 0x0400317B RID: 12667
        //			HDR,
        //			// Token: 0x0400317C RID: 12668
        //			KANG_JU_CHI,
        //			// Token: 0x0400317D RID: 12669
        //			TIE_TU_JING_DU,
        //			// Token: 0x0400317E RID: 12670
        //			CHUI_ZHI_TONG_BU,
        //			// Token: 0x0400317F RID: 12671
        //			TI_JI_GUANG,
        //			// Token: 0x04003180 RID: 12672
        //			ZHI_BEI_FAN_WEI,
        //			// Token: 0x04003181 RID: 12673
        //			WU_SE_JU_LI,
        //			// Token: 0x04003182 RID: 12674
        //			JING_TONG_MEI_HUA,
        //			// Token: 0x04003183 RID: 12675
        //			ZHAN_DOU_TE_XIAO,
        //			// Token: 0x04003184 RID: 12676
        //			SHUI_MIAN_DAO_YING,
        //			// Token: 0x04003185 RID: 12677
        //			GAO_JI_GUANG_YUAN,
        //			// Token: 0x04003186 RID: 12678
        //			SETTING_MAX
        //		}

        //		// Token: 0x020007A6 RID: 1958
        //		public class PlayerConfigs
        //		{
        //			// Token: 0x0600372B RID: 14123 RVA: 0x0018F5EC File Offset: 0x0018D7EC
        //			public PlayerConfigs()
        //			{
        //				for (int i = 0; i < 13; i++)
        //				{
        //					this.m_Settings[i] = 0;
        //				}
        //			}

        //			// Token: 0x04003187 RID: 12679
        //			public int[] m_Settings = new int[13];
        //		}

        //		// Token: 0x020007A7 RID: 1959
        //		public enum WatchType
        //		{
        //			// Token: 0x04003189 RID: 12681
        //			FirstPerson,
        //			// Token: 0x0400318A RID: 12682
        //			ThirdPerson,
        //			// Token: 0x0400318B RID: 12683
        //			Custem
        //		}

        //		// Token: 0x020007A8 RID: 1960
        //		public enum DISTANCE_CULL
        //		{
        //			// Token: 0x0400318D RID: 12685
        //			LOW,
        //			// Token: 0x0400318E RID: 12686
        //			MID,
        //			// Token: 0x0400318F RID: 12687
        //			FULL,
        //			// Token: 0x04003190 RID: 12688
        //			RESTORE
        //		}

        //		// Token: 0x020007A9 RID: 1961
        //		public enum POST_CAM
        //		{
        //			// Token: 0x04003192 RID: 12690
        //			NONE,
        //			// Token: 0x04003193 RID: 12691
        //			MID,
        //			// Token: 0x04003194 RID: 12692
        //			FULL
        //		}

        //		// Token: 0x020007AA RID: 1962
        //		public enum LIGHT
        //		{
        //			// Token: 0x04003196 RID: 12694
        //			NONE,
        //			// Token: 0x04003197 RID: 12695
        //			FULL
        //		}

        //		// Token: 0x020007AB RID: 1963
        //		public enum UNLOADPROIR
        //		{
        //			// Token: 0x04003199 RID: 12697
        //			IMMEDIATE,
        //			// Token: 0x0400319A RID: 12698
        //			SHORT,
        //			// Token: 0x0400319B RID: 12699
        //			LONG,
        //			// Token: 0x0400319C RID: 12700
        //			VERYLONG
        //		}

        //		// Token: 0x02001852 RID: 6226
        //		// (Invoke) Token: 0x060166B0 RID: 91824
        //		public delegate void void_func_void();

        //		// Token: 0x02001853 RID: 6227
        //		// (Invoke) Token: 0x060166B4 RID: 91828
        //		public delegate void void_func_float_float(float currentTime, float deltaTime);
    }
}
