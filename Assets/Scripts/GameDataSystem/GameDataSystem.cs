using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameDataSystem
{
    public string m_GameVersion;

    /// <summary>
    /// 金钱
    /// </summary>
    private int m_Money;

    private int m_SoulPoint;

    private int m_SoulStone;

    /// <summary>
    /// 耐力
    /// </summary>
    public int m_Stamina;

    public int m_Sense;

    public int m_FightScore;

    public int m_LegendPoint;

    public int m_CompleteGame;

    public int m_MaxCompleteGame;

    public int m_PlayGameCount;

    /// <summary>
    /// 玩家ID
    /// </summary>
    public int m_PlayerID;

    public int m_BreakBoxTimes;

    public int m_SelectPet;

    public int m_FightPlayerID;

    public int m_DefaultPlayerID;

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

    //private Dictionary<int, S_MapMusicData> m_MapMusicData;

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
            //Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.GetMoney, 0, 0, 0, this.m_Money);
            //Swd6Application.instance.m_QuestSystem.Dirty();
        }
    }

    public int SoulPoint
    {
        get
        {
            return this.m_SoulPoint;
        }
        set
        {
            this.m_SoulPoint = value;
            if (this.m_SoulPoint > 3000)
            {
                this.m_SoulPoint = 3000;
            }
            if (this.m_SoulPoint < 0)
            {
                this.m_SoulPoint = 0;
            }
        }
    }

    public int SoulStone
    {
        get
        {
            return this.m_SoulStone;
        }
        set
        {
            this.m_SoulStone = value;
            if (this.m_SoulStone < 0)
            {
                this.m_SoulStone = 0;
            }
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
        //this.m_MapMusicData = new Dictionary<int, S_MapMusicData>();
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

    /// <summary>
    /// 初始队伍角色列表
    /// </summary>
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

    /// <summary>
    /// 初始化角色数据
    /// </summary>
    public void InitRoleData()
    {
        this.Reset();
        GameEntry.Instance.InitNewGame();
        this.InitTeamRoleList();
        for (int j = 0; j < this.m_TeamRoleList.Count; j++)
        {
            this.SetStartData(this.m_TeamRoleList[j], this.m_TeamRoleList[j], this.m_TeamRoleList[j]);
        }
        GameEntry.Instance.m_SkillSystem.InitDefaultHotKeySkill();
        this.m_RoldData[0].BaseRoleData.IsJoin = true;
        this.m_DefaultPlayerID = 1;
        this.AddRole(1, false);
        ////NormalSetting normalSetting = Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting();
        //if (normalSetting.m_bEnableTeach)//应该是教程
        //{
        //    this.FlagON(75);
        //    this.FlagON(76);
        //    this.FlagON(77);
        //}
        //this.AddDLCItem();

        this.m_PlayerID = this.m_DefaultPlayerID;
        this.m_FightPlayerID = this.m_DefaultPlayerID;
        this.FlagON(24);
    }

    //	public void InitExRoleData(int chapId)
    //	{
    //		this.Reset();
    //		if (this.m_ChapID == chapId)
    //		{
    //			return;
    //		}
    //		this.m_ChapID = chapId;
    //		Swd6Application.instance.InitNewGame();
    //		this.InitTeamRoleList(chapId);
    //		switch (this.m_ChapID)
    //		{
    //		case 100:
    //			for (int i = 0; i < this.m_TeamRoleList.Count; i++)
    //			{
    //				this.SetStartData(this.m_TeamRoleList[i], this.m_TeamRoleList[i], this.m_TeamRoleList[i]);
    //			}
    //			Swd6Application.instance.m_InheritSystem.SetInheritData();
    //			Debug.Log("ChapEx_100");
    //			this.m_RoldData[0].BaseRoleData.IsJoin = true;
    //			this.m_DefaultPlayerID = 1;
    //			this.AddRole(1, false);
    //			break;
    //		}
    //		this.m_PlayerID = this.m_DefaultPlayerID;
    //		this.FlagON(24);
    //	}

    public int GetMinID()
    {      
        return 1;      
    }

    public int GetMaxID()
    {      
                return 5;      
    }

    //	public int GetMaxRoleCountByChapter(int chapId)
    //	{
    //		switch (chapId)
    //		{
    //		case 100:
    //			return 5;
    //		case 101:
    //			return 3;
    //		default:
    //			return 0;
    //		}
    //	}

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
        this.m_RoldData[id - 1].CalRoleAttr();
    }

    //	public void SetBaseRoleData(int id, S_BaseRoleData roleData)
    //	{
    //		if (id > this.GetMaxID())
    //		{
    //			Debug.LogError("id error!!");
    //			return;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.ID = roleData.ID;
    //		this.m_RoldData[id - 1].BaseRoleData.FamilyName = roleData.FamilyName;
    //		this.m_RoldData[id - 1].BaseRoleData.Name = roleData.Name;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxHP = roleData.MaxHP;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxMP = roleData.MaxMP;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxAP = roleData.MaxAP;
    //		this.m_RoldData[id - 1].BaseRoleData.HP = roleData.HP;
    //		this.m_RoldData[id - 1].BaseRoleData.MP = roleData.MP;
    //		this.m_RoldData[id - 1].BaseRoleData.AP = roleData.AP;
    //		this.m_RoldData[id - 1].BaseRoleData.Str = roleData.Str;
    //		this.m_RoldData[id - 1].BaseRoleData.Mag = roleData.Mag;
    //		this.m_RoldData[id - 1].BaseRoleData.Sta = roleData.Sta;
    //		this.m_RoldData[id - 1].BaseRoleData.Air = roleData.Air;
    //		this.m_RoldData[id - 1].BaseRoleData.Agi = roleData.Agi;
    //		this.m_RoldData[id - 1].BaseRoleData.Block = roleData.Block;
    //		this.m_RoldData[id - 1].BaseRoleData.Luck = roleData.Luck;
    //		this.m_RoldData[id - 1].BaseRoleData.Critical = roleData.Critical;
    //		this.m_RoldData[id - 1].BaseRoleData.Mind = roleData.Mind;
    //		this.m_RoldData[id - 1].BaseRoleData.emElemntType = roleData.emElemntType;
    //		this.m_RoldData[id - 1].BaseRoleData.Element = roleData.Element;
    //		for (int i = 0; i < roleData.EquipID.Length; i++)
    //		{
    //			this.m_RoldData[id - 1].BaseRoleData.EquipID[i] = roleData.EquipID[i];
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.CosClothID = roleData.CosClothID;
    //		this.m_RoldData[id - 1].BaseRoleData.Level = roleData.Level;
    //		this.m_RoldData[id - 1].BaseRoleData.TotalExp = roleData.TotalExp;
    //		this.m_RoldData[id - 1].BaseRoleData.SevenRingGrid = roleData.SevenRingGrid;
    //		this.m_RoldData[id - 1].BaseRoleData.SevenRingExp = roleData.SevenRingExp;
    //		this.m_RoldData[id - 1].BaseRoleData.SevenRingLevel = roleData.SevenRingLevel;
    //		this.m_RoldData[id - 1].BaseRoleData.IsJoin = roleData.IsJoin;
    //		this.m_RoldData[id - 1].BaseRoleData.IsFight = roleData.IsFight;
    //		this.m_RoldData[id - 1].BaseRoleData.IsDeath = roleData.IsDeath;
    //		this.m_RoldData[id - 1].BaseRoleData.Favorability = roleData.Favorability;
    //		this.m_RoldData[id - 1].BaseRoleData.AutoFightAI = roleData.AutoFightAI;
    //	}

    //	public void SetInheritBaseRoleData(int id, S_BaseRoleData roleData)
    //	{
    //		if (id > this.GetMaxID())
    //		{
    //			Debug.LogError("SetInheritBaseRoleData id error!!");
    //			return;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.ID = roleData.ID;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxHP = roleData.MaxHP;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxMP = roleData.MaxMP;
    //		this.m_RoldData[id - 1].BaseRoleData.MaxAP = roleData.MaxAP;
    //		this.m_RoldData[id - 1].BaseRoleData.HP = roleData.HP;
    //		this.m_RoldData[id - 1].BaseRoleData.MP = roleData.MP;
    //		this.m_RoldData[id - 1].BaseRoleData.AP = roleData.AP;
    //		this.m_RoldData[id - 1].BaseRoleData.Str = roleData.Str;
    //		this.m_RoldData[id - 1].BaseRoleData.Mag = roleData.Mag;
    //		this.m_RoldData[id - 1].BaseRoleData.Sta = roleData.Sta;
    //		this.m_RoldData[id - 1].BaseRoleData.Air = roleData.Air;
    //		this.m_RoldData[id - 1].BaseRoleData.Agi = roleData.Agi;
    //		this.m_RoldData[id - 1].BaseRoleData.Block = roleData.Block;
    //		this.m_RoldData[id - 1].BaseRoleData.Luck = roleData.Luck;
    //		this.m_RoldData[id - 1].BaseRoleData.Critical = roleData.Critical;
    //		this.m_RoldData[id - 1].BaseRoleData.Mind = roleData.Mind;
    //		this.m_RoldData[id - 1].BaseRoleData.emElemntType = roleData.emElemntType;
    //		for (int i = 0; i < roleData.Element.Length; i++)
    //		{
    //			this.m_RoldData[id - 1].BaseRoleData.Element = roleData.Element;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.CosClothID = roleData.CosClothID;
    //		this.m_RoldData[id - 1].BaseRoleData.TotalExp = roleData.TotalExp;
    //		this.m_RoldData[id - 1].BaseRoleData.Level = roleData.Level;
    //		for (int j = 0; j < roleData.Favorability.Length; j++)
    //		{
    //			this.m_RoldData[id - 1].BaseRoleData.Favorability[j].ID = roleData.Favorability[j].ID;
    //			this.m_RoldData[id - 1].BaseRoleData.Favorability[j].Value = roleData.Favorability[j].Value;
    //		}
    //		for (int k = 0; k < roleData.AutoFightAI.Length; k++)
    //		{
    //			this.m_RoldData[id - 1].BaseRoleData.AutoFightAI = roleData.AutoFightAI;
    //		}
    //		this.m_RoldData[id - 1].CalRoleAttr();
    //		this.m_RoldData[id - 1].SetFullHP();
    //		this.m_RoldData[id - 1].SetFullMP();
    //		this.m_RoldData[id - 1].SetFullAP();
    //	}

    //	public void SetInheritSevenRing(int id, S_BaseRoleData roleData)
    //	{
    //		if (id > this.GetMaxID())
    //		{
    //			Debug.LogError("SetInheritBaseRoleData id error!!");
    //			return;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.SevenRingExp = roleData.SevenRingExp;
    //		this.m_RoldData[id - 1].BaseRoleData.SevenRingLevel = roleData.SevenRingLevel;
    //	}

    //	public void ReLoadObjData()
    //	{
    //		for (int i = 0; i < this.GetMaxTeamRoleCount(); i++)
    //		{
    //			this.m_RoldData[this.m_TeamRoleList[i] - 1].CalRoleAttr();
    //		}
    //	}

    public void Update()
    {
        this.m_PlayTimes += Time.deltaTime;
    }

    public bool GetFlag(int flag)
    {
        return this.m_GameFlag.Get(flag);
    }

    public void FlagON(int flag)
    {
        this.m_GameFlag.ON(flag);
        if (flag >= this.GetMinID() && flag <= this.GetMaxID())
        {
            if (!this.m_RoldData[flag - 1].BaseRoleData.IsJoin && flag != 7)
            {
                //UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1040 + flag - 1), 3f);
            }
            
            this.FlagON(30 + flag);            
            this.m_RoldData[flag - 1].BaseRoleData.IsJoin = true;
            this.UpdatePartyRole();
            Debug.Log("开启阵型");
            GameEntry.Instance.m_FormationSystem.UnlockFormation(flag);
            GameEntry.Instance.m_FormationSystem.AutoSetUnitData();
        }
        //if (Swd6Application.instance.m_QuestSystem != null)
        //{
        //    Swd6Application.instance.m_QuestSystem.Dirty();
        //}
    }

    public void FlagOFF(int flag)
    {
        this.m_GameFlag.OFF(flag);
        if (flag >= this.GetMinID() && flag <= this.GetMaxID())
        {
            this.m_RoldData[flag - 1].BaseRoleData.IsFight = false;
            this.UpdatePartyRole();
        }
        if (GameEntry.Instance.m_QuestSystem != null)
        {
            GameEntry.Instance.m_QuestSystem.Dirty();
        }
    }

    //	public void FlagSet(int flag, bool val)
    //	{
    //		this.m_GameFlag.Set(flag, val);
    //	}

    /// <summary>
    /// 设置开始数据
    /// </summary>
    /// <param name="roleId">角色ID</param>
    /// <param name="dateId">数据ID</param>
    /// <param name="levelId">等级ID</param>
    /// <returns></returns>
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

    //	public void LevelUp(int roleId, int level, bool autoSetExp)
    //	{
    //		this.m_RoldData[roleId - 1].BaseRoleData.SetLevelData(level, autoSetExp);
    //		this.m_RoldData[roleId - 1].CalRoleAttr();
    //		this.m_RoldData[roleId - 1].SetFullHP();
    //		this.m_RoldData[roleId - 1].SetFullMP();
    //		this.m_RoldData[roleId - 1].SetFullAP();
    //		Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.Level, roleId, 0, 0, 1);
    //	}

    //	public bool AddRoleExp(int roleId, int exp)
    //	{
    //		bool result = false;
    //		if (this.m_RoldData[roleId - 1].BaseRoleData.Level >= 99)
    //		{
    //			return false;
    //		}
    //		this.m_RoldData[roleId - 1].BaseRoleData.TotalExp += exp;
    //		while (true)
    //		{
    //			S_Level levelData = this.GetLevelData(roleId, this.m_RoldData[roleId - 1].BaseRoleData.Level);
    //			if (this.m_RoldData[roleId - 1].BaseRoleData.TotalExp < levelData.NextExp)
    //			{
    //				break;
    //			}
    //			this.LevelUp(roleId, this.m_RoldData[roleId - 1].BaseRoleData.Level + 1, false);
    //			result = true;
    //		}
    //		return result;
    //	}

    //	public string GetPlayTimeText(float playTime)
    //	{
    //		int num = (int)playTime;
    //		int num2 = num / 3600;
    //		int num3 = num % 3600 / 60 / 10;
    //		int num4 = num % 3600 / 60 % 10;
    //		int num5 = num % 3600 % 60 / 10;
    //		int num6 = num % 3600 % 60 % 10;
    //		return string.Concat(new object[]
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

    public S_MapData AddMapData(int mapid)
    {
        S_MapData s_MapData;
        if (!this.m_MapData.ContainsKey(mapid))
        {
            s_MapData = GameDataDB.MapDB.GetData(mapid);
            if (s_MapData != null)
            {
                this.m_MapData.Add(mapid, s_MapData);
            }
        }
        else
        {
            s_MapData = this.m_MapData[mapid];
        }
        return s_MapData;
    }

    public S_MapData GetMapData(int mapid)
    {
        if (!this.m_MapData.ContainsKey(mapid))
        {
            this.AddMapData(mapid);
        }
        if (this.m_MapData.ContainsKey(mapid))
        {
            return this.m_MapData[mapid];
        }
        return null;
    }

    public void ClearMapData()
    {
        foreach (S_MapData current in this.m_MapData.Values)
        {
            //if (this.m_MapMusicData.ContainsKey(current.GUID))
            //{
            //    S_MapMusicData s_MapMusicData = this.m_MapMusicData[current.GUID];
            //    current.MusicID1 = s_MapMusicData.MusicID1;
            //    current.MusicID2 = s_MapMusicData.MusicID2;
            //    current.emMusicMode = s_MapMusicData.emMusicMode;
            //}
        }
        this.m_MapData.Clear();
        //this.m_MapMusicData.Clear();
    }

    //	public void ChangeMapMusic(int mapid, int music1, int music2, ENUM_MusicMode mode, ENUM_MusicChangeMode changeMode)
    //	{
    //		if (!this.m_MapData.ContainsKey(mapid))
    //		{
    //			this.AddMapData(mapid);
    //		}
    //		this.m_MapData[mapid].MusicID1 = music1;
    //		this.m_MapData[mapid].MusicID2 = music2;
    //		this.m_MapData[mapid].emMusicMode = mode;
    //		if (changeMode == ENUM_MusicChangeMode.NEXT_ENTER)
    //		{
    //			return;
    //		}
    //		S_MusicData data = GameDataDB.MusicDB.GetData(music1);
    //		if (data == null)
    //		{
    //			Debug.Log("Music == null");
    //			return;
    //		}
    //		AudioClip audioClip = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip == null)
    //		{
    //			Debug.Log("LoadMusic1_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		data = GameDataDB.MusicDB.GetData(music2);
    //		if (data == null)
    //		{
    //			Debug.Log("Music == null");
    //			return;
    //		}
    //		AudioClip audioClip2 = MusicGenerator.GetAudioClip(data.MusicName);
    //		if (audioClip2 == null)
    //		{
    //			Debug.Log("LoadMusic2_" + data.MusicName + "不存在");
    //			return;
    //		}
    //		if (mode == ENUM_MusicMode.ONCE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB(audioClip, audioClip2, 0.5f, 1f);
    //			return;
    //		}
    //		if (mode == ENUM_MusicMode.CIRCLE)
    //		{
    //			MusicControlSystem.Fade_PlayBackgroundMusicAB_ABLoop(audioClip, audioClip2, 0.5f, 1f);
    //			return;
    //		}
    //		MusicControlSystem.Fade_PlayBackgroundMusicAB_BLoop(audioClip, audioClip2, 0.5f, 1f);
    //	}

    /// <summary>
    /// 加人角色
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="showMsg"></param>
    public void AddRole(int roleId, bool showMsg)
    {
        if (roleId > 10)
        {
            Debug.LogError("id error!!");
            return;
        }
        if (showMsg && roleId > 1)
        {
            string str = this.m_RoldData[roleId - 1].BaseRoleData.FamilyName + this.m_RoldData[roleId - 1].BaseRoleData.Name;
            //UI_OkCancelBox.Instance.AddSysMsg(str + GameDataDB.StrID(1060), 3f);
        }
        this.FlagON(roleId);
        this.m_RoldData[roleId - 1].BaseRoleData.IsJoin = true;
        //this.m_RoldData[roleId - 1].BaseRoleData.IsFight = this.CheckCanFight();
        this.UpdatePartyRole();
    }

    //	public void RemoveRole(int roleId, bool showMsg)
    //	{
    //		if (roleId > 10)
    //		{
    //			Debug.LogError("id error!!");
    //			return;
    //		}
    //		if (showMsg)
    //		{
    //			string str = this.m_RoldData[roleId - 1].BaseRoleData.FamilyName + this.m_RoldData[roleId - 1].BaseRoleData.Name;
    //			UI_OkCancelBox.Instance.AddSysMsg(str + GameDataDB.StrID(1061), 3f);
    //		}
    //		this.FlagOFF(roleId);
    //		if (roleId == this.m_PlayerID)
    //		{
    //			this.m_PlayerID = this.m_DefaultPlayerID;
    //			UI_Explore.Instance.SetActionSkill(this.m_DefaultPlayerID);
    //		}
    //		if (showMsg)
    //		{
    //			bool flag = false;
    //			for (ENUM_EquipPosition eNUM_EquipPosition = ENUM_EquipPosition.Accessories; eNUM_EquipPosition <= ENUM_EquipPosition.Story; eNUM_EquipPosition++)
    //			{
    //				int num = (int)eNUM_EquipPosition;
    //				if (this.m_RoldData[roleId - 1].BaseRoleData.EquipID[num] > 0)
    //				{
    //					ItemData dataBySerialID = Swd6Application.instance.m_ItemSystem.GetDataBySerialID(this.m_RoldData[roleId - 1].BaseRoleData.EquipID[num]);
    //					if (dataBySerialID != null)
    //					{
    //						dataBySerialID.EquipCount--;
    //						dataBySerialID.Equip = false;
    //						this.m_RoldData[roleId - 1].BaseRoleData.EquipID[num] = 0;
    //						flag = true;
    //					}
    //				}
    //			}
    //			if (flag)
    //			{
    //				string str2 = this.m_RoldData[roleId - 1].BaseRoleData.FamilyName + this.m_RoldData[roleId - 1].BaseRoleData.Name;
    //				UI_OkCancelBox.Instance.AddSysMsg(str2 + GameDataDB.StrID(1065), 3f);
    //			}
    //		}
    //	}

    /// <summary>
    /// 更新伙伴
    /// </summary>
    public void UpdatePartyRole()
    {
        this.m_PartyRole.Clear();
        for (int i = 0; i < this.GetMaxTeamRoleCount(); i++)
        {
            int num = this.m_TeamRoleList[i];
            if (GameEntry.Instance.m_GameDataSystem.GetFlag(num))
            {
                S_PartyData s_PartyData = new S_PartyData();
                s_PartyData.m_ID = num;
                s_PartyData.m_IsFight = this.GetRoleData(num).BaseRoleData.IsFight;
                this.m_PartyRole.Add(s_PartyData);
            }
        }
    }

    //	public void UpdateMustFightList(List<int> fightList)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			S_PartyData s_PartyData = this.m_PartyRole[i];
    //			s_PartyData.m_MustFight = false;
    //			for (int j = 0; j < fightList.Count; j++)
    //			{
    //				if (s_PartyData.m_ID == fightList[j])
    //				{
    //					s_PartyData.m_MustFight = true;
    //					break;
    //				}
    //			}
    //		}
    //	}

    //	public void UpdateFightRole()
    //	{
    //		for (int i = 0; i < 3; i++)
    //		{
    //			this.m_FightRole[i] = 0;
    //		}
    //		int num = 0;
    //		for (int j = 0; j < this.GetMaxTeamRoleCount(); j++)
    //		{
    //			int num2 = this.m_TeamRoleList[j];
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(num2) && this.m_RoldData[j - 1].BaseRoleData.IsFight)
    //			{
    //				this.m_FightRole[num++] = num2;
    //				if (num >= 3)
    //				{
    //					return;
    //				}
    //			}
    //		}
    //	}

    public bool CheckCanFight()
    {
        int num = 0;
        for (int i = 0; i < this.m_PartyRole.Count; i++)
        {
            if (this.m_PartyRole[i].m_IsFight)
            {
                num++;
            }
        }
        return num < 3;
    }

    //	public bool CheckMustFightRole(int id)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			if (id == this.m_PartyRole[i].m_ID && this.m_PartyRole[i].m_MustFight)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public bool CheckCanSwitchFightRole(int id)
    //	{
    //		int num = 0;
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			if (this.m_PartyRole[i].m_IsFight)
    //			{
    //				num++;
    //			}
    //		}
    //		if (!this.m_RoldData[id - 1].BaseRoleData.IsJoin)
    //		{
    //			return false;
    //		}
    //		if (num == 1 && this.m_RoldData[id - 1].BaseRoleData.IsFight)
    //		{
    //			return false;
    //		}
    //		if (num >= 3 && !this.m_RoldData[id - 1].BaseRoleData.IsFight)
    //		{
    //			return false;
    //		}
    //		this.m_RoldData[id - 1].BaseRoleData.IsFight = !this.m_RoldData[id - 1].BaseRoleData.IsFight;
    //		this.UpdatePartyRole();
    //		return true;
    //	}

    public int GetNumberRoleFromParty()
    {
        return this.m_PartyRole.Count;
    }

    //	public List<S_PartyData> GetPartyRoleList()
    //	{
    //		return this.m_PartyRole;
    //	}

    //	public List<int> GetTeamRoleList()
    //	{
    //		return this.m_TeamRoleList;
    //	}

    public int GetMaxTeamRoleCount()
    {
        return this.m_TeamRoleList.Count;
    }

    public int GetPartyRoleID(int index)
    {
        if (index >= this.m_PartyRole.Count)
        {
            return 0;
        }
        return this.m_PartyRole[index].m_ID;
    }

    //	public List<int> GetActionSkillList()
    //	{
    //		return this.m_ActionSkillList;
    //	}

    //	public bool CheckPartyRole(int partyRole)
    //	{
    //		return ((partyRole & 1) != 1 || Swd6Application.instance.m_GameDataSystem.GetFlag(1)) && ((partyRole & 2) != 2 || Swd6Application.instance.m_GameDataSystem.GetFlag(2)) && ((partyRole & 4) != 4 || Swd6Application.instance.m_GameDataSystem.GetFlag(3)) && ((partyRole & 8) != 8 || Swd6Application.instance.m_GameDataSystem.GetFlag(4)) && ((partyRole & 16) != 16 || Swd6Application.instance.m_GameDataSystem.GetFlag(5)) && ((partyRole & 32) != 32 || Swd6Application.instance.m_GameDataSystem.GetFlag(6)) && ((partyRole & 64) != 64 || Swd6Application.instance.m_GameDataSystem.GetFlag(7));
    //	}

    //	public void CheckRoleToAddParty(int partyRole)
    //	{
    //		if ((partyRole & 1) == 1 && !Swd6Application.instance.m_GameDataSystem.GetFlag(1))
    //		{
    //			this.AddRole(1, false);
    //		}
    //		if ((partyRole & 2) == 2 && !Swd6Application.instance.m_GameDataSystem.GetFlag(2))
    //		{
    //			this.AddRole(2, false);
    //		}
    //		if ((partyRole & 4) == 4 && !Swd6Application.instance.m_GameDataSystem.GetFlag(3))
    //		{
    //			this.AddRole(3, false);
    //		}
    //		if ((partyRole & 8) == 8 && !Swd6Application.instance.m_GameDataSystem.GetFlag(4))
    //		{
    //			this.AddRole(4, false);
    //		}
    //		if ((partyRole & 16) == 16 && !Swd6Application.instance.m_GameDataSystem.GetFlag(5))
    //		{
    //			this.AddRole(5, false);
    //		}
    //		if ((partyRole & 32) == 32 && !Swd6Application.instance.m_GameDataSystem.GetFlag(6))
    //		{
    //			this.AddRole(6, false);
    //		}
    //		if ((partyRole & 64) == 64 && !Swd6Application.instance.m_GameDataSystem.GetFlag(7))
    //		{
    //			this.AddRole(7, false);
    //		}
    //	}

    //	public bool CheckPartyLevel(int level)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData == null)
    //			{
    //				return false;
    //			}
    //			if (roleData.BaseRoleData.Level >= level)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public int GetPartyMinLevel()
    //	{
    //		int num = 0;
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData != null)
    //			{
    //				if (i == 0)
    //				{
    //					num = roleData.BaseRoleData.Level;
    //				}
    //				else
    //				{
    //					num = Mathf.Min(roleData.BaseRoleData.Level, num);
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	public void SetPartyLevel(int level)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData != null)
    //			{
    //				this.LevelUp(i, level, true);
    //			}
    //		}
    //	}

    //	public void HealRoleHP(int roleId, int hp)
    //	{
    //		if (roleId <= 0 || roleId > this.GetMaxID())
    //		{
    //			Debug.Log("HealRoleHP::roleIde錯誤_" + roleId);
    //			return;
    //		}
    //		C_RoleDataEx roleData = this.GetRoleData(roleId);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		roleData.AddHP(hp);
    //	}

    //	public void HealRoleMP(int roleId, int mp)
    //	{
    //		if (roleId <= 0 || roleId > this.GetMaxID())
    //		{
    //			Debug.Log("HealRoleMP::roleIde錯誤_" + roleId);
    //			return;
    //		}
    //		C_RoleDataEx roleData = this.GetRoleData(roleId);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		roleData.AddMP(mp);
    //	}

    //	public void HealRoleAP(int roleId, int ap)
    //	{
    //		if (roleId <= 0 || roleId > this.GetMaxID())
    //		{
    //			Debug.Log("HealRoleAP::roleIde錯誤_" + roleId);
    //			return;
    //		}
    //		C_RoleDataEx roleData = this.GetRoleData(roleId);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		roleData.AddAP(ap);
    //	}

    //	public void HealPartyHP(int hp)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData == null)
    //			{
    //				return;
    //			}
    //			roleData.AddHP(hp);
    //		}
    //	}

    //	public void HealPartyMP(int mp)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData == null)
    //			{
    //				return;
    //			}
    //			roleData.AddMP(mp);
    //		}
    //	}

    //	public void HealPartyAP(int ap)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData == null)
    //			{
    //				return;
    //			}
    //			roleData.AddAP(ap);
    //		}
    //	}

    //	public void AddPartyExp(int exp)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData == null)
    //			{
    //				return;
    //			}
    //			if (this.AddRoleExp(this.m_PartyRole[i].m_ID, exp))
    //			{
    //				string msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1064);
    //				UI_OkCancelBox.Instance.AddSysMsg(msg, 3f);
    //				this.ShowLearnSkillMsg(this.m_PartyRole[i].m_ID);
    //			}
    //		}
    //	}

    //	public void ShowLearnSkillMsg(int id)
    //	{
    //		C_RoleDataEx roleData = this.GetRoleData(id);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		List<int> list = Swd6Application.instance.m_SkillSystem.GetSkillLearnList(id, roleData.BaseRoleData.Level);
    //		if (list.Count > 0)
    //		{
    //			for (int i = 0; i < list.Count; i++)
    //			{
    //				S_Skill data = GameDataDB.SkillDB.GetData(list[i]);
    //				if (data != null)
    //				{
    //					string msg = string.Concat(new string[]
    //					{
    //						roleData.BaseRoleData.FamilyName,
    //						roleData.BaseRoleData.Name,
    //						GameDataDB.StrID(1002),
    //						"~[CEB5]",
    //						data.Name
    //					});
    //					UI_OkCancelBox.Instance.AddSysMsg(msg, 3f);
    //				}
    //			}
    //		}
    //		list.Clear();
    //		list = Swd6Application.instance.m_SkillSystem.GetSuperSkillLearnList(id, roleData.BaseRoleData.Level);
    //		if (list.Count > 0)
    //		{
    //			for (int j = 0; j < list.Count; j++)
    //			{
    //				S_SuperSkillSlot data2 = GameDataDB.SuperSkillDB.GetData(list[j]);
    //				if (data2 != null)
    //				{
    //					string msg = string.Concat(new string[]
    //					{
    //						roleData.BaseRoleData.FamilyName,
    //						roleData.BaseRoleData.Name,
    //						GameDataDB.StrID(1002),
    //						"~[CEB5]",
    //						data2.Name
    //					});
    //					UI_OkCancelBox.Instance.AddSysMsg(msg, 3f);
    //				}
    //			}
    //		}
    //	}

    //	public bool CheckEquipItem(int roldId, int itemId)
    //	{
    //		if (!Swd6Application.instance.m_GameDataSystem.GetFlag(roldId))
    //		{
    //			return false;
    //		}
    //		C_RoleDataEx roleData = this.GetRoleData(roldId);
    //		return roleData != null && roleData.CheckEquipItem(itemId);
    //	}

    //	public bool CheckPartyEquipItem(int itemId)
    //	{
    //		for (int i = 0; i < this.m_PartyRole.Count; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(this.m_PartyRole[i].m_ID);
    //			if (roleData != null && roleData.CheckEquipItem(itemId))
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	public int GetEquipRole(int partyRole)
    //	{
    //		if ((partyRole & 1) == 1)
    //		{
    //			return 1;
    //		}
    //		if ((partyRole & 2) == 2)
    //		{
    //			return 2;
    //		}
    //		if ((partyRole & 4) == 4)
    //		{
    //			return 3;
    //		}
    //		if ((partyRole & 8) == 8)
    //		{
    //			return 4;
    //		}
    //		if ((partyRole & 16) == 16)
    //		{
    //			return 5;
    //		}
    //		if ((partyRole & 32) == 32)
    //		{
    //			return 6;
    //		}
    //		if ((partyRole & 64) == 64)
    //		{
    //			return 7;
    //		}
    //		return 0;
    //	}

    //	public bool AddSevenRingExp(int roleId, int exp)
    //	{
    //		if (this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel >= 10)
    //		{
    //			return false;
    //		}
    //		this.m_RoldData[roleId - 1].BaseRoleData.SevenRingExp += exp;
    //		if (this.m_RoldData[roleId - 1].BaseRoleData.SevenRingExp >= this.m_SevenRingNeedExp[this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel - 1])
    //		{
    //			Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.SeveingRing, roleId, 0, 0, 1);
    //			int sevenRingLevel = this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel;
    //			for (int i = sevenRingLevel; i < 10; i++)
    //			{
    //				int num = i - 1;
    //				if (num < 0 || num >= this.m_SevenRingNeedExp.Length)
    //				{
    //					break;
    //				}
    //				int num2 = this.m_SevenRingNeedExp[num];
    //				if (this.m_RoldData[roleId - 1].BaseRoleData.SevenRingExp < num2)
    //				{
    //					break;
    //				}
    //				this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel = i + 1;
    //			}
    //			if (this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel == 10 && 9 < this.m_SevenRingNeedExp.Length)
    //			{
    //				this.m_RoldData[roleId - 1].BaseRoleData.SevenRingExp = this.m_SevenRingNeedExp[9];
    //			}
    //			return true;
    //		}
    //		return false;
    //	}

    //	public bool SetSevenRingLevel(int roleId, int level)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			return false;
    //		}
    //		if (level > 10)
    //		{
    //			return false;
    //		}
    //		this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel = level;
    //		this.m_RoldData[roleId - 1].BaseRoleData.SevenRingExp = this.m_SevenRingNeedExp[level - 1];
    //		return true;
    //	}

    //	public int GetSevenRingNextExp(int roleId)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			return 0;
    //		}
    //		int sevenRingLevel = this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel;
    //		if (sevenRingLevel >= 10)
    //		{
    //			return 0;
    //		}
    //		int num = sevenRingLevel - 1;
    //		return this.m_SevenRingNeedExp[num];
    //	}

    //	public int GetSevenRingBaseExp(int roleId)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			return 0;
    //		}
    //		if (this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel > 10)
    //		{
    //			return 0;
    //		}
    //		int num = this.m_RoldData[roleId - 1].BaseRoleData.SevenRingLevel - 1;
    //		if (num <= 0)
    //		{
    //			return 0;
    //		}
    //		int num2 = num - 1;
    //		return this.m_SevenRingNeedExp[num2];
    //	}

    //	public void AddFavorability(int roleId, int targetId, int value)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("AddFavorability id error!!");
    //			return;
    //		}
    //		S_Favorability targetFavorability = this.GetTargetFavorability(this.m_RoldData[roleId - 1].BaseRoleData.Favorability, targetId);
    //		if (targetFavorability == null)
    //		{
    //			return;
    //		}
    //		targetFavorability.Value += value;
    //	}

    //	public void DelFavorability(int roleId, int targetId, int value)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("DelFavorability id error!!");
    //			return;
    //		}
    //		S_Favorability targetFavorability = this.GetTargetFavorability(this.m_RoldData[roleId - 1].BaseRoleData.Favorability, targetId);
    //		if (targetFavorability == null)
    //		{
    //			return;
    //		}
    //		targetFavorability.Value -= value;
    //		if (targetFavorability.Value < 0)
    //		{
    //			targetFavorability.Value = 0;
    //		}
    //	}

    //	public void SetFavorability(int roleId, int targetId, int value)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("AddFavorability id error!!");
    //			return;
    //		}
    //		S_Favorability targetFavorability = this.GetTargetFavorability(this.m_RoldData[roleId - 1].BaseRoleData.Favorability, targetId);
    //		if (targetFavorability == null)
    //		{
    //			return;
    //		}
    //		targetFavorability.Value = value;
    //		if (roleId == 1)
    //		{
    //			Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.Favorability, 1, targetId, 0, value);
    //			Swd6Application.instance.m_AchievementSystem.AddAchievementByType(Enum_AchievementType.Favorability, 1, -1, 0, 0);
    //		}
    //	}

    //	public int GetFavorability(int roleId, int targetId)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("GetFavorability id error!!");
    //			return 0;
    //		}
    //		S_Favorability targetFavorability = this.GetTargetFavorability(this.m_RoldData[roleId - 1].BaseRoleData.Favorability, targetId);
    //		if (targetFavorability == null)
    //		{
    //			return 0;
    //		}
    //		return targetFavorability.Value;
    //	}

    //	public S_Favorability GetTargetFavorability(S_Favorability[] Favorability, int targetId)
    //	{
    //		for (int i = 0; i < 4; i++)
    //		{
    //			if (Favorability[i].ID == targetId)
    //			{
    //				return Favorability[i];
    //			}
    //		}
    //		return null;
    //	}

    //	public int GetPartyMinFavorability()
    //	{
    //		int num = 0;
    //		for (int i = this.GetMinID(); i <= this.GetMaxID(); i++)
    //		{
    //			if (i != 1)
    //			{
    //				C_RoleDataEx roleData = this.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					int favorability = this.GetFavorability(1, i);
    //					if (num == 0)
    //					{
    //						num = favorability;
    //					}
    //					else
    //					{
    //						num = Mathf.Min(favorability, num);
    //					}
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	public void SetAutoFightAI(int roleId, int type, int index, Enum_AutoFightCommandType commandType, int commandId, int percent)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("SetAutoFightAI id error!!");
    //			return;
    //		}
    //		S_AutoFightAI s_AutoFightAI = this.m_RoldData[roleId - 1].BaseRoleData.AutoFightAI[type];
    //		if (s_AutoFightAI == null)
    //		{
    //			return;
    //		}
    //		s_AutoFightAI.emCommandType[index] = commandType;
    //		s_AutoFightAI.ID[index] = commandId;
    //		s_AutoFightAI.Percent = percent;
    //	}

    //	public S_AutoFightAI[] GetAutoFightAI(int roleId)
    //	{
    //		if (roleId > this.GetMaxID())
    //		{
    //			Debug.LogError("SetAutoFightAI id error!!");
    //			return null;
    //		}
    //		S_AutoFightAI[] autoFightAI = this.m_RoldData[roleId - 1].BaseRoleData.AutoFightAI;
    //		if (autoFightAI == null)
    //		{
    //			return null;
    //		}
    //		return autoFightAI;
    //	}

    //	public string ReplaceRoleName(string text)
    //	{
    //		if (Swd6Application.instance.IsDLC())
    //		{
    //			text = text.Replace("#", "");
    //			return text;
    //		}
    //		for (int i = 0; i < 5; i++)
    //		{
    //			C_RoleDataEx roleData = this.GetRoleData(i + 1);
    //			if (roleData == null)
    //			{
    //				return text;
    //			}
    //			for (int j = 1; j <= 2; j++)
    //			{
    //				string text2 = GameDataDB.StrID(i * 10 + j);
    //				if (text2 != null && text2.Length != 0 && text.Contains(text2))
    //				{
    //					string newValue;
    //					if (j == 1)
    //					{
    //						newValue = roleData.BaseRoleData.FamilyName;
    //					}
    //					else
    //					{
    //						newValue = roleData.BaseRoleData.Name;
    //					}
    //					text = text.Replace(text2, newValue);
    //				}
    //			}
    //			for (int k = 3; k <= 7; k++)
    //			{
    //				string text3 = GameDataDB.StrID(i * 10 + k);
    //				if (text3 != null && text.Contains(text3))
    //				{
    //					string name = roleData.BaseRoleData.Name;
    //					if (name != null && name.Length != 0)
    //					{
    //						string newValue2 = name.Substring(name.Length - 1);
    //						string text4 = GameDataDB.StrID(i * 10 + k + 50);
    //						if (text4 != null)
    //						{
    //							string text5 = GameDataDB.StrID(i * 10 + 8);
    //							if (text5 != null)
    //							{
    //								text4 = text4.Replace(text5, newValue2);
    //								text = text.Replace(text3, text4);
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return text;
    //	}

    //	public void Save(GameFileStream stream)
    //	{
    //		int count = this.m_MapData.Count;
    //		stream.WriteInt(count);
    //		foreach (S_MapData current in this.m_MapData.Values)
    //		{
    //			stream.WriteInt(current.GUID);
    //			stream.WriteInt(current.MusicID1);
    //			stream.WriteInt(current.MusicID2);
    //			stream.WriteInt((int)current.emMusicMode);
    //		}
    //	}

    //	public void Load(GameFileStream stream)
    //	{
    //		int num = stream.ReadInt();
    //		this.ClearMapData();
    //		for (int i = 0; i < num; i++)
    //		{
    //			S_MapData s_MapData = new S_MapData();
    //			S_MapMusicData s_MapMusicData = new S_MapMusicData();
    //			s_MapData.GUID = stream.ReadInt();
    //			s_MapData.MusicID1 = stream.ReadInt();
    //			s_MapData.MusicID2 = stream.ReadInt();
    //			s_MapData.emMusicMode = (ENUM_MusicMode)stream.ReadInt();
    //			S_MapData s_MapData2 = this.AddMapData(s_MapData.GUID);
    //			if (s_MapData2 != null)
    //			{
    //				s_MapData2 = GameDataDB.MapDB.GetData(s_MapData.GUID);
    //				if (s_MapData2 != null)
    //				{
    //					s_MapMusicData.GUID = s_MapData2.GUID;
    //					s_MapMusicData.MusicID1 = s_MapData2.MusicID1;
    //					s_MapMusicData.MusicID2 = s_MapData2.MusicID2;
    //					s_MapMusicData.emMusicMode = s_MapData2.emMusicMode;
    //					this.m_MapMusicData.Add(s_MapMusicData.GUID, s_MapMusicData);
    //				}
    //				s_MapData2.MusicID1 = s_MapData.MusicID1;
    //				s_MapData2.MusicID2 = s_MapData.MusicID2;
    //				s_MapData2.emMusicMode = s_MapData.emMusicMode;
    //			}
    //		}
    //		this.UpdatePartyRole();
    //	}

    public void AddDLCItem()
    {
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(12) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(12, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(32) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(32, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(52) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(52, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(72) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(72, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(301) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(301, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(302) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(302, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(303) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(303, 1, ENUM_ItemState.New, false);
        }
        if (GameEntry.Instance.m_ItemSystem.GetDataByItemID(304) == null)
        {
            GameEntry.Instance.m_ItemSystem.AddItem(304, 1, ENUM_ItemState.New, false);
        }
    }
}
