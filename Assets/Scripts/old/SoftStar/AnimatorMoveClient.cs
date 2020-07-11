using System;
using UnityEngine;

namespace SoftStar
{
	public class AnimatorMoveClient : MonoBehaviour
	{
        public AnimatorMoveClient.AnimatorMoveApplyFunc apply;

        private Animator animator;

        public delegate void AnimatorMoveApplyFunc(Animator animator);


        private void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}


		private void OnAnimatorMove()
		{
			if (this.apply != null && this.animator != null)
			{
				this.apply(this.animator);
			}
		}
	}
}
