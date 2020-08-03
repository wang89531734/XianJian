using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class M_StoryBase : MonoBehaviour
{
    private const string CHARACTER_TAG = "StoryCharacter";

    private const string MONSTER_TAG = "StoryMonster";

    private const string NPC_TAG = "StoryNPC";

    private const string CAMERA_TAG = "StoryCamera";

    private const string REFERENCEPOINT_TAG = "StoryPoint";

    private const string SCENEOBJECT_TAG = "StoryObject";

    public Dictionary<string, GameObject> m_CharacterNameDictionary;

    public Dictionary<string, GameObject> m_ReferencePointNameDictionary;

    public Dictionary<string, GameObject> m_CameraNameDictionary;

    public Dictionary<string, GameObject> m_SceneObjectNameDictionary;

    public Dictionary<string, List<GameObject>> m_CharacterHairs;

    public Dictionary<int, GameObject> m_AudioSources;

    [HideInInspector]
    public GameObject m_CurrentCamera;

    protected List<StoryEvent> m_StoryEvents;

    protected StoryEvent m_CurrentStoryEvent;

    protected int m_StoryEventIndex;

    protected bool m_IsPause;

    public bool m_WaitAnyKey = true;

    private List<AudioSource> m_PauseAudio = new List<AudioSource>();

    protected abstract void InitStories();

    public void Initial()
    {
        //if (Swd6Application.instance.GamePause)
        //{
        //	this.StoryContinue();
        //}
        this.m_AudioSources = new Dictionary<int, GameObject>();
        this.m_StoryEvents = new List<StoryEvent>();
        this.m_StoryEventIndex = 0;
        //this.InitCharacterNameDictionary();
        //this.InitReferencePointNameDictionary();
        //this.InitCameraNameDictionary();
        //this.InitSceneObjectNameDictionary();
        //this.HideCameras();
        //this.HideCharacters();
        //this.HideStoryObject();
        //this.InitStories();
        //this.ProcessNextEvent();
    }

    //	public void ProcessLastEvent()
    //	{
    //		base.StopAllCoroutines();
    //		this.m_CurrentStoryEvent = null;
    //		this.m_StoryEventIndex = this.m_StoryEvents.Count - 1;
    //		this.m_CurrentStoryEvent = this.m_StoryEvents[this.m_StoryEventIndex];
    //		this.m_StoryEventIndex++;
    //		this.m_CurrentStoryEvent.SetStoryBase(this);
    //		this.m_CurrentStoryEvent.Begin();
    //	}

    //	public IEnumerator DelayProcessNextEvent()
    //	{
    //		yield return 1;
    //		this.ProcessNextEvent();
    //		yield break;
    //	}

    public void ProcessNextEvent()
    {
        this.m_CurrentStoryEvent = null;
        if (this.m_IsPause)
        {
            return;
        }
        if (this.m_StoryEventIndex >= this.m_StoryEvents.Count)
        {
            return;
        }
        this.m_CurrentStoryEvent = this.m_StoryEvents[this.m_StoryEventIndex];
        this.m_StoryEventIndex++;
        this.m_CurrentStoryEvent.SetStoryBase(this);
        this.m_CurrentStoryEvent.Begin();
        if (!this.m_CurrentStoryEvent.IsWaitting)
        {
            this.ProcessNextEvent();
        }
    }

    //	protected void Update()
    //	{
    //		if (Swd6Application.instance.m_StorySystem.IsReviewStory() && Input.GetKeyDown(KeyCode.Escape) && this.m_StoryEventIndex < this.m_StoryEvents.Count)
    //		{
    //			this.ProcessLastEvent();
    //			return;
    //		}
    //		if ((Input.GetKeyDown(KeyCode.Space) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.START)) && Swd6Application.instance.GamePause)
    //		{
    //			this.StoryContinue();
    //			return;
    //		}
    //		if ((Input.GetKeyDown(KeyCode.Space) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.START)) && !Swd6Application.instance.GamePause && !UI_GameMainMenu.Instance.IsVisible() && !(Swd6Application.instance.gameStateService.getCurrentState() is FightState))
    //		{
    //			if (UI_StoryMovie.Instance.IsMoviePlaying())
    //			{
    //				this.StoryPause();
    //				return;
    //			}
    //			if (!Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting().m_bEnableTextFrameInStory || !Swd6Application.instance.m_NormalSettingSystem.GetNormalSetting().m_bEnableTextInStory)
    //			{
    //				this.StoryPause();
    //				return;
    //			}
    //		}
    //		if (Swd6Application.instance.GamePause)
    //		{
    //			return;
    //		}
    //		if (this.m_CurrentStoryEvent == null)
    //		{
    //			return;
    //		}
    //		this.m_CurrentStoryEvent.Update();
    //	}

    //	private void StoryPause()
    //	{
    //		UI_Pause.Instance.Show();
    //		Time.timeScale = 0f;
    //		Swd6Application.instance.GamePause = true;
    //		this.PauseAudio();
    //		this.PauseMovie();
    //	}

    //	private void PauseAudio()
    //	{
    //		AudioSource[] array = UnityEngine.Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    //		if (array == null)
    //		{
    //			return;
    //		}
    //		if (array.Length == 0)
    //		{
    //			return;
    //		}
    //		this.m_PauseAudio.Clear();
    //		for (int i = 0; i < array.Length; i++)
    //		{
    //			if (array[i].isPlaying)
    //			{
    //				array[i].Pause();
    //				this.m_PauseAudio.Add(array[i]);
    //			}
    //		}
    //	}

    //	private void PauseMovie()
    //	{
    //		if (UI_StoryMovie.Instance.IsMoviePlaying())
    //		{
    //			UI_StoryMovie.Instance.PauseMovie();
    //		}
    //	}

    //	private void StoryContinue()
    //	{
    //		Time.timeScale = 1f;
    //		Swd6Application.instance.GamePause = false;
    //		if (UI_StoryMovie.Instance.IsMoviePause())
    //		{
    //			UI_StoryMovie.Instance.ContinueMovie();
    //		}
    //		UI_Pause.Instance.Hide();
    //		if (this.m_PauseAudio.Count == 0)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < this.m_PauseAudio.Count; i++)
    //		{
    //			if (!(this.m_PauseAudio[i] == null))
    //			{
    //				this.m_PauseAudio[i].Play();
    //			}
    //		}
    //		this.m_PauseAudio.Clear();
    //	}

    //	public void SwitchWaitAnyKey(bool wait)
    //	{
    //		this.m_WaitAnyKey = wait;
    //	}

    //	protected void ReplaceModels(string tag)
    //	{
    //		GameObject[] array = GameObject.FindGameObjectsWithTag(tag);
    //		GameObject[] array2 = array;
    //		for (int i = 0; i < array2.Length; i++)
    //		{
    //			GameObject gameObject = array2[i];
    //			string[] array3 = gameObject.name.Split(new char[]
    //			{
    //				'_'
    //			});
    //			int num = int.Parse(array3[1]);
    //			S_NpcData data = GameDataDB.NpcDB.GetData(num);
    //			if (data == null)
    //			{
    //				Debug.LogWarning("npcData == null " + num);
    //			}
    //			else
    //			{
    //				GameObject gameObject2 = null;
    //				if (tag == "StoryCharacter")
    //				{
    //					gameObject2 = PlayerGenerator.CreatePlayerGameObject(data.PrefName);
    //				}
    //				else if (tag == "StoryMonster")
    //				{
    //					gameObject2 = MonsterGenerator.CreateMonsterGameObject(data.PrefName);
    //				}
    //				else if (tag == "StoryNPC")
    //				{
    //					gameObject2 = NpcGenerator.CreateNpcGameObject(num);
    //				}
    //				if (gameObject2 == null)
    //				{
    //					Debug.LogWarning("newCharacter == null");
    //				}
    //				else
    //				{
    //					if (tag == "StoryCharacter" && num <= 5)
    //					{
    //						C_RoleDataEx roleData = Swd6Application.instance.m_GameDataSystem.GetRoleData(num);
    //						if (roleData != null)
    //						{
    //							ItemData equipItemData = roleData.GetEquipItemData(ENUM_EquipPosition.CosCloth);
    //							if (equipItemData != null)
    //							{
    //								Swd6Application.instance.m_GameObjSystem.SetMaterail(equipItemData.ID, Enum_AvaterType.Show, gameObject2);
    //							}
    //						}
    //					}
    //					gameObject2.transform.position = gameObject.transform.position + new Vector3(0f, 0.1f, 0f);
    //					gameObject2.transform.rotation = gameObject.transform.rotation;
    //					gameObject2.transform.parent = gameObject.transform.parent;
    //					gameObject2.name = gameObject.name;
    //					gameObject2.AddComponent<StoryCharacterController>();
    //					BendingSegment bendingSegment = new BendingSegment();
    //					bendingSegment.firstTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //					bendingSegment.lastTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //					if (bendingSegment.firstTransform != null)
    //					{
    //						M_StoryHeadLookController m_StoryHeadLookController = gameObject2.AddComponent<M_StoryHeadLookController>();
    //						m_StoryHeadLookController.segments = new BendingSegment[1];
    //						m_StoryHeadLookController.segments[0] = bendingSegment;
    //						m_StoryHeadLookController.nonAffectedJoints = new NonAffectedJoints[0];
    //						m_StoryHeadLookController.enabled = false;
    //					}
    //					gameObject2.AddComponent<ExpressionController_Down>();
    //					gameObject2.AddComponent<ExpressionController_Up>();
    //					if (tag == "StoryCharacter" || tag == "StoryNPC")
    //					{
    //						List<GameObject> list = new List<GameObject>();
    //						SkinnedMeshRenderer[] componentsInChildren = gameObject2.GetComponentsInChildren<SkinnedMeshRenderer>();
    //						SkinnedMeshRenderer[] array4 = componentsInChildren;
    //						for (int j = 0; j < array4.Length; j++)
    //						{
    //							SkinnedMeshRenderer skinnedMeshRenderer = array4[j];
    //							if (skinnedMeshRenderer.name.Contains("hair"))
    //							{
    //								list.Add(skinnedMeshRenderer.gameObject);
    //							}
    //						}
    //						if (!this.m_CharacterHairs.ContainsKey(gameObject2.name))
    //						{
    //							this.m_CharacterHairs.Add(gameObject2.name, list);
    //						}
    //					}
    //					this.m_CharacterNameDictionary.Add(gameObject2.name, gameObject2);
    //					UnityEngine.Object.Destroy(gameObject);
    //				}
    //			}
    //		}
    //	}

    //	protected void ReplaceObjects(string tag)
    //	{
    //		GameObject[] array = GameObject.FindGameObjectsWithTag(tag);
    //		GameObject[] array2 = array;
    //		for (int i = 0; i < array2.Length; i++)
    //		{
    //			GameObject gameObject = array2[i];
    //			string[] array3 = gameObject.name.Split(new char[]
    //			{
    //				'_'
    //			});
    //			if (array3 != null && array3.Length != 0)
    //			{
    //				if (array3[0] != "Role")
    //				{
    //					this.m_SceneObjectNameDictionary.Add(gameObject.name, gameObject);
    //				}
    //				else
    //				{
    //					int num = int.Parse(array3[1]);
    //					if (GameDataDB.NpcDB.GetData(num) == null)
    //					{
    //						Debug.LogWarning("npcData == null " + num);
    //					}
    //					else
    //					{
    //						GameObject gameObject2 = NpcGenerator.CreateNpcGameObject(num);
    //						if (gameObject2 == null)
    //						{
    //							Debug.LogWarning("newCharacter == null");
    //						}
    //						else
    //						{
    //							gameObject2.transform.position = gameObject.transform.position;
    //							gameObject2.transform.rotation = gameObject.transform.rotation;
    //							gameObject2.transform.parent = gameObject.transform.parent;
    //							gameObject2.name = gameObject.name;
    //							BendingSegment bendingSegment = new BendingSegment();
    //							bendingSegment.firstTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //							bendingSegment.lastTransform = TransformTool.SearchHierarchyForBone(gameObject2.transform, "Bip001 Head");
    //							if (bendingSegment.firstTransform != null)
    //							{
    //								M_StoryHeadLookController m_StoryHeadLookController = gameObject2.AddComponent<M_StoryHeadLookController>();
    //								m_StoryHeadLookController.segments = new BendingSegment[1];
    //								m_StoryHeadLookController.segments[0] = bendingSegment;
    //								m_StoryHeadLookController.nonAffectedJoints = new NonAffectedJoints[0];
    //								m_StoryHeadLookController.enabled = false;
    //							}
    //							gameObject2.AddComponent<ExpressionController_Down>();
    //							gameObject2.AddComponent<ExpressionController_Up>();
    //							this.m_SceneObjectNameDictionary.Add(gameObject2.name, gameObject2);
    //							UnityEngine.Object.Destroy(gameObject);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	protected void InitCharacterNameDictionary()
    //	{
    //		this.m_CharacterNameDictionary = new Dictionary<string, GameObject>();
    //		this.m_CharacterHairs = new Dictionary<string, List<GameObject>>();
    //		this.ReplaceModels("StoryCharacter");
    //		this.ReplaceModels("StoryMonster");
    //		this.ReplaceModels("StoryNPC");
    //	}

    //	protected void InitReferencePointNameDictionary()
    //	{
    //		this.m_ReferencePointNameDictionary = new Dictionary<string, GameObject>();
    //		GameObject[] array = GameObject.FindGameObjectsWithTag("StoryPoint");
    //		GameObject[] array2 = array;
    //		for (int i = 0; i < array2.Length; i++)
    //		{
    //			GameObject gameObject = array2[i];
    //			this.m_ReferencePointNameDictionary.Add(gameObject.name, gameObject);
    //		}
    //	}

    //	protected void InitCameraNameDictionary()
    //	{
    //		this.m_CameraNameDictionary = new Dictionary<string, GameObject>();
    //		GameObject[] array = GameObject.FindGameObjectsWithTag("StoryCamera");
    //		int num = 8388608;
    //		GameObject[] array2 = array;
    //		for (int i = 0; i < array2.Length; i++)
    //		{
    //			GameObject gameObject = array2[i];
    //			gameObject.camera.cullingMask = ~num;
    //			gameObject.camera.depth = 2f;
    //			this.m_CameraNameDictionary.Add(gameObject.name, gameObject);
    //		}
    //	}

    //	protected void InitSceneObjectNameDictionary()
    //	{
    //		this.m_SceneObjectNameDictionary = new Dictionary<string, GameObject>();
    //		this.ReplaceObjects("StoryObject");
    //	}

    //	protected void HideCameras()
    //	{
    //		if (this.m_CameraNameDictionary == null)
    //		{
    //			return;
    //		}
    //		foreach (GameObject current in this.m_CameraNameDictionary.Values)
    //		{
    //			current.camera.enabled = false;
    //			current.GetComponent<AudioListener>().enabled = false;
    //		}
    //	}

    //	protected void HideCharacters()
    //	{
    //		if (this.m_CharacterNameDictionary == null)
    //		{
    //			return;
    //		}
    //		foreach (GameObject current in this.m_CharacterNameDictionary.Values)
    //		{
    //			current.SetActiveRecursively(false);
    //		}
    //	}

    //	public void HideStoryObject()
    //	{
    //		if (this.m_SceneObjectNameDictionary == null)
    //		{
    //			return;
    //		}
    //		foreach (GameObject current in this.m_SceneObjectNameDictionary.Values)
    //		{
    //			current.SetActiveRecursively(false);
    //		}
    //	}

    //	public void HideAllStoryObject()
    //	{
    //		foreach (GameObject current in this.m_CharacterNameDictionary.Values)
    //		{
    //			current.SetActiveRecursively(false);
    //		}
    //		foreach (GameObject current2 in this.m_ReferencePointNameDictionary.Values)
    //		{
    //			current2.SetActiveRecursively(false);
    //		}
    //		foreach (GameObject current3 in this.m_CameraNameDictionary.Values)
    //		{
    //			current3.SetActiveRecursively(false);
    //		}
    //		foreach (GameObject current4 in this.m_SceneObjectNameDictionary.Values)
    //		{
    //			current4.SetActiveRecursively(false);
    //		}
    //	}

    //	public void SetStoryPause(bool isPause)
    //	{
    //		this.m_IsPause = isPause;
    //	}

    //	public void DoFade(Camera cam1, Camera cam2, float fadeTime)
    //	{
    //		base.StartCoroutine(M_ScreenWipes.use.CrossFadePro(cam1, cam2, fadeTime));
    //		this.m_CurrentCamera = cam2.gameObject;
    //	}

    //	protected void Fight(int battleGroupID)
    //	{
    //		this.m_StoryEvents.Add(new Event_Fight(battleGroupID));
    //	}

    //	protected void PlayStory(int mapID, string storyName)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayStory(mapID, storyName));
    //	}

    //	protected void BackToExplore()
    //	{
    //		this.m_StoryEvents.Add(new Event_BackToExplore());
    //	}

    //	protected void BackToExplore(float x, float y, float z, float degree)
    //	{
    //		this.m_StoryEvents.Add(new Event_BackToExploreChangePos(x, y, z, degree));
    //	}

    //	protected void ChangeMapToExplore(int mapID, float x, float y, float z, float degree)
    //	{
    //		this.m_StoryEvents.Add(new Event_ChangeMapToExplore(mapID, x, y, z, degree));
    //	}

    //	protected void ReplaceMouthTimer(int roleID, int OSID)
    //	{
    //		string key = "Role_" + roleID.ToString();
    //		if (!this.m_CharacterNameDictionary.ContainsKey(key))
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_ReplaceMouthTimer(this.m_CharacterNameDictionary[key], OSID));
    //	}

    //	protected void Play_OS(int osID, float volume)
    //	{
    //		if (osID <= 0)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_PlayOS(osID, volume));
    //	}

    //	protected void Wait_OS()
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitOS());
    //	}

    //	protected void Wait_OS_Anykey()
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitOSAnykey());
    //	}

    //	protected void Stop_OS()
    //	{
    //		this.m_StoryEvents.Add(new Event_StopOS());
    //	}

    //	protected void ShowImage(string imageName, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowImage(imageName, fadeTime));
    //	}

    //	protected void HideImage(float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_HideImage(fadeTime));
    //	}

    //	protected void CancelAutoSubtitle()
    //	{
    //		this.m_StoryEvents.Add(new Event_CancelAutoSubtitle());
    //	}

    //	protected void ShowFightList(int roleID1, int roleID2, int roleID3)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowFightList(roleID1, roleID2, roleID3));
    //	}

    //	protected void WaitFightListClose()
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitFightListClose());
    //	}

    //	protected void ShowSystemMsg(int contentID)
    //	{
    //		string content = "";
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data != null)
    //		{
    //			content = data.Str;
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowSystemMsg(content));
    //	}

    //	protected void ShowSystemMsg(string content)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowSystemMsg(content));
    //	}

    //	protected void PLay_Movie(int movieID)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayMovie(movieID));
    //		this.Sleep(0.5f);
    //	}

    //	protected void Stop_Movie()
    //	{
    //		this.m_StoryEvents.Add(new Event_StopMovie());
    //	}

    //	protected void WaitMovieStop()
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitMovieStop());
    //	}

    //	protected void ShowMovieSubtitle(int contentID, float delayTime)
    //	{
    //		string content = "";
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data != null)
    //		{
    //			content = data.Str;
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowMovieSubtitle(content, delayTime));
    //	}

    //	protected void ShowMovieSubtitle(string content, float delayTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowMovieSubtitle(content, delayTime));
    //	}

    //	protected void HideMovieSubtitle()
    //	{
    //		this.m_StoryEvents.Add(new Event_HideMovieSubtitle());
    //	}

    //	protected void ShowSubtitleMacro(int roleID, string content)
    //	{
    //		string name = "";
    //		S_NpcData data = GameDataDB.NpcDB.GetData(Mathf.Abs(roleID));
    //		if (data != null)
    //		{
    //			if (roleID > 0)
    //			{
    //				name = data.Name;
    //			}
    //			else
    //			{
    //				name = data.Title;
    //			}
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowSubtitle(name, content));
    //		this.Stop_OS();
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void ShowFullScreenSubtitleMacro(string content)
    //	{
    //		this.ShowFullScreenSubtitle(content);
    //		this.Stop_OS();
    //		this.WaitAnyKey();
    //		this.HideFullScreenSubtitle();
    //	}

    //	protected void ShowFullScreenSubtitleMacro(string content, int pos, int alignment)
    //	{
    //		this.ShowFullScreenSubtitle(content, pos, alignment);
    //		this.Stop_OS();
    //		this.WaitAnyKey();
    //		this.HideFullScreenSubtitle();
    //	}

    //	protected void ShowSubtitleMacro(int roleID, int contentID)
    //	{
    //		string content = "";
    //		string name = "";
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data != null)
    //		{
    //			content = data.Str;
    //		}
    //		S_NpcData data2 = GameDataDB.NpcDB.GetData(Mathf.Abs(roleID));
    //		if (data2 != null)
    //		{
    //			if (roleID > 0)
    //			{
    //				name = data2.Name;
    //			}
    //			else
    //			{
    //				name = data2.Title;
    //			}
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowSubtitle(name, content));
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //		this.ReplaceMouthTimer(Mathf.Abs(roleID), data.OSID);
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void ShowFullScreenSubtitleMacro(int contentID)
    //	{
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		string str = data.Str;
    //		this.ShowFullScreenSubtitle(str);
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //		this.WaitAnyKey();
    //		this.HideFullScreenSubtitle();
    //	}

    //	protected void ShowFullScreenSubtitleMacro(int contentID, int pos, int alignment)
    //	{
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		string str = data.Str;
    //		this.ShowFullScreenSubtitle(str, pos, alignment);
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //		this.WaitAnyKey();
    //		this.HideFullScreenSubtitle();
    //	}

    //	protected void ShowSubtitle(int roleID, string content)
    //	{
    //		string name = "";
    //		S_NpcData data = GameDataDB.NpcDB.GetData(Mathf.Abs(roleID));
    //		if (data != null)
    //		{
    //			if (roleID > 0)
    //			{
    //				name = data.Name;
    //			}
    //			else
    //			{
    //				name = data.Title;
    //			}
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowSubtitle(name, content));
    //		this.Stop_OS();
    //	}

    //	protected void ShowSubtitle(int roleID, int contentID)
    //	{
    //		string content = "";
    //		string name = "";
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data != null)
    //		{
    //			content = data.Str;
    //		}
    //		S_NpcData data2 = GameDataDB.NpcDB.GetData(Mathf.Abs(roleID));
    //		if (data2 != null)
    //		{
    //			if (roleID > 0)
    //			{
    //				name = data2.Name;
    //			}
    //			else
    //			{
    //				name = data2.Title;
    //			}
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowSubtitle(name, content));
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //		this.ReplaceMouthTimer(Mathf.Abs(roleID), data.OSID);
    //	}

    //	protected void HideSubtitle()
    //	{
    //		this.m_StoryEvents.Add(new Event_HideSubtitle());
    //		this.Stop_OS();
    //	}

    //	protected void ShowFullScreenSubtitle(string content)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowFullScreenSubtitle(content));
    //	}

    //	protected void ShowFullScreenSubtitle(string content, int pos, int alignment)
    //	{
    //		this.m_StoryEvents.Add(new Event_ShowFullScreenSubtitle(content, pos, alignment));
    //	}

    //	protected void ShowFullScreenSubtitle(int contentID)
    //	{
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowFullScreenSubtitle(data.Str));
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //	}

    //	protected void ShowFullScreenSubtitle(int contentID, int pos, int alignment)
    //	{
    //		S_TalkString data = GameDataDB.TalkStringDB.GetData(contentID);
    //		if (data == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_ShowFullScreenSubtitle(data.Str, pos, alignment));
    //		this.Stop_OS();
    //		this.Play_OS(data.OSID, 1f);
    //	}

    //	protected void HideFullScreenSubtitle()
    //	{
    //		this.m_StoryEvents.Add(new Event_HideFullScreenSubtitle());
    //		this.Stop_OS();
    //	}

    //	protected void SetSubtitleSpeed(float speed)
    //	{
    //		this.m_StoryEvents.Add(new Event_SetSubtitleSpeed(speed));
    //	}

    //	protected void SetSubtitleControlInput(bool control)
    //	{
    //		this.m_StoryEvents.Add(new Event_SetSubtitleControlInput(control));
    //	}

    //	protected void WaitAnyKey()
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitAnyKey());
    //	}

    //	protected void BackWaitAnyKey()
    //	{
    //		this.m_StoryEvents.Add(new Event_BackWaitAnyKey());
    //	}

    //	protected void Sleep(float delayTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_Sleep(delayTime));
    //	}

    //	protected void CameraCrossFade(string cameraName1, string cameraName2, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraCrossFade(this.m_CameraNameDictionary[cameraName1].camera, this.m_CameraNameDictionary[cameraName2].camera, fadeTime));
    //	}

    //	protected void CameraEnable(string cameraName)
    //	{
    //		this.m_StoryEvents.Add(new Event_EnableCamera(this.m_CameraNameDictionary[cameraName]));
    //	}

    //	protected void CameraShake(string cameraName, float x, float y, float z, float shakeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraShake(this.m_CameraNameDictionary[cameraName], new Vector3(x, y, z), shakeTime));
    //	}

    //	protected void CameraDetach(string cameraName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraDetach(this.m_CameraNameDictionary[cameraName]));
    //	}

    //	protected void CameraFadeTo(float amount, float time)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraFadeTo(amount, time));
    //	}

    //	protected void TeleportCamera(string cameraName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_TeleportCamera(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void RotateCameraRight(string cameraName, float degree, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_RotateCamera(this.m_CameraNameDictionary[cameraName], 0f, degree, moveTime));
    //	}

    //	protected void RotateCameraLeft(string cameraName, float degree, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_RotateCamera(this.m_CameraNameDictionary[cameraName], 0f, -degree, moveTime));
    //	}

    //	protected void RotateCameraUp(string cameraName, float degree, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_RotateCamera(this.m_CameraNameDictionary[cameraName], -degree, 0f, moveTime));
    //	}

    //	protected void RotateCameraDown(string cameraName, float degree, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_RotateCamera(this.m_CameraNameDictionary[cameraName], degree, 0f, moveTime));
    //	}

    //	protected void MoveCamera(string cameraName, int mode, float x, float y, float z, float moveTime)
    //	{
    //		if (mode == 1)
    //		{
    //			this.m_StoryEvents.Add(new Event_MoveTo(this.m_CameraNameDictionary[cameraName], new Vector3(x, y, z), moveTime));
    //			return;
    //		}
    //		if (mode == 2)
    //		{
    //			this.m_StoryEvents.Add(new Event_MoveBy(this.m_CameraNameDictionary[cameraName], new Vector3(x, y, z), moveTime));
    //		}
    //	}

    //	protected void MoveCamera(string cameraName, string referencePointName, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_MoveTo(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName].transform.position, moveTime));
    //	}

    //	protected void MoveCameraOrienttopath(string cameraName, string referencePointName, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_MoveAndRotateTo(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName].transform.position, moveTime));
    //	}

    //	protected void MoveCameraAndLookAtTarget(string cameraName, string referencePointName, string targetPointName, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_MoveAndLookAtTarget(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName].transform.position, moveTime, this.m_ReferencePointNameDictionary[targetPointName].transform.position));
    //	}

    //	protected void RotateCamera(string cameraName, string referencePointName, float moveTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_LookTo(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName], moveTime));
    //	}

    //	protected void CameraRotateAround(string cameraName, string characterName, float degree, float speed)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraRotateAround(this.m_CameraNameDictionary[cameraName], this.m_CharacterNameDictionary[characterName], degree, speed));
    //	}

    //	protected void CameraRotateAroundReferencePoint(string cameraName, string referencePointName, float degree, float speed)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraRotateAround(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName], degree, speed));
    //	}

    //	protected void CameraStartFollowTarget(string cameraName, string characterName, float distance)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStartToFollow(this.m_CameraNameDictionary[cameraName], this.m_CharacterNameDictionary[characterName], distance));
    //	}

    //	protected void CameraStopFollowTarget(string cameraName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStopFollowing(this.m_CameraNameDictionary[cameraName]));
    //	}

    //	protected void CameraStartToLookAt(string cameraName, string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStartToLookAt(this.m_CameraNameDictionary[cameraName], this.m_CharacterNameDictionary[characterName]));
    //	}

    //	protected void CameraStartToLookAtPoint(string cameraName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStartToLookAt(this.m_CameraNameDictionary[cameraName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void CameraStartToLookAtObject(string cameraName, string objectName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStartToLookAt(this.m_CameraNameDictionary[cameraName], this.m_SceneObjectNameDictionary[objectName]));
    //	}

    //	protected void CameraStopLookingAt(string cameraName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CameraStopLookingAt(this.m_CameraNameDictionary[cameraName]));
    //	}

    //	protected void Camera_MovePath(string cameraName, string cameraPathName)
    //	{
    //		GameObject gameObject = GameObject.Find(cameraPathName);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		CameraPathBezierAnimator component = gameObject.GetComponent<CameraPathBezierAnimator>();
    //		M_CameraWayPointManager component2 = gameObject.GetComponent<M_CameraWayPointManager>();
    //		if (component2 != null)
    //		{
    //			this.m_StoryEvents.Add(new Event_CameraMovePath(this.m_CameraNameDictionary[cameraName], gameObject));
    //			return;
    //		}
    //		if (component != null)
    //		{
    //			this.m_StoryEvents.Add(new Event_CameraMovePath_New(this.m_CameraNameDictionary[cameraName], gameObject));
    //		}
    //	}

    //	protected void Wait_Camera_MovePath(string cameraPathName)
    //	{
    //		GameObject gameObject = GameObject.Find(cameraPathName);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		CameraPathBezierAnimator component = gameObject.GetComponent<CameraPathBezierAnimator>();
    //		M_CameraWayPointManager component2 = gameObject.GetComponent<M_CameraWayPointManager>();
    //		if (component2 != null)
    //		{
    //			this.m_StoryEvents.Add(new Event_WaitCameraMovePath(gameObject));
    //			return;
    //		}
    //		if (component != null)
    //		{
    //			this.m_StoryEvents.Add(new Event_WaitCameraMovePath_New(gameObject));
    //		}
    //	}

    //	protected void Wait_Camera_Stop(string cameraName)
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitCameraStop(this.m_CameraNameDictionary[cameraName]));
    //	}

    //	protected void EnableCharacterHairLight(string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterHairColor(characterName, true));
    //	}

    //	protected void DisableCharacterHairLight(string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterHairColor(characterName, false));
    //	}

    //	protected void EnableCharacter(string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_EnableCharacter(this.m_CharacterNameDictionary[characterName]));
    //	}

    //	protected void DisableCharacter(string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_DisableCharacter(this.m_CharacterNameDictionary[characterName]));
    //	}

    //	protected void CharacterMoveAndWait(string characterName, string referencePointName, int clipIndex, float speed)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterMoveToPlayAnim(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], speed, true, this.GetAnimationClipName(1)));
    //		this.WaitCharacterMove(characterName, referencePointName);
    //	}

    //	protected void CharacterMove(string characterName, string referencePointName, int clipIndex, float speed)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterMoveTo(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], speed, false, true));
    //	}

    //	protected void CharacterMove(string characterName, string referencePointName, int clipIndex, float speed, bool lookTarget)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterMoveTo(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], speed, false, lookTarget));
    //	}

    //	protected void CharacterMove(string characterName, string referencePointName, int clipIndexA, float speed, int clipIndexB)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexA)));
    //		this.m_StoryEvents.Add(new Event_CharacterMoveToPlayAnim(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], speed, true, this.GetAnimationClipName(clipIndexB)));
    //	}

    //	protected void CharacterMove(string characterName, string referencePointName, int clipIndexA, float speed, int clipIndexB, bool lookTarget)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexA)));
    //		this.m_StoryEvents.Add(new Event_CharacterMoveToPlayAnim(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], speed, lookTarget, this.GetAnimationClipName(clipIndexB)));
    //	}

    //	protected void WaitCharacterMove(string characterName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitCharacterMove(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void RotateWait(string characterName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitCharacterRotate(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void CharacterRotateAndWait(string characterName, string referencePointName, float rotateTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], rotateTime, true));
    //	}

    //	protected void CharacterRotate(string characterName, string referencePointName, float rotateTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], rotateTime, false));
    //	}

    //	protected void CharacterRotateToCharacterAndWait(string characterName, string targetName, float rotateTime, int clipIndexA, int clipIndexB)
    //	{
    //		this.m_StoryEvents.Add(new Event_CrossFadeAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexA)));
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_CharacterNameDictionary[targetName], rotateTime, true));
    //		this.m_StoryEvents.Add(new Event_CrossFadeAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexB)));
    //	}

    //	protected void CharacterRotateToCharacterAndWait(string characterName, string targetName, float rotateTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_CharacterNameDictionary[targetName], rotateTime, true));
    //	}

    //	protected void CharacterRotateToCharacter(string characterName, string targetName, float rotateTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_CharacterNameDictionary[targetName], rotateTime, false));
    //	}

    //	protected void CharacterCrossFadeAnimation(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_CrossFadeAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void CharacterPlayAnimation(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void CharacterPlayAnimationQueued(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimationQueued(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex), false));
    //	}

    //	protected void CharacterPlayAnimationQueuedClampForever(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimationQueued(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex), true));
    //	}

    //	protected void CharacterPlayAnimationLoop(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimationLoop(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void CharacterPlayAnimationClampForever(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimationClampForever(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void WaitCharacterAnimationStop(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitAnimationStop(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void CharacterTeleport(string characterName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterTeleport(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void CharacterRotateToAngle(string characterName, float angle, float time)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterRotateByAngle(this.m_CharacterNameDictionary[characterName], angle, time));
    //	}

    //	protected void CharacterRotateToAngleMacro(string characterName, float angle, float time, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterRotateByAngle(this.m_CharacterNameDictionary[characterName], angle, time));
    //		this.m_StoryEvents.Add(new Event_Sleep(time));
    //		this.m_StoryEvents.Add(new Event_CharacterStopItween(this.m_CharacterNameDictionary[characterName]));
    //		this.m_StoryEvents.Add(new Event_CharacterRotateByAngle(this.m_CharacterNameDictionary[characterName], angle, 0f));
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(1)));
    //	}

    //	protected void CharacterRotateToCharacterMacro(string characterName, string targetName, float rotateTime, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_CharacterNameDictionary[targetName], rotateTime, true));
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(1)));
    //	}

    //	protected void CharacterRotateMacro(string characterName, string referencePointName, float rotateTime, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex)));
    //		this.m_StoryEvents.Add(new Event_CharacterRotateTo(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName], rotateTime, true));
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(1)));
    //	}

    //	protected void Character_PlayExpression_Up(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayExpression(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex), Enum_ExpressionPart.Up));
    //	}

    //	protected void Character_PlayExpression_Down(string characterName, int clipIndex)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayExpression(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndex), Enum_ExpressionPart.Down));
    //	}

    //	protected void Character_PlayExpression_Up_Queued(string characterName, int clipIndexA, int clipIndexB, float delayTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayExpressionQueued(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexA), this.GetAnimationClipName(clipIndexB), Enum_ExpressionPart.Up, delayTime));
    //	}

    //	protected void Character_PlayExpression_Down_Queued(string characterName, int clipIndexA, int clipIndexB, float delayTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayExpressionQueued(this.m_CharacterNameDictionary[characterName], this.GetAnimationClipName(clipIndexA), this.GetAnimationClipName(clipIndexB), Enum_ExpressionPart.Down, delayTime));
    //	}

    //	protected void Character_PlayExpression_Queued_Macro(string characterName, int clipIndexA_Up, int clipIndexB_Up, float delayTime_Up, int clipIndexA_Down, int clipIndexB_Down, float delayTime_Down)
    //	{
    //		this.Character_PlayExpression_Up_Queued(characterName, clipIndexA_Up, clipIndexB_Up, delayTime_Up);
    //		this.Character_PlayExpression_Down_Queued(characterName, clipIndexA_Down, clipIndexB_Down, delayTime_Down);
    //	}

    //	protected void Character_PlayExpression_Macro(string characterName, int clipIndex_Up, int clipIndex_Down)
    //	{
    //		this.Character_PlayExpression_Down(characterName, clipIndex_Down);
    //		this.Character_PlayExpression_Up(characterName, clipIndex_Up);
    //	}

    //	protected void Character_PlayAnimation_Queued_Macro(string characterName, int clipIndexA, int clipIndexB)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.CharacterPlayAnimationQueued(characterName, clipIndexB);
    //	}

    //	protected void Character_PlayAnimation_Queued_Macro(string characterName, int clipIndexA, int clipIndexB, int mode)
    //	{
    //		if (mode == 1)
    //		{
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexA);
    //		}
    //		if (mode == 2)
    //		{
    //			this.CharacterPlayAnimation(characterName, clipIndexA);
    //			this.CharacterPlayAnimationQueuedClampForever(characterName, clipIndexB);
    //		}
    //	}

    //	protected void Character_PlayAnimation_Wait_PlayAnimation_Macro(string characterName, int clipIndexA, int clipIndexB)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.WaitCharacterAnimationStop(characterName, clipIndexA);
    //		this.CharacterPlayAnimation(characterName, clipIndexB);
    //	}

    //	protected void Character_PlayAnimation_Wait_Macro(string characterName, int clipIndex)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndex);
    //		this.WaitCharacterAnimationStop(characterName, clipIndex);
    //	}

    //	protected void Character_Wait_PlayAnimation_Macro(string characterName, int clipIndexA, int clipIndexB)
    //	{
    //		this.WaitCharacterAnimationStop(characterName, clipIndexA);
    //		this.CharacterPlayAnimation(characterName, clipIndexB);
    //	}

    //	protected void Character_PlayAnimation_Wait_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, int contentID)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.ShowSubtitle(roleID, contentID);
    //		this.Character_Wait_PlayAnimation_Macro(characterName, clipIndexA, clipIndexB);
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void Character_PlayAnimation_Wait_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, string content)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.ShowSubtitle(roleID, content);
    //		this.Character_Wait_PlayAnimation_Macro(characterName, clipIndexA, clipIndexB);
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void Character_PlayAnimation_Wait_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, string content, int mode)
    //	{
    //		if (mode == 1)
    //		{
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, content);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //		if (mode == 2)
    //		{
    //			this.CharacterPlayAnimation(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, content);
    //			this.WaitCharacterAnimationStop(characterName, clipIndexA);
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexB);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //	}

    //	protected void Character_PlayAnimation_Wait_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, int contentID, int mode)
    //	{
    //		if (mode == 1)
    //		{
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, contentID);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //		if (mode == 2)
    //		{
    //			this.CharacterPlayAnimation(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, contentID);
    //			this.WaitCharacterAnimationStop(characterName, clipIndexA);
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexB);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //	}

    //	protected void Character_PlayAnimationQueued_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, int contentID)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.CharacterPlayAnimationQueued(characterName, clipIndexB);
    //		this.ShowSubtitle(roleID, contentID);
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void Character_PlayAnimationQueued_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, string content)
    //	{
    //		this.CharacterPlayAnimation(characterName, clipIndexA);
    //		this.CharacterPlayAnimationQueued(characterName, clipIndexB);
    //		this.ShowSubtitle(roleID, content);
    //		this.WaitAnyKey();
    //		this.HideSubtitle();
    //	}

    //	protected void Character_PlayAnimationQueued_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, int contentID, int mode)
    //	{
    //		if (mode == 1)
    //		{
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, contentID);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //		if (mode == 2)
    //		{
    //			this.CharacterPlayAnimation(characterName, clipIndexA);
    //			this.CharacterPlayAnimationQueuedClampForever(characterName, clipIndexB);
    //			this.ShowSubtitle(roleID, contentID);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //	}

    //	protected void Character_PlayAnimationQueued_Subtitle_Macro(string characterName, int clipIndexA, int clipIndexB, int roleID, string content, int mode)
    //	{
    //		if (mode == 1)
    //		{
    //			this.CharacterPlayAnimationClampForever(characterName, clipIndexA);
    //			this.ShowSubtitle(roleID, content);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //		if (mode == 2)
    //		{
    //			this.CharacterPlayAnimation(characterName, clipIndexA);
    //			this.CharacterPlayAnimationQueuedClampForever(characterName, clipIndexB);
    //			this.ShowSubtitle(roleID, content);
    //			this.WaitAnyKey();
    //			this.HideSubtitle();
    //		}
    //	}

    //	protected void Character_TurnHead_Off(string characterName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterTurnHeadOff(this.m_CharacterNameDictionary[characterName]));
    //	}

    //	protected void Character_TurnHead(string characterName, int Direction)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterTurnHead(this.m_CharacterNameDictionary[characterName], Direction));
    //	}

    //	protected void Character_TurnHead(string characterName, int Direction, float bendingMultiplier, float responsiveness)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterTurnHead(this.m_CharacterNameDictionary[characterName], Direction, bendingMultiplier, responsiveness));
    //	}

    //	protected void Character_Look_Character(string characterName, string targetName)
    //	{
    //		Transform target = TransformTool.SearchHierarchyForBone(this.m_CharacterNameDictionary[targetName].transform, "Bip001 Head");
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(this.m_CharacterNameDictionary[characterName], target));
    //	}

    //	protected void Character_Look_Point(string characterName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(this.m_CharacterNameDictionary[characterName], this.m_ReferencePointNameDictionary[referencePointName].transform));
    //	}

    //	protected void Character_Look_StoryObject(string characterName, string objectName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		Transform transform = TransformTool.SearchHierarchyForBone(gameObject.transform, "Bip001 Head");
    //		if (transform == null)
    //		{
    //			transform = gameObject.transform;
    //		}
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(this.m_CharacterNameDictionary[characterName], transform));
    //	}

    //	protected void Character_LookEachother(string characterNameA, string characterNameB)
    //	{
    //		this.Character_Look_Character(characterNameA, characterNameB);
    //		this.Character_Look_Character(characterNameB, characterNameA);
    //	}

    //	protected void Character_Stop_LookEachother(string characterNameA, string characterNameB)
    //	{
    //		this.Character_TurnHead(characterNameA, 0);
    //		this.Character_TurnHead(characterNameB, 0);
    //	}

    //	protected void Character_Show_Item(string characterName, int itemID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterShowItem(this.m_CharacterNameDictionary[characterName], itemID, nodeName));
    //	}

    //	protected void Character_Hide_Item(string characterName, int itemID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CharacterHideItem(this.m_CharacterNameDictionary[characterName], itemID, nodeName));
    //	}

    //	protected void Character_Show_Weapon(string characterName)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int roleID = int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_CharacterShowWeapon(this.m_CharacterNameDictionary[characterName], roleID));
    //	}

    //	protected void Character_Hide_Weapon(string characterName)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int roleID = int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_CharacterHideWeapon(this.m_CharacterNameDictionary[characterName], roleID));
    //	}

    //	protected void Character_TurnOnSkinEffect(string characterName, float time)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_SwitchCharacterEmission(this.m_CharacterNameDictionary[characterName], 1, time));
    //	}

    //	protected void Character_TurnOffSkinEffect(string characterName, float time)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_SwitchCharacterEmission(this.m_CharacterNameDictionary[characterName], 2, time));
    //	}

    //	protected void Character_BlinkSkinEffect(string characterName, float time)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_SwitchCharacterEmission(this.m_CharacterNameDictionary[characterName], 3, time));
    //	}

    //	protected void Character_Dissolve(string characterName)
    //	{
    //		string[] array = characterName.Split(new char[]
    //		{
    //			'_'
    //		});
    //		int.Parse(array[1]);
    //		this.m_StoryEvents.Add(new Event_DissolveCharacterEmission(this.m_CharacterNameDictionary[characterName]));
    //	}

    //	protected void CreateEffect_Character(string characterName, int effectID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CreateEffect(this.m_CharacterNameDictionary[characterName], effectID, nodeName));
    //	}

    //	protected void CreateEffect_Point(string referencePointName, int effectID)
    //	{
    //		this.m_StoryEvents.Add(new Event_CreateEffect(this.m_ReferencePointNameDictionary[referencePointName], effectID, ""));
    //	}

    //	protected void CreateEffect_StoryObject(string objectName, int effectID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_CreateEffect(this.m_SceneObjectNameDictionary[objectName], effectID, nodeName));
    //	}

    //	protected void DestroyEffect_Character(string characterName, int effectID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_DestroyEffect(this.m_CharacterNameDictionary[characterName], effectID, nodeName));
    //	}

    //	protected void DestroyEffect_Point(string referencePointName, int effectID)
    //	{
    //		this.m_StoryEvents.Add(new Event_DestroyEffect(this.m_ReferencePointNameDictionary[referencePointName], effectID, ""));
    //	}

    //	protected void DestroyEffect_StoryObject(string objectName, int effectID, string nodeName)
    //	{
    //		this.m_StoryEvents.Add(new Event_DestroyEffect(this.m_SceneObjectNameDictionary[objectName], effectID, nodeName));
    //	}

    //	protected void Scene_Sound(int musicID, int loopMode, float volume)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayEnvironmentMusic(musicID, loopMode == 1, volume));
    //	}

    //	protected void Scene_Sound_Off(int stopMode)
    //	{
    //		this.m_StoryEvents.Add(new Event_StopEnvironmentMusic(stopMode));
    //	}

    //	protected void Story_Music(int musicID_A, int musicID_B, int loopMode, int extendMode, float extendTime, float volume)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayStoryMusic(musicID_A, musicID_B, loopMode, extendMode, extendTime, volume));
    //	}

    //	protected void Story_Music_Off(int stopMode, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_StopStoryMusic(stopMode, fadeTime));
    //	}

    //	protected void Map_Music_Off(float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_StopMapMusic(fadeTime));
    //	}

    //	protected void Map_Music(int mapID)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayMapMusic(mapID));
    //	}

    //	protected void Change_Map_Music(int mapID, int musicID_A, int musicID_B, int loopMode)
    //	{
    //		this.m_StoryEvents.Add(new Event_ChangeMapMusic(mapID, musicID_A, musicID_B, loopMode));
    //	}

    //	protected void Fade_Map_Music(float volume, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_FadeBackgroundMusic(volume, fadeTime));
    //	}

    //	protected void Fade_Story_Music(float volume, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_FadeBackgroundMusic(volume, fadeTime));
    //	}

    //	protected void Fade_Scene_Sound(float volume, float fadeTime)
    //	{
    //		this.m_StoryEvents.Add(new Event_FadeEnvironmentMusic(volume, fadeTime));
    //	}

    //	protected void Play_SoundEffect(int soundID, int times)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlaySound(soundID, times));
    //	}

    //	protected void Play_SoundEffect_Loop(int soundID)
    //	{
    //		this.m_StoryEvents.Add(new Event_PlayLoopSound(soundID));
    //	}

    //	protected void Stop_SoundEffect(int soundID)
    //	{
    //		this.m_StoryEvents.Add(new Event_StopSound(soundID));
    //	}

    //	protected void MoveSceneObject(string objectName, string referencePointName, float moveTime)
    //	{
    //		GameObject gameObject = GameObject.Find(objectName);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_MoveTo(gameObject, this.m_ReferencePointNameDictionary[referencePointName].transform.position, moveTime));
    //	}

    //	protected void PlaySceneObjectAnimation(string objectName, int clipIndex)
    //	{
    //		GameObject gameObject = GameObject.Find(objectName);
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void HideSceneObject(int id, bool hide)
    //	{
    //		this.m_StoryEvents.Add(new Event_HideRole(id, hide));
    //	}

    //	protected void StoryObject_Move(string objectName, string referencePointName, float moveTime)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_MoveTo(gameObject, this.m_ReferencePointNameDictionary[referencePointName].transform.position, moveTime));
    //	}

    //	protected void StoryObject_PlayAnim(string objectName, int clipIndex)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void StoryObject_PlayAnim_Loop(string objectName, int clipIndex)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_PlayAnimationLoop(gameObject, this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void StoryObject_Enable(string objectName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_EnableCharacter(gameObject));
    //	}

    //	protected void StoryObject_Disable(string objectName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_DisableCharacter(gameObject));
    //	}

    //	protected void StoryObject_Move_PlayAnim_Wait(string objectName, string referencePointName, int clipIndex, float speed)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		if (clipIndex > 0)
    //		{
    //			this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndex)));
    //		}
    //		this.m_StoryEvents.Add(new Event_MoveToBySpeed(gameObject, this.m_ReferencePointNameDictionary[referencePointName].transform.position, speed));
    //		this.Wait_StoryObject_Move(objectName, referencePointName);
    //	}

    //	protected void StoryObject_Move_PlayAnim(string objectName, string referencePointName, int clipIndex, float speed)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		if (clipIndex > 0)
    //		{
    //			this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndex)));
    //		}
    //		this.m_StoryEvents.Add(new Event_MoveToBySpeed(gameObject, this.m_ReferencePointNameDictionary[referencePointName].transform.position, speed));
    //	}

    //	protected void StoryObject_Move_PlayAnim(string objectName, string referencePointName, int clipIndex, float speed, bool rotateTo)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		if (clipIndex > 0)
    //		{
    //			this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndex)));
    //		}
    //		this.m_StoryEvents.Add(new Event_MoveToBySpeed(gameObject, this.m_ReferencePointNameDictionary[referencePointName].transform.position, speed, rotateTo));
    //	}

    //	protected void Wait_StoryObject_Move(string objectName, string referencePointName)
    //	{
    //		this.m_StoryEvents.Add(new Event_WaitCharacterMove(this.m_SceneObjectNameDictionary[objectName], this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void StoryObject_RotateTo_Point(string objectName, string referencePointName, float moveTime)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_LookTo(gameObject, this.m_ReferencePointNameDictionary[referencePointName], moveTime));
    //	}

    //	protected void StoryObject_RotateTo_Character(string objectName, string characterName, float moveTime)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_LookTo(gameObject, this.m_CharacterNameDictionary[characterName], moveTime));
    //	}

    //	protected void StoryObject_Teleport(string objectName, string referencePointName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject obj = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_Teleport(obj, this.m_ReferencePointNameDictionary[referencePointName]));
    //	}

    //	protected void StoryObject_RotateTo_Angle(string objectName, float angle, float time)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_CharacterRotateByAngle(character, angle, time));
    //	}

    //	protected void Wait_StoryObject_AnimationStop(string objectName, int clipIndex)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_WaitAnimationStop(character, this.GetAnimationClipName(clipIndex)));
    //	}

    //	protected void StoryObject_PlayAnimation_Queued_Macro(string objectName, int clipIndexA, int clipIndexB)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_PlayAnimation(gameObject, this.GetAnimationClipName(clipIndexA)));
    //		this.m_StoryEvents.Add(new Event_PlayAnimationQueued(gameObject, this.GetAnimationClipName(clipIndexB), false));
    //	}

    //	protected void StoryObject_PlayAnimation_Wait_Macro(string objectName, int clipIndex)
    //	{
    //		this.StoryObject_PlayAnim(objectName, clipIndex);
    //		this.Wait_StoryObject_AnimationStop(objectName, clipIndex);
    //	}

    //	protected void StoryObject_Wait_PlayAnimation_Macro(string objectName, int clipIndexA, int clipIndexB)
    //	{
    //		this.Wait_StoryObject_AnimationStop(objectName, clipIndexA);
    //		this.StoryObject_PlayAnim(objectName, clipIndexB);
    //	}

    //	protected void StoryObject_PlayAnimation_Wait_PlayAnimation_Macro(string objectName, int clipIndexA, int clipIndexB)
    //	{
    //		this.StoryObject_PlayAnim(objectName, clipIndexA);
    //		this.Wait_StoryObject_AnimationStop(objectName, clipIndexA);
    //		this.StoryObject_PlayAnim(objectName, clipIndexB);
    //	}

    //	protected void StoryObject_PlayExpression_Up(string objectName, int clipIndex)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject obj = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_PlayExpression(obj, this.GetAnimationClipName(clipIndex), Enum_ExpressionPart.Up));
    //	}

    //	protected void StoryObject_TurnHead(string objectName, int Direction)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_CharacterTurnHead(character, Direction));
    //	}

    //	protected void StoryObject_TurnHead(string objectName, int Direction, float bendingMultiplier, float responsiveness)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_CharacterTurnHead(character, Direction));
    //	}

    //	protected void StoryObject_Look_Character(string objectName, string targetName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		Transform target = TransformTool.SearchHierarchyForBone(this.m_CharacterNameDictionary[targetName].transform, "Bip001 Head");
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(character, target));
    //	}

    //	protected void StoryObject_Look_Point(string objectName, string referencePointName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject character = this.m_SceneObjectNameDictionary[objectName];
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(character, this.m_ReferencePointNameDictionary[referencePointName].transform));
    //	}

    //	protected void StoryObject_Look_StoryObject(string objectName, string targetObjectName)
    //	{
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(objectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + objectName);
    //			return;
    //		}
    //		GameObject gameObject = this.m_SceneObjectNameDictionary[objectName];
    //		if (gameObject == null)
    //		{
    //			return;
    //		}
    //		if (!this.m_SceneObjectNameDictionary.ContainsKey(targetObjectName))
    //		{
    //			Debug.LogWarning("Wrong objectName : " + targetObjectName);
    //			return;
    //		}
    //		GameObject gameObject2 = this.m_SceneObjectNameDictionary[targetObjectName];
    //		if (gameObject2 == null)
    //		{
    //			return;
    //		}
    //		this.m_StoryEvents.Add(new Event_CharacterLookAtTarget(gameObject, gameObject2.transform));
    //	}

    //	protected void StoryObject_LookEachother(string objectName, string characterName)
    //	{
    //		this.StoryObject_Look_Character(objectName, characterName);
    //		this.Character_Look_StoryObject(characterName, objectName);
    //	}

    //	protected void StoryObject_Stop_LookEachother(string objectName, string characterName)
    //	{
    //		this.StoryObject_TurnHead(objectName, 0);
    //		this.Character_TurnHead(characterName, 0);
    //	}

    //	protected void ChangeAmbientLight(byte r, byte g, byte b)
    //	{
    //		this.m_StoryEvents.Add(new Event_AmbientLight(new Color32(r, g, b, 255)));
    //	}

    //	protected void RevertAmbientLight()
    //	{
    //		this.m_StoryEvents.Add(new Event_AmbientLight(GameDefine.AMBIENTLIGHT));
    //	}

    //	protected string GetAnimationClipName(int ID)
    //	{
    //		S_AnimationData data = GameDataDB.AnimationDB.GetData(ID);
    //		if (data == null)
    //		{
    //			string text = "動作資料表內沒有這個編號 : " + ID;
    //			Debug.LogWarning(text);
    //			return "";
    //		}
    //		return data.ClipName;
    //	}
}
