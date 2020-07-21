using System;
using System.Collections;
using System.Diagnostics;

public class LogoState : SceneState
{
	private const int SOFTSTARLOGO = 54;

	private const int TOTEMLOGO = 55;

	private const int OPENING = 51;

	protected new Swd6Application gameApplication
	{
		get
		{
			return this.gameApplication as Swd6Application;
		}
	}

	public LogoState(string name, string sceneName, GameApplication gameApplication) : base(name, sceneName, gameApplication)
	{
	}

	public override void begin()
	{
		base.begin();		
		this.gameApplication.StartCoroutine(this.SimplifiedChineseCoroutine());
	}

	public override void update()
	{
	}

	public override void end()
	{
		base.end();
	}

    private IEnumerator SimplifiedChineseCoroutine()
    {
        yield return null;
        GameInput.KeyInput = false;
        this.gameApplication.SwitchState("MenuState");
        yield break;
    }
}
