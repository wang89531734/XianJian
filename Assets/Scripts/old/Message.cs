using System;

/// <summary>
/// ÏûÏ¢
/// </summary>
public class Message
{
    public Message.Style style = Message.Style.None;

    public Action ActFun;

    public enum Style
    {
        EndAction,
        Interact,
        Mechanism,
        Sneak,
        FMechanism,
        Action,
        None
    }

    public Message(Message.Style style, Action ActFun)
	{
		this.style = style;
		this.ActFun = ActFun;
	}
}
