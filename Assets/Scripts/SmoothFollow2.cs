using System;
using System.IO;
using SoftStar.Pal6;
using UnityEngine;


public class SmoothFollow2 : MonoBehaviour, ISaveInterface
{
    public bool bControl = true;

    // Token: 0x04001FA8 RID: 8104
    public bool bInUI;

    // Token: 0x04001FA9 RID: 8105
    public Transform target;

    // Token: 0x04001FAA RID: 8106
    public Transform targetRoot;

    // Token: 0x04001FAB RID: 8107
    private float baseHeight = 1.6f;

    // Token: 0x04001FAC RID: 8108
    public float height;

    // Token: 0x04001FAD RID: 8109
    public float damping = 5f;

    // Token: 0x04001FAE RID: 8110
    public float rotationDamping = 100000000f;

    // Token: 0x04001FAF RID: 8111
    public Vector3 CenterOffset = new Vector3(0f, 0f, -1f);

    // Token: 0x04001FB0 RID: 8112
    public float CamDistance = 1f;

    // Token: 0x04001FB1 RID: 8113
    public float fieldOfView = 45f;

    // Token: 0x04001FB2 RID: 8114
    [HideInInspector]
    [NonSerialized]
    public Vector3 CamPos;

    // Token: 0x04001FB3 RID: 8115
    public Quaternion CamRot = new Quaternion(0f, 0f, 0f, 1f);

    // Token: 0x04001FB4 RID: 8116
    private Vector3 FocalPos;

    // Token: 0x04001FB5 RID: 8117
    private Vector3 LastTargetPos;

    // Token: 0x04001FB6 RID: 8118
    private Quaternion LastWantedRotation = new Quaternion(0f, 0f, 0f, 1f);

    // Token: 0x04001FB7 RID: 8119
    private CharacterController charCtrl;

    // Token: 0x04001FB8 RID: 8120
    private static int ignorelayer = -100;

    // Token: 0x04001FB9 RID: 8121
    private static int maskValue = -1;

    // Token: 0x04001FBA RID: 8122
    public bool CanScroll = true;

    //public PalShake shakeScript;

    //public ShakeType curShakeType;

    // Token: 0x04001FBD RID: 8125
    public static bool LeftCameraMove = false;

    // Token: 0x04001FBE RID: 8126
    private static Vector3 lastMousePos = Vector3.zero;

    // Token: 0x04001FBF RID: 8127
    private bool HVByLoadArchive;

    // Token: 0x04001FC0 RID: 8128
    public Vector3 offsetScale = new Vector3(1f, 0.23f, 1f);

    // Token: 0x04001FC1 RID: 8129
    public Quaternion TargetCamRot = new Quaternion(0f, 0f, 0f, 1f);

    // Token: 0x04001FC2 RID: 8130
    public bool bJolt = true;

    // Token: 0x04001FC3 RID: 8131
    [HideInInspector]
    [NonSerialized]
    public float lastAngleH;

    // Token: 0x04001FC4 RID: 8132
    public bool bNeedReturn;

    // Token: 0x04001FC5 RID: 8133
    public float ReturnSpeed = 2f;

    // Token: 0x04001FC6 RID: 8134
    private bool bUseLeftReturn;

    // Token: 0x04001FC7 RID: 8135
    public float CameraRadius = 0.13f;

    // Token: 0x04001FC8 RID: 8136
    public static float CameraRadiusDefault = 0.16f;

    // Token: 0x04001FC9 RID: 8137
    public Vector2 FOV_Range = new Vector2(35f, 60f);

    // Token: 0x04001FCA RID: 8138
    public Action InsideFun;

    // Token: 0x04001FCB RID: 8139
    private static string guiDisplayStr;

    // Token: 0x04001FCC RID: 8140
    public static RaycastHit mouseHit;

    // Token: 0x04001FCD RID: 8141
    public static GameObject mouseHitObject = null;

    // Token: 0x04001FCE RID: 8142
    public float horizontalRotSpeed = 200f;

    // Token: 0x04001FCF RID: 8143
    public float verticalRotSpeed = 250f;

    // Token: 0x04001FD0 RID: 8144
    private float angleH;

    // Token: 0x04001FD1 RID: 8145
    private float angleV;

    // Token: 0x04001FD2 RID: 8146
    public float maxVerticalAngle = 60f;

    // Token: 0x04001FD3 RID: 8147
    public float minVerticalAngle = -55f;

    // Token: 0x04001FD4 RID: 8148
    private float m_maxVerticalAngle = 60f;

    // Token: 0x04001FD5 RID: 8149
    private float m_minVerticalAngle = -55f;

    // Token: 0x04001FD6 RID: 8150
    private float TargetCamDistance = 6f;

    // Token: 0x04001FD7 RID: 8151
    public float MaxDistance = 12.3f;

    // Token: 0x04001FD8 RID: 8152
    public float MinDistance = 0.8f;

    // Token: 0x04001FD9 RID: 8153
    private float currentDistance = 5f;

    // Token: 0x04001FDA RID: 8154
    public float elasticSpeed = 4f;

    // Token: 0x04001FDB RID: 8155
    private Ray ray = new Ray(Vector3.zero, Vector3.zero);

    // Token: 0x04001FDC RID: 8156
    private bool cullPlayer;

    // Token: 0x04001FDD RID: 8157
    private Vector3 posOrig;

    // Token: 0x04001FDE RID: 8158
    private Vector3 posEnd;

    // Token: 0x04001FDF RID: 8159
    public float YSpeed = 5f;

    // Token: 0x04001FE0 RID: 8160
    public bool UseYSpeed = true;

    // Token: 0x04001FE1 RID: 8161
    private float curY;

    // Token: 0x04001FE2 RID: 8162
    public float BigMap_maxVerticalAngle = 75f;

    // Token: 0x04001FE3 RID: 8163
    public float BigMap_verticalRotSpeed = 800f;

    // Token: 0x04001FE4 RID: 8164
    public float BigMap_CamDistanceSpeed = 40f;

    // Token: 0x04001FE5 RID: 8165
    public float BigMap_maxVerticalAngleK = 2f;

    // Token: 0x04001FE6 RID: 8166
    private float lastDistance;

    // Token: 0x04001FE7 RID: 8167
    private float lastVerticalAngle;

    // Token: 0x04001FE8 RID: 8168
    private Action<bool> MiddleEvent;

    public void CopyFrom(SmoothFollow2 sf2)
	{
		this.bControl = sf2.bControl;
		this.bInUI = sf2.bInUI;
		this.target = sf2.target;
		this.targetRoot = sf2.targetRoot;
		this.baseHeight = sf2.baseHeight;
		this.height = sf2.height;
		this.damping = sf2.damping;
		this.rotationDamping = sf2.rotationDamping;
		this.CenterOffset = sf2.CenterOffset;
		this.CamDistance = sf2.CamDistance;
		this.fieldOfView = sf2.fieldOfView;
		this.CamPos = sf2.CamPos;
		this.CamRot = sf2.CamRot;
		this.FocalPos = sf2.FocalPos;
		this.LastTargetPos = sf2.LastTargetPos;
		this.LastWantedRotation = sf2.LastWantedRotation;
		this.charCtrl = sf2.charCtrl;
		this.CanScroll = sf2.CanScroll;
		//this.shakeScript = sf2.shakeScript;
		//this.curShakeType = sf2.curShakeType;
		this.HVByLoadArchive = sf2.HVByLoadArchive;
		this.offsetScale = sf2.offsetScale;
		this.TargetCamRot = sf2.TargetCamRot;
		this.bJolt = sf2.bJolt;
		this.lastAngleH = sf2.lastAngleH;
		this.bNeedReturn = sf2.bNeedReturn;
		this.ReturnSpeed = sf2.ReturnSpeed;
		this.bUseLeftReturn = sf2.bUseLeftReturn;
		this.CameraRadius = sf2.CameraRadius;
		this.InsideFun = sf2.InsideFun;
		this.horizontalRotSpeed = sf2.horizontalRotSpeed;
		this.verticalRotSpeed = sf2.verticalRotSpeed;
		this.angleH = sf2.angleH;
		this.angleV = sf2.angleV;
		this.maxVerticalAngle = sf2.maxVerticalAngle;
		this.minVerticalAngle = sf2.minVerticalAngle;
		this.m_maxVerticalAngle = sf2.m_maxVerticalAngle;
		this.m_minVerticalAngle = sf2.m_minVerticalAngle;
		this.TargetCamDistance = sf2.TargetCamDistance;
		this.MaxDistance = sf2.MaxDistance;
		this.MinDistance = sf2.MinDistance;
		this.currentDistance = sf2.currentDistance;
		this.elasticSpeed = sf2.elasticSpeed;
		this.ray = sf2.ray;
		this.cullPlayer = sf2.cullPlayer;
		this.posOrig = sf2.posOrig;
		this.posEnd = sf2.posEnd;
		this.YSpeed = sf2.YSpeed;
		this.UseYSpeed = sf2.UseYSpeed;
		this.curY = sf2.curY;
		this.BigMap_maxVerticalAngle = sf2.BigMap_maxVerticalAngle;
		this.BigMap_verticalRotSpeed = sf2.BigMap_verticalRotSpeed;
		this.BigMap_CamDistanceSpeed = sf2.BigMap_CamDistanceSpeed;
		this.BigMap_maxVerticalAngleK = sf2.BigMap_maxVerticalAngleK;
		this.lastDistance = sf2.lastDistance;
		this.lastVerticalAngle = sf2.lastVerticalAngle;
		this.MiddleEvent = sf2.MiddleEvent;
	}

	public static int IgnoreLayer
	{
		get
		{
			if (SmoothFollow2.ignorelayer < -50)
			{
				SmoothFollow2.ignorelayer = LayerMask.NameToLayer("Ignore Camera Raycast");
			}
			return SmoothFollow2.ignorelayer;
		}
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06001C09 RID: 7177 RVA: 0x000FB3B0 File Offset: 0x000F95B0
	public static int MaskValue
	{
		get
		{
			return SmoothFollow2.maskValue;
		}
	}

	// Token: 0x06001C0A RID: 7178 RVA: 0x000FB3B8 File Offset: 0x000F95B8
	private void Start()
	{
		this.InitTarget();
		SmoothFollow2.maskValue = (1 << SmoothFollow2.IgnoreLayer | 131072 | 262144 | 4 | 524288 | 512);
		SmoothFollow2.maskValue = ~SmoothFollow2.maskValue;
		if (!this.HVByLoadArchive && PlayersManager.Player != null)
		{
			this.InitAngle();
		}
		this.HVByLoadArchive = false;
		//GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.InNormal));
		//GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.OutNormal));
		PlayersManager.OnTabPlayer -= this.OnTabPlayer;
		PlayersManager.OnTabPlayer += this.OnTabPlayer;
	}

	private void OnDestroy()
	{
		//GameStateManager.RemoveInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.InNormal));
		//GameStateManager.RemoveEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.OutNormal));
		PlayersManager.OnTabPlayer -= this.OnTabPlayer;
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x000FB4A8 File Offset: 0x000F96A8
	private void InNormal()
	{
		base.enabled = true;
		this.InitPlayerForward();
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x000FB4B8 File Offset: 0x000F96B8
	private void OutNormal()
	{
		base.enabled = false;
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x000FB4C4 File Offset: 0x000F96C4
	private void OnEnable()
	{
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x000FB4C8 File Offset: 0x000F96C8
	public void Init(GameObject go)
	{
		if (go == null)
		{
			Debug.LogError("SmoothFollow2 Init参数为null");
			return;
		}
		this.targetRoot = go.transform;
		this.target = null;
		this.InitTarget();
		if (!base.enabled)
		{
			base.enabled = true;
		}
		this.ResetData();
	}

	// Token: 0x06001C10 RID: 7184 RVA: 0x000FB520 File Offset: 0x000F9720
	public void InitTarget()
	{
		if (this.targetRoot == null)
		{
			return;
		}
		Transform transform = this.targetRoot;
		Animator componentInChildren = this.targetRoot.GetComponentInChildren<Animator>();
		if (componentInChildren != null)
		{
			transform = componentInChildren.transform;
		}
		this.target = null;
		if (this.target == null)
		{
			this.target = transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 Head");
		}
		if (this.target == null)
		{
			this.target = transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 Head");
		}
		if (this.target == null)
		{
			this.target = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Spine3/Bip001 Neck/Bip001 Head");
		}
		if (this.target == null)
		{
			this.target = transform.Find("Bip001/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 Head");
		}
		if (this.target == null)
		{
			this.target = transform.Find("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Neck/Bip001 Head");
		}
		if (this.target == null)
		{
			this.target = transform.Find("char_astrella_reference/char_astrella_Hips1/char_astrella_Spine/char_astrella_Spine1/char_astrella_Spine2/char_astrella_Neck/char_astrella_Head");
		}
		if (this.target == null)
		{
			this.target = this.FindHead();
		}
		if (this.target == null)
		{
			Debug.LogError("Error : 无法找到 Head");
			return;
		}
		this.curY = this.target.position.y;
		string name = this.targetRoot.name;
		switch (name)
		{
		case "YueJinChao":
			this.baseHeight = 1.559f;
			goto IL_280;
		case "YueQi":
			this.baseHeight = 1.3982f;
			goto IL_280;
		case "XianQing":
			this.baseHeight = 1.6169f;
			goto IL_280;
		case "LuoWenRen":
			this.baseHeight = 1.5489f;
			goto IL_280;
		case "JuShiFang":
			this.baseHeight = 1.5183f;
			goto IL_280;
		case "MingXiu":
			this.baseHeight = 1.4548f;
			goto IL_280;
		}
		this.baseHeight = 1.56f;
		IL_280:
		this.target = this.targetRoot;
		base.GetComponent<Camera>().fieldOfView = this.fieldOfView;
		base.GetComponent<Camera>().nearClipPlane = 0.1f;
		this.CamPos = base.transform.position;
		this.FocalPos = this.target.position;
		//Vector3 lastTargetPos = Util.RelativeMatrix(this.target, this.targetRoot).MultiplyPoint(Vector3.zero);
		//this.LastTargetPos = lastTargetPos;
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x000FB824 File Offset: 0x000F9A24
	public void InitAngle()
	{
		//this.CamAngleH = PlayersManager.Player.GetModelObj(true).transform.eulerAngles.y;
		this.CamAngleV = 10f;
		this.LateUpdate();
		PlayerCtrlManager.LastForward = base.transform.forward;
	}

	// Token: 0x06001C12 RID: 7186 RVA: 0x000FB878 File Offset: 0x000F9A78
	public void InitPlayerForward()
	{
		this.LateUpdate();
		PlayerCtrlManager.LastForward = base.transform.forward;
	}

	// Token: 0x06001C13 RID: 7187 RVA: 0x000FB890 File Offset: 0x000F9A90
	public void ResetData()
	{
		this.YSpeed = 5f;
		this.CameraRadius = SmoothFollow2.CameraRadiusDefault;
		this.horizontalRotSpeed = 170f;
		this.verticalRotSpeed = 250f;
		this.rotationDamping = 100000000f;
	}

	// Token: 0x06001C14 RID: 7188 RVA: 0x000FB8CC File Offset: 0x000F9ACC
	private void LateUpdate()
	{
		if (this.target == null)
		{
			return;
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
		{
			SmoothFollow2.LeftCameraMove = false;
			SmoothFollow2.lastMousePos = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0) && Vector3.SqrMagnitude(Input.mousePosition - SmoothFollow2.lastMousePos) > 4f)
		{
			SmoothFollow2.LeftCameraMove = true;
		}
		//if (UICamera.hoveredObject != null && (InputManager.GetKeyDown(KEY_ACTION.MOUSE_LEFT, false) || InputManager.GetKeyDown(KEY_ACTION.MOUSE_RIGHT, false)))
		//{
		//	this.bInUI = true;
		//}
		if (this.bInUI && (InputManager.GetKeyUp(KEY_ACTION.MOUSE_LEFT, false) || InputManager.GetKeyUp(KEY_ACTION.MOUSE_RIGHT, false)))
		{
			this.bInUI = false;
		}
		if (this.InsideFun != null)
		{
			this.InsideFun();
			return;
		}
		Vector3 position = Vector3.zero;
		//if (this.curShakeType != ShakeType.None)
		//{
		//	position = base.transform.position;
		//	base.transform.position = this.CamPos;
		//}
		if (this.bControl && !this.bInUI)
		{
			if (this.CanScroll)
			{
				this.TargetCamDistance = this.GetTargetCamDistance();
				this.CamDistance = this.TargetCamDistance;
			}
			this.AdjustFOV(this.CamDistance);
			if (InputManager.GetKey(KEY_ACTION.CAMERA_LEFT, false))
			{
				this.CamAngleH -= this.horizontalRotSpeed * Time.smoothDeltaTime;
			}
			else if (InputManager.GetKey(KEY_ACTION.CAMERA_RIGHT, false))
			{
				this.CamAngleH += this.horizontalRotSpeed * Time.smoothDeltaTime;
			}
			if (Input.GetMouseButton(1))
			{
				this.GetHV();
				this.bNeedReturn = false;
			}
			else if (Input.GetMouseButton(0))
			{
				this.GetHV();
			}
			if (this.bUseLeftReturn)
			{
				if (Input.GetMouseButtonDown(0))
				{
					if (!this.bNeedReturn)
					{
						this.lastAngleH = this.CamAngleH;
					}
					this.bNeedReturn = false;
				}
				else if (Input.GetMouseButtonUp(0))
				{
					this.bNeedReturn = true;
				}
				if (this.bNeedReturn)
				{
					this.CamAngleH = Mathf.LerpAngle(this.CamAngleH, this.lastAngleH, Time.deltaTime * this.ReturnSpeed);
					if (Mathf.Abs(this.CamAngleH - this.lastAngleH) < 0.5f)
					{
						this.bNeedReturn = false;
					}
				}
			}
			if (this.bJolt)
			{
				this.MakeJolt();
			}
			this.TargetCamRot = Quaternion.Euler(this.angleV, this.CamAngleH, 0f);
			this.CamRot = Quaternion.Lerp(this.CamRot, this.TargetCamRot, Time.deltaTime * this.rotationDamping);
		}
		this.FocalPos = this.GetLookAtPos(this.UseYSpeed);
		this.CamPos = this.FocalPos + this.CamRot * this.CenterOffset * this.CamDistance;
		this.CheckForCollision(ref this.CamPos, this.FocalPos, 0f, this.CameraRadius);
		//if (this.curShakeType != ShakeType.None)
		//{
		//	if (this.shakeScript != null)
		//	{
		//		this.shakeScript.referPos = this.CamPos;
		//	}
		//	base.transform.position = position;
		//}
		//else
		//{
		//	base.transform.position = this.CamPos;
		//}
		base.transform.rotation = this.CamRot;
		SmoothFollow2.CastRay(base.GetComponent<Camera>());
	}

	// Token: 0x06001C15 RID: 7189 RVA: 0x000FBC60 File Offset: 0x000F9E60
	public void AdjustFOV()
	{
		this.AdjustFOV((base.transform.position - this.GetLookAtPos(false)).magnitude);
	}

	// Token: 0x06001C16 RID: 7190 RVA: 0x000FBC94 File Offset: 0x000F9E94
	public void AdjustFOV(float camDis)
	{
		float t = (camDis - this.MinDistance) / (this.MaxDistance - this.MinDistance);
		float num = Mathf.Lerp(this.FOV_Range.x, this.FOV_Range.y, t);
		if (base.GetComponent<Camera>().fieldOfView != num)
		{
			base.GetComponent<Camera>().fieldOfView = num;
		}
	}

	// Token: 0x06001C17 RID: 7191 RVA: 0x000FBCF4 File Offset: 0x000F9EF4
	public void SetCurCamera()
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		this.angleV = eulerAngles.x;
		this.CamAngleH = eulerAngles.y;
		this.TargetCamDistance = (this.CamDistance = (base.transform.position - this.GetLookAtPos(false)).magnitude);
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x000FBD60 File Offset: 0x000F9F60
	public static void CastRay(Camera camera)
	{
	}

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06001C19 RID: 7193 RVA: 0x000FBD64 File Offset: 0x000F9F64
	// (set) Token: 0x06001C1A RID: 7194 RVA: 0x000FBD6C File Offset: 0x000F9F6C
	public float CamAngleH
	{
		get
		{
			return this.angleH;
		}
		set
		{
			this.angleH = value;
		}
	}

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06001C1B RID: 7195 RVA: 0x000FBD78 File Offset: 0x000F9F78
	// (set) Token: 0x06001C1C RID: 7196 RVA: 0x000FBD80 File Offset: 0x000F9F80
	public float CamAngleV
	{
		get
		{
			return this.angleV;
		}
		set
		{
			this.angleV = value;
		}
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x000FBD8C File Offset: 0x000F9F8C
	private Quaternion GetTargetCamRot()
	{
		this.CamAngleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f) * this.horizontalRotSpeed * Time.smoothDeltaTime;
		this.angleV -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -1f, 1f) * this.verticalRotSpeed * Time.smoothDeltaTime;
		this.angleV = Mathf.Clamp(this.angleV, this.m_minVerticalAngle, this.m_maxVerticalAngle);
		return Quaternion.Euler(this.angleV, this.CamAngleH, 0f);
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x000FBE34 File Offset: 0x000FA034
	private void GetHV()
	{
		this.CamAngleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f) * this.horizontalRotSpeed * Time.smoothDeltaTime;
		this.angleV -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -1f, 1f) * this.verticalRotSpeed * Time.smoothDeltaTime;
		if (this.angleV < -270f)
		{
			this.angleV += 360f;
		}
		this.angleV = Mathf.Clamp(this.angleV, this.m_minVerticalAngle, this.m_maxVerticalAngle);
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x000FBEE8 File Offset: 0x000FA0E8
	private void MakeJolt()
	{
		//Vector3 vector = Util.RelativeMatrix(this.target, this.targetRoot).MultiplyPoint(Vector3.zero);
		//Vector3 vector2 = vector - this.LastTargetPos;
		//vector2.x *= this.offsetScale.x;
		//vector2.y *= this.offsetScale.y;
		//vector2.z *= this.offsetScale.z;
		//this.LastTargetPos = vector;
		Vector3 vector3 = new Vector3(0f, 0f, this.CamDistance);
		//vector2 *= this.CamDistance;
		//Quaternion quaternion = Quaternion.FromToRotation(vector3, vector3 + vector2);
		//float num = quaternion.eulerAngles.x;
		//if (num > 350f)
		//{
		//	num -= 360f;
		//}
		//this.angleV -= num;
		//this.CamAngleH += quaternion.eulerAngles.y;
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x000FBFFC File Offset: 0x000FA1FC
	private float GetTargetCamDistance()
	{
		return Mathf.Clamp(this.TargetCamDistance - Input.GetAxis("Mouse ScrollWheel"), this.MinDistance, this.MaxDistance);
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x000FC030 File Offset: 0x000FA230
	private void CheckForCollision(ref Vector3 posEnd, Vector3 posOrig, float OrigR, float radius)
	{
		this.posEnd = posEnd;
		this.posOrig = posOrig;
		Vector3 direction = posEnd - posOrig;
		this.ray.origin = posOrig;
		this.ray.direction = direction;
		RaycastHit raycastHit;
		if (Physics.SphereCast(this.ray, radius, out raycastHit, direction.magnitude, SmoothFollow2.maskValue))
		{
			if (this.currentDistance < raycastHit.distance)
			{
				this.currentDistance = Mathf.Clamp(this.currentDistance + this.elasticSpeed * Time.deltaTime, this.currentDistance, raycastHit.distance);
			}
			else
			{
				this.currentDistance = raycastHit.distance;
			}
		}
		else if (this.currentDistance < this.CamDistance)
		{
			this.currentDistance = Mathf.Clamp(this.currentDistance + this.elasticSpeed * Time.deltaTime, this.currentDistance, this.CamDistance);
		}
		else
		{
			this.currentDistance = this.CamDistance;
		}
		posEnd = this.FocalPos + this.CamRot * this.CenterOffset * this.currentDistance;
		//GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		//if (modelObj == null)
		//{
		//	return;
		//}
		//CharacterController component = modelObj.GetComponent<CharacterController>();
		//if (!this.cullPlayer && this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		//{
		//	//modelObj.SetVisible(false);
		//	this.cullPlayer = true;
		//}
		//else if (this.cullPlayer && this.currentDistance > component.radius + base.GetComponent<Camera>().nearClipPlane)
		//{
		//	//modelObj.SetVisible(true);
		//	this.cullPlayer = false;
		//}
	}

	// Token: 0x06001C22 RID: 7202 RVA: 0x000FC1F4 File Offset: 0x000FA3F4
	private void CheckNearClipPlane()
	{
		//GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		//if (modelObj == null)
		//{
		//	return;
		//}
		//CharacterController component = modelObj.GetComponent<CharacterController>();
		//if (this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		//{
		//	//modelObj.SetVisible(false);
		//	this.cullPlayer = true;
		//}
		//else
		//{
		//	//modelObj.SetVisible(true);
		//	this.cullPlayer = false;
		//}
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x000FC260 File Offset: 0x000FA460
	private void OnTabPlayer(int i)
	{
		if (base.GetComponent<Camera>() == null)
		{
			Debug.LogError("Error : SmoothFollow2.OnTabPlayer camera == null");
			return;
		}
		//GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		//CharacterController component = modelObj.GetComponent<CharacterController>();
		//if (this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		//{
		//	modelObj.SetVisible(false);
		//	this.cullPlayer = true;
		//}
		//else if (this.currentDistance > component.radius + base.GetComponent<Camera>().nearClipPlane)
		//{
		//	modelObj.SetVisible(true);
		//	this.cullPlayer = false;
		//}
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x000FC2F8 File Offset: 0x000FA4F8
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(this.posOrig, this.posEnd);
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x000FC318 File Offset: 0x000FA518
	private Transform FindHead()
	{
		foreach (Transform transform in this.targetRoot.GetComponentsInChildren<Transform>())
		{
			if (transform.name.ToLower().Contains("head") && transform.name.ToLower() != "b head")
			{
				return transform;
			}
		}
		foreach (Transform transform2 in this.targetRoot.GetComponentsInChildren<Transform>())
		{
			if (transform2.name.ToLower().Contains("Focus"))
			{
				return transform2;
			}
		}
		return this.targetRoot;
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x000FC3D0 File Offset: 0x000FA5D0
	public Vector3 GetLookAtPos(bool bLerp = false)
	{
		Vector3 position = this.target.position;
		position.y += this.baseHeight + this.height;
		if (bLerp)
		{
			this.curY = Mathf.Lerp(this.curY, position.y, Time.deltaTime * this.YSpeed);
			position.y = this.curY;
		}
		return position;
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x000FC43C File Offset: 0x000FA63C
	private void BaseCalculate()
	{
		this.TargetCamRot = Quaternion.Euler(this.angleV, this.CamAngleH, 0f);
		this.CamRot = Quaternion.Lerp(this.CamRot, this.TargetCamRot, Time.deltaTime * this.rotationDamping);
		this.FocalPos = this.target.position;
		this.FocalPos.y = this.FocalPos.y + (this.baseHeight + this.height);
		this.CamPos = this.FocalPos + this.CamRot * this.CenterOffset * this.CamDistance;
		base.transform.position = this.CamPos;
		base.transform.rotation = this.CamRot;
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x000FC508 File Offset: 0x000FA708
	public void BeginMoveToMap()
	{
		this.lastVerticalAngle = this.angleV;
		this.lastDistance = this.CamDistance;
		this.InsideFun = new Action(this.ToBigMapCorePartA);
		//CtrlScreenBlend.Blend(BigMap.Instance.CurCamera, 2.2222223f, 45f, false, false, new Action(this.BlendFinishA), false);
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x000FC568 File Offset: 0x000FA768
	private void ToBigMapCorePartA()
	{
		if (this.angleV < this.BigMap_maxVerticalAngle)
		{
			this.angleV += this.BigMap_verticalRotSpeed * Time.smoothDeltaTime;
		}
		else
		{
			if (this.MiddleEvent != null)
			{
				this.MiddleEvent(true);
				this.MiddleEvent = null;
			}
			this.CamDistance += this.BigMap_CamDistanceSpeed * Time.deltaTime;
		}
		this.BaseCalculate();
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x000FC5E4 File Offset: 0x000FA7E4
	private void BlendFinishA()
	{
		base.enabled = false;
		this.InsideFun = null;
	}

	// Token: 0x06001C2B RID: 7211 RVA: 0x000FC5F4 File Offset: 0x000FA7F4
	public void BeginMoveToGround()
	{
		this.InsideFun = new Action(this.ToBigMapCorePartB);
		base.enabled = true;
		//CtrlScreenBlend.Blend(BigMap.Instance.CurCamera, 2.2222223f, 45f, true, false, new Action(this.BlendFinishB), false);
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x000FC644 File Offset: 0x000FA844
	private void ToBigMapCorePartB()
	{
		if (this.CamDistance > this.lastDistance)
		{
			this.CamDistance -= this.BigMap_CamDistanceSpeed * Time.deltaTime;
		}
		else if (this.angleV > this.lastVerticalAngle)
		{
			this.angleV -= this.BigMap_verticalRotSpeed * this.BigMap_maxVerticalAngleK * Time.smoothDeltaTime;
		}
		this.BaseCalculate();
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x000FC6B8 File Offset: 0x000FA8B8
	private void BlendFinishB()
	{
		this.InsideFun = null;
	}

	// Token: 0x06001C2E RID: 7214 RVA: 0x000FC6C4 File Offset: 0x000FA8C4
	public void Save(BinaryWriter writer)
	{
		writer.Write(this.CamDistance);
		writer.Write(this.CamAngleH);
		writer.Write(this.angleV);
		writer.Write(this.CamPos.x);
		writer.Write(this.CamPos.y);
		writer.Write(this.CamPos.z);
		writer.Write(this.CamRot.x);
		writer.Write(this.CamRot.y);
		writer.Write(this.CamRot.z);
		writer.Write(this.CamRot.w);
	}

	public void Load(BinaryReader reader)
	{
		//if (SaveManager.VersionNum >= 14u)
		//{
		//	this.HVByLoadArchive = true;
		//	this.CamDistance = reader.ReadSingle();
		//	this.CamAngleH = reader.ReadSingle();
		//	this.angleV = reader.ReadSingle();
		//	this.CamPos.x = reader.ReadSingle();
		//	this.CamPos.y = reader.ReadSingle();
		//	this.CamPos.z = reader.ReadSingle();
		//	this.CamRot.x = reader.ReadSingle();
		//	this.CamRot.y = reader.ReadSingle();
		//	this.CamRot.z = reader.ReadSingle();
		//	this.CamRot.w = reader.ReadSingle();
		//	this.lastAngleH = this.CamAngleH;
		//	this.TargetCamRot = this.CamRot;
		//	this.bNeedReturn = false;
		//	this.LateUpdate();
		//	this.CheckNearClipPlane();
		//	PlayerCtrlManager.LastForward = base.transform.forward;
		//}
	}
}
