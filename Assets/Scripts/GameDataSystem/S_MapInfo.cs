using System;

[Serializable]
public struct S_MapInfo
{
	public int MapID;

	public int ChangeMapID;

	public int OrgMapID;

	public float OrgMapPosX;

	public float OrgMapPosY;

	public float OrgMapPosZ;

	public float OrgMapDir;

	public void Clear()
	{
		this.MapID = 0;
		this.ChangeMapID = 0;
		this.OrgMapID = 0;
		this.OrgMapPosX = 0f;
		this.OrgMapPosY = 0f;
		this.OrgMapPosZ = 0f;
		this.OrgMapDir = 0f;
	}
}
