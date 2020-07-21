using System;
using UnityEngine;

public class MenuState : SceneState
{
	protected new Swd6Application gameApplication
	{
		get
		{
			return this.gameApplication as Swd6Application;
		}
	}

	public MenuState(string name, string sceneName, GameApplication gameApplication) : base(name, sceneName, gameApplication)
	{
	}

	public override void begin()
	{
		base.begin();
        UnityEngine.Debug.Log("MenuState!!");
        //this.gameApplication.m_StorySystem.StoryEnd();
        //GameObject gameObject = GameObject.Find("Menu Listener");
        //if (gameObject != null && gameObject.GetComponent<AudioListener>() != null)
        //{
        //    gameObject.GetComponent<AudioListener>().enabled = true;
        //}
        //Swd6Application.instance.m_AchievementSystem.InitForNewGame();
        //Swd6Application.instance.m_SaveloadSystem.m_AutoSave = true;
        //UI_TitleMenu.Instance.Show();
        //UI_Fade.Instance.FadeTo(0f, 1f);
        //UI_TitleMenu.Instance.PlayMenuMusic();
        //MusicSystem.Instance.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
        //Resources.UnloadUnusedAssets();
    }

	public override void end()
	{
		base.end();
		//UI_TitleMenu.Instance.Hide();
		//MusicSystem.Instance.Fade_StopBackgroundMusic(3f);
	}

	public override void suspend()
	{
		GameObject gameObject = GameObject.Find("Menu Listener");
		if (gameObject != null && gameObject.GetComponent<AudioListener>() != null)
		{
			gameObject.GetComponent<AudioListener>().enabled = false;
		}
		//UI_TitleMenu.Instance.Hide();
		//MusicSystem.Instance.StopBackgroundMusic();
	}

	public override void resume()
	{
		GameObject gameObject = GameObject.Find("Menu Listener");
		if (gameObject != null && gameObject.GetComponent<AudioListener>() != null)
		{
			gameObject.GetComponent<AudioListener>().enabled = true;
		}
		//UI_TitleMenu.Instance.Show();
		//MusicSystem.Instance.m_StoryMusicExtendMode = ENUM_MusicExtendMode.NOW;
	}
}
