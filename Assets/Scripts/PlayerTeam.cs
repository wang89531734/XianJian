using System;
using System.Collections.Generic;
//using Funfia.File;
//using SoftStar.Item;
using SoftStar.Pal6;
using UnityEngine;

/// <summary>
/// 玩家队伍
/// </summary>
public class PlayerTeam : MonoBehaviour
{
    public int money = 1000;

    [SerializeField]
    private PlayerTeamData[] data;

    //	[SerializeField]
    //	private List<ItemD> PackItemIDs = new List<ItemD>();

    //	[SerializeField]
    //	private List<FlagValue> flagValues = new List<FlagValue>();

    public float startWeatherTime = 0.4f;

    public static PlayerTeam instance;

    public static PlayerTeam Instance
    {
        get
        {
            if (PlayerTeam.instance == null)
            {          
               PlayerTeam.instance.Init();         
            }
            return PlayerTeam.instance;
        }
    }

    public static void ReStart()
    {
        if (PlayerTeam.instance != null)
        {
            UnityEngine.Object.Destroy(PlayerTeam.instance.gameObject);
            PlayerTeam.instance = null;
        }
    }

    private void Start()
    {
        if (PlayerTeam.instance == null)
        {
            this.Init();
        }
    }

    private void Init()
    {
        PlayerTeam.instance = this;
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }

    public void LoadTeam()
    {
        ScenesManager.Instance.OnLevelLoaded += this.OnLoadTeam;
        this.SetInitValue();
    }

    public void SetInitValue()
    {
        PalMain.SetMoney(this.money);
        this.InitTime();
    }

    public void OnLoadTeam(int Level)
    {
        UnityEngine.Debug.Log("加载队伍");
        ScenesManager.Instance.OnLevelLoaded -= this.OnLoadTeam;
        //if (UniStormWeatherSystem.instance != null)
        //{
        //    TimeManager.Initialize().timeStopped = UniStormWeatherSystem.instance.timeStopped;
        //}
        //else
        //{
        //    Debug.LogWarning("Warn : UniStormWeatherSystem.instance==null");
        //}
        //this.InitTeam();
        //this.InitPlayerLevel();
        //this.InitSkill();
        //this.InitItem();
        if (base.gameObject != null)
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }

    //	public void InitTeam()
    //	{
    //		PlayersManager.ActivePlayers.Clear();
    //		for (int i = 0; i < this.data.Length; i++)
    //		{
    //			GameObject x;
    //			if (this.data[i].Enqueue)
    //			{
    //				x = PlayersManager.AddPlayer(this.data[i].mCharacterID, true);
    //			}
    //			else
    //			{
    //				x = PlayersManager.FindMainChar(this.data[i].mCharacterID, true);
    //			}
    //			if (x == null)
    //			{
    //				Debug.LogError("InitTeam null gameobject " + i.ToString());
    //			}
    //		}
    //		PlayersManager.SetPlayer(0, true);
    //		PlayersManager.SetPlayerPosByDestObj("SceneEnter");
    //		PlayerCtrlManager.Reset();
    //	}

    //	public void InitPlayerLevel()
    //	{
    //		for (int i = 0; i < this.data.Length; i++)
    //		{
    //			GameObject gameObject = PlayersManager.FindMainChar(this.data[i].mCharacterID, true);
    //			if (gameObject != null)
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				PalNPC.CharacterData characterData = component.Data;
    //				characterData.Exp = PlayerBaseProperty.LevelData.GetLevelExp(this.data[i].mLevel - 1);
    //				characterData.HPMPDP.HP = this.data[i].HP;
    //			}
    //		}
    //	}

    //	public void InitItem()
    //	{
    //		for (int i = 0; i < this.data.Length; i++)
    //		{
    //			GameObject gameObject = PlayersManager.FindMainChar(this.data[i].mCharacterID, true);
    //			if (gameObject != null)
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				for (int j = 0; j < this.data[i].m_ItemIDs.Count; j++)
    //				{
    //					ItemD itemD = this.data[i].m_ItemIDs[j];
    //					uint id = ItemManager.GetID((uint)itemD.ParentID, (uint)itemD.ChildID);
    //					ItemManager.GetInstance().GetOrCreatePackage(1u).AddNewItem_Limit(id, 1);
    //					ItemWatcher[] itemsByItemType = ItemManager.GetInstance().GetOrCreatePackage(1u).GetItemsByItemType(id);
    //					foreach (ItemWatcher itemWatcher in itemsByItemType)
    //					{
    //						if (itemWatcher != null)
    //						{
    //							IItemAssemble<PalNPC> itemAssemble = itemWatcher.Target as IItemAssemble<PalNPC>;
    //							if (itemAssemble != null)
    //							{
    //								if (!(itemAssemble.GetOwner() != null))
    //								{
    //									component.PutOnEquip(itemAssemble);
    //									break;
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		for (int l = 0; l < this.PackItemIDs.Count; l++)
    //		{
    //			ItemD itemD2 = this.PackItemIDs[l];
    //			uint id2 = ItemManager.GetID((uint)itemD2.ParentID, (uint)itemD2.ChildID);
    //			ItemManager.GetInstance().GetOrCreatePackage(1u).AddNewItem_Limit(id2, itemD2.Number);
    //		}
    //	}

    //	public void InitSkill()
    //	{
    //		for (int i = 0; i < this.data.Length; i++)
    //		{
    //			GameObject gameObject = PlayersManager.FindMainChar(this.data[i].mCharacterID, true);
    //			if (gameObject != null)
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				foreach (PalNPC.SkillInfo newSkill in this.data[i].m_SkillIDs)
    //				{
    //					component.AddSkillNoRepeat(newSkill);
    //				}
    //			}
    //		}
    //	}

    //	public void InitPlayerTeamFlags()
    //	{
    //		for (int i = 0; i < this.flagValues.Count; i++)
    //		{
    //			PalMain.SetFlag(this.flagValues[i].flag, this.flagValues[i].Value);
    //		}
    //	}

    //	public static void InitPickItemFlag()
    //	{
    //		Dictionary<int, PickUpItemContainer> datasFromFile = PickUpItemContainer.GetDatasFromFile();
    //		foreach (int num in datasFromFile.Keys)
    //		{
    //			FlagManager.SetFlag(num + PalPickItem.OffsetPickItem, 0, true);
    //		}
    //	}

    public void InitTime()
    {
        TimeManager.Initialize().AutoSaveInit();
        TimeManager.Initialize().weatherTime = this.startWeatherTime;
    }
}
