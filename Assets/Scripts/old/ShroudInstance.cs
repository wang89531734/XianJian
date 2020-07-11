using System;
using System.Runtime.InteropServices;
//using SoftStar.Pal6.UI;
using UnityEngine;


[AddComponentMenu("Physics/Shroud/Shroud Instance")]
public class ShroudInstance : MonoBehaviour
{
    private const string Shroud_Module_Name = "ShroudUnityPlugin";

    private const uint kInvalidShroudID = 4294967295u;

    public string m_shroudFileName;

    public SkinnedMeshRenderer[] m_skinnedMesh;

    public Material[] m_materials;

    public float m_blendStartDistance = 30f;

    // Token: 0x04001D7D RID: 7549
    public float m_blendEndDistance = 35f;

    // Token: 0x04001D7E RID: 7550
    public float blendWeightK = 100f;

    // Token: 0x04001D7F RID: 7551
    public float windStrength = 1f;

    // Token: 0x04001D80 RID: 7552
    public bool CaculateCollider = true;

    // Token: 0x04001D81 RID: 7553
    protected Transform[] m_boneTransforms;

    // Token: 0x04001D82 RID: 7554
    protected Transform[] m_colliderTransforms;

    // Token: 0x04001D83 RID: 7555
    protected GameObject[] m_shroudGameObjects;

    // Token: 0x04001D84 RID: 7556
    private uint m_shroudInstanceID;

    // Token: 0x04001D85 RID: 7557
    //protected PalShroudObjectManager shroudMgrCmp;

    // Token: 0x04001D86 RID: 7558
    private uint hairIndex;

    // Token: 0x04001D87 RID: 7559
    private bool m_WeightForHair = true;

    // Token: 0x04001D88 RID: 7560
    private float m_HairWeightK = 100f;

    // Token: 0x04001D89 RID: 7561
    private bool HasInit;

    public event Action<GameObject> OnInitOver;

	// Token: 0x06001A25 RID: 6693
	[DllImport("ShroudUnityPlugin")]
	private static extern void ReleaseInstance(uint shroudInstanceID);

	// Token: 0x06001A26 RID: 6694
	[DllImport("ShroudUnityPlugin")]
	private static extern uint GetNumMeshes(uint shroudInstanceID);

	// Token: 0x06001A27 RID: 6695
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetBlend(float blendValue, uint meshIndex, uint shroudInstanceID);

	// Token: 0x06001A28 RID: 6696
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetRootMatrix(IntPtr mtx, uint meshIndex, uint shroudInstanceID);

	// Token: 0x06001A29 RID: 6697
	[DllImport("ShroudUnityPlugin")]
	private static extern uint GetNumTransforms(uint shroudInstanceID);

	// Token: 0x06001A2A RID: 6698
	[DllImport("ShroudUnityPlugin")]
	private static extern IntPtr GetTransformBoneName(uint index, uint shroudInstanceID);

	// Token: 0x06001A2B RID: 6699
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetTransformMatrix(uint index, IntPtr mtx, uint shroudInstanceID);

	// Token: 0x06001A2C RID: 6700
	[DllImport("ShroudUnityPlugin")]
	private static extern uint GetNumColliders(uint shroudInstanceID);

	// Token: 0x06001A2D RID: 6701
	[DllImport("ShroudUnityPlugin")]
	private static extern IntPtr GetColliderBoneName(uint index, uint shroudInstanceID);

	// Token: 0x06001A2E RID: 6702
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetColliderMatrix(uint index, IntPtr mtx, uint shroudInstanceID);

	// Token: 0x06001A2F RID: 6703
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetWind(ref Vector3 direction, float strength, uint shroudInstanceID);

	// Token: 0x06001A30 RID: 6704
	[DllImport("ShroudUnityPlugin")]
	private static extern void SetCameraDirection(ref Vector3 direction, uint shroudInstanceID);

	// Token: 0x06001A31 RID: 6705
	[DllImport("ShroudUnityPlugin")]
	private static extern void BeginUpdate(float timestep, uint shroudInstanceID);

	// Token: 0x06001A32 RID: 6706 RVA: 0x000EC5C0 File Offset: 0x000EA7C0
	public virtual void SetWind(ref Vector3 direction, float strength)
	{
		ShroudInstance.SetWind(ref direction, strength, this.m_shroudInstanceID);
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x000EC5D0 File Offset: 0x000EA7D0
	public void SetGlobalWind()
	{
		//if (this.shroudMgrCmp == null)
		//{
		//	return;
		//}
		//if (this.shroudMgrCmp.WindDir.magnitude < 0.001f)
		//{
		//	return;
		//}
		//ShroudInstance.SetWind(ref this.shroudMgrCmp.WindDir, this.shroudMgrCmp.WindDir.magnitude, this.m_shroudInstanceID);
	}

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06001A34 RID: 6708 RVA: 0x000EC630 File Offset: 0x000EA830
	// (set) Token: 0x06001A35 RID: 6709 RVA: 0x000EC638 File Offset: 0x000EA838
	public bool WeightForHair
	{
		get
		{
			return this.m_WeightForHair;
		}
		set
		{
			this.m_WeightForHair = value;
		}
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06001A36 RID: 6710 RVA: 0x000EC644 File Offset: 0x000EA844
	// (set) Token: 0x06001A37 RID: 6711 RVA: 0x000EC64C File Offset: 0x000EA84C
	public float HairWeightK
	{
		get
		{
			return this.m_HairWeightK;
		}
		set
		{
			this.m_HairWeightK = value;
		}
	}

	// Token: 0x06001A38 RID: 6712 RVA: 0x000EC658 File Offset: 0x000EA858
	public static void Init(GameObject go)
	{
		if (go == null)
		{
			Debug.LogError("ShroudInstance.Init go==null");
			return;
		}
		ShroudInstance component = go.GetComponent<ShroudInstance>();
		if (component != null)
		{
			component.Start();
		}
	}

	// Token: 0x06001A39 RID: 6713 RVA: 0x000EC698 File Offset: 0x000EA898
	public void SetHasInit(bool bValue)
	{
		this.HasInit = true;
	}

	// Token: 0x06001A3A RID: 6714 RVA: 0x000EC6A4 File Offset: 0x000EA8A4
	public void Start()
	{
		if (this.HasInit)
		{
			return;
		}
		this.HasInit = true;
		//this.shroudMgrCmp = PalShroudObjectManager.Instance;
		//if (this.shroudMgrCmp)
		//{
		//	this.m_shroudInstanceID = this.shroudMgrCmp.CreateInstance(this.m_shroudFileName, this);
		//}
		if (this.m_shroudInstanceID != 4294967295u)
		{
			uint numMeshes = ShroudInstance.GetNumMeshes(this.m_shroudInstanceID);
			this.m_shroudGameObjects = new GameObject[numMeshes];
			for (uint num = 0u; num < numMeshes; num += 1u)
			{
				this.m_shroudGameObjects[(int)((UIntPtr)num)] = new GameObject("Shroud Mesh");
				this.m_shroudGameObjects[(int)((UIntPtr)num)].layer = base.gameObject.layer;
				this.m_shroudGameObjects[(int)((UIntPtr)num)].transform.parent = base.transform;
				this.m_shroudGameObjects[(int)((UIntPtr)num)].AddComponent<MeshFilter>();
				MeshRenderer meshRenderer = this.m_shroudGameObjects[(int)((UIntPtr)num)].AddComponent<MeshRenderer>();
				//ShroudMesh shroudMesh = this.m_shroudGameObjects[(int)((UIntPtr)num)].AddComponent<ShroudMesh>();
				//shroudMesh.m_shroudInstanceID = this.m_shroudInstanceID;
				//shroudMesh.m_meshIndex = num;
				if ((ulong)num < (ulong)((long)this.m_materials.Length) && this.m_materials[(int)((UIntPtr)num)])
				{
					meshRenderer.material = this.m_materials[(int)((UIntPtr)num)];
				}
				else if ((ulong)num < (ulong)((long)this.m_skinnedMesh.Length) && this.m_skinnedMesh[(int)((UIntPtr)num)])
				{
					this.m_skinnedMesh[(int)((UIntPtr)num)].enabled = false;
					meshRenderer.material = this.m_skinnedMesh[(int)((UIntPtr)num)].material;
				}
				string text = meshRenderer.material.name.ToLower();
				if (text.Contains("_hair"))
				{
					this.hairIndex = num;
				}
			}
			this.SetupTransforms();
			this.SetupColliders();
			this.SetGlobalWind();
			if (this.OnInitOver != null)
			{
				this.OnInitOver(base.gameObject);
			}
		}
		else
		{
			Debug.LogError("Shroud: Failed to create Shroud Instance for " + this.m_shroudFileName);
		}
	}

	// Token: 0x06001A3B RID: 6715 RVA: 0x000EC8A4 File Offset: 0x000EAAA4
	public GameObject GetHairObj()
	{
		GameObject result = null;
		if ((ulong)this.hairIndex < (ulong)((long)this.m_shroudGameObjects.Length))
		{
			result = this.m_shroudGameObjects[(int)((UIntPtr)this.hairIndex)];
		}
		return result;
	}

	// Token: 0x06001A3C RID: 6716 RVA: 0x000EC8D8 File Offset: 0x000EAAD8
	public void OnDestroy()
	{
		//if (this.shroudMgrCmp != null)
		//{
		//	this.shroudMgrCmp.RemoveInstance(this);
		//}
		ShroudInstance.ReleaseInstance(this.m_shroudInstanceID);
		if (this.m_shroudGameObjects != null)
		{
			for (int i = 0; i < this.m_shroudGameObjects.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(this.m_shroudGameObjects[i]);
				this.m_shroudGameObjects[i] = null;
			}
			this.m_shroudGameObjects = null;
		}
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x000EC950 File Offset: 0x000EAB50
	private void LateUpdate()
	{
		uint numMeshes = ShroudInstance.GetNumMeshes(this.m_shroudInstanceID);
		if (numMeshes > 0u)
		{
			//ShroudMesh.EndUpdate(this.m_shroudInstanceID);
			//for (uint num = 0u; num < numMeshes; num += 1u)
			//{
			//	ShroudMesh component = this.m_shroudGameObjects[(int)((UIntPtr)num)].GetComponent<ShroudMesh>();
			//	if (component)
			//	{
			//		component.UpdateBounds();
			//	}
			//}
			bool flag = this.UpdateBlendValue();
			if (flag)
			{
				this.UpdateTransforms();
				if (this.CaculateCollider)
				{
					this.UpdateColliders();
				}
				for (uint num2 = 0u; num2 < numMeshes; num2 += 1u)
				{
					IntPtr intPtr = this.MarshalToPointer(this.m_shroudGameObjects[(int)((UIntPtr)num2)].transform.localToWorldMatrix);
					ShroudInstance.SetRootMatrix(intPtr, num2, this.m_shroudInstanceID);
					Marshal.FreeHGlobal(intPtr);
				}
				ShroudInstance.BeginUpdate(Time.deltaTime, this.m_shroudInstanceID);
			}
		}
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x000ECA30 File Offset: 0x000EAC30
	private void SetupTransforms()
	{
		uint numTransforms = ShroudInstance.GetNumTransforms(this.m_shroudInstanceID);
		this.m_boneTransforms = new Transform[numTransforms];
		for (uint num = 0u; num < numTransforms; num += 1u)
		{
			string text = Marshal.PtrToStringAnsi(ShroudInstance.GetTransformBoneName(num, this.m_shroudInstanceID));
			if (text.Length > 0)
			{
				Transform transform = this.FindBone(base.gameObject.transform, text);
				if (transform)
				{
					this.m_boneTransforms[(int)((UIntPtr)num)] = transform;
				}
				else
				{
					Debug.LogWarning("Shroud: Could not find bone defined in " + this.m_shroudFileName + ": " + text);
				}
			}
			else if (num == 0u)
			{
				this.m_boneTransforms[(int)((UIntPtr)num)] = base.transform;
			}
		}
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x000ECAE8 File Offset: 0x000EACE8
	private void SetupColliders()
	{
		uint numColliders = ShroudInstance.GetNumColliders(this.m_shroudInstanceID);
		this.m_colliderTransforms = new Transform[numColliders];
		for (uint num = 0u; num < numColliders; num += 1u)
		{
			string text = Marshal.PtrToStringAnsi(ShroudInstance.GetColliderBoneName(num, this.m_shroudInstanceID));
			if (text.Length > 0)
			{
				Transform transform = this.FindBone(base.gameObject.transform, text);
				if (transform)
				{
					this.m_colliderTransforms[(int)((UIntPtr)num)] = transform;
				}
				else
				{
					Debug.LogWarning("Shroud: Could not find bone defined in " + this.m_shroudFileName + ": " + text);
				}
			}
		}
	}

	// Token: 0x06001A40 RID: 6720 RVA: 0x000ECB88 File Offset: 0x000EAD88
	private void UpdateTransforms()
	{
		uint numTransforms = ShroudInstance.GetNumTransforms(this.m_shroudInstanceID);
		for (uint num = 0u; num < numTransforms; num += 1u)
		{
			if (this.m_boneTransforms[(int)((UIntPtr)num)])
			{
				IntPtr intPtr = this.MarshalToPointer(this.m_boneTransforms[(int)((UIntPtr)num)].localToWorldMatrix);
				ShroudInstance.SetTransformMatrix(num, intPtr, this.m_shroudInstanceID);
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	// Token: 0x06001A41 RID: 6721 RVA: 0x000ECBF4 File Offset: 0x000EADF4
	private bool UpdateBlendValue()
	{
		if (this.m_skinnedMesh.Length < 1)
		{
			Debug.LogError(base.transform.name + " shroud skinnedMesh列表为空");
			base.enabled = false;
			return false;
		}
		Camera camera;
		//if (!UIManager.IsPIPMode)
		//{
		//	camera = Camera.main;
		//}
		//else
		//{
		//	camera = UI_3D.Instance.UI_3D_Camera;
		//}
		//if (camera != null)
		//{
		//	Vector3 forward = camera.transform.forward;
		//	ShroudInstance.SetCameraDirection(ref forward, this.m_shroudInstanceID);
		//	Vector3 position = base.transform.position;
		//	float magnitude = (position - camera.transform.position).magnitude;
		//	float num = (magnitude - this.m_blendStartDistance) / (this.m_blendEndDistance - this.m_blendStartDistance);
		//	num = ((num >= 0f) ? num : 0f);
		//	num = ((num <= 1f) ? num : 1f);
		//	num = 1f - num;
		//	this.blendWeightK = Mathf.Clamp(this.blendWeightK, 0.01f, 100f);
		//	num *= this.blendWeightK / 100f;
		//	uint numMeshes = ShroudInstance.GetNumMeshes(this.m_shroudInstanceID);
		//	for (uint num2 = 0u; num2 < numMeshes; num2 += 1u)
		//	{
		//		if ((ulong)num2 < (ulong)((long)this.m_skinnedMesh.Length))
		//		{
		//			SkinnedMeshRenderer skinnedMeshRenderer = this.m_skinnedMesh[(int)((UIntPtr)num2)];
		//			if (this.WeightForHair && num2 == this.hairIndex)
		//			{
		//				this.HairWeightK = Mathf.Clamp(this.HairWeightK, 0.01f, 100f);
		//				float blendValue = this.HairWeightK / 100f;
		//				ShroudInstance.SetBlend(blendValue, num2, this.m_shroudInstanceID);
		//				if ((ulong)num2 < (ulong)((long)this.m_skinnedMesh.Length) && skinnedMeshRenderer)
		//				{
		//					MeshRenderer component = this.m_shroudGameObjects[(int)((UIntPtr)num2)].GetComponent<MeshRenderer>();
		//					skinnedMeshRenderer.enabled = false;
		//					component.enabled = true;
		//				}
		//			}
		//			else
		//			{
		//				ShroudInstance.SetBlend(num, num2, this.m_shroudInstanceID);
		//				if ((ulong)num2 < (ulong)((long)this.m_skinnedMesh.Length) && skinnedMeshRenderer)
		//				{
		//					MeshRenderer component2 = this.m_shroudGameObjects[(int)((UIntPtr)num2)].GetComponent<MeshRenderer>();
		//					if (num == 0f)
		//					{
		//						skinnedMeshRenderer.enabled = true;
		//						component2.enabled = false;
		//					}
		//					else
		//					{
		//						skinnedMeshRenderer.enabled = false;
		//						component2.enabled = true;
		//					}
		//				}
		//			}
		//		}
		//	}
		//	return num > 0f;
		//}
		return true;
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x000ECE78 File Offset: 0x000EB078
	private void UpdateColliders()
	{
		uint numColliders = ShroudInstance.GetNumColliders(this.m_shroudInstanceID);
		for (uint num = 0u; num < numColliders; num += 1u)
		{
			if (this.m_colliderTransforms[(int)((UIntPtr)num)])
			{
				IntPtr intPtr = this.MarshalToPointer(this.m_colliderTransforms[(int)((UIntPtr)num)].localToWorldMatrix);
				ShroudInstance.SetColliderMatrix(num, intPtr, this.m_shroudInstanceID);
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x000ECEE4 File Offset: 0x000EB0E4
	private Transform FindBone(Transform current, string name)
	{
		if (current.name == name)
		{
			return current;
		}
		for (int i = 0; i < current.childCount; i++)
		{
			Transform transform = this.FindBone(current.GetChild(i), name);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x000ECF3C File Offset: 0x000EB13C
	private IntPtr MarshalToPointer(object data)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(data));
		Marshal.StructureToPtr(data, intPtr, false);
		return intPtr;
	}
}
