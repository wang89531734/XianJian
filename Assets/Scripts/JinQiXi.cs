using System;
using SoftStar.Pal6;
using UnityEngine;


public class JinQiXi : SneakAttack
{
    private float curRatio;

    private float attackRatio;

    private float ratioSpeed;

    // Token: 0x040033F7 RID: 13303
    private Vector3 lastMainPos = Vector3.zero;

    // Token: 0x040033F8 RID: 13304
    public float Speed = 20f;

    private Agent agent;

    //private AnimCtrlScript animCtrl;

    // Token: 0x040033FB RID: 13307
    private bool hasInState;

    //private PalSE usedSE;

    // Token: 0x040033FD RID: 13309
    public float AttackTime = 0.1f;

    public override void Start()
	{
		base.Start();
	}

	protected override void Attack0()
	{
		if (base.curTF == null)
		{
			Debug.LogError("Error : JinQiXi.Attack0  curTF == null");
			return;
		}
		//base.Attack0();
		//GameObject modelObj = base.gameObject.GetModelObj(false);
		//this.animCtrl = modelObj.GetComponent<AnimCtrlScript>();
		//this.animCtrl.ActiveZhanDou(true, 1, true, true, true);
		//this.agent = modelObj.GetComponent<Agent>();
		//this.animCtrl.ActiveAnimCrossFade("ChongJi_Q", false, 0f, true);
		//this.animCtrl.animator.SetLayerWeight(2, 0f);
		//this.lastMainPos = this.animCtrl.transform.position;
		//this.curRatio = 0f;
		//this.attackRatio = 0f;
		//this.CaculateTarget(this.animCtrl.transform, base.curTF.gameObject.GetModelObj(false).transform, 0.7f);
		//this.hasInState = false;
		//this.Core = new Action(this.Attack0_Core);
		//this.battleTarget = base.curTF;
		//this.animCtrl.gameObject.PlayUnitSE(5271);
	}

	private void Attack0_Core()
	{
		//AnimatorStateInfo currentAnimatorStateInfo = this.animCtrl.animator.GetCurrentAnimatorStateInfo(0);
		//if (this.curRatio < 1f)
		//{
		//	Transform transform = this.animCtrl.transform;
		//	Vector3 a = Vector3.Lerp(this.lastMainPos, base.Target.position, this.curRatio);
		//	Vector3 motion = a - transform.position;
		//	this.agent.charCtrller.Move(motion);
		//	this.curRatio += this.ratioSpeed * Time.deltaTime;
		//	transform.rotation = Quaternion.Lerp(transform.rotation, base.Target.rotation, 15f * Time.deltaTime);
		//	if (this.curRatio > this.attackRatio && !currentAnimatorStateInfo.IsName("gongjiState.ChongJi_H") && !this.hasInState)
		//	{
		//		AdjustBody x = this.animCtrl.gameObject.GetComponent<AdjustBody>();
		//		if (x == null)
		//		{
		//			x = this.animCtrl.gameObject.AddComponent<AdjustBody>();
		//		}
		//		this.hasInState = true;
		//		this.usedSE = this.PlayAttck(this.animCtrl.gameObject, this.battleTarget.gameObject, this.SEPath, false);
		//		this.usedSE.m_OnEndCallback = new PalSE.OnEndCallback(this.OnEnd);
		//	}
		//}
		//else if (!currentAnimatorStateInfo.IsName("gongjiState.ChongJi_H") && !this.hasInState)
		//{
		//	this.hasInState = true;
		//	this.usedSE = this.PlayAttck(this.animCtrl.gameObject, this.battleTarget.gameObject, this.SEPath, false);
		//	this.usedSE.m_OnEndCallback = new PalSE.OnEndCallback(this.OnEnd);
		//}
	}

	private void CaculateTarget(Transform tfA, Transform tfB, float offset = 0.7f)
	{
		Vector3 forward = tfB.position - tfA.position;
		float num = forward.magnitude;
		CharacterController component = tfA.GetComponent<CharacterController>();
		CharacterController component2 = tfB.GetComponent<CharacterController>();
		float num2 = component.radius + component2.radius + offset;
		float t = 1f - num2 / num;
		Vector3 position = Vector3.Lerp(tfA.position, tfB.position, t);
		base.Target.position = position;
		base.Target.forward = forward;
		num -= num2;
		num = Mathf.Abs(num);
		float num3 = num / this.Speed;
		num3 = Mathf.Abs(num3);
		this.attackRatio = 1f - this.AttackTime / num3;
		this.ratioSpeed = 1f / num3;
	}
}
