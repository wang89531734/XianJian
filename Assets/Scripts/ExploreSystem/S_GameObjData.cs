using System;
using UnityEngine;

public class S_GameObjData
{
	public int Id;

	public int OrgMapId;

	public int MapId;

	public Vector3 Pos;

	public float Dir;

	public float Dir2;

	public int Motion;

	public GameObjState State;

	public ENUM_QuestState QuestState;

	public float SpawnTime;

	public int[] AttachID = new int[2];

	public bool HairNoLight;

	public bool SetDefaultData;

	public GameObject GameObj;

	public M_GameRoleBase RoleBase;

	public S_GameObjData()
	{
	}

	public S_GameObjData(int roleid, int mapid, Vector3 pos, float angle, int motion, GameObjState state, GameObject gameObj)
	{
		this.Id = roleid;
		this.MapId = mapid;
		this.Motion = motion;
		this.Pos = pos;
		this.Dir = angle;
		this.State = state;
		this.GameObj = gameObj;
		this.OrgMapId = mapid;
		this.Dir2 = 1000f;
	}

	//public S_GameObjData(GameObjCreateParam CreateParam, GameObject gameObj)
	//{
	//	this.Id = CreateParam.Id;
	//	this.MapId = CreateParam.MapId;
	//	this.Motion = CreateParam.Motion;
	//	this.Pos = CreateParam.Pos;
	//	this.Dir = CreateParam.Dir;
	//	this.State = CreateParam.State;
	//	this.QuestState = CreateParam.QuestState;
	//	this.GameObj = gameObj;
	//	this.OrgMapId = this.Id;
	//}

	//public void SetData(S_SaveGameObjData data)
	//{
	//	this.Id = data.Id;
	//	this.OrgMapId = data.OrgMapId;
	//	this.MapId = data.MapId;
	//	this.Pos.x = data.PosX;
	//	this.Pos.y = data.PosY;
	//	this.Pos.z = data.PosZ;
	//	this.Dir = data.Dir;
	//	this.Motion = data.Motion;
	//	this.State = data.State;
	//	this.QuestState = data.QuestState;
	//	this.SpawnTime = data.SpawnTime;
	//}

	public void Save(GameFileStream stream)
	{
		stream.WriteInt(this.Id);
		stream.WriteInt(this.OrgMapId);
		stream.WriteInt(this.MapId);
		stream.WriteVector3(this.Pos);
		stream.WriteFloat(this.Dir);
		stream.WriteInt(this.Motion);
		stream.WriteInt((int)this.QuestState);
		stream.WriteInt((int)this.State.Get());
		stream.WriteFloat(this.SpawnTime);
		stream.WriteInt(this.AttachID[0]);
		stream.WriteInt(this.AttachID[1]);
		stream.WriteBool(this.HairNoLight);
		stream.WriteBool(this.SetDefaultData);
		stream.WriteFloat(this.Dir2);
	}

	public void Load(GameFileStream stream)
	{
		this.Id = stream.ReadInt();
		this.OrgMapId = stream.ReadInt();
		this.MapId = stream.ReadInt();
		this.Pos = stream.ReadVector3();
		this.Dir = stream.ReadFloat();
		this.Motion = stream.ReadInt();
		this.QuestState = (ENUM_QuestState)stream.ReadInt();
		ENUM_GameObjFlag state = (ENUM_GameObjFlag)stream.ReadInt();
		this.State = new GameObjState();
		this.State.Set(state);
		this.SpawnTime = stream.ReadFloat();
		this.AttachID[0] = stream.ReadInt();
		this.AttachID[1] = stream.ReadInt();
		this.HairNoLight = stream.ReadBool();
		float num = float.Parse("0.03");
		//if (Swd6Application.instance.m_SaveloadSystem.m_Version >= num)
		//{
		//	this.SetDefaultData = stream.ReadBool();
		//	this.Dir2 = 1000f;
		//}
		//num = float.Parse("0.04");
		//if (Swd6Application.instance.m_SaveloadSystem.m_Version >= num)
		//{
		//	this.Dir2 = stream.ReadFloat();
		//}
	}
}
