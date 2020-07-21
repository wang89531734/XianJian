using System;

public enum ENUM_GameObjFlag
{
	None,
	Move,
	Run,
	Jump = 4,
	Talk = 8,
	PauseMove = 16,
	Turn = 32,
	TalkTurn = 64,
	Follow = 256,
	FadeOut = 512,
	Disable = 268435456,
	Hide = 536870912,
	NoCollider = 1073741824,
	Ground = 67108864,
	Open = 16777216,
	Pick = 33554432,
	Invalid = 134217728,
	View = 1048576,
	Hide2 = 2097152
}
