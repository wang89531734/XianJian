using System;
using System.Collections.Generic;
using SoftStar.Item;
using SoftStar.Pal6;

[Serializable]
public class PlayerTeamData
{
    /// <summary>
    /// 是否入队
    /// </summary>
	public bool Enqueue = true;

	public int HP;

    /// <summary>
    /// 角色ID
    /// </summary>
	public int mCharacterID = -1;

	public int mLevel = 1;

    public List<PalNPC.SkillInfo> m_SkillIDs = new List<PalNPC.SkillInfo>();

    public List<ItemD> m_ItemIDs = new List<ItemD>();
}
