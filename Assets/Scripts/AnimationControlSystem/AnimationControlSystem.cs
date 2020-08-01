using System;
using System.Collections;
using UnityEngine;

public class AnimationControlSystem
{
    //	public static bool GetClip_NoAlarm(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return false;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return false;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				return false;
    //			}
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Runtime)
    //			{
    //				string path;
    //				if (obj.name.StartsWith("Role"))
    //				{
    //					string[] array = obj.name.Split(new char[]
    //					{
    //						'_'
    //					});
    //					int id = int.Parse(array[1]);
    //					S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //					if (data == null)
    //					{
    //						return false;
    //					}
    //					path = data.PrefName.Split(new char[]
    //					{
    //						'-'
    //					})[0];
    //				}
    //				else
    //				{
    //					path = obj.name.Split(new char[]
    //					{
    //						'-'
    //					})[0];
    //				}
    //				AnimationClip animationClip = AnimationGenerator.GetAnimationClip(path, clipName);
    //				if (animationClip == null)
    //				{
    //					return false;
    //				}
    //				componentInChildren.AddClip(animationClip, clipName);
    //			}
    //		}
    //		return true;
    //	}

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
            string text = obj.name + "身上沒有這個動作 : " + clipName;
            Debug.LogWarning(text);
            return false;
        }
        return true;
    }

    //	public static void CrossFadeAnimation(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = componentInChildren[clipName].clip.wrapMode;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.CrossFade(clipName);
    //	}

    //	public static void PlayAnimation(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = componentInChildren[clipName].clip.wrapMode;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.Play(clipName);
    //	}

    //	public static void PlayAnimationLoop(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = WrapMode.Loop;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.CrossFade(clipName);
    //	}

    //	public static void PlayAnimationClampForever(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = WrapMode.ClampForever;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.CrossFade(clipName);
    //	}

    //	public static void PlayAnimationQueued(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = componentInChildren[clipName].clip.wrapMode;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.CrossFadeQueued(clipName);
    //	}

    //	public static void PlayAnimationQueuedClampForever(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		componentInChildren[clipName].wrapMode = WrapMode.ClampForever;
    //		componentInChildren[clipName].time = 0f;
    //		componentInChildren.CrossFadeQueued(clipName);
    //	}

    //	public static void PlayExpression_Up(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		Transform transform = TransformTool.SearchHierarchyForBone(obj.transform, "FU-Dummy01");
    //		if (transform == null)
    //		{
    //			Debug.LogWarning("upTransform = Null");
    //			return;
    //		}
    //		obj.animation[clipName].AddMixingTransform(transform);
    //		obj.animation[clipName].layer = 2;
    //		obj.animation[clipName].time = 0f;
    //		if (FPS_Counter.Instance.GetFPS() < 6f)
    //		{
    //			obj.animation.Play(clipName);
    //			return;
    //		}
    //		obj.animation.CrossFade(clipName);
    //	}

    //	public static void PlayExpression_Down(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		if (componentInChildren == null)
    //		{
    //			return;
    //		}
    //		if (componentInChildren[clipName] == null)
    //		{
    //			string text = obj.name + "身上沒有這個動作 : " + clipName;
    //			Debug.LogWarning(text);
    //			UI_OkCancelBox.Instance.AddSysMsg(text, 10f);
    //			return;
    //		}
    //		Transform transform = TransformTool.SearchHierarchyForBone(obj.transform, "Face-controller");
    //		if (transform == null)
    //		{
    //			Debug.LogWarning("downTransform = Null");
    //			return;
    //		}
    //		obj.animation[clipName].AddMixingTransform(transform);
    //		obj.animation[clipName].layer = 1;
    //		obj.animation[clipName].time = 0f;
    //		if (FPS_Counter.Instance.GetFPS() < 6f)
    //		{
    //			obj.animation.Play(clipName);
    //			return;
    //		}
    //		obj.animation.CrossFade(clipName);
    //	}

    //	public static IEnumerator PlayExpression_Up_Queued(GameObject obj, string clipNameA, string clipNameB, float delayTime)
    //	{
    //		yield return 1;
    //		if (AnimationControlSystem.GetClip(obj, clipNameA))
    //		{
    //			AnimationControlSystem.PlayExpression_Up(obj, clipNameA);
    //		}
    //		yield return new WaitForSeconds(delayTime);
    //		if (AnimationControlSystem.GetClip(obj, clipNameB))
    //		{
    //			AnimationControlSystem.PlayExpression_Up(obj, clipNameB);
    //		}
    //		yield break;
    //	}

    //	public static bool IsAnimationPlaying(GameObject obj, string clipName)
    //	{
    //		if (!obj)
    //		{
    //			return false;
    //		}
    //		Animation componentInChildren = obj.GetComponentInChildren<Animation>();
    //		return !(componentInChildren == null) && !(componentInChildren[clipName] == null) && componentInChildren[clipName].enabled;
    //	}
}
