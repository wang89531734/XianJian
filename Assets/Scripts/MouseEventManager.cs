using System;
using SoftStar.Pal6;
using UnityEngine;

/// <summary>
/// 鼠标事件管理器
/// </summary>
public class MouseEventManager : MonoBehaviour
{
    private static MouseEventManager instance;

    public Action<Transform> OnMouseEnterEvent;

    public Action<Transform> OnMouseOverEvent;

    public Action<Transform> OnMouseExitEvent;

    public static MouseEventManager Instance
	{
		get
		{
			if (MouseEventManager.instance == null)
			{
				MouseEventManager.Initialize();
			}
			return MouseEventManager.instance;
		}
	}

	public static void Initialize()
	{
		if (MouseEventManager.instance == null && PalMain.Instance != null)
		{
			GameObject gameObject = PalMain.Instance.gameObject;
			MouseEventManager.instance = gameObject.GetComponent<MouseEventManager>();
			if (MouseEventManager.instance == null)
			{
				MouseEventManager.instance = gameObject.AddComponent<MouseEventManager>();
			}
		}
	}

	public void MouseEnterEvent(Transform tf)
	{
		if (this.OnMouseEnterEvent != null)
		{
			this.OnMouseEnterEvent(tf);
		}
	}

	public void MouseOverEvent(Transform tf)
	{
		if (this.OnMouseOverEvent != null)
		{
			this.OnMouseOverEvent(tf);
		}
	}

	public void MouseExitEvent(Transform tf)
	{
		if (this.OnMouseExitEvent != null)
		{
			this.OnMouseExitEvent(tf);
		}
	}
}
