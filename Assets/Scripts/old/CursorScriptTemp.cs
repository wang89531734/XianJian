using SoftStar.Pal6;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CursorScriptTemp : MonoBehaviour
{
	public delegate void FunHander();

	private CursorScriptTemp.FunHander funh;

	public static CursorScriptTemp.FunHander CursorShow;

	//protected SelfExtern.Int_2 LastCursorPos;

	public Texture2D NormalCursorTex;

	//public List<CursorTexItem> CursorTexList = new List<CursorTexItem>();

	[HideInInspector]
	public List<Texture2D> GrabCursorTex = new List<Texture2D>();

	[HideInInspector]
	public Texture2D tempNormalTex;

	//public Dictionary<CursorTextureState, CursorTexItem> tempTypeDic = new Dictionary<CursorTextureState, CursorTexItem>();

	//public CursorState curState;

	//private CursorState lastState = CursorState.None;

	private Vector2 curAim = new Vector2(0f, 0f);

	public float flashInterval = 0.2f;

	private float tempTime;

	private int tempIndex;

	private int indexDir = 1;

	private static CursorScriptTemp instance;

	public bool hideCursorButtonDown = true;

	private bool canDrag;

	public float followCursorTime = 0.7f;

	public static CursorScriptTemp Instance
	{
		get
		{
			if (CursorScriptTemp.instance == null && PalMain.Instance != null)
			{
				CursorScriptTemp.instance = PalMain.Instance.gameObject.GetComponent<CursorScriptTemp>();
			}
			return CursorScriptTemp.instance;
		}
	}

	//public void SetLastCursorPos(SelfExtern.Int_2 v)
	//{
	//	this.LastCursorPos = v;
	//}

	private void Start()
	{
		CursorScriptTemp.instance = this;
		//GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.InitGameNormal));
		//GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.EndGameNormal));
		//GameStateManager.AddInitStateFun(GameState.Battle, new GameStateManager.void_fun(this.InitBattle));
		//GameStateManager.AddEndStateFun(GameState.Battle, new GameStateManager.void_fun(this.EndBattle));
		//GameStateManager.AddInitStateFun(GameState.Cutscene, new GameStateManager.void_fun(this.InitCutscene));
		//GameStateManager.AddEndStateFun(GameState.Cutscene, new GameStateManager.void_fun(this.EndCutscene));
		this.tempNormalTex = this.NormalCursorTex;
		//for (int i = 0; i < this.CursorTexList.Count; i++)
		//{
		//	if (!this.tempTypeDic.ContainsKey(this.CursorTexList[i].type))
		//	{
		//		this.tempTypeDic.Add(this.CursorTexList[i].type, this.CursorTexList[i]);
		//	}
		//}
	}

	private void OnDestroy()
	{
		CursorScriptTemp.instance = null;
	}

	private void InitCutscene()
	{
		this.HideCursor();
		base.enabled = false;
	}

	private void EndCutscene()
	{
		base.enabled = true;
	}

	private void InitBattle()
	{
		//this.CursorTexToState(CursorTextureState.Battle, -1f);
		this.ShowCursor();
		base.enabled = false;
	}

	private void EndBattle()
	{
		base.enabled = true;
	}

	private void InitGameNormal()
	{
		this.CursorTexToNormal();
		CursorScriptTemp.CursorShow = new CursorScriptTemp.FunHander(this.ProcessCursorShow);
	}

	private void EndGameNormal()
	{
		//if (GameStateManager.NextGameState != GameState.SmallGame)
		//{
		//	this.CursorTexToNormal();
		//}
		CursorScriptTemp.CursorShow = null;
		Cursor.visible = true;
	}

	private void Update()
	{
		this.ProcessCursorChange();
		if (CursorScriptTemp.CursorShow != null)
		{
			CursorScriptTemp.CursorShow();
		}
	}

	private void ProcessCursorChange()
	{
		//if (this.lastState != this.curState)
		//{
		//	CursorState cursorState = this.curState;
		//	if (cursorState != CursorState.Normal)
		//	{
		//		if (cursorState == CursorState.Grab)
		//		{
		//			this.funh = new CursorScriptTemp.FunHander(this.Grab);
		//		}
		//	}
		//	else
		//	{
		//		this.funh = new CursorScriptTemp.FunHander(this.Normal);
		//	}
		//	this.lastState = this.curState;
		//}
		if (this.funh != null)
		{
			this.funh();
		}
	}

	public void ProcessCursorShow()
	{
		bool flag = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
		bool flag2 = Input.GetMouseButton(0) || Input.GetMouseButton(1);
		if (flag && this.hideCursorButtonDown)
		{
			this.HideCursor();
		}
		else if (!flag2 && !Cursor.visible)
		{
			//if (!(PalMain.Instance != null) || !PalMain.Instance.GetDualCam())
			//{
			//	this.ShowCursor();
			//}
		}
		if (flag2 && !this.canDrag && this.hideCursorButtonDown)
		{
			//SelfExtern.SetCursorPos(this.LastCursorPos.x, this.LastCursorPos.y);
		}
	}

	public void ShowCursor()
	{
		Cursor.visible = true;
		//if (UICamera.hoveredObject == null)
		//{
		//	SelfExtern.SetCursorPos(this.LastCursorPos.x, this.LastCursorPos.y);
		//	this.canDrag = false;
		//}
		//else
		//{
		//	this.canDrag = true;
		//}
	}

	public void HideCursor()
	{
		//SelfExtern.GetCursorPos(out this.LastCursorPos);
		//if (UICamera.hoveredObject == null)
		//{
		//	Cursor.visible = false;
		//	this.canDrag = false;
		//}
		//else
		//{
		//	this.canDrag = true;
		//}
	}

	private void Normal()
	{
		Cursor.SetCursor(this.tempNormalTex, this.curAim, CursorMode.Auto);
	}

	private void Grab()
	{
		this.tempTime += Time.deltaTime;
		if (this.tempTime > this.flashInterval)
		{
			this.tempTime = 0f;
			this.tempIndex++;
			if (this.tempIndex >= this.GrabCursorTex.Count)
			{
				this.tempIndex = 0;
			}
			Cursor.SetCursor(this.GrabCursorTex[this.tempIndex], this.curAim, CursorMode.Auto);
		}
	}

	public void CursorTexToNormal()
	{
		CursorScriptTemp.Instance.tempNormalTex = CursorScriptTemp.Instance.NormalCursorTex;
		//CursorScriptTemp.Instance.curState = CursorState.Normal;
		this.ProcessCursorChange();
	}

	//public void CursorTexToState(CursorTextureState state, float dis = -1f)
	//{
	//	if (this.tempTypeDic.ContainsKey(state))
	//	{
	//		CursorTexItem cursorTexItem = this.tempTypeDic[state];
	//		if (cursorTexItem.dis < 0f || cursorTexItem.dis > dis)
	//		{
	//			if (cursorTexItem.TexList.Count > 1)
	//			{
	//				CursorScriptTemp.Instance.GrabCursorTex = cursorTexItem.TexList;
	//				CursorScriptTemp.Instance.curState = CursorState.Grab;
	//			}
	//			else if (cursorTexItem.TexList.Count == 1)
	//			{
	//				CursorScriptTemp.Instance.tempNormalTex = cursorTexItem.TexList[0];
	//				CursorScriptTemp.Instance.curState = CursorState.Normal;
	//			}
	//			this.ProcessCursorChange();
	//		}
	//	}
	//}
}
