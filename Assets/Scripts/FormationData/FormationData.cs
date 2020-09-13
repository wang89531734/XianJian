using System;
using System.Collections.Generic;

public class FormationData
{
	public int LeaderID;

	public int ControllerID;

	public int MobID;

	public bool Enable;

	public ENUM_ElementType emElement;

    /// <summary>
    /// µ¥Î»
    /// </summary>
	public List<FormationUnit> Unit = new List<FormationUnit>();
}
