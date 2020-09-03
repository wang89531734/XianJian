using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class cUIFightRoleSlot
{
    //	public class SlotElement
    //	{
    //		public UIWidget Container;

    //		public GameObject BaseElement;

    //		public UISprite BaseSprite;

    //		public GameObject CDCont;

    //		public UIButton SelectButton;

    //		public UITexture PCTexture;

    //		public UITexture GwTexture;

    //		public UILabel HotKeyLabel;

    //		public UIProgressBar HPBar;

    //		public UIProgressBar MPBar;

    //		public UILabel HPLabel;

    //		public UILabel MPLabel;

    //		public UIToggle AICheckBox;

    //		public UISprite HighLightSprite;

    //		public List<UISprite> PowerSpriteList = new List<UISprite>();

    //		public List<UISprite> BuffIconList = new List<UISprite>();

    //		public UISprite CureSprite_HP;

    //		public UISpriteAnimation CureSprite_HP_Animation;

    //		public UISprite CureSprite_MP;

    //		public UISpriteAnimation CureSprite_MP_Animation;

    //		public UIToggledComponents AICheckBoxComponents;
    //	}

    //	public cUIFightRoleSlot.SlotElement m_UIElement = new cUIFightRoleSlot.SlotElement();

    //	private M_Player m_PlayerInfo;

    //	private int m_iSlotIdx = -1;

    //	private bool m_bHighLight;

    //	private int m_NowHP;

    //	private int m_NowMP;

    //	private float m_CureAnimationTime;

    //	private float m_CureAnimationTimer_HP;

    //	private float m_CureAnimationTimer_MP;

    //	public cUIFightRoleSlot(GameObject slotcontainer)
    //	{
    //		this.m_UIElement.Container = slotcontainer.GetComponent<UIWidget>();
    //		this.m_UIElement.BaseElement = slotcontainer.transform.Find("RoleElement").gameObject;
    //		this.m_UIElement.BaseSprite = this.m_UIElement.BaseElement.GetComponent<UISprite>();
    //		UIWidget childElement = nGUICustomUtil.getChildElement<UIWidget>(this.m_UIElement.BaseElement, "CooldownContainer");
    //		this.m_UIElement.CDCont = childElement.gameObject;
    //		this.m_UIElement.SelectButton = this.m_UIElement.BaseElement.GetComponent<UIButton>();
    //		this.m_UIElement.PCTexture = nGUICustomUtil.getChildElement<UITexture>(this.m_UIElement.BaseElement, "PCTexture");
    //		this.m_UIElement.GwTexture = nGUICustomUtil.getChildElement<UITexture>(this.m_UIElement.BaseElement, "GwTexture");
    //		this.m_UIElement.HotKeyLabel = nGUICustomUtil.getChildElement<UILabel>(this.m_UIElement.BaseElement, "HotKeyLabel");
    //		this.m_UIElement.HPBar = nGUICustomUtil.getChildElement<UIProgressBar>(this.m_UIElement.BaseElement, "HPBar");
    //		this.m_UIElement.MPBar = nGUICustomUtil.getChildElement<UIProgressBar>(this.m_UIElement.BaseElement, "MPBar");
    //		this.m_UIElement.HPLabel = nGUICustomUtil.getChildElement<UILabel>(this.m_UIElement.HPBar.gameObject, "HPLab");
    //		this.m_UIElement.MPLabel = nGUICustomUtil.getChildElement<UILabel>(this.m_UIElement.MPBar.gameObject, "MPLab");
    //		this.m_UIElement.AICheckBox = nGUICustomUtil.getChildElement<UIToggle>(this.m_UIElement.BaseElement, "AICheckBox");
    //		this.m_UIElement.AICheckBoxComponents = nGUICustomUtil.getChildElement<UIToggledComponents>(this.m_UIElement.BaseElement, "AICheckBox");
    //		this.m_UIElement.HighLightSprite = nGUICustomUtil.getChildElement<UISprite>(this.m_UIElement.BaseElement, "HighLightSprite");
    //		this.m_UIElement.CureSprite_HP = nGUICustomUtil.getChildElement<UISprite>(this.m_UIElement.BaseElement, "CureSprite_HP");
    //		this.m_UIElement.CureSprite_HP_Animation = nGUICustomUtil.getChildElement<UISpriteAnimation>(this.m_UIElement.BaseElement, "CureSprite_HP");
    //		this.m_UIElement.CureSprite_MP = nGUICustomUtil.getChildElement<UISprite>(this.m_UIElement.BaseElement, "CureSprite_MP");
    //		this.m_UIElement.CureSprite_MP_Animation = nGUICustomUtil.getChildElement<UISpriteAnimation>(this.m_UIElement.BaseElement, "CureSprite_MP");
    //		float num = 1f / (float)this.m_UIElement.CureSprite_HP_Animation.framesPerSecond;
    //		this.m_CureAnimationTime = num * 13f;
    //		UIWidget childElement2 = nGUICustomUtil.getChildElement<UIWidget>(this.m_UIElement.BaseElement, "PowerContainer");
    //		string gameobjectName = string.Empty;
    //		for (int i = 1; i <= 3; i++)
    //		{
    //			gameobjectName = "Sprite" + i.ToString();
    //			UISprite childElement3 = nGUICustomUtil.getChildElement<UISprite>(childElement2.gameObject, gameobjectName);
    //			if (childElement3 != null)
    //			{
    //				this.m_UIElement.PowerSpriteList.Add(childElement3);
    //			}
    //		}
    //		UIWidget childElement4 = nGUICustomUtil.getChildElement<UIWidget>(this.m_UIElement.BaseElement, "BuffContainer");
    //		UISprite childElement5 = nGUICustomUtil.getChildElement<UISprite>(childElement4.gameObject, "BuffIcon");
    //		UIEventListener uIEventListener = UIEventListener.Get(childElement5.gameObject);
    //		UIEventListener expr_340 = uIEventListener;
    //		expr_340.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_340.onTooltip, new UIEventListener.BoolDelegate(UI_Fight.Instance.OnBuffIcon_ToolTip));
    //		this.m_UIElement.BuffIconList.Clear();
    //		this.m_UIElement.BuffIconList.Add(childElement5);
    //		for (int j = 1; j < UI_Fight.Instance.MAX_SHOWBUFFICON; j++)
    //		{
    //			float x = childElement5.transform.localPosition.x + (float)(j % 5) * childElement5.localSize.x;
    //			float y = childElement5.transform.localPosition.y + (float)(j / 5) * childElement5.localSize.y;
    //			GameObject gameObject = NGUITools.AddChild(childElement4.gameObject, childElement5.gameObject);
    //			gameObject.transform.localPosition = new Vector3(x, y, 0f);
    //			UISprite component = gameObject.GetComponent<UISprite>();
    //			this.m_UIElement.BuffIconList.Add(component);
    //			uIEventListener = UIEventListener.Get(gameObject);
    //			UIEventListener expr_440 = uIEventListener;
    //			expr_440.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_440.onTooltip, new UIEventListener.BoolDelegate(UI_Fight.Instance.OnBuffIcon_ToolTip));
    //		}
    //		uIEventListener = UIEventListener.Get(this.m_UIElement.SelectButton.gameObject);
    //		UIEventListener expr_495 = uIEventListener;
    //		expr_495.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_495.onClick, new UIEventListener.VoidDelegate(this.OnSelectButton_Click));
    //		UIEventListener expr_4B8 = uIEventListener;
    //		expr_4B8.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_4B8.onHover, new UIEventListener.BoolDelegate(this.OnSlot_Hover));
    //		uIEventListener = UIEventListener.Get(this.m_UIElement.AICheckBox.gameObject);
    //		UIEventListener expr_4F2 = uIEventListener;
    //		expr_4F2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_4F2.onClick, new UIEventListener.VoidDelegate(this.OnAICheckBox_Click));
    //		this.Reset();
    //	}

    //	public void Reset()
    //	{
    //		this.m_PlayerInfo = null;
    //		this.m_bHighLight = false;
    //		this.m_NowHP = 0;
    //		this.m_NowMP = 0;
    //		for (int i = 0; i < this.m_UIElement.PowerSpriteList.Count; i++)
    //		{
    //			this.m_UIElement.PowerSpriteList[i].spriteName = "icon_fightpower_1";
    //		}
    //		for (int j = 0; j < this.m_UIElement.BuffIconList.Count; j++)
    //		{
    //			this.m_UIElement.BuffIconList[j].enabled = false;
    //		}
    //		this.m_UIElement.HighLightSprite.enabled = false;
    //		this.m_UIElement.CureSprite_HP.enabled = false;
    //		this.m_UIElement.CureSprite_MP.enabled = false;
    //		this.m_UIElement.GwTexture.enabled = false;
    //	}

    //	public void SetSlotPos(Vector3 pos)
    //	{
    //		this.m_UIElement.Container.gameObject.transform.localPosition = pos;
    //	}

    //	public Vector3 GetSlotPos()
    //	{
    //		return this.m_UIElement.Container.gameObject.transform.localPosition;
    //	}

    //	public void PlayTween()
    //	{
    //	}

    //	public void SetSlotIdx(int idx)
    //	{
    //		this.m_iSlotIdx = idx;
    //	}

    //	public int GetSlotIdx()
    //	{
    //		return this.m_iSlotIdx;
    //	}

    //	public bool IsEmpty()
    //	{
    //		return this.m_PlayerInfo == null;
    //	}

    //	public void SetRoleInfo(M_Player playerInfo)
    //	{
    //		if (playerInfo == null)
    //		{
    //			this.Reset();
    //			this.SetEnable(false);
    //			return;
    //		}
    //		this.m_PlayerInfo = playerInfo;
    //		string text = "icon_spc_";
    //		NormalSetting normalSetting = NormalSettingSystem.Instance.GetNormalSetting();
    //		if (normalSetting.m_emCharacterStyle == Enum_CharacterStyle.Enum_CharacterStyle_Real)
    //		{
    //			text += "l_0";
    //		}
    //		else
    //		{
    //			text += "h_0";
    //		}
    //		text += playerInfo.m_RoleID.ToString();
    //		this.m_UIElement.PCTexture.mainTexture = ResourceManager.Instance.GetImage(text);
    //		this.UpdateUseAICheckbox();
    //		this.SetHP(playerInfo.m_FightRoleData.HP, playerInfo.m_FightRoleData.MaxHP);
    //		this.SetMP(playerInfo.m_FightRoleData.MP, playerInfo.m_FightRoleData.MaxMP);
    //		this.UpdateBuffIcon(this.m_PlayerInfo.GetShowBuffs());
    //		this.SetEnable(true);
    //		this.m_UIElement.HotKeyLabel.text = "F" + this.m_PlayerInfo.m_RoleID;
    //		if (playerInfo.m_bIsControlCharacter)
    //		{
    //			this.EnableAICheckBox(true);
    //		}
    //		else
    //		{
    //			this.EnableAICheckBox(false);
    //		}
    //	}

    //	public void EnableAICheckBox(bool bEnable)
    //	{
    //		this.m_UIElement.AICheckBox.gameObject.SetActive(bEnable);
    //		this.UpdateUseAICheckbox();
    //	}

    //	public int GetRoleID()
    //	{
    //		if (this.m_PlayerInfo == null)
    //		{
    //			return -1;
    //		}
    //		return this.m_PlayerInfo.m_RoleID;
    //	}

    //	public void SetHotKeyStr(string strHotKey)
    //	{
    //		this.m_UIElement.HotKeyLabel.text = strHotKey;
    //	}

    //	public void SetGwTexure(ENUM_FormationActionType emType)
    //	{
    //		switch (emType)
    //		{
    //		case ENUM_FormationActionType.Leader:
    //			this.m_UIElement.GwTexture.mainTexture = ResourceManager.Instance.GetTextImage("gw_fightgroup_w2");
    //			break;
    //		case ENUM_FormationActionType.Attack:
    //			this.m_UIElement.GwTexture.mainTexture = ResourceManager.Instance.GetTextImage("gw_fightgroup_w3");
    //			break;
    //		case ENUM_FormationActionType.Defence:
    //			this.m_UIElement.GwTexture.mainTexture = ResourceManager.Instance.GetTextImage("gw_fightgroup_w1");
    //			break;
    //		case ENUM_FormationActionType.Support:
    //			this.m_UIElement.GwTexture.mainTexture = ResourceManager.Instance.GetTextImage("gw_fightgroup_w4");
    //			break;
    //		}
    //	}

    //	public void SetGwTexureEnable(bool bEnable)
    //	{
    //		this.m_UIElement.GwTexture.enabled = bEnable;
    //	}

    //	public void SetCDEnable(bool bEnabled)
    //	{
    //		this.m_UIElement.CDCont.SetActive(bEnabled);
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator WaitCureAnimationFinish_HP()
    //	{
    //		cUIFightRoleSlot.<WaitCureAnimationFinish_HP>c__Iterator8C7 <WaitCureAnimationFinish_HP>c__Iterator8C = new cUIFightRoleSlot.<WaitCureAnimationFinish_HP>c__Iterator8C7();
    //		<WaitCureAnimationFinish_HP>c__Iterator8C.<>f__this = this;
    //		return <WaitCureAnimationFinish_HP>c__Iterator8C;
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator WaitCureAnimationFinish_MP()
    //	{
    //		cUIFightRoleSlot.<WaitCureAnimationFinish_MP>c__Iterator8C8 <WaitCureAnimationFinish_MP>c__Iterator8C = new cUIFightRoleSlot.<WaitCureAnimationFinish_MP>c__Iterator8C8();
    //		<WaitCureAnimationFinish_MP>c__Iterator8C.<>f__this = this;
    //		return <WaitCureAnimationFinish_MP>c__Iterator8C;
    //	}

    //	public void HideCureAimation()
    //	{
    //		this.m_UIElement.CureSprite_HP.enabled = false;
    //		this.m_UIElement.CureSprite_MP.enabled = false;
    //	}

    //	public void PlayCureAnimation_HP()
    //	{
    //		if (!UI_Fight.Instance.IsVisible())
    //		{
    //			return;
    //		}
    //		this.m_UIElement.CureSprite_HP.enabled = true;
    //		this.m_UIElement.CureSprite_HP_Animation.Play();
    //		this.m_CureAnimationTimer_HP = this.m_CureAnimationTime;
    //		UI_Fight.Instance.StartCoroutine(this.WaitCureAnimationFinish_HP());
    //	}

    //	public void PlayCureAnimation_MP()
    //	{
    //		if (!UI_Fight.Instance.IsVisible())
    //		{
    //			return;
    //		}
    //		this.m_UIElement.CureSprite_MP.enabled = true;
    //		this.m_UIElement.CureSprite_MP_Animation.Play();
    //		this.m_CureAnimationTimer_MP = this.m_CureAnimationTime;
    //		UI_Fight.Instance.StartCoroutine(this.WaitCureAnimationFinish_MP());
    //	}

    //	private void SetHP(int nowHP, int maxHp)
    //	{
    //		this.m_NowHP = nowHP;
    //		this.m_UIElement.HPBar.value = (float)nowHP / (float)maxHp;
    //		this.m_UIElement.HPLabel.text = string.Format("{0} / {1}", nowHP, maxHp);
    //	}

    //	private void SetMP(int nowMP, int maxMp)
    //	{
    //		this.m_NowMP = nowMP;
    //		this.m_UIElement.MPBar.value = (float)nowMP / (float)maxMp;
    //		this.m_UIElement.MPLabel.text = string.Format("{0} / {1}", nowMP, maxMp);
    //	}

    //	public void UpdateHP(int nowHP, int maxHp)
    //	{
    //		if (nowHP > maxHp)
    //		{
    //			return;
    //		}
    //		if (maxHp <= 0)
    //		{
    //			UnityEngine.Debug.Log("ROLE hp setting error,maxHp <= 0");
    //			return;
    //		}
    //		if (this.m_NowHP < nowHP)
    //		{
    //			this.PlayCureAnimation_HP();
    //		}
    //		this.SetHP(nowHP, maxHp);
    //		if (this.m_PlayerInfo.IsDead())
    //		{
    //			this.m_UIElement.BaseSprite.color = new Color(0f, 0f, 0f, 0.5882353f);
    //			this.m_UIElement.PCTexture.color = new Color(1f, 0.509803951f, 0.470588237f, 1f);
    //		}
    //		else
    //		{
    //			this.m_UIElement.BaseSprite.color = new Color(1f, 1f, 1f, 1f);
    //			this.m_UIElement.PCTexture.color = new Color(1f, 1f, 1f, 1f);
    //		}
    //	}

    //	public void UpdateMP(int nowMP, int maxMp)
    //	{
    //		if (nowMP > maxMp)
    //		{
    //			nowMP = maxMp;
    //		}
    //		if (maxMp <= 0)
    //		{
    //			UnityEngine.Debug.Log("ROLE hp setting error,maxMp <= 0");
    //			return;
    //		}
    //		if (this.m_NowMP < nowMP)
    //		{
    //			this.PlayCureAnimation_MP();
    //		}
    //		this.SetMP(nowMP, maxMp);
    //	}

    //	public void UpdateUseAICheckbox()
    //	{
    //		this.m_UIElement.AICheckBox.value = this.m_PlayerInfo.m_bUseAI;
    //		for (int i = 0; i < this.m_UIElement.AICheckBoxComponents.activate.Count; i++)
    //		{
    //			this.m_UIElement.AICheckBoxComponents.activate[i].enabled = this.m_PlayerInfo.m_bUseAI;
    //		}
    //		for (int j = 0; j < this.m_UIElement.AICheckBoxComponents.deactivate.Count; j++)
    //		{
    //			this.m_UIElement.AICheckBoxComponents.deactivate[j].enabled = !this.m_PlayerInfo.m_bUseAI;
    //		}
    //	}

    //	public void SetEnable(bool bEnable)
    //	{
    //		this.m_UIElement.BaseElement.SetActive(bEnable);
    //	}

    //	public void UpdateBuffIcon(List<Buff_Base> buffs)
    //	{
    //		for (int i = 0; i < this.m_UIElement.BuffIconList.Count; i++)
    //		{
    //			if (i < buffs.Count)
    //			{
    //				nGUICustomUtil.SetSpriteAtlas(this.m_UIElement.BuffIconList[i], buffs[i].m_BuffData.IconNo);
    //				this.m_UIElement.BuffIconList[i].enabled = true;
    //				UIEventListener uIEventListener = UIEventListener.Get(this.m_UIElement.BuffIconList[i].gameObject);
    //				uIEventListener.parameter = buffs[i].m_BuffData;
    //			}
    //			else
    //			{
    //				this.m_UIElement.BuffIconList[i].enabled = false;
    //			}
    //		}
    //		this.UpdateComboSprite();
    //	}

    //	private void UpdateComboSprite()
    //	{
    //		if (this.m_PlayerInfo == null)
    //		{
    //			return;
    //		}
    //		if (this.m_PlayerInfo.m_BuffList.ContainsKey(37))
    //		{
    //			this.m_UIElement.PowerSpriteList[0].spriteName = "icon_fightpower_2";
    //			this.m_UIElement.PowerSpriteList[1].spriteName = "icon_fightpower_1";
    //			this.m_UIElement.PowerSpriteList[2].spriteName = "icon_fightpower_1";
    //		}
    //		else if (this.m_PlayerInfo.m_BuffList.ContainsKey(38))
    //		{
    //			this.m_UIElement.PowerSpriteList[0].spriteName = "icon_fightpower_2";
    //			this.m_UIElement.PowerSpriteList[1].spriteName = "icon_fightpower_2";
    //			this.m_UIElement.PowerSpriteList[2].spriteName = "icon_fightpower_1";
    //		}
    //		else if (this.m_PlayerInfo.m_BuffList.ContainsKey(39))
    //		{
    //			this.m_UIElement.PowerSpriteList[0].spriteName = "icon_fightpower_2";
    //			this.m_UIElement.PowerSpriteList[1].spriteName = "icon_fightpower_2";
    //			this.m_UIElement.PowerSpriteList[2].spriteName = "icon_fightpower_2";
    //		}
    //		else
    //		{
    //			this.m_UIElement.PowerSpriteList[0].spriteName = "icon_fightpower_1";
    //			this.m_UIElement.PowerSpriteList[1].spriteName = "icon_fightpower_1";
    //			this.m_UIElement.PowerSpriteList[2].spriteName = "icon_fightpower_1";
    //		}
    //	}

    //	public void SetHighlight(bool bHighLight)
    //	{
    //		this.m_bHighLight = bHighLight;
    //		this.m_UIElement.HighLightSprite.enabled = bHighLight;
    //	}

    //	public void OnSelectButton_Click(GameObject go)
    //	{
    //		if (Input.GetMouseButtonUp(1))
    //		{
    //			return;
    //		}
    //		UI_Fight.Instance.SelectPlayer(this.m_PlayerInfo.m_RoleID);
    //		MusicSystem.Instance.PlaySound(3, 1);
    //	}

    //	public void OnAICheckBox_Click(GameObject go)
    //	{
    //		if (Input.GetMouseButtonUp(1))
    //		{
    //			return;
    //		}
    //		UI_Fight.Instance.m_FightSceneMgr.SetRoleUseAI_UI(this.m_PlayerInfo.m_RoleID, this.m_UIElement.AICheckBox.value);
    //		MusicSystem.Instance.PlaySound(3, 1);
    //	}

    //	public void OnSlot_Hover(GameObject go, bool bHover)
    //	{
    //		if (this.m_bHighLight)
    //		{
    //			this.m_UIElement.HighLightSprite.enabled = true;
    //		}
    //		else
    //		{
    //			this.m_UIElement.HighLightSprite.enabled = bHover;
    //		}
    //		if (bHover)
    //		{
    //			MusicSystem.Instance.PlaySound(2, 1);
    //			UI_Fight.Instance.SetJoyRoleIdx(this.m_iSlotIdx);
    //			UI_Fight.Instance.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Role);
    //		}
    //		else
    //		{
    //			UI_Fight.Instance.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Null);
    //		}
    //	}
}
