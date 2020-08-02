using System;
using YouYou;

public class StorySystem
{
    private bool m_IsStoryEnd;

    private bool m_IsStoryTest;

    public bool m_IsReviewStory;

    public void Initialize()
    {
        this.m_IsStoryEnd = true;
        this.m_IsStoryTest = false;
        this.m_IsReviewStory = false;
    }

    public void PlayStory(int mapID, string storyName)
    {
        //if (!Swd6Application.instance.m_Is64BitOS)
        //{
        //    UI_Fight.Instance.Destroy();
        //    UI_FinishFight.Instance.Destroy();
        //}
        //UI_GameAchievementMsg.Instance.SetLockAchievementMsg(true);
        this.m_IsStoryTest = false;
        this.m_IsReviewStory = false;
        this.m_IsStoryEnd = false;
        GameEntry.Instance.ChangeToStoryState(mapID, storyName);
    }

    //	public void PlayReviewStory(int mapID, string storyName)
    //	{
    //		UI_GameAchievementMsg.Instance.SetLockAchievementMsg(true);
    //		this.m_IsStoryTest = false;
    //		this.m_IsReviewStory = true;
    //		this.m_IsStoryEnd = false;
    //		Swd6Application.instance.ChangeToStoryState(mapID, storyName);
    //	}

    public bool IsReviewStory()
    {
        return this.m_IsReviewStory;
    }

    public bool IsStoryTest()
    {
        return this.m_IsStoryTest;
    }

    public bool IsStoryEnd()
    {
        return this.m_IsStoryEnd;
    }

    public void StoryEnd()
    {
        this.m_IsStoryEnd = true;
    }

    public void StoryBegin()
    {
        this.m_IsStoryEnd = false;
    }
}
