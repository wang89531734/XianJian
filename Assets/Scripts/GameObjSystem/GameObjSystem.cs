//using Pathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameObjSystem
{
    private struct Player3EffectParam
    {
        public float m_DetailBumpTiling;

        public float m_DissolveTiling;

        public float m_BlendHeight;

        public float m_DissolveRange;

        public Player3EffectParam(float detailBumpTiling, float dissolveTiling, float blendHeight, float dissolveRange)
        {
            this.m_DetailBumpTiling = detailBumpTiling;
            this.m_DissolveTiling = dissolveTiling;
            this.m_BlendHeight = blendHeight;
            this.m_DissolveRange = dissolveRange;
        }
    }

    private const string m_PlayerPrefPath = "Player";

    private bool m_IsHide;

    private int m_ChangeEffect;

    private float m_EffectValue;

    private GameObject m_PlayerGameObj;

    private GameObject m_AmberPigGameObj;

    //private ShroudInstance m_ShroudInstance;

    private Dictionary<int, S_GameObjData> m_AllGameObjData = new Dictionary<int, S_GameObjData>();

    private List<S_GameObjData> m_CurrentGameObjList = new List<S_GameObjData>();

    private List<GameObject> m_PhysicClothList = new List<GameObject>();

    private List<GameObject> m_PlayerObjList = new List<GameObject>();

    private List<string> m_Player3OrgMaterialList = new List<string>();

    private List<Material> m_Player3MaterialList = new List<Material>();

    //	private string[] Player3MeshName = new string[]
    //	{
    //		"p031-eye",
    //		"p031-eyelash",
    //		"p031-hair_A",
    //		"p031-hair_B",
    //		"p031-hair_C",
    //		"p031-ring",
    //		"p031-skin",
    //		"p031-swing_A",
    //		"p031-swing_B",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh"
    //	};

    //	private string[] Player3OrgMaterialName = new string[]
    //	{
    //		"P031-eye",
    //		"P031-eyelash",
    //		"P031-hair_A",
    //		"P031-hair_B",
    //		"P031-hair_C",
    //		"P031-ring",
    //		"P031-skin",
    //		"P031-cloth_A",
    //		"P031-cloth_B",
    //		"P031-hair_A",
    //		"P031-hair_B",
    //		"P031-hair_C",
    //		"P031-cloth_A",
    //		"P031-cloth_B"
    //	};

    //	private string[] Player3MaterialName = new string[]
    //	{
    //		"P031-S_skinB",
    //		"P031-S_skinB",
    //		"P031-S_hairB",
    //		"P031-S_hairB",
    //		"P031-S_hairA",
    //		"P031-S_clothB",
    //		"P031-S_skinA",
    //		"P031-S_clothB",
    //		"P031-S_clothA",
    //		"P031-S_hairB",
    //		"P031-S_hairB",
    //		"P031-S_hairA",
    //		"P031-S_clothB",
    //		"P031-S_clothA"
    //	};

    //	private GameObjSystem.Player3EffectParam[] Player3EffectParams = new GameObjSystem.Player3EffectParam[]
    //	{
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.15f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.15f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 5f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3.2f, 7f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 10f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3.2f, 7f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 6.38f, 0.3f, 0.1f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 5f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3.2f, 7f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 6.38f, 0.3f, 0.1f)
    //	};

    //	private string[] Player3MeshName2 = new string[]
    //	{
    //		"p032-eye",
    //		"p032-eyelash",
    //		"p032-hair_A",
    //		"p032-hair_B",
    //		"p032-hair_C",
    //		"p032-cloth",
    //		"p032-skin",
    //		"p032-swing_A",
    //		"p032-swing_B",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh",
    //		"Shroud Mesh"
    //	};

    //	private string[] Player3OrgMaterialName2 = new string[]
    //	{
    //		"P031-eye",
    //		"P031-eyelash",
    //		"P031-hair_A",
    //		"P031-hair_B",
    //		"P031-hair_C",
    //		"p032_cloth",
    //		"P032-skin",
    //		"p032_cloth",
    //		"p032_cloth",
    //		"P031-hair_A",
    //		"P031-hair_B",
    //		"P031-hair_C",
    //		"p032_cloth",
    //		"p032_cloth"
    //	};

    //	private string[] Player3MaterialName2 = new string[]
    //	{
    //		"P032-S_skin",
    //		"P032-S_skin",
    //		"P031-S_hairB",
    //		"P031-S_hairB",
    //		"P031-S_hairA",
    //		"P032-S_cloth",
    //		"P032-S_skin",
    //		"P032-S_cloth",
    //		"P032-S_cloth",
    //		"P031-S_hairB",
    //		"P031-S_hairB",
    //		"P031-S_hairA",
    //		"P032-S_cloth",
    //		"P032-S_cloth"
    //	};

    //	private GameObjSystem.Player3EffectParam[] Player3EffectParams2 = new GameObjSystem.Player3EffectParam[]
    //	{
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 5f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 1f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(3f, 5f, 0.3f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f),
    //		new GameObjSystem.Player3EffectParam(1f, 1f, 0.08f, 0.05f)
    //	};

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
        //this.m_AllGameObjData.Clear();
        GameDataDB.NpcDB.ResetByOrder();
        int dataSize = GameDataDB.NpcDB.GetDataSize();
        for (int i = 0; i < dataSize; i++)
        {
            S_NpcData dataByOrder = GameDataDB.NpcDB.GetDataByOrder();
            if (dataByOrder != null)
            {
                //GameObjState gameObjState = new GameObjState();
                //if (dataByOrder.Pick == 1)
                //{
                //    gameObjState.Set(ENUM_GameObjFlag.Pick);
                //}
                //if (dataByOrder.Show == 0)
                //{
                //    gameObjState.Set(ENUM_GameObjFlag.Hide);
                //}
                //if (dataByOrder.Disable == 1)
                //{
                //    gameObjState.Set(ENUM_GameObjFlag.Disable);
                //}
                //if (dataByOrder.NoCollider == 1)
                //{
                //    gameObjState.Set(ENUM_GameObjFlag.NoCollider);
                //}
                //if (dataByOrder.Ground == 1)
                //{
                //    gameObjState.Set(ENUM_GameObjFlag.Ground);
                //}
                //this.AddGameObjData(dataByOrder.GetGUID(), new Vector3(0f, 0f, 0f), 1000f, gameObjState.Get(), null, false);
            }
        }
    }

    public void Clear()
    {
        //this.ClearMapObjData();
        //this.m_AllGameObjData.Clear();
    }

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
        }
        else
        {
            this.m_AllGameObjData.Add(objData.Id, objData);
        }
    }

    public void AddGameObjData(int id, Vector3 pos, float dir, ENUM_GameObjFlag flag, GameObject gameObj, bool setData)
    {
        S_NpcData data = GameDataDB.NpcDB.GetData(id);
        if (data == null)
        {
            Debug.LogError("AddGameObjData Error!! Can't Find Id_" + id);
            return;
        }
        GameObjState gameObjState = new GameObjState();
        gameObjState.Set(data.emState | flag);
        this.AddGameObjData(new S_GameObjData(id, data.MapID, pos, dir, data.Motion, gameObjState, gameObj)
        {
            SetDefaultData = setData
        });
    }

    public bool CheckGameObjData(int id)
    {
        return this.m_AllGameObjData.ContainsKey(id);
    }

    public S_GameObjData GetObjData(int id)
    {
        if (this.CheckGameObjData(id))
        {
            return this.m_AllGameObjData[id];
        }
        return null;
    }

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
    //			if (data != null)
    //			{
    //				if (!(current.RoleBase == null) && !(current.GameObj == null))
    //				{
    //					if (data.Talk != null)
    //					{
    //						Component component = current.GameObj.GetComponent(data.Talk);
    //						if (component != null)
    //						{
    //							UnityEngine.Object.DestroyObject(component);
    //						}
    //						current.GameObj.AddComponent(data.Talk);
    //					}
    //				}
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
    //			if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Hide))
    //			{
    //				if (!(current.GameObj == null))
    //				{
    //					S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //					if (data.emType == ENUM_NpcType.Role)
    //					{
    //						if (Vector3.Distance(current.GameObj.transform.position, this.PlayerObj.transform.position) > 30f)
    //						{
    //							if (!current.State.Test(ENUM_GameObjFlag.FadeOut))
    //							{
    //								current.RoleBase.FadeOut = true;
    //							}
    //						}
    //						else if (current.State.Test(ENUM_GameObjFlag.FadeOut))
    //						{
    //							current.RoleBase.FadeOut = false;
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void PauseNpcObj()
    //	{
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Hide))
    //			{
    //				if (!(current.GameObj == null))
    //				{
    //					S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //					if (data.emType == ENUM_NpcType.Role)
    //					{
    //						M_GameNpc component = current.GameObj.GetComponent<M_GameNpc>();
    //						if (component != null)
    //						{
    //							component.SuspendMove();
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void ResumeNpcObj()
    //	{
    //		foreach (S_GameObjData current in this.m_CurrentGameObjList)
    //		{
    //			if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Hide) && !current.State.Test(ENUM_GameObjFlag.Hide2))
    //			{
    //				if (!(current.GameObj == null))
    //				{
    //					S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //					if (data.emType == ENUM_NpcType.Role)
    //					{
    //						M_GameNpc component = current.GameObj.GetComponent<M_GameNpc>();
    //						if (component != null)
    //						{
    //							component.ResumeMove();
    //						}
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
    //		if (ObjData.GameObj || ObjData.RoleBase)
    //		{
    //			return;
    //		}
    //		string name = "NPC_" + ObjData.Id;
    //		GameObject gameObject = GameObject.Find(name);
    //		if (gameObject == null)
    //		{
    //			gameObject = ResourceManager.Instance.GetGameNpc(name);
    //			if (gameObject != null)
    //			{
    //				gameObject.name = name;
    //			}
    //			else
    //			{
    //				gameObject = new GameObject(name);
    //				if (gameObject != null)
    //				{
    //					gameObject.transform.position = ObjData.Pos;
    //					gameObject.name = name;
    //				}
    //			}
    //		}
    //		if (gameObject != null)
    //		{
    //			S_NpcData data = GameDataDB.NpcDB.GetData(ObjData.Id);
    //			if (data != null)
    //			{
    //				GameObject gameObject2 = null;
    //				if (data.PrefName != null)
    //				{
    //					if (ObjData.Id >= 151 && ObjData.Id <= 153)
    //					{
    //						gameObject2 = this.GetPlayerCosCloth(ObjData.Id + 1 - 150);
    //						if (gameObject2 == null)
    //						{
    //							gameObject2 = ResourceManager.Instance.GetCharacterModel(data.PrefName);
    //						}
    //					}
    //					else
    //					{
    //						gameObject2 = ResourceManager.Instance.GetCharacterModel(data.PrefName);
    //					}
    //					if (gameObject2 != null)
    //					{
    //						for (int i = 0; i < data.DisableRenderer.Count; i++)
    //						{
    //							RendererTool.EnableRenderer(gameObject2, data.DisableRenderer[i], false);
    //						}
    //					}
    //				}
    //				else
    //				{
    //					Debug.LogWarning(data.GUID + "_Npc PrefName是空的!!");
    //				}
    //				if (gameObject2 == null)
    //				{
    //					Debug.LogWarning("Can't Load Npc PrefData_" + data.PrefName);
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
    //						gameObject2.AddComponent<M_HeadLookController>();
    //					}
    //					gameObject2.AddComponent<Seeker>();
    //					gameObject2.AddComponent<FunnelModifier>();
    //					gameObject2.AddComponent<M_AStarAI>();
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
    //				if (data.emType == ENUM_NpcType.Arrow)
    //				{
    //					gameObject2.AddComponent<M_GameNoEffectNpc>();
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameNoEffectNpc>();
    //				}
    //				if (data.emType == ENUM_NpcType.Map)
    //				{
    //					gameObject2.AddComponent<M_GameNoEffectNpc>();
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameNoEffectNpc>();
    //				}
    //				if (data.emType == ENUM_NpcType.NoEffect)
    //				{
    //					gameObject2.AddComponent<M_GameNoEffectNpc>();
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameNoEffectNpc>();
    //				}
    //				if (data.emType == ENUM_NpcType.Mob)
    //				{
    //					gameObject2.AddComponent<M_GameMapMob>();
    //					ObjData.RoleBase = gameObject2.GetComponent<M_GameMapMob>();
    //					gameObject2.tag = "Mob";
    //				}
    //				if (data.AnimatorController != null)
    //				{
    //					Animator component = gameObject2.GetComponent<Animator>();
    //					if (component != null)
    //					{
    //						component.runtimeAnimatorController = ResourceManager.Instance.GetAnimatorController(data.AnimatorController);
    //					}
    //				}
    //				FaceFXControllerScript component2 = gameObject2.GetComponent<FaceFXControllerScript>();
    //				if (component2 != null)
    //				{
    //					UnityEngine.Object.Destroy(component2);
    //				}
    //				Animation component3 = gameObject2.GetComponent<Animation>();
    //				if (component3 != null)
    //				{
    //					UnityEngine.Object.Destroy(component3);
    //				}
    //				RendererTool.SetNPCMaterail(ObjData.Id, gameObject2);
    //				RendererTool.ChangeSenceMaterialSetting(data.PrefName, gameObject2);
    //				gameObject.transform.position = position;
    //				gameObject.transform.eulerAngles = eulerAngles;
    //				gameObject.transform.localScale = localScale;
    //				if (data.Ground == 1)
    //				{
    //					int layer = gameObject2.transform.gameObject.layer;
    //					TransformTool.SetLayerRecursively(gameObject2.transform, 2);
    //					GameMath.CastObjectOnTerrain(gameObject2, 0.5f);
    //					TransformTool.SetLayerRecursively(gameObject2.transform, layer);
    //				}
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
    //					if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Invalid))
    //					{
    //						if (current.RoleBase != null)
    //						{
    //							current.RoleBase.HideRole = hide;
    //							current.RoleBase.NoCollider = hide;
    //						}
    //						else
    //						{
    //							current.State.Set(ENUM_GameObjFlag.Hide, hide);
    //							current.State.Set(ENUM_GameObjFlag.NoCollider, hide);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void HideObjByType2(int mapid, ENUM_NpcType type, bool hide)
    //	{
    //		if (mapid == 0)
    //		{
    //			Debug.LogError("Map == 0!!");
    //			return;
    //		}
    //		if (type == ENUM_NpcType.Role && !hide && Swd6Application.instance.m_GameDataSystem.GetFlag(54))
    //		{
    //			return;
    //		}
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			if (current.MapId == mapid)
    //			{
    //				S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //				if (data != null && type == data.emType)
    //				{
    //					if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Invalid))
    //					{
    //						if (current.RoleBase != null)
    //						{
    //							if (!current.RoleBase.HideRole)
    //							{
    //								if (!hide || !current.RoleBase.HideRole2)
    //								{
    //									current.RoleBase.HideRole2 = hide;
    //									current.RoleBase.NoCollider = hide;
    //									if (current.GameObj != null)
    //									{
    //										M_GameNpc component = current.GameObj.GetComponent<M_GameNpc>();
    //										if (component != null)
    //										{
    //											if (hide)
    //											{
    //												component.SuspendMove();
    //											}
    //											else
    //											{
    //												component.ResumeMove();
    //											}
    //										}
    //									}
    //								}
    //							}
    //						}
    //						else if (!current.State.Test(ENUM_GameObjFlag.Hide))
    //						{
    //							current.State.Set(ENUM_GameObjFlag.Hide2, hide);
    //							current.State.Set(ENUM_GameObjFlag.NoCollider, hide);
    //						}
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
    //				if (data != null)
    //				{
    //					if (!current.State.Test(ENUM_GameObjFlag.Disable) && !current.State.Test(ENUM_GameObjFlag.Invalid))
    //					{
    //						if (current.RoleBase != null)
    //						{
    //							current.RoleBase.HideRole = hide;
    //						}
    //						else
    //						{
    //							current.State.Set(ENUM_GameObjFlag.Hide, hide);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void DisableAllObj(int mapid, bool disable)
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
    //				if (data != null)
    //				{
    //					if (data.emType == ENUM_NpcType.Role)
    //					{
    //						if (current.RoleBase != null)
    //						{
    //							current.RoleBase.DisableRole = disable;
    //						}
    //						else
    //						{
    //							current.State.Set(ENUM_GameObjFlag.Disable, disable);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public void ResetSneakNpc(int mapid)
    //	{
    //		if (mapid == 0)
    //		{
    //			Debug.LogError("ResetSneakNpc::Map == 0!!");
    //			return;
    //		}
    //		foreach (S_GameObjData current in this.m_AllGameObjData.Values)
    //		{
    //			if (current.MapId == mapid)
    //			{
    //				if (!(current.GameObj == null))
    //				{
    //					S_NpcData data = GameDataDB.NpcDB.GetData(current.Id);
    //					if (data != null && data.SneakTalk != null)
    //					{
    //						M_GameNpc component = current.GameObj.GetComponent<M_GameNpc>();
    //						component.ResetWayPoint();
    //					}
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
    //			if (dataByOrder != null && dataByOrder.emActionHint == type)
    //			{
    //				if (type != ENUM_ActionHint.Break || dataByOrder.emType == ENUM_NpcType.Trap)
    //				{
    //					num++;
    //				}
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
    //			if (data != null)
    //			{
    //				if (data.emType == ENUM_NpcType.Treasure)
    //				{
    //					num++;
    //				}
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
    //			if (GameDataDB.NpcDB.GetData(current.Id) != null)
    //			{
    //				if (current.State.Test(ENUM_GameObjFlag.Open))
    //				{
    //					num++;
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	public int GetAllMapOpenTreasuerCount()
    //	{
    //		int num = 0;
    //		Dictionary<int, S_GameObjData> gameObjData = this.GetGameObjData();
    //		foreach (KeyValuePair<int, S_GameObjData> current in gameObjData)
    //		{
    //			if (GameDataDB.NpcDB.GetData(current.Value.Id) != null)
    //			{
    //				if (current.Value.State.Test(ENUM_GameObjFlag.Open))
    //				{
    //					num++;
    //				}
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
        GameObject characterRoot = ResourcesManager.Instance.GetCharacterRoot(name);
        if (characterRoot == null)
        {
            Debug.Log("CreatePlayerGameObj::無法建立Root物件_" + id);
            return null;
        }
        GameObject gameObject = this.GetPlayerCosCloth(id);
        if (gameObject == null)
        {
            gameObject = ResourcesManager.Instance.GetCharacterModel(text);
            if (gameObject == null)
            {
                Debug.Log("CreatePlayerGameObj::無法建立Model物件_" + id);
                return null;
            }
        }
        RendererTool.ChangeSenceMaterialSetting(text, gameObject);
        gameObject.transform.parent = characterRoot.transform;
        Animator component = gameObject.GetComponent<Animator>();
        if (component == null)
        {
            Debug.Log("CreatePlayerGameObj::找不到Animator_" + id);
            return null;
        }
        component.enabled = false;
        Avatar avatar = component.avatar;
        UnityEngine.Object.Destroy(component);
        string name2 = "Player" + id + "_Map";
        component = characterRoot.GetComponent<Animator>();
        component.runtimeAnimatorController = ResourcesManager.Instance.GetAnimatorController(name2);
        component.avatar = avatar;
        component.applyRootMotion = false;
        SphereCollider component2 = gameObject.GetComponent<SphereCollider>();
        if (component2 != null)
        {
            UnityEngine.Object.Destroy(component2);
        }
        CapsuleCollider component3 = gameObject.GetComponent<CapsuleCollider>();
        if (component3 != null)
        {
            component3.enabled = true;
            component3.isTrigger = true;
        }
        FaceFXControllerScript component4 = gameObject.GetComponent<FaceFXControllerScript>();
        if (component4 != null)
        {
            UnityEngine.Object.Destroy(component4);
        }
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
        //UnityEngine.Object.DestroyObject(component6);
        //characterRoot.transform.position = pos;
        //characterRoot.transform.eulerAngles = new Vector3(0f, dir, 0f);
        //characterRoot.name = "Player";
        //component.applyRootMotion = true;
        //TransformTool.SetLayerRecursively(characterRoot.transform, 2);
        //gameObject.tag = "Player";
        //this.PlayerObj = characterRoot;
        //GameObjState state = new GameObjState();
        //S_GameObjData objData = new S_GameObjData(id, 0, pos, dir, 1, state, this.PlayerObj);
        //this.AddGameObjData(objData);
        //if (!this.PlayerObj.GetComponent<AudioListener>())
        //{
        //    this.PlayerObj.AddComponent<AudioListener>();
        //}
        //this.m_PhysicClothList.Clear();
        //this.m_PlayerObjList.Clear();
        //this.m_IsHide = false;
        return this.PlayerObj;
    }

    //	public GameObject CreatePlayerShowObj(int id, int itemId)
    //	{
    //		string name = "Player" + id;
    //		GameObject gameObject = Swd6Application.instance.m_GameObjSystem.GetPlayerCosCloth(id);
    //		if (gameObject == null)
    //		{
    //			gameObject = ResourceManager.Instance.GetCharacterModel(name);
    //			if (gameObject == null)
    //			{
    //				Debug.Log("CreatePlayerShowObj::無法建立Model物件_" + id);
    //				return null;
    //			}
    //		}
    //		FaceFXControllerScript component = gameObject.GetComponent<FaceFXControllerScript>();
    //		if (component != null)
    //		{
    //			UnityEngine.Object.Destroy(component);
    //		}
    //		Animation component2 = gameObject.GetComponent<Animation>();
    //		if (component2 != null)
    //		{
    //			UnityEngine.Object.Destroy(component2);
    //		}
    //		CharacterController component3 = gameObject.GetComponent<CharacterController>();
    //		component3.enabled = false;
    //		M_GameRoleMotion m_GameRoleMotion = gameObject.AddComponent<M_GameRoleMotion>();
    //		this.m_ShroudInstance = gameObject.GetComponent<ShroudInstance>();
    //		if (this.m_ShroudInstance != null)
    //		{
    //			this.m_ShroudInstance.ReduceBlendWeight_StoryEnable();
    //		}
    //		return gameObject;
    //	}

    //	public void ReduceShowRoleClothBlendWeight()
    //	{
    //		if (this.m_ShroudInstance != null)
    //		{
    //			this.m_ShroudInstance.ReduceBlendWeight();
    //		}
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
    //		this.m_IsHide = false;
    //		if (this.PlayerObj)
    //		{
    //			UnityEngine.Object.Destroy(this.PlayerObj);
    //			this.PlayerObj = null;
    //		}
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
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.NoCollider = this.m_IsHide;
    //			if (bHide)
    //			{
    //				ShroudMesh[] componentsInChildren = this.PlayerObj.GetComponentsInChildren<ShroudMesh>();
    //				if (componentsInChildren != null)
    //				{
    //					if (componentsInChildren.Length > 0)
    //					{
    //						this.m_PhysicClothList.Clear();
    //					}
    //					ShroudMesh[] array = componentsInChildren;
    //					for (int i = 0; i < array.Length; i++)
    //					{
    //						ShroudMesh shroudMesh = array[i];
    //						if (shroudMesh)
    //						{
    //							shroudMesh.gameObject.SetActive(false);
    //							this.m_PhysicClothList.Add(shroudMesh.gameObject);
    //						}
    //					}
    //				}
    //				this.EnablePlayerObj(this.PlayerObj, this.m_IsHide);
    //			}
    //			else
    //			{
    //				for (int j = 0; j < this.m_PlayerObjList.Count; j++)
    //				{
    //					this.m_PlayerObjList[j].SetActive(true);
    //				}
    //				this.m_PlayerObjList.Clear();
    //				for (int k = 0; k < this.m_PhysicClothList.Count; k++)
    //				{
    //					this.m_PhysicClothList[k].SetActive(true);
    //				}
    //				this.m_PhysicClothList.Clear();
    //			}
    //		}
    //	}

    //	public void EnablePlayerObj(GameObject gameObject, bool bHide)
    //	{
    //		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    //		if (componentsInChildren != null)
    //		{
    //			if (componentsInChildren.Length > 0)
    //			{
    //				this.m_PlayerObjList.Clear();
    //			}
    //			SkinnedMeshRenderer[] array = componentsInChildren;
    //			for (int i = 0; i < array.Length; i++)
    //			{
    //				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
    //				if (skinnedMeshRenderer)
    //				{
    //					skinnedMeshRenderer.gameObject.SetActive(!bHide);
    //					this.m_PlayerObjList.Add(skinnedMeshRenderer.gameObject);
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
    //					meshRenderer.gameObject.SetActive(!bHide);
    //					this.m_PlayerObjList.Add(meshRenderer.gameObject);
    //				}
    //			}
    //		}
    //		if (gameObject.renderer != null)
    //		{
    //			gameObject.renderer.enabled = !bHide;
    //		}
    //	}

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
            return null;
        }
        if (equipItemData.ID == 0)
        {
            return null;
        }
        S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
        if (data == null)
        {
            return null;
        }
        if (data.Equip.Materail.Count == 0)
        {
            return null;
        }
        return ResourcesManager.Instance.GetCharacterModel(data.Equip.Materail[0].MeshName);
    }

    //	public int GetPlayerWhatCosCloth(int roleId)
    //	{
    //		if (roleId == 0)
    //		{
    //			return 1;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(roleId);
    //		if (roleData == null)
    //		{
    //			return 1;
    //		}
    //		ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.CosCloth);
    //		if (equipItemData == null)
    //		{
    //			return 1;
    //		}
    //		if (equipItemData.ID == 0)
    //		{
    //			return 1;
    //		}
    //		S_Item data = GameDataDB.ItemDB.GetData(equipItemData.ID);
    //		if (data == null)
    //		{
    //			return 1;
    //		}
    //		if (data.Equip.Materail.Count == 0)
    //		{
    //			return 1;
    //		}
    //		return data.Equip.MeshAvatar;
    //	}

    //	public void ChangePlayer3Materail(GameObject gameObject)
    //	{
    //		this.m_Player3MaterialList.Clear();
    //		string name = string.Empty;
    //		string value = string.Empty;
    //		string text = string.Empty;
    //		GameObjSystem.Player3EffectParam player3EffectParam = default(GameObjSystem.Player3EffectParam);
    //		int playerWhatCosCloth = this.GetPlayerWhatCosCloth(3);
    //		Shader shader = Shader.Find("Softstar/Character/StealthCamouflage/StealthCamouflage-50 IBL 2-side Cutout");
    //		if (shader == null)
    //		{
    //			Debug.Log("replaceShader == null");
    //			return;
    //		}
    //		Texture2D image = ResourceManager.Instance.GetImage("P031-Eff_mask");
    //		Texture2D image2 = ResourceManager.Instance.GetImage("P031-Eff_mask_N");
    //		for (int i = 0; i < 9; i++)
    //		{
    //			if (playerWhatCosCloth == 1)
    //			{
    //				name = this.Player3MeshName[i];
    //				value = this.Player3OrgMaterialName[i];
    //				text = this.Player3MaterialName[i];
    //				player3EffectParam = this.Player3EffectParams[i];
    //			}
    //			else if (playerWhatCosCloth == 2)
    //			{
    //				name = this.Player3MeshName2[i];
    //				value = this.Player3OrgMaterialName2[i];
    //				text = this.Player3MaterialName2[i];
    //				player3EffectParam = this.Player3EffectParams2[i];
    //			}
    //			Transform transform = TransformTool.FindChild(gameObject.transform, name);
    //			if (transform)
    //			{
    //				string name2 = transform.renderer.material.name;
    //				if (name2.Contains(value))
    //				{
    //					this.m_ChangeEffect = 1;
    //					transform.renderer.material.shader = shader;
    //					transform.renderer.material.SetTexture("_DetailBump", image2);
    //					transform.renderer.material.SetTexture("_DissolveMask", image);
    //					transform.renderer.material.SetFloat("_DetailBumpTiling", player3EffectParam.m_DetailBumpTiling);
    //					transform.renderer.material.SetFloat("_DissolveTiling", player3EffectParam.m_DissolveTiling);
    //					transform.renderer.material.SetFloat("_BlendHeight", player3EffectParam.m_BlendHeight);
    //					transform.renderer.material.SetFloat("_DissolveRange", player3EffectParam.m_DissolveRange);
    //					this.m_Player3MaterialList.Add(transform.renderer.material);
    //				}
    //			}
    //		}
    //		List<GameObject> list = new List<GameObject>();
    //		ShroudMesh[] componentsInChildren = this.PlayerObj.GetComponentsInChildren<ShroudMesh>();
    //		if (componentsInChildren != null)
    //		{
    //			ShroudMesh[] array = componentsInChildren;
    //			for (int j = 0; j < array.Length; j++)
    //			{
    //				ShroudMesh shroudMesh = array[j];
    //				if (shroudMesh)
    //				{
    //					list.Add(shroudMesh.gameObject);
    //				}
    //			}
    //		}
    //		string[] array2 = new string[]
    //		{
    //			string.Empty
    //		};
    //		string[] expr_280 = new string[]
    //		{
    //			string.Empty
    //		};
    //		if (playerWhatCosCloth == 1)
    //		{
    //			array2 = this.Player3OrgMaterialName;
    //			string[] array3 = this.Player3MaterialName;
    //		}
    //		else if (playerWhatCosCloth == 2)
    //		{
    //			array2 = this.Player3OrgMaterialName2;
    //			string[] array3 = this.Player3MaterialName2;
    //		}
    //		for (int k = 9; k < array2.Length; k++)
    //		{
    //			for (int l = 0; l < list.Count; l++)
    //			{
    //				Transform transform2 = list[l].transform;
    //				if (transform2)
    //				{
    //					string name3 = transform2.renderer.material.name;
    //					if (name3.Contains(array2[k]))
    //					{
    //						this.m_ChangeEffect = 1;
    //						transform2.renderer.material.shader = shader;
    //						transform2.renderer.material.SetTexture("_DetailBump", image2);
    //						transform2.renderer.material.SetTexture("_DissolveMask", image);
    //						transform2.renderer.material.SetFloat("_DetailBumpTiling", player3EffectParam.m_DetailBumpTiling);
    //						transform2.renderer.material.SetFloat("_DissolveTiling", player3EffectParam.m_DissolveTiling);
    //						transform2.renderer.material.SetFloat("_BlendHeight", player3EffectParam.m_BlendHeight);
    //						transform2.renderer.material.SetFloat("_DissolveRange", player3EffectParam.m_DissolveRange);
    //						this.m_Player3MaterialList.Add(transform2.renderer.material);
    //					}
    //				}
    //			}
    //		}
    //		GameObject gameObject2 = EffectSystem.Instance.CreateEffect(gameObject.transform, "P031_fight_out", true, true);
    //	}

    //	public void RestorePlayer3Materail(GameObject gameObject)
    //	{
    //		if (this.m_ChangeEffect != 1)
    //		{
    //			return;
    //		}
    //		this.m_ChangeEffect = 2;
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject2 = EffectSystem.Instance.CreateEffect(gameObject.transform, "P031_fight_in", true, true);
    //	}

    //	public void ClearPlayer3MaterailData()
    //	{
    //		this.m_ChangeEffect = 0;
    //		this.m_EffectValue = 0f;
    //		this.m_Player3MaterialList.Clear();
    //	}

    //	public void UpdatePlayerMaterailEffect(GameObject gameObject)
    //	{
    //		if (this.m_ChangeEffect == 0)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < this.m_Player3MaterialList.Count; i++)
    //		{
    //			Material material = this.m_Player3MaterialList[i];
    //			if (material)
    //			{
    //				material.SetVector("_ParentPosition", gameObject.transform.position);
    //				material.SetFloat("_StealthCamouflageControl", this.m_EffectValue);
    //			}
    //		}
    //		float num = 0.5f;
    //		if (this.m_ChangeEffect == 1 && this.m_EffectValue < 1f)
    //		{
    //			this.m_EffectValue += Time.deltaTime * num;
    //			this.m_EffectValue = Mathf.Min(this.m_EffectValue, 1f);
    //		}
    //		if (this.m_ChangeEffect == 2 && this.m_EffectValue > 0f)
    //		{
    //			this.m_EffectValue -= Time.deltaTime * num;
    //			this.m_EffectValue = Mathf.Max(this.m_EffectValue, 0f);
    //			if (this.m_EffectValue <= 0f)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.SwitchPlayer();
    //				this.m_ChangeEffect = 0;
    //				this.m_EffectValue = 0f;
    //			}
    //		}
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

    public GameObject CreateAmberPigGameObj()
    {
        return null;
    }

    //	public void RemoveAmberGameObj()
    //	{
    //		if (this.m_AmberPigGameObj)
    //		{
    //			UnityEngine.Object.Destroy(this.m_AmberPigGameObj);
    //			this.m_AmberPigGameObj = null;
    //		}
    //	}
}
