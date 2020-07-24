using System;
using UnityEngine;

public class ResourcesManager
{
	private static ResourcesManager instance;

    private ResourceLoader m_ActDataLoader;

    private ResourceLoader m_EffectLoader;

    private ResourceLoader m_GameNpcLoader;

    private ResourceLoader m_ImageLoader;

    private ResourceLoader m_ImageLoader_Tga;

    private ResourceLoader m_AtlasLoader;

    private ResourceLoader m_ItemLoader;

    private ResourceLoader m_MapEventLoader;

    private ResourceLoader m_MapSoundEventLoader;

    private ResourceLoader m_MaterialLoader;

    private ResourceLoader m_MusicLoader;

    private ResourceLoader m_VoiceLoader;

    private ResourceLoader m_StoryLoader;

    private ResourceLoader m_SoundLoader;

    private ResourceLoader m_OtherLoader;

    private ResourceLoader m_FightObjectLoader;

    private ResourceLoader m_CharacterRootLoader;

    private ResourceLoader m_CharacterModelLoader;

    private ResourceLoader m_AnimatorControllerLoader;

    private ResourceLoader m_FaceFxLoader;

    private ResourceLoader m_AnimationClipLoader;

    private ResourceLoader m_FaceAnimationClipLoader;

    public static ResourcesManager Instance
	{
		get
		{
			if (ResourcesManager.instance == null)
			{
				ResourcesManager.instance = new ResourcesManager();
			}
			return ResourcesManager.instance;
		}
	}

	public ResourcesManager()
	{
		if (ResourcesManager.instance == null)
		{
			ResourcesManager.instance = this;
		}
        this.m_FaceAnimationClipLoader = new ResourceLoader("/../Assetbundles/FaceAnimationClip/", "Assets/Assetbundles/FaceAnimationClip/", ".anim");
        this.m_AnimationClipLoader = new ResourceLoader("/../Assetbundles/AnimationClip/", "Assets/Assetbundles/AnimationClip/", ".anim");
        this.m_FaceFxLoader = new ResourceLoader("/../Assetbundles/FaceFx/", "Assets/Assetbundles/FaceFx/", ".anim");
        this.m_AnimatorControllerLoader = new ResourceLoader("/../Assetbundles/AnimatorController/", "Assets/Assetbundles/AnimatorController/", ".controller");
        this.m_CharacterModelLoader = new ResourceLoader("/../Assetbundles/CharacterModel/", "Assets/Assetbundles/CharacterModel/", ".prefab");
        this.m_CharacterRootLoader = new ResourceLoader("/../Assetbundles/CharacterRoot/", "Assets/Assetbundles/CharacterRoot/", ".prefab");
        this.m_ActDataLoader = new ResourceLoader("/../Assetbundles/ActData/", "Assets/Assetbundles/ActData/", ".asset");
        this.m_EffectLoader = new ResourceLoader("/../Assetbundles/Effect/", "Assets/Assetbundles/Effect/", ".prefab");
        this.m_ItemLoader = new ResourceLoader("/../Assetbundles/Item/", "Assets/Assetbundles/Item/", ".prefab");
        this.m_MaterialLoader = new ResourceLoader("/../Assetbundles/Material/", "Assets/Assetbundles/Material/", ".mat");
        this.m_OtherLoader = new ResourceLoader("/../Assetbundles/Other/", "Assets/Assetbundles/Other/", ".prefab");
        this.m_FightObjectLoader = new ResourceLoader("/../Assetbundles/Fight/", "Assets/Assetbundles/Fight/", ".prefab");
        this.m_MapEventLoader = new ResourceLoader("/../Assetbundles/MapEvent/", "Assets/Assetbundles/GameDesign/MapEvent/", ".prefab");
        this.m_GameNpcLoader = new ResourceLoader("/../Assetbundles/GameNpc/", "Assets/Assetbundles/GameDesign/GameNpc/", ".prefab");
        this.m_StoryLoader = new ResourceLoader("/../Assetbundles/Story/", "Assets/Assetbundles/GameDesign/Story/", ".prefab");
        this.m_ImageLoader = new ResourceLoader("/../Assetbundles/GUITexture/", "Assets/Assetbundles/GUI/GUITexture/", ".png");
        this.m_ImageLoader_Tga = new ResourceLoader("/../Assetbundles/GUITexture/", "Assets/Assetbundles/GUI/GUITexture/", ".tga");
        this.m_AtlasLoader = new ResourceLoader("/../Assetbundles/Atlas/", "Assets/Assetbundles/GUI/Atlas/", ".prefab");
        this.m_MapSoundEventLoader = new ResourceLoader("/../Assetbundles/MapSoundEvent/", "Assets/Assetbundles/Music/MapSoundEvent/", ".prefab");
        this.m_MusicLoader = new ResourceLoader("/../Assetbundles/Music/", "Assets/Assetbundles/Music/Music/", ".mp3");
        this.m_VoiceLoader = new ResourceLoader("/../Assetbundles/Voice/", "Assets/Assetbundles/Music/Voice/", ".ogg");
        this.m_SoundLoader = new ResourceLoader("/../Assetbundles/Sound/", "Assets/Assetbundles/Music/Sound/", ".ogg");
        //this.GetShaderList();
    }

	public void Clear()
	{
        this.m_ImageLoader.Clear();
        this.m_EffectLoader.Clear();
        this.m_AnimatorControllerLoader.Clear();
        this.m_CharacterModelLoader.Clear();
        this.m_ItemLoader.Clear();
        this.m_MaterialLoader.Clear();
        this.m_ActDataLoader.Clear();
        this.m_VoiceLoader.Clear();
        this.m_StoryLoader.Clear();
        this.m_SoundLoader.Clear();
        this.m_FightObjectLoader.Clear();
        this.m_FaceFxLoader.Clear();
        this.m_AnimationClipLoader.Clear();
        this.m_FaceAnimationClipLoader.Clear();
        this.m_OtherLoader.Clear();
        this.m_CharacterRootLoader.Clear();
        this.m_MusicLoader.Clear();
        this.m_GameNpcLoader.Clear();
        this.m_MapEventLoader.Clear();
        this.m_MapSoundEventLoader.Clear();
    }

	public void Clear_UI()
	{
        this.m_ItemLoader.Clear_UI();
        this.m_CharacterModelLoader.Clear_UI();
        this.m_AnimatorControllerLoader.Clear_UI();
    }

	public void Clear_Story()
	{
        this.m_EffectLoader.Clear_Story();
        this.m_AnimatorControllerLoader.Clear_Story();
        this.m_CharacterModelLoader.Clear_Story();
        this.m_ItemLoader.Clear_Story();
        this.m_MaterialLoader.Clear_Story();
        this.m_FaceAnimationClipLoader.Clear();
        this.m_AnimationClipLoader.Clear();
        this.m_FaceFxLoader.Clear();
        this.m_VoiceLoader.Clear();
        this.m_StoryLoader.Clear();
        this.m_MusicLoader.Clear();
    }

    public void Clear_Fight()
    {
        this.m_EffectLoader.Clear_Fight();
        this.m_AnimatorControllerLoader.Clear_Fight();
        this.m_CharacterModelLoader.Clear_Fight();
        this.m_ItemLoader.Clear_Fight();
        this.m_MaterialLoader.Clear_Fight();
        this.m_ActDataLoader.Clear();
        this.m_SoundLoader.Clear();
        this.m_FightObjectLoader.Clear();
    }

    private void GetShaderList()
    {
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.dataPath + "/../Assetbundles/Shader/ShaderList.unity3d");
    }

    public GameObject GetFightObject(string name)
    {
        UnityEngine.Object resourceObj = this.m_FightObjectLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetOther(string name)
    {
        UnityEngine.Object resourceObj = this.m_OtherLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetEffect(string name)
    {
        UnityEngine.Object resourceObj = this.m_EffectLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetEffect_Fight(string name)
    {
        UnityEngine.Object resourceObj_Fight = this.m_EffectLoader.GetResourceObj_Fight(name);
        if (resourceObj_Fight == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_Fight) as GameObject;
    }

    public GameObject GetEffect_Story(string name)
    {
        UnityEngine.Object resourceObj_Story = this.m_EffectLoader.GetResourceObj_Story(name);
        if (resourceObj_Story == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_Story) as GameObject;
    }

    //public ActData GetActData(string name)
    //{
    //    UnityEngine.Object resourceObj = this.m_ActDataLoader.GetResourceObj(name);
    //    if (resourceObj == null)
    //    {
    //        return null;
    //    }
    //    return UnityEngine.Object.Instantiate(resourceObj) as ActData;
    //}

    public AudioClip GetVoice(string name)
    {
        UnityEngine.Object resourceObj = this.m_VoiceLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AudioClip;
    }

    public AudioClip GetSound(string name)
    {
        UnityEngine.Object resourceObj = this.m_SoundLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AudioClip;
    }

    public AudioClip GetMusic(string name)
    {
        UnityEngine.Object resourceObj = this.m_MusicLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AudioClip;
    }

    public Texture2D GetImage(string name)
    {
        UnityEngine.Object resourceObj = this.m_ImageLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as Texture2D;
    }

    //public Texture2D GetTextImage(string name)
    //{
    //    if (Swd6Application.instance.m_NowLanguageType == ENUM_LanguageType.SimplifiedChinese)
    //    {
    //        name += "_gbk";
    //    }
    //    else if (Swd6Application.instance.m_NowLanguageType == ENUM_LanguageType.TraditionalChinese)
    //    {
    //        name += "_big5";
    //    }
    //    UnityEngine.Object resourceObj = this.m_ImageLoader.GetResourceObj(name);
    //    if (resourceObj == null)
    //    {
    //        return null;
    //    }
    //    return resourceObj as Texture2D;
    //}

    //public Texture2D GetTextImage_TGA(string name)
    //{
    //    if (Swd6Application.instance.m_NowLanguageType == ENUM_LanguageType.SimplifiedChinese)
    //    {
    //        name += "_gbk";
    //    }
    //    else if (Swd6Application.instance.m_NowLanguageType == ENUM_LanguageType.TraditionalChinese)
    //    {
    //        name += "_big5";
    //    }
    //    UnityEngine.Object resourceObj = this.m_ImageLoader_Tga.GetResourceObj(name);
    //    if (resourceObj == null)
    //    {
    //        return null;
    //    }
    //    return resourceObj as Texture2D;
    //}

    //public UIAtlas GetAtlas(string name)
    //{
    //    UnityEngine.Object resourceObj = this.m_AtlasLoader.GetResourceObj(name);
    //    if (resourceObj == null)
    //    {
    //        return null;
    //    }
    //    return (resourceObj as GameObject).GetComponent<UIAtlas>();
    //}

    public GameObject GetItem(string name)
    {
        UnityEngine.Object resourceObj = this.m_ItemLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetItem_UI(string name)
    {
        UnityEngine.Object resourceObj_UI = this.m_ItemLoader.GetResourceObj_UI(name);
        if (resourceObj_UI == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_UI) as GameObject;
    }

    public GameObject GetItem_Fight(string name)
    {
        UnityEngine.Object resourceObj_Fight = this.m_ItemLoader.GetResourceObj_Fight(name);
        if (resourceObj_Fight == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_Fight) as GameObject;
    }

    public GameObject GetItem_Story(string name)
    {
        UnityEngine.Object resourceObj_Story = this.m_ItemLoader.GetResourceObj_Story(name);
        if (resourceObj_Story == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_Story) as GameObject;
    }

    public GameObject GetMapEvent(string name)
    {
        UnityEngine.Object resourceObj = this.m_MapEventLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetGameNpc(string name)
    {
        UnityEngine.Object resourceObj = this.m_GameNpcLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetStory(string name)
    {
        UnityEngine.Object resourceObj = this.m_StoryLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetMapSoundEvent(string name)
    {
        UnityEngine.Object resourceObj = this.m_MapSoundEventLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public Material GetMaterial(string name)
    {
        UnityEngine.Object resourceObj = this.m_MaterialLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as Material;
    }

    public Material GetMaterial_Fight(string name)
    {
        UnityEngine.Object resourceObj_Fight = this.m_MaterialLoader.GetResourceObj_Fight(name);
        if (resourceObj_Fight == null)
        {
            return null;
        }
        return resourceObj_Fight as Material;
    }

    public Material GetMaterial_Story(string name)
    {
        UnityEngine.Object resourceObj_Story = this.m_MaterialLoader.GetResourceObj_Story(name);
        if (resourceObj_Story == null)
        {
            return null;
        }
        return resourceObj_Story as Material;
    }

    public GameObject GetCharacterRoot(string name)
    {
        UnityEngine.Object resourceObj = this.m_CharacterRootLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj) as GameObject;
    }

    public GameObject GetCharacterModel(string name)
    {
        UnityEngine.Object resourceObj = this.m_CharacterModelLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        GameObject gameObject = UnityEngine.Object.Instantiate(resourceObj) as GameObject;
        TransformTool.CreatePoint09(gameObject);
        return gameObject;
    }

    public GameObject GetCharacterModel_UI(string name)
    {
        UnityEngine.Object resourceObj_UI = this.m_CharacterModelLoader.GetResourceObj_UI(name);
        if (resourceObj_UI == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate(resourceObj_UI) as GameObject;
    }

    //public GameObject GetCharacterModel_Fight(string name)
    //{
    //    UnityEngine.Object resourceObj_Fight = this.m_CharacterModelLoader.GetResourceObj_Fight(name);
    //    if (resourceObj_Fight == null)
    //    {
    //        return null;
    //    }
    //    GameObject gameObject = UnityEngine.Object.Instantiate(resourceObj_Fight) as GameObject;
    //    TransformTool.CreatePoint09(gameObject);
    //    return gameObject;
    //}

    //public GameObject GetCharacterModel_Story(string name)
    //{
    //    UnityEngine.Object resourceObj_Story = this.m_CharacterModelLoader.GetResourceObj_Story(name);
    //    if (resourceObj_Story == null)
    //    {
    //        return null;
    //    }
    //    GameObject gameObject = UnityEngine.Object.Instantiate(resourceObj_Story) as GameObject;
    //    TransformTool.CreatePoint09(gameObject);
    //    return gameObject;
    //}

    public RuntimeAnimatorController GetAnimatorController(string name)
    {
        UnityEngine.Object resourceObj = this.m_AnimatorControllerLoader.GetResourceObj(name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as RuntimeAnimatorController;
    }

    public RuntimeAnimatorController GetAnimatorController_UI(string name)
    {
        UnityEngine.Object resourceObj_UI = this.m_AnimatorControllerLoader.GetResourceObj_UI(name);
        if (resourceObj_UI == null)
        {
            return null;
        }
        return resourceObj_UI as RuntimeAnimatorController;
    }

    public RuntimeAnimatorController GetAnimatorController_Fight(string name)
    {
        UnityEngine.Object resourceObj_Fight = this.m_AnimatorControllerLoader.GetResourceObj_Fight(name);
        if (resourceObj_Fight == null)
        {
            return null;
        }
        return resourceObj_Fight as RuntimeAnimatorController;
    }

    public RuntimeAnimatorController GetAnimatorController_Story(string name)
    {
        UnityEngine.Object resourceObj_Story = this.m_AnimatorControllerLoader.GetResourceObj_Story(name);
        if (resourceObj_Story == null)
        {
            return null;
        }
        return resourceObj_Story as RuntimeAnimatorController;
    }

    public AnimationClip GetFaceFxClip(string folderName, string name)
    {
        UnityEngine.Object resourceObj = this.m_FaceFxLoader.GetResourceObj(folderName + "/" + name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AnimationClip;
    }

    public AnimationClip GetFaceAnimationClip(string folderName, string name)
    {
        UnityEngine.Object resourceObj = this.m_FaceAnimationClipLoader.GetResourceObj(folderName + "/" + name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AnimationClip;
    }

    public AnimationClip GetAnimationClip(string folderName, string name)
    {
        UnityEngine.Object resourceObj = this.m_AnimationClipLoader.GetResourceObj(folderName + "/" + name);
        if (resourceObj == null)
        {
            return null;
        }
        return resourceObj as AnimationClip;
    }
}
