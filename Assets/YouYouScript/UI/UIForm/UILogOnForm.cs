using SoftStar.Pal6;
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

    public void OnNewGameBtn()
    {
        PalMain.GameDifficulty = 0;//设置游戏难度
        //SaveManager.GameDifficulty = 0;
        //HPMPDPProperty.StaticData.Reset();
        //FightProperty.StaticData.Reset();
        //PalMain.backgroundAudio.ChangeBackMusicImmediate(null);
        this.AfterSetGameDifficulty_NewStart();
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

    public void AfterSetGameDifficulty_NewStart()
    {
        if (PlayerTeam.Instance != null)
        {
            PlayerTeam.Instance.LoadTeam();
        }
        PalMain.GameBeginTime = Time.fixedTime;
        PalMain.GameTotleTime = 0f;
        PalMain.ChangeMap("SceneEnter", 1, true, true);
    }
}
