using System;
using System.Collections.Generic;
using UnityEngine;

public class S_SuperSkillEffect : I_BaseDBF
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

	public string FirstAnim;

	public S_EffectSetting FirstEffectSetting;

	public int FirstEffectDelayTime;

	public string FirstMusic;

	public int FirstMusicDelayTime;

	public string FirstEffectMusic;

	public int FirstEffectMusicDelayTime;

	public S_EffectSetting FirstBulletEffectSetting;

	public int FirstBulletEffectDelayTime;

	public int FirstBulletEffectMoveTime;

	public string FirstBulletMusic;

	public ENUM_BulletType FirstBulletType;

	public S_EffectSetting FirstHitEffectSetting;

	public int FirstHitEffectDelayTime;

	public ENUM_HitEffectType FirstHitEffectType;

	public string FirstHitMusic;

	public string SecondAnim;

	public S_EffectSetting SecondEffectSetting;

	public int SecondEffectDelayTime;

	public string SecondMusic;

	public int SecondMusicDelayTime;

	public string SecondEffectMusic;

	public int SecondEffectMusicDelayTime;

	public S_EffectSetting SecondBulletEffectSetting;

	public int SecondBulletEffectDelayTime;

	public int SecondBulletEffectMoveTime;

	public string SecondBulletMusic;

	public ENUM_BulletType SecondBulletType;

	public S_EffectSetting SecondHitEffectSetting;

	public int SecondHitEffectDelayTime;

	public ENUM_HitEffectType SecondHitEffectType;

	public string SecondHitMusic;

	public string FinishAnim;

	public S_EffectSetting FinishEffectSetting;

	public int FinishEffectDelayTime;

	public string FinishMusic;

	public int FinishMusicDelayTime;

	public string FinishEffectMusic;

	public int FinishEffectMusicDelayTime;

	public int SkillCameraPathID;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_SuperSkillEffect))
		{
			return;
		}
		Dictionary<string, string> jsonData = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		this.GetEffectSetting(Converter, jsonData, "StartEffect", ref this.StartEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "FirstEffect", ref this.FirstEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "FirstBulletEffect", ref this.FirstBulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "FirstHitEffect", ref this.FirstHitEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "SecondEffect", ref this.SecondEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "SecondBulletEffect", ref this.SecondBulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "SecondHitEffect", ref this.SecondHitEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "FinishEffect", ref this.FinishEffectSetting);
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
		effectName = this.GetEffectName(this.FirstEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.FirstBulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.FirstHitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.SecondEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.SecondBulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.SecondHitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.FinishEffectSetting);
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
