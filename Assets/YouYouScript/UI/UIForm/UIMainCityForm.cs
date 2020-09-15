using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 主城UI
/// </summary>
public class UIMainCityForm : UIFormBase
{
    public void OnMainMenuBtnClick()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return;
        }
        Debug.Log("切换到GameMenuState流程 ");
        GameEntry.Procedure.ChangeState(ProcedureState.EnterGame);
        //GameEntry.Instance.m_ExploreSystem.OpenGameMainMenu();
    }
}
