using System;
using System.Collections.Generic;

/// <summary>
/// ÓÎÏ·×´Ì¬·þÎñÆ÷
/// </summary>
public class GameStateService
{
	private Dictionary<string, GameState> availableStates = new Dictionary<string, GameState>();

	private Stack<GameState> activeStates = new Stack<GameState>();

	private bool isActiveStatesEmpty()
	{
		return this.activeStates.Count == 0;
	}

	public void addState(GameState newState)
	{
		if (newState == null)
		{
			throw new ArgumentNullException();
		}
		this.availableStates.Add(newState.name, newState);
	}

	public bool hasState(string stateName)
	{
		return this.availableStates.ContainsKey(stateName);
	}

	public GameState getState(string stateName)
	{
		if (this.hasState(stateName))
		{
			return this.availableStates[stateName];
		}
		return null;
	}

	public void changeState(string nextStateName)
	{
		if (!this.hasState(nextStateName))
		{
			return;
		}
		this.clearAllActiveStates();
		this.activeNextState(nextStateName);
	}

	public void update()
	{
		foreach (GameState current in this.activeStates)
		{
			current.update();
		}
	}

	public void onGUI()
	{
		foreach (GameState current in this.activeStates)
		{
			current.onGUI();
		}
	}

	private void clearAllActiveStates()
	{
		foreach (GameState current in this.activeStates)
		{
			current.end();
		}
		this.activeStates.Clear();
	}

	public GameState getCurrentState()
	{
		if (this.isActiveStatesEmpty())
		{
			return null;
		}
		return this.activeStates.Peek();
	}

	public void pushState(string pushedStateName)
	{
		if (!this.hasState(pushedStateName))
		{
			return;
		}
		if (!this.isActiveStatesEmpty())
		{
			GameState currentState = this.getCurrentState();
			currentState.suspend();
		}
		this.activeNextState(pushedStateName);
	}

	public void popState()
	{
		if (this.isActiveStatesEmpty())
		{
			return;
		}
		GameState gameState = this.activeStates.Pop();
		gameState.end();
		if (!this.isActiveStatesEmpty())
		{
			GameState currentState = this.getCurrentState();
			currentState.resume();
		}
	}

	private void activeNextState(string nextStateName)
	{
		GameState state = this.getState(nextStateName);
		this.activeStates.Push(state);
		state.begin();
	}

	public int getActiveStatesCount()
	{
		return this.activeStates.Count;
	}
}
