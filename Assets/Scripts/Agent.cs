using System;
using System.Collections;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;


//[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(Locomotion))]
//[RequireComponent(typeof(AnimCtrlScript))]
[RequireComponent(typeof(CharacterController))]
public class Agent : MonoBehaviour
{
    //	// Token: 0x04001E02 RID: 7682
    //	public PalNPC palNPC;

    //	// Token: 0x04001E03 RID: 7683
    //	public NavMeshAgent agent;

    public Animator animator;

    //	// Token: 0x04001E05 RID: 7685
    //	public AnimCtrlScript animCtrl;

    //	// Token: 0x04001E06 RID: 7686
    //	public CharacterController charCtrller;

    //	// Token: 0x04001E07 RID: 7687
    //	[NonSerialized]
    //	public Perception perception;

    //	// Token: 0x04001E08 RID: 7688
    //	public bool bControl = true;

    //	// Token: 0x04001E09 RID: 7689
    //	public float SpeedK = 1f;

    //	// Token: 0x04001E0A RID: 7690
    //	private bool m_NeedEnableAgent = true;

    //	// Token: 0x04001E0B RID: 7691
    //	public ControlMode m_curCtrlMode = ControlMode.None;

    //	// Token: 0x04001E0C RID: 7692
    //	protected bool controlByAgent = true;

    //	// Token: 0x04001E0D RID: 7693
    //	public float RunSpeed = 10f;

    //	// Token: 0x04001E0E RID: 7694
    //	public float WalkSpeed = 2f;

    //	// Token: 0x04001E0F RID: 7695
    //	public float AniRunSpeed = 7f;

    //	// Token: 0x04001E10 RID: 7696
    //	public float RotSpeed = 15f;

    //	// Token: 0x04001E11 RID: 7697
    //	public float dampSpeed = 3.7f;

    //	// Token: 0x04001E12 RID: 7698
    //	public float CurSpeed = 1f;

    //	// Token: 0x04001E13 RID: 7699
    //	public float LongJumpSpeed = 0.45f;

    //	// Token: 0x04001E14 RID: 7700
    //	public float jumpPower = 1f;

    //	// Token: 0x04001E15 RID: 7701
    //	private float jumpPowerSecond = 1.3f;

    //	// Token: 0x04001E16 RID: 7702
    //	public float MaxJumpPower = 2f;

    //	// Token: 0x04001E17 RID: 7703
    //	public float ActionRadius = 1.5f;

    //	// Token: 0x04001E18 RID: 7704
    //	public Locomotion locomotion;

    //	// Token: 0x04001E19 RID: 7705
    //	public Transform destObj;

    //	// Token: 0x04001E1A RID: 7706
    //	protected Vector3 destOffsetDir;

    //	// Token: 0x04001E1B RID: 7707
    //	protected float destDistance;

    //	// Token: 0x04001E1C RID: 7708
    //	public Type destType;

    //	// Token: 0x04001E1D RID: 7709
    //	public float JudgeStopDistance = 7f;

    //	// Token: 0x04001E1E RID: 7710
    //	private float gravityK = 3f;

    //	// Token: 0x04001E1F RID: 7711
    //	private float JumpSpeed = 17f;

    //	// Token: 0x04001E20 RID: 7712
    //	public float VerticalSpeed;

    //	// Token: 0x04001E21 RID: 7713
    //	public float ZhuoDiTime = 100f;

    //	// Token: 0x04001E22 RID: 7714
    //	public float ZhuoDiDistance = 0.05f;

    //	// Token: 0x04001E23 RID: 7715
    //	protected bool IsUsedInSky;

    //	// Token: 0x04001E24 RID: 7716
    //	public bool IsInSky;

    //	// Token: 0x04001E25 RID: 7717
    //	public bool IsJump;

    //	// Token: 0x04001E26 RID: 7718
    //	public bool CanSlowByKeyUp;

    //	// Token: 0x04001E27 RID: 7719
    //	private bool bSlow;

    //	// Token: 0x04001E28 RID: 7720
    //	public float XiaLuoSpeed = 5f;

    //	// Token: 0x04001E29 RID: 7721
    //	public bool CanSecondJump;

    //	// Token: 0x04001E2A RID: 7722
    //	public float SecondJumpDegree = 1.2f;

    //	// Token: 0x04001E2B RID: 7723
    //	public float SmallMoveSpeed = 4f;

    //	// Token: 0x04001E2C RID: 7724
    //	public AnimatorMoveClient animatorMoveClient;

    //	// Token: 0x04001E2D RID: 7725
    //	private AnimEvent animEvent;

    //	// Token: 0x04001E2E RID: 7726
    //	public Agent.void_fun OnApplyAnimatorMove;

    //	// Token: 0x04001E2F RID: 7727
    //	public float AgentSpeedK = 1f;

    //	// Token: 0x04001E30 RID: 7728
    //	public Landmark landmark;

    //	// Token: 0x04001E31 RID: 7729
    //	public float kkk = 1f;

    //	// Token: 0x04001E32 RID: 7730
    //	private Vector3 JumpTurnBodyVelocity = Vector3.zero;

    //	// Token: 0x04001E33 RID: 7731
    //	public float JumpTurnBodySpeed = 100f;

    //	// Token: 0x04001E34 RID: 7732
    //	[HideInInspector]
    //	public bool CanSmallMove;

    //	// Token: 0x04001E35 RID: 7733
    //	public float SlowSmoothTime = 0.1f;

    //	// Token: 0x04001E36 RID: 7734
    //	public float SlowDegree = 0.68f;

    //	// Token: 0x04001E37 RID: 7735
    //	private float SlowSpeed;

    //	// Token: 0x04001E38 RID: 7736
    //	private float orgColliderHeight;

    //	// Token: 0x04001E39 RID: 7737
    //	private float orgHeight;

    //	// Token: 0x04001E3A RID: 7738
    //	private Vector3 tempCtrlCenter = Vector3.zero;

    //	// Token: 0x04001E3B RID: 7739
    //	private bool bJumpStart;

    //	// Token: 0x04001E3C RID: 7740
    //	public float JumpMoveRatioWhenSlide = 0.3f;

    //	// Token: 0x04001E3D RID: 7741
    //	public float CrossZhuoDiTime = 0.08f;

    //	// Token: 0x020019B2 RID: 6578
    //	// (Invoke) Token: 0x06017C88 RID: 97416
    //	public delegate void void_fun();

    //	public bool NeedEnableAgent
    //	{
    //		get
    //		{
    //			return this.m_NeedEnableAgent;
    //		}
    //		set
    //		{
    //			this.m_NeedEnableAgent = value;
    //		}
    //	}

    //	// Token: 0x1700027A RID: 634
    //	// (get) Token: 0x06001ACE RID: 6862 RVA: 0x000F03A4 File Offset: 0x000EE5A4
    //	// (set) Token: 0x06001ACF RID: 6863 RVA: 0x000F03AC File Offset: 0x000EE5AC
    //	public ControlMode curCtrlMode
    //	{
    //		get
    //		{
    //			return this.m_curCtrlMode;
    //		}
    //		set
    //		{
    //			this.m_curCtrlMode = value;
    //			if (this.m_curCtrlMode == ControlMode.ControlByAgent)
    //			{
    //				if (this.agent != null)
    //				{
    //					this.agent.enabled = true;
    //					this.agent.updatePosition = true;
    //					this.agent.updateRotation = true;
    //					this.animatorMoveClient = base.gameObject.GetComponent<AnimatorMoveClient>();
    //					if (this.animatorMoveClient == null)
    //					{
    //						this.animatorMoveClient = base.gameObject.AddComponent<AnimatorMoveClient>();
    //					}
    //					AnimatorMoveClient animatorMoveClient = this.animatorMoveClient;
    //					animatorMoveClient.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Remove(animatorMoveClient.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.NavAgentMove));
    //					AnimatorMoveClient animatorMoveClient2 = this.animatorMoveClient;
    //					animatorMoveClient2.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Combine(animatorMoveClient2.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.NavAgentMove));
    //				}
    //			}
    //			else
    //			{
    //				if (this.agent != null)
    //				{
    //					this.agent.enabled = false;
    //					this.agent.updatePosition = false;
    //					this.agent.updateRotation = false;
    //				}
    //				if (this.animator == null)
    //				{
    //					this.animator = base.GetComponent<Animator>();
    //				}
    //				if (this.animator != null)
    //				{
    //					if (this.m_curCtrlMode == ControlMode.None)
    //					{
    //						this.animator.SetApplyRootMotion(false);
    //					}
    //					else if (this.m_curCtrlMode != ControlMode.ControlByCutscene)
    //					{
    //						this.SetApplyRootMotion();
    //					}
    //				}
    //				if (this.animatorMoveClient != null)
    //				{
    //					AnimatorMoveClient animatorMoveClient3 = this.animatorMoveClient;
    //					animatorMoveClient3.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Remove(animatorMoveClient3.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.NavAgentMove));
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x1700027B RID: 635
    //	// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x000F0554 File Offset: 0x000EE754
    //	public float SecondJumpMinDistanceFromGroud
    //	{
    //		get
    //		{
    //			return 1.3f;
    //		}
    //	}

    //	// Token: 0x06001AD1 RID: 6865 RVA: 0x000F055C File Offset: 0x000EE75C
    //	public void ClearAnimMoveClient()
    //	{
    //		if (this.animatorMoveClient != null)
    //		{
    //			UnityEngine.Object.Destroy(this.animatorMoveClient);
    //			this.animatorMoveClient = null;
    //		}
    //	}

    //	// Token: 0x06001AD2 RID: 6866 RVA: 0x000F0584 File Offset: 0x000EE784
    //	private void SetApplyRootMotion()
    //	{
    //		bool bActive = true;
    //		if (this.palNPC != null)
    //		{
    //			int num = -100;
    //			string text = this.palNPC.name;
    //			int num2 = text.IndexOf('(');
    //			if (num2 > 0)
    //			{
    //				text = text.Substring(0, num2);
    //			}
    //			if (int.TryParse(text, out num))
    //			{
    //				if (num > 7 && base.gameObject != PlayersManager.Player.GetModelObj(false))
    //				{
    //					bActive = false;
    //				}
    //			}
    //			else
    //			{
    //				bActive = false;
    //			}
    //		}
    //		this.animator.SetApplyRootMotion(bActive);
    //	}

    //	// Token: 0x06001AD3 RID: 6867 RVA: 0x000F0610 File Offset: 0x000EE810
    //	private void Start()
    //	{
    //		this.agent = base.GetComponent<NavMeshAgent>();
    //		this.animator = base.GetComponentInChildren<Animator>();
    //		if (this.animator != null)
    //		{
    //			this.animator.SetFloat("VerticalSpeed", 0f);
    //		}
    //		this.locomotion = base.GetComponent<Locomotion>();
    //		this.locomotion.RotSpeed = this.RotSpeed;
    //		this.animCtrl = base.GetComponent<AnimCtrlScript>();
    //		if (this.animCtrl == null)
    //		{
    //			this.animCtrl = this.animator.gameObject.AddComponent<AnimCtrlScript>();
    //		}
    //		this.charCtrller = base.GetComponent<CharacterController>();
    //		if (this.animator != null)
    //		{
    //			this.SetApplyRootMotion();
    //			this.animEvent = this.animator.GetComponent<AnimEvent>();
    //			if (this.animEvent == null)
    //			{
    //				this.animEvent = this.animator.gameObject.AddComponent<AnimEvent>();
    //			}
    //			AnimEvent animEvent = this.animEvent;
    //			animEvent.OnJumpStart = (AnimEvent.void_fun)Delegate.Remove(animEvent.OnJumpStart, new AnimEvent.void_fun(this.OnJumpStart));
    //			AnimEvent animEvent2 = this.animEvent;
    //			animEvent2.OnJumpStart = (AnimEvent.void_fun)Delegate.Combine(animEvent2.OnJumpStart, new AnimEvent.void_fun(this.OnJumpStart));
    //			AnimEvent animEvent3 = this.animEvent;
    //			animEvent3.OnJumpOver = (AnimEvent.void_fun)Delegate.Remove(animEvent3.OnJumpOver, new AnimEvent.void_fun(this.OnJumpOver));
    //			AnimEvent animEvent4 = this.animEvent;
    //			animEvent4.OnJumpOver = (AnimEvent.void_fun)Delegate.Combine(animEvent4.OnJumpOver, new AnimEvent.void_fun(this.OnJumpOver));
    //			AnimEvent animEvent5 = this.animEvent;
    //			animEvent5.OnJumpEvent = (AnimEvent.void_fun_float)Delegate.Remove(animEvent5.OnJumpEvent, new AnimEvent.void_fun_float(this.OnJumpEvent));
    //			AnimEvent animEvent6 = this.animEvent;
    //			animEvent6.OnJumpEvent = (AnimEvent.void_fun_float)Delegate.Combine(animEvent6.OnJumpEvent, new AnimEvent.void_fun_float(this.OnJumpEvent));
    //		}
    //		this.agent.enabled = false;
    //		if (this.NeedEnableAgent && (!(PlayerCtrlManager.agentObj != null) || !(PlayerCtrlManager.agentObj == this)))
    //		{
    //			this.agent.enabled = true;
    //		}
    //		if (((this.palNPC != null && this.palNPC.Data != null && this.palNPC.Data.CharacterID < 8) || this.palNPC == null) && this.palNPC != null && PlayersManager.Player != this.palNPC.gameObject)
    //		{
    //			this.curCtrlMode = ControlMode.None;
    //		}
    //		if (this.palNPC != null && this.palNPC.MonsterGroups.Length < 1)
    //		{
    //			this.agent.baseOffset = -0.1f;
    //			if (!NPCHeight.Instance.SetHeight(this.agent))
    //			{
    //				base.gameObject.AddComponent<AdjustNavAgentOffset>();
    //			}
    //		}
    //		GameObjectEvent x = base.GetComponent<GameObjectEvent>();
    //		if (x == null)
    //		{
    //			x = base.gameObject.AddComponent<GameObjectEvent>();
    //		}
    //		if (this.XiaLuoSpeed < 9f)
    //		{
    //			this.XiaLuoSpeed = 9f;
    //		}
    //	}

    //	// Token: 0x06001AD4 RID: 6868 RVA: 0x000F0944 File Offset: 0x000EEB44
    //	protected void SetDestination0()
    //	{
    //		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //		RaycastHit raycastHit = default(RaycastHit);
    //		if (Physics.Raycast(ray, out raycastHit))
    //		{
    //			this.agent.destination = raycastHit.point;
    //		}
    //	}

    //	// Token: 0x06001AD5 RID: 6869 RVA: 0x000F0988 File Offset: 0x000EEB88
    //	public void ResetDestination()
    //	{
    //		if (this.destType == typeof(Landmark))
    //		{
    //			Landmark component = this.destObj.GetComponent<Landmark>();
    //			this.SetDestination(component);
    //		}
    //		else if (this.destType == typeof(GameObject))
    //		{
    //			this.SetDestination(this.destObj.gameObject);
    //		}
    //	}

    //	// Token: 0x06001AD6 RID: 6870 RVA: 0x000F09E8 File Offset: 0x000EEBE8
    //	public void SetDestination(Vector3 position)
    //	{
    //		this.agent.destination = position;
    //	}

    //	// Token: 0x06001AD7 RID: 6871 RVA: 0x000F09F8 File Offset: 0x000EEBF8
    //	public void SetDestination(GameObject npcObj, Vector3 destPos)
    //	{
    //		this.destObj = npcObj.transform;
    //		PalNPC component = npcObj.GetComponent<PalNPC>();
    //		if (component != null && component.model)
    //		{
    //			this.destObj = component.model.transform;
    //		}
    //		this.destType = typeof(GameObject);
    //		this.SetDestination(this.destObj.transform.position + this.destObj.transform.rotation * destPos);
    //	}

    //	// Token: 0x06001AD8 RID: 6872 RVA: 0x000F0A88 File Offset: 0x000EEC88
    //	public void SetDestination(GameObject npcObj)
    //	{
    //		PalNPC component = base.GetComponent<PalNPC>();
    //		if (component == null)
    //		{
    //			Debug.LogWarning("没有NPC类");
    //			return;
    //		}
    //		Vector3 aimPos = component.GetAimPos(npcObj);
    //		this.destObj = npcObj.transform;
    //		this.destType = typeof(GameObject);
    //		this.SetDestination(aimPos);
    //	}

    //	// Token: 0x06001AD9 RID: 6873 RVA: 0x000F0AE0 File Offset: 0x000EECE0
    //	public void SetDestination(GameObject npcObj, Vector3 offsetDir, float distance)
    //	{
    //		float radius = PalNPC.GetRadius(npcObj);
    //		offsetDir.Normalize();
    //		offsetDir *= radius + this.agent.radius + distance;
    //		Vector3 destination = npcObj.transform.position + npcObj.transform.rotation * offsetDir;
    //		this.destObj = npcObj.transform;
    //		this.destType = typeof(GameObject);
    //		this.destOffsetDir = offsetDir;
    //		this.destDistance = distance;
    //		this.SetDestination(destination);
    //	}

    //	// Token: 0x06001ADA RID: 6874 RVA: 0x000F0B68 File Offset: 0x000EED68
    //	public void SetDestination(Landmark landmark)
    //	{
    //		this.destObj = landmark.transform;
    //		this.destType = typeof(Landmark);
    //		Vector3 vector = landmark.GetNewPos();
    //		if (!landmark.InSpace)
    //		{
    //			vector.y += 1.3f;
    //			RaycastHit raycastHit;
    //			if (Physics.Raycast(vector, Vector3.down, out raycastHit))
    //			{
    //				vector = raycastHit.point;
    //			}
    //			else if (Physics.Raycast(vector, Vector3.up, out raycastHit))
    //			{
    //				vector = raycastHit.point;
    //			}
    //		}
    //		this.SetDestination(vector);
    //	}

    //	// Token: 0x06001ADB RID: 6875 RVA: 0x000F0BF8 File Offset: 0x000EEDF8
    //	public void SetupAgentLocomotion()
    //	{
    //		if (this.AgentDone())
    //		{
    //			this.locomotion.Do(0f, 0f, base.transform, this.agent.desiredVelocity);
    //		}
    //		else
    //		{
    //			this.SetupAgentLocomotionByUScript();
    //		}
    //	}

    //	// Token: 0x06001ADC RID: 6876 RVA: 0x000F0C44 File Offset: 0x000EEE44
    //	public void ActiveDoMove(float Speed, GameObject destActor, Vector3 destPos)
    //	{
    //		this.agent.speed = Speed;
    //		this.agent.enabled = false;
    //		this.agent.enabled = true;
    //		this.curCtrlMode = ControlMode.ControlByAgent;
    //		if (destActor != null)
    //		{
    //			this.animator.SetBool("Move", true);
    //			this.landmark = destActor.GetComponent<Landmark>();
    //			if (this.landmark != null)
    //			{
    //				this.SetDestination(this.landmark);
    //			}
    //			else
    //			{
    //				this.SetDestination(destActor, destPos);
    //			}
    //		}
    //		else
    //		{
    //			this.animator.SetBool("Move", true);
    //			this.SetDestination(destPos);
    //		}
    //		AnimatorValueRestore component = base.GetComponent<AnimatorValueRestore>();
    //		if (component != null)
    //		{
    //			UnityEngine.Object.Destroy(component);
    //		}
    //	}

    //	// Token: 0x06001ADD RID: 6877 RVA: 0x000F0D08 File Offset: 0x000EEF08
    //	public void DeActiveDoMove(bool resetCtrlMode = false)
    //	{
    //		if (!base.gameObject.activeSelf)
    //		{
    //			return;
    //		}
    //		if (this.agent == null)
    //		{
    //			return;
    //		}
    //		this.agent.SetDestination(base.transform.position);
    //		if (resetCtrlMode)
    //		{
    //			this.curCtrlMode = ControlMode.None;
    //		}
    //	}

    //	// Token: 0x06001ADE RID: 6878 RVA: 0x000F0D5C File Offset: 0x000EEF5C
    //	public static void DeActiveDoMove(GameObject go, bool resetCtrlMode = false)
    //	{
    //		if (go == null)
    //		{
    //			return;
    //		}
    //		go = go.GetModelObj(false);
    //		Agent component = go.GetComponent<Agent>();
    //		if (component != null)
    //		{
    //			component.DeActiveDoMove(resetCtrlMode);
    //		}
    //	}

    //	// Token: 0x06001ADF RID: 6879 RVA: 0x000F0D9C File Offset: 0x000EEF9C
    //	public void Pause()
    //	{
    //	}

    //	// Token: 0x06001AE0 RID: 6880 RVA: 0x000F0DA0 File Offset: 0x000EEFA0
    //	public void SetupAgentLocomotionByUScript()
    //	{
    //		float speed = this.agent.desiredVelocity.magnitude * this.AgentSpeedK;
    //		Vector3 vector = Quaternion.Inverse(base.transform.rotation) * this.agent.desiredVelocity;
    //		float direction = Mathf.Atan2(vector.x, vector.z) * 180f / 3.1415927f;
    //		this.locomotion.Do(speed, direction, base.transform, this.agent.desiredVelocity);
    //	}

    //	// Token: 0x06001AE1 RID: 6881 RVA: 0x000F0E28 File Offset: 0x000EF028
    //	public void SetupAgentStopByUScript()
    //	{
    //		this.locomotion.Do(0f, 0f, base.transform, this.agent.desiredVelocity);
    //	}

    //	// Token: 0x06001AE2 RID: 6882 RVA: 0x000F0E5C File Offset: 0x000EF05C
    //	public float GetSpeed()
    //	{
    //		return this.animator.GetFloat("Speed");
    //	}

    //	// Token: 0x06001AE3 RID: 6883 RVA: 0x000F0E70 File Offset: 0x000EF070
    //	public bool AgentDone()
    //	{
    //		return !this.agent.pathPending && this.AgentStopping();
    //	}

    //	// Token: 0x06001AE4 RID: 6884 RVA: 0x000F0E8C File Offset: 0x000EF08C
    //	protected bool AgentStopping()
    //	{
    //		return !base.gameObject.activeSelf || this.agent.remainingDistance <= this.agent.stoppingDistance;
    //	}

    //	// Token: 0x06001AE5 RID: 6885 RVA: 0x000F0EC8 File Offset: 0x000EF0C8
    //	public bool AgentInJudgeStopPos()
    //	{
    //		return !base.gameObject.activeSelf || this.agent.remainingDistance < this.JudgeStopDistance;
    //	}

    //	// Token: 0x06001AE6 RID: 6886 RVA: 0x000F0EFC File Offset: 0x000EF0FC
    //	public float GetRadius()
    //	{
    //		float result = 1f;
    //		if (this.agent != null)
    //		{
    //			result = this.agent.radius;
    //		}
    //		else if (this.charCtrller != null)
    //		{
    //			result = this.charCtrller.radius;
    //		}
    //		else if (base.GetComponent<Collider>() != null)
    //		{
    //			SphereCollider component = base.GetComponent<SphereCollider>();
    //			if (component != null)
    //			{
    //				result = component.radius;
    //			}
    //			else
    //			{
    //				CapsuleCollider component2 = base.GetComponent<CapsuleCollider>();
    //				if (component2 != null)
    //				{
    //					result = component2.radius;
    //				}
    //				else
    //				{
    //					result = base.GetComponent<Collider>().bounds.extents.magnitude;
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x06001AE7 RID: 6887 RVA: 0x000F0FC0 File Offset: 0x000EF1C0
    //	private void NavAgentMove()
    //	{
    //		if (!float.IsNaN(this.animator.deltaPosition.x) && Time.deltaTime != 0f)
    //		{
    //			this.agent.velocity = this.animator.deltaPosition / Time.deltaTime;
    //		}
    //		else
    //		{
    //			this.agent.velocity = Vector3.zero;
    //		}
    //		if (this.agent.desiredVelocity.magnitude > 0f)
    //		{
    //			float num = (-Vector3.Dot(base.transform.forward, this.agent.desiredVelocity) + 2f) * 2f;
    //			base.transform.forward = Vector3.Lerp(base.transform.forward, this.agent.desiredVelocity, Time.deltaTime * 7.1f * num);
    //		}
    //	}

    //	// Token: 0x06001AE8 RID: 6888 RVA: 0x000F10A8 File Offset: 0x000EF2A8
    //	public void AgentUpdate()
    //	{
    //		if (this.CanFall())
    //		{
    //			this.Fall();
    //		}
    //		if (this.IsInSky && this.locomotion.ZhiKongSpeedVec != Vector3.zero)
    //		{
    //			float num = Vector3.Angle(base.transform.forward, this.locomotion.ZhiKongSpeedVec);
    //			if (num > 1f)
    //			{
    //				base.transform.forward = Vector3.Lerp(base.transform.forward, this.locomotion.ZhiKongSpeedVec, this.JumpTurnBodySpeed * Time.deltaTime);
    //			}
    //		}
    //	}

    //	// Token: 0x06001AE9 RID: 6889 RVA: 0x000F1144 File Offset: 0x000EF344
    //	private IEnumerator TurnBodyOnJump()
    //	{
    //		float angle = Vector3.Angle(base.transform.forward, this.locomotion.ZhiKongSpeedVec);
    //		while (angle > 5f && this.IsInSky)
    //		{
    //			base.transform.forward = Vector3.Lerp(base.transform.forward, this.locomotion.ZhiKongSpeedVec, this.JumpTurnBodySpeed * Time.deltaTime);
    //			angle = Vector3.Angle(base.transform.forward, this.locomotion.ZhiKongSpeedVec);
    //			yield return 0;
    //		}
    //		yield break;
    //	}

    //	// Token: 0x06001AEA RID: 6890 RVA: 0x000F1160 File Offset: 0x000EF360
    //	private IEnumerator slowDownVel()
    //	{
    //		float speed = (!this.CanSmallMove) ? this.AniRunSpeed : this.SmallMoveSpeed;
    //		float targetSpeed = speed * this.SlowDegree;
    //		Vector3 dir = this.locomotion.ZhiKongSpeedVec.normalized;
    //		while (targetSpeed < speed && this.IsInSky && this.bSlow)
    //		{
    //			speed = Mathf.SmoothDamp(speed, targetSpeed, ref this.SlowSpeed, this.SlowSmoothTime);
    //			this.locomotion.ZhiKongSpeedVec = dir * speed;
    //			yield return 0;
    //		}
    //		yield break;
    //	}

    //	// Token: 0x06001AEB RID: 6891 RVA: 0x000F117C File Offset: 0x000EF37C
    //	public void SlowDownVel()
    //	{
    //		this.CanSlowByKeyUp = false;
    //		this.bSlow = true;
    //		base.StartCoroutine(this.slowDownVel());
    //	}

    //	// Token: 0x06001AEC RID: 6892 RVA: 0x000F119C File Offset: 0x000EF39C
    //	public bool CanFall()
    //	{
    //		if (!this.IsInSky && this.charCtrller != null && !this.charCtrller.isGrounded && this.charCtrller.velocity.y < -this.XiaLuoSpeed)
    //		{
    //			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
    //			if (!currentAnimatorStateInfo.IsName("yidongState.TiaoQi") && !currentAnimatorStateInfo.IsName("yidongState.ZhiKong") && !currentAnimatorStateInfo.IsName("yidongState.ZhuoDi"))
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06001AED RID: 6893 RVA: 0x000F1238 File Offset: 0x000EF438
    //	public void Fall()
    //	{
    //		this.locomotion.firstShang = false;
    //		this.IsInSky = true;
    //		UIManager.Instance.DoNotOpenMainMenu = true;
    //		this.animatorMoveClient = base.gameObject.GetComponent<AnimatorMoveClient>();
    //		if (this.animatorMoveClient == null)
    //		{
    //			this.animatorMoveClient = base.gameObject.AddComponent<AnimatorMoveClient>();
    //		}
    //		AnimatorMoveClient animatorMoveClient = this.animatorMoveClient;
    //		animatorMoveClient.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Remove(animatorMoveClient.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.JumpProcessMove));
    //		AnimatorMoveClient animatorMoveClient2 = this.animatorMoveClient;
    //		animatorMoveClient2.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Combine(animatorMoveClient2.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.JumpProcessMove));
    //		this.VerticalSpeed = -2f;
    //		this.animator.SetFloat("VerticalSpeed", this.VerticalSpeed);
    //		this.animCtrl.ActiveAnimCrossFade("ZhiKong", false, 0.1f, true);
    //		this.locomotion.ZhiKongSpeedVec = Vector3.zero;
    //		this.CanSecondJump = true;
    //		this.CanSmallMove = false;
    //		this.CanSlowByKeyUp = false;
    //		this.bSlow = false;
    //	}

    //	// Token: 0x06001AEE RID: 6894 RVA: 0x000F1348 File Offset: 0x000EF548
    //	public virtual void OnJumpEvent(float JumpSpeedK)
    //	{
    //		AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
    //		if (currentAnimatorStateInfo.IsName("yidongState.TiaoQi"))
    //		{
    //			if (this.IsInSky)
    //			{
    //				return;
    //			}
    //		}
    //		else if (currentAnimatorStateInfo.IsName("yidongState.TiaoQi") && !this.CanSecondJump)
    //		{
    //			return;
    //		}
    //		if (JumpSpeedK < 0.001f)
    //		{
    //			JumpSpeedK = 1f;
    //		}
    //		this.locomotion.firstShang = false;
    //		float num = (!this.CanSecondJump) ? this.jumpPowerSecond : this.jumpPower;
    //		this.VerticalSpeed = JumpSpeedK * this.JumpSpeed * num;
    //		this.animatorMoveClient = base.gameObject.GetComponent<AnimatorMoveClient>();
    //		if (this.animatorMoveClient == null)
    //		{
    //			this.animatorMoveClient = base.gameObject.AddComponent<AnimatorMoveClient>();
    //		}
    //		AnimatorMoveClient animatorMoveClient = this.animatorMoveClient;
    //		animatorMoveClient.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Remove(animatorMoveClient.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.JumpProcessMove));
    //		AnimatorMoveClient animatorMoveClient2 = this.animatorMoveClient;
    //		animatorMoveClient2.apply = (AnimatorMoveClient.AnimatorMoveApplyFunc)Delegate.Combine(animatorMoveClient2.apply, new AnimatorMoveClient.AnimatorMoveApplyFunc(this.JumpProcessMove));
    //		this.animator.SetFloat("VerticalSpeed", this.VerticalSpeed);
    //		Vector3 curMoveDir = PlayerCtrlManager.GetCurMoveDir();
    //		this.locomotion.ZhiKongSpeedVec = curMoveDir.normalized;
    //		this.locomotion.ZhiKongSpeedVec.y = 0f;
    //		this.locomotion.ZhiKongSpeedVec *= this.locomotion.ZhiKongMag;
    //		if (this.locomotion.ZhiKongSpeedVec == Vector3.zero)
    //		{
    //			this.CanSmallMove = true;
    //		}
    //		else
    //		{
    //			this.CanSmallMove = false;
    //			this.CanSlowByKeyUp = true;
    //		}
    //		if (!this.CanSecondJump)
    //		{
    //			this.locomotion.ZhiKongSpeedVec *= this.SecondJumpDegree;
    //		}
    //		this.bSlow = false;
    //	}

    //	// Token: 0x06001AEF RID: 6895 RVA: 0x000F1534 File Offset: 0x000EF734
    //	public virtual void OnJumpStart()
    //	{
    //		AnimEvent animEvent = this.animEvent;
    //		animEvent.OnProcessFun = (AnimEvent.void_fun)Delegate.Remove(animEvent.OnProcessFun, new AnimEvent.void_fun(this.JumpProcess));
    //		AnimEvent animEvent2 = this.animEvent;
    //		animEvent2.OnProcessFun = (AnimEvent.void_fun)Delegate.Combine(animEvent2.OnProcessFun, new AnimEvent.void_fun(this.JumpProcess));
    //		this.orgColliderHeight = this.charCtrller.height;
    //		this.orgHeight = this.charCtrller.center.y;
    //		this.CanSecondJump = true;
    //		this.bJumpStart = true;
    //	}

    //	// Token: 0x06001AF0 RID: 6896 RVA: 0x000F15CC File Offset: 0x000EF7CC
    //	public virtual void JumpProcess()
    //	{
    //		float @float = this.animator.GetFloat("Height");
    //		float float2 = this.animator.GetFloat("ColliderHeight");
    //		this.charCtrller.height = this.orgColliderHeight * float2;
    //		this.tempCtrlCenter.y = this.orgHeight + @float;
    //		this.charCtrller.center = this.tempCtrlCenter;
    //	}

    //	// Token: 0x06001AF1 RID: 6897 RVA: 0x000F1634 File Offset: 0x000EF834
    //	public virtual void OnJumpOver()
    //	{
    //		AnimEvent animEvent = this.animEvent;
    //		animEvent.OnProcessFun = (AnimEvent.void_fun)Delegate.Remove(animEvent.OnProcessFun, new AnimEvent.void_fun(this.JumpProcess));
    //		this.charCtrller.height = this.orgColliderHeight;
    //		this.tempCtrlCenter.y = this.orgHeight;
    //		this.charCtrller.center = this.tempCtrlCenter;
    //		this.CanSecondJump = false;
    //		this.bJumpStart = false;
    //	}

    //	// Token: 0x06001AF2 RID: 6898 RVA: 0x000F16AC File Offset: 0x000EF8AC
    //	private void JumpProcessMove()
    //	{
    //		AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
    //		AnimatorStateInfo nextAnimatorStateInfo = this.animator.GetNextAnimatorStateInfo(0);
    //		float num = -Physics.gravity.y * this.gravityK;
    //		if (!this.charCtrller.isGrounded)
    //		{
    //			this.animator.SetFloat("VerticalSpeed", this.VerticalSpeed);
    //		}
    //		if (!this.IsInSky && currentAnimatorStateInfo.IsName("yidongState.ZhiKong"))
    //		{
    //			this.IsInSky = true;
    //		}
    //		if (((this.IsInSky && !this.charCtrller.isGrounded && !this.animator.GetBool("ZhuoDi")) || (this.IsInSky && this.charCtrller.isGrounded)) && !nextAnimatorStateInfo.IsName("yidongState.ZhuoDi") && !currentAnimatorStateInfo.IsName("yidongState.ZhuoDi"))
    //		{
    //			this.IsUsedInSky = true;
    //			RaycastHit raycastHit;
    //			if (this.charCtrller.velocity.y < 0f && Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, float.PositiveInfinity, Cutscene.MaskValue) && raycastHit.distance < this.ZhuoDiDistance)
    //			{
    //				this.JumpFinish();
    //			}
    //		}
    //		if (this.IsUsedInSky && this.charCtrller.isGrounded && !currentAnimatorStateInfo.IsName("yidongState.TiaoQi4") && !nextAnimatorStateInfo.IsName("yidongState.TiaoQi4"))
    //		{
    //			this.JumpFinish();
    //		}
    //		Vector3 motion = base.transform.forward;
    //		SlideDown instance = SlideDown.Instance;
    //		if (instance != null && instance.enabled)
    //		{
    //			Vector3 normalized = this.locomotion.ZhiKongSpeedVec.normalized;
    //			float magnitude = this.locomotion.ZhiKongSpeedVec.magnitude;
    //			this.locomotion.ZhiKongSpeedVec = normalized * magnitude * this.JumpMoveRatioWhenSlide;
    //		}
    //		motion = this.locomotion.ZhiKongSpeedVec * Time.deltaTime;
    //		base.transform.rotation = this.animator.rootRotation;
    //		this.VerticalSpeed += -num * Time.deltaTime;
    //		motion.y = this.VerticalSpeed * Time.deltaTime;
    //		if (this.charCtrller.Move(motion) == CollisionFlags.Below)
    //		{
    //			this.VerticalSpeed = 0f;
    //		}
    //	}

    //	// Token: 0x06001AF3 RID: 6899 RVA: 0x000F1930 File Offset: 0x000EFB30
    //	private void JumpFinish()
    //	{
    //		this.IsUsedInSky = false;
    //		this.IsInSky = false;
    //		this.CanSlowByKeyUp = false;
    //		bool @bool = this.animator.GetBool("Move");
    //		if (@bool)
    //		{
    //			this.animator.CrossFade("ZhuoDi", this.CrossZhuoDiTime);
    //		}
    //		else
    //		{
    //			this.animator.CrossFade("ZhuoDi", 0.025f);
    //		}
    //		this.ZhuoDiTime = 100f;
    //		this.locomotion.ZhiKongSpeedVec = Vector3.zero;
    //		if (this.bJumpStart)
    //		{
    //			this.OnJumpOver();
    //		}
    //		UnityEngine.Object.DestroyImmediate(this.animatorMoveClient);
    //		this.IsJump = false;
    //		SlideDown orAddComponent = base.gameObject.GetOrAddComponent<SlideDown>();
    //		orAddComponent.enabled = true;
    //		SneakAttack.canQiXi = true;
    //		LateSetDoNotOpenMainMenu.Instance.Set(false, 0.4f);
    //		this.palNPC.footMark.OnJumpFinish();
    //	}

    //	// Token: 0x06001AF4 RID: 6900 RVA: 0x000F1A10 File Offset: 0x000EFC10
    //	private void OnDestroy()
    //	{
    //		this.animator = null;
    //	}

    //	// Token: 0x06001AF5 RID: 6901 RVA: 0x000F1A1C File Offset: 0x000EFC1C
    //	private void OnEnable()
    //	{
    //		if (this.palNPC != null && this.palNPC.gameObject.IsMonster())
    //		{
    //			Interact component = this.palNPC.GetComponent<Interact>();
    //			if (component != null)
    //			{
    //				component.SendMessageToBehaviour("stroll", "Start");
    //			}
    //			this.palNPC.gameObject.SetEnableStroll(true);
    //		}
    //	}

    //	// Token: 0x06001AF6 RID: 6902 RVA: 0x000F1A88 File Offset: 0x000EFC88
    //	private void OnDisable()
    //	{
    //		if (this.palNPC != null && this.palNPC.gameObject.IsMonster())
    //		{
    //			this.DeActiveDoMove(false);
    //			Interact component = this.palNPC.GetComponent<Interact>();
    //			if (component != null)
    //			{
    //				component.SendMessageToBehaviour("stroll", "Pause");
    //				component.SendMessageToBehaviour("Pursue", "Pause");
    //			}
    //			this.palNPC.gameObject.SetEnableStroll(false);
    //		}
    //	}
}
