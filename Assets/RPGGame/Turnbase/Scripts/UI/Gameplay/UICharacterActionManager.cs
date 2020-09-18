using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UICharacterActionManager : UIBase
{
    public UICharacterAction[] uiActions;
    public FightSceneManager Manager;
    private readonly List<UICharacterAction> UICharacterSkills = new List<UICharacterAction>();

    private ToggleGroup tempToggleGroup;
    public ToggleGroup TempToggleGroup
    {
        get
        {
            if (tempToggleGroup == null)
                tempToggleGroup = GetComponent<ToggleGroup>();
            return tempToggleGroup;
        }
    }

    public M_Character ActiveCharacter
    {
        get { return Manager.ActiveCharacter; }
    }

    public bool IsPlayerCharacterActive
    {
        get { return ActiveCharacter != null; }// && ActiveCharacter.IsPlayerCharacter;
    }

    protected override void Awake()
    {
        base.Awake();
        //TempToggleGroup.allowSwitchOff = false;
        var skillIndex = 0;
        //foreach (var uiAction in uiActions)
        //{
        //    uiAction.ActionManager = this;
        //    uiAction.IsOn = false;
        //    var uiSkill = uiAction as UICharacterActionSkill;
        //    if (uiSkill != null)
        //    {
        //        uiSkill.skillIndex = skillIndex;
        //        UICharacterSkills.Add(uiSkill);
        //        ++skillIndex;
        //    }
        //}
    }

    private void Update()
    {
        //if (!IsPlayerCharacterActive || ActiveCharacter.IsDoingAction)
        //{
        //    Hide();
        //    return;
        //}

        //var i = 0;
        //foreach (var skill in Manager.ActiveCharacter.Skills)
        //{
        //    if (i >= UICharacterSkills.Count)
        //        break;
        //    var ui = UICharacterSkills[i];
        //    ui.skill = skill as CharacterSkill;
        //    ui.Show();
        //    ++i;
        //}
        //for (; i < UICharacterSkills.Count; ++i)
        //{
        //    var ui = UICharacterSkills[i];
        //    ui.Hide();
        //}
    }

    public override void Show()
    {
        Debug.Log("根据角色数据加载技能");
        List<FightSkillHotKeyInfo> controlledPlayerSkillList = GameEntry.Instance.m_SkillSystem.GetFightSkillHotkeyList(1, 0);

        uiActions[0].skillIndex = controlledPlayerSkillList[0].ID;
        uiActions[1].skillIndex = controlledPlayerSkillList[1].ID;
        uiActions[2].skillIndex = controlledPlayerSkillList[2].ID;
        //var i = 0;
        //for (i = 0; i < uiActions.Length; ++i)
        //{
        //    uiActions[i].IsOn = false;
        //    if (i == 0)
        //        uiActions[i].IsOn = true;
        //}
        //i = 0;
        //for (; i < UICharacterSkills.Count; ++i)
        //{
        //    var ui = UICharacterSkills[i];
        //    ui.Hide();
        //}
        base.Show();
    }
}
