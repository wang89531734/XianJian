using System;
using UnityEngine;

public class GameMath
{
	public static Quaternion RotateToTarget(Transform from, Transform target)
	{
		Vector3 vector = target.position - from.position;
		return Quaternion.LookRotation(new Vector3(vector.x, 0f, vector.z), Vector3.up);
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

	public static bool IsPosEqualXZ(Vector3 pos1, Vector3 pos2, float dist)
	{
		Vector3 a = new Vector3(pos1.x, 0f, pos1.z);
		Vector3 b = new Vector3(pos2.x, 0f, pos2.z);
		return Vector3.Distance(a, b) <= dist;
	}

	public static bool IsPosEqual(Vector3 pos1, Vector3 pos2, float dist)
	{
		return Vector3.Distance(pos1, pos2) <= dist;
	}

	public static float GetDistXZ(Vector3 pos1, Vector3 pos2)
	{
		Vector3 a = new Vector3(pos1.x, 0f, pos1.z);
		Vector3 b = new Vector3(pos2.x, 0f, pos2.z);
		return Vector3.Distance(a, b);
	}

	public static float Get2DDistance(Vector2 p1, Vector2 p2)
	{
		return Vector2.Distance(p1, p2);
	}

	public static float GetAngle(Vector3 pos1, Vector3 pos2)
	{
		float num = Mathf.Atan2(pos2.x - pos1.x, pos2.z - pos1.z);
		num *= 57.2957764f;
		if (num < 0f)
		{
			num = 360f + num;
		}
		return GameMath.ClampAngle(num, 0f, 360f);
	}

	public static float GetAngle(float x1, float z1, float x2, float z2)
	{
		float num = Mathf.Atan2(x2 - x1, z2 - z1);
		num *= 57.2957764f;
		if (num < 0f)
		{
			num = 360f + num;
		}
		return GameMath.ClampAngle(num, 0f, 360f);
	}

	public static float LerpAngle(float a, float b, float t)
	{
		float num = Mathf.LerpAngle(a, b, t);
		if (num < 0f)
		{
			num = 360f + num;
		}
		return num;
	}

	public static Vector3 TransformWorldPositionToSceenPoint(Camera camera, Vector3 v)
	{
		return camera.WorldToScreenPoint(v);
	}

	public static Vector3 ScreenToWorldPoint(Camera camera, Vector3 v)
	{
		return camera.ScreenToWorldPoint(v);
	}

	public static Vector3 WorldToNUIScreenPoint(Vector3 pos)
	{
		//UIRoot uIRoot = Swd6Application.instance.m_UIRoot;
		Vector3 result = Camera.main.WorldToScreenPoint(pos);
		result.x -= (float)Screen.width * 0.5f;
		result.y -= (float)Screen.height * 0.5f;
		result.z = 0f;
		//result.x *= uIRoot.pixelSizeAdjustment;
		//result.y *= uIRoot.pixelSizeAdjustment;
		return result;
	}

	public static Vector3 PlaneRayIntersection(Plane plane, Ray ray)
	{
		float distance = 0f;
		plane.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}

	public static Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
	{
		Ray ray = camera.ScreenPointToRay(screenPoint);
		return GameMath.PlaneRayIntersection(plane, ray);
	}

	public static Vector3 RayCastOnTerrain(Vector3 Pos, float height)
	{
		Vector3 vector = Pos;
		vector.y += height;
		Ray ray = default(Ray);
		ray.origin = vector;
		ray.direction = new Vector3(0f, -1f, 0f);
		RaycastHit raycastHit = default(RaycastHit);
		Physics.Raycast(ray, out raycastHit, 1000f);
		if (null != raycastHit.transform)
		{
			vector = Pos;
			vector.y = raycastHit.point.y + 0.01f;
		}
		return vector;
	}

	public static void CastObjectOnTerrain(GameObject PrefObj, float offsetY)
	{
		RaycastHit raycastHit;
		bool flag = Physics.Raycast(PrefObj.transform.position + new Vector3(0f, offsetY, 0f), Vector3.up * -1f, out raycastHit, 3f);
		if (flag)
		{
			PrefObj.transform.position = raycastHit.point;
		}
	}

	public static bool PointHitViewAngle(Vector3 centerPos, Vector3 targetPos, float startAngle, float alertAngle)
	{
		startAngle = GameMath.SetStartAngle(startAngle);
		float num = Vector3.Distance(centerPos, targetPos);
		float num2 = GameMath.GetAngle(centerPos, targetPos);
		if (startAngle > 180f && num2 < 180f)
		{
			num2 += 360f;
		}
		return num2 >= startAngle && num2 <= startAngle + alertAngle;
	}

	public static float SetStartAngle(float Angle)
	{
		if (Angle < 0f)
		{
			Angle = Angle % 360f + 360f;
		}
		else if (Angle >= 360f)
		{
			Angle %= 360f;
		}
		return Angle;
	}
}
