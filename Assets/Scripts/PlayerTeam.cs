using System;
using System.Collections.Generic;
//using Funfia.File;
using SoftStar.Item;
using SoftStar.Pal6;
using UnityEngine;
using YouYou;

public class PlayerTeam : MonoBehaviour
{
    public int money = 1000;

    //	[SerializeField]
    //	private PlayerTeamData[] data;

    //	[SerializeField]
    //	private List<ItemD> PackItemIDs = new List<ItemD>();

    [SerializeField]
    private List<FlagValue> flagValues = new List<FlagValue>();

    //	public float startWeatherTime = 0.4f;

    //	private static string MainLineTeamDataPath = "/Resources/Template/System/playerTeam.prefab";

    //	private static string DLCTeamDataPath0 = "/Resources/Template/System/playerTeamDLC0.prefab";

    //	private static string DLCTeamDataPath1 = "/Resources/Template/System/playerTeamDLC1.prefab";

    //	private static string DLCTeamDataPath2 = "/Resources/Template/System/playerTeamDLC2.prefab";

    //	private static string DLCTeamDataPath3 = "/Resources/Template/System/playerTeamDLC3.prefab";

    //	private static string DLCTeamDataPath4 = "/Resources/Template/System/playerTeamDLC4.prefab";

    //	private static string DLCTeamDataPath5 = "/Resources/Template/System/playerTeamDLC5.prefab";

    public static PlayerTeam instance;

    public static PlayerTeam Instance
    {
        get
        {
            if (PlayerTeam.instance == null)
            {
                //string path = PlayerTeam.MainLineTeamDataPath;
                //if (PalMain.IsDLC)
                //{
                //    switch (FlagManager.GetFlag(10))
                //    {
                //        case 0:
                //            path = PlayerTeam.DLCTeamDataPath0;
                //            break;
                //        case 1:
                //            path = PlayerTeam.DLCTeamDataPath1;
                //            break;
                //        case 2:
                //            path = PlayerTeam.DLCTeamDataPath2;
                //            break;
                //        case 3:
                //            path = PlayerTeam.DLCTeamDataPath3;
                //            break;
                //        case 4:
                //            path = PlayerTeam.DLCTeamDataPath4;
                //            break;
                //        case 5:
                //            path = PlayerTeam.DLCTeamDataPath5;
                //            break;
                //        default:
                //            path = PlayerTeam.DLCTeamDataPath0;
                //            break;
                //    }
                //}
                //GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>(path.ToAssetBundlePath(), true, true);
                //if (gameObject != null)
                //{
                //    PlayerTeam.instance = gameObject.GetComponent<PlayerTeam>();
                //    if (PlayerTeam.instance == null)
                //    {
                //        Debug.LogError("缺少 PlayerTeam 资源");
                //    }
                //    else
                //    {
                //        PlayerTeam.instance.Init();
                //    }
                //    gameObject.name = "playerTeam";
                //}
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
    }

    public void LoadTeam()
    {
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.OnSceneLoaded, OnLoadTeam);
        this.SetInitValue();
    }

    public void SetInitValue()
    {
        PalMain.SetMoney(this.money);
        this.InitTime();
    }

    public void OnLoadTeam(object userData)
    {
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
        //if (base.gameObject != null)
        //{
        //    UnityEngine.Object.Destroy(base.gameObject);
        //}
    }

    //	// Token: 0x06003216 RID: 12822 RVA: 0x0016BB34 File Offset: 0x00169D34
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

    //	// Token: 0x06003217 RID: 12823 RVA: 0x0016BBE0 File Offset: 0x00169DE0
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

    //	// Token: 0x06003218 RID: 12824 RVA: 0x0016BC68 File Offset: 0x00169E68
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

    //	// Token: 0x06003219 RID: 12825 RVA: 0x0016BDF8 File Offset: 0x00169FF8
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

    public void InitPlayerTeamFlags()
    {
        for (int i = 0; i < this.flagValues.Count; i++)
        {
            PalMain.SetFlag(this.flagValues[i].flag, this.flagValues[i].Value);
        }
    }

    //	// Token: 0x0600321B RID: 12827 RVA: 0x0016BEFC File Offset: 0x0016A0FC
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
        //TimeManager.Initialize().AutoSaveInit();
        //TimeManager.Initialize().weatherTime = this.startWeatherTime;
    }
}
