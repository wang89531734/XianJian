using System;
using SoftStar.Pal6;
using UnityEngine;

/// <summary>
/// 初始化潜伏脚本
/// </summary>
public class InitSneakScript : MonoBehaviour
{
    private PalNPC npc;

    private void Start()
	{
		this.npc = base.GetComponent<PalNPC>();
		if (this.npc == null)
		{
			Debug.LogError(base.name + " 没有PalNPC");
			UnityEngine.Object.DestroyImmediate(this);
		}
        SneakScript[] componentsInChildren = this.npc.GetComponentsInChildren<SneakScript>(true);
        if (componentsInChildren != null && componentsInChildren.Length > 0)
        {
            UnityEngine.Object.DestroyImmediate(this);
        }
    }

	private void Update()
	{
        if (this.npc.model != null)
        {
            SneakScript.Init(this.npc.model);
            UnityEngine.Object.DestroyImmediate(this);
        }
    }
}
