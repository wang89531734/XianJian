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
        //GameEntry.Instance.StartNewGame();
        //GameEntry.Scene.LoadScene(2, false, () =>
        //{
        //    GameEntry.Procedure.ChangeState(ProcedureState.WorldMap);
        //});




        string path = Application.dataPath + "/../assetbundles/Scene/MAP01.unity3d";
        AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
        if (assetBundle != null)
        {
            UnityEngine.Object mainAsset = assetBundle.LoadAsset("BuildPlayer-MAP01");
    
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("BuildPlayer-MAP01", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }







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
