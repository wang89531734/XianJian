//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 流程基类
    /// </summary>
    public class ProcedureBase : FsmState<ProcedureManager>
    {
        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnLeave()
        {

        }

        public override void OnDestroy()
        {

        }

        public override void Pause()
        {
            Time.timeScale = 0f;
            GameEntry.isPause = true;
        }

        public override void ReStart()
        {
            Time.timeScale = 1f;
            GameEntry.isPause = false;
        }
    }
}