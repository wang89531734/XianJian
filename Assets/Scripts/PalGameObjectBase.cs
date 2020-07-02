using Funfia.File;
using SoftStar;
using SoftStar.Pal6;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YouYou;

public class PalGameObjectBase : MonoBehaviour, IEditComponentHelper
{
	private bool isPrefab;

	//public DOBJLayer dobjLayer;

	public GameObject model;

    /// <summary>
    /// 物体类型
    /// </summary>
	public ObjType objType = ObjType.none;

    /// <summary>
    /// 当前物体类型
    /// </summary>
	protected ObjType m_curObjType = ObjType.none;

    /// <summary>
    /// 当前物体类型改变
    /// </summary>
	public Action<PalGameObjectBase> OnCurObjTypeChange;

	[NonSerialized]
	public bool HasLoad;

	public Action<PalGameObjectBase> DestroyEvent;

	public GameObject Another;

	private GameObject model2;

	private SphereCollider baseCollider;

	private Rigidbody baseRb;

	private List<UnityEngine.Object> prefabObjs = new List<UnityEngine.Object>();

	public ObjType CurObjType
	{
		get
		{
			return this.m_curObjType;
		}
		set
		{
			if (this.m_curObjType != value)
			{
				if ((value == ObjType.none || value == ObjType.none0) && this.objType != ObjType.MainLineCanNotGet && this.objType != ObjType.BranchCanNotGet0 && this.objType != ObjType.BranchCanNotGet1 && this.objType != ObjType.BranchCanNotGet2 && this.objType != ObjType.BranchCanNotGet3 && this.objType != ObjType.BranchCanNotGet4 && this.objType != ObjType.BranchCanNotGet5)
				{
					value = this.objType;
				}
				this.m_curObjType = value;
				//if (!CharactersManager.ExistCharacter(this))
				//{
				//	CharactersManager.AddCharacter(this);
				//}
				if (this.OnCurObjTypeChange != null)
				{
					this.OnCurObjTypeChange(this);
				}
			}
		}
	}

	public virtual string[] AvailableComponentNames
	{
		get
		{
			return new string[0];
		}
	}

	public GameObject anotherModel
	{
		get
		{
			GameObject result = null;
			if (this.Another != null)
			{
				//result = this.Another.GetModelObj(false);
			}
			return result;
		}
	}

	public virtual void Awake()
	{
		if (this.objType != ObjType.MainLineCanNotGet)
		{
			this.m_curObjType = this.objType;
		}
		//if (this.objType != ObjType.none && this.objType != ObjType.none0)
		//{
  //          //CharactersManager.AddCharacter(this);
  //      }
		//if (base.GetComponent<SignSetActiveByState>() != null)
		//{
		//	//CharactersManager.AddObj(this);
		//}
	}

	public virtual void Start()
	{
	}

	public virtual void AddComponentByName(string componentName)
	{
	}

	public virtual void RemoveComponentByName(string componentName)
	{
	}

	public virtual void SetModelResourcePath(string path, int index = 1)
	{
		if (index != 1)
		{
			if (index == 2)
			{
				//if (this.modelResourcePath2 != path)
				//{
				//	this.modelResourcePath2 = path;
				//}
			}
		}
		//else if (this.modelResourcePath != path)
		//{
		//	this.modelResourcePath = path;
		//	this.LoadModel();
		//}
	}

	//public string GetModelResourcePath(int index = 1)
	//{
	//	return (index >= 2) ? this.modelResourcePath2 : this.modelResourcePath;
	//}

	//public bool HasBundle()
	//{
	//	string path = this.modelResourcePath.ToAssetBundlePath();
	//	return File.Exists(path);
	//}

	//public virtual bool NeedArea()
	//{
	//	bool flag = this is PalNPC;
	//	bool flag2 = this.HasBundle();
	//	return flag && flag2;
	//}

    /// <summary>
    /// 加载模型
    /// </summary>
	public virtual void LoadModel()
	{
        if (this.HasLoad)
        {
            return;
        }
        this.HasLoad = true;
        UnityEngine.Object temp = null;
        GameEntry.Data.RoleDataManager.CreatePlayerByJobId(10001, (Transform trans) =>
        {
            this.isPrefab = false;
            temp = trans.gameObject;
            this.CreateAndSetModel(temp);
        });
    }

    /// <summary>
    /// 创建设置模型
    /// </summary>
    /// <param name="temp"></param>
	protected virtual void CreateAndSetModel(UnityEngine.Object temp)
	{
        if (temp == null)
        {
            this.LoadModelEnd(this);
            return;
        }
        this.model = (temp as GameObject);

        //if (this.model.GetComponent<AutoDestroyMaterials>() == null)
        //{
        //    this.model.AddComponent<AutoDestroyMaterials>();
        //}

        this.model.transform.parent = base.transform;
        this.model.transform.localPosition = Vector3.zero;
        this.model.transform.localEulerAngles = Vector3.zero;
        this.model.tag = base.gameObject.tag;
        //this.model.layer = base.gameObject.layer;
        //if (this.isPrefab)
        //{           
        //    //this.CollectPrefabObjs(this.model);
        //}

        this.LoadModelEnd(this);
    }

	public virtual void LoadOver()
	{
		if (this.model != null)
		{
			UtilFun.SetActive(this.model, true);
		}
	}

    /// <summary>
    /// 加载模型结束
    /// </summary>
    /// <param name="obj"></param>
	public virtual void LoadModelEnd(UnityEngine.Object obj)
	{
        //if (this.dobjLayer == null)
        //{
        //	Transform parent = base.transform.parent;
        //	if (parent == null)
        //	{
        //		return;
        //	}
        //	this.dobjLayer = parent.GetComponent<DOBJLayer>();
        //	if (this.dobjLayer == null)
        //	{
        //		return;
        //	}
        //}

        if (this.model != null)
        {
            this.model.hideFlags = HideFlags.None;
            //if (EntityManager.Low)
            //{
            //	Renderer[] componentsInChildren = this.model.GetComponentsInChildren<Renderer>(true);
            //	for (int i = 0; i < componentsInChildren.Length; i++)
            //	{
            //		for (int j = 0; j < componentsInChildren[i].materials.Length; j++)
            //		{
            //			if (componentsInChildren[i].materials[j] != null && componentsInChildren[i].materials[j].shader.name.Contains("/2-"))
            //			{
            //				string name = componentsInChildren[i].materials[j].shader.name;
            //				int num = componentsInChildren[i].materials[j].shader.name.IndexOf("/2-");
            //				int startIndex = componentsInChildren[i].materials[j].shader.name.IndexOf("/", num + 1);
            //				string text = name.Substring(0, num) + name.Substring(startIndex);
            //				Debug.LogWarning(this.model.name + componentsInChildren[i].name + text);
            //				if (EntityManager.shadersScript != null && EntityManager.shadersScript.shaders.ContainsKey(text))
            //				{
            //					componentsInChildren[i].materials[j].shader = EntityManager.shadersScript.shaders[text];
            //				}
            //			}
            //		}
            //	}
            //}
        }
        this.LoadOver();
        //this.dobjLayer.JudgeLoadOver(this);
    }

	public virtual void OnDestroy()
	{
		if (this.DestroyEvent != null)
		{
			this.DestroyEvent(this);
		}
	}

	public virtual void SetAnother(int ID)
	{
		GameObject gameObject = GameObject.Find(ID.ToString());
		if (gameObject == null)
		{
			return;
		}
		this.SetAnother(gameObject);
	}

	public virtual void SetAnother(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		this.Another = go;
	}

	public virtual void ChangeModelForever(GameObject go, bool bActive = false)
	{
		if (go == null)
		{
			Debug.LogError("ChangeModelForever 失败");
			return;
		}
		go.GetComponent<Agent>().palNPC = base.GetComponent<PalNPC>();
		Transform transform = go.transform;
		transform.parent = base.transform;
		transform.position = this.model.transform.position;
		transform.rotation = this.model.transform.rotation;
		UnityEngine.Object.Destroy(this.model);
		this.model = go;
		UtilFun.SetActive(this.model, bActive);
		if (base.gameObject == PlayersManager.Player)
		{
			//this.model.GetComponent<Agent>().curCtrlMode = ControlMode.None;
		}
		else
		{
			//this.model.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
		}
	}

	public virtual void ChangeModel(GameObject go, bool bSyncItem = true)
	{
		this.SetAnother(go);
		if (this.anotherModel == null)
		{
			Debug.LogError("没有另外一个模型");
			return;
		}
		if (this.model2 != null && this.model2.GetComponent<Animator>() == null)
		{
			this.model2 = null;
		}
		if (this.model2 == null)
		{
			this.model2 = this.anotherModel;
		}
		if (this.model2 == null)
		{
			Debug.LogError("Error : ChangeModel model2==null");
			return;
		}
		PalNPC component = base.GetComponent<PalNPC>();
		Agent component2 = this.model2.GetComponent<Agent>();
		component2.palNPC = component;
		//component.perception = component2.perception;
		GameObject gameObject = this.model;
		this.model = this.model2;
		this.model2 = gameObject;
		this.model.transform.position = this.model2.transform.position;
		this.model.transform.rotation = this.model2.transform.rotation;
		if (!this.model.activeSelf && PlayersManager.Player == base.gameObject)
		{
			UtilFun.SetActive(this.model, true);
		}
		if (this.model2.activeSelf)
		{
			UtilFun.SetActive(this.model2, false);
		}
		if (base.gameObject == PlayersManager.Player)
		{
			//this.model.GetComponent<Agent>().curCtrlMode = ControlMode.None;
		}
		else
		{
			//this.model.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
		}
		//this.model2.GetComponent<Agent>().curCtrlMode = ControlMode.ControlByAgent;
		if (PlayersManager.Player == base.gameObject)
		{
			//PlayerCtrlManager.Reset();
		}
		if (bSyncItem)
		{
			PalNPC palNPC = this as PalNPC;
			if (palNPC != null)
			{
				Transform transform = this.model.transform;
				for (int i = 0; i < palNPC.Weapons.Count; i++)
				{
					GameObject gameObject2 = palNPC.Weapons[i];
					if (gameObject2 != null)
					{
					//	UtilFun.BindItemToProp(transform, gameObject2.transform, i, UtilFun.BindSlot.Default);
					}
				}
				GameObject ornament = palNPC.ornament;
				if (ornament != null)
				{
				//	UtilFun.BindOrnamentToProp(transform, ornament.transform, true);
				}
			}
		}
	}

	public void InitForLowPC()
	{
		base.enabled = false;
		this.CreateAreaTarget();
		this.LoadModelEnd(this);
	}

	private void CreateAreaTarget()
	{
		base.gameObject.SetActive(true);
		this.baseCollider = base.gameObject.AddComponent<SphereCollider>();
		this.baseRb = base.gameObject.AddComponent<Rigidbody>();
		this.baseRb.isKinematic = true;
		Vector3 b = new Vector3(0f, 0.01f, 0f);
		base.transform.position += b;
		base.transform.position -= b;
		base.Invoke("ClearTarget", 0.01f);
	}

	private void ClearTarget()
	{
		if (this.baseCollider != null)
		{
			UnityEngine.Object.Destroy(this.baseCollider);
			this.baseCollider = null;
		}
		if (this.baseRb != null)
		{
			UnityEngine.Object.Destroy(this.baseRb);
			this.baseRb = null;
		}
	}

	public virtual void Clear()
	{
		if (this.isPrefab)
		{
			this.ClearPrefab();
		}
		if (this.model != null)
		{
			UnityEngine.Object.Destroy(this.model);
			this.model = null;
		}
	}

	public virtual void CollectPrefabObjs(GameObject go)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Renderer renderer = componentsInChildren[i];
			Material[] materials = renderer.materials;
			for (int j = 0; j < materials.Length; j++)
			{
				Material material = materials[j];
				if (!(material == null))
				{
					//if (material.HasProperty(ShaderPropertyIDManager._MainTexID))
					//{
					//	Texture texture = material.GetTexture(ShaderPropertyIDManager._MainTexID);
					//	this.prefabObjs.Add(texture);
					//}
					//if (material.HasProperty(ShaderPropertyIDManager._BumpMapID))
					//{
					//	Texture texture2 = material.GetTexture(ShaderPropertyIDManager._BumpMapID);
					//	this.prefabObjs.Add(texture2);
					//}
					//if (material.HasProperty(ShaderPropertyIDManager._SpecularTexID))
					//{
					//	Texture texture3 = material.GetTexture(ShaderPropertyIDManager._SpecularTexID);
					//	this.prefabObjs.Add(texture3);
					//}
					//if (material.HasProperty(ShaderPropertyIDManager._DetailID))
					//{
					//	Texture texture4 = material.GetTexture(ShaderPropertyIDManager._DetailID);
					//	this.prefabObjs.Add(texture4);
					//}
					//if (material.HasProperty(ShaderPropertyIDManager._DetailBumpID))
					//{
					//	Texture texture5 = material.GetTexture(ShaderPropertyIDManager._DetailBumpID);
					//	this.prefabObjs.Add(texture5);
					//}
				}
			}
		}
		MeshFilter[] componentsInChildren2 = go.GetComponentsInChildren<MeshFilter>(true);
		for (int k = 0; k < componentsInChildren2.Length; k++)
		{
			MeshFilter meshFilter = componentsInChildren2[k];
			this.prefabObjs.Add(meshFilter.sharedMesh);
		}
		Animator[] componentsInChildren3 = go.GetComponentsInChildren<Animator>(true);
		for (int l = 0; l < componentsInChildren3.Length; l++)
		{
			Animator animator = componentsInChildren3[l];
			this.prefabObjs.Add(animator.runtimeAnimatorController);
		}
	}

	public virtual void ClearPrefab()
	{
		if (base.transform == null)
		{
			return;
		}
		string path = GameObjectPath.GetPath(base.transform);
		for (int i = 0; i < this.prefabObjs.Count; i++)
		{
			UnityEngine.Object @object = this.prefabObjs[i];
			if (@object != null)
			{
				Resources.UnloadAsset(@object);
			}
		}
		this.prefabObjs.Clear();
	}
}
