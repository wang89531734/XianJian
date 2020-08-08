using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using YouYou;

public class FightSystem
{
    public int m_BattleGroupID;

    public int m_FightPlayerID;

    public float m_FightCameraFOV = 50f;

    public float m_FightCameraMouseX;

    public bool m_bPracticeFight;

    private static FightSystem instance;

    public bool m_LoseAndContinue;

    //public BuffSystem m_BuffSystem = new BuffSystem();

    private GameObject FightEffect;

    public static FightSystem Instance
    {
        get
        {
            if (FightSystem.instance == null)
            {
                FightSystem.instance = new FightSystem();
            }
            return FightSystem.instance;
        }
    }

    public void Fight(int battleGroupID, int fightPlayerID)
    {
        //MusicSystem.Instance.Fade_StopBackgroundMusic(2f);
        //MusicSystem.Instance.PlaySound(1, 1);
        //if (battleGroupID == 7108 && GameTalk.CheckItem(305, 1))
        //{
        //    battleGroupID = 7109;
        //}
        this.m_BattleGroupID = battleGroupID;
        this.m_FightPlayerID = fightPlayerID;
        this.m_LoseAndContinue = false;
        this.m_bPracticeFight = false;
        GameEntry.Instance.StartCoroutine(this.FightCoroutine());
    }

    private IEnumerator FightCoroutine()
    {
        //this.FightEffectIn(true);
        yield return null;
        //while (!this.IsFightEffectInFinish())
        //{
        //    yield return null;
        //}
        UnityEngine.Debug.Log("ÇÐ»»Õ½¶·×´Ì¬");
        GameEntry.Procedure.ChangeState(ProcedureState.GameLevel);
        yield break;
    }

    //	public void FightUnitTest(int battleGroupID)
    //	{
    //		this.m_BattleGroupID = battleGroupID;
    //		this.m_LoseAndContinue = true;
    //		Swd6Application.instance.ChangeToUTFightState();
    //	}

    //	public void FightEnd()
    //	{
    //		Swd6Application.instance.FadeAndPopState2(1f, 1f);
    //	}

    //	public void ReFight()
    //	{
    //		Swd6Application.instance.StartCoroutine(this.DoReFight());
    //	}

    //	[DebuggerHidden]
    //	private IEnumerator DoReFight()
    //	{
    //		return new FightSystem.<DoReFight>c__Iterator88E();
    //	}

    //	public bool IsFightEffectInFinish()
    //	{
    //		return UI_FightEffectIn.Instance.m_FadeWeight <= 0f;
    //	}

    //	public void FightEffectIn(bool enable)
    //	{
    //		if (enable)
    //		{
    //			UI_FightEffectIn.Instance.Show();
    //		}
    //		else
    //		{
    //			UI_FightEffectIn.Instance.Hide();
    //		}
    //	}

    //	public void FightEffectOut(bool enable)
    //	{
    //		if (enable)
    //		{
    //			this.FightEffect = ResourceManager.Instance.GetFightObject("FightEffect");
    //		}
    //		else if (this.FightEffect != null)
    //		{
    //			UnityEngine.Object.Destroy(this.FightEffect);
    //		}
    //	}
}
