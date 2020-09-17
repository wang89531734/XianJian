using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class GameInput : ManagerBase, IDisposable
{
    private static bool m_Initialize = false;

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

	public static bool KeyInput
	{
		get
		{
			return GameInput.m_IsKeyInput;
		}
		set
		{
			GameInput.m_IsKeyInput = value;
		}
	}

	public static bool FullScreen
	{
		get
		{
			return GameInput.m_IsFuuscreen;
		}
		set
		{
			GameInput.m_IsFuuscreen = value;
		}
	}

	public static bool JoyStick
	{
		get
		{
			return GameInput.m_IsJoyPad;
		}
		set
		{
			GameInput.m_IsJoyPad = value;
		}
	}

	public static void InitDefalutKeyMapping()
	{
		GameInput.GameKeyList.Clear();
		GameInput.GameKeyList.Add(KEY_ACTION.UPARROW, KeyCode.UpArrow);
		GameInput.GameKeyList.Add(KEY_ACTION.DOWNARROW, KeyCode.DownArrow);
		GameInput.GameKeyList.Add(KEY_ACTION.LEFTARROW, KeyCode.LeftArrow);
		GameInput.GameKeyList.Add(KEY_ACTION.RIGHTARROW, KeyCode.RightArrow);
		GameInput.GameKeyList.Add(KEY_ACTION.CONFIRM, KeyCode.Return);
		GameInput.GameKeyList.Add(KEY_ACTION.CANCEL, KeyCode.Escape);
		GameInput.GameKeyList.Add(KEY_ACTION.JUMP, KeyCode.Space);
		GameInput.GameKeyList.Add(KEY_ACTION.TAB, KeyCode.Tab);
		GameInput.GameKeyList.Add(KEY_ACTION.DASH, KeyCode.X);
		GameInput.GameKeyList.Add(KEY_ACTION.ACTION, KeyCode.F);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_UP, KeyCode.Equals);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_DOWN, KeyCode.Minus);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_LEFT, KeyCode.Q);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_RIGHT, KeyCode.E);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_IN, KeyCode.RightBracket);
		GameInput.GameKeyList.Add(KEY_ACTION.CAMERA_OUT, KeyCode.LeftBracket);
		GameInput.GameKeyList.Add(KEY_ACTION.ROLE_LEFT, KeyCode.Comma);
		GameInput.GameKeyList.Add(KEY_ACTION.ROLE_RIGHT, KeyCode.Period);
		GameInput.GameKeyList.Add(KEY_ACTION.MENU, KeyCode.Escape);
		GameInput.GameKeyList.Add(KEY_ACTION.MAP, KeyCode.M);
		GameInput.GameKeyList.Add(KEY_ACTION.RUN, KeyCode.R);
		GameInput.GameKeyList.Add(KEY_ACTION.UP, KeyCode.W);
		GameInput.GameKeyList.Add(KEY_ACTION.DOWN, KeyCode.S);
		GameInput.GameKeyList.Add(KEY_ACTION.LEFT, KeyCode.A);
		GameInput.GameKeyList.Add(KEY_ACTION.RIGHT, KeyCode.D);
		GameInput.GameKeyList.Add(KEY_ACTION.SNAP, KeyCode.Z);
	}

	public static void Clear()
	{
		GameInput.m_MoveDir = Vector3.zero;
		for (int i = 0; i < 4; i++)
		{
			GameInput.m_DirKeyUP[i] = false;
		}
	}

	public static Dictionary<KEY_ACTION, KeyCode> GetKeyList()
	{
		return GameInput.GameKeyList;
	}

	public static void DelayInput(bool bDelay)
	{
		if (bDelay)
		{
			GameInput.m_DelayTime = 1f;
		}
		else
		{
			GameInput.m_DelayTime = 0f;
		}
		GameInput.m_DelayInput = bDelay;
	}

	public static bool GetKeyDown(KeyCode key)
	{
		return !GameInput.IsDelayInput() && Input.GetKeyDown(key);
	}

	public static bool GetKey(KeyCode key)
	{
		if (!GameInput.m_IsDelayPress)
		{
			return Input.GetKey(key);
		}
		if (Input.GetKey(key))
		{
			GameInput.m_IsKeyInput = true;
			if (!GameInput.m_FirstPress)
			{
				GameInput.m_FirstWaitTime = 0.5f;
				GameInput.m_FirstPress = true;
				return true;
			}
			GameInput.m_PressTime += Time.deltaTime;
			if (GameInput.m_FirstWaitTime > 0f)
			{
				GameInput.m_FirstWaitTime -= Time.deltaTime;
				if (GameInput.m_FirstWaitTime < 0f)
				{
					GameInput.m_FirstWaitTime = 0f;
				}
			}
			else if (GameInput.m_PressTime > 0.05f)
			{
				GameInput.m_PressTime = 0f;
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
			GameInput.m_IsKeyInput = true;
			if (!GameInput.m_FirstPress)
			{
				GameInput.m_FirstWaitTime = 0.5f;
				GameInput.m_FirstPress = true;
				return axis;
			}
			GameInput.m_PressTime += Time.deltaTime;
			if (GameInput.m_FirstWaitTime > 0f)
			{
				GameInput.m_FirstWaitTime -= Time.deltaTime;
				if (GameInput.m_FirstWaitTime < 0f)
				{
					GameInput.m_FirstWaitTime = 0f;
				}
			}
			else if (GameInput.m_PressTime > 0.05f)
			{
				GameInput.m_PressTime = 0f;
				return axis;
			}
		}
		return 0f;
	}

	public static bool GetKeyUp()
	{
		if (GameInput.GetKeyActionUp(KEY_ACTION.UP) || GameInput.GetKeyActionUp(KEY_ACTION.UPARROW))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.DOWN) || GameInput.GetKeyActionUp(KEY_ACTION.DOWNARROW))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.LEFT) || GameInput.GetKeyActionUp(KEY_ACTION.LEFTARROW))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.RIGHT) || GameInput.GetKeyActionUp(KEY_ACTION.RIGHTARROW))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.PageUp))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.PageDown))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Home))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.End))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Return))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			GameInput.m_PressTime = 0f;
			GameInput.m_FirstPress = false;
		}
		if (Input.GetMouseButtonDown(0))
		{
			GameInput.m_IsKeyInput = false;
		}
		return !GameInput.m_FirstPress;
	}

    public void OnUpdate()
    {
        GameInput.GetDirKeyUp();
        GameInput.GetKeyUp();
    }

	public static bool IsDelayInput()
	{
		if (!GameInput.m_DelayInput)
		{
			return false;
		}
		GameInput.m_DelayTime -= Time.deltaTime;
		if (GameInput.m_DelayTime <= 0f)
		{
			GameInput.m_DelayTime = 0f;
			GameInput.m_DelayInput = false;
			return false;
		}
		return true;
	}

	public static void SetMappingKey(KEY_ACTION keyIndex, KeyCode keyCode)
	{
		if (!GameInput.GameKeyList.ContainsKey(keyIndex))
		{
			GameInput.GameKeyList.Add(keyIndex, keyCode);
			return;
		}
		GameInput.GameKeyList[keyIndex] = keyCode;
	}

	public static KeyCode GetMappingKey(KEY_ACTION keyIndex)
	{
		if (!GameInput.GameKeyList.ContainsKey(keyIndex))
		{
			return KeyCode.None;
		}
		return GameInput.GameKeyList[keyIndex];
	}

	public static bool GetKeyAction(KEY_ACTION key)
	{
		return !GameInput.IsDelayInput() && GameInput.GetKey(GameInput.GameKeyList[key]);
	}

	public static bool GetKeyActionPress(KEY_ACTION key)
	{
		return !GameInput.IsDelayInput() && (Input.GetKey(GameInput.GameKeyList[key]));
	}

	public static bool GetKeyActionDown(KEY_ACTION key)
	{
		return !GameInput.IsDelayInput() && (GameInput.GetKeyDown(GameInput.GameKeyList[key]));
	}

	public static bool GetKeyActionUp(KEY_ACTION key)
	{
		return Input.GetKeyUp(GameInput.GameKeyList[key]);
	}

	public static void GetDirKeyUp()
	{
		if (GameInput.GetKeyActionUp(KEY_ACTION.UP) || GameInput.GetKeyActionUp(KEY_ACTION.UPARROW))
		{
			GameInput.m_DirKeyUP[0] = true;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.DOWN) || GameInput.GetKeyActionUp(KEY_ACTION.DOWNARROW))
		{
			GameInput.m_DirKeyUP[1] = true;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.LEFT) || GameInput.GetKeyActionUp(KEY_ACTION.LEFTARROW))
		{
			GameInput.m_DirKeyUP[2] = true;
		}
		if (GameInput.GetKeyActionUp(KEY_ACTION.RIGHT) || GameInput.GetKeyActionUp(KEY_ACTION.RIGHTARROW))
		{
			GameInput.m_DirKeyUP[3] = true;
		}
	}

	public static Vector3 GetDirKeyMoveVector()
	{
		if (GameInput.GetKeyActionPress(KEY_ACTION.UP) || GameInput.GetKeyActionPress(KEY_ACTION.UPARROW))
		{
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y + Time.deltaTime * GameInput.m_DirKeySpeed;
			if (GameInput.m_MoveDir.y > 1f)
			{
				GameInput.m_MoveDir.y = 1f;
			}
			GameInput.m_DirKeyUP[0] = false;
		}
		else if (GameInput.m_DirKeyUP[0] && GameInput.m_MoveDir.y != 0f)
		{
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y - Time.deltaTime * (GameInput.m_DirKeySpeed / 2f);
			if (GameInput.m_MoveDir.y <= 0f)
			{
				GameInput.m_DirKeyUP[0] = false;
				GameInput.m_MoveDir.y = 0f;
			}
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.DOWN) || GameInput.GetKeyActionPress(KEY_ACTION.DOWNARROW))
		{
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y - Time.deltaTime * GameInput.m_DirKeySpeed;
			if (GameInput.m_MoveDir.y < -1f)
			{
				GameInput.m_MoveDir.y = -1f;
			}
			GameInput.m_DirKeyUP[1] = false;
		}
		else if (GameInput.m_DirKeyUP[1] && GameInput.m_MoveDir.y != 0f)
		{
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y + Time.deltaTime * (GameInput.m_DirKeySpeed / 2f);
			if (GameInput.m_MoveDir.y >= 0f)
			{
				GameInput.m_DirKeyUP[1] = false;
				GameInput.m_MoveDir.y = 0f;
			}
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.LEFT) || GameInput.GetKeyActionPress(KEY_ACTION.LEFTARROW))
		{
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x - Time.deltaTime * GameInput.m_DirKeySpeed;
			if (GameInput.m_MoveDir.x < -1f)
			{
				GameInput.m_MoveDir.x = -1f;
			}
			GameInput.m_DirKeyUP[2] = false;
		}
		else if (GameInput.m_DirKeyUP[2] && GameInput.m_MoveDir.x != 0f)
		{
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x + Time.deltaTime * (GameInput.m_DirKeySpeed / 2f);
			if (GameInput.m_MoveDir.x >= 0f)
			{
				GameInput.m_DirKeyUP[2] = false;
				GameInput.m_MoveDir.x = 0f;
			}
		}
		if (GameInput.GetKeyActionPress(KEY_ACTION.RIGHT) || GameInput.GetKeyActionPress(KEY_ACTION.RIGHTARROW))
		{
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x + Time.deltaTime * GameInput.m_DirKeySpeed;
			if (GameInput.m_MoveDir.x > 1f)
			{
				GameInput.m_MoveDir.x = 1f;
			}
			GameInput.m_DirKeyUP[3] = false;
		}
		else if (GameInput.m_DirKeyUP[3] && GameInput.m_MoveDir.x != 0f)
		{
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x - Time.deltaTime * (GameInput.m_DirKeySpeed / 2f);
			if (GameInput.m_MoveDir.x <= 0f)
			{
				GameInput.m_DirKeyUP[3] = false;
				GameInput.m_MoveDir.x = 0f;
			}
		}
		return GameInput.m_MoveDir;
	}

	public static bool IsPressUpKey()
	{
		float y = GameInput.m_DPadDir.y;
		return GameInput.GetKeyAction(KEY_ACTION.UP) || GameInput.GetKeyAction(KEY_ACTION.UPARROW) || y > 0f;
	}

	public static bool IsPressDownKey()
	{
		float y = GameInput.m_DPadDir.y;
		return GameInput.GetKeyAction(KEY_ACTION.DOWN) || GameInput.GetKeyAction(KEY_ACTION.DOWNARROW) || y < 0f;
	}

	public static bool IsPressLeftKey()
	{
		float x = GameInput.m_DPadDir.x;
		return GameInput.GetKeyAction(KEY_ACTION.LEFT) || GameInput.GetKeyAction(KEY_ACTION.LEFTARROW) || x < 0f;
	}

	public static bool IsPressRightKey()
	{
		float x = GameInput.m_DPadDir.x;
		return GameInput.GetKeyAction(KEY_ACTION.RIGHT) || GameInput.GetKeyAction(KEY_ACTION.RIGHTARROW) || x > 0f;
	}

	public static bool IsPressMenuTabKey()
	{
		return GameInput.GetKeyActionDown(KEY_ACTION.TAB);
	}

	public static bool IsPressAllConfirmKey()
	{
		return !GameInput.IsDelayInput() && (Input.GetMouseButtonDown(0) || GameInput.GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space));
	}

	public static bool IsPressConfirmKey()
	{
		if (GameInput.IsDelayInput())
		{
			return false;
		}
		if (GameInput.GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space))
		{
			GameInput.KeyInput = true;
			return true;
		}
		return false;
	}

	public static bool IsPressMouseConfirmKey()
	{
		return !GameInput.IsDelayInput() && Input.GetMouseButtonDown(0);
	}

	public static bool IsPressCancelKey()
	{
		if (GameInput.IsDelayInput())
		{
			return false;
		}
		if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
		{
			GameInput.KeyInput = true;
			if (GameInput.IsPressMouseCancelKey())
			{
				GameInput.KeyInput = false;
			}
			return true;
		}
		return false;
	}

	public static bool IsPressMouseCancelKey()
	{
		return !GameInput.IsDelayInput() && Input.GetMouseButtonDown(1);
	}

	//public static void MoveCursorToGui(iGUIElement pGui, float time, float fPosX, float fPosY)
	//{
	//	int num = (int)pGui.getAbsoluteRect().x;
	//	int num2 = (int)pGui.getAbsoluteRect().y;
	//	num += (int)(pGui.getAbsoluteRect().width * fPosX);
	//	num2 += (int)(pGui.getAbsoluteRect().height * fPosY);
	//	GameInput.MoveCursorTo(num, num2, time);
	//}

	//public static int GetHeight()
	//{
	//	RECT rECT = default(RECT);
	//	RECT rECT2 = default(RECT);
	//	IntPtr activeWindow = new IntPtr(0);
	//	activeWindow = Win32API.GetActiveWindow();
	//	Win32API.GetWindowRect(activeWindow, out rECT);
	//	Win32API.GetClientRect(activeWindow, out rECT2);
	//	int num = rECT.bottom - rECT.top;
	//	return num - rECT2.bottom;
	//}

	//public static void MoveCursorTo(int x, int y, float time)
	//{
	//	RECT rECT = default(RECT);
	//	RECT rECT2 = default(RECT);
	//	IntPtr activeWindow = new IntPtr(0);
	//	activeWindow = Win32API.GetActiveWindow();
	//	Win32API.GetWindowRect(activeWindow, out rECT);
	//	Win32API.GetClientRect(activeWindow, out rECT2);
	//	if (Swd6Application.instance.m_ResourceType == ENUM_ResourceType.Develop)
	//	{
	//		Win32API.SetCursorPos(x + rECT.left, y + rECT.top + 47);
	//		return;
	//	}
	//	int num = rECT.bottom - rECT.top;
	//	num -= rECT2.bottom;
	//	Win32API.SetCursorPos(x + rECT.left, y + rECT.top + num);
	//}

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

    public override void Init()
    {
        GameInput.InitDefalutKeyMapping();
        GameInput.m_Initialize = true;
    }

    public void Dispose()
    {
        
    }
}
