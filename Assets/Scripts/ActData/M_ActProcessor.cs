using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class M_ActProcessor : MonoBehaviour
{
	public delegate void AnimationEventTrigger(string animName);

	public delegate void ShootEffectEventTrigger(string effectName, string refPoint, Vector3 pos, bool follow, bool rotate);

	public delegate void HitEffectEventTrigger(string effectName, string refPoint, bool follow, bool rotate);

	public delegate void BulletEffectEventTrigger(string effectName, string refPoint, Vector3 bulletPos, bool follow, float speed, string hitActDataName);

	public delegate void SoundEventTrigger(string soundName);

	public delegate void ActEventTrigger(string actDataName);

	public delegate void EventTrigger();

	public ActData m_ActData;

	private float m_CurrentTime;

	public M_ActProcessor.ActEventTrigger OnCallActData;

	public M_ActProcessor.EventTrigger OnWeaponTrail_ON;

	public M_ActProcessor.EventTrigger OnWeaponTrail_OFF;

	public M_ActProcessor.EventTrigger OnAfterImage;

	public M_ActProcessor.EventTrigger OnHitAnimation;

	public M_ActProcessor.EventTrigger OnHitDamage;

	public M_ActProcessor.EventTrigger OnAnimationFinish;

	public M_ActProcessor.AnimationEventTrigger OnAnimationTrigger;

	public M_ActProcessor.ShootEffectEventTrigger OnShootEffect;

	public M_ActProcessor.BulletEffectEventTrigger OnBulletEffect;

	public M_ActProcessor.HitEffectEventTrigger OnHitEffect_One;

	public M_ActProcessor.HitEffectEventTrigger OnHitEffect_All;

	public M_ActProcessor.SoundEventTrigger OnSoundTrigger;

	private int m_HitTimes;

	public float CurrentTime
	{
		get
		{
			return this.m_CurrentTime;
		}
	}

	private void Start()
	{
		this.m_CurrentTime = 0f;
		//if (this.m_ActData == null)
		//{
		//	return;
		//}
		//if (this.m_ActData.m_AnimationEvents.Count == 0 && this.OnAnimationFinish != null)
		//{
		//	this.OnAnimationFinish();
		//	this.OnAnimationFinish = null;
		//}
	}

	private void Update()
	{
		if (this.m_ActData == null)
		{
			return;
		}
		this.m_CurrentTime += Time.deltaTime;
		//for (int i = 0; i < this.m_ActData.m_AnimationEvents.Count; i++)
		//{
		//	if (!this.m_ActData.m_AnimationEvents[i].isDone)
		//	{
		//		if (this.m_CurrentTime >= this.m_ActData.m_AnimationEvents[i].startTime)
		//		{
		//			this.AnimationTrigger(this.m_ActData.m_AnimationEvents[i]);
		//			if (i == this.m_ActData.m_AnimationEvents.Count - 1)
		//			{
		//				base.StartCoroutine(this.AnimationFinish(this.m_ActData.m_AnimationEvents[i].animationLength));
		//			}
		//		}
		//	}
		//}
		//for (int j = 0; j < this.m_ActData.m_EffectEvents.Count; j++)
		//{
		//	if (!this.m_ActData.m_EffectEvents[j].isDone)
		//	{
		//		if (this.m_CurrentTime >= this.m_ActData.m_EffectEvents[j].startTime)
		//		{
		//			this.EffectTrigger(this.m_ActData.m_EffectEvents[j]);
		//		}
		//	}
		//}
		//for (int k = 0; k < this.m_ActData.m_SoundEvents.Count; k++)
		//{
		//	if (!this.m_ActData.m_SoundEvents[k].isDone)
		//	{
		//		if (this.m_CurrentTime >= this.m_ActData.m_SoundEvents[k].startTime)
		//		{
		//			this.SoundTrigger(this.m_ActData.m_SoundEvents[k]);
		//		}
		//	}
		//}
		//if (this.m_CurrentTime > this.m_ActData.m_TotalTime + 1f)
		//{
		//	this.m_CurrentTime = 0f;
		//	UnityEngine.Object.Destroy(base.gameObject);
		//}
	}

    //[DebuggerHidden]
    //private IEnumerator AnimationFinish(float AnimLength)
    //{
    //	M_ActProcessor.<AnimationFinish>c__Iterator882 <AnimationFinish>c__Iterator = new M_ActProcessor.<AnimationFinish>c__Iterator882();
    //	<AnimationFinish>c__Iterator.AnimLength = AnimLength;
    //	<AnimationFinish>c__Iterator.<$>AnimLength = AnimLength;
    //	<AnimationFinish>c__Iterator.<>f__this = this;
    //	return <AnimationFinish>c__Iterator;
    //}

    //private void AnimationTrigger(ActAnimClip clip)
    //{
    //	if (this.OnAnimationTrigger != null)
    //	{
    //		this.OnAnimationTrigger(clip.animationName);
    //	}
    //	clip.isDone = true;
    //}

    //private void EffectTrigger(ActEffectClip clip)
    //{
    //	switch (clip.effectType)
    //	{
    //	case ActEffectClip.EffectType.Shoot:
    //		if (this.OnShootEffect != null)
    //		{
    //			this.OnShootEffect(clip.effectName, clip.refPoint.ToString(), clip.bulletPosition, clip.follow, clip.setRotation);
    //		}
    //		break;
    //	case ActEffectClip.EffectType.Bullet:
    //		if (this.OnBulletEffect != null)
    //		{
    //			this.OnBulletEffect(clip.effectName, clip.refPoint.ToString(), clip.bulletPosition, clip.follow, clip.speed, clip.hitActDataName);
    //		}
    //		break;
    //	case ActEffectClip.EffectType.Hit:
    //		if (clip.hitType == ActEffectClip.HitEffectType.OnlyOne)
    //		{
    //			if (this.OnHitEffect_One != null)
    //			{
    //				this.OnHitEffect_One(clip.effectName, clip.refPoint.ToString(), clip.follow, clip.setRotation);
    //			}
    //		}
    //		else if (this.OnHitEffect_All != null)
    //		{
    //			this.OnHitEffect_All(clip.effectName, clip.refPoint.ToString(), clip.follow, clip.setRotation);
    //		}
    //		if (clip.hitAnimation && this.OnHitAnimation != null)
    //		{
    //			this.OnHitAnimation();
    //		}
    //		if (clip.hitDamage && this.OnHitDamage != null)
    //		{
    //			this.OnHitDamage();
    //		}
    //		break;
    //	case ActEffectClip.EffectType.Trail_On:
    //		if (this.OnWeaponTrail_ON != null)
    //		{
    //			this.OnWeaponTrail_ON();
    //		}
    //		break;
    //	case ActEffectClip.EffectType.Trail_Off:
    //		if (this.OnWeaponTrail_OFF != null)
    //		{
    //			this.OnWeaponTrail_OFF();
    //		}
    //		break;
    //	case ActEffectClip.EffectType.AfterImage:
    //		if (this.OnAfterImage != null)
    //		{
    //			this.OnAfterImage();
    //		}
    //		break;
    //	case ActEffectClip.EffectType.CallActData:
    //		if (this.OnCallActData != null)
    //		{
    //			this.OnCallActData(clip.hitActDataName);
    //		}
    //		break;
    //	}
    //	clip.isDone = true;
    //}

    //private void SoundTrigger(ActSoundClip clip)
    //{
    //	if (this.OnSoundTrigger != null)
    //	{
    //		this.OnSoundTrigger(clip.soundName);
    //	}
    //	clip.isDone = true;
    //}

    public int GetHitTimes()
    {
        //this.m_HitTimes += this.m_ActData.m_HitTimes;
        //for (int i = 0; i < this.m_ActData.m_EffectEvents.Count; i++)
        //{
        //    if (this.m_ActData.m_EffectEvents[i].effectType == ActEffectClip.EffectType.CallActData || this.m_ActData.m_EffectEvents[i].effectType == ActEffectClip.EffectType.Bullet)
        //    {
        //        ActData actData = ResourceManager.Instance.GetActData(this.m_ActData.m_EffectEvents[i].hitActDataName);
        //        if (actData != null)
        //        {
        //            this.m_HitTimes += actData.m_HitTimes;
        //        }
        //    }
        //}
        return this.m_HitTimes;
    }
}
