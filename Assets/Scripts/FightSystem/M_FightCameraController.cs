using System;
using UnityEngine;

public class M_FightCameraController : MonoBehaviour
{
	public enum Enum_CameraState
	{
		None,
		Normal,
		Catch,
		ChangeFormation,
		Skill,
		Story,
		Finish,
		LevelUp
	}

	public M_FightCameraController.Enum_CameraState m_CurrentState;

	public FightSceneManager m_FightSceneManager;

	protected M_Character m_Follower;

	protected Animator m_Animator;

    protected Transform m_Transform;

    protected GameObject m_GameObject;

    protected Camera m_Camera;

    protected virtual void Start()
    {
        Debug.Log("Ö´ÐÐÏà»úStart");
        this.m_GameObject = base.gameObject;
        this.m_Transform = base.transform;
        this.m_Camera = gameObject.GetComponent<Camera>();
    }

    public virtual void SetStoryMode(bool isStory)
	{
	}

	public virtual void SetFirstFollower(M_Character follower)
	{
	}

	public virtual void SetFollower(M_Character follower)
	{
	}

	public void Shake(M_Character character)
	{
		if (character != this.m_Follower)
		{
			return;
		}
		//iTween.Stop(this.m_GameObject);
		//iTween.ShakePosition(base.gameObject, new Vector3(0.2f, 0.2f, 0f), 0.3f);
	}

	public virtual void StoryShotCharacter(M_Character character, Vector3 pos, Vector3 rot)
	{
	}

	//public virtual void CatchMobShotCharacter(M_CatchMob character)
	//{
	//}

	//public virtual void CatchSuccessShotCharacter(M_CatchMob character)
	//{
	//}

	//public virtual void SkillShotCharacter(M_Character character, S_SkillCameraData skillCameraData, bool bCritical)
	//{
	//}

	public virtual void ChangeFormation()
	{
	}
}
