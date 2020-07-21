using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader
{
	private Dictionary<string, UnityEngine.Object> m_ResourceDB_Map;

	private Dictionary<string, UnityEngine.Object> m_ResourceDB_Fight;

	private Dictionary<string, UnityEngine.Object> m_ResourceDB_Story;

	private Dictionary<string, UnityEngine.Object> m_ResourceDB_UI;

	private string m_AssetBundlePath = string.Empty;

	private string m_ResourcesPath = string.Empty;

	private string m_ExtensionName = string.Empty;

	public ResourceLoader(string assetBundlePath)
	{
		this.m_AssetBundlePath = assetBundlePath;
		this.m_ResourceDB_Map = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_Fight = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_Story = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_UI = new Dictionary<string, UnityEngine.Object>();
	}

	public ResourceLoader(string assetBundlePath, string resourcesPath, string extensionName)
	{
		this.m_AssetBundlePath = assetBundlePath;
		this.m_ResourcesPath = resourcesPath;
		this.m_ExtensionName = extensionName;
		this.m_ResourceDB_Map = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_Fight = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_Story = new Dictionary<string, UnityEngine.Object>();
		this.m_ResourceDB_UI = new Dictionary<string, UnityEngine.Object>();
	}

	public UnityEngine.Object GetResourceObj(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		UnityEngine.Object @object = null;
		if (this.m_ResourceDB_Map.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Map[name];
			if (@object == null)
			{
				this.m_ResourceDB_Map.Remove(name);
			}
		}
		if (@object == null)
		{
			@object = this.LoadFromAssetBundle(name, this.m_ResourceDB_Map);
		}
		return @object;
	}

	public UnityEngine.Object GetResourceObj_UI(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		UnityEngine.Object @object = null;
		if (this.m_ResourceDB_Map.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Map[name];
			if (@object == null)
			{
				this.m_ResourceDB_Map.Remove(name);
			}
		}
		if (@object == null && this.m_ResourceDB_UI.ContainsKey(name))
		{
			@object = this.m_ResourceDB_UI[name];
			if (@object == null)
			{
				this.m_ResourceDB_UI.Remove(name);
			}
		}
		if (@object == null)
		{
			@object = this.LoadFromAssetBundle(name, this.m_ResourceDB_UI);
		}
		return @object;
	}

	public UnityEngine.Object GetResourceObj_Story(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		UnityEngine.Object @object = null;
		if (this.m_ResourceDB_Map.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Map[name];
			if (@object == null)
			{
				this.m_ResourceDB_Map.Remove(name);
			}
		}
		if (@object == null && this.m_ResourceDB_Story.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Story[name];
			if (@object == null)
			{
				this.m_ResourceDB_Story.Remove(name);
			}
		}
		if (@object == null)
		{
			@object = this.LoadFromAssetBundle(name, this.m_ResourceDB_Story);
		}
		return @object;
	}

	public UnityEngine.Object GetResourceObj_Fight(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		UnityEngine.Object @object = null;
		if (this.m_ResourceDB_Map.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Map[name];
			if (@object == null)
			{
				this.m_ResourceDB_Map.Remove(name);
			}
		}
		if (@object == null && this.m_ResourceDB_Story.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Story[name];
			if (@object == null)
			{
				this.m_ResourceDB_Story.Remove(name);
			}
		}
		if (@object == null && this.m_ResourceDB_Fight.ContainsKey(name))
		{
			@object = this.m_ResourceDB_Fight[name];
			if (@object == null)
			{
				this.m_ResourceDB_Fight.Remove(name);
			}
		}
		if (@object == null)
		{
			@object = this.LoadFromAssetBundle(name, this.m_ResourceDB_Fight);
		}
		return @object;
	}

	private UnityEngine.Object LoadFromAssetBundle(string name, Dictionary<string, UnityEngine.Object> DB)
	{
		if (name == null || name == string.Empty)
		{
			return null;
		}
		AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.dataPath + this.m_AssetBundlePath + name + ".unity3d");
		if (assetBundle == null)
		{
			return null;
		}
		UnityEngine.Object mainAsset = assetBundle.LoadAsset(name);
        if (mainAsset == null)
		{
			assetBundle.Unload(false);
			return null;
		}
		DB.Add(name, mainAsset);
		assetBundle.Unload(false);
		return mainAsset;
	}

	private UnityEngine.Object LoadFromResources(string name, Dictionary<string, UnityEngine.Object> DB)
	{
		if (name == null || name == string.Empty)
		{
			return null;
		}      
        string assetPath = this.m_ResourcesPath + name + this.m_ExtensionName;
		UnityEngine.Object @object = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
		if (@object == null)
		{
			return null;
		}
		DB.Add(name, @object);
		return @object;
	}

	public void Clear()
	{
		this.m_ResourceDB_Map.Clear();
	}

	public void Clear_Fight()
	{
		this.m_ResourceDB_Fight.Clear();
	}

	public void Clear_Story()
	{
		this.m_ResourceDB_Story.Clear();
	}

	public void Clear_UI()
	{
		this.m_ResourceDB_UI.Clear();
	}
}
