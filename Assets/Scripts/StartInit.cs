//using Funfia.File;
using SoftStar;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInit : MonoBehaviour
{
	private static StartInit mInstance;

	[NonSerialized]
	private GameObject Background;

	public bool OverrideMainLine;

	private Action Step;

	[NonSerialized]
	private Transform[] mButtons;

	[NonSerialized]
	private float mButtonY;

	public static bool IsFirstStart = true;

	[NonSerialized]
	private float mBeginTime;

	public static StartInit Instance
	{
		get
		{
			return StartInit.mInstance;
		}
	}

	private void LoadMovieUIPanel()
	{
		//bool flag = !(StanealoneVideoPlayBack.Instance == null);
		//if (flag)
		//{
		//	return;
		//}
		//string path = FileLoader.MoviePanel.ToAssetBundlePath();
		//GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>(path, true, true);
		//StanealoneVideoPlayBack.Instance.gameObject.SetActive(false);
		//StanealoneVideoPlayBack.Instance.transform.parent.parent.GetComponent<AVProWindowsMediaManager>().enabled = true;
	}

	private void Awake()
	{
		this.LoadMovieUIPanel();
		this.Background = GameObject.Find("/Background");
		if (this.Background == null)
		{
            string path = ((PalMain.DetectMachine() <= PalMain.PLAYER_RECOMMANDATION.LOW) ? "StartUIBack_Low" : "StartUIBack").ToLanguagePath();
            //AssetBundle bundle = FileLoader.LoadAssetBundleFromFile(path);
            //this.Background = (UnityEngine.Object.Instantiate(bundle.MainAsset5()) as GameObject);
            //FileLoader.UnloadAssetBundle(path);
   //         this.Background.name = "Background";
			//this.Background.transform.localPosition = Vector3.zero;
			//this.Background.transform.localRotation = Quaternion.identity;
			//this.Background.transform.localScale = Vector3.one;
		}
		//this.Step = new Action(this.Step_0);
		//StartInit.mInstance = this;
		//this.Init();
	}

	private void Update()
	{
		//this.Step();
	}

	private void OnLevelLoadOver()
	{
		//PalMain.LoadOverEvent = (Action)Delegate.Remove(PalMain.LoadOverEvent, new Action(this.OnLevelLoadOver));
		//GameStateManager.CurGameState = GameState.Start;
	}

	private void Init()
	{
		if (SceneManager.GetActiveScene().buildIndex != 0)
		{
			return;
		}
		this.LoadMain();
		//PalMain.Instance.ReStart();
		if (StartInit.IsFirstStart)
		{
			//GameStateManager.CurGameState = GameState.Start;
		}
		else
		{
			//PalMain.LoadOverEvent = (Action)Delegate.Remove(PalMain.LoadOverEvent, new Action(this.OnLevelLoadOver));
			//PalMain.LoadOverEvent = (Action)Delegate.Combine(PalMain.LoadOverEvent, new Action(this.OnLevelLoadOver));
		}
	}

	private void LoadMain()
	{
		GameObject x = GameObject.Find("/Main");
		if (x == null)
		{
			//PalMain.CreateInstance();
		}
	}

	private void To_Step_0()
	{
		//if (UIManager.Instance.Panel_Start != null)
		//{
		//	UIManager.Instance.Panel_Start.Hide();
		//}
		if (this.Background != null)
		{
			this.Background.SetActive(false);
		}
		this.Step = new Action(this.Step_0);
	}

	private void Step_0()
	{
	}

	private void To_Step_1()
	{
		//if (UIManager.Instance.Panel_Start != null)
		//{
		//	UIManager.Instance.Panel_Start.Hide();
		//}
		if (this.Background != null)
		{
			this.Background.SetActive(true);
		}
		this.mBeginTime = Time.time;
		this.Step = new Action(this.Step_1);
	}

	private void Step_1()
	{
		if (Time.time >= this.mBeginTime + 11f)
		{
			//this.To_Step_2(Langue.IsLanguage2);
		}
	}

	private void To_Step_2(bool isEng = false)
	{
		if (this.mButtons == null)
		{
			//Transform transform = UIManager.Instance.Panel_Start.transform;
			this.mButtons = new Transform[]
			{
				transform.Find("Anchor/DLCButton"),
				transform.Find("Anchor/StartButton"),
				transform.Find("Anchor/LoadButton"),
				transform.Find("Anchor/MusicButton"),
				transform.Find("Anchor/CGButton"),
				transform.Find("Anchor/HistoryButton"),
				transform.Find("Anchor/WorkerListButton"),
				transform.Find("Anchor/QuitButton")
			};
			if (isEng)
			{
				this.mButtonY = this.mButtons[0].localPosition.x;
				Transform[] array = this.mButtons;
				for (int i = 0; i < array.Length; i++)
				{
					Transform transform2 = array[i];
					transform2.localPosition = new Vector3(this.mButtonY + 100f, transform2.localPosition.y, transform2.localPosition.z);
				}
			}
			else
			{
				this.mButtonY = this.mButtons[0].localPosition.y;
				Transform[] array2 = this.mButtons;
				for (int j = 0; j < array2.Length; j++)
				{
					Transform transform3 = array2[j];
					transform3.localPosition = new Vector3(transform3.localPosition.x, this.mButtonY - 100f, transform3.localPosition.z);
				}
			}
		}
		//UIManager.Instance.Panel_Start.GetComponent<UIPanel>().alpha = 0f;
		//this.mBeginTime = Time.time;
		//UIManager.Instance.Panel_Start.Show();
		this.Step = new Action(this.Step_2);
	}

	//[DebuggerHidden]
	//private IEnumerator CubeGameExit(int position)
	//{
	//	return new StartInit.<CubeGameExit>c__Iterator57();
	//}

	private void Step_2()
	{
		float num = Time.time - this.mBeginTime;
		if (num <= 1f)
		{
			//UIManager.Instance.Panel_Start.GetComponent<UIPanel>().alpha = num;
		}
		else
		{
			//UIManager.Instance.Panel_Start.GetComponent<UIPanel>().alpha = 1f;
			//this.mBeginTime = Time.time;
			//if (Langue.IsLanguage2)
			//{
			//	this.Step = new Action(this.Step_3_Eng);
			//}
			//else
			//{
			//	this.Step = new Action(this.Step_3);
			//}
		}
	}

	private void Step_3()
	{
		float num = Time.time - this.mBeginTime;
		if (num <= 1f)
		{
			Transform[] array = this.mButtons;
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform = array[i];
				num -= 0.05f;
				if (num > 0f)
				{
					if (num <= 0.1f)
					{
						transform.localPosition = new Vector3(transform.localPosition.x, this.mButtonY - 5000f * num * num + 1000f * num - 50f, transform.localPosition.z);
					}
					else
					{
						transform.localPosition = new Vector3(transform.localPosition.x, this.mButtonY, transform.localPosition.z);
					}
				}
			}
		}
		else
		{
			Transform[] array2 = this.mButtons;
			for (int j = 0; j < array2.Length; j++)
			{
				Transform transform2 = array2[j];
				transform2.localPosition = new Vector3(transform2.localPosition.x, this.mButtonY, transform2.localPosition.z);
			}
			this.Step = new Action(this.Step_0);
		}
	}

	private void Step_3_Eng()
	{
		float num = Time.time - this.mBeginTime;
		if (num <= 1f)
		{
			Transform[] array = this.mButtons;
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform = array[i];
				num -= 0.05f;
				if (num > 0f)
				{
					if (num <= 0.1f)
					{
						transform.localPosition = new Vector3(this.mButtonY + 5000f * num * num - 1000f * num + 50f, transform.localPosition.y, transform.localPosition.z);
					}
					else
					{
						transform.localPosition = new Vector3(this.mButtonY, transform.localPosition.y, transform.localPosition.z);
					}
				}
			}
		}
		else
		{
			Transform[] array2 = this.mButtons;
			for (int j = 0; j < array2.Length; j++)
			{
				Transform transform2 = array2[j];
				transform2.localPosition = new Vector3(this.mButtonY, transform2.localPosition.y, transform2.localPosition.z);
			}
			this.Step = new Action(this.Step_0);
		}
	}

	public void Show()
	{
		//PalMain.Instance.InitPlayBeginMovie();
	}

	public void ShowCore()
	{
		if (StartInit.IsFirstStart)
		{
			StartInit.IsFirstStart = false;
			//if (MoviesManager.Instance.Play(MoviesManager.BeginMoviePath, delegate
			//{
			//	this.To_Step_1();
			//}, null))
			//{
			//	this.To_Step_0();
			//}
			//else
			//{
			//	this.To_Step_1();
			//}
		}
		else
		{
			this.To_Step_1();
		}
	}

	public void Hide()
	{
		this.To_Step_0();
	}
}
