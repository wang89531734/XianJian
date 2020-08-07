using Pathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class M_GameEnemyPathAI : AIPath
{
    public float sleepVelocity = 1f;

    public float walkSpeed = 1f;

    public Vector3 startPosition;

    public Vector3 returnPosition;

    public float waitReturnTime = 1f;

    public float waitReturnDeltaTime;

    public bool returnStart;

    public bool searchTarget;

    public bool m_Pause;

    public bool m_Init;

    public bool m_DrawGizmos;

    public bool m_Enable = true;

    //public ENUM_EnemyPathAIState aiState = ENUM_EnemyPathAIState.Search;

    public float m_AlertAngle = 180f;

    public float m_AlertMinRange = 5f;

    public float m_AlertMaxRange = 8f;

    public float m_FollowTime;

    public float m_FollowMinTime = 5f;

    public float m_FollowMaxTime = 10f;

    public float m_FollowSpeed = 1f;

    public int m_FollowMotion;

    public int m_Follow;

    public float m_FindTargetWaitTime;

    public float m_FindTargetMaxWaitTime = 1f;

    public float m_RebornTime;

    public float m_RebornMaxTime = 10f;

    public float m_WaitFightTime;

    public float m_WaitFightMaxTime = 1f;

    public int m_BattleID;

    public int m_RandWalk;

    public float m_RandWalkRange = 5f;

    public float m_RandWalkTime = 3f;

    public float m_RandWalkDeltaTime;

    public float m_RandWalkRandDeltaTime;

    public int m_MoveMotion;

    public int m_WayPointIndex;

    public int m_PinePong;

    public float m_PatroleWaitTime;

    public float m_PatroleMaxWaitTime;

    public float m_ReturnHomeTime;

    public bool m_IsPatroleWait;

    public GameObject m_PatrolRootNode;

    public List<Vector3> m_WayPoint = new List<Vector3>();

    private Animator m_Anim;

    private AnimatorStateInfo m_CurrentBaseState;

    private M_GameRoleMotion m_Motion;

    //private S_NpcAI m_NpcAI;

    public GameObject endOfPathEffect;

    protected Vector3 lastTarget;

    public new void Start()
    {
        //if (!this.m_Init)
        //{
        //    this.initialize();
        //}
        base.Start();
    }

    //	public void initialize()
    //	{
    //		this.InitAI();
    //		this.endReachedDistance = 0.3f;
    //		this.closestOnPathCheck = false;
    //		this.startPosition = this.tr.position;
    //		this.aiState = ENUM_EnemyPathAIState.Search;
    //		if (this.m_RandWalk > 0)
    //		{
    //			this.aiState = ENUM_EnemyPathAIState.RandWalk;
    //		}
    //		this.m_Anim = base.GetComponent<Animator>();
    //		this.m_Motion = base.GetComponent<M_GameRoleMotion>();
    //		if (this.m_NpcAI != null)
    //		{
    //			this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //		}
    //		this.InitPatrolNode();
    //		if (this.target == null)
    //		{
    //			this.target = Swd6Application.instance.m_ExploreSystem.PlayerObj.transform;
    //		}
    //		GameMapMobSystem.Instance.AddObj(base.gameObject.GetInstanceID(), base.gameObject);
    //		this.m_Init = true;
    //	}

    //	public override void OnTargetReached()
    //	{
    //		if (this.endOfPathEffect != null && Vector3.Distance(this.tr.position, this.lastTarget) > 1f)
    //		{
    //			UnityEngine.Object.Instantiate(this.endOfPathEffect, this.tr.position, this.tr.rotation);
    //			this.lastTarget = this.tr.position;
    //		}
    //	}

    //	public override Vector3 GetFeetPosition()
    //	{
    //		return this.tr.position;
    //	}

    //	public void InitAI()
    //	{
    //		M_GameRoleBase component = base.GetComponent<M_GameRoleBase>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		this.m_NpcAI = GameDataDB.NpcAIDB.GetData(component.GetNpcData().AIMode);
    //		if (this.m_NpcAI == null)
    //		{
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				Debug.Log(component.RoleID + "_InitAI::讀取NpcAI資造錯誤_" + component.GetNpcData().AIMode);
    //			}
    //			return;
    //		}
    //		this.m_MoveMotion = this.m_NpcAI.MoveMotion;
    //		this.m_RandWalk = this.m_NpcAI.RandWalk;
    //		this.m_RandWalkRange = this.m_NpcAI.RandWalkRange;
    //		this.m_RandWalkTime = this.m_NpcAI.RandWalkTime;
    //		this.m_AlertAngle = this.m_NpcAI.AlertAngle;
    //		this.m_AlertMinRange = this.m_NpcAI.AlertMinRange;
    //		this.m_AlertMaxRange = this.m_NpcAI.AlertMaxRange;
    //		this.m_FollowMinTime = this.m_NpcAI.FollowMinTime;
    //		this.m_FollowMaxTime = this.m_NpcAI.FollowMaxTime;
    //		this.m_FollowMotion = this.m_NpcAI.FollowMotion;
    //		this.m_Follow = this.m_NpcAI.Follow;
    //		this.m_FollowSpeed = this.m_NpcAI.FollowSpeed;
    //		if (this.m_FollowSpeed == 0f)
    //		{
    //			this.m_FollowSpeed = 1f;
    //		}
    //		this.m_RebornMaxTime = this.m_NpcAI.RebornMaxTime;
    //		this.m_BattleID = this.m_NpcAI.BattleID;
    //		this.m_PatroleMaxWaitTime = (float)this.m_NpcAI.WaitMoveTime;
    //		this.m_PatrolRootNode = GameObject.Find(this.m_NpcAI.MovePrefab);
    //	}

    //	public void InitPatrolNode()
    //	{
    //		if (this.m_PatrolRootNode == null)
    //		{
    //			return;
    //		}
    //		this.m_WayPoint.Clear();
    //		for (int i = 0; i < this.m_PatrolRootNode.transform.childCount; i++)
    //		{
    //			Transform child = this.m_PatrolRootNode.transform.GetChild(i);
    //			this.m_WayPoint.Add(child.position);
    //		}
    //		this.m_IsPatroleWait = false;
    //		this.m_WayPointIndex = 0;
    //		this.m_PatroleWaitTime = 0f;
    //		this.aiState = ENUM_EnemyPathAIState.Patrol;
    //		this.SetMotion(this.m_MoveMotion);
    //		this.seeker.StartPath(this.GetFeetPosition(), this.m_WayPoint[this.m_WayPointIndex]);
    //	}

    //	public override void SearchPath()
    //	{
    //		if (this.target == null)
    //		{
    //			this.canSearch = false;
    //			return;
    //		}
    //		if (this.m_Pause)
    //		{
    //			return;
    //		}
    //		if (!this.searchTarget)
    //		{
    //			return;
    //		}
    //		Vector3 position = this.target.position;
    //		this.SetMotion(this.m_FollowMotion);
    //		this.canSearchAgain = false;
    //		this.seeker.StartPath(this.GetFeetPosition(), position);
    //	}

    //	public void Stop()
    //	{
    //		if (this.m_NpcAI != null)
    //		{
    //			this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //		}
    //	}

    //	public void ReturnToHome()
    //	{
    //		if (this.aiState == ENUM_EnemyPathAIState.Find || this.aiState == ENUM_EnemyPathAIState.Target)
    //		{
    //			this.aiState = ENUM_EnemyPathAIState.Wait;
    //			this.returnStart = true;
    //			this.canMove = false;
    //			this.searchTarget = false;
    //			this.repathRate = 0.5f;
    //			this.m_FindTargetWaitTime = 0f;
    //			this.m_FollowTime = 0f;
    //			this.seeker.ReleaseClaimedPath();
    //			if (this.m_NpcAI != null)
    //			{
    //				this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //			}
    //		}
    //	}

    //	public void TeleportToHome()
    //	{
    //		if (this.aiState == ENUM_EnemyPathAIState.Reborn)
    //		{
    //			return;
    //		}
    //		if (this.aiState == ENUM_EnemyPathAIState.Find || this.aiState == ENUM_EnemyPathAIState.Target || this.aiState == ENUM_EnemyPathAIState.Return)
    //		{
    //			if (this.m_NpcAI.WaitMotion.Count > 0)
    //			{
    //				int index = UnityEngine.Random.Range(0, this.m_NpcAI.WaitMotion.Count);
    //				this.SetMotion(this.m_NpcAI.WaitMotion[index]);
    //			}
    //			if (this.m_WayPoint.Count > 0)
    //			{
    //				this.aiState = ENUM_EnemyPathAIState.Patrol;
    //				this.SetMotion(this.m_MoveMotion);
    //				this.tr.position = this.returnPosition;
    //			}
    //			else
    //			{
    //				this.aiState = ENUM_EnemyPathAIState.Search;
    //				this.tr.position = this.startPosition;
    //			}
    //			this.turningSpeed = 5f;
    //			this.m_PatroleWaitTime = 0f;
    //			this.m_ReturnHomeTime = 0f;
    //			this.m_FindTargetWaitTime = 0f;
    //			this.m_FollowTime = 0f;
    //			this.m_IsPatroleWait = false;
    //			this.canMove = true;
    //			this.m_Anim.speed = this.walkSpeed;
    //		}
    //	}

    public void Enable()
    {
        this.m_Enable = true;
        this.Resume();
    }

    //	public void Disable()
    //	{
    //		this.m_Enable = false;
    //		this.Pause();
    //	}

    //	public void Pause()
    //	{
    //		this.m_Pause = true;
    //		this.Stop();
    //	}

    public void Resume()
    {
        if (!this.m_Enable)
        {
            return;
        }
        this.m_Pause = false;
        //if (this.aiState == ENUM_EnemyPathAIState.Patrol)
        //{
        //    if (!this.m_IsPatroleWait)
        //    {
        //        this.SetMotion(this.m_MoveMotion);
        //        this.m_Anim.speed = this.walkSpeed * this.m_FollowSpeed;
        //    }
        //}
        //else if (this.aiState == ENUM_EnemyPathAIState.Return)
        //{
        //    if (!this.m_IsPatroleWait)
        //    {
        //        this.SetMotion(this.m_FollowMotion);
        //        this.m_Anim.speed = this.walkSpeed * this.m_FollowSpeed;
        //    }
        //}
        //else if (this.aiState == ENUM_EnemyPathAIState.Target)
        //{
        //    this.SetMotion(this.m_FollowMotion);
        //    this.m_Anim.speed = this.walkSpeed * this.m_FollowSpeed;
        //}
    }

    //	public bool IsReborn()
    //	{
    //		return this.aiState == ENUM_EnemyPathAIState.Reborn;
    //	}

    //	public bool CheckEnterAlertRange()
    //	{
    //		if (!this.canMove)
    //		{
    //			return false;
    //		}
    //		if (this.m_Follow == 0)
    //		{
    //			return false;
    //		}
    //		if (Swd6Application.instance.m_ExploreSystem.IsAvoidMob())
    //		{
    //			return false;
    //		}
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(51) || Swd6Application.instance.m_GameDataSystem.GetFlag(21))
    //		{
    //			return false;
    //		}
    //		float f = Vector3.Distance(this.target.position, this.tr.position);
    //		if (Mathf.Abs(f) < this.m_AlertMinRange)
    //		{
    //			if (this.searchTarget)
    //			{
    //				return false;
    //			}
    //			if (this.m_AlertAngle > 0f && !GameMath.PointHitViewAngle(this.tr.transform.position, this.target.position, this.tr.eulerAngles.y - this.m_AlertAngle / 2f, this.m_AlertAngle))
    //			{
    //				return false;
    //			}
    //			this.canMove = false;
    //			this.aiState = ENUM_EnemyPathAIState.Find;
    //			if (this.m_NpcAI != null)
    //			{
    //				this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //			}
    //			UI_Explore.Instance.AddMobAlertUI(base.gameObject, this.m_FindTargetMaxWaitTime);
    //			return true;
    //		}
    //		else
    //		{
    //			if (this.aiState == ENUM_EnemyPathAIState.RandWalk)
    //			{
    //				return false;
    //			}
    //			if (this.m_RandWalk > 0 && this.seeker.IsDone() && this.path != null && GameMath.IsPosEqualXZ(this.path.vectorPath[this.path.vectorPath.Count - 1], this.tr.position, this.sleepVelocity))
    //			{
    //				this.m_RandWalkRandDeltaTime = (float)UnityEngine.Random.Range(1, 5);
    //				this.aiState = ENUM_EnemyPathAIState.RandWalk;
    //				if (this.m_NpcAI != null)
    //				{
    //					this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //				}
    //			}
    //			return false;
    //		}
    //	}

    //	public void UpdateFindTarget()
    //	{
    //		Vector3 vector = this.target.transform.position - base.transform.position;
    //		vector.y = 0f;
    //		vector = vector.normalized;
    //		if (vector != Vector3.zero)
    //		{
    //			this.RotateTowards(vector);
    //		}
    //		this.m_FindTargetWaitTime += Time.deltaTime;
    //		if (this.m_FindTargetWaitTime >= this.m_FindTargetMaxWaitTime)
    //		{
    //			this.canMove = true;
    //			this.m_FindTargetWaitTime = 0f;
    //			this.m_FollowTime = 0f;
    //			this.repathRate = 0.5f;
    //			this.turningSpeed = 20f;
    //			this.aiState = ENUM_EnemyPathAIState.Target;
    //			this.SetMotion(this.m_FollowMotion);
    //			this.m_Anim.speed = this.m_FollowSpeed;
    //			this.returnPosition = this.tr.position;
    //		}
    //	}

    //	public void CheckExitAlertRange()
    //	{
    //		if (!this.canMove)
    //		{
    //			return;
    //		}
    //		this.targetDirection = this.target.position - this.tr.position;
    //		this.targetDirection.Normalize();
    //		if (this.targetDirection != Vector3.zero)
    //		{
    //			this.RotateTowards(this.targetDirection);
    //		}
    //		bool flag = false;
    //		if (this.m_FollowMinTime > 0f && this.m_FollowTime < this.m_FollowMinTime)
    //		{
    //			this.m_FollowTime += Time.deltaTime;
    //			return;
    //		}
    //		if (this.m_FollowMaxTime > 0f && this.m_FollowTime > this.m_FollowMinTime)
    //		{
    //			this.m_FollowTime += Time.deltaTime;
    //			if (this.m_FollowTime > this.m_FollowMaxTime)
    //			{
    //				flag = true;
    //				this.m_FollowTime = 0f;
    //			}
    //		}
    //		float num = Vector3.Distance(this.target.position, this.tr.position);
    //		if (num > this.m_AlertMaxRange || flag)
    //		{
    //			this.aiState = ENUM_EnemyPathAIState.Wait;
    //			this.returnStart = true;
    //			this.canMove = false;
    //			this.searchTarget = false;
    //			this.repathRate = 0.5f;
    //			this.seeker.ReleaseClaimedPath();
    //			if (this.m_NpcAI != null)
    //			{
    //				this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //			}
    //		}
    //	}

    //	public void UpdateWaitToHome()
    //	{
    //		if (this.returnStart)
    //		{
    //			this.waitReturnDeltaTime += Time.deltaTime;
    //			if (this.waitReturnDeltaTime >= this.waitReturnTime)
    //			{
    //				this.returnStart = false;
    //				this.canMove = true;
    //				this.repathRate = 0.5f;
    //				this.waitReturnDeltaTime = 0f;
    //				this.m_RandWalkDeltaTime = 0f;
    //				this.m_ReturnHomeTime = 0f;
    //				this.aiState = ENUM_EnemyPathAIState.Return;
    //				this.SetMotion(this.m_FollowMotion);
    //				if (this.m_WayPoint.Count > 0)
    //				{
    //					this.seeker.StartPath(this.GetFeetPosition(), this.returnPosition);
    //				}
    //				else
    //				{
    //					this.seeker.StartPath(this.GetFeetPosition(), this.startPosition);
    //				}
    //			}
    //		}
    //	}

    //	public void UpdateToHome()
    //	{
    //		if (this.m_WayPoint.Count > 0)
    //		{
    //			this.m_ReturnHomeTime += Time.deltaTime;
    //			if (this.m_ReturnHomeTime >= this.m_FollowMaxTime + 5f)
    //			{
    //				this.TeleportToHome();
    //				return;
    //			}
    //			this.m_Anim.speed = this.m_FollowSpeed * 0.7f;
    //			if (GameMath.IsPosEqualXZ(this.returnPosition, this.GetFeetPosition(), this.sleepVelocity))
    //			{
    //				if (!this.m_IsPatroleWait && this.m_PatroleMaxWaitTime > 0f)
    //				{
    //					if (this.m_NpcAI != null && this.m_NpcAI.WaitMotion.Count > 0)
    //					{
    //						int index = UnityEngine.Random.Range(0, this.m_NpcAI.WaitMotion.Count);
    //						this.SetMotion(this.m_NpcAI.WaitMotion[index]);
    //					}
    //					this.m_IsPatroleWait = true;
    //				}
    //				if (this.m_IsPatroleWait && this.m_PatroleMaxWaitTime > 0f)
    //				{
    //					this.m_PatroleWaitTime += Time.deltaTime;
    //					if (this.m_PatroleWaitTime < this.m_PatroleMaxWaitTime)
    //					{
    //						return;
    //					}
    //					if (this.m_WayPoint.Count > 0)
    //					{
    //						this.aiState = ENUM_EnemyPathAIState.Patrol;
    //					}
    //					this.turningSpeed = 5f;
    //					this.m_PatroleWaitTime = 0f;
    //					this.m_IsPatroleWait = false;
    //					this.m_Anim.speed = this.walkSpeed;
    //					this.SetMotion(this.m_MoveMotion);
    //				}
    //			}
    //		}
    //		else if (GameMath.IsPosEqualXZ(this.startPosition, this.GetFeetPosition(), this.sleepVelocity))
    //		{
    //			if (this.m_NpcAI != null)
    //			{
    //				this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //			}
    //			this.aiState = ENUM_EnemyPathAIState.Search;
    //			if (this.m_RandWalk > 0)
    //			{
    //				this.aiState = ENUM_EnemyPathAIState.RandWalk;
    //			}
    //		}
    //	}

    //	public void UpdateRandWalk()
    //	{
    //		if (this.m_RandWalk == 0)
    //		{
    //			return;
    //		}
    //		if (this.CheckEnterAlertRange())
    //		{
    //			return;
    //		}
    //		this.m_RandWalkDeltaTime += Time.deltaTime;
    //		if (this.m_RandWalkDeltaTime >= this.m_RandWalkTime + this.m_RandWalkRandDeltaTime)
    //		{
    //			this.m_RandWalkDeltaTime = 0f;
    //			this.m_RandWalkRandDeltaTime = 0f;
    //			Vector3 b = new Vector3(0f, 0f, 0f);
    //			int num = 0;
    //			while (true)
    //			{
    //				float randWalkRange = this.m_RandWalkRange;
    //				b.x = UnityEngine.Random.Range(-randWalkRange, randWalkRange);
    //				b.z = UnityEngine.Random.Range(-randWalkRange, randWalkRange);
    //				float distXZ = GameMath.GetDistXZ(this.startPosition, this.tr.position + b);
    //				if (distXZ <= randWalkRange)
    //				{
    //					distXZ = GameMath.GetDistXZ(this.tr.position, this.tr.position + b);
    //					if (distXZ >= 2f && this.CheckCanMove(this.tr.position, this.tr.position + b))
    //					{
    //						break;
    //					}
    //				}
    //				num++;
    //				if (num >= 25)
    //				{
    //					return;
    //				}
    //			}
    //			this.SetMotion(this.m_MoveMotion);
    //			this.aiState = ENUM_EnemyPathAIState.Search;
    //			return;
    //		}
    //	}

    //	public bool CheckCanMove(Vector3 startPos, Vector3 destPos)
    //	{
    //		return this.seeker.StartPath(startPos, destPos) != null;
    //	}

    //	public void UpdatePatrol()
    //	{
    //		if (this.CheckEnterAlertRange())
    //		{
    //			return;
    //		}
    //		Vector3 vector = this.m_WayPoint[this.m_WayPointIndex] - this.tr.position;
    //		vector.Normalize();
    //		if (vector != Vector3.zero)
    //		{
    //			this.RotateTowards(vector);
    //		}
    //		if (GameMath.IsPosEqualXZ(this.m_WayPoint[this.m_WayPointIndex], this.tr.position, this.sleepVelocity) && !this.m_IsPatroleWait && this.m_PatroleMaxWaitTime > 0f)
    //		{
    //			if (this.m_NpcAI != null && this.m_NpcAI.WaitMotion.Count > 0)
    //			{
    //				int index = UnityEngine.Random.Range(0, this.m_NpcAI.WaitMotion.Count);
    //				this.SetMotion(this.m_NpcAI.WaitMotion[index]);
    //			}
    //			this.m_IsPatroleWait = true;
    //		}
    //		if (this.m_IsPatroleWait)
    //		{
    //			if (this.m_PatroleMaxWaitTime > 0f)
    //			{
    //				this.m_PatroleWaitTime += Time.deltaTime;
    //				if (this.m_PatroleWaitTime < this.m_PatroleMaxWaitTime)
    //				{
    //					return;
    //				}
    //				this.m_PatroleWaitTime = 0f;
    //				this.m_IsPatroleWait = false;
    //			}
    //			if (this.m_PinePong == 0)
    //			{
    //				this.m_WayPointIndex++;
    //				if (this.m_WayPointIndex >= this.m_WayPoint.Count)
    //				{
    //					this.m_WayPointIndex = this.m_WayPoint.Count - 2;
    //					this.m_PinePong = 1;
    //				}
    //			}
    //			else
    //			{
    //				this.m_WayPointIndex--;
    //				if (this.m_WayPointIndex < 0)
    //				{
    //					this.m_WayPointIndex = 1;
    //					this.m_PinePong = 0;
    //				}
    //			}
    //			this.SetMotion(this.m_MoveMotion);
    //		}
    //	}

    //	public void UpdateWaitFight()
    //	{
    //		this.m_WaitFightTime += Time.deltaTime;
    //		if (this.m_WaitFightTime < 0.5f)
    //		{
    //			return;
    //		}
    //		if (FightSystem.Instance.IsFightEffectInFinish())
    //		{
    //			GameMapMobSystem.Instance.TeleportToHome();
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.ShowWeapon(false);
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(1, 0f);
    //			this.DoReborn();
    //		}
    //	}

    public void EnterFight(bool bHit)
    {
        GameEntry.Instance.m_ExploreSystem.EnterFight(this.m_BattleID, bHit);
    }

    //	public void DoReborn()
    //	{
    //		this.Stop();
    //		this.tr.position = new Vector3(5000f, 0f, 5000f);
    //		this.m_RebornTime = 0f;
    //		this.m_WayPointIndex = 0;
    //		this.m_PinePong = 0;
    //		this.searchTarget = false;
    //		this.Pause();
    //		if (this.m_RebornMaxTime >= 0f)
    //		{
    //			this.HideGameObj(true);
    //			this.aiState = ENUM_EnemyPathAIState.Reborn;
    //		}
    //		else
    //		{
    //			this.DisableGameObj(true);
    //		}
    //	}

    //	public void UpdateReborn()
    //	{
    //		this.m_RebornTime += Time.deltaTime;
    //		if (this.m_RebornTime > this.m_RebornMaxTime)
    //		{
    //			this.HideGameObj(false);
    //			M_GameRoleBase component = base.gameObject.GetComponent<M_GameRoleBase>();
    //			if (component != null && component.NoCollider)
    //			{
    //				component.NoCollider = false;
    //			}
    //			this.tr.position = this.startPosition;
    //			this.m_RebornTime = 0f;
    //			this.repathRate = 0.5f;
    //			this.canMove = true;
    //			this.seeker.StartPath(this.GetFeetPosition(), this.startPosition);
    //			this.aiState = ENUM_EnemyPathAIState.Search;
    //			if (this.m_RandWalk > 0)
    //			{
    //				this.aiState = ENUM_EnemyPathAIState.RandWalk;
    //			}
    //			if (this.m_NpcAI != null)
    //			{
    //				this.SetMotion(this.m_NpcAI.WaitMotion[0]);
    //			}
    //			this.InitPatrolNode();
    //		}
    //	}

    //	public void UpdateAIState()
    //	{
    //		switch (this.aiState)
    //		{
    //		case ENUM_EnemyPathAIState.RandWalk:
    //			this.UpdateRandWalk();
    //			break;
    //		case ENUM_EnemyPathAIState.Search:
    //			this.CheckEnterAlertRange();
    //			break;
    //		case ENUM_EnemyPathAIState.Find:
    //			this.UpdateFindTarget();
    //			break;
    //		case ENUM_EnemyPathAIState.Target:
    //			this.CheckExitAlertRange();
    //			break;
    //		case ENUM_EnemyPathAIState.Wait:
    //			this.UpdateWaitToHome();
    //			break;
    //		case ENUM_EnemyPathAIState.Return:
    //			this.UpdateToHome();
    //			break;
    //		case ENUM_EnemyPathAIState.Patrol:
    //			this.UpdatePatrol();
    //			break;
    //		case ENUM_EnemyPathAIState.WatiFight:
    //			this.UpdateWaitFight();
    //			break;
    //		case ENUM_EnemyPathAIState.Reborn:
    //			this.UpdateReborn();
    //			break;
    //		}
    //	}

    //	protected new void Update()
    //	{
    //		if (this.m_Pause)
    //		{
    //			return;
    //		}
    //		if (this.target == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_Enable)
    //		{
    //			return;
    //		}
    //		this.m_CurrentBaseState = this.m_Anim.GetCurrentAnimatorStateInfo(0);
    //		this.UpdateAIState();
    //		if (this.canMove)
    //		{
    //			Vector3 vector = base.CalculateVelocity(this.GetFeetPosition());
    //			if (this.aiState == ENUM_EnemyPathAIState.Return && this.targetDirection != Vector3.zero)
    //			{
    //				this.RotateTowards(this.targetDirection);
    //			}
    //			if (vector.sqrMagnitude <= this.sleepVelocity * this.sleepVelocity)
    //			{
    //				vector = Vector3.zero;
    //			}
    //		}
    //		else
    //		{
    //			Vector3 zero = Vector3.zero;
    //		}
    //	}

    //	protected Vector3 CalculateMoveVelocity(Vector3 currentPosition)
    //	{
    //		if (this.path == null || this.path.vectorPath == null || this.path.vectorPath.Count == 0)
    //		{
    //			return Vector3.zero;
    //		}
    //		List<Vector3> vectorPath = this.path.vectorPath;
    //		if (vectorPath.Count == 1)
    //		{
    //			vectorPath.Insert(0, currentPosition);
    //		}
    //		if (this.currentWaypointIndex >= vectorPath.Count)
    //		{
    //			this.currentWaypointIndex = vectorPath.Count - 1;
    //		}
    //		if (this.currentWaypointIndex <= 1)
    //		{
    //			this.currentWaypointIndex = 1;
    //		}
    //		if (this.currentWaypointIndex < vectorPath.Count - 1)
    //		{
    //			float num = base.XZSqrMagnitude(vectorPath[this.currentWaypointIndex], currentPosition);
    //			if (num < this.pickNextWaypointDist * this.pickNextWaypointDist)
    //			{
    //				this.currentWaypointIndex++;
    //			}
    //		}
    //		Vector3 vector = vectorPath[this.currentWaypointIndex] - currentPosition;
    //		vector.y = 0f;
    //		vector.Normalize();
    //		this.targetDirection = vector;
    //		return vector;
    //	}

    //	private void SetMotion(int id)
    //	{
    //		if (id <= 0)
    //		{
    //			return;
    //		}
    //		if (this.m_Motion != null)
    //		{
    //			this.m_Motion.SetCrossMotion(id);
    //		}
    //	}

    //	private void OnTriggerEnter(Collider other)
    //	{
    //		if (other.tag == "Player")
    //		{
    //		}
    //	}

    //	public void OnStrikeHit()
    //	{
    //		S_BattleRate data = GameDataDB.BattleRateDB.GetData(this.m_BattleID);
    //		if (data == null)
    //		{
    //			Debug.LogWarning("OnStrikeHit::讀取BattleRateDB表錯誤_" + this.m_BattleID);
    //			return;
    //		}
    //		int num = 0;
    //		int num2 = 0;
    //		int num3 = UnityEngine.Random.Range(0, 100);
    //		for (int i = 0; i < data.Group.Count; i++)
    //		{
    //			num += data.Group[i].GroupRate;
    //			if (num3 < num)
    //			{
    //				num2 = data.Group[i].GroupID;
    //				break;
    //			}
    //		}
    //		if (num2 == 0)
    //		{
    //			return;
    //		}
    //		S_BattleGroup data2 = GameDataDB.BattleGroupDB.GetData(num2);
    //		if (data2 == null)
    //		{
    //			Debug.LogWarning("OnStrikeHit::讀取BattleGroupDB表錯誤_" + num2);
    //			return;
    //		}
    //		for (int j = 0; j < data2.BattleMob.Count; j++)
    //		{
    //			if (data2.BattleMob[j].GUID != 0)
    //			{
    //				S_Item data3 = GameDataDB.ItemDB.GetData(data2.BattleMob[j].GUID);
    //				for (int k = 0; k < data3.MobData.DropItem.Count; k++)
    //				{
    //					if (data3.MobData.DropItem[k].ID > 0)
    //					{
    //						Swd6Application.instance.m_ItemSystem.AddItem(data3.MobData.DropItem[k].ID, data3.MobData.DropItem[k].Count, ENUM_ItemState.New, true);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public bool OnHurt()
    //	{
    //		if (this.aiState == ENUM_EnemyPathAIState.Return)
    //		{
    //			return false;
    //		}
    //		if (this.aiState == ENUM_EnemyPathAIState.Reborn)
    //		{
    //			return false;
    //		}
    //		if (this.m_Pause)
    //		{
    //			return false;
    //		}
    //		if (!this.m_Enable)
    //		{
    //			return false;
    //		}
    //		this.aiState = ENUM_EnemyPathAIState.WatiFight;
    //		this.EnterFight(true);
    //		this.canMove = false;
    //		this.m_WaitFightTime = 0f;
    //		GameMapMobSystem.Instance.Pause();
    //		this.Enable();
    //		string name = "Base Layer.hit1";
    //		int stateNameHash = Animator.StringToHash(name);
    //		this.m_Anim.CrossFade(stateNameHash, 0.1f);
    //		EffectSystem.Instance.CreateEffect(base.transform, "point04", "P021_attack1_hit", false, true);
    //		return true;
    //	}

    public bool OnEncounter()
    {
        //if (this.aiState == ENUM_EnemyPathAIState.Return)
        //{
        //    return false;
        //}
        //if (this.aiState == ENUM_EnemyPathAIState.Reborn)
        //{
        //    return false;
        //}
        //if (this.m_Pause)
        //{
        //    return false;
        //}
        //if (!this.m_Enable)
        //{
        //    return false;
        //}
        //this.aiState = ENUM_EnemyPathAIState.WatiFight;
        this.EnterFight(false);
        //this.canMove = false;
        this.m_WaitFightTime = 0f;
        //GameMapMobSystem.Instance.Pause();
        this.Enable();
        return true;
    }

    //	public void DisableGameObj(bool disable)
    //	{
    //		M_GameRoleBase component = base.gameObject.GetComponent<M_GameRoleBase>();
    //		if (component != null)
    //		{
    //			component.DisableRole = disable;
    //			if (disable)
    //			{
    //				ExploreMiniMapSystem.Instance.RemoveQuestIcon(component.RoleID);
    //			}
    //		}
    //	}

    //	public void HideGameObj(bool bHide)
    //	{
    //		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		if (componentsInChildren != null)
    //		{
    //			SkinnedMeshRenderer[] array = componentsInChildren;
    //			for (int i = 0; i < array.Length; i++)
    //			{
    //				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
    //				if (skinnedMeshRenderer)
    //				{
    //					skinnedMeshRenderer.enabled = !bHide;
    //				}
    //			}
    //		}
    //		MeshRenderer[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<MeshRenderer>();
    //		if (componentsInChildren2 != null)
    //		{
    //			MeshRenderer[] array2 = componentsInChildren2;
    //			for (int j = 0; j < array2.Length; j++)
    //			{
    //				MeshRenderer meshRenderer = array2[j];
    //				if (meshRenderer)
    //				{
    //					meshRenderer.enabled = !bHide;
    //				}
    //			}
    //		}
    //		Light[] componentsInChildren3 = base.gameObject.GetComponentsInChildren<Light>();
    //		if (componentsInChildren != null)
    //		{
    //			Light[] array3 = componentsInChildren3;
    //			for (int k = 0; k < array3.Length; k++)
    //			{
    //				Light light = array3[k];
    //				if (light)
    //				{
    //					light.enabled = !bHide;
    //				}
    //			}
    //		}
    //		ParticleSystem[] componentsInChildren4 = base.gameObject.GetComponentsInChildren<ParticleSystem>();
    //		if (componentsInChildren4 != null)
    //		{
    //			ParticleSystem[] array4 = componentsInChildren4;
    //			for (int l = 0; l < array4.Length; l++)
    //			{
    //				ParticleSystem particleSystem = array4[l];
    //				if (particleSystem)
    //				{
    //					if (bHide)
    //					{
    //						particleSystem.Stop();
    //					}
    //					else
    //					{
    //						particleSystem.Play();
    //					}
    //				}
    //			}
    //		}
    //		if (base.gameObject.renderer != null)
    //		{
    //			base.gameObject.renderer.enabled = !bHide;
    //		}
    //	}

    //	public void NoCollider(bool value)
    //	{
    //		Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>();
    //		if (componentsInChildren != null)
    //		{
    //			Collider[] array = componentsInChildren;
    //			for (int i = 0; i < array.Length; i++)
    //			{
    //				Collider collider = array[i];
    //				collider.enabled = !value;
    //			}
    //		}
    //		MeshCollider[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<MeshCollider>();
    //		if (componentsInChildren2 != null)
    //		{
    //			MeshCollider[] array2 = componentsInChildren2;
    //			for (int j = 0; j < array2.Length; j++)
    //			{
    //				MeshCollider meshCollider = array2[j];
    //				meshCollider.enabled = !value;
    //				meshCollider.isTrigger = value;
    //			}
    //		}
    //		CharacterController component = base.gameObject.GetComponent<CharacterController>();
    //		if (component != null)
    //		{
    //			component.enabled = !value;
    //		}
    //	}

    //	public void OnDrawGizmos()
    //	{
    //		if (!this.m_DrawGizmos)
    //		{
    //			return;
    //		}
    //		if (this.path == null)
    //		{
    //			return;
    //		}
    //		if (this.path.vectorPath.Count == 0)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < this.path.vectorPath.Count; i++)
    //		{
    //			Gizmos.color = new Color(1f, 0f, 0f, 1f);
    //			Gizmos.DrawSphere(this.path.vectorPath[i], 0.1f);
    //			Gizmos.color = new Color(1f, 0f, 0f, 1f);
    //			Gizmos.DrawWireSphere(this.path.vectorPath[i], 0.4f);
    //		}
    //	}
}
