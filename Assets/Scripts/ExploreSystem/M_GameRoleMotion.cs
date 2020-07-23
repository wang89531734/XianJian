using System;
using UnityEngine;

public class M_GameRoleMotion : MonoBehaviour
{
	private int m_RoleId;

	public int m_Id;

	public int m_FaceUpId;

	public int m_FaceDownId;

	private bool m_Destory;

	private float m_DelayTime = 0.1f;

	private string m_PlayMotionName;

	public ENUM_Motion m_MotionState;

	public string[] m_MotionName;

	private Animation m_Animation;

	private Animator m_Animator;

	public ENUM_Motion MotionState
	{
		get
		{
			return this.m_MotionState;
		}
		set
		{
			this.m_MotionState = value;
			int motionState = (int)this.m_MotionState;
			this.SetMotion(motionState);
		}
	}

	public M_GameRoleMotion(Animation anim)
	{
		this.m_Animation = anim;
	}

	private void Start()
	{
	}

	public void Init(int roleID, int id)
	{
		this.m_RoleId = roleID;
		this.m_Animator = base.gameObject.GetComponent<Animator>();
		if (this.m_Animator == null)
		{
			Animator[] componentsInChildren = base.gameObject.GetComponentsInChildren<Animator>();
			if (componentsInChildren != null && componentsInChildren.Length > 0)
			{
				this.m_Animator = componentsInChildren[0];
			}
		}
		if (this.m_Animator == null)
		{
			this.m_Animation = base.gameObject.GetComponent<Animation>();
			if (this.m_Animation == null)
			{
				Transform[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Transform>();
				if (componentsInChildren2 != null)
				{
					Transform[] array = componentsInChildren2;
					for (int i = 0; i < array.Length; i++)
					{
						Transform transform = array[i];
						Animation[] componentsInChildren3 = transform.GetComponentsInChildren<Animation>();
						if (componentsInChildren3 != null)
						{
							Animation[] array2 = componentsInChildren3;
							for (int j = 0; j < array2.Length; j++)
							{
								Animation animation = array2[j];
								if (animation.GetClipCount() != 0)
								{
									this.m_Animation = animation;
									break;
								}
							}
						}
						if (this.m_Animation != null)
						{
							break;
						}
					}
				}
			}
		}
		this.SetMotion(id);
		this.ClampMotion(id);
	}

	public void Enable(bool enable)
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.enabled = enable;
		}
		if (this.m_Animator != null)
		{
			this.m_Animator.enabled = enable;
		}
	}

	public void SetAlwaysAnimate(bool update)
	{
		if (this.m_Animation != null)
		{
			if (update)
			{
				this.m_Animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			else
			{
				this.m_Animation.cullingType = AnimationCullingType.BasedOnRenderers;
			}
		}
		if (this.m_Animator != null)
		{
			if (update)
			{
				this.m_Animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
			}
			else
			{
               // this.m_Animator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
            }
		}
	}

	public void ApplyRootMotion(bool enable)
	{
		if (this.m_Animator != null)
		{
			this.m_Animator.applyRootMotion = enable;
		}
	}

	private void Update()
	{
		if (this.m_Destory && this.m_Animation)
		{
			this.m_DelayTime -= Time.deltaTime;
			if (this.IsMotionFinished() || this.m_DelayTime <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	public void DestroyObj()
	{
		this.m_Destory = true;
		this.m_DelayTime = this.GetMotionTime(this.m_Id);
	}

	public void SetMotionState(int state)
	{
		this.m_MotionState = (ENUM_Motion)state;
		//if (!AnimationControlSystem.GetClip(base.gameObject, this.m_MotionName[state]))
		//{
		//	return;
		//}
		this.m_Animation.CrossFade(this.m_MotionName[state]);
	}

	public int GetMotion()
	{
		return this.m_Id;
	}

	public void SetMotion(int id)
	{
		if (id == 0)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			//if (Swd6Application.instance != null && Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	string message = string.Concat(new object[]
			//	{
			//		"角色",
			//		this.m_RoleId,
			//		"_DBF沒有這個動作 : ",
			//		id
			//	});
			//	Debug.LogWarning(message);
			//}
			return;
		}
		this.m_Id = id;
		this.m_PlayMotionName = data.ClipName;
		//if (this.m_Animator != null)
		//{
		//	string name = "Base Layer." + data.ClipName;
		//	int stateNameHash = Animator.StringToHash(name);
		//	this.m_Animator.Play(stateNameHash, 0, 0f);
		//}
		//else if (this.m_Animation != null)
		//{
		//	//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
		//	//{
		//	//	return;
		//	//}
		//	this.m_Animation.Play(this.m_PlayMotionName);
		//}
		//else if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//{
		//	string message2 = string.Concat(new object[]
		//	{
		//		"角色",
		//		this.m_RoleId,
		//		"_身上沒有這個動作_NULL_ : ",
		//		data.ClipName
		//	});
		//	Debug.LogWarning(message2);
		//}
	}

	public void SetCrossMotion(int id)
	{
		if (id == 0)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	string message = string.Concat(new object[]
			//	{
			//		"角色",
			//		this.m_RoleId,
			//		"_DBF沒有這個動作 : ",
			//		id
			//	});
			//	Debug.LogWarning(message);
			//}
			return;
		}
		this.m_Id = id;
		this.m_PlayMotionName = data.ClipName;
		if (this.m_Animation != null)
		{
			//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
			//{
			//	return;
			//}
			this.m_Animation.CrossFade(this.m_PlayMotionName);
		}
		else
		{
			if (this.m_Animator == null)
			{
				//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
				//{
				//	string message2 = string.Concat(new object[]
				//	{
				//		"角色",
				//		this.m_RoleId,
				//		"_身上沒有這個動作_NULL_ : ",
				//		data.ClipName
				//	});
				//	Debug.LogWarning(message2);
				//}
				return;
			}
			string name = "Base Layer." + data.ClipName;
			int stateNameHash = Animator.StringToHash(name);
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.length > 0f)
			{
				this.m_Animator.CrossFade(stateNameHash, 0.2f / currentAnimatorStateInfo.length, 0, 0f);
			}
			else
			{
				this.m_Animator.CrossFade(stateNameHash, 0f);
			}
		}
	}

	public void SetMotionQueued(int id)
	{
		if (id == 0)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	string message = string.Concat(new object[]
			//	{
			//		"角色",
			//		this.m_RoleId,
			//		"_DBF沒有這個動作 : ",
			//		id
			//	});
			//	Debug.LogWarning(message);
			//}
			return;
		}
		if (this.m_Animation != null)
		{
			//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
			//{
			//	return;
			//}
			this.m_Animation.CrossFade(this.m_PlayMotionName);
		}
		else
		{
			if (this.m_Animator == null)
			{
				//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
				//{
				//	string message2 = string.Concat(new object[]
				//	{
				//		"角色",
				//		this.m_RoleId,
				//		"_身上沒有這個動作_NULL_ : ",
				//		data.ClipName
				//	});
				//	Debug.LogWarning(message2);
				//}
				return;
			}
			string name = "Base Layer." + data.ClipName;
			int stateNameHash = Animator.StringToHash(name);
			this.m_Animator.CrossFade(stateNameHash, 0.1f);
		}
	}

	public void SetMotion(string name)
	{
		this.m_PlayMotionName = name;
		//if (!AnimationControlSystem.GetClip(base.gameObject, this.m_PlayMotionName))
		//{
		//	return;
		//}
		this.m_Animation.CrossFade(name);
	}

	public void SetMotionSpeed(int id, float speed)
	{
		if (id == 0)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return;
		}
		if (this.m_Animation == null)
		{
			return;
		}
		//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
		//{
		//	return;
		//}
		AnimationState animationState = this.m_Animation[data.ClipName];
		animationState.speed = speed;
	}

	public bool IsMotionFinished()
	{
		if (this.m_Animator != null)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.IsName(this.m_PlayMotionName) && currentAnimatorStateInfo.normalizedTime >= 1f;
		}
		return !this.m_Animation.IsPlaying(this.m_PlayMotionName);
	}

	public bool IsMotionFinished(int id)
	{
		if (id == 0)
		{
			return true;
		}
		bool result = false;
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return true;
		}
		if (this.m_Animation != null)
		{
			AnimationState animationState = this.m_Animation[data.ClipName];
			return animationState == null || animationState.time >= animationState.length || !this.m_Animation.IsPlaying(data.ClipName);
		}
		if (this.m_Animator == null)
		{
			//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	string message = "角色" + this.m_RoleId + "_身上沒有Animator!!";
			//	Debug.LogWarning(message);
			//}
			return false;
		}
		AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
		if (!currentAnimatorStateInfo.IsName(data.ClipName))
		{
			return false;
		}
		if (currentAnimatorStateInfo.normalizedTime >= 1f)
		{
			result = true;
		}
		return result;
	}

	public void ClampMotion(int id)
	{
		if (id == 0)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return;
		}
		if (this.m_Animation == null)
		{
			return;
		}
		//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
		//{
		//	return;
		//}
		AnimationState animationState = this.m_Animation[data.ClipName];
		if (animationState == null)
		{
			return;
		}
		if (animationState.wrapMode != WrapMode.Loop)
		{
			animationState.time = animationState.length;
			this.m_Animation.Play(data.ClipName);
		}
	}

	public float GetMotionTime(int id)
	{
		if (id == 0)
		{
			return 0f;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return 0f;
		}
		if (this.m_Animator != null)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Animator.GetCurrentAnimatorStateInfo(0);
			if (!currentAnimatorStateInfo.IsName(data.ClipName))
			{
				return 0f;
			}
			return currentAnimatorStateInfo.length;
		}
		else
		{
			if (this.m_Animation == null)
			{
				return 0f;
			}
			//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
			//{
			//	return 0f;
			//}
			AnimationState animationState = this.m_Animation[data.ClipName];
			if (animationState == null)
			{
				return 0f;
			}
			return animationState.length;
		}
	}

	public void PlayExpression_Up(int id)
	{
		if (this.m_FaceUpId == id)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return;
		}
		if (this.m_Animation == null)
		{
			return;
		}
		//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
		//{
		//	return;
		//}
		this.m_FaceUpId = id;
		//AnimationControlSystem.PlayExpression_Up(base.gameObject, data.ClipName);
	}

	public void PlayExpression_Down(int id)
	{
		if (this.m_FaceDownId == id)
		{
			return;
		}
		S_AnimationData data = GameDataDB.AnimationDB.GetData(id);
		if (data == null)
		{
			return;
		}
		if (this.m_Animation == null)
		{
			return;
		}
		//if (!AnimationControlSystem.GetClip(base.gameObject, data.ClipName))
		//{
		//	return;
		//}
		this.m_FaceDownId = id;
		//AnimationControlSystem.PlayExpression_Down(base.gameObject, data.ClipName);
	}

	public void Idle()
	{
		this.MotionState = ENUM_Motion.Idle;
	}

	public void Walk()
	{
		this.MotionState = ENUM_Motion.Walk;
	}

	public void Run()
	{
		this.MotionState = ENUM_Motion.Run;
	}

	public void Jump()
	{
		this.MotionState = ENUM_Motion.Jump;
	}

	public void JumpLand()
	{
		this.MotionState = ENUM_Motion.Idle;
	}
}
