using System;

/// <summary>
/// ½ÇÉ«ÊôÐÔ
/// </summary>
public class S_RoleAttr
{
	public S_RoleAttr_Plus sAttrPlus;

	public S_RoleAttr_Finial sFinial;

	public S_RoleAttr()
	{
		this.sAttrPlus = new S_RoleAttr_Plus();
		this.sFinial = new S_RoleAttr_Finial();
	}
}
