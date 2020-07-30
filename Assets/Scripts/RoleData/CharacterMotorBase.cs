using System;
using UnityEngine;

public abstract class CharacterMotorBase : MonoBehaviour
{
	public float maxForwardSpeed = 1.5f;

	public float maxBackwardsSpeed = 1.5f;

	public float maxSidewaysSpeed = 1.5f;

	public float maxVelocityChange = 8f;

	public float gravity = 25f;

	public bool canJump = true;

	public float jumpHeight = 1.7f;

	public Vector3 forwardVector = Vector3.forward;

	protected Quaternion alignCorrection;

	private bool m_Grounded;

	private bool m_Jumping;

	private Vector3 m_desiredMovementDirection;

	private Vector3 m_desiredFacingDirection;

	public bool grounded
	{
		get
		{
			return this.m_Grounded;
		}
		protected set
		{
			this.m_Grounded = value;
		}
	}

	public bool jumping
	{
		get
		{
			return this.m_Jumping;
		}
		protected set
		{
			this.m_Jumping = value;
		}
	}

	public Vector3 desiredMovementDirection
	{
		get
		{
			return this.m_desiredMovementDirection;
		}
		set
		{
			this.m_desiredMovementDirection = value;
			if (this.m_desiredMovementDirection.magnitude > 1f)
			{
				this.m_desiredMovementDirection = this.m_desiredMovementDirection.normalized;
			}
		}
	}

	public Vector3 desiredFacingDirection
	{
		get
		{
			return this.m_desiredFacingDirection;
		}
		set
		{
			this.m_desiredFacingDirection = value;
			if (this.m_desiredFacingDirection.magnitude > 1f)
			{
				this.m_desiredFacingDirection = this.m_desiredFacingDirection.normalized;
			}
		}
	}

	public Vector3 desiredVelocity
	{
		get
		{
			if (this.m_desiredMovementDirection == Vector3.zero)
			{
				return Vector3.zero;
			}
			float num = ((this.m_desiredMovementDirection.z > 0f) ? this.maxForwardSpeed : this.maxBackwardsSpeed) / this.maxSidewaysSpeed;
			Vector3 normalized = new Vector3(this.m_desiredMovementDirection.x, 0f, this.m_desiredMovementDirection.z / num).normalized;
			float d = new Vector3(normalized.x, 0f, normalized.z * num).magnitude * this.maxSidewaysSpeed;
			Vector3 point = this.m_desiredMovementDirection * d;
			return base.transform.rotation * point;
		}
	}

	private void Start()
	{
		this.alignCorrection = default(Quaternion);
		this.alignCorrection.SetLookRotation(this.forwardVector, Vector3.up);
		this.alignCorrection = Quaternion.Inverse(this.alignCorrection);
	}
}
