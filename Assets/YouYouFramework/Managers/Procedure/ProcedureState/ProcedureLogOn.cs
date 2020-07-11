using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 登录流程
    /// </summary>
    public class ProcedureLogOn : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureLogOn");
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.EnterProcedureLogOn);
            Debug.Log("加载主菜单UI");
            GameEntry.UI.OpenUIForm(101);
        }

        private void OnLogonBGOpen(UIFormBase uiFormBase)
        {
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.CloseCheckVersionUI);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureLogOn");
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LeaveProcedureLogOn);
            GameEntry.UI.CloseUIForm(101);
        }
    }
}