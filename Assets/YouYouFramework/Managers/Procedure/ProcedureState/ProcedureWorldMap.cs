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
    /// 世界地图流程
    /// </summary>
    public class ProcedureWorldMap : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.EnterProcedureLogOn);

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