using System;

public class S_MaterialEffectData : I_BaseDBF
{
	public int GUID;

	public string CryMesh;

	public string CryMaterial;

	public string ShyMesh;

	public string ShyMaterial;

	public string ChangeEyeMesh;

	public string ChangeEyeMaterial;

	public string GuardLineMesh;

	public string GuardLineMaterial;

	public string SnakeLineMesh;

	public string SnakeLineMaterial;

	public string BleedMesh;

	public string BleedMaterial;

	public int GetGUID()
	{
		return this.GUID;
	}

	public void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record)
	{
	}
}
