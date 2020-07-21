using System;

public class S_SkillCameraPath : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string ShootCameraPathName;

	public int ShootCameraPathTime;

	public int ShootShakeStartTime;

	public int ShootShakeEndTime;

	public int ShootSlowStartTime;

	public int ShootSlowEndTime;

	public float ShootSlowTimeScale;

	public int ShootSlowStartTime2;

	public int ShootSlowEndTime2;

	public float ShootSlowTimeScale2;

	public int ShootSlowStartTime3;

	public int ShootSlowEndTime3;

	public float ShootSlowTimeScale3;

	public string HitCameraPathName;

	public int HitCameraPathTime;

	public int HitShakeStartTime;

	public int HitShakeEndTime;

	public int HitSlowStartTime;

	public int HitSlowEndTime;

	public float HitSlowTimeScale;

	public string SkyBoxName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
