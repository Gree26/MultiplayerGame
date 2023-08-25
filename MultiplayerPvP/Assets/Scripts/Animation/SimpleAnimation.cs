using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleAnimation : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _frames;

    [SerializeField]
    private float _delayBetweenFrames = 1f;

    private Image _imageComponent;

    private Coroutine _animationCoroutine;

    private void OnEnable()
    {
        _imageComponent = this.GetComponent<Image>();

        _animationCoroutine = StartCoroutine(PlayAnimation());
        _imageComponent.sprite = _frames[0];
    }

    private void OnDisable()
    {
        StopCoroutine(_animationCoroutine);
    }

    private IEnumerator PlayAnimation()
    {
        int _currentFrame = 0;

        while (true)
        {
            yield return new WaitForSeconds(_delayBetweenFrames);
            _currentFrame++;
            if (_currentFrame >= _frames.Count)
            {
                _currentFrame = 0;
            }
            _imageComponent.sprite = _frames[_currentFrame];
        }
    }
}
