using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ui
{
    public class AnimationHelper : MonoBehaviour
    {
        /// <summary>
        /// Fade animation handler.
        /// </summary>
        /// <param name="canvasGroup">The canvas group to fade in/out.</param>
        /// <param name="Speed">The speed of the transition.</param>
        /// <param name="OnFinish">Called when the animation is completed.</param>
        /// <returns></returns>
        public static IEnumerator FadeIn(CanvasGroup canvasGroup, float Speed, UnityEvent? OnFinish)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;

            float time = 0;
            while (time < 1)
            {
                //Changes whether we are fading in or out
                canvasGroup.alpha = Mathf.Lerp(0, 1, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            canvasGroup.alpha = 1;
            OnFinish?.Invoke();
        }

        /// <summary>
        /// Fade animation handler.
        /// </summary>
        /// <param name="canvasGroup">The canvas group to fade in/out.</param>
        /// <param name="Speed">The speed of the transition.</param>
        /// <param name="OnFinish">Called when the animation is completed.</param>
        /// <returns></returns>
        public static IEnumerator FadeOut(CanvasGroup canvasGroup, float Speed, UnityEvent? OnFinish)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

            float time = 0;
            while (time < 1)
            {
                //Changes whether we are fading in or out
                canvasGroup.alpha = Mathf.Lerp(1, 0, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            canvasGroup.alpha = 0;
            OnFinish?.Invoke();
        }

        /// <summary>
        /// Scale in horizontaly.
        /// </summary>
        /// <param name="canvasGroup">The canvas group to enable.</param>
        /// <param name="rectTransform">The transform to modify.</param>
        /// <param name="targetWidth">The widt to scale up to.</param>
        /// <param name="speed">The speed to do it at.</param>
        /// <param name="OnFinish">Event to invoke when completed.</param>
        /// <returns></returns>
        public static IEnumerator WidthScaleIn(CanvasGroup canvasGroup, RectTransform rectTransform, float targetWidth, float speed, UnityEvent? OnFinish)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;

            float time = 0;

            canvasGroup.alpha = 1;

            float startWidth = rectTransform.rect.width;

            while (time < 1)
            {
                //Changes whether we are fading in or out
                canvasGroup.alpha = Mathf.Lerp(0, targetWidth, time);
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(startWidth, targetWidth, time));
                yield return null;
                time += Time.deltaTime * speed;
            }

            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
            OnFinish?.Invoke();
        }

        /// <summary>
        /// Scale out horizontaly.
        /// </summary>
        /// <param name="canvasGroup">The canvas group to disable.</param>
        /// <param name="rectTransform">The transform to manipulate.</param>
        /// <param name="speed">The speed to do it at.</param>
        /// <param name="OnFinish">Event to invoke when completed.</param>
        /// <returns></returns>
        public static IEnumerator WidthScaleOut(CanvasGroup canvasGroup, RectTransform rectTransform, float speed, UnityEvent? OnFinish)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

            float time = 0;
            float startWidth = rectTransform.rect.width;

            while (time < 1)
            {
                //Changes whether we are fading in or out
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(startWidth, 0, time));
                yield return null;
                time += Time.deltaTime * speed;
            }

            canvasGroup.alpha = 0;
            OnFinish?.Invoke();
        }

        /// <summary>
        /// Zoom enter handler.
        /// </summary>
        /// <param name="transform">The transform of the object to be zoomed on.</param>
        /// <param name="Speed">Speed of the zoome.</param>
        /// <param name="OnFinish">UnityEvent to be called when completed.</param>
        /// <returns></returns>
        public static IEnumerator ZoomIn(RectTransform transform, float Speed, UnityEvent? OnFinish)
        {
            float time = 0;
            while (time < 1)
            {
                //Changes whether we are fading in or out
                transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            transform.localScale = Vector3.one;
            OnFinish?.Invoke();
        }

        /// <summary>
        /// Zoom enter handler.
        /// </summary>
        /// <param name="transform">The transform of the object to be zoomed on.</param>
        /// <param name="Speed">Speed of the zoome.</param>
        /// <param name="OnFinish">UnityEvent to be called when completed.</param>
        /// <returns></returns>
        public static IEnumerator ZoomOut(RectTransform transform, float Speed, UnityEvent? OnFinish)
        {
            float time = 0;
            while (time < 1)
            {
                //Changes whether we are fading in or out
                transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            transform.localScale = Vector3.zero;
            OnFinish?.Invoke();
        }
    }
}
