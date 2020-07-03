using SoftStar.Pal6;
using System;
using System.IO;
using UnityEngine;
using YouYou;

public class SmoothFollow2 : MonoBehaviour, ISaveInterface
{
	public bool bControl = true;

	public Transform target;

	public Transform targetRoot;

	private float baseHeight = 1.6f;

	public float height;

	public float damping = 5f;

	public float rotationDamping = 1E+08f;

	public Vector3 CenterOffset = new Vector3(0f, 0f, -1f);

	public float CamDistance = 1f;

	public float fieldOfView = 45f;

	[HideInInspector]
	[NonSerialized]
	public Vector3 CamPos;

	public Quaternion CamRot = new Quaternion(0f, 0f, 0f, 1f);

	private Vector3 FocalPos;

	private Vector3 LastTargetPos;

	private Quaternion LastWantedRotation = new Quaternion(0f, 0f, 0f, 1f);

	private CharacterController charCtrl;

	private static int ignorelayer = -100;

	private static int maskValue = -1;

	public bool CanScroll = true;

    //public PalShake shakeScript;

    //public ShakeType curShakeType;

    public static bool LeftCameraMove = false;

	private static Vector3 lastMousePos = Vector3.zero;

	private bool HVByLoadArchive;

	public Vector3 offsetScale = new Vector3(1f, 0.23f, 1f);

	public Quaternion TargetCamRot = new Quaternion(0f, 0f, 0f, 1f);

	public bool bJolt = true;

	[HideInInspector]
	[NonSerialized]
	public float lastAngleH;

	public bool bNeedReturn;

	public float ReturnSpeed = 2f;

    private bool bUseLeftReturn;

    public float CameraRadius = 0.13f;

	public static float CameraRadiusDefault = 0.16f;

	public Vector2 FOV_Range = new Vector2(35f, 60f);

    /// <summary>
    /// 内部 应该是控制大小
    /// </summary>
	public Action InsideFun;

	private static string guiDisplayStr;

	public static RaycastHit mouseHit;

	public static GameObject mouseHitObject = null;

	public float horizontalRotSpeed = 200f;

	public float verticalRotSpeed = 250f;

	private float angleH;

	private float angleV;

	public float maxVerticalAngle = 60f;

	public float minVerticalAngle = -55f;

	private float m_maxVerticalAngle = 60f;

	private float m_minVerticalAngle = -55f;

	private float TargetCamDistance = 6f;

	public float MaxDistance = 12.3f;

	public float MinDistance = 0.8f;

	private float currentDistance = 5f;

	public float elasticSpeed = 4f;

	private Ray ray = new Ray(Vector3.zero, Vector3.zero);

	private bool cullPlayer;

	private Vector3 posOrig;

	private Vector3 posEnd;

	public float YSpeed = 5f;

	public bool UseYSpeed = true;

	private float curY;

	public float BigMap_maxVerticalAngle = 75f;

	public float BigMap_verticalRotSpeed = 800f;

	public float BigMap_CamDistanceSpeed = 40f;

	public float BigMap_maxVerticalAngleK = 2f;

	private float lastDistance;

	private float lastVerticalAngle;

	private Action<bool> MiddleEvent;

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

	public static int MaskValue
	{
		get
		{
			return SmoothFollow2.maskValue;
		}
	}

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
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.EnterProcedureWorldMap, InNormal);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.LeaveProcedureWorldMap, OutNormal);
        //////GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.InNormal));
        //////GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.OutNormal));
        //PlayersManager.OnTabPlayer -= new Action<int>(this.OnTabPlayer);
        //PlayersManager.OnTabPlayer += new Action<int>(this.OnTabPlayer);
    }

    private void OnDestroy()
	{
		//GameStateManager.RemoveInitStateFun(GameState.Normal, new GameStateManager.void_fun(this.InNormal));
		//GameStateManager.RemoveEndStateFun(GameState.Normal, new GameStateManager.void_fun(this.OutNormal));
		PlayersManager.OnTabPlayer -= new Action<int>(this.OnTabPlayer);
	}

	private void InNormal(object userData)
	{
		base.enabled = true;
		this.InitPlayerForward();
	}

	private void OutNormal(object userData)
	{
		base.enabled = false;
	}

	private void OnEnable()
	{
	}

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

    /// <summary>
    /// 初始化目标
    /// </summary>
	public void InitTarget()
	{
		if (this.targetRoot == null)
		{
			return;
		}
        //this.curY = this.target.position.y;
        this.baseHeight = 1.56f;
        this.target = this.targetRoot;
        base.GetComponent<Camera>().fieldOfView = this.fieldOfView;
        base.GetComponent<Camera>().nearClipPlane = 0.1f;
        this.CamPos = base.transform.position;
        this.FocalPos = this.target.position;
        Vector3 lastTargetPos = Util.RelativeMatrix(this.target, this.targetRoot).MultiplyPoint(Vector3.zero);
        this.LastTargetPos = lastTargetPos;
    }

    public void InitAngle()
	{
		this.CamAngleH = PlayersManager.Player.GetModelObj(true).transform.eulerAngles.y;
		this.CamAngleV = 10f;
		this.LateUpdate();
		PlayerCtrlManager.LastForward = base.transform.forward;
	}

	public void InitPlayerForward()
	{
		this.LateUpdate();
		PlayerCtrlManager.LastForward = base.transform.forward;
	}

	public void ResetData()
	{
		this.YSpeed = 5f;
		this.CameraRadius = SmoothFollow2.CameraRadiusDefault;
		this.horizontalRotSpeed = 170f;
		this.verticalRotSpeed = 250f;
		this.rotationDamping = 1E+08f;
	}

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

        if (this.InsideFun != null)
        {
            this.InsideFun();
            return;
        }

        //Vector3 position = Vector3.zero;
        //if (this.curShakeType != ShakeType.None)
        //{
        //    position = base.transform.position;
        //    base.transform.position = this.CamPos;
        //}

        if (this.bControl)
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

            if (this.bUseLeftReturn)//左键旋转会返回
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
        ////if (this.curShakeType != ShakeType.None)
        ////{
        ////	if (this.shakeScript != null)
        ////	{
        ////		this.shakeScript.referPos = this.CamPos;
        ////	}
        //	base.transform.position = position;
        ////}
        ////else
        ////{
        base.transform.position = this.CamPos;
        ////}
        base.transform.rotation = this.CamRot;
    }

	public void AdjustFOV()
	{
		this.AdjustFOV((base.transform.position - this.GetLookAtPos(false)).magnitude);
	}

    /// <summary>
    /// 调整FOV
    /// </summary>
    /// <param name="camDis"></param>
	public void AdjustFOV(float camDis)
	{
		float t = (camDis - this.MinDistance) / (this.MaxDistance - this.MinDistance);
		float num = Mathf.Lerp(this.FOV_Range.x, this.FOV_Range.y, t);
		if (base.GetComponent<Camera>().fieldOfView != num)
		{
			base.GetComponent<Camera>().fieldOfView = num;
		}
	}

	public void SetCurCamera()
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		this.angleV = eulerAngles.x;
		this.CamAngleH = eulerAngles.y;
		this.TargetCamDistance = (this.CamDistance = (base.transform.position - this.GetLookAtPos(false)).magnitude);
	}

	private Quaternion GetTargetCamRot()
	{
		this.CamAngleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f) * this.horizontalRotSpeed * Time.smoothDeltaTime;
		this.angleV -= Mathf.Clamp(Input.GetAxis("Mouse Y"), -1f, 1f) * this.verticalRotSpeed * Time.smoothDeltaTime;
		this.angleV = Mathf.Clamp(this.angleV, this.m_minVerticalAngle, this.m_maxVerticalAngle);
		return Quaternion.Euler(this.angleV, this.CamAngleH, 0f);
	}

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

    /// <summary>
    ///制造摇晃
    /// </summary>
	private void MakeJolt()
	{
        Vector3 vector = Util.RelativeMatrix(this.target, this.targetRoot).MultiplyPoint(Vector3.zero);
        Vector3 vector2 = vector - this.LastTargetPos;
        vector2.x *= this.offsetScale.x;
        vector2.y *= this.offsetScale.y;
        vector2.z *= this.offsetScale.z;
        this.LastTargetPos = vector;
        Vector3 vector3 = new Vector3(0f, 0f, this.CamDistance);
        vector2 *= this.CamDistance;
        Quaternion quaternion = Quaternion.FromToRotation(vector3, vector3 + vector2);
        float num = quaternion.eulerAngles.x;
        if (num > 350f)
        {
            num -= 360f;
        }
        this.angleV -= num;
        this.CamAngleH += quaternion.eulerAngles.y;
    }

    /// <summary>
    /// 获取目标摄像机距离
    /// </summary>
    /// <returns></returns>
	private float GetTargetCamDistance()
	{
		return Mathf.Clamp(this.TargetCamDistance - Input.GetAxis("Mouse ScrollWheel"), this.MinDistance, this.MaxDistance);
	}

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
		GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		if (modelObj == null)
		{
			return;
		}
		CharacterController component = modelObj.GetComponent<CharacterController>();
		if (!this.cullPlayer && this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		{
			modelObj.SetVisible(false);
			this.cullPlayer = true;
		}
		else if (this.cullPlayer && this.currentDistance > component.radius + base.GetComponent<Camera>().nearClipPlane)
		{
			modelObj.SetVisible(true);
			this.cullPlayer = false;
		}
	}

	private void CheckNearClipPlane()
	{
		GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		if (modelObj == null)
		{
			return;
		}
		CharacterController component = modelObj.GetComponent<CharacterController>();
		if (this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		{
			modelObj.SetVisible(false);
			this.cullPlayer = true;
		}
		else
		{
			modelObj.SetVisible(true);
			this.cullPlayer = false;
		}
	}

	private void OnTabPlayer(int i)
	{
		if (base.GetComponent<Camera>() == null)
		{
			Debug.LogError("Error : SmoothFollow2.OnTabPlayer camera == null");
			return;
		}
		GameObject modelObj = PlayersManager.Player.GetModelObj(false);
		CharacterController component = modelObj.GetComponent<CharacterController>();
		if (this.currentDistance <= component.radius + base.GetComponent<Camera>().nearClipPlane)
		{
			modelObj.SetVisible(false);
			this.cullPlayer = true;
		}
		else if (this.currentDistance > component.radius + base.GetComponent<Camera>().nearClipPlane)
		{
			modelObj.SetVisible(true);
			this.cullPlayer = false;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(this.posOrig, this.posEnd);
	}

	private Transform FindHead()
	{
		Transform[] componentsInChildren = this.targetRoot.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Transform transform = componentsInChildren[i];
			if (transform.name.ToLower().Contains("head") && transform.name.ToLower() != "b head")
			{
				return transform;
			}
		}
		Transform[] componentsInChildren2 = this.targetRoot.GetComponentsInChildren<Transform>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			Transform transform2 = componentsInChildren2[j];
			if (transform2.name.ToLower().Contains("Focus"))
			{
				return transform2;
			}
		}
		return this.targetRoot;
	}

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

	public void BeginMoveToMap()
	{
		this.lastVerticalAngle = this.angleV;
		this.lastDistance = this.CamDistance;
		this.InsideFun = new Action(this.ToBigMapCorePartA);
		//CtrlScreenBlend.Blend(BigMap.Instance.CurCamera, 2.22222233f, 45f, false, false, new Action(this.BlendFinishA), false);
	}

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

	private void BlendFinishA()
	{
		base.enabled = false;
		this.InsideFun = null;
	}

	public void BeginMoveToGround()
	{
		this.InsideFun = new Action(this.ToBigMapCorePartB);
		base.enabled = true;
		//CtrlScreenBlend.Blend(BigMap.Instance.CurCamera, 2.22222233f, 45f, true, false, new Action(this.BlendFinishB), false);
	}

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

	private void BlendFinishB()
	{
		this.InsideFun = null;
	}

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
