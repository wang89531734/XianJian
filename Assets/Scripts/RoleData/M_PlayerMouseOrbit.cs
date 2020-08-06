using System;
using UnityEngine;
using YouYou;

public class M_PlayerMouseOrbit : MonoBehaviour
{
	public Transform m_Target;

	private float m_TargetHeight;

	private bool m_IsLerp;

	public float m_YPositionLimit = 0.02f;

	public float m_Distance = 5.5f;

	public float m_XSpeed = 120f;

	public float m_YSpeed = 120f;

	public float m_YMinLimit = -20f;

	public float m_YMaxLimit = 80f;

	public float m_DistanceMin = 1f;

	public float m_DistanceMax = 5.5f;

	public float m_XAngle;

	public float m_YAngle = 30f;

	public float m_SnapAngle;

	public float m_TurnSpeed = 0.05f;

	public float m_FreeMoveSpeed = 10f;

	public bool m_LockMode;

	public bool m_BigMapMode;

	public bool m_NoControl;

	public bool m_AtuoFollow;

	public bool m_Snapping;

	public bool m_FreeControl;

	private Vector3 velocity = Vector3.zero;

	private Transform m_Transform;

	private float m_DistanceByPhysics;

	private float m_yVelocity;

	public float m_Damping = 10f;

	public float m_ZoomDamping = 0.3f;

	public bool m_Isphysics = true;

	public bool m_ShootMode
	{
		get;
		set;
	}

	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.m_XAngle = eulerAngles.y;
		this.m_YAngle = eulerAngles.x;
		if (GameEntry.Instance.m_ExploreSystem.PlayerController)
		{
			this.m_XAngle = GameEntry.Instance.m_ExploreSystem.PlayerController.Dir;
			this.m_YAngle = 10f;
		}
		if (GameEntry.Instance.m_ExploreSystem.m_SetCemeraInfo)
		{
            GameEntry.Instance.m_ExploreSystem.m_SetCemeraInfo = false;
			this.m_XAngle = GameEntry.Instance.m_ExploreSystem.m_CameraXAngle;
			this.m_YAngle = GameEntry.Instance.m_ExploreSystem.m_CameraYAngle;
			if (GameEntry.Instance.m_ExploreSystem.m_CameraDist > 0f)
			{
				this.m_Distance = GameEntry.Instance.m_ExploreSystem.m_CameraDist;
			}
		}
		if (this.m_BigMapMode)
		{
			this.m_Distance = 8f;
			this.m_DistanceMax = 8f;
			this.m_YAngle = 30.5f;
		}
		//if (base.rigidbody)
		//{
		//	base.rigidbody.freezeRotation = true;
		//}
		this.m_Transform = base.transform;
		this.m_DistanceByPhysics = this.m_Distance;
		if (this.m_Target != null)
		{
			Quaternion rotation = Quaternion.Euler(this.m_YAngle, this.m_XAngle, 0f);
			Vector3 point = new Vector3(0f, 0f, -this.m_Distance);
			Vector3 position = rotation * point + this.m_Target.position;
			this.m_Transform.position = position;
			this.m_TargetHeight = this.m_Target.position.y;
		}
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
		bool lockPlayer = GameEntry.Instance.m_ExploreSystem.LockPlayer;
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
		bool flag = false;
		bool flag2 = false;
		if (Input.GetMouseButton(1))
		{
			this.m_Snapping = false;
			flag = true;
			if (!lockPlayer || !this.m_ShootMode)
			{
				this.m_XAngle += Input.GetAxis("Mouse X") * this.m_XSpeed * this.m_TurnSpeed;
				if (!this.m_LockMode)
				{
					this.m_YAngle -= Input.GetAxis("Mouse Y") * this.m_YSpeed * this.m_TurnSpeed;
				}
			}
		}

		if (!lockPlayer || !this.m_ShootMode)
		{
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_LEFT))
			{
				flag2 = true;
				this.m_XAngle -= this.m_XSpeed * Time.deltaTime;
			}
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_RIGHT))
			{
				flag2 = true;
				this.m_XAngle += this.m_XSpeed * Time.deltaTime;
			}
			if (!this.m_LockMode)
			{
				if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_UP))
				{
					flag2 = true;
					this.m_YAngle += this.m_YSpeed * 0.01f;
				}
				if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_DOWN))
				{
					flag2 = true;
					this.m_YAngle -= this.m_YSpeed * 0.01f;
				}
			}
		}
		this.m_YAngle = M_PlayerMouseOrbit.ClampAngle(this.m_YAngle, this.m_YMinLimit, this.m_YMaxLimit);
		this.m_XAngle = M_PlayerMouseOrbit.ClampAngle360(this.m_XAngle);
		Quaternion rotation = Quaternion.Euler(this.m_YAngle, this.m_XAngle, 0f);
		if (!lockPlayer && !this.m_LockMode)
		{
			this.m_Distance = Mathf.Clamp(this.m_Distance - Input.GetAxis("Mouse ScrollWheel") * 5f, this.m_DistanceMin, this.m_DistanceMax);
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_IN))
			{
				this.m_Distance = Mathf.Clamp(this.m_Distance - 0.1f, this.m_DistanceMin, this.m_DistanceMax);
			}
			if (GameInput.GetKeyActionPress(KEY_ACTION.CAMERA_OUT))
			{
				this.m_Distance = Mathf.Clamp(this.m_Distance - -0.1f, this.m_DistanceMin, this.m_DistanceMax);
			}
		}
		if (this.m_AtuoFollow)
		{
			if (GameInput.GetKeyActionDown(KEY_ACTION.SNAP) && !this.m_Snapping)
			{
				this.m_SnapAngle = GameEntry.Instance.m_ExploreSystem.PlayerController.Dir;
				this.velocity = Vector3.zero;
				this.m_Snapping = true;
			}
			if (!flag && !flag2)
			{
				this.m_YAngle = Mathf.Lerp(this.m_YAngle, 10f, Time.deltaTime * 0.5f);
				rotation = this.SetUpRotation(this.m_Target.position);
				this.m_Transform.rotation = rotation;
			}
		}
		Vector3 point = new Vector3(0f, 0f, -this.m_Distance);
		Vector3 vector = rotation * point + this.m_Target.position;
		bool flag3 = false;
		int num = 1024;
		num |= 4;
		num |= 512;
		num = ~num;
		this.m_Transform.rotation = rotation;
		if (this.m_Isphysics)
		{
			RaycastHit raycastHit;
			if (Physics.Linecast(this.m_Target.position, vector, out raycastHit, num))
			{
				flag3 = true;
				if (raycastHit.collider.tag == "Player")
				{
					flag3 = false;
				}
				if (raycastHit.collider.tag == "Npc")
				{
					flag3 = false;
				}
				if (raycastHit.collider.tag == "Event")
				{
					flag3 = false;
				}
			}
			if (flag3)
			{
				float num2 = (this.m_Target.position - raycastHit.point).magnitude;
				num2 = Mathf.Clamp(num2 - 1f, this.m_DistanceMin, this.m_DistanceMax);
				this.m_DistanceByPhysics = Mathf.SmoothDamp(this.m_DistanceByPhysics, num2, ref this.m_yVelocity, this.m_ZoomDamping);
			}
			else if (this.m_DistanceByPhysics != this.m_Distance)
			{
				this.m_DistanceByPhysics = Mathf.SmoothDamp(this.m_DistanceByPhysics, this.m_Distance, ref this.m_yVelocity, this.m_ZoomDamping);
			}
			vector = rotation * new Vector3(0f, 0f, -this.m_DistanceByPhysics) + this.m_Target.position;
		}
		if (Mathf.Abs(this.m_Target.position.y - this.m_TargetHeight) > this.m_YPositionLimit)
		{
			this.m_IsLerp = true;
		}
		if (this.m_IsLerp)
		{
			this.m_Transform.position = new Vector3(vector.x, Mathf.Lerp(this.m_Transform.position.y, vector.y, Time.deltaTime * this.m_Damping), vector.z);
			if (Mathf.Abs(this.m_Transform.position.y - vector.y) < 0.01f)
			{
				this.m_IsLerp = false;
			}
		}
		else
		{
			this.m_Transform.position = vector;
		}
		this.m_TargetHeight = this.m_Target.position.y;
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

	public void SetFlyMode()
	{
		this.m_LockMode = true;
		this.m_Distance = 8f;
		this.m_DistanceMax = 8f;
		this.m_YAngle = 31.5f;
	}

	public void SetBigMapMode()
	{
		this.m_LockMode = true;
		this.m_BigMapMode = true;
		this.m_Distance = 8f;
		this.m_DistanceMax = 8f;
		this.m_YAngle = 30.5f;
	}

	public void SetNormalMode()
	{
		this.m_LockMode = false;
		this.m_BigMapMode = false;
		this.m_NoControl = false;
		this.m_DistanceMax = 5.5f;
		if (this.m_Distance > this.m_DistanceMax)
		{
			this.m_Distance = this.m_DistanceMax;
		}
	}

	public void SetLookTargetMode(string target1, string target2)
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
