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
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.EnterProcedureWorldMap);
            Debug.Log("加载角色");
            //GameEntry.Role.CreatePlayer();
            PlayerTeam.Instance.LoadTeam();
            PlayerCtrlManager.OnLevelLoaded(1);
            PlayerCtrlManager.OnInit();
            //level = ScenesManager.CurLoadedLevel;          
            //PalMain.OnReadySpawn();
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLoadOver = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOver, new EntityManager.void_fun(PalMain.OnLoadOver));
            //EntityManager.OnLevelWasLoaded(level);
            //OptionConfig.GetInstance().Use_OnLevelLoaded();
            //OptionConfig.GetInstance().Use_CharacterEmission();
            //MapWatch.Instance.SetMap();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureWorldMap");
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LeaveProcedureLogOn);
        }
    }
}