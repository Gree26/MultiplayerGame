using System.Collections;
using System.Collections.Generic;
using Ui;
using UnityEngine;

namespace UI
{
    public class PageFade : Page
    {
        /// <summary>
        /// Called on entry to this page
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        public override void Enter(bool playAudio)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }

            _animationCoroutine = StartCoroutine(AnimationHelper.FadeIn(_canvasGroup, _animationSpeed, null));

            PlayEntryClip(playAudio);
        }

        /// <summary>
        /// Called on entry to this page
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        public override void Exit(bool playAudio)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }

            _animationCoroutine = StartCoroutine(AnimationHelper.FadeOut(_canvasGroup, _animationSpeed, null));

            PlayExitClip(playAudio);
        }
    }
}
