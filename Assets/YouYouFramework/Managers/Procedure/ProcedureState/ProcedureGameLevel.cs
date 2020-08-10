using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 游戏关卡流程
    /// </summary>
    public class ProcedureGameLevel : ProcedureBase
    {
        public FightSceneManager m_FightSceneMgr;

        //public BuffSystem m_BuffSystem;

        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");
            //this.m_BuffSystem = FightSystem.Instance.m_BuffSystem;
            this.m_FightSceneMgr = new FightSceneManager();
            this.m_FightSceneMgr.m_FihgtState = this;
            //this.m_FightSceneMgr.m_BuffSystem = this.m_BuffSystem;
            //UI_Fade.Instance.FadeTo(0f, 1f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            this.m_FightSceneMgr.Update();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureWorldMap");
            //this.m_FightSceneMgr.ClearFightObjs();
            //UI_Fight.Instance.Hide();
            //UI_FinishFight.Instance.Hide();
            //UI_TalkDialog.Instance.Close();
            //UI_GameGMFightStatistics.Instance.Hide();
            //if (UI_FinishFight.Instance.m_bWin && Swd6Application.instance != null && Swd6Application.instance.m_ExploreSystem.PlayerController != null)
            //{
            //    Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(1, 0f);
            //}
            //this.gameApplication.m_UserBehavior.EventInfo.TimeEnd(FightSystem.Instance.m_BattleGroupID, TimerType.Battle);
        }
    }
}