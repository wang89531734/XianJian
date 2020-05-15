using System;
using System.Collections.Generic;
using System.IO;
//using Funfia.File;
//using pumpkin.swf;
//using SoftStar.Item;
//using SoftStar.Pal6.UI;
using UnityEngine;

namespace SoftStar.Pal6
{
    public class PalBattleManager
    {
        //		protected const int mBattleIDFriendStart = 7;

        //		protected const int mBattleIDEnemyStart = 10;

        //		public const int MainCharactorNum = 8;

        //		public static readonly int[] BaseDebuffArray;

        //		// Token: 0x04001487 RID: 5255
        //		public PalBattleManager.OnRetureCutsceneCallback mReturnCutsceneCallback;

        //		// Token: 0x04001488 RID: 5256
        //		protected MonsterGroupDataManager mMonsterGroupDataMgr;

        //		// Token: 0x04001489 RID: 5257
        //		protected MonsterSkillDataManager mMonsterSkillDataMgr;

        //		// Token: 0x0400148A RID: 5258
        //		protected StatusDataManager mStatusDataMgr;

        //		// Token: 0x0400148B RID: 5259
        //		protected BattleFieldDataManager mBattleFieldDataMgr;

        //		// Token: 0x0400148C RID: 5260
        //		public Dictionary<int, int> flags = new Dictionary<int, int>();

        private static PalBattleManager instance;

        //		// Token: 0x0400148E RID: 5262
        //		public BattleScriptManager mBattleScriptMgr;

        //		// Token: 0x0400148F RID: 5263
        //		public Dictionary<int, BattlePlayer> mBattlePlayers = new Dictionary<int, BattlePlayer>();

        //		// Token: 0x04001490 RID: 5264
        //		public List<BattlePlayer> mBattlePlayersForLogout = new List<BattlePlayer>();

        //		// Token: 0x04001491 RID: 5265
        //		public BattlePlayer mControlledPlayer;

        //		// Token: 0x04001492 RID: 5266
        //		private ATBBattleUI mATBUI;

        //		// Token: 0x04001493 RID: 5267
        //		private TeammateBattleUI mTeammateUI;

        //		// Token: 0x04001494 RID: 5268
        //		private TargetUI mTargetUI;

        //		// Token: 0x04001495 RID: 5269
        //		private ThreePhaseUI mThreePhaseUI;

        //		// Token: 0x04001496 RID: 5270
        //		private DialogUI mDialogUI;

        //		// Token: 0x04001497 RID: 5271
        //		private DialogUIFlash mDialogUIFlash;

        //		// Token: 0x04001498 RID: 5272
        //		private FormationUI mFormationUI;

        //		// Token: 0x04001499 RID: 5273
        //		public BattleMonsterGroupLoss mLossScript_C_Sharp;

        //		// Token: 0x0400149A RID: 5274
        //		public BattleMonsterGroupShop mShopScript_C_Sharp;

        //		// Token: 0x0400149B RID: 5275
        //		public BattleMonsterGroupStart mStartScript_C_Sharp;

        //		// Token: 0x0400149C RID: 5276
        //		public BattleMonsterGroupTitle mTitleScript_C_Sharp;

        //		// Token: 0x0400149D RID: 5277
        //		public BattleMonsterGroupWin mWinScript_C_Sharp;

        //		// Token: 0x0400149E RID: 5278
        //		private BattleHPChangeGUI mHPGUI;

        //		// Token: 0x0400149F RID: 5279
        //		public BattleEventProcessor mEventProcessor;

        //		// Token: 0x040014A0 RID: 5280
        //		public NewThreePhaseAngrySystem mNewTPASystem;

        //		// Token: 0x040014A1 RID: 5281
        //		public PalBattleManager.BATTLE_STATE mCurrentBattleState = PalBattleManager.BATTLE_STATE.POST_BATTLE;

        //		// Token: 0x040014A2 RID: 5282
        //		public bool mbLogoutAll;

        //		// Token: 0x040014A3 RID: 5283
        //		public PolarSystemLBI m_PolarLBI;

        //		// Token: 0x040014A4 RID: 5284
        //		public BattleDirector mBattleDirector;

        //		// Token: 0x040014A5 RID: 5285
        //		public BattleIndicator mBattleIndicator;

        //		// Token: 0x040014A6 RID: 5286
        //		public List<int> mDangdangList = new List<int>();

        //		// Token: 0x040014A7 RID: 5287
        //		public int mQTEBattlePlayerID;

        //		// Token: 0x040014A8 RID: 5288
        //		public int mQTEIndex;

        //		// Token: 0x040014A9 RID: 5289
        //		public PalSE mQTESE;

        //		// Token: 0x040014AA RID: 5290
        //		public PalBattleManager.void_Exit_Battle mDramaBattleEndFunc;

        //		// Token: 0x040014AB RID: 5291
        //		private static bool mbFirstTime = true;

        //		// Token: 0x040014AC RID: 5292
        //		public Dictionary<int, List<BattleSkill>> m_CommonSkills = new Dictionary<int, List<BattleSkill>>();

        //		// Token: 0x040014AD RID: 5293
        //		public BattleFormationManager m_BattleFormation = new BattleFormationManager();

        //		// Token: 0x040014AE RID: 5294
        //		public Material m_HitMaterial;

        //		// Token: 0x040014AF RID: 5295
        //		public Material m_BreakMaterial;

        //		// Token: 0x040014B0 RID: 5296
        //		public Material m_DisappearMaterial;

        //		// Token: 0x040014B1 RID: 5297
        //		public Material m_InvisibleMaterial;

        //		// Token: 0x040014B2 RID: 5298
        //		private bool m_nextAllIdle;

        //		// Token: 0x040014B3 RID: 5299
        //		public int m_Money;

        //		// Token: 0x040014B4 RID: 5300
        //		public int m_CurrentMonsterGroup;

        //		// Token: 0x040014B5 RID: 5301
        //		public bool m_bBattleSuspend;

        //		// Token: 0x040014B6 RID: 5302
        //		public int m_YuanShen;

        //		// Token: 0x040014B7 RID: 5303
        //		public int m_Exp;

        //		// Token: 0x040014B8 RID: 5304
        //		public Dictionary<uint, int> m_Items = new Dictionary<uint, int>();

        //		// Token: 0x040014B9 RID: 5305
        //		public Dictionary<int, int> m_UpgradeList = new Dictionary<int, int>();

        //		// Token: 0x040014BA RID: 5306
        //		private Vector3 m_AvoidBattleAgainPos;

        //		// Token: 0x040014BB RID: 5307
        //		public bool m_bUseDefaultEndBattle = true;

        //		// Token: 0x040014BC RID: 5308
        //		private bool m_bSkipOutBattleResult;

        //		// Token: 0x040014BD RID: 5309
        //		public Vector3 m_InitCameraPos;

        //		// Token: 0x040014BE RID: 5310
        //		public Quaternion m_InitCameraRot;

        //		// Token: 0x040014BF RID: 5311
        //		public Vector3 m_InitPosToPlayer;

        //		// Token: 0x040014C0 RID: 5312
        //		public Quaternion m_InitRotToPlayer;

        //		// Token: 0x040014C1 RID: 5313
        //		public bool m_bUseInitToPlayer;

        //		// Token: 0x040014C2 RID: 5314
        //		public List<int> m_VisibleBP = new List<int>();

        //		// Token: 0x040014C3 RID: 5315
        //		private List<PalNPC> m_Rebattle_players;

        //		// Token: 0x040014C4 RID: 5316
        //		private List<PalNPC> m_Rebattle_enemys;

        //		// Token: 0x040014C5 RID: 5317
        //		private int m_Rebattle_BattleFieldID;

        //		// Token: 0x040014C6 RID: 5318
        //		private int m_Rebattle_MonsterGroupID;

        //		// Token: 0x040014C7 RID: 5319
        //		public bool m_Rebattle_bInPlaceBattle;

        //		// Token: 0x040014C8 RID: 5320
        //		public bool m_bCommonBattle;

        //		// Token: 0x040014C9 RID: 5321
        //		public PalNPC m_Rebattle_MeNPC;

        //		// Token: 0x040014CA RID: 5322
        //		private PalNPC m_Rebattle_OtherNPC;

        //		// Token: 0x040014CB RID: 5323
        //		private bool m_bRebattle;

        //		// Token: 0x040014CC RID: 5324
        //		private bool m_Rebattle_bChangeMusic = true;

        //		// Token: 0x040014CD RID: 5325
        //		public int m_NumberEnemyDie;

        //		// Token: 0x040014CE RID: 5326
        //		public PetManager m_PetMgr;

        //		// Token: 0x040014CF RID: 5327
        //		public float m_QiXiHP = 1f;

        //		// Token: 0x040014D0 RID: 5328
        //		public bool m_RebattleQiXi;

        //		// Token: 0x040014D1 RID: 5329
        //		private bool m_bEnableGoToBattle = true;

        //		// Token: 0x040014D2 RID: 5330
        //		private PalNPC m_BattlePalNPC;

        //		// Token: 0x040014D3 RID: 5331
        //		private int m_CamCullingMask;

        //		// Token: 0x040014D4 RID: 5332
        //		public PalBattleManager.RandomTask m_RandomTask = new PalBattleManager.RandomTask();

        //		// Token: 0x040014D5 RID: 5333
        //		public bool m_bRandomTask;

        //		// Token: 0x040014D6 RID: 5334
        //		public float m_BattleTime;

        //		// Token: 0x040014D7 RID: 5335
        //		public BattlePlayer m_LastAttackBp;

        //		// Token: 0x040014D8 RID: 5336
        //		public BattlePlayer m_bMostHatredMan;

        //		// Token: 0x040014D9 RID: 5337
        //		public BattlePlayer m_bLowestThreatenMan;

        //		// Token: 0x040014DA RID: 5338
        //		public AchievementManager m_Achievement = new AchievementManager();

        //		// Token: 0x040014DB RID: 5339
        //		public bool m_bControlledPlayerWait;

        //		// Token: 0x040014DC RID: 5340
        //		private Dictionary<int, int> m_PlayersHP = new Dictionary<int, int>();

        //		// Token: 0x040014DD RID: 5341
        //		public PalBattleManager.PLAYER_AI_TACTICAL m_CurrentTactical;

        //		// Token: 0x040014DE RID: 5342
        //		public int m_unfinishLoadingCount;

        //		// Token: 0x040014DF RID: 5343
        //		private List<PalNPC> m_players = new List<PalNPC>();

        //		// Token: 0x040014E0 RID: 5344
        //		private List<PalNPC> m_monsters = new List<PalNPC>();

        //		// Token: 0x040014E1 RID: 5345
        //		private int m_gp;

        //		// Token: 0x040014E2 RID: 5346
        //		public int m_bid;

        //		// Token: 0x040014E3 RID: 5347
        //		public bool m_bChangeMusic;

        //		// Token: 0x040014E4 RID: 5348
        //		public int m_OldAudioClipID;

        //		// Token: 0x040014E5 RID: 5349
        //		public int mOldAnimTime;

        //		// Token: 0x040014E6 RID: 5350
        //		private int m_FailCountDown = 2;

        //		// Token: 0x040014E7 RID: 5351
        //		public bool m_bShowDisplayer;

        //		// Token: 0x040014E8 RID: 5352
        //		public bool m_bEnableBattleUI;

        //		// Token: 0x040014E9 RID: 5353
        //		public bool m_BFixedBattleDirection;

        //		// Token: 0x040014EA RID: 5354
        //		public float m_EnemyMaxRadius = 5f;

        //		// Token: 0x040014EB RID: 5355
        //		private float m_FriendOffset = 3f;

        //		// Token: 0x040014EC RID: 5356
        //		private float m_EnemyOffset = 3f;

        //		// Token: 0x040014ED RID: 5357
        //		private bool m_bShowHPUI;

        //		// Token: 0x040014EE RID: 5358
        //		private List<GameObject> m_SelectedPlayers = new List<GameObject>();

        //		// Token: 0x040014EF RID: 5359
        //		private float m_BattleCoolDown = 2f;

        //		// Token: 0x040014F0 RID: 5360
        //		private int m_YueSkillGroup;

        //		// Token: 0x040014F1 RID: 5361
        //		public float m_CameraRadiusLimit;

        //		// Token: 0x040014F2 RID: 5362
        //		public float m_CameraYawClamp;

        //		// Token: 0x040014F3 RID: 5363
        //		private List<int> m_FixedPlayer = new List<int>();

        //		// Token: 0x040014F4 RID: 5364
        //		private Vector3 m_CutScenePos;

        //		// Token: 0x040014F5 RID: 5365
        //		private Quaternion m_CutSceneRot;

        //		// Token: 0x040014F6 RID: 5366
        //		private bool m_bScreenTexturing;

        //		// Token: 0x040014F7 RID: 5367
        //		private Shader m_ScreenTexturingShader;

        //		// Token: 0x040014F8 RID: 5368
        //		private bool m_ScreenTexturingEnabled;

        //		// Token: 0x040014F9 RID: 5369
        //		private ScreenTexturing.ST_BlendMode m_ScreenTexturingBlendMode;

        //		// Token: 0x040014FA RID: 5370
        //		private bool m_ScreenTexturingInverseMask;

        //		// Token: 0x040014FB RID: 5371
        //		private Texture m_ScreenTexturingMaskTexture;

        //		// Token: 0x040014FC RID: 5372
        //		private Texture m_ScreenTexturingTex;

        //		// Token: 0x040014FD RID: 5373
        //		private float m_ScreenTexturingT;

        //		// Token: 0x040014FE RID: 5374
        //		private Vector2 m_ScreenTexturingUvAnimSpeed;

        //		// Token: 0x040014FF RID: 5375
        //		private bool m_ScreenTexturingDisableUVAnim;

        //		// Token: 0x04001500 RID: 5376
        //		private bool m_bHSL;

        //		// Token: 0x04001501 RID: 5377
        //		private Shader m_HSLShader;

        //		// Token: 0x04001502 RID: 5378
        //		private bool m_HSLEnabled;

        //		// Token: 0x04001503 RID: 5379
        //		private Texture m_HSLMaskTexture;

        //		// Token: 0x04001504 RID: 5380
        //		private bool m_HSLInverseMask;

        //		// Token: 0x04001505 RID: 5381
        //		private float m_HSLT;

        //		// Token: 0x04001506 RID: 5382
        //		private float m_HSLHue;

        //		// Token: 0x04001507 RID: 5383
        //		private float m_HSLSaturation;

        //		// Token: 0x04001508 RID: 5384
        //		private float m_HSLLightness;

        //		// Token: 0x04001509 RID: 5385
        //		private float m_HSLContrast;

        //		// Token: 0x0400150A RID: 5386
        //		private bool m_bRadialBlur;

        //		// Token: 0x0400150B RID: 5387
        //		private Shader m_RadialBlurShader;

        //		// Token: 0x0400150C RID: 5388
        //		private bool m_RadialBlurEnabled;

        //		// Token: 0x0400150D RID: 5389
        //		private Texture m_RadialBlurMaskTexture;

        //		// Token: 0x0400150E RID: 5390
        //		private bool m_RadialBlurInverseMask;

        //		// Token: 0x0400150F RID: 5391
        //		private float m_RadialBlurT;

        //		// Token: 0x04001510 RID: 5392
        //		private float m_RadialBlurBlurStrength;

        //		// Token: 0x04001511 RID: 5393
        //		private float m_RadialBlurSampleDist;

        //		// Token: 0x04001512 RID: 5394
        //		private float m_RadialBlurCenterX;

        //		// Token: 0x04001513 RID: 5395
        //		private float m_RadialBlurCenterY;

        //		// Token: 0x04001514 RID: 5396
        //		private bool m_bDisturb;

        //		// Token: 0x04001515 RID: 5397
        //		private Shader m_DisturbShader;

        //		// Token: 0x04001516 RID: 5398
        //		private bool m_DisturbEnabled;

        //		// Token: 0x04001517 RID: 5399
        //		private Texture m_DisturbMaskTexture;

        //		// Token: 0x04001518 RID: 5400
        //		private bool m_DisturbInverseMask;

        //		// Token: 0x04001519 RID: 5401
        //		private float m_DisturbT;

        //		// Token: 0x0400151A RID: 5402
        //		private Texture2D m_DisturbDisturbTex;

        //		// Token: 0x0400151B RID: 5403
        //		private float m_DisturbStrength;

        //		// Token: 0x0400151C RID: 5404
        //		private float m_DisturbXSpeed;

        //		// Token: 0x0400151D RID: 5405
        //		private float m_DisturbYSpeed;

        //		// Token: 0x0400151E RID: 5406
        //		private GameObject m_JGXModel;

        //		// Token: 0x0400151F RID: 5407
        //		private Behaviour m_GlobalFog;

        //		// Token: 0x04001520 RID: 5408
        //		public bool m_bFogEnable;

        //		// Token: 0x04001521 RID: 5409
        //		private BattleCameraController m_CamCtrl;

        //		// Token: 0x04001522 RID: 5410
        //		private bool m_bNeverFail;

        //		// Token: 0x04001523 RID: 5411
        //		public bool m_bHDR;

        //		// Token: 0x04001524 RID: 5412
        //		private bool m_bScriptWin;

        //		// Token: 0x04001525 RID: 5413
        //		public bool m_bEnterBattle;

        //		// Token: 0x04001526 RID: 5414
        //		private bool m_bLastCap;

        //		// Token: 0x04001527 RID: 5415
        //		private GameObject m_scObject;

        //		// Token: 0x04001528 RID: 5416
        //		private List<PalSE> m_PalSEs = new List<PalSE>();

        //		// Token: 0x04001529 RID: 5417
        //		private bool m_bLastFrameZero;

        //		// Token: 0x0400152A RID: 5418
        //		private float m_CurForceInBattleTime;

        //		// Token: 0x0400152B RID: 5419
        //		public List<uint> m_RebattleItems = new List<uint>();

        //		// Token: 0x0400152C RID: 5420
        //		private GameState m_LastGameState = GameState.None;

        //		// Token: 0x0400152D RID: 5421
        //		public static bool m_bOnBattleUnitSE = true;

        //		// Token: 0x0400152E RID: 5422
        //		public static bool m_bCheat;

        public enum BATTLE_MODE
        {
            BATTLE_MODE_CONTINUE,
            BATTLE_MODE_DISCREET
        }

        public enum PLAYER_AI_TACTICAL : byte
        {
            CHU_SHI_GONG_JI,
            FEN_SAN_GONG_JI,
            JI_HUO_GONG_JI,
            HUI_FU_YOU_XIAN,
            JIAN_GU_FANG_YU,
            TIAO_ZHENG_ZHUANG_TAI,
            MAX_TACTICAL
        }

        public class RandomTask
        {
            public float[] m_Times = new float[3];

            public float[] m_rewards = new float[3];

            public enum CLASS_ENUM
            {
                B,
                A,
                S,
                MAX
            }
        }

        public enum BATTLE_DIFFICULTY
        {
            EASY,
            NORMAL,
            HARD
        }

        public enum BATTLE_STATE
        {
            PRE_BATTLE,
            RESUME_BATTLE,
            PAUSE_BATTLE,
            POST_BATTLE,
            WIN_BATTLE,
            LOSS_BATTLE,
            STATE_MAX
        }

        public delegate void void_Enter_Battle();

        public delegate void void_Exit_Battle();

        public delegate void OnRetureCutsceneCallback(bool bSucceed);

        public PalBattleManager()
        {
            //UnitSEIDPathDataGameManager.GetInstance();
            //PalBattleManager.instance = this;
            //string empty = string.Empty;
            //this.mMonsterGroupDataMgr = new MonsterGroupDataManager(Application.dataPath + empty + "/Data/Property/monsterGroupData.txt");
            //this.mMonsterSkillDataMgr = new MonsterSkillDataManager(Application.dataPath + empty + "/Data/Property/skillData.txt");
            //this.mStatusDataMgr = new StatusDataManager(Application.dataPath + empty + "/Data/Property/statusData.txt");
            //this.mBattleFieldDataMgr = new BattleFieldDataManager(Application.dataPath + empty + "/Data/Property/battlefieldData.txt");
            //BattleEventProcessorManager.Initialize();
            //this.mBattleScriptMgr = new BattleScriptManager();
            //PalMain.GameMain.updateHandles += PalBattleManager.Update;
            //this.m_PolarLBI = new PolarSystemLBI();
            //this.mBattleDirector = new BattleDirector(this);
            //this.mEventProcessor = new BattleEventProcessor();
            //this.mEventProcessor.RegisiterHandler(24, new BattleEventProcessor.EventHandler(this.OnQTEStart));
            //this.mATBUI = new ATBBattleUI();
            //this.mTeammateUI = new TeammateBattleUI();
            //this.mTargetUI = new TargetUI();
            //this.mThreePhaseUI = new ThreePhaseUI();
            //this.mDialogUI = new DialogUI();
            //this.mDialogUIFlash = new DialogUIFlash();
            //this.mFormationUI = new FormationUI();
            //this.mHPGUI = new BattleHPChangeGUI();
            //this.registerUICallback();
            //this.mNewTPASystem = new NewThreePhaseAngrySystem();
            //this.mEventProcessor.RegisiterHandler(14, new BattleEventProcessor.EventHandler(this.OnStartStateChange));
            //this.mEventProcessor.RegisiterHandler(20, new BattleEventProcessor.EventHandler(this.OnBattleControl));
            //this.mEventProcessor.RegisiterHandler(7, new BattleEventProcessor.EventHandler(this.BattlePlayerOnHPChange));
            //this.CreateBattleIndicator();
            //this.m_BattleFormation.m_BattleFormationChangeCallback = new BattleFormationManager.BattleFormationChangeCallback(this.OnSetBattleFormation);
            //this.m_PetMgr = new PetManager();
        }

        static PalBattleManager()
        {
            //PalBattleManager.BaseDebuffArray = new int[]
            //{
            //            12,
            //            13
            //};
        }

        //		// Token: 0x1400000F RID: 15
        //		// (add) Token: 0x0600125C RID: 4700 RVA: 0x000B4B50 File Offset: 0x000B2D50
        //		// (remove) Token: 0x0600125D RID: 4701 RVA: 0x000B4B6C File Offset: 0x000B2D6C
        //		public event PalBattleManager.void_Enter_Battle mEnterBattleFunc;

        //		// Token: 0x14000010 RID: 16
        //		// (add) Token: 0x0600125E RID: 4702 RVA: 0x000B4B88 File Offset: 0x000B2D88
        //		// (remove) Token: 0x0600125F RID: 4703 RVA: 0x000B4BA4 File Offset: 0x000B2DA4
        //		public event PalBattleManager.void_Exit_Battle mExitBattleFunc;

        public static void Initialize()
        {
            Debug.Log("Initialize PalBattleManager");
            PalBattleManager.instance = new PalBattleManager();
        }

        public static PalBattleManager Instance()
        {
            return PalBattleManager.instance;
        }

        //		// Token: 0x06001262 RID: 4706 RVA: 0x000B4BE0 File Offset: 0x000B2DE0
        //		public static void Update(float currentTime, float deltaTime)
        //		{
        //			if (PalBattleManager.mbFirstTime)
        //			{
        //				PalBattleManager.mbFirstTime = false;
        //				PalBattleManager.Instance().m_HitMaterial = (Material)Resources.Load("Material/ChangeMatHit");
        //				PalBattleManager.Instance().m_BreakMaterial = (Material)Resources.Load("Material/ChangeMatBreak");
        //				PalBattleManager.Instance().m_DisappearMaterial = (Material)Resources.Load("Material/ChangeMatDisappear");
        //				PalBattleManager.Instance().m_InvisibleMaterial = (Material)Resources.Load("Material/ChangeMatInvisible");
        //			}
        //			if (PalBattleManager.Instance() == null)
        //			{
        //				return;
        //			}
        //			BattleEventProcessorManager.Instance().Update(currentTime, deltaTime);
        //			if (PalBattleManager.Instance().mShopScript_C_Sharp != null)
        //			{
        //				PalBattleManager.Instance().mShopScript_C_Sharp.OnUpdate();
        //			}
        //			if (PalBattleManager.Instance().mStartScript_C_Sharp != null)
        //			{
        //				PalBattleManager.Instance().mStartScript_C_Sharp.OnUpdate();
        //			}
        //			if (PalBattleManager.Instance().mTitleScript_C_Sharp != null)
        //			{
        //				PalBattleManager.Instance().mTitleScript_C_Sharp.OnUpdate();
        //			}
        //			PalBattleManager.Instance().UpdateMe();
        //		}

        //		// Token: 0x06001263 RID: 4707 RVA: 0x000B4CDC File Offset: 0x000B2EDC
        //		public void AddBattlePlayer(BattlePlayer bp)
        //		{
        //			BattlePlayer battlePlayer = null;
        //			if (this.mBattlePlayers.TryGetValue(bp.BattleID, out battlePlayer))
        //			{
        //				this.mBattlePlayers[bp.BattleID] = bp;
        //			}
        //			else
        //			{
        //				this.mBattlePlayers.Add(bp.BattleID, bp);
        //				this.m_PolarLBI.RegisterBattlePlayer(bp);
        //			}
        //		}

        //		// Token: 0x06001264 RID: 4708 RVA: 0x000B4D38 File Offset: 0x000B2F38
        //		public void ShowDisplayer(bool bShow)
        //		{
        //			this.m_bShowDisplayer = bShow;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.ShowDisplayer(bShow);
        //			}
        //		}

        //		// Token: 0x06001265 RID: 4709 RVA: 0x000B4DAC File Offset: 0x000B2FAC
        //		public void EnableBattleUI(bool bShow)
        //		{
        //			this.m_bEnableBattleUI = bShow;
        //		}

        //		// Token: 0x06001266 RID: 4710 RVA: 0x000B4DB8 File Offset: 0x000B2FB8
        //		public void DebugBattle(int BfID, int MgID)
        //		{
        //			PalNPC component = PlayersManager.ActivePlayers[0].GetComponent<PalNPC>();
        //			this.m_bCommonBattle = true;
        //			this.GoToBattle(component, null, MgID, BfID, false, true, false);
        //		}

        //		// Token: 0x06001267 RID: 4711 RVA: 0x000B4DEC File Offset: 0x000B2FEC
        //		public void ReBattle()
        //		{
        //			this.AddRebattleItemToPack();
        //			for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
        //			{
        //				if (PlayersManager.ActivePlayers[i] != null)
        //				{
        //					PalNPC component = PlayersManager.ActivePlayers[i].GetComponent<PalNPC>();
        //					int hp = 0;
        //					if (this.m_PlayersHP.TryGetValue(component.Data.CharacterID, out hp))
        //					{
        //						component.Data.HPMPDP.HP = hp;
        //					}
        //				}
        //			}
        //			PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.REBATTLE_NUM_10, true);
        //			PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.REBATTLE_NUM_50, true);
        //			this.m_bRebattle = true;
        //			if (this.m_Rebattle_bInPlaceBattle)
        //			{
        //				this.StartBattle(this.m_Rebattle_players, this.m_Rebattle_enemys, this.m_Rebattle_BattleFieldID, this.m_Rebattle_MonsterGroupID, this.m_Rebattle_bInPlaceBattle, true, this.m_Rebattle_bChangeMusic);
        //			}
        //			else
        //			{
        //				this.GoToBattle(this.m_Rebattle_MeNPC, null, this.m_gp, this.m_bid, false, this.m_Rebattle_bChangeMusic, true);
        //			}
        //			this.m_bRebattle = false;
        //		}

        //		// Token: 0x06001268 RID: 4712 RVA: 0x000B4F04 File Offset: 0x000B3104
        //		public void StartBattle(List<PalNPC> players, List<PalNPC> enemys, int BattleFieldID, int MonsterGroupID, bool bInPlaceBattle, bool bStartBattle = false, bool bChangeMusic = true)
        //		{
        //			this.m_CurForceInBattleTime = 0f;
        //			this.m_bFogEnable = false;
        //			this.m_CameraYawClamp = 1f;
        //			this.m_GlobalFog = (Behaviour)Camera.main.GetComponent("GlobalFog");
        //			if (this.m_GlobalFog != null)
        //			{
        //				this.m_bFogEnable = this.m_GlobalFog.enabled;
        //				this.m_GlobalFog.enabled = false;
        //			}
        //			PalProfiler.GetProfiler().Log("StartBattle");
        //			if (players.Count == 2 && ((players[0].Data.CharacterID == 0 && players[1].Data.CharacterID == 1) || (players[1].Data.CharacterID == 0 && players[0].Data.CharacterID == 1)))
        //			{
        //				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.YYZ_YQ_FIGHT, true);
        //			}
        //			if (players.Count == 1)
        //			{
        //				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.SOLO_FIGHT, true);
        //			}
        //			for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
        //			{
        //				bool flag = false;
        //				for (int j = 0; j < players.Count; j++)
        //				{
        //					PalNPC x = players[j];
        //					if (x != null && x == PlayersManager.ActivePlayers[i])
        //					{
        //						flag = true;
        //						break;
        //					}
        //				}
        //				if (!flag)
        //				{
        //					PalNPC component = PlayersManager.ActivePlayers[i].GetComponent<PalNPC>();
        //					if (component != null)
        //					{
        //						component.model.SetActive(false);
        //					}
        //				}
        //			}
        //			GameObject gameObject = PlayersManager.FindMainChar(6, false);
        //			bool flag2 = false;
        //			if (gameObject != null)
        //			{
        //				PalNPC component2 = gameObject.GetComponent<PalNPC>();
        //				if (component2 != null && component2.model != null)
        //				{
        //					flag2 = true;
        //					component2.model.transform.position = Vector3.zero;
        //				}
        //			}
        //			if (!flag2)
        //			{
        //			}
        //			this.m_bScriptWin = false;
        //			this.m_bHDR = Camera.main.hdr;
        //			this.m_CameraRadiusLimit = 99f;
        //			this.m_FixedPlayer.Clear();
        //			this.SetSkipOutBattleResult(false);
        //			this.SetNeverFail(false);
        //			this.m_players = players;
        //			this.m_Rebattle_players = new List<PalNPC>();
        //			for (int k = 0; k < players.Count; k++)
        //			{
        //				this.m_Rebattle_players.Add(players[k]);
        //			}
        //			this.m_monsters = new List<PalNPC>();
        //			for (int l = 0; l < enemys.Count; l++)
        //			{
        //				this.m_monsters.Add(enemys[l]);
        //			}
        //			for (int m = 0; m < enemys.Count; m++)
        //			{
        //				if (enemys[m] == null)
        //				{
        //					Debug.LogError("进入战场的第" + m.ToString() + "个敌人是空");
        //				}
        //			}
        //			this.m_bChangeMusic = bChangeMusic;
        //			Cursor.visible = true;
        //			PalBattleManager.Instance().LoadPreLoadCommonSECache();
        //			this.m_bid = BattleFieldID;
        //			BattleFieldDataManager.BattleFieldData data = this.mBattleFieldDataMgr.GetData(BattleFieldID);
        //			if (data == null)
        //			{
        //				Debug.LogError("战场" + BattleFieldID.ToString() + "在战场表里找不到");
        //			}
        //			if (data != null && data.m_BGM != -1 && this.m_bChangeMusic)
        //			{
        //				BackgroundAudio component3 = PalMain.GameMain.GetComponent<BackgroundAudio>();
        //				this.m_OldAudioClipID = component3.CurMusicID;
        //				this.mOldAnimTime = component3.AnimTime;
        //				component3.ChangeBackMusic(data.m_BGM, 0f, false);
        //			}
        //			PlayerCtrlManager.bControl = false;
        //			this.m_BattleTime = 0f;
        //			this.m_NumberEnemyDie = 0;
        //			foreach (GameObject gameObject2 in PlayersManager.ActivePlayers)
        //			{
        //				PalNPC component4 = gameObject2.GetComponent<PalNPC>();
        //				if (component4.Data.HPMPDP.HP < 1)
        //				{
        //					component4.Data.HPMPDP.HP = 1;
        //				}
        //			}
        //			for (int n = 0; n < PlayersManager.ActivePlayers.Count; n++)
        //			{
        //				if (PlayersManager.ActivePlayers[n] != null)
        //				{
        //					PalNPC component5 = PlayersManager.ActivePlayers[n].GetComponent<PalNPC>();
        //					this.m_PlayersHP[component5.Data.CharacterID] = component5.Data.HPMPDP.HP;
        //				}
        //			}
        //			this.m_Rebattle_enemys = new List<PalNPC>();
        //			for (int num = 0; num < enemys.Count; num++)
        //			{
        //				this.m_Rebattle_enemys.Add(enemys[num]);
        //			}
        //			this.m_Rebattle_BattleFieldID = BattleFieldID;
        //			this.m_Rebattle_MonsterGroupID = MonsterGroupID;
        //			this.m_Rebattle_bInPlaceBattle = bInPlaceBattle;
        //			this.m_Rebattle_bChangeMusic = bChangeMusic;
        //			this.m_VisibleBP.Clear();
        //			this.m_Money = 0;
        //			this.m_YuanShen = 0;
        //			this.m_Exp = 0;
        //			this.m_Items.Clear();
        //			this.m_UpgradeList.Clear();
        //			this.SyncBattleFormation();
        //			this.ReWriteBattleFormation(players);
        //			BattleFormationManager.BattleFormationData currentFormation = this.m_BattleFormation.GetCurrentFormation();
        //			if (currentFormation == null)
        //			{
        //				Debug.LogError("Formation data is null");
        //			}
        //			int num2 = 0;
        //			while (num2 < currentFormation.m_InFormationCharaDatas.Count && num2 < 4 && num2 < currentFormation.m_InFormationCharaDatas.Count)
        //			{
        //				foreach (GameObject gameObject3 in PlayersManager.ActivePlayers)
        //				{
        //					PalNPC component6 = gameObject3.GetComponent<PalNPC>();
        //					if (component6.Data.CharacterID == currentFormation.m_InFormationCharaDatas[num2].m_CharacterID)
        //					{
        //						component6.SetSkillGroup(currentFormation.m_InFormationCharaDatas[num2].m_CharacterSkillGroup);
        //					}
        //				}
        //				num2++;
        //			}
        //			this.m_CurrentMonsterGroup = MonsterGroupID;
        //			MonsterGroupDataManager.MonsterGroupData data2 = PalBattleManager.Instance().GetMonsterGroupDataManager().GetData(MonsterGroupID);
        //			if (data2 == null)
        //			{
        //				Debug.LogError("怪物组" + data2.ToString() + "在怪物组表里找不到");
        //			}
        //			this.m_CamCullingMask = Camera.main.cullingMask;
        //			if (data != null)
        //			{
        //				this.m_PolarLBI.Init(new Vector3(data.mCenterX, data.mHeight, data.mCenterY), data.m_MaxIdleDist);
        //			}
        //			for (int num3 = 0; num3 < players.Count; num3++)
        //			{
        //				if (players[num3].Data.CharacterID == 4)
        //				{
        //					GameObject gameObject4 = PlayersManager.FindMainChar(6, false);
        //					PalNPC component7 = gameObject4.GetComponent<PalNPC>();
        //					this.m_JGXModel = component7.model;
        //					WeaponItem weaponItem = players[num3].GetSlot(EquipSlotEnum.Weapon) as WeaponItem;
        //					if (weaponItem != null)
        //					{
        //						players.Add(gameObject4.GetComponent<PalNPC>());
        //						GameObject model = players[num3].model;
        //						GameObject jgxmodel = this.m_JGXModel;
        //						Agent component8 = model.GetComponent<Agent>();
        //						Agent component9 = jgxmodel.GetComponent<Agent>();
        //						component9.palNPC = component7;
        //						component7.model = jgxmodel;
        //						PalNPC palNPC = players[num3];
        //						PalNPC palNPC2 = component7;
        //						palNPC2.model = model;
        //						palNPC.model = jgxmodel;
        //						component8.palNPC = palNPC2;
        //						component9.palNPC = palNPC;
        //						Vector3 localPosition = model.transform.localPosition;
        //						Quaternion localRotation = model.transform.localRotation;
        //						model.transform.parent = palNPC2.transform;
        //						jgxmodel.transform.parent = palNPC.transform;
        //						float f = UnityEngine.Random.Range(-3.1415927f, 3.1415927f);
        //						jgxmodel.transform.localPosition = localPosition + new Vector3(1f * Mathf.Sin(f), 0f, 1f * Mathf.Cos(f));
        //						jgxmodel.transform.localRotation = localRotation;
        //					}
        //					else
        //					{
        //						Debug.LogError("居士方没有装备武器");
        //						players.RemoveAt(num3);
        //					}
        //					break;
        //				}
        //			}
        //			BattlePlayer battlePlayer = null;
        //			BattlePlayer battlePlayer2 = null;
        //			List<Vector3> list = new List<Vector3>();
        //			List<Vector3> list2 = new List<Vector3>();
        //			for (int num4 = 0; num4 < players.Count; num4++)
        //			{
        //				if (players[num4].model.activeSelf)
        //				{
        //					this.m_VisibleBP.Add(players[num4].Data.CharacterID);
        //				}
        //				GameObject model2 = players[num4].model;
        //				model2.SetActive(true);
        //				LateSetActive.Init(model2, true, 0.01f);
        //				BattlePlayer battlePlayer3 = players[num4].model.AddComponent<BattlePlayer>();
        //				battlePlayer3.gameObject.SetVisible(true);
        //				battlePlayer3.m_bDontDestroy = true;
        //				battlePlayer3.m_BeforeBattlePos = players[num4].model.transform.position;
        //				battlePlayer3.m_BeforeBattleRot = players[num4].model.transform.rotation;
        //				battlePlayer3.SetNPC(players[num4]);
        //				if (bInPlaceBattle)
        //				{
        //					if (num4 == 0)
        //					{
        //						battlePlayer3.m_bInPlaceLeader = true;
        //					}
        //					battlePlayer3.m_bUseOrigin = true;
        //					Vector3 zero = Vector3.zero;
        //					zero.x = data.mCenterX;
        //					zero.z = data.mCenterY;
        //					Vector3 position = players[num4].model.transform.position;
        //					position.y = 0f;
        //					list.Add(position);
        //					float num5 = Vector3.Distance(zero, position);
        //					if (num5 > 30f)
        //					{
        //						int x2;
        //						if (num4 >= data2.mPlayer_posX.Count)
        //						{
        //							x2 = data2.mPlayer_posX[0];
        //						}
        //						else
        //						{
        //							x2 = data2.mPlayer_posX[num4];
        //						}
        //						int y;
        //						if (num4 >= data2.mPlayer_posY.Count)
        //						{
        //							y = data2.mPlayer_posY[0];
        //						}
        //						else
        //						{
        //							y = data2.mPlayer_posY[num4];
        //						}
        //						float x3;
        //						float z;
        //						this.m_PolarLBI.IntToFloat(x2, y, out x3, out z);
        //						Vector3 vector;
        //						vector.x = x3;
        //						vector.z = z;
        //						vector.y = this.m_PolarLBI.GetCenter().y;
        //						battlePlayer3.SetDest(vector);
        //						battlePlayer3.SetPlayerTranslation(vector, battlePlayer3.transform.rotation);
        //					}
        //				}
        //				else
        //				{
        //					battlePlayer3.m_bUseOrigin = false;
        //					int x4;
        //					if (num4 >= data2.mPlayer_posX.Count)
        //					{
        //						x4 = data2.mPlayer_posX[0];
        //					}
        //					else
        //					{
        //						x4 = data2.mPlayer_posX[num4];
        //					}
        //					int y2;
        //					if (num4 >= data2.mPlayer_posY.Count)
        //					{
        //						y2 = data2.mPlayer_posY[0];
        //					}
        //					else
        //					{
        //						y2 = data2.mPlayer_posY[num4];
        //					}
        //					float x5;
        //					float z2;
        //					this.m_PolarLBI.IntToFloat(x4, y2, out x5, out z2);
        //					Vector3 vector2;
        //					vector2.x = x5;
        //					vector2.z = z2;
        //					vector2.y = this.m_PolarLBI.GetCenter().y;
        //					battlePlayer3.SetDest(vector2);
        //					battlePlayer3.SetPlayerTranslation(vector2, battlePlayer3.transform.rotation);
        //					list.Add(vector2);
        //				}
        //				if (players[num4].Data.CharacterID == 4)
        //				{
        //					battlePlayer2 = battlePlayer3;
        //				}
        //				if (players[num4].Data.CharacterID == 6)
        //				{
        //					battlePlayer = battlePlayer3;
        //				}
        //			}
        //			if (battlePlayer2 != null && battlePlayer != null)
        //			{
        //				battlePlayer.SetFollowTarget(battlePlayer2);
        //				battlePlayer2.SetFollower(battlePlayer);
        //			}
        //			for (int num6 = 0; num6 < enemys.Count; num6++)
        //			{
        //				enemys[num6].Start();
        //				if (enemys[num6].model != null && enemys[num6].model.activeSelf)
        //				{
        //					this.m_VisibleBP.Add(enemys[num6].Data.CharacterID);
        //				}
        //				BattlePlayer battlePlayer4 = enemys[num6].model.gameObject.AddComponent<BattlePlayer>();
        //				enemys[num6].model.gameObject.SetActive(true);
        //				enemys[num6].gameObject.SetActive(true);
        //				battlePlayer4.SetNPC(enemys[num6]);
        //				if (bInPlaceBattle)
        //				{
        //					battlePlayer4.m_bDontDestroy = true;
        //					battlePlayer4.m_BeforeBattlePos = enemys[num6].model.transform.position;
        //					battlePlayer4.m_BeforeBattleRot = enemys[num6].model.transform.rotation;
        //					battlePlayer4.m_bUseOrigin = true;
        //					Vector3 zero2 = Vector3.zero;
        //					zero2.x = data.mCenterX;
        //					zero2.z = data.mCenterY;
        //					Vector3 position2 = enemys[num6].model.transform.position;
        //					position2.y = 0f;
        //					float num7 = Vector3.Distance(zero2, position2);
        //					if (num7 > 70f)
        //					{
        //						enemys[num6].model.transform.position = zero2;
        //						position2 = enemys[num6].model.transform.position;
        //					}
        //					list2.Add(position2);
        //				}
        //				else
        //				{
        //					battlePlayer4.m_bDontDestroy = false;
        //					battlePlayer4.m_bUseOrigin = false;
        //					if (num6 >= data2.mMonster_posX.Count || num6 >= data2.mMonster_posY.Count)
        //					{
        //						Debug.LogError("怪物组" + MonsterGroupID.ToString() + "站位数量不足");
        //					}
        //					float x6;
        //					float z3;
        //					this.m_PolarLBI.IntToFloat(data2.mMonster_posX[(num6 + data2.mMonster_posX.Count) % data2.mMonster_posX.Count], data2.mMonster_posY[(num6 + data2.mMonster_posY.Count) % data2.mMonster_posY.Count], out x6, out z3);
        //					Vector3 vector3;
        //					vector3.x = x6;
        //					vector3.z = z3;
        //					vector3.y = this.m_PolarLBI.GetCenter().y;
        //					battlePlayer4.SetDest(vector3);
        //					list2.Add(vector3);
        //				}
        //				battlePlayer4.Start();
        //			}
        //			SmoothFollow2 component10 = Camera.main.GetComponent<SmoothFollow2>();
        //			if (component10 != null)
        //			{
        //				component10.enabled = false;
        //			}
        //			BattleCameraController battleCameraController = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //			if (battleCameraController == null)
        //			{
        //				battleCameraController = Camera.main.gameObject.AddComponent<BattleCameraController>();
        //				battleCameraController.Start();
        //			}
        //			battleCameraController.SetYawClamp(data2.mCameraClampRadian);
        //			this.SetFixBattleDirection(data2.mFixSidePos != 0);
        //			this.m_PolarLBI.SetFirendRadian(this.m_PolarLBI.CalculateFriendRadianByPos(list.ToArray(), list2.ToArray()));
        //			this.CalculateOffset(list, list2);
        //			this.mLossScript_C_Sharp = null;
        //			if (data2.mLossScriptID != -1)
        //			{
        //				this.mLossScript_C_Sharp = (BattleMonsterGroupLoss)this.mBattleScriptMgr.InitializeScript_C_Sharp(BattleScriptManager.SCRIPT_TYPE.MONSTER_GROUP_SCRIPT_LOSS, data2.mLossScriptID);
        //			}
        //			this.mShopScript_C_Sharp = null;
        //			if (data2.mShopScriptID != -1)
        //			{
        //				this.mShopScript_C_Sharp = (BattleMonsterGroupShop)this.mBattleScriptMgr.InitializeScript_C_Sharp(BattleScriptManager.SCRIPT_TYPE.MONSTER_GROUP_SCRIPT_SHOP, data2.mShopScriptID);
        //			}
        //			this.mStartScript_C_Sharp = null;
        //			if (data2.mStartScriptID != -1)
        //			{
        //				this.mStartScript_C_Sharp = (BattleMonsterGroupStart)this.mBattleScriptMgr.InitializeScript_C_Sharp(BattleScriptManager.SCRIPT_TYPE.MONSTER_GROUP_SCRIPT_START, data2.mStartScriptID);
        //			}
        //			this.mTitleScript_C_Sharp = null;
        //			if (data2.mTitleScriptID != -1)
        //			{
        //				this.mTitleScript_C_Sharp = (BattleMonsterGroupTitle)this.mBattleScriptMgr.InitializeScript_C_Sharp(BattleScriptManager.SCRIPT_TYPE.MONSTER_GROUP_SCRIPT_TITLE, data2.mTitleScriptID);
        //			}
        //			this.mWinScript_C_Sharp = null;
        //			if (data2.mWinScriptID != -1)
        //			{
        //				this.mWinScript_C_Sharp = (BattleMonsterGroupWin)this.mBattleScriptMgr.InitializeScript_C_Sharp(BattleScriptManager.SCRIPT_TYPE.MONSTER_GROUP_SCRIPT_WIN, data2.mWinScriptID);
        //			}
        //			SmoothFollow2 component11 = Camera.main.GetComponent<SmoothFollow2>();
        //			if (component11 != null)
        //			{
        //				component11.enabled = false;
        //			}
        //			float value = UnityEngine.Random.value;
        //			if (GameStateManager.CurGameState != GameState.Battle)
        //			{
        //				GameStateManager.CurGameState = GameState.Battle;
        //			}
        //			this.SaveCameraParam();
        //			this.m_bRandomTask = false;
        //			if (!bInPlaceBattle && this.m_BattlePalNPC != null && this.m_BattlePalNPC.Data != null && this.m_BattlePalNPC.Data.SocialNPC != null && value > this.m_BattlePalNPC.Data.SocialNPC.m_RandomBattleTask)
        //			{
        //				this.m_bRandomTask = true;
        //				float num8 = PalBattleManager.Instance().m_RandomTask.m_Times[0];
        //				float num9 = PalBattleManager.Instance().m_RandomTask.m_rewards[0];
        //				float num10 = PalBattleManager.Instance().m_RandomTask.m_Times[1];
        //				float num11 = PalBattleManager.Instance().m_RandomTask.m_rewards[1];
        //				float num12 = PalBattleManager.Instance().m_RandomTask.m_Times[2];
        //				float num13 = PalBattleManager.Instance().m_RandomTask.m_rewards[2];
        //				PalBattleManager.Instance().SetBattleState(PalBattleManager.BATTLE_STATE.PAUSE_BATTLE);
        //				if (Langue.get_string(10031645UL, "UI") == null)
        //				{
        //					Debug.LogError("战斗随机任务 多语言 10031645 字符没有找到");
        //				}
        //				string text = string.Concat(new string[]
        //				{
        //					string.Format(Langue.get_string(10031645UL, "UI"), num8.ToString(), num9.ToString()),
        //					"<br/>",
        //					string.Format(Langue.get_string(10031645UL, "UI"), num10, num11),
        //					"<br/>",
        //					string.Format(Langue.get_string(10031645UL, "UI"), num12, num13),
        //					"<br/>"
        //				});
        //				UIDialogManager.Instance.ShowForceInfoDialog(text, delegate
        //				{
        //					PalBattleManager.Instance().SetBattleState(PalBattleManager.BATTLE_STATE.RESUME_BATTLE);
        //				});
        //			}
        //			else
        //			{
        //				PalBattleManager.Instance().SetBattleState(PalBattleManager.BATTLE_STATE.RESUME_BATTLE);
        //			}
        //			this.ClearPalSEs();
        //			this.mNewTPASystem.AddTPA(0, 0f);
        //			foreach (GameObject gameObject5 in PlayersManager.AllPlayers)
        //			{
        //				try
        //				{
        //					if (gameObject5 != null)
        //					{
        //						PalNPC component12 = gameObject5.GetComponent<PalNPC>();
        //						if (component12 != null)
        //						{
        //							SymbolPanelItem symbolPanelItem = component12.GetSlot(EquipSlotEnum.SymbolPanel) as SymbolPanelItem;
        //							bool weaponEffect = symbolPanelItem != null && symbolPanelItem.IsPerfect();
        //							if (symbolPanelItem != null)
        //							{
        //								symbolPanelItem.SetWeaponEffect(weaponEffect);
        //							}
        //						}
        //					}
        //				}
        //				catch (Exception exception)
        //				{
        //					Debug.LogException(exception);
        //				}
        //			}
        //		}

        //		// Token: 0x06001269 RID: 4713 RVA: 0x000B625C File Offset: 0x000B445C
        //		public void EndBattle(bool bRebattle)
        //		{
        //			foreach (GameObject gameObject in PlayersManager.AllPlayers)
        //			{
        //				try
        //				{
        //					if (gameObject != null)
        //					{
        //						PalNPC component = gameObject.GetComponent<PalNPC>();
        //						if (component != null)
        //						{
        //							SymbolPanelItem symbolPanelItem = component.GetSlot(EquipSlotEnum.SymbolPanel) as SymbolPanelItem;
        //							if (symbolPanelItem != null)
        //							{
        //								symbolPanelItem.SetWeaponEffect(false);
        //							}
        //						}
        //					}
        //				}
        //				catch (Exception exception)
        //				{
        //					Debug.LogException(exception);
        //				}
        //			}
        //			if (PalBattleManager.Instance().mStartScript_C_Sharp != null)
        //			{
        //				PalBattleManager.Instance().mStartScript_C_Sharp.OnEnd();
        //			}
        //			if (this.m_GlobalFog != null)
        //			{
        //				this.m_GlobalFog.enabled = this.m_bFogEnable;
        //			}
        //			this.ResetExpression();
        //			this.m_bEnterBattle = false;
        //			this.m_bRandomTask = false;
        //			Camera.main.cullingMask = this.m_CamCullingMask;
        //			GameObject gameObject2 = GameObject.FindGameObjectWithTag("zhanchang");
        //			if (gameObject2 != null)
        //			{
        //				gameObject2.transform.GetChild(0).gameObject.SetActive(false);
        //			}
        //			this.m_QiXiHP = 1f;
        //			PlayersManager.Player.GetModelObj(false).SetActive(true);
        //			PlayersManager.Player.SetActive(true);
        //			GameObject modelObj = PlayersManager.Player.GetModelObj(false);
        //			AnimCtrlScript component2 = modelObj.GetComponent<AnimCtrlScript>();
        //			component2.ActiveZhanDou(false, 1, true, true, true);
        //			foreach (GameObject gameObject3 in PlayersManager.ActivePlayers)
        //			{
        //				PalNPC component3 = gameObject3.GetComponent<PalNPC>();
        //				if (component3 != null && component3.Data.HPMPDP.HP <= 0)
        //				{
        //					component3.Data.HPMPDP.HP = 1;
        //				}
        //				if (component3.model != null && component3.gameObject != null)
        //				{
        //					component3.gameObject.transform.localScale = Vector3.one;
        //					if (component3.model != null)
        //					{
        //						component3.model.transform.localScale = Vector3.one;
        //					}
        //				}
        //			}
        //			GameStateManager.CurGameState = GameState.Normal;
        //			if (this.mExitBattleFunc != null)
        //			{
        //				this.mExitBattleFunc();
        //			}
        //			SmoothFollow2 component4 = Camera.main.GetComponent<SmoothFollow2>();
        //			component4.enabled = true;
        //			this.LoadCameraParam();
        //			PalBattleManager.Instance().UnloadCommonSE();
        //			this.ClearPalSEs();
        //			PalMain.UnloadUnusedAssets(PalMain.UNLOADPROIR.LONG);
        //			MovieClipPlayer.clearContextCache(true);
        //			if (!bRebattle && this.mDramaBattleEndFunc != null)
        //			{
        //				this.mDramaBattleEndFunc();
        //			}
        //			this.m_bEnableGoToBattle = true;
        //			if (this.m_BattlePalNPC != null)
        //			{
        //				if (this.GetBattleState() != PalBattleManager.BATTLE_STATE.POST_BATTLE && this.GetBattleState() != PalBattleManager.BATTLE_STATE.LOSS_BATTLE)
        //				{
        //					this.m_BattlePalNPC.model.SetActive(false);
        //					BattleEvent component5 = this.m_BattlePalNPC.model.GetComponent<BattleEvent>();
        //					if (component5 != null && component5.OnBattleWin != null)
        //					{
        //						component5.OnBattleWin();
        //					}
        //				}
        //				ReSpawnMonster.Begin(this.m_BattlePalNPC.gameObject);
        //				TriggerBattleSleeper orAddComponent = this.m_BattlePalNPC.gameObject.GetOrAddComponent<TriggerBattleSleeper>();
        //				if (orAddComponent != null)
        //				{
        //					orAddComponent.DestroyCountDown();
        //				}
        //			}
        //			else if (this.m_Rebattle_enemys != null)
        //			{
        //				for (int i = 0; i < this.m_Rebattle_enemys.Count; i++)
        //				{
        //					PalNPC palNPC = this.m_Rebattle_enemys[i];
        //					if (palNPC != null)
        //					{
        //						palNPC.RemoveDisCull();
        //					}
        //				}
        //			}
        //			this.m_BattlePalNPC = null;
        //			BattleFieldDataManager.BattleFieldData data = this.mBattleFieldDataMgr.GetData(this.m_Rebattle_BattleFieldID);
        //			if (data != null && data.m_BGM != -1 && this.m_bChangeMusic)
        //			{
        //				BackgroundAudio component6 = PalMain.GameMain.GetComponent<BackgroundAudio>();
        //				component6.AnimTime = this.mOldAnimTime;
        //				component6.ChangeBackMusicImmediate(this.m_OldAudioClipID);
        //			}
        //		}

        //		// Token: 0x0600126A RID: 4714 RVA: 0x000B66C4 File Offset: 0x000B48C4
        //		protected List<PalNPC> GetMonsterList(int MonsterGroupID)
        //		{
        //			PalBattleManager palBattleManager = PalBattleManager.Instance();
        //			if (palBattleManager == null)
        //			{
        //				Debug.LogError("Error : GetMonsterList PalBattleManager.Instance () == null");
        //				return null;
        //			}
        //			MonsterGroupDataManager monsterGroupDataManager = palBattleManager.GetMonsterGroupDataManager();
        //			if (monsterGroupDataManager == null)
        //			{
        //				Debug.LogError("Error : GetMonsterList GetMonsterGroupDataManager () == null");
        //				return null;
        //			}
        //			MonsterGroupDataManager.MonsterGroupData data = monsterGroupDataManager.GetData(MonsterGroupID);
        //			if (data == null)
        //			{
        //				Debug.LogError("Error : GetMonsterList monsterGroupDataManager.GetData(" + MonsterGroupID.ToString() + ") == null");
        //				return null;
        //			}
        //			List<PalNPC> list = new List<PalNPC>();
        //			for (int i = 0; i < data.mMonsters.Count; i++)
        //			{
        //				GameObject gameObject = null;
        //				string text = "Template/Character/" + data.mMonsters[i].ToString();
        //				GameObject gameObject2 = FileLoader.LoadObjectFromFile<GameObject>(text.ToAssetBundlePath(), true, true);
        //				if (gameObject2 != null)
        //				{
        //					gameObject = gameObject2;
        //				}
        //				if (gameObject == null)
        //				{
        //					string message = string.Concat(new string[]
        //					{
        //						"Error : 严重错误！！！！怪物组",
        //						MonsterGroupID.ToString(),
        //						"怪物",
        //						text,
        //						"找不到"
        //					});
        //					Debug.LogError(message);
        //					Debug.LogError(message);
        //				}
        //				else
        //				{
        //					PalNPC component = gameObject.GetComponent<PalNPC>();
        //					list.Add(component);
        //				}
        //			}
        //			return list;
        //		}

        //		// Token: 0x0600126B RID: 4715 RVA: 0x000B6800 File Offset: 0x000B4A00
        //		public void GoToBattleWithCameraMotion(PalNPC MeNPC, PalNPC OtherNPC, bool bQiXi = false)
        //		{
        //			this.m_bCommonBattle = true;
        //			this.m_bEnterBattle = true;
        //			GameObject gameObject = OtherNPC.gameObject;
        //			MonsterStateScript.PushState(gameObject, MonsterStateScript.MonsterState.None);
        //			Interact orAddComponent = gameObject.GetOrAddComponent<Interact>();
        //			orAddComponent.SendMessageToBehaviour("stroll", "Pause");
        //			if (this.m_BattleCoolDown > 0f)
        //			{
        //				Debug.LogError("短时间内触发多次战斗，应该是有错误");
        //				return;
        //			}
        //			this.m_BattleCoolDown = 2f;
        //			uScriptCode component = OtherNPC.GetComponent<uScriptCode>();
        //			if (component != null)
        //			{
        //				component.enabled = false;
        //			}
        //			if (bQiXi)
        //			{
        //				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_1, true);
        //				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_50, true);
        //				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_100, true);
        //				GameObject gameObject2 = FileLoader.LoadObjectFromFile<GameObject>(FileLoader.BaoDian.ToAssetBundlePath(), true, true);
        //				if (gameObject2 != null)
        //				{
        //					Vector3 vector = MeNPC.model.transform.position - OtherNPC.model.transform.position;
        //					vector.Normalize();
        //					Vector3 pos = OtherNPC.model.transform.position + vector * 0.5f;
        //					pos.y = MeNPC.model.transform.position.y + 1.5f;
        //					UtilFun.SetPosition(gameObject2.transform, pos);
        //					gameObject2.transform.forward = vector;
        //					UnityEngine.Object.Destroy(gameObject2, 3f);
        //				}
        //				else
        //				{
        //					Debug.LogError("Error : Assets/Pal_Resources/Effects/SystemEffects/MT/EXMT_P_baodian.prefab 读取失败");
        //				}
        //			}
        //			InBattleCameraPerfomer inBattleCameraPerfomer = MeNPC.model.gameObject.AddComponent<InBattleCameraPerfomer>();
        //			this.m_RebattleQiXi = bQiXi;
        //			this.bEnableGoToBattle = false;
        //			inBattleCameraPerfomer.Init(MeNPC, OtherNPC, Camera.main, bQiXi);
        //			this.m_BattlePalNPC = OtherNPC;
        //		}

        //		// Token: 0x0600126C RID: 4716 RVA: 0x000B69C0 File Offset: 0x000B4BC0
        //		public bool QiXi(PalNPC MeNPC, PalNPC OtherNPC)
        //		{
        //			float num = (float)(MeNPC.Data.Level - OtherNPC.Data.SocialNPC.Level) * 7f / 110f + 0.3f;
        //			if (num <= 0f)
        //			{
        //				this.m_QiXiHP = 1f;
        //				return true;
        //			}
        //			if (num > 0f && num < 1f)
        //			{
        //				this.m_QiXiHP = 1f - num;
        //				return true;
        //			}
        //			this.m_QiXiHP = 1f;
        //			this.DirectWin(OtherNPC);
        //			this.m_bEnterBattle = false;
        //			return false;
        //		}

        //		// Token: 0x0600126D RID: 4717 RVA: 0x000B6A54 File Offset: 0x000B4C54
        //		public void GoToBattle(PalNPC MeNPC, PalNPC OtherNPC, int monsterGroupID, int BattleFieldID, bool bFixPlayer, bool bChangeMusic, bool bFromRebattle = false)
        //		{
        //			this.m_bChangeMusic = bChangeMusic;
        //			this.m_Rebattle_MeNPC = MeNPC;
        //			this.m_Rebattle_OtherNPC = OtherNPC;
        //			this.SyncBattleFormation();
        //			BattleFormationManager.BattleFormationData currentFormation = this.m_BattleFormation.GetCurrentFormation();
        //			if (currentFormation == null)
        //			{
        //				Debug.LogError("Formation data is null");
        //			}
        //			List<PalNPC> list = new List<PalNPC>();
        //			if (!bFixPlayer)
        //			{
        //				int num = 0;
        //				while (num < currentFormation.m_InFormationCharaDatas.Count && num < 4 && num < currentFormation.m_InFormationCharaDatas.Count - currentFormation.m_Store)
        //				{
        //					foreach (GameObject gameObject in PlayersManager.ActivePlayers)
        //					{
        //						PalNPC component = gameObject.GetComponent<PalNPC>();
        //						if (component.Data.CharacterID == currentFormation.m_InFormationCharaDatas[num].m_CharacterID)
        //						{
        //							component.SetSkillGroup(currentFormation.m_InFormationCharaDatas[num].m_CharacterSkillGroup);
        //							list.Add(component);
        //						}
        //					}
        //					num++;
        //				}
        //			}
        //			else
        //			{
        //				int num2 = 0;
        //				while (num2 < currentFormation.m_InFormationCharaDatas.Count && num2 < 4 && num2 < currentFormation.m_InFormationCharaDatas.Count)
        //				{
        //					foreach (GameObject gameObject2 in PlayersManager.ActivePlayers)
        //					{
        //						PalNPC component2 = gameObject2.GetComponent<PalNPC>();
        //						if (component2.Data.CharacterID == currentFormation.m_InFormationCharaDatas[num2].m_CharacterID)
        //						{
        //							component2.SetSkillGroup(currentFormation.m_InFormationCharaDatas[num2].m_CharacterSkillGroup);
        //							list.Add(component2);
        //						}
        //					}
        //					num2++;
        //				}
        //			}
        //			if (!bFromRebattle)
        //			{
        //				this.m_Rebattle_players = new List<PalNPC>();
        //				for (int i = 0; i < list.Count; i++)
        //				{
        //					this.m_Rebattle_players.Add(list[i]);
        //				}
        //			}
        //			int num4;
        //			if (monsterGroupID == -1)
        //			{
        //				if (OtherNPC.MonsterGroups.Length == 0)
        //				{
        //					Debug.LogError(OtherNPC.ToString() + "怪物组数量为0,不触发战斗！");
        //					return;
        //				}
        //				int num3 = UnityEngine.Random.Range(0, OtherNPC.MonsterGroups.Length);
        //				num4 = OtherNPC.MonsterGroups[num3];
        //			}
        //			else
        //			{
        //				num4 = monsterGroupID;
        //			}
        //			List<PalNPC> monsterList = this.GetMonsterList(num4);
        //			Vector3 vector = Vector3.one;
        //			if (OtherNPC != null)
        //			{
        //				vector = MeNPC.model.transform.position - OtherNPC.model.transform.position;
        //			}
        //			vector.Normalize();
        //			vector *= 0.5f;
        //			if (this.m_bRebattle)
        //			{
        //				vector = Vector3.zero;
        //			}
        //			this.m_AvoidBattleAgainPos = MeNPC.model.transform.position + vector;
        //			this.m_unfinishLoadingCount = 0;
        //			for (int j = 0; j < monsterList.Count; j++)
        //			{
        //				if (monsterList[j].model == null)
        //				{
        //					this.m_unfinishLoadingCount++;
        //					PalNPC palNPC = monsterList[j];
        //					palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(this.OnFinishLoadingOnEnemy));
        //				}
        //			}
        //			if (this.m_unfinishLoadingCount == 0)
        //			{
        //				if (BattleFieldID != -1)
        //				{
        //					if (this.m_bCommonBattle)
        //					{
        //						this.StartBattle(list, monsterList, BattleFieldID, num4, false, this.m_bChangeMusic, true);
        //					}
        //					else
        //					{
        //						this.StartBattle(this.m_Rebattle_players, monsterList, BattleFieldID, num4, false, this.m_bChangeMusic, true);
        //					}
        //				}
        //				else if (this.m_bCommonBattle)
        //				{
        //					this.StartBattle(list, monsterList, OtherNPC.mBattleFieldID, num4, false, this.m_bChangeMusic, true);
        //				}
        //				else
        //				{
        //					this.StartBattle(this.m_Rebattle_players, monsterList, OtherNPC.mBattleFieldID, num4, false, this.m_bChangeMusic, true);
        //				}
        //			}
        //			else
        //			{
        //				this.m_players = list;
        //				this.m_monsters = monsterList;
        //				this.m_gp = num4;
        //				if (BattleFieldID != -1)
        //				{
        //					this.m_bid = BattleFieldID;
        //				}
        //				else
        //				{
        //					this.m_bid = OtherNPC.mBattleFieldID;
        //				}
        //			}
        //		}

        //		// Token: 0x0600126E RID: 4718 RVA: 0x000B6EC4 File Offset: 0x000B50C4
        //		public void DirectWin(PalNPC OtherNPC)
        //		{
        //			this.m_Money = 0;
        //			this.m_YuanShen = 0;
        //			this.m_Exp = 0;
        //			this.m_Items.Clear();
        //			OtherNPC.model.GetComponent<Animator>().CrossFade("BeiJiFei", 0.3f);
        //			DelayInactiver delayInactiver = OtherNPC.model.AddComponent<DelayInactiver>();
        //			delayInactiver.m_Timer = 2.4f;
        //			MaterialChanger materialChanger = OtherNPC.model.AddComponent<MaterialChanger>();
        //			materialChanger.Start();
        //			materialChanger.ChangeMaterial(PalBattleManager.Instance().m_DisappearMaterial, 2f, false, 0.5f);
        //			BattleEvent component = OtherNPC.model.GetComponent<BattleEvent>();
        //			if (component != null && component.OnBattleWin != null)
        //			{
        //				component.OnBattleWin();
        //			}
        //			ReSpawnMonster.Begin(OtherNPC.gameObject);
        //			TriggerBattleSleeper orAddComponent = OtherNPC.gameObject.GetOrAddComponent<TriggerBattleSleeper>();
        //			if (orAddComponent != null)
        //			{
        //				orAddComponent.m_Time = 7.5f;
        //				orAddComponent.DestroyCountDown();
        //			}
        //			if (OtherNPC.MonsterGroups.Length == 0)
        //			{
        //				Debug.LogError(OtherNPC.ToString() + "怪物组数量为0,不触发战斗！");
        //				return;
        //			}
        //			int num = UnityEngine.Random.Range(0, OtherNPC.MonsterGroups.Length);
        //			int monsterGroupID = OtherNPC.MonsterGroups[num];
        //			List<PalNPC> monsterList = this.GetMonsterList(monsterGroupID);
        //			for (int i = 0; i < monsterList.Count; i++)
        //			{
        //				monsterList[i].SetDontLoadModel(true);
        //				monsterList[i].Start();
        //				this.GetAward(monsterList[i]);
        //			}
        //			for (int j = 0; j < monsterList.Count; j++)
        //			{
        //				UnityEngine.Object.Destroy(monsterList[j].gameObject);
        //			}
        //			this.AddMoneyToGame();
        //			this.AddExpToGame();
        //			this.AddYuanShenToGame();
        //			this.AddItemsToGame();
        //		}

        //		// Token: 0x0600126F RID: 4719 RVA: 0x000B7088 File Offset: 0x000B5288
        //		public BattlePlayer GetBattlePlayerByBattleID(int battleID)
        //		{
        //			BattlePlayer result = null;
        //			this.mBattlePlayers.TryGetValue(battleID, out result);
        //			return result;
        //		}

        //		// Token: 0x06001270 RID: 4720 RVA: 0x000B70A8 File Offset: 0x000B52A8
        //		public List<int> GetFactionList(int faction)
        //		{
        //			List<int> list = new List<int>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction == (BattlePlayer.FACTION)faction && keyValuePair.Value.GetFollowTarget() == null)
        //				{
        //					list.Add(keyValuePair.Key);
        //				}
        //			}
        //			return list;
        //		}

        //		// Token: 0x06001271 RID: 4721 RVA: 0x000B7144 File Offset: 0x000B5344
        //		public List<int> GetFactionListForScript(int faction, bool SkipDie)
        //		{
        //			List<int> list = new List<int>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction == (BattlePlayer.FACTION)faction && keyValuePair.Value.GetFollowTarget() == null)
        //				{
        //					if (!SkipDie || !keyValuePair.Value.IsDie())
        //					{
        //						list.Add(keyValuePair.Key);
        //					}
        //				}
        //			}
        //			return list;
        //		}

        //		// Token: 0x06001272 RID: 4722 RVA: 0x000B71FC File Offset: 0x000B53FC
        //		public List<int> GetAllIDList()
        //		{
        //			List<int> list = new List<int>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				list.Add(keyValuePair.Key);
        //			}
        //			return list;
        //		}

        //		// Token: 0x06001273 RID: 4723 RVA: 0x000B7270 File Offset: 0x000B5470
        //		public List<BattlePlayer> GetAllBattlePlayers()
        //		{
        //			List<BattlePlayer> list = new List<BattlePlayer>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				list.Add(keyValuePair.Value);
        //			}
        //			return list;
        //		}

        //		// Token: 0x06001274 RID: 4724 RVA: 0x000B72E4 File Offset: 0x000B54E4
        //		public int Login(int id, int xIndex, int yIndex)
        //		{
        //			return 1;
        //		}

        //		// Token: 0x06001275 RID: 4725 RVA: 0x000B72E8 File Offset: 0x000B54E8
        //		public void AssignSkillToBattlePlayer(BattlePlayer bp, int skillID, int skillGroup = -1, BattleSkill.SKILL_TYPE type = BattleSkill.SKILL_TYPE.NORMAL_SKILL, int PartnerID = 0, bool bFlash = false, bool bStopTargetMovement = false)
        //		{
        //			bp.AssiginSkill(skillID, skillGroup, type, PartnerID, bFlash, bStopTargetMovement, false);
        //		}

        //		// Token: 0x06001276 RID: 4726 RVA: 0x000B7308 File Offset: 0x000B5508
        //		public void MarkForLogout(BattlePlayer player)
        //		{
        //			this.mBattlePlayersForLogout.Add(player);
        //		}

        //		// Token: 0x06001277 RID: 4727 RVA: 0x000B7318 File Offset: 0x000B5518
        //		public void Logout(int bpId)
        //		{
        //			if (bpId == 6)
        //			{
        //				return;
        //			}
        //			BattlePlayer battlePlayer = null;
        //			if (this.mBattlePlayers.TryGetValue(bpId, out battlePlayer))
        //			{
        //				if (bpId == 4)
        //				{
        //					BattlePlayer battlePlayer2 = null;
        //					if (this.mBattlePlayers.TryGetValue(6, out battlePlayer2))
        //					{
        //						GameObject gameObject = battlePlayer2.gameObject;
        //						GameObject gameObject2 = battlePlayer.gameObject;
        //						Agent component = gameObject.GetComponent<Agent>();
        //						Agent component2 = gameObject2.GetComponent<Agent>();
        //						PalNPC palNPC = component.palNPC;
        //						PalNPC palNPC2 = component2.palNPC;
        //						palNPC2.model = gameObject;
        //						palNPC.model = gameObject2;
        //						component.palNPC = palNPC2;
        //						component2.palNPC = palNPC;
        //						Vector3 localPosition = gameObject.transform.localPosition;
        //						Quaternion localRotation = gameObject.transform.localRotation;
        //						gameObject.transform.parent = palNPC2.transform;
        //						gameObject2.transform.parent = palNPC.transform;
        //						gameObject2.transform.localPosition = localPosition;
        //						gameObject2.transform.localRotation = localRotation;
        //						this.m_PolarLBI.UnRegisterBattlePlayer(battlePlayer2);
        //						battlePlayer2.OnDestroyMe();
        //						this.mBattlePlayers.Remove(6);
        //						BattleEventProcessorManager.Instance().SendBattleEvent(new BattlePlayerDieEvent(6), 0f);
        //					}
        //				}
        //				if (battlePlayer.m_bProxy)
        //				{
        //					battlePlayer.m_HostBp.ChangeModelBack();
        //					battlePlayer = battlePlayer.m_HostBp;
        //				}
        //				this.m_PolarLBI.UnRegisterBattlePlayer(battlePlayer);
        //				battlePlayer.OnDestroyMe();
        //				this.mBattlePlayers.Remove(bpId);
        //				BattleEventProcessorManager.Instance().SendBattleEvent(new BattlePlayerDieEvent(bpId), 0f);
        //			}
        //			else
        //			{
        //				Debug.Log("Logout exception: battleUnit does not exist.");
        //			}
        //		}

        //		// Token: 0x06001278 RID: 4728 RVA: 0x000B749C File Offset: 0x000B569C
        //		private void OnDestroy()
        //		{
        //			this.mHPGUI.OnDestroyMe();
        //		}

        //		// Token: 0x06001279 RID: 4729 RVA: 0x000B74AC File Offset: 0x000B56AC
        //		protected void registerUICallback()
        //		{
        //			PalMain.GameMain.onGUIHandles += this.mATBUI.OnGUI;
        //			PalMain.GameMain.onGUIHandles += this.mTeammateUI.OnGUI;
        //			PalMain.GameMain.onGUIHandles += this.mTargetUI.OnGUI;
        //			PalMain.GameMain.onInputHandles += this.mATBUI.OnUpdate;
        //			PalMain.GameMain.updateHandles += this.mDialogUI.OnUpdate;
        //			PalMain.GameMain.updateHandles += this.mDialogUIFlash.OnUpdate;
        //		}

        //		// Token: 0x0600127A RID: 4730 RVA: 0x000B755C File Offset: 0x000B575C
        //		protected void unregisterUICallback()
        //		{
        //			PalMain.GameMain.onGUIHandles -= this.mATBUI.OnGUI;
        //			PalMain.GameMain.onGUIHandles -= this.mTeammateUI.OnGUI;
        //			PalMain.GameMain.onGUIHandles -= this.mTargetUI.OnGUI;
        //			PalMain.GameMain.onInputHandles -= this.mATBUI.OnUpdate;
        //			PalMain.GameMain.updateHandles -= this.mDialogUI.OnUpdate;
        //			PalMain.GameMain.updateHandles -= this.mDialogUIFlash.OnUpdate;
        //		}

        //		// Token: 0x0600127B RID: 4731 RVA: 0x000B760C File Offset: 0x000B580C
        //		public bool IsAutoMode()
        //		{
        //			BattlePlayer currentControllCharater = this.GetCurrentControllCharater();
        //			if (currentControllCharater != null)
        //			{
        //				BattlePlayerInputer playerInputer = currentControllCharater.GetPlayerInputer();
        //				if (playerInputer != null && playerInputer.GetInputerType() == BattlePlayerInputer.BATTLE_PLAYER_INPUTER.AI_INPUTER)
        //				{
        //					return true;
        //				}
        //			}
        //			return false;
        //		}

        //		// Token: 0x0600127C RID: 4732 RVA: 0x000B7648 File Offset: 0x000B5848
        //		public void SetControlledPlayer(int battleID)
        //		{
        //			BattlePlayer battlePlayerByBattleID = this.GetBattlePlayerByBattleID(battleID);
        //			if (battlePlayerByBattleID != null)
        //			{
        //				battlePlayerByBattleID.SetPlayerInputer(BattlePlayerInputer.BATTLE_PLAYER_INPUTER.UI_INPUTER);
        //				this.mControlledPlayer = battlePlayerByBattleID;
        //				SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
        //				if (component != null)
        //				{
        //					component.enabled = false;
        //				}
        //				BattleCameraController battleCameraController = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //				if (battleCameraController == null)
        //				{
        //					battleCameraController = Camera.main.gameObject.AddComponent<BattleCameraController>();
        //					battleCameraController.Start();
        //				}
        //			}
        //			int num = -1;
        //			int index = 0;
        //			for (int i = 0; i < this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas.Count; i++)
        //			{
        //				if (this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[i].m_CharacterID == battleID)
        //				{
        //					num = i;
        //					break;
        //				}
        //			}
        //			if (num != -1)
        //			{
        //				BattleFormationManager.InFormationCharaData value = this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index];
        //				this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index] = this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[num];
        //				this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[num] = value;
        //			}
        //		}

        //		// Token: 0x0600127D RID: 4733 RVA: 0x000B77AC File Offset: 0x000B59AC
        //		public BattlePlayer GetCurrentControllCharater()
        //		{
        //			return this.mControlledPlayer;
        //		}

        //		// Token: 0x0600127E RID: 4734 RVA: 0x000B77B4 File Offset: 0x000B59B4
        //		public void OnQTESucceed()
        //		{
        //			BattlePlayer battlePlayerByBattleID = this.GetBattlePlayerByBattleID(this.mQTEBattlePlayerID);
        //			if (battlePlayerByBattleID != null && this.mQTESE != null && this.mQTESE.mSkillScript != null)
        //			{
        //				this.mQTESE.mSkillScript.OnQTESucceed(this.mQTEIndex);
        //			}
        //			SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
        //			component.enabled = false;
        //		}

        //		// Token: 0x0600127F RID: 4735 RVA: 0x000B7824 File Offset: 0x000B5A24
        //		public void OnQTEFailed()
        //		{
        //			BattlePlayer battlePlayerByBattleID = this.GetBattlePlayerByBattleID(this.mQTEBattlePlayerID);
        //			if (battlePlayerByBattleID != null && this.mQTESE != null && this.mQTESE.mSkillScript != null)
        //			{
        //				this.mQTESE.mSkillScript.OnQTEFailed(this.mQTEIndex);
        //			}
        //			SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
        //			component.enabled = false;
        //		}

        //		// Token: 0x06001280 RID: 4736 RVA: 0x000B7894 File Offset: 0x000B5A94
        //		public bool OnQTEStart(BattleEventBase evt)
        //		{
        //			QTEEvent qteevent = (QTEEvent)evt;
        //			this.mQTEBattlePlayerID = qteevent.mBpID;
        //			this.mQTEIndex = qteevent.mIndex;
        //			this.mQTESE = qteevent.mPalSE;
        //			PalMain.GameMain.m_QTEManager.StartQTE(qteevent.m_TimeSpan, qteevent.m_TimeScale, qteevent.m_QTEType, qteevent.m_SubType, new QTEInitiator.QTESucceed(this.OnQTESucceed), new QTEInitiator.QTEFailed(this.OnQTEFailed), true);
        //			return true;
        //		}

        //		// Token: 0x06001281 RID: 4737 RVA: 0x000B7910 File Offset: 0x000B5B10
        //		public Vector3 GetMyGetherPos(BattlePlayer targetBP, BattlePlayer centerBP, float radius)
        //		{
        //			int indexInFaction = this.GetIndexInFaction((int)targetBP.mPlyerFaction, targetBP.BattleID, centerBP.BattleID);
        //			int numberInFaction = this.GetNumberInFaction((int)targetBP.mPlyerFaction);
        //			float angle = (float)indexInFaction / (float)numberInFaction * 360f;
        //			Vector3 point = new Vector3(radius, 0f, 0f);
        //			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //			Vector3 a = rotation * point;
        //			return a + centerBP.GetPlayerPosition();
        //		}

        //		// Token: 0x06001282 RID: 4738 RVA: 0x000B798C File Offset: 0x000B5B8C
        //		public int GetIndexInFaction(int faction, int bpID, int skipID)
        //		{
        //			int num = 0;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				if (value.mPlyerFaction == (BattlePlayer.FACTION)faction && bpID != value.BattleID && value.BattleID != skipID)
        //				{
        //					num++;
        //				}
        //			}
        //			return num;
        //		}

        //		// Token: 0x06001283 RID: 4739 RVA: 0x000B7A20 File Offset: 0x000B5C20
        //		public int GetNumberInFaction(int faction)
        //		{
        //			int num = 0;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				if (value.mPlyerFaction == (BattlePlayer.FACTION)faction)
        //				{
        //					num++;
        //				}
        //			}
        //			return num;
        //		}

        //		// Token: 0x06001284 RID: 4740 RVA: 0x000B7A9C File Offset: 0x000B5C9C
        //		public void CleanUpBattleField(bool bSucceed)
        //		{
        //			this.mbLogoutAll = true;
        //			if (this.mbLogoutAll)
        //			{
        //				List<BattlePlayer> allBattlePlayers = this.GetAllBattlePlayers();
        //				foreach (BattlePlayer battlePlayer in allBattlePlayers)
        //				{
        //					this.Logout(battlePlayer.BattleID);
        //				}
        //				this.mbLogoutAll = false;
        //			}
        //			this.mLossScript_C_Sharp = null;
        //			this.mShopScript_C_Sharp = null;
        //			this.mStartScript_C_Sharp = null;
        //			this.mTitleScript_C_Sharp = null;
        //			this.mWinScript_C_Sharp = null;
        //			if (this.mReturnCutsceneCallback != null)
        //			{
        //				this.mReturnCutsceneCallback(bSucceed);
        //			}
        //			this.flags.Clear();
        //		}

        //		// Token: 0x06001285 RID: 4741 RVA: 0x000B7B68 File Offset: 0x000B5D68
        //		public void SetPauseExcept(int bpID)
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				if (bpID != value.BattleID)
        //				{
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.PAUSE_BATTLE, value.BattleID), 0f);
        //				}
        //			}
        //		}

        //		// Token: 0x06001286 RID: 4742 RVA: 0x000B7BF8 File Offset: 0x000B5DF8
        //		public void SetResumeAllPause()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.RESUME_BATTLE, value.BattleID), 0f);
        //			}
        //		}

        //		// Token: 0x06001287 RID: 4743 RVA: 0x000B7C7C File Offset: 0x000B5E7C
        //		public void SetBattleState(PalBattleManager.BATTLE_STATE state)
        //		{
        //			if (this.mCurrentBattleState != state)
        //			{
        //				switch (state)
        //				{
        //				case PalBattleManager.BATTLE_STATE.PRE_BATTLE:
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.PAUSE_BATTLE, -1), 0f);
        //					break;
        //				case PalBattleManager.BATTLE_STATE.RESUME_BATTLE:
        //					if (this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.PAUSE_BATTLE)
        //					{
        //						BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.RESUME_BATTLE, -1), 0f);
        //					}
        //					else
        //					{
        //						BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.START_BATTLE, -1), 0f);
        //					}
        //					break;
        //				case PalBattleManager.BATTLE_STATE.PAUSE_BATTLE:
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.PAUSE_BATTLE, -1), 0f);
        //					break;
        //				case PalBattleManager.BATTLE_STATE.POST_BATTLE:
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.END_BATTLE, -1), 0f);
        //					break;
        //				case PalBattleManager.BATTLE_STATE.WIN_BATTLE:
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.WIN_BATTLE, -1), 0f);
        //					break;
        //				case PalBattleManager.BATTLE_STATE.LOSS_BATTLE:
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.LOSS_BATTLE, -1), 0f);
        //					break;
        //				}
        //			}
        //			PalBattleManager.BATTLE_STATE battle_STATE = this.mCurrentBattleState;
        //			this.mCurrentBattleState = state;
        //			if ((battle_STATE != PalBattleManager.BATTLE_STATE.POST_BATTLE && battle_STATE != PalBattleManager.BATTLE_STATE.WIN_BATTLE && battle_STATE != PalBattleManager.BATTLE_STATE.LOSS_BATTLE) || this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.PRE_BATTLE || this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE || this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.PAUSE_BATTLE)
        //			{
        //			}
        //		}

        //		// Token: 0x06001288 RID: 4744 RVA: 0x000B7DCC File Offset: 0x000B5FCC
        //		public PalBattleManager.BATTLE_STATE GetBattleState()
        //		{
        //			return this.mCurrentBattleState;
        //		}

        //		// Token: 0x06001289 RID: 4745 RVA: 0x000B7DD4 File Offset: 0x000B5FD4
        //		private bool OnStartStateChange(BattleEventBase evt)
        //		{
        //			BattleStateEvent battleStateEvent = (BattleStateEvent)evt;
        //			if (battleStateEvent.mBPID == -1)
        //			{
        //				switch (battleStateEvent.mCMD)
        //				{
        //				case 0:
        //					if (GameStateManager.CurGameState != GameState.Battle)
        //					{
        //						GameStateManager.CurGameState = GameState.Battle;
        //					}
        //					if (this.mEnterBattleFunc != null)
        //					{
        //						this.mEnterBattleFunc();
        //					}
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattlePlayerGroupScriptEvent(BattlePlayerGroupScriptEvent.EVT_CMD.START_BATTLE_EVENT), -1f);
        //					if (this.mStartScript_C_Sharp != null)
        //					{
        //						this.mStartScript_C_Sharp.OnStart();
        //					}
        //					break;
        //				case 3:
        //				{
        //					this.ShowGongLiUI(false, false, false);
        //					this.RemoveAllPlayerBuff();
        //					this.StopAllCharacterPalSE();
        //					BattleCameraController component = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //					if (component != null)
        //					{
        //						UnityEngine.Object.Destroy(component);
        //					}
        //					this.FreezeAll();
        //					if (this.GetSkipOutBattleResult())
        //					{
        //						this.CleanUpBattleField(false);
        //						this.EndBattle(false);
        //					}
        //					else
        //					{
        //						this.PauseAllPlayers();
        //						OutBattlePerformer outBattlePerformer = Camera.main.gameObject.AddComponent<OutBattlePerformer>();
        //						outBattlePerformer.Init(Camera.main, BattleStateEvent.BATTLE_STATE_CONTROL.END_BATTLE);
        //					}
        //					break;
        //				}
        //				case 4:
        //				{
        //					this.ShowGongLiUI(false, false, false);
        //					PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.BATTLE_SUCCEED_TIMES_1, true);
        //					PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.BATTLE_SUCCEED_TIMES_100, true);
        //					PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.BATTLE_SUCCEED_TIMES_500, true);
        //					PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.BATTLE_SUCCEED_TIMES_1000, true);
        //					this.RemoveAllPlayerBuff();
        //					this.StopAllCharacterPalSE();
        //					this.AddMoneyToGame();
        //					this.AddExpToGame();
        //					this.AddYuanShenToGame();
        //					this.AddItemsToGame();
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattlePlayerGroupScriptEvent(BattlePlayerGroupScriptEvent.EVT_CMD.WIN_EVENT), -1f);
        //					BattleCameraController component = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //					if (component != null)
        //					{
        //						UnityEngine.Object.Destroy(component);
        //					}
        //					if (this.mWinScript_C_Sharp != null)
        //					{
        //						this.mWinScript_C_Sharp.OnStart();
        //					}
        //					this.FreezeAll();
        //					if (this.GetSkipOutBattleResult())
        //					{
        //						this.CleanUpBattleField(true);
        //						this.EndBattle(false);
        //					}
        //					else
        //					{
        //						OutBattlePerformer outBattlePerformer2 = Camera.main.gameObject.AddComponent<OutBattlePerformer>();
        //						outBattlePerformer2.Init(Camera.main, BattleStateEvent.BATTLE_STATE_CONTROL.WIN_BATTLE);
        //					}
        //					break;
        //				}
        //				case 5:
        //				{
        //					this.ShowGongLiUI(false, false, false);
        //					this.RemoveAllPlayerBuff();
        //					this.StopAllCharacterPalSE();
        //					BattleEventProcessorManager.Instance().SendBattleEvent(new BattlePlayerGroupScriptEvent(BattlePlayerGroupScriptEvent.EVT_CMD.LOSS_EVENT), -1f);
        //					BattleCameraController component = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //					if (component != null)
        //					{
        //						UnityEngine.Object.Destroy(component);
        //					}
        //					if (this.mLossScript_C_Sharp != null)
        //					{
        //						this.mLossScript_C_Sharp.OnStart();
        //					}
        //					this.FreezeAll();
        //					if (this.GetSkipOutBattleResult())
        //					{
        //						this.CleanUpBattleField(false);
        //						this.EndBattle(false);
        //					}
        //					else
        //					{
        //						this.PauseAllPlayers();
        //						OutBattlePerformer outBattlePerformer3 = Camera.main.gameObject.AddComponent<OutBattlePerformer>();
        //						outBattlePerformer3.Init(Camera.main, BattleStateEvent.BATTLE_STATE_CONTROL.LOSS_BATTLE);
        //					}
        //					break;
        //				}
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x0600128A RID: 4746 RVA: 0x000B80B4 File Offset: 0x000B62B4
        //		public void DrawGizmos()
        //		{
        //			if (this.m_PolarLBI != null)
        //			{
        //				this.m_PolarLBI.DrawGizmos();
        //			}
        //		}

        //		// Token: 0x0600128B RID: 4747 RVA: 0x000B80CC File Offset: 0x000B62CC
        //		public int GetFlag(int idx)
        //		{
        //			if (this.flags.ContainsKey(idx))
        //			{
        //				return this.flags[idx];
        //			}
        //			return -1;
        //		}

        //		// Token: 0x0600128C RID: 4748 RVA: 0x000B80F0 File Offset: 0x000B62F0
        //		public void SetFlag(int idx, int value)
        //		{
        //			if (this.flags.ContainsKey(idx))
        //			{
        //				this.flags[idx] = value;
        //			}
        //			else
        //			{
        //				this.flags.Add(idx, value);
        //			}
        //		}

        //		// Token: 0x0600128D RID: 4749 RVA: 0x000B8130 File Offset: 0x000B6330
        //		public void UpdateMe()
        //		{
        //			if (this.m_LastGameState != GameState.Normal && GameStateManager.CurGameState == GameState.Normal && this.m_Achievement != null)
        //			{
        //				this.m_Achievement.m_CurTime = 1f;
        //			}
        //			this.m_LastGameState = GameStateManager.CurGameState;
        //			if (GameStateManager.CurGameState == GameState.Normal && this.m_Achievement != null)
        //			{
        //				this.m_Achievement.UpdateShowUI();
        //			}
        //			this.m_CurForceInBattleTime += Time.deltaTime;
        //			if (this.m_CurForceInBattleTime < 0.5f)
        //			{
        //				foreach (KeyValuePair<int, BattlePlayer> keyValuePair in PalBattleManager.Instance().mBattlePlayers)
        //				{
        //					Time.timeScale = 1f;
        //					if (keyValuePair.Value.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && keyValuePair.Value.BattleID <= 6)
        //					{
        //						Vector3 playerPosition = keyValuePair.Value.GetPlayerPosition();
        //						Vector3 vector = playerPosition - this.m_PolarLBI.GetCenter();
        //						vector.y = 0f;
        //						if (vector.magnitude > 10f)
        //						{
        //							keyValuePair.Value.SetPlayerTranslation(keyValuePair.Value.GetDest(), keyValuePair.Value.GetPlayerRotation());
        //						}
        //					}
        //				}
        //			}
        //			this.m_BattleCoolDown -= Time.deltaTime;
        //			if (this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //			{
        //				this.m_BattleTime += Time.deltaTime;
        //			}
        //			if (this.m_bBattleSuspend)
        //			{
        //				return;
        //			}
        //			this.m_PolarLBI.UpdateLBI();
        //			this.mBattleDirector.Update();
        //			foreach (BattlePlayer battlePlayer in this.mBattlePlayersForLogout)
        //			{
        //				this.Logout(battlePlayer.BattleID);
        //				if (this.m_bUseDefaultEndBattle && this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //				{
        //					List<int> factionList = this.GetFactionList(1);
        //					List<int> factionList2 = this.GetFactionList(2);
        //					if (factionList2.Count + factionList.Count == 0)
        //					{
        //						this.SetBattleState(PalBattleManager.BATTLE_STATE.WIN_BATTLE);
        //					}
        //				}
        //			}
        //			this.mBattlePlayersForLogout.Clear();
        //			BattlePlayer currentControllCharater = PalBattleManager.Instance().GetCurrentControllCharater();
        //			if (currentControllCharater != null && currentControllCharater.mUserInputStateManager != null)
        //			{
        //				BattleStateBase.INPUT_STATE_ENUM currentState = currentControllCharater.mUserInputStateManager.GetCurrentState();
        //				if (currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_MANUAL_ATB_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_MANUAL_SELECT_ATB_SKILL && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_FENGYIN_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_ITEM_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_MIAOSHOU_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_TPA_JI_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_TPA_HE_FRIEND_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_TPA_HE_TARGET_SELECT && currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_TPA_ZHAN_TARGET_SELECT)
        //				{
        //					this.GetIndicator().SetBpTarget(null);
        //				}
        //			}
        //			else
        //			{
        //				this.GetIndicator().SetBpTarget(null);
        //			}
        //			if (GameStateManager.CurGameState == GameState.Battle && this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //			{
        //				BattlePlayer currentControllCharater2 = this.GetCurrentControllCharater();
        //				if (currentControllCharater2 != null)
        //				{
        //					if (currentControllCharater2.m_PlayerBattleState.mCurrentState == 0 && currentControllCharater2.GetPalNPC().Data.HPMPDP.HP > 0 && this.GetAllEnemyHP() > 0 && !currentControllCharater2.IfPlayerHasBuff(StatusDataManager.STATUS_TYPE_ENUM.TYPE_FREEZE_STATE))
        //					{
        //						this.ShowGongLiUI(true, true, true);
        //					}
        //					else if (currentControllCharater2.m_PlayerBattleState.mCurrentState != 0 || currentControllCharater2.GetPalNPC().Data.HPMPDP.HP <= 0 || this.GetAllEnemyHP() <= 0 || currentControllCharater2.IfPlayerHasBuff(StatusDataManager.STATUS_TYPE_ENUM.TYPE_FREEZE_STATE))
        //					{
        //						this.ShowGongLiUI(false, true, true);
        //					}
        //				}
        //				else
        //				{
        //					this.ShowGongLiUI(false, true, true);
        //				}
        //				bool flag = true;
        //				foreach (KeyValuePair<int, BattlePlayer> keyValuePair2 in this.mBattlePlayers)
        //				{
        //					if (!keyValuePair2.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.IDLE) && !keyValuePair2.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.ATTACKING_PREPARE) && !keyValuePair2.Value.m_bPause)
        //					{
        //						if (keyValuePair2.Key != 6 || !keyValuePair2.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.FOLLOW))
        //						{
        //							flag = false;
        //							break;
        //						}
        //					}
        //				}
        //				if (flag)
        //				{
        //					if (!this.m_nextAllIdle)
        //					{
        //						this.m_nextAllIdle = true;
        //						Debug.LogError("Idle!!!!!!!!!!!!!!!!");
        //						Resources.UnloadUnusedAssets();
        //					}
        //				}
        //				else
        //				{
        //					this.m_nextAllIdle = false;
        //				}
        //				if (this.m_bScriptWin)
        //				{
        //					bool flag2 = true;
        //					foreach (KeyValuePair<int, BattlePlayer> keyValuePair3 in PalBattleManager.Instance().mBattlePlayers)
        //					{
        //						if (keyValuePair3.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.COOPERATE_STATE) || keyValuePair3.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.INSTANCE_ACTION) || keyValuePair3.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.INSTANCEACTION_TARGET_STATE) || keyValuePair3.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.TPA))
        //						{
        //							flag2 = false;
        //						}
        //						if (keyValuePair3.Value.IsUsingUnique())
        //						{
        //							flag2 = false;
        //						}
        //					}
        //					if (flag2)
        //					{
        //						this.SetBattleState(PalBattleManager.BATTLE_STATE.WIN_BATTLE);
        //					}
        //				}
        //			}
        //			this.UpdateEnemyMaxRadius();
        //			if (this.m_CamCtrl == null && Camera.main != null)
        //			{
        //				this.m_CamCtrl = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //			}
        //			if (!(this.m_CamCtrl != null) || !this.m_CamCtrl.IsFPSMode())
        //			{
        //				if (this.GetCurrentControllCharater() != null)
        //				{
        //					if (this.GetShowEnemyHPUI())
        //					{
        //						int num = 0;
        //						BattlePlayer currentDefaultSkillTarget = this.GetCurrentControllCharater().GetCurrentDefaultSkillTarget(out num);
        //						if (currentDefaultSkillTarget != null)
        //						{
        //							BattleTarget target = currentDefaultSkillTarget.GetTarget(num);
        //							if (num == 0)
        //							{
        //								UIBattle_UnitInfo.Instance.IsPartHP = false;
        //							}
        //							else
        //							{
        //								UIBattle_UnitInfo.Instance.IsPartHP = true;
        //							}
        //							UIBattle_UnitInfo.Instance.OwnerBattleTarget = target;
        //						}
        //						else
        //						{
        //							UIBattle_UnitInfo.Instance.OwnerBattleTarget = null;
        //						}
        //					}
        //					else
        //					{
        //						UIBattle_UnitInfo.Instance.OwnerBattleTarget = null;
        //					}
        //				}
        //			}
        //			this.UpdatePalSE();
        //			if (GameStateManager.CurGameState == GameState.Battle)
        //			{
        //				if (Input.GetKeyDown(KeyCode.Tab))
        //				{
        //					this.SwitchLeader();
        //				}
        //				if (Input.GetKeyDown(KeyCode.LeftControl))
        //				{
        //					this.SwitchSkillGroup();
        //				}
        //			}
        //		}

        //		// Token: 0x0600128E RID: 4750 RVA: 0x000B880C File Offset: 0x000B6A0C
        //		private bool OnBattleControl(BattleEventBase evt)
        //		{
        //			BattleControlCMD battleControlCMD = (BattleControlCMD)evt;
        //			switch (battleControlCMD.mCMD)
        //			{
        //			case 2:
        //				this.SetControlledPlayer(battleControlCMD.mParam0);
        //				break;
        //			}
        //			return true;
        //		}

        //		// Token: 0x0600128F RID: 4751 RVA: 0x000B885C File Offset: 0x000B6A5C
        //		public bool BattlePlayerOnHPChange(BattleEventBase evt)
        //		{
        //			HPChangeEvent hpchangeEvent = (HPChangeEvent)evt;
        //			BattlePlayer mCaster = hpchangeEvent.mCaster;
        //			if (mCaster != null && mCaster.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && mCaster.GetFollowTarget() == null && hpchangeEvent.mdHPValue < 0 && mCaster.BattleID <= 6)
        //			{
        //				this.m_LastAttackBp = mCaster;
        //			}
        //			return true;
        //		}

        //		// Token: 0x06001290 RID: 4752 RVA: 0x000B88C0 File Offset: 0x000B6AC0
        //		public void AddDialog(string dialog, DialogUI.ContinueExecution exe, float fadeTime)
        //		{
        //			this.mDialogUI.PushDialog(dialog, exe, fadeTime);
        //		}

        //		// Token: 0x06001291 RID: 4753 RVA: 0x000B88D0 File Offset: 0x000B6AD0
        //		public void AddBattleDialog(string title, string dialog, DialogUI.ContinueExecution exe, float fadeTime)
        //		{
        //			this.mDialogUI.PushDialog(title, dialog, exe, fadeTime);
        //		}

        //		// Token: 0x06001292 RID: 4754 RVA: 0x000B88E4 File Offset: 0x000B6AE4
        //		public void AddBattleDialogFlash(string title, string dialog, float fadeTime)
        //		{
        //			this.mDialogUIFlash.PushDialogFlash(title, dialog, fadeTime);
        //		}

        //		// Token: 0x06001293 RID: 4755 RVA: 0x000B88F4 File Offset: 0x000B6AF4
        //		public void AddIconDialog(string path)
        //		{
        //			GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>(path.ToAssetBundlePath(), true, true);
        //			Cutscene component = gameObject.GetComponent<Cutscene>();
        //			component.Play();
        //		}

        //		// Token: 0x06001294 RID: 4756 RVA: 0x000B891C File Offset: 0x000B6B1C
        //		public void SetPlayerState(bool bPause, int bpID)
        //		{
        //			if (bPause)
        //			{
        //				BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.PAUSE_BATTLE, bpID), -1f);
        //			}
        //			else
        //			{
        //				BattleEventProcessorManager.Instance().SendBattleEvent(new BattleStateEvent(BattleStateEvent.BATTLE_STATE_CONTROL.RESUME_BATTLE, bpID), -1f);
        //			}
        //		}

        //		// Token: 0x06001295 RID: 4757 RVA: 0x000B8958 File Offset: 0x000B6B58
        //		private void CreateBattleIndicator()
        //		{
        //			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Indicator"));
        //			this.mBattleIndicator = gameObject.GetComponent<BattleIndicator>();
        //		}

        //		// Token: 0x06001296 RID: 4758 RVA: 0x000B8988 File Offset: 0x000B6B88
        //		public BattleIndicator GetIndicator()
        //		{
        //			return this.mBattleIndicator;
        //		}

        //		// Token: 0x06001297 RID: 4759 RVA: 0x000B8990 File Offset: 0x000B6B90
        //		public void ActiveAllBattlePlayer(bool bActive)
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.SetActive(bActive);
        //			}
        //		}

        //		// Token: 0x06001298 RID: 4760 RVA: 0x000B89FC File Offset: 0x000B6BFC
        //		public void EnableAllBattlePlayer(bool bEnable)
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value != null)
        //				{
        //					keyValuePair.Value.SetEnable(bEnable);
        //				}
        //			}
        //		}

        //		// Token: 0x06001299 RID: 4761 RVA: 0x000B8A7C File Offset: 0x000B6C7C
        //		public void SetBattleEndCall_Test(PalBattleManager.OnRetureCutsceneCallback cb)
        //		{
        //			this.mReturnCutsceneCallback = cb;
        //		}

        //		// Token: 0x0600129A RID: 4762 RVA: 0x000B8A88 File Offset: 0x000B6C88
        //		public static void DestroyInstance()
        //		{
        //			PalBattleManager.instance = null;
        //		}

        //		// Token: 0x0600129B RID: 4763 RVA: 0x000B8A90 File Offset: 0x000B6C90
        //		public int FindAvailbleID(bool bFriend)
        //		{
        //			int num;
        //			if (bFriend)
        //			{
        //				num = 7;
        //			}
        //			else
        //			{
        //				num = 10;
        //			}
        //			while (this.mBattlePlayers.ContainsKey(num))
        //			{
        //				num++;
        //			}
        //			return num;
        //		}

        //		// Token: 0x0600129C RID: 4764 RVA: 0x000B8AD0 File Offset: 0x000B6CD0
        //		public void ShowUI(bool d)
        //		{
        //			this.mTeammateUI.ShowUI(d);
        //			this.mTargetUI.ShowUI(d);
        //			this.mThreePhaseUI.ShowUI(d);
        //			this.mFormationUI.ShowUI(d);
        //		}

        //		// Token: 0x0600129D RID: 4765 RVA: 0x000B8B10 File Offset: 0x000B6D10
        //		protected void LoadPreLoadCommonSECache()
        //		{
        //			this.UnloadCommonSE();
        //			for (int i = 0; i < this.mMonsterSkillDataMgr.m_PreLoadCommonSkills.Count; i++)
        //			{
        //				int id = this.mMonsterSkillDataMgr.m_PreLoadCommonSkills[i];
        //				MonsterSkillDataManager.SkillData data = PalBattleManager.Instance().GetMonsterSkillDataManager().GetData(id);
        //				if (data != null)
        //				{
        //					List<BattleSkill> list = new List<BattleSkill>();
        //					BattleSkill battleSkill = new BattleSkill();
        //					battleSkill.mSkillType = BattleSkill.SKILL_TYPE.COMMON_SE;
        //					battleSkill.m_PartnerID = -1;
        //					battleSkill.mRangeType = (BattleSkill.PERFORM_RANGE_TYPE)data.mRangeType;
        //					battleSkill.mATBTimeCost = 0f;
        //					battleSkill.mSkillSEID = data.mSEID;
        //					battleSkill.mName = data.mName;
        //					battleSkill.mSkillPerformRange = data.mAttackRange;
        //					battleSkill.mPalSEPath = data.mSEPath;
        //					battleSkill.mTotalDamage = data.mTotalDamage;
        //					battleSkill.mbFriendly = (data.mIsFriendly == 1);
        //					battleSkill.mScriptID = data.mScriptID;
        //					battleSkill.mBreakMask = data.mBREAK_MASK;
        //					int num = 8;
        //					for (int j = 0; j < num; j++)
        //					{
        //						battleSkill.mElemRate[j] = data.mELEM_RATE[j];
        //					}
        //					battleSkill.mPreSkill = data.mPRE_SKILL;
        //					battleSkill.m_ElemID = data.m_ElemID;
        //					battleSkill.mSkillGroup = 0;
        //					battleSkill.m_NormalSkillType = data.m_NormalSkillType;
        //					battleSkill.m_BuffType = data.m_BuffType;
        //					battleSkill.m_BuleConsumption = data.m_BuleConsumption;
        //					battleSkill.m_ChanceOfUse = data.m_ChanceOfUse;
        //					if (data.m_StopTargetMovement == 1)
        //					{
        //						battleSkill.m_bStopTargetMovement = true;
        //					}
        //					else
        //					{
        //						battleSkill.m_bStopTargetMovement = false;
        //					}
        //					list.Add(battleSkill);
        //					this.m_CommonSkills.Add(battleSkill.mSkillSEID, list);
        //				}
        //				else
        //				{
        //					Debug.LogError("AssignSkillToBattlePlayer failed:Skill " + id.ToString() + " not found");
        //				}
        //			}
        //		}

        //		// Token: 0x0600129E RID: 4766 RVA: 0x000B8CF0 File Offset: 0x000B6EF0
        //		public void UnloadCommonSE()
        //		{
        //			foreach (KeyValuePair<int, List<BattleSkill>> keyValuePair in this.m_CommonSkills)
        //			{
        //				List<BattleSkill> value = keyValuePair.Value;
        //				for (int i = 0; i < value.Count; i++)
        //				{
        //					if (value[i] != null && value[i].mSE != null)
        //					{
        //						UnityEngine.Object.Destroy(value[i].mSE.gameObject);
        //					}
        //				}
        //			}
        //			this.m_CommonSkills.Clear();
        //		}

        //		// Token: 0x0600129F RID: 4767 RVA: 0x000B8DB4 File Offset: 0x000B6FB4
        //		public void OnSetBattleFormation()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.UpdateBattleFormation();
        //			}
        //		}

        //		// Token: 0x060012A0 RID: 4768 RVA: 0x000B8E20 File Offset: 0x000B7020
        //		public void UpdateFormaionCharacters()
        //		{
        //			List<BattlePlayer> list = new List<BattlePlayer>();
        //			int currentFormation = this.m_BattleFormation.CurrentFormation;
        //			List<Vector3> list2 = new List<Vector3>();
        //			List<Vector3> list3 = new List<Vector3>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.BattleID < 10 && !(keyValuePair.Value.GetFollowTarget() != null))
        //				{
        //					bool flag = false;
        //					int num = 0;
        //					while (num < this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas.Count && num < 4 && num < this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas.Count - this.m_BattleFormation.m_Formations[currentFormation].m_Store)
        //					{
        //						if (this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas[num].m_CharacterID == keyValuePair.Value.BattleID)
        //						{
        //							flag = true;
        //							break;
        //						}
        //						num++;
        //					}
        //					if (!flag && keyValuePair.Value.BattleID <= 6)
        //					{
        //						list2.Add(keyValuePair.Value.GetPlayerPosition());
        //						Vector3 currentIdlePos = PalBattleManager.Instance().m_PolarLBI.GetCurrentIdlePos(keyValuePair.Value);
        //						list3.Add(currentIdlePos);
        //						this.MarkForLogout(keyValuePair.Value);
        //						list.Add(keyValuePair.Value);
        //					}
        //				}
        //			}
        //			List<PalNPC> list4 = new List<PalNPC>();
        //			int num2 = 0;
        //			while (num2 < this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas.Count && num2 < 4 && num2 < this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas.Count - this.m_BattleFormation.m_Formations[currentFormation].m_Store)
        //			{
        //				bool flag2 = false;
        //				foreach (KeyValuePair<int, BattlePlayer> keyValuePair2 in this.mBattlePlayers)
        //				{
        //					if (keyValuePair2.Value.BattleID < 10 && !(keyValuePair2.Value.GetFollowTarget() != null))
        //					{
        //						if (this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas[num2].m_CharacterID == keyValuePair2.Value.BattleID)
        //						{
        //							flag2 = true;
        //							break;
        //						}
        //					}
        //				}
        //				if (!flag2)
        //				{
        //					GameObject player = PlayersManager.GetPlayer(this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas[num2].m_CharacterID);
        //					if (player != null)
        //					{
        //						PalNPC component = player.GetComponent<PalNPC>();
        //						component.SetSkillGroup(this.m_BattleFormation.m_Formations[currentFormation].m_InFormationCharaDatas[num2].m_CharacterSkillGroup);
        //						list4.Add(component);
        //					}
        //				}
        //				num2++;
        //			}
        //			for (int i = 0; i < list4.Count; i++)
        //			{
        //				if (list4[i].Data.CharacterID == 4)
        //				{
        //					GameObject gameObject = PlayersManager.FindMainChar(6, false);
        //					PalNPC component2 = gameObject.GetComponent<PalNPC>();
        //					this.m_JGXModel = component2.model;
        //					WeaponItem weaponItem = list4[i].GetSlot(EquipSlotEnum.Weapon) as WeaponItem;
        //					if (weaponItem != null)
        //					{
        //						list4.Add(gameObject.GetComponent<PalNPC>());
        //						GameObject model = list4[i].model;
        //						GameObject jgxmodel = this.m_JGXModel;
        //						Agent component3 = model.GetComponent<Agent>();
        //						Agent component4 = jgxmodel.GetComponent<Agent>();
        //						component4.palNPC = component2;
        //						component2.model = jgxmodel;
        //						PalNPC palNPC = list4[i];
        //						PalNPC palNPC2 = component2;
        //						palNPC2.model = model;
        //						palNPC.model = jgxmodel;
        //						component3.palNPC = palNPC2;
        //						component4.palNPC = palNPC;
        //						Vector3 localPosition = model.transform.localPosition;
        //						Quaternion localRotation = model.transform.localRotation;
        //						model.transform.parent = palNPC2.transform;
        //						jgxmodel.transform.parent = palNPC.transform;
        //						jgxmodel.transform.localPosition = localPosition;
        //						jgxmodel.transform.localRotation = localRotation;
        //					}
        //					else
        //					{
        //						list4.RemoveAt(i);
        //					}
        //					break;
        //				}
        //			}
        //			BattlePlayer battlePlayer = null;
        //			BattlePlayer battlePlayer2 = null;
        //			for (int j = 0; j < list4.Count; j++)
        //			{
        //				if (list4[j].Data.HPMPDP.HP <= 0)
        //				{
        //					list4[j].Data.HPMPDP.HP = 1;
        //				}
        //				GameObject model2 = list4[j].model;
        //				model2.SetActive(true);
        //				BattlePlayer battlePlayer3 = list4[j].model.AddComponent<BattlePlayer>();
        //				battlePlayer3.gameObject.SetVisible(true);
        //				battlePlayer3.m_bDontDestroy = true;
        //				battlePlayer3.m_BeforeBattlePos = list4[j].model.transform.position;
        //				battlePlayer3.m_BeforeBattleRot = list4[j].model.transform.rotation;
        //				battlePlayer3.SetNPC(list4[j]);
        //				battlePlayer3.m_bUseOrigin = false;
        //				if (j >= list2.Count)
        //				{
        //					Vector3 vacantPos = this.m_PolarLBI.GetVacantPos(false);
        //					list2.Add(vacantPos);
        //					list3.Add(vacantPos);
        //				}
        //				battlePlayer3.SetDest(list3[j]);
        //				battlePlayer3.m_bFormationLogin = true;
        //				if (list4[j].Data.CharacterID == 4)
        //				{
        //					battlePlayer2 = list4[j].model.GetComponent<BattlePlayer>();
        //				}
        //				if (list4[j].Data.CharacterID == 6)
        //				{
        //					battlePlayer = list4[j].model.GetComponent<BattlePlayer>();
        //				}
        //				if (this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //				{
        //					battlePlayer3.SetPause(false);
        //				}
        //			}
        //			if (battlePlayer2 != null && battlePlayer != null)
        //			{
        //				battlePlayer.SetFollowTarget(battlePlayer2);
        //				battlePlayer2.SetFollower(battlePlayer);
        //			}
        //			int characterID = this.m_BattleFormation.m_Formations[this.m_BattleFormation.CurrentFormation].m_InFormationCharaDatas[0].m_CharacterID;
        //			BattlePlayer battlePlayer4 = null;
        //			if (this.mBattlePlayers.TryGetValue(characterID, out battlePlayer4) && this.GetCurrentControllCharater() != battlePlayer4)
        //			{
        //				this.SetControlledPlayer(battlePlayer4.BattleID);
        //				GameObject gameObject2 = SpecialEffect.CreateUnitSE(4749, null, false, true, true);
        //				if (gameObject2 == null)
        //				{
        //					Console.WriteLine("PalBattleManamger.UpdateFromaionCharacters: unitSEObj == null");
        //					return;
        //				}
        //				UtilFun.SetPosition(gameObject2.transform, battlePlayer4.gameObject.transform.position);
        //				gameObject2.GetComponent<SpecialEffect>().Play(0f, false);
        //			}
        //			for (int k = 0; k < list.Count; k++)
        //			{
        //				if (list[k].mPlyerFaction == BattlePlayer.FACTION.FACTION_A && list[k].GetFollowTarget() == null)
        //				{
        //					list[k].IdleAndStopAction();
        //				}
        //			}
        //			PalBattleManager.Instance().SetControlledPlayerWait(false);
        //		}

        //		// Token: 0x060012A1 RID: 4769 RVA: 0x000B95D8 File Offset: 0x000B77D8
        //		public void PostLoginPlayer(PalNPC player)
        //		{
        //			GameObject model = player.model;
        //			model.SetActive(true);
        //			BattlePlayer battlePlayer = player.model.AddComponent<BattlePlayer>();
        //			battlePlayer.m_bDontDestroy = false;
        //			battlePlayer.m_BeforeBattlePos = player.model.transform.position;
        //			battlePlayer.m_BeforeBattleRot = player.model.transform.rotation;
        //			battlePlayer.SetNPC(player);
        //			battlePlayer.m_bUseOrigin = false;
        //			Vector3 vacantPos = this.m_PolarLBI.GetVacantPos(player.Data.CharacterCommon.Faction != 0);
        //			vacantPos.y = this.m_PolarLBI.GetCenter().y;
        //			battlePlayer.SetDest(vacantPos);
        //			battlePlayer.m_bFormationLogin = true;
        //			if (this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //			{
        //				battlePlayer.SetPause(false);
        //			}
        //		}

        //		// Token: 0x060012A2 RID: 4770 RVA: 0x000B96A0 File Offset: 0x000B78A0
        //		public void LoginPlayer(int id)
        //		{
        //			GameObject gameObject = null;
        //			string path = "Template/Character/" + id.ToString();
        //			GameObject gameObject2 = FileLoader.LoadObjectFromFile<GameObject>(path.ToAssetBundlePath(), true, true);
        //			if (gameObject2 != null)
        //			{
        //				gameObject = gameObject2;
        //			}
        //			if (gameObject == null)
        //			{
        //				return;
        //			}
        //			PalNPC component = gameObject.GetComponent<PalNPC>();
        //			PalNPC palNPC = component;
        //			palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(this.PostLoginPlayer));
        //		}

        //		// Token: 0x060012A3 RID: 4771 RVA: 0x000B9714 File Offset: 0x000B7914
        //		public MonsterGroupDataManager GetMonsterGroupDataManager()
        //		{
        //			return this.mMonsterGroupDataMgr;
        //		}

        //		// Token: 0x060012A4 RID: 4772 RVA: 0x000B971C File Offset: 0x000B791C
        //		public MonsterSkillDataManager GetMonsterSkillDataManager()
        //		{
        //			return this.mMonsterSkillDataMgr;
        //		}

        //		// Token: 0x060012A5 RID: 4773 RVA: 0x000B9724 File Offset: 0x000B7924
        //		public StatusDataManager GetStatusDataManager()
        //		{
        //			return this.mStatusDataMgr;
        //		}

        //		// Token: 0x060012A6 RID: 4774 RVA: 0x000B972C File Offset: 0x000B792C
        //		public BattleFieldDataManager GetBattleFieldDataManager()
        //		{
        //			return this.mBattleFieldDataMgr;
        //		}

        //		// Token: 0x060012A7 RID: 4775 RVA: 0x000B9734 File Offset: 0x000B7934
        //		public void EnterFPSMode(BattlePlayer Target, List<int> subTargetIDs, string Bindname, float camTime, float fireDamage, int autoBP, int hideBP)
        //		{
        //			Transform transform = GameObjectPath.SearchSubNode(Target.gameObject.transform, Bindname);
        //			if (transform != null)
        //			{
        //				BattleCameraController component = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //				List<BattleTarget> list = new List<BattleTarget>();
        //				for (int i = 0; i < subTargetIDs.Count; i++)
        //				{
        //					if (Target.mTargets.ContainsKey(subTargetIDs[i]))
        //					{
        //						BattleTarget battleTarget = Target.mTargets[subTargetIDs[i]];
        //						if (battleTarget != null)
        //						{
        //							list.Add(battleTarget);
        //						}
        //					}
        //				}
        //				component.SetFPSCamera(Target, list, transform, camTime, fireDamage, autoBP, hideBP);
        //			}
        //			else
        //			{
        //				Debug.LogError("找不到" + Bindname + "绑定射击点");
        //			}
        //		}

        //		// Token: 0x060012A8 RID: 4776 RVA: 0x000B97F4 File Offset: 0x000B79F4
        //		public void ExitFPSMode()
        //		{
        //			BattleCameraController component = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //			if (component != null)
        //			{
        //				component.ExitFPSCamera();
        //			}
        //		}

        //		// Token: 0x060012A9 RID: 4777 RVA: 0x000B9824 File Offset: 0x000B7A24
        //		public void SuspendBattle(bool bSuspend)
        //		{
        //			if (this.m_bBattleSuspend != bSuspend)
        //			{
        //				if (bSuspend)
        //				{
        //					foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //					{
        //						keyValuePair.Value.SetEnable(!bSuspend);
        //						keyValuePair.Value.enabled = false;
        //					}
        //					BattleCameraController component = Camera.main.GetComponent<BattleCameraController>();
        //					if (component != null)
        //					{
        //						component.enabled = false;
        //					}
        //					GameStateManager.CurGameState = GameState.Normal;
        //					SmoothFollow2 component2 = Camera.main.GetComponent<SmoothFollow2>();
        //					component2.enabled = true;
        //				}
        //				else
        //				{
        //					foreach (KeyValuePair<int, BattlePlayer> keyValuePair2 in this.mBattlePlayers)
        //					{
        //						keyValuePair2.Value.SetEnable(!bSuspend);
        //						keyValuePair2.Value.enabled = true;
        //					}
        //					BattleCameraController component3 = Camera.main.GetComponent<BattleCameraController>();
        //					if (component3 != null)
        //					{
        //						component3.enabled = true;
        //					}
        //					GameStateManager.CurGameState = GameState.Battle;
        //					SmoothFollow2 component4 = Camera.main.GetComponent<SmoothFollow2>();
        //					component4.enabled = false;
        //				}
        //			}
        //			this.m_bBattleSuspend = bSuspend;
        //		}

        //		// Token: 0x060012AA RID: 4778 RVA: 0x000B99A0 File Offset: 0x000B7BA0
        //		public void SyncBattleFormation()
        //		{
        //			this.m_BattleFormation.SyncFrom(PalMain.GameMain.CurBattleFormationManager);
        //		}

        //		// Token: 0x060012AB RID: 4779 RVA: 0x000B99B8 File Offset: 0x000B7BB8
        //		public void RemoveBackupFromList(List<PalNPC> players)
        //		{
        //			for (int i = 0; i < players.Count; i++)
        //			{
        //				for (int j = 0; j < this.m_BattleFormation.m_Formations[0].m_Store; j++)
        //				{
        //					int index = this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas.Count - j - 1;
        //					if (players[i].Data.CharacterID == this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index].m_CharacterID)
        //					{
        //						int index2 = this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas.Count - this.m_BattleFormation.m_Formations[0].m_Store;
        //						this.m_BattleFormation.m_Formations[0].m_Store--;
        //						BattleFormationManager.InFormationCharaData value = new BattleFormationManager.InFormationCharaData(this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index2].m_CharacterID, this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index2].m_CharacterSkillGroup);
        //						this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index2] = this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index];
        //						this.m_BattleFormation.m_Formations[0].m_InFormationCharaDatas[index] = value;
        //						break;
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x060012AC RID: 4780 RVA: 0x000B9B50 File Offset: 0x000B7D50
        //		public void ReWriteBattleFormation(List<PalNPC> players)
        //		{
        //			BattleFormationManager.BattleFormationData battleFormationData = this.m_BattleFormation.m_Formations[0];
        //			BattleFormationManager.BattleFormationData battleFormationData2 = new BattleFormationManager.BattleFormationData();
        //			for (int i = 0; i < players.Count; i++)
        //			{
        //				for (int j = 0; j < battleFormationData.m_InFormationCharaDatas.Count; j++)
        //				{
        //					if (players[i].Data.CharacterID == battleFormationData.m_InFormationCharaDatas[j].m_CharacterID)
        //					{
        //						battleFormationData2.AddOrChangeCharacter(battleFormationData.m_InFormationCharaDatas[j].m_CharacterID, battleFormationData.m_InFormationCharaDatas[j].m_CharacterSkillGroup);
        //						break;
        //					}
        //				}
        //			}
        //			for (int k = 0; k < battleFormationData.m_InFormationCharaDatas.Count; k++)
        //			{
        //				bool flag = false;
        //				for (int l = 0; l < players.Count; l++)
        //				{
        //					if (players[l].Data.CharacterID == battleFormationData.m_InFormationCharaDatas[k].m_CharacterID)
        //					{
        //						flag = true;
        //						break;
        //					}
        //				}
        //				if (!flag)
        //				{
        //					battleFormationData2.AddOrChangeCharacter(battleFormationData.m_InFormationCharaDatas[k].m_CharacterID, battleFormationData.m_InFormationCharaDatas[k].m_CharacterSkillGroup);
        //				}
        //			}
        //			int num = 0;
        //			for (int m = 0; m < battleFormationData.m_InFormationCharaDatas.Count; m++)
        //			{
        //				if (battleFormationData.m_InFormationCharaDatas[m] != null)
        //				{
        //					num++;
        //				}
        //			}
        //			battleFormationData2.m_Store = num - players.Count;
        //			this.m_BattleFormation.m_Formations[0] = battleFormationData2;
        //		}

        //		// Token: 0x060012AD RID: 4781 RVA: 0x000B9CF8 File Offset: 0x000B7EF8
        //		public string GetBattleDescription()
        //		{
        //			if (!this.m_bRandomTask)
        //			{
        //				return Langue.get_string(131238UL, "UI");
        //			}
        //			if (this.m_RandomTask == null)
        //			{
        //				return Langue.get_string(131238UL, "UI");
        //			}
        //			if (this.m_BattleTime < this.m_RandomTask.m_Times[2])
        //			{
        //				return Langue.get_string(131242UL, "UI");
        //			}
        //			if (this.m_BattleTime < this.m_RandomTask.m_Times[1])
        //			{
        //				return Langue.get_string(131241UL, "UI");
        //			}
        //			if (this.m_BattleTime < this.m_RandomTask.m_Times[0])
        //			{
        //				return Langue.get_string(131240UL, "UI");
        //			}
        //			return Langue.get_string(131239UL, "UI");
        //		}

        //		// Token: 0x060012AE RID: 4782 RVA: 0x000B9DC8 File Offset: 0x000B7FC8
        //		public int GetYuanShen()
        //		{
        //			return this.m_YuanShen;
        //		}

        //		// Token: 0x060012AF RID: 4783 RVA: 0x000B9DD0 File Offset: 0x000B7FD0
        //		public string GetChengHao()
        //		{
        //			if (this.mTitleScript_C_Sharp != null)
        //			{
        //				return this.mTitleScript_C_Sharp.GetTitle();
        //			}
        //			return "无称号";
        //		}

        //		// Token: 0x060012B0 RID: 4784 RVA: 0x000B9DF0 File Offset: 0x000B7FF0
        //		public int GetMoney()
        //		{
        //			return this.m_Money;
        //		}

        //		// Token: 0x060012B1 RID: 4785 RVA: 0x000B9DF8 File Offset: 0x000B7FF8
        //		public int GetExp()
        //		{
        //			return this.m_Exp;
        //		}

        //		// Token: 0x060012B2 RID: 4786 RVA: 0x000B9E00 File Offset: 0x000B8000
        //		public void FreezeAll()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.AddBuff(40, null, null, true);
        //			}
        //		}

        //		// Token: 0x060012B3 RID: 4787 RVA: 0x000B9E70 File Offset: 0x000B8070
        //		public void SetUseDefaultEnd(bool bDefault)
        //		{
        //			this.m_bUseDefaultEndBattle = bDefault;
        //		}

        //		// Token: 0x060012B4 RID: 4788 RVA: 0x000B9E7C File Offset: 0x000B807C
        //		public void StopAllCharacterPalSE()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.ClearSkillQueueAndStopAction();
        //			}
        //		}

        //		// Token: 0x060012B5 RID: 4789 RVA: 0x000B9EE8 File Offset: 0x000B80E8
        //		public void SetRandomTask(PalBattleManager.RandomTask task)
        //		{
        //			this.m_RandomTask = task;
        //		}

        //		// Token: 0x060012B6 RID: 4790 RVA: 0x000B9EF4 File Offset: 0x000B80F4
        //		public float CheckRandomTask()
        //		{
        //			if (FlagManager.GetFlag(400014) == 0)
        //			{
        //				FlagManager.SetFlag(6010, 1, true);
        //			}
        //			if (this.m_bRandomTask && this.m_RandomTask != null)
        //			{
        //				if (this.m_BattleTime < this.m_RandomTask.m_Times[2])
        //				{
        //					return this.m_RandomTask.m_rewards[2];
        //				}
        //				if (this.m_BattleTime < this.m_RandomTask.m_Times[1])
        //				{
        //					return this.m_RandomTask.m_rewards[1];
        //				}
        //				if (this.m_BattleTime < this.m_RandomTask.m_Times[0])
        //				{
        //					return this.m_RandomTask.m_rewards[0];
        //				}
        //			}
        //			return 1f;
        //		}

        //		// Token: 0x060012B7 RID: 4791 RVA: 0x000B9FAC File Offset: 0x000B81AC
        //		public BattleSkill PlayWin(out int BattleID)
        //		{
        //			BattleID = -1;
        //			BattlePlayer lastAttackBP = this.GetLastAttackBP();
        //			if (lastAttackBP == null)
        //			{
        //				return null;
        //			}
        //			lastAttackBP.m_PlayerBattleState.SetNextState(13, false);
        //			BattlePlayerWin battlePlayerWin = (BattlePlayerWin)lastAttackBP.m_PlayerBattleState.mStates[13];
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value != lastAttackBP && !keyValuePair.Value.IsDie())
        //				{
        //					keyValuePair.Value.SetPause(true);
        //				}
        //			}
        //			BattleID = lastAttackBP.BattleID;
        //			return battlePlayerWin.GetBattleSkill();
        //		}

        //		// Token: 0x060012B8 RID: 4792 RVA: 0x000BA084 File Offset: 0x000B8284
        //		public void ActiveMonsterEnterEffect(int index)
        //		{
        //			switch (index)
        //			{
        //			case 0:
        //				this.LoginPlayer(8001);
        //				break;
        //			case 1:
        //				this.LoginPlayer(8001);
        //				break;
        //			case 2:
        //				this.LoginPlayer(8001);
        //				break;
        //			}
        //		}

        //		// Token: 0x060012B9 RID: 4793 RVA: 0x000BA0DC File Offset: 0x000B82DC
        //		public void AddMoneyToGame()
        //		{
        //			float num = this.CheckRandomTask();
        //			this.m_Money = (int)((float)this.m_Money * num * PalMain.Instance.MoneyRate);
        //			PalMain.ChangeMoney(this.m_Money);
        //		}

        //		// Token: 0x060012BA RID: 4794 RVA: 0x000BA118 File Offset: 0x000B8318
        //		public void AddExpToGame()
        //		{
        //			float num = this.CheckRandomTask();
        //			this.m_Exp = (int)((float)this.m_Exp * num);
        //			this.m_UpgradeList.Clear();
        //			for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
        //			{
        //				if (PlayersManager.ActivePlayers[i] != null)
        //				{
        //					PalNPC component = PlayersManager.ActivePlayers[i].GetComponent<PalNPC>();
        //					if (component != null && component.Data != null && component.Data.CharacterID < 6)
        //					{
        //						this.m_UpgradeList.Add(component.Data.CharacterID, component.Data.Level);
        //						int num2 = (int)((float)this.m_Exp * component.ExpRate);
        //						try
        //						{
        //							if (component != null && component.Data != null)
        //							{
        //								component.Data.Exp += num2;
        //							}
        //						}
        //						catch (Exception exception)
        //						{
        //							Debug.LogException(exception);
        //							break;
        //						}
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x060012BB RID: 4795 RVA: 0x000BA240 File Offset: 0x000B8440
        //		public void AddYuanShenToGame()
        //		{
        //			for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
        //			{
        //				if (PlayersManager.ActivePlayers[i] != null)
        //				{
        //					PalNPC component = PlayersManager.ActivePlayers[i].GetComponent<PalNPC>();
        //					if (component != null && component.Data != null && component.Data.CharacterID < 6)
        //					{
        //						int soul = component.Data.Soul;
        //						if (soul + this.m_YuanShen >= 9999)
        //						{
        //							component.Data.Soul = 9999;
        //						}
        //						else
        //						{
        //							component.Data.Soul += this.m_YuanShen;
        //						}
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x060012BC RID: 4796 RVA: 0x000BA304 File Offset: 0x000B8504
        //		public void AddItemsToGame()
        //		{
        //			foreach (KeyValuePair<uint, int> keyValuePair in this.m_Items)
        //			{
        //				ItemPackage.GetOrCreatePackage(1u).AddNewItem_Limit(keyValuePair.Key, keyValuePair.Value);
        //			}
        //		}

        //		// Token: 0x060012BD RID: 4797 RVA: 0x000BA37C File Offset: 0x000B857C
        //		public void AddItems(uint itemID, int num)
        //		{
        //			if (this.m_Items.ContainsKey(itemID))
        //			{
        //				this.m_Items[itemID] = this.m_Items[itemID] + num;
        //			}
        //			else
        //			{
        //				this.m_Items.Add(itemID, num);
        //			}
        //		}

        //		// Token: 0x060012BE RID: 4798 RVA: 0x000BA3C8 File Offset: 0x000B85C8
        //		public void AddYuanShen(int dYuanShen)
        //		{
        //			this.m_YuanShen += dYuanShen;
        //		}

        //		// Token: 0x060012BF RID: 4799 RVA: 0x000BA3D8 File Offset: 0x000B85D8
        //		public void AddExp(int dExp)
        //		{
        //			this.m_Exp += dExp;
        //		}

        //		// Token: 0x060012C0 RID: 4800 RVA: 0x000BA3E8 File Offset: 0x000B85E8
        //		public void AddMoney(int dMoney)
        //		{
        //			this.m_Money += dMoney;
        //		}

        //		// Token: 0x060012C1 RID: 4801 RVA: 0x000BA3F8 File Offset: 0x000B85F8
        //		public Dictionary<int, int> GetBeforeUpgradeLevel()
        //		{
        //			return this.m_UpgradeList;
        //		}

        //		// Token: 0x060012C2 RID: 4802 RVA: 0x000BA400 File Offset: 0x000B8600
        //		public bool GetSkipOutBattleResult()
        //		{
        //			return this.m_bSkipOutBattleResult;
        //		}

        //		// Token: 0x060012C3 RID: 4803 RVA: 0x000BA408 File Offset: 0x000B8608
        //		public void SetSkipOutBattleResult(bool bSkip)
        //		{
        //			this.m_bSkipOutBattleResult = bSkip;
        //		}

        //		// Token: 0x060012C4 RID: 4804 RVA: 0x000BA414 File Offset: 0x000B8614
        //		public List<PalNPC> GetRebattleEnemies()
        //		{
        //			return this.m_Rebattle_enemys;
        //		}

        //		// Token: 0x170001F1 RID: 497
        //		// (get) Token: 0x060012C5 RID: 4805 RVA: 0x000BA41C File Offset: 0x000B861C
        //		// (set) Token: 0x060012C6 RID: 4806 RVA: 0x000BA424 File Offset: 0x000B8624
        //		public bool bEnableGoToBattle
        //		{
        //			get
        //			{
        //				return this.m_bEnableGoToBattle;
        //			}
        //			set
        //			{
        //				this.m_bEnableGoToBattle = value;
        //			}
        //		}

        //		// Token: 0x060012C7 RID: 4807 RVA: 0x000BA430 File Offset: 0x000B8630
        //		public int GetAllEnemyHP()
        //		{
        //			int num = 0;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction != BattlePlayer.FACTION.FACTION_A)
        //				{
        //					num += keyValuePair.Value.GetPalNPC().Data.HPMPDP.HP;
        //				}
        //			}
        //			return num;
        //		}

        //		// Token: 0x060012C8 RID: 4808 RVA: 0x000BA4C4 File Offset: 0x000B86C4
        //		public BattlePlayer GetLastAttackBP()
        //		{
        //			if (this.m_LastAttackBp != null && !this.m_LastAttackBp.IsDie() && !this.m_LastAttackBp.m_bProxy)
        //			{
        //				return this.m_LastAttackBp;
        //			}
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && !keyValuePair.Value.IsDie() && keyValuePair.Value.GetFollowTarget() == null)
        //				{
        //					return keyValuePair.Value;
        //				}
        //			}
        //			if (this.m_LastAttackBp == null)
        //			{
        //				foreach (KeyValuePair<int, BattlePlayer> keyValuePair2 in this.mBattlePlayers)
        //				{
        //					if (keyValuePair2.Value.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && keyValuePair2.Value.GetFollowTarget() == null && keyValuePair2.Value.IsDie())
        //					{
        //						keyValuePair2.Value.Revive();
        //						return this.m_LastAttackBp;
        //					}
        //				}
        //				return null;
        //			}
        //			if (this.m_LastAttackBp.IsDie())
        //			{
        //				this.m_LastAttackBp.Revive();
        //			}
        //			return this.m_LastAttackBp;
        //		}

        //		// Token: 0x060012C9 RID: 4809 RVA: 0x000BA680 File Offset: 0x000B8880
        //		public void FreezeAllPlayersExcept(int bpID)
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				if (bpID != value.BattleID)
        //				{
        //					keyValuePair.Value.AddBuff(40, null, keyValuePair.Value, true);
        //				}
        //			}
        //		}

        //		// Token: 0x060012CA RID: 4810 RVA: 0x000BA70C File Offset: 0x000B890C
        //		public void DisappearExceptMainRole(int mainrole)
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				BattlePlayer value = keyValuePair.Value;
        //				if (value.BattleID > 6)
        //				{
        //					if (value.GetPalNPC().Data.CharacterID == 8103 || value.GetPalNPC().Data.CharacterID == 8104)
        //					{
        //						value.SetVisible(false);
        //					}
        //					else
        //					{
        //						MaterialChanger materialChanger = value.gameObject.AddComponent<MaterialChanger>();
        //						materialChanger.Start();
        //						materialChanger.ChangeMaterialPermanent(PalBattleManager.Instance().m_DisappearMaterial, 1f, -1f);
        //						value.SetPlayerTranslation(new Vector3(0f, 0f, 0f), Quaternion.identity);
        //					}
        //				}
        //				else if (value.BattleID != mainrole)
        //				{
        //					value.SetPlayerTranslation(new Vector3(0f, 0f, 0f), Quaternion.identity);
        //				}
        //			}
        //		}

        //		// Token: 0x060012CB RID: 4811 RVA: 0x000BA83C File Offset: 0x000B8A3C
        //		public void FreezeAllPlayers()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (!keyValuePair.Value.IsDie())
        //				{
        //					keyValuePair.Value.AddBuff(40, null, keyValuePair.Value, true);
        //				}
        //			}
        //		}

        //		// Token: 0x060012CC RID: 4812 RVA: 0x000BA8C4 File Offset: 0x000B8AC4
        //		public void PauseAllPlayers()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (!keyValuePair.Value.IsDie())
        //				{
        //					keyValuePair.Value.SetPause(true);
        //				}
        //			}
        //		}

        //		// Token: 0x060012CD RID: 4813 RVA: 0x000BA944 File Offset: 0x000B8B44
        //		public void ResumeAllPlayers()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				keyValuePair.Value.SetPause(false);
        //			}
        //		}

        //		// Token: 0x060012CE RID: 4814 RVA: 0x000BA9B0 File Offset: 0x000B8BB0
        //		public bool CheckWin()
        //		{
        //			bool result = true;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction != BattlePlayer.FACTION.FACTION_A && !keyValuePair.Value.IsDie() && keyValuePair.Value.GetFollowTarget() == null)
        //				{
        //					result = false;
        //				}
        //			}
        //			return result;
        //		}

        //		// Token: 0x060012CF RID: 4815 RVA: 0x000BAA50 File Offset: 0x000B8C50
        //		public void CheckFail()
        //		{
        //			if (this.mCurrentBattleState == PalBattleManager.BATTLE_STATE.RESUME_BATTLE)
        //			{
        //				bool flag = true;
        //				foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //				{
        //					if (keyValuePair.Value.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && keyValuePair.Value.BattleID <= 5 && !keyValuePair.Value.IsDie() && !keyValuePair.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.DIE) && keyValuePair.Value.GetFollowTarget() == null)
        //					{
        //						flag = false;
        //					}
        //				}
        //				if (flag)
        //				{
        //					this.SetBattleState(PalBattleManager.BATTLE_STATE.LOSS_BATTLE);
        //				}
        //			}
        //		}

        //		// Token: 0x060012D0 RID: 4816 RVA: 0x000BAB2C File Offset: 0x000B8D2C
        //		public void RemoveAllPlayerBuff()
        //		{
        //			Dictionary<int, BattlePlayer> dictionary = new Dictionary<int, BattlePlayer>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
        //			}
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair2 in dictionary)
        //			{
        //				keyValuePair2.Value.CancelAllBuffs();
        //			}
        //		}

        //		// Token: 0x170001F2 RID: 498
        //		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x000BABFC File Offset: 0x000B8DFC
        //		// (set) Token: 0x060012D2 RID: 4818 RVA: 0x000BAC08 File Offset: 0x000B8E08
        //		public PalBattleManager.BATTLE_MODE m_BattleMode
        //		{
        //			get
        //			{
        //				return OptionConfig.GetInstance().BattleMode;
        //			}
        //			set
        //			{
        //				OptionConfig.GetInstance().BattleMode = value;
        //			}
        //		}

        //		// Token: 0x060012D3 RID: 4819 RVA: 0x000BAC18 File Offset: 0x000B8E18
        //		public void SetControlledPlayerWait(bool bWait)
        //		{
        //			if (this.m_BattleMode == PalBattleManager.BATTLE_MODE.BATTLE_MODE_DISCREET)
        //			{
        //				this.m_bControlledPlayerWait = bWait;
        //			}
        //			else
        //			{
        //				this.m_bControlledPlayerWait = false;
        //			}
        //		}

        //		// Token: 0x060012D4 RID: 4820 RVA: 0x000BAC3C File Offset: 0x000B8E3C
        //		public void SetTurnMode(int id)
        //		{
        //			if (id == 1)
        //			{
        //				this.m_BattleMode = PalBattleManager.BATTLE_MODE.BATTLE_MODE_DISCREET;
        //			}
        //			else
        //			{
        //				this.m_BattleMode = PalBattleManager.BATTLE_MODE.BATTLE_MODE_CONTINUE;
        //				this.m_bControlledPlayerWait = false;
        //			}
        //		}

        //		// Token: 0x060012D5 RID: 4821 RVA: 0x000BAC60 File Offset: 0x000B8E60
        //		public bool GetControlledPlayerWait()
        //		{
        //			return this.m_bControlledPlayerWait;
        //		}

        //		// Token: 0x060012D6 RID: 4822 RVA: 0x000BAC68 File Offset: 0x000B8E68
        //		public void ChangeTactical(PalBattleManager.PLAYER_AI_TACTICAL tac)
        //		{
        //			if (tac != this.m_CurrentTactical)
        //			{
        //				this.GetCurrentControllCharater().PlayTacSound((int)tac);
        //			}
        //			this.m_CurrentTactical = tac;
        //		}

        //		// Token: 0x060012D7 RID: 4823 RVA: 0x000BAC8C File Offset: 0x000B8E8C
        //		public void OnFinishLoadingOnEnemy(PalNPC npc)
        //		{
        //			this.m_unfinishLoadingCount--;
        //			if (this.m_unfinishLoadingCount == 0)
        //			{
        //				if (this.m_bCommonBattle)
        //				{
        //					this.StartBattle(this.m_players, this.m_monsters, this.m_bid, this.m_gp, false, this.m_bChangeMusic, true);
        //				}
        //				else
        //				{
        //					this.StartBattle(this.m_Rebattle_players, this.m_monsters, this.m_bid, this.m_gp, false, this.m_bChangeMusic, true);
        //				}
        //			}
        //		}

        //		// Token: 0x060012D8 RID: 4824 RVA: 0x000BAD10 File Offset: 0x000B8F10
        //		public bool CanEscape()
        //		{
        //			MonsterGroupDataManager.MonsterGroupData data = PalBattleManager.Instance().GetMonsterGroupDataManager().GetData(this.m_CurrentMonsterGroup);
        //			return data != null && data.mEscapeChance != 0f;
        //		}

        //		// Token: 0x060012D9 RID: 4825 RVA: 0x000BAD4C File Offset: 0x000B8F4C
        //		public void SetFixBattleDirection(bool bFix)
        //		{
        //			this.m_BFixedBattleDirection = bFix;
        //		}

        //		// Token: 0x060012DA RID: 4826 RVA: 0x000BAD58 File Offset: 0x000B8F58
        //		public bool GetFixBattleDirection()
        //		{
        //			return this.m_BFixedBattleDirection;
        //		}

        //		// Token: 0x060012DB RID: 4827 RVA: 0x000BAD60 File Offset: 0x000B8F60
        //		public List<int> GetBattlePlayerByDataID(int id)
        //		{
        //			List<int> list = new List<int>();
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.GetPalNPC().Data.CharacterID == id)
        //				{
        //					list.Add(id);
        //				}
        //			}
        //			return list;
        //		}

        //		// Token: 0x060012DC RID: 4828 RVA: 0x000BADEC File Offset: 0x000B8FEC
        //		public void UpdateEnemyMaxRadius()
        //		{
        //			float num = 0f;
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Key >= 10 && keyValuePair.Value.GetRadius() > num)
        //				{
        //					num = keyValuePair.Value.GetRadius();
        //				}
        //			}
        //			this.m_EnemyMaxRadius = Mathf.Lerp(this.m_EnemyMaxRadius, num, 0.6f * Time.deltaTime);
        //		}

        //		// Token: 0x060012DD RID: 4829 RVA: 0x000BAE9C File Offset: 0x000B909C
        //		public float GetEnemyMaxRadius()
        //		{
        //			return this.m_EnemyMaxRadius;
        //		}

        //		// Token: 0x060012DE RID: 4830 RVA: 0x000BAEA4 File Offset: 0x000B90A4
        //		public MonsterGroupDataManager.MonsterGroupData GetCurrentMonsterGroupData()
        //		{
        //			return PalBattleManager.Instance().GetMonsterGroupDataManager().GetData(this.m_CurrentMonsterGroup);
        //		}

        //		// Token: 0x060012DF RID: 4831 RVA: 0x000BAEBC File Offset: 0x000B90BC
        //		public bool GetCanChanllengeAgain()
        //		{
        //			MonsterGroupDataManager.MonsterGroupData data = PalBattleManager.Instance().GetMonsterGroupDataManager().GetData(this.m_CurrentMonsterGroup);
        //			if (data != null)
        //			{
        //				return data.mChanllange;
        //			}
        //			Debug.LogError("重新挑战画面找不到当前怪物组是否可重新挑战" + this.m_CurrentMonsterGroup.ToString());
        //			return true;
        //		}

        //		// Token: 0x060012E0 RID: 4832 RVA: 0x000BAF08 File Offset: 0x000B9108
        //		public void GetAward(PalNPC palNpc)
        //		{
        //			PalBattleManager.Instance().AddYuanShen(palNpc.Data.Monster.Soul);
        //			PalBattleManager.Instance().AddExp(palNpc.Data.Monster.Exp);
        //			PalBattleManager.Instance().AddMoney(palNpc.Data.Monster.Money);
        //			for (int i = 0; i < palNpc.Data.Monster.LegacyItems.Length; i++)
        //			{
        //				float num = UnityEngine.Random.Range(0f, 1f) * 100f;
        //				if (num < palNpc.Data.Monster.LegacyItems[i].Chance)
        //				{
        //					int count = (int)palNpc.Data.Monster.LegacyItems[i].Count;
        //					if (count > 0)
        //					{
        //						PalBattleManager.Instance().AddItems(palNpc.Data.Monster.LegacyItems[i].ItemType, count);
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x060012E1 RID: 4833 RVA: 0x000BAFFC File Offset: 0x000B91FC
        //		public void SetFriendOffset(float offset)
        //		{
        //			this.m_FriendOffset = offset;
        //		}

        //		// Token: 0x060012E2 RID: 4834 RVA: 0x000BB008 File Offset: 0x000B9208
        //		public void SetEnemyOffset(float offset)
        //		{
        //			this.m_EnemyOffset = offset;
        //		}

        //		// Token: 0x060012E3 RID: 4835 RVA: 0x000BB014 File Offset: 0x000B9214
        //		public float GetFriendOffset()
        //		{
        //			return this.m_FriendOffset;
        //		}

        //		// Token: 0x060012E4 RID: 4836 RVA: 0x000BB01C File Offset: 0x000B921C
        //		public float GetEnemyOffset()
        //		{
        //			return this.m_EnemyOffset;
        //		}

        //		// Token: 0x060012E5 RID: 4837 RVA: 0x000BB024 File Offset: 0x000B9224
        //		public bool AllFriendDie()
        //		{
        //			foreach (KeyValuePair<int, BattlePlayer> keyValuePair in this.mBattlePlayers)
        //			{
        //				if (keyValuePair.Value.mPlyerFaction == BattlePlayer.FACTION.FACTION_A && keyValuePair.Value.BattleID < 6 && !keyValuePair.Value.IsDie() && !keyValuePair.Value.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.DIE))
        //				{
        //					return false;
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x060012E6 RID: 4838 RVA: 0x000BB0D4 File Offset: 0x000B92D4
        //		private void CalculateOffset(List<Vector3> my, List<Vector3> they)
        //		{
        //			Vector3 vector = Vector3.zero;
        //			Vector3 vector2 = Vector3.zero;
        //			float num = 0f;
        //			float num2 = 0f;
        //			int count = they.Count;
        //			int count2 = my.Count;
        //			for (int i = 0; i < my.Count; i++)
        //			{
        //				vector2 = my[i] - this.m_PolarLBI.GetCenter();
        //				vector2.y = 0f;
        //				num2 += vector2.magnitude;
        //			}
        //			for (int j = 0; j < they.Count; j++)
        //			{
        //				vector = they[j] - this.m_PolarLBI.GetCenter();
        //				vector.y = 0f;
        //				num += vector.magnitude;
        //			}
        //			if (count2 != 0)
        //			{
        //				num2 /= (float)count2;
        //			}
        //			if (count != 0)
        //			{
        //				num /= (float)count;
        //			}
        //			this.SetFriendOffset(Mathf.Clamp(num2, 3f, 10f));
        //			this.SetEnemyOffset(Mathf.Clamp(num, 3f, 10f));
        //		}

        //		// Token: 0x060012E7 RID: 4839 RVA: 0x000BB1E4 File Offset: 0x000B93E4
        //		public void SetSelectedPlayer(List<GameObject> objs)
        //		{
        //			this.m_SelectedPlayers = objs;
        //		}

        //		// Token: 0x060012E8 RID: 4840 RVA: 0x000BB1F0 File Offset: 0x000B93F0
        //		public List<GameObject> GetSelectedPlayer()
        //		{
        //			return this.m_SelectedPlayers;
        //		}

        //		// Token: 0x060012E9 RID: 4841 RVA: 0x000BB1F8 File Offset: 0x000B93F8
        //		public void ShowEnemyHPUI(bool bShow)
        //		{
        //			this.m_bShowHPUI = bShow;
        //		}

        //		// Token: 0x060012EA RID: 4842 RVA: 0x000BB204 File Offset: 0x000B9404
        //		public bool GetShowEnemyHPUI()
        //		{
        //			return this.m_bShowHPUI;
        //		}

        //		// Token: 0x060012EB RID: 4843 RVA: 0x000BB20C File Offset: 0x000B940C
        //		public void ShowGongLiUI(bool bShow, bool bShowTac, bool bShowTeam)
        //		{
        //			if (UIManager.Instance.Panel_Battle.transform.Find("MenuLocation").gameObject.activeSelf != bShow)
        //			{
        //				UIManager.Instance.Panel_Battle.transform.Find("MenuLocation").gameObject.SetActive(bShow);
        //			}
        //			if (FlagManager.GetFlag(1) >= 204030)
        //			{
        //				if (UIManager.Instance.Panel_Battle.transform.Find("DP").gameObject.activeSelf != bShow)
        //				{
        //					UIManager.Instance.Panel_Battle.transform.Find("DP").gameObject.SetActive(bShow);
        //				}
        //			}
        //			else
        //			{
        //				UIManager.Instance.Panel_Battle.transform.Find("DP").gameObject.SetActive(false);
        //			}
        //			if (UIManager.Instance.Panel_Battle.transform.Find("PlayerLocation").gameObject.activeSelf != bShowTeam)
        //			{
        //				UIManager.Instance.Panel_Battle.transform.Find("PlayerLocation").gameObject.SetActive(bShowTeam);
        //			}
        //			if (UIManager.Instance.Panel_Battle.transform.Find("Tactical").gameObject.activeSelf != bShowTac)
        //			{
        //				UIManager.Instance.Panel_Battle.transform.Find("Tactical").gameObject.SetActive(bShowTac);
        //			}
        //		}

        //		// Token: 0x060012EC RID: 4844 RVA: 0x000BB388 File Offset: 0x000B9588
        //		public void CacheSound(string path)
        //		{
        //			if (path != null && path != string.Empty)
        //			{
        //				FileLoader.PreloadAssetBundleFromFileAsync(path.ToAssetBundlePath());
        //			}
        //		}

        //		// Token: 0x060012ED RID: 4845 RVA: 0x000BB3AC File Offset: 0x000B95AC
        //		public void RemoveSoundCache(string path)
        //		{
        //			if (path != null && path != string.Empty)
        //			{
        //				FileLoader.UnloadAssetBundle(path.ToAssetBundlePath());
        //			}
        //		}

        //		// Token: 0x060012EE RID: 4846 RVA: 0x000BB3D0 File Offset: 0x000B95D0
        //		public void PlaySound(string path, BattlePlayer bp)
        //		{
        //			AssetBundle bundle = FileLoader.LoadAssetBundleFromFile(path.ToAssetBundlePath());
        //			AudioClip clip = bundle.MainAsset5() as AudioClip;
        //			AudioSource audioSource = bp.GetAudioSource();
        //			audioSource.clip = clip;
        //			audioSource.volume = OptionConfig.GetInstance().SoundEffect;
        //			audioSource.Play();
        //		}

        //		// Token: 0x060012EF RID: 4847 RVA: 0x000BB41C File Offset: 0x000B961C
        //		public int GetDandang(BattlePlayer.FACTION TargetFac)
        //		{
        //			foreach (int num in PalBattleManager.Instance().mDangdangList)
        //			{
        //				BattlePlayer battlePlayerByBattleID = PalBattleManager.Instance().GetBattlePlayerByBattleID(num);
        //				if (battlePlayerByBattleID != null && battlePlayerByBattleID.mPlyerFaction == TargetFac && battlePlayerByBattleID.GetFollowTarget() == null && !battlePlayerByBattleID.IsDie())
        //				{
        //					return num;
        //				}
        //			}
        //			return -1;
        //		}

        //		// Token: 0x060012F0 RID: 4848 RVA: 0x000BB4CC File Offset: 0x000B96CC
        //		public void Save(BinaryWriter writer)
        //		{
        //			writer.Write(this.mNewTPASystem.m_CurrentTPA[0]);
        //			writer.Write(this.mNewTPASystem.m_CurrentTPA[1]);
        //			writer.Write(this.mNewTPASystem.m_CurrentTPA[2]);
        //		}

        //		// Token: 0x060012F1 RID: 4849 RVA: 0x000BB508 File Offset: 0x000B9708
        //		public void Load(BinaryReader reader)
        //		{
        //			this.mNewTPASystem.m_CurrentTPA[0] = reader.ReadSingle();
        //			this.mNewTPASystem.m_CurrentTPA[1] = reader.ReadSingle();
        //			this.mNewTPASystem.m_CurrentTPA[2] = reader.ReadSingle();
        //		}

        //		// Token: 0x060012F2 RID: 4850 RVA: 0x000BB550 File Offset: 0x000B9750
        //		public int GetYueJinZhaoSkillGroup()
        //		{
        //			return this.m_YueSkillGroup;
        //		}

        //		// Token: 0x060012F3 RID: 4851 RVA: 0x000BB558 File Offset: 0x000B9758
        //		public void SetYueJinZhaoSkillGroup(int s)
        //		{
        //			this.m_YueSkillGroup = s;
        //		}

        //		// Token: 0x060012F4 RID: 4852 RVA: 0x000BB564 File Offset: 0x000B9764
        //		public void SaveCameraParam()
        //		{
        //			ScreenTexturing component = Camera.main.GetComponent<ScreenTexturing>();
        //			if (component != null)
        //			{
        //				this.m_bScreenTexturing = true;
        //				this.m_ScreenTexturingShader = component.shader;
        //				this.m_ScreenTexturingEnabled = component.enabled;
        //				this.m_ScreenTexturingBlendMode = component.blendMode;
        //				this.m_ScreenTexturingInverseMask = component.inverseMask;
        //				this.m_ScreenTexturingMaskTexture = component.maskTexture;
        //				this.m_ScreenTexturingTex = component.tex;
        //				this.m_ScreenTexturingT = component.t;
        //				this.m_ScreenTexturingUvAnimSpeed = component.uvAnimSpeed;
        //				this.m_ScreenTexturingDisableUVAnim = component.disableUVAnim;
        //			}
        //			else
        //			{
        //				this.m_bScreenTexturing = false;
        //			}
        //			HSL component2 = Camera.main.GetComponent<HSL>();
        //			if (component2 != null)
        //			{
        //				this.m_bHSL = true;
        //				this.m_HSLShader = component2.shader;
        //				this.m_HSLEnabled = component2.enabled;
        //				this.m_HSLMaskTexture = component2.maskTexture;
        //				this.m_HSLInverseMask = component2.inverseMask;
        //				this.m_HSLT = component2.t;
        //				this.m_HSLHue = component2.hue;
        //				this.m_HSLSaturation = component2.saturation;
        //				this.m_HSLLightness = component2.lightness;
        //				this.m_HSLContrast = component2.contrast;
        //			}
        //			else
        //			{
        //				this.m_bHSL = false;
        //			}
        //			RadialBlur component3 = Camera.main.GetComponent<RadialBlur>();
        //			if (component3 != null)
        //			{
        //				this.m_bRadialBlur = true;
        //				this.m_RadialBlurShader = component3.shader;
        //				this.m_RadialBlurEnabled = component3.enabled;
        //				this.m_RadialBlurMaskTexture = component3.maskTexture;
        //				this.m_RadialBlurInverseMask = component3.inverseMask;
        //				this.m_RadialBlurT = component3.t;
        //				this.m_RadialBlurBlurStrength = component3.blurStrength;
        //				this.m_RadialBlurSampleDist = component3.sampleDist;
        //				this.m_RadialBlurCenterX = component3.centerX;
        //				this.m_RadialBlurCenterY = component3.centerY;
        //			}
        //			else
        //			{
        //				this.m_bRadialBlur = false;
        //			}
        //			Disturb component4 = Camera.main.GetComponent<Disturb>();
        //			if (component4 != null)
        //			{
        //				this.m_bDisturb = true;
        //				this.m_DisturbShader = component4.shader;
        //				this.m_DisturbEnabled = component4.enabled;
        //				this.m_DisturbMaskTexture = component4.maskTexture;
        //				this.m_DisturbInverseMask = component4.inverseMask;
        //				this.m_DisturbT = component4.t;
        //				this.m_DisturbDisturbTex = component4.disturbTex;
        //				this.m_DisturbStrength = component4.disturbStrength;
        //				this.m_DisturbXSpeed = component4.xSpeed;
        //				this.m_DisturbYSpeed = component4.ySpeed;
        //			}
        //			else
        //			{
        //				this.m_bDisturb = false;
        //			}
        //		}

        //		// Token: 0x060012F5 RID: 4853 RVA: 0x000BB7CC File Offset: 0x000B99CC
        //		public void LoadCameraParam()
        //		{
        //			if (Camera.main == null)
        //			{
        //				Debug.LogError("主摄像机检测为空");
        //				return;
        //			}
        //			if (this.m_bScreenTexturing)
        //			{
        //				ScreenTexturing component = Camera.main.GetComponent<ScreenTexturing>();
        //				if (component != null)
        //				{
        //					component.shader = this.m_ScreenTexturingShader;
        //					component.enabled = this.m_ScreenTexturingEnabled;
        //					component.blendMode = this.m_ScreenTexturingBlendMode;
        //					component.inverseMask = this.m_ScreenTexturingInverseMask;
        //					component.maskTexture = this.m_ScreenTexturingMaskTexture;
        //					component.tex = this.m_ScreenTexturingTex;
        //					component.t = 0f;
        //					component.uvAnimSpeed = this.m_ScreenTexturingUvAnimSpeed;
        //					component.disableUVAnim = this.m_ScreenTexturingDisableUVAnim;
        //				}
        //			}
        //			else if (Camera.main != null)
        //			{
        //				ScreenTexturing component2 = Camera.main.GetComponent<ScreenTexturing>();
        //				if (component2 != null)
        //				{
        //					component2.enabled = false;
        //				}
        //			}
        //			if (this.m_bHSL)
        //			{
        //				HSL component3 = Camera.main.GetComponent<HSL>();
        //				if (component3 != null)
        //				{
        //					component3.shader = this.m_HSLShader;
        //					component3.enabled = this.m_HSLEnabled;
        //					component3.maskTexture = this.m_HSLMaskTexture;
        //					component3.inverseMask = this.m_HSLInverseMask;
        //					component3.t = 0f;
        //					component3.hue = this.m_HSLHue;
        //					component3.saturation = this.m_HSLSaturation;
        //					component3.lightness = this.m_HSLLightness;
        //					component3.contrast = this.m_HSLContrast;
        //				}
        //			}
        //			else
        //			{
        //				HSL component4 = Camera.main.GetComponent<HSL>();
        //				if (component4 != null)
        //				{
        //					component4.enabled = false;
        //				}
        //			}
        //			if (this.m_bRadialBlur)
        //			{
        //				RadialBlur component5 = Camera.main.GetComponent<RadialBlur>();
        //				if (component5 != null)
        //				{
        //					component5.shader = this.m_RadialBlurShader;
        //					component5.enabled = this.m_RadialBlurEnabled;
        //					component5.maskTexture = this.m_RadialBlurMaskTexture;
        //					component5.inverseMask = this.m_RadialBlurInverseMask;
        //					component5.t = 0f;
        //					component5.blurStrength = this.m_RadialBlurBlurStrength;
        //					component5.sampleDist = this.m_RadialBlurSampleDist;
        //					component5.centerX = this.m_RadialBlurCenterX;
        //					component5.centerY = this.m_RadialBlurCenterY;
        //				}
        //			}
        //			else
        //			{
        //				RadialBlur component6 = Camera.main.GetComponent<RadialBlur>();
        //				if (component6 != null)
        //				{
        //					component6.enabled = false;
        //				}
        //			}
        //			if (this.m_bDisturb)
        //			{
        //				Disturb component7 = Camera.main.GetComponent<Disturb>();
        //				if (component7 != null)
        //				{
        //					component7.shader = this.m_DisturbShader;
        //					component7.enabled = this.m_DisturbEnabled;
        //					component7.maskTexture = this.m_DisturbMaskTexture;
        //					component7.inverseMask = this.m_DisturbInverseMask;
        //					component7.t = 0f;
        //					component7.disturbTex = this.m_DisturbDisturbTex;
        //					component7.disturbStrength = this.m_DisturbStrength;
        //					component7.xSpeed = this.m_DisturbXSpeed;
        //					component7.ySpeed = this.m_DisturbYSpeed;
        //				}
        //			}
        //			else
        //			{
        //				Disturb component8 = Camera.main.GetComponent<Disturb>();
        //				if (component8 != null)
        //				{
        //					component8.enabled = false;
        //				}
        //			}
        //		}

        //		// Token: 0x060012F6 RID: 4854 RVA: 0x000BBAE0 File Offset: 0x000B9CE0
        //		public void SaveLastCamPosRot(Vector3 pos, Quaternion rot)
        //		{
        //			this.m_CutScenePos = pos;
        //			this.m_CutSceneRot = rot;
        //		}

        //		// Token: 0x060012F7 RID: 4855 RVA: 0x000BBAF0 File Offset: 0x000B9CF0
        //		public void LoadLastCamPosRot(out Vector3 pos, out Quaternion rot)
        //		{
        //			pos = this.m_CutScenePos;
        //			rot = this.m_CutSceneRot;
        //		}

        //		// Token: 0x060012F8 RID: 4856 RVA: 0x000BBB0C File Offset: 0x000B9D0C
        //		public void SetCameraPitch(float pitch)
        //		{
        //			if (this.m_CamCtrl == null)
        //			{
        //				this.m_CamCtrl = Camera.main.gameObject.GetComponent<BattleCameraController>();
        //			}
        //			if (this.m_CamCtrl != null)
        //			{
        //				float camPitchRad = Mathf.Lerp(this.m_CamCtrl.GetCamPitchRad(), pitch, Time.deltaTime * 0.6f);
        //				this.m_CamCtrl.SetCamPitchRad(camPitchRad);
        //			}
        //		}

        //		// Token: 0x060012F9 RID: 4857 RVA: 0x000BBB7C File Offset: 0x000B9D7C
        //		public void AbnormalExitBattle()
        //		{
        //			OutBattlePerformer component = Camera.main.gameObject.GetComponent<OutBattlePerformer>();
        //			if (component != null)
        //			{
        //				UnityEngine.Object.Destroy(component);
        //			}
        //			Debug.LogError("异常情况下结束战斗");
        //			this.CleanUpBattleField(false);
        //			this.EndBattle(false);
        //		}

        //		// Token: 0x060012FA RID: 4858 RVA: 0x000BBBC4 File Offset: 0x000B9DC4
        //		public void SetNeverFail(bool bNeverFail)
        //		{
        //			this.m_bNeverFail = bNeverFail;
        //		}

        //		// Token: 0x060012FB RID: 4859 RVA: 0x000BBBD0 File Offset: 0x000B9DD0
        //		public bool GetNeverFail()
        //		{
        //			return this.m_bNeverFail;
        //		}

        //		// Token: 0x060012FC RID: 4860 RVA: 0x000BBBD8 File Offset: 0x000B9DD8
        //		public void SetFixPlayer(int Player)
        //		{
        //			bool flag = false;
        //			for (int i = 0; i < this.m_FixedPlayer.Count; i++)
        //			{
        //				if (this.m_FixedPlayer[i] == Player)
        //				{
        //					flag = true;
        //					break;
        //				}
        //			}
        //			if (!flag)
        //			{
        //				this.m_FixedPlayer.Add(Player);
        //			}
        //		}

        //		// Token: 0x060012FD RID: 4861 RVA: 0x000BBC30 File Offset: 0x000B9E30
        //		public bool IsFixedPlayer(int player)
        //		{
        //			for (int i = 0; i < this.m_FixedPlayer.Count; i++)
        //			{
        //				if (this.m_FixedPlayer[i] == player)
        //				{
        //					return true;
        //				}
        //			}
        //			return false;
        //		}

        //		// Token: 0x060012FE RID: 4862 RVA: 0x000BBC70 File Offset: 0x000B9E70
        //		public void SetCameraLimit(float r)
        //		{
        //			this.m_CameraRadiusLimit = r;
        //		}

        //		// Token: 0x060012FF RID: 4863 RVA: 0x000BBC7C File Offset: 0x000B9E7C
        //		public void SetYawClamp(float r)
        //		{
        //			this.m_CameraYawClamp = r;
        //		}

        //		// Token: 0x06001300 RID: 4864 RVA: 0x000BBC88 File Offset: 0x000B9E88
        //		public void ScriptWin()
        //		{
        //			this.m_bScriptWin = true;
        //		}

        //		// Token: 0x06001301 RID: 4865 RVA: 0x000BBC94 File Offset: 0x000B9E94
        //		public bool IsEnteringBattle()
        //		{
        //			return this.m_bEnterBattle;
        //		}

        //		// Token: 0x06001302 RID: 4866 RVA: 0x000BBC9C File Offset: 0x000B9E9C
        //		public void ResetExpression()
        //		{
        //			for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
        //			{
        //				if (i != 6)
        //				{
        //					if (PlayersManager.ActivePlayers[i] != null)
        //					{
        //						GameObject modelObj = PlayersManager.ActivePlayers[i].GetModelObj(false);
        //						if (modelObj != null)
        //						{
        //							SkinnedMeshRenderer face = modelObj.GetFace();
        //							if (face != null)
        //							{
        //								for (int j = 0; j < 50; j++)
        //								{
        //									face.SetBlendShapeWeight(j, 0f);
        //								}
        //							}
        //						}
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06001303 RID: 4867 RVA: 0x000BBD38 File Offset: 0x000B9F38
        //		public void Capture()
        //		{
        //			if (this.m_scObject != null)
        //			{
        //				UnityEngine.Object.Destroy(this.m_scObject);
        //			}
        //			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("ScreenCaptureQuad"));
        //			ScreenCapture component = gameObject.GetComponent<ScreenCapture>();
        //			gameObject.transform.parent = Camera.main.transform;
        //			gameObject.transform.localScale = Vector3.one;
        //			gameObject.transform.localPosition = Vector3.zero;
        //			gameObject.transform.localRotation = Quaternion.identity;
        //			this.m_scObject = gameObject;
        //			component.Capture();
        //			if (this.m_bLastCap)
        //			{
        //				return;
        //			}
        //			this.m_bLastCap = true;
        //		}

        //		// Token: 0x06001304 RID: 4868 RVA: 0x000BBDE4 File Offset: 0x000B9FE4
        //		public void DeCapture()
        //		{
        //			if (this.m_scObject != null)
        //			{
        //				UnityEngine.Object.Destroy(this.m_scObject);
        //			}
        //			this.m_scObject = null;
        //			if (Camera.main != null)
        //			{
        //				ScreenCapture[] componentsInChildren = Camera.main.GetComponentsInChildren<ScreenCapture>();
        //				for (int i = 0; i < componentsInChildren.Length; i++)
        //				{
        //					UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
        //				}
        //			}
        //			if (!this.m_bLastCap)
        //			{
        //				return;
        //			}
        //			this.m_bLastCap = false;
        //		}

        //		// Token: 0x06001305 RID: 4869 RVA: 0x000BBE64 File Offset: 0x000BA064
        //		public void AddPalSE(PalSE ps)
        //		{
        //			if (GameStateManager.CurGameState == GameState.Battle)
        //			{
        //				this.m_PalSEs.Add(ps);
        //			}
        //		}

        //		// Token: 0x06001306 RID: 4870 RVA: 0x000BBE80 File Offset: 0x000BA080
        //		public void RemovePalSE(PalSE ps)
        //		{
        //			if (GameStateManager.CurGameState == GameState.Battle)
        //			{
        //				this.m_PalSEs.Remove(ps);
        //			}
        //		}

        //		// Token: 0x06001307 RID: 4871 RVA: 0x000BBE9C File Offset: 0x000BA09C
        //		public void ClearPalSEs()
        //		{
        //			this.m_PalSEs.Clear();
        //		}

        //		// Token: 0x06001308 RID: 4872 RVA: 0x000BBEAC File Offset: 0x000BA0AC
        //		public void UpdatePalSE()
        //		{
        //			if (GameStateManager.CurGameState == GameState.Battle)
        //			{
        //				for (int i = this.m_PalSEs.Count - 1; i >= 0; i--)
        //				{
        //					if (this.m_PalSEs[i] == null)
        //					{
        //						this.m_PalSEs.RemoveAt(i);
        //					}
        //				}
        //				if (this.m_PalSEs.Count == 0 && !this.m_bLastFrameZero)
        //				{
        //					this.LoadCameraParam();
        //				}
        //				if (this.m_PalSEs.Count != 0)
        //				{
        //					this.m_bLastFrameZero = false;
        //				}
        //				else
        //				{
        //					this.m_bLastFrameZero = true;
        //				}
        //				if (this.m_PalSEs.Count == 0)
        //				{
        //					Time.timeScale = 1f;
        //				}
        //			}
        //		}

        //		// Token: 0x06001309 RID: 4873 RVA: 0x000BBF68 File Offset: 0x000BA168
        //		public void Restart()
        //		{
        //			this.mNewTPASystem.Restart();
        //			this.m_Achievement.Restart();
        //		}

        //		// Token: 0x0600130A RID: 4874 RVA: 0x000BBF80 File Offset: 0x000BA180
        //		public void AddToRebattleItemList(uint id)
        //		{
        //			this.m_RebattleItems.Add(id);
        //		}

        //		// Token: 0x0600130B RID: 4875 RVA: 0x000BBF90 File Offset: 0x000BA190
        //		public void AddRebattleItemToPack()
        //		{
        //			for (int i = 0; i < this.m_RebattleItems.Count; i++)
        //			{
        //				ItemPackage.GetOrCreatePackage(1u).AddNewItem_Limit(this.m_RebattleItems[i], 1);
        //			}
        //			this.m_RebattleItems.Clear();
        //		}

        //		// Token: 0x0600130C RID: 4876 RVA: 0x000BBFDC File Offset: 0x000BA1DC
        //		public void SwitchSkillGroup()
        //		{
        //			BattlePlayer currentControllCharater = PalBattleManager.Instance().GetCurrentControllCharater();
        //			if (currentControllCharater == null)
        //			{
        //				return;
        //			}
        //			BattleStateBase.INPUT_STATE_ENUM currentState = currentControllCharater.mUserInputStateManager.GetCurrentState();
        //			if (currentState != BattleStateBase.INPUT_STATE_ENUM.WAIT_FOR_MANUAL_SELECT_ATB_SKILL)
        //			{
        //				int mCurrentSkillGroup = currentControllCharater.mCurrentSkillGroup;
        //				if (mCurrentSkillGroup != 0)
        //				{
        //					if (mCurrentSkillGroup == 1)
        //					{
        //						currentControllCharater.SwitchSkillGroup(0, true);
        //					}
        //				}
        //				else
        //				{
        //					currentControllCharater.SwitchSkillGroup(1, true);
        //				}
        //			}
        //		}

        //		// Token: 0x0600130D RID: 4877 RVA: 0x000BC048 File Offset: 0x000BA248
        //		public void SwitchLeader()
        //		{
        //			BattlePlayer currentControllCharater = PalBattleManager.Instance().GetCurrentControllCharater();
        //			if (currentControllCharater == null)
        //			{
        //				return;
        //			}
        //			bool flag = true;
        //			if (currentControllCharater.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.DIE) || currentControllCharater.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.IDLE) || currentControllCharater.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.FREEZE))
        //			{
        //				flag = false;
        //			}
        //			if (flag)
        //			{
        //				return;
        //			}
        //			currentControllCharater.ClearSkillActionQueue();
        //			int currentFormation = PalBattleManager.Instance().m_BattleFormation.m_CurrentFormation;
        //			BattleFormationManager.BattleFormationData battleFormationData = PalBattleManager.Instance().m_BattleFormation.m_Formations[currentFormation];
        //			BattleFormationManager.InFormationCharaData inFormationCharaData = battleFormationData.m_InFormationCharaDatas[0];
        //			BattleFormationManager.InFormationCharaData inFormationCharaData2 = inFormationCharaData;
        //			int num = -1;
        //			for (int i = 1; i < battleFormationData.m_InFormationCharaDatas.Count; i++)
        //			{
        //				if (battleFormationData.m_InFormationCharaDatas[i] != null && battleFormationData.m_InFormationCharaDatas[i].m_CharacterID >= 0)
        //				{
        //					BattlePlayer battlePlayerByBattleID = this.GetBattlePlayerByBattleID(battleFormationData.m_InFormationCharaDatas[i].m_CharacterID);
        //					if (!(battlePlayerByBattleID == null))
        //					{
        //						if (!battlePlayerByBattleID.IsCurrentState(BattlePlayer.PLAYER_STATE_ENUM.DIE) && battlePlayerByBattleID.GetPalNPC().Data.HPMPDP.HP > 0)
        //						{
        //							inFormationCharaData2 = battleFormationData.m_InFormationCharaDatas[i];
        //							num = i;
        //						}
        //					}
        //				}
        //			}
        //			int num2 = battleFormationData.m_InFormationCharaDatas.Count - battleFormationData.m_Store;
        //			if (inFormationCharaData != inFormationCharaData2)
        //			{
        //				List<BattleFormationManager.InFormationCharaData> list = new List<BattleFormationManager.InFormationCharaData>();
        //				for (int j = 0; j < num2; j++)
        //				{
        //					list.Add(battleFormationData.m_InFormationCharaDatas[j]);
        //				}
        //				for (int k = 0; k < num2; k++)
        //				{
        //					int index = (k + num) % num2;
        //					battleFormationData.m_InFormationCharaDatas[k] = list[index];
        //				}
        //				PalBattleManager.Instance().m_BattleFormation.CurrentFormation = currentFormation;
        //				UIManager.Instance.Panel_Battle.CurMenuMain.PlayerID = inFormationCharaData2.m_CharacterID;
        //			}
        //		}

        //		// Token: 0x0600130E RID: 4878 RVA: 0x000BC24C File Offset: 0x000BA44C
        //		public void ToggleBattleUnitSE(bool bOn)
        //		{
        //			PalBattleManager.m_bOnBattleUnitSE = bOn;
        //		}

        public void OnSceneChangeClear()
        {
            //this.m_Rebattle_OtherNPC = null;
            //this.m_Rebattle_MeNPC = null;
            //if (this.m_Rebattle_players != null)
            //{
            //    this.m_Rebattle_players.Clear();
            //}
            //if (this.m_Rebattle_enemys != null)
            //{
            //    this.m_Rebattle_enemys.Clear();
            //}
            //this.mControlledPlayer = null;
            //this.m_players.Clear();
            //this.m_monsters.Clear();
            //this.m_LastAttackBp = null;
            //this.m_bLowestThreatenMan = null;
            //this.m_bMostHatredMan = null;
            //this.mBattlePlayers.Clear();
            //this.m_SelectedPlayers.Clear();
            //this.m_CamCtrl = null;
            //UIManager.Instance.Panel_Battle.clearPlayers();
            //if (UIManager.Instance.Panel_Battle.CurMenuSelectTarget != null)
            //{
            //    UIManager.Instance.Panel_Battle.CurMenuSelectTarget.clearTarget();
            //}
        }

        //		public bool IsLoadingFinished
        //		{
        //			get
        //			{
        //				return this.m_unfinishLoadingCount == 0;
        //			}
        //		}
    }
}
