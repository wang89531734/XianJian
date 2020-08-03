using System;

public abstract class StoryEvent
{
	protected M_StoryBase m_StoryBase;

	protected bool m_IsWaitting;

	public bool IsWaitting
	{
		get
		{
			return this.m_IsWaitting;
		}
	}

	public StoryEvent()
	{
	}

	public abstract void Begin();

	public virtual void Update()
	{
		this.m_StoryBase.ProcessNextEvent();
	}

	public virtual void SetStoryBase(M_StoryBase storyBase)
	{
		this.m_StoryBase = storyBase;
	}
}
