using System;

public class S_CombineSkillEffect : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string MainAnim;

	public string AssistantAnim;

	public string StartEffect;

	public int StartEffectTime;

	public string StartAnimMusic;

	public string StartEffectMusic;

	public string BulletEffect;

	public int BulletEffectTime;

	public string BulletEffectMusic;

	public string HitEffect;

	public int HitEffectTime;

	public string HitEffectMusic;

	public int HitDelayTime;

	public int ShakeStartTime;

	public int ShakeEndTime;

	public string SkyBoxName;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
