using System;

public class S_BuffStatusRelationship : I_BaseDBF
{
	public int GUID;

	public string Name;

	public int AtkUp;

	public int DefUp;

	public int MAtkUp;

	public int MDefUp;

	public int Strengthen;

	public int CriUp;

	public int DodgeUp;

	public int BlockUp;

	public int WindAUp;

	public int FireAUp;

	public int WaterAUp;

	public int EarthAUp;

	public int WindDUp;

	public int FireDUp;

	public int WaterDUp;

	public int EarthDUp;

	public int Hot;

	public int ReduceDmg;

	public int AbsorbShield;

	public int Reflex;

	public int Focus;

	public int Avoid;

	public int Berserker;

	public int Execute;

	public int Immortal;

	public int Redemption;

	public int Immunity;

	public int Fearless;

	public int SpdUp;

	public int HPUp;

	public int MPUp;

	public int DrainLife;

	public int WindCostDown;

	public int FireCostDown;

	public int WaterCostDown;

	public int EarthCostDown;

	public int Combo;

	public int Combo2;

	public int Combo3;

	public int Windbuff1;

	public int Windbuff2;

	public int Earthbuff1;

	public int Earthbuff2;

	public int Waterbuff1;

	public int Waterbuff2;

	public int Firebuff1;

	public int Firebuff2;

	public int Mhot;

	public int AtkDown;

	public int DefDown;

	public int MAtkDown;

	public int MDefDown;

	public int Weak;

	public int CriDown;

	public int DodgeDown;

	public int BlockDown;

	public int WindADown;

	public int FireADown;

	public int WaterADown;

	public int EarthADown;

	public int WindDDown;

	public int FireDDown;

	public int WaterDDown;

	public int EarthDDown;

	public int TransWind;

	public int TransFire;

	public int TransWater;

	public int TransEarth;

	public int Poison;

	public int WindDot;

	public int FireDot;

	public int WaterDot;

	public int EarthDot;

	public int LoseHeart;

	public int Stun;

	public int Paralysis;

	public int Sleep;

	public int Freeze;

	public int Seal;

	public int Silence;

	public int Tuant;

	public int Dead;

	public int SpdDown;

	public int HPDown;

	public int MPDown;

	public int Vision;

	public int MPHPDot;

	public int BonusDrop;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
		this.Name = GameDataDB.TransStringByLanguageType(this.Name);
	}
}
