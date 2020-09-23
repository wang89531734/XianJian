using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterAction : MonoBehaviour
{
    public Text textRemainsTurns;
    public Image imageRemainsTurnsGage;
    public int skillIndex;

    public UICharacterActionManager ActionManager;
  
    private Toggle tempToggle;
    public Toggle TempToggle
    {
        get
        {
            if (tempToggle == null)
                tempToggle = GetComponent<Toggle>();
            return tempToggle;
        }
    }

    public bool IsOn
    {
        get { return TempToggle.isOn; }
        set { TempToggle.isOn = value; }
    }

    //protected void OnSelected(bool select)
    //{
    //    //if (!ActionManager.IsPlayerCharacterActive || ActionManager.ActiveCharacter.IsDoingAction || !select)
    //    //    return;
    //    //ActionManager.ActiveCharacter.SetAction(skillIndex);
    //    //OnActionSelected();
    //    Debug.Log("直接执行");
    //}

    public void OnSkillBtn_Click()
    {
        Debug.Log("技能按键" + skillIndex);
        //if (Input.GetMouseButtonUp(1))
        //{
        //    return;
        //}
        //if (go == null)
        //{
        //    return;
        //}
        //UIEventListener component = go.GetComponent<UIEventListener>();
        //if (component == null)
        //{
        //    return;
        //}

        S_Skill data = GameDataDB.SkillDB.GetData(skillIndex);
        if (data == null)
        {
            return;
        }

        S_UseEffect data2 = GameDataDB.UseEffectDB.GetData(data.UseEffectID);
        if (data2 == null)
        {
            return;
        }

        ////MusicSystem.Instance.PlaySound(3, 1);
        ////判断技能的类型
        if (data2.emTarget == ENUM_UseTarget.Enemy)
        {
            ActionManager.ActiveCharacter.AddSkillCommand(skillIndex, ActionManager.Manager.m_FightSceneMgr.GetMainTarget());
            //this.SetSelectCommandTargetState(false);
            //this.AddPlayerSkillCommand(num2, this.m_FightSceneMgr.GetMainTarget());
            //if (!this.m_FightSceneMgr.AddPlayerItemCommand(itemID, target))
            //        {
            //            return;
            //        }
            //        UI_Fight.S_UIFightCommand s_UIFightCommand = default(UI_Fight.S_UIFightCommand);
            //        s_UIFightCommand.id = itemID;
            //        s_UIFightCommand.bSkill = true;
            //        this.m_GCDTimer = this.m_FightSceneMgr.GetControlledPlayerGCD();
        }
        if (data2.emTarget == ENUM_UseTarget.Partner)
        {
            //if (data2.emRange == ENUM_UseRange.All)
            //{
            //    if (data2.DeBuffer.Contains(84))
            //    {
            //        this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetOneDeadRole());
            //    }
            //    else
            //    {
            //        this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
            //    }
            //    return;
            //}
            //if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || this.m_FightSceneMgr.GetRoleList().Count == 1)
            //{
            //    int controlledPlayerRoleID = this.m_FightSceneMgr.GetControlledPlayerRoleID();
            //    if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID))
            //    {
            //        return;
            //    }
            //    this.SetSelectCommandTargetState(false);
            //    this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
            //    return;
            //}
            //else
            //{
            //    this.m_TmpCommandID = num;
            //    this.SetSelectCommandTargetState(true);
            //    this.m_emMenuState = UI_Fight.ENUM_MenuState.UseSkillTarget;
            //}
        }
        if (data2.emTarget == ENUM_UseTarget.Self)
        {
            //int controlledPlayerRoleID2 = this.m_FightSceneMgr.GetControlledPlayerRoleID();
            //if (!this.m_RoleSlotTable.ContainsKey(controlledPlayerRoleID2))
            //{
            //    return;
            //}
            //this.SetSelectCommandTargetState(false);
            //this.AddPlayerSkillCommand(num, this.m_FightSceneMgr.GetControlledPlayer());
        }
    }
}
