using System;
using UnityEngine;
using YouYou;

public class RendererTool
{
	public static void ChangeSenceMaterialSetting(string roleName, GameObject gameObject, int skyID)
	{
		if (roleName == null)
		{
			return;
		}
		int mapID = GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID;
		if (GameDataDB.MapDB.GetData(mapID) == null)
		{
			return;
		}
		int id = mapID * 100 + skyID + 1;
		S_SenceMaterialSetting data = GameDataDB.SenceMaterialSettingDB.GetData(id);
		if (data == null)
		{
			id = mapID * 100;
			data = GameDataDB.SenceMaterialSettingDB.GetData(id);
			if (data == null)
			{
				return;
			}
		}
		if (data.Settings.ContainsKey(roleName))
		{
			foreach (Transform transform in gameObject.transform)
			{
				SkinnedMeshRenderer component = transform.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					component.material.SetFloat("_ExposureIBLX", data.Settings[roleName].IBL);
					component.material.SetFloat("_ExposureIBLY", Mathf.Max(1f, data.Settings[roleName].IBL * 0.5f));
					component.material.SetFloat("_IBLDiffSaturationValue", data.Settings[roleName].Saturation);
				}
			}
		}
		else if (data.Settings.ContainsKey("Common"))
		{
			foreach (Transform transform2 in gameObject.transform)
			{
				SkinnedMeshRenderer component2 = transform2.GetComponent<SkinnedMeshRenderer>();
				if (component2 != null)
				{
					component2.material.SetFloat("_ExposureIBLX", data.Settings["Common"].IBL);
				}
			}
		}
	}

	public static void ChangeSenceMaterialSetting(string roleName, GameObject gameObject)
	{
		int mapID = GameEntry.Instance.m_GameDataSystem.m_MapInfo.MapID;
		S_MapData data = GameDataDB.MapDB.GetData(mapID);
		if (data == null)
		{
			return;
		}
		int id;
		if (data.SkyID == -1)
		{
			id = mapID * 100;
		}
		else
		{
			id = mapID * 100 + data.SkyID + 1;
		}
		S_SenceMaterialSetting data2 = GameDataDB.SenceMaterialSettingDB.GetData(id);
		if (data2 == null)
		{
			id = mapID * 100;
			data2 = GameDataDB.SenceMaterialSettingDB.GetData(id);
			if (data2 == null)
			{
				return;
			}
		}
		if (data2.Settings.ContainsKey(roleName))
		{
			foreach (Transform transform in gameObject.transform)
			{
				SkinnedMeshRenderer component = transform.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					component.material.SetFloat("_ExposureIBLX", data2.Settings[roleName].IBL);
					component.material.SetFloat("_ExposureIBLY", Mathf.Max(1f, data2.Settings[roleName].IBL * 0.5f));
					component.material.SetFloat("_IBLDiffSaturationValue", data2.Settings[roleName].Saturation);
				}
			}
		}
		else if (data2.Settings.ContainsKey("Common"))
		{
			foreach (Transform transform2 in gameObject.transform)
			{
				SkinnedMeshRenderer component2 = transform2.GetComponent<SkinnedMeshRenderer>();
				if (component2 != null)
				{
					component2.material.SetFloat("_ExposureIBLX", data2.Settings["Common"].IBL);
				}
			}
		}
	}

	public static void SetNPCMaterail(int ID, GameObject gameObject)
	{
		S_NpcData data = GameDataDB.NpcDB.GetData(ID);
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < data.Materail.Count; i++)
		{
			if (data.Materail[i].MeshName != null)
			{
				Transform transform = TransformTool.FindChild(gameObject.transform, data.Materail[i].MeshName);
				if (transform)
				{
					//transform.renderer.material = null;
					//transform.renderer.material = ResourcesManager.Instance.GetMaterial(data.Materail[i].MaterailName);
				}
			}
		}
	}

	public static void EnableRenderer(GameObject obj, string rendererName, bool enable)
	{
		Transform transform = obj.transform.FindChild(rendererName);
		if (transform == null)
		{
			return;
		}
		Renderer component = transform.GetComponent<Renderer>();
		if (component == null)
		{
			return;
		}
		component.enabled = enable;
	}

	public static void EnableChildRenderers(GameObject obj, bool enable)
	{
		foreach (Transform transform in obj.transform)
		{
			Renderer component = transform.GetComponent<Renderer>();
			if (component != null)
			{
				component.enabled = enable;
			}
		}
	}

	public static void EnableAllRenderers(GameObject obj, bool enable)
	{
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		Renderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Renderer renderer = array[i];
			renderer.enabled = enable;
		}
	}

	public static void EnableAllRendererLightProbes(GameObject obj, bool enable)
	{
		Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
		Renderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Renderer renderer = array[i];
			renderer.useLightProbes = enable;
		}
	}

	public static void CreateAfterImage(GameObject character)
	{
		SkinnedMeshRenderer[] componentsInChildren = character.GetComponentsInChildren<SkinnedMeshRenderer>();
		CombineInstance[] array = new CombineInstance[componentsInChildren.Length];
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Mesh mesh = new Mesh();
			mesh.name = "Smrs Mesh";
			componentsInChildren[i].BakeMesh(mesh);
			array[i].mesh = mesh;
			array[i].transform = componentsInChildren[i].transform.localToWorldMatrix;
		}
		GameObject gameObject = new GameObject("AfterImage");
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		meshFilter.mesh = new Mesh();
		meshFilter.mesh.CombineMeshes(array);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.sharedMaterial = ResourcesManager.Instance.GetMaterial("AfterImage");
		//gameObject.AddComponent<AfterImage>();
		for (int j = 0; j < array.Length; j++)
		{
			UnityEngine.Object.Destroy(array[j].mesh);
		}
	}

	public static void ChangeShader(GameObject gameObject, string oldShader, string newShader)
	{
		if (gameObject == null)
		{
			return;
		}
		Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
		if (componentsInChildren != null)
		{
			Renderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Renderer renderer = array[i];
				if (renderer)
				{
					if (oldShader != string.Empty)
					{
						if (renderer.material.shader.name == oldShader)
						{
							renderer.material.shader = Shader.Find(newShader);
						}
					}
					else
					{
						renderer.material.shader = Shader.Find(newShader);
					}
				}
			}
		}
	}

	public static string GetShaderName(GameObject gameObject)
	{
		if (gameObject == null)
		{
			return null;
		}
		Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
		if (componentsInChildren != null)
		{
			Renderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Renderer renderer = array[i];
				if (renderer)
				{
					return renderer.material.shader.name;
				}
			}
		}
		return null;
	}

	public static void SetColor(GameObject gameObject, Color color)
	{
		if (gameObject == null)
		{
			return;
		}
		Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
		if (componentsInChildren != null)
		{
			Renderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Renderer renderer = array[i];
				if (renderer)
				{
					renderer.material.color = color;
				}
			}
		}
	}
}
