using System;
using UnityEngine;

public struct ControllerState
{
	public int Stance;

	public Vector3 Velocity;

	public Vector3 Position;

	public GameObject Support;

	public Vector3 SupportPosition;

	public Quaternion SupportRotation;

	public Vector3 SupportContactPosition;

	public Vector3 SupportMove;

	public bool IsForwardPathBlocked;

	public bool IsGrounded;

	public bool IsSlop;

	public float GroundDistance;

	public Vector3 GroundNormal;

	public float GroundAngle;

	public Vector3 GroundLaunchVelocity;

	public float InputX;

	public float InputY;

	public Vector3 InputForward;

	public float InputFromAvatarAngle;

	public float InputFromCameraAngle;

	public static void Shift(ref ControllerState rCurrent, ref ControllerState rPrev)
	{
		rPrev = rCurrent;
		rCurrent.Support = null;
		rCurrent.SupportMove = Vector3.zero;
		rCurrent.SupportPosition = Vector3.zero;
		rCurrent.SupportRotation = Quaternion.identity;
		rCurrent.IsForwardPathBlocked = false;
		rCurrent.IsGrounded = false;
		rCurrent.GroundAngle = 0f;
		rCurrent.GroundNormal = Vector3.up;
		rCurrent.GroundDistance = 3.40282347E+38f;
	}
}
