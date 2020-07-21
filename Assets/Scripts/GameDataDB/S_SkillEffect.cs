using System;
using System.Collections.Generic;
using UnityEngine;

public class S_SkillEffect : I_BaseDBF
{
	public int GUID;

	public string Name;

	public string StartAnim;

	public S_EffectSetting StartEffectSetting;

	public int StartEffectDelayTime;

	public string StartMusic;

	public int StartMusicDelayTime;

	public string StartEffectMusic;

	public int StartEffectMusicDelayTime;

	public string CastAnim;

	public int CastTime;

	public S_EffectSetting CastEffectSetting;

	public int CastEffectKeepTime;

	public string CastMusic;

	public int CastMusicDelayTime;

	public string CastEffectMusic;

	public int CastEffectMusicDelayTime;

	public string AttackAnim;

	public S_EffectSetting AttackEffectSetting;

	public int AttackEffectDelayTime;

	public string AttackMusic;

	public int AttackMusicDelayTime;

	public string AttackEffectMusic;

	public int AttackEffectMusicDelayTime;

	public S_EffectSetting BulletEffectSetting;

	public int BulletEffectDelayTime;

	public int BulletEffectMoveTime;

	public string BulletMusic;

	public ENUM_BulletType BulletType;

	public S_EffectSetting HitEffectSetting;

	public int HitEffectDelayTime;

	public ENUM_HitEffectType HitEffectType;

	public string HitMusic;

	public int SkillCameraPathID;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_SkillEffect))
		{
			return;
		}
		Dictionary<string, string> jsonData = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		this.GetEffectSetting(Converter, jsonData, "StartEffect", ref this.StartEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "CastEffect", ref this.CastEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "AttackEffect", ref this.AttackEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "BulletEffect", ref this.BulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "HitEffect", ref this.HitEffectSetting);
	}

	private void GetEffectSetting(IConverter Converter, Dictionary<string, string> JsonData, string SourceKeyName, ref S_EffectSetting EffectSetting)
	{
		if (!JsonData.ContainsKey(SourceKeyName))
		{
			return;
		}
		string text = JsonData[SourceKeyName];
		if (text == null || text.Length == 0)
		{
			return;
		}
		if (text[0] != '{' || text[text.Length - 1] != '}')
		{
			Debug.LogWarning(string.Concat(new string[]
			{
				"以[",
				SourceKeyName,
				"]所取得的值非JsonCode編碼[",
				text,
				"]"
			}));
			return;
		}
		EffectSetting = Converter.deserializeObject<S_EffectSetting>(text);
	}

	public void GetEffectResourceName(List<string> EffectResourceNames)
	{
		string effectName = this.GetEffectName(this.StartEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.CastEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.AttackEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.BulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.HitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
	}

	private string GetEffectName(S_EffectSetting EffectSetting)
	{
		if (EffectSetting.EffectName == null || EffectSetting.EffectName.Length == 0)
		{
			return null;
		}
		return EffectSetting.EffectName;
	}
}
