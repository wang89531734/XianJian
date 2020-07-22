//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 选人流程
    /// </summary>
    public class ProcedureSelectRole : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter SelectRole");
            string a=GameEntry.Procedure.GetData<string>("m_StoryName");
            Debug.Log(a);
            //this.LoadEventPrefab();
            //this.CreateNewStory();
            //this.gameApplication.m_StorySystem.StoryBegin();
            //this.gameApplication.m_UserBehavior.EventInfo.TimeStart(this.m_StoryName, TimerType.Story);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave SelectRole");
            //this.gameApplication.m_UserBehavior.EventInfo.TimeEnd(this.m_StoryName, TimerType.Story);
            //this.gameApplication.m_UserBehavior.EventInfo.TimeEnd();
            //MusicSystem.Instance.StopVoice();
            //MusicSystem.Instance.isPlayingFaceFx = false;
            //this.HideGUI();
            //this.DestroyCurrentStory();
            //this.SetMainCameraEnable(true);
            //if (this.m_MapEvent != null)
            //{
            //    UnityEngine.Object.Destroy(this.m_MapEvent);
            //}
        }
    }
}