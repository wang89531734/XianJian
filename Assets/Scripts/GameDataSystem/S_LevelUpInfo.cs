using System;
using System.Collections.Generic;

public class S_LevelUpInfo
{
	public bool IsLevelUp;

	public int SkillPoint;

	public List<int> LearnSkillList;

	public S_LevelUpInfo()
	{
		this.IsLevelUp = false;
		this.SkillPoint = 0;
		this.LearnSkillList = new List<int>();
	}
}
