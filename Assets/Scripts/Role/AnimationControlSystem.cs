using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AnimationControlSystem
{
	public static bool GetClip(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return false;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return false;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return false;
		}
		return true;
	}

	public static void CrossFadeAnimation(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animator component = obj.GetComponent<Animator>();
		if (component == null)
		{
			return;
		}
		component.enabled = true;
		component.applyRootMotion = true;
		if (component.layerCount >= 2)
		{
			component.SetLayerWeight(1, 0f);
		}
		if (component.layerCount >= 3)
		{
			component.SetLayerWeight(2, 0f);
		}
		if (component.layerCount >= 4)
		{
			component.SetLayerWeight(3, 0f);
		}
		AnimatorStateInfo currentAnimatorStateInfo = component.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.length > 0f)
		{
			component.CrossFade(clipName, 0.2f / currentAnimatorStateInfo.length, 0, 0f);
		}
		else
		{
			component.Play(clipName, 0, 0f);
		}
	}

	public static void PlayAnimation(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animator component = obj.GetComponent<Animator>();
		if (component == null)
		{
			return;
		}
		component.enabled = true;
		component.applyRootMotion = true;
		if (component.layerCount >= 2)
		{
			component.SetLayerWeight(1, 0f);
		}
		if (component.layerCount >= 3)
		{
			component.SetLayerWeight(2, 0f);
		}
		if (component.layerCount >= 4)
		{
			component.SetLayerWeight(3, 0f);
		}
		component.Play(clipName, 0, 0f);
	}

	public static void OverrideAnimation(GameObject obj, string clipNameBase, string clipNameOverride, int layer)
	{
		if (!obj)
		{
			return;
		}
		Animator component = obj.GetComponent<Animator>();
		if (component == null)
		{
			return;
		}
		layer = Mathf.Clamp(layer, 1, 3);
		component.enabled = true;
		component.applyRootMotion = true;
		if (component.layerCount >= 2)
		{
			component.SetLayerWeight(1, 0f);
		}
		if (component.layerCount >= 3)
		{
			component.SetLayerWeight(2, 0f);
		}
		if (component.layerCount >= 4)
		{
			component.SetLayerWeight(3, 0f);
		}
		AnimatorStateInfo currentAnimatorStateInfo = component.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.length > 0f)
		{
			component.CrossFade(clipNameBase, 0.2f / currentAnimatorStateInfo.length, 0, 0f);
		}
		else
		{
			component.Play(clipNameBase, 0, 0f);
		}
		if (component.layerCount >= layer + 1)
		{
			component.Play(clipNameOverride, layer, 0f);
			component.SetLayerWeight(layer, 1f);
		}
	}

	public static void PlayAnimationLoop(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		componentInChildren[clipName].wrapMode = WrapMode.Loop;
		componentInChildren[clipName].time = 0f;
		componentInChildren.CrossFade(clipName);
	}

	public static void PlayAnimationClampForever(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		componentInChildren[clipName].wrapMode = WrapMode.ClampForever;
		componentInChildren[clipName].time = 0f;
		componentInChildren.CrossFade(clipName);
	}

	public static void PlayAnimationQueued(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		componentInChildren[clipName].wrapMode = componentInChildren[clipName].clip.wrapMode;
		componentInChildren[clipName].time = 0f;
		componentInChildren.CrossFadeQueued(clipName);
	}

	public static void PlayAnimationQueuedClampForever(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		componentInChildren[clipName].wrapMode = WrapMode.ClampForever;
		componentInChildren[clipName].time = 0f;
		componentInChildren.CrossFadeQueued(clipName);
	}

	public static void PlayExpression_Up(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		if (componentInChildren == null)
		{
			return;
		}
		if (componentInChildren[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		Transform transform = TransformTool.FindChild(obj.transform, "FU-Dummy001");
		if (transform == null)
		{
			UnityEngine.Debug.LogWarning("upTransform = Null");
			return;
		}
        Animation animation = obj.GetComponent<Animation>();

        animation[clipName].AddMixingTransform(transform);
		animation[clipName].layer = 12;
		animation[clipName].time = 0f;
		animation.Play(clipName);
	}

	public static void PlayExpression_Down(GameObject obj, string clipName)
	{
		if (!obj)
		{
			UnityEngine.Debug.LogWarning("無此物件");
			return;
		}
		Animation component = obj.GetComponent<Animation>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("無animation");
			return;
		}
		if (component[clipName] == null)
		{
			string message = obj.name + "身上沒有這個動作 : " + clipName;
			UnityEngine.Debug.LogWarning(message);
			return;
		}
		Transform transform = TransformTool.FindChild(obj.transform, "FD-Dummy001");
		if (transform == null)
		{
			UnityEngine.Debug.LogWarning("downTransform = Null");
			return;
		}

        Animation animation = obj.GetComponent<Animation>();
        animation[clipName].AddMixingTransform(transform);
		animation[clipName].layer = 11;
		animation[clipName].time = 0f;
		UnityEngine.Debug.LogWarning("PlayExpression_Down :" + clipName);
		animation.Play(clipName);
	}

    public static IEnumerator PlayExpression_Up_Queued(GameObject obj, string clipNameA, string clipNameB, float delayTime)
    {
        yield return 1;
        if (AnimationControlSystem.GetClip(obj, clipNameA))
        {
            AnimationControlSystem.PlayExpression_Up(obj, clipNameA);
        }
        yield return new WaitForSeconds(delayTime);
        if (AnimationControlSystem.GetClip(obj, clipNameB))
        {
            AnimationControlSystem.PlayExpression_Up(obj, clipNameB);
        }
        yield break;
    }

    public static bool IsAnimationPlaying(GameObject obj, string clipName)
	{
		if (!obj)
		{
			return false;
		}
		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
		return !(componentInChildren == null) && !(componentInChildren[clipName] == null) && componentInChildren[clipName].enabled;
	}
}
