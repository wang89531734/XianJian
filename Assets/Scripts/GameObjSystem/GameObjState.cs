using System;

public class GameObjState
{
	private ENUM_GameObjFlag m_ObjFlag;

	public bool Disable
	{
		get
		{
			return this.Test(ENUM_GameObjFlag.Disable);
		}
		set
		{
			if (value)
			{
				this.Set(ENUM_GameObjFlag.Disable);
				return;
			}
			this.Reset(ENUM_GameObjFlag.Disable);
		}
	}

	public void Set(ENUM_GameObjFlag state)
	{
		this.m_ObjFlag |= state;
	}

	public void Set(ENUM_GameObjFlag state, bool isON)
	{
		if (isON)
		{
			this.m_ObjFlag |= state;
			return;
		}
		this.m_ObjFlag &= ~state;
	}

	public ENUM_GameObjFlag Get()
	{
		return this.m_ObjFlag;
	}

	public void Reset(ENUM_GameObjFlag state)
	{
		this.m_ObjFlag &= ~state;
	}

	public bool Test(ENUM_GameObjFlag state)
	{
		return (this.m_ObjFlag & state) == state;
	}

	public void Clear()
	{
		this.m_ObjFlag = ENUM_GameObjFlag.None;
	}
}
