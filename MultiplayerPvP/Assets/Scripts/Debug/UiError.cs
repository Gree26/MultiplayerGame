using Debugers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiError : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _thisCanvasGroup;

    [SerializeField]
    private Text _errorText;

    [SerializeField]
    private float _fadeSpeed = .05f;

    private Queue<Failed> _failedMessages = new Queue<Failed>();

    private Coroutine _messagePlay;

    private void OnEnable()
    {
        Failed.ActionFailed += ActionFailed;
    }

    private void OnDisable()
    {
        Failed.ActionFailed -= ActionFailed;
    }

    private void ActionFailed(Failed failedAction)
    {
        _failedMessages.Enqueue(failedAction);

        if (_messagePlay == null)
        {
            _messagePlay = StartCoroutine(TextFlashCoroutine());
        }
        else
        {
            StopCoroutine(_messagePlay);
            _messagePlay = null;
            _thisCanvasGroup.alpha = 0;
            _messagePlay = StartCoroutine(TextFlashCoroutine());
        }
    }

    private IEnumerator TextFlashCoroutine()
    {
        while (_failedMessages.Count > 0)
        {
            var currentMessage = _failedMessages.Dequeue();
            _errorText.text = currentMessage.FailMessage();
            _thisCanvasGroup.alpha = 1f;
            while (_thisCanvasGroup.alpha > 0)
            {
                yield return null;
                _thisCanvasGroup.alpha = Mathf.Clamp(_thisCanvasGroup.alpha-_fadeSpeed, 0, 1);
            }
        }
        _thisCanvasGroup.alpha = 0;
        _messagePlay = null;
    }
}
