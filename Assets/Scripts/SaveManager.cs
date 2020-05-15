using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SoftStar;
//using SoftStar.BuffDebuff;
//using SoftStar.Item;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public delegate void void_fun();

    //	// Token: 0x04002DB5 RID: 11701
    //	private const int GLOBALDATA_FILE_SIZE = 1024;

    //	// Token: 0x04002DB6 RID: 11702
    //	private const int SAVE_FILE_SIZE = 10485760;

    public static readonly uint Version;

    //	// Token: 0x04002DB8 RID: 11704
    //	public static string TempGameLayerName;

    //	// Token: 0x04002DB9 RID: 11705
    //	public static string LevelName;

    //	// Token: 0x04002DBA RID: 11706
    //	public static int LevelIndex;

    //	// Token: 0x04002DBB RID: 11707
    //	public static bool IsErZhouMu;

    //	// Token: 0x04002DBC RID: 11708
    //	public static uint VersionNum;

    //	// Token: 0x04002DBD RID: 11709
    //	public static DateTime dateTime;

    //	// Token: 0x04002DBE RID: 11710
    //	public static Action OnSaveEnd;

    //	// Token: 0x04002DBF RID: 11711
    //	private static Dictionary<int, SaveManager.SaveInfo> AllSaveInfos;

    //	// Token: 0x04002DC0 RID: 11712
    //	public static SaveManager.InheritStruct inheritStruct;

    /// <summary>
    /// 游戏难度
    /// </summary>
    public static int GameDifficulty;

    //	// Token: 0x04002DC2 RID: 11714
    //	private static SaveManager.PalGlobalData mPalGlobalData = new SaveManager.PalGlobalData();


    static SaveManager()
    {
        SaveManager.Version = 28u;
        //SaveManager.TempGameLayerName = "TempGameLayer";
        //SaveManager.LevelIndex = -1;
        //SaveManager.IsErZhouMu = false;
        //SaveManager.dateTime = DateTime.Now;
        //SaveManager.AllSaveInfos = new Dictionary<int, SaveManager.SaveInfo>();
        //SaveManager.inheritStruct = new SaveManager.InheritStruct();
        SaveManager.GameDifficulty = 0;
        SaveManager.OnLoadOver = null;
    }

    public static event SaveManager.void_fun OnLoadOver;

    //	// Token: 0x06003230 RID: 12848 RVA: 0x0016C344 File Offset: 0x0016A544
    //	public static bool Load(string LoadName)
    //	{
    //		if (UIManager.Instance.DoNotOpenMainMenu)
    //		{
    //			Debug.LogError("DoNotOpenMainMenu==true 不能读档");
    //			return false;
    //		}
    //		string text = string.Format("{0}/{1}.pal6", SaveManager.GetStoreDirePath(LoadName), LoadName);
    //		if (!File.Exists(text))
    //		{
    //			Debug.LogError(string.Format("{0} isn't exist", text));
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(text);
    //		SaveManager.ReadFromBuffer(buffer);
    //		UtilFun.WriteSaveLog(string.Concat(new object[]
    //		{
    //			"读档:",
    //			LoadName,
    //			"版本号:",
    //			SaveManager.VersionNum
    //		}));
    //		return true;
    //	}

    //	// Token: 0x06003231 RID: 12849 RVA: 0x0016C3DC File Offset: 0x0016A5DC
    //	private static void InitErZhouMuNPCData()
    //	{
    //		if (SaveManager.IsErZhouMu)
    //		{
    //			PlayersManager.Restart();
    //			PlayerTeam.Instance.InitTeam();
    //			if (!SaveManager.inheritStruct.Item)
    //			{
    //				ItemManager.GetInstance().ClearData();
    //				for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //				{
    //					try
    //					{
    //						if (i < PlayersManager.AllPlayers.Count)
    //						{
    //							PalNPC component = PlayersManager.AllPlayers[i].GetComponent<PalNPC>();
    //							if (component != null)
    //							{
    //								BuffDebuffManager.BuffDebuffOwner buffDebuffData = PlayersManager.AllPlayers[i].GetComponent<PalNPC>().BuffDebuffData;
    //								buffDebuffData.PartClearData();
    //							}
    //						}
    //					}
    //					catch
    //					{
    //						Debug.Log("SaveManager.InitErZhouMuNPCData Exception");
    //					}
    //				}
    //				PlayerTeam.Instance.InitItem();
    //			}
    //			if (!SaveManager.inheritStruct.Level)
    //			{
    //				for (int j = 0; j < PlayersManager.AllPlayers.Count; j++)
    //				{
    //					try
    //					{
    //						if (j < PlayersManager.AllPlayers.Count)
    //						{
    //							PalNPC component2 = PlayersManager.AllPlayers[j].GetComponent<PalNPC>();
    //							if (component2 != null && component2.Data != null)
    //							{
    //								PlayersManager.AllPlayers[j].GetComponent<PalNPC>().Data.Exp = 0;
    //								PlayersManager.AllPlayers[j].GetComponent<PalNPC>().Data.Soul = 0;
    //							}
    //						}
    //					}
    //					catch
    //					{
    //						Debug.Log("SaveManager.InitErZhouMuNPCData Exception2");
    //					}
    //				}
    //				PlayerTeam.Instance.InitPlayerLevel();
    //			}
    //			if (!SaveManager.inheritStruct.Skill)
    //			{
    //				for (int k = 0; k < PlayersManager.AllPlayers.Count; k++)
    //				{
    //					try
    //					{
    //						if (k < PlayersManager.AllPlayers.Count)
    //						{
    //							PalNPC component3 = PlayersManager.AllPlayers[k].GetComponent<PalNPC>();
    //							if (component3 != null && component3.m_SkillIDs != null)
    //							{
    //								PlayersManager.AllPlayers[k].GetComponent<PalNPC>().m_SkillIDs.Clear();
    //							}
    //						}
    //					}
    //					catch
    //					{
    //						Debug.Log("SaveManager.InitErZhouMuNPCData Exception3");
    //					}
    //				}
    //				PlayerTeam.Instance.InitSkill();
    //			}
    //		}
    //	}

    //	// Token: 0x06003232 RID: 12850 RVA: 0x0016C64C File Offset: 0x0016A84C
    //	private static void InitErZhouMu()
    //	{
    //		if (SaveManager.IsErZhouMu)
    //		{
    //			SaveManager.LevelIndex = 1;
    //			PalMain.GameDifficulty = SaveManager.GameDifficulty;
    //			int money = PalMain.GetMoney();
    //			FlagManager.InitFlags();
    //			UIInformation_Help_Item.CloseAllFirst();
    //			UIInformation_Help_Item.ReStart();
    //			MissionManager.Restart();
    //			PalMain.Instance.CurBattleFormationManager.Clear();
    //			BattleFormationManager.BattleFormationData battleFormationData = new BattleFormationManager.BattleFormationData();
    //			battleFormationData.m_InFormationCharaDatas.AddRange(new BattleFormationManager.InFormationCharaData[9]);
    //			PalMain.Instance.CurBattleFormationManager.AddFormation(battleFormationData);
    //			if (!SaveManager.inheritStruct.Money)
    //			{
    //				PalMain.ChangeMoney(PlayerTeam.Instance.money);
    //			}
    //			else
    //			{
    //				PalMain.ChangeMoney(money);
    //			}
    //			if (!SaveManager.inheritStruct.Renown)
    //			{
    //				RenownManager.Reset();
    //			}
    //			if (!SaveManager.inheritStruct.Achievement)
    //			{
    //				PalBattleManager.Instance().Restart();
    //			}
    //		}
    //	}

    //	// Token: 0x06003233 RID: 12851 RVA: 0x0016C71C File Offset: 0x0016A91C
    //	public static void LoadInSceneByPlayerName()
    //	{
    //		PalMain.LoadOverEvent = (Action)Delegate.Remove(PalMain.LoadOverEvent, new Action(SaveManager.LoadInSceneByPlayerName));
    //		SaveManager.LoadInScene(PalMain.PlayerName);
    //	}

    //	// Token: 0x06003234 RID: 12852 RVA: 0x0016C74C File Offset: 0x0016A94C
    //	private static void LoadOver()
    //	{
    //		if (SaveManager.OnLoadOver != null)
    //		{
    //			SaveManager.OnLoadOver();
    //		}
    //		SaveManager.IsErZhouMu = false;
    //	}

    //	// Token: 0x06003235 RID: 12853 RVA: 0x0016C768 File Offset: 0x0016A968
    //	public static bool LoadInScene(string LoadName)
    //	{
    //		PlayersManager.Load(LoadName);
    //		if (!SaveManager.IsErZhouMu)
    //		{
    //			if (SaveManager.VersionNum < 22u)
    //			{
    //				try
    //				{
    //					SaveManager.LoadLayer(LoadName);
    //				}
    //				catch
    //				{
    //					string text = "Error : 读取旧信息有错误";
    //					Debug.LogError(text);
    //					SoftStar.Pal6.Console.Log(text);
    //				}
    //			}
    //			SaveManager.LoadTempLayer(LoadName);
    //		}
    //		SaveManager.InitErZhouMuNPCData();
    //		SaveManager.LoadOver();
    //		return true;
    //	}

    //	// Token: 0x06003236 RID: 12854 RVA: 0x0016C7E4 File Offset: 0x0016A9E4
    //	public IEnumerator LoadAfterLoadLevel(string LoadName)
    //	{
    //		while (Application.isLoadingLevel)
    //		{
    //			yield return 0;
    //		}
    //		SaveManager.LoadInScene(LoadName);
    //		yield break;
    //	}

    //	// Token: 0x06003237 RID: 12855 RVA: 0x0016C808 File Offset: 0x0016AA08
    //	public static bool GetSaveInfo(string _loadName, SaveManager.SaveInfo _saveInfo)
    //	{
    //		string path = string.Format("{0}/{1}.pal6", SaveManager.GetStoreDirePath(_loadName), _loadName);
    //		if (!File.Exists(path))
    //		{
    //			byte[] array = SaveManager.PackageAllFile(SaveManager.GetStoreDirePath(_loadName), _loadName);
    //			if (array == null)
    //			{
    //				return false;
    //			}
    //			File.WriteAllBytes(string.Format("{0}/{1}.pal6", SaveManager.GetStoreDirePath(_loadName), _loadName), array);
    //		}
    //		byte[] buffer = File.ReadAllBytes(path);
    //		SaveManager.LoadSaveInfo_FileStream(buffer, _saveInfo);
    //		return true;
    //	}

    //	// Token: 0x06003238 RID: 12856 RVA: 0x0016C870 File Offset: 0x0016AA70
    //	public static bool Save(string SaveName)
    //	{
    //		if (UIManager.Instance.DoNotOpenMainMenu)
    //		{
    //			Debug.LogError("DoNotOpenMainMenu==true 不能存档");
    //			return false;
    //		}
    //		string storeDirePath = SaveManager.GetStoreDirePath(SaveName);
    //		if (!Directory.Exists(storeDirePath))
    //		{
    //			Directory.CreateDirectory(storeDirePath);
    //		}
    //		byte[] bytes = SaveManager.WriteToBuffer();
    //		File.WriteAllBytes(string.Format("{0}/{1}.pal6", storeDirePath, SaveName), bytes);
    //		UtilFun.WriteSaveLog(string.Concat(new object[]
    //		{
    //			"存档:",
    //			SaveName,
    //			"版本号:",
    //			SaveManager.Version
    //		}));
    //		if (SaveManager.OnSaveEnd != null)
    //		{
    //			SaveManager.OnSaveEnd();
    //		}
    //		return true;
    //	}

    //	// Token: 0x06003239 RID: 12857 RVA: 0x0016C910 File Offset: 0x0016AB10
    //	public static bool SaveGlobalData()
    //	{
    //		byte[] bytes = SaveManager.WriteGlobalDataToBuffer();
    //		File.WriteAllBytes(string.Format("{0}/Config.pal6", ConfigManager.ReadWritePath), bytes);
    //		return true;
    //	}

    //	// Token: 0x0600323A RID: 12858 RVA: 0x0016C93C File Offset: 0x0016AB3C
    //	public static bool LoadGlobalData()
    //	{
    //		string path = string.Format("{0}/Config.pal6", ConfigManager.ReadWritePath);
    //		if (!File.Exists(path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(path);
    //		SaveManager.ReadGlobalDataFromBuffer(buffer);
    //		return true;
    //	}

    //	// Token: 0x0600323B RID: 12859 RVA: 0x0016C974 File Offset: 0x0016AB74
    //	public static void SaveScreenshot(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text = text + "/" + SaveName + ".bin";
    //		ReadPixels.Instance(text);
    //	}

    //	// Token: 0x0600323C RID: 12860 RVA: 0x0016C9A0 File Offset: 0x0016ABA0
    //	private static void SaveQueue(BinaryWriter writer)
    //	{
    //		List<BattleFormationManager.BattleFormationData> formations = PalMain.GameMain.CurBattleFormationManager.m_Formations;
    //		writer.Write(formations.Count);
    //		writer.Write(PalMain.GameMain.CurBattleFormationManager.CurrentFormation);
    //		foreach (BattleFormationManager.BattleFormationData battleFormationData in formations)
    //		{
    //			if (battleFormationData.m_UserDefineName == null)
    //			{
    //				battleFormationData.m_UserDefineName = string.Empty;
    //			}
    //			writer.Write(battleFormationData.m_UserDefineName);
    //			writer.Write(battleFormationData.m_Store);
    //			writer.Write(battleFormationData.m_InFormationCharaDatas.Count);
    //			for (int i = 0; i < battleFormationData.m_InFormationCharaDatas.Count; i++)
    //			{
    //				if (battleFormationData.m_InFormationCharaDatas[i] == null)
    //				{
    //					writer.Write(-1);
    //				}
    //				else
    //				{
    //					writer.Write(battleFormationData.m_InFormationCharaDatas[i].m_CharacterID);
    //					writer.Write(battleFormationData.m_InFormationCharaDatas[i].m_CharacterSkillGroup);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600323D RID: 12861 RVA: 0x0016CAD4 File Offset: 0x0016ACD4
    //	private static void LoadQueue(BinaryReader reader)
    //	{
    //		int num = reader.ReadInt32();
    //		List<BattleFormationManager.BattleFormationData> formations = PalMain.GameMain.CurBattleFormationManager.m_Formations;
    //		if (formations.Capacity < num)
    //		{
    //			formations.Capacity = num;
    //		}
    //		PalMain.GameMain.CurBattleFormationManager.CurrentFormation = reader.ReadInt32();
    //		for (int i = 0; i < num; i++)
    //		{
    //			BattleFormationManager.BattleFormationData battleFormationData = new BattleFormationManager.BattleFormationData();
    //			battleFormationData.m_UserDefineName = reader.ReadString();
    //			battleFormationData.m_Store = reader.ReadInt32();
    //			int num2 = reader.ReadInt32();
    //			battleFormationData.m_InFormationCharaDatas.Capacity = num2;
    //			for (int j = 0; j < num2; j++)
    //			{
    //				int num3 = reader.ReadInt32();
    //				if (num3 >= 0)
    //				{
    //					battleFormationData.m_InFormationCharaDatas.Add(new BattleFormationManager.InFormationCharaData(num3, reader.ReadInt32()));
    //				}
    //				else
    //				{
    //					battleFormationData.m_InFormationCharaDatas.Add(null);
    //				}
    //			}
    //			formations.Add(battleFormationData);
    //		}
    //	}

    //	// Token: 0x0600323E RID: 12862 RVA: 0x0016CBBC File Offset: 0x0016ADBC
    //	public static bool SaveMain(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text += "/Main";
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			string text2 = SaveManager.SaveMainCore(binaryWriter);
    //			if (text2 != string.Empty)
    //			{
    //				Debug.LogError(text2);
    //				return false;
    //			}
    //			FileInfo fileInfo = new FileInfo(text);
    //			UtilFun.WriteSaveLog("Main大小:" + fileInfo.Length);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600323F RID: 12863 RVA: 0x0016CC68 File Offset: 0x0016AE68
    //	private static string SaveMainCore(BinaryWriter writer)
    //	{
    //		writer.Write(SaveManager.Version);
    //		if (FlagManager.GetFlag(1) == 245030)
    //		{
    //			writer.Write(true);
    //		}
    //		else
    //		{
    //			writer.Write(false);
    //		}
    //		writer.Write(Application.loadedLevel);
    //		writer.Write(DateTime.Now.ToBinary());
    //		writer.Write(PalMain.GameTotleTime + (Time.fixedTime - PalMain.GameBeginTime));
    //		writer.Write(PalMain.GameDifficulty);
    //		List<GameObject> activePlayers = PlayersManager.ActivePlayers;
    //		writer.Write(activePlayers.Count);
    //		foreach (GameObject gameObject in activePlayers)
    //		{
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			if (component == null)
    //			{
    //				writer.Write(0UL);
    //				writer.Write(string.Empty);
    //				writer.Write(0);
    //			}
    //			else
    //			{
    //				component.Data.CharacterCommon.ShowName.Serialize(writer);
    //				writer.Write(component.Data.Level);
    //			}
    //		}
    //		int idx = (!PalMain.IsDLC) ? MissionManager.MainLineFlag : MissionManager.BranchLineFlag;
    //		int flag = FlagManager.GetFlag(idx);
    //		Mission curMission = MissionManager.GetCurMission(flag);
    //		int num = (curMission != null) ? curMission.ChapterIndex : 0;
    //		Chapter chapter = null;
    //		if (!PalMain.IsDLC)
    //		{
    //			if (MissionManager.mainChapters.TryGetValue(num, out chapter))
    //			{
    //				writer.Write(chapter.nameID);
    //			}
    //			else
    //			{
    //				Debug.LogError("MissionManager.mainChapters没有找到" + num);
    //				writer.Write(0UL);
    //			}
    //		}
    //		else if (MissionManager.branchChapters.TryGetValue(num, out chapter))
    //		{
    //			writer.Write(chapter.nameID);
    //		}
    //		else
    //		{
    //			Debug.LogError("MissionManager.mainChapters没有找到" + num);
    //			writer.Write(0UL);
    //		}
    //		Debug.Log("SaveMainCore2::" + writer.BaseStream.Length);
    //		FlagManager.Save(writer);
    //		MonsterProperty.Save(writer);
    //		MissionManager.Save(writer);
    //		SaveManager.SaveQueue(writer);
    //		HuanHuaManager.Instance.Save(writer);
    //		RenownManager.Save(writer);
    //		PalBattleManager.Instance().m_Achievement.Save(writer);
    //		PalBattleManager.Instance().Save(writer);
    //		return string.Empty;
    //	}

    //	// Token: 0x06003240 RID: 12864 RVA: 0x0016CEE0 File Offset: 0x0016B0E0
    //	public static bool LoadMain(string LoadName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(LoadName);
    //		text += "/Main";
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //		{
    //			string text2 = SaveManager.LoadMainCore(binaryReader);
    //			if (text2 != string.Empty)
    //			{
    //				Debug.LogError(text2);
    //				return false;
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x06003241 RID: 12865 RVA: 0x0016CF68 File Offset: 0x0016B168
    //	private static string LoadMainCore(BinaryReader reader)
    //	{
    //		SaveManager.VersionNum = reader.ReadUInt32();
    //		Debug.Log(string.Format("[VersionNum : {0}]", SaveManager.VersionNum));
    //		if (SaveManager.VersionNum > SaveManager.Version)
    //		{
    //			UIDialogManager.Instance.ShowForceInfoDialog("读取失败：存档版本高于游戏版本！", null);
    //			return "读取失败：存档版本高于游戏版本！";
    //		}
    //		if (SaveManager.VersionNum >= 28u)
    //		{
    //			SaveManager.IsErZhouMu = reader.ReadBoolean();
    //		}
    //		else
    //		{
    //			SaveManager.IsErZhouMu = false;
    //		}
    //		SaveManager.LevelIndex = reader.ReadInt32();
    //		SaveManager.dateTime = DateTime.FromBinary(reader.ReadInt64());
    //		if (SaveManager.VersionNum >= 12u)
    //		{
    //			PalMain.GameTotleTime = reader.ReadSingle();
    //		}
    //		PalMain.Instance.MoneyRate = 1f;
    //		PalMain.Instance.DropAddRate = 0f;
    //		PalMain.Instance.DPRate = 1f;
    //		PalMain.GameDifficulty = reader.ReadInt32();
    //		if (PalMain.GameDifficulty < 0)
    //		{
    //			PalMain.GameDifficulty = 0;
    //		}
    //		else if (PalMain.GameDifficulty > 2)
    //		{
    //			PalMain.GameDifficulty = 2;
    //		}
    //		HPMPDPProperty.StaticData.Reset();
    //		FightProperty.StaticData.Reset();
    //		int num = reader.ReadInt32();
    //		for (int i = 0; i < num; i++)
    //		{
    //			new Langue(reader);
    //			reader.ReadInt32();
    //		}
    //		reader.ReadUInt64();
    //		PlayersManager.BeforeLoadData();
    //		FlagManager.Load(reader);
    //		MonsterProperty.Load(reader);
    //		MissionManager.Load(reader);
    //		if (SaveManager.VersionNum <= 18u)
    //		{
    //			ItemManager.GetInstance().Load(reader);
    //			BuffDebuffManager.GetInstance().Load(reader);
    //		}
    //		PalMain.GameMain.CurBattleFormationManager.Clear();
    //		SaveManager.LoadQueue(reader);
    //		if (SaveManager.VersionNum < 15u)
    //		{
    //			Debug.Log("改存档版本过低，无法读取幻化、声望等系统");
    //			return string.Empty;
    //		}
    //		HuanHuaManager.Instance.Load(reader);
    //		if (SaveManager.VersionNum >= 11u)
    //		{
    //			RenownManager.Load(reader);
    //		}
    //		if (SaveManager.VersionNum >= 25u)
    //		{
    //			PalBattleManager.Instance().m_Achievement.Load(reader);
    //		}
    //		if (SaveManager.VersionNum >= 20u)
    //		{
    //			PalBattleManager.Instance().Load(reader);
    //		}
    //		return string.Empty;
    //	}

    //	// Token: 0x06003242 RID: 12866 RVA: 0x0016D168 File Offset: 0x0016B368
    //	private static void SaveItemAndBuffdebuff(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text += "/ItemAndBuffdebuff";
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			ItemManager.GetInstance().Save(binaryWriter);
    //			BuffDebuffManager.GetInstance().Save(binaryWriter);
    //		}
    //	}

    //	// Token: 0x06003243 RID: 12867 RVA: 0x0016D1E0 File Offset: 0x0016B3E0
    //	private static void LoadItemAndBuffdebuff(string LoadName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(LoadName);
    //		text += "/ItemAndBuffdebuff";
    //		if (File.Exists(text))
    //		{
    //			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //			{
    //				ItemManager.GetInstance().Load(binaryReader);
    //				BuffDebuffManager.GetInstance().Load(binaryReader);
    //			}
    //		}
    //		else
    //		{
    //			ItemManager.GetInstance().ClearData();
    //			BuffDebuffManager.GetInstance().ClearData();
    //		}
    //	}

    //	// Token: 0x06003244 RID: 12868 RVA: 0x0016D27C File Offset: 0x0016B47C
    //	private static void SaveStrangeNews(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text += "/StrangeNews";
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			UIInformation_StrangeNews_Item.TypeData[] items = UIInformation_StrangeNews_Item.Items;
    //			foreach (UIInformation_StrangeNews_Item.TypeData typeData in items)
    //			{
    //				foreach (UIInformation_StrangeNews_Item.TitleData titleData in typeData.TitleDatas)
    //				{
    //					if (titleData.Position > 0)
    //					{
    //						binaryWriter.Write(titleData.TitleID);
    //						binaryWriter.Write(titleData.Position);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003245 RID: 12869 RVA: 0x0016D358 File Offset: 0x0016B558
    //	private static void LoadStrangeNews(string LoadName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(LoadName);
    //		text += "/StrangeNews";
    //		UIInformation_StrangeNews_Item.TypeData[] items = UIInformation_StrangeNews_Item.Items;
    //		Dictionary<int, UIInformation_StrangeNews_Item.TitleData> dictionary = new Dictionary<int, UIInformation_StrangeNews_Item.TitleData>();
    //		foreach (UIInformation_StrangeNews_Item.TypeData typeData in items)
    //		{
    //			foreach (UIInformation_StrangeNews_Item.TitleData titleData in typeData.TitleDatas)
    //			{
    //				dictionary[titleData.TitleID] = titleData;
    //				titleData.Position = 0;
    //			}
    //		}
    //		UIInformation_StrangeNews_Item.SetDirty();
    //		if (File.Exists(text))
    //		{
    //			try
    //			{
    //				using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //				{
    //					while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
    //					{
    //						int key = binaryReader.ReadInt32();
    //						int position = binaryReader.ReadInt32();
    //						UIInformation_StrangeNews_Item.TitleData titleData2;
    //						if (dictionary.TryGetValue(key, out titleData2))
    //						{
    //							titleData2.Position = position;
    //						}
    //					}
    //				}
    //			}
    //			catch (Exception exception)
    //			{
    //				Debug.LogException(exception);
    //			}
    //		}
    //	}

    //	// Token: 0x06003246 RID: 12870 RVA: 0x0016D4B0 File Offset: 0x0016B6B0
    //	private static void SaveHelp(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text += "/Help";
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			List<uint> list = new List<uint>();
    //			UIInformation_Help_Item.ItemClass[] items = UIInformation_Help_Item.Items;
    //			uint num = 0u;
    //			while ((ulong)num < (ulong)((long)items.Length))
    //			{
    //				list.Clear();
    //				UIInformation_Help_Item.ItemClass[] subItems = items[(int)((UIntPtr)num)].SubItems;
    //				uint num2 = 0u;
    //				while ((ulong)num2 < (ulong)((long)subItems.Length))
    //				{
    //					if (subItems[(int)((UIntPtr)num2)].IsOpen)
    //					{
    //						list.Add(num2);
    //					}
    //					num2 += 1u;
    //				}
    //				if (list.Count > 0)
    //				{
    //					binaryWriter.Write(num);
    //					binaryWriter.Write((uint)list.Count);
    //					foreach (uint value in list)
    //					{
    //						binaryWriter.Write(value);
    //					}
    //				}
    //				num += 1u;
    //			}
    //		}
    //	}

    //	// Token: 0x06003247 RID: 12871 RVA: 0x0016D5F0 File Offset: 0x0016B7F0
    //	private static void LoadHelp(string LoadName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(LoadName);
    //		text += "/Help";
    //		UIInformation_Help_Item.ReStart();
    //		UIInformation_Help_Item.ItemClass[] items = UIInformation_Help_Item.Items;
    //		if (File.Exists(text))
    //		{
    //			try
    //			{
    //				using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //				{
    //					List<uint> list = new List<uint>();
    //					while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
    //					{
    //						list.Clear();
    //						uint num = binaryReader.ReadUInt32();
    //						uint num2 = binaryReader.ReadUInt32();
    //						list.Capacity = (int)num2;
    //						for (uint num3 = 0u; num3 < num2; num3 += 1u)
    //						{
    //							list.Add(binaryReader.ReadUInt32());
    //						}
    //						if ((ulong)num < (ulong)((long)items.Length))
    //						{
    //							UIInformation_Help_Item.ItemClass itemClass = items[(int)((UIntPtr)num)];
    //							foreach (uint num4 in list)
    //							{
    //								if ((ulong)num4 < (ulong)((long)itemClass.SubItems.Length))
    //								{
    //									itemClass.SubItems[(int)((UIntPtr)num4)].IsOpen = true;
    //								}
    //							}
    //						}
    //					}
    //				}
    //			}
    //			catch (Exception exception)
    //			{
    //				Debug.LogException(exception);
    //			}
    //		}
    //	}

    //	// Token: 0x06003248 RID: 12872 RVA: 0x0016D780 File Offset: 0x0016B980
    //	public static bool SaveObjects(string SaveName)
    //	{
    //		SaveTarget[] array = (SaveTarget[])UnityEngine.Object.FindObjectsOfType(typeof(SaveTarget));
    //		if (array.Length > 0)
    //		{
    //			string text = SaveManager.GetLevelNameDirePath(SaveName);
    //			text += "/Objects";
    //			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //			{
    //				binaryWriter.Write(array.Length);
    //				foreach (SaveTarget saveTarget in array)
    //				{
    //					saveTarget.Save(binaryWriter);
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x06003249 RID: 12873 RVA: 0x0016D834 File Offset: 0x0016BA34
    //	public static bool LoadObjects(string SaveName)
    //	{
    //		string text = SaveManager.GetLevelNameDirePath(SaveName);
    //		text += "/Objects";
    //		if (!File.Exists(text))
    //		{
    //			Debug.LogError("Can't find " + text);
    //			return false;
    //		}
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //		{
    //			int num = binaryReader.ReadInt32();
    //			for (int i = 0; i < num; i++)
    //			{
    //				if (!SaveTarget.LOAD(binaryReader))
    //				{
    //					Debug.LogError("读取 Objects 时出错");
    //					return false;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324A RID: 12874 RVA: 0x0016D8EC File Offset: 0x0016BAEC
    //	public static bool SaveLayer(string SaveName)
    //	{
    //		DOBJLayer[] array = (DOBJLayer[])UnityEngine.Object.FindObjectsOfType(typeof(DOBJLayer));
    //		foreach (DOBJLayer dobJLayer in array)
    //		{
    //			SaveManager.SaveSingleLayer(dobJLayer, SaveName);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324B RID: 12875 RVA: 0x0016D934 File Offset: 0x0016BB34
    //	public static bool SaveSingleLayer(DOBJLayer dobJLayer, string SaveName)
    //	{
    //		string text = SaveManager.GetLevelNameDirePath(SaveName);
    //		Debug.Log(text);
    //		text = text + "/" + dobJLayer.name;
    //		SaveTarget[] componentsInChildren = dobJLayer.GetComponentsInChildren<SaveTarget>();
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			foreach (SaveTarget saveTarget in componentsInChildren)
    //			{
    //				saveTarget.Save(binaryWriter);
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324C RID: 12876 RVA: 0x0016D9D4 File Offset: 0x0016BBD4
    //	public static bool LoadLayer(string SaveName)
    //	{
    //		DOBJLayer[] array = (DOBJLayer[])UnityEngine.Object.FindObjectsOfType(typeof(DOBJLayer));
    //		foreach (DOBJLayer dobJLayer in array)
    //		{
    //			SaveManager.LoadSingleLayer(dobJLayer, SaveName);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324D RID: 12877 RVA: 0x0016DA1C File Offset: 0x0016BC1C
    //	public static bool LoadSingleLayer(DOBJLayer dobJLayer, string SaveName)
    //	{
    //		string text = SaveManager.GetLevelNameDirePath(SaveName);
    //		text = text + "/" + dobJLayer.name;
    //		if (!File.Exists(text))
    //		{
    //			Debug.LogError("Can't find " + text);
    //			return false;
    //		}
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //		{
    //			while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
    //			{
    //				if (!SaveTarget.LOAD(binaryReader))
    //				{
    //					Debug.LogError("读取" + dobJLayer.name + "时出错");
    //					return false;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324E RID: 12878 RVA: 0x0016DAF0 File Offset: 0x0016BCF0
    //	public static bool SaveTempLayer(string SaveName)
    //	{
    //		GameObject gameObject = GameObject.Find(SaveManager.TempGameLayerName);
    //		if (gameObject == null)
    //		{
    //			return false;
    //		}
    //		string text = SaveManager.GetLevelNameDirePath(SaveName);
    //		text = text + "/" + SaveManager.TempGameLayerName;
    //		SavePrefabTarget[] componentsInChildren = gameObject.GetComponentsInChildren<SavePrefabTarget>();
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create), Encoding.UTF8))
    //		{
    //			foreach (SavePrefabTarget savePrefabTarget in componentsInChildren)
    //			{
    //				savePrefabTarget.Save(binaryWriter);
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600324F RID: 12879 RVA: 0x0016DBA4 File Offset: 0x0016BDA4
    //	public static bool LoadTempLayer(string SaveName)
    //	{
    //		string text = SaveManager.GetLevelNameDirePath(SaveName);
    //		text = text + "/" + SaveManager.TempGameLayerName;
    //		if (!File.Exists(text))
    //		{
    //			return false;
    //		}
    //		GameObject gameObject = GameObject.Find(SaveManager.TempGameLayerName);
    //		if (gameObject != null)
    //		{
    //			UnityEngine.Object.Destroy(gameObject);
    //		}
    //		GameObject gameObject2 = new GameObject(SaveManager.TempGameLayerName);
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text), Encoding.UTF8))
    //		{
    //			while (binaryReader.BaseStream.Length > binaryReader.BaseStream.Position)
    //			{
    //				if (!SavePrefabTarget.Load(binaryReader, gameObject2.transform))
    //				{
    //					Debug.LogError("读取 TempGameLayer 时出错");
    //					return false;
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x06003250 RID: 12880 RVA: 0x0016DC8C File Offset: 0x0016BE8C
    //	public static void ResetCache()
    //	{
    //		SaveManager.AllSaveInfos.Clear();
    //	}

    //	// Token: 0x06003251 RID: 12881 RVA: 0x0016DC98 File Offset: 0x0016BE98
    //	public static string GetStoreDirePath(string SaveName)
    //	{
    //		string str = Path.Combine(ConfigManager.ReadWritePath, "Save");
    //		return str + "/" + SaveName;
    //	}

    //	// Token: 0x06003252 RID: 12882 RVA: 0x0016DCC4 File Offset: 0x0016BEC4
    //	private static string GetLevelNameDirePath(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text = text + "/" + Application.loadedLevelName;
    //		if (!Directory.Exists(text))
    //		{
    //			Directory.CreateDirectory(text);
    //		}
    //		return text;
    //	}

    //	// Token: 0x06003253 RID: 12883 RVA: 0x0016DCFC File Offset: 0x0016BEFC
    //	private static int GetHeaderOffset(SaveManager.FileHeader _type)
    //	{
    //		int result = 0;
    //		switch (_type)
    //		{
    //		case SaveManager.FileHeader.Screen:
    //			result = 0;
    //			break;
    //		case SaveManager.FileHeader.Main:
    //			result = 4;
    //			break;
    //		case SaveManager.FileHeader.ItemBuffDebuff:
    //			result = 8;
    //			break;
    //		case SaveManager.FileHeader.StrangeNews:
    //			result = 12;
    //			break;
    //		case SaveManager.FileHeader.Help:
    //			result = 16;
    //			break;
    //		case SaveManager.FileHeader.OrnamentItemTypeCache:
    //			result = 20;
    //			break;
    //		case SaveManager.FileHeader.FashionClothItemTypeCache:
    //			result = 24;
    //			break;
    //		case SaveManager.FileHeader.TempLayer:
    //			result = 28;
    //			break;
    //		case SaveManager.FileHeader.PlayerManager:
    //			result = 32;
    //			break;
    //		case SaveManager.FileHeader.DynamicObjsDataManager:
    //			result = 36;
    //			break;
    //		case SaveManager.FileHeader.StartData:
    //			result = 40;
    //			break;
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003254 RID: 12884 RVA: 0x0016DD9C File Offset: 0x0016BF9C
    //	private static void WirteCurPositionAtHeader(BinaryWriter _writer, SaveManager.FileHeader _type)
    //	{
    //		int num = (int)_writer.BaseStream.Position;
    //		int headerOffset = SaveManager.GetHeaderOffset(_type);
    //		_writer.Seek(headerOffset, SeekOrigin.Begin);
    //		_writer.Write(num);
    //		_writer.Seek(num, SeekOrigin.Begin);
    //	}

    //	// Token: 0x06003255 RID: 12885 RVA: 0x0016DDD8 File Offset: 0x0016BFD8
    //	private static void MoveToStartPosionAtHeader(BinaryReader _reader, SaveManager.FileHeader _type)
    //	{
    //		int headerOffset = SaveManager.GetHeaderOffset(_type);
    //		_reader.BaseStream.Seek((long)headerOffset, SeekOrigin.Begin);
    //		int num = _reader.ReadInt32();
    //		_reader.BaseStream.Seek((long)num, SeekOrigin.Begin);
    //	}

    //	// Token: 0x06003256 RID: 12886 RVA: 0x0016DE14 File Offset: 0x0016C014
    //	public static void ReadFromBuffer(byte[] buffer)
    //	{
    //		PalMain.Instance.ReStart();
    //		MemoryStream input = new MemoryStream(buffer);
    //		BinaryReader reader = new BinaryReader(input);
    //		SaveManager.LoadMain_FileStream(reader);
    //		if (SaveManager.VersionNum >= 22u)
    //		{
    //			if (SaveManager.IsErZhouMu)
    //			{
    //				DynamicObjsDataManager.Instance.Clear();
    //			}
    //			else
    //			{
    //				SaveManager.MoveToStartPosionAtHeader(reader, SaveManager.FileHeader.DynamicObjsDataManager);
    //				DynamicObjsDataManager.Instance.LoadFromFileStream(reader);
    //			}
    //		}
    //		SaveManager.LoadItemAndBuffdebuff_FileStream(reader);
    //		SaveManager.LoadStrangeNews_FileStream(reader);
    //		SaveManager.LoadHelp_FileStream(reader);
    //		SaveManager.MoveToStartPosionAtHeader(reader, SaveManager.FileHeader.OrnamentItemTypeCache);
    //		OrnamentItemTypeCache.Load_IsGet(reader);
    //		SaveManager.MoveToStartPosionAtHeader(reader, SaveManager.FileHeader.FashionClothItemTypeCache);
    //		FashionClothItemTypeCache.Load_IsGet(reader);
    //		SaveManager.InitErZhouMu();
    //		PalMain.ChangeMap("SceneEnter", SaveManager.LevelIndex, true, false);
    //		bool flag = true;
    //		if (flag)
    //		{
    //			Action hander = null;
    //			hander = delegate()
    //			{
    //				PalMain.LoadOverEvent = (Action)Delegate.Remove(PalMain.LoadOverEvent, hander);
    //				SaveManager.MoveToStartPosionAtHeader(reader, SaveManager.FileHeader.PlayerManager);
    //				PlayersManager.Load_FileStream(reader);
    //				SaveManager.LoadTempLayer_FileStream(reader);
    //				reader.Close();
    //				SaveManager.InitErZhouMuNPCData();
    //				SaveManager.LoadOver();
    //			};
    //			PalMain.LoadOverEvent = (Action)Delegate.Combine(PalMain.LoadOverEvent, hander);
    //		}
    //		PalMain.GameBeginTime = Time.fixedTime;
    //	}

    //	// Token: 0x06003257 RID: 12887 RVA: 0x0016DF50 File Offset: 0x0016C150
    //	public static byte[] WriteToBuffer()
    //	{
    //		MemoryStream memoryStream = new MemoryStream(10485760);
    //		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
    //		binaryWriter.Seek(SaveManager.GetHeaderOffset(SaveManager.FileHeader.StartData), SeekOrigin.Begin);
    //		SaveManager.SaveScreenshot_FileStream(binaryWriter);
    //		SaveManager.SaveMain_FileStream(binaryWriter);
    //		SaveManager.SaveItemAndBuffdebuff_FileStream(binaryWriter);
    //		SaveManager.SaveStrangeNews_FileStream(binaryWriter);
    //		SaveManager.SaveHelp_FileStream(binaryWriter);
    //		SaveManager.WirteCurPositionAtHeader(binaryWriter, SaveManager.FileHeader.OrnamentItemTypeCache);
    //		OrnamentItemTypeCache.Save_IsGet(binaryWriter);
    //		SaveManager.WirteCurPositionAtHeader(binaryWriter, SaveManager.FileHeader.FashionClothItemTypeCache);
    //		FashionClothItemTypeCache.Save_IsGet(binaryWriter);
    //		SaveManager.SaveTempLayer_FileStream(binaryWriter);
    //		SaveManager.WirteCurPositionAtHeader(binaryWriter, SaveManager.FileHeader.PlayerManager);
    //		PlayersManager.Save_FileStream(binaryWriter);
    //		SaveManager.WirteCurPositionAtHeader(binaryWriter, SaveManager.FileHeader.DynamicObjsDataManager);
    //		DynamicObjsDataManager.Instance.SaveToFileStream(binaryWriter);
    //		int num = (int)binaryWriter.BaseStream.Position;
    //		binaryWriter.Close();
    //		byte[] array = new byte[num];
    //		Array.Copy(memoryStream.GetBuffer(), array, num);
    //		memoryStream.Close();
    //		return array;
    //	}

    //	// Token: 0x06003258 RID: 12888 RVA: 0x0016E014 File Offset: 0x0016C214
    //	public static void LoadSaveInfo_FileStream(byte[] _buffer, SaveManager.SaveInfo _info)
    //	{
    //		if (_info == null)
    //		{
    //			return;
    //		}
    //		MemoryStream memoryStream = new MemoryStream(_buffer);
    //		BinaryReader binaryReader = new BinaryReader(memoryStream);
    //		SaveManager.LoadScreenshot_FileStream(binaryReader, ref _info.Screenshot);
    //		SaveManager.MoveToStartPosionAtHeader(binaryReader, SaveManager.FileHeader.Main);
    //		SaveManager.VersionNum = binaryReader.ReadUInt32();
    //		if (SaveManager.VersionNum >= 28u)
    //		{
    //			_info.IsErZhouMu = binaryReader.ReadBoolean();
    //		}
    //		else
    //		{
    //			_info.IsErZhouMu = false;
    //		}
    //		SaveManager.LevelIndex = binaryReader.ReadInt32();
    //		_info.levelIndex = SaveManager.LevelIndex;
    //		_info.LevelName = Langue.get_string((ulong)((long)(PalMain.MapOffset + SaveManager.LevelIndex)), "default");
    //		_info.LastModifyTime = DateTime.FromBinary(binaryReader.ReadInt64());
    //		_info.GameTotleTime = binaryReader.ReadSingle();
    //		_info.GameDifficulty = binaryReader.ReadInt32();
    //		int num = binaryReader.ReadInt32();
    //		_info.players = new List<SaveManager.SaveInfo.PlayerData>(num);
    //		for (int i = 0; i < num; i++)
    //		{
    //			SaveManager.SaveInfo.PlayerData playerData = new SaveManager.SaveInfo.PlayerData();
    //			try
    //			{
    //				Langue langue = new Langue(binaryReader);
    //				playerData.name = langue.get_string();
    //			}
    //			catch
    //			{
    //				Debug.Log("SaveManager.GetDataList Exception");
    //			}
    //			playerData.level = binaryReader.ReadInt32();
    //			_info.players.Add(playerData);
    //		}
    //		ulong nameID = binaryReader.ReadUInt64();
    //		Chapter chapter = new Chapter(nameID);
    //		_info.ChapterName = chapter.Name;
    //		_info.IsDirty = false;
    //		binaryReader.Close();
    //		memoryStream.Close();
    //	}

    //	// Token: 0x06003259 RID: 12889 RVA: 0x0016E194 File Offset: 0x0016C394
    //	private static bool SaveScreenshot_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Screen);
    //		RenderTexture temporary = RenderTexture.GetTemporary(256, 256, 24);
    //		Camera.main.targetTexture = temporary;
    //		bool hdr = Camera.main.hdr;
    //		Camera.main.hdr = false;
    //		Texture2D texture2D = new Texture2D(256, 256, TextureFormat.RGB24, false);
    //		Camera.main.Render();
    //		RenderTexture.active = temporary;
    //		texture2D.ReadPixels(new Rect(0f, 0f, 256f, 256f), 0, 0);
    //		Camera.main.targetTexture = null;
    //		RenderTexture.active = null;
    //		RenderTexture.ReleaseTemporary(temporary);
    //		Camera.main.hdr = hdr;
    //		byte[] array = texture2D.EncodeToPNG();
    //		int value = array.Length;
    //		_writer.Write(256);
    //		_writer.Write(256);
    //		_writer.Write(value);
    //		_writer.Write(array);
    //		UnityEngine.Object.Destroy(texture2D);
    //		return true;
    //	}

    //	// Token: 0x0600325A RID: 12890 RVA: 0x0016E280 File Offset: 0x0016C480
    //	private static bool SaveMain_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Main);
    //		string text = SaveManager.SaveMainCore(_writer);
    //		if (text != string.Empty)
    //		{
    //			Debug.LogError(text);
    //			return false;
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600325B RID: 12891 RVA: 0x0016E2B4 File Offset: 0x0016C4B4
    //	private static bool SaveItemAndBuffdebuff_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.ItemBuffDebuff);
    //		ItemManager.GetInstance().Save(_writer);
    //		BuffDebuffManager.GetInstance().Save(_writer);
    //		return true;
    //	}

    //	// Token: 0x0600325C RID: 12892 RVA: 0x0016E2D4 File Offset: 0x0016C4D4
    //	private static bool SaveStrangeNews_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.StrangeNews);
    //		UIInformation_StrangeNews_Item.TypeData[] items = UIInformation_StrangeNews_Item.Items;
    //		List<int> list = new List<int>();
    //		for (int i = 0; i < items.Length; i++)
    //		{
    //			UIInformation_StrangeNews_Item.TitleData[] titleDatas = items[i].TitleDatas;
    //			for (int j = 0; j < titleDatas.Length; j++)
    //			{
    //				if (titleDatas[j].Position > 0)
    //				{
    //					list.Add(titleDatas[j].TitleID);
    //					list.Add(titleDatas[j].Position);
    //				}
    //			}
    //		}
    //		int num = list.Count >> 1;
    //		_writer.Write(num);
    //		for (int k = 0; k < num; k++)
    //		{
    //			_writer.Write(list[k << 1]);
    //			_writer.Write(list[(k << 1) + 1]);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600325D RID: 12893 RVA: 0x0016E3A8 File Offset: 0x0016C5A8
    //	private static bool SaveHelp_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Help);
    //		List<uint> list = new List<uint>();
    //		UIInformation_Help_Item.ItemClass[] items = UIInformation_Help_Item.Items;
    //		_writer.Write(items.Length);
    //		uint num = 0u;
    //		while ((ulong)num < (ulong)((long)items.Length))
    //		{
    //			list.Clear();
    //			UIInformation_Help_Item.ItemClass[] subItems = items[(int)((UIntPtr)num)].SubItems;
    //			uint num2 = 0u;
    //			while ((ulong)num2 < (ulong)((long)subItems.Length))
    //			{
    //				if (subItems[(int)((UIntPtr)num2)].IsOpen)
    //				{
    //					list.Add(num2);
    //				}
    //				num2 += 1u;
    //			}
    //			_writer.Write(num);
    //			_writer.Write((uint)list.Count);
    //			if (list.Count > 0)
    //			{
    //				foreach (uint value in list)
    //				{
    //					_writer.Write(value);
    //				}
    //			}
    //			num += 1u;
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600325E RID: 12894 RVA: 0x0016E4A0 File Offset: 0x0016C6A0
    //	private static bool SaveTempLayer_FileStream(BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.TempLayer);
    //		GameObject gameObject = GameObject.Find(SaveManager.TempGameLayerName);
    //		if (gameObject == null)
    //		{
    //			_writer.Write(0);
    //			return false;
    //		}
    //		SavePrefabTarget[] componentsInChildren = gameObject.GetComponentsInChildren<SavePrefabTarget>();
    //		_writer.Write(componentsInChildren.Length);
    //		foreach (SavePrefabTarget savePrefabTarget in componentsInChildren)
    //		{
    //			savePrefabTarget.Save(_writer);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600325F RID: 12895 RVA: 0x0016E50C File Offset: 0x0016C70C
    //	private static void LoadScreenshot_FileStream(BinaryReader _reader, ref Texture2D _screenshot)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.Screen);
    //		int num = _reader.ReadInt32();
    //		int num2 = _reader.ReadInt32();
    //		if (_screenshot == null)
    //		{
    //			_screenshot = new Texture2D(num, num2, TextureFormat.ARGB32, false);
    //		}
    //		else if (_screenshot.width != num || _screenshot.height != num2)
    //		{
    //			UnityEngine.Object.Destroy(_screenshot);
    //			_screenshot = new Texture2D(num, num2, TextureFormat.ARGB32, false);
    //		}
    //		int count = _reader.ReadInt32();
    //		byte[] data = _reader.ReadBytes(count);
    //		_screenshot.LoadImage(data);
    //	}

    //	// Token: 0x06003260 RID: 12896 RVA: 0x0016E590 File Offset: 0x0016C790
    //	private static void LoadMain_FileStream(BinaryReader _reader)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.Main);
    //		string text = SaveManager.LoadMainCore(_reader);
    //		if (text != string.Empty)
    //		{
    //			Debug.LogError(text);
    //			return;
    //		}
    //	}

    //	// Token: 0x06003261 RID: 12897 RVA: 0x0016E5C4 File Offset: 0x0016C7C4
    //	private static void LoadItemAndBuffdebuff_FileStream(BinaryReader _reader)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.ItemBuffDebuff);
    //		ItemManager.GetInstance().Load(_reader);
    //		BuffDebuffManager.GetInstance().Load(_reader);
    //	}

    //	// Token: 0x06003262 RID: 12898 RVA: 0x0016E5E4 File Offset: 0x0016C7E4
    //	private static void LoadStrangeNews_FileStream(BinaryReader _reader)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.StrangeNews);
    //		UIInformation_StrangeNews_Item.TypeData[] items = UIInformation_StrangeNews_Item.Items;
    //		Dictionary<int, UIInformation_StrangeNews_Item.TitleData> dictionary = new Dictionary<int, UIInformation_StrangeNews_Item.TitleData>();
    //		foreach (UIInformation_StrangeNews_Item.TypeData typeData in items)
    //		{
    //			foreach (UIInformation_StrangeNews_Item.TitleData titleData in typeData.TitleDatas)
    //			{
    //				dictionary[titleData.TitleID] = titleData;
    //				titleData.Position = 0;
    //			}
    //		}
    //		UIInformation_StrangeNews_Item.SetDirty();
    //		int num = _reader.ReadInt32();
    //		for (int k = 0; k < num; k++)
    //		{
    //			int key = _reader.ReadInt32();
    //			int position = _reader.ReadInt32();
    //			UIInformation_StrangeNews_Item.TitleData titleData2;
    //			if (dictionary.TryGetValue(key, out titleData2))
    //			{
    //				titleData2.Position = position;
    //			}
    //		}
    //	}

    //	// Token: 0x06003263 RID: 12899 RVA: 0x0016E6B0 File Offset: 0x0016C8B0
    //	private static void LoadHelp_FileStream(BinaryReader _reader)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.Help);
    //		UIInformation_Help_Item.ReStart();
    //		UIInformation_Help_Item.ItemClass[] items = UIInformation_Help_Item.Items;
    //		List<uint> list = new List<uint>();
    //		int num = _reader.ReadInt32();
    //		for (int i = 0; i < num; i++)
    //		{
    //			list.Clear();
    //			uint num2 = _reader.ReadUInt32();
    //			uint num3 = _reader.ReadUInt32();
    //			if (0u < num3)
    //			{
    //				list.Capacity = (int)num3;
    //				for (uint num4 = 0u; num4 < num3; num4 += 1u)
    //				{
    //					list.Add(_reader.ReadUInt32());
    //				}
    //				if ((ulong)num2 < (ulong)((long)items.Length))
    //				{
    //					UIInformation_Help_Item.ItemClass itemClass = items[(int)((UIntPtr)num2)];
    //					foreach (uint num5 in list)
    //					{
    //						if ((ulong)num5 < (ulong)((long)itemClass.SubItems.Length))
    //						{
    //							itemClass.SubItems[(int)((UIntPtr)num5)].IsOpen = true;
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003264 RID: 12900 RVA: 0x0016E7C4 File Offset: 0x0016C9C4
    //	public static bool LoadTempLayer_FileStream(BinaryReader _reader)
    //	{
    //		SaveManager.MoveToStartPosionAtHeader(_reader, SaveManager.FileHeader.TempLayer);
    //		GameObject gameObject = GameObject.Find(SaveManager.TempGameLayerName);
    //		if (gameObject != null)
    //		{
    //			UnityEngine.Object.Destroy(gameObject);
    //		}
    //		GameObject gameObject2 = new GameObject(SaveManager.TempGameLayerName);
    //		int num = _reader.ReadInt32();
    //		for (int i = 0; i < num; i++)
    //		{
    //			if (!SavePrefabTarget.Load(_reader, gameObject2.transform))
    //			{
    //				Debug.LogError("读取 TempGameLayer 时出错");
    //				return false;
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x170003E2 RID: 994
    //	// (get) Token: 0x06003265 RID: 12901 RVA: 0x0016E83C File Offset: 0x0016CA3C
    //	public static SaveManager.PalGlobalData GlobalData
    //	{
    //		get
    //		{
    //			return SaveManager.mPalGlobalData;
    //		}
    //	}

    //	// Token: 0x06003266 RID: 12902 RVA: 0x0016E844 File Offset: 0x0016CA44
    //	public static void ResetGlobalData()
    //	{
    //		MoviesManager.Instance.ResetToDefault();
    //		SaveManager.mPalGlobalData.mCircle = false;
    //		SaveManager.mPalGlobalData.mHadCheck = false;
    //		SaveManager.mPalGlobalData.mLSI = 0;
    //		OptionConfig.GetInstance().ReLoad();
    //	}

    //	// Token: 0x06003267 RID: 12903 RVA: 0x0016E87C File Offset: 0x0016CA7C
    //	public static void ReadGlobalDataFromBuffer(byte[] buffer)
    //	{
    //		MemoryStream memoryStream = new MemoryStream(buffer);
    //		BinaryReader binaryReader = new BinaryReader(memoryStream);
    //		MoviesManager.Instance.LoadFromReader(binaryReader);
    //		SaveManager.mPalGlobalData.mCircle = binaryReader.ReadBoolean();
    //		SaveManager.mPalGlobalData.mHadCheck = binaryReader.ReadBoolean();
    //		SaveManager.mPalGlobalData.mLSI = binaryReader.ReadInt32();
    //		binaryReader.Close();
    //		memoryStream.Close();
    //	}

    //	// Token: 0x06003268 RID: 12904 RVA: 0x0016E8E0 File Offset: 0x0016CAE0
    //	public static byte[] WriteGlobalDataToBuffer()
    //	{
    //		MemoryStream memoryStream = new MemoryStream(1024);
    //		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
    //		MoviesManager.Instance.SaveToWriter(binaryWriter);
    //		binaryWriter.Write(SaveManager.mPalGlobalData.mCircle);
    //		binaryWriter.Write(SaveManager.mPalGlobalData.mHadCheck);
    //		binaryWriter.Write(SaveManager.mPalGlobalData.mLSI);
    //		int num = (int)binaryWriter.BaseStream.Position;
    //		binaryWriter.Close();
    //		byte[] array = new byte[num];
    //		Array.Copy(memoryStream.GetBuffer(), array, num);
    //		memoryStream.Close();
    //		return array;
    //	}

    //	// Token: 0x06003269 RID: 12905 RVA: 0x0016E968 File Offset: 0x0016CB68
    //	public static byte[] PackageAllFile(string _path, string _file)
    //	{
    //		MemoryStream memoryStream = new MemoryStream(10485760);
    //		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
    //		byte[] array = null;
    //		try
    //		{
    //			binaryWriter.Seek(SaveManager.GetHeaderOffset(SaveManager.FileHeader.StartData), SeekOrigin.Begin);
    //			if (!SaveManager.LoadScreenshot(string.Format("{0}/{1}.bin", _path, _file), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadMain(string.Format("{0}/Main", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadItemAndBuffdebuff(string.Format("{0}/ItemAndBuffdebuff", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadStrangeNews(string.Format("{0}/StrangeNews", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadHelp(string.Format("{0}/Help", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadOrnamentItemIsGet(string.Format("{0}/OrnamentItemIsGet", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadFashionClothItemIsGet(string.Format("{0}/FashionClothItemIsGet", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadTempGameLayer(string.Format("{0}/TempGameLayer", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadPlayer(string.Format("{0}/Player", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			if (!SaveManager.LoadDynamicData(string.Format("{0}/DynamicData", _path), binaryWriter))
    //			{
    //				throw new Exception();
    //			}
    //			int num = (int)binaryWriter.BaseStream.Position;
    //			array = new byte[num];
    //			binaryWriter.Close();
    //			Array.Copy(memoryStream.GetBuffer(), array, num);
    //			memoryStream.Close();
    //		}
    //		catch
    //		{
    //			binaryWriter.Close();
    //			memoryStream.Close();
    //			return null;
    //		}
    //		return array;
    //	}

    //	// Token: 0x0600326A RID: 12906 RVA: 0x0016EB20 File Offset: 0x0016CD20
    //	private static bool LoadScreenshot(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Screen);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x0600326B RID: 12907 RVA: 0x0016EB50 File Offset: 0x0016CD50
    //	private static bool LoadMain(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Main);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x0600326C RID: 12908 RVA: 0x0016EB80 File Offset: 0x0016CD80
    //	private static bool LoadItemAndBuffdebuff(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.ItemBuffDebuff);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x0600326D RID: 12909 RVA: 0x0016EBB0 File Offset: 0x0016CDB0
    //	private static bool LoadStrangeNews(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.StrangeNews);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		List<int> list = new List<int>();
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(_path), Encoding.UTF8))
    //		{
    //			while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
    //			{
    //				int item = binaryReader.ReadInt32();
    //				int item2 = binaryReader.ReadInt32();
    //				list.Add(item);
    //				list.Add(item2);
    //			}
    //		}
    //		int num = list.Count >> 1;
    //		_writer.Write(num);
    //		for (int i = 0; i < num; i++)
    //		{
    //			_writer.Write(list[i << 1]);
    //			_writer.Write(list[(i << 1) + 1]);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600326E RID: 12910 RVA: 0x0016ECA0 File Offset: 0x0016CEA0
    //	private static bool LoadHelp(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.Help);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		_writer.Write(9);
    //		List<uint>[] array = new List<uint>[9];
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(_path), Encoding.UTF8))
    //		{
    //			while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
    //			{
    //				uint num = binaryReader.ReadUInt32();
    //				uint num2 = binaryReader.ReadUInt32();
    //				array[(int)((UIntPtr)num)] = new List<uint>();
    //				for (uint num3 = 0u; num3 < num2; num3 += 1u)
    //				{
    //					array[(int)((UIntPtr)num)].Add(binaryReader.ReadUInt32());
    //				}
    //			}
    //		}
    //		for (int i = 0; i < 9; i++)
    //		{
    //			_writer.Write(i);
    //			if (array[i] == null)
    //			{
    //				_writer.Write(0);
    //			}
    //			else
    //			{
    //				_writer.Write(array[i].Count);
    //				foreach (uint value in array[i])
    //				{
    //					_writer.Write(value);
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600326F RID: 12911 RVA: 0x0016EE0C File Offset: 0x0016D00C
    //	private static bool LoadOrnamentItemIsGet(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.OrnamentItemTypeCache);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x06003270 RID: 12912 RVA: 0x0016EE3C File Offset: 0x0016D03C
    //	private static bool LoadFashionClothItemIsGet(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.FashionClothItemTypeCache);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x06003271 RID: 12913 RVA: 0x0016EE6C File Offset: 0x0016D06C
    //	private static bool LoadTempGameLayer(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.TempLayer);
    //		_writer.Write(0);
    //		return true;
    //	}

    //	// Token: 0x06003272 RID: 12914 RVA: 0x0016EE80 File Offset: 0x0016D080
    //	private static bool LoadPlayer(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.PlayerManager);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}

    //	// Token: 0x06003273 RID: 12915 RVA: 0x0016EEB0 File Offset: 0x0016D0B0
    //	private static bool LoadDynamicData(string _path, BinaryWriter _writer)
    //	{
    //		SaveManager.WirteCurPositionAtHeader(_writer, SaveManager.FileHeader.DynamicObjsDataManager);
    //		if (!File.Exists(_path))
    //		{
    //			return false;
    //		}
    //		byte[] buffer = File.ReadAllBytes(_path);
    //		_writer.Write(buffer);
    //		return true;
    //	}


    //	// Token: 0x02000722 RID: 1826
    //	[Serializable]
    //	public class SaveInfo : IComparable<SaveManager.SaveInfo>
    //	{
    //		// Token: 0x06003275 RID: 12917 RVA: 0x0016EEEC File Offset: 0x0016D0EC
    //		public int CompareTo(SaveManager.SaveInfo other)
    //		{
    //			return other.LastModifyTime.CompareTo(this.LastModifyTime);
    //		}

    //		// Token: 0x04002DC4 RID: 11716
    //		public string BasePath;

    //		// Token: 0x04002DC5 RID: 11717
    //		public int levelIndex;

    //		// Token: 0x04002DC6 RID: 11718
    //		public string LevelName;

    //		// Token: 0x04002DC7 RID: 11719
    //		public DateTime LastModifyTime;

    //		// Token: 0x04002DC8 RID: 11720
    //		public float GameTotleTime;

    //		// Token: 0x04002DC9 RID: 11721
    //		public Texture2D Screenshot;

    //		// Token: 0x04002DCA RID: 11722
    //		public int GameDifficulty;

    //		// Token: 0x04002DCB RID: 11723
    //		public List<SaveManager.SaveInfo.PlayerData> players;

    //		// Token: 0x04002DCC RID: 11724
    //		public string ChapterName;

    //		// Token: 0x04002DCD RID: 11725
    //		public bool IsErZhouMu;

    //		// Token: 0x04002DCE RID: 11726
    //		public bool IsDirty;

    //		// Token: 0x02000723 RID: 1827
    //		public class PlayerData
    //		{
    //			// Token: 0x04002DCF RID: 11727
    //			public string name;

    //			// Token: 0x04002DD0 RID: 11728
    //			public int level;
    //		}
    //	}

    //	// Token: 0x02000724 RID: 1828
    //	public class InheritStruct
    //	{
    //		// Token: 0x04002DD1 RID: 11729
    //		public bool Level;

    //		// Token: 0x04002DD2 RID: 11730
    //		public bool Item;

    //		// Token: 0x04002DD3 RID: 11731
    //		public bool Achievement;

    //		// Token: 0x04002DD4 RID: 11732
    //		public bool Skill;

    //		// Token: 0x04002DD5 RID: 11733
    //		public bool Renown;

    //		// Token: 0x04002DD6 RID: 11734
    //		public bool Money;
    //	}

    //	// Token: 0x02000725 RID: 1829
    //	public enum FileHeader
    //	{
    //		// Token: 0x04002DD8 RID: 11736
    //		Screen,
    //		// Token: 0x04002DD9 RID: 11737
    //		Main,
    //		// Token: 0x04002DDA RID: 11738
    //		ItemBuffDebuff,
    //		// Token: 0x04002DDB RID: 11739
    //		StrangeNews,
    //		// Token: 0x04002DDC RID: 11740
    //		Help,
    //		// Token: 0x04002DDD RID: 11741
    //		OrnamentItemTypeCache,
    //		// Token: 0x04002DDE RID: 11742
    //		FashionClothItemTypeCache,
    //		// Token: 0x04002DDF RID: 11743
    //		TempLayer,
    //		// Token: 0x04002DE0 RID: 11744
    //		PlayerManager,
    //		// Token: 0x04002DE1 RID: 11745
    //		DynamicObjsDataManager,
    //		// Token: 0x04002DE2 RID: 11746
    //		StartData
    //	}

    //	// Token: 0x02000726 RID: 1830
    //	public class PalGlobalData
    //	{
    //		// Token: 0x04002DE3 RID: 11747
    //		public bool mCircle;

    //		// Token: 0x04002DE4 RID: 11748
    //		public bool mHadCheck;

    //		// Token: 0x04002DE5 RID: 11749
    //		public int mLSI;
    //	}
}
