using System;
using System.Text;

public class S_BuffInfo
{
	public int CasterGameObjID;

	public int BuffDBFID;

	public int Timer;

	public int BuffMagicObjID;

	public int FollowMagicObjID;

	public int Param;

	public S_BuffInfo()
	{
		this.Reset();
	}

	public void Reset()
	{
		this.CasterGameObjID = -1;
		this.BuffDBFID = -1;
		this.Timer = 0;
		this.BuffMagicObjID = -1;
		this.FollowMagicObjID = -1;
		this.Param = 0;
	}

	public bool IsEmpty()
	{
		return this.BuffDBFID <= 0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("S_BuffInfo:" + this.BuffDBFID);
		stringBuilder.Append("\n CasterGameObjID:" + this.CasterGameObjID);
		stringBuilder.Append("\n Timer:" + this.Timer);
		stringBuilder.Append("\n BuffMagicObjID:" + this.BuffMagicObjID);
		stringBuilder.Append("\n FollowMagicObjID:" + this.FollowMagicObjID);
		stringBuilder.Append("\n Param:" + this.Param);
		return stringBuilder.ToString();
	}
}
