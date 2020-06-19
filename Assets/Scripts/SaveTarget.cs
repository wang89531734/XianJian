using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveTarget : MonoBehaviour
{
    [SerializeField]
    private bool m_TransDataSkip;

    public virtual bool Save(BinaryWriter writer)
	{
		//string path = GameObjectPath.GetPath(base.transform);
		//writer.Write(path);
		this.SaveTranData(writer);
		this.SaveTargetData(writer);
		return true;
	}

	public virtual bool Load(BinaryReader reader)
	{
		this.LoadTranData(reader);
		this.LoadTargetData(reader);
		return true;
	}
	
	public static bool LOAD(BinaryReader reader)
	{
		string text = reader.ReadString();
		GameObject gameObject = GameObject.Find(text);
		if (gameObject == null)
		{
			int length = text.IndexOf("/", 1);
			string name = text.Substring(0, length);
			GameObject gameObject2 = GameObject.Find(name);
			if (gameObject2 != null)
			{
				int startIndex = text.LastIndexOf("/") + 1;
				string b = text.Substring(startIndex);
				foreach (SaveTarget saveTarget in gameObject2.GetComponentsInChildren<SaveTarget>(true))
				{
					if (saveTarget.name == b)
					{
						gameObject = saveTarget.gameObject;
						break;
					}
				}
			}
		}
		if (gameObject == null)
		{
			return false;
		}
		SaveTarget saveTarget2 = gameObject.GetComponent<SaveTarget>();
		if (saveTarget2 == null)
		{
			saveTarget2 = gameObject.AddComponent<SaveTarget>();
		}
		saveTarget2.Load(reader);
		return true;
	}

	protected virtual void SaveTranData(BinaryWriter writer)
	{
		//Transform transform = base.gameObject.GetModelObj(false).transform;
		try
		{
			writer.Write(transform.position.x);
			writer.Write(transform.position.y);
			writer.Write(transform.position.z);
			writer.Write(transform.rotation.w);
			writer.Write(transform.rotation.x);
			writer.Write(transform.rotation.y);
			writer.Write(transform.rotation.z);
			writer.Write(transform.gameObject.activeSelf);
		}
		catch (Exception ex)
		{
			//string path = GameObjectPath.GetPath(base.transform);
			//Debug.LogError("Error : " + path + " " + ex.ToString());
		}
	}

	// Token: 0x060032AC RID: 12972 RVA: 0x0016FD80 File Offset: 0x0016DF80
	protected virtual void LoadTranData(BinaryReader reader)
	{
		bool flag = base.gameObject.name == "XianJing01" || base.gameObject.name == "XianJing02" || base.gameObject.name == "XianJing03" || this.m_TransDataSkip;
		//Transform transform = base.gameObject.GetModelObj(false).transform;
		Vector3 position;
		position.x = reader.ReadSingle();
		position.y = reader.ReadSingle();
		position.z = reader.ReadSingle();
		if (!flag)
		{
			transform.position = position;
		}
		Quaternion rotation;
		rotation.w = reader.ReadSingle();
		rotation.x = reader.ReadSingle();
		rotation.y = reader.ReadSingle();
		rotation.z = reader.ReadSingle();
		if (!flag)
		{
			transform.rotation = rotation;
		}
		bool bActive = reader.ReadBoolean();
		//transform.SetActive(bActive);
	}

	// Token: 0x060032AD RID: 12973 RVA: 0x0016FE84 File Offset: 0x0016E084
	protected virtual void SaveTargetData(BinaryWriter writer)
	{
		Dictionary<Type, List<ISaveInterface>> dictionary = new Dictionary<Type, List<ISaveInterface>>();
		foreach (Component component in base.gameObject.GetComponents<Component>())
		{
			ISaveInterface saveInterface = component as ISaveInterface;
			if (saveInterface != null)
			{
				Type type = component.GetType();
				if (!dictionary.ContainsKey(type))
				{
					dictionary.Add(type, new List<ISaveInterface>
					{
						saveInterface
					});
				}
				else
				{
					dictionary[type].Add(saveInterface);
				}
			}
		}
		writer.Write(dictionary.Keys.Count);
		foreach (KeyValuePair<Type, List<ISaveInterface>> keyValuePair in dictionary)
		{
			writer.Write(keyValuePair.Key.FullName);
			List<ISaveInterface> value = keyValuePair.Value;
			writer.Write(value.Count);
			for (int j = 0; j < value.Count; j++)
			{
				ISaveInterface saveInterface2 = value[j];
				saveInterface2.Save(writer);
			}
		}
	}

	// Token: 0x060032AE RID: 12974 RVA: 0x0016FFCC File Offset: 0x0016E1CC
	protected virtual void LoadTargetData(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		GameObject gameObject = base.gameObject;
		object[] args = new object[]
		{
			reader
		};
		for (int i = 0; i < num; i++)
		{
			string typeName = reader.ReadString();
			Type type = Type.GetType(typeName);
			int num2 = reader.ReadInt32();
			foreach (Component target in base.GetComponents(type))
			{
				type.InvokeMember("Load", BindingFlags.Public | BindingFlags.InvokeMethod, null, target, args);
			}
			Component[] components;
			//for (int k = 0; k < num2 - components.Length; k++)
			//{
			//	Component target2 = gameObject.AddComponent(type);
			//	type.InvokeMember("Load", BindingFlags.Public | BindingFlags.InvokeMethod, null, target2, args);
			//}
		}
	}
}
