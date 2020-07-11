using System;

/// <summary>
/// 物品类型
/// </summary>
public enum ObjType
{
	monster,
	player,
	WeaponTrader,
	CanPay,
	CanGet,
	CanNotPay,
	CanNotGet,
	MainLine,
    /// <summary>
    /// 主线不能得到
    /// </summary>
	MainLineCanNotGet,
	BranchCanGet0,
	BranchCanNotGet0,
	BranchCanGet1,
	BranchCanNotGet1,
	BranchCanGet2,
	BranchCanNotGet2,
	BranchCanGet3,
	BranchCanNotGet3,
	BranchCanGet4,
	BranchCanNotGet4,
	BranchCanGet5,
	BranchCanNotGet5,
    /// <summary>
    /// 没有人
    /// </summary>
	none0,
	Enter,
	FuZhuang,
	RanFang,
	WuQi,
	XiuXi,
	YaoDian,
	ZaHuoDian,
	BaoXiang,
    /// <summary>
    /// 没有人
    /// </summary>
    none,
	HuanHua,
	CanContinue
}
