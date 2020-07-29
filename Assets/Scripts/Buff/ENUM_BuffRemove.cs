using System;

public enum ENUM_BuffRemove
{
	Null = -1,
	Hit = 1,
	SkillHit,
	SuperSkillHit = 4,
	AbsorbShieldBroken = 8,
	Die = 16,
	CallSkillAfter = 32,
	UseAttack = 64,
	UseSkill = 128,
	UseSuperSkill = 256,
	UseItem = 512,
	Invisible = 1024
}
