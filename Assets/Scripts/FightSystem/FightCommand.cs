using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗指令
/// </summary>
public class FightCommand
{
    public M_Character m_Actor;

    public M_Character m_Target;

    public List<M_Character> m_Targets = new List<M_Character>();

    public int m_ID;

    public int m_UseEffectID;

    public List<GameObject> m_ActDatas = new List<GameObject>();

    public S_UseEffect m_UseEffect;

    private int m_HitTimes;

    private int m_HitTimesCounter;

    private bool isFirstHitSound = true;

    public Dictionary<M_Character, FightDamageData> m_HitDatas = new Dictionary<M_Character, FightDamageData>();

    public FightCommand(M_Character a, M_Character t, int id)
    {
        this.m_Actor = a;
        this.m_Target = t;
        this.m_ID = id;
    }

    public void Clear()
    {
        foreach (GameObject current in this.m_ActDatas)
        {
            UnityEngine.Object.Destroy(current);
        }
    }

    public virtual void Execute()
    {
    }

    //	public void ProcessActData(string actDataName)
    //	{
    //		M_ActProcessor actProcessor = ActSystem.Instance.GetActProcessor(actDataName);
    //		if (actProcessor == null)
    //		{
    //			Debug.Log("找不到ActData : " + actDataName);
    //			this.OnAnimationFinish();
    //			return;
    //		}
    //		actProcessor.OnCallActData = new M_ActProcessor.ActEventTrigger(this.OnCallActData);
    //		actProcessor.OnWeaponTrail_ON = new M_ActProcessor.EventTrigger(this.OnWeaponTrail_ON);
    //		actProcessor.OnWeaponTrail_OFF = new M_ActProcessor.EventTrigger(this.OnWeaponTrail_OFF);
    //		actProcessor.OnAfterImage = new M_ActProcessor.EventTrigger(this.OnAfterImage);
    //		actProcessor.OnHitAnimation = new M_ActProcessor.EventTrigger(this.OnHitAnimation);
    //		actProcessor.OnHitDamage = new M_ActProcessor.EventTrigger(this.OnHitDamage);
    //		actProcessor.OnAnimationFinish = new M_ActProcessor.EventTrigger(this.OnAnimationFinish);
    //		actProcessor.OnAnimationTrigger = new M_ActProcessor.AnimationEventTrigger(this.OnAnimationTrigger);
    //		actProcessor.OnShootEffect = new M_ActProcessor.ShootEffectEventTrigger(this.OnShootEffect);
    //		actProcessor.OnHitEffect_One = new M_ActProcessor.HitEffectEventTrigger(this.OnHitEffect_One);
    //		actProcessor.OnHitEffect_All = new M_ActProcessor.HitEffectEventTrigger(this.OnHitEffect_All);
    //		actProcessor.OnBulletEffect = new M_ActProcessor.BulletEffectEventTrigger(this.OnBulletEffect);
    //		actProcessor.OnSoundTrigger = new M_ActProcessor.SoundEventTrigger(this.OnSoundTrigger);
    //		this.m_ActDatas.Add(actProcessor.gameObject);
    //		this.m_HitTimes = actProcessor.GetHitTimes();
    //		this.m_HitTimesCounter = this.m_HitTimes;
    //	}

    //	public virtual void OnCallActData(string actDataName)
    //	{
    //		M_ActProcessor actProcessor = ActSystem.Instance.GetActProcessor(actDataName);
    //		actProcessor.OnCallActData = new M_ActProcessor.ActEventTrigger(this.OnCallActData);
    //		actProcessor.OnWeaponTrail_ON = new M_ActProcessor.EventTrigger(this.OnWeaponTrail_ON);
    //		actProcessor.OnWeaponTrail_OFF = new M_ActProcessor.EventTrigger(this.OnWeaponTrail_OFF);
    //		actProcessor.OnAfterImage = new M_ActProcessor.EventTrigger(this.OnAfterImage);
    //		actProcessor.OnHitAnimation = new M_ActProcessor.EventTrigger(this.OnHitAnimation);
    //		actProcessor.OnHitDamage = new M_ActProcessor.EventTrigger(this.OnHitDamage);
    //		actProcessor.OnHitEffect_One = new M_ActProcessor.HitEffectEventTrigger(this.OnHitEffect_One);
    //		actProcessor.OnHitEffect_All = new M_ActProcessor.HitEffectEventTrigger(this.OnHitEffect_All);
    //		actProcessor.OnSoundTrigger = new M_ActProcessor.SoundEventTrigger(this.OnSoundTrigger);
    //		this.m_ActDatas.Add(actProcessor.gameObject);
    //	}

    //	public virtual void OnWeaponTrail_ON()
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		M_WeaponTrail[] componentsInChildren = this.m_Actor.m_RoleModel.GetComponentsInChildren<M_WeaponTrail>();
    //		if (componentsInChildren == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			componentsInChildren[i].Emit = true;
    //		}
    //	}

    //	public virtual void OnWeaponTrail_OFF()
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		M_WeaponTrail[] componentsInChildren = this.m_Actor.m_RoleModel.GetComponentsInChildren<M_WeaponTrail>();
    //		if (componentsInChildren == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			componentsInChildren[i].Emit = false;
    //		}
    //	}

    //	public virtual void OnAfterImage()
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		RendererTool.CreateAfterImage(this.m_Actor.m_RoleModel);
    //	}

    //	public virtual void OnHitAnimation()
    //	{
    //		if (this.m_UseEffect == null)
    //		{
    //			return;
    //		}
    //		if (this.m_UseEffect.emItemType != ENUM_ItemSubType.Attack)
    //		{
    //			return;
    //		}
    //		if (this.m_UseEffect.emShakeSkillCamera == Enum_ShakeSkillCamera.Yes)
    //		{
    //			FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //			if (fightState != null && fightState.m_FightSceneMgr != null)
    //			{
    //				fightState.m_FightSceneMgr.ShakeCamera(this.m_Actor);
    //			}
    //		}
    //		foreach (KeyValuePair<M_Character, FightDamageData> current in this.m_HitDatas)
    //		{
    //			M_Character key = current.Key;
    //			if (!(key == null))
    //			{
    //				if (key.gameObject.activeInHierarchy)
    //				{
    //					key.OnHitAnimation(current.Value.m_emAnimationType);
    //				}
    //			}
    //		}
    //	}

    //	public virtual void OnHitDamage()
    //	{
    //		this.m_HitTimesCounter--;
    //		if (this.m_HitTimesCounter <= 0)
    //		{
    //			this.OnLastHit();
    //		}
    //		M_ActProcessor actProcessor = ActSystem.Instance.GetActProcessor(this.m_UseEffect.ActDataName);
    //		foreach (KeyValuePair<M_Character, FightDamageData> current in this.m_HitDatas)
    //		{
    //			FightDamageData value = current.Value;
    //			if (value != null)
    //			{
    //				M_Character key = current.Key;
    //				if (!(key == null))
    //				{
    //					if (key.gameObject.activeInHierarchy)
    //					{
    //						for (int i = 0; i < value.m_HitList.Count; i++)
    //						{
    //							if (this.m_HitTimes > 1)
    //							{
    //								if (value.m_HitList[i].m_emMsgType == Enum_FightHitType.DamageHP || value.m_HitList[i].m_emMsgType == Enum_FightHitType.DamageMP)
    //								{
    //									float num = (float)value.m_HitList[i].m_MsgValue / (float)this.m_HitTimes;
    //									num += 0.1f;
    //									key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, Mathf.RoundToInt(num), this.m_Actor);
    //									if (value.m_DoubleDmg)
    //									{
    //										key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, Mathf.RoundToInt(num), this.m_Actor);
    //									}
    //								}
    //								else
    //								{
    //									key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
    //									if (value.m_DoubleDmg)
    //									{
    //										key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
    //									}
    //								}
    //							}
    //							else
    //							{
    //								key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
    //								if (value.m_DoubleDmg)
    //								{
    //									key.OnHitDamage(value.m_HitList[i].m_emMsgType, value.m_bCritical, value.m_bBlock, value.m_HitList[i].m_MsgValue, this.m_Actor);
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public virtual void OnAnimationFinish()
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		this.m_Actor.OnCommandFinish(this);
    //	}

    //	public virtual void OnLastHit()
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		foreach (KeyValuePair<M_Character, FightDamageData> current in this.m_HitDatas)
    //		{
    //			if (current.Value != null)
    //			{
    //				M_Character key = current.Key;
    //				if (!(key == null))
    //				{
    //					if (key.gameObject.activeInHierarchy)
    //					{
    //						foreach (int current2 in current.Value.m_HitBuffs)
    //						{
    //							FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //							S_BufferData data = GameDataDB.BufferDB.GetData(current2);
    //							if (data != null)
    //							{
    //								if (data.Time < 0f)
    //								{
    //									fightState.m_BuffSystem.AddNoRemoveBuff(current2, this.m_Actor, key);
    //								}
    //								else
    //								{
    //									fightState.m_BuffSystem.AddBuff(current2, this.m_Actor, key);
    //								}
    //							}
    //						}
    //						foreach (int current3 in current.Value.m_DeBuffs)
    //						{
    //							key.Debuff(current3);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void OnAnimationTrigger(string animName)
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		this.m_Actor.PlayAnimation("Base Layer." + animName);
    //	}

    //	public virtual void OnShootEffect(string effectName, string refPoint, Vector3 shootPos, bool follow, bool rotate)
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = EffectSystem.Instance.CreateEffect(this.m_Actor.m_ModelTransform, refPoint, effectName, follow, rotate);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		gameObject.transform.position += this.m_Actor.m_ModelTransform.TransformDirection(shootPos);
    //	}

    //	public void OnBulletEffect(string effectName, string refPoint, Vector3 bulletPos, bool follow, float speed, string hitActDataName)
    //	{
    //		if (this.m_Actor == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Actor.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = EffectSystem.Instance.CreateEffect(this.m_Actor.m_ModelTransform, refPoint, effectName, follow, false);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		gameObject.transform.position += this.m_Actor.m_ModelTransform.TransformDirection(bulletPos);
    //		M_Bullet component = gameObject.GetComponent<M_Bullet>();
    //		if (component == null)
    //		{
    //			UnityEngine.Object.Destroy(gameObject);
    //			return;
    //		}
    //		component.m_Actor = this.m_Actor.m_RoleModel;
    //		component.m_Target = this.m_Target.m_RoleModel;
    //		component.m_HitActDataName = hitActDataName;
    //		component.OnBulletHit = new M_Bullet.HitEventTrigger(this.OnCallActData);
    //	}

    //	public void OnHitEffect_One(string effectName, string refPoint, bool follow, bool rotate)
    //	{
    //		if (this.m_Target == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Target.gameObject.activeInHierarchy)
    //		{
    //			return;
    //		}
    //		if (string.IsNullOrEmpty(refPoint) || refPoint == "None")
    //		{
    //			EffectSystem.Instance.CreateEffect(this.m_Target.m_ModelTransform, this.m_Target.GetModelPosition(), effectName, follow, rotate);
    //		}
    //		else
    //		{
    //			EffectSystem.Instance.CreateEffect(this.m_Target.m_ModelTransform, refPoint, effectName, follow, rotate);
    //		}
    //	}

    //	public void OnHitEffect_All(string effectName, string refPoint, bool follow, bool rotate)
    //	{
    //		for (int i = 0; i < this.m_Targets.Count; i++)
    //		{
    //			if (!(this.m_Targets[i] == null))
    //			{
    //				if (!this.m_Targets[i].gameObject.activeInHierarchy)
    //				{
    //					return;
    //				}
    //				if (string.IsNullOrEmpty(refPoint) || refPoint == "None")
    //				{
    //					EffectSystem.Instance.CreateEffect(this.m_Targets[i].m_ModelTransform, this.m_Targets[i].GetModelPosition(), effectName, follow, rotate);
    //				}
    //				else
    //				{
    //					EffectSystem.Instance.CreateEffect(this.m_Targets[i].m_ModelTransform, refPoint, effectName, follow, rotate);
    //				}
    //			}
    //		}
    //	}

    //	public void OnSoundTrigger(string soundName)
    //	{
    //		AudioClip sound = ResourceManager.Instance.GetSound(soundName);
    //		if (sound == null)
    //		{
    //			return;
    //		}
    //		if (soundName.Contains("hit"))
    //		{
    //			if (this.isFirstHitSound)
    //			{
    //				this.isFirstHitSound = false;
    //				if (this.m_Target == null)
    //				{
    //					return;
    //				}
    //				if (!this.m_Target.gameObject.activeInHierarchy)
    //				{
    //					return;
    //				}
    //				MusicSystem.Instance.PlaySoundAtPos(sound, this.m_Target.transform.position);
    //			}
    //		}
    //		else
    //		{
    //			if (this.m_Actor == null)
    //			{
    //				return;
    //			}
    //			if (soundName.Contains("attackos"))
    //			{
    //				if (!NormalSettingSystem.Instance.GetNormalSetting().m_bEnableFightingVoice)
    //				{
    //					return;
    //				}
    //				FightState fightState = Swd6Application.instance.GetCurrentGameState() as FightState;
    //				if (fightState != null && fightState.m_FightSceneMgr != null)
    //				{
    //					if (this.m_Actor == fightState.m_FightSceneMgr.GetControlledPlayer())
    //					{
    //						MusicSystem.Instance.PlaySoundAtPos(sound, this.m_Actor.GetModelPosition());
    //					}
    //					else
    //					{
    //						MusicSystem.Instance.PlaySoundAtPos_HalfVolume(sound, this.m_Actor.GetModelPosition());
    //					}
    //				}
    //			}
    //			else
    //			{
    //				MusicSystem.Instance.PlaySoundAtPos(sound, this.m_Actor.GetModelPosition());
    //			}
    //		}
    //	}
}
