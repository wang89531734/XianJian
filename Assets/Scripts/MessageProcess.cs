using System;
using System.Collections.Generic;
using SoftStar.Pal6;
using UnityEngine;

/// <summary>
/// 信息处理
/// </summary>
public class MessageProcess : MonoBehaviour
{
    private static MessageProcess instance;

    private Dictionary<Message.Style, Message> messages = new Dictionary<Message.Style, Message>();

    public static MessageProcess Instance
	{
		get
		{
			if (MessageProcess.instance == null)
			{
				MessageProcess.Initialize();
			}
			return MessageProcess.instance;
		}
	}

	public static void Initialize()
	{
		if (MessageProcess.instance != null)
		{
			return;
		}
		//PalMain gameMain = PalMain.GameMain;
		//if (gameMain != null)
		//{
		//	MessageProcess.instance = gameMain.gameObject.GetOrAddComponent<MessageProcess>();
		//}
	}

	private void Start()
	{
	}

	public void AddMess(Message.Style style, Action ActFun)
	{
		if (this.messages.ContainsKey(style))
		{
			return;
		}
		Message message = new Message(style, ActFun);
		this.messages.Add(message.style, message);
	}

	public void AddMess(Message mess)
	{
		if (this.messages.ContainsKey(mess.style))
		{
			return;
		}
		this.messages.Add(mess.style, mess);
	}

	private void LateUpdate()
	{
		if (this.messages.Count < 1)
		{
			return;
		}
		int num = 6;
		for (int i = 0; i < num; i++)
		{
			Message.Style key = (Message.Style)i;
			if (this.messages.ContainsKey(key))
			{
				Message message = this.messages[key];
				if (message != null)
				{
					if (message.ActFun != null)
					{
						message.ActFun();
						break;
					}
				}
			}
		}
		this.messages.Clear();
	}
}
