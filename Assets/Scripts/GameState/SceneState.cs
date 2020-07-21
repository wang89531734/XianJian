using System;

public abstract class SceneState : GameState
{
	protected string sceneName;

	protected GameApplication gameApplication;

	public SceneState(string name, string sceneName, GameApplication gameApplication) : base(name)
	{
		this.sceneName = sceneName;
		this.gameApplication = gameApplication;
	}

	public override void begin()
	{
	}

	public override void update()
	{
	}

	public override void onGUI()
	{
	}

	public override void end()
	{
	}

	public override void suspend()
	{
	}

	public override void resume()
	{
	}

	public virtual string getSceneName()
	{
		return this.sceneName;
	}
}
