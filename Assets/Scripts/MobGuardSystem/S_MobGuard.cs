using System;

[Serializable]
public class S_MobGuard
{
	public int ID;

	public int[] AI;

	public S_MobGuard()
	{
		this.AI = new int[5];
	}
}
