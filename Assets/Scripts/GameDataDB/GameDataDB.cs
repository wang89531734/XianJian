using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class GameDataDB
{
    private static IConverter m_Conevrt;

    private static string m_MapBlockPath;

    private static string m_DBF_Path;

    private static string m_LanguagePath;

    public static T_GameDB<S_MapData> MapDB = new T_GameDB<S_MapData>();

    //	public static T_GameDB<S_MapConnect> MapConnectDB = new T_GameDB<S_MapConnect>();

    //	public static T_GameDB<S_NpcData> NpcDB = new T_GameDB<S_NpcData>();

    //	public static T_GameDB<S_NpcAI> NpcAIDB = new T_GameDB<S_NpcAI>();

    //	public static T_GameDB<S_Treasure> TreasureDB = new T_GameDB<S_Treasure>();

    //	public static T_GameDB<S_Trap> TrapDB = new T_GameDB<S_Trap>();

    public static T_GameDB<S_StartRoleData> StartRoleDB = new T_GameDB<S_StartRoleData>();

    public static T_GameDB<S_Level> LevelDB = new T_GameDB<S_Level>();

    public static T_GameDB<S_Item> ItemDB = new T_GameDB<S_Item>();

    public static T_GameDB<S_RoleAttrPlus_Tmp> RoleAttrPlusDB = new T_GameDB<S_RoleAttrPlus_Tmp>();

    public static T_GameDB<S_SkillSlot> SkillPoolDB = new T_GameDB<S_SkillSlot>();

    public static T_GameDB<S_Skill> SkillDB = new T_GameDB<S_Skill>();

    public static T_GameDB<S_BufferData> BufferDB = new T_GameDB<S_BufferData>();

    public static T_GameDB<S_SuperSkillSlot> SuperSkillDB = new T_GameDB<S_SuperSkillSlot>();

    //	public static T_GameDB<S_Quest> QuestDB = new T_GameDB<S_Quest>();

    //	public static T_GameDB<S_MainQuest> MainQuestDB = new T_GameDB<S_MainQuest>();

    //	public static T_GameDB<S_TalkString> TalkStringDB = new T_GameDB<S_TalkString>();

    //	public static T_GameDB<S_PartnerTalk> PartnerTalkDB = new T_GameDB<S_PartnerTalk>();

    //	public static T_GameDB<S_Achievement> AchievementDB = new T_GameDB<S_Achievement>();

    //	public static T_GameDB<S_NpcShop> NpcShopDB = new T_GameDB<S_NpcShop>();

    //	public static T_GameDB<S_BattleArea> BattleAreaDB = new T_GameDB<S_BattleArea>();

    //	public static T_GameDB<S_BattleGroup> BattleGroupDB = new T_GameDB<S_BattleGroup>();

    public static T_GameDB<S_AnimationData> AnimationDB = new T_GameDB<S_AnimationData>();

    //	public static T_GameDB<S_EffectData> EffectDB = new T_GameDB<S_EffectData>();

    //	public static T_GameDB<S_OSData> OSDB = new T_GameDB<S_OSData>();

    //	public static T_GameDB<S_MovieData> MovieDB = new T_GameDB<S_MovieData>();

    //	public static T_GameDB<S_MovieSubtitleData> MovieSubDB = new T_GameDB<S_MovieSubtitleData>();

    //	public static T_GameDB<S_MusicData> MusicDB = new T_GameDB<S_MusicData>();

    //	public static T_GameDB<S_MusicEffectData> MusicEffectDB = new T_GameDB<S_MusicEffectData>();

    //	public static T_GameDB<S_MobMoneyExp> MobMoneyExpDB = new T_GameDB<S_MobMoneyExp>();

    //	public static T_GameDB<S_MobAI> MobAIDB = new T_GameDB<S_MobAI>();

    //	public static T_GameDB<S_CombineSkillEffect> CombineSkillEffectDB = new T_GameDB<S_CombineSkillEffect>();

    //	public static T_GameDB<S_SuperSkillEffect> SuperSkillEffectDB = new T_GameDB<S_SuperSkillEffect>();

    //	public static T_GameDB<S_SkillEffect> SkillEffectDB = new T_GameDB<S_SkillEffect>();

    //	public static T_GameDB<S_AttackEffect> AttackEffectDB = new T_GameDB<S_AttackEffect>();

    //	public static T_GameDB<S_SkillCameraPath> SkillCameraPathDB = new T_GameDB<S_SkillCameraPath>();

    //	public static T_GameDB<S_MonsterCompositeData> MonsterCompositeDB = new T_GameDB<S_MonsterCompositeData>();

    //	public static T_GameDB<S_ManufactureFormulaData> ManufactureFormulaDB = new T_GameDB<S_ManufactureFormulaData>();

    //	public static T_GameDB<S_RefineGradeData> RefineGradeDB = new T_GameDB<S_RefineGradeData>();

    //	public static T_GameDB<S_MonsterRefineFactorData> MonsterRefineFactorDB = new T_GameDB<S_MonsterRefineFactorData>();

    //	public static T_GameDB<S_BuffStatusRelationship> BuffStatusDB = new T_GameDB<S_BuffStatusRelationship>();

    //	public static T_GameDB<S_UnlockCode> UnlockCodeDB = new T_GameDB<S_UnlockCode>();

    //	public static T_GameDB<S_UnlockData> UnlockDataDB = new T_GameDB<S_UnlockData>();

    //	public static T_GameDB<S_MemoryPuzzle> MemoryPuzzleDB = new T_GameDB<S_MemoryPuzzle>();

    //	public static T_GameDB<S_UserGuide_Tmp> UserGuideDB = new T_GameDB<S_UserGuide_Tmp>();

    //	public static T_GameDB<S_Help_Tmp> HelpDB = new T_GameDB<S_Help_Tmp>();

    //	public static T_GameDB<S_FilterString> FilterDB = new T_GameDB<S_FilterString>();

    //	public static T_GameDB<S_ReviewStory> ReviewStoryDB = new T_GameDB<S_ReviewStory>();

    public static Dictionary<int, string> LanguageDB = new Dictionary<int, string>();

    public static IEnumerator LoadDBF()
    {
        Debug.Log("GameDB Load DBF Path:" + GameDataDB.m_DBF_Path);
        string dataPath = GameDataDB.m_DBF_Path + "MapData.dbf";
        GameDataDB.LoadFromFile<S_MapData>(GameDataDB.MapDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MapConnect.dbf";
        //GameDataDB.LoadFromFile<S_MapConnect>(GameDataDB.MapConnectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "NpcData.dbf";
        //GameDataDB.LoadFromFile<S_NpcData>(GameDataDB.NpcDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "NpcData1.dbf";
        //GameDataDB.LoadFromFile<S_NpcData>(GameDataDB.NpcDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "NpcData2.dbf";
        //GameDataDB.LoadFromFile<S_NpcData>(GameDataDB.NpcDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "NpcData3.dbf";
        //GameDataDB.LoadFromFile<S_NpcData>(GameDataDB.NpcDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "NpcAI.dbf";
        //GameDataDB.LoadFromFile<S_NpcAI>(GameDataDB.NpcAIDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Treasure.dbf";
        //GameDataDB.LoadFromFile<S_Treasure>(GameDataDB.TreasureDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Trap.dbf";
        //GameDataDB.LoadFromFile<S_Trap>(GameDataDB.TrapDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "TalkString.dbf";
        //GameDataDB.LoadFromFile<S_TalkString>(GameDataDB.TalkStringDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "TalkString1.dbf";
        //GameDataDB.LoadFromFile<S_TalkString>(GameDataDB.TalkStringDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "TalkString2.dbf";
        //GameDataDB.LoadFromFile<S_TalkString>(GameDataDB.TalkStringDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "TalkString3.dbf";
        //GameDataDB.LoadFromFile<S_TalkString>(GameDataDB.TalkStringDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "PartnerTalk.dbf";
        //GameDataDB.LoadFromFile<S_PartnerTalk>(GameDataDB.PartnerTalkDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Achievement.dbf";
        //GameDataDB.LoadFromFile<S_Achievement>(GameDataDB.AchievementDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "NpcShop.dbf";
        //GameDataDB.LoadFromFile<S_NpcShop>(GameDataDB.NpcShopDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "StartRoleData.dbf";
        GameDataDB.LoadFromFile<S_StartRoleData>(GameDataDB.StartRoleDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "Level.dbf";
        GameDataDB.LoadFromFile<S_Level>(GameDataDB.LevelDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "Item.dbf";
        GameDataDB.LoadFromFile<S_Item>(GameDataDB.ItemDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Equip.dbf";
        //GameDataDB.LoadFromFile<S_Item>(GameDataDB.ItemDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "MagicItem.dbf";
        //GameDataDB.LoadFromFile<S_Item>(GameDataDB.ItemDB, dataPath, false);
        dataPath = GameDataDB.m_DBF_Path + "ItemMob.dbf";
        GameDataDB.LoadFromFile<S_Item>(GameDataDB.ItemDB, dataPath, false);
        dataPath = GameDataDB.m_DBF_Path + "RoleAttrPlus.dbf";
        GameDataDB.LoadFromFile<S_RoleAttrPlus_Tmp>(GameDataDB.RoleAttrPlusDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "SkillPool.dbf";
        GameDataDB.LoadFromFile<S_SkillSlot>(GameDataDB.SkillPoolDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "Buffer.dbf";
        GameDataDB.LoadFromFile<S_BufferData>(GameDataDB.BufferDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Skill.dbf";
        //GameDataDB.LoadFromFile<S_Skill>(GameDataDB.SkillDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "SuperSkillPool.dbf";
        //GameDataDB.LoadFromFile<S_SuperSkillSlot>(GameDataDB.SuperSkillDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "BattleArea.dbf";
        //GameDataDB.LoadFromFile<S_BattleArea>(GameDataDB.BattleAreaDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "BattleGroup.dbf";
        //GameDataDB.LoadFromFile<S_BattleGroup>(GameDataDB.BattleGroupDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Quest.dbf";
        //GameDataDB.LoadFromFile<S_Quest>(GameDataDB.QuestDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MainQuest.dbf";
        //GameDataDB.LoadFromFile<S_MainQuest>(GameDataDB.MainQuestDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "AnimationData.dbf";
        GameDataDB.LoadFromFile<S_AnimationData>(GameDataDB.AnimationDB, dataPath, true);
        dataPath = GameDataDB.m_DBF_Path + "AnimationData2.dbf";
        GameDataDB.LoadFromFile<S_AnimationData>(GameDataDB.AnimationDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "EffectData.dbf";
        //GameDataDB.LoadFromFile<S_EffectData>(GameDataDB.EffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "OSData.dbf";
        //GameDataDB.LoadFromFile<S_OSData>(GameDataDB.OSDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MovieData.dbf";
        //GameDataDB.LoadFromFile<S_MovieData>(GameDataDB.MovieDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MovieSubtitleData.dbf";
        //GameDataDB.LoadFromFile<S_MovieSubtitleData>(GameDataDB.MovieSubDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MusicData.dbf";
        //GameDataDB.LoadFromFile<S_MusicData>(GameDataDB.MusicDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MusicEffectData.dbf";
        //GameDataDB.LoadFromFile<S_MusicEffectData>(GameDataDB.MusicEffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MobMoneyExp.dbf";
        //GameDataDB.LoadFromFile<S_MobMoneyExp>(GameDataDB.MobMoneyExpDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MobAI.dbf";
        //GameDataDB.LoadFromFile<S_MobAI>(GameDataDB.MobAIDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "SkillCameraPath.dbf";
        //GameDataDB.LoadFromFile<S_SkillCameraPath>(GameDataDB.SkillCameraPathDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "CombineSkillEffect.dbf";
        //GameDataDB.LoadFromFile<S_CombineSkillEffect>(GameDataDB.CombineSkillEffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "SuperSkillEffect.dbf";
        //GameDataDB.LoadFromFile<S_SuperSkillEffect>(GameDataDB.SuperSkillEffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "SkillEffect.dbf";
        //GameDataDB.LoadFromFile<S_SkillEffect>(GameDataDB.SkillEffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "AttackEffect.dbf";
        //GameDataDB.LoadFromFile<S_AttackEffect>(GameDataDB.AttackEffectDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MonsterCompositeTable.dbf";
        //GameDataDB.LoadFromFile<S_MonsterCompositeData>(GameDataDB.MonsterCompositeDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "ManufactureFormula.dbf";
        //GameDataDB.LoadFromFile<S_ManufactureFormulaData>(GameDataDB.ManufactureFormulaDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "RefineGrade.dbf";
        //GameDataDB.LoadFromFile<S_RefineGradeData>(GameDataDB.RefineGradeDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MonsterRefineFactor.dbf";
        //GameDataDB.LoadFromFile<S_MonsterRefineFactorData>(GameDataDB.MonsterRefineFactorDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "BuffStatusTable.dbf";
        //GameDataDB.LoadFromFile<S_BuffStatusRelationship>(GameDataDB.BuffStatusDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "UnlockCode.dbf";
        //GameDataDB.LoadFromFile<S_UnlockCode>(GameDataDB.UnlockCodeDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "UnlockData.dbf";
        //GameDataDB.LoadFromFile<S_UnlockData>(GameDataDB.UnlockDataDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "MemoryPuzzle.dbf";
        //GameDataDB.LoadFromFile<S_MemoryPuzzle>(GameDataDB.MemoryPuzzleDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "UserGuide.dbf";
        //GameDataDB.LoadFromFile<S_UserGuide_Tmp>(GameDataDB.UserGuideDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "Help.dbf";
        //GameDataDB.LoadFromFile<S_Help_Tmp>(GameDataDB.HelpDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "FilterString.dbf";
        //GameDataDB.LoadFromFile<S_FilterString>(GameDataDB.FilterDB, dataPath, true);
        //dataPath = GameDataDB.m_DBF_Path + "FilterString1.dbf";
        //GameDataDB.LoadFromFile<S_FilterString>(GameDataDB.FilterDB, dataPath, false);
        //dataPath = GameDataDB.m_DBF_Path + "ReviewStory.dbf";
        //GameDataDB.LoadFromFile<S_ReviewStory>(GameDataDB.ReviewStoryDB, dataPath, true);
        yield return null;
        yield break;
    }

    public static IEnumerator LoadLanguage()
    {
        string text = "Load Language From [" + GameDataDB.m_LanguagePath + "] Loading ";
        Debug.Log(text);
        GameDataDB.LanguageDB.Clear();
        StreamReader streamReader = new StreamReader(GameDataDB.m_LanguagePath + "Client_TC.xml");
        if (streamReader != null)
        {
            string xml = streamReader.ReadToEnd();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("descendant::Language");
            if (xmlNode != null)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;
                string attribute = xmlElement.GetAttribute("size");
                int num = 11000;
                if (attribute.Length > 0)
                {
                    int.TryParse(attribute, out num);
                }
                for (int i = 1; i <= num; i++)
                {
                    string xpath = string.Format("descendant::ID_{0}", i);
                    XmlNode xmlNode2 = xmlNode.SelectSingleNode(xpath);
                    if (xmlNode2 != null && xmlNode2.InnerText.Length != 0)
                    {

                        GameDataDB.LanguageDB.Add(i, ChineseConvertor.TCtoSC(xmlNode2.InnerText));

                    }
                }
                Debug.Log(text + "OK Size:" + GameDataDB.LanguageDB.Count);
            }
            else
            {
                Debug.LogError(text + "Error: Language Node Not Exist");
            }
        }
        else
        {
            Debug.LogError(text + " 無法載入");
        }
        yield return null;
        yield break;
    }

    public static string StrID(int id)
    {
        if (GameDataDB.LanguageDB.ContainsKey(id))
        {
            return GameDataDB.LanguageDB[id];
        }
        return "";
    }

    public static string TransStringByLanguageType(string OrgString)
    {
        return ChineseConvertor.TCtoSC(OrgString);
    }

    public static void SetConevrt(IConverter conevrt)
    {
        GameDataDB.m_Conevrt = conevrt;
    }

    public static void Initialize(string MapBlockPath, string DBF_Path, string LanguagePath)
    {
        GameDataDB.m_MapBlockPath = GameDataDB.MakePath(MapBlockPath);
        GameDataDB.m_DBF_Path = GameDataDB.MakePath(DBF_Path);
        GameDataDB.m_LanguagePath = GameDataDB.MakePath(LanguagePath);
        Debug.Log("MapBlockPath:" + GameDataDB.m_MapBlockPath);
        Debug.Log("DBF_Path:" + GameDataDB.m_DBF_Path);
        Debug.Log("Language_Path:" + GameDataDB.m_LanguagePath);
    }

    private static string MakePath(string Source)
    {
        int num = Source.IndexOf(":");
        bool flag = Source.StartsWith("\\\\");
        string result = Source;
        if (num == -1 && !flag)
        {
            result = Application.dataPath + "\\..\\" + Source + "\\";
        }
        return result;
    }

    //	public static IEnumerator ReadMapBlock()
    //	{
    //		Debug.Log("GameDB Load MapBlock_URL Path:" + GameDataDB.m_MapBlockPath);
    //		for (int i = 1; i <= 6; i++)
    //		{
    //			string url = "";
    //			string str = "st_0" + i;
    //			url = GameDataDB.m_MapBlockPath + str + ".txt";
    //			WWW wWW = new WWW(url);
    //			yield return wWW;
    //			if (wWW.isDone)
    //			{
    //				if (wWW.error == null)
    //				{
    //					string arg_D4_0 = wWW.text;
    //				}
    //				else
    //				{
    //					Debug.LogError("ReadMapBlock error =>" + wWW.error);
    //				}
    //			}
    //		}
    //		yield break;
    //	}

    private static bool LoadFromFile<T>(T_GameDB<T> GameDB, string DataPath, bool ClearData)
    {
        if (ClearData)
        {
            GameDB.Clear();
        }
        string name = typeof(I_BaseDBF).Name;
        string str = string.Concat(new string[]
        {
                "Load DBF[",
                name,
                "] From [",
                DataPath,
                "] "
        });
        Debug.Log(str + " Loading");
        if (File.Exists(DataPath + "s"))
        {
            string txt = C_FileCodec.DecodeFile2(DataPath + "s");
            List<T> datas = GameDataDB.CovertData<T>(txt);
            GameDB.AddDataFromList(datas);
            Debug.Log(str + "OK");
            return true;
        }
        StreamReader streamReader = new StreamReader(DataPath);
        if (streamReader != null)
        {
            string txt2 = streamReader.ReadToEnd();
            List<T> datas2 = GameDataDB.CovertData<T>(txt2);
            GameDB.AddDataFromList(datas2);
            Debug.Log(str + "OK");
            return true;
        }
        Debug.LogError(str + " 無法載入");
        return false;
    }

    private static List<T> CovertData<T>(string txt)
    {
        List<T> list = new List<T>();
        string text = "\r\n";
        string[] array = txt.Split(text.ToCharArray());
        string[] array2 = array;
        for (int i = 0; i < array2.Length; i++)
        {
            string text2 = array2[i];
            if (!(text2 == ""))
            {
                T t = GameDataDB.m_Conevrt.deserializeObject<T>(text2);
                if (t is I_BaseDBF)
                {
                    I_BaseDBF i_BaseDBF = t as I_BaseDBF;
                    i_BaseDBF.ParseJson(text2, GameDataDB.m_Conevrt, i_BaseDBF);
                }
                list.Add(t);
            }
        }
        return list;
    }
}
