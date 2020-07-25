using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameInputManager : ManagerBase, IDisposable
{
	private static Dictionary<KEY_ACTION, KeyCode> GameKeyList = new Dictionary<KEY_ACTION, KeyCode>();

	private static float m_DirKeySpeed = 6f;

	private static Vector3 m_MoveDir = Vector3.zero;

	private static Vector2 m_DPadDir = Vector2.zero;

	private static bool[] m_DirKeyUP = new bool[4];

	private static bool m_FirstPress = false;

	private static float m_FirstWaitTime = 0.5f;

	private static float m_PressTime = 0f;

	private static bool m_DelayInput = false;

	private static float m_DelayTime = 0f;

	public static bool m_IsKeyInput = false;

	public static bool m_IsDelayPress = true;

	private static bool m_IsPressDPad = false;

	public static bool m_IsFuuscreen = false;

	public static bool m_IsJoyPad = true;

	private static bool m_IsLTrigger = false;

	private static bool m_IsRTrigger = false;

	private static bool m_Initialize = false;

	public bool KeyInput
	{
		get
		{
			return GameInputManager.m_IsKeyInput;
		}
		set
		{
            GameInputManager.m_IsKeyInput = value;
		}
	}

	public static bool FullScreen
	{
		get
		{
			return GameInputManager.m_IsFuuscreen;
		}
		set
		{
			GameInputManager.m_IsFuuscreen = value;
		}
	}

	public static bool JoyStick
	{
		get
		{
			return GameInputManager.m_IsJoyPad;
		}
		set
		{
			GameInputManager.m_IsJoyPad = value;
		}
	}

    public GameInputManager()
    {

    }

    public override void Init()
    {
        GameInputManager.InitDefalutKeyMapping();
        GameInputManager.m_Initialize = true;
    }

	public static void InitDefalutKeyMapping()
	{
		GameInputManager.GameKeyList.Clear();
		GameInputManager.GameKeyList.Add(KEY_ACTION.UPARROW, KeyCode.UpArrow);
		GameInputManager.GameKeyList.Add(KEY_ACTION.DOWNARROW, KeyCode.DownArrow);
		GameInputManager.GameKeyList.Add(KEY_ACTION.LEFTARROW, KeyCode.LeftArrow);
		GameInputManager.GameKeyList.Add(KEY_ACTION.RIGHTARROW, KeyCode.RightArrow);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CONFIRM, KeyCode.Return);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CANCEL, KeyCode.Escape);
		GameInputManager.GameKeyList.Add(KEY_ACTION.TAB, KeyCode.Tab);
		GameInputManager.GameKeyList.Add(KEY_ACTION.ACTION, KeyCode.F);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_UP, KeyCode.Equals);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_DOWN, KeyCode.Minus);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_LEFT, KeyCode.Q);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_RIGHT, KeyCode.E);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_IN, KeyCode.RightBracket);
		GameInputManager.GameKeyList.Add(KEY_ACTION.CAMERA_OUT, KeyCode.LeftBracket);
		GameInputManager.GameKeyList.Add(KEY_ACTION.ROLE_LEFT, KeyCode.Comma);
		GameInputManager.GameKeyList.Add(KEY_ACTION.ROLE_RIGHT, KeyCode.Period);
		GameInputManager.GameKeyList.Add(KEY_ACTION.MENU, KeyCode.Escape);
		GameInputManager.GameKeyList.Add(KEY_ACTION.MAP, KeyCode.M);
		GameInputManager.GameKeyList.Add(KEY_ACTION.SCREENSHOT, KeyCode.P);
		GameInputManager.GameKeyList.Add(KEY_ACTION.QSAVE, KeyCode.F9);
		GameInputManager.GameKeyList.Add(KEY_ACTION.QLOAD, KeyCode.F10);
		GameInputManager.GameKeyList.Add(KEY_ACTION.UP, KeyCode.W);
		GameInputManager.GameKeyList.Add(KEY_ACTION.DOWN, KeyCode.S);
		GameInputManager.GameKeyList.Add(KEY_ACTION.LEFT, KeyCode.A);
		GameInputManager.GameKeyList.Add(KEY_ACTION.RIGHT, KeyCode.D);
	}

	public void Clear()
	{
		GameInputManager.m_MoveDir = Vector3.zero;
		for (int i = 0; i < 4; i++)
		{
			GameInputManager.m_DirKeyUP[i] = false;
		}
	}

	public static Dictionary<KEY_ACTION, KeyCode> GetKeyList()
	{
		return GameInputManager.GameKeyList;
	}

	public static void DelayInput(bool bDelay)
	{
		if (bDelay)
		{
			GameInputManager.m_DelayTime = 1f;
		}
		else
		{
			GameInputManager.m_DelayTime = 0f;
		}
		GameInputManager.m_DelayInput = bDelay;
	}

	public static bool GetKeyDown(KeyCode key)
	{
		return !GameInputManager.IsDelayInput() && Input.GetKeyDown(key);
	}

	public bool GetKey(KeyCode key)
	{
		if (!GameInputManager.m_IsDelayPress)
		{
			return Input.GetKey(key);
		}
		if (Input.GetKey(key))
		{
			GameInputManager.m_IsKeyInput = true;
			if (!GameInputManager.m_FirstPress)
			{
				GameInputManager.m_FirstWaitTime = 0.5f;
				GameInputManager.m_FirstPress = true;
				return true;
			}
			GameInputManager.m_PressTime += Time.deltaTime;
			if (GameInputManager.m_FirstWaitTime > 0f)
			{
				GameInputManager.m_FirstWaitTime -= Time.deltaTime;
				if (GameInputManager.m_FirstWaitTime < 0f)
				{
					GameInputManager.m_FirstWaitTime = 0f;
				}
			}
			else if (GameInputManager.m_PressTime > 0.05f)
			{
				GameInputManager.m_PressTime = 0f;
				return true;
			}
		}
		return false;
	}

	public static float GetAxis(string name)
	{
		float axis = Input.GetAxis(name);
		if (axis != 0f)
		{
			GameInputManager.m_IsKeyInput = true;
			if (!GameInputManager.m_FirstPress)
			{
				GameInputManager.m_FirstWaitTime = 0.5f;
				GameInputManager.m_FirstPress = true;
				return axis;
			}
			GameInputManager.m_PressTime += Time.deltaTime;
			if (GameInputManager.m_FirstWaitTime > 0f)
			{
				GameInputManager.m_FirstWaitTime -= Time.deltaTime;
				if (GameInputManager.m_FirstWaitTime < 0f)
				{
					GameInputManager.m_FirstWaitTime = 0f;
				}
			}
			else if (GameInputManager.m_PressTime > 0.05f)
			{
				GameInputManager.m_PressTime = 0f;
				return axis;
			}
		}
		return 0f;
	}

	public static bool GetKeyUp()
	{
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.UP) || GameInputManager.GetKeyActionUp(KEY_ACTION.UPARROW))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.DOWN) || GameInputManager.GetKeyActionUp(KEY_ACTION.DOWNARROW))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.LEFT) || GameInputManager.GetKeyActionUp(KEY_ACTION.LEFTARROW))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.RIGHT) || GameInputManager.GetKeyActionUp(KEY_ACTION.RIGHTARROW))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.PageUp))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.PageDown))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Home))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.End))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Return))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			GameInputManager.m_PressTime = 0f;
			GameInputManager.m_FirstPress = false;
		}
		if (Input.GetMouseButtonDown(0))
		{
			GameInputManager.m_IsKeyInput = false;
		}
		return !GameInputManager.m_FirstPress;
	}

	public static void Update()
	{
		GameInputManager.GetDirKeyUp();
		GameInputManager.GetKeyUp();
	}

	public static bool IsDelayInput()
	{
		if (!GameInputManager.m_DelayInput)
		{
			return false;
		}
		GameInputManager.m_DelayTime -= Time.deltaTime;
		if (GameInputManager.m_DelayTime <= 0f)
		{
			GameInputManager.m_DelayTime = 0f;
			GameInputManager.m_DelayInput = false;
			return false;
		}
		return true;
	}

	public static void SetMappingKey(KEY_ACTION keyIndex, KeyCode keyCode)
	{
		if (!GameInputManager.GameKeyList.ContainsKey(keyIndex))
		{
			GameInputManager.GameKeyList.Add(keyIndex, keyCode);
		}
		else
		{
			GameInputManager.GameKeyList[keyIndex] = keyCode;
		}
	}

	public static KeyCode GetMappingKey(KEY_ACTION keyIndex)
	{
		if (!GameInputManager.GameKeyList.ContainsKey(keyIndex))
		{
			return KeyCode.None;
		}
		return GameInputManager.GameKeyList[keyIndex];
	}

	public bool GetKeyAction(KEY_ACTION key)
	{
		return GameInputManager.m_Initialize && !GameInputManager.IsDelayInput() && this.GetKey(GameInputManager.GameKeyList[key]);
	}

	public bool GetKeyActionPress(KEY_ACTION key)
	{
		return GameInputManager.m_Initialize && !GameInputManager.IsDelayInput() && (Input.GetKey(GameInputManager.GameKeyList[key]));
	}

	public bool GetKeyActionDown(KEY_ACTION key)
	{
		return GameInputManager.m_Initialize && !GameInputManager.IsDelayInput() && (GameInputManager.GetKeyDown(GameInputManager.GameKeyList[key]));
	}

	public static bool GetKeyActionUp(KEY_ACTION key)
	{
		return Input.GetKeyUp(GameInputManager.GameKeyList[key]);
	}

	public static void GetDirKeyUp()
	{
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.UP) || GameInputManager.GetKeyActionUp(KEY_ACTION.UPARROW))
		{
			GameInputManager.m_DirKeyUP[0] = true;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.DOWN) || GameInputManager.GetKeyActionUp(KEY_ACTION.DOWNARROW))
		{
			GameInputManager.m_DirKeyUP[1] = true;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.LEFT) || GameInputManager.GetKeyActionUp(KEY_ACTION.LEFTARROW))
		{
			GameInputManager.m_DirKeyUP[2] = true;
		}
		if (GameInputManager.GetKeyActionUp(KEY_ACTION.RIGHT) || GameInputManager.GetKeyActionUp(KEY_ACTION.RIGHTARROW))
		{
			GameInputManager.m_DirKeyUP[3] = true;
		}
	}

	public Vector3 GetDirKeyMoveVector()
	{
		if (GetKeyActionPress(KEY_ACTION.UP) || GetKeyActionPress(KEY_ACTION.UPARROW))
		{
			GameInputManager.m_MoveDir.y = GameInputManager.m_MoveDir.y + Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.y > 1f)
			{
				GameInputManager.m_MoveDir.y = 1f;
			}
			GameInputManager.m_DirKeyUP[0] = false;
		}
		else if (GameInputManager.m_DirKeyUP[0] && GameInputManager.m_MoveDir.y != 0f)
		{
			GameInputManager.m_MoveDir.y = GameInputManager.m_MoveDir.y - Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.y <= 0f)
			{
				GameInputManager.m_DirKeyUP[0] = false;
				GameInputManager.m_MoveDir.y = 0f;
			}
		}
		if (GetKeyActionPress(KEY_ACTION.DOWN) || GetKeyActionPress(KEY_ACTION.DOWNARROW))
		{
			GameInputManager.m_MoveDir.y = GameInputManager.m_MoveDir.y - Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.y < -1f)
			{
				GameInputManager.m_MoveDir.y = -1f;
			}
			GameInputManager.m_DirKeyUP[1] = false;
		}
		else if (GameInputManager.m_DirKeyUP[1] && GameInputManager.m_MoveDir.y != 0f)
		{
			GameInputManager.m_MoveDir.y = GameInputManager.m_MoveDir.y + Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.y >= 0f)
			{
				GameInputManager.m_DirKeyUP[1] = false;
				GameInputManager.m_MoveDir.y = 0f;
			}
		}
		if (GetKeyActionPress(KEY_ACTION.LEFT) || GetKeyActionPress(KEY_ACTION.LEFTARROW))
		{
			GameInputManager.m_MoveDir.x = GameInputManager.m_MoveDir.x - Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.x < -1f)
			{
				GameInputManager.m_MoveDir.x = -1f;
			}
			GameInputManager.m_DirKeyUP[2] = false;
		}
		else if (GameInputManager.m_DirKeyUP[2] && GameInputManager.m_MoveDir.x != 0f)
		{
			GameInputManager.m_MoveDir.x = GameInputManager.m_MoveDir.x + Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.x >= 0f)
			{
				GameInputManager.m_DirKeyUP[2] = false;
				GameInputManager.m_MoveDir.x = 0f;
			}
		}
		if (GetKeyActionPress(KEY_ACTION.RIGHT) || GetKeyActionPress(KEY_ACTION.RIGHTARROW))
		{
			GameInputManager.m_MoveDir.x = GameInputManager.m_MoveDir.x + Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.x > 1f)
			{
				GameInputManager.m_MoveDir.x = 1f;
			}
			GameInputManager.m_DirKeyUP[3] = false;
		}
		else if (GameInputManager.m_DirKeyUP[3] && GameInputManager.m_MoveDir.x != 0f)
		{
			GameInputManager.m_MoveDir.x = GameInputManager.m_MoveDir.x - Time.deltaTime * GameInputManager.m_DirKeySpeed;
			if (GameInputManager.m_MoveDir.x <= 0f)
			{
				GameInputManager.m_DirKeyUP[3] = false;
				GameInputManager.m_MoveDir.x = 0f;
			}
		}
		return GameInputManager.m_MoveDir;
	}

	public bool IsPressUpKey()
	{
		float y = GameInputManager.m_DPadDir.y;
		return GetKeyAction(KEY_ACTION.UP) || GetKeyAction(KEY_ACTION.UPARROW) || y > 0f;
	}

	public bool IsPressDownKey()
	{
		float y = GameInputManager.m_DPadDir.y;
		return GetKeyAction(KEY_ACTION.DOWN) || GetKeyAction(KEY_ACTION.DOWNARROW) || y < 0f;
	}

	public bool IsPressLeftKey()
	{
		float x = GameInputManager.m_DPadDir.x;
		return GetKeyAction(KEY_ACTION.LEFT) || GetKeyAction(KEY_ACTION.LEFTARROW) || x < 0f;
	}

	public bool IsPressRightKey()
	{
		float x = GameInputManager.m_DPadDir.x;
		return GetKeyAction(KEY_ACTION.RIGHT) || GetKeyAction(KEY_ACTION.RIGHTARROW) || x > 0f;
	}

	public bool IsPressMenuTabKey()
	{
		return GetKeyActionDown(KEY_ACTION.TAB);
	}

	public bool IsPressAllConfirmKey()
	{
		return !GameInputManager.IsDelayInput() && (Input.GetMouseButtonDown(0) || GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space));
	}

	public bool IsPressConfirmKey()
	{
		if (GameInputManager.IsDelayInput())
		{
			return false;
		}
		if (GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space))
		{
			KeyInput = true;
			return true;
		}
		return false;
	}

	public bool IsPressMouseConfirmKey()
	{
		return !GameInputManager.IsDelayInput() && Input.GetMouseButtonDown(0);
	}

	public bool IsPressCancelKey()
	{
		if (GameInputManager.IsDelayInput())
		{
			return false;
		}
		if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
		{
			KeyInput = true;
			if (IsPressMouseCancelKey())
			{
				KeyInput = false;
			}
			return true;
		}
		return false;
	}

	public bool IsPressKeyboardCancelKey()
	{
		if (GameInputManager.IsDelayInput())
		{
			return false;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			KeyInput = true;
			return true;
		}
		return false;
	}

	public bool IsPressMouseCancelKey()
	{
		return !GameInputManager.IsDelayInput() && Input.GetMouseButtonDown(1);
	}

	public bool IsPressDirKeyDown()
	{
		return GetKeyActionDown(KEY_ACTION.UP) || GetKeyActionDown(KEY_ACTION.UPARROW) || (GetKeyActionDown(KEY_ACTION.DOWN) || GetKeyActionDown(KEY_ACTION.DOWNARROW)) || (GetKeyActionDown(KEY_ACTION.LEFT) || GetKeyActionDown(KEY_ACTION.LEFTARROW)) || (GetKeyActionDown(KEY_ACTION.RIGHT) || GetKeyActionDown(KEY_ACTION.RIGHTARROW));
	}

	public static void MoveCursorToGui(GameObject guiObj)
	{
		//Camera camera = NGUITools.FindCameraForLayer(guiObj.layer);
		//Vector3 vector = camera.WorldToScreenPoint(guiObj.transform.position);
		//int x = (int)vector.x;
		//int num = (int)vector.y;
		//num = Screen.height - num;
		//GameInputManager.MoveCursorTo(x, num, 0f);
	}

	public static void MoveCursorToGui(GameObject guiObj, int offsetX, int offsetY)
	{
		//Camera camera = NGUITools.FindCameraForLayer(guiObj.layer);
		//Vector3 vector = camera.WorldToScreenPoint(guiObj.transform.position);
		//int num = (int)vector.x;
		//int num2 = (int)vector.y;
		//num2 = Screen.height - num2;
		//GameInputManager.MoveCursorTo(num + offsetX, num2 + offsetY, 0f);
	}

	public static void MoveCursorToGui<T>(GameObject guiObj) where T : MonoBehaviour
	{
		//Camera camera = NGUITools.FindCameraForLayer(guiObj.layer);
		//Vector3 vector = camera.WorldToScreenPoint(guiObj.transform.position);
		//T[] componentsInChildren = guiObj.GetComponentsInChildren<T>();
		//if (componentsInChildren != null)
		//{
		//	camera = NGUITools.FindCameraForLayer(componentsInChildren[0].gameObject.layer);
		//	vector = camera.WorldToScreenPoint(componentsInChildren[0].gameObject.transform.position);
		//}
		//int x = (int)vector.x;
		//int num = (int)vector.y;
		//num = Screen.height - num;
		//GameInputManager.MoveCursorTo(x, num, 0f);
	}

	//public static int GetHeight()
	//{
 //       //RECT rect = default(RECT);
 //       //RECT rect2 = default(RECT);
 //       //IntPtr activeWindow = new IntPtr(0);
 //       //activeWindow = Win32API.GetActiveWindow();
 //       //Win32API.GetWindowRect(activeWindow, out rect);
 //       //Win32API.GetClientRect(activeWindow, out rect2);
 //       //int num = rect.bottom - rect.top;
 //       //return num - rect2.bottom;
 //   }

	public static void MoveCursorToCenter()
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		GameInputManager.MoveCursorTo(x, y, 0f);
	}

	public static void MoveCursorTo(int x, int y, float time)
	{
		//RECT rECT = default(RECT);
		//RECT rECT2 = default(RECT);
		//IntPtr activeWindow = new IntPtr(0);
		//activeWindow = Win32API.GetActiveWindow();
		//Win32API.GetWindowRect(activeWindow, out rECT);
		//Win32API.GetClientRect(activeWindow, out rECT2);
		//if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
		//{
		//	Win32API.SetCursorPos(x, y + 20);
		//}
		//else
		//{
		//	int num = rECT.bottom - rECT.top;
		//	num -= rECT2.bottom;
		//	Win32API.SetCursorPos(x + rECT.left, y + rECT.top + num);
		//}
	}

	public static void MoveGuiToCursor(GameObject guiObj)
	{
		//UIRoot uIRoot = Swd6Application.instance.m_UIRoot;
		//Vector3 mousePosition = Input.mousePosition;
		//int num = (int)mousePosition.x - Screen.width / 2;
		//int num2 = (int)mousePosition.y - Screen.height / 2;
		//float y = (float)num2 * uIRoot.pixelSizeAdjustment;
		//float x = (float)num * uIRoot.pixelSizeAdjustment;
		//guiObj.transform.localPosition = new Vector3(x, y, 0f);
	}

	public static void MoveCursor(int x, int y)
	{
		//Point point = default(Point);
		//Win32API.GetCursorPos(out point);
		//point.x += x;
		//point.y += y;
		//Win32API.SetCursorPos(point.x, point.y);
	}

	public static KeyCode CheckPressKey()
	{
		KeyCode keyCode = KeyCode.Backspace;
		while (keyCode <= KeyCode.Menu)
		{
			if (Input.GetKeyDown(keyCode))
			{
				if ((keyCode >= KeyCode.F1 && keyCode <= KeyCode.ScrollLock) || (keyCode >= KeyCode.RightCommand && keyCode <= KeyCode.Menu) || (keyCode >= KeyCode.UpArrow && keyCode <= KeyCode.DownArrow) || keyCode == KeyCode.BackQuote || keyCode == KeyCode.Pause || keyCode == KeyCode.P || keyCode == KeyCode.Escape)
				{
					return KeyCode.None;
				}
				return keyCode;
			}
			else
			{
				keyCode++;
			}
		}
		return KeyCode.None;
	}

    public void Dispose()
    {
       
    }
}
