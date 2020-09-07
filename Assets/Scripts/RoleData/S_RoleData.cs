using System;
using System.Collections.Generic;

/// <summary>
/// ½ÇÉ«Êý¾Ý
/// </summary>
public class S_RoleData
{
	public S_BaseRoleData BaseRoleData;

	public S_RoleAttr RoleAttr;

	public List<S_BuffInfo> BuffSlot;

	public S_RoleData()
	{
		this.BaseRoleData = new S_BaseRoleData();
		this.RoleAttr = new S_RoleAttr();
		this.BuffSlot = new List<S_BuffInfo>();
		this.BaseRoleData.init();
	}
}
