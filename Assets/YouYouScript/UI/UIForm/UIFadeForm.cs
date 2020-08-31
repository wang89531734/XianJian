using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 战斗面板
/// </summary>
public class UIFadeForm : UIFormBase
{
    public RawImage m_Image;

    Tweener tweenAlpha;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        
        FadeTo();
    }

    public void FadeTo()
    {
        m_Image.DOFade(0,3f);
        //this.m_FadeTexture.mainTexture = this.m_BlackTexture;
        //StopAllCoroutines();
        //this.Show();
        //if (time == 0f)
        //{
        //    //TweenAlpha component = this.m_FadeTexture.GetComponent<TweenAlpha>();
        //    //if (component != null)
        //    //{
        //    //    component.enabled = false;
        //    //}
        //    //this.m_FadeTexture.alpha = amount;
        //    //if (amount == 0f)
        //    //{
        //    //    this.Hide();
        //    //}
        //    return;
        //}
        //Tween.Begin(this.m_FadeTexture.gameObject, time, amount);
        //if (amount == 0f)
        //{
        //    base.StartCoroutine(this.Hide(time));
        //}
    }

    protected override void OnBeforDestroy()
    {
        base.OnBeforDestroy();
    }
}
