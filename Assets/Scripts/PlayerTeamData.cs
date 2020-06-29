using SoftStar.Item;
using SoftStar.Pal6;
using System;
using System.Collections.Generic;

/// <summary>
/// 玩家队伍数据
/// </summary>
[Serializable]
public class PlayerTeamData
{
    /// <summary>
    /// 入队
    /// </summary>
	public bool Enqueue = true;

    /// <summary>
    /// 血量
    /// </summary>
	public int HP;

    /// <summary>
    /// 角色ID
    /// </summary>
	public int mCharacterID = -1;

    /// <summary>
    /// 等级
    /// </summary>
    public int mLevel = 1;

    /// <summary>
    /// 技能信息列表
    /// </summary>
	public List<PalNPC.SkillInfo> m_SkillIDs = new List<PalNPC.SkillInfo>();

    /// <summary>
    /// 物品ID
    /// </summary>
	public List<ItemD> m_ItemIDs = new List<ItemD>();
}
