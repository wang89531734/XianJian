using System;
using UnityEngine;


public class AnimatorMoveClient : MonoBehaviour
{
    public AnimatorMoveClient.AnimatorMoveApplyFunc apply;

    public delegate void AnimatorMoveApplyFunc();

    private void OnAnimatorMove()
	{
		if (this.apply != null)
		{
			this.apply();
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}
