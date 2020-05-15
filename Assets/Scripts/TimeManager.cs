using System;
using System.IO;
using SoftStar;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;

    private float autoSaveTime;

    public float autoSaveSecond = 300f;

    private float waitAutoSave;

    public float waitSaveSecond = 10f;

    public float weatherTime;

    public float NightTimeAcceleration = 1f;

    public float dayLength = 4800f;

    public float startAcceleration;

    public float endAcceleration;

    public bool timeStopped;

    public event Action selfUpdate;

	public static TimeManager Instance
	{
		get
		{
			if (TimeManager.instance == null)
			{
				TimeManager.Initialize();
			}
			return TimeManager.instance;
		}
	}

	public static TimeManager Initialize()
	{
		PalMain gameMain = PalMain.GameMain;
		if (gameMain != null)
		{
			TimeManager.instance = gameMain.GetComponent<TimeManager>();
			if (TimeManager.instance == null)
			{
				TimeManager.instance = gameMain.gameObject.AddComponent<TimeManager>();
			}
            SaveManager.OnLoadOver -= TimeManager.instance.AutoSaveInit;
            SaveManager.OnLoadOver += TimeManager.instance.AutoSaveInit;
            //ScenesManager.Instance.OnChangeMap -= TimeManager.instance.RecordWeatherTime;
            //ScenesManager.Instance.OnChangeMap += TimeManager.instance.RecordWeatherTime;
            //ScenesManager.Instance.OnLevelLoaded -= TimeManager.instance.RecoverWeatherTime;
            //ScenesManager.Instance.OnLevelLoaded += TimeManager.instance.RecoverWeatherTime;
            //GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.InitNormal));
            //GameStateManager.AddEndStateFun(GameState.Cutscene, new GameStateManager.void_fun(TimeManager.EndCutscene));
            //GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.instance.Begin));
            //GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.instance.Pause));
        }
		return TimeManager.instance;
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		SaveManager.OnLoadOver -= TimeManager.instance.AutoSaveInit;
		ScenesManager.Instance.OnChangeMap -= TimeManager.instance.RecordWeatherTime;
		ScenesManager.Instance.OnLevelLoaded -= TimeManager.instance.RecoverWeatherTime;
		//GameStateManager.RemoveInitStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.InitNormal));
		//GameStateManager.RemoveInitStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.instance.Begin));
		//GameStateManager.RemoveEndStateFun(GameState.Normal, new GameStateManager.void_fun(TimeManager.instance.Pause));
	}

	private static void InitNormal()
	{
		TimeManager timeManager = TimeManager.Initialize();
		timeManager.selfUpdate = (Action)Delegate.Remove(timeManager.selfUpdate, new Action(TimeManager.instance.AutoSave));
		TimeManager timeManager2 = TimeManager.Initialize();
		timeManager2.selfUpdate = (Action)Delegate.Combine(timeManager2.selfUpdate, new Action(TimeManager.instance.AutoSave));
		TimeManager.instance.waitAutoSave = 0f;
	}

	private static void EndCutscene()
	{
		TimeManager.instance.autoSaveTime = TimeManager.instance.autoSaveSecond;
	}

	private void Update()
	{
		if (this.selfUpdate != null)
		{
			this.selfUpdate();
		}
	}

	public void AutoSaveInit()
	{
		this.autoSaveTime = 0f;
		this.waitAutoSave = 0f;
	}

	public void AutoSave()
	{
		if (SceneManager.GetActiveScene().buildIndex != 0)
		{
			this.autoSaveTime += Time.unscaledDeltaTime;
		}
		if (this.autoSaveTime >= this.autoSaveSecond)
		{
			this.waitAutoSave += Time.unscaledDeltaTime;
			//if (GameStateManager.CurGameState == GameState.Normal && !PalBattleManager.Instance().IsEnteringBattle() && this.waitAutoSave >= this.waitSaveSecond && !PlayerCtrlManager.agentObj.IsJump && !PlayerCtrlManager.agentObj.IsInSky)
			//{
			//	if (SaveManager.Save("00"))
			//	{
			//		UIDialogManager.Instance.PushFlashMessageDialog(null, Langue.get_string(131231UL, "UI"), 2500, true);
			//	}
			//	this.autoSaveTime = 0f;
			//	this.waitAutoSave = 0f;
			//	Resources.UnloadUnusedAssets();
			//}
		}
	}

	public void RecordWeatherTime(int level)
	{
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	this.weatherTime = UniStormWeatherSystem.instance.startTime;
		//	this.NightTimeAcceleration = UniStormWeatherSystem.instance.NightTimeAcceleration;
		//	this.dayLength = UniStormWeatherSystem.instance.dayLength;
		//	this.startAcceleration = UniStormWeatherSystem.instance.startAcceleration;
		//	this.endAcceleration = UniStormWeatherSystem.instance.endAcceleration;
		//}
	}

	public void RecoverWeatherTime(int level)
	{
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	WeatherManage.Instance.SetTimeOfDay(this.weatherTime * 24f, true);
		//	this.selfUpdate = (Action)Delegate.Remove(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//	UniStormWeatherSystem.instance.timeStopped = this.timeStopped;
		//}
		//else if (!this.timeStopped)
		//{
		//	this.selfUpdate = (Action)Delegate.Remove(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//	this.selfUpdate = (Action)Delegate.Combine(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//}
		//else
		//{
		//	this.selfUpdate = (Action)Delegate.Remove(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//}
	}

	public void Stop()
	{
		this.timeStopped = true;
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	UniStormWeatherSystem.instance.timeStopped = true;
		//}
	}

	public void Play()
	{
		this.timeStopped = false;
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	UniStormWeatherSystem.instance.timeStopped = false;
		//}
	}

	public void Pause()
	{
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	UniStormWeatherSystem.instance.timeStopped = true;
		//}
		//else
		//{
		//	this.selfUpdate = (Action)Delegate.Remove(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//}
	}

	public void Begin()
	{
		//if (UniStormWeatherSystem.instance != null)
		//{
		//	UniStormWeatherSystem.instance.timeStopped = this.timeStopped;
		//}
		//else
		//{
		//	this.selfUpdate = (Action)Delegate.Remove(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//	this.selfUpdate = (Action)Delegate.Combine(this.selfUpdate, new Action(this.CaculateWeatherTime));
		//}
	}

	public void CaculateWeatherTime()
	{
		float num = 24f * this.weatherTime;
		if (!this.timeStopped)
		{
			if (num > this.startAcceleration || num < this.endAcceleration)
			{
				this.weatherTime += Time.deltaTime * this.NightTimeAcceleration / this.dayLength;
			}
			else
			{
				this.weatherTime += Time.deltaTime / this.dayLength;
			}
		}
	}

	public void SaveWeatherTime(BinaryWriter writer)
	{
		this.RecordWeatherTime(0);
		writer.Write(this.weatherTime);
		writer.Write(this.NightTimeAcceleration);
		writer.Write(this.dayLength);
		writer.Write(this.startAcceleration);
		writer.Write(this.endAcceleration);
		writer.Write(this.timeStopped);
	}

	public void LoadWeatherTime(BinaryReader reader)
	{
		//if (SaveManager.VersionNum >= 18u)
		//{
		//	this.weatherTime = reader.ReadSingle();
		//	this.NightTimeAcceleration = reader.ReadSingle();
		//	this.dayLength = reader.ReadSingle();
		//	this.startAcceleration = reader.ReadSingle();
		//	this.endAcceleration = reader.ReadSingle();
		//	this.timeStopped = reader.ReadBoolean();
		//	this.RecoverWeatherTime(0);
		//}
	}
}
