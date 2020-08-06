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
        private string m_StoryName;

        private GameObject m_CurrentStroyObject;

        private GameObject m_MapEvent;

        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter SelectRole");
            m_StoryName = GameEntry.Procedure.GetData<string>("m_StoryName");
            this.LoadEventPrefab();
            this.CreateNewStory();           
        }

        public override void OnUpdate()
        {
            base.OnUpdate();//剧情回顾的时候有用
            //if (Swd6Application.instance.m_StorySystem.IsReviewStory() && GameInput.IsPressKeyboardCancelKey() && this.m_StoryBase != null && !this.m_StoryBase.isFinish)
            //{
            //    this.m_StoryBase.ProcessFinishEvent();
            //}
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave SelectRole");
            //this.HideGUI();
            //this.DestroyCurrentStory();
            //this.SetMainCameraEnable(true);
            //Swd6Application.instance.m_StorySystem.StoryEnd();
            //QualitySettings.shadowDistance = this.m_ShadowDistance;
            //Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting().m_bEnableTextFrameInStory = this.m_bEnableTextFrameInStory;
            //Swd6Application.instance.ClearResourceSystem();
            //Resources.UnloadUnusedAssets();
        }

        public void LoadEventPrefab()
        {
            S_MapData mapData = GameEntry.Instance.m_GameDataSystem.GetMapData(GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID);
            if (mapData == null)
            {
                return;
            }
            string name = mapData.Name + "_Event_3";
            this.m_MapEvent = ResourcesManager.Instance.GetMapEvent(name);
        }

        public void CreateNewStory()
        {
            this.SetMainCameraEnable(false);
            //this.HideGUI();
            //this.DestroyCurrentStory();
            //ResourcesManager.Instance.Clear_Story();
            //ResourcesManager.Instance.Clear_Fight();
            //Resources.UnloadUnusedAssets();
            this.m_CurrentStroyObject = ResourcesManager.Instance.GetStory(this.m_StoryName);
            if (this.m_CurrentStroyObject == null)
            {
                Debug.LogWarning("m_CurrentStroyObject is null ");
                return;
            }
        }

        private void DestroyCurrentStory()
        {
            UnityEngine.Object.DestroyImmediate(this.m_CurrentStroyObject);
            //MovieSystem.Instance.StopMovie();
            //MusicSystem.Instance.StopVoice();
            //MusicSystem.Instance.FadeStopEnvironmentMusic();
            //MusicSystem.Instance.StopAllLoopSound();
        }

        private void SetMainCameraEnable(bool isEnable)
        {
            GameObject gameObject = GameObject.Find("Main Camera");
            if (gameObject == null)
            {
                gameObject = GameObject.FindWithTag("MainCamera");
            }
            if (gameObject)
            {
                Camera component = gameObject.GetComponent<Camera>();
                if (component)
                {
                    component.enabled = isEnable;
                }
                AudioListener component2 = gameObject.GetComponent<AudioListener>();
                if (component2)
                {
                    UnityEngine.Object.Destroy(component2);
                }
            }
            GameObject playerObj = GameEntry.Instance.m_GameObjSystem.PlayerObj;
            if (playerObj)
            {
                AudioListener component3 = playerObj.GetComponent<AudioListener>();
                if (component3)
                {
                    component3.enabled = isEnable;
                }
            }
        }
    }
}