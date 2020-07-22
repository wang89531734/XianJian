using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(M_GameRoleMotion))]
public abstract class M_GameRoleBase : MonoBehaviour
{
	public delegate void EventHandler(GameObject e);

	public delegate IEnumerator EventHandlerTalk();

	public delegate bool EventHandlerMoveOver(Vector3 e);

	protected int m_RoleId;

	protected GameObjState m_RoleState = new GameObjState();

	protected S_GameObjData m_GameObjData;

	protected GameObject m_PrefObj;

	protected Vector3 m_HidePos = Vector3.zero;

	protected Vector3 m_StartPos = Vector3.zero;

	protected float m_StartDir;

	protected Vector3 m_MoveDirection = Vector3.zero;

	protected Vector3 m_RotateDirection = Vector3.zero;

	protected Vector3 m_MoveDesPos = Vector3.zero;

	protected float m_DesiredDistance = 0.1f;

	public float m_MoveSpeed = 1f;

	protected float m_TurnAngle;

	protected float m_TurnSpeed;

	public int m_MotionID;

	public int m_TalkMotionID;

	public int m_TurnMotion;

	public int m_WaitMotion;

	public int m_QuestID;

	protected float m_Alpha = 1f;

	protected bool m_FadeIn;

	protected bool m_bUpdateDist;

	public bool m_EnterTalk;

	public bool m_DontRemoveScript;

	protected GameObject m_QuestHint;

	protected Component m_QuestTalk;

	protected S_NpcData m_NpcData;

	protected Animator m_Animator;

	public M_GameRoleMotion m_RoleMotion;

	private List<GameObject> m_PhysicClothList = new List<GameObject>();

	public M_GameRoleBase.EventHandler OnTalkDelegate;

	public M_GameRoleBase.EventHandlerTalk OnTalkBeforEventDelegate;

	public M_GameRoleBase.EventHandlerTalk OnTalkAfterEventDelegate;

	public M_GameRoleBase.EventHandlerMoveOver OnFollowBoundDelegate;

	public M_GameRoleBase.EventHandlerTalk OnTalkAfterTrigger;

	public int RoleID
	{
		get
		{
			return this.m_RoleId;
		}
		set
		{
			this.m_RoleId = value;
		}
	}

	public GameObjState RoleState
	{
		get
		{
			return this.m_RoleState;
		}
	}

	public bool MoveRole
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Move);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Move);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Move);
			}
		}
	}

	public bool PauseMove
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.PauseMove);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.PauseMove);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.PauseMove);
			}
			this.m_Animator.applyRootMotion = !value;
		}
	}

	public bool DisableRole
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Disable);
		}
		set
		{
			if (value)
			{
				this.OnExitFocus();
				this.CheckQuestState();
				if (this.m_NpcData.emType != ENUM_NpcType.Treasure)
				{
					//ExploreMiniMapSystem.Instance.RemoveQuestIcon(this.RoleID);
				}
				this.m_RoleState.Set(ENUM_GameObjFlag.Disable);
				UnityEngine.Object.DestroyObject(base.gameObject);
				this.m_GameObjData.GameObj = null;
				this.m_GameObjData.RoleBase = null;
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Disable);
				this.m_RoleState.Reset(ENUM_GameObjFlag.Hide2);
				if (this.m_GameObjData.GameObj == null)
				{
					//Swd6Application.instance.m_GameObjSystem.LoadObj(this.m_GameObjData);
				}
			}
		}
	}

	public virtual bool HideRole
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Hide);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Hide);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Hide);
			}
			this.HideGameObj(value);
			if (this.m_GameObjData == null)
			{
				return;
			}
			this.CheckQuestState();
		}
	}

	public virtual bool HideRole2
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Hide2);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Hide2);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Hide2);
			}
			this.HideGameObj(value);
			if (this.m_GameObjData == null)
			{
				return;
			}
			this.CheckQuestState();
		}
	}

	public virtual bool NoCollider
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
			Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>();
			if (componentsInChildren != null)
			{
				Collider[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Collider collider = array[i];
					collider.enabled = !value;
				}
			}
			MeshCollider[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<MeshCollider>();
			if (componentsInChildren2 != null)
			{
				MeshCollider[] array2 = componentsInChildren2;
				for (int j = 0; j < array2.Length; j++)
				{
					MeshCollider meshCollider = array2[j];
					meshCollider.enabled = !value;
					meshCollider.isTrigger = value;
				}
			}
			CharacterController component = base.gameObject.GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = !value;
			}
		}
	}

	public virtual bool FadeOut
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.FadeOut);
		}
		set
		{
			if (value)
			{
				this.m_FadeIn = false;
				this.m_Alpha = 1f;
				this.m_RoleState.Set(ENUM_GameObjFlag.FadeOut);
			}
			else
			{
				this.m_FadeIn = true;
				this.m_Alpha = 0f;
				this.m_RoleState.Reset(ENUM_GameObjFlag.FadeOut);
			}
		}
	}

	public bool Run
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Run);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Run);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Run);
			}
		}
	}

	public bool TurnRole
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Turn);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Turn);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Turn);
			}
		}
	}

	public bool Open
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Open);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Open);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Open);
			}
		}
	}

	public bool TalkTurn
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.TalkTurn);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.TalkTurn);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.TalkTurn);
			}
		}
	}

	public bool Talk
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Talk);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Talk);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Talk);
			}
		}
	}

	public bool Pick
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Pick);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Pick);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Pick);
			}
		}
	}

	public bool Grouund
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Ground);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Ground);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Ground);
			}
		}
	}

	public int Motion
	{
		get
		{
			return this.m_RoleMotion.GetMotion();
		}
		set
		{
			this.SetMotion(value);
		}
	}

	public bool Invalid
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.Invalid);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.Invalid);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.Invalid);
			}
		}
	}

	public bool View
	{
		get
		{
			return this.m_RoleState.Test(ENUM_GameObjFlag.View);
		}
		set
		{
			if (value)
			{
				this.m_RoleState.Set(ENUM_GameObjFlag.View);
			}
			else
			{
				this.m_RoleState.Reset(ENUM_GameObjFlag.View);
			}
		}
	}

	public float Dir
	{
		get
		{
			return base.transform.eulerAngles.y;
		}
		set
		{
			this.SetRotate(0f, value, 0f);
		}
	}

	public float Dir2
	{
		get
		{
			float num = base.transform.localRotation.eulerAngles.y;
			float num2 = Mathf.Abs(360f - num);
			if (num <= 1f)
			{
				num = 0f;
			}
			else
			{
				num2 = Mathf.Abs(0f - num);
				if (num <= 1f)
				{
					num = 0f;
				}
			}
			return num;
		}
		set
		{
			Vector3 eulerAngles = base.transform.parent.eulerAngles;
			base.transform.parent.eulerAngles = new Vector3(0f, 0f, 0f);
			base.transform.eulerAngles = new Vector3(0f, value, 0f);
			base.transform.parent.eulerAngles = eulerAngles;
		}
	}

	public Vector3 Pos
	{
		get
		{
			return this.GetPos();
		}
		set
		{
			this.SetPos(value);
		}
	}

	public float MoveSpeed
	{
		get
		{
			return this.m_MoveSpeed;
		}
		set
		{
			this.m_MoveSpeed = value;
		}
	}

	private void Start()
	{
		//if (Swd6Application.instance)
		//{
		//	Swd6Application instance = Swd6Application.instance;
		//	int mapID = instance.m_GameDataSystem.m_MapInfo.MapID;
		//	string text = base.gameObject.name;
		//	if (base.gameObject.transform.parent != null)
		//	{
		//		text = base.gameObject.transform.parent.name;
		//	}
		//	this.m_StartPos = base.gameObject.transform.position;
		//	this.m_StartDir = base.gameObject.transform.eulerAngles.y;
		//	if (text.Contains("NPC_"))
		//	{
		//		text = text.Replace("NPC_", string.Empty);
		//		this.RoleID = int.Parse(text);
		//		this.m_NpcData = GameDataDB.NpcDB.GetData(this.RoleID);
		//		if (this.m_NpcData == null)
		//		{
		//			UnityEngine.Debug.Log("找不到NPC資料_" + this.RoleID);
		//		}
		//		if (!instance.m_GameObjSystem.CheckGameObjData(this.RoleID))
		//		{
		//			int num = (int)this.m_RoleState.Get();
		//			string text2 = string.Format(string.Concat(new object[]
		//			{
		//				base.gameObject.name,
		//				"+",
		//				this.RoleID,
		//				"+",
		//				mapID,
		//				"+",
		//				num.ToString("X")
		//			}), new object[0]);
		//			this.LoadPrefabModel();
		//			this.m_GameObjData = new S_GameObjData(this.RoleID, mapID, this.GetPos(), this.GetDir(), this.m_NpcData.Motion, this.m_RoleState, base.gameObject);
		//			instance.m_GameObjSystem.AddGameObjData(this.m_GameObjData);
		//		}
		//		else
		//		{
		//			this.m_GameObjData = instance.m_GameObjSystem.GetObjData(this.RoleID);
		//			if (this.m_GameObjData != null)
		//			{
		//				this.LoadPrefabModel();
		//				this.m_GameObjData.GameObj = base.gameObject;
		//				this.m_RoleState = this.m_GameObjData.State;
		//				if (mapID != this.m_GameObjData.MapId)
		//				{
		//					UnityEngine.Object.Destroy(base.gameObject);
		//					return;
		//				}
		//				if (this.m_GameObjData.Pos == Vector3.zero)
		//				{
		//					this.m_GameObjData.Pos = this.GetPos();
		//				}
		//				this.SetPos(this.m_GameObjData.Pos);
		//				if (this.m_GameObjData.Dir != 1000f)
		//				{
		//					this.Dir = this.m_GameObjData.Dir;
		//				}
		//				if (this.m_GameObjData.Dir2 != 1000f)
		//				{
		//					this.Dir2 = this.m_GameObjData.Dir2;
		//				}
		//				if (this.HideRole)
		//				{
		//					this.HideRole = true;
		//				}
		//				if (this.HideRole2)
		//				{
		//					this.HideRole2 = true;
		//				}
		//				if (this.NoCollider)
		//				{
		//					this.NoCollider = true;
		//				}
		//				if (this.DisableRole)
		//				{
		//					if (this.Open)
		//					{
		//						ExploreMiniMapSystem.Instance.ChangeToOpenIcon(this.RoleID);
		//					}
		//					UnityEngine.Object.Destroy(base.gameObject);
		//				}
		//			}
		//		}
		//	}
		//}
		if (this.m_NpcData != null)
		{
			this.m_RoleMotion = base.GetComponent<M_GameRoleMotion>();
			if (this.m_RoleMotion != null)
			{
				this.m_RoleMotion.Init(this.RoleID, this.m_GameObjData.Motion);
			}
		}
		//ExploreMiniMapSystem.Instance.CreateNpcIcon(this.RoleID);
		this.initialize();
	}

	private void OnDestroy()
	{
		if (this.m_QuestHint)
		{
			UnityEngine.Object.DestroyObject(this.m_QuestHint);
		}
		this.m_QuestHint = null;
	}

	protected abstract void initialize();

	public void SetMotion(int id)
	{
		this.m_MotionID = id;
		if (this.m_RoleMotion != null)
		{
			if (this.m_NpcData != null)
			{
				if (this.m_NpcData.emType == ENUM_NpcType.Role)
				{
					this.m_RoleMotion.SetCrossMotion(this.m_MotionID);
				}
				else
				{
					this.m_RoleMotion.SetMotion(this.m_MotionID);
				}
			}
			else
			{
				this.m_RoleMotion.SetMotion(this.m_MotionID);
			}
			this.m_GameObjData.Motion = id;
		}
	}

	public void SetMotion(int id, bool crossMotion)
	{
		this.m_MotionID = id;
		if (this.m_RoleMotion != null)
		{
			if (this.m_NpcData != null)
			{
				if (crossMotion)
				{
					this.m_RoleMotion.SetCrossMotion(this.m_MotionID);
				}
				else
				{
					this.m_RoleMotion.SetMotion(this.m_MotionID);
				}
			}
			else
			{
				this.m_RoleMotion.SetMotion(this.m_MotionID);
			}
			this.m_GameObjData.Motion = id;
		}
	}

	public void SetMotionQueued(int id)
	{
		this.m_MotionID = id;
		this.m_RoleMotion.SetMotionQueued(id);
		this.m_GameObjData.Motion = id;
	}

    public IEnumerator SetRoleQueuedMotion(int motionId, int motionId2)
    {
        this.SetMotion(motionId);
        while (!this.IsMotionFinished(motionId))
        {
            yield return null;
        }
        this.SetMotion(motionId2);
        yield return null;
        yield break;
    }

    public bool IsMotionFinished(int id)
	{
		if (this.m_RoleMotion)
		{
			return this.m_RoleMotion.IsMotionFinished(id);
		}
		Animator component = base.GetComponent<Animator>();
		if (component == null)
		{
			return true;
		}
		AnimatorStateInfo currentAnimatorStateInfo = component.GetCurrentAnimatorStateInfo(0);
		return currentAnimatorStateInfo.normalizedTime >= 0.95f && currentAnimatorStateInfo.normalizedTime <= 0.96f;
	}

	public bool IsEndTransition()
	{
		Animator component = base.GetComponent<Animator>();
		return component == null || !component.IsInTransition(0);
	}

	public void SetPos(Vector3 pos)
	{
		base.transform.position = pos;
	}

	public void SetPos(float x, float y, float z)
	{
		this.SetPos(new Vector3(x, y, z));
	}

	public Vector3 GetPos()
	{
		return base.transform.position;
	}

	public void Translate(float x, float y, float z)
	{
		if (base.transform.parent != null)
		{
			base.transform.parent.Translate(x, y, z);
		}
		else
		{
			base.transform.Translate(x, y, z);
		}
	}

	public void SetRotate(float xAngle, float yAngle, float zAngle)
	{
		base.transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);
	}

	public void SetDir(float dir)
	{
		this.SetRotate(0f, dir, 0f);
	}

	public float GetDir()
	{
		return base.transform.eulerAngles.y;
	}

	public virtual void Update()
	{
		if (this.FadeOut)
		{
			if (!this.HideRole)
			{
				this.m_Alpha -= Time.deltaTime * 0.5f;
				if (this.m_Alpha < 0f)
				{
					this.m_Alpha = 0f;
				}
				this.AlphaObj(this.m_Alpha);
				if (this.m_Alpha <= 0f)
				{
					this.HideRole = true;
				}
			}
		}
		else if (!this.HideRole && this.m_FadeIn)
		{
			this.m_Alpha += Time.deltaTime * 0.5f;
			if (this.m_Alpha > 1f)
			{
				this.m_Alpha = 1f;
			}
			this.AlphaObj(this.m_Alpha);
			if (this.m_Alpha >= 1f)
			{
				this.m_FadeIn = false;
				this.RestoreOrgShader("Softstar/Bump Specular");
			}
		}
	}

	public void UpdateTurn()
	{
		if (this.TurnRole && this.Turn(this.m_TurnAngle, this.m_TurnSpeed))
		{
			this.TurnRole = false;
			if (this.m_RoleMotion == null)
			{
				return;
			}
			if (this.m_WaitMotion > 0)
			{
				this.m_RoleMotion.SetMotion(this.m_WaitMotion);
				this.m_WaitMotion = 0;
			}
			else if (this.TalkTurn)
			{
				this.TalkTurn = false;
				if (this.m_TalkMotionID > 0)
				{
					this.m_RoleMotion.SetMotion(this.m_TalkMotionID);
				}
				else
				{
					this.m_RoleMotion.SetMotion(this.m_NpcData.Motion);
				}
			}
		}
	}

	public void SetTurn(float flAngle, float flSpeed)
	{
		this.TurnRole = false;
		//this.m_TurnAngle = GameMath.ClampAngle(flAngle, 0f, 360f);
		this.m_TurnSpeed = flSpeed;
		if (this.m_TurnSpeed == 0f)
		{
			this.SetDir(this.m_TurnAngle);
		}
		else
		{
			this.TurnRole = true;
		}
		if (this.m_TurnMotion > 0)
		{
			if (this.m_RoleMotion != null)
			{
				this.m_RoleMotion.SetMotion(this.m_TurnMotion);
			}
			this.m_TurnMotion = 0;
		}
	}

	public void SetTurn(Vector3 pos, float flSpeed)
	{
		this.TurnRole = false;
		//float angle = GameMath.GetAngle(this.GetPos(), pos);
		//this.m_TurnAngle = GameMath.ClampAngle(angle, 0f, 360f);
		this.m_TurnSpeed = flSpeed;
		if (this.m_TurnSpeed == 0f)
		{
			this.SetDir(this.m_TurnAngle);
		}
		else
		{
			this.TurnRole = true;
		}
		if (this.m_TurnMotion > 0)
		{
			if (this.m_RoleMotion != null)
			{
				this.m_RoleMotion.SetMotion(this.m_TurnMotion);
			}
			this.m_TurnMotion = 0;
		}
	}

	public bool SmoothTurn(float flAngle, float flSpeed)
	{
		//flAngle = GameMath.ClampAngle(flAngle, 0f, 360f);
		float dir = this.GetDir();
		//float angle = GameMath.LerpAngle(dir, flAngle, Time.deltaTime * flSpeed);
		//this.SetDir(GameMath.ClampAngle(angle, 0f, 360f));
		return Mathf.Abs(dir - flAngle) < 1f;
	}

	public bool Turn(float flAngle, float flSpeed)
	{
		if (this.m_Animator != null)
		{
			this.m_Animator.applyRootMotion = false;
		}
		//flAngle = GameMath.ClampAngle(flAngle, 0f, 360f);
		float dir = this.GetDir();
		if (Mathf.Abs(dir - flAngle) < 1f)
		{
			return true;
		}
		float num = Time.deltaTime * flSpeed;
		float num2 = flAngle - dir;
		if (Mathf.Abs(num2) > 180f)
		{
			if (dir < flAngle)
			{
				num2 = -360f - dir + flAngle;
			}
			else
			{
				num2 = 360f - dir + flAngle;
			}
		}
		if (num > Mathf.Abs(num2))
		{
			num = Mathf.Abs(num2);
		}
		if (num2 < 0f)
		{
			num = -num;
		}
		//this.SetDir(GameMath.ClampAngle(360f + dir + num, 0f, 360f));
		return false;
	}

	public void LoadPrefabModel()
	{
	}

	public void AttachDefaultComponent()
	{
		if (!base.gameObject.GetComponent<CapsuleCollider>())
		{
			CapsuleCollider capsuleCollider = base.gameObject.AddComponent<CapsuleCollider>();
			capsuleCollider.center = new Vector3(0f, 1f, 0f);
			capsuleCollider.radius = 1f;
			capsuleCollider.height = 2.2f;
			capsuleCollider.isTrigger = true;
			if (this.NoCollider)
			{
				capsuleCollider.enabled = false;
			}
		}
		if (!base.gameObject.GetComponent<CharacterController>())
		{
			CharacterController characterController = base.gameObject.AddComponent<CharacterController>();
			characterController.center = new Vector3(0f, 1.155f, 0f);
			characterController.radius = 0.4f;
			characterController.height = 2.4f;
			if (this.NoCollider)
			{
				characterController.enabled = false;
			}
		}
	}

	public void SetNpcData(S_NpcData npcData)
	{
		this.m_NpcData = npcData;
		if (this.m_NpcData.Pick == 1)
		{
			this.Pick = true;
		}
		else
		{
			this.Pick = false;
		}
	}

	public S_NpcData GetNpcData()
	{
		return this.m_NpcData;
	}

	public virtual void SetMove(Vector3 moveDest)
	{
		this.MoveRole = true;
		this.m_MoveDesPos = moveDest;
		this.m_MoveDirection = this.m_MoveDesPos - this.GetPos();
		this.m_MoveDirection = this.m_MoveDirection.normalized;
		this.m_RotateDirection = this.m_MoveDirection;
		S_NpcAI data = GameDataDB.NpcAIDB.GetData(this.m_NpcData.AIMode);
		this.SetMotion(data.MoveMotion);
		this.PauseMove = false;
		this.m_Animator.applyRootMotion = true;
	}

	public virtual bool SetAutoMovePosition(Vector3 moveTarget)
	{
		return true;
	}

	public virtual void StopAutoMove()
	{
	}

	public void SetMoveDir(Vector3 moveDir)
	{
		this.m_MoveDirection = moveDir;
		this.m_MoveDirection.y = 0f;
		this.m_MoveDirection = this.m_MoveDirection.normalized;
		float d = Mathf.Clamp(this.m_MoveSpeed * Time.deltaTime, this.m_DesiredDistance + 0.01f, 2f);
		Vector3 move = this.GetPos() + this.m_MoveDirection * d;
		this.SetMove(move);
	}

	public virtual void StopMove()
	{
		this.m_MoveDirection = Vector3.zero;
		this.MoveRole = false;
	}

	public bool IsMoveOver()
	{
		return !this.MoveRole;
	}

	public void HideGameObj(bool bHide)
	{
		if (bHide)
		{
			this.m_PhysicClothList.Clear();
			//ShroudMesh[] componentsInChildren = base.gameObject.GetComponentsInChildren<ShroudMesh>();
			//if (componentsInChildren != null)
			//{
			//	ShroudMesh[] array = componentsInChildren;
			//	for (int i = 0; i < array.Length; i++)
			//	{
			//		ShroudMesh shroudMesh = array[i];
			//		if (shroudMesh)
			//		{
			//			this.m_PhysicClothList.Add(shroudMesh.gameObject);
			//			shroudMesh.gameObject.SetActive(false);
			//		}
			//	}
			//}
		}
		else
		{
			for (int j = 0; j < this.m_PhysicClothList.Count; j++)
			{
				this.m_PhysicClothList[j].SetActive(true);
			}
			this.m_PhysicClothList.Clear();
		}
		SkinnedMeshRenderer[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		if (componentsInChildren2 != null)
		{
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int k = 0; k < array2.Length; k++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[k];
				if (skinnedMeshRenderer)
				{
					skinnedMeshRenderer.enabled = !bHide;
				}
			}
		}
		MeshRenderer[] componentsInChildren3 = base.gameObject.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren3 != null)
		{
			MeshRenderer[] array3 = componentsInChildren3;
			for (int l = 0; l < array3.Length; l++)
			{
				MeshRenderer meshRenderer = array3[l];
				if (meshRenderer)
				{
					meshRenderer.enabled = !bHide;
				}
			}
		}
		Light[] componentsInChildren4 = base.gameObject.GetComponentsInChildren<Light>();
		if (componentsInChildren4 != null)
		{
			Light[] array4 = componentsInChildren4;
			for (int m = 0; m < array4.Length; m++)
			{
				Light light = array4[m];
				if (light)
				{
					light.enabled = !bHide;
				}
			}
		}
		ParticleSystem[] componentsInChildren5 = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		if (componentsInChildren5 != null)
		{
			ParticleSystem[] array5 = componentsInChildren5;
			for (int n = 0; n < array5.Length; n++)
			{
				ParticleSystem particleSystem = array5[n];
				if (particleSystem)
				{
					if (bHide)
					{
						particleSystem.Stop();
					}
					else
					{
						particleSystem.Play();
					}
				}
			}
		}
		Projector[] componentsInChildren6 = base.gameObject.GetComponentsInChildren<Projector>();
		if (componentsInChildren6 != null)
		{
			Projector[] array6 = componentsInChildren6;
			for (int num = 0; num < array6.Length; num++)
			{
				Projector projector = array6[num];
				if (projector)
				{
					projector.enabled = !bHide;
				}
			}
		}
		//if (base.gameObject.renderer != null)
		//{
		//	base.gameObject.renderer.enabled = !bHide;
		//}
		//if (!bHide && this.m_NpcData != null)
		//{
		//	for (int num2 = 0; num2 < this.m_NpcData.DisableRenderer.Count; num2++)
		//	{
		//		RendererTool.EnableRenderer(base.gameObject, this.m_NpcData.DisableRenderer[num2], false);
		//	}
		//}
	}

	public void AlphaObj(float alpha)
	{
		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		if (componentsInChildren != null)
		{
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				//if (skinnedMeshRenderer && skinnedMeshRenderer.renderer)
				//{
				//	skinnedMeshRenderer.renderer.material.color = new Color(1f, 1f, 1f, alpha);
				//}
			}
		}
		MeshRenderer[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren2 != null)
		{
			MeshRenderer[] array2 = componentsInChildren2;
			for (int j = 0; j < array2.Length; j++)
			{
				MeshRenderer meshRenderer = array2[j];
				//if (meshRenderer && meshRenderer.renderer)
				//{
				//	meshRenderer.renderer.material.color = new Color(1f, 1f, 1f, alpha);
				//}
			}
		}
		//if (base.gameObject.renderer != null)
		//{
		//	base.gameObject.renderer.material.color = new Color(1f, 1f, 1f, alpha);
		//}
	}

	public void SetRenderColor(Color color)
	{
		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		if (componentsInChildren != null)
		{
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				if (skinnedMeshRenderer)
				{
					//skinnedMeshRenderer.renderer.material.color = color;
				}
			}
		}
	}

	public void SetShader(string shader)
	{
		if (this.m_NpcData == null)
		{
			UnityEngine.Debug.Log("SetShader m_NpcData == null");
			return;
		}
		Transform child = base.gameObject.transform.GetChild(0);
		if (child != null)
		{
			Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
			if (componentsInChildren != null)
			{
				Renderer[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Renderer renderer = array[i];
					if (renderer)
					{
						renderer.material.shader = Shader.Find(shader);
					}
				}
			}
		}
	}

	public void RestoreOrgShader(string shader)
	{
		if (this.m_NpcData == null)
		{
			UnityEngine.Debug.Log("SetShader m_NpcData == null");
			return;
		}
		Transform child = base.gameObject.transform.GetChild(0);
		if (child != null)
		{
			Renderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<Renderer>();
			if (componentsInChildren != null)
			{
				Renderer[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Renderer renderer = array[i];
					if (renderer && renderer.material.shader.name == "Softstar/Transparent/Bumped Diffuse_zFight")
					{
						renderer.material.shader = Shader.Find(shader);
					}
				}
			}
		}
	}

	//private bool UpdateMouseUIEvent()
	//{
	//	return Swd6Application.instance.guiManager != null && Swd6Application.instance.guiManager.DetecteMouseOnUI(true);
	//}

	public void OnKeyMouseDown()
	{
		//if (Swd6Application.instance.gameStateService.getCurrentState().name == "SmallTrapGameState" && !Swd6Application.instance.m_ExploreSystem.m_SubTalk)
		//{
		//	SmallTrapGameSystem.Instance.SetActiveTarget(base.gameObject);
		//	this.RunTalk();
		//}
	}

	public void OnMouseDown()
	{
		//if (this.UpdateMouseUIEvent())
		//{
		//	return;
		//}
		//if (Swd6Application.instance.gameStateService.getCurrentState().name == "SmallTrapGameState")
		//{
		//	if (Input.GetMouseButton(0) && !Swd6Application.instance.m_ExploreSystem.m_SubTalk)
		//	{
		//		SmallTrapGameSystem.Instance.SetActiveTarget(base.gameObject);
		//		this.RunTalk();
		//	}
		//	return;
		//}
		//if (Swd6Application.instance.m_ExploreSystem.LockPlayer)
		//{
		//	return;
		//}
		if (Input.GetMouseButton(0))
		{
			GameObject gameObject = GameObject.Find("Player");
			if (gameObject)
			{
				M_PlayerController component = gameObject.GetComponent<M_PlayerController>();
				if (component)
				{
					if (base.gameObject == gameObject)
					{
						return;
					}
					if (this.Pick)
					{
						if (!this.m_EnterTalk)
						{
							component.SetAutoMoveTarget(base.gameObject.transform.position);
						}
						component.MoveTarget = base.gameObject;
					}
				}
			}
		}
	}

	public void OnMouseEnter()
	{
		//if (this.UpdateMouseUIEvent())
		//{
		//	return;
		//}
		GameObject gameObject = GameObject.Find("Player");
		if (gameObject)
		{
			M_PlayerController component = gameObject.GetComponent<M_PlayerController>();
			if (component && this.Pick)
			{
				component.m_PickTarget = base.gameObject;
				//if (component.IsHeadCanLookAt())
				//{
				//	this.OnHeadLookAt(gameObject, base.gameObject);
				//}
			}
		}
	}

	public void OnMouseOver()
	{
		//if (this.UpdateMouseUIEvent())
		//{
		//	GameCursor.SetCursor(ENUM_CURSOR.NORMAL);
		//	return;
		//}
		if (base.gameObject.name == "Player")
		{
			return;
		}
		if (this.Invalid || this.DisableRole)
		{
			return;
		}
		//if (Swd6Application.instance.m_ExploreSystem.LockPlayer && Swd6Application.instance.gameStateService.getCurrentState().name != "SmallTrapGameState")
		//{
		//	return;
		//}
		GameObject gameObject = GameObject.Find("Player");
		if (gameObject)
		{
			M_PlayerController component = gameObject.GetComponent<M_PlayerController>();
			if (component && this.Pick)
			{
				component.m_PickTarget = base.gameObject;
				//if (component.IsHeadCanLookAt())
				//{
				//	this.OnHeadLookAt(gameObject, base.gameObject);
				//}
				if (this.m_NpcData.emType == ENUM_NpcType.Treasure && (this.HideRole || this.HideRole2) && this.m_NpcData.Show == 0 && this.m_NpcData.emActionHint == ENUM_ActionHint.Null)
				{
					return;
				}
				if (this.m_NpcData.emType == ENUM_NpcType.Mine)
				{
					//GameCursor.SetCursor(ENUM_CURSOR.GATHER);
				}
				else if (this.m_NpcData.emType == ENUM_NpcType.Treasure)
				{
					//GameCursor.SetCursor(ENUM_CURSOR.PICK);
				}
				else if (this.m_NpcData.emType == ENUM_NpcType.Trap)
				{
					//GameCursor.SetCursor(ENUM_CURSOR.SEE);
				}
				else
				{
					//GameCursor.SetCursor(ENUM_CURSOR.TALK);
				}
			}
		}
	}

	public void OnMouseExit()
	{
		this.OnExitFocus();
	}

	public void OnExitFocus()
	{
		//GameCursor.SetCursor(ENUM_CURSOR.NORMAL);
		if (base.gameObject.name == "Player")
		{
			return;
		}
		GameObject gameObject = GameObject.Find("Player");
		if (gameObject)
		{
			M_PlayerController component = gameObject.GetComponent<M_PlayerController>();
			if (component)
			{
				component.m_PickTarget = null;
				this.OnHeadLookAt(gameObject, null);
			}
		}
	}

	public void OnHeadLookAt(GameObject sourceObj, GameObject targetObj)
	{
		if (sourceObj == null)
		{
			return;
		}
		//M_HeadLookController component = sourceObj.GetComponent<M_HeadLookController>();
		//if (component == null)
		//{
		//	return;
		//}
		if (targetObj == null)
		{
			//component.SetLookTarget(null);
			return;
		}
		//Transform transform = TransformTool.FindChild(targetObj.transform, "Bip001 Head");
		if (transform == null)
		{
			//transform = targetObj.transform;
		}
		//component.SetLookTarget(transform);
	}

	//private GameObject CreateQuestHintObj(int id)
	//{
	//	if (this.m_QuestHint)
	//	{
	//		UnityEngine.Object.Destroy(this.m_QuestHint);
	//	}
	//	string text = "QuestHint" + id;
	//	//GameObject other = ResourceManager.Instance.GetOther(text);
	//	//if (other == null)
	//	//{
	//	//	UnityEngine.Debug.Log("CreateQuestHintObj error__" + text);
	//	//}
	//	//TransformTool.SetLayerRecursively(other.transform, 9);
	//	return other;
	//}

	public void CheckQuestState()
	{
		//this.SetQuestState(ENUM_QuestHint.Null);
		if (this.HideRole || this.HideRole2)
		{
			this.m_GameObjData.QuestState = ENUM_QuestState.Null;
			//ExploreMiniMapSystem.Instance.UpdateQuestIcon(this.RoleID);
			return;
		}
		//if (Swd6Application.instance.m_ExploreSystem.LockPlayer)
		//{
		//	QuestRecord questRecord = Swd6Application.instance.m_QuestSystem.GetQuestRecord(this.m_QuestID);
		//	if (questRecord != null)
		//	{
		//		this.m_GameObjData.QuestState = questRecord.State;
		//	}
		//	return;
		//}
		this.m_QuestID = 0;
		bool flag = false;
		bool flag2 = false;
		//int num = this.m_QuestID = Swd6Application.instance.m_QuestSystem.CheckNpctFinishState(this.RoleID, ref flag2);
		//if (num > 0 && flag2)
		//{
		//	this.m_GameObjData.QuestState = ENUM_QuestState.Report;
		//	//this.SetQuestState(ENUM_QuestHint.Report);
		//	Swd6Application.instance.m_QuestSystem.ReportQuestRecord(num);
		//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//	{
		//		UnityEngine.Debug.Log(this.RoleID + "角色可回報任務_" + num);
		//	}
		//	if (!this.HideRole)
		//	{
		//		ExploreMiniMapSystem.Instance.UpdateQuestIcon(this.RoleID);
		//	}
		//	return;
		//}
		//num = (this.m_QuestID = Swd6Application.instance.m_QuestSystem.CheckNpctRunState(this.RoleID));
		//if (num > 0)
		//{
		//	this.m_GameObjData.QuestState = ENUM_QuestState.Normal;
		//	this.SetQuestState(ENUM_QuestHint.NoReport);
		//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//	{
		//		UnityEngine.Debug.Log(this.RoleID + "角色正在進行任務_" + num);
		//	}
		//	if (!this.HideRole)
		//	{
		//		ExploreMiniMapSystem.Instance.UpdateQuestIcon(this.RoleID);
		//	}
		//	return;
		//}
		//num = (this.m_QuestID = Swd6Application.instance.m_QuestSystem.CheckNpctGiveState(this.RoleID, ref flag));
		//if (num > 0 && flag)
		//{
		//	Swd6Application.instance.m_QuestSystem.ActiveQuestRecord(num);
		//	this.m_GameObjData.QuestState = ENUM_QuestState.Active;
		//	this.SetQuestState(ENUM_QuestHint.Give);
		//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//	{
		//		UnityEngine.Debug.Log(this.RoleID + "角色可接取任務_" + num);
		//	}
		//	if (!this.HideRole)
		//	{
		//		ExploreMiniMapSystem.Instance.UpdateQuestIcon(this.RoleID);
		//	}
		//	return;
		//}
		if (this.m_QuestTalk && !this.m_DontRemoveScript)
		{
			UnityEngine.Object.DestroyObject(this.m_QuestTalk);
			this.m_QuestTalk = null;
		}
		this.m_GameObjData.QuestState = ENUM_QuestState.Null;
		//ExploreMiniMapSystem.Instance.UpdateQuestIcon(this.RoleID);
	}

	//public void SetQuestState(ENUM_QuestHint state)
	//{
	//	int id = 0;
	//	switch (state)
	//	{
	//	case ENUM_QuestHint.Null:
	//		if (this.m_QuestHint)
	//		{
	//			UnityEngine.Object.Destroy(this.m_QuestHint);
	//		}
	//		return;
	//	case ENUM_QuestHint.Give:
	//		id = 1;
	//		break;
	//	case ENUM_QuestHint.NoGive:
	//		id = 3;
	//		break;
	//	case ENUM_QuestHint.Report:
	//		id = 2;
	//		break;
	//	case ENUM_QuestHint.NoReport:
	//		id = 4;
	//		break;
	//	}
	//	if (this.HideRole || this.HideRole2)
	//	{
	//		return;
	//	}
	//	this.m_QuestHint = this.CreateQuestHintObj(id);
	//}

	public void ShowQuestHint()
	{
		if (this.m_QuestHint == null)
		{
			return;
		}
		float num = 2f;
		Vector3 position = base.gameObject.transform.position;
		if (!this.m_bUpdateDist)
		{
			Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>();
			if (componentsInChildren != null)
			{
				num = componentsInChildren[0].bounds.extents.y;
				position.y = componentsInChildren[0].bounds.center.y;
				num += 0.2f;
			}
		}
		position.y += num;
		this.m_QuestHint.transform.position = position;
	}

	public void RunTalk()
	{
		//GameObject gameObject = Swd6Application.instance.gameObject;
		this.Talk = true;
		if (this.m_GameObjData.QuestState != ENUM_QuestState.Null)
		{
			S_Quest data = GameDataDB.QuestDB.GetData(this.m_QuestID);
			if (data != null)
			{
				if (this.m_QuestTalk && this.m_QuestTalk.name != data.Talk)
				{
					UnityEngine.Object.DestroyObject(this.m_QuestTalk);
					this.m_QuestTalk = null;
				}
				if (this.m_QuestTalk == null)
				{
					//this.m_QuestTalk = gameObject.AddComponent(data.Talk);
					//Swd6Application.instance.m_ExploreSystem.m_TalkComponent = this.m_QuestTalk;
				}
			}
			//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
			//{
			//	UnityEngine.Debug.Log("DoQuestTalk_" + this.m_GameObjData.QuestState);
			//}
			if (this.m_GameObjData.QuestState == ENUM_QuestState.Active)
			{
				gameObject.SendMessage("GiveQuest", SendMessageOptions.DontRequireReceiver);
			}
			if (this.m_GameObjData.QuestState == ENUM_QuestState.Normal)
			{
				gameObject.SendMessage("RunQuest", SendMessageOptions.DontRequireReceiver);
			}
			if (this.m_GameObjData.QuestState == ENUM_QuestState.Report)
			{
				gameObject.SendMessage("ReportQuest", SendMessageOptions.DontRequireReceiver);
			}
		}
		else if (this.m_NpcData.Talk != null)
		{
			bool flag = true;
			//if (Swd6Application.instance.gameStateService.getCurrentState().name == "SmallTrapGameState" || Swd6Application.instance.m_ExploreSystem.m_SubTalk)
			//{
			//	flag = false;
			//	gameObject = base.gameObject;
			//}
			Component component = gameObject.GetComponent(this.m_NpcData.Talk);
			if (!(component != null))
			{
				if (flag)
				{
					//Swd6Application.instance.m_ExploreSystem.m_TalkComponent = gameObject.AddComponent(this.m_NpcData.Talk);
				}
				else
				{
					//gameObject.AddComponent(this.m_NpcData.Talk);
				}
				//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
				//{
				//	UnityEngine.Debug.Log("DoTalk_" + this.RoleID);
				//}
			}
			gameObject.SendMessage("OnTalk", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void SetAttachItem(int itemID, int position)
	{
		string text = "1006";
		if (position != 0)
		{
			text = "1007";
		}
		this.m_GameObjData.AttachID[position] = itemID;
		S_Item data = GameDataDB.ItemDB.GetData(itemID);
		if (data == null)
		{
			UnityEngine.Debug.LogWarning("itemData not be found : " + itemID);
			return;
		}
		//GameObject item = ResourceManager.Instance.GetItem(data.StoryPrefabName);
		//if (item == null)
		//{
		//	UnityEngine.Debug.LogWarning("item not be found : " + data.StoryPrefabName);
		//	return;
		//}
		//item.name = data.StoryPrefabName;
		//Transform transform = TransformTool.FindChild(base.gameObject.transform, text);
		if (transform == null)
		{
			UnityEngine.Debug.LogWarning("node not be found : " + text);
			return;
		}
		//item.transform.position = transform.position;
		//item.transform.rotation = transform.rotation;
		//item.transform.parent = transform;
	}

	public void DeleteAttachItem(int itemID, int position)
	{
		string text = "1006";
		if (position != 0)
		{
			text = "1007";
		}
		this.m_GameObjData.AttachID[position] = 0;
		S_Item data = GameDataDB.ItemDB.GetData(itemID);
		if (data == null)
		{
			UnityEngine.Debug.LogWarning("itemData not be found : " + itemID);
			return;
		}
		//Transform transform = TransformTool.FindChild(base.gameObject.transform, text);
		if (transform == null)
		{
			UnityEngine.Debug.LogWarning("node not be found : " + text);
			return;
		}
		Transform transform2 = transform.FindChild(data.StoryPrefabName);
		if (transform2 == null)
		{
			UnityEngine.Debug.LogWarning("item not be found : " + data.StoryPrefabName);
			return;
		}
		UnityEngine.Object.Destroy(transform2.gameObject);
	}

	public void LoadAttachItem()
	{
		if (this.m_GameObjData.AttachID[0] > 0)
		{
			this.SetAttachItem(this.m_GameObjData.AttachID[0], 0);
		}
		if (this.m_GameObjData.AttachID[1] > 0)
		{
			this.SetAttachItem(this.m_GameObjData.AttachID[1], 1);
		}
	}

	public void SetHairLight(bool light)
	{
		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		SkinnedMeshRenderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array[i];
			if (skinnedMeshRenderer.name.Contains("hair"))
			{
				this.m_GameObjData.HairNoLight = !light;
				if (light)
				{
					skinnedMeshRenderer.gameObject.layer = 0;
				}
				else
				{
					skinnedMeshRenderer.gameObject.layer = 20;
				}
			}
		}
	}

	public void LoadHairLightState()
	{
		this.SetHairLight(!this.m_GameObjData.HairNoLight);
	}
}
