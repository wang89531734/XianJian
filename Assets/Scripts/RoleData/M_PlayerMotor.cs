using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class M_PlayerMotor : CharacterMotorBase
{
	public float maxRotationSpeed = 270f;

	public float dirY = -1f;

	public bool m_DoJump;

	public bool m_IsJump;

	public bool m_CanJump = true;

	public bool m_NavAgent;

	private bool firstframe = true;

	private float m_JumpOverTime;

	public Vector3 jumpAddVelocity;

	private Vector3 activeLocalPlatformPoint;

	private Vector3 activeGlobalPlatformPoint;

	private Transform activePlatform;

	private void OnEnable()
	{
		this.firstframe = true;
	}

	public void Jump()
	{
		//LegAnimator component = base.gameObject.GetComponent<LegAnimator>();
		//if (component && !component.enabled)
		//{
		//	M_PlayerController component2 = base.gameObject.GetComponent<M_PlayerController>();
		//	if (component2)
		//	{
		//		component2.PlayIdleMotion();
		//	}
		//}
		this.activePlatform = null;
		if (this.m_CanJump)
		{
			this.m_DoJump = true;
			this.m_IsJump = true;
			this.m_JumpOverTime = 0f;
		}
	}

	public bool IsJump()
	{
		return this.m_DoJump;
	}

	public bool IsJumpOver()
	{
		return this.m_IsJump;
	}

	private void UpdateFacingDirection()
	{
		float magnitude = base.desiredFacingDirection.magnitude;
		Vector3 vector = base.transform.rotation * base.desiredMovementDirection * (1f - magnitude) + base.desiredFacingDirection * magnitude;
        vector = Util.ProjectOntoPlane(vector, base.transform.up);
        vector = this.alignCorrection * vector;
        if (vector.sqrMagnitude > 0.01f)
        {
            Vector3 vector2 = Util.ConstantSlerp(base.transform.forward, vector, this.maxRotationSpeed * Time.deltaTime);
            vector2 = Util.ProjectOntoPlane(vector2, base.transform.up);
            Quaternion rotation = default(Quaternion);
            rotation.SetLookRotation(vector2, base.transform.up);
            base.transform.rotation = rotation;
            this.dirY = base.transform.eulerAngles.y;
        }
    }

	private void UpdateVelocity()
	{
		CharacterController characterController = base.GetComponent(typeof(CharacterController)) as CharacterController;
		Vector3 vector = characterController.velocity;
		if (this.firstframe)
		{
			vector = Vector3.zero;
			this.firstframe = false;
		}
		if (this.activePlatform != null)
		{
			M_PlayerController component = base.gameObject.GetComponent<M_PlayerController>();
			if (component)
			{
                component.UpdateInputOnMovePlatform();
            }
			Vector3 a = this.activePlatform.TransformPoint(this.activeLocalPlatformPoint);
			Vector3 b = a - this.activeGlobalPlatformPoint;
			base.transform.position = base.transform.position + b;
		}
		this.activePlatform = null;
		if (base.grounded)
		{
            vector = Util.ProjectOntoPlane(vector, base.transform.up);
        }
		Vector3 a2 = vector;
		base.jumping = false;
		if (base.grounded)
		{
			Vector3 b2 = base.desiredVelocity - vector;
			if (b2.magnitude > this.maxVelocityChange)
			{
				b2 = b2.normalized * this.maxVelocityChange;
			}
			a2 += b2;
		}
		if (this.m_DoJump && this.m_CanJump)
		{
			a2 += base.transform.up * Mathf.Sqrt(2f * this.jumpHeight * this.gravity);
			this.m_CanJump = false;
			base.jumping = true;
			this.jumpAddVelocity = Vector3.zero;
		}
		a2 += base.transform.up * -this.gravity * Time.deltaTime;
		if (base.jumping)
		{
			a2 -= base.transform.up * -this.gravity * Time.deltaTime / 2f;
		}
		if (characterController.enabled)
		{
			CollisionFlags collisionFlags = characterController.Move(a2 * Time.deltaTime);
			base.grounded = ((collisionFlags & CollisionFlags.Below) != CollisionFlags.None);
		}
		if (base.grounded && this.m_DoJump)
		{
			base.SendMessage("OnFootStrike", SendMessageOptions.DontRequireReceiver);
			this.m_JumpOverTime = 0.5f;
			this.m_CanJump = true;
			this.m_DoJump = false;
			this.jumpAddVelocity = Vector3.zero;
		}
		if (this.activePlatform != null)
		{
			this.activeGlobalPlatformPoint = base.transform.position;
			this.activeLocalPlatformPoint = this.activePlatform.InverseTransformPoint(base.transform.position);
		}
		if (this.m_JumpOverTime > 0f)
		{
			this.m_JumpOverTime -= Time.deltaTime;
			if (this.m_JumpOverTime <= 0f)
			{
				this.m_JumpOverTime = 0f;
				this.m_IsJump = false;
			}
		}
	}

	private void Update()
	{
		if (!this.m_NavAgent)
		{
			this.UpdateFacingDirection();
		}
		this.UpdateVelocity();
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.collider.tag == "MovePlatform")
		{
			this.activePlatform = hit.collider.transform;
		}
	}
}
