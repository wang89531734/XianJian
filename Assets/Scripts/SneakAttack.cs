using System;
//using Funfia.File;
using SoftStar.Pal6;
using UnityEngine;

public class SneakAttack : MonoBehaviour
{
    protected Action Core;

    // Token: 0x0400345C RID: 13404
    public float Distance = 10f;

    // Token: 0x0400345D RID: 13405
    public string SEPath;

    // Token: 0x0400345E RID: 13406
    protected Transform m_curTF;

    // Token: 0x0400345F RID: 13407
    protected Transform battleTarget;

    // Token: 0x04003460 RID: 13408
    protected Transform mTarget;

    // Token: 0x04003461 RID: 13409
    protected PalNPC npc;

    // Token: 0x04003462 RID: 13410
    private static Transform m_curCursorTF;

    // Token: 0x04003463 RID: 13411
    public static bool canQiXi = true;

    // Token: 0x04003464 RID: 13412
    public bool NeedBattle = true;

    protected Transform curTF
	{
		get
		{
			return SneakScript.MonsterTarget;
		}
	}

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06003B6A RID: 15210 RVA: 0x001AA590 File Offset: 0x001A8790
	protected Transform Target
	{
		get
		{
			if (this.mTarget == null)
			{
				this.mTarget = new GameObject("MatchTarget")
				{
					hideFlags = HideFlags.HideInHierarchy
				}.transform;
			}
			return this.mTarget;
		}
	}

	// Token: 0x06003B6B RID: 15211 RVA: 0x001AA5D4 File Offset: 0x001A87D4
	protected void OnInit()
	{
		if (PlayersManager.Player == base.gameObject)
		{
			base.enabled = true;
		}
		else
		{
			base.enabled = false;
		}
	}

	protected void OnExit()
	{
		base.enabled = false;
		//PalBattleManager.Instance().mExitBattleFunc -= this.OnExitBattle;
	}

	// Token: 0x06003B6D RID: 15213 RVA: 0x001AA62C File Offset: 0x001A882C
	protected void OnExitBattle()
	{
	}

	// Token: 0x06003B6E RID: 15214 RVA: 0x001AA630 File Offset: 0x001A8830
	public virtual void Start()
	{
		this.npc = base.GetComponent<PalNPC>();
		//GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.OnInit));
		//GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.OnExit));
		//MouseEventManager instance = MouseEventManager.Instance;
		//instance.OnMouseEnterEvent = (Action<Transform>)Delegate.Combine(instance.OnMouseEnterEvent, new Action<Transform>(this.OnMouseEnterEvent));
		//MouseEventManager instance2 = MouseEventManager.Instance;
		//instance2.OnMouseExitEvent = (Action<Transform>)Delegate.Combine(instance2.OnMouseExitEvent, new Action<Transform>(this.OnMouseExitEvent));
		//PalBattleManager.Instance().mExitBattleFunc += this.OnExitBattle;
		//if (this.npc != null)
		//{
		//	this.SEPath = FileLoader.SneakAttackPaths[this.npc.Data.CharacterID];
		//}
	}

	//protected void Achievement()
	//{
	//	int num = FlagManager.GetFlag(4);
	//	if (num < 0)
	//	{
	//		num = 0;
	//	}
	//	num++;
	//	FlagManager.SetFlag(4, num, true);
	//	int num2 = num;
	//	if (num2 != 1)
	//	{
	//		if (num2 != 50)
	//		{
	//			if (num2 == 100)
	//			{
	//				PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_100, true);
	//			}
	//		}
	//		else
	//		{
	//			PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_50, true);
	//		}
	//	}
	//	else
	//	{
	//		PalBattleManager.Instance().m_Achievement.Increse(AchievementManager.ACHIEVEMENT_INDEX.RIDE_TIMES_1, true);
	//	}
	//}

	//// Token: 0x1700049D RID: 1181
	//// (get) Token: 0x06003B71 RID: 15217 RVA: 0x001AA7C4 File Offset: 0x001A89C4
	//// (set) Token: 0x06003B70 RID: 15216 RVA: 0x001AA78C File Offset: 0x001A898C
	//public static Transform curCursorTF
	//{
	//	get
	//	{
	//		return SneakAttack.m_curCursorTF;
	//	}
	//	set
	//	{
	//		SneakAttack.m_curCursorTF = value;
	//		if (SneakAttack.m_curCursorTF != null)
	//		{
	//			CursorScriptTemp.Instance.CursorTexToState(CursorTextureState.SneakAttack, -1f);
	//		}
	//		else
	//		{
	//			CursorScriptTemp.Instance.CursorTexToNormal();
	//		}
	//	}
	//}

	//// Token: 0x06003B72 RID: 15218 RVA: 0x001AA7CC File Offset: 0x001A89CC
	//protected void OnMouseEnterEvent(Transform tf)
	//{
	//	if (GameStateManager.CurGameState == GameState.Battle)
	//	{
	//		return;
	//	}
	//	if (tf.CanSneak())
	//	{
	//		SneakAttack.curCursorTF = tf;
	//	}
	//}

	//// Token: 0x06003B73 RID: 15219 RVA: 0x001AA7EC File Offset: 0x001A89EC
	//protected void OnMouseExitEvent(Transform tf)
	//{
	//	if (GameStateManager.CurGameState == GameState.Battle)
	//	{
	//		return;
	//	}
	//	if (tf.CanSneak())
	//	{
	//		SneakAttack.curCursorTF = null;
	//	}
	//}

	//// Token: 0x06003B74 RID: 15220 RVA: 0x001AA80C File Offset: 0x001A8A0C
	//protected virtual void Attack0()
	//{
	//	SneakAttack.canQiXi = false;
	//	PlayerCtrlManager.bControl = false;
	//	PlayerCtrlManager.bCanTab = false;
	//}

	//// Token: 0x06003B75 RID: 15221 RVA: 0x001AA820 File Offset: 0x001A8A20
	//protected virtual PalSE PlayAttck(GameObject actorA, GameObject actorB, string path, bool bBaseOnSEPos = false)
	//{
	//	GameObject[] actors = new GameObject[]
	//	{
	//		actorA,
	//		actorB
	//	};
	//	return actors.PlaySE(path, bBaseOnSEPos, false);
	//}

	//// Token: 0x06003B76 RID: 15222 RVA: 0x001AA848 File Offset: 0x001A8A48
	//public static void OnDirectWin(PalNPC MeNPC, PalNPC OtherNPC)
	//{
	//	SneakAttack.canQiXi = true;
	//	Transform transform = OtherNPC.transform;
	//	SneakAttack.RemoveTarget(transform, MeNPC);
	//	PlayerCtrlManager.bControl = true;
	//	PlayerCtrlManager.agentObj.charCtrller.enabled = true;
	//}

	//// Token: 0x06003B77 RID: 15223 RVA: 0x001AA880 File Offset: 0x001A8A80
	//public static void RemoveTarget(Transform targetTF, PalNPC MeNPC = null)
	//{
	//	if (MeNPC == null && PlayerCtrlManager.agentObj != null)
	//	{
	//		MeNPC = PlayerCtrlManager.agentObj.palNPC;
	//	}
	//	if (SneakAttack.curCursorTF == targetTF)
	//	{
	//		SneakAttack.curCursorTF = null;
	//	}
	//	Perception.RemoveCanBeSeen(MeNPC, targetTF);
	//	if (SneakScript.monsterCanSneaks != null)
	//	{
	//		SneakScript.monsterCanSneaks.Remove(targetTF);
	//		if (targetTF != null)
	//		{
	//			MonsterStateScript.PushState(targetTF.gameObject, MonsterStateScript.MonsterState.None);
	//		}
	//	}
	//}

	//// Token: 0x06003B78 RID: 15224 RVA: 0x001AA900 File Offset: 0x001A8B00
	//public static void SneakUpdate()
	//{
	//	if (GameStateManager.CurGameState != GameState.Normal)
	//	{
	//		return;
	//	}
	//	if (TriggerBattleSleeper.Instance != null)
	//	{
	//		return;
	//	}
	//	if (InputManager.GetKeyDown(KEY_ACTION.TAB_SNEAK, false))
	//	{
	//		SneakScript.TabTarget();
	//	}
	//	if (SneakAttack.canQiXi)
	//	{
	//		bool flag = Input.GetKeyUp(KeyCode.Mouse0);
	//		if (flag)
	//		{
	//			flag = (flag && UICamera.hoveredObject == null && !SmoothFollow2.LeftCameraMove);
	//		}
	//		bool keyDown = InputManager.GetKeyDown(KEY_ACTION.ACTION, false);
	//		if (flag || keyDown)
	//		{
	//			SneakAttack component = PlayersManager.Player.GetComponent<SneakAttack>();
	//			if (!component.enabled)
	//			{
	//				component.enabled = true;
	//			}
	//			component.ExcuteAttack();
	//		}
	//	}
	//}

	//// Token: 0x06003B79 RID: 15225 RVA: 0x001AA9B4 File Offset: 0x001A8BB4
	//protected virtual void Update()
	//{
	//	if (this.Core != null)
	//	{
	//		this.Core();
	//	}
	//}

	//// Token: 0x06003B7A RID: 15226 RVA: 0x001AA9CC File Offset: 0x001A8BCC
	//public void ExcuteAttack()
	//{
	//	if (this.curTF == null)
	//	{
	//		return;
	//	}
	//	Transform curTF = this.curTF;
	//	if (curTF.GetComponent<QiXiInhibiter>())
	//	{
	//		Debug.Log("Log : 此对象 " + this.curTF.ToString() + " 有QiXiInhibiter 不能奇袭");
	//		return;
	//	}
	//	if (curTF != null && curTF.gameObject.activeSelf)
	//	{
	//		if (!Perception.IsCanBeSeen(this.npc, curTF))
	//		{
	//			if (SneakAttack.curCursorTF == curTF)
	//			{
	//				SneakAttack.curCursorTF = null;
	//			}
	//			SneakScript.monsterCanSneaks.Remove(curTF);
	//		}
	//		else
	//		{
	//			MessageProcess.Instance.AddMess(Message.Style.Sneak, new Action(this.Attack0));
	//		}
	//	}
	//}

	//// Token: 0x06003B7B RID: 15227 RVA: 0x001AAA90 File Offset: 0x001A8C90
	//protected virtual void OnEnd()
	//{
	//	this.Core = null;
	//	Agent component = this.battleTarget.gameObject.GetModelObj(false).GetComponent<Agent>();
	//	component.animCtrl.ActiveAnimCrossFade("BeiGongJi", false, 0.1f, true);
	//	PalNPC palNPC = component.palNPC;
	//	if (this.npc == null)
	//	{
	//		Debug.LogError("Error : JinQiXi 找不到主角NPC");
	//		return;
	//	}
	//	if (palNPC == null)
	//	{
	//		Debug.LogError("Error : JinQiXi 找不到otherNPC");
	//		return;
	//	}
	//	Vector3 forward = this.npc.model.transform.forward;
	//	forward.y = 0f;
	//	Vector3 forward2 = palNPC.model.transform.forward;
	//	forward2.y = 0f;
	//	float num = Vector3.Angle(forward, forward2);
	//	int num2 = (num <= 90f) ? 1 : 0;
	//	bool flag = true;
	//	if (flag)
	//	{
	//		this.Achievement();
	//	}
	//	CharacterController component2 = this.npc.model.GetComponent<CharacterController>();
	//	component2.enabled = false;
	//	PalBattleManager.Instance().bEnableGoToBattle = true;
	//	PalBattleManager.Instance().GoToBattleWithCameraMotion(this.npc, palNPC, flag);
	//	PlayerCtrlManager.bCanTab = true;
	//}
}
