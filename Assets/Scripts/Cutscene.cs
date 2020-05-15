using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SoftStar;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;


[ExecuteInEditMode]
public class Cutscene : MonoBehaviour
{
    public static Cutscene current;

    //	// Token: 0x0400040A RID: 1034
    //	public static int maskValue = -1;

    //	// Token: 0x0400040B RID: 1035
    //	[NonSerialized]
    //	public bool IsSaving;

    //	// Token: 0x0400040C RID: 1036
    //	public bool NeedChangeState = true;

    //	// Token: 0x0400040D RID: 1037
    //	public GameState lastGameState;

    //	// Token: 0x0400040E RID: 1038
    //	private GhostCamera m_ghostCamera;

    //	// Token: 0x0400040F RID: 1039
    //	[HideInInspector]
    //	public uScriptAct_Cutscene uScriptCutsc;

    //	// Token: 0x04000410 RID: 1040
    //	public string cutscenePath;

    //	// Token: 0x04000411 RID: 1041
    //	public string MergedClipsPath = "Assets/CutsceneEditor/CutScene/MergedClips/";

    //	// Token: 0x04000412 RID: 1042
    //	public string cutsceneName = "新过场";

    //	// Token: 0x04000413 RID: 1043
    //	[HideInInspector]
    //	public List<LockedGroup> lockedGroups = new List<LockedGroup>();

    //	// Token: 0x04000414 RID: 1044
    //	[NonSerialized]
    //	public List<CutsceneEvent> tempEvents;

    //	// Token: 0x04000415 RID: 1045
    //	public List<CutsceneEvent> events = new List<CutsceneEvent>();

    //	// Token: 0x04000416 RID: 1046
    //	public CutsceneRow eventRow = new CutsceneRow();

    //	// Token: 0x04000417 RID: 1047
    //	public int eventIndex;

    //	// Token: 0x04000418 RID: 1048
    //	public List<CutsceneRow> cutsceneRows = new List<CutsceneRow>();

    //	// Token: 0x04000419 RID: 1049
    //	public List<CutsceneClip> activeClips = new List<CutsceneClip>();

    //	// Token: 0x0400041A RID: 1050
    //	public float TotalTime = 30f;

    //	// Token: 0x0400041B RID: 1051
    //	public float currentTime;

    //	// Token: 0x0400041C RID: 1052
    //	private float curBackMusicRatio = 1f;

    //	// Token: 0x0400041D RID: 1053
    //	private bool isplaying;

    //	// Token: 0x0400041E RID: 1054
    //	[NonSerialized]
    //	public bool isPause;

    //	// Token: 0x0400041F RID: 1055
    //	public bool isSkip;

    //	// Token: 0x04000420 RID: 1056
    //	public List<CutParam_GameObject> cutsceneParams = new List<CutParam_GameObject>();

    //	// Token: 0x04000421 RID: 1057
    //	public bool CanESC = true;

    //	// Token: 0x04000422 RID: 1058
    //	public bool hideWeapon = true;

    //	// Token: 0x04000423 RID: 1059
    //	public bool restoreOrigin;

    //	// Token: 0x04000424 RID: 1060
    //	public Transform playerPoint;

    //	// Token: 0x04000425 RID: 1061
    //	public bool IsCGClip;

    //	// Token: 0x04000426 RID: 1062
    //	public float SmallfaceScale = 1f;

    //	// Token: 0x04000427 RID: 1063
    //	public float SmallFaceScaleTime = 1f;

    //	// Token: 0x04000428 RID: 1064
    //	public Action OnClickEvent;

    //	// Token: 0x04000429 RID: 1065
    //	public bool ContinueCutscene;

    //	// Token: 0x0400042A RID: 1066
    //	public bool BeginFromBlack = true;

    //	// Token: 0x0400042B RID: 1067
    //	private bool ReceiveShadows = true;

    //	// Token: 0x0400042C RID: 1068
    //	private Dictionary<GameObject, List<Cutscene.ProcessedData>> processedCpGO = new Dictionary<GameObject, List<Cutscene.ProcessedData>>();

    //	// Token: 0x0400042D RID: 1069
    //	[NonSerialized]
    //	public List<CutsceneClip> StringClips = new List<CutsceneClip>();

    //	// Token: 0x0400042E RID: 1070
    //	[NonSerialized]
    //	public List<DramaContent> dramas = new List<DramaContent>();

    //	// Token: 0x0400042F RID: 1071
    //	[NonSerialized]
    //	public List<CutsceneClip> SkipPoints = new List<CutsceneClip>();

    //	// Token: 0x04000430 RID: 1072
    //	private int SkipPointIndex;

    //	// Token: 0x04000431 RID: 1073
    //	private ParamObject[] m_paramObjects;

    //	// Token: 0x04000432 RID: 1074
    //	private string skipContent1;

    //	// Token: 0x04000433 RID: 1075
    //	private string skipContent2;

    //	// Token: 0x04000434 RID: 1076
    //	public static bool CanEscSkip = true;

    //	// Token: 0x04000435 RID: 1077
    //	private cutsceneData data;

    //	// Token: 0x04000436 RID: 1078
    //	public static bool ShowTransferFlash = true;

    //	// Token: 0x04000437 RID: 1079
    //	private float curBeginTime;

    //	// Token: 0x04000438 RID: 1080
    //	private bool NeedSkipToEnd;

    //	// Token: 0x04000439 RID: 1081
    //	private float SkipEndTime = 10f;

    //	// Token: 0x0400043A RID: 1082
    //	private bool CanSkipToEnd = true;

    //	// Token: 0x0400043B RID: 1083
    //	public static bool SkipOnBegin;

    //	// Token: 0x0400043C RID: 1084
    //	private float SkipOnBeginTime = 2f;

    //	// Token: 0x0400043D RID: 1085
    //	private bool is2D;

    //	// Token: 0x0400043E RID: 1086
    //	public static bool ShowSkipContent = true;

    //	// Token: 0x0400043F RID: 1087
    //	private bool HasOpenedText;

    //	// Token: 0x04000440 RID: 1088
    //	private string SkipContent = string.Empty;

    //	// Token: 0x04000441 RID: 1089
    //	private static GameObject _mainCamera;

    //	// Token: 0x04000442 RID: 1090
    //	private List<string> SpeechPaths = new List<string>();

    //	// Token: 0x04000443 RID: 1091
    //	private bool HasChangeMap;

    //	// Token: 0x04000444 RID: 1092
    //	private List<Cutscene.SkipClipData> ChangeMapClipList = new List<Cutscene.SkipClipData>();

    //	// Token: 0x04000445 RID: 1093
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> ActiveZhanDouDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x04000446 RID: 1094
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> PlayAnimDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x04000447 RID: 1095
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetPosDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x04000448 RID: 1096
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetVisDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x04000449 RID: 1097
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetActiveDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x0400044A RID: 1098
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetYanZhaoActiveDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x0400044B RID: 1099
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetClothDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x0400044C RID: 1100
    //	private Dictionary<CutsceneActor, Cutscene.SkipClipData> SetTurnBodyDic = new Dictionary<CutsceneActor, Cutscene.SkipClipData>();

    //	// Token: 0x0400044D RID: 1101
    //	private List<Cutscene.SkipClipData> AddNewStrangeNewList = new List<Cutscene.SkipClipData>();

    //	// Token: 0x0400044E RID: 1102
    //	private Cutscene.SkipClipData LastPlayAudio;

    //	// Token: 0x0400044F RID: 1103
    //	private Cutscene.SkipClipData LastWeather;

    //	// Token: 0x04000450 RID: 1104
    //	private Cutscene.SkipClipData LastWeatherTime;

    //	// Token: 0x04000451 RID: 1105
    //	private bool skipEnd;

    public event Cutscene.void_fun OnEnd;

    //	public static int MaskValue
    //	{
    //		get
    //		{
    //			if (Cutscene.maskValue < 0)
    //			{
    //				Cutscene.maskValue = 134611220;
    //				Cutscene.maskValue = ~Cutscene.maskValue;
    //			}
    //			return Cutscene.maskValue;
    //		}
    //	}

    //	// Token: 0x1700007B RID: 123
    //	// (get) Token: 0x06000426 RID: 1062 RVA: 0x00025578 File Offset: 0x00023778
    //	private GhostCamera ghostCamera
    //	{
    //		get
    //		{
    //			if (this.m_ghostCamera == null)
    //			{
    //				GameObject gameObject = Camera.main.gameObject;
    //				if (gameObject != null)
    //				{
    //					GhostCamera ghostCamera = gameObject.GetComponent<GhostCamera>();
    //					if (ghostCamera == null)
    //					{
    //						ghostCamera = gameObject.AddComponent<GhostCamera>();
    //						ghostCamera.enabled = false;
    //					}
    //					this.m_ghostCamera = ghostCamera;
    //				}
    //			}
    //			return this.m_ghostCamera;
    //		}
    //	}

    //	// Token: 0x1700007C RID: 124
    //	// (get) Token: 0x06000427 RID: 1063 RVA: 0x000255DC File Offset: 0x000237DC
    //	// (set) Token: 0x06000428 RID: 1064 RVA: 0x000255E4 File Offset: 0x000237E4
    //	public float CurBackMusicRatio
    //	{
    //		get
    //		{
    //			return this.curBackMusicRatio;
    //		}
    //		set
    //		{
    //			this.curBackMusicRatio = value;
    //		}
    //	}

    //	// Token: 0x06000429 RID: 1065 RVA: 0x000255F0 File Offset: 0x000237F0
    //	private void RestormBackMusic()
    //	{
    //		UtilFun.SetVolume(PalMain.backgroundAudio.BackMusicSource, OptionConfig.GetInstance().Music);
    //	}

    //	// Token: 0x0600042A RID: 1066 RVA: 0x0002560C File Offset: 0x0002380C
    //	private void OnDisable()
    //	{
    //		if (this.isPlaying && this.currentTime < 2f)
    //		{
    //			Debug.LogError("有问题disable: 考虑上一个场景中的 动态加载资源可能有重复，造成了重复读图的情况");
    //		}
    //	}

    //	// Token: 0x1700007D RID: 125
    //	// (get) Token: 0x0600042B RID: 1067 RVA: 0x00025634 File Offset: 0x00023834
    //	// (set) Token: 0x0600042C RID: 1068 RVA: 0x0002563C File Offset: 0x0002383C
    //	public bool isPlaying
    //	{
    //		get
    //		{
    //			return this.isplaying;
    //		}
    //		set
    //		{
    //			if (this.isplaying != value)
    //			{
    //				this.isplaying = value;
    //				this.SetActorsAnimAlways(this.isplaying);
    //				if (this.isPause && this.isplaying)
    //				{
    //					this.isPause = false;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600042D RID: 1069 RVA: 0x00025688 File Offset: 0x00023888
    //	private void PreProcessAssetBundle()
    //	{
    //		this.PreProcessAssetBundleCore(this.cutsceneRows);
    //	}

    //	// Token: 0x0600042E RID: 1070 RVA: 0x00025698 File Offset: 0x00023898
    //	private void PreProcessAssetBundleCore(List<CutsceneRow> rows)
    //	{
    //		if (rows == null || rows.Count < 1)
    //		{
    //			return;
    //		}
    //		foreach (CutsceneRow cutsceneRow in rows)
    //		{
    //			foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //			{
    //				if (cutsceneClip.ActionTypeName.Contains("CreateBundle"))
    //				{
    //					object customProperty = cutsceneClip.GetCustomProperty("bundlePath");
    //					string text = (customProperty != null) ? ((string)customProperty) : string.Empty;
    //					int startIndex = text.IndexOf("AssetBundles/");
    //					text = text.Substring(startIndex);
    //					text = Application.dataPath + "/../" + text;
    //					StreamAssetBundle.LoadBundle(text, false, false, this, null, false, AssetBundleType.Asset);
    //					this.PreProcessAssetBundleCore(cutsceneClip.subcutRows);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600042F RID: 1071 RVA: 0x000257D8 File Offset: 0x000239D8
    //	public void RefreshStringList()
    //	{
    //		this.StringClips.Clear();
    //		foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //		{
    //			foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //			{
    //				if (cutsceneClip.ActionType == typeof(CutAction_ShowStringOnGUI) || cutsceneClip.ActionType == typeof(CutAction_ShowStringOnGUIRole))
    //				{
    //					this.InsertClipToStringClips(cutsceneClip);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000430 RID: 1072 RVA: 0x000258C4 File Offset: 0x00023AC4
    //	public void InsertClipToStringClips(CutsceneClip newClip)
    //	{
    //		if (this.StringClips.Count < 1)
    //		{
    //			this.StringClips.Add(newClip);
    //			return;
    //		}
    //		for (int i = 0; i < this.StringClips.Count; i++)
    //		{
    //			CutsceneClip cutsceneClip = this.StringClips[i];
    //			if (cutsceneClip.startTime >= newClip.startTime)
    //			{
    //				this.StringClips.Insert(i, newClip);
    //				return;
    //			}
    //		}
    //		this.StringClips.Add(newClip);
    //	}

    //	// Token: 0x06000431 RID: 1073 RVA: 0x00025948 File Offset: 0x00023B48
    //	public void LoadDramaFromFile()
    //	{
    //		if (this.cutscenePath == null)
    //		{
    //			return;
    //		}
    //		int num = this.cutscenePath.IndexOf("Resources/");
    //		string text = this.cutscenePath.Substring(num);
    //		num = text.IndexOf('/') + 1;
    //		text = text.Substring(num);
    //		num = text.LastIndexOf('.');
    //		text = text.Substring(0, num);
    //		text += "_CHN";
    //		Debug.Log(text);
    //		TextAsset textAsset = Resources.Load(text) as TextAsset;
    //		if (textAsset == null)
    //		{
    //			return;
    //		}
    //		MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
    //		BinaryReader binaryReader = new BinaryReader(memoryStream);
    //		int num2 = binaryReader.ReadInt32();
    //		for (int i = 0; i < num2; i++)
    //		{
    //			DramaContent dramaContent = new DramaContent();
    //			dramaContent.ToMemory(binaryReader);
    //			this.dramas.Add(dramaContent);
    //		}
    //		binaryReader.Close();
    //		memoryStream.Close();
    //	}

    //	// Token: 0x06000432 RID: 1074 RVA: 0x00025A30 File Offset: 0x00023C30
    //	public void ReLoadSkipPoints()
    //	{
    //		this.SkipPoints.Clear();
    //		foreach (CutsceneClip cutsceneClip in this.eventRow.cutsceneClips)
    //		{
    //			if (cutsceneClip.ActionType != null && cutsceneClip.ActionType == typeof(CutEvent_SkipPoint))
    //			{
    //				this.SkipPoints.Add(cutsceneClip);
    //			}
    //		}
    //		this.ReCalcuSkipIndex();
    //	}

    //	// Token: 0x06000433 RID: 1075 RVA: 0x00025AD4 File Offset: 0x00023CD4
    //	public void DestroyActors()
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in this.cutsceneParams)
    //		{
    //			if (cutParam_GameObject != null || !(cutParam_GameObject.paramValue == null))
    //			{
    //				CutsceneActor cutsceneActor = (!(cutParam_GameObject.paramValue == null)) ? cutParam_GameObject.paramValue.GetComponent<CutsceneActor>() : null;
    //				if (!(cutsceneActor == null))
    //				{
    //					if (cutsceneActor.NeedDestroyOnEnd)
    //					{
    //						cutsceneActor.DestroyActor();
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000434 RID: 1076 RVA: 0x00025B94 File Offset: 0x00023D94
    //	public void ResetActorPos()
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in this.cutsceneParams)
    //		{
    //			if (cutParam_GameObject != null || !(cutParam_GameObject.paramValue == null))
    //			{
    //				CutsceneActor cutsceneActor = (!(cutParam_GameObject.paramValue == null)) ? cutParam_GameObject.paramValue.GetComponent<CutsceneActor>() : null;
    //				if (!(cutsceneActor == null))
    //				{
    //					cutsceneActor.ActorBegin();
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000435 RID: 1077 RVA: 0x00025C4C File Offset: 0x00023E4C
    //	private static void ClearParticle(Cutscene cutscene)
    //	{
    //		ProcessParticleOnEnd[] componentsInChildren = cutscene.gameObject.GetComponentsInChildren<ProcessParticleOnEnd>(true);
    //		foreach (ProcessParticleOnEnd processParticleOnEnd in componentsInChildren)
    //		{
    //			UnityEngine.Object.Destroy(processParticleOnEnd.gameObject);
    //		}
    //	}

    //	// Token: 0x06000436 RID: 1078 RVA: 0x00025C8C File Offset: 0x00023E8C
    //	private static void RestoreCutsceneParams(Cutscene cutscene)
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in cutscene.cutsceneParams)
    //		{
    //			GameObject paramValue = cutParam_GameObject.paramValue;
    //			if (!(paramValue == null))
    //			{
    //				paramValue.transform.parent = cutscene.transform;
    //				CutsceneActor component = paramValue.GetComponent<CutsceneActor>();
    //				if (component != null && component.curActor != null)
    //				{
    //					PalGameObjectBase component2 = component.curActor.GetComponent<PalGameObjectBase>();
    //					if (component2 != null && component2.model != null)
    //					{
    //						component2.model.transform.parent = component2.transform;
    //					}
    //				}
    //				CurvySpline component3 = paramValue.GetComponent<CurvySpline>();
    //				if (component3 != null)
    //				{
    //					UtilFun.SetActive(paramValue, false);
    //				}
    //				CutAction_PlayAudio component4 = paramValue.GetComponent<CutAction_PlayAudio>();
    //				if (component4 != null)
    //				{
    //					UtilFun.SetActive(paramValue, false);
    //				}
    //			}
    //		}
    //		ParticleSystem[] componentsInChildren = cutscene.GetComponentsInChildren<ParticleSystem>(true);
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
    //		}
    //		XffectComponent[] componentsInChildren2 = cutscene.GetComponentsInChildren<XffectComponent>(true);
    //		for (int j = 0; j < componentsInChildren2.Length; j++)
    //		{
    //			UnityEngine.Object.Destroy(componentsInChildren2[j].gameObject);
    //		}
    //		foreach (Camera camera in cutscene.GetComponentsInChildren<Camera>(true))
    //		{
    //			camera.transform.parent = null;
    //		}
    //	}

    //	// Token: 0x06000437 RID: 1079 RVA: 0x00025E4C File Offset: 0x0002404C
    //	public void ActiveAllCurvySpline(bool bActive)
    //	{
    //		CurvySpline[] componentsInChildren = base.GetComponentsInChildren<CurvySpline>(true);
    //		foreach (CurvySpline curvySpline in componentsInChildren)
    //		{
    //			UtilFun.SetActive(curvySpline.gameObject, bActive);
    //		}
    //	}

    //	// Token: 0x1700007E RID: 126
    //	// (get) Token: 0x06000438 RID: 1080 RVA: 0x00025E88 File Offset: 0x00024088
    //	public ParamObject[] paramObjects
    //	{
    //		get
    //		{
    //			if (this.m_paramObjects == null)
    //			{
    //				this.m_paramObjects = base.GetComponentsInChildren<ParamObject>(true);
    //			}
    //			return this.m_paramObjects;
    //		}
    //	}

    //	// Token: 0x06000439 RID: 1081 RVA: 0x00025EA8 File Offset: 0x000240A8
    //	public void SetActive(bool bAct)
    //	{
    //		ScreenAttachColor component = Camera.main.GetComponent<ScreenAttachColor>();
    //		if (component != null)
    //		{
    //			if (Application.isPlaying)
    //			{
    //				UnityEngine.Object.Destroy(component);
    //			}
    //			else
    //			{
    //				UnityEngine.Object.DestroyImmediate(component);
    //			}
    //		}
    //		UITalkManager.Instance.Hide();
    //		ParamObject[] componentsInChildren = base.GetComponentsInChildren<ParamObject>(true);
    //		foreach (ParamObject paramObject in componentsInChildren)
    //		{
    //			if (!bAct)
    //			{
    //				UtilFun.SetActive(paramObject.gameObject, false);
    //				CutsceneActor component2 = paramObject.gameObject.GetComponent<CutsceneActor>();
    //				if (component2 != null && component2.curActor)
    //				{
    //					UtilFun.SetAllComponentActive(component2.curActor, false, new Type[0]);
    //				}
    //			}
    //			else
    //			{
    //				CurvySpline component3 = paramObject.gameObject.GetComponent<CurvySpline>();
    //				if (component3 != null)
    //				{
    //					UtilFun.SetActive(paramObject.gameObject, true);
    //				}
    //				CutsceneActor component4 = paramObject.gameObject.GetComponent<CutsceneActor>();
    //				if (component4 != null && component4.curActor != null)
    //				{
    //					UtilFun.SetAllComponentActive(component4.curActor, true, new Type[]
    //					{
    //						typeof(TurnHead),
    //						typeof(MegaModifyObject)
    //					});
    //					GameObject modelObj = component4.curActor.GetModelObj(true);
    //					AnimCtrlScript componentInChildren = modelObj.GetComponentInChildren<AnimCtrlScript>();
    //					if (componentInChildren != null)
    //					{
    //						componentInChildren.ActiveAnim("ZhanLi", false, false, false);
    //						componentInChildren.ActiveZhanDou(false, 1, true, true, true);
    //					}
    //					Animator component5 = modelObj.GetComponent<Animator>();
    //					if (component5 != null)
    //					{
    //						component5.CrossFade("New State", 0.01f);
    //					}
    //				}
    //			}
    //		}
    //	}

    public void Init()
    {
        //uint curLangue = Langue.CurLangue;
        //this.skipContent1 = ((curLangue != 0u) ? "秒內按~跳過" : "秒内按~跳过");
        //this.skipContent2 = ((curLangue != 0u) ? "即將跳過" : "即将跳过");
        //this.is2D = base.name.Contains("csmh");
        //Cutscene.current = this;
        //this.ReLoadSkipPoints();
        //this.ResetActorPos();
    }

    private void Awake()
    {
        this.Init();
    }

    private void Start()
    {
        Debug.LogWarning("Start");
        //this.PreProcessAssetBundle();
    }

    //	// Token: 0x0600043D RID: 1085 RVA: 0x000260E4 File Offset: 0x000242E4
    //	private void ProcessActors(bool bActive)
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in this.cutsceneParams)
    //		{
    //			if (cutParam_GameObject != null || !(cutParam_GameObject.paramValue == null))
    //			{
    //				CutsceneActor cutsceneActor = (!(cutParam_GameObject.paramValue == null)) ? cutParam_GameObject.paramValue.GetComponent<CutsceneActor>() : null;
    //				if (!(cutsceneActor == null))
    //				{
    //					if (cutsceneActor.NeedDestroyOnEnd && bActive)
    //					{
    //						cutsceneActor.DestroyActor();
    //					}
    //					GameObject curActor = cutsceneActor.curActor;
    //					if (curActor == null)
    //					{
    //						Debug.LogError(cutsceneActor.name + " curActor 为空");
    //					}
    //					else
    //					{
    //						GameObject modelObj = curActor.GetModelObj(false);
    //						if (!bActive)
    //						{
    //							this.ProcessModelAnim(modelObj, bActive);
    //							if (modelObj != null)
    //							{
    //								modelObj.SetVisible(true);
    //								cutsceneActor.SynActorCloth();
    //							}
    //							else
    //							{
    //								string path = GameObjectPath.GetPath(curActor.transform);
    //								UtilFun.LogError("Error : " + path + ".model==null");
    //							}
    //						}
    //						else
    //						{
    //							modelObj.SetVisible(cutsceneActor.NeedVisibleOnEnd);
    //							CharacterController component = modelObj.GetComponent<CharacterController>();
    //							if (component != null)
    //							{
    //								component.detectCollisions = true;
    //							}
    //							TurnHead[] components = modelObj.GetComponents<TurnHead>();
    //							foreach (TurnHead turnHead in components)
    //							{
    //								if (turnHead != null)
    //								{
    //									turnHead.Reset();
    //									turnHead.enabled = false;
    //								}
    //							}
    //						}
    //						PalNPC component2 = curActor.GetComponent<PalNPC>();
    //						if (PlayersManager.AllPlayers.Contains(curActor))
    //						{
    //							if (this.hideWeapon)
    //							{
    //								this.ProcessModelWeapon(component2, bActive);
    //							}
    //							TurnBodyOld component3 = curActor.GetComponent<TurnBodyOld>();
    //							if (component3 != null)
    //							{
    //								component3.Reset();
    //								UnityEngine.Object.Destroy(component3);
    //							}
    //							if (bActive && PlayersManager.ActivePlayers.Contains(curActor))
    //							{
    //								Animator animator = component2.animator;
    //								if (animator)
    //								{
    //									animator.SetBool("Move", false);
    //									animator.Play("ZhanLi");
    //									animator.Play("New State", 2);
    //									animator.SetFloat("Speed", 0f);
    //									animator.speed = 1f;
    //								}
    //							}
    //						}
    //						else if (this.restoreOrigin && bActive && cutsceneActor.NeedOriPosOnEnd)
    //						{
    //							this.ProcessModelOriPos(curActor);
    //						}
    //						if (!(component2 == null))
    //						{
    //							this.ProcessModelFace(modelObj, component2.Data.CharacterID, bActive);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600043E RID: 1086 RVA: 0x000263B8 File Offset: 0x000245B8
    //	private void ProcessModelAnim(GameObject model, bool bActive)
    //	{
    //		if (model == null)
    //		{
    //			return;
    //		}
    //		Animator component = model.GetComponent<Animator>();
    //		if (component != null)
    //		{
    //			component.SetBool("Move", false);
    //			component.Play("ZhanLi");
    //			component.Play("New State", 2);
    //			component.SetFloat("Speed", 0f);
    //			component.speed = 1f;
    //		}
    //		TurnHead[] components = model.GetComponents<TurnHead>();
    //		foreach (TurnHead turnHead in components)
    //		{
    //			if (turnHead != null)
    //			{
    //				turnHead.Reset();
    //				turnHead.enabled = false;
    //			}
    //		}
    //	}

    //	// Token: 0x0600043F RID: 1087 RVA: 0x00026464 File Offset: 0x00024664
    //	private void ProcessModelWeapon(PalNPC npc, bool bActive)
    //	{
    //		if (!bActive)
    //		{
    //			npc.SetActiveWeaponInCutscene(true);
    //		}
    //		else
    //		{
    //			npc.SetActiveWeaponInNormal(true);
    //		}
    //	}

    //	// Token: 0x06000440 RID: 1088 RVA: 0x00026480 File Offset: 0x00024680
    //	private void ProcessModelOriPos(GameObject actor)
    //	{
    //		GameObject modelObj = actor.GetModelObj(false);
    //		if (modelObj != actor)
    //		{
    //			Transform transform = modelObj.transform;
    //			transform.parent = actor.transform;
    //			transform.localPosition = Vector3.zero;
    //		}
    //	}

    //	// Token: 0x06000441 RID: 1089 RVA: 0x000264C0 File Offset: 0x000246C0
    //	private void ProcessModelFace(GameObject model, int ID, bool bActive)
    //	{
    //		if (model == null)
    //		{
    //			UtilFun.LogError("Error : model==null");
    //			return;
    //		}
    //		if (this.ReceiveShadows)
    //		{
    //			bActive = true;
    //		}
    //		foreach (object obj in model.transform)
    //		{
    //			Transform transform = (Transform)obj;
    //			if (transform.name.ToLower().Contains("_face"))
    //			{
    //				transform.renderer.receiveShadows = bActive;
    //				SkinnedMeshRenderer component = transform.GetComponent<SkinnedMeshRenderer>();
    //				if (component != null)
    //				{
    //					for (int i = 0; i < CutAction_MegaMorph.expressionLength(ID); i++)
    //					{
    //						component.SetBlendShapeWeight(i, 0f);
    //					}
    //				}
    //				break;
    //			}
    //		}
    //	}

    //	// Token: 0x06000442 RID: 1090 RVA: 0x000265B4 File Offset: 0x000247B4
    //	public void ProcessHideWeapon(bool bActive)
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in this.cutsceneParams)
    //		{
    //			if (cutParam_GameObject != null || !(cutParam_GameObject.paramValue == null))
    //			{
    //				CutsceneActor cutsceneActor = (!(cutParam_GameObject.paramValue == null)) ? cutParam_GameObject.paramValue.GetComponent<CutsceneActor>() : null;
    //				if (!(cutsceneActor == null))
    //				{
    //					GameObject curActor = cutsceneActor.curActor;
    //					if (curActor == null)
    //					{
    //						Debug.LogError(cutsceneActor.name + " curActor 为空");
    //					}
    //					else
    //					{
    //						PalNPC component = curActor.GetComponent<PalNPC>();
    //						if (!(component == null))
    //						{
    //							if (PlayersManager.AllPlayers.Contains(curActor) || component.Data.CharacterID == 7)
    //							{
    //								if (bActive)
    //								{
    //									component.SetActiveWeaponInCutscene(true);
    //								}
    //								else
    //								{
    //									component.SetActiveWeaponInNormal(true);
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000443 RID: 1091 RVA: 0x000266E8 File Offset: 0x000248E8
    //	public void ProcessFace()
    //	{
    //		foreach (CutParam_GameObject cutParam_GameObject in this.cutsceneParams)
    //		{
    //			if (cutParam_GameObject != null || !(cutParam_GameObject.paramValue == null))
    //			{
    //				CutsceneActor cutsceneActor = (!(cutParam_GameObject.paramValue == null)) ? cutParam_GameObject.paramValue.GetComponent<CutsceneActor>() : null;
    //				if (!(cutsceneActor == null))
    //				{
    //					if (cutsceneActor.curActor == null)
    //					{
    //						Debug.LogError(cutsceneActor.name + " curActor 为空");
    //					}
    //					else
    //					{
    //						PalNPC component = cutsceneActor.curActor.GetComponent<PalNPC>();
    //						if (!(component == null))
    //						{
    //							GameObject modelObj = cutsceneActor.curActor.GetModelObj(false);
    //							foreach (object obj in modelObj.transform)
    //							{
    //								Transform transform = (Transform)obj;
    //								if (transform.name.ToLower().Contains("_face"))
    //								{
    //									SkinnedMeshRenderer component2 = transform.GetComponent<SkinnedMeshRenderer>();
    //									if (component2 != null)
    //									{
    //										for (int i = 0; i < CutAction_MegaMorph.expressionLength(component.Data.CharacterID); i++)
    //										{
    //											component2.SetBlendShapeWeight(i, 0f);
    //										}
    //									}
    //									break;
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000444 RID: 1092 RVA: 0x000268B8 File Offset: 0x00024AB8
    //	public void Begin(float curTime = -0.0001f)
    //	{
    //		this.skipEnd = false;
    //		if (!base.name.Contains("csmh"))
    //		{
    //			this.PreProcessForCutscene();
    //		}
    //		LateSetActive.Clear();
    //		Debug.Log(base.gameObject.name + " 播放");
    //		this.currentTime = curTime;
    //		this.curBeginTime = curTime;
    //		if (PlayerCtrlManager.agentObj != null)
    //		{
    //			PlayerCtrlManager.agentObj.ClearAnimMoveClient();
    //		}
    //		this.curBackMusicRatio = 1f;
    //		this.lastGameState = GameStateManager.CurGameState;
    //		if (this.lastGameState == GameState.Cutscene)
    //		{
    //			this.lastGameState = GameState.Normal;
    //		}
    //		GameStateManager.CurGameState = GameState.Cutscene;
    //		bool flag = false;
    //		UniStormWeatherSystem instance = UniStormWeatherSystem.instance;
    //		if (instance != null)
    //		{
    //			TimeManager.Initialize().Stop();
    //			int num = base.name.IndexOf("_");
    //			string text = base.name.Substring(num + 1);
    //			text = text.Replace("(Clone)", string.Empty);
    //			text = text.Replace("(clone)", string.Empty);
    //			int id = 0;
    //			if (int.TryParse(text, out id))
    //			{
    //				this.data = cutsceneData.GetData(id);
    //				if (this.data != null && (instance.startTime * 24f < this.data.TimeCell || instance.startTime * 24f > this.data.TimeFloor))
    //				{
    //					string content = (Langue.CurLangue != 0u) ? "時光流轉" : "时光流转";
    //					CutsceneFlash.Active(content, 3f, new Action(this.FlashEvent));
    //					flag = true;
    //				}
    //			}
    //		}
    //		Cutscene.current = this;
    //		if (!flag)
    //		{
    //			this.isPlaying = true;
    //			this.isPause = false;
    //		}
    //		CameraViewport.Initialise(Camera.main, 16, 9);
    //		PlayerCtrlManager.bAutoWalk = false;
    //		this.ProcessActors(false);
    //		if (curTime < 0.01f)
    //		{
    //			Color color = (!this.BeginFromBlack) ? Color.white : Color.black;
    //			CutAction_CameraFade.InitScreenColor(color, 1f);
    //		}
    //		this.SetActiveDisturb(false);
    //	}

    //	// Token: 0x06000445 RID: 1093 RVA: 0x00026AC8 File Offset: 0x00024CC8
    //	private void SetActiveDisturb(bool bActive)
    //	{
    //		if (Camera.main != null && UtilFun.GetPalMapLevel(Application.loadedLevel) == 9)
    //		{
    //			Camera main = Camera.main;
    //			Disturb component = main.GetComponent<Disturb>();
    //			if (component != null)
    //			{
    //				component.enabled = bActive;
    //			}
    //		}
    //	}

    //	// Token: 0x06000446 RID: 1094 RVA: 0x00026B18 File Offset: 0x00024D18
    //	public void FlashEvent()
    //	{
    //		this.isPlaying = true;
    //		this.isPause = false;
    //		WeatherManage.Instance.SetTimeOfDay(this.data.TimeCell, true);
    //	}

    //	// Token: 0x06000447 RID: 1095 RVA: 0x00026B4C File Offset: 0x00024D4C
    //	public void SetActorsAnimAlways(bool bValue)
    //	{
    //		CutsceneActor[] componentsInChildren = base.GetComponentsInChildren<CutsceneActor>(true);
    //		foreach (CutsceneActor cutsceneActor in componentsInChildren)
    //		{
    //			if (!(cutsceneActor == null) && !(cutsceneActor.curActor == null))
    //			{
    //				PalNPC component = cutsceneActor.curActor.GetComponent<PalNPC>();
    //				if (component != null)
    //				{
    //					if (component.animator != null)
    //					{
    //						component.animator.cullingMode = ((!bValue) ? AnimatorCullingMode.BasedOnRenderers : AnimatorCullingMode.AlwaysAnimate);
    //						if (component.model != null)
    //						{
    //							if (bValue)
    //							{
    //								CharacterController component2 = component.model.GetComponent<CharacterController>();
    //								if (component2 != null)
    //								{
    //									component2.enabled = false;
    //								}
    //								if (component.animator != null)
    //								{
    //									component.animator.SetApplyRootMotion(false);
    //								}
    //							}
    //							else if (this.currentTime >= this.TotalTime)
    //							{
    //								CharacterController[] componentsInChildren2 = component.model.GetComponentsInChildren<CharacterController>(true);
    //								CharacterController characterController = null;
    //								foreach (CharacterController characterController2 in componentsInChildren2)
    //								{
    //									if (!(characterController2 == null))
    //									{
    //										characterController = characterController2;
    //										break;
    //									}
    //								}
    //								if (characterController != null)
    //								{
    //									characterController.detectCollisions = true;
    //									characterController.enabled = true;
    //								}
    //								TurnHead component3 = component.model.GetComponent<TurnHead>();
    //								if (component3 != null)
    //								{
    //									UnityEngine.Object.Destroy(component3);
    //								}
    //								AnimCtrlScript component4 = component.model.GetComponent<AnimCtrlScript>();
    //								if (component4 != null)
    //								{
    //									component4.ActiveZhanDou(false, 1, true, true, false);
    //								}
    //								component.model.SetVisible(cutsceneActor.NeedVisibleOnEnd);
    //							}
    //						}
    //					}
    //					else
    //					{
    //						Debug.LogError(component.name + "没有animator");
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000448 RID: 1096 RVA: 0x00026D3C File Offset: 0x00024F3C
    //	public void Pause()
    //	{
    //		this.isPlaying = false;
    //		this.isPause = true;
    //	}

    //	// Token: 0x06000449 RID: 1097 RVA: 0x00026D4C File Offset: 0x00024F4C
    //	public void Play()
    //	{
    //		if (!base.gameObject.activeSelf)
    //		{
    //			UtilFun.SetActive(base.gameObject, true);
    //		}
    //		this.isPlaying = true;
    //		this.isPause = false;
    //	}

    //	// Token: 0x0600044A RID: 1098 RVA: 0x00026D84 File Offset: 0x00024F84
    //	public void End(bool HideBlack = true)
    //	{
    //		UIManager.CloseText();
    //		this.currentTime = this.TotalTime;
    //		this.isPlaying = false;
    //		this.isPause = false;
    //		this.ClearSpeech();
    //		this.SetActiveDisturb(true);
    //		PlayLip.Instance.Stop();
    //		Camera camera = Camera.main;
    //		if (camera == null)
    //		{
    //			GameObject mainCamera = PalMain.MainCamera;
    //			if (mainCamera != null)
    //			{
    //				camera = mainCamera.GetComponent<Camera>();
    //			}
    //		}
    //		if (camera != null)
    //		{
    //			if (camera.rect.y != 0f || camera.rect.height != 1f)
    //			{
    //				camera.rect = new Rect(0f, 0f, 1f, 1f);
    //			}
    //			UtilFun.SetActive(camera.gameObject, true);
    //			camera.enabled = true;
    //			camera.transform.parent = null;
    //		}
    //		foreach (GameObject gameObject in PlayersManager.ActivePlayers)
    //		{
    //			if (!(gameObject == null))
    //			{
    //				if (gameObject != PlayersManager.Player)
    //				{
    //					LateSetActive.Init(gameObject.GetModelObj(false), false, 0.01f);
    //				}
    //			}
    //		}
    //		UniStormWeatherSystem instance = UniStormWeatherSystem.instance;
    //		if (instance != null && (this.data == null || !this.data.TurnoffWeahterTime))
    //		{
    //			TimeManager.Initialize().Play();
    //		}
    //		if (base.name.Contains("csmh_"))
    //		{
    //			GameStateManager.CurGameState = this.lastGameState;
    //		}
    //		else
    //		{
    //			UIManager.Instance.DoNotOpenMainMenu = false;
    //			GameStateManager.CurGameState = GameState.Normal;
    //		}
    //		UITalkManager instance2 = UITalkManager.Instance;
    //		if (instance2 != null)
    //		{
    //			instance2.Hide();
    //		}
    //		GameObject gameObject2 = base.gameObject;
    //		if (gameObject2 != null)
    //		{
    //			UtilFun.SetActive(gameObject2, false);
    //		}
    //		if (!gameObject2.name.Contains("csmh_"))
    //		{
    //			PlayersManager.RestoreLayer(false);
    //		}
    //		this.ProcessActors(true);
    //		if (this.playerPoint != null && PlayersManager.Player != null)
    //		{
    //			GameObject modelObj = PlayersManager.Player.GetModelObj(true);
    //			UtilFun.SetPosition(modelObj.transform, this.playerPoint.position);
    //			modelObj.transform.rotation = this.playerPoint.rotation;
    //			AssertWarrning.GetAssert().Assert("提示： 进行了主控角色位置的设置 playerPoint " + this.playerPoint.position);
    //		}
    //		for (int i = 0; i < CutsceneAction.referenceObjs.Count; i++)
    //		{
    //			if (CutsceneAction.referenceObjs[i] == null)
    //			{
    //				CutsceneAction.referenceObjs.RemoveAt(i);
    //				i--;
    //			}
    //			else if (CutsceneAction.referenceObjs[i].transform.childCount == 0)
    //			{
    //				UnityEngine.Object.Destroy(CutsceneAction.referenceObjs[i]);
    //				CutsceneAction.referenceObjs.RemoveAt(i);
    //				i--;
    //			}
    //		}
    //		if (!this.ContinueCutscene)
    //		{
    //			Agent agentObj = PlayerCtrlManager.agentObj;
    //			if (agentObj != null)
    //			{
    //				GameObject gameObject3 = agentObj.gameObject;
    //				agentObj.animator.SetApplyRootMotion(true);
    //				SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
    //				if (component != null)
    //				{
    //					component.Init(gameObject3);
    //					component.InitAngle();
    //				}
    //			}
    //			this.RestormBackMusic();
    //			if (HideBlack)
    //			{
    //				CutAction_CameraFade.DestroyScreenColor();
    //			}
    //		}
    //		if (this.OnEnd != null)
    //		{
    //			this.OnEnd();
    //		}
    //		if (this.uScriptCutsc != null)
    //		{
    //			this.uScriptCutsc.Stop = true;
    //		}
    //	}

    //	// Token: 0x0600044B RID: 1099 RVA: 0x00027160 File Offset: 0x00025360
    //	public void ReCalcuSkipIndex()
    //	{
    //		for (int i = 0; i < this.SkipPoints.Count; i++)
    //		{
    //			CutsceneClip cutsceneClip = this.SkipPoints[i];
    //			if (cutsceneClip.startTime > this.currentTime)
    //			{
    //				this.SkipPointIndex = i;
    //				break;
    //			}
    //		}
    //	}

    //	// Token: 0x0600044C RID: 1100 RVA: 0x000271B8 File Offset: 0x000253B8
    //	[CutsceneEventExclude]
    //	private void FixedUpdate()
    //	{
    //		if (Time.timeScale > 0f)
    //		{
    //			float num = this.currentTime - this.curBeginTime;
    //			if (Input.anyKeyDown)
    //			{
    //				if (this.CanSkipToEnd && this.CanESC && InputManager.GetKeyDown(KEY_ACTION.OTHER) && num <= this.SkipEndTime && !this.is2D)
    //				{
    //					this.NeedSkipToEnd = true;
    //				}
    //				if (InputManager.GetKeyDown(KEY_ACTION.MOUSE_LEFT) && this.isPause && !this.IsCGClip)
    //				{
    //					this.Play();
    //					UITalkManager.Instance.Hide();
    //					if (this.OnClickEvent != null)
    //					{
    //						this.OnClickEvent();
    //					}
    //				}
    //			}
    //			if (this.CanSkipToEnd)
    //			{
    //				if (Cutscene.SkipOnBegin && !this.is2D && num > this.SkipOnBeginTime)
    //				{
    //					if (!this.ProcessSkipEnd())
    //					{
    //						this.End(true);
    //					}
    //					return;
    //				}
    //				if (!this.is2D && Cutscene.ShowSkipContent && this.SkipEndTime < this.TotalTime)
    //				{
    //					if (num <= this.SkipEndTime)
    //					{
    //						if (!this.HasOpenedText)
    //						{
    //							this.HasOpenedText = true;
    //							UIManager.OpenText();
    //						}
    //						int num2 = (int)(this.SkipEndTime - num);
    //						if (!this.NeedSkipToEnd)
    //						{
    //							this.SkipContent = this.skipContent1;
    //							if (this.SkipEndTime < 30f)
    //							{
    //								this.SkipContent = "10" + this.SkipContent;
    //							}
    //							else
    //							{
    //								this.SkipContent = "30" + this.SkipContent;
    //							}
    //						}
    //						else
    //						{
    //							this.SkipContent = this.skipContent2;
    //						}
    //						this.SkipContent = "<font size='17'>" + this.SkipContent + num2.ToString() + "</font>";
    //						UIManager.SetText(this.SkipContent, CameraViewport.TopRightPos, UIWidget.Pivot.TopRight);
    //					}
    //					else if (this.HasOpenedText)
    //					{
    //						this.HasOpenedText = false;
    //						UIManager.CloseText();
    //					}
    //				}
    //				if (this.NeedSkipToEnd && num > this.SkipEndTime)
    //				{
    //					if (!this.ProcessSkipEnd())
    //					{
    //						this.End(true);
    //					}
    //					return;
    //				}
    //			}
    //			if (!this.isPlaying)
    //			{
    //				return;
    //			}
    //			this.ReCalcuSkipIndex();
    //			this.currentTime += Time.fixedDeltaTime;
    //			this.UpdateCutscene(this.currentTime, true);
    //			if (this.isSkip)
    //			{
    //				this.isSkip = false;
    //			}
    //			if (this.currentTime >= this.TotalTime)
    //			{
    //				this.End(true);
    //				return;
    //			}
    //		}
    //	}

    //	// Token: 0x0600044D RID: 1101 RVA: 0x00027444 File Offset: 0x00025644
    //	public void Skip()
    //	{
    //		if (this.SkipPointIndex > this.SkipPoints.Count - 1)
    //		{
    //			return;
    //		}
    //		CutEvent_SkipPoint.Skip(this, this.SkipPoints[this.SkipPointIndex]);
    //		this.SkipPointIndex++;
    //		this.eventIndex++;
    //	}

    //	// Token: 0x0600044E RID: 1102 RVA: 0x000274A0 File Offset: 0x000256A0
    //	public void UpdateCutscene(float time, bool triggerEvents = true)
    //	{
    //		if (!triggerEvents)
    //		{
    //			for (int i = 0; i < this.eventRow.cutsceneClips.Count; i++)
    //			{
    //				CutsceneClip cutsceneClip = this.eventRow.cutsceneClips[i];
    //				if (cutsceneClip.startTime > this.currentTime)
    //				{
    //					this.eventIndex = i;
    //					break;
    //				}
    //			}
    //		}
    //		if (triggerEvents)
    //		{
    //			for (int j = this.eventIndex; j < this.eventRow.cutsceneClips.Count; j++)
    //			{
    //				CutsceneClip cutsceneClip2 = this.eventRow.cutsceneClips[j];
    //				if (this.currentTime < cutsceneClip2.startTime)
    //				{
    //					break;
    //				}
    //				if (cutsceneClip2.ActionType != null)
    //				{
    //					object[] args = new object[]
    //					{
    //						this,
    //						cutsceneClip2
    //					};
    //					cutsceneClip2.ActionType.InvokeMember("EventFun", BindingFlags.Static | BindingFlags.InvokeMethod, null, null, args);
    //				}
    //				this.eventIndex++;
    //			}
    //		}
    //		this.ProcessRows(this.cutsceneRows, time, null);
    //	}

    //	// Token: 0x0600044F RID: 1103 RVA: 0x000275B4 File Offset: 0x000257B4
    //	public void ProcessRows(List<CutsceneRow> cutsceneRows, float time, CutsceneClip paClip = null)
    //	{
    //		if (!this.isPlaying || this.isSkip)
    //		{
    //			Dictionary<CutsceneRow, int> dictionary = new Dictionary<CutsceneRow, int>();
    //			for (int i = 0; i < cutsceneRows.Count; i++)
    //			{
    //				CutsceneRow cutsceneRow = cutsceneRows[i];
    //				if (cutsceneRow.bEnable)
    //				{
    //					if (cutsceneRow.cutsceneClips.Count >= 1)
    //					{
    //						if (cutsceneRow.cutsceneClips.Count <= 0 || time >= cutsceneRow.cutsceneClips[0].startTime)
    //						{
    //							CutsceneClip cutsceneClip = cutsceneRow.cutsceneClips[cutsceneRow.cutsceneClips.Count - 1];
    //							if (time > cutsceneClip.startTime + cutsceneClip.length)
    //							{
    //								dictionary.Add(cutsceneRow, cutsceneRow.cutsceneClips.Count);
    //							}
    //							else
    //							{
    //								int num = -1;
    //								for (int j = 0; j < cutsceneRow.cutsceneClips.Count; j++)
    //								{
    //									CutsceneClip cutsceneClip2 = cutsceneRow.cutsceneClips[j];
    //									num++;
    //									if (cutsceneClip2 != null)
    //									{
    //										float num2 = cutsceneClip2.startTime + cutsceneClip2.length;
    //										if (num2 < time)
    //										{
    //											if ((!this.isPlaying || this.isSkip) && this.NeedProcessOnJump(cutsceneClip2) && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip2, false) && cutsceneClip2.ActionType == typeof(CutAction_TakeItem) && cutsceneClip2.bEnable)
    //											{
    //												if (paClip != null)
    //												{
    //													cutsceneClip2.PaCutclip = paClip;
    //												}
    //												cutsceneClip2.SetActive(true, this, true);
    //											}
    //										}
    //										else
    //										{
    //											if (time < cutsceneClip2.startTime)
    //											{
    //												break;
    //											}
    //											if (cutsceneClip2.IsActive)
    //											{
    //												break;
    //											}
    //											if (!cutsceneClip2.bEnable)
    //											{
    //												break;
    //											}
    //											if (paClip != null)
    //											{
    //												cutsceneClip2.PaCutclip = paClip;
    //											}
    //											cutsceneClip2.SetActive(true, this, true);
    //											this.CheckClipWhetherHasBeenProcessed(cutsceneClip2, false);
    //											break;
    //										}
    //									}
    //								}
    //								dictionary.Add(cutsceneRow, num);
    //							}
    //						}
    //					}
    //				}
    //			}
    //			foreach (KeyValuePair<CutsceneRow, int> keyValuePair in dictionary)
    //			{
    //				for (int k = keyValuePair.Value - 1; k > -1; k--)
    //				{
    //					CutsceneClip cutsceneClip3 = keyValuePair.Key.cutsceneClips[k];
    //					if ((!this.isPlaying || this.isSkip) && this.NeedProcessOnJump(cutsceneClip3) && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip3, false) && cutsceneClip3.bEnable)
    //					{
    //						if (paClip != null)
    //						{
    //							cutsceneClip3.PaCutclip = paClip;
    //						}
    //						cutsceneClip3.SetActive(true, this, true);
    //					}
    //					if (cutsceneClip3.IsActive || (cutsceneClip3.subcutRows != null && cutsceneClip3.subcutRows.Count > 0))
    //					{
    //						cutsceneClip3.SetActive(false, this, true);
    //					}
    //				}
    //			}
    //		}
    //		for (int l = 0; l < cutsceneRows.Count; l++)
    //		{
    //			CutsceneRow cutsceneRow2 = cutsceneRows[l];
    //			if (cutsceneRow2.bEnable)
    //			{
    //				if (cutsceneRow2.cutsceneClips.Count >= 1)
    //				{
    //					if (cutsceneRow2.cutsceneClips.Count > 0 && time < cutsceneRow2.cutsceneClips[0].startTime)
    //					{
    //						if (!this.isPlaying || this.isSkip)
    //						{
    //							for (int m = 0; m < cutsceneRow2.cutsceneClips.Count; m++)
    //							{
    //								CutsceneClip cutsceneClip4 = cutsceneRow2.cutsceneClips[m];
    //								if (this.NeedProcessOnJump(cutsceneClip4) && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip4, true) && cutsceneClip4.bEnable)
    //								{
    //									if (paClip != null)
    //									{
    //										cutsceneClip4.PaCutclip = paClip;
    //									}
    //									cutsceneClip4.SetActive(true, this, true);
    //								}
    //								if (cutsceneClip4.IsActive || (cutsceneClip4.subcutRows != null && cutsceneClip4.subcutRows.Count > 0))
    //								{
    //									cutsceneClip4.SetActive(false, this, true);
    //								}
    //							}
    //						}
    //					}
    //					else
    //					{
    //						CutsceneClip cutsceneClip = cutsceneRow2.cutsceneClips[cutsceneRow2.cutsceneClips.Count - 1];
    //						if (time > cutsceneClip.startTime + cutsceneClip.length)
    //						{
    //							if ((!this.isPlaying || this.isSkip) && !this.isPause)
    //							{
    //								for (int n = cutsceneRow2.cutsceneClips.Count - 1; n > -1; n--)
    //								{
    //									CutsceneClip cutsceneClip5 = cutsceneRow2.cutsceneClips[n];
    //									if (this.NeedProcessOnJump(cutsceneClip5) && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip5, false) && cutsceneClip5.bEnable)
    //									{
    //										if (paClip != null)
    //										{
    //											cutsceneClip5.PaCutclip = paClip;
    //										}
    //										cutsceneClip5.SetActive(true, this, true);
    //									}
    //									if (cutsceneClip5.IsActive || (cutsceneClip5.subcutRows != null && cutsceneClip5.subcutRows.Count > 0))
    //									{
    //										cutsceneClip5.SetActive(false, this, true);
    //									}
    //								}
    //							}
    //							if (cutsceneClip.IsActive)
    //							{
    //								cutsceneClip.SetActive(false, this, true);
    //							}
    //						}
    //						else
    //						{
    //							for (int num3 = 0; num3 < cutsceneRow2.cutsceneClips.Count; num3++)
    //							{
    //								CutsceneClip cutsceneClip6 = cutsceneRow2.cutsceneClips[num3];
    //								if (cutsceneClip6 != null)
    //								{
    //									float num4 = cutsceneClip6.startTime + cutsceneClip6.length;
    //									if (num4 < time)
    //									{
    //										if (!this.isPause && (!this.isPlaying || this.isSkip) && this.NeedProcessOnJump(cutsceneClip6) && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip6, false) && cutsceneClip6.bEnable)
    //										{
    //											if (paClip != null)
    //											{
    //												cutsceneClip6.PaCutclip = paClip;
    //											}
    //											cutsceneClip6.SetActive(true, this, true);
    //										}
    //										if (cutsceneClip6.IsActive || (cutsceneClip6.subcutRows != null && cutsceneClip6.subcutRows.Count > 0))
    //										{
    //											cutsceneClip6.SetActive(false, this, true);
    //										}
    //									}
    //									else if (time < cutsceneClip6.startTime)
    //									{
    //										if ((!this.isPlaying || this.isSkip) && this.NeedProcessOnJump(cutsceneClip6) && (cutsceneClip6.curRelaTime > 0f || this.IsMomentClip(cutsceneClip6)) && cutsceneClip6.targets.Count > 0 && !this.CheckClipWhetherHasBeenProcessed(cutsceneClip6, true))
    //										{
    //											if (paClip != null)
    //											{
    //												cutsceneClip6.PaCutclip = paClip;
    //											}
    //											cutsceneClip6.SetActive(true, this, true);
    //										}
    //										if (cutsceneClip6.IsActive || (cutsceneClip6.subcutRows != null && cutsceneClip6.subcutRows.Count > 0))
    //										{
    //											cutsceneClip6.SetActive(false, this, true);
    //										}
    //										if (this.isPlaying)
    //										{
    //											break;
    //										}
    //									}
    //									else
    //									{
    //										if (cutsceneClip6.ActiveByCompare && this.isPlaying)
    //										{
    //											break;
    //										}
    //										if (cutsceneClip6.IsActive)
    //										{
    //											if (this.isPlaying)
    //											{
    //												break;
    //											}
    //										}
    //										else
    //										{
    //											if (!cutsceneClip6.bEnable)
    //											{
    //												break;
    //											}
    //											if (paClip != null)
    //											{
    //												cutsceneClip6.PaCutclip = paClip;
    //											}
    //											cutsceneClip6.SetActive(true, this, true);
    //											this.CheckClipWhetherHasBeenProcessed(cutsceneClip6, false);
    //										}
    //									}
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000450 RID: 1104 RVA: 0x00027D44 File Offset: 0x00025F44
    //	private bool IsMomentClip(CutsceneClip clip)
    //	{
    //		return clip.ActionType == typeof(CutAction_SetPositionAndAnim) || clip.ActionType == typeof(CutAction_SetVisible) || clip.ActionType == typeof(CutAction_SetActive) || clip.ActionType == typeof(CutAction_SetParent) || clip.ActionType == typeof(CutAction_PlayEffect) || clip.ActionType == typeof(CutAction_ActiveZhanDou) || clip.ActionType == typeof(CutAction_SetFace) || clip.ActionType == typeof(CutAction_ChatMode) || clip.ActionType == typeof(CutAction_CreateRole) || clip.ActionType == typeof(CutAction_SetDepth) || clip.ActionType == typeof(CutAction_SwapDepth) || clip.ActionType == typeof(CutAction_HighLight) || clip.ActionType == typeof(CutAction_SelfLuminous) || clip.ActionType == typeof(CutAction_SetActiveWeapon) || clip.ActionType == typeof(CutAction_PlayMovie) || clip.ActionType == typeof(CutAction_SetYanZhaoActive) || clip.ActionType == typeof(CutAction_SetFaceReceiveShadow) || clip.ActionType == typeof(CutAction_SetActiveSSAO);
    //	}

    //	// Token: 0x06000451 RID: 1105 RVA: 0x00027ED0 File Offset: 0x000260D0
    //	private bool NeedProcessOnJump(CutsceneClip clip)
    //	{
    //		return clip.ActionType == typeof(CutAction_SetPositionAndAnim) || clip.ActionType == typeof(CutAction_MainCameraFollowCurve) || clip.ActionType == typeof(CutAction_FollowCurveWithAnimator) || clip.ActionType == typeof(CutAction_CameraFollowCurve) || clip.ActionType == typeof(CutAction_TurnBody) || clip.ActionType == typeof(CutAction_TakeItem) || clip.ActionType == typeof(CutAction_SetVisible) || clip.ActionType == typeof(CutAction_SetActive) || clip.ActionType == typeof(CutAction_MegaMorph) || clip.ActionType == typeof(CutAction_Weather) || clip.ActionType == typeof(CutAction_WeatherTime) || clip.ActionType == typeof(CutAction_FollowCurve) || clip.ActionType == typeof(CutAction_ActiveZhanDou) || clip.ActionType == typeof(CutAction_ShowImage) || clip.ActionType == typeof(CutAction_SetParent) || clip.ActionType == typeof(CutAction_TimeScale) || clip.ActionType == typeof(CutAction_SetFace) || clip.ActionType == typeof(CutAction_ChatMode) || clip.ActionType == typeof(CutAction_CreateRole) || clip.ActionType == typeof(CutAction_ShowRole) || clip.ActionType == typeof(CutAction_SetDepth) || clip.ActionType == typeof(CutAction_SwapDepth) || clip.ActionType == typeof(CutAction_HighLight) || clip.ActionType == typeof(CutAction_ScaleRole) || clip.ActionType == typeof(CutAction_RotRole) || clip.ActionType == typeof(CutAction_MoveRole) || clip.ActionType == typeof(CutAction_SetAnim) || clip.ActionType == typeof(CutAction_SelfLuminous) || clip.ActionType == typeof(CutAction_SetActiveWeapon) || clip.ActionType == typeof(CutAction_IE_ImageBasedOffset) || clip.ActionType == typeof(CutAction_IE_Disturb) || clip.ActionType == typeof(CutAction_SetYanZhaoActive) || clip.ActionType == typeof(CutAction_SetFaceReceiveShadow) || clip.ActionType == typeof(CutAction_SetActiveSSAO);
    //	}

    //	// Token: 0x06000452 RID: 1106 RVA: 0x000281AC File Offset: 0x000263AC
    //	private bool CheckClipWhetherHasBeenProcessed(CutsceneClip clip, bool Order = false)
    //	{
    //		bool flag = true;
    //		foreach (CutParam_GameObject cutParam_GameObject in clip.targets)
    //		{
    //			if (cutParam_GameObject != null)
    //			{
    //				bool flag2 = this.TheActionHasBeenProcessed(cutParam_GameObject, clip, Order);
    //				flag = (flag && flag2);
    //			}
    //		}
    //		return flag;
    //	}

    //	// Token: 0x06000453 RID: 1107 RVA: 0x00028230 File Offset: 0x00026430
    //	public bool TheActionHasBeenProcessed(CutParam_GameObject cpgo, CutsceneClip clip, bool Order = false)
    //	{
    //		bool flag = false;
    //		Type actionType = clip.ActionType;
    //		float num = clip.GlobleStartTime + clip.length;
    //		if (cpgo.paramValue != null && this.processedCpGO.ContainsKey(cpgo.paramValue))
    //		{
    //			Cutscene.ProcessedData processedData = Cutscene.ProcessedData.ExistInArray(actionType, this.processedCpGO[cpgo.paramValue]);
    //			if (processedData != null)
    //			{
    //				if (!Order)
    //				{
    //					if (processedData.endTime > num)
    //					{
    //						flag = true;
    //					}
    //				}
    //				else if (processedData.endTime <= num)
    //				{
    //					flag = true;
    //				}
    //			}
    //			if (!flag)
    //			{
    //				Cutscene.ProcessedData.InsertToArrayUp(new Cutscene.ProcessedData(actionType, num), this.processedCpGO[cpgo.paramValue]);
    //			}
    //		}
    //		else
    //		{
    //			List<Cutscene.ProcessedData> list = new List<Cutscene.ProcessedData>();
    //			list.Add(new Cutscene.ProcessedData(actionType, num));
    //			if (cpgo.paramValue != null)
    //			{
    //				this.processedCpGO.Add(cpgo.paramValue, list);
    //			}
    //			else
    //			{
    //				Debug.Log(string.Concat(new object[]
    //				{
    //					clip.name,
    //					" |",
    //					clip.GlobleStartTime,
    //					"| 的cpgo.paramValue为 null"
    //				}));
    //			}
    //		}
    //		return flag;
    //	}

    //	// Token: 0x06000454 RID: 1108 RVA: 0x00028360 File Offset: 0x00026560
    //	public void SetParamObjectsActive(bool bActive)
    //	{
    //		ParamObject[] componentsInChildren = base.GetComponentsInChildren<ParamObject>(true);
    //		foreach (ParamObject paramObject in componentsInChildren)
    //		{
    //			CutsceneActor component = paramObject.gameObject.GetComponent<CutsceneActor>();
    //			if (component != null && component.curActor)
    //			{
    //				GameObject curActor = component.curActor;
    //				ParticleSystem component2 = curActor.GetComponent<ParticleSystem>();
    //				if (component2 != null)
    //				{
    //					UtilFun.SetActive(curActor, false);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000455 RID: 1109 RVA: 0x000283E4 File Offset: 0x000265E4
    //	public void ClearActiveClips()
    //	{
    //		foreach (CutsceneClip cutsceneClip in this.activeClips)
    //		{
    //			cutsceneClip.SetActive(false, this, false);
    //		}
    //		this.activeClips.Clear();
    //		ParamObject[] componentsInChildren = base.GetComponentsInChildren<ParamObject>(true);
    //		foreach (ParamObject paramObject in componentsInChildren)
    //		{
    //			if (!(paramObject == null))
    //			{
    //				paramObject.HasSetPosTime = -1f;
    //				paramObject.HasSetRotTime = -1f;
    //			}
    //		}
    //	}

    //	// Token: 0x06000456 RID: 1110 RVA: 0x000284A8 File Offset: 0x000266A8
    //	public CutsceneClip FindTheClip(int ID)
    //	{
    //		foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //		{
    //			foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //			{
    //				if (cutsceneClip.InstanceID == ID)
    //				{
    //					return cutsceneClip;
    //				}
    //				if (cutsceneClip.subcutRows != null && cutsceneClip.subcutRows.Count > 0)
    //				{
    //					foreach (CutsceneRow cutsceneRow2 in cutsceneClip.subcutRows)
    //					{
    //						foreach (CutsceneClip cutsceneClip2 in cutsceneRow2.cutsceneClips)
    //						{
    //							if (cutsceneClip2.InstanceID == ID)
    //							{
    //								return cutsceneClip2;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06000457 RID: 1111 RVA: 0x00028644 File Offset: 0x00026844
    //	public List<CutsceneClip> FindClips(string clipName)
    //	{
    //		List<CutsceneClip> list = new List<CutsceneClip>();
    //		string[] splits = clipName.Split(new char[]
    //		{
    //			' '
    //		});
    //		foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //		{
    //			foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //			{
    //				if (this.ClipContainTheStr(splits, cutsceneClip))
    //				{
    //					list.Add(cutsceneClip);
    //				}
    //			}
    //		}
    //		foreach (CutsceneClip cutsceneClip2 in this.eventRow.cutsceneClips)
    //		{
    //			if (this.ClipContainTheStr(splits, cutsceneClip2))
    //			{
    //				list.Add(cutsceneClip2);
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06000458 RID: 1112 RVA: 0x00028790 File Offset: 0x00026990
    //	private bool ClipContainTheStr(string[] splits, CutsceneClip clip)
    //	{
    //		bool result = false;
    //		foreach (string value in splits)
    //		{
    //			if (!clip.name.ToLower().Contains(value))
    //			{
    //				result = false;
    //				break;
    //			}
    //			result = true;
    //		}
    //		return result;
    //	}

    //	// Token: 0x06000459 RID: 1113 RVA: 0x000287E0 File Offset: 0x000269E0
    //	public void UseGhostCamera()
    //	{
    //		GameObject gameObject = Camera.main.gameObject;
    //		if (gameObject != null)
    //		{
    //			this.ghostCamera.enabled = true;
    //			SmoothFollow2 component = gameObject.GetComponent<SmoothFollow2>();
    //			if (component != null)
    //			{
    //				component.enabled = false;
    //			}
    //		}
    //	}

    //	// Token: 0x0600045A RID: 1114 RVA: 0x0002882C File Offset: 0x00026A2C
    //	public void RestoreCamera()
    //	{
    //		GameObject gameObject = Camera.main.gameObject;
    //		if (gameObject != null)
    //		{
    //			this.ghostCamera.enabled = false;
    //			SmoothFollow2 component = gameObject.GetComponent<SmoothFollow2>();
    //			if (component != null)
    //			{
    //				component.enabled = true;
    //			}
    //		}
    //	}

    //	// Token: 0x0600045B RID: 1115 RVA: 0x00028878 File Offset: 0x00026A78
    //	[CutsceneEventExclude]
    //	public static Cutscene Find(string n)
    //	{
    //		Cutscene[] array = (Cutscene[])UnityEngine.Object.FindObjectsOfType(typeof(Cutscene));
    //		int num = array.Length;
    //		for (int i = 0; i < num; i++)
    //		{
    //			if (array[i].cutsceneName == n)
    //			{
    //				return array[i];
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x0600045C RID: 1116 RVA: 0x000288C8 File Offset: 0x00026AC8
    //	[CutsceneEventExclude]
    //	public static string FormatTime(float time)
    //	{
    //		int num = (int)Mathf.Floor(time / 60f);
    //		int num2 = (int)Mathf.Repeat(time, 60f);
    //		int num3 = (int)Mathf.Repeat(time * 100f, 100f);
    //		string text = string.Empty;
    //		if (num < 10)
    //		{
    //			text += "0";
    //		}
    //		text += num;
    //		text += ":";
    //		if (num2 < 10)
    //		{
    //			text += "0";
    //		}
    //		text += num2;
    //		text += ":";
    //		if (num3 < 10)
    //		{
    //			text += "0";
    //		}
    //		return text + num3;
    //	}

    //	// Token: 0x0600045D RID: 1117 RVA: 0x00028988 File Offset: 0x00026B88
    //	public float ReCalculateTotalTime(float offsetTime = 0.01f)
    //	{
    //		float num = 0f;
    //		if (this.eventRow != null && this.eventRow.cutsceneClips != null && this.eventRow.cutsceneClips.Count > 0)
    //		{
    //			CutsceneClip cutsceneClip = this.eventRow.cutsceneClips[this.eventRow.cutsceneClips.Count - 1];
    //			num = cutsceneClip.startTime;
    //		}
    //		foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //		{
    //			int count = cutsceneRow.cutsceneClips.Count;
    //			if (count >= 1)
    //			{
    //				CutsceneClip cutsceneClip2 = cutsceneRow.cutsceneClips[count - 1];
    //				float num2 = cutsceneClip2.startTime + cutsceneClip2.length;
    //				if (num < num2)
    //				{
    //					num = num2;
    //				}
    //			}
    //		}
    //		num += offsetTime;
    //		this.TotalTime = num;
    //		return num;
    //	}

    //	// Token: 0x1700007F RID: 127
    //	// (get) Token: 0x0600045E RID: 1118 RVA: 0x00028A9C File Offset: 0x00026C9C
    //	public static GameObject MainCamera
    //	{
    //		get
    //		{
    //			if (Cutscene._mainCamera == null)
    //			{
    //				Cutscene._mainCamera = GameObject.FindWithTag("MainCamera");
    //				if (Cutscene._mainCamera == null)
    //				{
    //					Camera[] array = (Camera[])Resources.FindObjectsOfTypeAll(typeof(Camera));
    //					foreach (Camera camera in array)
    //					{
    //						if (camera.gameObject.tag == "MainCamera")
    //						{
    //							Cutscene._mainCamera = camera.gameObject;
    //							break;
    //						}
    //					}
    //				}
    //			}
    //			return Cutscene._mainCamera;
    //		}
    //	}

    //	// Token: 0x0600045F RID: 1119 RVA: 0x00028B38 File Offset: 0x00026D38
    //	public static GameObject Play(GameObject go, string path, float beginTime = -0.0001f, uScriptAct_Cutscene uScriptCut = null)
    //	{
    //		if (go == null)
    //		{
    //			if (!string.IsNullOrEmpty(path))
    //			{
    //				go = GameObject.Find(path);
    //			}
    //			if (go == null)
    //			{
    //				Debug.LogError("Cutscene GameObject 为 null");
    //				return null;
    //			}
    //		}
    //		GameObject result = null;
    //		string text = "Log : Cutscene.Play " + go.name;
    //		Debug.Log(text);
    //		SoftStar.Pal6.Console.Log(text);
    //		PalCutscenePrefab component = go.GetComponent<PalCutscenePrefab>();
    //		if (component != null)
    //		{
    //			result = component.Begin(beginTime, uScriptCut);
    //		}
    //		else
    //		{
    //			Debug.LogError("Error : " + go.name + " 没有PalCutscenePrefab");
    //			Cutscene component2 = go.GetComponent<Cutscene>();
    //			if (component2 != null)
    //			{
    //				result = go;
    //				component2.uScriptCutsc = uScriptCut;
    //				component2.Begin(beginTime);
    //			}
    //			else
    //			{
    //				Debug.LogError("Error : " + go.name + " 没有PalCutscenePrefab 也没有 Cutscene");
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x06000460 RID: 1120 RVA: 0x00028C1C File Offset: 0x00026E1C
    //	public void ClearRedundancyObjs()
    //	{
    //		foreach (ParamObject paramObject in base.GetComponentsInChildren<ParamObject>(true))
    //		{
    //			if (!(paramObject == null))
    //			{
    //				bool flag = false;
    //				foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //				{
    //					foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //					{
    //						foreach (CutParam_GameObject cutParam_GameObject in cutsceneClip.targets)
    //						{
    //							if (cutParam_GameObject.InstanceID == paramObject.cpGoID)
    //							{
    //								flag = true;
    //								break;
    //							}
    //						}
    //						List<CutParam_GameObject> cutParams = cutsceneClip.GetCutParams();
    //						foreach (CutParam_GameObject cutParam_GameObject2 in cutParams)
    //						{
    //							if (cutParam_GameObject2.InstanceID == paramObject.cpGoID)
    //							{
    //								flag = true;
    //								break;
    //							}
    //						}
    //					}
    //					if (flag)
    //					{
    //						break;
    //					}
    //				}
    //				if (!flag)
    //				{
    //					UnityEngine.Object.DestroyImmediate(paramObject.gameObject);
    //				}
    //			}
    //		}
    //		ParamObject[] componentsInChildren = base.GetComponentsInChildren<ParamObject>(true);
    //		for (int j = 0; j < componentsInChildren.Length; j++)
    //		{
    //			ParamObject paramObject2 = componentsInChildren[j];
    //			if (!(paramObject2 == null))
    //			{
    //				for (int k = j + 1; k < componentsInChildren.Length; k++)
    //				{
    //					ParamObject paramObject3 = componentsInChildren[k];
    //					if (!(paramObject3 == null))
    //					{
    //						if (paramObject2.cpGoID == paramObject3.cpGoID)
    //						{
    //							UnityEngine.Object.DestroyImmediate(paramObject3.gameObject);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000461 RID: 1121 RVA: 0x00028E84 File Offset: 0x00027084
    //	public void Clear()
    //	{
    //		ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>(true);
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			UnityEngine.Object.DestroyImmediate(componentsInChildren[i].gameObject);
    //		}
    //		XffectComponent[] componentsInChildren2 = base.GetComponentsInChildren<XffectComponent>(true);
    //		for (int j = 0; j < componentsInChildren2.Length; j++)
    //		{
    //			UnityEngine.Object.DestroyImmediate(componentsInChildren2[j].gameObject);
    //		}
    //		Agent[] componentsInChildren3 = base.GetComponentsInChildren<Agent>(true);
    //		for (int k = 0; k < componentsInChildren3.Length; k++)
    //		{
    //			UnityEngine.Object.DestroyImmediate(componentsInChildren3[k].gameObject);
    //		}
    //		foreach (Camera camera in base.GetComponentsInChildren<Camera>(true))
    //		{
    //			camera.transform.parent = null;
    //		}
    //		AudioSource[] componentsInChildren5 = base.GetComponentsInChildren<AudioSource>(true);
    //		int m = 0;
    //		while (m < componentsInChildren5.Length)
    //		{
    //			AudioSource audioSource = componentsInChildren5[m];
    //			if (!(audioSource.clip != null))
    //			{
    //				goto IL_119;
    //			}
    //			int num = 0;
    //			if (int.TryParse(audioSource.clip.name, out num))
    //			{
    //				if (num >= 1000000)
    //				{
    //					goto IL_119;
    //				}
    //			}
    //			IL_120:
    //			m++;
    //			continue;
    //			IL_119:
    //			UnityEngine.Object.DestroyImmediate(audioSource);
    //			goto IL_120;
    //		}
    //	}

    //	// Token: 0x06000462 RID: 1122 RVA: 0x00028FC4 File Offset: 0x000271C4
    //	private void CheckSkipClipDataCore(CutsceneClip clip, CutsceneActor actor, Dictionary<CutsceneActor, Cutscene.SkipClipData> dic)
    //	{
    //		if (actor == null)
    //		{
    //			Debug.Log(clip.name + "里的 " + clip.targets[0].paramValue.name + " 没有 CutsceneActor");
    //			return;
    //		}
    //		float globleStartTime = clip.GlobleStartTime;
    //		if (!dic.ContainsKey(actor))
    //		{
    //			Cutscene.SkipClipData value = new Cutscene.SkipClipData(actor, clip, globleStartTime);
    //			dic.Add(actor, value);
    //		}
    //		else
    //		{
    //			Cutscene.SkipClipData skipClipData = dic[actor];
    //			if (skipClipData.startTime < globleStartTime)
    //			{
    //				skipClipData.clip = clip;
    //				skipClipData.startTime = globleStartTime;
    //			}
    //		}
    //	}

    //	// Token: 0x06000463 RID: 1123 RVA: 0x0002905C File Offset: 0x0002725C
    //	public void PreProcessForCutscene()
    //	{
    //		this.SpeechPaths.Clear();
    //		if (Application.isPlaying)
    //		{
    //			this.SkipEndTime = 10f;
    //			if (base.name.Contains("0406") || base.name.Contains("2911") || base.name.Contains("8005"))
    //			{
    //				this.SkipEndTime = 11f;
    //			}
    //			else if (base.name.Contains("1609") || base.name.Contains("3252"))
    //			{
    //				this.SkipEndTime = 9.5f;
    //			}
    //			else if (base.name.Contains("2102"))
    //			{
    //				this.SkipEndTime = 12f;
    //			}
    //			else if (base.name.Contains("csm_8451"))
    //			{
    //				this.SkipEndTime = 32f;
    //			}
    //			else if (base.name.Contains("3602"))
    //			{
    //				this.SkipOnBeginTime = 0.2f;
    //			}
    //			else if (base.name.Contains("2606") || base.name.Contains("1703"))
    //			{
    //				this.CanSkipToEnd = false;
    //			}
    //			lipManager instance = lipManager.GetInstance(base.gameObject);
    //			foreach (CutsceneRow cutsceneRow in this.cutsceneRows)
    //			{
    //				foreach (CutsceneClip cutsceneClip in cutsceneRow.cutsceneClips)
    //				{
    //					if (cutsceneClip.ActionType == typeof(CutAction_ShowStringOnGUI))
    //					{
    //						object customProperty = cutsceneClip.GetCustomProperty("audioName");
    //						if (customProperty != null)
    //						{
    //							string str = customProperty as string;
    //							string text = CutAction_ShowStringOnGUI.audioExterPath + str;
    //							UtilFun.AssetBundleInstantiate<AudioClip>(text, AssetBundleType.Audio, true);
    //							this.SpeechPaths.Add(text);
    //						}
    //						object customProperty2 = cutsceneClip.GetCustomProperty("ID");
    //						if (customProperty2 != null)
    //						{
    //							int num = (int)customProperty2;
    //							if (instance != null)
    //							{
    //								instance.LoadLip(num.ToString());
    //							}
    //						}
    //					}
    //					else if (cutsceneClip.targets.Count >= 1)
    //					{
    //						CutParam_GameObject cutParam_GameObject = cutsceneClip.targets[0];
    //						GameObject paramValue = cutParam_GameObject.paramValue;
    //						if (!(paramValue == null))
    //						{
    //							CutsceneActor component = paramValue.GetComponent<CutsceneActor>();
    //							if (this.HasChangeMap && this.ChangeMapClipList.Count > 1)
    //							{
    //								break;
    //							}
    //							string actionTypeName = cutsceneClip.ActionTypeName;
    //							switch (actionTypeName)
    //							{
    //							case "CutAction_ChangeMap":
    //							{
    //								this.HasChangeMap = true;
    //								float globleStartTime = cutsceneClip.GlobleStartTime;
    //								Cutscene.SkipClipData item = new Cutscene.SkipClipData(component, cutsceneClip, globleStartTime);
    //								this.ChangeMapClipList.Add(item);
    //								break;
    //							}
    //							case "CutAction_ActiveZhanDou":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.ActiveZhanDouDic);
    //								break;
    //							case "CutAction_AnimatorCtrl":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.PlayAnimDic);
    //								break;
    //							case "CutAction_FollowCurveWithAnimator":
    //							{
    //								object customProperty3 = cutsceneClip.GetCustomProperty("specialAnim");
    //								bool flag = customProperty3 != null && (bool)customProperty3;
    //								if (flag)
    //								{
    //									this.CheckSkipClipDataCore(cutsceneClip, component, this.PlayAnimDic);
    //								}
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetPosDic);
    //								break;
    //							}
    //							case "CutAction_SetPositionAndAnim":
    //								foreach (CutParam_GameObject cutParam_GameObject2 in cutsceneClip.targets)
    //								{
    //									GameObject paramValue2 = cutParam_GameObject2.paramValue;
    //									if (!(paramValue2 == null))
    //									{
    //										CutsceneActor component2 = paramValue2.GetComponent<CutsceneActor>();
    //										this.CheckSkipClipDataCore(cutsceneClip, component2, this.SetPosDic);
    //									}
    //								}
    //								break;
    //							case "CutAction_FollowCurve":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetPosDic);
    //								break;
    //							case "CutAction_SetVisible":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetVisDic);
    //								break;
    //							case "CutAction_SetActive":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetActiveDic);
    //								break;
    //							case "CutAction_SetYanZhaoActive":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetYanZhaoActiveDic);
    //								break;
    //							case "CutAction_SetCloth":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetClothDic);
    //								break;
    //							case "CutAction_TurnBody":
    //								this.CheckSkipClipDataCore(cutsceneClip, component, this.SetTurnBodyDic);
    //								break;
    //							case "CutAction_WeatherTime":
    //							{
    //								float globleStartTime2 = cutsceneClip.GlobleStartTime;
    //								if (this.LastWeatherTime == null)
    //								{
    //									Cutscene.SkipClipData lastWeatherTime = new Cutscene.SkipClipData(component, cutsceneClip, globleStartTime2);
    //									this.LastWeatherTime = lastWeatherTime;
    //								}
    //								else if (this.LastWeatherTime.startTime < globleStartTime2)
    //								{
    //									this.LastWeatherTime.actor = component;
    //									this.LastWeatherTime.clip = cutsceneClip;
    //									this.LastWeatherTime.startTime = globleStartTime2;
    //								}
    //								break;
    //							}
    //							case "CutAction_Weather":
    //							{
    //								float globleStartTime3 = cutsceneClip.GlobleStartTime;
    //								if (this.LastWeather == null)
    //								{
    //									Cutscene.SkipClipData lastWeather = new Cutscene.SkipClipData(component, cutsceneClip, globleStartTime3);
    //									this.LastWeather = lastWeather;
    //								}
    //								else if (this.LastWeather.startTime < globleStartTime3)
    //								{
    //									this.LastWeather.actor = component;
    //									this.LastWeather.clip = cutsceneClip;
    //									this.LastWeather.startTime = globleStartTime3;
    //								}
    //								break;
    //							}
    //							case "CutAction_PlayAudio":
    //							{
    //								object customProperty4 = cutsceneClip.GetCustomProperty("IsBackSound");
    //								bool flag2 = customProperty4 == null || (bool)customProperty4;
    //								if (flag2)
    //								{
    //									float globleStartTime4 = cutsceneClip.GlobleStartTime;
    //									if (this.LastPlayAudio == null)
    //									{
    //										Cutscene.SkipClipData lastPlayAudio = new Cutscene.SkipClipData(component, cutsceneClip, globleStartTime4);
    //										this.LastPlayAudio = lastPlayAudio;
    //									}
    //									else if (this.LastPlayAudio.startTime < globleStartTime4)
    //									{
    //										this.LastPlayAudio.actor = component;
    //										this.LastPlayAudio.clip = cutsceneClip;
    //										this.LastPlayAudio.startTime = globleStartTime4;
    //									}
    //								}
    //								break;
    //							}
    //							case "CutAction_AddNewStrangeNew":
    //							{
    //								Cutscene.SkipClipData item2 = new Cutscene.SkipClipData(component, cutsceneClip, cutsceneClip.GlobleStartTime);
    //								this.AddNewStrangeNewList.Add(item2);
    //								break;
    //							}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06000464 RID: 1124 RVA: 0x000297D4 File Offset: 0x000279D4
    //	public void CheckPlayAnimDic(CutsceneActor actor, float startTime)
    //	{
    //		if (this.PlayAnimDic.ContainsKey(actor))
    //		{
    //			Cutscene.SkipClipData skipClipData = this.PlayAnimDic[actor];
    //			if (skipClipData != null && skipClipData.startTime < startTime)
    //			{
    //				this.PlayAnimDic.Remove(actor);
    //			}
    //		}
    //	}

    //	// Token: 0x17000080 RID: 128
    //	// (get) Token: 0x06000465 RID: 1125 RVA: 0x00029820 File Offset: 0x00027A20
    //	// (set) Token: 0x06000466 RID: 1126 RVA: 0x00029828 File Offset: 0x00027A28
    //	public bool SkipEnd
    //	{
    //		get
    //		{
    //			return this.skipEnd;
    //		}
    //		set
    //		{
    //			this.skipEnd = value;
    //		}
    //	}

    //	// Token: 0x06000467 RID: 1127 RVA: 0x00029834 File Offset: 0x00027A34
    //	private bool ProcessSkipEnd()
    //	{
    //		this.SkipEnd = true;
    //		UIManager.CloseText();
    //		if (MoviesManager.Instance.enabled)
    //		{
    //			MoviesManager.Instance.Stop();
    //		}
    //		CutAction_PlayParticle.Clear();
    //		CutAction_PlayUnitSE.Clear();
    //		CutAction_PlayEffect.Clear();
    //		if (this.HasChangeMap)
    //		{
    //			for (int i = 0; i < this.ChangeMapClipList.Count; i++)
    //			{
    //				Cutscene.SkipClipData skipClipData = this.ChangeMapClipList[i];
    //				if (skipClipData != null)
    //				{
    //					if (this.currentTime < skipClipData.startTime)
    //					{
    //						foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair in this.ActiveZhanDouDic)
    //						{
    //							keyValuePair.Value.ProcImme(Cutscene.EndSkipEnum.ActiveZhanDou);
    //						}
    //						skipClipData.ProcImme(Cutscene.EndSkipEnum.None);
    //						return true;
    //					}
    //				}
    //			}
    //		}
    //		if (CutsceneFlash.Instance != null)
    //		{
    //			CutsceneFlash.Instance.End();
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair2 in this.ActiveZhanDouDic)
    //		{
    //			keyValuePair2.Value.ProcImme(Cutscene.EndSkipEnum.ActiveZhanDou);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair3 in this.SetPosDic)
    //		{
    //			keyValuePair3.Value.ProcImme(Cutscene.EndSkipEnum.SetPos);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair4 in this.SetTurnBodyDic)
    //		{
    //			if (!this.SetPosDic.ContainsKey(keyValuePair4.Key))
    //			{
    //				keyValuePair4.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //			}
    //			else
    //			{
    //				Cutscene.SkipClipData skipClipData2 = this.SetPosDic[keyValuePair4.Key];
    //				if (skipClipData2.startTime < keyValuePair4.Value.startTime)
    //				{
    //					keyValuePair4.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //				}
    //			}
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair5 in this.PlayAnimDic)
    //		{
    //			keyValuePair5.Value.ProcImme(Cutscene.EndSkipEnum.PlayAnim);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair6 in this.SetVisDic)
    //		{
    //			keyValuePair6.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair7 in this.SetActiveDic)
    //		{
    //			keyValuePair7.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair8 in this.SetYanZhaoActiveDic)
    //		{
    //			keyValuePair8.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		foreach (KeyValuePair<CutsceneActor, Cutscene.SkipClipData> keyValuePair9 in this.SetClothDic)
    //		{
    //			keyValuePair9.Value.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		for (int j = 0; j < this.AddNewStrangeNewList.Count; j++)
    //		{
    //			Cutscene.SkipClipData skipClipData3 = this.AddNewStrangeNewList[j];
    //			if (skipClipData3 != null)
    //			{
    //				skipClipData3.ProcImme(Cutscene.EndSkipEnum.None);
    //			}
    //		}
    //		if (this.LastPlayAudio != null)
    //		{
    //			this.LastPlayAudio.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		if (this.LastWeather != null)
    //		{
    //			this.LastWeather.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		if (this.LastWeatherTime != null)
    //		{
    //			this.LastWeatherTime.ProcImme(Cutscene.EndSkipEnum.None);
    //		}
    //		Camera main = Camera.main;
    //		if (main != null)
    //		{
    //			DepthOfFieldScatter component = main.GetComponent<DepthOfFieldScatter>();
    //			if (component != null)
    //			{
    //				UnityEngine.Object.Destroy(component);
    //			}
    //			FirstPersonEyesEffect component2 = main.GetComponent<FirstPersonEyesEffect>();
    //			if (component2 != null)
    //			{
    //				UnityEngine.Object.Destroy(component2);
    //			}
    //			PalShake component3 = main.GetComponent<PalShake>();
    //			if (component3 != null)
    //			{
    //				component3.StopShake();
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06000468 RID: 1128 RVA: 0x00029D8C File Offset: 0x00027F8C
    //	private void ClearSpeech()
    //	{
    //		for (int i = 0; i < this.SpeechPaths.Count; i++)
    //		{
    //			string path = this.SpeechPaths[i];
    //			StreamAssetBundle.UnLoadExistObj(path);
    //		}
    //	}


    //	// Token: 0x0200008D RID: 141
    //	public class ProcessedData
    //	{
    //		// Token: 0x06000469 RID: 1129 RVA: 0x00029DC8 File Offset: 0x00027FC8
    //		public ProcessedData(Type type, float endTime)
    //		{
    //			this.type = type;
    //			this.endTime = endTime;
    //		}

    //		// Token: 0x0600046A RID: 1130 RVA: 0x00029DE0 File Offset: 0x00027FE0
    //		public bool Equal(Type type)
    //		{
    //			bool flag = this.type == type;
    //			if (!flag)
    //			{
    //				if (type == typeof(CutAction_SetPositionAndAnim))
    //				{
    //					flag = (this.type == typeof(CutAction_FollowCurveWithAnimator) || this.type == typeof(CutAction_FollowCurve));
    //				}
    //				else if (type == typeof(CutAction_FollowCurveWithAnimator) || type == typeof(CutAction_FollowCurve))
    //				{
    //					flag = (this.type == typeof(CutAction_SetPositionAndAnim));
    //				}
    //				else if (type == typeof(CutAction_TurnBody))
    //				{
    //					flag = (this.type == typeof(CutAction_SetPositionAndAnim) || this.type == typeof(CutAction_FollowCurveWithAnimator));
    //				}
    //				else if (type == typeof(CutAction_AnimatorCtrl))
    //				{
    //					flag = (this.type == typeof(CutAction_ActiveZhanDou));
    //				}
    //				else if (type == typeof(CutAction_ShowRole))
    //				{
    //					flag = (this.type == typeof(CutAction_SetFace) || this.type == typeof(CutAction_ChatMode));
    //				}
    //				else if (type == typeof(CutAction_SetFace))
    //				{
    //					flag = (this.type == typeof(CutAction_ShowRole));
    //				}
    //				else if (type == typeof(CutAction_ChatMode))
    //				{
    //					flag = (this.type == typeof(CutAction_ShowRole));
    //				}
    //				else if (this.type == typeof(CutAction_MoveRole))
    //				{
    //					flag = (type == typeof(CutAction_ChatMode) || type == typeof(CutAction_CreateRole));
    //				}
    //				else if (this.type == typeof(CutAction_SetAnim))
    //				{
    //					flag = (type == typeof(CutAction_MoveRole) || type == typeof(CutAction_CreateRole));
    //				}
    //				else if (this.type == typeof(CutAction_SwapDepth))
    //				{
    //					flag = (type == typeof(CutAction_CreateRole));
    //				}
    //				else if (this.type == typeof(CutAction_ChatMode))
    //				{
    //					flag = (type == typeof(CutAction_MoveRole) || type == typeof(CutAction_CreateRole) || type == typeof(CutAction_SetAnim));
    //				}
    //			}
    //			return flag;
    //		}

    //		// Token: 0x0600046B RID: 1131 RVA: 0x0002A054 File Offset: 0x00028254
    //		public static Cutscene.ProcessedData ExistInArray(Type type, List<Cutscene.ProcessedData> pds)
    //		{
    //			Cutscene.ProcessedData result = null;
    //			for (int i = pds.Count - 1; i > -1; i--)
    //			{
    //				Cutscene.ProcessedData processedData = pds[i];
    //				if (processedData.Equal(type))
    //				{
    //					result = processedData;
    //					break;
    //				}
    //			}
    //			return result;
    //		}

    //		// Token: 0x0600046C RID: 1132 RVA: 0x0002A098 File Offset: 0x00028298
    //		public static void InsertToArrayUp(Cutscene.ProcessedData newPd, List<Cutscene.ProcessedData> pds)
    //		{
    //			int num = 0;
    //			foreach (Cutscene.ProcessedData processedData in pds)
    //			{
    //				if (newPd.endTime < processedData.endTime)
    //				{
    //					break;
    //				}
    //				num++;
    //			}
    //			pds.Insert(num, newPd);
    //		}

    //		// Token: 0x04000454 RID: 1108
    //		public Type type;

    //		// Token: 0x04000455 RID: 1109
    //		public float endTime;
    //	}

    //	// Token: 0x0200008E RID: 142
    //	public enum EndSkipEnum
    //	{
    //		// Token: 0x04000457 RID: 1111
    //		ActiveZhanDou,
    //		// Token: 0x04000458 RID: 1112
    //		PlayAnim,
    //		// Token: 0x04000459 RID: 1113
    //		SetPos,
    //		// Token: 0x0400045A RID: 1114
    //		SetVis,
    //		// Token: 0x0400045B RID: 1115
    //		SetActive,
    //		// Token: 0x0400045C RID: 1116
    //		None = 20
    //	}

    //	// Token: 0x0200008F RID: 143
    //	public class SkipClipData
    //	{
    //		// Token: 0x0600046D RID: 1133 RVA: 0x0002A118 File Offset: 0x00028318
    //		public SkipClipData(CutsceneActor actor, CutsceneClip clip, float startTime)
    //		{
    //			this.actor = actor;
    //			this.clip = clip;
    //			this.startTime = startTime;
    //		}

    //		// Token: 0x0600046E RID: 1134 RVA: 0x0002A138 File Offset: 0x00028338
    //		public void ProcImme(Cutscene.EndSkipEnum skipEnum = Cutscene.EndSkipEnum.None)
    //		{
    //			if (this.clip == null)
    //			{
    //				return;
    //			}
    //			CutsceneAction cutsceneAction;
    //			if (this.actor != null)
    //			{
    //				cutsceneAction = (this.actor.GetComponent(this.clip.ActionType) as CutsceneAction);
    //			}
    //			else
    //			{
    //				GameObject paramValue = this.clip.targets[0].paramValue;
    //				cutsceneAction = (paramValue.GetComponent(this.clip.ActionType) as CutsceneAction);
    //			}
    //			if (cutsceneAction == null)
    //			{
    //				return;
    //			}
    //			GameObject go = (!(this.actor == null)) ? this.actor.curActor : null;
    //			cutsceneAction.ProcessImme(go, Cutscene.current, this.clip, this.clip.functionName, skipEnum);
    //		}

    //		// Token: 0x0400045D RID: 1117
    //		public float startTime;

    //		// Token: 0x0400045E RID: 1118
    //		public CutsceneClip clip;

    //		// Token: 0x0400045F RID: 1119
    //		public CutsceneActor actor;
    //	}

    public delegate void void_fun();
}
