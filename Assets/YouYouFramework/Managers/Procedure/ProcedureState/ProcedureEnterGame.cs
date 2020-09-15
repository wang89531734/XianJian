using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 进入游戏流程
    /// </summary>
    public class ProcedureEnterGame : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("OnEnter Procedure主城UI");
            //this.gameApplication.m_ExploreSystem.LockPlayer = true;
            //if (this.gameApplication.m_ExploreSystem.PlayerController)
            //{
            //    this.gameApplication.m_ExploreSystem.PlayerController.StopMoveToTarget();
            //}
            //this.gameApplication.m_ExploreSystem.EnableMainCamera(false);
            //UI_GameMainMenu.Instance.Open();
            //GameMenuSystem.Instance.Begin();
            //UI_BubbleDialog.Instance.Close();
            //SkyManager skyManager = SkyManager.Get();
            //if (skyManager != null)
            //{
            //    this.m_CurrentSky = skyManager.GlobalSky;
            //    skyManager.BlendToGlobalSky(this.gameApplication.m_MainMenuSky, 0f);
            //}
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            Debug.Log("OnLeave ProcedureEnterGame");
            //Swd6Application.instance.m_ExploreSystem.EnableMainCamera(true);
            //GameMenuSystem.Instance.End();
            //UI_GameMainMenu.Instance.Close();
            //SkyManager skyManager = SkyManager.Get();
            //if (skyManager != null)
            //{
            //    skyManager.BlendToGlobalSky(this.m_CurrentSky, 0f);
            //}
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}