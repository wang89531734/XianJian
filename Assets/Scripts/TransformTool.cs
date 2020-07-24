using System;
using UnityEngine;

public class TransformTool
{
	public static Transform FindChild(Transform current, string name)
	{
		if (current.name == name)
		{
			return current;
		}
		for (int i = 0; i < current.childCount; i++)
		{
			Transform transform = TransformTool.FindChild(current.GetChild(i), name);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	public static void SetLayerRecursively(Transform root, int layer)
	{
		if (root == null)
		{
			return;
		}
		if (root.gameObject == null)
		{
			return;
		}
		root.gameObject.layer = layer;
		foreach (Transform root2 in root)
		{
			TransformTool.SetLayerRecursively(root2, layer);
		}
	}

	public static void SetLayerRecursively(Transform root, int layer, string[] ignoreName)
	{
		if (root == null)
		{
			return;
		}
		if (root.gameObject == null)
		{
			return;
		}
		for (int i = 0; i < ignoreName.Length; i++)
		{
			if (root.name == ignoreName[i])
			{
				return;
			}
		}
		root.gameObject.layer = layer;
		foreach (Transform root2 in root)
		{
			TransformTool.SetLayerRecursively(root2, layer, ignoreName);
		}
	}

	public static void SetTagRecursively(Transform root, string tag)
	{
		if (root == null)
		{
			return;
		}
		if (root.gameObject == null)
		{
			return;
		}
		root.gameObject.tag = tag;
		foreach (Transform root2 in root)
		{
			TransformTool.SetTagRecursively(root2, tag);
		}
	}

	public static void CopyTransformsRecurse(Transform src, Transform dst)
	{
		dst.position = src.position;
		dst.rotation = src.rotation;
		foreach (Transform transform in dst)
		{
			Transform transform2 = src.Find(transform.name);
			if (transform2)
			{
				TransformTool.CopyTransformsRecurse(transform2, transform);
			}
		}
	}

	public static void CreatePoint09(GameObject root)
	{
		CharacterController component = root.GetComponent<CharacterController>();
		if (component == null)
		{
			return;
		}
		GameObject gameObject = new GameObject("point09");
		gameObject.transform.position = root.transform.position + new Vector3(0f, component.center.y, 0f);
		gameObject.transform.rotation = root.transform.rotation;
		gameObject.transform.parent = root.transform;
	}
}
