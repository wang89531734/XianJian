using System;
using System.IO;
using SoftStar.Pal6;
using UnityEngine;


public class SavePrefabTarget : SaveTarget
{
    public string PrefabPath;

    public int ID
	{
		get
		{
			PalNPC component = base.GetComponent<PalNPC>();
			if (component != null)
			{
				return component.Data.CharacterID;
			}
			return -1;
		}
	}

	// Token: 0x060032A3 RID: 12963 RVA: 0x0016FA08 File Offset: 0x0016DC08
	private void Start()
	{
		this.GetPrefabPath();
	}

	// Token: 0x060032A4 RID: 12964 RVA: 0x0016FA14 File Offset: 0x0016DC14
	private string GetPrefabPath()
	{
		if (string.IsNullOrEmpty(this.PrefabPath))
		{
			string text = base.gameObject.name;
			if (text.Contains("(Clone)"))
			{
				int length = text.IndexOf("(Clone)");
				text = text.Substring(0, length);
			}
			this.PrefabPath = "Template/Character/" + text;
		}
		return this.PrefabPath;
	}

	// Token: 0x060032A5 RID: 12965 RVA: 0x0016FA7C File Offset: 0x0016DC7C
	public override bool Save(BinaryWriter writer)
	{
		writer.Write(this.ID);
		writer.Write(this.GetPrefabPath());
		this.SaveTranData(writer);
		this.SaveTargetData(writer);
		return true;
	}

	// Token: 0x060032A6 RID: 12966 RVA: 0x0016FAB0 File Offset: 0x0016DCB0
	public static GameObject Load(BinaryReader reader, Transform parent)
	{
		int num = reader.ReadInt32();
		string prefabPath = reader.ReadString();
		GameObject gameObject = null;
		if (num >= 0)
		{
			gameObject = PlayersManager.FindMainChar(num, true);
		}
		if (gameObject == null)
		{
			Debug.LogError("PlayersManager.FindMainChar not found, tempID = " + num);
		}
		SavePrefabTarget savePrefabTarget = gameObject.GetComponent<SavePrefabTarget>();
		if (savePrefabTarget == null)
		{
			savePrefabTarget = gameObject.AddComponent<SavePrefabTarget>();
		}
		savePrefabTarget.PrefabPath = prefabPath;
		gameObject.transform.parent = parent;
		savePrefabTarget.Load(reader);
		return gameObject;
	}
}
