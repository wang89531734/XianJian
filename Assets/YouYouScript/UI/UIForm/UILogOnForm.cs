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
        //PalMain.GameDifficulty = 0;//设置游戏难度
        //SaveManager.GameDifficulty = 0;
        //HPMPDPProperty.StaticData.Reset();
        //FightProperty.StaticData.Reset();
        ////PalMain.backgroundAudio.ChangeBackMusicImmediate(null);
        //this.AfterSetGameDifficulty_NewStart();
        GameEntry.Scene.LoadScene(2, false, () =>
        {
            //level = ScenesManager.CurLoadedLevel;
            //PlayerCtrlManager.OnLevelLoaded(level);
            //PalMain.OnReadySpawn();
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLevelWasLoaded(level);
            //OptionConfig.GetInstance().Use_OnLevelLoaded();
            //OptionConfig.GetInstance().Use_CharacterEmission();
            //MapWatch.Instance.SetMap();
            GameEntry.Procedure.ChangeState(ProcedureState.WorldMap);
        }); 
        //PalMain.GameBeginTime = Time.fixedTime;
        //PalMain.GameTotleTime = 0f;
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
