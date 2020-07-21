using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInput
{
	private static Dictionary<KEY_ACTION, KeyCode> GameKeyList = new Dictionary<KEY_ACTION, KeyCode>();

	private static Dictionary<JOYSTICK_KEY, string> JostickKeyList = new Dictionary<JOYSTICK_KEY, string>();

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

	public static void Initialize()
	{
		GameInput.InitDefalutKeyMapping();
		GameInput.InitDefalutJoystickKeyMapping();
		GameInput.m_Initialize = true;
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
		GameInput.GameKeyList.Add(KEY_ACTION.TAB, KeyCode.Tab);
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
		GameInput.GameKeyList.Add(KEY_ACTION.SCREENSHOT, KeyCode.P);
		GameInput.GameKeyList.Add(KEY_ACTION.QSAVE, KeyCode.F9);
		GameInput.GameKeyList.Add(KEY_ACTION.QLOAD, KeyCode.F10);
		GameInput.GameKeyList.Add(KEY_ACTION.UP, KeyCode.W);
		GameInput.GameKeyList.Add(KEY_ACTION.DOWN, KeyCode.S);
		GameInput.GameKeyList.Add(KEY_ACTION.LEFT, KeyCode.A);
		GameInput.GameKeyList.Add(KEY_ACTION.RIGHT, KeyCode.D);
	}

	public static void InitDefalutJoystickKeyMapping()
	{
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.A, "A_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.B, "B_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.X, "X_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.Y, "Y_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.LB, "LB_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.RB, "RB_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.BACK, "Back_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.START, "Start_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.L3, "LS_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.R3, "RS_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.L_XAxis, "L_XAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.L_YAxis, "L_YAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.Trigger, "Triggers_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.R_XAxis, "R_XAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.R_YAxis, "R_YAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.DPad_XAxis, "DPad_XAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.DPad_YAxis, "DPad_YAxis_1");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.LTrigger, "LTriggers");
		GameInput.JostickKeyList.Add(JOYSTICK_KEY.RTrigger, "RTriggers");
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

	public static void Update()
	{
		//GameInput.GetJoyDpadInput();
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
		}
		else
		{
			GameInput.GameKeyList[keyIndex] = keyCode;
		}
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
		return GameInput.m_Initialize && !GameInput.IsDelayInput() && GameInput.GetKey(GameInput.GameKeyList[key]);
	}

	public static bool GetKeyActionPress(KEY_ACTION key)
	{
		return GameInput.m_Initialize && !GameInput.IsDelayInput() && (GameInput.GetJoyKeyActionPress(key) || Input.GetKey(GameInput.GameKeyList[key]));
	}

	public static bool GetKeyActionDown(KEY_ACTION key)
	{
		return GameInput.m_Initialize && !GameInput.IsDelayInput() && (GameInput.GetJoyKeyActionDown(key) || GameInput.GetKeyDown(GameInput.GameKeyList[key]));
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
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y - Time.deltaTime * GameInput.m_DirKeySpeed;
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
			GameInput.m_MoveDir.y = GameInput.m_MoveDir.y + Time.deltaTime * GameInput.m_DirKeySpeed;
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
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x + Time.deltaTime * GameInput.m_DirKeySpeed;
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
			GameInput.m_MoveDir.x = GameInput.m_MoveDir.x - Time.deltaTime * GameInput.m_DirKeySpeed;
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
		return GameInput.GetKeyActionDown(KEY_ACTION.TAB) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.BACK);
	}

	public static bool IsPressAllConfirmKey()
	{
		return !GameInput.IsDelayInput() && (Input.GetMouseButtonDown(0) || GameInput.GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.A));
	}

	public static bool IsPressConfirmKey()
	{
		if (GameInput.IsDelayInput())
		{
			return false;
		}
		if (GameInput.GetKeyActionDown(KEY_ACTION.CONFIRM) || Input.GetKeyDown(KeyCode.Space) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.A))
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
		if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.B))
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

	public static bool IsPressKeyboardCancelKey()
	{
		if (GameInput.IsDelayInput())
		{
			return false;
		}
		if (Input.GetKeyDown(KeyCode.Escape) || GameInput.GetJoyKeyDown(JOYSTICK_KEY.B))
		{
			GameInput.KeyInput = true;
			return true;
		}
		return false;
	}

	public static bool IsPressMouseCancelKey()
	{
		return !GameInput.IsDelayInput() && Input.GetMouseButtonDown(1);
	}

	public static bool IsPressDirKeyDown()
	{
		return GameInput.GetKeyActionDown(KEY_ACTION.UP) || GameInput.GetKeyActionDown(KEY_ACTION.UPARROW) || (GameInput.GetKeyActionDown(KEY_ACTION.DOWN) || GameInput.GetKeyActionDown(KEY_ACTION.DOWNARROW)) || (GameInput.GetKeyActionDown(KEY_ACTION.LEFT) || GameInput.GetKeyActionDown(KEY_ACTION.LEFTARROW)) || (GameInput.GetKeyActionDown(KEY_ACTION.RIGHT) || GameInput.GetKeyActionDown(KEY_ACTION.RIGHTARROW));
	}

	public static bool GetJoyKeyPressDown(JOYSTICK_KEY key)
	{
		if (!GameInput.m_IsJoyPad)
		{
			return false;
		}
		if (key == JOYSTICK_KEY.LTrigger)
		{
			return GameInput.GetJoyPressLTriggerAxis() != 0f;
		}
		if (key != JOYSTICK_KEY.RTrigger)
		{
			return Input.GetButton(GameInput.JostickKeyList[key]);
		}
		return GameInput.GetJoyPressRTriggerAxis() != 0f;
	}

	public static bool GetJoyKeyDown(JOYSTICK_KEY key)
	{
		if (!GameInput.m_IsJoyPad)
		{
			return false;
		}
		if (key == JOYSTICK_KEY.LTrigger)
		{
			return GameInput.GetJoyLTriggerAxis() != 0f;
		}
		if (key != JOYSTICK_KEY.RTrigger)
		{
			return Input.GetButtonDown(GameInput.JostickKeyList[key]);
		}
		return GameInput.GetJoyRTriggerAxis() != 0f;
	}

	public static bool GetJoyKeyActionDown(KEY_ACTION key)
	{
        if (!GameInput.m_IsJoyPad)
        {
            return false;
        }
        switch (key)
        {
            case KEY_ACTION.CONFIRM:
                return GameInput.GetJoyKeyDown(JOYSTICK_KEY.A);
            default:
                switch (key)
                {
                    case KEY_ACTION.MENU:
                        return GameInput.GetJoyKeyDown(JOYSTICK_KEY.START);
                    case KEY_ACTION.CANCEL:
                        return GameInput.GetJoyKeyDown(JOYSTICK_KEY.B);
                    case KEY_ACTION.SCREENSHOT:
                        return GameInput.GetJoyKeyDown(JOYSTICK_KEY.L3);
                    case KEY_ACTION.QSAVE:
                        if (GameInput.GetJoyKeyPressDown(JOYSTICK_KEY.RTrigger) && GameInput.GetJoyKeyDown(JOYSTICK_KEY.A))
                        {
                            return true;
                        }
                        break;
                    case KEY_ACTION.QLOAD:
                        if (GameInput.GetJoyKeyPressDown(JOYSTICK_KEY.RTrigger) && GameInput.GetJoyKeyDown(JOYSTICK_KEY.B))
                        {
                            return true;
                        }
                        break;
                    case KEY_ACTION.SNAP:
                        return GameInput.GetJoyKeyDown(JOYSTICK_KEY.R3);
                }
                return false;
            case KEY_ACTION.ACTION:
                return GameInput.GetJoyKeyDown(JOYSTICK_KEY.X);
            case KEY_ACTION.ROLE_LEFT:
                return GameInput.GetJoyKeyDown(JOYSTICK_KEY.LB);
            case KEY_ACTION.ROLE_RIGHT:
                return GameInput.GetJoyKeyDown(JOYSTICK_KEY.RB);
            case KEY_ACTION.MAP:
                return GameInput.GetJoyKeyDown(JOYSTICK_KEY.Y);
        }
    }

	public static bool GetJoyKeyActionPress(KEY_ACTION key)
	{
		if (!GameInput.m_IsJoyPad)
		{
			return false;
		}
		if (key != KEY_ACTION.CAMERA_IN)
		{
			if (key == KEY_ACTION.CAMERA_OUT)
			{
				float axis = Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_YAxis]);
				if (axis < 0f)
				{
					return true;
				}
			}
		}
		else
		{
			float axis = Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_YAxis]);
			if (axis > 0f)
			{
				return true;
			}
		}
		return false;
	}

	public static float GetJoyDpadXAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		return GameInput.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_XAxis]);
	}

	public static float GetJoyDpadYAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		return GameInput.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_YAxis]);
	}

	public static bool GetJoyDpadInput()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return false;
		}
		Vector2 vector = new Vector2(0f, 0f);
		vector.x = Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_XAxis]);
		vector.y = Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.DPad_YAxis]);
		if (vector == Vector2.zero)
		{
			if (GameInput.m_IsPressDPad)
			{
				GameInput.m_PressTime = 0f;
				GameInput.m_FirstPress = false;
				GameInput.m_IsPressDPad = false;
			}
			GameInput.m_DPadDir = vector;
			return true;
		}
		if (vector.x != 0f)
		{
			GameInput.m_DPadDir.x = GameInput.GetJoyDpadXAxis();
		}
		if (vector.y != 0f)
		{
			GameInput.m_DPadDir.y = GameInput.GetJoyDpadYAxis();
		}
		GameInput.m_IsPressDPad = true;
		return false;
	}

	public static Vector3 GetJoyLAxis()
	{
		if (!GameInput.m_Initialize)
		{
			return new Vector3(0f, 0f, 0f);
		}
		if (!GameInput.m_IsJoyPad)
		{
			return new Vector3(0f, 0f, 0f);
		}
		return new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.L_XAxis]), Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.L_YAxis]), 0f);
	}

	public static Vector3 GetJoyRAxis()
	{
		if (!GameInput.m_Initialize)
		{
			return new Vector3(0f, 0f, 0f);
		}
		if (!GameInput.m_IsJoyPad)
		{
			return new Vector3(0f, 0f, 0f);
		}
		return new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.R_XAxis]), Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.R_YAxis]), 0f);
	}

	public static float GetJoyLTriggerAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.LTrigger]), 0f, 0f);
		if (GameInput.m_IsLTrigger)
		{
			if (vector.x == 0f)
			{
				GameInput.m_IsLTrigger = false;
			}
			return 0f;
		}
		if (vector.x > 0f)
		{
			GameInput.m_IsLTrigger = true;
			return vector.x;
		}
		return 0f;
	}

	public static float GetJoyRTriggerAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.RTrigger]), 0f, 0f);
		if (GameInput.m_IsRTrigger)
		{
			if (vector.x == 0f)
			{
				GameInput.m_IsRTrigger = false;
			}
			return 0f;
		}
		if (vector.x > 0f)
		{
			GameInput.m_IsRTrigger = true;
			return vector.x;
		}
		return 0f;
	}

	public static float GetJoyPressLTriggerAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.LTrigger]), 0f, 0f);
		return vector.x;
	}

	public static float GetJoyPressRTriggerAxis()
	{
		if (!GameInput.m_IsJoyPad)
		{
			return 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis(GameInput.JostickKeyList[JOYSTICK_KEY.RTrigger]), 0f, 0f);
		return vector.x;
	}

	public static bool IsJoyPressUpKey()
	{
		float y = GameInput.m_DPadDir.y;
		return y > 0f;
	}

	public static bool IsJoyPressDownKey()
	{
		float y = GameInput.m_DPadDir.y;
		return y < 0f;
	}

	public static bool IsJoyPressLeftKey()
	{
		float x = GameInput.m_DPadDir.x;
		return x < 0f;
	}

	public static bool IsJoyPressRightKey()
	{
		float x = GameInput.m_DPadDir.x;
		return x > 0f;
	}

	public static void MoveCursorToGui(GameObject guiObj)
	{
		//Camera camera = NGUITools.FindCameraForLayer(guiObj.layer);
		//Vector3 vector = camera.WorldToScreenPoint(guiObj.transform.position);
		//int x = (int)vector.x;
		//int num = (int)vector.y;
		//num = Screen.height - num;
		//GameInput.MoveCursorTo(x, num, 0f);
	}

	public static void MoveCursorToGui(GameObject guiObj, int offsetX, int offsetY)
	{
		//Camera camera = NGUITools.FindCameraForLayer(guiObj.layer);
		//Vector3 vector = camera.WorldToScreenPoint(guiObj.transform.position);
		//int num = (int)vector.x;
		//int num2 = (int)vector.y;
		//num2 = Screen.height - num2;
		//GameInput.MoveCursorTo(num + offsetX, num2 + offsetY, 0f);
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
		//GameInput.MoveCursorTo(x, num, 0f);
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
		GameInput.MoveCursorTo(x, y, 0f);
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
}
