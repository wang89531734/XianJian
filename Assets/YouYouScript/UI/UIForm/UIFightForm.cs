using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 战斗面板
/// </summary>
public class UIFightForm : UIFormBase
{
    public enum ENUM_FightInputLevel
    {
        Null = -1,
        Formation,
        MagicItem,
        Skill,
        Item,
        Role,
        Mob
    }

    //    private struct S_UIFightCommand
    //    {
    //        public int id;

    //        public bool bSkill;
    //    }

    //    private enum ENUM_MenuState
    //    {
    //        Null = -1,
    //        UseSkillTarget,
    //        UseItemTarget
    //    }

    //    [SerializeField]
    //    private GameObject m_FormationCont;

    //    [SerializeField]
    //    private List<UIButton> m_FormationBtnList;

    //    [SerializeField]
    //    private List<UILabel> m_FormationHotKeyLabList;

    //    [SerializeField]
    //    private UIButton m_FormationMiddleBtn;

    //    [SerializeField]
    //    private UISprite m_FormationMiddleSprite;

    //    [SerializeField]
    //    private UITexture m_FormationMiddleTexture;

    //    [SerializeField]
    //    private TweenColor m_twFormationMiddle;

    //    private Dictionary<UIButton, UISprite> m_FormationBtnIconTable = new Dictionary<UIButton, UISprite>();

    //    [SerializeField]
    //    private List<UIButton> m_SkillBtnList;

    //    [SerializeField]
    //    private UIButton m_SkillPageUpBtn;

    //    [SerializeField]
    //    private UIButton m_SkillPageDownBtn;

    //    [SerializeField]
    //    private UILabel m_SkillPageLabel;

    //    private Dictionary<UIButton, int> m_SkillBtnIDTable = new Dictionary<UIButton, int>();

    //    private Dictionary<UIButton, UISprite> m_SkillBtnIconTable = new Dictionary<UIButton, UISprite>();

    //    private List<UISprite> m_SkillColddownSpriteList = new List<UISprite>();

    //    private List<UISprite> m_SkillBtnIconList = new List<UISprite>();

    //    [SerializeField]
    //    private List<UIButton> m_ItemBtnList;

    //    [SerializeField]
    //    private UIButton m_ItemPageUpBtn;

    //    [SerializeField]
    //    private UIButton m_ItemPageDownBtn;

    //    [SerializeField]
    //    private UILabel m_ItemPageLabel;

    //    private Dictionary<UIButton, int> m_ItemBtnIDTable = new Dictionary<UIButton, int>();

    //    private Dictionary<UIButton, UISprite> m_ItemBtnIconTable = new Dictionary<UIButton, UISprite>();

    //    private Dictionary<UIButton, UILabel> m_ItemBtnCountTable = new Dictionary<UIButton, UILabel>();

    //    private List<UISprite> m_ItemColddownSpriteList = new List<UISprite>();

    //    private List<UISprite> m_ItemBtnIconList = new List<UISprite>();

    //    [SerializeField]
    //    private GameObject m_MagicItemCont;

    //    [SerializeField]
    //    private UIButton m_MagicItemBtn;

    //    [SerializeField]
    //    private BoxCollider m_MagicItemSpriteCol;

    //    [SerializeField]
    //    private UIButton m_EscapeBtn;

    //    [SerializeField]
    //    private UITexture m_CatchResultTexture;

    //    private TweenAlpha m_CatchResultTw;

    [SerializeField]
    private GameObject m_TempRoleSlot;

    [SerializeField]
    private GameObject m_TempSelectedRoleSlot;

    //    [SerializeField]
    //    private UIToggle m_PauseCheckbox;

    //    [SerializeField]
    //    private GameObject m_HintContainer_Skill;

    //    [SerializeField]
    //    private UILabel m_HintLab_Skill;

    //    [SerializeField]
    //    private GameObject m_HintContainer_Catch;

    //    [SerializeField]
    //    private UILabel m_HintLab_Catch;

    //    [SerializeField]
    //    private GameObject m_EscapeFail;

    //    [SerializeField]
    //    private GameObject m_CutInContainer;

    //    [SerializeField]
    //    private List<UITexture> m_CutInTextureList;

    private UIFightRoleSlot m_ControlledRoleSlot;

    private List<UIFightRoleSlot> m_RoleSlots = new List<UIFightRoleSlot>();

    private Dictionary<int, UIFightRoleSlot> m_RoleSlotTable = new Dictionary<int, UIFightRoleSlot>();

    [SerializeField]
    private GameObject m_TempMobSlot;

    [SerializeField]
    private GameObject m_TempBossSlot;

    [SerializeField]
    private GameObject m_MobSlot;
    
    private List<UIFightMobSlot> m_MobSlots_Normal = new List<UIFightMobSlot>();

    private List<UIFightMobSlot> m_MobSlots_Boss = new List<UIFightMobSlot>();

    //    private Dictionary<int, cUIFightMobSlot> m_MobSlotTable = new Dictionary<int, cUIFightMobSlot>();

    //    [SerializeField]
    //    private GameObject m_TempGuardSlot;

    //    private List<cUIFightGuardSlot> m_GuardSlots = new List<cUIFightGuardSlot>();

    //    private UI_Fight.ENUM_FightInputLevel m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Null;

    //    private int m_JoyMobIdx = -1;

    //    private int m_JoyRoleIdx = -1;

    //    private int m_JoyFormationIdx = -1;

    //    private Dictionary<GameObject, int> m_FormationBtnIdxTable = new Dictionary<GameObject, int>();

    //    private int m_JoyInputIdx = -1;

    //    private Dictionary<GameObject, int> m_ActionBtnsTable = new Dictionary<GameObject, int>();

    //    public int MAX_SHOWBUFFICON = 10;

    //    public string CATCH_SUCCESS = "g_damage_getsuccess";

    //    public string CATCH_FAIL = "g_damage_getfail";

    //    private Color COLOR_WIND = new Color(0f, 1f, 0.3372549f, 0.3529412f);

    //    private Color COLOR_EARTH = new Color(1f, 0.8235294f, 0.219607845f, 0.2901961f);

    //    private Color COLOR_WATER = new Color(0f, 0.470588237f, 1f, 0.3019608f);

    //    private Color COLOR_FIRE = new Color(1f, 0f, 0f, 0.654902f);

    //    private M_Mob m_TargetMob;

    public FightSceneManager m_FightSceneMgr;

    //    private float m_GCDTimer;

    //    private float m_HintTimer;

    //    private int m_NowSkillPage;

    //    private int m_NowItemPage;

    //    private int m_TmpCommandID = -1;

    //    private Dictionary<int, int> m_RoleHotKeyPageRecord = new Dictionary<int, int>();

    //    private bool m_bHoverPauseCheckBox;

    //    private int m_KeyboardInputIdx = -1;

    //    private UI_Fight.ENUM_MenuState m_emMenuState = UI_Fight.ENUM_MenuState.Null;

    //    private bool m_bStoryMode;

    //    public static UI_Fight Instance;

    //    public void HotKeyTestShowHide()
    //    {
    //        if (this.IsVisible())
    //        {
    //            base.Hide();
    //        }
    //        else
    //        {
    //            base.Show();
    //        }
    //    }

    //    public override void ForceUpdateUI()
    //    {
    //        base.ForceUpdateUI();
    //        if (this.m_HintTimer > 0f)
    //        {
    //            this.m_HintTimer -= Time.deltaTime;
    //            if (this.m_HintTimer <= 0f)
    //            {
    //                this.m_HintContainer_Skill.SetActive(false);
    //                this.m_HintContainer_Catch.SetActive(false);
    //            }
    //        }
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        if (this.m_FightSceneMgr.m_IsFightFinish)
    //        {
    //            return;
    //        }
    //        if (!this.m_FightSceneMgr.m_IsFightStart)
    //        {
    //            return;
    //        }
    //        if (this.m_bStoryMode != this.m_FightSceneMgr.m_bIsStoryMode)
    //        {
    //            this.m_bStoryMode = this.m_FightSceneMgr.m_bIsStoryMode;
    //        }
    //        if (!this.m_bStoryMode)
    //        {
    //            this.Update_Input();
    //        }
    //        this.UpdateMobSlot_HP();
    //        this.UpdateRoleSlot_HPMP();
    //        this.m_GCDTimer = this.m_FightSceneMgr.GetControlledPlayerGCDTimer();
    //        bool flag = true;
    //        if (this.m_FightSceneMgr.GetControlledPlayerCommandQueue() != null && this.m_FightSceneMgr.GetControlledPlayerCommandQueue().Length >= 2)
    //        {
    //            flag = false;
    //        }
    //        if (this.m_GCDTimer > 0f)
    //        {
    //            flag = false;
    //        }
    //        float num = 0f;
    //        if (this.m_FightSceneMgr.GetControlledPlayer().GetAddActionCD() > 0f)
    //        {
    //            num = this.m_GCDTimer / this.m_FightSceneMgr.GetControlledPlayer().GetAddActionCD();
    //        }
    //        if (num > 1f)
    //        {
    //            num = 1f;
    //        }
    //        if (num < 0f)
    //        {
    //            num = 0f;
    //        }
    //        for (int i = 0; i < this.m_SkillColddownSpriteList.Count; i++)
    //        {
    //            this.m_SkillColddownSpriteList[i].fillAmount = num;
    //        }
    //        for (int j = 0; j < this.m_ItemColddownSpriteList.Count; j++)
    //        {
    //            this.m_ItemColddownSpriteList[j].fillAmount = num;
    //        }
    //        if (!this.m_FightSceneMgr.IsBossFight())
    //        {
    //            this.m_EscapeBtn.isEnabled = flag;
    //        }
    //        M_Player controlledPlayer = this.m_FightSceneMgr.GetControlledPlayer();
    //        if (controlledPlayer != null && controlledPlayer.m_MagicItem_Active != null && controlledPlayer.m_MagicItem_Active.IsCD())
    //        {
    //            this.m_MagicItemBtn.isEnabled = false;
    //            this.m_MagicItemSpriteCol.enabled = true;
    //        }
    //        else
    //        {
    //            this.m_MagicItemBtn.isEnabled = flag;
    //            this.m_MagicItemSpriteCol.enabled = !flag;
    //        }
    //        flag = (this.m_FightSceneMgr.m_CatchMobCDTimer <= 0f);
    //        foreach (KeyValuePair<int, cUIFightMobSlot> current in this.m_MobSlotTable)
    //        {
    //            if (current.Value != null)
    //            {
    //                current.Value.SetCatchBtnEnable(flag);
    //            }
    //        }
    //        for (int k = 0; k < this.m_FormationBtnList.Count; k++)
    //        {
    //            this.m_FormationBtnList[k].isEnabled = (this.m_FightSceneMgr.m_ChangeFormationCDTimer <= 0f);
    //            if (this.m_FormationBtnIconTable.ContainsKey(this.m_FormationBtnList[k]))
    //            {
    //                BoxCollider component = this.m_FormationBtnIconTable[this.m_FormationBtnList[k]].GetComponent<BoxCollider>();
    //                component.enabled = (this.m_FightSceneMgr.m_ChangeFormationCDTimer > 0f);
    //            }
    //        }
    //    }

    //    public override void Show()
    //    {
    //        this.ResetFightInfo();
    //        if (this.m_FightSceneMgr.IsBossFight())
    //        {
    //            this.m_EscapeBtn.isEnabled = false;
    //            NGUITools.SetActive(this.m_EscapeBtn.gameObject, false);
    //        }
    //        else
    //        {
    //            this.m_EscapeBtn.isEnabled = true;
    //            NGUITools.SetActive(this.m_EscapeBtn.gameObject, true);
    //        }
    //        if (this.m_FightSceneMgr.m_BattleGroupGUID == 7001 && NormalSettingSystem.Instance.GetNormalSetting().m_bEnableTeach)
    //        {
    //            this.m_HintTimer = 15f;
    //            this.m_HintContainer_Skill.SetActive(true);
    //            this.m_HintContainer_Catch.SetActive(false);
    //        }
    //        else if (this.m_FightSceneMgr.m_BattleGroupGUID == 7041 && NormalSettingSystem.Instance.GetNormalSetting().m_bEnableTeach)
    //        {
    //            this.m_HintTimer = 15f;
    //            this.m_HintContainer_Skill.SetActive(false);
    //            this.m_HintContainer_Catch.SetActive(true);
    //        }
    //        else
    //        {
    //            this.m_HintTimer = 0f;
    //            this.m_HintContainer_Skill.SetActive(false);
    //            this.m_HintContainer_Catch.SetActive(false);
    //        }
    //        base.Show();
    //        foreach (KeyValuePair<int, cUIFightRoleSlot> current in this.m_RoleSlotTable)
    //        {
    //            current.Value.PlayTween();
    //        }
    //        this.m_bStoryMode = this.m_FightSceneMgr.m_bIsStoryMode;
    //        if (this.m_bStoryMode)
    //        {
    //            base.Hide();
    //        }
    //    }

    //    public override void Hide()
    //    {
    //        base.Hide();
    //        this.m_CatchResultTexture.gameObject.SetActive(false);
    //        this.m_EscapeFail.SetActive(false);
    //        this.m_CutInContainer.SetActive(false);
    //        for (int i = 0; i < this.m_RoleSlots.Count; i++)
    //        {
    //            this.m_RoleSlots[i].HideCureAimation();
    //        }
    //        this.m_ControlledRoleSlot.HideCureAimation();
    //    }

    //    public void SetStoryMode(bool bStory)
    //    {
    //        this.m_bStoryMode = bStory;
    //        if (bStory)
    //        {
    //            base.Hide();
    //            this.m_CatchResultTexture.gameObject.SetActive(false);
    //            this.m_EscapeFail.SetActive(false);
    //            this.m_CutInContainer.SetActive(false);
    //            for (int i = 0; i < this.m_RoleSlots.Count; i++)
    //            {
    //                this.m_RoleSlots[i].HideCureAimation();
    //            }
    //            this.m_ControlledRoleSlot.HideCureAimation();
    //        }
    //        else
    //        {
    //            base.Show();
    //        }
    //    }

    //    public void SetKeyboardInputIdx(int idx)
    //    {
    //        this.m_KeyboardInputIdx = idx;
    //        if (idx < 0)
    //        {
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Null;
    //        }
    //        else
    //        {
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Mob;
    //        }
    //    }

    //    private void Update_Input()
    //    {
    //        GameState currentGameState = Swd6Application.instance.GetCurrentGameState();
    //        if (!(currentGameState is FightState))
    //        {
    //            return;
    //        }
    //        if (!this.m_FightSceneMgr.m_IsFightStart)
    //        {
    //            return;
    //        }
    //        if (this.m_FightSceneMgr.m_IsFightFinish)
    //        {
    //            return;
    //        }
    //        this.Update_JoyInput();
    //        if (GameInput.CheckPressKey() == KeyCode.Tab)
    //        {
    //            this.m_KeyboardInputIdx++;
    //            if (this.m_KeyboardInputIdx < 0)
    //            {
    //                this.m_KeyboardInputIdx = 0;
    //            }
    //            if (this.m_KeyboardInputIdx > 0)
    //            {
    //                if (this.m_KeyboardInputIdx >= this.m_MobSlots_Normal.Count || this.m_KeyboardInputIdx >= this.m_MobSlots_Boss.Count)
    //                {
    //                    this.m_KeyboardInputIdx = 0;
    //                }
    //                if (!this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled() && !this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //                {
    //                    this.m_KeyboardInputIdx = 0;
    //                }
    //            }
    //            if (this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                GameInput.MoveCursorToGui(this.m_MobSlots_Normal[this.m_KeyboardInputIdx].m_UIElement.BaseElement);
    //            }
    //            if (this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                GameInput.MoveCursorToGui(this.m_MobSlots_Boss[this.m_KeyboardInputIdx].m_UIElement.BaseElement);
    //            }
    //            return;
    //        }
    //        if (GameInput.IsPressConfirmKey() && this.m_KeyboardInputIdx >= 0 && this.m_KeyboardInputIdx < this.m_MobSlots_Normal.Count && this.m_KeyboardInputIdx < this.m_MobSlots_Boss.Count)
    //        {
    //            if (this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                this.m_MobSlots_Normal[this.m_KeyboardInputIdx].OnSelectBtn_Click(this.m_MobSlots_Normal[this.m_KeyboardInputIdx].m_UIElement.SelectButton.gameObject);
    //            }
    //            if (this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                this.m_MobSlots_Boss[this.m_KeyboardInputIdx].OnSelectBtn_Click(this.m_MobSlots_Boss[this.m_KeyboardInputIdx].m_UIElement.SelectButton.gameObject);
    //            }
    //        }
    //        if (Input.GetKeyUp(KeyCode.Space) && this.m_KeyboardInputIdx >= 0 && this.m_KeyboardInputIdx < this.m_MobSlots_Normal.Count && this.m_KeyboardInputIdx < this.m_MobSlots_Boss.Count)
    //        {
    //            if (this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                this.m_MobSlots_Normal[this.m_KeyboardInputIdx].OnCatchMobBtn_Click(this.m_MobSlots_Normal[this.m_KeyboardInputIdx].m_UIElement.CatchMobBtn.gameObject);
    //            }
    //            if (this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                this.m_MobSlots_Boss[this.m_KeyboardInputIdx].OnCatchMobBtn_Click(this.m_MobSlots_Boss[this.m_KeyboardInputIdx].m_UIElement.CatchMobBtn.gameObject);
    //            }
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha1) && this.m_SkillBtnList[0].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[0].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha2) && this.m_SkillBtnList[1].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[1].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha3) && this.m_SkillBtnList[2].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[2].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha4) && this.m_SkillBtnList[3].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[3].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha5) && this.m_SkillBtnList[4].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[4].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha6) && this.m_SkillBtnList[5].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[5].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha7) && this.m_SkillBtnList[6].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[6].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha8) && this.m_SkillBtnList[7].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[7].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha9) && this.m_SkillBtnList[8].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[8].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Alpha0) && this.m_SkillBtnList[9].isEnabled)
    //        {
    //            this.OnSkillBtn_Click(this.m_SkillBtnList[9].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Q) && this.m_ItemBtnList[0].isEnabled)
    //        {
    //            this.OnItemBtn_Click(this.m_ItemBtnList[0].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.W) && this.m_ItemBtnList[1].isEnabled)
    //        {
    //            this.OnItemBtn_Click(this.m_ItemBtnList[1].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.E) && this.m_ItemBtnList[2].isEnabled)
    //        {
    //            this.OnItemBtn_Click(this.m_ItemBtnList[2].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.R) && this.m_ItemBtnList[3].isEnabled)
    //        {
    //            this.OnItemBtn_Click(this.m_ItemBtnList[3].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.T) && this.m_ItemBtnList[4].isEnabled)
    //        {
    //            this.OnItemBtn_Click(this.m_ItemBtnList[4].gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.Equals) && this.m_EscapeBtn.isEnabled)
    //        {
    //            this.OnFinishBtn_Click();
    //        }
    //        if (Input.GetKeyUp(KeyCode.Minus))
    //        {
    //            this.m_PauseCheckbox.value = !this.m_PauseCheckbox.value;
    //        }
    //        if (Input.GetKeyUp(KeyCode.F1) && this.m_RoleSlotTable.ContainsKey(1))
    //        {
    //            this.SelectPlayer(1);
    //        }
    //        if (Input.GetKeyUp(KeyCode.F2) && this.m_RoleSlotTable.ContainsKey(2))
    //        {
    //            this.SelectPlayer(2);
    //        }
    //        if (Input.GetKeyUp(KeyCode.F3) && this.m_RoleSlotTable.ContainsKey(3))
    //        {
    //            this.SelectPlayer(3);
    //        }
    //        if (Input.GetKeyUp(KeyCode.F4) && this.m_RoleSlotTable.ContainsKey(4))
    //        {
    //            this.SelectPlayer(4);
    //        }
    //        if (this.m_FormationMiddleBtn.isEnabled)
    //        {
    //            if (Input.GetKeyUp(KeyCode.Z) && this.m_FormationBtnList[0].isEnabled)
    //            {
    //                this.OnFormationBtn_Click(this.m_FormationBtnList[0].gameObject);
    //                this.UpdateNowFormation();
    //            }
    //            if (Input.GetKeyUp(KeyCode.X) && this.m_FormationBtnList[1].isEnabled)
    //            {
    //                this.OnFormationBtn_Click(this.m_FormationBtnList[1].gameObject);
    //                this.UpdateNowFormation();
    //            }
    //            if (Input.GetKeyUp(KeyCode.C) && this.m_FormationBtnList[2].isEnabled)
    //            {
    //                this.OnFormationBtn_Click(this.m_FormationBtnList[2].gameObject);
    //                this.UpdateNowFormation();
    //            }
    //            if (Input.GetKeyUp(KeyCode.V) && this.m_FormationBtnList[3].isEnabled)
    //            {
    //                this.OnFormationBtn_Click(this.m_FormationBtnList[3].gameObject);
    //                this.UpdateNowFormation();
    //            }
    //        }
    //        if (Input.GetKeyUp(KeyCode.Home))
    //        {
    //            this.OnSkillPageUpBtn_Click(this.m_SkillPageUpBtn.gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.End))
    //        {
    //            this.OnSkillPageDownBtn_Click(this.m_SkillPageDownBtn.gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.PageUp))
    //        {
    //            this.OnItemPageUpBtn_Click(this.m_ItemPageUpBtn.gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.PageDown))
    //        {
    //            this.OnItemPageDownBtn_Click(this.m_ItemPageDownBtn.gameObject);
    //        }
    //        if (Input.GetKeyUp(KeyCode.BackQuote) && this.m_MagicItemBtn.gameObject.activeSelf && this.m_MagicItemBtn.isEnabled)
    //        {
    //            this.OnMagicItemBtn_Click(this.m_MagicItemBtn.gameObject);
    //        }
    //        if (GameInput.IsPressCancelKey())
    //        {
    //            this.SetSelectCommandTargetState(false);
    //        }
    //    }

    //    private void Update_JoyInput()
    //    {
    //        GameState currentGameState = Swd6Application.instance.GetCurrentGameState();
    //        if (!(currentGameState is FightState))
    //        {
    //            return;
    //        }
    //        if (!this.m_FightSceneMgr.m_IsFightStart)
    //        {
    //            return;
    //        }
    //        if (this.m_FightSceneMgr.m_IsFightFinish)
    //        {
    //            return;
    //        }
    //        if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.LB))
    //        {
    //            this.m_JoyRoleIdx--;
    //            if (this.m_JoyRoleIdx < 0 || this.m_JoyRoleIdx >= this.m_RoleSlots.Count)
    //            {
    //                this.m_JoyRoleIdx = this.m_RoleSlots.Count - 1;
    //            }
    //            for (int i = this.m_JoyRoleIdx; i > 0; i--)
    //            {
    //                if (!this.m_RoleSlots[this.m_JoyRoleIdx].IsEmpty())
    //                {
    //                    this.m_JoyRoleIdx = i;
    //                    break;
    //                }
    //            }
    //            GameInput.MoveCursorToGui(this.m_RoleSlots[this.m_JoyRoleIdx].m_UIElement.SelectButton.gameObject, 98, 0);
    //            return;
    //        }
    //        if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.RB))
    //        {
    //            this.m_JoyRoleIdx++;
    //            if (this.m_JoyRoleIdx < 0 || this.m_JoyRoleIdx >= this.m_RoleSlots.Count)
    //            {
    //                this.m_JoyRoleIdx = 0;
    //            }
    //            if (this.m_JoyRoleIdx > 0 && this.m_RoleSlots[this.m_JoyRoleIdx].IsEmpty())
    //            {
    //                this.m_JoyRoleIdx = 0;
    //            }
    //            GameInput.MoveCursorToGui(this.m_RoleSlots[this.m_JoyRoleIdx].m_UIElement.SelectButton.gameObject, 98, 0);
    //            return;
    //        }
    //        if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.RTrigger))
    //        {
    //            this.m_KeyboardInputIdx++;
    //            if (this.m_KeyboardInputIdx < 0)
    //            {
    //                this.m_KeyboardInputIdx = 0;
    //            }
    //            if (this.m_KeyboardInputIdx > 0)
    //            {
    //                if (this.m_KeyboardInputIdx >= this.m_MobSlots_Normal.Count || this.m_KeyboardInputIdx >= this.m_MobSlots_Boss.Count)
    //                {
    //                    this.m_KeyboardInputIdx = 0;
    //                }
    //                if (!this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled() && !this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //                {
    //                    this.m_KeyboardInputIdx = 0;
    //                }
    //            }
    //            if (this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                GameInput.MoveCursorToGui(this.m_MobSlots_Normal[this.m_KeyboardInputIdx].m_UIElement.BaseElement);
    //            }
    //            if (this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //            {
    //                GameInput.MoveCursorToGui(this.m_MobSlots_Boss[this.m_KeyboardInputIdx].m_UIElement.BaseElement);
    //            }
    //            return;
    //        }
    //        if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.LTrigger))
    //        {
    //            if (!this.m_FormationCont.activeSelf)
    //            {
    //                return;
    //            }
    //            this.m_JoyFormationIdx++;
    //            if (this.m_JoyFormationIdx < 0 || this.m_JoyFormationIdx >= this.m_FormationBtnList.Count)
    //            {
    //                this.m_JoyFormationIdx = 0;
    //            }
    //            if (!this.m_FormationBtnList[this.m_JoyFormationIdx].gameObject.activeSelf)
    //            {
    //                this.m_JoyFormationIdx = 0;
    //            }
    //            GameInput.MoveCursorToGui(this.m_FormationBtnList[this.m_JoyFormationIdx].gameObject);
    //            return;
    //        }
    //        else
    //        {
    //            if (GameInput.IsJoyPressUpKey())
    //            {
    //                if (this.m_emInputLevel == UI_Fight.ENUM_FightInputLevel.Skill)
    //                {
    //                    this.OnSkillPageUpBtn_Click(this.m_SkillPageUpBtn.gameObject);
    //                }
    //                if (this.m_emInputLevel == UI_Fight.ENUM_FightInputLevel.Item)
    //                {
    //                    this.OnItemPageUpBtn_Click(this.m_ItemPageUpBtn.gameObject);
    //                }
    //                return;
    //            }
    //            if (GameInput.IsJoyPressDownKey())
    //            {
    //                if (this.m_emInputLevel == UI_Fight.ENUM_FightInputLevel.Skill)
    //                {
    //                    this.OnSkillPageDownBtn_Click(this.m_SkillPageDownBtn.gameObject);
    //                }
    //                if (this.m_emInputLevel == UI_Fight.ENUM_FightInputLevel.Item)
    //                {
    //                    this.OnItemPageDownBtn_Click(this.m_ItemPageDownBtn.gameObject);
    //                }
    //                return;
    //            }
    //            if (GameInput.IsJoyPressLeftKey())
    //            {
    //                this.m_JoyInputIdx = this.GetPrevEnableActionBtnIdx(this.m_JoyInputIdx);
    //                if (this.m_JoyInputIdx < 0)
    //                {
    //                    return;
    //                }
    //                int num = this.m_JoyInputIdx;
    //                if (num == 0)
    //                {
    //                    GameInput.MoveCursorToGui(this.m_MagicItemBtn.gameObject);
    //                }
    //                else if (num - 1 < this.m_SkillBtnList.Count)
    //                {
    //                    GameInput.MoveCursorToGui(this.m_SkillBtnList[num - 1].gameObject);
    //                }
    //                else
    //                {
    //                    num -= this.m_SkillBtnList.Count;
    //                    GameInput.MoveCursorToGui(this.m_ItemBtnList[num - 1].gameObject);
    //                }
    //            }
    //            if (GameInput.IsJoyPressRightKey())
    //            {
    //                this.m_JoyInputIdx = this.GetNextEnableActionBtnIdx(this.m_JoyInputIdx);
    //                if (this.m_JoyInputIdx < 0)
    //                {
    //                    return;
    //                }
    //                int num2 = this.m_JoyInputIdx;
    //                if (num2 == 0)
    //                {
    //                    GameInput.MoveCursorToGui(this.m_MagicItemBtn.gameObject);
    //                }
    //                else if (num2 - 1 < this.m_SkillBtnList.Count)
    //                {
    //                    GameInput.MoveCursorToGui(this.m_SkillBtnList[num2 - 1].gameObject);
    //                }
    //                else
    //                {
    //                    num2 -= this.m_SkillBtnList.Count;
    //                    GameInput.MoveCursorToGui(this.m_ItemBtnList[num2 - 1].gameObject);
    //                }
    //            }
    //            if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.START))
    //            {
    //                this.m_PauseCheckbox.value = !this.m_PauseCheckbox.value;
    //            }
    //            if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.Y) && this.m_KeyboardInputIdx >= 0 && this.m_KeyboardInputIdx < this.m_MobSlots_Normal.Count && this.m_KeyboardInputIdx < this.m_MobSlots_Boss.Count)
    //            {
    //                if (this.m_MobSlots_Normal[this.m_KeyboardInputIdx].IsEnabled())
    //                {
    //                    this.m_MobSlots_Normal[this.m_KeyboardInputIdx].OnCatchMobBtn_Click(this.m_MobSlots_Normal[this.m_KeyboardInputIdx].m_UIElement.CatchMobBtn.gameObject);
    //                }
    //                if (this.m_MobSlots_Boss[this.m_KeyboardInputIdx].IsEnabled())
    //                {
    //                    this.m_MobSlots_Boss[this.m_KeyboardInputIdx].OnCatchMobBtn_Click(this.m_MobSlots_Boss[this.m_KeyboardInputIdx].m_UIElement.CatchMobBtn.gameObject);
    //                }
    //            }
    //            if (GameInput.GetJoyKeyDown(JOYSTICK_KEY.BACK) && this.m_EscapeBtn.isEnabled)
    //            {
    //                this.OnFinishBtn_Click();
    //            }
    //            if (GameInput.IsPressConfirmKey())
    //            {
    //                switch (this.m_emInputLevel)
    //                {
    //                    case UI_Fight.ENUM_FightInputLevel.Formation:
    //                        if (this.m_JoyFormationIdx >= 0 && this.m_JoyFormationIdx < this.m_FormationBtnList.Count && this.m_FormationBtnList[this.m_JoyFormationIdx].isEnabled)
    //                        {
    //                            this.OnFormationBtn_Click(this.m_FormationBtnList[this.m_JoyFormationIdx].gameObject);
    //                            this.UpdateNowFormation();
    //                        }
    //                        break;
    //                    case UI_Fight.ENUM_FightInputLevel.MagicItem:
    //                    case UI_Fight.ENUM_FightInputLevel.Skill:
    //                    case UI_Fight.ENUM_FightInputLevel.Item:
    //                        {
    //                            int num3 = this.m_JoyInputIdx;
    //                            if (num3 == 0)
    //                            {
    //                                if (this.m_MagicItemCont.activeSelf && this.m_MagicItemBtn.gameObject.activeSelf && this.m_MagicItemBtn.isEnabled)
    //                                {
    //                                    this.OnMagicItemBtn_Click(this.m_MagicItemBtn.gameObject);
    //                                }
    //                            }
    //                            else if (num3 - 1 < this.m_SkillBtnList.Count)
    //                            {
    //                                if (this.m_SkillBtnList[num3 - 1].isEnabled)
    //                                {
    //                                    this.OnSkillBtn_Click(this.m_SkillBtnList[num3 - 1].gameObject);
    //                                }
    //                            }
    //                            else
    //                            {
    //                                num3 -= this.m_SkillBtnList.Count;
    //                                if (this.m_ItemBtnList[num3 - 1].isEnabled)
    //                                {
    //                                    this.OnItemBtn_Click(this.m_ItemBtnList[num3 - 1].gameObject);
    //                                }
    //                            }
    //                            break;
    //                        }
    //                    case UI_Fight.ENUM_FightInputLevel.Role:
    //                        if (this.m_JoyRoleIdx == this.m_ControlledRoleSlot.GetSlotIdx())
    //                        {
    //                            this.SelectPlayer(this.m_ControlledRoleSlot.GetRoleID());
    //                        }
    //                        else if (this.m_JoyRoleIdx >= 0 && this.m_JoyRoleIdx < this.m_RoleSlots.Count)
    //                        {
    //                            this.SelectPlayer(this.m_RoleSlots[this.m_JoyRoleIdx].GetRoleID());
    //                        }
    //                        break;
    //                }
    //            }
    //            return;
    //        }
    //    }

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        //this.m_CatchResultTw = this.m_CatchResultTexture.GetComponent<TweenAlpha>();//捕捉结果
        //this.CreateMobSlots();
        this.CreateRoleSlots();
        //this.CreateGuardSlot();
        //this.InitSkillBtn(this.m_SkillBtnList);
        //this.InitItemBtn(this.m_ItemBtnList);
        //this.InitFormationBtnCallback();
        //UIEventListener uieventListener = UIEventListener.Get(this.m_MagicItemBtn.gameObject);
        //UIEventListener uieventListener2 = uieventListener;
        //uieventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uieventListener2.onClick, new UIEventListener.VoidDelegate(this.OnMagicItemBtn_Click));
        //UIEventListener uieventListener3 = uieventListener;
        //uieventListener3.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener3.onTooltip, new UIEventListener.BoolDelegate(this.OnMagicItemBtn_ToolTip));
        //UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(this.m_MagicItemBtn.gameObject, "ImageSprite");
        //uieventListener = UIEventListener.Get(childElement.gameObject);
        //UIEventListener uieventListener4 = uieventListener;
        //uieventListener4.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener4.onTooltip, new UIEventListener.BoolDelegate(this.OnMagicItemBtn_ToolTip));
        //UIEventListener uieventListener5 = uieventListener;
        //uieventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uieventListener5.onClick, new UIEventListener.VoidDelegate(this.OnMagicItemBtn_Click));
        //this.m_ActionBtnsTable.Add(this.m_MagicItemBtn.gameObject, 0);
        //this.m_ActionBtnsTable.Add(childElement.gameObject, 0);
        //uieventListener = UIEventListener.Get(this.m_EscapeBtn.gameObject);
        //UIEventListener uieventListener6 = uieventListener;
        //uieventListener6.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener6.onTooltip, new UIEventListener.BoolDelegate(this.OnEscapeBtn_ToolTip));
        //GameObject gameObject = this.m_EscapeBtn.transform.Find("HoverObject").gameObject;
        //uieventListener = UIEventListener.Get(gameObject);
        //UIEventListener uieventListener7 = uieventListener;
        //uieventListener7.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener7.onTooltip, new UIEventListener.BoolDelegate(this.OnEscapeBtn_ToolTip));
        //UIEventListener uieventListener8 = uieventListener;
        //uieventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uieventListener8.onClick, new UIEventListener.VoidDelegate(this.OnBtn_ErrorClick));
        //uieventListener = UIEventListener.Get(this.m_PauseCheckbox.gameObject);
        //UIEventListener uieventListener9 = uieventListener;
        //uieventListener9.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener9.onHover, new UIEventListener.BoolDelegate(this.OnPauseCheckbox_Hover));
        //UIEventListener uieventListener10 = uieventListener;
        //uieventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uieventListener10.onClick, new UIEventListener.VoidDelegate(this.OnBtn_Click));
        //this.m_CatchResultTexture.mainTexture = ResourceManager.Instance.GetImage(this.CATCH_SUCCESS);
        //this.m_HintLab_Skill.text = GameDataDB.StrID(8300);
        //this.m_HintLab_Catch.text = GameDataDB.StrID(8301);
        //string str = "cutin_";
        //NormalSetting normalSetting = NormalSettingSystem.Instance.GetNormalSetting();
        //if (normalSetting.m_emCharacterStyle == Enum_CharacterStyle.Enum_CharacterStyle_Real)
        //{
        //    str += "l_p0";
        //}
        //else
        //{
        //    str += "h_p0";
        //}
        //for (int i = 1; i <= this.m_CutInTextureList.Count; i++)
        //{
        //    string name = str + i.ToString();
        //    this.m_CutInTextureList[i - 1].mainTexture = ResourceManager.Instance.GetImage(name);
        //}
    }

    //    public void ResetFightInfo()
    //    {
    //        this.m_NowSkillPage = 0;
    //        for (int i = 0; i < 4; i++)
    //        {
    //            if (this.m_RoleHotKeyPageRecord.ContainsKey(i))
    //            {
    //                this.m_RoleHotKeyPageRecord[i] = 0;
    //            }
    //            else
    //            {
    //                this.m_RoleHotKeyPageRecord.Add(i, 0);
    //            }
    //            for (int j = 0; j < 5; j++)
    //            {
    //                if (this.CheckSkillPage(i, j))
    //                {
    //                    this.m_RoleHotKeyPageRecord[i] = j;
    //                    break;
    //                }
    //            }
    //        }
    //        this.InitMobSlotInfo();
    //        this.InitTargetAndRoleSlotInfo();
    //        this.SetGuardSlot();
    //        this.SetItemBtn();
    //        this.SetSkillBtn();
    //        this.SetFormationBtn();
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            UnityEngine.Debug.Log("m_FightSceneMgr == null");
    //            return;
    //        }
    //        this.UpdateNowFormation();
    //        this.m_PauseCheckbox.value = this.m_FightSceneMgr.m_bIsPauseMode;
    //        this.m_EscapeFail.SetActive(false);
    //        this.m_CutInContainer.SetActive(false);
    //    }

    //    private void AddPlayerSkillCommand(int skillId, M_Character target)
    //    {
    //        this.SetSelectCommandTargetState(false);
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        if (!this.m_FightSceneMgr.AddPlayerSkillCommand(skillId, target))
    //        {
    //            return;
    //        }
    //    }

    //    private void AddPlayerItemCommand(int itemID, M_Character target)
    //    {
    //        this.SetSelectCommandTargetState(false);
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        if (!this.m_FightSceneMgr.AddPlayerItemCommand(itemID, target))
    //        {
    //            return;
    //        }
    //        UI_Fight.S_UIFightCommand s_UIFightCommand = default(UI_Fight.S_UIFightCommand);
    //        s_UIFightCommand.id = itemID;
    //        s_UIFightCommand.bSkill = true;
    //        this.m_GCDTimer = this.m_FightSceneMgr.GetControlledPlayerGCD();
    //    }

    //    private void InitItemBtn(List<UIButton> itemBtnList)
    //    {
    //        this.m_ItemBtnIDTable.Clear();
    //        this.m_ItemBtnIconTable.Clear();
    //        this.m_ItemBtnCountTable.Clear();
    //        for (int i = 0; i < itemBtnList.Count; i++)
    //        {
    //            UIEventListener uIEventListener = UIEventListener.Get(itemBtnList[i].gameObject);
    //            UIEventListener expr_3B = uIEventListener;
    //            expr_3B.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_3B.onClick, new UIEventListener.VoidDelegate(this.OnItemBtn_Click));
    //            UIEventListener expr_5D = uIEventListener;
    //            expr_5D.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_5D.onTooltip, new UIEventListener.BoolDelegate(this.OnItemBtn_ToolTip));
    //            UIEventListener expr_7F = uIEventListener;
    //            expr_7F.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_7F.onHover, new UIEventListener.BoolDelegate(this.OnSkillItemBtn_Hover));
    //            this.m_ActionBtnsTable.Add(itemBtnList[i].gameObject, this.m_SkillBtnList.Count + i + 1);
    //            UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(itemBtnList[i].gameObject, "ImageSprite");
    //            this.m_ItemBtnIconList.Add(childElement);
    //            uIEventListener = UIEventListener.Get(childElement.gameObject);
    //            UIEventListener expr_F6 = uIEventListener;
    //            expr_F6.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_F6.onTooltip, new UIEventListener.BoolDelegate(this.OnItemBtn_ToolTip));
    //            UIEventListener expr_118 = uIEventListener;
    //            expr_118.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_118.onHover, new UIEventListener.BoolDelegate(this.OnSkillItemBtn_Hover));
    //            UIEventListener expr_13A = uIEventListener;
    //            expr_13A.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_13A.onClick, new UIEventListener.VoidDelegate(this.OnBtn_ErrorClick));
    //            this.m_ActionBtnsTable.Add(childElement.gameObject, this.m_SkillBtnList.Count + i + 1);
    //            UISprite childElement2 = nGUICustomUtil.getChildElement<UISprite>(itemBtnList[i].gameObject, "HighlightSprite");
    //            childElement2.enabled = false;
    //            this.m_ItemBtnIDTable.Add(itemBtnList[i], -1);
    //            this.m_ItemBtnIconTable.Add(itemBtnList[i], childElement);
    //            UILabel childElement3 = nGUICustomUtil.getChildElement<UILabel>(itemBtnList[i].gameObject, "CountLabel");
    //            childElement3.text = string.Empty;
    //            this.m_ItemBtnCountTable.Add(itemBtnList[i], childElement3);
    //            UISprite childElement4 = nGUICustomUtil.getChildElement<UISprite>(itemBtnList[i].gameObject, "ColddownSprite");
    //            this.m_ItemColddownSpriteList.Add(childElement4);
    //        }
    //        EventDelegate item = new EventDelegate(this, "OnItemPageUpBtn_Click");
    //        this.m_ItemPageUpBtn.onClick.Add(item);
    //        UIEventListener uIEventListener2 = UIEventListener.Get(this.m_ItemPageUpBtn.gameObject);
    //        UIEventListener expr_25F = uIEventListener2;
    //        expr_25F.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_25F.onHover, new UIEventListener.BoolDelegate(this.OnBtn_Hover));
    //        EventDelegate item2 = new EventDelegate(this, "OnItemPageDownBtn_Click");
    //        this.m_ItemPageDownBtn.onClick.Add(item2);
    //        uIEventListener2 = UIEventListener.Get(this.m_ItemPageDownBtn.gameObject);
    //        UIEventListener expr_2B3 = uIEventListener2;
    //        expr_2B3.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_2B3.onHover, new UIEventListener.BoolDelegate(this.OnBtn_Hover));
    //    }

    //    private void InitSkillBtn(List<UIButton> skillBtnList)
    //    {
    //        this.m_SkillBtnIDTable.Clear();
    //        this.m_SkillBtnIconTable.Clear();
    //        for (int i = 0; i < skillBtnList.Count; i++)
    //        {
    //            UIEventListener uIEventListener = UIEventListener.Get(skillBtnList[i].gameObject);
    //            UIEventListener expr_30 = uIEventListener;
    //            expr_30.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_30.onClick, new UIEventListener.VoidDelegate(this.OnSkillBtn_Click));
    //            UIEventListener expr_52 = uIEventListener;
    //            expr_52.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_52.onTooltip, new UIEventListener.BoolDelegate(this.OnSkillBtn_ToolTip));
    //            UIEventListener expr_74 = uIEventListener;
    //            expr_74.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_74.onHover, new UIEventListener.BoolDelegate(this.OnSkillItemBtn_Hover));
    //            this.m_ActionBtnsTable.Add(skillBtnList[i].gameObject, i + 1);
    //            UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(skillBtnList[i].gameObject, "ImageSprite");
    //            this.m_SkillBtnIconList.Add(childElement);
    //            uIEventListener = UIEventListener.Get(childElement.gameObject);
    //            UIEventListener expr_DF = uIEventListener;
    //            expr_DF.onTooltip = (UIEventListener.BoolDelegate)Delegate.Combine(expr_DF.onTooltip, new UIEventListener.BoolDelegate(this.OnSkillBtn_ToolTip));
    //            UIEventListener expr_101 = uIEventListener;
    //            expr_101.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_101.onHover, new UIEventListener.BoolDelegate(this.OnSkillItemBtn_Hover));
    //            UIEventListener expr_123 = uIEventListener;
    //            expr_123.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_123.onClick, new UIEventListener.VoidDelegate(this.OnBtn_ErrorClick));
    //            this.m_ActionBtnsTable.Add(childElement.gameObject, i + 1);
    //            this.m_SkillBtnIDTable.Add(skillBtnList[i], -1);
    //            this.m_SkillBtnIconTable.Add(skillBtnList[i], childElement);
    //            UISprite childElement2 = nGUICustomUtil.getChildElement<UISprite>(skillBtnList[i].gameObject, "HighlightSprite");
    //            childElement2.enabled = false;
    //            UISprite childElement3 = nGUICustomUtil.getChildElement<UISprite>(skillBtnList[i].gameObject, "ColddownSprite");
    //            this.m_SkillColddownSpriteList.Add(childElement3);
    //        }
    //        EventDelegate item = new EventDelegate(this, "OnSkillPageUpBtn_Click");
    //        this.m_SkillPageUpBtn.onClick.Add(item);
    //        UIEventListener uIEventListener2 = UIEventListener.Get(this.m_SkillPageUpBtn.gameObject);
    //        UIEventListener expr_204 = uIEventListener2;
    //        expr_204.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_204.onHover, new UIEventListener.BoolDelegate(this.OnBtn_Hover));
    //        EventDelegate item2 = new EventDelegate(this, "OnSkillPageDownBtn_Click");
    //        this.m_SkillPageDownBtn.onClick.Add(item2);
    //        uIEventListener2 = UIEventListener.Get(this.m_SkillPageDownBtn.gameObject);
    //        UIEventListener expr_258 = uIEventListener2;
    //        expr_258.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_258.onHover, new UIEventListener.BoolDelegate(this.OnBtn_Hover));
    //    }

    //    private void InitFormationBtnCallback()
    //    {
    //        this.m_FormationBtnIdxTable.Clear();
    //        UIEventListener uIEventListener;
    //        for (int i = 0; i < this.m_FormationBtnList.Count; i++)
    //        {
    //            uIEventListener = UIEventListener.Get(this.m_FormationBtnList[i].gameObject);
    //            uIEventListener.parameter = i;
    //            UIEventListener expr_36 = uIEventListener;
    //            expr_36.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_36.onClick, new UIEventListener.VoidDelegate(this.OnFormationBtn_Click));
    //            UIEventListener expr_58 = uIEventListener;
    //            expr_58.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_58.onHover, new UIEventListener.BoolDelegate(this.OnFormationBtn_Hover));
    //            UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(this.m_FormationBtnList[i].gameObject, "Sprite");
    //            uIEventListener = UIEventListener.Get(childElement.gameObject);
    //            uIEventListener.parameter = i;
    //            UIEventListener expr_AE = uIEventListener;
    //            expr_AE.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_AE.onClick, new UIEventListener.VoidDelegate(this.OnBtn_ErrorClick));
    //            UIEventListener expr_D0 = uIEventListener;
    //            expr_D0.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_D0.onHover, new UIEventListener.BoolDelegate(this.OnFormationBtn_Hover));
    //            this.m_FormationBtnIconTable.Add(this.m_FormationBtnList[i], childElement);
    //            UILabel componentInChildren = this.m_FormationBtnList[i].GetComponentInChildren<UILabel>();
    //            this.m_FormationBtnIdxTable.Add(this.m_FormationBtnList[i].gameObject, i);
    //        }
    //        uIEventListener = UIEventListener.Get(this.m_FormationMiddleBtn.gameObject);
    //        UIEventListener expr_15F = uIEventListener;
    //        expr_15F.onHover = (UIEventListener.BoolDelegate)Delegate.Combine(expr_15F.onHover, new UIEventListener.BoolDelegate(this.OnFormationMiddleBtn_Hover));
    //        this.m_FormationMiddleTexture.enabled = false;
    //    }

    //    private void SetFormationBtn()
    //    {
    //        FormationData formationData;
    //        for (int i = 0; i < 4; i++)
    //        {
    //            if (i >= this.m_FormationBtnList.Count || i >= this.m_FormationHotKeyLabList.Count)
    //            {
    //                break;
    //            }
    //            formationData = Swd6Application.instance.m_FormationSystem.GetFormationData(i);
    //            if (formationData == null || !formationData.Enable)
    //            {
    //                this.m_FormationBtnList[i].gameObject.SetActive(false);
    //                this.m_FormationHotKeyLabList[i].gameObject.SetActive(false);
    //            }
    //            else
    //            {
    //                this.m_FormationBtnList[i].gameObject.SetActive(true);
    //                this.m_FormationHotKeyLabList[i].gameObject.SetActive(true);
    //            }
    //        }
    //        formationData = Swd6Application.instance.m_FormationSystem.GetFormationData(1);
    //        if (formationData == null || !formationData.Enable)
    //        {
    //            this.m_FormationCont.SetActive(false);
    //        }
    //        else
    //        {
    //            this.m_FormationCont.SetActive(true);
    //        }
    //    }

    /// <summary>
    /// 创建敌人头像
    /// </summary>
    private void CreateMobSlots()
    {
        this.m_MobSlots_Normal.Clear();
        this.m_MobSlots_Boss.Clear();
        for (int i = 0; i < 6; i++)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate(m_TempMobSlot) as GameObject;
            //GameObject gameObject2 = UnityEngine.Object.Instantiate(m_TempBossSlot) as GameObject;
           // gameObject.SetParent(m_MobSlot.transform);
            //UIFightMobSlot cUIFightMobSlot = new UIFightMobSlot(gameObject, false);
            //cUIFightMobSlot cUIFightMobSlot2 = new cUIFightMobSlot(gameObject2, true);
            //this.m_MobSlots_Normal.Add(cUIFightMobSlot);
            //this.m_MobSlots_Boss.Add(cUIFightMobSlot2);
            //float y = this.m_TempBossSlot.transform.localPosition.y + -95f * (float)i;
            //gameObject.transform.localPosition = new Vector3(this.m_TempMobSlot.transform.localPosition.x, y, this.m_TempMobSlot.transform.localPosition.z);
            //gameObject2.transform.localPosition = new Vector3(this.m_TempBossSlot.transform.localPosition.x, y, this.m_TempBossSlot.transform.localPosition.z);
           // cUIFightMobSlot.SetSlotIndex(i);
           // cUIFightMobSlot.SetEnable(false);
            //cUIFightMobSlot2.SetSlotIndex(i);
            //cUIFightMobSlot2.SetEnable(false);
        }

        //if (this.m_TempMobSlot != null)
        //{
        //    UnityEngine.Object.Destroy(this.m_TempMobSlot);
        //}

        //if (this.m_TempBossSlot != null)
        //{
        //    UnityEngine.Object.Destroy(this.m_TempBossSlot);
        //}
    }

    /// <summary>
    /// 创建角色头像
    /// </summary>
    private void CreateRoleSlots()
    {
        Debug.Log("CreateRoleSlots");
        //this.m_ControlledRoleSlot = new UIFightRoleSlot(this.m_TempSelectedRoleSlot);
        this.m_RoleSlotTable.Clear();
        //cUIFightRoleSlot cUIFightRoleSlot = new cUIFightRoleSlot(this.m_TempRoleSlot);
        //cUIFightRoleSlot.SetSlotIdx(0);
        //this.m_RoleSlots.Add(cUIFightRoleSlot);
        //for (int i = 1; i < 4; i++)
        //{
        //    if (this.m_TempRoleSlot == null)
        //    {
        //        UnityEngine.Debug.Log("m_TempRoleSlot == null");
        //        return;
        //    }
        //    GameObject slotcontainer = NGUITools.AddChild(this.m_TempRoleSlot.transform.parent.gameObject, this.m_TempRoleSlot);
        //    cUIFightRoleSlot cUIFightRoleSlot2 = new cUIFightRoleSlot(slotcontainer);
        //    cUIFightRoleSlot2.SetSlotIdx(i);
        //    this.m_RoleSlots.Add(cUIFightRoleSlot2);
        //    Vector3 slotPos = cUIFightRoleSlot.GetSlotPos();
        //    slotPos.x += cUIFightRoleSlot.m_UIElement.Container.localSize.x * (float)i;
        //    cUIFightRoleSlot2.SetSlotPos(slotPos);
        //}
    }

    //    public void CreateGuardSlot()
    //    {
    //        this.m_GuardSlots.Clear();
    //        cUIFightGuardSlot item = new cUIFightGuardSlot(this.m_TempGuardSlot);
    //        this.m_GuardSlots.Add(item);
    //        GameObject gameObject = NGUITools.AddChild(this.m_TempGuardSlot.transform.parent.gameObject, this.m_TempGuardSlot);
    //        item = new cUIFightGuardSlot(gameObject);
    //        this.m_GuardSlots.Add(item);
    //        float y = this.m_TempGuardSlot.transform.position.y - 80f;
    //        gameObject.transform.position = new Vector3(this.m_TempGuardSlot.transform.position.x, y, 0f);
    //        for (int i = 0; i < this.m_GuardSlots.Count; i++)
    //        {
    //            this.m_GuardSlots[i].SetEnable(false);
    //        }
    //    }

    //    public void SetGuardSlot()
    //    {
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        Dictionary<int, M_Guard> guardList = this.m_FightSceneMgr.GetGuardList();
    //        if (guardList == null)
    //        {
    //            UnityEngine.Debug.Log("cant get guardList");
    //            return;
    //        }
    //        IEnumerator<KeyValuePair<int, M_Guard>> enumerator = guardList.GetEnumerator();
    //        enumerator.Reset();
    //        for (int i = 0; i < this.m_GuardSlots.Count; i++)
    //        {
    //            M_Guard m_Guard = null;
    //            while (enumerator.MoveNext())
    //            {
    //                KeyValuePair<int, M_Guard> current = enumerator.Current;
    //                if (!(current.Value == null))
    //                {
    //                    KeyValuePair<int, M_Guard> current2 = enumerator.Current;
    //                    if (current2.Value.m_RoleModel.activeSelf)
    //                    {
    //                        KeyValuePair<int, M_Guard> current3 = enumerator.Current;
    //                        m_Guard = current3.Value;
    //                        break;
    //                    }
    //                }
    //            }
    //            if (m_Guard == null)
    //            {
    //                this.m_GuardSlots[i].SetEnable(false);
    //            }
    //            else
    //            {
    //                this.m_GuardSlots[i].SetEnable(true);
    //                this.m_GuardSlots[i].SetGuardInfo(m_Guard.m_MobGUID);
    //            }
    //        }
    //    }

    //    private void SetItemBtn()
    //    {
    //        List<FightItemHotKeyInfo> fightItemHotkeyList = Swd6Application.instance.m_ItemSystem.GetFightItemHotkeyList(this.m_NowItemPage);
    //        if (fightItemHotkeyList == null)
    //        {
    //            UnityEngine.Debug.LogWarning("無該頁道具資料");
    //            return;
    //        }
    //        this.m_ItemPageLabel.text = (this.m_NowItemPage + 1).ToString();
    //        for (int i = 0; i < this.m_ItemBtnList.Count; i++)
    //        {
    //            S_Item s_Item = null;
    //            int num = -1;
    //            if (i < fightItemHotkeyList.Count)
    //            {
    //                num = fightItemHotkeyList[i].ID;
    //                s_Item = GameDataDB.ItemDB.GetData(num);
    //            }
    //            UIEventListener uIEventListener = UIEventListener.Get(this.m_ItemBtnList[i].gameObject);
    //            uIEventListener.parameter = num;
    //            if (i < this.m_ItemBtnIconList.Count)
    //            {
    //                if (s_Item == null)
    //                {
    //                    this.m_ItemBtnIconList[i].enabled = false;
    //                    this.m_ItemColddownSpriteList[i].enabled = false;
    //                    this.m_ItemBtnList[i].gameObject.SetActive(false);
    //                }
    //                else
    //                {
    //                    nGUICustomUtil.SetSpriteAtlas(this.m_ItemBtnIconList[i], s_Item.IconNo);
    //                    this.m_ItemBtnList[i].normalSprite = this.m_ItemBtnIconList[i].spriteName;
    //                    this.m_ItemBtnIconList[i].enabled = true;
    //                    this.m_ItemColddownSpriteList[i].enabled = true;
    //                    this.m_ItemBtnList[i].gameObject.SetActive(true);
    //                }
    //                uIEventListener = UIEventListener.Get(this.m_ItemBtnIconList[i].gameObject);
    //                uIEventListener.parameter = num;
    //            }
    //            if (this.m_ItemBtnIDTable.ContainsKey(this.m_ItemBtnList[i]))
    //            {
    //                this.m_ItemBtnIDTable[this.m_ItemBtnList[i]] = num;
    //            }
    //        }
    //        this.UpdateItemBtnEnableAndCount();
    //    }

    //    private void SetSkillBtn()
    //    {
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        List<FightSkillHotKeyInfo> controlledPlayerSkillList = this.m_FightSceneMgr.GetControlledPlayerSkillList(this.m_NowSkillPage);
    //        if (controlledPlayerSkillList == null)
    //        {
    //            UnityEngine.Debug.Log("List NULL");
    //            return;
    //        }
    //        if (this.m_SkillBtnList == null)
    //        {
    //            UnityEngine.Debug.Log("BTN NULL");
    //            return;
    //        }
    //        this.m_SkillPageLabel.text = (this.m_NowSkillPage + 1).ToString();
    //        for (int i = 0; i < this.m_SkillBtnList.Count; i++)
    //        {
    //            if (i >= this.m_SkillBtnIconList.Count)
    //            {
    //                break;
    //            }
    //            int num;
    //            if (i < controlledPlayerSkillList.Count)
    //            {
    //                num = controlledPlayerSkillList[i].ID;
    //            }
    //            else
    //            {
    //                num = -1;
    //            }
    //            S_Skill data = GameDataDB.SkillDB.GetData(num);
    //            UIEventListener uIEventListener = UIEventListener.Get(this.m_SkillBtnList[i].gameObject);
    //            uIEventListener.parameter = num;
    //            uIEventListener = UIEventListener.Get(this.m_SkillBtnIconList[i].gameObject);
    //            uIEventListener.parameter = num;
    //            if (data == null)
    //            {
    //                this.m_SkillBtnIconList[i].enabled = false;
    //                this.m_SkillColddownSpriteList[i].enabled = false;
    //                this.m_SkillBtnList[i].gameObject.SetActive(false);
    //            }
    //            else
    //            {
    //                this.m_SkillBtnList[i].gameObject.SetActive(true);
    //                nGUICustomUtil.SetSpriteAtlas(this.m_SkillBtnIconList[i], data.IconNo);
    //                this.m_SkillBtnList[i].normalSprite = this.m_SkillBtnIconList[i].spriteName;
    //                this.m_SkillBtnIconList[i].enabled = true;
    //                this.m_SkillColddownSpriteList[i].enabled = true;
    //            }
    //            if (this.m_SkillBtnIDTable.ContainsKey(this.m_SkillBtnList[i]))
    //            {
    //                this.m_SkillBtnIDTable[this.m_SkillBtnList[i]] = num;
    //            }
    //        }
    //        this.UpdateSkillBtnEnable();
    //        int roleID = this.m_ControlledRoleSlot.GetRoleID();
    //        if (this.m_RoleHotKeyPageRecord.ContainsKey(roleID))
    //        {
    //            this.m_RoleHotKeyPageRecord[roleID] = this.m_NowSkillPage;
    //        }
    //        else
    //        {
    //            this.m_RoleHotKeyPageRecord.Add(roleID, this.m_NowSkillPage);
    //        }
    //    }

    //    public void UpdateMobSlot_HP()
    //    {
    //        Dictionary<int, M_Mob> mobList = this.m_FightSceneMgr.GetMobList();
    //        if (mobList == null)
    //        {
    //            return;
    //        }
    //        foreach (KeyValuePair<int, M_Mob> current in mobList)
    //        {
    //            if (!current.Value.IsDead())
    //            {
    //                if (this.m_MobSlotTable.ContainsKey(current.Key) && this.m_MobSlotTable[current.Key] != null)
    //                {
    //                    this.m_MobSlotTable[current.Key].UpdateHP();
    //                }
    //            }
    //        }
    //    }

    //    public void UpdateRoleSlot_HPMP()
    //    {
    //        M_Player controlledPlayer = this.m_FightSceneMgr.GetControlledPlayer();
    //        if (controlledPlayer != null)
    //        {
    //            this.m_ControlledRoleSlot.UpdateHP(controlledPlayer.m_FightRoleData.HP, controlledPlayer.m_FightRoleData.MaxHP);
    //            this.m_ControlledRoleSlot.UpdateMP(controlledPlayer.m_FightRoleData.MP, controlledPlayer.m_FightRoleData.MaxMP);
    //        }
    //        Dictionary<int, M_Player> roleList = this.m_FightSceneMgr.GetRoleList();
    //        if (roleList == null)
    //        {
    //            return;
    //        }
    //        foreach (KeyValuePair<int, M_Player> current in roleList)
    //        {
    //            if (current.Key != this.m_FightSceneMgr.GetControlledPlayerRoleID())
    //            {
    //                if (this.m_RoleSlotTable.ContainsKey(current.Key))
    //                {
    //                    if (this.m_RoleSlotTable[current.Key] != null)
    //                    {
    //                        this.m_RoleSlotTable[current.Key].UpdateHP(current.Value.m_FightRoleData.HP, current.Value.m_FightRoleData.MaxHP);
    //                        this.m_RoleSlotTable[current.Key].UpdateMP(current.Value.m_FightRoleData.MP, current.Value.m_FightRoleData.MaxMP);
    //                        if (current.Value.m_ActionCDTimer > 0f)
    //                        {
    //                            this.m_RoleSlotTable[current.Key].SetCDEnable(false);
    //                        }
    //                        else
    //                        {
    //                            this.m_RoleSlotTable[current.Key].SetCDEnable(true);
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public void SelectPlayer(int roleID)
    //    {
    //        UI_Fight.ENUM_MenuState emMenuState = this.m_emMenuState;
    //        if (emMenuState != UI_Fight.ENUM_MenuState.UseSkillTarget)
    //        {
    //            if (emMenuState != UI_Fight.ENUM_MenuState.UseItemTarget)
    //            {
    //                this.ChangeControlledRole(roleID);
    //            }
    //            else
    //            {
    //                this.AddPlayerItemCommand(this.m_TmpCommandID, this.m_FightSceneMgr.GetRole(roleID));
    //            }
    //        }
    //        else
    //        {
    //            this.AddPlayerSkillCommand(this.m_TmpCommandID, this.m_FightSceneMgr.GetRole(roleID));
    //        }
    //        this.m_emMenuState = UI_Fight.ENUM_MenuState.Null;
    //        this.SetSelectCommandTargetState(false);
    //    }

    //    public void ChangeControlledRole(int roleID)
    //    {
    //        this.m_FightSceneMgr.ChangeControlCharacter(roleID, false);
    //        this.SetSelectCommandTargetState(false);
    //    }

    //    public void UpdateSkillBtnEnable()
    //    {
    //        foreach (KeyValuePair<UIButton, int> current in this.m_SkillBtnIDTable)
    //        {
    //            bool flag = this.m_FightSceneMgr.GetControlledPlayer().CheckCanUseSkill(current.Value);
    //            if (this.m_FightSceneMgr.GetControlledPlayer().IsLoseHeart())
    //            {
    //                flag = false;
    //            }
    //            current.Key.isEnabled = flag;
    //            if (this.m_SkillBtnIconTable.ContainsKey(current.Key))
    //            {
    //                BoxCollider component = this.m_SkillBtnIconTable[current.Key].GetComponent<BoxCollider>();
    //                component.enabled = !flag;
    //            }
    //        }
    //    }

    //    public void UpdateItemBtnEnableAndCount()
    //    {
    //        M_Player controlledPlayer = this.m_FightSceneMgr.GetControlledPlayer();
    //        foreach (KeyValuePair<UIButton, int> current in this.m_ItemBtnIDTable)
    //        {
    //            ItemData dataByItemID = Swd6Application.instance.m_ItemSystem.GetDataByItemID(current.Value);
    //            if (this.m_ItemBtnCountTable.ContainsKey(current.Key))
    //            {
    //                if (dataByItemID != null)
    //                {
    //                    this.m_ItemBtnCountTable[current.Key].text = dataByItemID.Count.ToString();
    //                }
    //                else if (current.Value > 0)
    //                {
    //                    this.m_ItemBtnCountTable[current.Key].text = "0";
    //                }
    //                else
    //                {
    //                    this.m_ItemBtnCountTable[current.Key].text = string.Empty;
    //                }
    //                bool flag = true;
    //                if (controlledPlayer == null || controlledPlayer.CannotUseAnyCommand() || controlledPlayer.IsLoseHeart())
    //                {
    //                    flag = false;
    //                }
    //                if (this.m_FightSceneMgr.GetControlledPlayerGCDTimer() > 0f)
    //                {
    //                    flag = false;
    //                }
    //                if (dataByItemID == null || dataByItemID.Count <= 0)
    //                {
    //                    flag = false;
    //                }
    //                current.Key.isEnabled = flag;
    //                BoxCollider component = this.m_ItemBtnIconTable[current.Key].GetComponent<BoxCollider>();
    //                component.enabled = !flag;
    //            }
    //        }
    //    }

    //    public void UpdatePlayerBuffIcon(int roleID, List<Buff_Base> buffList)
    //    {
    //        if (!this.m_RoleSlotTable.ContainsKey(roleID))
    //        {
    //            return;
    //        }
    //        this.m_RoleSlotTable[roleID].UpdateBuffIcon(buffList);
    //    }

    //    public void UpdateMobBuffIcon(int mobKeyID)
    //    {
    //        if (!this.m_MobSlotTable.ContainsKey(mobKeyID))
    //        {
    //            return;
    //        }
    //        if (this.m_MobSlotTable[mobKeyID] == null)
    //        {
    //            return;
    //        }
    //        this.m_MobSlotTable[mobKeyID].UpdateBuffIcon();
    //    }

    //    private void SetSelectCommandTargetState(bool enabled)
    //    {
    //        if (!enabled)
    //        {
    //            this.m_emMenuState = UI_Fight.ENUM_MenuState.Null;
    //        }
    //        foreach (KeyValuePair<int, cUIFightRoleSlot> current in this.m_RoleSlotTable)
    //        {
    //            current.Value.SetHighlight(enabled);
    //        }
    //    }

    public void UpdateSelectRole()
    {
        this.SetControlledRole(this.m_FightSceneMgr.GetControlledPlayer());
    }

    //    public void UpdateRoleAICheckBox(int roleID)
    //    {
    //        if (this.m_RoleSlotTable.ContainsKey(roleID))
    //        {
    //            this.m_RoleSlotTable[roleID].UpdateUseAICheckbox();
    //        }
    //    }

    //    [DebuggerHidden]
    //    public IEnumerator ShowCatchResult(bool bSuccess)
    //    {
    //        UI_Fight.< ShowCatchResult > c__Iterator8C9 < ShowCatchResult > c__Iterator8C = new UI_Fight.< ShowCatchResult > c__Iterator8C9();

    //        < ShowCatchResult > c__Iterator8C.bSuccess = bSuccess;

    //        < ShowCatchResult > c__Iterator8C.<$> bSuccess = bSuccess;

    //        < ShowCatchResult > c__Iterator8C.<> f__this = this;
    //        return < ShowCatchResult > c__Iterator8C;
    //    }

    //    public void ShowCutIn(int roleID)
    //    {
    //        int num = roleID - 1;
    //        if (num < 0 || num >= this.m_CutInTextureList.Count)
    //        {
    //            return;
    //        }
    //        this.m_CutInContainer.SetActive(false);
    //        for (int i = 0; i < this.m_CutInTextureList.Count; i++)
    //        {
    //            if (i == num)
    //            {
    //                this.m_CutInTextureList[i].enabled = true;
    //            }
    //            else
    //            {
    //                this.m_CutInTextureList[i].enabled = false;
    //            }
    //        }
    //        this.m_CutInContainer.SetActive(true);
    //    }

    //    public void ShowEscapeFail()
    //    {
    //        this.m_EscapeFail.SetActive(false);
    //        this.m_EscapeFail.SetActive(true);
    //    }

    //    public bool ChangeTargetMob(int mobkey)
    //    {
    //        return this.m_FightSceneMgr != null && this.m_FightSceneMgr.ChangeTargetMob(mobkey);
    //    }

    //    public void UpdateNowFormation()
    //    {
    //        int nowFormationIdx = this.m_FightSceneMgr.GetNowFormationIdx();
    //        string text = string.Empty;
    //        string normalSprite = string.Empty;
    //        nGUICustomUtil.SetSpriteAtlas(this.m_FormationMiddleSprite, 783 + nowFormationIdx);
    //        FormationData nowFormation = this.m_FightSceneMgr.GetNowFormation();
    //        switch (nowFormation.emElement)
    //        {
    //            case ENUM_ElementType.Wind:
    //                this.m_twFormationMiddle.to = this.COLOR_WIND;
    //                text = "gw_fight_wood";
    //                normalSprite = "fight_magic_wood";
    //                break;
    //            case ENUM_ElementType.Earth:
    //                this.m_twFormationMiddle.to = this.COLOR_EARTH;
    //                text = "gw_fight_earth";
    //                normalSprite = "fight_magic_earth";
    //                break;
    //            case ENUM_ElementType.Water:
    //                this.m_twFormationMiddle.to = this.COLOR_WATER;
    //                text = "gw_fight_water";
    //                normalSprite = "fight_magic_water";
    //                break;
    //            case ENUM_ElementType.Fire:
    //                this.m_twFormationMiddle.to = this.COLOR_FIRE;
    //                text = "gw_fight_fire";
    //                normalSprite = "fight_magic_fire";
    //                break;
    //        }
    //        this.m_FormationMiddleBtn.normalSprite = normalSprite;
    //        if (text.Length > 0)
    //        {
    //            this.m_FormationMiddleTexture.mainTexture = ResourceManager.Instance.GetTextImage(text);
    //        }
    //    }

    //    public void CatchMob(int mobKeyID)
    //    {
    //        this.m_FightSceneMgr.CatchMob(this.m_ControlledRoleSlot.GetRoleID(), mobKeyID);
    //    }

    //    public void SetMobBeCaught(int mobKeyID, bool bCaught)
    //    {
    //        if (this.m_MobSlotTable.ContainsKey(mobKeyID))
    //        {
    //            this.m_MobSlotTable[mobKeyID].SetBeCaught(bCaught);
    //        }
    //    }

    //    public void SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel emLevel)
    //    {
    //        this.m_emInputLevel = emLevel;
    //    }

    //    public void SetJoyRoleIdx(int idx)
    //    {
    //        this.m_JoyRoleIdx = idx;
    //    }

    //    private int GetNextEnableActionBtnIdx(int startIdx)
    //    {
    //        List<int> list = new List<int>();
    //        if (this.m_MagicItemCont.gameObject.activeSelf)
    //        {
    //            list.Add(0);
    //        }
    //        for (int i = 0; i < this.m_SkillBtnList.Count; i++)
    //        {
    //            if (this.m_SkillBtnList[i].gameObject.activeSelf)
    //            {
    //                if (i + 1 > startIdx)
    //                {
    //                    return i + 1;
    //                }
    //                list.Add(i + 1);
    //            }
    //        }
    //        for (int j = 0; j < this.m_ItemBtnList.Count; j++)
    //        {
    //            int num = this.m_SkillBtnList.Count + j + 1;
    //            if (this.m_ItemBtnList[j].gameObject.activeSelf)
    //            {
    //                if (num > startIdx)
    //                {
    //                    return num;
    //                }
    //                list.Add(num);
    //            }
    //        }
    //        if (list.Count > 0)
    //        {
    //            return list[0];
    //        }
    //        return startIdx;
    //    }

    //    private int GetPrevEnableActionBtnIdx(int startIdx)
    //    {
    //        List<int> list = new List<int>();
    //        for (int i = this.m_ItemBtnList.Count - 1; i >= 0; i--)
    //        {
    //            int num = this.m_SkillBtnList.Count + i + 1;
    //            if (this.m_ItemBtnList[i].gameObject.activeSelf)
    //            {
    //                if (num < startIdx)
    //                {
    //                    return num;
    //                }
    //                list.Add(num);
    //            }
    //        }
    //        for (int j = this.m_SkillBtnList.Count - 1; j >= 0; j--)
    //        {
    //            int num2 = j + 1;
    //            if (this.m_SkillBtnList[j].gameObject.activeSelf)
    //            {
    //                if (num2 < startIdx)
    //                {
    //                    return num2;
    //                }
    //                list.Add(num2);
    //            }
    //        }
    //        if (this.m_MagicItemCont.gameObject.activeSelf)
    //        {
    //            return 0;
    //        }
    //        if (list.Count > 0)
    //        {
    //            return list[0];
    //        }
    //        return startIdx;
    //    }

    //    private void InitTargetAndRoleSlotInfo()
    //    {
    //        this.m_RoleSlotTable.Clear();
    //        this.m_ControlledRoleSlot.Reset();
    //        this.m_ControlledRoleSlot.SetEnable(false);
    //        for (int i = 0; i < this.m_RoleSlots.Count; i++)
    //        {
    //            this.m_RoleSlots[i].Reset();
    //            this.m_RoleSlots[i].SetEnable(false);
    //        }
    //        Dictionary<int, M_Player> roleList = this.m_FightSceneMgr.GetRoleList();
    //        foreach (KeyValuePair<int, M_Player> current in roleList)
    //        {
    //            this.SetUnitRoleSlot(current.Value);
    //        }
    //        this.SetTargetRoleSlot(this.m_FightSceneMgr.GetControlledPlayer());
    //    }

    //    private void SetUnitRoleSlot(M_Player playerInfo)
    //    {
    //        for (int i = 0; i < this.m_RoleSlots.Count; i++)
    //        {
    //            if (this.m_RoleSlots[i].IsEmpty())
    //            {
    //                this.SetUnitRoleSlot(i, playerInfo);
    //                break;
    //            }
    //        }
    //    }

    //    private void SetUnitRoleSlot(int slotIdx, M_Player playerInfo)
    //    {
    //        if (slotIdx < 0 || slotIdx >= this.m_RoleSlots.Count)
    //        {
    //            return;
    //        }
    //        int key = -1;
    //        if (playerInfo != null)
    //        {
    //            key = playerInfo.m_RoleID;
    //        }
    //        if (this.m_RoleSlotTable.ContainsKey(key))
    //        {
    //            this.m_RoleSlotTable[key] = this.m_RoleSlots[slotIdx];
    //        }
    //        else
    //        {
    //            this.m_RoleSlotTable.Add(key, this.m_RoleSlots[slotIdx]);
    //        }
    //        this.m_RoleSlots[slotIdx].SetRoleInfo(playerInfo);
    //    }

    //    private void SetTargetRoleSlot(M_Player roleInfo)
    //    {
    //        if (roleInfo == null)
    //        {
    //            return;
    //        }
    //        this.m_ControlledRoleSlot.SetRoleInfo(roleInfo);
    //        if (this.m_RoleSlotTable.ContainsKey(roleInfo.m_RoleID))
    //        {
    //            cUIFightRoleSlot cUIFightRoleSlot = this.m_RoleSlotTable[roleInfo.m_RoleID];
    //            cUIFightRoleSlot.SetEnable(false);
    //            this.m_ControlledRoleSlot.SetSlotIdx(cUIFightRoleSlot.GetSlotIdx());
    //            this.m_ControlledRoleSlot.SetSlotPos(cUIFightRoleSlot.GetSlotPos());
    //            this.m_RoleSlotTable[roleInfo.m_RoleID] = this.m_ControlledRoleSlot;
    //        }
    //        else
    //        {
    //            this.m_RoleSlotTable.Add(roleInfo.m_RoleID, this.m_ControlledRoleSlot);
    //        }
    //        this.SetSelectCommandTargetState(false);
    //        if (this.m_RoleHotKeyPageRecord.ContainsKey(roleInfo.m_RoleID))
    //        {
    //            this.m_NowSkillPage = this.m_RoleHotKeyPageRecord[roleInfo.m_RoleID];
    //        }
    //        else
    //        {
    //            this.m_NowSkillPage = 0;
    //        }
    //        this.SetSkillBtn();
    //        this.UpdateSkillBtnEnable();
    //        this.UpdateItemBtnEnableAndCount();
    //        this.m_MagicItemCont.SetActive(false);
    //        ItemData equipItemData = roleInfo.m_RoleDataEx.GetEquipItemData(ENUM_EquipPosition.Talisman);
    //        if (equipItemData == null)
    //        {
    //            return;
    //        }
    //        S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
    //        if (data == null || data.emItemType != ENUM_ItemType.MagicItem)
    //        {
    //            return;
    //        }
    //        if (data.emSubItemType != ENUM_ItemSubType.MagicArms)
    //        {
    //            return;
    //        }
    //        this.m_MagicItemCont.SetActive(true);
    //        UIEventListener uIEventListener = UIEventListener.Get(this.m_MagicItemBtn.gameObject);
    //        uIEventListener.parameter = equipItemData.ID;
    //    }

    private void SetControlledRole(M_Player newControlledRole)
    {
        Debug.Log("执行SetControlledRole");
        //if (this.m_ControlledRoleSlot == null)
        //{
        //    return;
        //}
        //if (this.m_ControlledRoleSlot.GetRoleID() == newControlledRole.m_RoleID)
        //{
        //    return;
        //}
        //int slotIdx = this.m_ControlledRoleSlot.GetSlotIdx();
        //if (slotIdx < 0)
        //{
        //    this.SetTargetRoleSlot(newControlledRole);
        //    return;
        //}
        //int roleID = this.m_ControlledRoleSlot.GetRoleID();
        //if (roleID > 0)
        //{
        //    this.SetUnitRoleSlot(slotIdx, this.m_FightSceneMgr.GetRole(roleID));
        //}
        //this.SetTargetRoleSlot(newControlledRole);
        //this.m_ControlledRoleSlot.PlayTween();
        //this.m_RoleSlots[slotIdx].PlayTween();
    }

    //    public void SetTargetMob(M_Mob mobData)
    //    {
    //        if (mobData == null)
    //        {
    //            return;
    //        }
    //        this.m_TargetMob = mobData;
    //        foreach (KeyValuePair<int, cUIFightMobSlot> current in this.m_MobSlotTable)
    //        {
    //            if (current.Value != null)
    //            {
    //                if (current.Key == this.m_TargetMob.m_MobSerialID)
    //                {
    //                    current.Value.SetFocus(true);
    //                }
    //                else
    //                {
    //                    current.Value.SetFocus(false);
    //                }
    //            }
    //        }
    //        this.SetSelectCommandTargetState(false);
    //    }

    //    private void ResetAllMobSlot()
    //    {
    //        for (int i = 0; i < this.m_MobSlots_Normal.Count; i++)
    //        {
    //            this.m_MobSlots_Normal[i].Reset();
    //            this.m_MobSlots_Normal[i].SetEnable(false);
    //        }
    //        for (int j = 0; j < this.m_MobSlots_Boss.Count; j++)
    //        {
    //            this.m_MobSlots_Boss[j].Reset();
    //            this.m_MobSlots_Boss[j].SetEnable(false);
    //        }
    //    }

    //    private void InitMobSlotInfo()
    //    {
    //        this.m_MobSlotTable.Clear();
    //        this.ResetAllMobSlot();
    //        Dictionary<int, M_Mob> mobList = this.m_FightSceneMgr.GetMobList();
    //        foreach (KeyValuePair<int, M_Mob> current in mobList)
    //        {
    //            if (!(current.Value == null))
    //            {
    //                if (current.Value.CanBeTarget())
    //                {
    //                    this.SetUnitMobSlot(current.Value);
    //                }
    //            }
    //        }
    //        if (this.m_FightSceneMgr.GetMainTarget() != null)
    //        {
    //            this.SetTargetMob(this.m_FightSceneMgr.GetMainTarget());
    //        }
    //    }

    //    public void SetUnitMobSlot(M_Mob mobData)
    //    {
    //        int count = this.m_MobSlotTable.Count;
    //        if (!this.SetUnitMobSlot(count, mobData))
    //        {
    //            UnityEngine.Debug.Log("SetUnitMobSlot 失敗");
    //        }
    //    }

    //    private bool SetUnitMobSlot(int slotIdx, M_Mob mobData)
    //    {
    //        if (slotIdx < 0)
    //        {
    //            return false;
    //        }
    //        int mobSerialID = mobData.m_MobSerialID;
    //        cUIFightMobSlot value;
    //        if (mobData.m_MobData.emType == ENUM_MobType.Boss)
    //        {
    //            if (slotIdx >= this.m_MobSlots_Boss.Count)
    //            {
    //                return false;
    //            }
    //            this.m_MobSlots_Boss[slotIdx].SetSlotInfo(mobData);
    //            value = this.m_MobSlots_Boss[slotIdx];
    //        }
    //        else
    //        {
    //            if (slotIdx >= this.m_MobSlots_Normal.Count)
    //            {
    //                return false;
    //            }
    //            this.m_MobSlots_Normal[slotIdx].SetSlotInfo(mobData);
    //            value = this.m_MobSlots_Normal[slotIdx];
    //        }
    //        if (this.m_MobSlotTable.ContainsKey(mobSerialID))
    //        {
    //            this.m_MobSlotTable[mobSerialID] = value;
    //        }
    //        else
    //        {
    //            this.m_MobSlotTable.Add(mobSerialID, value);
    //        }
    //        return true;
    //    }

    //    public void OnMobEnableUpdate(M_Mob mob, bool bEnable)
    //    {
    //        this.InitMobSlotInfo();
    //    }

    //    public void OnEscapeBtn_ToolTip(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        if (state)
    //        {
    //            M_FightUITip.Show(GameDataDB.StrID(8304));
    //            MusicSystem.Instance.PlaySound(2, 1);
    //        }
    //    }

    //    public void OnPauseCheckbox_Hover(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        this.m_bHoverPauseCheckBox = state;
    //        if (state)
    //        {
    //            if (this.m_PauseCheckbox.value)
    //            {
    //                M_FightUITip.Show(GameDataDB.StrID(8302));
    //            }
    //            else
    //            {
    //                M_FightUITip.Show(GameDataDB.StrID(8303));
    //            }
    //            MusicSystem.Instance.PlaySound(2, 1);
    //        }
    //    }

    //    public void OnBuffIcon_ToolTip(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        S_BufferData s_BufferData = (S_BufferData)component.parameter;
    //        if (s_BufferData == null)
    //        {
    //            return;
    //        }
    //        if (state)
    //        {
    //            string text = "[5dcaf7]" + s_BufferData.Name;
    //            if (s_BufferData.Tip != null && s_BufferData.Tip.Length != 0)
    //            {
    //                text = text + "[-]\n" + s_BufferData.Tip;
    //            }
    //            M_FightUITip.Show(text);
    //            MusicSystem.Instance.PlaySound(2, 1);
    //        }
    //    }

    //    public void OnSkillBtn_ToolTip(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int id = (int)component.parameter;
    //        S_Skill data = GameDataDB.SkillDB.GetData(id);
    //        if (data == null)
    //        {
    //            return;
    //        }
    //        if (state)
    //        {
    //            string text = "[5dcaf7]" + data.Name + "[-]\n" + this.GetSkillDesc(data);
    //            M_FightUITip.Show(text);
    //            MusicSystem.Instance.PlaySound(2, 1);
    //            this.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Skill);
    //        }
    //        else
    //        {
    //            this.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Null);
    //        }
    //    }

    //    public void OnSkillBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int num = (int)component.parameter;
    //        S_Skill data = GameDataDB.SkillDB.GetData(num);
    //        if (data == null)
    //        {
    //            return;
    //        }
    //        S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //        if (data2 == null)
    //        {
    //            return;
    //        }
    //        MusicSystem.Instance.PlaySound(3, 1);
    //        if (data2.emTarget == ENUM_UseTarget.Enemy)
    //        {
    //            this.SetSelectCommandTargetState(false);
    //            this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetMainTarget());
    //        }
    //        if (data2.emTarget == ENUM_UseTarget.Partner)
    //        {
    //            if (data2.emRange == ENUM_UseRange.All)
    //            {
    //                if (data2.DeBuffer.Contains(84))
    //                {
    //                    this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetOneDeadRole());
    //                }
    //                else
    //                {
    //                    this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //                }
    //                return;
    //            }
    //            if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || this.m_FightSceneMgr.GetRoleList().Count == 1)
    //            {
    //                int controlledPlayerRoleID = this.m_FightSceneMgr.GetControlledPlayerRoleID();
    //                if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID))
    //                {
    //                    return;
    //                }
    //                this.SetSelectCommandTargetState(false);
    //                this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //                return;
    //            }
    //            else
    //            {
    //                this.m_TmpCommandID = num;
    //                this.SetSelectCommandTargetState(true);
    //                this.m_emMenuState = UI_Fight.ENUM_MenuState.UseSkillTarget;
    //            }
    //        }
    //        if (data2.emTarget == ENUM_UseTarget.Self)
    //        {
    //            int controlledPlayerRoleID2 = this.m_FightSceneMgr.GetControlledPlayerRoleID();
    //            if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID2))
    //            {
    //                return;
    //            }
    //            this.SetSelectCommandTargetState(false);
    //            this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //        }
    //    }

    //    public void OnSkillItemBtn_Hover(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        if (go.name == "ImageSprite")
    //        {
    //            UISprite childElement = nGUICustomUtil.getChildElement<UISprite>(go.transform.parent.gameObject, "HighlightSprite");
    //            childElement.enabled = state;
    //        }
    //        else
    //        {
    //            UISprite childElement2 = nGUICustomUtil.getChildElement<UISprite>(go, "HighlightSprite");
    //            childElement2.enabled = state;
    //        }
    //        if (state)
    //        {
    //            if (!this.m_ActionBtnsTable.ContainsKey(go))
    //            {
    //                return;
    //            }
    //            this.m_JoyInputIdx = this.m_ActionBtnsTable[go];
    //            if (this.m_JoyInputIdx > 0 && this.m_JoyInputIdx <= this.m_SkillBtnList.Count)
    //            {
    //                this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Skill;
    //            }
    //            if (this.m_JoyInputIdx > this.m_SkillBtnList.Count)
    //            {
    //                this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Item;
    //            }
    //        }
    //        else
    //        {
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Null;
    //        }
    //    }

    //    public void OnItemBtn_ToolTip(GameObject go, bool state)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int id = (int)component.parameter;
    //        S_Item data = GameDataDB.ItemDB.GetData(id);
    //        if (data == null)
    //        {
    //            return;
    //        }
    //        if (state)
    //        {
    //            string text = "[5dcaf7]" + data.Name + "[-]\n" + data.Desc;
    //            M_FightUITip.Show(text);
    //            MusicSystem.Instance.PlaySound(2, 1);
    //            this.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Item);
    //        }
    //        else
    //        {
    //            this.SetJoyInputLevel(UI_Fight.ENUM_FightInputLevel.Null);
    //        }
    //    }

    //    public void OnItemBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int num = (int)component.parameter;
    //        S_Item data = GameDataDB.ItemDB.GetData(num);
    //        if (data == null)
    //        {
    //            return;
    //        }
    //        S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
    //        if (data2 == null)
    //        {
    //            return;
    //        }
    //        if (data2.emTarget == ENUM_UseTarget.Enemy)
    //        {
    //            this.SetSelectCommandTargetState(false);
    //            this.AddPlayerItemCommand(num, this.m_FightSceneMgr.GetMainTarget());
    //        }
    //        if (data2.emTarget == ENUM_UseTarget.Partner)
    //        {
    //            if (data2.emRange == ENUM_UseRange.All)
    //            {
    //                if (data2.DeBuffer.Contains(84))
    //                {
    //                    this.AddPlayerItemCommand(num, this.m_FightSceneMgr.GetOneDeadRole());
    //                }
    //                else
    //                {
    //                    this.AddPlayerItemCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //                }
    //                return;
    //            }
    //            if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || this.m_FightSceneMgr.GetRoleList().Count == 1)
    //            {
    //                int controlledPlayerRoleID = this.m_FightSceneMgr.GetControlledPlayerRoleID();
    //                if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID))
    //                {
    //                    return;
    //                }
    //                this.SetSelectCommandTargetState(false);
    //                this.AddPlayerItemCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //                return;
    //            }
    //            else
    //            {
    //                this.m_TmpCommandID = num;
    //                this.SetSelectCommandTargetState(true);
    //                this.m_emMenuState = UI_Fight.ENUM_MenuState.UseItemTarget;
    //            }
    //        }
    //        if (data2.emTarget == ENUM_UseTarget.Self)
    //        {
    //            int controlledPlayerRoleID2 = this.m_FightSceneMgr.GetControlledPlayerRoleID();
    //            if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID2))
    //            {
    //                return;
    //            }
    //            this.SetSelectCommandTargetState(false);
    //            this.AddPlayerItemCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
    //        }
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnBtn_ErrorClick(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        MusicSystem.Instance.PlaySound(204, 1);
    //    }

    //    public void OnFormationMiddleBtn_Hover(GameObject go, bool state)
    //    {
    //        this.m_FormationMiddleTexture.enabled = state;
    //        if (state)
    //        {
    //            FormationData nowFormation = this.m_FightSceneMgr.GetNowFormation();
    //            for (int i = 0; i < nowFormation.Unit.Count; i++)
    //            {
    //                int roleID = nowFormation.Unit[i].RoleID;
    //                if (this.m_RoleSlotTable.ContainsKey(roleID) && this.m_RoleSlotTable[roleID] != null)
    //                {
    //                    this.m_RoleSlotTable[roleID].SetGwTexure(nowFormation.Unit[i].emActionType);
    //                }
    //            }
    //            MusicSystem.Instance.PlaySound(2, 1);
    //        }
    //        foreach (KeyValuePair<int, cUIFightRoleSlot> current in this.m_RoleSlotTable)
    //        {
    //            current.Value.SetGwTexureEnable(state);
    //        }
    //    }

    //    public void OnFormationBtn_Hover(GameObject go, bool bHover)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int num = (int)component.parameter;
    //        if (bHover)
    //        {
    //            nGUICustomUtil.SetSpriteAtlas(this.m_FormationMiddleSprite, 783 + num);
    //            FormationData formationData = Swd6Application.instance.m_FormationSystem.GetFormationData(num);
    //            for (int i = 0; i < formationData.Unit.Count; i++)
    //            {
    //                int roleID = formationData.Unit[i].RoleID;
    //                if (this.m_RoleSlotTable.ContainsKey(roleID) && this.m_RoleSlotTable[roleID] != null)
    //                {
    //                    this.m_RoleSlotTable[roleID].SetGwTexure(formationData.Unit[i].emActionType);
    //                }
    //            }
    //            MusicSystem.Instance.PlaySound(2, 1);
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Formation;
    //            if (this.m_FormationBtnIdxTable.ContainsKey(go))
    //            {
    //                this.m_JoyFormationIdx = this.m_FormationBtnIdxTable[go];
    //            }
    //        }
    //        else
    //        {
    //            nGUICustomUtil.SetSpriteAtlas(this.m_FormationMiddleSprite, 783 + this.m_FightSceneMgr.GetNowFormationIdx());
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Null;
    //        }
    //        foreach (KeyValuePair<int, cUIFightRoleSlot> current in this.m_RoleSlotTable)
    //        {
    //            current.Value.SetGwTexureEnable(bHover);
    //        }
    //    }

    //    public void OnFormationBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        if (!go.activeSelf || !this.m_FormationCont.activeSelf)
    //        {
    //            return;
    //        }
    //        UIEventListener component = go.GetComponent<UIEventListener>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        int num = (int)component.parameter;
    //        if (Swd6Application.instance.m_FormationSystem.GetFormationData(num) == null)
    //        {
    //            UnityEngine.Debug.LogWarning("沒有該陣型資料 formationID:" + num);
    //            return;
    //        }
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        this.m_FightSceneMgr.ChangeFormation(num);
    //        Swd6Application.instance.m_UserBehavior.EventInfo.Counter(num, CounterType.Formation);
    //        this.SetSelectCommandTargetState(false);
    //        foreach (KeyValuePair<int, cUIFightRoleSlot> current in this.m_RoleSlotTable)
    //        {
    //            current.Value.SetGwTexureEnable(false);
    //        }
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnFinishBtn_Click()
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        if (this.m_FightSceneMgr == null)
    //        {
    //            return;
    //        }
    //        this.m_FightSceneMgr.Escape();
    //        this.SetSelectCommandTargetState(false);
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    private bool CheckSkillPage(int roleid, int page)
    //    {
    //        List<FightSkillHotKeyInfo> fightSkillHotkeyList = Swd6Application.instance.m_SkillSystem.GetFightSkillHotkeyList(roleid, page);
    //        for (int i = 0; i < fightSkillHotkeyList.Count; i++)
    //        {
    //            if (fightSkillHotkeyList[i].ID > 0)
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void OnSkillPageUpBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        int num = this.m_NowSkillPage;
    //        for (int i = 0; i < 5; i++)
    //        {
    //            num--;
    //            if (num < 0)
    //            {
    //                num = 4;
    //            }
    //            if (this.CheckSkillPage(this.m_ControlledRoleSlot.GetRoleID(), num))
    //            {
    //                break;
    //            }
    //        }
    //        this.m_NowSkillPage = num;
    //        this.SetSkillBtn();
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnSkillPageDownBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        int num = this.m_NowSkillPage;
    //        for (int i = 0; i < 5; i++)
    //        {
    //            num++;
    //            if (num >= 5)
    //            {
    //                num = 0;
    //            }
    //            if (this.CheckSkillPage(this.m_ControlledRoleSlot.GetRoleID(), num))
    //            {
    //                break;
    //            }
    //        }
    //        this.m_NowSkillPage = num;
    //        this.SetSkillBtn();
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    private bool CheckItemPage(int page)
    //    {
    //        List<FightItemHotKeyInfo> fightItemHotkeyList = Swd6Application.instance.m_ItemSystem.GetFightItemHotkeyList(page);
    //        for (int i = 0; i < fightItemHotkeyList.Count; i++)
    //        {
    //            if (fightItemHotkeyList[i].ID > 0)
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void OnItemPageUpBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        int num = this.m_NowItemPage;
    //        for (int i = 0; i < 5; i++)
    //        {
    //            num--;
    //            if (num < 0)
    //            {
    //                num = 4;
    //            }
    //            if (this.CheckItemPage(num))
    //            {
    //                break;
    //            }
    //        }
    //        this.m_NowItemPage = num;
    //        this.SetItemBtn();
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnItemPageDownBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        int num = this.m_NowItemPage;
    //        for (int i = 0; i < 5; i++)
    //        {
    //            num++;
    //            if (num >= 5)
    //            {
    //                num = 0;
    //            }
    //            if (this.CheckItemPage(num))
    //            {
    //                break;
    //            }
    //        }
    //        this.m_NowItemPage = num;
    //        this.SetItemBtn();
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnMagicItemBtn_ToolTip(GameObject go, bool state)
    //    {
    //        if (this.m_FightSceneMgr.GetControlledPlayer() == null)
    //        {
    //            return;
    //        }
    //        if (state)
    //        {
    //            M_FightUITip.Show(this.m_FightSceneMgr.GetControlledPlayer().m_MagicItem_Active.GetDesc());
    //            MusicSystem.Instance.PlaySound(2, 1);
    //            this.m_JoyInputIdx = 0;
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.MagicItem;
    //        }
    //        else
    //        {
    //            this.m_emInputLevel = UI_Fight.ENUM_FightInputLevel.Null;
    //        }
    //    }

    //    public void OnMagicItemBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        if (!this.m_MagicItemBtn.isEnabled)
    //        {
    //            this.OnBtn_ErrorClick(go);
    //            return;
    //        }
    //        if (this.m_ControlledRoleSlot == null)
    //        {
    //            return;
    //        }
    //        this.m_FightSceneMgr.UseMagicItem_UI(this.m_ControlledRoleSlot.GetRoleID());
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnPauseCheckbox_ValueChange(GameObject go)
    //    {
    //        this.m_FightSceneMgr.SetPauseMode(this.m_PauseCheckbox.value);
    //        if (this.m_bHoverPauseCheckBox)
    //        {
    //            if (this.m_PauseCheckbox.value)
    //            {
    //                M_FightUITip.Show(GameDataDB.StrID(8302));
    //            }
    //            else
    //            {
    //                M_FightUITip.Show(GameDataDB.StrID(8303));
    //            }
    //        }
    //    }

    //    public void OnBtn_Hover(GameObject go, bool state)
    //    {
    //        if (state)
    //        {
    //            MusicSystem.Instance.PlaySound(2, 1);
    //        }
    //    }

    //    public void OnBtn_Click(GameObject go)
    //    {
    //        if (Input.GetMouseButtonUp(1))
    //        {
    //            return;
    //        }
    //        MusicSystem.Instance.PlaySound(3, 1);
    //    }

    //    public void OnEscapeFail_TweenFinish(GameObject go)
    //    {
    //        this.m_EscapeFail.SetActive(false);
    //    }

    //    private string GetSkillDesc(S_Skill skill)
    //    {
    //        string result;
    //        if (skill.Desc.Contains("{"))
    //        {
    //            result = string.Format(skill.Desc, this.GetSkillTipValue(skill));
    //        }
    //        else
    //        {
    //            result = skill.Desc;
    //        }
    //        return result;
    //    }

    //    private int GetSkillTipValue(S_Skill skill)
    //    {
    //        if (skill.UseEffectID <= 0)
    //        {
    //            return 0;
    //        }
    //        S_UseEffect data = GameDataDB.UseEffectDB.GetData(skill.UseEffectID);
    //        if (data == null)
    //        {
    //            return 0;
    //        }
    //        float num = 0f;
    //        if (data.RefValueList.Count > 0)
    //        {
    //            int refValue = FightCalculate.GetRefValue(data.RefValueList[0].emRefValue, this.m_FightSceneMgr.GetControlledPlayer());
    //            num = Mathf.Abs((float)refValue * data.RefValueList[0].RefPercent / 100f);
    //        }
    //        else if (data.Buffer.Count > 0)
    //        {
    //            S_BufferData data2 = GameDataDB.BufferDB.GetData(data.Buffer[0]);
    //            if (data2 == null)
    //            {
    //                return 0;
    //            }
    //            if (data2.emRefValue > ENUM_RefValue.No)
    //            {
    //                int refValue = FightCalculate.GetRefValue(data2.emRefValue, this.m_FightSceneMgr.GetControlledPlayer());
    //                if (data2.AddHP != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.AddHP) / 100f);
    //                }
    //                else if (data2.ReflexDmg != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.ReflexDmg) / 100f);
    //                }
    //                else if (data2.AbsortDmg != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.AbsortDmg) / 100f);
    //                }
    //                else if (data2.ReduceDmg != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.ReduceDmg) / 100f);
    //                }
    //                else if (data2.TransferDmg != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.TransferDmg) / 100f);
    //                }
    //                else if (data2.TransferDmgToMP != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.TransferDmgToMP) / 100f);
    //                }
    //                else if (data2.AddMP != 0)
    //                {
    //                    num = Mathf.Abs((float)(refValue * data2.AddMP) / 100f);
    //                }
    //            }
    //            else if (data2.EndCallID > 0)
    //            {
    //                S_Skill data3 = GameDataDB.SkillDB.GetData(data2.EndCallID);
    //                if (data3 == null)
    //                {
    //                    return 0;
    //                }
    //                S_UseEffect data4 = GameDataDB.UseEffectDB.GetData(data3.UseEffectID);
    //                if (data4 == null)
    //                {
    //                    return 0;
    //                }
    //                if (data4.RefValueList.Count == 0)
    //                {
    //                    return 0;
    //                }
    //                int refValue = FightCalculate.GetRefValue(data4.RefValueList[0].emRefValue, this.m_FightSceneMgr.GetControlledPlayer());
    //                num = Mathf.Abs((float)(refValue * data4.AddRatioHP) / 100f);
    //            }
    //        }
    //        if (data.emItemType == ENUM_ItemSubType.Attack)
    //        {
    //            return (int)num + 9;
    //        }
    //        return (int)num;
}
