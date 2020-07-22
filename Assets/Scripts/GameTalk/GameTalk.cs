using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using YouYou;

public class GameTalk : MonoBehaviour
{
    private static float m_TurnDirSpeed;

    private static bool m_PlayStory;

    //	public static bool GetFlag(int flag)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.GetFlag(flag);
    //	}

    //	public static void FlagON(int flag)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.FlagON(flag);
    //	}

    //	public static void FlagOFF(int flag)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.FlagOFF(flag);
    //	}

    //	public static void FlagSet(int flag, bool val)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.FlagSet(flag, val);
    //	}

    //	public static void ChangeMap(int mapid, float x, float y, float z, float dir)
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			if (mapid == Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID)
    //			{
    //				GameTalk.SetRolePos(-1, x, y, z);
    //				GameTalk.SetRoleDir(-1, dir, 0, 0);
    //				Swd6Application.instance.StartCoroutine(GameTalk.WaitFadeTime(0f, 1f));
    //			}
    //			else
    //			{
    //				Swd6Application.instance.ChangeMap("ExploreState", mapid, x, y, z, dir);
    //			}
    //		}
    //	}

    //	public static void ChangeMap(int mapid, string targetName)
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			if (mapid == Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID)
    //			{
    //				GameObject gameObject = GameObject.Find(targetName);
    //				if (gameObject == null)
    //				{
    //					UnityEngine.Debug.LogWarning("ChangeMap::找不到定位點::" + targetName);
    //					return;
    //				}
    //				Vector3 position = gameObject.transform.position;
    //				float y = gameObject.transform.eulerAngles.y;
    //				GameTalk.ChangeMap(mapid, position.x, position.y, position.z, y);
    //			}
    //			else
    //			{
    //				Swd6Application.instance.ChangeMap("ExploreState", mapid, targetName);
    //			}
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitChangeMap(int mapid, float x, float y, float z, float dir)
    //	{
    //		GameTalk.<WaitChangeMap>c__Iterator844 <WaitChangeMap>c__Iterator = new GameTalk.<WaitChangeMap>c__Iterator844();
    //		<WaitChangeMap>c__Iterator.mapid = mapid;
    //		<WaitChangeMap>c__Iterator.x = x;
    //		<WaitChangeMap>c__Iterator.y = y;
    //		<WaitChangeMap>c__Iterator.z = z;
    //		<WaitChangeMap>c__Iterator.dir = dir;
    //		<WaitChangeMap>c__Iterator.<$>mapid = mapid;
    //		<WaitChangeMap>c__Iterator.<$>x = x;
    //		<WaitChangeMap>c__Iterator.<$>y = y;
    //		<WaitChangeMap>c__Iterator.<$>z = z;
    //		<WaitChangeMap>c__Iterator.<$>dir = dir;
    //		return <WaitChangeMap>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitChangeMap(int mapid, string targetName)
    //	{
    //		GameTalk.<WaitChangeMap>c__Iterator845 <WaitChangeMap>c__Iterator = new GameTalk.<WaitChangeMap>c__Iterator845();
    //		<WaitChangeMap>c__Iterator.mapid = mapid;
    //		<WaitChangeMap>c__Iterator.targetName = targetName;
    //		<WaitChangeMap>c__Iterator.<$>mapid = mapid;
    //		<WaitChangeMap>c__Iterator.<$>targetName = targetName;
    //		return <WaitChangeMap>c__Iterator;
    //	}

    //	public static void PotRealmChangeMap()
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapID == 0)
    //			{
    //				UnityEngine.Debug.Log("PotRealmChangeMap_地圖id為0!!");
    //				return;
    //			}
    //			Swd6Application.instance.ChangeMap("ExploreState", Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapID, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosX, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosY, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosZ, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapDir);
    //		}
    //	}

    //	public static void OpenBigMap()
    //	{
    //		Swd6Application.instance.m_BigMapSystem.Open();
    //	}

    //	public static void OpenNewZone(int newMapId, bool showHint)
    //	{
    //		Swd6Application.instance.m_BigMapSystem.OpenNewMap(newMapId, showHint);
    //	}

    //	public static void SetZoneState(int mapId, bool enable)
    //	{
    //		Swd6Application.instance.m_BigMapSystem.SetMapState(mapId, enable);
    //	}

    //	public static void SetBackPoint(string name)
    //	{
    //		Swd6Application.instance.m_BigMapSystem.SetBackPoint(name);
    //	}

    //	public static void SetCameraLookTarget(bool bLook)
    //	{
    //		if (bLook)
    //		{
    //			if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //			{
    //				Transform[] componentsInChildren = Swd6Application.instance.m_GameObjSystem.PlayerObj.transform.GetComponentsInChildren<Transform>();
    //				Transform[] array = componentsInChildren;
    //				for (int i = 0; i < array.Length; i++)
    //				{
    //					Transform transform = array[i];
    //					if (transform.name == "CamPos")
    //					{
    //						GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>().m_Target = transform;
    //					}
    //				}
    //			}
    //		}
    //		else
    //		{
    //			GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>().m_Target = null;
    //		}
    //	}

    //	public static void SetCameraLookAt(string target1, string target2)
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.SetLookTargetMode(target1, target2, 0f);
    //		}
    //	}

    //	public static void SetCameraLookAt2(string target1, string target2, float dir)
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.SetLookTargetMode(target1, target2, dir);
    //		}
    //	}

    //	public static void SetCameraNormalMode()
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.SetNormalMode();
    //		}
    //	}

    //	public static void SetCameraData(float dist, float dirX, float dirY)
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.m_Distance = dist;
    //			component.m_XAngle = dirX;
    //			component.m_YAngle = dirY;
    //		}
    //	}

    //	public static void SetSneakGameCamera(float dist, float minYdir, float maxYDir)
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.m_DistanceMin = dist;
    //			component.m_DistanceMax = dist;
    //			component.m_Distance = dist;
    //			component.m_YMinLimit = minYdir;
    //			component.m_YMaxLimit = maxYDir;
    //			component.m_Isphysics = false;
    //			component.camera.useOcclusionCulling = false;
    //		}
    //	}

    //	public static void SetLockCamera(float dist, float dir, float offsetY)
    //	{
    //		if (Swd6Application.instance.m_GameObjSystem.PlayerObj != null)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.m_DistanceMin = dist;
    //			component.m_DistanceMax = dist;
    //			component.m_Distance = dist;
    //			component.m_XAngle = dir;
    //			component.m_YMinLimit = 5f;
    //			component.m_YMaxLimit = 5f;
    //			component.m_Isphysics = false;
    //			component.m_LockMode = true;
    //			component.m_LookOffset = new Vector3(0f, offsetY, 0f);
    //		}
    //	}

    //	public static void SetCameraDOFEffect(bool enabled)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.SetCameraDOFEffect(enabled);
    //	}

    //	public static void SetCameraCullingEffect(bool enabled)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.SetCameraCullingEffect(enabled);
    //	}

    //	public static void PlayStoryTest(int mapid, string storyName)
    //	{
    //		S_MapData mapData = Swd6Application.instance.m_GameDataSystem.GetMapData(mapid);
    //		if (mapData != null)
    //		{
    //			if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //			{
    //				UnityEngine.Debug.Log("PlayStory");
    //			}
    //			Swd6Application.instance.m_StorySystem.PlayStoryTest(mapid, storyName);
    //		}
    //	}

    public static void PlayStory(int mapid, string storyName)
    {     
        S_MapData mapData = GameEntry.Instance.m_GameDataSystem.GetMapData(mapid);
        if (mapData != null)
        {          
            int mapID = GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID;//关闭之前的场景
            UnityEngine.Debug.Log("执行"+ mapID);
            //Swd6Application.instance.m_ExploreSystem.m_AutoHideMapID = mapID;
            //Swd6Application.instance.m_GameObjSystem.HideObjByType2(mapID, ENUM_NpcType.Role, true);
            //Swd6Application.instance.m_GameDataSystem.FlagON(55);
            GameTalk.m_PlayStory = true;
            //Swd6Application.instance.m_ExploreSystem.m_PlayStory = GameTalk.m_PlayStory;
            //Swd6Application.instance.m_ExploreSystem.BattleStep = 0f;
            GameEntry.Instance.m_StorySystem.PlayStory(mapid, storyName);
        }
    }

    //	[DebuggerHidden]
    //	public static IEnumerator IsPlayStoryEnd()
    //	{
    //		return new GameTalk.<IsPlayStoryEnd>c__Iterator846();
    //	}

    //	public static void StartTalk(bool bTalk)
    //	{
    //		if (!bTalk)
    //		{
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.m_EnterTalkEvent = false;
    //			}
    //			UI_TalkDialog.Instance.Close();
    //			GameObject talkTarget = Swd6Application.instance.m_ExploreSystem.TalkTarget;
    //			if (talkTarget != null)
    //			{
    //				M_GameNpc component = talkTarget.GetComponent<M_GameNpc>();
    //				if (component)
    //				{
    //					component.RestoreIdlekMotion();
    //				}
    //			}
    //			if (GameTalk.m_PlayStory)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.m_PlayStory = false;
    //				GameTalk.m_PlayStory = false;
    //			}
    //			Swd6Application.instance.m_ExploreSystem.TalkOver();
    //			GameMapMobSystem.Instance.Resume();
    //		}
    //		else
    //		{
    //			GameMapMobSystem.Instance.Pause();
    //			Swd6Application.instance.m_ExploreSystem.RemoveNoFightEffect();
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.ShowWeapon(false);
    //				if (Swd6Application.instance.m_ExploreSystem.PlayerController.m_EnterTalkEvent)
    //				{
    //					Vector3 eventPos = Vector3.zero;
    //					Vector3 pos = Swd6Application.instance.m_ExploreSystem.PlayerController.Pos;
    //					if (Swd6Application.instance.m_ExploreSystem.m_TalkEventObj != null)
    //					{
    //						eventPos = Swd6Application.instance.m_ExploreSystem.m_TalkEventObj.transform.position;
    //					}
    //					if (MapPathSystem.Instance.FindNearStoryHint(Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID, pos, eventPos))
    //					{
    //						Swd6Application.instance.m_ExploreSystem.AutoSave();
    //					}
    //				}
    //			}
    //		}
    //		GameTalk.LockPlayer(bTalk);
    //	}

    //	public static void StartSubTalk(bool bTalk)
    //	{
    //		if (!bTalk)
    //		{
    //			UI_TalkDialog.Instance.Close();
    //			Swd6Application.instance.m_ExploreSystem.TalkOver();
    //		}
    //		Swd6Application.instance.m_ExploreSystem.m_SubTalk = bTalk;
    //	}

    //	public static void ShowQuestMenu(int questID)
    //	{
    //		UI_TalkDialog.Instance.ShowQuestButton(questID);
    //	}

    //	public static bool IsGetQuest()
    //	{
    //		return UI_TalkDialog.Instance.IsAccessQuest();
    //	}

    //	public static void TalkSpeed(float speed)
    //	{
    //	}

    //	public static void TalkMsg(int roleID, int id)
    //	{
    //		if (roleID == -1)
    //		{
    //			roleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		S_NpcData data = GameDataDB.NpcDB.GetData(roleID);
    //		if (data != null)
    //		{
    //			UI_TalkDialog.Instance.SetName(data.Name);
    //		}
    //		else
    //		{
    //			UI_TalkDialog.Instance.SetName(string.Empty);
    //		}
    //		UI_TalkDialog.Instance.SetContent(id);
    //		UI_TalkDialog.Instance.Open();
    //		MusicSystem.Instance.StopVoice();
    //		S_TalkString data2 = GameDataDB.TalkStringDB.GetData(id);
    //		if (data2 != null && data2.OSID > 0)
    //		{
    //			S_OSData data3 = GameDataDB.OSDB.GetData(data2.OSID);
    //			if (data3 != null)
    //			{
    //				AudioClip voice = ResourceManager.Instance.GetVoice(data3.OSName);
    //				if (voice != null)
    //				{
    //					MusicSystem.Instance.PlayVoice(voice);
    //				}
    //			}
    //		}
    //	}

    //	public static void TalkMsg(int roleID, string msg)
    //	{
    //		if (roleID == -1)
    //		{
    //			roleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		S_NpcData data = GameDataDB.NpcDB.GetData(roleID);
    //		if (data != null)
    //		{
    //			UI_TalkDialog.Instance.SetName(data.Name);
    //		}
    //		else
    //		{
    //			UI_TalkDialog.Instance.SetName(string.Empty);
    //		}
    //		msg = GameDataDB.TransStringByLanguageType(msg);
    //		UI_TalkDialog.Instance.SetContent(msg);
    //		UI_TalkDialog.Instance.Open();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitTalkMsg(int roleID, int id)
    //	{
    //		GameTalk.<WaitTalkMsg>c__Iterator847 <WaitTalkMsg>c__Iterator = new GameTalk.<WaitTalkMsg>c__Iterator847();
    //		<WaitTalkMsg>c__Iterator.roleID = roleID;
    //		<WaitTalkMsg>c__Iterator.id = id;
    //		<WaitTalkMsg>c__Iterator.<$>roleID = roleID;
    //		<WaitTalkMsg>c__Iterator.<$>id = id;
    //		return <WaitTalkMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitTalkMsg(int roleID, string msg)
    //	{
    //		GameTalk.<WaitTalkMsg>c__Iterator848 <WaitTalkMsg>c__Iterator = new GameTalk.<WaitTalkMsg>c__Iterator848();
    //		<WaitTalkMsg>c__Iterator.roleID = roleID;
    //		<WaitTalkMsg>c__Iterator.msg = msg;
    //		<WaitTalkMsg>c__Iterator.<$>roleID = roleID;
    //		<WaitTalkMsg>c__Iterator.<$>msg = msg;
    //		return <WaitTalkMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator TalkMsg()
    //	{
    //		return new GameTalk.<TalkMsg>c__Iterator849();
    //	}

    //	public static void BubbleMsg(int roleID, int id)
    //	{
    //		string name = null;
    //		GameObject taklObj;
    //		if (roleID == -1)
    //		{
    //			roleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			taklObj = Swd6Application.instance.m_ExploreSystem.PlayerObj;
    //			S_RoleData roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(roleID);
    //			name = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name;
    //		}
    //		else
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(roleID);
    //			if (objData == null)
    //			{
    //				return;
    //			}
    //			taklObj = objData.GameObj;
    //			S_NpcData data = GameDataDB.NpcDB.GetData(roleID);
    //			if (data != null)
    //			{
    //				name = data.Name;
    //			}
    //		}
    //		UI_BubbleDialog.Instance.SetName(name);
    //		UI_BubbleDialog.Instance.SetTaklObj(taklObj);
    //		UI_BubbleDialog.Instance.SetContent(id);
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitBubbleMsg(int roleID, int id)
    //	{
    //		GameTalk.<WaitBubbleMsg>c__Iterator84A <WaitBubbleMsg>c__Iterator84A = new GameTalk.<WaitBubbleMsg>c__Iterator84A();
    //		<WaitBubbleMsg>c__Iterator84A.roleID = roleID;
    //		<WaitBubbleMsg>c__Iterator84A.id = id;
    //		<WaitBubbleMsg>c__Iterator84A.<$>roleID = roleID;
    //		<WaitBubbleMsg>c__Iterator84A.<$>id = id;
    //		return <WaitBubbleMsg>c__Iterator84A;
    //	}

    //	public static void PartnerTalkMsg(int groupId, float delay)
    //	{
    //	}

    //	public static void CloseTalkMsg()
    //	{
    //		MusicSystem.Instance.StopVoice();
    //		UI_TalkDialog.Instance.Close();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowTalkSelectMenu(string text)
    //	{
    //		GameTalk.<ShowTalkSelectMenu>c__Iterator84B <ShowTalkSelectMenu>c__Iterator84B = new GameTalk.<ShowTalkSelectMenu>c__Iterator84B();
    //		<ShowTalkSelectMenu>c__Iterator84B.text = text;
    //		<ShowTalkSelectMenu>c__Iterator84B.<$>text = text;
    //		return <ShowTalkSelectMenu>c__Iterator84B;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowTalkSelectMenu(int id)
    //	{
    //		GameTalk.<ShowTalkSelectMenu>c__Iterator84C <ShowTalkSelectMenu>c__Iterator84C = new GameTalk.<ShowTalkSelectMenu>c__Iterator84C();
    //		<ShowTalkSelectMenu>c__Iterator84C.id = id;
    //		<ShowTalkSelectMenu>c__Iterator84C.<$>id = id;
    //		return <ShowTalkSelectMenu>c__Iterator84C;
    //	}

    //	public static void SetTalkSelectText(int id, string text)
    //	{
    //		text = GameDataDB.TransStringByLanguageType(text);
    //		UI_TalkDialog.Instance.SetTalkSelectItemText(id, text);
    //	}

    //	public static void SetTalkSelectText(int id, int strId)
    //	{
    //		UI_TalkDialog.Instance.SetTalkSelectItemText(id, strId);
    //	}

    //	public static int GetTalkSelectID()
    //	{
    //		return UI_TalkDialog.Instance.GetTalkSelectItem();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitAnyKey()
    //	{
    //		return new GameTalk.<WaitAnyKey>c__Iterator84D();
    //	}

    //	public static bool CheckPlayerID(int id)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.m_PlayerID == id;
    //	}

    //	public static int GetPlayerID()
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //	}

    //	public static int GetNpcID()
    //	{
    //		GameObject talkTarget = Swd6Application.instance.m_ExploreSystem.TalkTarget;
    //		if (talkTarget == null)
    //		{
    //			return 0;
    //		}
    //		M_GameRoleBase component = talkTarget.GetComponent<M_GameRoleBase>();
    //		if (component)
    //		{
    //			return component.RoleID;
    //		}
    //		return 0;
    //	}

    //	public static int GetNpcID(GameObject obj)
    //	{
    //		M_GameRoleBase component = obj.GetComponent<M_GameRoleBase>();
    //		if (component)
    //		{
    //			return component.RoleID;
    //		}
    //		return 0;
    //	}

    //	public static void HidePlayer(bool bHide)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HidePlayer(bHide);
    //		if (!bHide)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.ShowWeapon(false);
    //		}
    //	}

    //	public static void LockPlayer(bool bLock)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.LockPlayer = bLock;
    //	}

    //	public static void ShowWeapon(bool bShow)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.PlayerController.ShowWeapon(bShow);
    //	}

    //	public static void ChangeRoleMap(int id, int mapid, float x, float y, float z, float dir)
    //	{
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log("ChangeRoleMap_" + id);
    //		}
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Vector3 vector = new Vector3(x, y, z);
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangePos = vector;
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.Pos = vector;
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.Dir = dir;
    //			}
    //			return;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null)
    //			{
    //				objData.Pos = new Vector3(x, y, z);
    //				objData.Dir = dir;
    //				if (objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						component.Dir = dir;
    //						if (mapid != objData.MapId)
    //						{
    //							ExploreMiniMapSystem.Instance.RemoveQuestIcon(id);
    //							UnityEngine.Object.Destroy(objData.GameObj);
    //							objData.GameObj = null;
    //							objData.MapId = mapid;
    //						}
    //						else
    //						{
    //							component.SetPos(objData.Pos);
    //						}
    //					}
    //				}
    //				else if (mapid != objData.MapId)
    //				{
    //					objData.MapId = mapid;
    //					if (mapid == Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID)
    //					{
    //						Swd6Application.instance.m_GameObjSystem.LoadObj(objData);
    //						Swd6Application.instance.m_GameObjSystem.SetMapObjData(mapid);
    //					}
    //				}
    //			}
    //			else
    //			{
    //				UnityEngine.Debug.Log("ChangeRoleMap找不到角色_" + id);
    //			}
    //		}
    //	}

    //	public static void SetRolePos(int id, float x, float y, float z)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Vector3 playerChangePos = new Vector3(x, y, z);
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangePos = playerChangePos;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null)
    //			{
    //				objData.Pos = new Vector3(x, y, z);
    //				if (objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						component.Pos = objData.Pos;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static void SetRolePos(int id, string targetName)
    //	{
    //		GameObject gameObject = GameObject.Find(targetName);
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogWarning("SetRolePos::找不到定位點::" + targetName);
    //			return;
    //		}
    //		Vector3 position = gameObject.transform.position;
    //		float y = gameObject.transform.eulerAngles.y;
    //		GameTalk.SetRolePos(id, position.x, position.y, position.z);
    //		GameTalk.SetRoleDir(id, y, 0, 0);
    //	}

    //	public static void SetRolePos(int id, string targetName, bool camereLookRoleBack)
    //	{
    //		GameObject gameObject = GameObject.Find(targetName);
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogWarning("SetRolePos::找不到定位點::" + targetName);
    //			return;
    //		}
    //		Vector3 position = gameObject.transform.position;
    //		float y = gameObject.transform.eulerAngles.y;
    //		GameTalk.SetRolePos(id, position.x, position.y, position.z);
    //		GameTalk.SetRoleDir(id, y, 0, 0);
    //		if (camereLookRoleBack)
    //		{
    //			M_PlayerMouseOrbit component = GameObject.Find("Main Camera").GetComponent<M_PlayerMouseOrbit>();
    //			if (component == null)
    //			{
    //				return;
    //			}
    //			component.m_XAngle = y;
    //		}
    //	}

    //	public static void GetRolePos(int id, out float x, out float y, out float z)
    //	{
    //		x = 0f;
    //		y = 0f;
    //		z = 0f;
    //		if (id == -1)
    //		{
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				x = Swd6Application.instance.m_ExploreSystem.PlayerController.Pos.x;
    //				y = Swd6Application.instance.m_ExploreSystem.PlayerController.Pos.y;
    //				z = Swd6Application.instance.m_ExploreSystem.PlayerController.Pos.z;
    //			}
    //			return;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					x = objData.Pos.x;
    //					y = objData.Pos.y;
    //					z = objData.Pos.z;
    //				}
    //			}
    //		}
    //	}

    //	public static Vector3 GetRolePos(int id)
    //	{
    //		Vector3 zero = Vector3.zero;
    //		GameTalk.GetRolePos(id, out zero.x, out zero.y, out zero.z);
    //		return zero;
    //	}

    //	public static void SetRoleDirSpeed(float speed)
    //	{
    //		GameTalk.m_TurnDirSpeed = speed;
    //	}

    //	public static void SetRoleDir(int id, float dir, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.StopMoveToTarget();
    //				if (GameTalk.m_TurnDirSpeed <= 0f)
    //				{
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.Dir = dir;
    //				}
    //				else
    //				{
    //					if (turnMotion == 0)
    //					{
    //						turnMotion = 7;
    //					}
    //					if (waitMotion == 0)
    //					{
    //						waitMotion = 1;
    //					}
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.m_TurnMotion = turnMotion;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.m_WaitMotion = waitMotion;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.SetTurn(dir, GameTalk.m_TurnDirSpeed);
    //					GameTalk.m_TurnDirSpeed = 0f;
    //				}
    //			}
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //			return;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null)
    //			{
    //				objData.Dir = dir;
    //				if (objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						if (GameTalk.m_TurnDirSpeed <= 0f)
    //						{
    //							component.Dir = dir;
    //						}
    //						else
    //						{
    //							if (id != -1)
    //							{
    //								S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //								S_NpcAI data2 = GameDataDB.NpcAIDB.GetData(data.AIMode);
    //								if (turnMotion == 0 && data2 != null)
    //								{
    //									turnMotion = data2.TurnMotion;
    //								}
    //								if (waitMotion == 0 && data2 != null)
    //								{
    //									waitMotion = data2.TalkOverMotion;
    //								}
    //							}
    //							component.m_TurnMotion = turnMotion;
    //							component.m_WaitMotion = waitMotion;
    //							component.SetTurn(dir, GameTalk.m_TurnDirSpeed);
    //						}
    //						GameTalk.m_TurnDirSpeed = 0f;
    //						if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //						{
    //							UnityEngine.Debug.Log("SetRoleDir:" + objData.GameObj.name + objData.Dir);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static void SetRoleDir2(int id, float dir, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.m_ExploreSystem.PlayerController != null)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.StopMoveToTarget();
    //				if (GameTalk.m_TurnDirSpeed <= 0f)
    //				{
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.Dir = dir;
    //				}
    //				else
    //				{
    //					if (turnMotion == 0)
    //					{
    //						turnMotion = 7;
    //					}
    //					if (waitMotion == 0)
    //					{
    //						waitMotion = 1;
    //					}
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.m_TurnMotion = turnMotion;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.m_WaitMotion = waitMotion;
    //					Swd6Application.instance.m_ExploreSystem.PlayerController.SetTurn(dir, GameTalk.m_TurnDirSpeed);
    //					GameTalk.m_TurnDirSpeed = 0f;
    //				}
    //			}
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //			return;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null)
    //			{
    //				dir = GameMath.ClampAngle360(dir);
    //				float num = Mathf.Abs(360f - dir);
    //				if (num <= 1f)
    //				{
    //					dir = num;
    //				}
    //				objData.Dir2 = dir;
    //				if (objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						if (GameTalk.m_TurnDirSpeed <= 0f)
    //						{
    //							Vector3 eulerAngles = component.transform.parent.eulerAngles;
    //							component.transform.parent.eulerAngles = new Vector3(0f, 0f, 0f);
    //							component.transform.eulerAngles = new Vector3(0f, dir, 0f);
    //							component.transform.parent.eulerAngles = eulerAngles;
    //						}
    //						else
    //						{
    //							if (id != -1)
    //							{
    //								S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //								S_NpcAI data2 = GameDataDB.NpcAIDB.GetData(data.AIMode);
    //								if (turnMotion == 0 && data2 != null)
    //								{
    //									turnMotion = data2.TurnMotion;
    //								}
    //								if (waitMotion == 0 && data2 != null)
    //								{
    //									waitMotion = data2.TalkOverMotion;
    //								}
    //							}
    //							component.m_TurnMotion = turnMotion;
    //							component.m_WaitMotion = waitMotion;
    //							component.SetTurn(dir, GameTalk.m_TurnDirSpeed);
    //						}
    //						GameTalk.m_TurnDirSpeed = 0f;
    //						if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //						{
    //							UnityEngine.Debug.Log("SetRoleDir2:" + objData.GameObj.name + objData.Dir);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static float GetRoleDir(int id)
    //	{
    //		if (id == -1)
    //		{
    //			return Swd6Application.instance.m_ExploreSystem.PlayerController.Dir;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					if (objData.Dir == 1000f)
    //					{
    //						objData.Dir = component.Dir;
    //					}
    //					return objData.Dir;
    //				}
    //			}
    //		}
    //		return 0f;
    //	}

    //	public static float GetRoleDir2(int id)
    //	{
    //		if (id == -1)
    //		{
    //			return Swd6Application.instance.m_ExploreSystem.PlayerController.Dir;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					float dir;
    //					if (objData.Dir2 == 1000f)
    //					{
    //						objData.Dir2 = component.Dir2;
    //						dir = objData.Dir2;
    //					}
    //					else
    //					{
    //						dir = objData.Dir2;
    //					}
    //					return dir;
    //				}
    //			}
    //		}
    //		return 0f;
    //	}

    //	public static void FaceRoleDir(int id, int targetId, float speed, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(targetId);
    //			if (objData != null && objData.GameObj)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.SetTurn(objData.GameObj);
    //			}
    //			return;
    //		}
    //		Vector3 pos = default(Vector3);
    //		GameTalk.GetRolePos(targetId, out pos.x, out pos.y, out pos.z);
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData2 = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData2 != null && objData2.GameObj)
    //			{
    //				M_GameRoleBase component = objData2.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					if (id != -1)
    //					{
    //						S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //						S_NpcAI data2 = GameDataDB.NpcAIDB.GetData(data.AIMode);
    //						if (turnMotion == 0 && data2 != null)
    //						{
    //							turnMotion = data2.TurnMotion;
    //						}
    //						if (waitMotion == 0 && data != null)
    //						{
    //							waitMotion = data.Motion;
    //						}
    //					}
    //					component.m_TurnMotion = turnMotion;
    //					component.m_WaitMotion = waitMotion;
    //					component.SetTurn(pos, speed);
    //				}
    //			}
    //		}
    //	}

    //	public static void TurnRoleDir(int id, float dir, float speed, bool turnRight, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					objData.Dir = component.Dir;
    //					if (turnRight)
    //					{
    //						objData.Dir = GameMath.ClampAngle360(objData.Dir + dir);
    //					}
    //					else
    //					{
    //						objData.Dir = GameMath.ClampAngle360(objData.Dir - dir);
    //					}
    //					if (id != -1)
    //					{
    //						S_NpcData data = GameDataDB.NpcDB.GetData(id);
    //						S_NpcAI data2 = GameDataDB.NpcAIDB.GetData(data.AIMode);
    //						if (turnMotion == 0 && data2 != null)
    //						{
    //							turnMotion = data2.TurnMotion;
    //						}
    //						if (waitMotion == 0 && data != null)
    //						{
    //							waitMotion = data.Motion;
    //						}
    //					}
    //					component.m_TurnMotion = turnMotion;
    //					component.m_WaitMotion = waitMotion;
    //					if (speed <= 0f)
    //					{
    //						component.Dir = objData.Dir;
    //					}
    //					else
    //					{
    //						component.SetTurn(objData.Dir, speed);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static void SetPlayerIdleMotion()
    //	{
    //	}

    //	public static void SetRoleMotion(int id, int motionId)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(motionId, 0.1f);
    //			return;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null)
    //			{
    //				objData.Motion = motionId;
    //				if (objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						component.Motion = motionId;
    //					}
    //				}
    //			}
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator SetRoleQueuedMotion(int id, int motionId, int motionId2, bool wait)
    //	{
    //		GameTalk.<SetRoleQueuedMotion>c__Iterator84E <SetRoleQueuedMotion>c__Iterator84E = new GameTalk.<SetRoleQueuedMotion>c__Iterator84E();
    //		<SetRoleQueuedMotion>c__Iterator84E.id = id;
    //		<SetRoleQueuedMotion>c__Iterator84E.motionId = motionId;
    //		<SetRoleQueuedMotion>c__Iterator84E.motionId2 = motionId2;
    //		<SetRoleQueuedMotion>c__Iterator84E.wait = wait;
    //		<SetRoleQueuedMotion>c__Iterator84E.<$>id = id;
    //		<SetRoleQueuedMotion>c__Iterator84E.<$>motionId = motionId;
    //		<SetRoleQueuedMotion>c__Iterator84E.<$>motionId2 = motionId2;
    //		<SetRoleQueuedMotion>c__Iterator84E.<$>wait = wait;
    //		return <SetRoleQueuedMotion>c__Iterator84E;
    //	}

    //	public static int GetRoleMotion(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					return component.Motion;
    //				}
    //			}
    //		}
    //		return 0;
    //	}

    //	public static bool IsMotionFinished(int roleId, int id)
    //	{
    //		if (roleId == -1)
    //		{
    //			roleId = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(roleId);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					return component.IsMotionFinished(id);
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitMotionFinished(int roleId, int id)
    //	{
    //		GameTalk.<WaitMotionFinished>c__Iterator84F <WaitMotionFinished>c__Iterator84F = new GameTalk.<WaitMotionFinished>c__Iterator84F();
    //		<WaitMotionFinished>c__Iterator84F.roleId = roleId;
    //		<WaitMotionFinished>c__Iterator84F.id = id;
    //		<WaitMotionFinished>c__Iterator84F.<$>roleId = roleId;
    //		<WaitMotionFinished>c__Iterator84F.<$>id = id;
    //		return <WaitMotionFinished>c__Iterator84F;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitMotionTransition(int roleId)
    //	{
    //		GameTalk.<WaitMotionTransition>c__Iterator850 <WaitMotionTransition>c__Iterator = new GameTalk.<WaitMotionTransition>c__Iterator850();
    //		<WaitMotionTransition>c__Iterator.roleId = roleId;
    //		<WaitMotionTransition>c__Iterator.<$>roleId = roleId;
    //		return <WaitMotionTransition>c__Iterator;
    //	}

    //	public static void SetMoveRole(int id, float x, float y, float z, float speed)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			M_PlayerController playerController = Swd6Application.instance.m_ExploreSystem.PlayerController;
    //			if (playerController)
    //			{
    //				if (speed == 0f)
    //				{
    //					playerController.m_AtuoMoveSpeed = 0.4f;
    //					playerController.PlayMotion(1, 0.1f);
    //					playerController.PlayMotion(7, 0.1f);
    //				}
    //				else
    //				{
    //					playerController.m_AtuoMoveSpeed = 0f;
    //				}
    //				playerController.SetMove(new Vector3(x, y, z));
    //				return;
    //			}
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					Vector3 move = new Vector3(x, y, z);
    //					component.SetMove(move);
    //					component.MoveSpeed = speed;
    //				}
    //			}
    //		}
    //	}

    //	public static void SetMoveRole(int id, string targetName, float speed)
    //	{
    //		GameObject gameObject = GameObject.Find(targetName);
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogWarning("找不到移動目標物件_" + targetName);
    //			return;
    //		}
    //		Vector3 position = gameObject.transform.position;
    //		GameTalk.SetMoveRole(id, position.x, position.y, position.z, speed);
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitMoveRole(int id)
    //	{
    //		GameTalk.<WaitMoveRole>c__Iterator851 <WaitMoveRole>c__Iterator = new GameTalk.<WaitMoveRole>c__Iterator851();
    //		<WaitMoveRole>c__Iterator.id = id;
    //		<WaitMoveRole>c__Iterator.<$>id = id;
    //		return <WaitMoveRole>c__Iterator;
    //	}

    //	public static void StopMoveRole(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			M_PlayerController playerController = Swd6Application.instance.m_ExploreSystem.PlayerController;
    //			if (playerController)
    //			{
    //				playerController.StopAutoMove();
    //				return;
    //			}
    //		}
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameNpc component = objData.GameObj.GetComponent<M_GameNpc>();
    //				if (component)
    //				{
    //					component.StopAutoMove();
    //				}
    //			}
    //		}
    //	}

    //	public static void DisableRole(int id, bool disable)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log(id + "_disable_" + disable);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.DisableRole = disable;
    //					objData.State = component.RoleState;
    //				}
    //			}
    //			else
    //			{
    //				objData.State.Set(ENUM_GameObjFlag.Disable, disable);
    //				if (!disable)
    //				{
    //					objData.State.Set(ENUM_GameObjFlag.Hide2, disable);
    //					if (objData.RoleBase == null && objData.MapId == Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID)
    //					{
    //						Swd6Application.instance.m_GameObjSystem.LoadObj(objData);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static bool IsDisableRole(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (!objData.GameObj)
    //			{
    //				return true;
    //			}
    //			M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				return component.DisableRole;
    //			}
    //		}
    //		return false;
    //	}

    //	public static void HideRole(int id, bool hide)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log(id + "_hide_" + hide);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.HideRole = hide;
    //					objData.State = component.RoleState;
    //					if (!hide)
    //					{
    //						component.HideRole2 = false;
    //						component.NoCollider = false;
    //					}
    //				}
    //			}
    //			else
    //			{
    //				objData.State.Set(ENUM_GameObjFlag.Hide, hide);
    //				if (!hide)
    //				{
    //					objData.State.Set(ENUM_GameObjFlag.Hide2, hide);
    //					objData.State.Set(ENUM_GameObjFlag.NoCollider, hide);
    //				}
    //			}
    //		}
    //	}

    //	public static bool IsHideRole(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (!objData.GameObj)
    //			{
    //				return true;
    //			}
    //			M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				return component.HideRole;
    //			}
    //		}
    //		return false;
    //	}

    //	public static void SetNoCollider(int id, bool noCollider)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log(id + "_NoCollider_" + noCollider);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.NoCollider = noCollider;
    //					objData.State = component.RoleState;
    //				}
    //			}
    //			else
    //			{
    //				objData.State.Set(ENUM_GameObjFlag.NoCollider, noCollider);
    //			}
    //		}
    //	}

    //	public static void RoleShowItem(int id, int itemID, int position)
    //	{
    //		if (id == -1)
    //		{
    //			return;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log("RoleShowItem_" + id);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.SetAttachItem(itemID, position);
    //				}
    //			}
    //			else
    //			{
    //				objData.AttachID[position] = itemID;
    //			}
    //		}
    //	}

    //	public static void RoleHideItem(int id, int itemID, int position)
    //	{
    //		if (id == -1)
    //		{
    //			return;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log("RoleHideItem_" + id);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.DeleteAttachItem(itemID, position);
    //				}
    //			}
    //			else
    //			{
    //				objData.AttachID[position] = 0;
    //			}
    //		}
    //	}

    //	public static void SetRoleHairLight(int id, bool light)
    //	{
    //		if (id == -1)
    //		{
    //			return;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			UnityEngine.Debug.Log("SetRoleHairLight_" + id);
    //		}
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null)
    //		{
    //			if (objData.GameObj)
    //			{
    //				M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //				if (component)
    //				{
    //					component.SetHairLight(light);
    //				}
    //			}
    //			else
    //			{
    //				objData.HairNoLight = !light;
    //			}
    //		}
    //	}

    //	public static void DisableAllNpc(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.DisableAllObj(mapID, true);
    //	}

    //	public static void EnableAllNpc(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.DisableAllObj(mapID, false);
    //	}

    public static void HideAllNpc(int mapID)
    {
        //GameTalk.FlagON(54);
        //Swd6Application.instance.m_GameObjSystem.HideObjByType2(mapID, ENUM_NpcType.Role, true);
    }

    //	public static void ShowAllNpc(int mapID)
    //	{
    //		GameTalk.FlagOFF(54);
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType2(mapID, ENUM_NpcType.Role, false);
    //	}

    //	public static void HideAllMapMob(int mapID)
    //	{
    //		GameTalk.FlagON(53);
    //	}

    //	public static void ShowAllMapMob(int mapID)
    //	{
    //		GameTalk.FlagOFF(53);
    //		GameMapMobSystem.Instance.Show();
    //	}

    //	public static void HideAllTreasure(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Treasure, true);
    //	}

    //	public static void ShnowAllTreasure(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Treasure, false);
    //	}

    //	public static void HideAllMine(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Mine, true);
    //	}

    //	public static void ShnowAllMine(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Mine, false);
    //	}

    //	public static void HideAllTrap(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Trap, true);
    //	}

    //	public static void ShowAllTrap(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Trap, false);
    //	}

    //	public static void HideAllNoEffectObj(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.NoEffect, true);
    //	}

    //	public static void ShowAllNoEffectObj(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.NoEffect, false);
    //	}

    //	public static void ReStartPos(List<Vector3> ResetPointList)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.ReStartPos(ResetPointList);
    //	}

    //	public static void DontRemoveQuestTalk(int id)
    //	{
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //		if (objData != null && objData.GameObj)
    //		{
    //			M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //			if (component)
    //			{
    //				component.m_DontRemoveScript = true;
    //			}
    //		}
    //	}

    //	public static void SetPlayerPointLight(bool enable)
    //	{
    //		if (enable)
    //		{
    //			GameTalk.FlagON(52);
    //		}
    //		else
    //		{
    //			GameTalk.FlagOFF(52);
    //		}
    //		Swd6Application.instance.m_ExploreSystem.SetPlayerPointLight(enable);
    //	}

    //	public static void AddQuest(int questID)
    //	{
    //		Swd6Application.instance.m_QuestSystem.AddQuestRecord(questID);
    //	}

    //	public static void ReportQuest(int questID)
    //	{
    //		Swd6Application.instance.m_QuestSystem.ReportQuestRecord(questID);
    //	}

    //	public static void FinishQuest(int questID)
    //	{
    //		Swd6Application.instance.m_QuestSystem.FinishQuestRecord(questID);
    //	}

    //	public static void FailQuest(int questID)
    //	{
    //		Swd6Application.instance.m_QuestSystem.FailQuestRecord(questID);
    //	}

    //	public static bool CheckQuestGive(int questID)
    //	{
    //		ENUM_QuestState questState = Swd6Application.instance.m_QuestSystem.GetQuestState(questID);
    //		return questState == ENUM_QuestState.Active;
    //	}

    //	public static bool HasQuest(int questID)
    //	{
    //		ENUM_QuestState questState = Swd6Application.instance.m_QuestSystem.GetQuestState(questID);
    //		return questState == ENUM_QuestState.Normal || questState == ENUM_QuestState.Report;
    //	}

    //	public static bool CheckQuestFinish(int questID)
    //	{
    //		ENUM_QuestState questState = Swd6Application.instance.m_QuestSystem.GetQuestState(questID);
    //		return questState == ENUM_QuestState.Finish;
    //	}

    //	public static bool CheckQuestFail(int questID)
    //	{
    //		ENUM_QuestState questState = Swd6Application.instance.m_QuestSystem.GetQuestState(questID);
    //		return questState == ENUM_QuestState.Fail;
    //	}

    //	public static void ShowMissionMsg(int id)
    //	{
    //		S_MainQuest data = GameDataDB.MainQuestDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		UI_Message.Instance.AddMissionMsg(data.Hint, 5f);
    //		GameTalk.FlagON(data.GUID);
    //		UI_MiniMap.Instance.FindStoryHint();
    //		UI_ZoneMap.Instance.FindStoryHint();
    //	}

    //	public static void FinishMission(int id)
    //	{
    //		GameTalk.FlagON(id + 500);
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg(int id, bool wait)
    //	{
    //		GameTalk.<ShowSystemMsg>c__Iterator852 <ShowSystemMsg>c__Iterator = new GameTalk.<ShowSystemMsg>c__Iterator852();
    //		<ShowSystemMsg>c__Iterator.id = id;
    //		<ShowSystemMsg>c__Iterator.wait = wait;
    //		<ShowSystemMsg>c__Iterator.<$>id = id;
    //		<ShowSystemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowSystemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg(string msg, bool wait)
    //	{
    //		GameTalk.<ShowSystemMsg>c__Iterator853 <ShowSystemMsg>c__Iterator = new GameTalk.<ShowSystemMsg>c__Iterator853();
    //		<ShowSystemMsg>c__Iterator.msg = msg;
    //		<ShowSystemMsg>c__Iterator.wait = wait;
    //		<ShowSystemMsg>c__Iterator.<$>msg = msg;
    //		<ShowSystemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowSystemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg2(int id, bool wait, bool playSound)
    //	{
    //		GameTalk.<ShowSystemMsg2>c__Iterator854 <ShowSystemMsg2>c__Iterator = new GameTalk.<ShowSystemMsg2>c__Iterator854();
    //		<ShowSystemMsg2>c__Iterator.id = id;
    //		<ShowSystemMsg2>c__Iterator.wait = wait;
    //		<ShowSystemMsg2>c__Iterator.playSound = playSound;
    //		<ShowSystemMsg2>c__Iterator.<$>id = id;
    //		<ShowSystemMsg2>c__Iterator.<$>wait = wait;
    //		<ShowSystemMsg2>c__Iterator.<$>playSound = playSound;
    //		return <ShowSystemMsg2>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg2(string msg, bool wait, bool playSound)
    //	{
    //		GameTalk.<ShowSystemMsg2>c__Iterator855 <ShowSystemMsg2>c__Iterator = new GameTalk.<ShowSystemMsg2>c__Iterator855();
    //		<ShowSystemMsg2>c__Iterator.msg = msg;
    //		<ShowSystemMsg2>c__Iterator.playSound = playSound;
    //		<ShowSystemMsg2>c__Iterator.wait = wait;
    //		<ShowSystemMsg2>c__Iterator.<$>msg = msg;
    //		<ShowSystemMsg2>c__Iterator.<$>playSound = playSound;
    //		<ShowSystemMsg2>c__Iterator.<$>wait = wait;
    //		return <ShowSystemMsg2>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowGetItemMsg(int id, int count, bool wait)
    //	{
    //		GameTalk.<ShowGetItemMsg>c__Iterator856 <ShowGetItemMsg>c__Iterator = new GameTalk.<ShowGetItemMsg>c__Iterator856();
    //		<ShowGetItemMsg>c__Iterator.id = id;
    //		<ShowGetItemMsg>c__Iterator.count = count;
    //		<ShowGetItemMsg>c__Iterator.wait = wait;
    //		<ShowGetItemMsg>c__Iterator.<$>id = id;
    //		<ShowGetItemMsg>c__Iterator.<$>count = count;
    //		<ShowGetItemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowGetItemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowDeleteItemMsg(int id, int count, bool wait)
    //	{
    //		GameTalk.<ShowDeleteItemMsg>c__Iterator857 <ShowDeleteItemMsg>c__Iterator = new GameTalk.<ShowDeleteItemMsg>c__Iterator857();
    //		<ShowDeleteItemMsg>c__Iterator.id = id;
    //		<ShowDeleteItemMsg>c__Iterator.count = count;
    //		<ShowDeleteItemMsg>c__Iterator.wait = wait;
    //		<ShowDeleteItemMsg>c__Iterator.<$>id = id;
    //		<ShowDeleteItemMsg>c__Iterator.<$>count = count;
    //		<ShowDeleteItemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowDeleteItemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowLearnSkillmMsg(int id, bool wait)
    //	{
    //		GameTalk.<ShowLearnSkillmMsg>c__Iterator858 <ShowLearnSkillmMsg>c__Iterator = new GameTalk.<ShowLearnSkillmMsg>c__Iterator858();
    //		<ShowLearnSkillmMsg>c__Iterator.id = id;
    //		<ShowLearnSkillmMsg>c__Iterator.wait = wait;
    //		<ShowLearnSkillmMsg>c__Iterator.<$>id = id;
    //		<ShowLearnSkillmMsg>c__Iterator.<$>wait = wait;
    //		return <ShowLearnSkillmMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitSystemMsg()
    //	{
    //		return new GameTalk.<WaitSystemMsg>c__Iterator859();
    //	}

    //	public static void LearnSkill(int roleId, int skillId, bool show)
    //	{
    //		Swd6Application.instance.m_SkillSystem.LearnSkill(roleId, skillId);
    //		if (show)
    //		{
    //			C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(roleId);
    //			string msg = string.Empty;
    //			S_Skill data = GameDataDB.SkillDB.GetData(skillId);
    //			if (data != null)
    //			{
    //				msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1002) + data.Name;
    //			}
    //			Swd6Application.instance.StartCoroutine(GameTalk.ShowSystemMsg(msg, false));
    //		}
    //	}

    //	public static void AddItem(int id, int count, bool showMsg)
    //	{
    //		Swd6Application.instance.m_ItemSystem.AddItem(id, count, ENUM_ItemState.New, showMsg);
    //	}

    //	public static void CostItem(int id, int count)
    //	{
    //		Swd6Application.instance.m_ItemSystem.DeleteItemByItemID(id, count, true);
    //	}

    //	public static bool CheckItem(int id, int count)
    //	{
    //		return Swd6Application.instance.m_ItemSystem.CheckItemBag(id, count);
    //	}

    //	public static bool CheckEquipItem(int roldId, int id)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.CheckEquipItem(roldId, id);
    //	}

    //	public static bool CheckPartyEquipItem(int id)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.CheckPartyEquipItem(id);
    //	}

    //	public static void AddMoney(int money, bool showMsg)
    //	{
    //		if (showMsg)
    //		{
    //			string msg = GameDataDB.StrID(1000) + money + GameDataDB.StrID(1005);
    //			UI_Explore.Instance.AddPopMsg(msg, 0);
    //		}
    //		Swd6Application.instance.m_GameDataSystem.Money += money;
    //	}

    //	public static void CostMoney(int money, bool showMsg)
    //	{
    //		if (showMsg)
    //		{
    //			string msg = GameDataDB.StrID(1001) + money + GameDataDB.StrID(1005);
    //			UI_Explore.Instance.AddPopMsg(msg, 0);
    //		}
    //		Swd6Application.instance.m_GameDataSystem.Money -= money;
    //	}

    //	public static bool CheckMoney(int money)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.Money >= money;
    //	}

    //	public static bool CheckWeaponBookComplete()
    //	{
    //		int equipItemRecordCount = Swd6Application.instance.m_IdentifySystem.GetEquipItemRecordCount(1);
    //		int equipItemTotalCount = Swd6Application.instance.m_IdentifySystem.GetEquipItemTotalCount(1);
    //		return equipItemRecordCount >= equipItemTotalCount;
    //	}

    //	public static void AddMobGuard(int id)
    //	{
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (data.MobData.ShowFlag > 0)
    //		{
    //			Swd6Application.instance.m_GameDataSystem.FlagON(data.MobData.ShowFlag);
    //		}
    //		Swd6Application.instance.m_IdentifySystem.AddIdentify(id, ENUM_IdentifyType.Mob, 100f, 0);
    //		UI_Message.Instance.AddSysMsg(data.Name + GameDataDB.StrID(1062), 3f);
    //	}

    //	public static void RemoveMobGuard(int id)
    //	{
    //		S_Item data = GameDataDB.ItemDB.GetData(id);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		if (data.MobData.ShowFlag > 0)
    //		{
    //			Swd6Application.instance.m_GameDataSystem.FlagOFF(data.MobData.ShowFlag);
    //		}
    //		Swd6Application.instance.m_MobGuardSystem.ClearDataByID(id);
    //		UI_Message.Instance.AddSysMsg(data.Name + GameDataDB.StrID(1061), 3f);
    //	}

    //	public static void AddPartner(int id, bool showMsg)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.AddRole(id, showMsg);
    //		GameTalk.OpenRoleActionSkill(id);
    //	}

    //	public static void RemovePartner(int id, bool showMsg)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.RemoveRole(id, showMsg);
    //		GameTalk.DisableRoleActionSkill(id);
    //	}

    //	public static void RemovePartner2(int id, bool showMsg)
    //	{
    //		if (id == Swd6Application.instance.m_GameDataSystem.m_PlayerID)
    //		{
    //			GameTalk.RemovePartner(id, showMsg);
    //			Swd6Application.instance.m_ExploreSystem.SwitchPlayer();
    //		}
    //		else
    //		{
    //			GameTalk.RemovePartner(id, showMsg);
    //		}
    //	}

    //	public static void UpgradePartnerLevel(int id)
    //	{
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(1);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		C_RoleDataEx roleData2 = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData2 == null)
    //		{
    //			return;
    //		}
    //		if (roleData2.BaseRoleData.Level >= roleData.BaseRoleData.Level)
    //		{
    //			return;
    //		}
    //		S_LevelUpInfo s_LevelUpInfo = new S_LevelUpInfo();
    //		while (true)
    //		{
    //			roleData2 = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //			if (roleData2.BaseRoleData.Level >= roleData.BaseRoleData.Level)
    //			{
    //				break;
    //			}
    //			s_LevelUpInfo.SkillPoint = 0;
    //			Swd6Application.instance.m_GameDataSystem.LevelUp(id, roleData2.BaseRoleData.Level + 1, true, ref s_LevelUpInfo);
    //		}
    //		Swd6Application.instance.m_GameDataSystem.ShowLearnSkillMsg(id, s_LevelUpInfo);
    //	}

    //	public static void UpgradePartnerLevel(int id, bool showMsg)
    //	{
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(1);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		C_RoleDataEx roleData2 = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData2 == null)
    //		{
    //			return;
    //		}
    //		if (roleData2.BaseRoleData.Level >= roleData.BaseRoleData.Level)
    //		{
    //			return;
    //		}
    //		S_LevelUpInfo s_LevelUpInfo = new S_LevelUpInfo();
    //		while (true)
    //		{
    //			roleData2 = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //			if (roleData2.BaseRoleData.Level >= roleData.BaseRoleData.Level)
    //			{
    //				break;
    //			}
    //			s_LevelUpInfo.SkillPoint = 0;
    //			Swd6Application.instance.m_GameDataSystem.LevelUp(id, roleData2.BaseRoleData.Level + 1, true, ref s_LevelUpInfo);
    //		}
    //		if (showMsg)
    //		{
    //			Swd6Application.instance.m_GameDataSystem.ShowLearnSkillMsg(id, s_LevelUpInfo);
    //		}
    //	}

    //	public static void AddRoleExp(int id, int exp)
    //	{
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData == null)
    //		{
    //			return;
    //		}
    //		S_LevelUpInfo levelUpInfo = new S_LevelUpInfo();
    //		if (Swd6Application.instance.m_GameDataSystem.AddRoleExp(id, exp, ref levelUpInfo))
    //		{
    //			string msg = roleData.BaseRoleData.FamilyName + roleData.BaseRoleData.Name + GameDataDB.StrID(1064);
    //			UI_Message.Instance.AddSysMsg(msg, 3f);
    //			Swd6Application.instance.m_GameDataSystem.ShowLearnSkillMsg(id, levelUpInfo);
    //		}
    //	}

    //	public static int GetPlayerLevel(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData == null)
    //		{
    //			return 0;
    //		}
    //		return roleData.BaseRoleData.Level;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator CallFight(int id)
    //	{
    //		GameTalk.<CallFight>c__Iterator85A <CallFight>c__Iterator85A = new GameTalk.<CallFight>c__Iterator85A();
    //		<CallFight>c__Iterator85A.id = id;
    //		<CallFight>c__Iterator85A.<$>id = id;
    //		return <CallFight>c__Iterator85A;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitFightOver()
    //	{
    //		return new GameTalk.<WaitFightOver>c__Iterator85B();
    //	}

    //	public static void AddAchievement(int id)
    //	{
    //		Swd6Application.instance.m_AchievementSystem.FinishAchievement(id);
    //	}

    //	public static bool CheckAchievement(int id)
    //	{
    //		return Swd6Application.instance.m_AchievementSystem.CheckFinishAchievement(id);
    //	}

    //	public static void OpenPotRealmSystem()
    //	{
    //		GameTalk.FlagON(28);
    //		if (Swd6Application.instance.IsDLC())
    //		{
    //			UI_Message.Instance.AddSysMsg(GameDataDB.StrID(1024), 3f);
    //		}
    //		else
    //		{
    //			UI_Message.Instance.AddSysMsg(GameDataDB.StrID(1021), 3f);
    //		}
    //	}

    //	public static void OpenWeaponBookSystem()
    //	{
    //		GameTalk.FlagON(29);
    //		UI_Message.Instance.AddSysMsg(GameDataDB.StrID(1022), 3f);
    //	}

    //	public static void OpenFormationSystem()
    //	{
    //		GameTalk.FlagON(26);
    //		UI_Message.Instance.AddSysMsg(GameDataDB.StrID(1023), 3f);
    //	}

    //	public static void OpenRoleActionSkill(int roldId)
    //	{
    //		if (roldId == 7)
    //		{
    //			return;
    //		}
    //		GameTalk.FlagON(30 + roldId);
    //	}

    //	public static void DisableRoleActionSkill(int roldId)
    //	{
    //		GameTalk.FlagOFF(30 + roldId);
    //	}

    //	public static void DisableZoneMap()
    //	{
    //		GameTalk.FlagOFF(40);
    //	}

    //	public static void AddRidePet()
    //	{
    //		GameTalk.FlagON(36);
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowSystemMsg(GameDataDB.StrID(1050), false));
    //	}

    //	public static void AddRidePet2()
    //	{
    //		GameTalk.FlagON(37);
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowSystemMsg(GameDataDB.StrID(1051), false));
    //	}

    //	public static void AddFlyPet1()
    //	{
    //		GameTalk.FlagON(38);
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowSystemMsg(GameDataDB.StrID(1052), false));
    //	}

    //	public static void AddFlyPet2()
    //	{
    //		GameTalk.FlagON(39);
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowSystemMsg(GameDataDB.StrID(1053), false));
    //	}

    //	public static int GetPlayGameCount()
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.m_PlayGameCount;
    //	}

    //	public static int GetMaxCompleteGameCount()
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.m_MaxCompleteGame;
    //	}

    //	public static int GetPlayerHP(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData == null)
    //		{
    //			return 0;
    //		}
    //		return roleData.GetHP();
    //	}

    //	public static int GetPlayerMaxHP(int id)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData == null)
    //		{
    //			return 0;
    //		}
    //		return roleData.GetRoleAttr_IntValue(ENUM_RoleAttr.MaxHP);
    //	}

    //	public static void CostHealth(int id, int HP, int MP)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData != null)
    //		{
    //			roleData.AddHP(-HP);
    //			roleData.AddMP(-MP);
    //			if (HP != 0)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //			}
    //		}
    //	}

    //	public static void CostPartyHealth(int HP, int MP)
    //	{
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(i))
    //			{
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					roleData.AddHP(-HP);
    //					roleData.AddMP(-MP);
    //				}
    //			}
    //		}
    //		if (HP != 0)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //		}
    //	}

    //	public static void RestoreHealth(int id, int HP, int MP)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData != null)
    //		{
    //			roleData.AddHP(HP);
    //			roleData.AddMP(MP);
    //		}
    //	}

    //	public static void RestorePartyHealth(int HP, int MP)
    //	{
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //			if (roleData != null)
    //			{
    //				roleData.AddHP(HP);
    //				roleData.AddMP(MP);
    //				if (HP >= 99999)
    //				{
    //					roleData.BaseRoleData.IsDeath = false;
    //				}
    //			}
    //		}
    //	}

    //	public static void CostHealthRatio(int id, float HP, float MP, float AP)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData != null)
    //		{
    //			roleData.AddHP(-HP);
    //			roleData.AddMP(-MP);
    //		}
    //		int num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //		if (num != 0)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //		}
    //	}

    //	public static void CostPartyHealthRatio(float HP, float MP, float AP)
    //	{
    //		int num = 0;
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(i))
    //			{
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					roleData.AddHP(-HP);
    //					roleData.AddMP(-MP);
    //				}
    //				if (num == 0)
    //				{
    //					num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //				}
    //			}
    //		}
    //		if (num != 0)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //		}
    //	}

    //	public static void RestoreHealthRatio(int id, float HP, float MP, float AP)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(id);
    //		if (roleData != null)
    //		{
    //			roleData.AddHP(HP);
    //			roleData.AddMP(MP);
    //		}
    //	}

    //	public static void RestorePartyHealthRatio(float HP, float MP, float AP)
    //	{
    //		int num = 0;
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //			if (roleData != null)
    //			{
    //				roleData.AddHP(HP);
    //				roleData.AddMP(MP);
    //			}
    //			if (num == 0)
    //			{
    //				num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //			}
    //		}
    //	}

    //	public static void RestorePartyHealthRatio1(float HP, float MP)
    //	{
    //		int num = 0;
    //		int num2 = 0;
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //			if (roleData != null)
    //			{
    //				roleData.AddHP(HP);
    //				roleData.AddMP(MP);
    //			}
    //			if (num == 0)
    //			{
    //				num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //			}
    //			if (num2 == 0)
    //			{
    //				num2 = (int)((float)roleData.RoleAttr.sFinial.MaxMP * MP) / 100;
    //			}
    //		}
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowRestoreNumber(num, num2));
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowRestoreNumber(int HP, int MP)
    //	{
    //		GameTalk.<ShowRestoreNumber>c__Iterator85C <ShowRestoreNumber>c__Iterator85C = new GameTalk.<ShowRestoreNumber>c__Iterator85C();
    //		<ShowRestoreNumber>c__Iterator85C.HP = HP;
    //		<ShowRestoreNumber>c__Iterator85C.MP = MP;
    //		<ShowRestoreNumber>c__Iterator85C.<$>HP = HP;
    //		<ShowRestoreNumber>c__Iterator85C.<$>MP = MP;
    //		return <ShowRestoreNumber>c__Iterator85C;
    //	}

    //	public static int Rand(int min, int max)
    //	{
    //		return UnityEngine.Random.Range(min, max);
    //	}

    //	public static bool Abs(float valueA, float valueB, float delta)
    //	{
    //		float num = Mathf.Abs(valueA - valueB);
    //		return num <= delta;
    //	}

    //	public static void OpenTreasure(GameObject obj)
    //	{
    //		if (obj != null)
    //		{
    //			obj.SendMessage("DoOpen", SendMessageOptions.DontRequireReceiver);
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenShop(int shoId)
    //	{
    //		GameTalk.<OpenShop>c__Iterator85D <OpenShop>c__Iterator85D = new GameTalk.<OpenShop>c__Iterator85D();
    //		<OpenShop>c__Iterator85D.shoId = shoId;
    //		<OpenShop>c__Iterator85D.<$>shoId = shoId;
    //		return <OpenShop>c__Iterator85D;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenMakeName(int roldId)
    //	{
    //		GameTalk.<OpenMakeName>c__Iterator85E <OpenMakeName>c__Iterator85E = new GameTalk.<OpenMakeName>c__Iterator85E();
    //		<OpenMakeName>c__Iterator85E.roldId = roldId;
    //		<OpenMakeName>c__Iterator85E.<$>roldId = roldId;
    //		return <OpenMakeName>c__Iterator85E;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSaveLoad()
    //	{
    //		return new GameTalk.<OpenSaveLoad>c__Iterator85F();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenCompleteSave()
    //	{
    //		return new GameTalk.<OpenCompleteSave>c__Iterator860();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenItemGuideMenu()
    //	{
    //		return new GameTalk.<OpenItemGuideMenu>c__Iterator861();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSkillGuideMenu()
    //	{
    //		return new GameTalk.<OpenSkillGuideMenu>c__Iterator862();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenFormationGuideMenu()
    //	{
    //		return new GameTalk.<OpenFormationGuideMenu>c__Iterator863();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenMobGuardGuideMenu()
    //	{
    //		return new GameTalk.<OpenMobGuardGuideMenu>c__Iterator864();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSubQuestMenu()
    //	{
    //		return new GameTalk.<OpenSubQuestMenu>c__Iterator865();
    //	}

    //	public static void OpenExploreGuideMenu()
    //	{
    //		NormalSetting normalSetting = Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting();
    //		if (normalSetting.m_bEnableTeach)
    //		{
    //			UI_Explore.Instance.ShowGuideMenu();
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitTime(float fTime)
    //	{
    //		GameTalk.<WaitTime>c__Iterator866 <WaitTime>c__Iterator = new GameTalk.<WaitTime>c__Iterator866();
    //		<WaitTime>c__Iterator.fTime = fTime;
    //		<WaitTime>c__Iterator.<$>fTime = fTime;
    //		return <WaitTime>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitFadeTime(float alpha, float fTime)
    //	{
    //		GameTalk.<WaitFadeTime>c__Iterator867 <WaitFadeTime>c__Iterator = new GameTalk.<WaitFadeTime>c__Iterator867();
    //		<WaitFadeTime>c__Iterator.alpha = alpha;
    //		<WaitFadeTime>c__Iterator.fTime = fTime;
    //		<WaitFadeTime>c__Iterator.<$>alpha = alpha;
    //		<WaitFadeTime>c__Iterator.<$>fTime = fTime;
    //		return <WaitFadeTime>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitFadeTime(float alpha, float fTime, bool isBright)
    //	{
    //		GameTalk.<WaitFadeTime>c__Iterator868 <WaitFadeTime>c__Iterator = new GameTalk.<WaitFadeTime>c__Iterator868();
    //		<WaitFadeTime>c__Iterator.alpha = alpha;
    //		<WaitFadeTime>c__Iterator.fTime = fTime;
    //		<WaitFadeTime>c__Iterator.isBright = isBright;
    //		<WaitFadeTime>c__Iterator.<$>alpha = alpha;
    //		<WaitFadeTime>c__Iterator.<$>fTime = fTime;
    //		<WaitFadeTime>c__Iterator.<$>isBright = isBright;
    //		return <WaitFadeTime>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ReturnToStartMenu()
    //	{
    //		return new GameTalk.<ReturnToStartMenu>c__Iterator869();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator StartUserGuide(int userguideID)
    //	{
    //		return new GameTalk.<StartUserGuide>c__Iterator86A();
    //	}

    //	public static void SaveDLCCompleteSave()
    //	{
    //		Swd6Application.instance.m_SaveloadSystem.GenerateDLCReviewStoryFlag();
    //		Swd6Application.instance.m_SaveloadSystem.SaveSystemData();
    //	}

    //	public static void AtuoSave()
    //	{
    //		Swd6Application.instance.m_ExploreSystem.AutoSave();
    //	}

    //	public static void HideExploreUI(bool hide)
    //	{
    //		if (hide)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.m_HideMap = 1;
    //		}
    //		else
    //		{
    //			Swd6Application.instance.m_ExploreSystem.m_HideMap = 2;
    //		}
    //	}

    //	public static void DisableRainEffect(bool disable)
    //	{
    //		if (disable)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.RemoveMapRainEffect();
    //			Swd6Application.instance.m_GameDataSystem.FlagON(56);
    //		}
    //		else
    //		{
    //			Swd6Application.instance.m_ExploreSystem.SetMapRainEffect();
    //			Swd6Application.instance.m_GameDataSystem.FlagOFF(56);
    //		}
    //	}

    //	public static void OpenWOPMainMenu()
    //	{
    //	}

    //	public static void OpenWOPMonsterCompositeMenu()
    //	{
    //	}

    //	public static void OpenWOPManufactureMenu()
    //	{
    //	}

    //	public static void OpenWOPSevenRingMenu()
    //	{
    //	}

    //	public static void OpenWOPRefineMenu()
    //	{
    //	}

    //	public static void OpenWOPSpellTransferMenu()
    //	{
    //	}

    //	public static void OpenWOPUpgradeMenu()
    //	{
    //	}

    //	public static void OpenWOPCenterMenu()
    //	{
    //	}

    //	public static void OpenWOPArenaMenu()
    //	{
    //	}

    //	public static int GetEggNumber()
    //	{
    //		return Swd6Application.instance.m_WOPSystem.GetEggNumber();
    //	}

    //	public static void AddEggNumber(int number)
    //	{
    //		Swd6Application.instance.m_WOPSystem.AddEggNumber(number);
    //	}

    //	public static int GetMonsterCompositeSystemLevel()
    //	{
    //		return Swd6Application.instance.m_WOPSystem.GetMonsterCompositeSystemLevel();
    //	}

    //	public static int GetManufactureSystemLevel()
    //	{
    //		return Swd6Application.instance.m_WOPSystem.GetManufactureSystemLevel();
    //	}

    //	public static int GetRefineSystemLevel()
    //	{
    //		return Swd6Application.instance.m_WOPSystem.GetRefineSystemLevel();
    //	}

    //	public static int GetSpellTransferSystemLevel()
    //	{
    //		return Swd6Application.instance.m_WOPSystem.GetSpellTransferSystemLevel();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenUnLockGame(int ID)
    //	{
    //		GameTalk.<OpenUnLockGame>c__Iterator86B <OpenUnLockGame>c__Iterator86B = new GameTalk.<OpenUnLockGame>c__Iterator86B();
    //		<OpenUnLockGame>c__Iterator86B.ID = ID;
    //		<OpenUnLockGame>c__Iterator86B.<$>ID = ID;
    //		return <OpenUnLockGame>c__Iterator86B;
    //	}

    //	public static int GetUnLockGameResult()
    //	{
    //		return UI_UnlockGame.Instance.GetGameResult();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenMemoryGame(int ID)
    //	{
    //		return new GameTalk.<OpenMemoryGame>c__Iterator86C();
    //	}

    //	public static int GetMemoryGameResult()
    //	{
    //		return 0;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator CheckViewAngle(int roleId, float alertAngle, float alertDist)
    //	{
    //		GameTalk.<CheckViewAngle>c__Iterator86D <CheckViewAngle>c__Iterator86D = new GameTalk.<CheckViewAngle>c__Iterator86D();
    //		<CheckViewAngle>c__Iterator86D.roleId = roleId;
    //		<CheckViewAngle>c__Iterator86D.alertDist = alertDist;
    //		<CheckViewAngle>c__Iterator86D.alertAngle = alertAngle;
    //		<CheckViewAngle>c__Iterator86D.<$>roleId = roleId;
    //		<CheckViewAngle>c__Iterator86D.<$>alertDist = alertDist;
    //		<CheckViewAngle>c__Iterator86D.<$>alertAngle = alertAngle;
    //		return <CheckViewAngle>c__Iterator86D;
    //	}

    //	public static void SetSneakData(int roldId, float angle, float dist)
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(roldId);
    //			if (objData != null && objData.GameObj)
    //			{
    //				M_GameNpc component = objData.GameObj.GetComponent<M_GameNpc>();
    //				if (component)
    //				{
    //					component.SetSneadkData(angle, dist);
    //				}
    //			}
    //		}
    //	}

    //	public static void AddSneakEffect(int roldId, string effectName)
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(roldId);
    //			if (objData != null && objData.GameObj)
    //			{
    //				GameObject effect = ResourceManager.Instance.GetEffect(effectName);
    //				if (effect)
    //				{
    //					effect.transform.parent = objData.GameObj.transform;
    //					effect.transform.localPosition = new Vector3(0f, 0.2f, 0f);
    //					effect.transform.eulerAngles = objData.GameObj.transform.eulerAngles;
    //				}
    //			}
    //		}
    //	}

    //	public static void ResetAllSneakNpc()
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			Swd6Application.instance.m_GameObjSystem.ResetSneakNpc(Swd6Application.instance.m_GameDataSystem.m_MapInfo.MapID);
    //		}
    //	}

    //	public static void ResetWayPoint(int roldId)
    //	{
    //		S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(roldId);
    //		if (objData != null && objData.GameObj)
    //		{
    //			M_GameNpc component = objData.GameObj.GetComponent<M_GameNpc>();
    //			if (component)
    //			{
    //				component.ResetWayPoint();
    //			}
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSmallTrapGame()
    //	{
    //		return new GameTalk.<OpenSmallTrapGame>c__Iterator86E();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSmallTrapGame(bool restore)
    //	{
    //		GameTalk.<OpenSmallTrapGame>c__Iterator86F <OpenSmallTrapGame>c__Iterator86F = new GameTalk.<OpenSmallTrapGame>c__Iterator86F();
    //		<OpenSmallTrapGame>c__Iterator86F.restore = restore;
    //		<OpenSmallTrapGame>c__Iterator86F.<$>restore = restore;
    //		return <OpenSmallTrapGame>c__Iterator86F;
    //	}

    //	public static void AddSmallTrapGameObj(int id)
    //	{
    //		Swd6Application.instance.m_SmallTrapGameSystem.AddTrapObj(id);
    //	}

    //	public static void AddSmallTrapGameCancelObj(int id)
    //	{
    //		Swd6Application.instance.m_SmallTrapGameSystem.AddCancelObj(id);
    //	}

    //	public static void CloseSmallTrapGame()
    //	{
    //		Swd6Application.instance.m_SmallTrapGameSystem.Close();
    //	}

    //	public static bool IsSmallTrapGame()
    //	{
    //		return Swd6Application.instance.gameStateService.getCurrentState().name == "SmallTrapGameState";
    //	}

    //	public static void ChangeMapMusic(int mapid, int music1, int music2, int mode, int changeMode)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.ChangeMapMusic(mapid, music1, music2, (ENUM_MusicMode)mode, (ENUM_MusicChangeMode)changeMode);
    //	}

    //	public static void PlayMusic(int music1, int music2, int mode)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.PlayMapMusic(music1, music2, (ENUM_MusicMode)mode);
    //	}

    //	public static void PlaySound(int soundID, int times)
    //	{
    //		MusicSystem.Instance.PlaySound(soundID, times);
    //	}

    //	public static void PlayLoopSound(int soundID)
    //	{
    //		MusicSystem.Instance.PlayLoopSound(soundID);
    //	}

    //	public static void StopSound(int soundID)
    //	{
    //		MusicSystem.Instance.StopSound(soundID);
    //	}

    //	public static void PlayHitSound()
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 1)
    //		{
    //			GameTalk.PlaySound(106, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 2)
    //		{
    //			GameTalk.PlaySound(329, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3)
    //		{
    //			GameTalk.PlaySound(557, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 4)
    //		{
    //			GameTalk.PlaySound(459, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 5)
    //		{
    //			GameTalk.PlaySound(208, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 6)
    //		{
    //			GameTalk.PlaySound(702, 1);
    //		}
    //	}

    //	public static void PlayDieSound()
    //	{
    //		if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 1)
    //		{
    //			GameTalk.PlaySound(101, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 2)
    //		{
    //			GameTalk.PlaySound(325, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 3)
    //		{
    //			GameTalk.PlaySound(553, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 4)
    //		{
    //			GameTalk.PlaySound(455, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 5)
    //		{
    //			GameTalk.PlaySound(204, 1);
    //		}
    //		else if (Swd6Application.instance.m_GameDataSystem.m_PlayerID == 6)
    //		{
    //			GameTalk.PlaySound(698, 1);
    //		}
    //	}

    //	public static void ChangeSky(int skyID)
    //	{
    //		SkySystem.Instance.ChangeSky(skyID, true);
    //	}

    //	public static void ChangeMapSky(int mapID, int skyID)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.ChangeMapSky(mapID, skyID);
    //	}

    //	public static int PlayEffect(string targetName, int effectId)
    //	{
    //		S_EffectData data = GameDataDB.EffectDB.GetData(effectId);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.LogWarning("PlayEffect::讀取effectDB錯誤:" + effectId);
    //			return 0;
    //		}
    //		GameObject gameObject = GameObject.Find(targetName);
    //		if (gameObject == null)
    //		{
    //			UnityEngine.Debug.LogWarning("PlayEffect::找不到定位點::" + targetName);
    //			return 0;
    //		}
    //		return Swd6Application.instance.m_ExploreSystem.CreateEffect(gameObject.transform.position, data.EffectName);
    //	}

    //	public static int PlayEffect(float x, float y, float z, int effectId)
    //	{
    //		S_EffectData data = GameDataDB.EffectDB.GetData(effectId);
    //		if (data == null)
    //		{
    //			UnityEngine.Debug.LogWarning("PlayEffect::讀取effectDB錯誤:" + effectId);
    //			return 0;
    //		}
    //		Vector3 pos = new Vector3(x, y, z);
    //		return Swd6Application.instance.m_ExploreSystem.CreateEffect(pos, data.EffectName);
    //	}

    //	public static void RemoveEffect(int id)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.RemoveEffect(id);
    //	}

    //	public static void PauseMapMob()
    //	{
    //		GameMapMobSystem.Instance.Pause();
    //	}

    //	public static void ResumeMapMob()
    //	{
    //		GameMapMobSystem.Instance.Resume();
    //	}
}
