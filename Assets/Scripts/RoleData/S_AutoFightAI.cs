using System;

[Serializable]
public class S_AutoFightAI
{
	public Enum_AutoFightCommandType[] emCommandType = new Enum_AutoFightCommandType[6];

	public int[] ID = new int[6];

	public int Percent;
}
