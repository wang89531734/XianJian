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
        //private UI_Subtitle m_UI_Subtitle;

        //private UI_Subtitle_FullScreen m_UI_Subtitle_FullScreen;

        private string m_StoryName;

        private GameObject m_CurrentStroyObject;

        private M_StoryBase m_StoryBase;

        private float m_ShadowDistance;

        private bool m_bEnableTextFrameInStory;

        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter SelectRole");
            string a=GameEntry.Procedure.GetData<string>("m_StoryName");
            Debug.Log(a);
            AssetBundle.LoadFromFile(Application.dataPath + "/../assetbundles/Story/" + a + ".unity3d");
            //this.m_bEnableTextFrameInStory = false;//Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting().m_bEnableTextFrameInStory;
            //this.LoadEventPrefab();
            //this.GetGUI();
            this.CreateNewStory();
            //this.SetMainCameraEnable(false);
            GameEntry.Instance.m_StorySystem.StoryBegin();
            //this.m_ShadowDistance = QualitySettings.shadowDistance;
            //QualitySettings.shadowDistance = 50f;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
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
            //MapEventGenerator.GetMapEvent(name);
        }

        public void CreateNewStory()
        {
            //this.HideGUI();
            this.DestroyCurrentStory();
            //this.m_CurrentStroyObject = StoryGenerator.CreateOtherGameObject(this.m_StoryName);
            //if (this.m_CurrentStroyObject == null)
            //{
            //    Debug.LogWarning("m_CurrentStroyObject is null ");
            //    return;
            //}
            //this.m_StoryBase = this.m_CurrentStroyObject.GetComponent<M_StoryBase>();
            //this.m_StoryBase.Initial();
        }

        private void DestroyCurrentStory()
        {
            this.m_StoryBase = null;
            UnityEngine.Object.DestroyImmediate(this.m_CurrentStroyObject);
            //RenderSettings.ambientLight = GameDefine.AMBIENTLIGHT;
            //MovieSystem.Instance.StopMovie();
            //MusicControlSystem.StopSpeech();
            //MusicControlSystem.FadeStopEnvironmentMusic();
            //MusicControlSystem.StopAllLoopSound();
        }
    }
}