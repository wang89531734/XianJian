using System;
using System.Collections.Generic;
using UnityEngine;


public class LateSetActive : MonoBehaviour
{
    public static Dictionary<string, LateSetActive> Dic = new Dictionary<string, LateSetActive>();

    public float time = 0.01f;

    public bool bActive;

    private GameObject go;

    public static void DeleteKey(string objName)
	{
		if (LateSetActive.Dic.ContainsKey(objName))
		{
			LateSetActive lateSetActive = LateSetActive.Dic[objName];
			if (lateSetActive != null)
			{
				lateSetActive.time = 10000f;
				UnityEngine.Object.Destroy(lateSetActive);
			}
		}
	}

	public static void Clear()
	{
		foreach (KeyValuePair<string, LateSetActive> keyValuePair in LateSetActive.Dic)
		{
			LateSetActive.DeleteKey(keyValuePair.Key);
		}
		LateSetActive.Dic.Clear();
	}

	private void Start()
	{
	}

	public static void Init(GameObject go, bool bActive, float time)
	{
		GameObject gameObject = GameObject.Find("/Main");
		if (gameObject == null)
		{
			gameObject = new GameObject("Main");
		}
		LateSetActive lateSetActive;
		if (LateSetActive.Dic.ContainsKey(go.name))
		{
			lateSetActive = LateSetActive.Dic[go.name];
			if (lateSetActive == null)
			{
				lateSetActive = gameObject.AddComponent<LateSetActive>();
				LateSetActive.Dic[go.name] = lateSetActive;
			}
		}
		else
		{
			lateSetActive = gameObject.AddComponent<LateSetActive>();
			LateSetActive.Dic.Add(go.name, lateSetActive);
		}
		lateSetActive.bActive = bActive;
		lateSetActive.time = time;
		lateSetActive.go = go;
	}


	private void Update()
	{
		if (this.time < 0.02f)
		{
			UtilFun.SetActive(this.go, this.bActive);
			UnityEngine.Object.Destroy(this);
		}
		this.time -= Time.deltaTime;
	}
}
