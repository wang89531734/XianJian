using Pathfinding;
using System;
using UnityEngine;

public class M_AStarAI : MonoBehaviour
{
	public Path m_Path;

	public float m_NextWaypointDistance = 1f;

	public int m_CurrnetWaypoint;

	public float m_PickNextWaypointDist = 1.5f;

	public Vector3 m_MoveTarget;

	public bool m_DrawGizmos;

	private Seeker m_Seeker;

	public M_GameRoleBase m_RoleBase;

	public void Awake()
	{
		this.m_RoleBase = base.GetComponent<M_GameRoleBase>();
		this.m_Seeker = base.GetComponent<Seeker>();
	}

	public void SetMoveTarget(Vector3 moveTarget)
	{
		this.m_MoveTarget = moveTarget;
		this.m_Seeker.StartPath(base.transform.position, moveTarget, new OnPathDelegate(this.OnPathComplete));
	}

	public void Stop()
	{
		this.m_CurrnetWaypoint = 0;
		this.m_Seeker.ReleaseClaimedPath();
		this.m_Path = null;
	}

	public void OnPathComplete(Path p)
	{
		if (!p.error)
		{
			this.m_Path = p;
			this.m_Path.Claim(this);
			this.m_CurrnetWaypoint = 0;
			this.IgnoreNearPoint(base.transform.position);
		}
		else
		{
			this.m_Path = p;
		}
	}

	public void FixedUpdate()
	{
		if (this.m_Path == null)
		{
			return;
		}
		if (this.m_Path.error)
		{
			if (this.m_RoleBase.SetAutoMovePosition(this.m_MoveTarget))
			{
				this.m_Path = null;
				if (this.m_RoleBase != null)
				{
					this.m_RoleBase.StopAutoMove();
				}
			}
			return;
		}
		if (this.m_CurrnetWaypoint >= this.m_Path.vectorPath.Count)
		{
			if (this.m_RoleBase != null)
			{
				this.m_RoleBase.StopAutoMove();
			}
			return;
		}
		if (this.m_RoleBase != null && this.m_RoleBase.SetAutoMovePosition(this.m_Path.vectorPath[this.m_CurrnetWaypoint]))
		{
			this.m_CurrnetWaypoint++;
		}
	}

	public void IgnoreNearPoint(Vector3 currentPosition)
	{
		while (this.m_CurrnetWaypoint < this.m_Path.vectorPath.Count - 1)
		{
			float num = this.XZSqrMagnitude(this.m_Path.vectorPath[this.m_CurrnetWaypoint], currentPosition);
			if (num >= this.m_PickNextWaypointDist * this.m_PickNextWaypointDist)
			{
				return;
			}
			this.m_CurrnetWaypoint++;
		}
	}

	private float XZSqrMagnitude(Vector3 a, Vector3 b)
	{
		float num = b.x - a.x;
		float num2 = b.z - a.z;
		return num * num + num2 * num2;
	}

	public void OnDrawGizmos()
	{
		if (!this.m_DrawGizmos)
		{
			return;
		}
		if (this.m_Path == null)
		{
			return;
		}
		if (this.m_Path.vectorPath.Count == 0)
		{
			return;
		}
		for (int i = 0; i < this.m_Path.vectorPath.Count; i++)
		{
			Gizmos.color = new Color(1f, 0f, 0f, 1f);
			Gizmos.DrawSphere(this.m_Path.vectorPath[i], 0.1f);
			Gizmos.color = new Color(1f, 0f, 0f, 1f);
			Gizmos.DrawWireSphere(this.m_Path.vectorPath[i], 0.4f);
		}
	}
}
