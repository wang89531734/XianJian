using System;
using System.Collections;
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

    //	public static void PotRealmChangeMap()
    //	{
    //		if (Swd6Application.instance)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapID == 0)
    //			{
    //				Debug.Log("PotRealmChangeMap_地圖id為0!!");
    //				return;
    //			}
    //			Swd6Application.instance.ChangeMap("ExploreState", Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapID, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosX, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosY, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapPosZ, Swd6Application.instance.m_GameDataSystem.m_MapInfo.OrgMapDir);
    //		}
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
    //					if (transform.name == "camera view point")
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
    //			component.SetLookTargetMode(target1, target2);
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

    //	public static void SetCameraDOFEffect(bool enabled)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.SetCameraDOFEffect(enabled);
    //	}

    public static void PlayStory(int mapid, string storyName)
    {
        S_MapData mapData = GameEntry.Instance.m_GameDataSystem.GetMapData(mapid);
        UnityEngine.Debug.Log(mapData.Name);
        if (mapData != null)
        {
            GameEntry.Instance.m_ExploreSystem.BattleStep = 0f;
            GameEntry.Instance.m_StorySystem.PlayStory(mapid, storyName);
            GameTalk.m_PlayStory = true;
            GameEntry.Instance.m_ExploreSystem.m_PlayStory = true;
        }
    }

    [DebuggerHidden]
    public static IEnumerator IsPlayStoryEnd()
    {
        while (!GameEntry.Instance.m_StorySystem.IsStoryEnd())
        {
            yield return null;
        }
        GameTalk.LockPlayer(true);
        yield return null;
        yield break;
    }

    //	public static void StartTalk(bool bTalk)
    //	{
    //		if (!bTalk)
    //		{
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.m_EnterTalkEvent = false;
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
    //				Swd6Application.instance.StartCoroutine(Swd6Application.instance.m_SaveloadSystem.AutoSave(ENUM_AUTOSAVETYPE.Story));
    //			}
    //		}
    //		Swd6Application.instance.m_ExploreSystem.EndActionSkill();
    //		Swd6Application.instance.GetComponent<M_SceneController>().EndActionSkill();
    //		GameTalk.LockPlayer(bTalk);
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
    //		UI_TalkDialog.Instance.SetTalkSpeed(speed);
    //	}

    //	public static void TalkMsg(int roleID, int id)
    //	{
    //		if (roleID == -1)
    //		{
    //			roleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.IsDLC() && roleID == 6)
    //			{
    //				roleID = 7;
    //			}
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
    //	}

    //	public static void TalkMsg(int roleID, string msg)
    //	{
    //		if (roleID == -1)
    //		{
    //			roleID = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.IsDLC() && roleID == 6)
    //			{
    //				roleID = 7;
    //			}
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
    //		GameTalk.<WaitTalkMsg>c__Iterator1D <WaitTalkMsg>c__Iterator1D = new GameTalk.<WaitTalkMsg>c__Iterator1D();
    //		<WaitTalkMsg>c__Iterator1D.roleID = roleID;
    //		<WaitTalkMsg>c__Iterator1D.id = id;
    //		<WaitTalkMsg>c__Iterator1D.<$>roleID = roleID;
    //		<WaitTalkMsg>c__Iterator1D.<$>id = id;
    //		return <WaitTalkMsg>c__Iterator1D;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitTalkMsg(int roleID, string msg)
    //	{
    //		GameTalk.<WaitTalkMsg>c__Iterator1E <WaitTalkMsg>c__Iterator1E = new GameTalk.<WaitTalkMsg>c__Iterator1E();
    //		<WaitTalkMsg>c__Iterator1E.roleID = roleID;
    //		<WaitTalkMsg>c__Iterator1E.msg = msg;
    //		<WaitTalkMsg>c__Iterator1E.<$>roleID = roleID;
    //		<WaitTalkMsg>c__Iterator1E.<$>msg = msg;
    //		return <WaitTalkMsg>c__Iterator1E;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator TalkMsg()
    //	{
    //		return new GameTalk.<TalkMsg>c__Iterator1F();
    //	}

    //	public static void PartnerTalkMsg(int groupId, float delay)
    //	{
    //		UI_PartnerTalkDialog.Instance.BeginAssignTalk(groupId, delay);
    //	}

    //	public static void CloseTalkMsg()
    //	{
    //		UI_TalkDialog.Instance.Close();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowTalkSelectMenu(string text)
    //	{
    //		GameTalk.<ShowTalkSelectMenu>c__Iterator20 <ShowTalkSelectMenu>c__Iterator = new GameTalk.<ShowTalkSelectMenu>c__Iterator20();
    //		<ShowTalkSelectMenu>c__Iterator.text = text;
    //		<ShowTalkSelectMenu>c__Iterator.<$>text = text;
    //		return <ShowTalkSelectMenu>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowTalkSelectMenu(int id)
    //	{
    //		GameTalk.<ShowTalkSelectMenu>c__Iterator21 <ShowTalkSelectMenu>c__Iterator = new GameTalk.<ShowTalkSelectMenu>c__Iterator21();
    //		<ShowTalkSelectMenu>c__Iterator.id = id;
    //		<ShowTalkSelectMenu>c__Iterator.<$>id = id;
    //		return <ShowTalkSelectMenu>c__Iterator;
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
    //		return new GameTalk.<WaitAnyKey>c__Iterator22();
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

    //	public static void HidePlayer(bool bHide)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HidePlayer(bHide);
    //	}

    public static void LockPlayer(bool bLock)
    {
        GameEntry.Instance.m_ExploreSystem.LockPlayer = bLock;
    }

    //	public static void ChangeRoleMap(int id, int mapid, float x, float y, float z, float dir)
    //	{
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("ChangeRoleMap_" + id);
    //		}
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Vector3 vector = new Vector3(x, y, z);
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangePos = vector;
    //			Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.Pos = vector;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.Dir = dir;
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
    //				Debug.Log("ChangeRoleMap找不到角色_" + id);
    //			}
    //		}
    //	}

    //	public static void SetRolePos(int id, float x, float y, float z)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Vector3 vector = new Vector3(x, y, z);
    //			if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.RidePetController.Pos = vector;
    //			}
    //			else
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerChangePos = vector;
    //			}
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
    //						if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //						{
    //							Debug.Log("SetRolePos:" + objData.GameObj.name + objData.Pos);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static void GetRolePos(int id, out float x, out float y, out float z)
    //	{
    //		x = 0f;
    //		y = 0f;
    //		z = 0f;
    //		if (id == -1)
    //		{
    //			if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //			{
    //				x = Swd6Application.instance.m_ExploreSystem.RidePetController.Pos.x;
    //				y = Swd6Application.instance.m_ExploreSystem.RidePetController.Pos.y;
    //				z = Swd6Application.instance.m_ExploreSystem.RidePetController.Pos.z;
    //			}
    //			else
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

    //	public static void SetRoleDirSpeed(float speed)
    //	{
    //		GameTalk.m_TurnDirSpeed = speed;
    //	}

    //	public static void SetRoleDir(int id, float dir, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.RidePetController.Dir = dir;
    //			}
    //			else
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.StopMoveToTarget();
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.Dir = dir;
    //				Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
    //			}
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
    //							Debug.Log("SetRoleDir:" + objData.GameObj.name + objData.Dir);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static float GetRoleDir(int id)
    //	{
    //		if (id != -1)
    //		{
    //			if (Swd6Application.instance)
    //			{
    //				S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(id);
    //				if (objData != null && objData.GameObj)
    //				{
    //					M_GameRoleBase component = objData.GameObj.GetComponent<M_GameRoleBase>();
    //					if (component)
    //					{
    //						if (objData.Dir == 1000f)
    //						{
    //							objData.Dir = component.Dir;
    //						}
    //						return objData.Dir;
    //					}
    //				}
    //			}
    //			return 0f;
    //		}
    //		if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //		{
    //			return Swd6Application.instance.m_ExploreSystem.RidePetController.Dir;
    //		}
    //		return Swd6Application.instance.m_ExploreSystem.PlayerController.Dir;
    //	}

    //	public static void FaceRoleDir(int id, int targetId, float speed, int turnMotion, int waitMotion)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			S_GameObjData objData = Swd6Application.instance.m_GameObjSystem.GetObjData(targetId);
    //			if (objData != null && objData.GameObj)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerController.MoveTarget = objData.GameObj;
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

    //	public static void TurnRoleDir(int id, float dir, float speed, bool turnRight)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.RidePetController.Dir = dir;
    //			}
    //			else
    //			{
    //				Swd6Application.instance.m_ExploreSystem.PlayerChangeDir = dir;
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
    //					objData.Dir = component.Dir;
    //					if (turnRight)
    //					{
    //						objData.Dir = GameMath.ClampAngle360(objData.Dir + dir);
    //					}
    //					else
    //					{
    //						objData.Dir = GameMath.ClampAngle360(objData.Dir - dir);
    //					}
    //					if (speed <= 0f)
    //					{
    //						component.Dir = objData.Dir;
    //					}
    //					else
    //					{
    //						component.SetTurn(objData.Dir, speed);
    //					}
    //					if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //					{
    //						Debug.Log("TurnRoleDestDir_" + objData.Dir);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	public static void SetPlayerIdleMotion()
    //	{
    //		Swd6Application.instance.m_ExploreSystem.PlayerController.PlayIdleMotion();
    //	}

    //	public static void SetRoleMotion(int id, int motionId)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotion(motionId);
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

    //	public static void SetRoleQueuedMotion(int id, int motionId)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			Swd6Application.instance.m_ExploreSystem.PlayerController.PlayMotionQueued(motionId);
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
    //						component.SetMotionQueued(motionId);
    //					}
    //				}
    //			}
    //		}
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
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
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
    //		GameTalk.<WaitMotionFinished>c__Iterator23 <WaitMotionFinished>c__Iterator = new GameTalk.<WaitMotionFinished>c__Iterator23();
    //		<WaitMotionFinished>c__Iterator.id = id;
    //		<WaitMotionFinished>c__Iterator.roleId = roleId;
    //		<WaitMotionFinished>c__Iterator.<$>id = id;
    //		<WaitMotionFinished>c__Iterator.<$>roleId = roleId;
    //		return <WaitMotionFinished>c__Iterator;
    //	}

    //	public static void SetMoveRole(int id, float x, float y, float z, float speed)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //			if (Swd6Application.instance.m_ExploreSystem.RidePetController)
    //			{
    //				Swd6Application.instance.m_ExploreSystem.RidePetController.SetMove(new Vector3(x, y, z));
    //			}
    //			else
    //			{
    //				M_PlayerController playerController = Swd6Application.instance.m_ExploreSystem.PlayerController;
    //				if (playerController)
    //				{
    //					playerController.SetMove(new Vector3(x, y, z));
    //					return;
    //				}
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

    //	[DebuggerHidden]
    //	public static IEnumerator WaitMoveRole(int id)
    //	{
    //		GameTalk.<WaitMoveRole>c__Iterator24 <WaitMoveRole>c__Iterator = new GameTalk.<WaitMoveRole>c__Iterator24();
    //		<WaitMoveRole>c__Iterator.id = id;
    //		<WaitMoveRole>c__Iterator.<$>id = id;
    //		return <WaitMoveRole>c__Iterator;
    //	}

    //	public static void DisableRole(int id, bool disable)
    //	{
    //		if (id == -1)
    //		{
    //			id = Swd6Application.instance.m_GameDataSystem.m_PlayerID;
    //		}
    //		if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
    //		{
    //			Debug.Log("disable_" + id);
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
    //				Swd6Application.instance.m_GameObjSystem.LoadObj(objData);
    //			}
    //		}
    //		else
    //		{
    //			Swd6Application.instance.m_GameObjSystem.AddGameObjData(id, new Vector3(0f, 0f, 0f), 0f, ENUM_GameObjFlag.Disable, null);
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
    //			Debug.Log("Hide_" + id);
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
    //				}
    //			}
    //			else
    //			{
    //				objData.State.Set(ENUM_GameObjFlag.Hide, hide);
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
    //			Debug.Log("NoCollider_" + id);
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
    //			Debug.Log("RoleShowItem_" + id);
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
    //			Debug.Log("RoleHideItem_" + id);
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
    //			Debug.Log("SetRoleHairLight_" + id);
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

    //	public static void HideAllNpc(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Role, true);
    //	}

    //	public static void ShowAllNpc(int mapID)
    //	{
    //		Swd6Application.instance.m_GameObjSystem.HideObjByType(mapID, ENUM_NpcType.Role, false);
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

    //	public static void ReStartPos(Transform target)
    //	{
    //		Swd6Application.instance.m_ExploreSystem.ReStartPos(target);
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
    //		UI_OkCancelBox.Instance.AddMissionMsg(data.Hint, 5f);
    //		GameTalk.FlagON(data.GUID);
    //		UI_SmallMap.Instance.FindStoryHint();
    //	}

    //	public static void FinishMission(int id)
    //	{
    //		GameTalk.FlagON(id + 500);
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg(int id, bool wait)
    //	{
    //		GameTalk.<ShowSystemMsg>c__Iterator25 <ShowSystemMsg>c__Iterator = new GameTalk.<ShowSystemMsg>c__Iterator25();
    //		<ShowSystemMsg>c__Iterator.id = id;
    //		<ShowSystemMsg>c__Iterator.wait = wait;
    //		<ShowSystemMsg>c__Iterator.<$>id = id;
    //		<ShowSystemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowSystemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowSystemMsg(string msg, bool wait)
    //	{
    //		GameTalk.<ShowSystemMsg>c__Iterator26 <ShowSystemMsg>c__Iterator = new GameTalk.<ShowSystemMsg>c__Iterator26();
    //		<ShowSystemMsg>c__Iterator.msg = msg;
    //		<ShowSystemMsg>c__Iterator.wait = wait;
    //		<ShowSystemMsg>c__Iterator.<$>msg = msg;
    //		<ShowSystemMsg>c__Iterator.<$>wait = wait;
    //		return <ShowSystemMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowGetItemMsg(int id, int count, bool wait)
    //	{
    //		GameTalk.<ShowGetItemMsg>c__Iterator27 <ShowGetItemMsg>c__Iterator = new GameTalk.<ShowGetItemMsg>c__Iterator27();
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
    //		GameTalk.<ShowDeleteItemMsg>c__Iterator28 <ShowDeleteItemMsg>c__Iterator = new GameTalk.<ShowDeleteItemMsg>c__Iterator28();
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
    //		GameTalk.<ShowLearnSkillmMsg>c__Iterator29 <ShowLearnSkillmMsg>c__Iterator = new GameTalk.<ShowLearnSkillmMsg>c__Iterator29();
    //		<ShowLearnSkillmMsg>c__Iterator.id = id;
    //		<ShowLearnSkillmMsg>c__Iterator.wait = wait;
    //		<ShowLearnSkillmMsg>c__Iterator.<$>id = id;
    //		<ShowLearnSkillmMsg>c__Iterator.<$>wait = wait;
    //		return <ShowLearnSkillmMsg>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitSystemMsg()
    //	{
    //		return new GameTalk.<WaitSystemMsg>c__Iterator2A();
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
    //				msg = string.Concat(new string[]
    //				{
    //					roleData.BaseRoleData.FamilyName,
    //					roleData.BaseRoleData.Name,
    //					GameDataDB.StrID(1002),
    //					"~[CEB5]",
    //					data.Name
    //				});
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
    //		return Swd6Application.instance.m_IdentifySystem.GetEquipItemRecordCount() >= Swd6Application.instance.m_IdentifySystem.GetEquipItemTotalCount() - 1;
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
    //		UI_OkCancelBox.Instance.AddSysMsg(data.Name + GameDataDB.StrID(1062), 3f);
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
    //		UI_OkCancelBox.Instance.AddSysMsg(data.Name + GameDataDB.StrID(1061), 3f);
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
    //		Swd6Application.instance.m_GameDataSystem.LevelUp(id, roleData.BaseRoleData.Level, true);
    //		Swd6Application.instance.m_GameDataSystem.ShowLearnSkillMsg(id);
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
    //		GameTalk.<CallFight>c__Iterator2B <CallFight>c__Iterator2B = new GameTalk.<CallFight>c__Iterator2B();
    //		<CallFight>c__Iterator2B.id = id;
    //		<CallFight>c__Iterator2B.<$>id = id;
    //		return <CallFight>c__Iterator2B;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitFightOver()
    //	{
    //		return new GameTalk.<WaitFightOver>c__Iterator2C();
    //	}

    //	public static void AddFavorability(int roleId, int targetId, int value)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.AddFavorability(roleId, targetId, value);
    //	}

    //	public static void DelFavorability(int roleId, int targetId, int value)
    //	{
    //		Swd6Application.instance.m_GameDataSystem.DelFavorability(roleId, targetId, value);
    //	}

    //	public static int GetFavorability(int roleId, int targetId)
    //	{
    //		return Swd6Application.instance.m_GameDataSystem.GetFavorability(roleId, targetId);
    //	}

    //	public static void AddAchievement(int id)
    //	{
    //		Swd6Application.instance.m_AchievementSystem.FinishAchievement(id);
    //	}

    //	public static bool CheckAchievement(int id)
    //	{
    //		return Swd6Application.instance.m_AchievementSystem.CheckFinishAchievement(id);
    //	}

    //	public static void OpenSevenRingmSystem()
    //	{
    //		GameTalk.FlagON(26);
    //		UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1020), 3f);
    //	}

    //	public static void OpenPotRealmSystem()
    //	{
    //		GameTalk.FlagON(28);
    //		if (Swd6Application.instance.IsDLC())
    //		{
    //			UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1024), 3f);
    //		}
    //		else
    //		{
    //			UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1021), 3f);
    //		}
    //	}

    //	public static void OpenWeaponBookSystem()
    //	{
    //		GameTalk.FlagON(29);
    //		UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1022), 3f);
    //	}

    //	public static void OpenSuperSkillSystem()
    //	{
    //		GameTalk.FlagON(30);
    //		UI_OkCancelBox.Instance.AddSysMsg(GameDataDB.StrID(1023), 3f);
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
    //		UI_Explore.Instance.ShowPetUI();
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

    //	public static void CostHealth(int id, int HP, int MP, int AP)
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
    //			roleData.AddAP(-AP);
    //			if (HP != 0)
    //			{
    //				FightSystem.Instance.m_HitDamageManager.SetDamage(Swd6Application.instance.m_ExploreSystem.PlayerObj.transform, -HP, 1);
    //				Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //			}
    //		}
    //	}

    //	public static void CostPartyHealth(int HP, int MP, int AP)
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
    //					roleData.AddAP(-AP);
    //				}
    //			}
    //		}
    //		if (HP != 0)
    //		{
    //			FightSystem.Instance.m_HitDamageManager.SetDamage(Swd6Application.instance.m_ExploreSystem.PlayerObj.transform, -HP, 1);
    //			Swd6Application.instance.m_ExploreSystem.AddHitDamageDelayTime();
    //		}
    //	}

    //	public static void RestoreHealth(int id, int HP, int MP, int AP)
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
    //			roleData.AddAP(AP);
    //		}
    //	}

    //	public static void RestorePartyHealth(int HP, int MP, int AP)
    //	{
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(i))
    //			{
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					roleData.AddHP(HP);
    //					roleData.AddMP(MP);
    //					roleData.AddAP(AP);
    //					if (HP >= 99999)
    //					{
    //						roleData.BaseRoleData.IsDeath = false;
    //					}
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
    //			roleData.AddAP(-AP);
    //		}
    //		int num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //		if (num != 0)
    //		{
    //			FightSystem.Instance.m_HitDamageManager.SetDamage(Swd6Application.instance.m_ExploreSystem.PlayerObj.transform, -num, 1);
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
    //					roleData.AddAP(-AP);
    //				}
    //				if (num == 0)
    //				{
    //					num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //				}
    //			}
    //		}
    //		if (num != 0)
    //		{
    //			FightSystem.Instance.m_HitDamageManager.SetDamage(Swd6Application.instance.m_ExploreSystem.PlayerObj.transform, -num, 1);
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
    //			roleData.AddAP(AP);
    //		}
    //	}

    //	public static void RestorePartyHealthRatio(float HP, float MP, float AP)
    //	{
    //		int num = 0;
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(i))
    //			{
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					roleData.AddHP(HP);
    //					roleData.AddMP(MP);
    //					roleData.AddAP(AP);
    //				}
    //				if (num == 0)
    //				{
    //					num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //				}
    //			}
    //		}
    //	}

    //	public static void RestorePartyHealthRatio1(float HP, float MP, float AP)
    //	{
    //		int num = 0;
    //		int num2 = 0;
    //		int num3 = 0;
    //		for (int i = Swd6Application.instance.m_GameDataSystem.GetMinID(); i <= Swd6Application.instance.m_GameDataSystem.GetMaxID(); i++)
    //		{
    //			if (Swd6Application.instance.m_GameDataSystem.GetFlag(i))
    //			{
    //				C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(i);
    //				if (roleData != null)
    //				{
    //					roleData.AddHP(HP);
    //					roleData.AddMP(MP);
    //					roleData.AddAP(AP);
    //				}
    //				if (num == 0)
    //				{
    //					num = (int)((float)roleData.RoleAttr.sFinial.MaxHP * HP) / 100;
    //				}
    //				if (num2 == 0)
    //				{
    //					num2 = (int)((float)roleData.RoleAttr.sFinial.MaxMP * MP) / 100;
    //				}
    //				if (num3 == 0)
    //				{
    //					num3 = (int)((float)roleData.RoleAttr.sFinial.MaxAP * AP) / 100;
    //				}
    //			}
    //		}
    //		Swd6Application.instance.StartCoroutine(GameTalk.ShowRestoreNumber(num, num2, num3));
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ShowRestoreNumber(int HP, int MP, int AP)
    //	{
    //		GameTalk.<ShowRestoreNumber>c__Iterator2D <ShowRestoreNumber>c__Iterator2D = new GameTalk.<ShowRestoreNumber>c__Iterator2D();
    //		<ShowRestoreNumber>c__Iterator2D.HP = HP;
    //		<ShowRestoreNumber>c__Iterator2D.MP = MP;
    //		<ShowRestoreNumber>c__Iterator2D.AP = AP;
    //		<ShowRestoreNumber>c__Iterator2D.<$>HP = HP;
    //		<ShowRestoreNumber>c__Iterator2D.<$>MP = MP;
    //		<ShowRestoreNumber>c__Iterator2D.<$>AP = AP;
    //		return <ShowRestoreNumber>c__Iterator2D;
    //	}

    //	public static int Rand(int min, int max)
    //	{
    //		return UnityEngine.Random.Range(min, max);
    //	}

    //	public static void OpenTreasure(GameObject obj)
    //	{
    //		if (obj != null)
    //		{
    //			obj.SendMessage("DoOpen", SendMessageOptions.DontRequireReceiver);
    //		}
    //		else
    //		{
    //			UI_Explore.Instance.AddPopMsg(GameDataDB.StrID(1010), 0);
    //		}
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenShop(int shoId)
    //	{
    //		GameTalk.<OpenShop>c__Iterator2E <OpenShop>c__Iterator2E = new GameTalk.<OpenShop>c__Iterator2E();
    //		<OpenShop>c__Iterator2E.shoId = shoId;
    //		<OpenShop>c__Iterator2E.<$>shoId = shoId;
    //		return <OpenShop>c__Iterator2E;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenMakeName(int roldId)
    //	{
    //		GameTalk.<OpenMakeName>c__Iterator2F <OpenMakeName>c__Iterator2F = new GameTalk.<OpenMakeName>c__Iterator2F();
    //		<OpenMakeName>c__Iterator2F.roldId = roldId;
    //		<OpenMakeName>c__Iterator2F.<$>roldId = roldId;
    //		return <OpenMakeName>c__Iterator2F;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenSaveLoad()
    //	{
    //		return new GameTalk.<OpenSaveLoad>c__Iterator30();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenCompleteSave()
    //	{
    //		return new GameTalk.<OpenCompleteSave>c__Iterator31();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenFight(int roldId1, int roldId2, int roldId3)
    //	{
    //		GameTalk.<OpenFight>c__Iterator32 <OpenFight>c__Iterator = new GameTalk.<OpenFight>c__Iterator32();
    //		<OpenFight>c__Iterator.roldId1 = roldId1;
    //		<OpenFight>c__Iterator.roldId2 = roldId2;
    //		<OpenFight>c__Iterator.roldId3 = roldId3;
    //		<OpenFight>c__Iterator.<$>roldId1 = roldId1;
    //		<OpenFight>c__Iterator.<$>roldId2 = roldId2;
    //		<OpenFight>c__Iterator.<$>roldId3 = roldId3;
    //		return <OpenFight>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitTime(float fTime)
    //	{
    //		GameTalk.<WaitTime>c__Iterator33 <WaitTime>c__Iterator = new GameTalk.<WaitTime>c__Iterator33();
    //		<WaitTime>c__Iterator.fTime = fTime;
    //		<WaitTime>c__Iterator.<$>fTime = fTime;
    //		return <WaitTime>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator WaitFadeTime(float alpha, float fTime)
    //	{
    //		GameTalk.<WaitFadeTime>c__Iterator34 <WaitFadeTime>c__Iterator = new GameTalk.<WaitFadeTime>c__Iterator34();
    //		<WaitFadeTime>c__Iterator.alpha = alpha;
    //		<WaitFadeTime>c__Iterator.fTime = fTime;
    //		<WaitFadeTime>c__Iterator.<$>alpha = alpha;
    //		<WaitFadeTime>c__Iterator.<$>fTime = fTime;
    //		return <WaitFadeTime>c__Iterator;
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator ReturnToStartMenu()
    //	{
    //		return new GameTalk.<ReturnToStartMenu>c__Iterator35();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator StartUserGuide(int userguideID)
    //	{
    //		GameTalk.<StartUserGuide>c__Iterator36 <StartUserGuide>c__Iterator = new GameTalk.<StartUserGuide>c__Iterator36();
    //		<StartUserGuide>c__Iterator.userguideID = userguideID;
    //		<StartUserGuide>c__Iterator.<$>userguideID = userguideID;
    //		return <StartUserGuide>c__Iterator;
    //	}

    //	public static void SaveDLCCompleteSave()
    //	{
    //		Swd6Application.instance.m_SaveloadSystem.GenerateDLCReviewStoryFlag();
    //		Swd6Application.instance.m_SaveloadSystem.SaveSystemData();
    //	}

    //	public static void OpenWOPMainMenu()
    //	{
    //		UI_WOPMainMenu.Instance.Open();
    //	}

    //	public static void OpenWOPMonsterCompositeMenu()
    //	{
    //		UI_WOPMonsterCompositeMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPManufactureMenu()
    //	{
    //		UI_WOPManufactureMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPSevenRingMenu()
    //	{
    //		UI_WOPSevenRingMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPRefineMenu()
    //	{
    //		UI_WOPRefineMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPSpellTransferMenu()
    //	{
    //		UI_WOPSpellTransferMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPUpgradeMenu()
    //	{
    //		UI_WOPUpgradeMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPCenterMenu()
    //	{
    //		UI_WOPCenterMenu.Instance.Open(true);
    //	}

    //	public static void OpenWOPArenaMenu()
    //	{
    //		UI_WOPArenaMenu.Instance.Open(true);
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
    //		GameTalk.<OpenUnLockGame>c__Iterator37 <OpenUnLockGame>c__Iterator = new GameTalk.<OpenUnLockGame>c__Iterator37();
    //		<OpenUnLockGame>c__Iterator.ID = ID;
    //		<OpenUnLockGame>c__Iterator.<$>ID = ID;
    //		return <OpenUnLockGame>c__Iterator;
    //	}

    //	public static int GetUnLockGameResult()
    //	{
    //		return UI_Unlock.Instance.GetGameResult();
    //	}

    //	[DebuggerHidden]
    //	public static IEnumerator OpenMemoryGame(int ID)
    //	{
    //		GameTalk.<OpenMemoryGame>c__Iterator38 <OpenMemoryGame>c__Iterator = new GameTalk.<OpenMemoryGame>c__Iterator38();
    //		<OpenMemoryGame>c__Iterator.ID = ID;
    //		<OpenMemoryGame>c__Iterator.<$>ID = ID;
    //		return <OpenMemoryGame>c__Iterator;
    //	}

    //	public static int GetMemoryGameResult()
    //	{
    //		return UI_MemoryPuzzle.Instance.GetGameResult();
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
    //		S_MusicEffectData data = GameDataDB.MusicEffectDB.GetData(soundID);
    //		if (data == null)
    //		{
    //			Debug.Log("musicEffectData == null " + soundID);
    //			return;
    //		}
    //		AudioClip audioClip = MusicEffectGenerator.GetAudioClip(data.MusicEffectName);
    //		if (audioClip == null)
    //		{
    //			return;
    //		}
    //		MusicControlSystem.PlaySound(audioClip, times);
    //	}

    //	public static void PlayLoopSound(int soundID)
    //	{
    //		S_MusicEffectData data = GameDataDB.MusicEffectDB.GetData(soundID);
    //		if (data == null)
    //		{
    //			Debug.Log("musicEffectData == null " + soundID);
    //			return;
    //		}
    //		AudioClip audioClip = MusicEffectGenerator.GetAudioClip(data.MusicEffectName);
    //		if (audioClip == null)
    //		{
    //			return;
    //		}
    //		MusicControlSystem.PlayLoopSound(audioClip);
    //	}

    //	public static void StopSound(int soundID)
    //	{
    //		S_MusicEffectData data = GameDataDB.MusicEffectDB.GetData(soundID);
    //		if (data == null)
    //		{
    //			Debug.Log("musicEffectData == null " + soundID);
    //			return;
    //		}
    //		MusicControlSystem.StopLoopSound(data.MusicEffectName);
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
}
