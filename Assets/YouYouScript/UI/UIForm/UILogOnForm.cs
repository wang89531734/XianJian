using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 登陆面板
/// </summary>
public class UILogOnForm : UIFormBase
{
    private void Start()
    {

    }

    private void EndState_Start()
    {
       
    }

    private void InitState_Start()
    {

    }

    public void OnNewGameBtn()
    {
        GameEntry.Instance.StartNewGame();
        GameEntry.Scene.LoadScene(2, false, () =>
        {
            GameEntry.Procedure.ChangeState(ProcedureState.WorldMap);
        });       
    }

    public void OnLoadBtn()
    {
        //LoadPlane.SetActive(true);
    }

    public void OnSystemBtn()
    {
        //SystemPlane.SetActive(true);
    }

    public void OnLoadbackBtn()
    {
        //LoadPlane.SetActive(false);
    }

    public void OnSystembackBtn()
    {
        //SystemPlane.SetActive(false);
    } 
}
