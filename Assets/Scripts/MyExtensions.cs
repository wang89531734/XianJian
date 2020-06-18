using System;
using System.IO;
//using Funfia.File;
using SoftStar.Pal6;
using UnityEngine;


public static class MyExtensions
{
    //	public static UnityEngine.Object MainAsset5(this AssetBundle bundle)
    //	{
    //		if (bundle == null)
    //		{
    //			return null;
    //		}
    //		if (bundle.mainAsset == null)
    //		{
    //			return bundle.LoadAsset(bundle.GetAllAssetNames()[0]);
    //		}
    //		return bundle.mainAsset;
    //	}

    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        T t = obj.GetComponent<T>();
        if (t == null)
        {
            t = obj.AddComponent<T>();
        }
        return t;
    }

    //	// Token: 0x06000617 RID: 1559 RVA: 0x0003A7B8 File Offset: 0x000389B8
    //	public static bool ExistFile(this string path)
    //	{
    //		return File.Exists(path);
    //	}

    //	// Token: 0x06000618 RID: 1560 RVA: 0x0003A7C0 File Offset: 0x000389C0
    //	public static void ChangeLayersRecursively(this Transform trans, string name)
    //	{
    //		trans.gameObject.layer = LayerMask.NameToLayer(name);
    //		foreach (object obj in trans)
    //		{
    //			Transform trans2 = (Transform)obj;
    //			trans2.ChangeLayersRecursively(name);
    //		}
    //	}

    //	// Token: 0x06000619 RID: 1561 RVA: 0x0003A83C File Offset: 0x00038A3C
    //	private static string RemovePathPrefix(string path)
    //	{
    //		string[] array = null;
    //		foreach (string text in MyExtensions.s_separators)
    //		{
    //			if (path.Contains(text))
    //			{
    //				array = new string[]
    //				{
    //					text
    //				};
    //				break;
    //			}
    //		}
    //		string text2;
    //		if (array == null)
    //		{
    //			text2 = path;
    //		}
    //		else
    //		{
    //			string[] array3 = path.Split(array, StringSplitOptions.None);
    //			text2 = array3[1];
    //		}
    //		if (path.Contains("Pal_Scenes"))
    //		{
    //			text2 = "EntityLayers/" + text2;
    //		}
    //		text2 = text2.Replace("：", "_");
    //		return text2.Replace("，", "_");
    //	}

    //	// Token: 0x0600061A RID: 1562 RVA: 0x0003A8EC File Offset: 0x00038AEC
    //	private static string RemovePathPrefixAndExtension(string path)
    //	{
    //		string text = MyExtensions.RemovePathPrefix(path);
    //		return text.Split(new char[]
    //		{
    //			'.'
    //		})[0];
    //	}

    //	// Token: 0x0600061B RID: 1563 RVA: 0x0003A918 File Offset: 0x00038B18
    //	public static string ToDataFolder(this string path)
    //	{
    //		if (path == string.Empty || path == null)
    //		{
    //			System.Console.WriteLine("Utilities.ToDataPath: ToDataPath path == null");
    //			return null;
    //		}
    //		if (path.StartsWith(FileLoader.DataPath))
    //		{
    //			System.Console.WriteLine("Utilities.ToDataPath: path is already a data path, path = " + path);
    //			return path;
    //		}
    //		string path2 = MyExtensions.RemovePathPrefix(path);
    //		return Path.Combine(FileLoader.DataPath, path2);
    //	}

    //	// Token: 0x0600061C RID: 1564 RVA: 0x0003A980 File Offset: 0x00038B80
    //	public static string ToDataPath(this string path)
    //	{
    //		return path.ToDataFolder() + ".unity3d";
    //	}

    //	// Token: 0x0600061D RID: 1565 RVA: 0x0003A994 File Offset: 0x00038B94
    //	public static string ToAssetBundleFolder(this string path)
    //	{
    //		if (path == string.Empty || path == null)
    //		{
    //			System.Console.WriteLine("Utilities.ToAssetBundlePath: ToAssetBundlePath path == null");
    //			return null;
    //		}
    //		if (path.StartsWith(FileLoader.AssetBundlePath))
    //		{
    //			System.Console.WriteLine("Utilities.ToAssetBundlePath: path is already a data path, path = " + path);
    //			return path;
    //		}
    //		string path2 = MyExtensions.RemovePathPrefixAndExtension(path);
    //		return Path.Combine(FileLoader.AssetBundlePath, path2);
    //	}

    //	// Token: 0x0600061E RID: 1566 RVA: 0x0003A9FC File Offset: 0x00038BFC
    //	public static string ToAssetBundlePath(this string path)
    //	{
    //		return path.ToAssetBundleFolder() + ".unity3d";
    //	}

    //	// Token: 0x0600061F RID: 1567 RVA: 0x0003AA10 File Offset: 0x00038C10
    //	public static string ToAnimationFolder(this string path)
    //	{
    //		if (path == string.Empty || path == null)
    //		{
    //			System.Console.WriteLine("Utilities.ToAnimationPath: ToAnimationPath path == null");
    //			return null;
    //		}
    //		if (path.StartsWith(FileLoader.AnimationPath))
    //		{
    //			System.Console.WriteLine("Utilities.ToAnimationPath: path is already a data path, path = " + path);
    //			return path;
    //		}
    //		string path2 = MyExtensions.RemovePathPrefixAndExtension(path);
    //		string fileName = Path.GetFileName(path2);
    //		string directoryName = Path.GetDirectoryName(path2);
    //		int startIndex = directoryName.LastIndexOf('/') + 1;
    //		string path3 = directoryName.Substring(startIndex);
    //		return Path.Combine(FileLoader.AnimationPath, Path.Combine(path3, fileName));
    //	}

    //	// Token: 0x06000620 RID: 1568 RVA: 0x0003AAA0 File Offset: 0x00038CA0
    //	public static string ToAnimationPath(this string path)
    //	{
    //		return path.ToAnimationFolder() + ".unity3d";
    //	}

    //	// Token: 0x06000621 RID: 1569 RVA: 0x0003AAB4 File Offset: 0x00038CB4
    //	public static string ToLanguageFolder(this string path)
    //	{
    //		if (path == string.Empty || path == null)
    //		{
    //			System.Console.WriteLine("Utilities.ToLanguagePath: ToLanguagePath path == null");
    //			return null;
    //		}
    //		if (path.StartsWith(FileLoader.LanguagePath))
    //		{
    //			System.Console.WriteLine("Utilities.ToLanguagePath: path is already a data path, path = " + path);
    //			return path;
    //		}
    //		string path2 = MyExtensions.RemovePathPrefixAndExtension(path);
    //		return Path.Combine(FileLoader.LanguagePath, path2);
    //	}

    //	// Token: 0x06000622 RID: 1570 RVA: 0x0003AB1C File Offset: 0x00038D1C
    //	public static string ToLanguagePath(this string path)
    //	{
    //		return path.ToLanguageFolder() + ".unity3d";
    //	}

    //	// Token: 0x06000623 RID: 1571 RVA: 0x0003AB30 File Offset: 0x00038D30
    //	public static PalBattleManager.PLAYER_AI_TACTICAL NextTactic(this PalBattleManager.PLAYER_AI_TACTICAL tactic)
    //	{
    //		int num = (int)((tactic + 1) % PalBattleManager.PLAYER_AI_TACTICAL.MAX_TACTICAL);
    //		return (PalBattleManager.PLAYER_AI_TACTICAL)num;
    //	}

    //	// Token: 0x0400062E RID: 1582
    //	private static string[] s_separators = new string[]
    //	{
    //		"SceneResources/",
    //		"CutsceneResources/",
    //		"SEObjects/LDF/",
    //		"Pal_Resources/Effects/",
    //		"Pal_Resources/Character/PaperDoll/",
    //		"AssetBundles/",
    //		"ResourcesTemp/",
    //		"Pal_Resources/",
    //		"Resources/"
    //	};
}
