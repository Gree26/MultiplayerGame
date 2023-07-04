using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ui
{
    [RequireComponent(typeof(AudioSource), typeof(CanvasGroup))]
    [DisallowMultipleComponent]
    public abstract class Page : MonoBehaviour
    {
        protected AudioSource _audioSource;
        protected RectTransform _rectTransform;
        protected CanvasGroup _canvasGroup;

        [SerializeField]
        protected float _animationSpeed = 1f;
        public bool ExitOnNewPagePush = false;

        [SerializeField]
        protected AudioClip _entryClip;
        [SerializeField]
        protected AudioClip _exitClip;

        protected Coroutine _animationCoroutine;
        protected Coroutine _audioCoroutine;


        private void Awake()
        {
            _rectTransform = this.GetComponent<RectTransform>();
            _canvasGroup = this.GetComponent<CanvasGroup>();
            _audioSource = this.GetComponent<AudioSource>();

            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
            _audioSource.spatialBlend = 0;
            _audioSource.enabled = false;
        }

        /// <summary>
        /// Called on entry to this page
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        public abstract void Enter(bool playAudio);

        /// <summary>
        /// Called on entry to this page
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        public abstract void Exit(bool playAudio);

        /// <summary>
        /// Play the fade animation
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        private void FadeIn(bool playAudio)
        {
            if(_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }

            _animationCoroutine = StartCoroutine(AnimationHelper.FadeIn(_canvasGroup, _animationSpeed, null));

            PlayEntryClip(playAudio);
        }

        /// <summary>
        /// Play the fade animation
        /// </summary>
        /// <param name="playAudio">Should this Play audio?</param>
        private void FadeOut(bool playAudio)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }

            _animationCoroutine = StartCoroutine(AnimationHelper.FadeOut(_canvasGroup, _animationSpeed, null));

            PlayExitClip(playAudio);
        }

        protected void PlayEntryClip(bool playAudio)
        {
            if (_entryClip != null && _audioSource != null)
            {
                if(_audioCoroutine != null)
                {
                    StopCoroutine(_audioCoroutine);
                }

                _audioCoroutine = StartCoroutine(PlayClip(_entryClip));
            }
        }

        protected void PlayExitClip(bool playAudio)
        {
            if (_exitClip != null && _audioSource != null)
            {
                if (_audioCoroutine != null)
                {
                    StopCoroutine(_audioCoroutine);
                }

                _audioCoroutine = StartCoroutine(PlayClip(_exitClip));
            }
        }

        private IEnumerator PlayClip(AudioClip clip)
        {
            _audioSource.enabled = true;

            WaitForSeconds wait = new WaitForSeconds(clip.length);

            _audioSource.PlayOneShot(clip);

            yield return wait;

            _audioSource.enabled = false;
        }


    }

    
}
