//using SoftStarStatisticsSheet;
using System;
using System.Collections;
using UnityEngine;

public class M_PlayerController : M_GameRoleBase
{
	public enum BaseState
	{
		Base,
		Climb,
		Combat,
		Jump,
		Falling,
		TalkTurn
	}

	[Serializable]
	public class AnimControllers
	{
		public RuntimeAnimatorController baseC;

		public RuntimeAnimatorController climb;
	}

	public enum ClimbState
	{
		Stair,
		AutoClimb,
		Climb,
		Top,
		ClimbLadderTop,
		Corner,
		Wall,
		Area,
		Edge,
		Grabble,
		GrabbleUp,
		None
	}

	private class RayHitComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
		}
	}

	public const float GROUND_DISTANCE_TEST = 0.075f;

	public M_PlayerController.BaseState m_BaseState;

	public M_PlayerController.AnimControllers animCtrl;

	public M_PlayerController.ClimbState m_ClimbState = M_PlayerController.ClimbState.None;

	[NonSerialized]
	public float lookWeight;

	[NonSerialized]
	public Transform enemy;

	public GameObject m_PickTarget;

	public float m_RunSpeed = 1f;

	public float m_AtuoMoveSpeed;

	public float m_WalkMultiplier = 1f;

	public float m_DashMultiplier = 1.5f;

	public float m_JumpHeight = 1.5f;

	public float m_Gravity = 50f;

	public float m_DownGravity = 0.4f;

	public float m_MaxVelocityChange = 1f;

	public bool m_IsDash;

	public bool m_bPlayNormalMotion;

	public Vector3 m_PreMoveVelocity;

	public float m_AutoMoveDist = 0.5f;

	public float m_AutoMoveStopDist = 0.5f;

	public float m_WaterWaveTime = 0.5f;

	public bool m_SlowMove;

	public bool m_Reverse;

	public bool m_NoJump;

	public bool m_AutoMove;

	public bool m_WalkInWater;

	public bool m_DoJump;

	public bool m_WalkMask;

	public bool m_LMouseDown;

	public bool m_EnterTalkEvent;

	public float m_AnimSpeed = 1f;

	public float m_WalkSpeed = 0.25f;

	public float m_TurnDir;

	public float m_RotateSpeed = 15f;

	public float m_CanMoveDelta = 0.4f;

	public float m_IdleBlendSpeed = 0.2f;

	public float m_WalkBlendSpeed = 0.1f;

	public float m_RuuBlendSpeed = 0.5f;

	public bool m_IsRun = true;

	public bool m_LockControl;

	public float m_footWidth = 4.5f;

	public float m_GroundStickyEffect = 5f;

	public bool m_IsAutoMove;

	public bool m_UseCurves;

	public bool m_Slide;

	public bool m_SprintJump;

	public bool m_SlideLoop;

	public bool m_MarthTarget;

	public bool m_FootIK;

	public float m_JumpNeedLenthMin = 1.5f;

	public float m_JumpNeedLenthMax = 4f;

	public float m_SlideMatchTargetStart = 0.11f;

	public float m_SlideMatchTargetStop = 0.4f;

	public float m_SprintJumpMatchTargetStart = 0.4f;

	public float m_SprintJumpMatchTargetStop = 0.51f;

	public float m_SprintJumpTime = 0.8f;

	public float m_ClimbMatchTargetStart = 0.19f;

	public float m_ClimbMatchTargetStop = 0.3f;

	public float m_ClimbBackJumpMatchTargetStart = 0.19f;

	public float m_ClimbBackJumpMatchTargetStop = 0.3f;

	public float m_SlideLoopMatchTargetStart = 0.19f;

	public float m_SlideLoopMatchTargetStop = 0.3f;

	public float m_MouseAttackTime;

	public float m_MouseMaxAttackTime = 0.13f;

	public float m_ResearchTargetTime;

	public LayerMask groundLayers = -1;

	public LayerMask wallRunLayers = -1;

	public float groundedDistance = 3f;

	public float groundedTime;

	public float groundedMaxTime = 0.5f;

	private bool grounded;

	private bool jumpGrounded;

	public Vector3 m_AutoMoveTargetPos = new Vector3(0f, 0f, 0f);

	public GameObject m_CameraViewTarget;

	public GameObject m_MoveTargetObj;

	public GameObject m_FaceTargetObj;

	public Vector3 m_ActionTarget = default(Vector3);

	public Vector3 m_Velocity = default(Vector3);

	private Animator m_Anim;

	private AnimatorStateInfo m_CurrentBaseState;

	private RaycastHit groundHit;

	//private M_AStarAI m_AstarAI;

	private GameObject m_WeaponObj;

	private bool m_ShowWeaponEffect;

	private static int idleState = Animator.StringToHash("Base Layer.Idle");

	private static int locoState = Animator.StringToHash("Base Layer.Locomotion");

	private static int waveState = Animator.StringToHash("Layer2.Wave");

	private static string idleTag = "Idle";

	private static string locoTag = "Loco";

	public LayerMask climbLayers = 512;

	public float climbSpeed = 0.7f;

	public float climbCheckRadius = 0.4f;

	public float climbCheckDistance = 3f;

	public float climbOffsetToWall = 0.2f;

	public float heightOffsetToEdge = 1f;

	public float smoothDistanceSpeed = 2f;

	public float cornerSideOffset = 0.4f;

	public float setFloatDampTime = 0.15f;

	private bool doClimb;

	private bool doGrabble;

	public bool bWalk;

	private bool bPressDirKey;

	private float cacheDist;

	private bool bTurnWalk;

	public float m_UpdateAutoMoveTime;

	public float m_StartIdleTime = 15f;

	public float m_UpdateIdleTime;

	//public ENUM_IDLESTATE m_IdelState;

	private Vector3 activeLocalPlatformPoint;

	private Vector3 activeGlobalPlatformPoint;

	private Transform activePlatform;

	public CharacterController m_Controller;

	private Vector3 nextPoint;

	private Rigidbody cRigidbody;

	private IComparer rayHitComparer;

	//private ShroudInstance m_ShroudInstance;

	private static RaycastHit sGroundCollisionInfo = default(RaycastHit);

	private float mGroundDragDuration = 0.1f;

	public bool m_CheckSlop;

	public float m_SlopDownSpeed = 10f;

	public Vector3 _Gravity = new Vector3(0f, -11.81f, 0f);

	public float _MinSlideAngle = 60f;

	private Vector3 mAccumulatedAcceleration = Vector3.zero;

	private Vector3 mAccumulatedVelocity = Vector3.zero;

	private Vector3 mRootMotionVelocity = Vector3.zero;

	private Quaternion mRootMotionAngularVelocity = Quaternion.identity;

	//public ControllerState m_State = default(ControllerState);

	//protected ControllerState m_PrevState = default(ControllerState);

	[HideInInspector]
	public float horizontal;

	[HideInInspector]
	public float vertical;

	public bool Grounded
	{
		get
		{
			return this.grounded;
		}
	}

	public GameObject m_MoveTarget
	{
		get;
		set;
	}

	public int PlayerMask
	{
		get
		{
			int num = 16384;
			return ~num;
		}
	}

	public Vector3 Gravity
	{
		get
		{
			return this._Gravity;
		}
		set
		{
			this._Gravity = value;
		}
	}

	public float MinSlideAngle
	{
		get
		{
			return this._MinSlideAngle;
		}
		set
		{
			this._MinSlideAngle = value;
		}
	}

	public Vector3 AccumulatedAcceleration
	{
		get
		{
			return this.mAccumulatedAcceleration;
		}
	}

	public Vector3 AccumulatedVelocity
	{
		get
		{
			return this.mAccumulatedVelocity;
		}
		set
		{
			this.mAccumulatedVelocity = value;
		}
	}

	public Vector3 RootMotionVelocity
	{
		get
		{
			return this.mRootMotionVelocity;
		}
		set
		{
			this.mRootMotionVelocity = value;
		}
	}

	public Quaternion RootMotionAngularVelocity
	{
		get
		{
			return this.mRootMotionAngularVelocity;
		}
		set
		{
			this.mRootMotionAngularVelocity = value;
		}
	}

	//public ControllerState State
	//{
	//	get
	//	{
	//		return this.m_State;
	//	}
	//	set
	//	{
	//		this.m_State = value;
	//	}
	//}

	//public ControllerState PrevState
	//{
	//	get
	//	{
	//		return this.m_PrevState;
	//	}
	//	set
	//	{
	//		this.m_PrevState = value;
	//	}
	//}

	public bool LockControl
	{
		get
		{
			return this.m_LockControl;
		}
		set
		{
			this.m_LockControl = value;
			if (this.m_LockControl)
			{
				this.StopAutoMove();
			}
		}
	}

	public GameObject MoveTarget
	{
		get
		{
			return this.m_MoveTarget;
		}
		set
		{
			this.m_MoveTarget = value;
		}
	}

	public bool EnterTalk
	{
		get
		{
			return this.m_EnterTalk;
		}
		set
		{
			this.m_EnterTalk = value;
		}
	}

	public override bool NoCollider
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.NoCollider);
		}
		set
		{
			if (value)
			{
				this.m_EnterTalk = false;
				this.m_RoleState.Set(ENUM_GameObjFlag.NoCollider);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.NoCollider);
			}
			CharacterController component = base.gameObject.GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = !value;
			}
		}
	}

	protected override void initialize()
	{
	}

	private void Awake()
	{
		this.m_Controller = base.GetComponent<CharacterController>();
	}

	private void Start()
	{
		//this.m_AstarAI = base.GetComponent<M_AStarAI>();
		this.m_Animator = (this.m_Anim = base.GetComponent<Animator>());
		Rigidbody[] componentsInChildren = base.gameObject.GetComponentsInChildren<Rigidbody>();
		this.cRigidbody = componentsInChildren[0];
		this.cRigidbody.isKinematic = false;
		this.cacheDist = this.climbCheckDistance;
		this.rayHitComparer = new M_PlayerController.RayHitComparer();
		if (!base.gameObject.GetComponent<Rigidbody>())
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
		}
		//if (Swd6Application.instance != null)
		//{
		//	base.RoleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
		//}
		this.m_RoleMotion = base.gameObject.AddComponent<M_GameRoleMotion>();
		if (this.m_RoleMotion != null)
		{
			this.m_RoleMotion.Init(base.RoleID, 1);
		}
		//ShroudInstance[] componentsInChildren2 = base.GetComponentsInChildren<ShroudInstance>();
		//this.m_ShroudInstance = componentsInChildren2[0];
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
		this.m_RunSpeed = 1f;
		S_StartRoleData data = GameDataDB.StartRoleDB.GetData(base.RoleID);
		if (data != null)
		{
			this.m_RunSpeed = data.MoveSpeed;
		}
	}

	public bool IsGround()
	{
		return false;
	}

	public bool IsJump()
	{
		return false;
	}

	public override void StopMove()
	{
		this.MoveTarget = null;
		this.StopAutoMove();
	}

	public void StopMoveToTarget()
	{
		//if (this.m_AstarAI != null)
		//{
		//	this.m_AstarAI.Stop();
		//}
		this.m_AtuoMoveSpeed = 0f;
		this.m_WalkSpeed = 0f;
		base.MoveRole = false;
		this.m_MoveTarget = null;
		this.m_IsAutoMove = false;
		this.bWalk = false;
		this.m_RotateDirection = Vector3.zero;
		this.m_MoveDirection = Vector3.zero;
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
		if (this.m_Anim != null)
		{
			this.m_Anim.SetFloat("Speed", 0f);
		}
		//if (Swd6Application.instance != null)
		//{
		//	Swd6Application.instance.m_ExploreSystem.ShowMoveTarget(false, Vector3.zero);
		//}
	}

	public override void StopAutoMove()
	{
		//if (this.m_AstarAI != null)
		//{
		//	this.m_AstarAI.Stop();
		//}
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
		if (this.m_AtuoMoveSpeed > 0f)
		{
			this.PlayMotion(1, 0.1f);
			this.m_AtuoMoveSpeed = 0f;
		}
		this.m_WalkSpeed = 0f;
		base.MoveRole = false;
		this.m_MoveTarget = null;
		this.m_IsAutoMove = false;
		this.bWalk = false;
		this.m_RotateDirection = Vector3.zero;
		this.m_MoveDirection = Vector3.zero;
		if (this.m_Anim != null)
		{
			this.m_Anim.applyRootMotion = false;
			//if (Swd6Application.instance != null)
			//{
			//	if (!this.LockControl)
			//	{
			//		if (Swd6Application.instance.m_ExploreSystem.BattleID > 0)
			//		{
			//			this.m_Anim.SetFloat("Speed", 0f);
			//		}
			//		else
			//		{
			//			this.m_Anim.SetFloat("Speed", 0f, this.m_IdleBlendSpeed, Time.deltaTime);
			//		}
			//	}
			//}
			//else
			//{
			//	this.m_Anim.SetFloat("Speed", 0f);
			//}
		}
		//if (Swd6Application.instance != null)
		//{
		//	Swd6Application.instance.m_ExploreSystem.ShowMoveTarget(false, Vector3.zero);
		//}
	}

	public override void Update()
	{
		if (this.m_Anim == null)
		{
			return;
		}
		//if (Swd6Application.instance != null)
		//{
		//	GameState currentState = Swd6Application.instance.gameStateService.getCurrentState();
		//	if (currentState == null)
		//	{
		//		return;
		//	}
		//	if (currentState.name != "ExploreState")
		//	{
		//		return;
		//	}
		//}
		//this.m_CurrentBaseState = this.m_Anim.GetCurrentAnimatorStateInfo(0);
		//if (this.m_Controller != null)
		//{
		//	this.m_Controller.velocity.y = 0f;
		//	this.grounded = Physics.Raycast(base.transform.position + base.transform.up * this.m_Controller.center.y, base.transform.up * -1f, out this.groundHit, this.groundedDistance, this.groundLayers);
		//}
		this.m_Velocity = this.cRigidbody.velocity;
		switch (this.m_BaseState)
		{
		case M_PlayerController.BaseState.Base:
			this.UpdateSupportMove();
			this.UpdateAutoMoveTime();
			this.UpdateBaseInput();
			this.UpdateIdleMotion();
			this.UpdatePlayerTalk();
			base.UpdateTurn();
			this.UpdateSlopMovement(Time.deltaTime);
			break;
		case M_PlayerController.BaseState.Combat:
			this.UpdateCombat();
			break;
		case M_PlayerController.BaseState.Jump:
			this.UpdateJump();
			break;
		case M_PlayerController.BaseState.Falling:
			this.UpdateFalling();
			break;
		case M_PlayerController.BaseState.TalkTurn:
			this.UpdateTalkTurn();
			break;
		}
		//if (Swd6Application.instance != null)
		//{
		//	Swd6Application.instance.m_GameObjSystem.UpdatePlayerMaterailEffect(base.gameObject);
		//}
	}

	private void HandleGroundedVelocities()
	{
		this.m_Velocity.y = 0f;
		if (this.m_MoveDirection.magnitude == 0f)
		{
			this.m_Velocity.x = 0f;
			this.m_Velocity.z = 0f;
		}
		bool flag = this.m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") || this.m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("Loco");
		if (this.m_DoJump && flag)
		{
			this.grounded = false;
			this.m_Velocity = this.m_MoveDirection * 2f;
			this.m_Velocity.y = this.m_JumpHeight;
		}
	}

	private void HandleAirborneVelocities()
	{
		Vector3 to = new Vector3(this.m_MoveDirection.x * 6f, this.m_Velocity.y, this.m_MoveDirection.z * 6f);
		this.m_Velocity = Vector3.Lerp(this.m_Velocity, to, Time.deltaTime * 2f);
		this.cRigidbody.useGravity = true;
		Vector3 force = Physics.gravity * 2f - Physics.gravity;
		this.cRigidbody.AddForce(force);
	}

	private void UpdateAnimator()
	{
		this.m_Anim.SetBool("Ground", this.grounded);
		if (!this.grounded)
		{
			this.m_Anim.SetFloat("JumpHeight", this.m_Velocity.y);
		}
		if (this.grounded && this.m_MoveDirection.magnitude > 0f)
		{
			this.m_Anim.speed = 1f;
		}
		else
		{
			this.m_Anim.speed = 1f;
		}
	}

	private void UpdateJumpGravity()
	{
		if (this.m_Controller != null && this.m_BaseState == M_PlayerController.BaseState.Jump)
		{
			Vector3 velocity = this.m_Controller.velocity;
			Vector3 vector = velocity;
			if (this.m_MoveDirection != Vector3.zero || this.m_IsAutoMove)
			{
				this.m_PreMoveVelocity = vector;
				Vector3 vector2 = this.m_MoveDirection - velocity;
				if (vector2.magnitude > this.m_MaxVelocityChange)
				{
					vector2 = vector2.normalized * this.m_MaxVelocityChange;
				}
			}
			else
			{
				vector = Vector3.zero;
				if (!this.grounded)
				{
					vector = Vector3.Lerp(this.m_PreMoveVelocity, Vector3.zero, Time.deltaTime);
				}
				vector.y = this.m_Controller.velocity.y;
			}
			if (!this.grounded)
			{
				Vector3 b = Vector3.Lerp(Vector3.zero, this.m_MoveDirection.normalized, Time.deltaTime * this.m_MaxVelocityChange);
				vector += b;
			}
			if (this.m_DoJump)
			{
				vector += base.transform.up * Mathf.Sqrt(2f * this.m_JumpHeight * this.m_Gravity);
				this.m_DoJump = false;
			}
			vector += base.transform.up * -this.m_Gravity * Time.deltaTime;
			CollisionFlags collisionFlags = this.m_Controller.Move(vector * Time.deltaTime);
		}
	}

	public void SetTalkTurn(GameObject target)
	{
		Vector3 lhs = target.transform.position - base.gameObject.transform.position;
		lhs.Normalize();
		float num = Vector3.Dot(lhs, base.gameObject.transform.forward);
		if (num >= 0.8f)
		{
			return;
		}
		this.bTurnWalk = false;
		this.SetTurn(target);
		this.m_BaseState = M_PlayerController.BaseState.TalkTurn;
	}

	private void UpdateTalkTurn()
	{
		if (this.bTurnWalk)
		{
			this.m_Anim.SetFloat("Speed", 0.2f, 0.01f, Time.deltaTime);
			//this.m_FaceTargetObj = Swd6Application.instance.m_ExploreSystem.TalkTarget;
			this.UpdateFaceToTarget();
			return;
		}
		if (!this.m_IsAutoMove)
		{
			this.m_Anim.SetFloat("Speed", 0f, 0.05f, Time.deltaTime);
		}
		this.m_BaseState = M_PlayerController.BaseState.Base;
		this.MoveTarget = null;
	}

	private void UpdateFaceToTarget()
	{
		if (this.m_FaceTargetObj == null)
		{
			this.bTurnWalk = false;
			return;
		}
		this.m_MoveDirection = this.m_FaceTargetObj.transform.position - base.gameObject.transform.position;
		this.m_MoveDirection.y = 0f;
		this.m_MoveDirection.Normalize();
		this.m_RotateDirection = this.m_MoveDirection.normalized;
		this.UpdateRotate();
		this.m_Anim.applyRootMotion = false;
		float num = Vector3.Dot(this.m_MoveDirection, base.gameObject.transform.forward);
		if (num >= 0.99f)
		{
			this.m_FaceTargetObj = null;
			this.bTurnWalk = false;
		}
	}

	public void SetWalk()
	{
		this.bTurnWalk = true;
		this.m_Anim.SetFloat("Speed", 0.2f, 0.05f, Time.deltaTime);
	}

	public void SetTurn(GameObject target)
	{
		this.m_FaceTargetObj = target;
		Vector3 lhs = target.transform.position - base.gameObject.transform.position;
		lhs.Normalize();
		float num = Vector3.Dot(lhs, base.gameObject.transform.forward);
		this.SetWalk();
	}

	private void UpdateAutoMoveTime()
	{
		if (!this.m_IsAutoMove)
		{
			return;
		}
		if (!this.LockControl)
		{
			return;
		}
		this.m_UpdateAutoMoveTime += Time.deltaTime;
		if (this.m_UpdateAutoMoveTime >= 10f)
		{
			this.m_UpdateAutoMoveTime = 0f;
			this.StopAutoMove();
		}
	}

	private void UpdateBaseInput()
	{
		if (this.m_LockControl)
		{
			if (this.bTurnWalk)
			{
				this.m_Anim.SetFloat("Speed", 0.2f, 0.01f, Time.deltaTime);
				this.UpdateFaceToTarget();
			}
			else if (!this.m_IsAutoMove)
			{
				this.m_Anim.SetFloat("Speed", 0f, 0.05f, Time.deltaTime);
			}
			return;
		}
		if (!this.m_Controller.enabled)
		{
			return;
		}
		bool flag = false;
		this.m_DoJump = false;
		if (!this.grounded)
		{
		}
		//if (GameInput.GetKeyActionDown(KEY_ACTION.ACTION) || flag)
		//{
		//	bool flag2 = true;
		//	if (Swd6Application.instance.m_GameDataSystem.GetFlag(41))
		//	{
		//		if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3)
		//		{
		//			if (!Swd6Application.instance.m_ExploreSystem.IsAvoidMob())
		//			{
		//				if (!Swd6Application.instance.m_ExploreSystem.AvoidMob(10f, false))
		//				{
		//					flag2 = false;
		//				}
		//			}
		//			else
		//			{
		//				flag2 = false;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		flag2 = false;
		//	}
		//	if (flag2)
		//	{
		//		if (this.m_IdelState != ENUM_IDLESTATE.None)
		//		{
		//			this.PlayMotion(1, 0.01f);
		//			this.m_UpdateIdleTime = 0f;
		//			this.m_IdelState = ENUM_IDLESTATE.None;
		//		}
		//		if (Swd6Application.instance.m_GameDataSystem.m_PlayerID != 3)
		//		{
		//			this.m_ShowWeaponEffect = false;
		//			if (!this.m_Anim.IsInTransition(0))
		//			{
		//				this.ShowWeaponEffect();
		//			}
		//			this.ShowWeapon(true);
		//		}
		//		this.m_BaseState = M_PlayerController.BaseState.Combat;
		//		this.m_Anim.SetBool("Attack", true);
		//		this.m_Anim.SetFloat("Speed", 0f);
		//		this.m_Anim.speed = this.m_AnimSpeed;
		//		this.m_Anim.applyRootMotion = false;
		//		this.PlayAttackSound();
		//		if (this.m_ShroudInstance != null)
		//		{
		//			this.m_ShroudInstance.ReduceBlendWeight();
		//		}
		//		Swd6Application.instance.m_UserBehavior.EventInfo.Counter(base.RoleID, CounterType.Genius);
		//	}
		//	return;
		//}
		//Vector3 dirKeyMoveVector = GameInput.GetDirKeyMoveVector();
		//this.horizontal = dirKeyMoveVector.x;
		//this.vertical = dirKeyMoveVector.y;
		//Vector3 joyLAxis = new Vector3(this.horizontal, 0f, this.vertical);
		//if (joyLAxis == Vector3.zero)
		//{
		//	joyLAxis = GameInput.GetJoyLAxis();
		//	this.horizontal = joyLAxis.x;
		//	this.vertical = joyLAxis.y;
		//	joyLAxis.z = joyLAxis.y;
		//}
		//Vector3 normalized = Vector3.Scale(Camera.main.transform.forward, new Vector3(1f, 0f, 1f)).normalized;
		//Vector3 direction = this.vertical * normalized + this.horizontal * Camera.main.transform.right;
		//if (joyLAxis.magnitude > 1f)
		//{
		//	joyLAxis.Normalize();
		//}
		//if (direction.magnitude > 1f)
		//{
		//	direction.Normalize();
		//}
		//Vector3 vector = base.transform.InverseTransformDirection(direction);
		//float magnitude = joyLAxis.magnitude;
		//if (magnitude != 0f)
		//{
		//	if (this.m_MoveTarget != null || this.m_IsAutoMove)
		//	{
		//		this.StopAutoMove();
		//	}
		//	this.m_MoveDirection = this.GetMoveDir(joyLAxis);
		//	this.m_MoveDirection.y = 0f;
		//	this.m_RotateDirection = (this.m_MoveDirection = this.m_MoveDirection.normalized);
		//	if (!this.bPressDirKey && this.m_ShroudInstance != null)
		//	{
		//		this.m_ShroudInstance.ReduceBlendWeight();
		//	}
		//	this.bPressDirKey = true;
		//}
		//else
		//{
		//	this.bPressDirKey = false;
		//}
		//this.UpdateMousePickFloor();
		//if (this.m_IsAutoMove)
		//{
		//	this.m_Controller.Move(new Vector3(0f, -this.m_DownGravity, 0f));
		//	return;
		//}
		//this.UpdateRotate();
		//this.m_WalkSpeed = vector.z;
		//if (this.m_WalkSpeed > 0f)
		//{
		//	if (this.m_IdelState == ENUM_IDLESTATE.WaitStart)
		//	{
		//		this.PlayMotion(1, 0.1f);
		//		this.m_IdelState = ENUM_IDLESTATE.None;
		//	}
		//	if (!this.bWalk && this.m_ShroudInstance != null)
		//	{
		//		this.m_ShroudInstance.ReduceBlendWeight();
		//	}
		//	this.bWalk = true;
		//	this.m_UpdateIdleTime = 0f;
		//	this.m_Anim.applyRootMotion = true;
		//	this.m_Anim.speed = this.m_RunSpeed;
		//	this.m_Anim.SetFloat("Speed", this.m_WalkSpeed, this.m_RuuBlendSpeed, Time.deltaTime);
		//}
		//else
		//{
		//	if (this.bWalk)
		//	{
		//		if (this.m_ShroudInstance != null)
		//		{
		//			this.m_ShroudInstance.ReduceBlendWeight();
		//		}
		//		this.m_Anim.applyRootMotion = false;
		//	}
		//	this.bWalk = false;
		//	this.m_Anim.speed = this.m_AnimSpeed;
		//	this.m_Anim.SetFloat("Speed", 0f, this.m_IdleBlendSpeed, Time.deltaTime);
		//	if (this.m_IdelState == ENUM_IDLESTATE.None)
		//	{
		//		this.m_IdelState = ENUM_IDLESTATE.Start;
		//	}
		//}
		//if (this.m_Controller != null && this.m_Controller.enabled)
		//{
		//	this.m_Controller.Move(new Vector3(0f, -this.m_DownGravity, 0f));
		//}
		//if (this.m_CameraViewTarget != null)
		//{
		//	this.m_CameraViewTarget.transform.position = base.transform.position + new Vector3(0f, 1.7f, 0f);
		//}
	}

	private void GroundCheck()
	{
		Ray ray = new Ray(base.transform.position + Vector3.up * 0.1f, -Vector3.up);
		RaycastHit[] array = Physics.RaycastAll(ray, 0.5f);
		Array.Sort(array, this.rayHitComparer);
		if (this.m_Velocity.y < 6f)
		{
			this.grounded = false;
			this.cRigidbody.useGravity = true;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (!raycastHit.collider.isTrigger)
				{
					if (this.m_Velocity.y <= 0f)
					{
						this.cRigidbody.position = Vector3.MoveTowards(this.cRigidbody.position, raycastHit.point, Time.deltaTime * this.m_GroundStickyEffect);
					}
					this.grounded = true;
					this.cRigidbody.useGravity = false;
					break;
				}
			}
		}
	}

	private void UpdateCombat()
	{
		if (!this.m_Anim.IsInTransition(0))
		{
			this.ShowWeaponEffect();
		}
		if (this.m_CurrentBaseState.IsTag("Attack"))
		{
			this.StopAutoMove();
			this.m_Anim.SetBool("Attack", false);
			this.m_Anim.SetFloat("Speed", 0f);
		}
		else if (!this.m_Anim.GetBool("Attack") || this.LockControl)
		{
			this.m_Anim.SetBool("Attack", false);
			this.m_Anim.SetFloat("Speed", 0f);
			this.m_MouseAttackTime = 0f;
			this.m_BaseState = M_PlayerController.BaseState.Base;
			if (!this.LockControl)
			{
				this.ShowWeapon(false);
			}
		}
	}

	private void UpdateJump()
	{
		this.horizontal = Input.GetAxis("Horizontal");
		this.vertical = Input.GetAxis("Vertical");
		this.m_Anim.speed = this.m_AnimSpeed;
		Vector3 normalized = new Vector3(this.horizontal, 0f, this.vertical);
		if (normalized.magnitude > 1f)
		{
			normalized = normalized.normalized;
		}
		this.m_MoveDirection = this.GetMoveDir(normalized);
		this.m_MoveDirection.Normalize();
		this.m_RotateDirection = this.m_MoveDirection;
		this.UpdateJumpGravity();
		this.groundedTime += Time.deltaTime;
		if (this.groundedTime >= this.groundedMaxTime && this.grounded)
		{
			this.m_Anim.SetBool("Ground", this.grounded);
			this.m_Anim.SetBool("CanLand", this.grounded);
			this.m_Anim.SetBool("Jump", false);
			if (this.m_CurrentBaseState.IsTag("Jump"))
			{
				this.m_Anim.SetBool("Jump", false);
			}
			else if (!this.m_Anim.GetBool("Jump") && (this.m_CurrentBaseState.IsTag(M_PlayerController.locoTag) || this.m_CurrentBaseState.IsTag(M_PlayerController.idleTag)))
			{
				if (normalized == Vector3.zero)
				{
					this.m_Anim.SetFloat("Speed", 0f, 0.01f, Time.deltaTime);
				}
				this.m_Anim.applyRootMotion = true;
				this.m_BaseState = M_PlayerController.BaseState.Base;
			}
		}
	}

	private void UpdateFalling()
	{
		this.horizontal = Input.GetAxis("Horizontal");
		this.vertical = Input.GetAxis("Vertical");
		this.m_Anim.speed = this.m_AnimSpeed;
		Vector3 normalized = new Vector3(this.horizontal, 0f, this.vertical);
		if (normalized.magnitude > 1f)
		{
			normalized = normalized.normalized;
		}
		this.m_MoveDirection = this.GetMoveDir(normalized);
		this.UpdateFalingGravity();
		this.m_Anim.SetBool("Ground", this.grounded);
		this.m_Anim.SetBool("CanLand", this.grounded);
		if (this.m_CurrentBaseState.IsTag("Jump"))
		{
			this.m_Anim.SetBool("Falling", false);
		}
		else if (!this.m_Anim.GetBool("Falling") && (this.m_CurrentBaseState.IsTag(M_PlayerController.locoTag) || this.m_CurrentBaseState.IsTag(M_PlayerController.idleTag)))
		{
			this.m_Anim.SetBool("CanLand", false);
			this.m_Anim.applyRootMotion = true;
			this.m_BaseState = M_PlayerController.BaseState.Base;
		}
	}

	private void UpdateFalingGravity()
	{
		if (this.m_Controller != null && this.m_BaseState == M_PlayerController.BaseState.Falling)
		{
			Vector3 velocity = this.m_Controller.velocity;
			Vector3 a = velocity;
			Vector3 vector = velocity - velocity;
			if (vector.magnitude > this.m_MaxVelocityChange)
			{
				vector = vector.normalized * this.m_MaxVelocityChange;
			}
			Vector3 a2 = Vector3.Lerp(Vector3.zero, velocity.normalized, Time.deltaTime * this.m_MaxVelocityChange);
			a -= a2 * 20f;
			a += base.transform.up * -this.m_Gravity * Time.deltaTime;
			CollisionFlags collisionFlags = this.m_Controller.Move(a * Time.deltaTime);
		}
	}

	private void UpdateMousePickFloor()
	{
		//if (Swd6Application.instance != null)
		//{
		//	if (Swd6Application.instance.gameStateService.getCurrentState() == null)
		//	{
		//		Debug.Log("StateNULL");
		//		return;
		//	}
		//	if (Swd6Application.instance.gameStateService.getCurrentState().name != "ExploreState")
		//	{
		//		return;
		//	}
		//	if (GUIManager.instance.DetecteMouseOnUI(false))
		//	{
		//		return;
		//	}
		//}
		if (this.LockControl)
		{
			return;
		}
		bool flag = false;
		if (Input.GetMouseButtonDown(0))
		{
			if (this.m_PickTarget)
			{
				return;
			}
			if (this.m_WalkSpeed > 0f)
			{
				return;
			}
			int num = 32768;
			num |= 4;
			num = ~num;
			RaycastHit raycastHit = default(RaycastHit);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Linecast(ray.origin, ray.origin + ray.direction * 1000f, out raycastHit, num);
			if (null != raycastHit.transform)
			{
				//if (Swd6Application.instance != null && Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
				//{
				//	Debug.Log("Hit_" + raycastHit.collider.name);
				//}
				//if (raycastHit.collider.tag == "Player")
				//{
				//	return;
				//}
				//if (raycastHit.collider.tag == "No Raycast")
				//{
				//	return;
				//}
				//if (GameMath.IsPosEqualXZ(raycastHit.point, base.gameObject.transform.position, 0.6f))
				//{
				//	return;
				//}
				//if (flag)
				//{
				//	this.SetMoveTarget(ray, flag, !flag);
				//	return;
				//}
				//if (Swd6Application.instance != null)
				//{
				//	this.MoveTarget = Swd6Application.instance.m_ExploreSystem.ShowMoveTarget(true, raycastHit.point);
				//}
				this.SetAutoMoveTarget(raycastHit.point);
			}
		}
	}

	private void UpdateRotate()
	{
		if (this.m_RotateDirection != Vector3.zero)
		{
			this.RotateTowards(this.m_RotateDirection);
		}
	}

	protected void RotateTowards(Vector3 dir)
	{
		Quaternion quaternion = base.transform.rotation;
		Quaternion to = Quaternion.LookRotation(dir);
		Vector3 eulerAngles = Quaternion.Slerp(quaternion, to, this.m_RotateSpeed * Time.deltaTime).eulerAngles;
		eulerAngles.z = 0f;
		eulerAngles.x = 0f;
		quaternion = Quaternion.Euler(eulerAngles);
		base.transform.rotation = quaternion;
	}

	private void UpdateAutoMove()
	{
		if (this.m_MoveTarget == null)
		{
			return;
		}
		if (!this.m_CurrentBaseState.IsTag(M_PlayerController.locoTag))
		{
			return;
		}
		if (this.m_LockControl)
		{
			return;
		}
		this.m_ResearchTargetTime += Time.deltaTime;
		if (this.m_ResearchTargetTime >= 0.5f)
		{
			this.m_ResearchTargetTime = 0f;
			this.SetAutoMoveTarget(this.m_MoveTarget.transform.position);
		}
	}

	//public override bool SetAutoMovePosition(Vector3 moveTarget)
	//{
	//	float dist = 0.2f;
	//	if (this.m_IsRun)
	//	{
	//		dist = this.m_AutoMoveStopDist;
	//	}
	//	if (this.LockControl)
	//	{
	//		dist = 1f;
	//	}
	//	float num = Vector3.Distance(moveTarget, base.transform.position);
	//	this.m_MoveDirection = moveTarget - base.transform.position;
	//	this.m_MoveDirection.y = 0f;
	//	this.m_RotateDirection = this.m_MoveDirection.normalized;
	//	if (this.m_IsRun)
	//	{
	//		if (num >= 1.25f)
	//		{
	//			if (this.m_AtuoMoveSpeed == 0f)
	//			{
	//				this.m_Anim.speed = this.m_RunSpeed;
	//				this.m_Anim.SetFloat("Speed", 1f, this.m_RuuBlendSpeed, Time.deltaTime);
	//			}
	//		}
	//		else
	//		{
	//			this.m_Anim.SetFloat("Speed", 0.3f, 0.01f, Time.deltaTime);
	//		}
	//	}
	//	else
	//	{
	//		this.m_Anim.SetFloat("Speed", 0.3f, 0.01f, Time.deltaTime);
	//	}
	//	this.UpdateRotate();
	//	return GameMath.IsPosEqualXZ(moveTarget, base.transform.position, dist);
	//}

	private Vector3 GetMoveDir(Vector3 horizontal)
	{
		Vector3 point = horizontal;
		point = point.normalized * Mathf.Pow(point.magnitude, 2f);
		return Camera.main.transform.rotation * point;
	}

	public bool SetMoveTarget(Ray ray, bool applyNow, bool autoMove)
	{
		if (this.m_WalkSpeed > 0f)
		{
			return false;
		}
		RaycastHit raycastHit = default(RaycastHit);
		int num = 1024;
		num |= 4;
		num = ~num;
		Physics.Raycast(ray, out raycastHit, 1000f, num);
		if (!(null != raycastHit.transform))
		{
			return false;
		}
		if (raycastHit.collider.tag == "Player")
		{
			return false;
		}
		if (raycastHit.collider.tag == "No Raycast")
		{
			return false;
		}
		if (autoMove)
		{
			this.SetAutoMoveTarget(raycastHit.point);
		}
		else
		{
			//this.MoveTarget = Swd6Application.instance.m_ExploreSystem.ShowMoveTarget(true, raycastHit.point);
		}
		if (applyNow)
		{
			base.Pos = raycastHit.point + new Vector3(0f, 0.2f, 0f);
		}
		return true;
	}

	public void SetAutoMoveTarget(Vector3 moveTarget)
	{
		//if (GameMath.IsPosEqualXZ(moveTarget, base.transform.position, 0.1f))
		//{
		//	base.MoveRole = false;
		//	return;
		//}
		this.m_UpdateAutoMoveTime = 0f;
		this.m_UpdateIdleTime = 0f;
		this.m_IsAutoMove = true;
		this.bWalk = true;
		this.m_Anim.applyRootMotion = true;
		//this.m_IdelState = ENUM_IDLESTATE.None;
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
		//if (this.m_AstarAI != null)
		//{
		//	this.m_AstarAI.SetMoveTarget(moveTarget);
		//}
	}

	public override void SetMove(Vector3 moveDest)
	{
		base.MoveRole = true;
		this.SetAutoMoveTarget(moveDest);
	}

	private void MatchP(float dist, float desiredDist, Vector3 positive, Vector3 negative)
	{
		if (dist.ToString("f2") != desiredDist.ToString("f2"))
		{
			float num = this.climbSpeed * Time.deltaTime;
			if (dist > desiredDist)
			{
				if (dist > desiredDist + 0.1f)
				{
					num *= this.smoothDistanceSpeed * 2f;
				}
				else
				{
					num /= this.smoothDistanceSpeed / 1.5f;
				}
				base.transform.Translate(positive * num);
			}
			else if (dist < desiredDist)
			{
				if (dist < desiredDist + 0.1f)
				{
					num *= this.smoothDistanceSpeed * 2f;
				}
				else
				{
					num /= this.smoothDistanceSpeed / 1.5f;
				}
				base.transform.Translate(negative * num);
			}
		}
	}

	private void FeetPlacementIK()
	{
		if (!this.grounded)
		{
			return;
		}
		if (!this.m_CurrentBaseState.IsTag(M_PlayerController.locoTag))
		{
			return;
		}
		int layerIndex = 2;
		float layerWeight = this.m_Anim.GetLayerWeight(layerIndex);
		if (this.vertical != 0f || this.horizontal != 0f)
		{
			if (layerWeight > 0f)
			{
				this.m_Anim.SetLayerWeight(layerIndex, 0.5f);
			}
		}
		else if (layerWeight < 1f)
		{
			this.m_Anim.SetLayerWeight(layerIndex, layerWeight + (Time.deltaTime + 0.1f));
		}
		if (layerWeight > 0.1f)
		{
			Vector3 origin = base.transform.position + base.transform.up - base.transform.right / this.m_footWidth;
			Vector3 origin2 = base.transform.position + base.transform.up + base.transform.right / this.m_footWidth;
			RaycastHit raycastHit;
			if (!Physics.Raycast(origin, Vector3.down, out raycastHit, 2f, this.groundLayers))
			{
				return;
			}
			RaycastHit raycastHit2;
			if (!Physics.Raycast(origin2, Vector3.down, out raycastHit2, 2f, this.groundLayers))
			{
				return;
			}
			float num = Mathf.Abs(raycastHit.distance - raycastHit2.distance);
			if (num < 0.05f)
			{
				return;
			}
			this.m_Anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, layerWeight);
			this.m_Anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, layerWeight);
			Vector3 b = Vector3.Lerp(Vector3.zero, new Vector3(0f, num, 0f), layerWeight);
			this.m_Anim.bodyPosition -= b;
			Vector3 b2 = new Vector3(0f, 0.09f, 0f);
			Vector3 goalPosition = raycastHit.point + b2;
			Vector3 goalPosition2 = raycastHit2.point + b2;
			this.m_Anim.SetIKPosition(AvatarIKGoal.LeftFoot, goalPosition);
			this.m_Anim.SetIKPosition(AvatarIKGoal.RightFoot, goalPosition2);
		}
	}

	private void OnAnimatorIK(int layerIndex)
	{
		if (!this.m_FootIK)
		{
			return;
		}
		if (layerIndex == 2)
		{
			this.FeetPlacementIK();
		}
		else if (layerIndex == 3)
		{
			Vector3 origin = base.transform.position + new Vector3(0f, 1f, 0f);
			RaycastHit raycastHit;
			if (!Physics.Raycast(origin, base.transform.forward, out raycastHit, 1f))
			{
				return;
			}
			float layerWeight = this.m_Anim.GetLayerWeight(layerIndex);
			this.m_Anim.SetLayerWeight(layerIndex, layerWeight);
			this.m_Anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, layerWeight);
			this.m_Anim.SetIKPositionWeight(AvatarIKGoal.RightHand, layerWeight);
			this.m_Anim.SetIKPosition(AvatarIKGoal.LeftHand, raycastHit.point);
			this.m_Anim.SetIKPosition(AvatarIKGoal.RightHand, raycastHit.point);
		}
	}

	public new void OnMouseDown()
	{
	}

	public new void OnMouseOver()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (this.LockControl)
		{
			return;
		}
		//if (Swd6Application.instance == null)
		//{
		//	return;
		//}
		//if (other.tag == "Npc")
		//{
		//	this.m_EnterTalk = true;
		//}
		//if (other.tag == "MusicEvent")
		//{
		//	other.gameObject.SendMessage("OnTalk", SendMessageOptions.DontRequireReceiver);
		//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//	{
		//		Debug.Log("執行切換音樂事件_" + other.name);
		//	}
		//}
		//if (other.tag == "Event")
		//{
		//	this.m_EnterTalkEvent = true;
		//	Swd6Application.instance.m_ExploreSystem.m_TalkEventObj = other.gameObject;
		//	other.gameObject.SendMessage("OnTalk", SendMessageOptions.DontRequireReceiver);
		//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//	{
		//		Debug.Log("觸發事件_" + other.name);
		//	}
		//}
		//if (other.tag == "WaterEvent1")
		//{
		//	this.m_WalkInWater = true;
		//}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Npc")
		{
			this.m_EnterTalk = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "WaterEvent1")
		{
			this.m_WalkInWater = false;
		}
		if (other.tag == "MusicEvent")
		{
			//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	Debug.Log("切回原本地圖音樂!!");
			//}
			//Swd6Application.instance.m_ExploreSystem.PlayMusic();
		}
		if (other.tag == "Npc")
		{
			this.m_EnterTalk = false;
		}
		if (other.tag != "Event")
		{
			return;
		}
		this.m_EnterTalkEvent = false;
	}

	private void DetermineGrounding()
	{
		Ray ray = new Ray(base.transform.position + this.m_Controller.transform.rotation * this.m_Controller.center, Vector3.down);
		if (Physics.Raycast(ray, out M_PlayerController.sGroundCollisionInfo, 10f, this.PlayerMask))
		{
			//this.m_State.GroundNormal = M_PlayerController.sGroundCollisionInfo.normal;
			//this.m_State.GroundDistance = M_PlayerController.sGroundCollisionInfo.distance - this.m_Controller.center.y;
			//this.m_State.GroundAngle = Vector3.Angle(this.m_State.GroundNormal, Vector3.up);
			//if (this.m_State.GroundDistance <= 0.075f)
			//{
			//	this.m_State.IsGrounded = true;
			//	this.m_State.Support = M_PlayerController.sGroundCollisionInfo.collider.gameObject;
			//	if (this.m_State.Support.rigidbody != null)
			//	{
			//		this.m_State.SupportPosition = this.m_State.Support.rigidbody.position;
			//		this.m_State.SupportRotation = this.m_State.Support.rigidbody.rotation;
			//	}
			//	else
			//	{
			//		this.m_State.SupportPosition = this.m_State.Support.transform.position;
			//		this.m_State.SupportRotation = this.m_State.Support.transform.rotation;
			//	}
			//	if (this.m_State.Support != this.m_PrevState.Support || this.m_State.SupportContactPosition.sqrMagnitude == 0f)
			//	{
			//		this.m_State.SupportContactPosition = Quaternion.Inverse(this.m_State.SupportRotation) * (M_PlayerController.sGroundCollisionInfo.point - this.m_State.SupportPosition);
			//	}
			//}
		}
		//if (!this.m_State.IsGrounded && this.m_State.GroundDistance < this.m_Controller.stepOffset && this.m_State.GroundAngle > this.m_Controller.slopeLimit / 2f)
		//{
		//	this.m_State.IsGrounded = true;
		//}
	}

	public void UpdateSupportMove()
	{
		//if (this.m_State.Support != null && this.m_State.Support == this.m_PrevState.Support)
		//{
		//	this.m_State.SupportMove = Vector3.zero;
		//	if (this.m_State.Support.rigidbody != null)
		//	{
		//		this.m_State.SupportPosition = this.m_State.Support.rigidbody.position;
		//		this.m_State.SupportRotation = this.m_State.Support.rigidbody.rotation;
		//	}
		//	else
		//	{
		//		this.m_State.SupportPosition = this.m_State.Support.transform.position;
		//		this.m_State.SupportRotation = this.m_State.Support.transform.rotation;
		//	}
		//	if (this.m_State.SupportPosition != this.m_PrevState.SupportPosition)
		//	{
		//		this.m_State.SupportMove = this.m_State.SupportPosition - this.m_PrevState.SupportPosition;
		//	}
		//	if (Quaternion.Angle(this.m_State.SupportRotation, this.m_PrevState.SupportRotation) != 0f)
		//	{
		//		Quaternion quaternion = this.m_PrevState.SupportRotation.RotationTo(this.m_State.SupportRotation);
		//		base.transform.Rotate(quaternion.eulerAngles);
		//		this.m_State.SupportMove = this.m_State.SupportMove + (this.m_State.SupportRotation * this.m_State.SupportContactPosition - this.m_PrevState.SupportRotation * this.m_State.SupportContactPosition);
		//	}
		//	if (this.m_State.SupportMove.sqrMagnitude != 0f && this.m_BaseState != M_PlayerController.BaseState.Jump)
		//	{
		//		this.m_Controller.Move(this.m_State.SupportMove);
		//	}
		//}
		//if (this.m_State.Support != null && this.m_State.Velocity.HorizontalMagnitude() > 0f)
		//{
		//	this.m_State.SupportContactPosition = Vector3.zero;
		//}
	}

	private void UpdateSlopMovement(float rDeltaTime)
	{
		if (!this.m_CheckSlop)
		{
			return;
		}
		if (this.m_BaseState == M_PlayerController.BaseState.Jump)
		{
			return;
		}
		bool flag = true;
		Vector3 zero = Vector3.zero;
		//if (this.m_State.IsGrounded && this.m_State.GroundDistance < -0.01f && flag)
		//{
		//	zero.y = (-this.m_State.GroundDistance + 0.01f) / Time.deltaTime;
		//}
		//this.mAccumulatedAcceleration = Vector3.zero;
		//this.mAccumulatedVelocity = Vector3.zero;
		//if (this.m_State.IsGrounded)
		//{
		//	if (this.mAccumulatedAcceleration.sqrMagnitude < 0.005f)
		//	{
		//		this.mAccumulatedAcceleration = Vector3.zero;
		//	}
		//	else
		//	{
		//		this.mAccumulatedAcceleration -= this.mAccumulatedAcceleration * (rDeltaTime / this.mGroundDragDuration);
		//	}
		//	if (this.mAccumulatedVelocity.sqrMagnitude < 0.005f)
		//	{
		//		this.mAccumulatedVelocity = Vector3.zero;
		//	}
		//	else
		//	{
		//		this.mAccumulatedVelocity -= this.mAccumulatedVelocity * (rDeltaTime / this.mGroundDragDuration);
		//	}
		//}
		//if (flag)
		//{
		//	Vector3 b = this._Gravity;
		//	this.m_State.IsSlop = false;
		//	if (this.m_State.GroundAngle > this._MinSlideAngle && (this.m_State.IsGrounded || (!this.m_State.IsGrounded && this.m_Controller.isGrounded)) && this.m_State.GroundNormal != Vector3.up)
		//	{
		//		Vector3 normalized = this._Gravity.normalized;
		//		Vector3.OrthoNormalize(ref this.m_State.GroundNormal, ref normalized);
		//		b = normalized * this._Gravity.magnitude;
		//		this.m_State.IsSlop = true;
		//	}
		//	this.mAccumulatedAcceleration += b;
		//}
		//this.mAccumulatedVelocity += this.mAccumulatedAcceleration * rDeltaTime * this.m_SlopDownSpeed;
		//this.m_State.Velocity = this.mAccumulatedVelocity;
		//this.m_State.Velocity = this.m_State.Velocity + base.transform.rotation * this.mRootMotionVelocity;
		//Vector3 velocity = this.m_State.Velocity;
		//if (zero.y > 0f)
		//{
		//	velocity.y = Mathf.Max(velocity.y, zero.y);
		//}
		//this.m_Controller.Move(velocity * rDeltaTime);
		//if (this.m_State.IsGrounded && this.m_State.GroundDistance > 0.01f && flag)
		//{
		//	float num = this.GroundCast(ref M_PlayerController.sGroundCollisionInfo);
		//	Vector3 motion = new Vector3(0f, -num, 0f);
		//	this.m_Controller.Move(motion);
		//	this.m_State.GroundDistance = 0f;
		//}
		//this.m_State.Position = base.transform.position;
	}

	public float GroundCast(ref RaycastHit rCollisionInfo)
	{
		float result = 3.40282347E+38f;
		int num = this.PlayerMask;
		num = ~num;
		Vector3 origin = this.m_Controller.transform.position + this.m_Controller.transform.rotation * this.m_Controller.center;
		bool flag = Physics.Raycast(origin, Vector3.down, out rCollisionInfo, 10f, num);
		if (flag)
		{
			result = rCollisionInfo.distance - this.m_Controller.center.y;
		}
		return result;
	}

	private void UpdatePlayerTalk()
	{
		if (this.MoveTarget == null)
		{
			return;
		}
		if (this.LockControl)
		{
			return;
		}
		if (this.MoveTarget.tag != "Npc")
		{
			return;
		}
		//M_GameNpc component = this.MoveTarget.GetComponent<M_GameNpc>();
		//if (component == null)
		//{
		//	return;
		//}
		//if (component.GetNpcData().MouseTalkRange > 0f)
		//{
		//	float num = Vector3.Distance(this.MoveTarget.transform.position, base.Pos);
		//	if (num <= component.GetNpcData().MouseTalkRange)
		//	{
		//		Swd6Application.instance.m_ExploreSystem.TalkTarget = this.MoveTarget;
		//		this.StopMoveToTarget();
		//		component.DoTalkMotion(Swd6Application.instance.m_ExploreSystem.PlayerObj);
		//		component.RunTalk();
		//		this.PlayMotion(1, 0.1f);
		//		this.SetTalkTurn(base.gameObject);
		//	}
		//}
	}

	public void UpdateIdleMotion()
	{
		if (this.LockControl)
		{
			return;
		}
		//if (this.m_IdelState == ENUM_IDLESTATE.None)
		//{
		//	return;
		//}
		//ENUM_IDLESTATE idelState = this.m_IdelState;
		//if (idelState != ENUM_IDLESTATE.Start)
		//{
		//	if (idelState == ENUM_IDLESTATE.WaitStart)
		//	{
		//		this.m_UpdateIdleTime += Time.deltaTime;
		//		if (this.m_UpdateIdleTime >= 1f && this.m_Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
		//		{
		//			this.PlayMotion(1, 0.1f);
		//			this.m_UpdateIdleTime = 0f;
		//			this.m_IdelState = ENUM_IDLESTATE.Start;
		//			this.m_StartIdleTime = UnityEngine.Random.Range(15f, 30f);
		//		}
		//	}
		//}
		//else if (this.m_StartIdleTime > 0f)
		//{
		//	this.m_UpdateIdleTime += Time.deltaTime;
		//	if (this.m_UpdateIdleTime >= this.m_StartIdleTime)
		//	{
		//		int num = UnityEngine.Random.Range(0, 2);
		//		this.PlayMotion(2504 + num, 0.1f);
		//		this.m_UpdateIdleTime = 0f;
		//		this.m_IdelState = ENUM_IDLESTATE.WaitStart;
		//	}
		//}
	}

	public void PlayMotion(int id, float fadeTime)
	{
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
		AnimatorStateInfo currentAnimatorStateInfo = this.m_Anim.GetCurrentAnimatorStateInfo(0);
		string text = "Base Layer." + data.ClipName;
		int num = Animator.StringToHash(text);
		if (fadeTime > 0f)
		{
			this.m_Anim.CrossFade(text, fadeTime);
		}
		else
		{
			this.m_Anim.Play(text);
		}
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
	}

	public void PlayMotion(string motionName)
	{
		string name = "Base Layer." + motionName;
		int stateNameHash = Animator.StringToHash(name);
		this.m_Anim.CrossFade(stateNameHash, 0.1f);
		//if (this.m_ShroudInstance != null)
		//{
		//	this.m_ShroudInstance.ReduceBlendWeight();
		//}
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
		if (this.m_Anim == null)
		{
			return 0f;
		}
		AnimatorStateInfo currentAnimatorStateInfo = this.m_Anim.GetCurrentAnimatorStateInfo(0);
		if (!currentAnimatorStateInfo.IsName(data.ClipName))
		{
			return 0f;
		}
		return currentAnimatorStateInfo.length;
	}

	public new bool IsEndTransition()
	{
		return this.m_Anim == null || !this.m_Anim.IsInTransition(0);
	}

	public void OnTriggerFight(GameObject other, bool weapon)
	{
		if (this.LockControl)
		{
			return;
		}
		//M_GameEnemyPathAI component = other.gameObject.GetComponent<M_GameEnemyPathAI>();
		//if (component == null)
		//{
		//	return;
		//}
		//if (Swd6Application.instance.m_GameDataSystem.GetFlag(21))
		//{
		//	return;
		//}
		//if (this.m_BaseState == M_PlayerController.BaseState.Combat && weapon)
		//{
		//	if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3)
		//	{
		//		return;
		//	}
		//	this.LockControl = true;
		//	if (!component.OnHurt())
		//	{
		//		this.LockControl = false;
		//	}
		//	else
		//	{
		//		this.m_Anim.SetBool("Attack", false);
		//		this.m_Anim.SetFloat("Speed", 0f);
		//		this.m_MouseAttackTime = 0f;
		//		this.m_BaseState = M_PlayerController.BaseState.Base;
		//		this.PlayMotion(2, 1.1f);
		//		this.PlayMapSkillSound();
		//	}
		//}
		//else if (component.OnEncounter())
		//{
		//	this.LockControl = true;
		//	base.transform.rotation = GameMath.RotateToTarget(base.transform, component.transform);
		//	component.transform.rotation = GameMath.RotateToTarget(component.transform, base.transform);
		//	this.ShowWeapon(true);
		//	this.PlayMotion(2, 0.2f);
		//}
	}

	public void ChangeWeapon()
	{
		this.ShowWeapon(false);
		this.m_WeaponObj = null;
	}

	public void PlayAttackSound()
	{
		//switch (Swd6Application.instance.m_GameDataSystem.m_PlayerID)
		//{
		//case 1:
		//	MusicSystem.Instance.PlaySound(17, 1);
		//	break;
		//case 2:
		//	MusicSystem.Instance.PlaySound(19, 1);
		//	break;
		//case 4:
		//	MusicSystem.Instance.PlaySound(21, 1);
		//	break;
		//}
	}

	public void PlayMapSkillSound()
	{
		//switch (Swd6Application.instance.m_GameDataSystem.m_PlayerID)
		//{
		//case 1:
		//	MusicSystem.Instance.PlaySound(18, 1);
		//	break;
		//case 2:
		//	MusicSystem.Instance.PlaySound(20, 1);
		//	break;
		//case 4:
		//	MusicSystem.Instance.PlaySound(22, 1);
		//	break;
		//}
	}

	public void ShowWeapon(bool enable)
	{
		if (this.m_WeaponObj == null)
		{
			//C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(Swd6Application.instance.m_GameDataSystem.m_PlayerID);
			//ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.Weapon);
			//if (equipItemData == null)
			//{
			//	return;
			//}
			//S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
			//string weaponModelName = data.Equip.WeaponModelName;
			//string text = data.Equip.WeaponTrail[0];
			//this.m_WeaponObj = AvatarTool.GetWeapon(base.gameObject, weaponModelName, "weapon Right", string.Empty);
			//TransformTool.SetTagRecursively(this.m_WeaponObj.transform.parent, "Weapon");
		}
		if (this.m_WeaponObj != null)
		{
			this.HideObj(this.m_WeaponObj, !enable);
			//M_WeaponTrail[] componentsInChildren = this.m_WeaponObj.GetComponentsInChildren<M_WeaponTrail>();
			//if (componentsInChildren == null)
			//{
			//	return;
			//}
			//for (int i = 0; i < componentsInChildren.Length; i++)
			//{
			//	componentsInChildren[i].Emit = enable;
			//}
		}
	}

	public void ShowWeaponEffect()
	{
		//if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3)
		//{
		//	return;
		//}
		//if (this.m_ShowWeaponEffect)
		//{
		//	return;
		//}
		//this.m_ShowWeaponEffect = true;
		//string effectName = string.Format("P0{0}1_fight", Swd6Application.instance.m_GameDataSystem.m_PlayerID);
		//EffectSystem.Instance.CreateEffect(base.transform, effectName, false, true);
	}

	public void HideObj(GameObject obj, bool bHide)
	{
		//RendererTool.EnableAllRenderers(obj, !bHide);
		//ParticleSystem[] componentsInChildren = obj.GetComponentsInChildren<ParticleSystem>();
		//if (componentsInChildren != null)
		//{
		//	ParticleSystem[] array = componentsInChildren;
		//	for (int i = 0; i < array.Length; i++)
		//	{
		//		ParticleSystem particleSystem = array[i];
		//		if (particleSystem)
		//		{
		//			if (bHide)
		//			{
		//				particleSystem.Stop();
		//			}
		//			else
		//			{
		//				particleSystem.Play();
		//			}
		//		}
		//	}
		//}
		Light[] componentsInChildren2 = obj.GetComponentsInChildren<Light>();
		if (componentsInChildren2 != null)
		{
			Light[] array2 = componentsInChildren2;
			for (int j = 0; j < array2.Length; j++)
			{
				Light light = array2[j];
				if (light)
				{
					light.enabled = !bHide;
				}
			}
		}
		Projector[] componentsInChildren3 = obj.GetComponentsInChildren<Projector>();
		if (componentsInChildren3 != null)
		{
			Projector[] array3 = componentsInChildren3;
			for (int k = 0; k < array3.Length; k++)
			{
				Projector projector = array3[k];
				if (projector)
				{
					projector.enabled = !bHide;
				}
			}
		}
	}

	//public bool IsHeadCanLookAt()
	//{
	//	return !this.LockControl && this.m_IdelState != ENUM_IDLESTATE.WaitStart;
	//}

	//public bool IsHideSkill()
	//{
	//	return Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3 && Swd6Application.instance.m_ExploreSystem.IsAvoidMob() && !Swd6Application.instance.m_ExploreSystem.m_UseNoFightItem;
	//}
}
