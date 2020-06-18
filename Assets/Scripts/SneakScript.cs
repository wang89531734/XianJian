using System;
using System.Collections.Generic;
using SoftStar.Pal6;
using UnityEngine;

/// <summary>
/// 潜伏脚本
/// </summary>
public class SneakScript : MonoBehaviour
{
    private static bool First = true;

    private static List<SneakScript> sneaks = new List<SneakScript>();

    private static int targetIndex = 0;

    public static List<Transform> monsterCanSneaks = new List<Transform>();

    private static Vector3 curPlayerPos = Vector3.zero;

    public PalNPC hostNpc;

    public static Transform MonsterTarget
	{
		get
		{
			Transform result = null;
			if (SneakScript.targetIndex < SneakScript.monsterCanSneaks.Count)
			{
				result = SneakScript.monsterCanSneaks[SneakScript.targetIndex];
			}
			return result;
		}
	}

    //public static Transform TabTarget()
    //{
    //	if (SneakScript.MonsterTarget != null)
    //	{
    //		GameObject gameObject = SneakScript.MonsterTarget.gameObject;
    //		if (MonsterStateScript.GetState(gameObject) == MonsterStateScript.MonsterState.CanBeSneaked)
    //		{
    //			MonsterStateScript.PopState(gameObject);
    //		}
    //	}
    //	if (SneakScript.monsterCanSneaks.Count < 1)
    //	{
    //		SneakScript.targetIndex = 0;
    //		Debug.LogError("Error ： monsterCanSneaks列表为空");
    //		return null;
    //	}
    //	SneakScript.targetIndex = (SneakScript.targetIndex + 1) % SneakScript.monsterCanSneaks.Count;
    //	Transform monsterTarget = SneakScript.MonsterTarget;
    //	if (monsterTarget != null)
    //	{
    //		MonsterStateScript.PushState(monsterTarget.gameObject, MonsterStateScript.MonsterState.CanBeSneaked);
    //	}
    //	return monsterTarget;
    //}

    //// Token: 0x06003B80 RID: 15232 RVA: 0x001AACC0 File Offset: 0x001A8EC0
    //private static int CompareFunc(Transform a, Transform b)
    //{
    //	float num = Vector3.Distance(a.position, SneakScript.curPlayerPos);
    //	float num2 = Vector3.Distance(b.position, SneakScript.curPlayerPos);
    //	return (num >= num2) ? 1 : -1;
    //}

    //// Token: 0x06003B81 RID: 15233 RVA: 0x001AAD00 File Offset: 0x001A8F00
    //private static void UpdateMonsterOrder(float a, float b)
    //{
    //	if (PlayerCtrlManager.agentObj != null && SneakScript.monsterCanSneaks.Count > 0)
    //	{
    //		SneakScript.curPlayerPos = PlayerCtrlManager.agentObj.transform.position;
    //		SneakScript.monsterCanSneaks.Sort(new Comparison<Transform>(SneakScript.CompareFunc));
    //	}
    //}

    public static void Init(GameObject go)
    {
        if (go == null)
        {
            return;
        }
        go.GetOrAddComponent<SneakScript>();
    }

    //// Token: 0x06003B83 RID: 15235 RVA: 0x001AAD70 File Offset: 0x001A8F70
    //private void Start()
    //{
    //	if (!SneakScript.sneaks.Contains(this))
    //	{
    //		SneakScript.sneaks.Add(this);
    //	}
    //	Agent component = base.GetComponent<Agent>();
    //	if (component != null)
    //	{
    //		this.hostNpc = component.palNPC;
    //	}
    //	if (SneakScript.First)
    //	{
    //		SneakScript.First = false;
    //		GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(SneakScript.OnInit));
    //		GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(SneakScript.OnExit));
    //	}
    //	SneakScript.SetActive(GameStateManager.CurGameState == GameState.Normal);
    //}

    //// Token: 0x06003B84 RID: 15236 RVA: 0x001AADF8 File Offset: 0x001A8FF8
    //private static void SetActive(bool bActive)
    //{
    //	if (bActive)
    //	{
    //		PalMain.Instance.updateHandles += SneakScript.UpdateMonsterOrder;
    //	}
    //	else
    //	{
    //		PalMain.Instance.updateHandles -= SneakScript.UpdateMonsterOrder;
    //	}
    //	for (int i = 0; i < SneakScript.sneaks.Count; i++)
    //	{
    //		SneakScript sneakScript = SneakScript.sneaks[i];
    //		if (!(sneakScript == null))
    //		{
    //			sneakScript.enabled = bActive;
    //			Perception perception = null;
    //			if (sneakScript.hostNpc != null && sneakScript.hostNpc.perception != null)
    //			{
    //				perception = sneakScript.hostNpc.perception;
    //			}
    //			else
    //			{
    //				Debug.LogError("Error : " + sneakScript.name + " sneak.hostNpc.perception获取有问题");
    //			}
    //			if (perception != null)
    //			{
    //				if (bActive)
    //				{
    //					Perception perception2 = perception;
    //					perception2.OnBeSeenEvent = (Action<Transform>)Delegate.Remove(perception2.OnBeSeenEvent, new Action<Transform>(sneakScript.OnBeSeenEvent));
    //					Perception perception3 = perception;
    //					perception3.OnBeSeenEvent = (Action<Transform>)Delegate.Combine(perception3.OnBeSeenEvent, new Action<Transform>(sneakScript.OnBeSeenEvent));
    //					Perception perception4 = perception;
    //					perception4.OnBeNotSeenEvent = (Action<Transform>)Delegate.Remove(perception4.OnBeNotSeenEvent, new Action<Transform>(sneakScript.OnBeNotSeenEvent));
    //					Perception perception5 = perception;
    //					perception5.OnBeNotSeenEvent = (Action<Transform>)Delegate.Combine(perception5.OnBeNotSeenEvent, new Action<Transform>(sneakScript.OnBeNotSeenEvent));
    //				}
    //				else
    //				{
    //					Perception perception6 = perception;
    //					perception6.OnBeSeenEvent = (Action<Transform>)Delegate.Remove(perception6.OnBeSeenEvent, new Action<Transform>(sneakScript.OnBeSeenEvent));
    //					Perception perception7 = perception;
    //					perception7.OnBeNotSeenEvent = (Action<Transform>)Delegate.Remove(perception7.OnBeNotSeenEvent, new Action<Transform>(sneakScript.OnBeNotSeenEvent));
    //				}
    //			}
    //		}
    //	}
    //}

    //// Token: 0x06003B85 RID: 15237 RVA: 0x001AAFB4 File Offset: 0x001A91B4
    //private void OnBeSeenEvent(Transform tf)
    //{
    //	if (!base.enabled)
    //	{
    //		return;
    //	}
    //	GameObject modelObj = tf.gameObject.GetModelObj(false);
    //	DelayInactiver component = modelObj.GetComponent<DelayInactiver>();
    //	if (component != null || !modelObj.activeSelf || !modelObj.IsMonster())
    //	{
    //		return;
    //	}
    //	GameObject npcobj = base.gameObject.GetNPCObj();
    //	PalNPC component2 = npcobj.GetComponent<PalNPC>();
    //	List<Transform> list = new List<Transform>();
    //	foreach (Transform transform in SneakScript.monsterCanSneaks)
    //	{
    //		if (!Perception.IsCanBeSeen(component2, transform))
    //		{
    //			list.Add(transform);
    //		}
    //	}
    //	foreach (Transform transform2 in list)
    //	{
    //		if (SneakAttack.curCursorTF == transform2)
    //		{
    //			SneakAttack.curCursorTF = null;
    //		}
    //		SneakScript.monsterCanSneaks.Remove(transform2);
    //	}
    //	if (SneakScript.monsterCanSneaks.Count < 1)
    //	{
    //		MonsterStateScript.PushState(modelObj, MonsterStateScript.MonsterState.CanBeSneaked);
    //	}
    //	if (!SneakScript.monsterCanSneaks.Contains(tf))
    //	{
    //		SneakScript.monsterCanSneaks.Add(tf);
    //		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //		RaycastHit raycastHit;
    //		if (Physics.Raycast(ray, out raycastHit, 200f, PlayerCtrlManager.maskValue))
    //		{
    //			Transform transform3 = raycastHit.transform;
    //			if (modelObj.transform == transform3)
    //			{
    //				SneakAttack.curCursorTF = tf;
    //			}
    //		}
    //		GameObjectEvent component3 = modelObj.GetComponent<GameObjectEvent>();
    //		if (component3 != null)
    //		{
    //			GameObjectEvent gameObjectEvent = component3;
    //			gameObjectEvent.OnEnableEvent = (Action<Transform>)Delegate.Remove(gameObjectEvent.OnEnableEvent, new Action<Transform>(this.OnEnableEvent));
    //			GameObjectEvent gameObjectEvent2 = component3;
    //			gameObjectEvent2.OnEnableEvent = (Action<Transform>)Delegate.Combine(gameObjectEvent2.OnEnableEvent, new Action<Transform>(this.OnEnableEvent));
    //			GameObjectEvent gameObjectEvent3 = component3;
    //			gameObjectEvent3.OnDisableEvent = (Action<Transform>)Delegate.Remove(gameObjectEvent3.OnDisableEvent, new Action<Transform>(this.OnDisableEvent));
    //			GameObjectEvent gameObjectEvent4 = component3;
    //			gameObjectEvent4.OnDisableEvent = (Action<Transform>)Delegate.Combine(gameObjectEvent4.OnDisableEvent, new Action<Transform>(this.OnDisableEvent));
    //		}
    //	}
    //}

    //// Token: 0x06003B86 RID: 15238 RVA: 0x001AB218 File Offset: 0x001A9418
    //private void OnEnableEvent(Transform tf)
    //{
    //}

    //// Token: 0x06003B87 RID: 15239 RVA: 0x001AB21C File Offset: 0x001A941C
    //private void OnDisableEvent(Transform tf)
    //{
    //	SneakScript.OnBattleEnd(tf.gameObject);
    //}

    //// Token: 0x06003B88 RID: 15240 RVA: 0x001AB22C File Offset: 0x001A942C
    //public static void OnBattleEnd(GameObject go)
    //{
    //	go = go.GetNPCObj();
    //	SneakAttack.RemoveTarget(go.transform, null);
    //}

    //// Token: 0x06003B89 RID: 15241 RVA: 0x001AB244 File Offset: 0x001A9444
    //private void OnBeNotSeenEvent(Transform tf)
    //{
    //	if (!base.enabled)
    //	{
    //		return;
    //	}
    //	GameObject modelObj = tf.gameObject.GetModelObj(false);
    //	if (!modelObj.IsMonster())
    //	{
    //		return;
    //	}
    //	int num = SneakScript.monsterCanSneaks.IndexOf(tf);
    //	if (num > -1)
    //	{
    //		if (SneakAttack.curCursorTF == tf)
    //		{
    //			SneakAttack.curCursorTF = null;
    //		}
    //		SneakScript.monsterCanSneaks.RemoveAt(num);
    //	}
    //	MonsterStateScript.PopState(modelObj);
    //}

    //private static void OnInit()
    //{
    //	SneakScript.SetActive(true);
    //}

    //private static void OnExit()
    //{
    //	SneakScript.SetActive(false);
    //}
}
