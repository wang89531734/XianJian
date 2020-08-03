using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActData : ScriptableObject
{
	public float m_TotalTime = 5f;

	public int m_HitTimes;

	public bool m_UseSpecialHitEvent;

	//public List<ActAnimClip> m_AnimationEvents = new List<ActAnimClip>();

	//public List<ActEffectClip> m_EffectEvents = new List<ActEffectClip>();

	//public List<ActSoundClip> m_SoundEvents = new List<ActSoundClip>();

	//public List<ActHitClip> m_HitEvents = new List<ActHitClip>();

	public void Reset()
	{
		//for (int i = 0; i < this.m_AnimationEvents.Count; i++)
		//{
		//	this.m_AnimationEvents[i].isDone = false;
		//}
		//for (int j = 0; j < this.m_EffectEvents.Count; j++)
		//{
		//	this.m_EffectEvents[j].isDone = false;
		//}
		//for (int k = 0; k < this.m_SoundEvents.Count; k++)
		//{
		//	this.m_SoundEvents[k].isDone = false;
		//}
		//for (int l = 0; l < this.m_HitEvents.Count; l++)
		//{
		//	this.m_HitEvents[l].isDone = false;
		//}
	}

	public void ClearAsset()
	{
		//for (int i = 0; i < this.m_AnimationEvents.Count; i++)
		//{
		//	this.m_AnimationEvents[i].ClearAsset();
		//}
		//for (int j = 0; j < this.m_EffectEvents.Count; j++)
		//{
		//	this.m_EffectEvents[j].ClearAsset();
		//}
		//for (int k = 0; k < this.m_SoundEvents.Count; k++)
		//{
		//	this.m_SoundEvents[k].ClearAsset();
		//}
		//for (int l = 0; l < this.m_HitEvents.Count; l++)
		//{
		//	this.m_HitEvents[l].ClearAsset();
		//}
	}

	//public ActAnimClip AddAnimEvent(float startTime)
	//{
	//	ActAnimClip actAnimClip = new ActAnimClip();
	//	actAnimClip.startTime = startTime;
	//	this.m_AnimationEvents.Add(actAnimClip);
	//	SortAnimationEvents comparer = new SortAnimationEvents();
	//	this.m_AnimationEvents.Sort(comparer);
	//	return actAnimClip;
	//}

	//public ActEffectClip AddEffectEvent(float startTime)
	//{
	//	ActEffectClip actEffectClip = new ActEffectClip();
	//	actEffectClip.startTime = startTime;
	//	this.m_EffectEvents.Add(actEffectClip);
	//	SortEffectEvents comparer = new SortEffectEvents();
	//	this.m_EffectEvents.Sort(comparer);
	//	return actEffectClip;
	//}

	//public ActSoundClip AddSoundEvent(float startTime)
	//{
	//	ActSoundClip actSoundClip = new ActSoundClip();
	//	actSoundClip.startTime = startTime;
	//	this.m_SoundEvents.Add(actSoundClip);
	//	SortSoundEvents comparer = new SortSoundEvents();
	//	this.m_SoundEvents.Sort(comparer);
	//	return actSoundClip;
	//}

	//public ActHitClip AddGameDesignEvent(float startTime)
	//{
	//	ActHitClip actHitClip = new ActHitClip();
	//	actHitClip.startTime = startTime;
	//	this.m_HitEvents.Add(actHitClip);
	//	SortGameDesignEvents comparer = new SortGameDesignEvents();
	//	this.m_HitEvents.Sort(comparer);
	//	return actHitClip;
	//}

	public void CountHitTimes()
	{
		this.m_HitTimes = 0;
		//for (int i = 0; i < this.m_EffectEvents.Count; i++)
		//{
		//	if (this.m_EffectEvents[i].effectType == ActEffectClip.EffectType.Hit && this.m_EffectEvents[i].hitDamage)
		//	{
		//		this.m_HitTimes++;
		//	}
		//}
	}
}
