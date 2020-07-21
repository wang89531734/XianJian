using System;

/// <summary>
/// ÓÎÏ·×´Ì¬
/// </summary>
public abstract class GameState
{
	public string name
	{
		get;
		private set;
	}

	public GameState(string name)
	{
		this.name = name;
	}

	public abstract void begin();

	public abstract void update();

	public abstract void onGUI();

	public abstract void end();

	public abstract void suspend();

	public abstract void resume();
}
