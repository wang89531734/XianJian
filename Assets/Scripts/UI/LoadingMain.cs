using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001D9 RID: 473
public class LoadingMain 
{
    //    public static bool loadingIsShow;

    //   //private static UIStateToggleBtn u_LoadingTex;

    //    // Token: 0x04000AC1 RID: 2753
    //    private static GameObject u_LoadingMap;

    //    // Token: 0x04000AC2 RID: 2754
    //    private static Callback callBack;

    //    // Token: 0x04000AC3 RID: 2755
    //    private GameObject u_BloodLoading;

    //    // Token: 0x04000AC4 RID: 2756
    //    //public SpriteText _tGame;

    //    //// Token: 0x04000AC5 RID: 2757
    //    //public static SpriteText _tLoad;

    //    //// Token: 0x04000AC6 RID: 2758
    //    //public static SpriteText _tTab;

    //    public override bool Init()
    //	{
    //		//UIStateToggleBtn.CreationTime = Time.time;
    //		//UnityEngine.Object original = ResourceLoader.Load("EZGUI/Loading", typeof(GameObject));
    //		//LoadingMain.u_LoadingMap = (UnityEngine.Object.Instantiate(original, new Vector3(0f, 122.8469f, 2f), Quaternion.identity) as GameObject);
    //		//GUIControl.SetChildrenLevel(LoadingMain.u_LoadingMap.transform, 10);
    //		////LoadingMain.u_LoadingTex = LoadingMain.u_LoadingMap.transform.FindChild("LoadingTex").GetComponent<UIStateToggleBtn>();
    //		//this.u_BloodLoading = LoadingMain.u_LoadingMap.transform.FindChild("MainPanel/LoadingBar").gameObject;
    //		////this._tGame = LoadingMain.u_LoadingMap.transform.FindChild("Game").GetComponent<SpriteText>();
    //		////LoadingMain._tLoad = LoadingMain.u_LoadingMap.transform.FindChild("Load").GetComponent<SpriteText>();
    //		////LoadingMain._tTab = LoadingMain.u_LoadingMap.transform.FindChild("Tab").GetComponent<SpriteText>();
    //		////UIStateToggleBtn.CreationTime = Time.time;
    //		//base.SetParentEx(LoadingMain.u_LoadingMap);
    //		////this.AdjustPos();
    //		//LoadingMain.u_LoadingMap.gameObject.SetActive(false);
    //		return true;
    //	}

    //	// Token: 0x06000B0E RID: 2830 RVA: 0x0004F2F0 File Offset: 0x0004D4F0
    //	private void Awake()
    //	{

    //	}

    //	// Token: 0x06000B0F RID: 2831 RVA: 0x0004F2FC File Offset: 0x0004D4FC
    //	public static void Show(Callback callbackFun)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Show();
    //		if (callbackFun != null)
    //		{
    //			LoadingMain.callBack = callbackFun;
    //		}
    //	}

    //	//// Token: 0x06000B10 RID: 2832 RVA: 0x0004F31C File Offset: 0x0004D51C
    //	//public void AdjustPos()
    //	//{
    //	//	this._tGame.transform.position = base.Position(GUI_LAYER.UILAYER_LOADING, GUI_POS.UIPOS_LEFT, 0.6f * (float)this._tGame.Text.Length, 0.6f);
    //	//	this._tGame.transform.position = new Vector3(this._tGame.transform.position.x + 0.5f, this._tGame.transform.position.y + 6.5f, this._tGame.transform.position.z);
    //	//	LoadingMain._tTab.transform.position = base.Position(GUI_LAYER.UILAYER_LOADING, GUI_POS.UIPOS_LEFT, 0.6f * (float)this._tGame.Text.Length, 0.6f);
    //	//	LoadingMain._tTab.transform.position = new Vector3(LoadingMain._tTab.transform.position.x + 0.5f, LoadingMain._tTab.transform.position.y + 5f, LoadingMain._tTab.transform.position.z);
    //	//	LoadingMain._tLoad.transform.position = base.Position(GUI_LAYER.UILAYER_LOADING, GUI_POS.UIPOS_RIGHT, 0.6f * (float)LoadingMain._tLoad.Text.Length, 0.6f);
    //	//	LoadingMain._tLoad.transform.position = new Vector3(LoadingMain._tLoad.transform.position.x - 2f, LoadingMain._tLoad.transform.position.y - 7f, LoadingMain._tLoad.transform.position.z);
    //	//	LoadingMain.u_LoadingTex.transform.position = new Vector3(LoadingMain._tLoad.transform.position.x + 0.6f * LoadingMain._tLoad.lineSpacing, LoadingMain._tLoad.transform.position.y, LoadingMain._tLoad.transform.position.z + 3f);
    //	//	if (this._tGame.transform.parent.FindChild("Line") != null)
    //	//	{
    //	//		this._tGame.transform.parent.FindChild("Line").position = new Vector3(this._tGame.transform.position.x + 3f, this._tGame.transform.position.y - 1.1f, this._tGame.transform.position.z);
    //	//	}
    //	//}

    //	//// Token: 0x06000B11 RID: 2833 RVA: 0x0004F610 File Offset: 0x0004D810
    //	//public override void Show()
    //	//{
    //	//	MouseManager.ShowCursor(false);
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane") != null)
    //	//	{
    //	//		Singleton<EZGUIManager>.GetInstance().GetGUI<LandPlane>().Hide();
    //	//	}
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("EquipPlane") != null)
    //	//	{
    //	//		Singleton<EZGUIManager>.GetInstance().GetGUI<EquipPlane>().Hide();
    //	//	}
    //	//	SingletonMono<AudioManager>.GetInstance().PauseAll(true);
    //	//	LoadingMain.callBack = null;
    //	//	LoadingMain.loadingIsShow = true;
    //	//	if (LoadingMain.u_LoadingMap != null)
    //	//	{
    //	//		LoadingMain.u_LoadingMap.gameObject.SetActive(true);
    //	//	}
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("SystemPlane") != null)
    //	//	{
    //	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SystemPlane>().ResetText(LoadingMain.u_LoadingMap.transform, 25);
    //	//	}
    //	//	if (SceneManager.scenenInfo.name == "Start")
    //	//	{
    //	//		LoadingMain._tTab.Text = "探索会为你带来意想不到的惊喜。";
    //	//		this._tGame.Text = "游戏提示";
    //	//	}
    //	//	else
    //	//	{
    //	//		int nType = UnityEngine.Random.Range(1, GameData.Instance.LoadInfo.LoadInfoList.Count);
    //	//		LoadingInfo loadByType = GameData.Instance.LoadInfo.GetLoadByType(nType);
    //	//		this._tGame.SetCamera();
    //	//		this._tGame.Text = "游戏提示";
    //	//		LoadingMain._tTab.SetCamera();
    //	//		LoadingMain._tTab.Text = loadByType._str;
    //	//	}
    //	//	this.AdjustPos();
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("BigMap") != null)
    //	//	{
    //	//		Singleton<EZGUIManager>.GetInstance().GetGUI("BigMap").Hide();
    //	//	}
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("TaskTrackPlane") != null)
    //	//	{
    //	//		Singleton<EZGUIManager>.GetInstance().GetGUI<TaskTrackPlane>().Disable();
    //	//	}
    //	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("HelpPlane") != null)
    //	//	{
    //	//		if (Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.activeSelf)
    //	//		{
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.gameObject.SetActive(false);
    //	//		}
    //	//		if (Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.activeSelf)
    //	//		{
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.gameObject.SetActive(false);
    //	//		}
    //	//	}
    //	//}

    //	//// Token: 0x06000B12 RID: 2834 RVA: 0x0004F85C File Offset: 0x0004DA5C
    //	//public override void Hide()
    //	//{
    //	//	if (LoadingMain.u_LoadingMap.activeSelf)
    //	//	{
    //	//		SingletonMono<AudioManager>.GetInstance().PauseAll(false);
    //	//	}
    //	//	LoadingMain.loadingIsShow = false;
    //	//	if (LoadingMain.callBack != null)
    //	//	{
    //	//		LoadingMain.callBack();
    //	//		LoadingMain.callBack = null;
    //	//	}
    //	//	LoadingMain.u_LoadingMap.gameObject.SetActive(false);
    //	//	KeyManager.hotKeyEnabled = true;
    //	//	if (Application.loadedLevelName == "map0011")
    //	//	{
    //	//		GameData.Instance.ScrMan.Exec(44, 1001103);
    //	//		if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001103) && Player.Instance._helpBase.m_HelpGroup[1001103].finished)
    //	//		{
    //	//			GameData.Instance.ScrMan.Exec(44, 1001104);
    //	//		}
    //	//		if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001104) && Player.Instance._helpBase.m_HelpGroup[1001104].finished)
    //	//		{
    //	//			GameData.Instance.ScrMan.Exec(44, 1001105);
    //	//		}
    //	//	}
    //	//	if (SceneManager.scenenInfo.mapName == "黄枫谷" || Application.loadedLevelName == "map0010")
    //	//	{
    //	//		GameData.Instance.ScrMan.Exec(44, 1000015);
    //	//	}
    //	//	Player instance = Player.Instance;
    //	//	if (instance != null)
    //	//	{
    //	//		FigureSkillData.Data figureSkillData = Singleton<FigureSkillData>.GetInstance().GetFigureSkillData(instance.SystemFigure.SkillID);
    //	//		if (figureSkillData != null)
    //	//		{
    //	//			Texture2D mainTexture = ResourceLoader.Load(figureSkillData.IconPath, typeof(Texture2D)) as Texture2D;
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/head").GetComponent<MeshRenderer>().material.mainTexture = mainTexture;
    //	//		}
    //	//		else
    //	//		{
    //	//			Texture2D mainTexture2 = ResourceLoader.Load("GameLegend/Icon/Item/lock", typeof(Texture2D)) as Texture2D;
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/head").GetComponent<MeshRenderer>().material.mainTexture = mainTexture2;
    //	//		}
    //	//		if (Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_1 != null && Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2 != null && Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3 != null && Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4 != null)
    //	//		{
    //	//			Texture2D mainTexture3 = ResourceLoader.Load("GameLegend/Icon/Item/lock", typeof(Texture2D)) as Texture2D;
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2.material.mainTexture = mainTexture3;
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3.material.mainTexture = mainTexture3;
    //	//			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4.material.mainTexture = mainTexture3;
    //	//			ModSkillProperty modSkillProperty = SceneManager.RoleMan.GetRole(1).GetModule(MODULE_TYPE.MT_SKILL) as ModSkillProperty;
    //	//			SSkillCoolTime[] m_cSkills = modSkillProperty.M_cSkills;
    //	//			List<int> list = new List<int>();
    //	//			for (int i = 0; i < 4; i++)
    //	//			{
    //	//				if (m_cSkills[i] != null)
    //	//				{
    //	//					list.Add(m_cSkills[i].ID);
    //	//				}
    //	//			}
    //	//			int[] array = list.ToArray();
    //	//			for (int j = 0; j < Singleton<EZGUIManager>.GetInstance().GetGUI<GUIPlayerSkill>().m_arrSkillDes.Length; j++)
    //	//			{
    //	//				for (int k = Singleton<EZGUIManager>.GetInstance().GetGUI<GUIPlayerSkill>().m_arrSkillDes[j].Length; k >= 0; k--)
    //	//				{
    //	//					UIButton uibutton = Singleton<EZGUIManager>.GetInstance().GetGUI<GUIPlayerSkill>().leftIconBox.GetUIbutton(j, k);
    //	//					if (uibutton != null)
    //	//					{
    //	//						for (int l = 0; l < array.Length; l++)
    //	//						{
    //	//							if (array[l] == Singleton<EZGUIManager>.GetInstance().GetGUI<GUIPlayerSkill>().m_arrSkillDes[j][k].id)
    //	//							{
    //	//								if (j == 0)
    //	//								{
    //	//									Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_1.material.mainTexture = uibutton.transform.GetComponent<MeshRenderer>().material.mainTexture;
    //	//								}
    //	//								if (j == 1)
    //	//								{
    //	//									Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2.material.mainTexture = uibutton.transform.GetComponent<MeshRenderer>().material.mainTexture;
    //	//								}
    //	//								if (j == 2)
    //	//								{
    //	//									Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3.material.mainTexture = uibutton.transform.GetComponent<MeshRenderer>().material.mainTexture;
    //	//								}
    //	//								if (j == 3)
    //	//								{
    //	//									Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4.material.mainTexture = uibutton.transform.GetComponent<MeshRenderer>().material.mainTexture;
    //	//								}
    //	//							}
    //	//						}
    //	//					}
    //	//				}
    //	//			}
    //	//		}
    //	//	}
    //	//}
}
