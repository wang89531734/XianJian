using System;
using System.Collections.Generic;
using UnityEngine;

public class T_GameDB<T>
{
	private SortedDictionary<int, T> m_ContainerObject = new SortedDictionary<int, T>();

	private SortedDictionary<int, T>.Enumerator m_UseIter;

	public void AddDataFromList(List<T> datas)
	{
		foreach (T current in datas)
		{
			this.AddData(current);
		}
	}

	public void AddData(T data)
	{
		if (data == null)
		{
			return;
		}
		if (data is I_BaseDBF)
		{
			I_BaseDBF i_BaseDBF = data as I_BaseDBF;
			int gUID = i_BaseDBF.GetGUID();
			if (this.m_ContainerObject.ContainsKey(gUID))
			{
				Debug.LogWarning(typeof(T) + "中有重覆使用的GUID:" + gUID);
			}
			else
			{
				this.m_ContainerObject.Add(gUID, data);
			}
		}
		else
		{
			Debug.LogError(typeof(T) + "未繼承自I_DBFGetGUID類別");
		}
	}

	public T GetData(int id)
	{
		if (this.m_ContainerObject.ContainsKey(id))
		{
			return this.m_ContainerObject[id];
		}
		return default(T);
	}

	public int GetDataSize()
	{
		return this.m_ContainerObject.Count;
	}

	public void Clear()
	{
		this.m_ContainerObject.Clear();
	}

	public void ResetByOrder()
	{
		this.m_UseIter = this.m_ContainerObject.GetEnumerator();
	}

	public T GetDataByOrder()
	{
		if (!this.m_UseIter.MoveNext())
		{
			return default(T);
		}
		KeyValuePair<int, T> current = this.m_UseIter.Current;
		return current.Value;
	}
}
