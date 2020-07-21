using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameDataSystem
{
	public string m_GameVersion;

	private int m_Money;

	public int m_Stamina;

	public int m_CompleteGame;

	public int m_MaxCompleteGame;

	public int m_PlayGameCount;

	public int m_PlayerID;

	public int m_BreakBoxTimes;

	public int m_SelectPet;

	public int m_DefaultPlayerID;

	public int m_FightPlayerID;

	public int[] m_StoreSpendMoney;

	public int[] m_ReviewStory;

	public int[] m_FightRole;

	public float m_PlayTimes;

	public S_MapInfo m_MapInfo;

	public S_GameFlag m_GameFlag;

	private C_RoleDataEx[] m_RoldData;

	private Dictionary<int, S_MapData> m_MapData;

	private List<S_PartyData> m_PartyRole;

	private List<int> m_TeamRoleList;

	private List<int> m_ActionSkillList;

	private Dictionary<int, S_MapMusicData> m_MapMusicData;

	public int Money
	{
		get
		{
			return this.m_Money;
		}
		set
		{
			this.m_Money = value;
			if (this.m_Money <= 0)
			{
				this.m_Money = 0;
			}
			//Swd6Application.instance.m_QuestSystem.Dirty();
		}
	}

	public void Initialize()
	{
		this.m_GameVersion = "1.04";
		this.m_Money = 0;
		this.m_Stamina = 600;
		this.m_PlayerID = 1;
		this.m_PlayTimes = 0f;
		this.m_BreakBoxTimes = 0;
		this.m_CompleteGame = 0;
		this.m_MaxCompleteGame = 0;
		this.m_PlayGameCount = 1;
		this.m_StoreSpendMoney = new int[256];
		this.m_ReviewStory = new int[512];
		this.m_FightRole = new int[4];
		this.m_MapInfo = default(S_MapInfo);
		this.m_GameFlag = new S_GameFlag();
		this.m_MapData = new Dictionary<int, S_MapData>();
		this.m_MapMusicData = new Dictionary<int, S_MapMusicData>();
		this.m_PartyRole = new List<S_PartyData>();
		this.m_TeamRoleList = new List<int>();
		this.m_ActionSkillList = new List<int>();
		this.m_RoldData = new C_RoleDataEx[10];
		for (int i = 0; i < 10; i++)
		{
			this.m_RoldData[i] = new C_RoleDataEx();
		}
	}

	public void Reset()
	{
		this.m_Money = 0;
		this.m_Stamina = 600;
		this.m_PlayerID = 1;
		this.m_PlayTimes = 0f;
		this.m_BreakBoxTimes = 0;
		this.m_CompleteGame = 0;
		this.m_PlayGameCount = 1;
		this.m_SelectPet = 0;
		for (int i = 0; i < 4; i++)
		{
			this.m_FightRole[i] = 0;
		}
		this.m_MapInfo.Clear();
		this.m_GameFlag.Clear();
		this.m_PartyRole.Clear();
		this.m_TeamRoleList.Clear();
		this.m_ActionSkillList.Clear();
        this.ClearMapData();
    }

	public void InitTeamRoleList()
	{
		this.m_TeamRoleList.Clear();
		this.m_ActionSkillList.Clear();

        this.m_TeamRoleList.Add(1);
        this.m_TeamRoleList.Add(2);
        this.m_TeamRoleList.Add(3);
        this.m_TeamRoleList.Add(4);
        this.m_ActionSkillList.Add(1);
        this.m_ActionSkillList.Add(2);
        this.m_ActionSkillList.Add(3);
        this.m_ActionSkillList.Add(4);
    }

	//public void AddDLCItem()
	//{
	//	if (Swd6Application.instance.CheckDLCItem(100))
	//	{
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(12) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(12, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(32) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(32, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(52) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(52, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(72) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(72, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(301) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(301, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(302) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(302, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(303) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(303, 1, ENUM_ItemState.New, false);
	//		}
	//		if (Swd6Application.instance.m_ItemSystem.GetDataByItemID(304) == null)
	//		{
	//			Swd6Application.instance.m_ItemSystem.AddItem(304, 1, ENUM_ItemState.New, false);
	//		}
	//	}
	//}

	public void InitRoleData()
	{
		this.Reset();
        GameEntry.Instance.InitNewGame();
        this.InitTeamRoleList();
		int num = 0;
        for (int j = 0; j < this.m_TeamRoleList.Count; j++)
        {
            this.SetStartData(this.m_TeamRoleList[j], this.m_TeamRoleList[j], this.m_TeamRoleList[j]);
            num++;
        }
        //Swd6Application.instance.m_SkillSystem.InitDefaultHotKeySkill();
        //this.m_RoldData[0].BaseRoleData.IsJoin = true;
        this.m_DefaultPlayerID = 1;
        //this.AddRole(1, false);
        //NormalSetting normalSetting = Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting();
        //if (normalSetting.m_bEnableTeach)
        //{
        //	this.FlagON(75);
        //	this.FlagON(76);
        //	this.FlagON(77);
        //}
        //this.AddDLCItem();
        this.m_PlayerID = this.m_DefaultPlayerID;
		this.m_FightPlayerID = this.m_DefaultPlayerID;
		//this.FlagON(24);
	}

	public void InitExRoleData(int chapId)
	{
		this.Reset();
		//if (this.m_ChapID == chapId)
		//{
		//	return;
		//}
		//this.m_ChapID = chapId;
		////Swd6Application.instance.InitNewGame();
		//this.InitTeamRoleList(chapId);
		//int chapID = this.m_ChapID;
		//if (chapID != 100)
		//{
		//	if (chapID != 101)
		//	{
		//	}
		//}
		//else
		//{
		//	for (int i = 0; i < this.m_TeamRoleList.Count; i++)
		//	{
		//		//this.SetStartData(this.m_TeamRoleList[i], this.m_TeamRoleList[i], this.m_TeamRoleList[i]);
		//	}
		//	//Swd6Application.instance.m_InheritSystem.SetInheritData();
		//	//Swd6Application.instance.m_SkillSystem.InitDefaultHotKeySkill();
		//	Debug.Log("ChapEx_100");
		//	//this.m_RoldData[0].BaseRoleData.IsJoin = true;
		//	this.m_DefaultPlayerID = 1;
		//	//this.AddRole(1, false);
		//	//NormalSetting normalSetting = Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting();
		//	//if (normalSetting.m_bEnableTeach)
		//	//{
		//	//	this.FlagON(75);
		//	//	this.FlagON(76);
		//	//	this.FlagON(77);
		//	//}
		//	//this.AddDLCItem();
		//}
		this.m_PlayerID = this.m_DefaultPlayerID;
		this.m_FightPlayerID = this.m_DefaultPlayerID;
		//this.FlagON(24);
	}

	public int GetMinID()
	{
		//int chapID = this.m_ChapID;
		//if (chapID == 100)
		//{
		//	return 1;
		//}
		//if (chapID != 101)
		//{
		//	return 1;
		//}
		return 2;
	}

	public int GetMaxID()
	{
		//int chapID = this.m_ChapID;
		//if (chapID == 100)
		//{
		//	return 4;
		//}
		//if (chapID != 101)
		//{
		//	return 1;
		//}
		return 7;
	}

	public int GetMaxRoleCountByChapter(int chapId)
	{
		if (chapId == 100)
		{
			return 4;
		}
		if (chapId != 101)
		{
			return 0;
		}
		return 3;
	}

	public C_RoleDataEx GetRoleData(int id)
	{
		if (id > this.GetMaxID())
		{
			Debug.LogError("id error!!");
			return null;
		}
		return this.m_RoldData[id - 1];
	}

	public void SetRoleData(int id, C_RoleDataEx roleData)
	{
		if (id > this.GetMaxID())
		{
			Debug.LogError("id error!!");
			return;
		}
		this.m_RoldData[id - 1] = roleData;
		//this.m_RoldData[id - 1].CalRoleAttr();
	}

	public void SetBaseRoleData(int id, S_BaseRoleData roleData)
	{
		if (id > this.GetMaxID())
		{
			Debug.LogError("id error!!");
			return;
		}
		//this.m_RoldData[id - 1].BaseRoleData.ID = roleData.ID;
		//this.m_RoldData[id - 1].BaseRoleData.FamilyName = roleData.FamilyName;
		//this.m_RoldData[id - 1].BaseRoleData.Name = roleData.Name;
		//this.m_RoldData[id - 1].BaseRoleData.MaxHP = roleData.MaxHP;
		//this.m_RoldData[id - 1].BaseRoleData.MaxMP = roleData.MaxMP;
		//this.m_RoldData[id - 1].BaseRoleData.HP = roleData.HP;
		//this.m_RoldData[id - 1].BaseRoleData.MP = roleData.MP;
		//this.m_RoldData[id - 1].BaseRoleData.Atk = roleData.Atk;
		//this.m_RoldData[id - 1].BaseRoleData.MAtk = roleData.MAtk;
		//this.m_RoldData[id - 1].BaseRoleData.Def = roleData.Def;
		//this.m_RoldData[id - 1].BaseRoleData.MDef = roleData.MDef;
		//this.m_RoldData[id - 1].BaseRoleData.Block = roleData.Block;
		//this.m_RoldData[id - 1].BaseRoleData.Dodge = roleData.Dodge;
		//this.m_RoldData[id - 1].BaseRoleData.Critical = roleData.Critical;
		//this.m_RoldData[id - 1].BaseRoleData.emElemntType = roleData.emElemntType;
		//this.m_RoldData[id - 1].BaseRoleData.emWeaponElemntType = roleData.emWeaponElemntType;
		//this.m_RoldData[id - 1].BaseRoleData.Element = roleData.Element;
		//this.m_RoldData[id - 1].BaseRoleData.AtkElement = roleData.AtkElement;
		//for (int i = 0; i < this.m_RoldData[id - 1].BaseRoleData.EquipID.Length; i++)
		//{
		//	this.m_RoldData[id - 1].BaseRoleData.EquipID[i] = roleData.EquipID[i];
		//}
		//this.m_RoldData[id - 1].BaseRoleData.Level = roleData.Level;
		//this.m_RoldData[id - 1].BaseRoleData.TotalExp = roleData.TotalExp;
		//this.m_RoldData[id - 1].BaseRoleData.TotalSkillPoint = roleData.TotalSkillPoint;
		//this.m_RoldData[id - 1].BaseRoleData.CostSkillPoint = roleData.CostSkillPoint;
		//this.m_RoldData[id - 1].BaseRoleData.IsJoin = roleData.IsJoin;
		//this.m_RoldData[id - 1].BaseRoleData.IsFight = roleData.IsFight;
		//this.m_RoldData[id - 1].BaseRoleData.IsDeath = roleData.IsDeath;
	}

    //public void CheckSpherSkillCostPoint(int id)
    //{
    //	int num = Swd6Application.instance.m_SkillSystem.CheckSpherSkillCostPoint(id);
    //	if (num != this.m_RoldData[id - 1].BaseRoleData.CostSkillPoint)
    //	{
    //		if (num > this.m_RoldData[id - 1].BaseRoleData.TotalSkillPoint)
    //		{
    //			num = this.m_RoldData[id - 1].BaseRoleData.TotalSkillPoint;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.CostSkillPoint = num;
    //	}
    //}

    //public void SetInheritBaseRoleData(int id, S_BaseRoleData roleData)
    //{
    //	if (id > this.GetMaxID())
    //	{
    //		Debug.LogError("SetInheritBaseRoleData id error!!");
    //		return;
    //	}
    //	this.m_RoldData[id - 1].BaseRoleData.ID = roleData.ID;
    //	this.m_RoldData[id - 1].BaseRoleData.MaxHP = roleData.MaxHP;
    //	this.m_RoldData[id - 1].BaseRoleData.MaxMP = roleData.MaxMP;
    //	this.m_RoldData[id - 1].BaseRoleData.HP = roleData.HP;
    //	this.m_RoldData[id - 1].BaseRoleData.MP = roleData.MP;
    //	this.m_RoldData[id - 1].BaseRoleData.Atk = roleData.Atk;
    //	this.m_RoldData[id - 1].BaseRoleData.MAtk = roleData.MAtk;
    //	this.m_RoldData[id - 1].BaseRoleData.Def = roleData.Def;
    //	this.m_RoldData[id - 1].BaseRoleData.MDef = roleData.MDef;
    //	this.m_RoldData[id - 1].BaseRoleData.Block = roleData.Block;
    //	this.m_RoldData[id - 1].BaseRoleData.Dodge = roleData.Dodge;
    //	this.m_RoldData[id - 1].BaseRoleData.Critical = roleData.Critical;
    //	this.m_RoldData[id - 1].BaseRoleData.emElemntType = roleData.emElemntType;
    //	for (int i = 0; i < roleData.Element.Length; i++)
    //	{
    //		this.m_RoldData[id - 1].BaseRoleData.Element = roleData.Element;
    //	}
    //	this.m_RoldData[id - 1].BaseRoleData.TotalExp = roleData.TotalExp;
    //	this.m_RoldData[id - 1].BaseRoleData.Level = roleData.Level;
    //	this.m_RoldData[id - 1].CalRoleAttr();
    //	this.m_RoldData[id - 1].SetFullHP();
    //	this.m_RoldData[id - 1].SetFullMP();
    //}

    //public void ReLoadObjData()
    //{
    //	for (int i = 0; i < this.GetMaxTeamRoleCount(); i++)
    //	{
    //		this.m_RoldData[this.m_TeamRoleList[i] - 1].CalRoleAttr();
    //	}
    //}

    //public void Update()
    //{
    //	this.m_PlayTimes += Time.deltaTime;
    //}

    //public bool GetFlag(int flag)
    //{
    //	return this.m_GameFlag.Get(flag);
    //}

    //public void FlagON(int flag)
    //{
    //	this.m_GameFlag.ON(flag);
    //	if (flag >= this.GetMinID() && flag <= this.GetMaxID())
    //	{
    //		if (this.m_RoldData[flag - 1].BaseRoleData.IsJoin || flag != 7)
    //		{
    //		}
    //		if (!Swd6Application.instance.IsDLC())
    //		{
    //			this.FlagON(30 + flag);
    //		}
    //		this.m_RoldData[flag - 1].BaseRoleData.IsJoin = true;
    //		this.UpdatePartyRole();
    //		Swd6Application.instance.m_FormationSystem.UnlockFormation(flag);
    //		Swd6Application.instance.m_FormationSystem.AutoSetUnitData();
    //	}
    //	if (Swd6Application.instance.m_QuestSystem != null)
    //	{
    //		Swd6Application.instance.m_QuestSystem.Dirty();
    //	}
    //}

    //public void FlagOFF(int flag)
    //{
    //	this.m_GameFlag.OFF(flag);
    //	if (flag >= this.GetMinID() && flag <= this.GetMaxID())
    //	{
    //		this.m_RoldData[flag - 1].BaseRoleData.IsFight = false;
    //		this.UpdatePartyRole();
    //		if (flag == this.m_FightPlayerID)
    //		{
    //			this.m_FightPlayerID = this.m_DefaultPlayerID;
    //		}
    //		if (flag == this.m_PlayerID)
    //		{
    //			this.m_PlayerID = this.m_DefaultPlayerID;
    //			if (UI_Explore.Instance != null)
    //			{
    //				UI_Explore.Instance.SetActionSkill(this.m_DefaultPlayerID);
    //			}
    //			Swd6Application.instance.m_ExploreSystem.SwitchPlayer();
    //		}
    //	}
    //	if (Swd6Application.instance.m_QuestSystem != null)
    //	{
    //		Swd6Application.instance.m_QuestSystem.Dirty();
    //	}
    //}

    //public void FlagSet(int flag, bool val)
    //{
    //	this.m_GameFlag.Set(flag, val);
    //}

    public bool SetStartData(int roleId, int dateId, int levelId)
    {
        int num = roleId - 1;
        S_StartRoleData data = GameDataDB.StartRoleDB.GetData(dateId);
        if (data == null)
        {
            return false;
        }
        this.m_RoldData[num].BaseRoleData.ID = roleId;
        this.m_RoldData[num].BaseRoleData.FamilyName = GameDataDB.StrID(num * 10 + 51);
        this.m_RoldData[num].BaseRoleData.Name = GameDataDB.StrID(num * 10 + 52);
        this.m_RoldData[num].BaseRoleData.SetStartData(data, levelId, true);
        this.m_RoldData[num].CalRoleAttr();
        this.m_RoldData[num].SetFullHP();
        this.m_RoldData[num].SetFullMP();
        return true;
    }

    //public bool LoadStartData(int roleId)
    //{
    //	int num = roleId - 1;
    //	S_StartRoleData data = GameDataDB.StartRoleDB.GetData(roleId);
    //	if (data == null)
    //	{
    //		return false;
    //	}
    //	this.m_RoldData[num].BaseRoleData.SetStartData(data, roleId, false);
    //	this.m_RoldData[num].CalRoleAttr();
    //	this.m_RoldData[num].SetFullHP();
    //	this.m_RoldData[num].SetFullMP();
    //	return true;
    //}

    public S_Level GetLevelData(int roleId, int level)
    {
        int num = (roleId - 1) * 150 + level;
        S_Level data = GameDataDB.LevelDB.GetData(num);
        if (data == null)
        {
            Debug.Log("讀取升級表錯誤_" + num);
        }
        return data;
    }

    //public void LevelUp(int roleId, int level, bool autoSetExp, ref S_LevelUpInfo levelUpInfo)
    //{
    //	this.m_RoldData[roleId - 1].BaseRoleData.SetLevelUpData(level, autoSetExp, ref levelUpInfo);
    //	this.m_RoldData[roleId - 1].CalRoleAttr();
    //	this.m_RoldData[roleId - 1].SetFullHP();
    //	this.m_RoldData[roleId - 1].SetFullMP();
    //}

    //public bool AddRoleExp(int roleId, int exp, ref S_LevelUpInfo levelUpInfo)
    //{
    //	bool result = false;
    //	if (this.m_RoldData[roleId - 1].BaseRoleData.Level >= 99)
    //	{
    //		return false;
    //	}
    //	this.m_RoldData[roleId - 1].BaseRoleData.TotalExp += exp;
    //	while (true)
    //	{
    //		S_Level levelData = this.GetLevelData(roleId, this.m_RoldData[roleId - 1].BaseRoleData.Level);
    //		if (this.m_RoldData[roleId - 1].BaseRoleData.TotalExp < levelData.NextExp)
    //		{
    //			break;
    //		}
    //		this.LevelUp(roleId, this.m_RoldData[roleId - 1].BaseRoleData.Level + 1, false, ref levelUpInfo);
    //		if (levelUpInfo != null)
    //		{
    //			result = true;
    //			levelUpInfo.IsLevelUp = true;
    //		}
    //	}
    //	return result;
    //}

    //public string GetPlayTimeText(float playTime, bool showHour)
    //{
    //	int num = (int)playTime;
    //	int num2 = num / 3600;
    //	int num3 = num % 3600 / 60 / 10;
    //	int num4 = num % 3600 / 60 % 10;
    //	int num5 = num % 3600 % 60 / 10;
    //	int num6 = num % 3600 % 60 % 10;
    //	string result = string.Empty;
    //	if (showHour)
    //	{
    //		result = string.Concat(new object[]
    //		{
    //			num2,
    //			":",
    //			num3,
    //			num4,
    //			":",
    //			num5,
    //			num6
    //		});
    //	}
    //	else
    //	{
    //		result = string.Concat(new object[]
    //		{
    //			num3 + num4,
    //			":",
    //			num5,
    //			num6
    //		});
    //	}
    //	return result;
    //}

    //public S_MapData AddMapData(int mapid)
    //{
    //	S_MapData s_MapData;
    //	if (!this.m_MapData.ContainsKey(mapid))
    //	{
    //		s_MapData = GameDataDB.MapDB.GetData(mapid);
    //		if (s_MapData != null)
    //		{
    //			this.m_MapData.Add(mapid, s_MapData);
    //		}
    //	}
    //	else
    //	{
    //		s_MapData = this.m_MapData[mapid];
    //	}
    //	return s_MapData;
    //}

    //public S_MapData GetMapData(int mapid)
    //{
    //	if (!this.m_MapData.ContainsKey(mapid))
    //	{
    //		this.AddMapData(mapid);
    //	}
    //	if (this.m_MapData.ContainsKey(mapid))
    //	{
    //		return this.m_MapData[mapid];
    //	}
    //	return null;
    //}

    public void ClearMapData()
    {
        foreach (S_MapData current in this.m_MapData.Values)
        {
            if (this.m_MapMusicData.ContainsKey(current.GUID))
            {
                S_MapMusicData s_MapMusicData = this.m_MapMusicData[current.GUID];
                current.MusicID1 = s_MapMusicData.MusicID1;
                current.MusicID2 = s_MapMusicData.MusicID2;
                current.emMusicMode = s_MapMusicData.emMusicMode;
                current.SkyID = s_MapMusicData.SkyID;
            }
        }
        this.m_MapData.Clear();
        this.m_MapMusicData.Clear();
    }

    //public void ChangeMapSky(int mapid, int skyid)
    //{
    //	if (!this.m_MapData.ContainsKey(mapid))
    //	{
    //		this.AddMapData(mapid);
    //	}
    //	this.m_MapData[mapid].SkyID = skyid;
    //}

    //public void ChangeMapMusic(int mapid, int music1, int music2, ENUM_MusicMode mode, ENUM_MusicChangeMode changeMode)
    //{
    //	if (!this.m_MapData.ContainsKey(mapid))
    //	{
    //		this.AddMapData(mapid);
    //	}
    //	this.m_MapData[mapid].MusicID1 = music1;
    //	this.m_MapData[mapid].MusicID2 = music2;
    //	this.m_MapData[mapid].emMusicMode = mode;
    //	if (changeMode == ENUM_MusicChangeMode.NEXT_ENTER)
    //	{
    //		return;
    //	}
    //	S_MusicData data = GameDataDB.MusicDB.GetData(music1);
    //	if (data == null)
    //	{
    //		Debug.Log("Music == null");
    //		return;
    //	}
    //	AudioClip music3 = ResourceManager.Instance.GetMusic(data.MusicName);
    //	if (music3 == null)
    //	{
    //		Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //		return;
    //	}
    //	data = GameDataDB.MusicDB.GetData(music2);
    //	if (data == null)
    //	{
    //		Debug.Log("Music == null");
    //		return;
    //	}
    //	AudioClip music4 = ResourceManager.Instance.GetMusic(data.MusicName);
    //	if (music4 == null)
    //	{
    //		Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //		return;
    //	}
    //	if (mode == ENUM_MusicMode.ONCE)
    //	{
    //		MusicSystem.Instance.PlayBackgroundMusicAB(music3, music4, 1f);
    //	}
    //	else if (mode == ENUM_MusicMode.CIRCLE)
    //	{
    //		MusicSystem.Instance.PlayBackgroundMusicAB_ABLoop(music3, music4, 1f);
    //	}
    //	else
    //	{
    //		MusicSystem.Instance.PlayBackgroundMusicAB_BLoop(music3, music4, 1f);
    //	}
    //}

    //public void AddRole(int roleId, bool showMsg)
    //{
    //	if (roleId > 10)
    //	{
    //		Debug.LogError("id error!!");
    //		return;
    //	}
    //	if (showMsg && roleId > 1)
    //	{
    //		string str = this.m_RoldData[roleId - 1].BaseRoleData.FamilyName + this.m_RoldData[roleId - 1].BaseRoleData.Name;
    //		UI_Message.Instance.AddSysMsg(str + GameDataDB.StrID(1060), 3f);
    //	}
    //	this.FlagON(roleId);
    //	this.m_RoldData[roleId - 1].BaseRoleData.IsJoin = true;
    //	this.m_RoldData[roleId - 1].BaseRoleData.IsFight = this.CheckCanFight();
    //	this.UpdatePartyRole();
    //}

    //public void RemoveRole(int roleId, bool showMsg)
    //{
    //	if (roleId > 10)
    //	{
    //		Debug.LogError("id error!!");
    //		return;
    //	}
    //	if (showMsg)
    //	{
    //		string str = this.m_RoldData[roleId - 1].BaseRoleData.FamilyName + this.m_RoldData[roleId - 1].BaseRoleData.Name;
    //		UI_Message.Instance.AddSysMsg(str + GameDataDB.StrID(1061), 3f);
    //	}
    //	this.FlagOFF(roleId);
    //}

    //public void UpdatePartyRole()
    //{
    //	this.m_PartyRole.Clear();
    //	for (int i = 0; i < this.GetMaxTeamRoleCount(); i++)
    //	{
    //		int num = this.m_TeamRoleList[i];
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(num))
    //		{
    //			S_PartyData s_PartyData = new S_PartyData();
    //			s_PartyData.m_ID = num;
    //			s_PartyData.m_IsFight = this.GetRoleData(num).BaseRoleData.IsFight;
    //			this.m_PartyRole.Add(s_PartyData);
    //		}
    //	}
    //	if (UI_Explore.Instance != null)
    //	{
    //		UI_Explore.Instance.InitPlayerUI();
    //	}
    //}

    //public void UpdateMustFightList(List<int> fightList)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		S_PartyData s_PartyData = this.m_PartyRole[i];
    //		s_PartyData.m_MustFight = false;
    //		for (int j = 0; j < fightList.Count; j++)
    //		{
    //			if (s_PartyData.m_ID == fightList[j])
    //			{
    //				s_PartyData.m_MustFight = true;
    //				break;
    //			}
    //		}
    //	}
    //}

    //public void UpdateFightRole()
    //{
    //	for (int i = 0; i < 4; i++)
    //	{
    //		this.m_FightRole[i] = 0;
    //	}
    //	int num = 0;
    //	for (int j = 0; j < this.GetMaxTeamRoleCount(); j++)
    //	{
    //		int num2 = this.m_TeamRoleList[j];
    //		if (Swd6Application.instance.m_GameDataSystem.GetFlag(num2) && this.m_RoldData[j - 1].BaseRoleData.IsFight)
    //		{
    //			this.m_FightRole[num++] = num2;
    //			if (num >= 4)
    //			{
    //				break;
    //			}
    //		}
    //	}
    //}

    //public bool CheckCanFight()
    //{
    //	int num = 0;
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		if (this.m_PartyRole[i].m_IsFight)
    //		{
    //			num++;
    //		}
    //	}
    //	return num < 4;
    //}

    //public bool CheckMustFightRole(int id)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		if (id == this.m_PartyRole[i].m_ID && this.m_PartyRole[i].m_MustFight)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //public bool CheckCanSwitchFightRole(int id)
    //{
    //	int num = 0;
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		if (this.m_PartyRole[i].m_IsFight)
    //		{
    //			num++;
    //		}
    //	}
    //	if (!this.m_RoldData[id - 1].BaseRoleData.IsJoin)
    //	{
    //		return false;
    //	}
    //	if (num == 1 && this.m_RoldData[id - 1].BaseRoleData.IsFight)
    //	{
    //		return false;
    //	}
    //	if (num >= 4 && !this.m_RoldData[id - 1].BaseRoleData.IsFight)
    //	{
    //		return false;
    //	}
    //	this.m_RoldData[id - 1].BaseRoleData.IsFight = !this.m_RoldData[id - 1].BaseRoleData.IsFight;
    //	this.UpdatePartyRole();
    //	return true;
    //}

    //public int GetNumberRoleFromParty()
    //{
    //	return this.m_PartyRole.Count;
    //}

    //public List<S_PartyData> GetPartyRoleList()
    //{
    //	return this.m_PartyRole;
    //}

    //public List<int> GetTeamRoleList()
    //{
    //	return this.m_TeamRoleList;
    //}

    //public int GetMaxTeamRoleCount()
    //{
    //	return this.m_TeamRoleList.Count;
    //}

    //public int GetPartyRoleID(int index)
    //{
    //	if (index >= this.m_PartyRole.Count)
    //	{
    //		return 0;
    //	}
    //	return this.m_PartyRole[index].m_ID;
    //}

    //public List<int> GetActionSkillList()
    //{
    //	return this.m_ActionSkillList;
    //}

    //public bool CheckPartyRole(int partyRole)
    //{
    //	return ((partyRole & 1) != 1 || Swd6Application.instance.m_GameDataSystem.GetFlag(1)) && ((partyRole & 2) != 2 || Swd6Application.instance.m_GameDataSystem.GetFlag(2)) && ((partyRole & 4) != 4 || Swd6Application.instance.m_GameDataSystem.GetFlag(3)) && ((partyRole & 8) != 8 || Swd6Application.instance.m_GameDataSystem.GetFlag(4)) && ((partyRole & 16) != 16 || Swd6Application.instance.m_GameDataSystem.GetFlag(5)) && ((partyRole & 32) != 32 || Swd6Application.instance.m_GameDataSystem.GetFlag(6)) && ((partyRole & 64) != 64 || Swd6Application.instance.m_GameDataSystem.GetFlag(7));
    //}

    //public void CheckRoleToAddParty(int partyRole)
    //{
    //	if ((partyRole & 1) == 1 && !Swd6Application.instance.m_GameDataSystem.GetFlag(1))
    //	{
    //		this.AddRole(1, false);
    //	}
    //	if ((partyRole & 2) == 2 && !Swd6Application.instance.m_GameDataSystem.GetFlag(2))
    //	{
    //		this.AddRole(2, false);
    //	}
    //	if ((partyRole & 4) == 4 && !Swd6Application.instance.m_GameDataSystem.GetFlag(3))
    //	{
    //		this.AddRole(3, false);
    //	}
    //	if ((partyRole & 8) == 8 && !Swd6Application.instance.m_GameDataSystem.GetFlag(4))
    //	{
    //		this.AddRole(4, false);
    //	}
    //	if ((partyRole & 16) == 16 && !Swd6Application.instance.m_GameDataSystem.GetFlag(5))
    //	{
    //		this.AddRole(5, false);
    //	}
    //	if ((partyRole & 32) == 32 && !Swd6Application.instance.m_GameDataSystem.GetFlag(6))
    //	{
    //		this.AddRole(6, false);
    //	}
    //	if ((partyRole & 64) == 64 && !Swd6Application.instance.m_GameDataSystem.GetFlag(7))
    //	{
    //		this.AddRole(7, false);
    //	}
    //}

    //public bool CheckPartyLevel(int level)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData == null)
    //		{
    //			return false;
    //		}
    //		if (roleData.BaseRoleData.Level >= level)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //public int GetPartyMinLevel()
    //{
    //	int num = 0;
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData != null)
    //		{
    //			if (i == 0)
    //			{
    //				num = roleData.BaseRoleData.Level;
    //			}
    //			else
    //			{
    //				num = Mathf.Min(roleData.BaseRoleData.Level, num);
    //			}
    //		}
    //	}
    //	return num;
    //}

    //public void SetPartyLevel(int level)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		if (this.GetRoleData(this.m_PartyRole[i].m_ID) == null)
    //		{
    //		}
    //	}
    //}

    //public void HealRoleHP(int roleId, int hp)
    //{
    //	if (roleId <= 0 || roleId > this.GetMaxID())
    //	{
    //		Debug.Log("HealRoleHP::roleIde錯誤_" + roleId);
    //		return;
    //	}
    //	C_RoleDataEx roleData = this.GetRoleData(roleId);
    //	if (roleData == null)
    //	{
    //		return;
    //	}
    //	roleData.AddHP(hp);
    //}

    //public void HealRoleMP(int roleId, int mp)
    //{
    //	if (roleId <= 0 || roleId > this.GetMaxID())
    //	{
    //		Debug.Log("HealRoleMP::roleIde錯誤_" + roleId);
    //		return;
    //	}
    //	C_RoleDataEx roleData = this.GetRoleData(roleId);
    //	if (roleData == null)
    //	{
    //		return;
    //	}
    //	roleData.AddMP(mp);
    //}

    //public void HealPartyHP(int hp)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		roleData.AddHP(hp);
    //	}
    //}

    //public void HealPartyMP(int mp)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		roleData.AddMP(mp);
    //	}
    //}

    //public void AddPartyExp(int exp)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		S_LevelUpInfo levelUpInfo = new S_LevelUpInfo();
    //		if (this.AddRoleExp(this.m_PartyRole[i].m_ID, exp, ref levelUpInfo))
    //		{
    //			string msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1064);
    //			UI_Message.Instance.AddSysMsg(msg, 3f);
    //			this.ShowLearnSkillMsg(this.m_PartyRole[i].m_ID, levelUpInfo);
    //		}
    //	}
    //}

    //public void ShowLearnSkillMsg(int id, S_LevelUpInfo levelUpInfo)
    //{
    //	string msg = string.Empty;
    //	C_RoleDataEx roleData = this.GetRoleData(id);
    //	if (roleData == null)
    //	{
    //		return;
    //	}
    //	if (levelUpInfo.LearnSkillList.Count > 0)
    //	{
    //		for (int i = 0; i < levelUpInfo.LearnSkillList.Count; i++)
    //		{
    //			S_Skill data = GameDataDB.SkillDB.GetData(levelUpInfo.LearnSkillList[i]);
    //			if (data != null)
    //			{
    //				msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1002) + data.Name;
    //				UI_Message.Instance.AddSysMsg(msg, 3f);
    //			}
    //		}
    //	}
    //}

    //public bool CheckEquipItem(int roldId, int itemId)
    //{
    //	if (!Swd6Application.instance.m_GameDataSystem.GetFlag(roldId))
    //	{
    //		return false;
    //	}
    //	C_RoleDataEx roleData = this.GetRoleData(roldId);
    //	return roleData != null && roleData.CheckEquipItem(itemId);
    //}

    //public bool CheckPartyEquipItem(int itemId)
    //{
    //	for (int i = 0; i < this.m_PartyRole.Count; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //		if (roleData != null)
    //		{
    //			if (roleData.CheckEquipItem(itemId))
    //			{
    //				return true;
    //			}
    //		}
    //	}
    //	return false;
    //}

    //public void RemoveDLCItem()
    //{
    //	if (!Swd6Application.instance.CheckDLCItem(100))
    //	{
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("remove dlc item!!");
    //		}
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(12);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(32);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(52);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(72);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(301);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(302);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(303);
    //		Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(304);
    //	}
    //	else
    //	{
    //		this.AddDLCItem();
    //	}
    //}

    //public void CheckDLCItem()
    //{
    //	List<int> teamRoleList = this.GetTeamRoleList();
    //	for (int i = 0; i < this.GetMaxTeamRoleCount(); i++)
    //	{
    //		int id = teamRoleList[i];
    //		C_RoleDataEx roleData = this.GetRoleData(id);
    //		if (roleData != null)
    //		{
    //			int num = 8;
    //			for (int j = 0; j < num; j++)
    //			{
    //				ENUM_EquipPosition eNUM_EquipPosition = (ENUM_EquipPosition)j;
    //				ItemData itemData = roleData.GetEquipItemData(eNUM_EquipPosition);
    //				if (itemData != null)
    //				{
    //					if (!Swd6Application.instance.CheckDLCItem(100) && (itemData.ID == 12 || itemData.ID == 32 || itemData.ID == 52 || itemData.ID == 72 || itemData.ID == 301 || itemData.ID == 302 || itemData.ID == 303 || itemData.ID == 304))
    //					{
    //						if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //						{
    //							Debug.Log("remomve dlc equip_" + itemData.ID);
    //						}
    //						Swd6Application.instance.m_ItemSystem.RemoveItemByItemID(itemData.ID);
    //						roleData.BaseRoleData.EquipID[j] = 0;
    //						if (eNUM_EquipPosition == ENUM_EquipPosition.Weapon)
    //						{
    //							S_StartRoleData data = GameDataDB.StartRoleDB.GetData(id);
    //							if (data != null)
    //							{
    //								itemData = Swd6Application.instance.m_ItemSystem.GetDataByItemID(data.Equip[0]);
    //								if (itemData != null)
    //								{
    //									itemData.Equip = true;
    //									itemData.EquipCount++;
    //									roleData.BaseRoleData.EquipID[j] = itemData.SerialID;
    //								}
    //								else
    //								{
    //									itemData = Swd6Application.instance.m_ItemSystem.AddItem(data.Equip[0], 1, ENUM_ItemState.Old, false);
    //									if (itemData != null)
    //									{
    //										itemData.Equip = true;
    //										itemData.EquipCount++;
    //										roleData.BaseRoleData.EquipID[j] = itemData.SerialID;
    //									}
    //								}
    //							}
    //						}
    //						if (eNUM_EquipPosition == ENUM_EquipPosition.CosCloth)
    //						{
    //							S_StartRoleData data2 = GameDataDB.StartRoleDB.GetData(id);
    //							if (data2 != null)
    //							{
    //								itemData = Swd6Application.instance.m_ItemSystem.GetDataByItemID(data2.Equip[7]);
    //								if (itemData != null)
    //								{
    //									itemData.Equip = true;
    //									itemData.EquipCount++;
    //									roleData.BaseRoleData.EquipID[j] = itemData.SerialID;
    //								}
    //								else
    //								{
    //									itemData = Swd6Application.instance.m_ItemSystem.AddItem(data2.Equip[7], 1, ENUM_ItemState.Old, false);
    //									if (itemData != null)
    //									{
    //										itemData.Equip = true;
    //										itemData.EquipCount++;
    //										roleData.BaseRoleData.EquipID[j] = itemData.SerialID;
    //									}
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}
    //	this.RemoveDLCItem();
    //}

    //public int GetEquipRole(int partyRole)
    //{
    //	if ((partyRole & 1) == 1)
    //	{
    //		return 1;
    //	}
    //	if ((partyRole & 2) == 2)
    //	{
    //		return 2;
    //	}
    //	if ((partyRole & 4) == 4)
    //	{
    //		return 3;
    //	}
    //	if ((partyRole & 8) == 8)
    //	{
    //		return 4;
    //	}
    //	if ((partyRole & 16) == 16)
    //	{
    //		return 5;
    //	}
    //	if ((partyRole & 32) == 32)
    //	{
    //		return 6;
    //	}
    //	if ((partyRole & 64) == 64)
    //	{
    //		return 7;
    //	}
    //	return 0;
    //}

    //public string ReplaceRoleName(string text)
    //{
    //	if (Swd6Application.instance.IsDLC())
    //	{
    //		text = text.Replace("#", string.Empty);
    //		return text;
    //	}
    //	if (text == null)
    //	{
    //		return text;
    //	}
    //	if (text.Length == 0)
    //	{
    //		return text;
    //	}
    //	for (int i = 0; i < 4; i++)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(i + 1);
    //		if (roleData == null)
    //		{
    //			return text;
    //		}
    //		for (int j = 1; j <= 2; j++)
    //		{
    //			string text2 = GameDataDB.StrID(i * 10 + j);
    //			if (text2 != null)
    //			{
    //				if (text2.Length != 0)
    //				{
    //					if (text.Contains(text2))
    //					{
    //						string newValue;
    //						if (j == 1)
    //						{
    //							newValue = roleData.BaseRoleData.FamilyName;
    //						}
    //						else
    //						{
    //							newValue = roleData.BaseRoleData.Name;
    //						}
    //						text = text.Replace(text2, newValue);
    //					}
    //				}
    //			}
    //		}
    //		for (int k = 3; k <= 7; k++)
    //		{
    //			string text3 = GameDataDB.StrID(i * 10 + k);
    //			if (text3 != null)
    //			{
    //				if (text.Contains(text3))
    //				{
    //					string name = roleData.BaseRoleData.Name;
    //					if (name != null)
    //					{
    //						if (name.Length != 0)
    //						{
    //							string newValue2 = name.Substring(name.Length - 1);
    //							string text4 = GameDataDB.StrID(i * 10 + k + 50);
    //							if (text4 != null)
    //							{
    //								string text5 = GameDataDB.StrID(i * 10 + 8);
    //								if (text5 != null)
    //								{
    //									text4 = text4.Replace(text5, newValue2);
    //									text = text.Replace(text3, text4);
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}
    //	return text;
    //}

    //public void Save(GameFileStream stream)
    //{
    //	int count = this.m_MapData.Count;
    //	stream.WriteInt(count);
    //	foreach (S_MapData current in this.m_MapData.Values)
    //	{
    //		stream.WriteInt(current.GUID);
    //		stream.WriteInt(current.MusicID1);
    //		stream.WriteInt(current.MusicID2);
    //		stream.WriteInt((int)current.emMusicMode);
    //		stream.WriteInt(current.SkyID);
    //	}
    //}

    //public void Load(GameFileStream stream)
    //{
    //	int num = stream.ReadInt();
    //	this.ClearMapData();
    //	for (int i = 0; i < num; i++)
    //	{
    //		S_MapData s_MapData = new S_MapData();
    //		S_MapMusicData s_MapMusicData = new S_MapMusicData();
    //		s_MapData.GUID = stream.ReadInt();
    //		s_MapData.MusicID1 = stream.ReadInt();
    //		s_MapData.MusicID2 = stream.ReadInt();
    //		s_MapData.emMusicMode = (ENUM_MusicMode)stream.ReadInt();
    //		s_MapData.SkyID = stream.ReadInt();
    //		S_MapData s_MapData2 = this.AddMapData(s_MapData.GUID);
    //		if (s_MapData2 != null)
    //		{
    //			s_MapData2 = GameDataDB.MapDB.GetData(s_MapData.GUID);
    //			if (s_MapData2 != null)
    //			{
    //				s_MapMusicData.GUID = s_MapData2.GUID;
    //				s_MapMusicData.MusicID1 = s_MapData2.MusicID1;
    //				s_MapMusicData.MusicID2 = s_MapData2.MusicID2;
    //				s_MapMusicData.emMusicMode = s_MapData2.emMusicMode;
    //				s_MapMusicData.SkyID = s_MapData2.SkyID;
    //				this.m_MapMusicData.Add(s_MapMusicData.GUID, s_MapMusicData);
    //			}
    //			s_MapData2.MusicID1 = s_MapData.MusicID1;
    //			s_MapData2.MusicID2 = s_MapData.MusicID2;
    //			s_MapData2.emMusicMode = s_MapData.emMusicMode;
    //			s_MapData2.SkyID = s_MapData.SkyID;
    //		}
    //	}
    //	this.UpdatePartyRole();
    //}
}
