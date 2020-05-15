using System;
using System.Collections;
//using Funfia.File;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;

public class ShowLoading : MonoBehaviour
{
    public static ShowLoading Instance;

    //    // Token: 0x04002E1C RID: 11804
    //    public static string LoadingPath = "/Resources/LoadingTextures";

    //    // Token: 0x04002E1D RID: 11805
    //    public static string prefabPath = "Assets/Resources/UI/LoadingText.prefab";

    //    // Token: 0x04002E1E RID: 11806
    //    private static string m_loadingTexturePath = string.Empty;

    //    // Token: 0x04002E1F RID: 11807
    //    private Texture blackImage;

    //    // Token: 0x04002E20 RID: 11808
    //    private GameObject m_loadingCamera;

    //    // Token: 0x04002E21 RID: 11809
    //    private Transform LoadingPlane;

    //    // Token: 0x04002E22 RID: 11810
    //    private bool m_readyToDestroy;

    //    // Token: 0x04002E23 RID: 11811
    //    [SerializeField]
    //    private UI_Bar m_loadBar;

    //    // Token: 0x04002E24 RID: 11812
    //    [SerializeField]
    //    private GameObject m_loadBarObject;

    //    // Token: 0x04002E25 RID: 11813
    //    public static float Interval = 0.56f;

    //    public static GameObject LoadingCamera
    //	{
    //		get
    //		{
    //			if (ShowLoading.Instance == null)
    //			{
    //				return null;
    //			}
    //			return ShowLoading.Instance.m_loadingCamera;
    //		}
    //	}

    public static ShowLoading Initialize(string ResourcesPath)
    {
        if (ShowLoading.Instance != null)
        {
            return ShowLoading.Instance;
        }
        //ShowLoading.m_loadingTexturePath = (ShowLoading.LoadingPath + "/" + ResourcesPath).ToAssetBundlePath();
        //Texture texture = FileLoader.LoadObjectFromFile<Texture>(ShowLoading.m_loadingTexturePath, false, true);
        //if (texture == null)
        //{
        //    Debug.LogError("Refresh Resource/LoadingTextures!");
        //    return null;
        //}
        //GameObject gameObject = FileLoader.LoadObjectFromFile<GameObject>(ShowLoading.prefabPath.ToAssetBundlePath(), true, true);
        //if (gameObject == null)
        //{
        //    Debug.LogError("Refresh Pal_Resources\\Data\\AssetBundles\\UI !");
        //    return null;
        //}
        //UnityEngine.Object.DontDestroyOnLoad(gameObject);
        //if (gameObject != null)
        //{
        //    ShowLoading.Instance = gameObject.GetComponent<ShowLoading>();
        //    ShowLoading.Instance.m_loadingCamera = gameObject;
        //    ShowLoading.Instance.LoadingPlane = gameObject.transform.FindChild("Quad");
        //    ShowLoading.Instance.LoadingPlane.GetComponent<Renderer>().material.mainTexture = texture;
        //    if ((float)Screen.width / (float)Screen.height > 1.6f)
        //    {
        //        ShowLoading.Instance.LoadingPlane.localScale *= (float)Screen.width / (float)Screen.height / 1.6f;
        //    }
        //    else
        //    {
        //        CameraViewport.Initialise(ShowLoading.Instance.m_loadingCamera.GetComponent<Camera>(), 16, 10, false);
        //    }
        //    EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(ShowLoading.Instance.OnEnd));
        //    EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(ShowLoading.Instance.OnEnd));
        //    if (UIManager.Instance != null)
        //    {
        //        UIManager.Instance.DoNotOpenMainMenu = true;
        //    }
        //}
        //CutAction_CameraFade.DestroyScreenColor();
        //PalMain.LoadingValue = 0f;
        //if (ShowLoading.Instance.m_loadBarObject != null)
        //{
        //    if (ShowLoading.Instance.m_loadBar != null)
        //    {
        //        ShowLoading.Instance.m_loadBar.setBarValue(0f);
        //    }
        //    ShowLoading.Instance.m_loadBarObject.SetActive(true);
        //}
        return ShowLoading.Instance;
    }

    //	public void setDepth(UnityEngine.Object obj, EventArgs args)
    //	{
    //		if (this.LoadingPlane == null)
    //		{
    //			return;
    //		}
    //		GameObject gameObject = obj as GameObject;
    //		float num = gameObject.transform.localPosition.z;
    //		if ((float)Screen.width / (float)Screen.height <= 1.65f)
    //		{
    //			num *= 1.1111112f;
    //			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, num);
    //		}
    //		num += 1f;
    //		if (this.LoadingPlane.localPosition.z == num)
    //		{
    //			return;
    //		}
    //		if (num != 0f)
    //		{
    //			this.LoadingPlane.localScale = this.LoadingPlane.localScale * num / this.LoadingPlane.transform.localPosition.z;
    //			this.LoadingPlane.localPosition = new Vector3(0f, 0f, num);
    //		}
    //	}

    //	// Token: 0x060032B0 RID: 12976 RVA: 0x00170EDC File Offset: 0x0016F0DC
    //	private void OnEnd()
    //	{
    //		EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(this.OnEnd));
    //		GameObject x = GameObject.Find("/ReturnMapRestoreCutscene");
    //		if (x == null)
    //		{
    //			this.Over();
    //		}
    //	}

    //	// Token: 0x060032B1 RID: 12977 RVA: 0x00170F28 File Offset: 0x0016F128
    //	public void Over()
    //	{
    //		if (ShowLoading.Instance.m_loadBar != null)
    //		{
    //			ShowLoading.Instance.m_loadBar.setBarValue(1f);
    //		}
    //		base.StartCoroutine(this.delayLoadingPlaneClear());
    //	}

    //	// Token: 0x060032B2 RID: 12978 RVA: 0x00170F6C File Offset: 0x0016F16C
    //	private IEnumerator delayLoadingPlaneClear()
    //	{
    //		yield return new WaitForSeconds(ShowLoading.Interval / 2f);
    //		this.loadingPlaneClear();
    //		yield break;
    //	}

    //	// Token: 0x060032B3 RID: 12979 RVA: 0x00170F88 File Offset: 0x0016F188
    //	private void loadingPlaneClear()
    //	{
    //		if (this.m_loadBarObject != null)
    //		{
    //			this.m_loadBarObject.SetActive(false);
    //		}
    //		if (this.blackImage == null)
    //		{
    //			this.blackImage = FileLoader.LoadObjectFromFile<Texture>((ShowLoading.LoadingPath + "/black").ToAssetBundlePath(), false, true);
    //		}
    //		if (this.LoadingPlane != null)
    //		{
    //			this.LoadingPlane.GetComponent<Renderer>().material.mainTexture = this.blackImage;
    //		}
    //		if (ShowLoading.m_loadingTexturePath != string.Empty)
    //		{
    //			FileLoader.UnloadAssetBundle(ShowLoading.m_loadingTexturePath);
    //			ShowLoading.m_loadingTexturePath = string.Empty;
    //		}
    //		base.Invoke("HideMoviePlan", ShowLoading.Interval / 2f);
    //	}

    //	private void HideMoviePlan()
    //	{
    //		ShowLoading.Instance = null;
    //		this.m_readyToDestroy = true;
    //	}

    //	private void Update()
    //	{
    //		if (this.m_readyToDestroy)
    //		{
    //			UnityEngine.Object.Destroy(base.gameObject);
    //		}
    //		if (this.m_loadBar != null)
    //		{
    //			this.m_loadBar.setBarValue(PalMain.LoadingValue);
    //		}
    //	}
}
