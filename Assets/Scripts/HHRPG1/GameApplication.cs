using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public abstract class GameApplication : MonoBehaviour
{
	protected static GameApplication _instance;

    public GameStateService gameStateService
    {
        get;
        private set;
    }

    public bool isPause
	{
		get;
		protected set;
	}

	protected virtual void Awake()
	{
		GameApplication._instance = this;
		this.isPause = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	public virtual void Start()
	{
        this.gameStateService = new GameStateService();
        this.initialize();
	}

	public virtual void Update()
	{
        this.gameStateService.update();
    }

	public virtual void OnGUI()
	{
	}

	protected abstract void initialize();

    /// <summary>
    /// ��ͣ
    /// </summary>
	public virtual void Pause()
	{
		Time.timeScale = 0f;
		this.isPause = true;
	}

    /// <summary>
    /// ���¿�ʼ
    /// </summary>
	public virtual void ReStart()
	{
		Time.timeScale = 1f;
		this.isPause = false;
	}

    /// <summary>
    /// �����Ϸ״̬
    /// </summary>
    /// <param name="gameState"></param>
    public void AddGameState(GameState gameState)
    {
        this.gameStateService.addState(gameState);
    }

    /// <summary>
    /// �л�״̬
    /// </summary>
    /// <param name="nextStateName"></param>
    /// <returns></returns>
    public IEnumerator ChangeState(string nextStateName)
    {
        yield return new WaitForEndOfFrame();
        this.gameStateService.changeState(nextStateName);
        yield break;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    /// <param name="pushStateName"></param>
    /// <returns></returns>
    public IEnumerator PushState(string pushStateName)
    {
        yield return new WaitForEndOfFrame();
        this.gameStateService.pushState(pushStateName);
        yield break;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    public void PopState()
	{
        this.gameStateService.popState();
    }

    /// <summary>
    /// �õ���Ϸ״̬����
    /// </summary>
    /// <param name="stateName"></param>
    /// <returns></returns>
    public GameState GetGameStateByName(string stateName)
    {
        return this.gameStateService.getState(stateName);
    }

    /// <summary>
    /// �õ���ǰ��Ϸ״̬
    /// </summary>
    /// <returns></returns>
    public GameState GetCurrentGameState()
    {
        return this.gameStateService.getCurrentState();
    }
}
