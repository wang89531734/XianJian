using System;
using UnityEngine;

public class M_MouseOrbit : MonoBehaviour
{
	public Transform target;

	public float distance = 8f;

	public float xSpeed = 50f;

	public float ySpeed = 50f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	public float distanceMin = 0.5f;

	public float distanceMax = 25f;

	public float x;

	public float y;

	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		//if (base.rigidbody)
		//{
		//	base.rigidbody.freezeRotation = true;
		//}
	}

	private void LateUpdate()
	{
		if (this.target)
		{
			if (Input.GetMouseButton(1))
			{
				this.x += Input.GetAxis("Mouse X") * this.xSpeed * this.distance * 0.02f;
				this.y -= Input.GetAxis("Mouse Y") * this.ySpeed * 0.02f;
			}
			this.y = M_MouseOrbit.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
			Quaternion rotation = Quaternion.Euler(this.y, this.x, 0f);
			this.distance = Mathf.Clamp(this.distance - Input.GetAxis("Mouse ScrollWheel") * 5f, this.distanceMin, this.distanceMax);
			Vector3 point = new Vector3(0f, 0f, -this.distance);
			Vector3 position = rotation * point + this.target.position;
			base.transform.rotation = rotation;
			base.transform.position = position;
		}
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
}
