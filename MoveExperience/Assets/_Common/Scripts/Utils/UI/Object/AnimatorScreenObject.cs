///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 26/04/2020 15:24
///-----------------------------------------------------------------

using System;
using UnityEngine;

namespace Com.IsartDigital.Four.Common.UI.Object {
	[RequireComponent(typeof(Animator))]
	public class AnimatorScreenObject : ScreenObject {

		protected Animator animator;

        private static readonly int isAppearHash = Animator.StringToHash("IsAppear");
        private static readonly int appearHash = Animator.StringToHash("Appear");
        private static readonly int disappearHash = Animator.StringToHash("Disappear");

        public override void Init()
        {
            base.Init();
            animator = GetComponent<Animator>();
        }

        private void UpdateAnimator()
        {
            animator.SetBool(isAppearHash, isAppear);
        }

        #region Appear

        public override void Appear()
        {
            base.Appear();
            UpdateAnimator();
        }

        public override void ForceAppear()
        {
            base.Appear();
            animator.Play(appearHash, 0, 1);
            UpdateAnimator();
        }

        #endregion

        #region Disappear

        public override void Disappear()
        {
            base.Disappear();
            UpdateAnimator();
        }

        public override void ForceDisappear()
        {
            base.Disappear();
            animator.Play(disappearHash, 0, 1);
            UpdateAnimator();
        }

        #endregion
    }
}