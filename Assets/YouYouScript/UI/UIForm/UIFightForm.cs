using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 战斗面板
/// </summary>
public class UIFightForm : UIFormBase
{
    /// <summary>
    /// 设置选择角色
    /// </summary>
    public void SetControlledRole(M_Player newControlledRole)
    {
        //if (this.m_ControlledRoleSlot == null)
        //{
        //    return;
        //}
        //if (this.m_ControlledRoleSlot.GetRoleID() == newControlledRole.m_RoleID)
        //{
        //    return;
        //}
        //int slotIdx = this.m_ControlledRoleSlot.GetSlotIdx();
        //if (slotIdx < 0)
        //{
        //    this.SetTargetRoleSlot(newControlledRole);
        //    return;
        //}
        //int roleID = this.m_ControlledRoleSlot.GetRoleID();
        //if (roleID > 0)
        //{
        //    this.SetUnitRoleSlot(slotIdx, this.m_FightSceneMgr.GetRole(roleID));
        //}
        //this.SetTargetRoleSlot(newControlledRole);
        //this.m_ControlledRoleSlot.PlayTween();
        //this.m_RoleSlots[slotIdx].PlayTween();
    }
}
