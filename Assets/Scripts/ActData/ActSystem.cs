using System;
using UnityEngine;

public class ActSystem
{
	private static ActSystem instance;

	public float createTime;

	public static ActSystem Instance
	{
		get
		{
			if (ActSystem.instance == null)
			{
				ActSystem.instance = new ActSystem();
			}
			return ActSystem.instance;
		}
	}

	private ActSystem()
	{
		this.createTime = Time.time;
	}

	public M_ActProcessor GetActProcessor(int skillID)
	{
		string name = skillID.ToString();
		ActData actData = ResourcesManager.Instance.GetActData(name);
		if (actData == null)
		{
			return null;
		}
		GameObject gameObject = new GameObject(name);
		M_ActProcessor m_ActProcessor = gameObject.AddComponent<M_ActProcessor>();
		m_ActProcessor.m_ActData = actData;
		actData.Reset();
		return m_ActProcessor;
	}

	public M_ActProcessor GetActProcessor(string actDataName)
	{
        //获取攻击数据
        //ActData actData = ResourcesManager.Instance.GetActData(actDataName);
        //if (actData == null)
        //{
        //          Debug.Log("actDataName : " + actDataName);
        //          return null;
        //}
        ActData actData = new ActData();//后期改成读表
        GameObject gameObject = new GameObject(actDataName);
		M_ActProcessor m_ActProcessor = gameObject.AddComponent<M_ActProcessor>();
        m_ActProcessor.m_ActData = actData;
		actData.Reset();
        return m_ActProcessor;
	}

	public M_ActProcessor GetActProcessor(ActData actData)
	{
		if (actData == null)
		{
			return null;
		}
		GameObject gameObject = new GameObject(actData.name);
		M_ActProcessor m_ActProcessor = gameObject.AddComponent<M_ActProcessor>();
		m_ActProcessor.m_ActData = actData;
		actData.Reset();
		return m_ActProcessor;
	}
}
