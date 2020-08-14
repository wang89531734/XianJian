using System;
using System.Collections.Generic;

public class FightDamageData
{
	public Enum_FightHitType m_emAnimationType;

	public List<FightShowMsg> m_HitList = new List<FightShowMsg>();

	public List<int> m_HitBuffs = new List<int>();

	public List<int> m_DeBuffs = new List<int>();

	public bool m_bCritical;

	public bool m_bBlock;

	public bool m_DoubleDmg;
}
