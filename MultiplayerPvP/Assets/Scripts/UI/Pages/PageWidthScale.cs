using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ui;

namespace UI
{
    public class PageWidthScale : Page
    {
        private float _startWidth;

        private void Awake()
        {
            _startWidth = this.GetComponent<RectTransform>().rect.width;
            this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }

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

            _animationCoroutine = StartCoroutine(AnimationHelper.WidthScaleIn(_canvasGroup, this.GetComponent<RectTransform>(), _startWidth, _animationSpeed, null));

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

            _animationCoroutine = StartCoroutine(AnimationHelper.WidthScaleOut(_canvasGroup, this.GetComponent<RectTransform>(), _animationSpeed, null));

            PlayExitClip(playAudio);
        }
    }
}
