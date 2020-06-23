using System;
using SoftStar.Pal6;

public class YuanQiXi : SneakAttack
{
	public override void Start()
	{
		base.Start();
	}

	protected override void Attack0()
	{
		base.Attack0();
		this.battleTarget = base.curTF;
		//PalSE palSE = this.PlayAttck(base.gameObject.GetModelObj(false), this.battleTarget.gameObject, this.SEPath, false);
		//PalSE palSE2 = palSE;
		//palSE2.m_OnEndCallback = (PalSE.OnEndCallback)Delegate.Combine(palSE2.m_OnEndCallback, new PalSE.OnEndCallback(this.OnEnd));
	}
}
