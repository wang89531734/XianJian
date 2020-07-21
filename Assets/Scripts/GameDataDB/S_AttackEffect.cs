using System;
using System.Collections.Generic;
using UnityEngine;

public class S_AttackEffect : I_BaseDBF
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

	public string GoAnim;

	public S_EffectSetting GoEffectSetting;

	public int GoEffectDelayTime;

	public string GoMusic;

	public int GoMusicDelayTime;

	public string GoEffectMusic;

	public int GoEffectMusicDelayTime;

	public string Attack_1_Anim;

	public S_EffectSetting Attack_1_EffectSetting;

	public int Attack_1_EffectDelayTime;

	public string Attack_1_Music;

	public int Attack_1_MusicDelayTime;

	public string Attack_1_EffectMusic;

	public int Attack_1_EffectMusicDelayTime;

	public S_EffectSetting Attack_1_BulletEffectSetting;

	public int Attack_1_BulletEffectDelayTime;

	public int Attack_1_BulletEffectMoveTime;

	public string Attack_1_BulletMusic;

	public ENUM_BulletType Attack_1_BulletType;

	public S_EffectSetting Attack_1_HitEffectSetting;

	public int Attack_1_HitEffectDelayTime;

	public string Attack_1_HitMusic;

	public string Attack_2_Anim;

	public S_EffectSetting Attack_2_EffectSetting;

	public int Attack_2_EffectDelayTime;

	public string Attack_2_Music;

	public int Attack_2_MusicDelayTime;

	public string Attack_2_EffectMusic;

	public int Attack_2_EffectMusicDelayTime;

	public S_EffectSetting Attack_2_BulletEffectSetting;

	public int Attack_2_BulletEffectDelayTime;

	public int Attack_2_BulletEffectMoveTime;

	public string Attack_2_BulletMusic;

	public ENUM_BulletType Attack_2_BulletType;

	public S_EffectSetting Attack_2_HitEffectSetting;

	public int Attack_2_HitEffectDelayTime;

	public string Attack_2_HitMusic;

	public string Attack_3_Anim;

	public S_EffectSetting Attack_3_EffectSetting;

	public int Attack_3_EffectDelayTime;

	public string Attack_3_Music;

	public int Attack_3_MusicDelayTime;

	public string Attack_3_EffectMusic;

	public int Attack_3_EffectMusicDelayTime;

	public S_EffectSetting Attack_3_BulletEffectSetting;

	public int Attack_3_BulletEffectDelayTime;

	public int Attack_3_BulletEffectMoveTime;

	public string Attack_3_BulletMusic;

	public ENUM_BulletType Attack_3_BulletType;

	public S_EffectSetting Attack_3_HitEffectSetting;

	public int Attack_3_HitEffectDelayTime;

	public string Attack_3_HitMusic;

	public string BackAnim;

	public S_EffectSetting BackEffectSetting;

	public int BackEffectDelayTime;

	public string BackMusic;

	public int BackMusicDelayTime;

	public string BackEffectMusic;

	public int BackEffectMusicDelayTime;

	public string FinishAnim;

	public S_EffectSetting FinishEffectSetting;

	public int FinishEffectDelayTime;

	public string FinishMusic;

	public int FinishMusicDelayTime;

	public string FinishEffectMusic;

	public int FinishEffectMusicDelayTime;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		if (!(Record is S_AttackEffect))
		{
			return;
		}
		Dictionary<string, string> jsonData = Converter.deserializeObject<Dictionary<string, string>>(JsonString);
		this.GetEffectSetting(Converter, jsonData, "StartEffect", ref this.StartEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "GoEffect", ref this.GoEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_1_Effect", ref this.Attack_1_EffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_1_BulletEffect", ref this.Attack_1_BulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_1_HitEffect", ref this.Attack_1_HitEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_2_Effect", ref this.Attack_2_EffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_2_BulletEffect", ref this.Attack_2_BulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_2_HitEffect", ref this.Attack_2_HitEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_3_Effect", ref this.Attack_3_EffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_3_BulletEffect", ref this.Attack_3_BulletEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "Attack_3_HitEffect", ref this.Attack_3_HitEffectSetting);
		this.GetEffectSetting(Converter, jsonData, "BackEffect", ref this.BackEffectSetting);
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
		effectName = this.GetEffectName(this.GoEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_1_EffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_1_BulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_1_HitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_2_EffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_2_BulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_2_HitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_3_EffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_3_BulletEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.Attack_3_HitEffectSetting);
		if (effectName != null)
		{
			EffectResourceNames.Add(effectName);
		}
		effectName = this.GetEffectName(this.BackEffectSetting);
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
