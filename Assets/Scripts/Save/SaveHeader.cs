using System;

[Serializable]
public class SaveHeader
{
	public string m_GameVersion;

	public int m_ChapID;

	public int m_Money;

	public int m_SoulPoint;

	public int m_SoulStone;

	public int m_Stamina;

	public int m_Sense;

	public int m_FightScore;

	public int m_LegendPoint;

	public int m_CompleteGame;

	public int m_PlayGameCount;

	public int m_PlayerID;

	public int m_BreakBoxTimes;

	public int m_SelectPet;

	public int[] m_FightRole;

	public int[] m_LV;

	public float m_PlayTimes;

	public float m_PosX;

	public float m_PosY;

	public float m_PosZ;

	public float m_Dir;

	public float m_CameraXAngle;

	public float m_CameraYAngle;

	public float m_CameraDist;

	//public S_MapInfo m_MapInfo;

	public byte[] m_GameFlag;

	//public SaveTime m_SaveTime;

	public int[] m_Reserve;

	public SaveHeader()
	{
		this.m_FightRole = new int[3];
		this.m_LV = new int[5];
		this.m_Reserve = new int[20];
		//this.m_MapInfo = default(S_MapInfo);
		//this.m_SaveTime = new SaveTime();
	}
}
