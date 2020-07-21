using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class NewGame : MonoBehaviour
{
	[DebuggerHidden]
	public IEnumerator DoTalk()
	{
        //GameTalk.StartTalk(true);
        //yield return base.StartCoroutine(GameTalk.WaitFadeTime(1f, 2f));
        //GameTalk.AddItem(901, 3, false);
        //GameTalk.AddItem(921, 3, false);
        //GameTalk.AddMoney(200, false);
        //GameTalk.FlagOFF(61);
        //GameTalk.FlagOFF(62);
        //GameTalk.FlagOFF(63);
        //GameTalk.FlagOFF(64);
        //GameObject listener = GameObject.Find("Menu Listener");
        //if (listener != null && listener.GetComponent<AudioListener>() != null)
        //{
        //    listener.GetComponent<AudioListener>().enabled = false;
        //}
        //if (!GameTalk.GetFlag(1001))
        //{
        //    GameTalk.FlagON(1001);
        //}
        //GameTalk.StartTalk(false);
        //GameTalk.HideAllNpc(1);
        GameTalk.PlayStory(100, "ME0000");
        //yield return base.StartCoroutine(GameTalk.IsPlayStoryEnd());
        yield return null;
        yield break;
    }
}
