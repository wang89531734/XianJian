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
    /// 进入游戏流程
    /// </summary>
    public class ProcedureEnterGame : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("OnEnter Procedure进入游戏流程");
            GameEntry.UI.OpenUIForm(101);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            Debug.Log("OnLeave ProcedureEnterGame");
            GameEntry.UI.CloseUIForm(101);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}