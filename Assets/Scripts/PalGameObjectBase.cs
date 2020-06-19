using System;
using System.Collections.Generic;
using System.IO;
//using Funfia.File;
using SoftStar;
using SoftStar.Pal6;
using UnityEngine;

public class PalGameObjectBase : MonoBehaviour, IEditComponentHelper
{
    public static bool LoadImmediately;

    private bool isPrefab;

    //	public DOBJLayer dobjLayer;

    public GameObject model;

    //	public ObjType objType = ObjType.none;

    //	protected ObjType m_curObjType = ObjType.none;

    //	public Action<PalGameObjectBase> OnCurObjTypeChange;

    [SerializeField]
    protected string modelResourcePath;

    [SerializeField]
    protected string modelResourcePath2;

    [NonSerialized]
    public bool HasLoad;

    //	private TimeSpan loadTime;

    //	// Token: 0x040020A9 RID: 8361
    //	public Action<PalGameObjectBase> DestroyEvent;

    public GameObject Another;

    private GameObject model2;

    //	// Token: 0x040020AC RID: 8364
    //	private SphereCollider baseCollider;

    //	private Rigidbody baseRb;

    //	private List<UnityEngine.Object> prefabObjs = new List<UnityEngine.Object>();

    //	public ObjType CurObjType
    //	{
    //		get
    //		{
    //			return this.m_curObjType;
    //		}
    //		set
    //		{
    //			if (this.m_curObjType != value)
    //			{
    //				if ((value == ObjType.none || value == ObjType.none0) && this.objType != ObjType.MainLineCanNotGet && this.objType != ObjType.BranchCanNotGet0 && this.objType != ObjType.BranchCanNotGet1 && this.objType != ObjType.BranchCanNotGet2 && this.objType != ObjType.BranchCanNotGet3 && this.objType != ObjType.BranchCanNotGet4 && this.objType != ObjType.BranchCanNotGet5)
    //				{
    //					value = this.objType;
    //				}
    //				this.m_curObjType = value;
    //				if (!CharactersManager.ExistCharacter(this))
    //				{
    //					CharactersManager.AddCharacter(this);
    //				}
    //				if (this.OnCurObjTypeChange != null)
    //				{
    //					this.OnCurObjTypeChange(this);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06001CB0 RID: 7344 RVA: 0x000FFB54 File Offset: 0x000FDD54
    //	public virtual void Awake()
    //	{
    //		if (this.objType != ObjType.MainLineCanNotGet)
    //		{
    //			this.m_curObjType = this.objType;
    //		}
    //		if (this.objType != ObjType.none && this.objType != ObjType.none0)
    //		{
    //			CharactersManager.AddCharacter(this);
    //		}
    //		if (base.GetComponent<SignSetActiveByState>() != null)
    //		{
    //			CharactersManager.AddObj(this);
    //		}
    //	}

    //	// Token: 0x06001CB1 RID: 7345 RVA: 0x000FFBB0 File Offset: 0x000FDDB0
    //	public virtual void Start()
    //	{
    //	}

    public virtual string[] AvailableComponentNames
    {
        get
        {
            return new string[0];
        }
    }

    public virtual void AddComponentByName(string componentName)
    {
    }

    public virtual void RemoveComponentByName(string componentName)
    {
    }

    //	// Token: 0x06001CB5 RID: 7349 RVA: 0x000FFBC4 File Offset: 0x000FDDC4
    //	public virtual void SetModelResourcePath(string path, int index = 1)
    //	{
    //		if (index != 1)
    //		{
    //			if (index == 2)
    //			{
    //				if (this.modelResourcePath2 != path)
    //				{
    //					this.modelResourcePath2 = path;
    //				}
    //			}
    //		}
    //		else if (this.modelResourcePath != path)
    //		{
    //			this.modelResourcePath = path;
    //			this.LoadModel();
    //		}
    //	}

    //	// Token: 0x06001CB6 RID: 7350 RVA: 0x000FFC28 File Offset: 0x000FDE28
    //	public string GetModelResourcePath(int index = 1)
    //	{
    //		return (index >= 2) ? this.modelResourcePath2 : this.modelResourcePath;
    //	}

    //	// Token: 0x06001CB7 RID: 7351 RVA: 0x000FFC44 File Offset: 0x000FDE44
    //	public bool HasBundle()
    //	{
    //		string path = this.modelResourcePath.ToAssetBundlePath();
    //		return File.Exists(path);
    //	}

    //	// Token: 0x06001CB8 RID: 7352 RVA: 0x000FFC68 File Offset: 0x000FDE68
    //	public virtual bool NeedArea()
    //	{
    //		bool flag = this is PalNPC;
    //		bool flag2 = this.HasBundle();
    //		return flag && flag2;
    //	}

    //	// Token: 0x06001CB9 RID: 7353 RVA: 0x000FFC94 File Offset: 0x000FDE94
    //	public virtual void LoadModel()
    //	{
    //		if (this.HasLoad && Application.isPlaying)
    //		{
    //			return;
    //		}
    //		this.HasLoad = true;
    //		string text = this.modelResourcePath;
    //		if ((PalMain.IsXP || QualitySettings.GetQualityLevel() == 0) && !string.IsNullOrEmpty(this.modelResourcePath2))
    //		{
    //			text = this.modelResourcePath2;
    //		}
    //		if (string.IsNullOrEmpty(text))
    //		{
    //			this.LoadModelEnd(this);
    //			return;
    //		}
    //		this.loadTime = DateTime.Now.TimeOfDay;
    //		string text2 = text.ToAssetBundlePath();
    //		UnityEngine.Object temp = null;
    //		if (text2.ExistFile() && Application.isPlaying)
    //		{
    //			this.isPrefab = false;
    //			if (!PalGameObjectBase.LoadImmediately)
    //			{
    //				FileLoader.LoadAssetBundleFromFileAsync(text2, new Action<UnityEngine.Object, string>(this.OnLoadOver), true);
    //			}
    //			else
    //			{
    //				AssetBundle bundle = FileLoader.LoadAssetBundleFromFile(text2);
    //				temp = UnityEngine.Object.Instantiate(bundle.MainAsset5());
    //				this.CreateAndSetModel(temp);
    //			}
    //		}
    //		else
    //		{
    //			Debug.LogError("Load " + text + " failed, actual path = " + text2);
    //			this.LoadModelEnd(this);
    //			this.CreateAndSetModel(temp);
    //		}
    //	}

    //	// Token: 0x06001CBA RID: 7354 RVA: 0x000FFDA4 File Offset: 0x000FDFA4
    //	protected void OnLoadOver(UnityEngine.Object loadedObj, string assetBundlePath)
    //	{
    //		this.CreateAndSetModel(loadedObj);
    //	}

    //	// Token: 0x06001CBB RID: 7355 RVA: 0x000FFDB0 File Offset: 0x000FDFB0
    //	protected virtual void CreateAndSetModel(UnityEngine.Object temp)
    //	{
    //		if (temp == null)
    //		{
    //			string text = base.name + "load failed";
    //			SoftStar.Pal6.Console.Log(text);
    //			Debug.LogError(text);
    //			this.LoadModelEnd(this);
    //			return;
    //		}
    //		if (this.model != null)
    //		{
    //			UnityEngine.Object.DestroyImmediate(this.model);
    //		}
    //		this.model = (temp as GameObject);
    //		if (this.model == null)
    //		{
    //			SoftStar.Pal6.Console.Log("GameObject.Instantiate failed");
    //		}
    //		else
    //		{
    //			if (this.model.GetComponent<AutoDestroyMaterials>() == null)
    //			{
    //				this.model.AddComponent<AutoDestroyMaterials>();
    //			}
    //			this.model.transform.parent = base.transform;
    //			this.model.transform.localPosition = Vector3.zero;
    //			this.model.transform.localEulerAngles = Vector3.zero;
    //			this.model.tag = base.gameObject.tag;
    //			this.model.layer = base.gameObject.layer;
    //			if (this.isPrefab)
    //			{
    //				this.CollectPrefabObjs(this.model);
    //			}
    //		}
    //		this.LoadModelEnd(this);
    //	}

    //	// Token: 0x06001CBC RID: 7356 RVA: 0x000FFEE4 File Offset: 0x000FE0E4
    //	public virtual void LoadOver()
    //	{
    //		if (this.model != null)
    //		{
    //			UtilFun.SetActive(this.model, true);
    //		}
    //	}

    //	// Token: 0x06001CBD RID: 7357 RVA: 0x000FFF04 File Offset: 0x000FE104
    //	public virtual void LoadModelEnd(UnityEngine.Object obj)
    //	{
    //		this.loadTime = DateTime.Now.TimeOfDay.Subtract(this.loadTime);
    //		if (this.dobjLayer == null)
    //		{
    //			Transform parent = base.transform.parent;
    //			if (parent == null)
    //			{
    //				return;
    //			}
    //			this.dobjLayer = parent.GetComponent<DOBJLayer>();
    //			if (this.dobjLayer == null)
    //			{
    //				return;
    //			}
    //		}
    //		if (this.model != null)
    //		{
    //			this.model.hideFlags = HideFlags.None;
    //			if (EntityManager.Low)
    //			{
    //				Renderer[] componentsInChildren = this.model.GetComponentsInChildren<Renderer>(true);
    //				for (int i = 0; i < componentsInChildren.Length; i++)
    //				{
    //					for (int j = 0; j < componentsInChildren[i].materials.Length; j++)
    //					{
    //						if (componentsInChildren[i].materials[j] != null && componentsInChildren[i].materials[j].shader.name.Contains("/2-"))
    //						{
    //							string name = componentsInChildren[i].materials[j].shader.name;
    //							int num = componentsInChildren[i].materials[j].shader.name.IndexOf("/2-");
    //							int startIndex = componentsInChildren[i].materials[j].shader.name.IndexOf("/", num + 1);
    //							string text = name.Substring(0, num) + name.Substring(startIndex);
    //							Debug.LogWarning(this.model.name + componentsInChildren[i].name + text);
    //							if (EntityManager.shadersScript != null && EntityManager.shadersScript.shaders.ContainsKey(text))
    //							{
    //								componentsInChildren[i].materials[j].shader = EntityManager.shadersScript.shaders[text];
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		this.LoadOver();
    //		this.dobjLayer.JudgeLoadOver(this);
    //	}

    //	// Token: 0x06001CBE RID: 7358 RVA: 0x00100104 File Offset: 0x000FE304
    //	public virtual void OnDestroy()
    //	{
    //		if (this.DestroyEvent != null)
    //		{
    //			this.DestroyEvent(this);
    //		}
    //	}

    //	// Token: 0x17000295 RID: 661
    //	// (get) Token: 0x06001CBF RID: 7359 RVA: 0x00100120 File Offset: 0x000FE320
    //	public GameObject anotherModel
    //	{
    //		get
    //		{
    //			GameObject result = null;
    //			if (this.Another != null)
    //			{
    //				result = this.Another.GetModelObj(false);
    //			}
    //			return result;
    //		}
    //	}

    //	// Token: 0x06001CC0 RID: 7360 RVA: 0x00100150 File Offset: 0x000FE350
    //	public virtual void SetAnother(int ID)
    //	{
    //		GameObject gameObject = GameObject.Find(ID.ToString());
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.SetAnother(gameObject);
    //	}

    //	// Token: 0x06001CC1 RID: 7361 RVA: 0x00100180 File Offset: 0x000FE380
    //	public virtual void SetAnother(GameObject go)
    //	{
    //		if (go == null)
    //		{
    //			return;
    //		}
    //		this.Another = go;
    //	}

    //	// Token: 0x06001CC2 RID: 7362 RVA: 0x00100198 File Offset: 0x000FE398
    //	public virtual void ChangeModelForever(GameObject go, bool bActive = false)
    //	{
    //		if (go == null)
    //		{
    //			Debug.LogError("ChangeModelForever 失败");
    //			return;
    //		}
    //		go.GetComponent<Agent>().palNPC = base.GetComponent<PalNPC>();
    //		Transform transform = go.transform;
    //		transform.parent = base.transform;
    //		transform.position = this.model.transform.position;
    //		transform.rotation = this.model.transform.rotation;
    //		UnityEngine.Object.Destroy(this.model);
    //		this.model = go;
    //		UtilFun.SetActive(this.model, bActive);
    //		if (base.gameObject == PlayersManager.Player)
    //		{
    //			this.model.GetComponent<Agent>().curCtrlMode = ControlMode.None;
    //		}
    //		else
    //		{
    //			this.model.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
    //		}
    //	}

    //	// Token: 0x06001CC3 RID: 7363 RVA: 0x00100268 File Offset: 0x000FE468
    //	public virtual void ChangeModel(GameObject go, bool bSyncItem = true)
    //	{
    //		this.SetAnother(go);
    //		if (this.anotherModel == null)
    //		{
    //			Debug.LogError("没有另外一个模型");
    //			return;
    //		}
    //		if (this.model2 != null && this.model2.GetComponent<Animator>() == null)
    //		{
    //			this.model2 = null;
    //		}
    //		if (this.model2 == null)
    //		{
    //			this.model2 = this.anotherModel;
    //		}
    //		if (this.model2 == null)
    //		{
    //			Debug.LogError("Error : ChangeModel model2==null");
    //			return;
    //		}
    //		PalNPC component = base.GetComponent<PalNPC>();
    //		Agent component2 = this.model2.GetComponent<Agent>();
    //		component2.palNPC = component;
    //		component.perception = component2.perception;
    //		SneakScript orAddComponent = this.model2.GetOrAddComponent<SneakScript>();
    //		orAddComponent.hostNpc = component;
    //		GameObject gameObject = this.model;
    //		this.model = this.model2;
    //		this.model2 = gameObject;
    //		this.model.transform.position = this.model2.transform.position;
    //		this.model.transform.rotation = this.model2.transform.rotation;
    //		if (!this.model.activeSelf && PlayersManager.Player == base.gameObject)
    //		{
    //			UtilFun.SetActive(this.model, true);
    //		}
    //		if (this.model2.activeSelf)
    //		{
    //			UtilFun.SetActive(this.model2, false);
    //		}
    //		if (base.gameObject == PlayersManager.Player)
    //		{
    //			this.model.GetComponent<Agent>().curCtrlMode = ControlMode.None;
    //		}
    //		else
    //		{
    //			this.model.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
    //		}
    //		this.model2.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
    //		if (PlayersManager.Player == base.gameObject)
    //		{
    //			PlayerCtrlManager.Reset();
    //		}
    //		if (bSyncItem)
    //		{
    //			PalNPC palNPC = this as PalNPC;
    //			if (palNPC != null)
    //			{
    //				Transform transform = this.model.transform;
    //				for (int i = 0; i < palNPC.Weapons.Count; i++)
    //				{
    //					GameObject gameObject2 = palNPC.Weapons[i];
    //					if (gameObject2 != null)
    //					{
    //						UtilFun.BindItemToProp(transform, gameObject2.transform, i, UtilFun.BindSlot.Default);
    //					}
    //				}
    //				GameObject ornament = palNPC.ornament;
    //				if (ornament != null)
    //				{
    //					UtilFun.BindOrnamentToProp(transform, ornament.transform, true);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06001CC4 RID: 7364 RVA: 0x001004E4 File Offset: 0x000FE6E4
    //	public void InitForLowPC()
    //	{
    //		base.enabled = false;
    //		this.CreateAreaTarget();
    //		this.LoadModelEnd(this);
    //	}

    //	// Token: 0x06001CC5 RID: 7365 RVA: 0x001004FC File Offset: 0x000FE6FC
    //	private void CreateAreaTarget()
    //	{
    //		base.gameObject.SetActive(true);
    //		this.baseCollider = base.gameObject.AddComponent<SphereCollider>();
    //		this.baseRb = base.gameObject.AddComponent<Rigidbody>();
    //		this.baseRb.isKinematic = true;
    //		Vector3 b = new Vector3(0f, 0.01f, 0f);
    //		base.transform.position += b;
    //		base.transform.position -= b;
    //		base.Invoke("ClearTarget", 0.01f);
    //	}

    //	// Token: 0x06001CC6 RID: 7366 RVA: 0x00100598 File Offset: 0x000FE798
    //	private void ClearTarget()
    //	{
    //		if (this.baseCollider != null)
    //		{
    //			UnityEngine.Object.Destroy(this.baseCollider);
    //			this.baseCollider = null;
    //		}
    //		if (this.baseRb != null)
    //		{
    //			UnityEngine.Object.Destroy(this.baseRb);
    //			this.baseRb = null;
    //		}
    //	}

    //	// Token: 0x06001CC7 RID: 7367 RVA: 0x001005EC File Offset: 0x000FE7EC
    //	public virtual void Clear()
    //	{
    //		if (this.isPrefab)
    //		{
    //			this.ClearPrefab();
    //		}
    //		if (this.model != null)
    //		{
    //			UnityEngine.Object.Destroy(this.model);
    //			this.model = null;
    //		}
    //	}

    //	// Token: 0x06001CC8 RID: 7368 RVA: 0x00100630 File Offset: 0x000FE830
    //	public virtual void CollectPrefabObjs(GameObject go)
    //	{
    //		foreach (Renderer renderer in go.GetComponentsInChildren<Renderer>(true))
    //		{
    //			foreach (Material material in renderer.materials)
    //			{
    //				if (!(material == null))
    //				{
    //					if (material.HasProperty(ShaderPropertyIDManager._MainTexID))
    //					{
    //						Texture texture = material.GetTexture(ShaderPropertyIDManager._MainTexID);
    //						this.prefabObjs.Add(texture);
    //					}
    //					if (material.HasProperty(ShaderPropertyIDManager._BumpMapID))
    //					{
    //						Texture texture2 = material.GetTexture(ShaderPropertyIDManager._BumpMapID);
    //						this.prefabObjs.Add(texture2);
    //					}
    //					if (material.HasProperty(ShaderPropertyIDManager._SpecularTexID))
    //					{
    //						Texture texture3 = material.GetTexture(ShaderPropertyIDManager._SpecularTexID);
    //						this.prefabObjs.Add(texture3);
    //					}
    //					if (material.HasProperty(ShaderPropertyIDManager._DetailID))
    //					{
    //						Texture texture4 = material.GetTexture(ShaderPropertyIDManager._DetailID);
    //						this.prefabObjs.Add(texture4);
    //					}
    //					if (material.HasProperty(ShaderPropertyIDManager._DetailBumpID))
    //					{
    //						Texture texture5 = material.GetTexture(ShaderPropertyIDManager._DetailBumpID);
    //						this.prefabObjs.Add(texture5);
    //					}
    //				}
    //			}
    //		}
    //		foreach (MeshFilter meshFilter in go.GetComponentsInChildren<MeshFilter>(true))
    //		{
    //			this.prefabObjs.Add(meshFilter.sharedMesh);
    //		}
    //		foreach (Animator animator in go.GetComponentsInChildren<Animator>(true))
    //		{
    //			this.prefabObjs.Add(animator.runtimeAnimatorController);
    //		}
    //	}

    //	// Token: 0x06001CC9 RID: 7369 RVA: 0x001007F0 File Offset: 0x000FE9F0
    //	public virtual void ClearPrefab()
    //	{
    //		if (base.transform == null)
    //		{
    //			return;
    //		}
    //		string path = GameObjectPath.GetPath(base.transform);
    //		for (int i = 0; i < this.prefabObjs.Count; i++)
    //		{
    //			UnityEngine.Object @object = this.prefabObjs[i];
    //			if (@object != null)
    //			{
    //				Resources.UnloadAsset(@object);
    //			}
    //		}
    //		this.prefabObjs.Clear();
    //	}
}
