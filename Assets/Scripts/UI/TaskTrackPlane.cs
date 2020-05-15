using System;
using UnityEngine;

/// <summary>
/// 任务追踪面板
/// </summary>
public class TaskTrackPlane 
{
    //    private const string TASK_PLANE = "EZGUI/TaskTrackPlane/TaskPlane";

    //    private const string TASK_BACK = "Back";

    //    private const string TASK_IMAGE = "Imageback/Image";

    //    private const string TASK_TXT_CHA = "TextC";

    //    private const string TASK_TXT_TA = "TextT";

    //    private GameObject m_tTaskPlane;

    //    //private SpriteText m_tTextCha;

    //    //private SpriteText m_tTextTa;

    //    //private UIButton m_tBack;

    //    private MeshRenderer m_rImage;

    //    //private UIBistateInteractivePanel m_taskBack;

    //    //private UIBistateInteractivePanel m_tasktextT;

    //    //private UIBistateInteractivePanel m_tasktextC;

    //    //private UIBistateInteractivePanel m_taskimageback;

    //    //private UIBistateInteractivePanel m_taskimage;

    //    private float m_fCreatTime;

    //    private bool m_bActive;

    //    private bool m_bTime;

    //    private bool m_bMoving;

    //    private bool m_bKey;

    //    private bool m_bHide = true;

    //    private float fLastTimer;

    //    private float fSpaceTimer = 2f;

    //    public void Awake()
    //	{
    //		//base.RegisterGUI();
    //	}

    //	public override bool Init()
    //	{
    //		UnityEngine.Object original = ResourceLoader.Load("EZGUI/TaskTrackPlane/TaskPlane", typeof(GameObject));
    //		this.m_tTaskPlane = (UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity) as GameObject);
    //		//if (this.m_taskBack == null)
    //		//{
    //		//	this.m_taskBack = this.m_tTaskPlane.transform.FindChild("Back").GetComponent<UIBistateInteractivePanel>();
    //		//}
    //		//if (this.m_taskimageback == null)
    //		//{
    //		//	this.m_taskimageback = this.m_tTaskPlane.transform.FindChild("Imageback").GetComponent<UIBistateInteractivePanel>();
    //		//}
    //		//if (this.m_taskimage == null)
    //		//{
    //		//	this.m_taskimage = this.m_tTaskPlane.transform.FindChild("Imageback/Image").GetComponent<UIBistateInteractivePanel>();
    //		//}
    //		//if (this.m_tasktextT == null)
    //		//{
    //		//	this.m_tasktextT = this.m_tTaskPlane.transform.FindChild("TextT").GetComponent<UIBistateInteractivePanel>();
    //		//}
    //		//if (this.m_tasktextC == null)
    //		//{
    //		//	this.m_tasktextC = this.m_tTaskPlane.transform.FindChild("TextC").GetComponent<UIBistateInteractivePanel>();
    //		//}
    //		//if (this.m_tTextCha == null)
    //		//{
    //		//	this.m_tTextCha = this.m_tTaskPlane.transform.FindChild("TextC").GetComponent<SpriteText>();
    //		//}
    //		//if (this.m_tTextTa == null)
    //		//{
    //		//	this.m_tTextTa = this.m_tTaskPlane.transform.FindChild("TextT").GetComponent<SpriteText>();
    //		//}
    //		//if (this.m_tBack == null)
    //		//{
    //		//	this.m_tBack = this.m_tTaskPlane.transform.FindChild("Back").GetComponent<UIButton>();
    //		//}
    //		if (this.m_rImage == null)
    //		{
    //			this.m_rImage = this.m_tTaskPlane.transform.FindChild("Imageback/Image").GetComponent<MeshRenderer>();
    //		}
    //		this.AdjustPosition();
    //		base.SetParentEx(this.m_tTaskPlane);
    //		this.Disable();
    //		//KeyManager.addUIKey(KeyCode.L, new Callback(this.Key));
    //		return true;
    //	}

    //	public void AddInformation()
    //	{
    //		this.m_bTime = false;
    //		//Player player = (Player)FanrenSceneManager.RoleMan.GetRole(Player.currentPlayerId);
    //		//ModAttribute modAttribute = (ModAttribute)player.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
    //		//string text = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_CHAPTER).ToString();
    //		//if (text == "1")
    //		//{
    //		//	text = "第一章";
    //		//}
    //		//else if (text == "2")
    //		//{
    //		//	text = "第二章";
    //		//}
    //		//else if (text == "3")
    //		//{
    //		//	text = "第三章";
    //		//}
    //		//else if (text == "4")
    //		//{
    //		//	text = "第四章";
    //		//}
    //		//else if (text == "5")
    //		//{
    //		//	text = "第五章";
    //		//}
    //		//else if (text == "6")
    //		//{
    //		//	text = "第六章";
    //		//}
    //		//this.m_tTextTa.Text = text;
    //		//ModMission modMission = player.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
    //		//for (int i = 0; i < modMission.accMisList.Count; i++)
    //		//{
    //		//	ModMission.AccMisInfo accMisInfo = modMission.accMisList[i];
    //		//	if (accMisInfo == null)
    //		//	{
    //		//		Debug.LogError(new object[]
    //		//		{
    //		//			"AddItem failed : AccMisInfo Data Error."
    //		//		});
    //		//	}
    //		//	else if (accMisInfo.MisInfo.Type == MissionType.Main && !accMisInfo.Complete)
    //		//	{
    //		//		char[] array = accMisInfo.MisInfo.AimRequire.ToCharArray();
    //		//		string text2 = string.Empty;
    //		//		string text3 = string.Empty;
    //		//		for (int j = 0; j < accMisInfo.MisInfo.AimRequire.Length; j++)
    //		//		{
    //		//			if (j <= 7)
    //		//			{
    //		//				text2 += array[j];
    //		//			}
    //		//			else if (j == 17 || j == 27 || j == 37 || j == 47 || j == 57 || j == 67 || j == 77)
    //		//			{
    //		//				text3 = text3 + array[j] + "\n";
    //		//			}
    //		//			else
    //		//			{
    //		//				text3 += array[j];
    //		//			}
    //		//		}
    //		//		//this.m_tTextCha.transform.FindChild("TextC1").GetComponent<SpriteText>().Text = "        " + text2;
    //		//		//this.m_tTextCha.transform.FindChild("TextC1").transform.position = new Vector3(this.m_tTextCha.transform.FindChild("TextC1").transform.position.x, this.m_tTextCha.transform.position.y + 0.3f, this.m_tTextCha.transform.FindChild("TextC1").transform.position.z);
    //		//		//this.m_tTextCha.Text = text3;
    //		//		this.m_rImage.material.mainTexture = (Texture)ResourceLoader.Load(accMisInfo.MisInfo.PicPath, typeof(Texture));
    //		//	}
    //		//}
    //	}

    //	private void Update()
    //	{
    //		if (FanrenSceneManager.RoleMan == null)
    //		{
    //			return;
    //		}
    //		if (GameTime.time - this.m_fCreatTime > 8f && !this.m_bTime)
    //		{
    //			this.Hide();
    //			this.m_bTime = true;
    //		}
    //		//if (MovieManager.MovieMag.IsPlaying() && this.m_bMoving)
    //		//{
    //		//	this.m_bMoving = false;
    //		//	this.Hide();
    //		//}
    //	}

    //	public void AdjustPosition()
    //	{
    //		//Vector3 vector = base.Position(GUI_LAYER.UILAYER_MAIN, GUI_POS.UIPOS_RIGHT, this.m_tBack.width, this.m_tBack.height);
    //		//this.m_tTaskPlane.transform.position = new Vector3(vector.x, vector.y, vector.z);
    //	}

    //	public override void Show()
    //	{
    //        //如果已经打开 返回

    //        //if (MovieManager.MovieMag.IsPlaying()) //如果播放动画 返回
    //        //{
    //        //	return;
    //        //}

    //        //if (this.m_bKey && FantasyAssist.Instance.TimerMan.IsEvent("TaskHide"))
    //        //{
    //        //	this.m_bKey = false;
    //        //	FantasyAssist.Instance.TimerMan.RemoveEvent("TaskHide");
    //        //}
    //        this.m_bHide = false;
    //		this.m_bMoving = true;
    //		this.m_bTime = false;
    //		//if (!this.m_tTaskPlane.active && !PlayerUIManager._bIsSound)//设置音乐
    //		//{
    //		//	this.m_tTaskPlane.SetActive(true);
    //		//	EZGUIManager.SetSoundEx(5010, EZGUIManager._aQuest);
    //		//}

    //		//if (Singleton<EZGUIManager>.GetInstance().GetGUI("SystemPlane") != null)//系统面板
    //		//{
    //		//	Singleton<EZGUIManager>.GetInstance().GetGUI<SystemPlane>().ResetText(this.m_tTaskPlane.transform, 24);
    //		//}

    //		this.AdjustPosition();
    //		this.AddInformation();
    //		////this.m_taskBack.Reveal();
    //		////this.m_taskimageback.Reveal();
    //		////this.m_taskimage.Reveal();
    //		////this.m_tasktextT.Reveal();
    //		////this.m_tasktextC.Reveal();
    //		//this.m_bActive = true;
    //		//this.m_fCreatTime = GameTime.time;
    //		//FantasyAssist.Instance.TimerMan.AddDelayTimeEventEx(7f, "TaskHide", this, "Hide");
    //		//if (FantasyAssist.Instance.TimerMan.IsEvent("Task"))
    //		//{
    //		//	FantasyAssist.Instance.TimerMan.RemoveEvent("Task");
    //		//}
    //	}

    //	public void Key()
    //	{
    //		if (Time.fixedTime - this.fLastTimer <= this.fSpaceTimer)
    //		{
    //			return;
    //		}
    //		this.m_bKey = true;
    //		if (!this.m_tTaskPlane.active || !this.m_bActive)
    //		{
    //			this.Show();
    //			this.fLastTimer = Time.fixedTime;
    //			return;
    //		}
    //		this.Hide();
    //	}

    //	public override void Hide()
    //	{
    //		this.m_bHide = true;
    //		this.m_bTime = true;
    //		this.m_bActive = false;
    //		//if (this.m_tTaskPlane.active)
    //		//{
    //		//	this.m_taskBack.Hide();
    //		//	this.m_taskimage.Hide();
    //		//	this.m_taskimageback.Hide();
    //		//	this.m_tasktextT.Hide();
    //		//	this.m_tasktextC.Hide();
    //		//	FantasyAssist.Instance.TimerMan.AddDelayTimeEventEx(0.4f, "Task", this, "Disable");
    //		//}
    //	}

    //	public void Disable()
    //	{
    //		this.m_bActive = true;
    //		if (this.m_tTaskPlane != null && this.m_tTaskPlane.active)
    //		{
    //			this.m_tTaskPlane.SetActive(false);
    //		}
    //	}
}
