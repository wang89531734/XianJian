using System;
using UnityEngine;
using YouYou;

public class M_PlayerMouseOrbit : MonoBehaviour
{
	public Transform m_Target;

	public float m_Distance = 5.5f;

	public float m_XSpeed = 120f;

	public float m_YSpeed = 120f;

	public float m_YMinLimit = -15f;

	public float m_YMaxLimit = 50f;

	public float m_DistanceMin = 1.5f;

	public float m_DistanceMax = 7f;

	public float m_XAngle;

	public float m_YAngle = 30f;

	public float m_SnapAngle;

	public float m_TurnSpeed = 0.03f;

	public float m_FreeMoveSpeed = 10f;

	public Vector3 m_LookOffset = Vector3.zero;

	public bool m_LockMode;

	public bool m_NoControl;

	public bool m_AtuoFollow;

	public bool m_Snapping;

	public bool m_FreeControl;

	private Vector3 velocity = Vector3.zero;

	private Transform m_Transform;

	public float m_DistanceByPhysics;

	private float m_yVelocity;

	public float m_RMosuePressTime;

	public float m_LMosuePressTime;

	public float m_Damping = 10f;

	public float m_ZoomDamping = 0.05f;

	public bool m_Isphysics = true;

	public float m_BeforeHitOffset = 2f;

	public float m_AfterHitOffset = 0.5f;

	private void Start()
	{
		this.m_Transform = base.transform;
		this.SetSaveCameraData(true);
	}

	public void Init()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.m_XAngle = eulerAngles.y;
		this.m_YAngle = eulerAngles.x;
		if (GameEntry.Instance.m_ExploreSystem.PlayerController)
		{
			this.m_XAngle = GameEntry.Instance.m_ExploreSystem.PlayerController.Dir;
			this.m_YAngle = 10f;
		}
		this.m_DistanceByPhysics = this.m_Distance;
		if (this.m_Target != null)
		{
			Quaternion rotation = Quaternion.Euler(this.m_YAngle, this.m_XAngle, 0f);
			Vector3 point = new Vector3(0f, 0f, -this.m_Distance);
			Vector3 position = rotation * point + this.m_Target.position;
			this.m_Transform.position = position;
		}
	}

	public void SetSaveCameraData(bool clear)
	{
		if (GameEntry.Instance == null)
		{
			return;
		}
		if (GameEntry.Instance.m_ExploreSystem.m_SetCemeraInfo)
		{
			if (clear)
			{
                GameEntry.Instance.m_ExploreSystem.m_SetCemeraInfo = false;
			}
			this.m_XAngle = GameEntry.Instance.m_ExploreSystem.m_CameraXAngle;
			this.m_YAngle = GameEntry.Instance.m_ExploreSystem.m_CameraYAngle;
			if (GameEntry.Instance.m_ExploreSystem.m_CameraDist > 0f)
			{
				this.m_Distance = GameEntry.Instance.m_ExploreSystem.m_CameraDist;
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraMinDist > 0f)
			{
				this.m_DistanceMin = GameEntry.Instance.m_ExploreSystem.m_CameraMinDist;
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraMaxDist > 0f)
			{
				this.m_DistanceMax = GameEntry.Instance.m_ExploreSystem.m_CameraMaxDist;
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraYMinLimit != 0f)
			{
				this.m_YMinLimit = GameEntry.Instance.m_ExploreSystem.m_CameraYMinLimit;
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraYMaxLimit != 0f)
			{
				this.m_YMaxLimit = GameEntry.Instance.m_ExploreSystem.m_CameraYMaxLimit;
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraIsphysics != 0)
			{
				if (GameEntry.Instance.m_ExploreSystem.m_CameraIsphysics == 1)
				{
					this.m_Isphysics = true;
				}
				else
				{
					this.m_Isphysics = false;
				}
			}
			if (GameEntry.Instance.m_ExploreSystem.m_CameraLock != 0)
			{
				if (GameEntry.Instance.m_ExploreSystem.m_CameraLock == 1)
				{
					this.m_LockMode = true;
				}
				else
				{
					this.m_LockMode = false;
				}
			}
		}
	}

	private void UpdateFreeControl()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		if (Input.GetMouseButton(1))
		{
			this.m_XAngle += Input.GetAxis("Mouse X") * this.m_XSpeed * this.m_TurnSpeed;
			this.m_YAngle -= Input.GetAxis("Mouse Y") * this.m_YSpeed * this.m_TurnSpeed;
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_LEFT))
		{
			this.m_XAngle -= this.m_XSpeed * 0.01f;
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_RIGHT))
		{
			this.m_XAngle += this.m_XSpeed * 0.01f;
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_UP))
		{
			this.m_YAngle += this.m_YSpeed * 0.01f;
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_DOWN))
		{
			this.m_YAngle -= this.m_YSpeed * 0.01f;
		}
		if (GameInput.IsPressUpKey())
		{
			vector += this.m_Transform.forward * (this.m_FreeMoveSpeed * Time.deltaTime);
		}
		if (GameInput.IsPressDownKey())
		{
			vector -= this.m_Transform.forward * (this.m_FreeMoveSpeed * Time.deltaTime);
		}
		if (GameInput.IsPressLeftKey())
		{
			vector -= this.m_Transform.right * (this.m_FreeMoveSpeed * Time.deltaTime);
		}
		if (GameInput.IsPressRightKey())
		{
			vector += this.m_Transform.right * (this.m_FreeMoveSpeed * Time.deltaTime);
		}
		if (GameInput.GetKey(KeyCode.KeypadPlus))
		{
			this.m_FreeMoveSpeed += 0.1f;
		}
		if (GameInput.GetKey(KeyCode.KeypadMinus))
		{
			this.m_FreeMoveSpeed -= 0.1f;
			if (this.m_FreeMoveSpeed <= 0.1f)
			{
				this.m_FreeMoveSpeed = 0.1f;
			}
		}
		this.m_YAngle = M_PlayerMouseOrbit.ClampAngle(this.m_YAngle, this.m_YMinLimit, this.m_YMaxLimit);
		this.m_XAngle = M_PlayerMouseOrbit.ClampAngle360(this.m_XAngle);
		Quaternion rotation = Quaternion.Euler(this.m_YAngle, this.m_XAngle, 0f);
		this.m_Transform.rotation = rotation;
		this.m_Transform.position += vector;
	}

	private void LateUpdate()
	{
		if (this.m_NoControl)
		{
			return;
		}
		Camera component = base.GetComponent<Camera>();
		if (component && !component.enabled)
		{
			return;
		}
		if (this.m_FreeControl)
		{
			this.UpdateFreeControl();
			return;
		}
		if (this.m_Target == null)
		{
			return;
		}
		if (Input.GetMouseButton(1))
		{
			this.m_RMosuePressTime += Time.deltaTime;
		}
		if (Input.GetMouseButtonUp(1))
		{
			this.m_RMosuePressTime = 0f;
		}
		if (this.m_RMosuePressTime >= 0.05f)
		{
			this.m_Snapping = false;
			if (!this.m_LockMode)
			{
				this.m_XAngle += Input.GetAxis("Mouse X") * this.m_XSpeed * this.m_TurnSpeed;
				this.m_YAngle -= Input.GetAxis("Mouse Y") * this.m_YSpeed * this.m_TurnSpeed;
			}
		}
		if (!this.m_LockMode)
		{
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_LEFT))
			{
				this.m_XAngle -= this.m_XSpeed * Time.deltaTime;
			}
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_RIGHT))
			{
				this.m_XAngle += this.m_XSpeed * Time.deltaTime;
			}
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_UP))
			{
				this.m_YAngle += this.m_YSpeed * 0.01f;
			}
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_DOWN))
			{
				this.m_YAngle -= this.m_YSpeed * 0.01f;
			}
		}
		this.m_YAngle = M_PlayerMouseOrbit.ClampAngle(this.m_YAngle, this.m_YMinLimit, this.m_YMaxLimit);
		this.m_XAngle = M_PlayerMouseOrbit.ClampAngle360(this.m_XAngle);
		Quaternion rotation = Quaternion.Euler(this.m_YAngle, this.m_XAngle, 0f);
		if (!this.m_LockMode)
		{
			this.m_Distance = Mathf.Clamp(this.m_Distance - Input.GetAxis("Mouse ScrollWheel") * 5f, this.m_DistanceMin, this.m_DistanceMax);
			if (!GameEntry.Instance.m_ExploreSystem.LockPlayer)
			{
				if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_IN))
				{
					this.m_Distance = Mathf.Clamp(this.m_Distance - 0.1f, this.m_DistanceMin, this.m_DistanceMax);
				}
				if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_OUT))
				{
					this.m_Distance = Mathf.Clamp(this.m_Distance - -0.1f, this.m_DistanceMin, this.m_DistanceMax);
				}
			}
		}
		if (this.m_AtuoFollow)
		{
		}
		Vector3 point = new Vector3(0f, -0.5f, -(this.m_Distance + this.m_BeforeHitOffset));
		Vector3 vector = this.m_Target.position + this.m_LookOffset;
		Vector3 vector2 = rotation * point + vector;
		int num = 32768;
		num |= 4;
		num = ~num;
		this.m_Transform.rotation = rotation;
		if (this.m_Isphysics)
		{
			RaycastHit raycastHit;
			if (Physics.Linecast(vector, vector2, out raycastHit, num))
			{
				if (raycastHit.collider.tag != "Npc")
				{
					float num2 = (vector - raycastHit.point).magnitude;
					num2 = Mathf.Clamp(num2 - this.m_AfterHitOffset, this.m_DistanceMin, this.m_DistanceMax);
					this.m_DistanceByPhysics = Mathf.SmoothDamp(this.m_DistanceByPhysics, num2, ref this.m_yVelocity, this.m_ZoomDamping);
				}
			}
			else if (this.m_DistanceByPhysics != this.m_Distance)
			{
				this.m_DistanceByPhysics = Mathf.SmoothDamp(this.m_DistanceByPhysics, this.m_Distance, ref this.m_yVelocity, this.m_ZoomDamping);
			}
			vector2 = rotation * new Vector3(0f, 0f, -this.m_DistanceByPhysics) + vector;
		}
		this.m_Transform.position = vector2;
	}

	public Quaternion SetUpRotation(Vector3 centerPos)
	{
		Vector3 position = base.transform.position;
		Vector3 vector = centerPos - position;
		Quaternion lhs = Quaternion.LookRotation(new Vector3(vector.x, 0f, vector.z));
		Vector3 forward = Vector3.forward * this.m_Distance;
		base.transform.rotation = lhs * Quaternion.LookRotation(forward);
		base.transform.rotation *= Quaternion.Euler(this.m_YAngle, 0f, 0f);
		if (this.m_Snapping)
		{
			Vector3 eulerAngles = default(Vector3);
			eulerAngles = base.transform.rotation.eulerAngles;
			eulerAngles.y = Mathf.Lerp(base.transform.rotation.eulerAngles.y, this.m_SnapAngle, Time.deltaTime * this.m_Damping);
			base.transform.eulerAngles = eulerAngles;
			if ((double)this.AngleDistance(eulerAngles.y, this.m_SnapAngle) <= 1.0)
			{
				this.m_SnapAngle = 0f;
				this.m_Snapping = false;
			}
		}
		this.m_XAngle = base.transform.rotation.eulerAngles.y;
		this.m_XAngle = M_PlayerMouseOrbit.ClampAngle360(this.m_XAngle);
		return base.transform.rotation;
	}

	public Vector3 ApplySnapping(Vector3 targetCenter)
	{
		Vector3 position = base.transform.position;
		Vector3 vector = position - targetCenter;
		vector.y = 0f;
		float num = vector.magnitude;
		float smoothTime = 0.2f;
		float maxSpeed = 10f;
		float smoothTime2 = 0.3f;
		float y = this.m_Target.eulerAngles.y;
		float num2 = base.transform.eulerAngles.y;
		num2 = Mathf.SmoothDampAngle(num2, y, ref this.velocity.x, smoothTime2);
		num = Mathf.SmoothDamp(num, this.m_Distance, ref this.velocity.z, smoothTime2);
		Vector3 vector2 = targetCenter;
		vector2 += Quaternion.Euler(0f, num2, 0f) * Vector3.back * num;
		vector2.y = Mathf.SmoothDamp(position.y, targetCenter.y + 1f, ref this.velocity.y, smoothTime, maxSpeed);
		vector2 = this.AdjustLineOfSight(vector2, targetCenter);
		base.transform.position = vector2;
		if ((double)this.AngleDistance(num2, y) < 3.0)
		{
			this.m_Snapping = false;
			this.velocity = Vector3.zero;
		}
		return vector2;
	}

	public Vector3 AdjustLineOfSight(Vector3 newPosition, Vector3 target)
	{
		int num = 1024;
		num |= 4;
		num = ~num;
		RaycastHit raycastHit;
		if (Physics.Linecast(target, newPosition, out raycastHit, num))
		{
			this.velocity = Vector3.zero;
			return raycastHit.point;
		}
		return newPosition;
	}

	public float AngleDistance(float a, float b)
	{
		a = Mathf.Repeat(a, 360f);
		b = Mathf.Repeat(b, 360f);
		return Mathf.Abs(b - a);
	}

	public void SetNormalMode()
	{
		this.m_LockMode = false;
		this.m_NoControl = false;
		this.m_Isphysics = true;
		this.m_DistanceMin = 1.5f;
		this.m_DistanceMax = 7f;
		this.m_YMinLimit = -15f;
		this.m_YMaxLimit = 50f;
		this.m_TurnSpeed = 0.03f;
		this.m_LookOffset = Vector3.zero;
		if (this.m_Distance > this.m_DistanceMax)
		{
			this.m_Distance = this.m_DistanceMax;
		}
		this.SetSaveCameraData(false);
	}

	public void SetLookTargetMode(string target1, string target2, float dir)
	{
		this.m_NoControl = true;
		GameObject gameObject = GameObject.Find(target1);
		if (gameObject == null)
		{
			Debug.Log("SetLookTargetMode_找不到targer1_" + target1);
			return;
		}
		GameObject gameObject2 = GameObject.Find(target2);
		if (gameObject2 == null)
		{
			Debug.Log("SetLookTargetMode_找不到targer2_" + target2);
			return;
		}
		this.m_Transform.position = gameObject.transform.position;
		this.m_Transform.LookAt(gameObject2.transform);
		if (dir != 0f)
		{
			Vector3 eulerAngles = this.m_Transform.eulerAngles;
			eulerAngles.y = dir;
			this.m_Transform.eulerAngles = eulerAngles;
		}
	}

	public void TurnLeft()
	{
		this.m_XAngle += Time.deltaTime * this.m_TurnSpeed;
	}

	public void TurnRight()
	{
		this.m_XAngle -= Time.deltaTime * this.m_TurnSpeed;
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public static float ClampAngle360(float angle)
	{
		if (angle < 0f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, 0f, 360f);
	}
}
