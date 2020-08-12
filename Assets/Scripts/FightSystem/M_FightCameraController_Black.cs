using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class M_FightCameraController_Black : M_FightCameraController
{
	[Tooltip("換陣型時的座標")]
	public Vector3 m_ChangeFormationPos;

	[Tooltip("換陣型時的停留時間")]
	public float m_ChangeFormationStayTime;

	[Tooltip("滑鼠移動的速度")]
	public float m_MouseSpeedX = 10f;

	[Tooltip("滑鼠移動的範圍最大值")]
	public float m_MouseRangeMax = 5f;

	[Tooltip("滑鼠移動的範圍最小值")]
	public float m_MouseRangeMin = -5f;

	[Tooltip("FOV最小值")]
	public float m_MinFOV = 50f;

	[Tooltip("FOV最大值")]
	public float m_MaxFOV = 60f;

	[Tooltip("滾輪速度")]
	public float m_ScrollSpeed = 5f;

	[Tooltip("滾輪速度")]
	public float m_JoySpeedX = 20f;

	[Tooltip("滾輪速度")]
	public float m_JoySpeedY = 20f;

	[Tooltip("注視敵方的高度比例0~1")]
	public float m_TargetHeightRatio = 0.5f;

	[Tooltip("在角色後方跟隨的位置")]
	public Vector3 m_FollowPos;

	[Tooltip("跟隨的速度")]
	public float m_FollowSpeed;

	[Tooltip("轉向的速度")]
	public float m_RotateSpeed;

	//[Tooltip("收妖開始的運鏡資料")]
	//public S_SkillCameraData m_CatchMobStartData;

	//[Tooltip("收妖成功的運鏡資料")]
	//public S_SkillCameraData m_CatchMobSuccessData;

	private M_Character m_CurrentFaceTarget;

	public float m_MouseX;

	private float m_CurrentFOV = 50f;

	private bool hasCatchMob;

	private bool hasCatchSuccess;

	private void OnDestroy()
	{
		if (FightSystem.Instance != null)
		{
			FightSystem.Instance.m_FightCameraFOV = this.m_CurrentFOV;
			FightSystem.Instance.m_FightCameraMouseX = this.m_MouseX;
		}
	}

	public override void ChangeFormation()
	{
		if (this.m_CurrentState >= M_FightCameraController.Enum_CameraState.ChangeFormation)
		{
			return;
		}
		base.StopAllCoroutines();
		//base.StartCoroutine(this.ChangeFormationCoroutine());
	}

	//[DebuggerHidden]
	//private IEnumerator ChangeFormationCoroutine()
	//{
	//	M_FightCameraController_Black.<ChangeFormationCoroutine>c__Iterator88F <ChangeFormationCoroutine>c__Iterator88F = new M_FightCameraController_Black.<ChangeFormationCoroutine>c__Iterator88F();
	//	<ChangeFormationCoroutine>c__Iterator88F.<>f__this = this;
	//	return <ChangeFormationCoroutine>c__Iterator88F;
	//}

	public override void StoryShotCharacter(M_Character character, Vector3 pos, Vector3 rot)
	{
		base.StopAllCoroutines();
		this.m_CurrentState = M_FightCameraController.Enum_CameraState.Story;
		this.m_Transform.parent = character.m_ModelTransform;
		this.m_Transform.localPosition = pos;
		this.m_Transform.localRotation = Quaternion.Euler(rot);
		this.m_Transform.parent = null;
	}

	//public override void SkillShotCharacter(M_Character character, S_SkillCameraData skillCameraData, bool bCritical)
	//{
	//	if (this.m_CurrentState >= M_FightCameraController.Enum_CameraState.Skill)
	//	{
	//		return;
	//	}
	//	if (character != this.m_Follower)
	//	{
	//		return;
	//	}
	//	base.StopAllCoroutines();
	//	base.StartCoroutine(this.SkillShotCharacterCoroutine(character, skillCameraData));
	//	if (character is M_Player && bCritical)
	//	{
	//		M_Player m_Player = character as M_Player;
	//		UI_Fight.Instance.ShowCutIn(m_Player.m_RoleID);
	//	}
	//}

	//[DebuggerHidden]
	//private IEnumerator SkillShotCharacterCoroutine(M_Character character, S_SkillCameraData skillCameraData)
	//{
	//	M_FightCameraController_Black.<SkillShotCharacterCoroutine>c__Iterator890 <SkillShotCharacterCoroutine>c__Iterator = new M_FightCameraController_Black.<SkillShotCharacterCoroutine>c__Iterator890();
	//	<SkillShotCharacterCoroutine>c__Iterator.skillCameraData = skillCameraData;
	//	<SkillShotCharacterCoroutine>c__Iterator.character = character;
	//	<SkillShotCharacterCoroutine>c__Iterator.<$>skillCameraData = skillCameraData;
	//	<SkillShotCharacterCoroutine>c__Iterator.<$>character = character;
	//	<SkillShotCharacterCoroutine>c__Iterator.<>f__this = this;
	//	return <SkillShotCharacterCoroutine>c__Iterator;
	//}

	//public override void CatchMobShotCharacter(M_CatchMob character)
	//{
	//	if (this.m_CurrentState >= M_FightCameraController.Enum_CameraState.Catch)
	//	{
	//		return;
	//	}
	//	if (this.hasCatchMob)
	//	{
	//		return;
	//	}
	//	this.hasCatchMob = true;
	//	base.StopAllCoroutines();
	//	base.StartCoroutine(this.CatchMobShotCharacterCoroutine(character));
	//}

	//[DebuggerHidden]
	//private IEnumerator CatchMobShotCharacterCoroutine(M_CatchMob character)
	//{
	//	M_FightCameraController_Black.<CatchMobShotCharacterCoroutine>c__Iterator891 <CatchMobShotCharacterCoroutine>c__Iterator = new M_FightCameraController_Black.<CatchMobShotCharacterCoroutine>c__Iterator891();
	//	<CatchMobShotCharacterCoroutine>c__Iterator.character = character;
	//	<CatchMobShotCharacterCoroutine>c__Iterator.<$>character = character;
	//	<CatchMobShotCharacterCoroutine>c__Iterator.<>f__this = this;
	//	return <CatchMobShotCharacterCoroutine>c__Iterator;
	//}

	//public override void CatchSuccessShotCharacter(M_CatchMob character)
	//{
	//	if (this.m_CurrentState >= M_FightCameraController.Enum_CameraState.Catch)
	//	{
	//		return;
	//	}
	//	if (this.hasCatchSuccess)
	//	{
	//		return;
	//	}
	//	this.hasCatchSuccess = true;
	//	base.StopAllCoroutines();
	//	base.StartCoroutine(this.CatchSuccessShotCharacterCoroutine(character));
	//}

	//[DebuggerHidden]
	//private IEnumerator CatchSuccessShotCharacterCoroutine(M_CatchMob character)
	//{
	//	M_FightCameraController_Black.<CatchSuccessShotCharacterCoroutine>c__Iterator892 <CatchSuccessShotCharacterCoroutine>c__Iterator = new M_FightCameraController_Black.<CatchSuccessShotCharacterCoroutine>c__Iterator892();
	//	<CatchSuccessShotCharacterCoroutine>c__Iterator.character = character;
	//	<CatchSuccessShotCharacterCoroutine>c__Iterator.<$>character = character;
	//	<CatchSuccessShotCharacterCoroutine>c__Iterator.<>f__this = this;
	//	return <CatchSuccessShotCharacterCoroutine>c__Iterator;
	//}

	private void LateUpdate()
	{
		if (this.m_Follower == null)
		{
			return;
		}
		if (this.m_CurrentState != M_FightCameraController.Enum_CameraState.Normal)
		{
			return;
		}
		if (this.m_FightSceneManager.m_IsFightFinish)
		{
			return;
		}
		this.UpdatePosition();
		this.UpdateRotation();
	}

	private void UpdatePosition()
	{
		this.m_CurrentFOV = this.m_Camera.fieldOfView;
		//Vector3 joyRAxis = GameInput.GetJoyRAxis();
		//if (joyRAxis != Vector3.zero)
		//{
		//	this.m_MouseX += joyRAxis.x * this.m_JoySpeedX * Time.deltaTime;
		//	this.m_MouseX = Mathf.Clamp(this.m_MouseX, this.m_MouseRangeMin, this.m_MouseRangeMax);
		//	this.m_CurrentFOV = Mathf.Clamp(this.m_CurrentFOV + joyRAxis.y * this.m_JoySpeedY * Time.deltaTime, this.m_MinFOV, this.m_MaxFOV);
		//	this.m_Camera.fieldOfView = this.m_CurrentFOV;
		//}
		//else
		//{
		//	if (Input.GetMouseButton(1))
		//	{
		//		this.m_MouseX += Input.GetAxis("Mouse X") * this.m_MouseSpeedX;
		//		this.m_MouseX = Mathf.Clamp(this.m_MouseX, this.m_MouseRangeMin, this.m_MouseRangeMax);
		//	}
		//	this.m_CurrentFOV = Mathf.Clamp(this.m_CurrentFOV - Input.GetAxis("Mouse ScrollWheel") * this.m_ScrollSpeed, this.m_MinFOV, this.m_MaxFOV);
		//	this.m_Camera.fieldOfView = this.m_CurrentFOV;
		//}
		Vector3 to = this.m_Follower.m_ModelTransform.TransformPoint(this.m_FollowPos + new Vector3(this.m_MouseX, 0f, 0f));
		this.m_Transform.position = Vector3.Lerp(this.m_Transform.position, to, Time.deltaTime * this.m_FollowSpeed);
	}

	private void UpdateRotation()
	{
		if (this.m_GameObject == null)
		{
			return;
		}
		if (this.m_FightSceneManager == null)
		{
			return;
		}
		//if (this.m_Follower.m_FaceToTarget is M_Mob || this.m_Follower.IsLoseHeart())
		//{
		//	this.m_CurrentFaceTarget = this.m_Follower.m_FaceToTarget;
		//}
		//Vector3 a = this.m_CurrentFaceTarget.GetModelPosition() + new Vector3(0f, this.m_CurrentFaceTarget.m_RoleHeight * this.m_TargetHeightRatio, 0f);
		//Quaternion to = Quaternion.Euler(Quaternion.LookRotation(a - this.m_Transform.position, Vector3.up).eulerAngles);
		//this.m_Transform.rotation = Quaternion.Slerp(this.m_Transform.rotation, to, Time.deltaTime * this.m_RotateSpeed);
	}

	private void ChangePosition()
	{
		if (this.m_GameObject == null)
		{
			return;
		}
		if (this.m_FightSceneManager == null)
		{
			return;
		}
		//if (this.m_Follower.m_FaceToTarget is M_Mob || this.m_Follower.IsLoseHeart())
		//{
		//	this.m_CurrentFaceTarget = this.m_Follower.m_FaceToTarget;
		//}
		Vector3 position = this.m_Follower.m_ModelTransform.TransformPoint(this.m_FollowPos + new Vector3(this.m_MouseX, 0f, 0f));
		this.m_Transform.position = position;
		this.m_Transform.rotation = this.m_Follower.m_ModelTransform.rotation;
	}

	public override void SetStoryMode(bool isStory)
	{
		if (isStory)
		{
			this.m_CurrentState = M_FightCameraController.Enum_CameraState.Story;
		}
		else
		{
			if (this.m_FightSceneManager.m_IsFightFinish)
			{
				return;
			}
			this.m_CurrentState = M_FightCameraController.Enum_CameraState.Normal;
			this.ChangePosition();
		}
	}

	public override void SetFirstFollower(M_Character follower)
	{
		this.m_Follower = follower;
		this.m_CurrentState = M_FightCameraController.Enum_CameraState.Normal;
	}

	public override void SetFollower(M_Character follower)
	{
		this.m_Follower = follower;
		if (this.m_CurrentState != M_FightCameraController.Enum_CameraState.Normal)
		{
			return;
		}
		if (this.m_FightSceneManager.m_IsFightFinish)
		{
			return;
		}
		this.ChangePosition();
	}

	private void OnTriggerEnter(Collider other)
	{
		//if (other is CharacterController)
		//{
		//	return;
		//}
		//M_Guard component = other.GetComponent<M_Guard>();
		//if (component != null)
		//{
		//	RendererTool.EnableChildRenderers(component.m_RoleModel, false);
		//	ShroudInstance component2 = component.GetComponent<ShroudInstance>();
		//	if (component2 != null)
		//	{
		//		component2.enabled = false;
		//	}
		//}
		//M_Mob component3 = other.GetComponent<M_Mob>();
		//if (component3 != null && component3.m_MobData.emType == ENUM_MobType.Normal)
		//{
		//	RendererTool.EnableChildRenderers(component3.m_RoleModel, false);
		//	ShroudInstance component4 = component3.GetComponent<ShroudInstance>();
		//	if (component4 != null)
		//	{
		//		component4.enabled = false;
		//	}
		//}
		//if (this.m_CurrentState == M_FightCameraController.Enum_CameraState.Finish)
		//{
		//	M_Player component5 = other.GetComponent<M_Player>();
		//	if (component5 != null)
		//	{
		//		RendererTool.EnableAllRenderers(component5.m_RoleModel, false);
		//		ShroudInstance component6 = component5.GetComponent<ShroudInstance>();
		//		if (component6 != null)
		//		{
		//			component6.enabled = false;
		//		}
		//	}
		//}
	}

	private void OnTriggerExit(Collider other)
	{
		//if (other is CharacterController)
		//{
		//	return;
		//}
		//M_Guard component = other.GetComponent<M_Guard>();
		//if (component != null)
		//{
		//	RendererTool.EnableChildRenderers(component.m_RoleModel, true);
		//	ShroudInstance component2 = component.GetComponent<ShroudInstance>();
		//	if (component2 != null)
		//	{
		//		component2.enabled = true;
		//	}
		//}
		//M_Mob component3 = other.GetComponent<M_Mob>();
		//if (component3 != null && component3.m_MobData.emType == ENUM_MobType.Normal)
		//{
		//	RendererTool.EnableChildRenderers(component3.m_RoleModel, true);
		//	ShroudInstance component4 = component3.GetComponent<ShroudInstance>();
		//	if (component4 != null)
		//	{
		//		component4.enabled = true;
		//	}
		//}
		//if (this.m_CurrentState == M_FightCameraController.Enum_CameraState.Finish)
		//{
		//	M_Player component5 = other.GetComponent<M_Player>();
		//	if (component5 != null)
		//	{
		//		RendererTool.EnableAllRenderers(component5.m_RoleModel, true);
		//		ShroudInstance component6 = component5.GetComponent<ShroudInstance>();
		//		if (component6 != null)
		//		{
		//			component6.enabled = true;
		//		}
		//	}
		//}
	}
}
