using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [RequireComponent(typeof(CanvasGroup))]
    [AddComponentMenu("UI/Blur Panel")]
    public class BlurPanel : Image
    {
        public bool animate;
        public float time = 0.5f;
        public float delay = 0f;

        CanvasGroup canvas;

        protected override void Reset()
        {
            base.Reset();
            color = Color.black * 0.1f;
        }

        protected override void Awake()
        {
            base.Awake();
            canvas = GetComponent<CanvasGroup>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            if (Application.isPlaying)
            {
                AlphaBlur(0);
                StartCoroutine(Tween());
            }
        }

        /// <summary>
        /// Coroutine for moving to a given position
        /// </summary>
        /// <returns></returns>
        private IEnumerator Tween()
        {
            float time = 0;
            while (time < delay)
            {
                yield return null;
                time += Time.deltaTime;
            }

            time = 0;
            while (time < 1)
            {
                AlphaBlur(time);
                yield return null;
                time += Time.deltaTime * this.time;
            }

            AlphaBlur(1);
        }

        private void AlphaBlur(float amount)
        {
            material.SetFloat("_Size", amount);
            canvas.alpha = amount;
        }
    }
}
