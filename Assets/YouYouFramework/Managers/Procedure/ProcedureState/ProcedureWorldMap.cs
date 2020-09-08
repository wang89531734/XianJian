using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 世界地图流程
    /// </summary>
    public class ProcedureWorldMap : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");
            //if (UI_Explore.Instance != null)
            //{
            //    UI_Explore.Instance.Show();
            //}
            //this.gameApplication.m_StorySystem.StoryEnd();
            GameEntry.Instance.m_ExploreSystem.Begin();
            //if (!Swd6Application.instance.m_ExploreSystem.m_PlayStory && UI_Fade.Instance != null)
            //{
            //    UI_Fade.Instance.DelayFadeTo(0f, 1.5f, 0.3f);
            //}
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            GameEntry.Instance.m_ExploreSystem.Update();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureWorldMap");
            //UI_Explore.Instance.Hide();
            //UI_BubbleDialog.Instance.Close();
            GameEntry.Instance.m_ExploreSystem.End();
        }
    }
}