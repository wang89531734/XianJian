using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameObjSystem
{
    private const string m_PlayerPrefPath = "Player";

    private bool m_IsHide;

    private GameObject m_PlayerGameObj;

    private GameObject m_AmberGameObj;

    private Dictionary<int, S_GameObjData> m_AllGameObjData = new Dictionary<int, S_GameObjData>();

    private List<S_GameObjData> m_CurrentGameObjList = new List<S_GameObjData>();

    private List<Material> m_Materials = new List<Material>();

    private List<CombineInstance> m_CombineInstances = new List<CombineInstance>();

    private List<GameObject> m_PhysicClothList = new List<GameObject>();

    private List<GameObject> m_PlayerObjList = new List<GameObject>();

    private string[] PlayerShowName = new string[]
    {
        "p01-show",
        "p04-show",
        "p02-show",
        "p05-show",
        "p03-show",
        "p06-show",
        "p07-show"
    };

    public GameObject PlayerObj
    {
        get
        {
            return this.m_PlayerGameObj;
        }
        set
        {
            this.m_PlayerGameObj = value;
        }
    }

    public void Initialize()
    {
        this.m_AllGameObjData.Clear();
        //GameDataDB.NpcDB.ResetByOrder();
        //int dataSize = GameDataDB.NpcDB.GetDataSize();
        //for (int i = 0; i < dataSize; i++)
        //{
        //    S_NpcData dataByOrder = GameDataDB.NpcDB.GetDataByOrder();
        //    if (dataByOrder != null)
        //    {
        //        GameObjState gameObjState = new GameObjState();
        //        if (dataByOrder.Pick == 1)
        //        {
        //            gameObjState.Set(ENUM_GameObjFlag.Pick);
        //        }
        //        if (dataByOrder.Show == 0)
        //        {
        //            gameObjState.Set(ENUM_GameObjFlag.Hide);
        //        }
        //        if (dataByOrder.Disable == 1)
        //        {
        //            gameObjState.Set(ENUM_GameObjFlag.Disable);
        //        }
        //        if (dataByOrder.NoCollider == 1)
        //        {
        //            gameObjState.Set(ENUM_GameObjFlag.NoCollider);
        //        }
        //        if (dataByOrder.Ground == 1)
        //        {
        //            gameObjState.Set(ENUM_GameObjFlag.Ground);
        //        }
        //        this.AddGameObjData(dataByOrder.GetGUID(), new Vector3(0f, 0f, 0f), 1000f, gameObjState.Get(), null);
        ////    }
        //}
    }

    //	public void Clear()
    //	{
    //		this.ClearMapObjData();
    //		this.m_AllGameObjData.Clear();
    //	}

    public void AddGameObjData(S_GameObjData objData)
    {
        if (objData.Id == 0)
        {
            Debug.LogError("objData.Id == 0!!");
            return;
        }
        if (this.CheckGameObjData(objData.Id))
        {
            this.m_AllGameObjData[objData.Id] = objData;
            return;
        }
        this.m_AllGameObjData.Add(objData.Id, objData);
    }

    //	public void AddGameObjData(int id, Vector3 pos, float dir, ENUM_GameObjFlag flag, GameObject gameObj)
    //	{
    //		S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //		if (data == null)
    //		{
    //			Debug.LogError("AddGameObjData Error!! Can't Find Id_" + id);
    //			return;
    //		}
    //		GameObjState gameObjState = new GameObjState();
    //		gameObjState.Set(data.emState | flag);
    //		S_GameObjData objData = new S_GameObjData(id, data.MapID, pos, dir, data.Motion, gameObjState, gameObj);
    //		this.AddGameObjData(objData);
    //	}

    public bool CheckGameObjData(int id)
    {
        return this.m_AllGameObjData.ContainsKey(id);
    }

    //	public S_GameObjData GetObjData(int id)
    //	{
    //		if (this.CheckGameObjData(id))
    //		{
    //			return this.m_AllGameObjData[id];
    //		}
    //		return null;
    //	}

    //	public Dictionary<int, S_GameObjData> GetGameObjData()
    //	{
    //		return this.m_AllGameObjData;
    //	}

    //	public void Save(GameFileStream stream)
    //	{
    //		int count = this.m_AllGameObjData.Count;
    //		stream.WriteInt(count);
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			current.Save(stream);
    //		}
    //	}

    //	public void Load(GameFileStream stream)
    //	{
    //		int num = stream.ReadInt();
    //		for (int i = 0; i < num; i++)
    //		{
    //			S_GameObjData s_GameObjData = new S_GameObjData();
    //			s_GameObjData.Load(stream);
    //			this.m_AllGameObjData.Remove(s_GameObjData.Id);
    //			this.AddGameObjData(s_GameObjData);
    //		}
    //	}

    //	public void SetMapObjData(int mapid)
    //	{
    //		if (mapid == 0)
    //		{
    //			Debug.LogError("Map == 0!!");
    //			return;
    //		}
    //		this.ClearMapObjData();
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			if (current.MapId == mapid || current.OrgMapId == mapid)
    //			{
    //				this.m_CurrentGameObjList.Add(current);
    //			}
    //		}
    //	}

    //	public List<S_GameObjData> GetMapObjData()
    //	{
    //		return this.m_CurrentGameObjList;
    //	}

    //	public void ClearMapObjData()
    //	{
    //		this.m_CurrentGameObjList.Clear();
    //	}

    //	public void LoadMapObj(int mapid)
    //	{
    //		this.SetMapObjData(mapid);
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			this.LoadObj(current);
    //		}
    //	}

    //	public void ResetMineObjData(int mapid)
    //	{
    //	}

    //	public void ReLoadMapObjData()
    //	{
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //			if (data != null && current.RoleBase != null)
    //			{
    //				current.RoleBase.SetNpcData(data);
    //			}
    //		}
    //	}

    //	public void ReAttackMapObjScript()
    //	{
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //			if (data != null && !(current.RoleBase == null) && !(current.GameObj == null) && data.Talk != null)
    //			{
    //				Component component = current.GameObj.GetComponent(data.Talk);
    //				if (component != null)
    //				{
    //					UnityEngine.Object.DestroyObject(component);
    //				}
    //				current.GameObj.AddComponent(data.Talk);
    //			}
    //		}
    //	}

    //	public void UpdateAllMapObj()
    //	{
    //		GameObject x = GameObject.Find("Main Camera");
    //		if (x == null)
    //		{
    //			x = GameObject.FindWithTag("MainCamera");
    //		}
    //		if (x == null)
    //		{
    //			return;
    //		}
    //		if (this.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Hide) && !(current.GameObj == null))
    //			{
    //				S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //				if (data.emType == ENUM_NpcType.Role)
    //				{
    //					if (Vector3.Distance(current.GameObj.transform.position, this.PlayerObj.transform.position) > 30f)
    //					{
    //						if (!current.State.Test(ENUM_GameObjFlag.FadeOut))
    //						{
    //							current.RoleBase.FadeOut = true;
    //						}
    //					}
    //					else if (current.State.Test(ENUM_GameObjFlag.FadeOut))
    //					{
    //						current.RoleBase.FadeOut = false;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void LoadObj(S_GameObjData ObjData)
    //	{
    //		if (ObjData == null)
    //		{
    //			return;
    //		}
    //		string name = "NPC_" + ObjData.Id;
    //		GameObject gameObject = GameObject.Find(name);
    //		if (gameObject == null)
    //		{
    //			gameObject = GameNpcGenerator.GetGameNpc(name);
    //			if (gameObject)
    //			{
    //				gameObject.transform.position = ObjData.Pos;
    //				gameObject.name = name;
    //			}
    //		}
    //		if (gameObject != null)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(ObjData.Id);
    //			if (data != null)
    //			{
    //				GameObject gameObject2;
    //				if (ObjData.Id >= 101 && ObjData.Id <= 104)
    //				{
    //					gameObject2 = PlayerGenerator.CreatePlayerGameObject(data.PrefName);
    //					C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(ObjData.Id + 1 - 100);
    //					if (roleData != null)
    //					{
    //						ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.CosCloth);
    //						if (equipItemData != null)
    //						{
    //							this.SetMaterail(equipItemData.ID, Enum_AvaterType.Map, gameObject2);
    //						}
    //					}
    //				}
    //				else
    //				{
    //					gameObject2 = NpcGenerator.CreateNpcGameObject(ObjData.Id);
    //				}
    //				if (gameObject2 == null)
    //				{
    //					Debug.Log("Can't Load Npc PrefData_" + data.PrefName);
    //					return;
    //				}
    //				gameObject2.tag = "Npc";
    //				Transform transform = gameObject.transform.Find(data.PrefName);
    //				if (transform != null)
    //				{
    //					UnityEngine.Object.DestroyObject(transform.gameObject);
    //				}
    //				Vector3 position = gameObject.transform.position;
    //				Vector3 eulerAngles = gameObject.transform.eulerAngles;
    //				Vector3 localScale = gameObject.transform.localScale;
    //				gameObject.transform.position = new Vector3(0f, 0f, 0f);
    //				gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    //				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    //				gameObject2.transform.parent = gameObject.transform;
    //				if (data.emType == ENUM_NpcType.Role || data.emType == ENUM_NpcType.Quest || data.emType == ENUM_NpcType.Service)
    //				{
    //					if (!gameObject2.GetComponent<M_GameNpc>())
    //					{
    //						gameObject2.AddComponent<M_GameNpc>();
    //					}
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameNpc>();
    //					if (data.LookAtRange > 0f)
    //					{
    //						BendingSegment bendingSegment = new BendingSegment();
    //						bendingSegment.firstTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //						bendingSegment.lastTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //						if (bendingSegment.firstTransform != null)
    //						{
    //							M_HeadLookController m_HeadLookController = gameObject2.AddComponent<M_HeadLookController>();
    //							m_HeadLookController.segments = new BendingSegment[1];
    //							m_HeadLookController.segments[0] = bendingSegment;
    //							m_HeadLookController.nonAffectedJoints = new NonAffectedJoints[0];
    //						}
    //					}
    //				}
    //				if (data.emType == ENUM_NpcType.Treasure)
    //				{
    //					if (!gameObject2.GetComponent<M_GameTreasure>())
    //					{
    //						gameObject2.AddComponent<M_GameTreasure>();
    //					}
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameTreasure>();
    //				}
    //				if (data.emType == ENUM_NpcType.Mine)
    //				{
    //					if (!gameObject2.GetComponent<M_GameMine>())
    //					{
    //						gameObject2.AddComponent<M_GameMine>();
    //					}
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameMine>();
    //				}
    //				if (data.emType == ENUM_NpcType.Trap)
    //				{
    //					if (!gameObject2.GetComponent<M_GameTrap>())
    //					{
    //						gameObject2.AddComponent<M_GameTrap>();
    //					}
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameTrap>();
    //				}
    //				if (data.emType == ENUM_NpcType.Egg)
    //				{
    //					if (!gameObject2.GetComponent<M_GameEgg>())
    //					{
    //						gameObject2.AddComponent<M_GameEgg>();
    //					}
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameEgg>();
    //					if (Swd6Application.instance.m_SaveloadSystem.m_Loading)
    //					{
    //						M_GameEgg m_GameEgg = ObjData.RoleBase as M_GameEgg;
    //						m_GameEgg.m_NoReBirth = true;
    //					}
    //				}
    //				if (data.emType == ENUM_NpcType.NoEffect)
    //				{
    //					gameObject2.AddComponent<M_GameNoEffectNpc>();
    //				}
    //				gameObject.transform.position = position;
    //				gameObject.transform.eulerAngles = eulerAngles;
    //				gameObject.transform.localScale = localScale;
    //			}
    //		}
    //	}

    //	public void HideObjByType(int mapid, ENUM_NpcType type, bool hide)
    //	{
    //		if (mapid == 0)
    //		{
    //			Debug.LogError("Map == 0!!");
    //			return;
    //		}
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			if (current.MapId == mapid)
    //			{
    //				S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //				if (data != null && type == data.emType)
    //				{
    //					if (current.RoleBase != null)
    //					{
    //						current.RoleBase.HideRole = hide;
    //						current.RoleBase.NoCollider = hide;
    //					}
    //					else
    //					{
    //						current.State.Set(ENUM_GameObjFlag.Hide, hide);
    //						current.State.Set(ENUM_GameObjFlag.NoCollider, hide);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void HideAllObj(int mapid, bool hide)
    //	{
    //		if (mapid == 0)
    //		{
    //			Debug.LogError("Map == 0!!");
    //			return;
    //		}
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			if (current.MapId == mapid)
    //			{
    //				S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //				if (data != null && current.RoleBase != null)
    //				{
    //					current.RoleBase.HideRole = hide;
    //				}
    //			}
    //		}
    //	}

    //	public int GetNpcCountByActionType(ENUM_ActionHint type)
    //	{
    //		GameDataDB.NpcDB.ResetByOrder();
    //		int dataSize = GameDataDB.NpcDB.GetDataSize();
    //		int num = 0;
    //		for (int i = 0; i < dataSize; i++)
    //		{
    //			S_NpcData dataByOrder = GameDataDB.NpcDB.GetDataByOrder();
    //			if (dataByOrder != null && dataByOrder.emActionHint == type && (type != ENUM_ActionHint.Break || dataByOrder.emType == ENUM_NpcType.Trap))
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetCurrentMapTreasuerCount()
    //	{
    //		int num = 0;
    //		List<S_GameObjData> mapObjData = this.GetMapObjData();
    //		foreach (S_GameObjData current in mapObjData)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //			if (data != null && data.emType == ENUM_NpcType.Treasure)
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetCurrentMapOpenTreasuerCount()
    //	{
    //		int num = 0;
    //		List<S_GameObjData> mapObjData = this.GetMapObjData();
    //		foreach (S_GameObjData current in mapObjData)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //			if (data != null && current.State.Test(ENUM_GameObjFlag.Open))
    //			{
    //				num++;
    //			}
    //		}
    //		return num;
    //	}

    /// <summary>
    /// 创建玩家物体
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pos"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    public GameObject CreatePlayerGameObj(int id, Vector3 pos, float dir)
    {
        if (this.PlayerObj != null)
        {
            return this.PlayerObj;
        }
        string text = "Player" + id;
        string name = "Player" + id + "_Map";

        GameEntry.Pool.GameObjectSpawn(1, (Transform trans) =>
        {
            GameObject gameObject = trans.gameObject;
            if (gameObject != null)
            {
                GameEntry.Pool.GameObjectSpawn(10001, (Transform trans2) =>
                {
                    trans2.SetParent(gameObject.transform);
                    gameObject.transform.position = pos;
                    gameObject.transform.eulerAngles = new Vector3(0f, dir, 0f);
                    gameObject.name = "Player";
                    //gameObject.layer = 2;
                    this.PlayerObj = gameObject;
                    GameObjState state = new GameObjState();
                    S_GameObjData objData = new S_GameObjData(id, 0, pos, dir, 1, state, this.PlayerObj);
                    this.AddGameObjData(objData);
                    if (!this.PlayerObj.GetComponent<M_PlayerController>())
                    {
                        this.PlayerObj.AddComponent<M_PlayerController>();
                    }
                    if (!this.PlayerObj.GetComponent<M_PlayerMotor>())
                    {
                        this.PlayerObj.AddComponent<M_PlayerMotor>();
                    }
                    //BendingSegment bendingSegment = new BendingSegment();
                    //bendingSegment.firstTransform = TransformTool.SearchHierarchyForBone(this.PlayerObj.transform, "Face-controller");
                    //bendingSegment.lastTransform = TransformTool.SearchHierarchyForBone(this.PlayerObj.transform, "Face-controller");
                    //if (bendingSegment.firstTransform != null)
                    //{
                    //    M_HeadLookController m_HeadLookController = this.PlayerObj.AddComponent<M_HeadLookController>();
                    //    m_HeadLookController.segments = new BendingSegment[1];
                    //    m_HeadLookController.segments[0] = bendingSegment;
                    //    m_HeadLookController.nonAffectedJoints = new NonAffectedJoints[0];
                    //}
                    //if (!this.PlayerObj.GetComponent<AudioListener>())
                    //{
                    //    this.PlayerObj.AddComponent<AudioListener>();
                    //}
                    //C_RoleDataEx roleData = GameEntry.Instance.m_GameDataSystem.GetRoleData(id);
                    //ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.CosCloth);
                    //if (equipItemData != null)
                    //{
                    //    this.SetPlayerCosCloth(equipItemData.ID, Enum_AvaterType.Map);
                    //}
                });
            }
        });
      
        //RendererTool.ChangeSenceMaterialSetting(text, gameObject);
        //gameObject.transform.parent = characterRoot.transform;
        //Animator component = gameObject.GetComponent<Animator>();
        //if (component == null)
        //{
        //    Debug.Log("CreatePlayerGameObj::找不到Animator_" + id);
        //    return null;
        //}
        //component.enabled = false;
        //Avatar avatar = component.avatar;
        //UnityEngine.Object.Destroy(component);
        ////string name2 = "Player" + id + "_Map";
        ////component = characterRoot.GetComponent<Animator>();
        ////component.runtimeAnimatorController = ResourceManager.Instance.GetAnimatorController(name2);
        ////component.avatar = avatar;
        ////component.applyRootMotion = false;
        //SphereCollider component2 = gameObject.GetComponent<SphereCollider>();
        //if (component2 != null)
        //{
        //    UnityEngine.Object.Destroy(component2);
        //}
        //CapsuleCollider component3 = gameObject.GetComponent<CapsuleCollider>();
        //if (component3 != null)
        //{
        //    component3.enabled = true;
        //    component3.isTrigger = true;
        //}
        ////FaceFXControllerScript component4 = gameObject.GetComponent<FaceFXControllerScript>();
        ////if (component4 != null)
        ////{
        ////    UnityEngine.Object.Destroy(component4);
        ////}
        //Animation component5 = gameObject.GetComponent<Animation>();
        //if (component5 != null)
        //{
        //    UnityEngine.Object.Destroy(component5);
        //}
        ////this.m_ShroudInstance = gameObject.GetComponent<ShroudInstance>();
        ////if (this.m_ShroudInstance != null)
        ////{
        ////    this.m_ShroudInstance.ReduceBlendWeight_StoryEnable();
        ////}
        //CharacterController component6 = gameObject.GetComponent<CharacterController>();
        //UnityEngine.Object.Destroy(component6);
        //characterRoot.transform.position = pos;
        //characterRoot.transform.eulerAngles = new Vector3(0f, dir, 0f);
        //characterRoot.name = "Player";
        //component.applyRootMotion = true;
        ////TransformTool.SetLayerRecursively(characterRoot.transform, 2);
        //gameObject.tag = "Player";
        //this.PlayerObj = characterRoot;
        //GameObjState state = new GameObjState();
        //S_GameObjData objData = new S_GameObjData(id, 0, pos, dir, 1, state, this.PlayerObj);
        //this.AddGameObjData(objData);
        ////if (!this.PlayerObj.GetComponent<AudioListener>())
        ////{
        ////    this.PlayerObj.AddComponent<AudioListener>();
        ////}
        //this.m_PhysicClothList.Clear();
        //this.m_PlayerObjList.Clear();

        this.m_IsHide = false;
        return this.PlayerObj;
    }

    public GameObject GetPlayerCosCloth(int roleId)
    {
        if (roleId == 0)
        {
            return null;
        }
        C_RoleDataEx roleData = GameEntry.Instance.m_GameDataSystem.GetRoleData(roleId);
        if (roleData == null)
        {
            return null;
        }
        ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.CosCloth);
        if (equipItemData == null)
        {
            Debug.Log("执行");
            return null;
        }
        if (equipItemData.ID == 0)
        {
            Debug.Log("执行");
            return null;
        }
        S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
        if (data == null)
        {
            Debug.Log(data.Equip.Materail[0].MeshName);
            return null;
        }
        if (data.Equip.Materail.Count == 0)
        {
            Debug.Log(data.Equip.Materail[0].MeshName);
            return null;
        }
        return ResourcesManager.Instance.GetCharacterModel(data.Equip.Materail[0].MeshName);
    }

    //	public GameObject CreatePlayerShowObj(int id, int itemId)
    //	{
    //		string name = this.PlayerShowName[id - 1];
    //		GameObject gameObject = PlayerGenerator.CreatePlayerGameObject(name);
    //		if (gameObject == null)
    //		{
    //			return null;
    //		}
    //		M_GameRoleMotion m_GameRoleMotion = gameObject.AddComponent<M_GameRoleMotion>();
    //		if (m_GameRoleMotion != null)
    //		{
    //			m_GameRoleMotion.Init(id, 1);
    //			if (id != 7)
    //			{
    //				if (id == 3 || id == 5)
    //				{
    //					m_GameRoleMotion.PlayExpression_Up(901);
    //					m_GameRoleMotion.PlayExpression_Down(913);
    //				}
    //				else if (id == 1 || id == 2)
    //				{
    //					m_GameRoleMotion.PlayExpression_Up(901);
    //					m_GameRoleMotion.PlayExpression_Down(904);
    //				}
    //				else
    //				{
    //					m_GameRoleMotion.PlayExpression_Up(907);
    //					m_GameRoleMotion.PlayExpression_Down(913);
    //				}
    //			}
    //			else
    //			{
    //				gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    //			}
    //		}
    //		return gameObject;
    //	}

    //	public void HideBreakWeapon()
    //	{
    //		Transform transform = this.m_PlayerGameObj.transform.Find("p05-01-cloth-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-meta-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //		transform = this.m_PlayerGameObj.transform.Find("p05-01-weap-map-f");
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(false);
    //		}
    //	}

    //	public void RemovePlayerGameObj()
    //	{
    //		this.m_Materials.Clear();
    //		this.m_CombineInstances.Clear();
    //		this.m_IsHide = false;
    //		if (this.PlayerObj)
    //		{
    //			UnityEngine.Object.DestroyImmediate(this.PlayerObj, false);
    //			this.PlayerObj = null;
    //		}
    //		GC.Collect();
    //		Resources.UnloadUnusedAssets();
    //	}

    //	public bool IsHidePlayer()
    //	{
    //		return this.m_IsHide;
    //	}

    //	public void HidePlayer(bool bHide)
    //	{
    //		if (this.PlayerObj == null)
    //		{
    //			return;
    //		}
    //		this.m_IsHide = bHide;
    //		if (Swd6Application.instance.m_ExploreSystem.PlayerController)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.HideRole = this.m_IsHide;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.NoCollider = this.m_IsHide;
    //		}
    //		if (this.m_AmberGameObj != null)
    //		{
    //			this.m_AmberGameObj.GetComponent<M_AmberController>().SetRender(!bHide);
    //		}
    //	}

    //	public void SetPlayerCosCloth(int ID, Enum_AvaterType type)
    //	{
    //		this.PlayerObj = this.SetMaterail(ID, type, this.PlayerObj);
    //	}

    //	public GameObject SetMaterail(int ID, Enum_AvaterType type, GameObject gameObject)
    //	{
    //		S_Item data = GameDataDB.ItemDB.GetData(ID);
    //		if (data == null)
    //		{
    //			return gameObject;
    //		}
    //		if (data.Equip.MeshAvatar == 1)
    //		{
    //			gameObject = this.GenerateAvatar(gameObject, data.Equip.Materail[(int)type].MeshName);
    //		}
    //		else
    //		{
    //			for (int i = 0; i < data.Equip.Materail.Count; i++)
    //			{
    //				if (data.Equip.Materail[i].MeshName != null)
    //				{
    //					Transform transform = TransformTool.SearchHierarchyForBone(gameObject.transform, data.Equip.Materail[i].MeshName);
    //					if (transform)
    //					{
    //						transform.renderer.material = null;
    //						transform.renderer.material = MaterialGenerator.CreateMaterial(data.Equip.Materail[i].MaterailName);
    //					}
    //				}
    //			}
    //		}
    //		return gameObject;
    //	}

    //	public void UseGameObjLightProbes(GameObject gameObject, bool enable)
    //	{
    //		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		if (componentsInChildren != null)
    //		{
    //			SkinnedMeshRenderer[] array = componentsInChildren;
    //			for (int i = 0; i < array.Length; i++)
    //			{
    //				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
    //				if (skinnedMeshRenderer)
    //				{
    //					skinnedMeshRenderer.useLightProbes = enable;
    //				}
    //			}
    //		}
    //		MeshRenderer[] componentsInChildren2 = gameObject.GetComponentsInChildren<MeshRenderer>();
    //		if (componentsInChildren2 != null)
    //		{
    //			MeshRenderer[] array2 = componentsInChildren2;
    //			for (int j = 0; j < array2.Length; j++)
    //			{
    //				MeshRenderer meshRenderer = array2[j];
    //				if (meshRenderer)
    //				{
    //					meshRenderer.useLightProbes = enable;
    //				}
    //			}
    //		}
    //	}

    //	public GameObject CreateAmberGameObj()
    //	{
    //		if (Swd6Application.instance.m_ChapID == 101)
    //		{
    //			return null;
    //		}
    //		if (this.m_AmberGameObj != null)
    //		{
    //			return this.m_AmberGameObj;
    //		}
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(1902))
    //		{
    //			this.m_AmberGameObj = PlayerGenerator.CreatePlayerGameObject("Amber1");
    //		}
    //		else
    //		{
    //			this.m_AmberGameObj = PlayerGenerator.CreatePlayerGameObject("Amber");
    //		}
    //		if (this.m_AmberGameObj != null)
    //		{
    //			this.m_AmberGameObj.AddComponent<M_AmberController>();
    //		}
    //		return this.m_AmberGameObj;
    //	}

    //	public void RemoveAmberGameObj()
    //	{
    //		if (this.m_AmberGameObj)
    //		{
    //			UnityEngine.Object.Destroy(this.m_AmberGameObj);
    //			this.m_AmberGameObj = null;
    //		}
    //	}

    //	public GameObject GenerateAvatar(GameObject root, string newAvaterName)
    //	{
    //		GameObject gameObject = PlayerGenerator.CreatePlayerGameObject(newAvaterName);
    //		if (gameObject == null)
    //		{
    //			Debug.Log("讀取Avater物件錯誤!!");
    //			return null;
    //		}
    //		GameObject gameObject2 = this.Generate_CombineSkinMesh1(root, gameObject);
    //		if (gameObject2 == null)
    //		{
    //			return null;
    //		}
    //		return gameObject2;
    //	}

    //	private GameObject Generate_CombineSkinMesh(GameObject root, GameObject newAvatarObj)
    //	{
    //		if (root == null)
    //		{
    //			return null;
    //		}
    //		List<Material> list = new List<Material>();
    //		List<Transform> list2 = new List<Transform>();
    //		List<CombineInstance> list3 = new List<CombineInstance>();
    //		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
    //		SkinnedMeshRenderer[] componentsInChildren2 = newAvatarObj.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		for (int i = 0; i < componentsInChildren2.Length; i++)
    //		{
    //			SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren2[i];
    //			if (skinnedMeshRenderer.materials == null || skinnedMeshRenderer.materials.Length == 0)
    //			{
    //				Debug.LogWarning("角色部位[" + skinnedMeshRenderer.name + "] 沒有包含材質球");
    //			}
    //			else if (skinnedMeshRenderer.sharedMesh == null || skinnedMeshRenderer.sharedMesh.subMeshCount == 0)
    //			{
    //				Debug.LogWarning("角色部位[" + skinnedMeshRenderer.name + "] 沒有包含材Mesh資訊");
    //			}
    //			else
    //			{
    //				list.AddRange(skinnedMeshRenderer.materials);
    //				for (int j = 0; j < skinnedMeshRenderer.sharedMesh.subMeshCount; j++)
    //				{
    //					list3.Add(new CombineInstance
    //					{
    //						mesh = skinnedMeshRenderer.sharedMesh,
    //						subMeshIndex = j
    //					});
    //				}
    //				List<string> list4 = new List<string>();
    //				Transform[] bones = skinnedMeshRenderer.bones;
    //				for (int k = 0; k < bones.Length; k++)
    //				{
    //					Transform transform = bones[k];
    //					list4.Add(transform.name);
    //				}
    //				MStringHolder mStringHolder = ScriptableObject.CreateInstance<MStringHolder>();
    //				mStringHolder.content = list4.ToArray();
    //				string[] content = mStringHolder.content;
    //				int num = content.Length;
    //				int num2 = 0;
    //				for (int l = 0; l < num; l++)
    //				{
    //					string b = content[l];
    //					Transform[] array = componentsInChildren;
    //					for (int m = 0; m < array.Length; m++)
    //					{
    //						Transform transform2 = array[m];
    //						if (!(transform2.name != b))
    //						{
    //							list2.Add(transform2);
    //							num2++;
    //							break;
    //						}
    //					}
    //				}
    //				if (num2 != num)
    //				{
    //					return null;
    //				}
    //			}
    //		}
    //		SkinnedMeshRenderer component = root.GetComponent<SkinnedMeshRenderer>();
    //		if (component == null)
    //		{
    //			Debug.LogWarning("角色主體沒有SkinnedMeshRenderer");
    //			return root;
    //		}
    //		component.sharedMesh = new Mesh();
    //		component.sharedMesh.CombineMeshes(list3.ToArray(), false, false);
    //		component.bones = list2.ToArray();
    //		component.materials = list.ToArray();
    //		component.useLightProbes = true;
    //		UnityEngine.Object.DestroyImmediate(newAvatarObj, false);
    //		newAvatarObj = null;
    //		list.Clear();
    //		list3.Clear();
    //		return root;
    //	}

    //	private GameObject Generate_CombineSkinMesh1(GameObject root, GameObject newAvatarObj)
    //	{
    //		if (root == null)
    //		{
    //			return null;
    //		}
    //		List<CombineInstance> list = new List<CombineInstance>();
    //		List<Material> list2 = new List<Material>();
    //		List<Transform> list3 = new List<Transform>();
    //		Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
    //		SkinnedMeshRenderer skinnedMeshRenderer = null;
    //		SkinnedMeshRenderer[] componentsInChildren2 = root.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		for (int i = 0; i < componentsInChildren2.Length; i++)
    //		{
    //			SkinnedMeshRenderer skinnedMeshRenderer2 = componentsInChildren2[i];
    //			bool flag = false;
    //			SkinnedMeshRenderer[] componentsInChildren3 = newAvatarObj.GetComponentsInChildren<SkinnedMeshRenderer>();
    //			for (int j = 0; j < componentsInChildren3.Length; j++)
    //			{
    //				SkinnedMeshRenderer skinnedMeshRenderer3 = componentsInChildren3[j];
    //				if (skinnedMeshRenderer3.gameObject.name == skinnedMeshRenderer2.gameObject.name)
    //				{
    //					flag = true;
    //					break;
    //				}
    //			}
    //			if (!flag)
    //			{
    //				UnityEngine.Object.DestroyImmediate(skinnedMeshRenderer2.gameObject);
    //			}
    //		}
    //		this.m_Materials.Clear();
    //		SkinnedMeshRenderer[] componentsInChildren4 = newAvatarObj.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		int k = 0;
    //		while (k < componentsInChildren4.Length)
    //		{
    //			SkinnedMeshRenderer skinnedMeshRenderer4 = componentsInChildren4[k];
    //			bool flag = false;
    //			SkinnedMeshRenderer[] componentsInChildren5 = root.GetComponentsInChildren<SkinnedMeshRenderer>();
    //			for (int l = 0; l < componentsInChildren5.Length; l++)
    //			{
    //				SkinnedMeshRenderer skinnedMeshRenderer5 = componentsInChildren5[l];
    //				if (skinnedMeshRenderer4.gameObject.name == skinnedMeshRenderer5.gameObject.name)
    //				{
    //					flag = true;
    //					skinnedMeshRenderer = skinnedMeshRenderer5;
    //					break;
    //				}
    //			}
    //			list.Clear();
    //			list3.Clear();
    //			if (flag)
    //			{
    //				goto IL_17C;
    //			}
    //			skinnedMeshRenderer = new GameObject(skinnedMeshRenderer4.gameObject.name)
    //			{
    //				transform = 
    //				{
    //					parent = root.transform
    //				}
    //			}.AddComponent<SkinnedMeshRenderer>();
    //			if (!(skinnedMeshRenderer4.rootBone == null))
    //			{
    //				skinnedMeshRenderer.rootBone = TransformTool.SearchHierarchyForBone(root.transform, skinnedMeshRenderer4.rootBone.name);
    //				goto IL_17C;
    //			}
    //			IL_39E:
    //			k++;
    //			continue;
    //			IL_17C:
    //			list2.AddRange(skinnedMeshRenderer4.materials);
    //			this.m_Materials.AddRange(skinnedMeshRenderer4.materials);
    //			if (skinnedMeshRenderer4.sharedMesh == null || skinnedMeshRenderer4.sharedMesh.subMeshCount == 0)
    //			{
    //				Debug.LogWarning("角色部位[" + skinnedMeshRenderer4.name + "] 沒有包含材Mesh資訊");
    //				goto IL_39E;
    //			}
    //			for (int m = 0; m < skinnedMeshRenderer4.sharedMesh.subMeshCount; m++)
    //			{
    //				CombineInstance item = default(CombineInstance);
    //				item.mesh = skinnedMeshRenderer4.sharedMesh;
    //				item.subMeshIndex = m;
    //				list.Add(item);
    //				this.m_CombineInstances.Add(item);
    //			}
    //			List<string> list4 = new List<string>();
    //			Transform[] bones = skinnedMeshRenderer4.bones;
    //			for (int n = 0; n < bones.Length; n++)
    //			{
    //				Transform transform = bones[n];
    //				list4.Add(transform.name);
    //			}
    //			MStringHolder mStringHolder = ScriptableObject.CreateInstance<MStringHolder>();
    //			mStringHolder.content = list4.ToArray();
    //			string[] content = mStringHolder.content;
    //			int num = content.Length;
    //			int num2 = 0;
    //			for (int num3 = 0; num3 < num; num3++)
    //			{
    //				string b = content[num3];
    //				Transform[] array = componentsInChildren;
    //				for (int num4 = 0; num4 < array.Length; num4++)
    //				{
    //					Transform transform2 = array[num4];
    //					if (!(transform2.name != b))
    //					{
    //						list3.Add(transform2);
    //						num2++;
    //						break;
    //					}
    //				}
    //			}
    //			if (num2 != num)
    //			{
    //				Debug.LogWarning(string.Concat(new object[]
    //				{
    //					"[",
    //					skinnedMeshRenderer4.name,
    //					"] 的骨架無法完全對應的Root主體骨架上 BoneSize[",
    //					num,
    //					"] 對應到[",
    //					num2,
    //					"]"
    //				}));
    //				return null;
    //			}
    //			skinnedMeshRenderer.sharedMesh = null;
    //			skinnedMeshRenderer.sharedMesh = new Mesh();
    //			skinnedMeshRenderer.sharedMesh.CombineMeshes(list.ToArray(), false, false);
    //			skinnedMeshRenderer.bones = list3.ToArray();
    //			skinnedMeshRenderer.materials = list2.ToArray();
    //			skinnedMeshRenderer.useLightProbes = true;
    //			skinnedMeshRenderer.updateWhenOffscreen = skinnedMeshRenderer4.updateWhenOffscreen;
    //			list2.Clear();
    //			goto IL_39E;
    //		}
    //		UnityEngine.Object.DestroyImmediate(newAvatarObj, false);
    //		newAvatarObj = null;
    //		return root;
    //	}
}
