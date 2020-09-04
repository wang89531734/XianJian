using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class UIFightMobSlot : UIFormBase
{
    //public class SlotElement
    //{
    //	public GameObject BaseElement;

    //	public UIButton SelectButton;

    //	public UISprite MobHeadSprite;

    //	public UISprite FocusSprite;

    //	public UISprite PropertySprite;

    //	public UIProgressBar HPBar;

    //	public UILabel HPBarLabel;

    //	public UILabel LvLabel;

    //	public UISprite LvSprite;

    //	public UILabel NameLabel;

    //	public UIButton CatchMobBtn;

    //	public GameObject CatchMobAnimation;

    //	public UITexture CatchResultTexture;

    //	public TweenAlpha CatchResultTw;

    //	public List<UISprite> BuffIconList = new List<UISprite>();
    //}

    //public cUIFightMobSlot.SlotElement m_UIElement = new cUIFightMobSlot.SlotElement();

    //private M_Mob m_MobInfo;

    private int m_Index;

    private bool m_bLook;

    private bool m_bFocus;

    //private BoxCollider m_CatchMobBtnDisableColl;

    //public UIFightMobSlot(GameObject baseElement, bool bBoss)
    //{
    //    //this.m_UIElement.BaseElement = baseElement;
    //    //this.m_UIElement.SelectButton = baseElement.GetComponent<UIButton>();
    //    //this.m_UIElement.MobHeadSprite = nGUICustomUtil.getChildElement<UISprite>(baseElement, "MobHeadSprite");
    //    //this.m_UIElement.FocusSprite = nGUICustomUtil.getChildElement<UISprite>(baseElement, "FocusSprite");
    //    //this.m_UIElement.PropertySprite = nGUICustomUtil.getChildElement<UISprite>(baseElement, "PropertySprite");
    //    //this.m_UIElement.HPBar = nGUICustomUtil.getChildElement<UIProgressBar>(baseElement, "HPBar");
    //    //this.m_UIElement.NameLabel = nGUICustomUtil.getChildElement<UILabel>(baseElement, "NameLabel");
    //    //this.m_UIElement.LvLabel = nGUICustomUtil.getChildElement<UILabel>(baseElement, "LvLabel");
    //    //this.m_UIElement.LvSprite = nGUICustomUtil.getChildElement<UISprite>(this.m_UIElement.LvLabel.gameObject, "Sprite");
    //    //this.m_UIElement.CatchMobBtn = nGUICustomUtil.getChildElement<UIButton>(baseElement, "CatchMobBtn");
    //    //this.m_UIElement.CatchMobAnimation = baseElement.transform.Find("Getmoster_sfx").gameObject;
    //    //this.m_UIElement.CatchResultTexture = nGUICustomUtil.getChildElement<UITexture>(baseElement, "CatchResultTexture");
    //    //this.m_UIElement.CatchResultTw = this.m_UIElement.CatchResultTexture.GetComponent<TweenAlpha>();
    //    //UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(this.m_UIElement.CatchMobBtn.gameObject, "Background");
    //    //NGUITools.AddWidgetCollider(childElement.gameObject);
    //    //this.m_CatchMobBtnDisableColl = childElement.GetComponent<BoxCollider>();
    //    //UIEventListener uIEventListener = UIEventListener.Get(childElement.gameObject);
    //    //if (uIEventListener != null)
    //    //{
    //    //    UIEventListener expr_189 = uIEventListener;
    //    //    expr_189.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_189.onClick, new UIEventListener.VoidDelegate(UI_Fight.Instance.OnBtn_ErrorClick));
    //    //}
    //    //if (bBoss)
    //    //{
    //    //    this.m_UIElement.HPBarLabel = nGUICustomUtil.getChildElement<UILabel>(this.m_UIElement.HPBar.gameObject, "HPLab");
    //    //}
    //    //this.m_UIElement.BuffIconList.Clear();
    //    //UIWidget childElement2 = nGUICustomUtil.getChildElement<UIWidget>(baseElement, "BuffContainer");
    //    //UISprite childElement3 = nGUICustomUtil.getChildElement<UISprite>(childElement2.gameObject, "BuffIcon");
    //    //uIEventListener = UIEventListener.Get(childElement3.gameObject);
    //    //UIEventListener expr_213 = uIEventListener;
    //    //expr_213.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_213.onTooltip, new UIEventListener.BoolDelegate(UI_Fight.Instance.OnBuffIcon_ToolTip));
    //    //this.m_UIElement.BuffIconList.Add(childElement3);
    //    //for (int i = 1; i < 10; i++)
    //    //{
    //    //    float x = childElement3.transform.localPosition.x - (float)i * childElement3.localSize.x;
    //    //    GameObject gameObject = NGUITools.AddChild(childElement2.gameObject, childElement3.gameObject);
    //    //    gameObject.transform.localPosition = new Vector3(x, 0f, 0f);
    //    //    UISprite component = gameObject.GetComponent<UISprite>();
    //    //    this.m_UIElement.BuffIconList.Add(component);
    //    //    uIEventListener = UIEventListener.Get(gameObject);
    //    //    UIEventListener expr_2CF = uIEventListener;
    //    //    expr_2CF.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_2CF.onTooltip, new UIEventListener.BoolDelegate(UI_Fight.Instance.OnBuffIcon_ToolTip));
    //    //    component.enabled = false;
    //    //}
    //    //childElement3.enabled = false;
    //    //this.Reset();
    //    //uIEventListener = UIEventListener.Get(this.m_UIElement.SelectButton.gameObject);
    //    //if (uIEventListener != null)
    //    //{
    //    //    UIEventListener expr_33B = uIEventListener;
    //    //    expr_33B.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_33B.onHover, new UIEventListener.BoolDelegate(this.OnSelectBtn_Hover));
    //    //    UIEventListener expr_35D = uIEventListener;
    //    //    expr_35D.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_35D.onClick, new UIEventListener.VoidDelegate(this.OnSelectBtn_Click));
    //    //}
    //    //uIEventListener = UIEventListener.Get(this.m_UIElement.CatchMobBtn.gameObject);
    //    //if (uIEventListener != null)
    //    //{
    //    //    UIEventListener expr_3A1 = uIEventListener;
    //    //    expr_3A1.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_3A1.onClick, new UIEventListener.VoidDelegate(this.OnCatchMobBtn_Click));
    //    //}
    //    //this.m_UIElement.CatchResultTexture.mainTexture = ResourceManager.Instance.GetImage("g_damage_getfail");
    //    //this.m_UIElement.CatchResultTexture.gameObject.SetActive(false);
    //}

    //public void Reset()
    //{
    //	this.m_MobInfo = null;
    //	this.m_UIElement.FocusSprite.enabled = false;
    //	this.m_UIElement.CatchMobBtn.gameObject.SetActive(false);
    //	this.m_UIElement.CatchResultTexture.gameObject.SetActive(false);
    //	this.SetFocus(false);
    //	this.SetLookThrough(false);
    //	this.SetBeCaught(false);
    //	for (int i = 0; i < this.m_UIElement.BuffIconList.Count; i++)
    //	{
    //		this.m_UIElement.BuffIconList[i].enabled = false;
    //	}
    //}

    //public M_Mob GetMobInfo()
    //{
    //	return this.m_MobInfo;
    //}

    //public bool IsEmpty()
    //{
    //	return this.m_MobInfo == null;
    //}

    //public int GetIndex()
    //{
    //	return this.m_Index;
    //}

    //public int GetMobKeyID()
    //{
    //	if (this.m_MobInfo == null)
    //	{
    //		return -1;
    //	}
    //	return this.m_MobInfo.m_MobSerialID;
    //}

    //public bool IsDead()
    //{
    //	if (this.m_MobInfo == null)
    //	{
    //		Debug.Log("m_MobInfo == null");
    //		return false;
    //	}
    //	return this.m_MobInfo.IsDead();
    //}

    //public bool IsEnabled()
    //{
    //	return this.m_UIElement.BaseElement.activeSelf;
    //}

    public void SetEnable(bool bEnable)
    {
        //this.m_UIElement.BaseElement.SetActive(bEnable);
        //if (!bEnable)
        //{
        //    this.m_UIElement.FocusSprite.enabled = false;
        //}
    }

    public void SetSlotIndex(int index)
    {
        this.m_Index = index;
    }

    //public void SetBeCaught(bool bCaught)
    //{
    //	this.m_UIElement.CatchMobAnimation.SetActive(bCaught);
    //}

    //public void SetFocus(bool bFocus)
    //{
    //	this.m_bFocus = bFocus;
    //	this.m_UIElement.FocusSprite.enabled = bFocus;
    //}

    //public void SetCatchBtnEnable(bool bEnable)
    //{
    //	if (!this.m_UIElement.CatchMobAnimation.activeSelf)
    //	{
    //		this.m_UIElement.CatchMobBtn.isEnabled = bEnable;
    //	}
    //	else
    //	{
    //		this.m_UIElement.CatchMobBtn.isEnabled = true;
    //	}
    //	this.m_CatchMobBtnDisableColl.enabled = !this.m_UIElement.CatchMobBtn.isEnabled;
    //}

    //public void SetCatchFail()
    //{
    //	if (!this.m_UIElement.CatchMobAnimation.activeSelf)
    //	{
    //		return;
    //	}
    //	if (this.m_UIElement.CatchResultTw != null)
    //	{
    //		this.m_UIElement.CatchResultTw.ResetToBeginning();
    //		this.m_UIElement.CatchResultTw.PlayForward();
    //	}
    //	this.m_UIElement.CatchResultTexture.gameObject.SetActive(true);
    //}

    //public void SetSlotInfo(M_Mob mob)
    //{
    //	if (mob == null)
    //	{
    //		this.SetEnable(false);
    //		return;
    //	}
    //	this.Reset();
    //	this.m_MobInfo = mob;
    //	this.SetEnable(true);
    //	this.m_UIElement.NameLabel.text = this.m_MobInfo.m_CharacterName;
    //	this.m_UIElement.LvLabel.text = this.m_MobInfo.m_MobData.Level.ToString();
    //	nGUICustomUtil.SetSpriteAtlas(this.m_UIElement.MobHeadSprite, this.m_MobInfo.m_IconNo);
    //	if (this.m_MobInfo.GetMobDefElementType() != ENUM_ElementType.Null && this.m_MobInfo.GetMobDefElementType() != ENUM_ElementType.Physical)
    //	{
    //		int id = (int)(169 + this.m_MobInfo.GetMobDefElementType());
    //		nGUICustomUtil.SetSpriteAtlas(this.m_UIElement.PropertySprite, id);
    //	}
    //	this.UpdateHP();
    //	this.UpdateBuffIcon();
    //	if (Swd6Application.instance.m_GameDataSystem.GetFlag(28))
    //	{
    //		this.m_UIElement.CatchMobBtn.gameObject.SetActive(this.m_MobInfo.m_MobData.CanCatch == 1);
    //	}
    //	else
    //	{
    //		this.m_UIElement.CatchMobBtn.gameObject.SetActive(false);
    //	}
    //	this.SetBeCaught(mob.GetBeCatchState());
    //}

    //public void SetLookThrough(bool bLook)
    //{
    //	if (this.m_MobInfo != null)
    //	{
    //		if (this.m_MobInfo.GetMobDefElementType() != ENUM_ElementType.Null && this.m_MobInfo.GetMobDefElementType() != ENUM_ElementType.Physical)
    //		{
    //			int id = (int)(169 + this.m_MobInfo.GetMobDefElementType());
    //			nGUICustomUtil.SetSpriteAtlas(this.m_UIElement.PropertySprite, id);
    //			this.m_UIElement.PropertySprite.enabled = bLook;
    //		}
    //		else
    //		{
    //			this.m_UIElement.PropertySprite.enabled = false;
    //		}
    //	}
    //	else
    //	{
    //		this.m_UIElement.PropertySprite.enabled = false;
    //	}
    //	this.m_UIElement.LvLabel.enabled = bLook;
    //	this.m_UIElement.LvSprite.enabled = bLook;
    //	this.m_bLook = bLook;
    //	if (this.m_UIElement.HPBarLabel != null)
    //	{
    //		this.m_UIElement.HPBarLabel.enabled = bLook;
    //	}
    //	else if (this.m_MobInfo != null)
    //	{
    //		if (bLook)
    //		{
    //			this.m_UIElement.NameLabel.text = this.m_MobInfo.m_FightRoleData.HP.ToString();
    //		}
    //		else
    //		{
    //			this.m_UIElement.NameLabel.text = this.m_MobInfo.m_CharacterName;
    //		}
    //	}
    //}

    //public void UpdateHP()
    //{
    //	if (this.m_MobInfo == null)
    //	{
    //		return;
    //	}
    //	int hP = this.m_MobInfo.m_FightRoleData.HP;
    //	int maxHP = this.m_MobInfo.m_FightRoleData.MaxHP;
    //	float value = (float)hP / (float)maxHP;
    //	if (this.m_UIElement.HPBarLabel != null)
    //	{
    //		this.m_UIElement.HPBarLabel.text = hP.ToString() + "/" + maxHP.ToString();
    //	}
    //	else if (this.m_bLook)
    //	{
    //		this.m_UIElement.NameLabel.text = hP.ToString();
    //	}
    //	else
    //	{
    //		this.m_UIElement.NameLabel.text = this.m_MobInfo.m_CharacterName;
    //	}
    //	this.m_UIElement.HPBar.value = value;
    //}

    //public void UpdateBuffIcon()
    //{
    //	if (this.m_MobInfo == null)
    //	{
    //		return;
    //	}
    //	List<Buff_Base> showBuffs = this.m_MobInfo.GetShowBuffs();
    //	for (int i = 0; i < this.m_UIElement.BuffIconList.Count; i++)
    //	{
    //		if (i < showBuffs.Count)
    //		{
    //			nGUICustomUtil.SetSpriteAtlas(this.m_UIElement.BuffIconList[i], showBuffs[i].m_BuffData.IconNo);
    //			this.m_UIElement.BuffIconList[i].enabled = true;
    //			UIEventListener uIEventListener = UIEventListener.Get(this.m_UIElement.BuffIconList[i].gameObject);
    //			uIEventListener.parameter = showBuffs[i].m_BuffData;
    //		}
    //		else
    //		{
    //			this.m_UIElement.BuffIconList[i].enabled = false;
    //		}
    //	}
    //	if (this.m_MobInfo.m_BuffList.ContainsKey(88))
    //	{
    //		this.SetLookThrough(true);
    //	}
    //	else
    //	{
    //		this.SetLookThrough(false);
    //	}
    //}

    //public void OnSelectBtn_Hover(GameObject go, bool bState)
    //{
    //	if (bState)
    //	{
    //		UI_Fight.Instance.SetKeyboardInputIdx(this.m_Index);
    //		MusicSystem.Instance.PlaySound(2, 1);
    //	}
    //	else
    //	{
    //		UI_Fight.Instance.SetKeyboardInputIdx(-1);
    //	}
    //}

    //public void OnSelectBtn_Click(GameObject go)
    //{
    //	if (Input.GetMouseButtonUp(1))
    //	{
    //		return;
    //	}
    //	UI_Fight.Instance.ChangeTargetMob(this.m_MobInfo.m_MobSerialID);
    //	MusicSystem.Instance.PlaySound(3, 1);
    //}

    //public void OnCatchMobBtn_Click(GameObject go)
    //{
    //	if (Input.GetMouseButtonUp(1))
    //	{
    //		return;
    //	}
    //	if (!this.m_UIElement.CatchMobBtn.gameObject.activeSelf)
    //	{
    //		return;
    //	}
    //	if (!this.m_UIElement.CatchMobBtn.isEnabled)
    //	{
    //		return;
    //	}
    //	UI_Fight.Instance.CatchMob(this.m_MobInfo.m_MobSerialID);
    //	MusicSystem.Instance.PlaySound(3, 1);
    //}
}
