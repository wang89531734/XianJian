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
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");
            Debug.Log("加载角色");
            Debug.Log("显示主UI");
            //this.m_FightSceneManager = new FightSceneManager(this);
            //this.m_FightCommandManager = new FightCommandManager(this);
            //this.m_FightCommandFactory = new FightCommandFactory();
            //this.m_FightScoreManager = new FightScoreManager();
            //this.m_FightCommandTemp = new FightCommandTemp();
            //this.m_AISystem = new AISystem(this);
            //this.m_BuffSystem = new BuffSystem(this);
            //UI_Fight.Instance.m_FightState = this;
            //UI_Fight.Instance.m_FightSceneManager = this.m_FightSceneManager;
            //UI_Fight.Instance.m_FightCommandFactory = this.m_FightCommandFactory;
            //UI_Fight.Instance.m_FightCommandTemp = this.m_FightCommandTemp;
            //UI_FinishFight.Instance.m_FightSceneManager = this.m_FightSceneManager;
            //UI_FinishFight.Instance.LoadGUI();
            //UI_Fight.Instance.LoadGUI();
            //this.InitFightSubStates();
            //this.SetMainCameraEnable(false);
            //this.ChangeSubState(FightState.SubState.Appearence);
            //this.ChangeAmbientLight();
            //CameraControlSystem.FadeTo(0f, 1f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //if (this.m_CurrentFightSubState == null)
            //{
            //    return;
            //}
            //this.m_CurrentFightSubState.Update();
            //if (this.m_FightSceneManager.IsFightFinish() && this.m_CurrentFightSubState.m_SubState == FightState.SubState.Normal)
            //{
            //    if (this.m_FightSceneManager.fightStoryMode == Enum_FightStoryMode.None)
            //    {
            //        this.ChangeSubState(FightState.SubState.Finish);
            //        return;
            //    }
            //    if (this.m_FightSceneManager.fightStoryMode == Enum_FightStoryMode.ProcessWin && this.m_FightSceneManager.IsAllPlayerDead())
            //    {
            //        this.ChangeSubState(FightState.SubState.Finish);
            //    }
            //}
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureWorldMap");
        }
    }
}