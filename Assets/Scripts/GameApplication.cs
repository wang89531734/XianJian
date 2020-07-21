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
    /// 暂停
    /// </summary>
	public virtual void Pause()
	{
		Time.timeScale = 0f;
		this.isPause = true;
	}

    /// <summary>
    /// 重新开始
    /// </summary>
	public virtual void ReStart()
	{
		Time.timeScale = 1f;
		this.isPause = false;
	}

    /// <summary>
    /// 添加游戏状态
    /// </summary>
    /// <param name="gameState"></param>
    public void AddGameState(GameState gameState)
    {
        this.gameStateService.addState(gameState);
    }

    /// <summary>
    /// 改变状态
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
    /// 加入游戏状态
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
    /// 移除游戏状态
    /// </summary>
    public void PopState()
	{
        this.gameStateService.popState();
    }

    /// <summary>
    /// 获取游戏状态名称
    /// </summary>
    /// <param name="stateName"></param>
    /// <returns></returns>
    public GameState GetGameStateByName(string stateName)
    {
        return this.gameStateService.getState(stateName);
    }

    /// <summary>
    /// 获取当前游戏状态
    /// </summary>
    /// <returns></returns>
    public GameState GetCurrentGameState()
    {
        return this.gameStateService.getCurrentState();
    }
}
