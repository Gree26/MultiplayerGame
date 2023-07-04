using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class hideWhenCameraClose : MonoBehaviour
{
    private Color _thisColor;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        Color thisColor = _spriteRenderer.color;

    }

    private void FixedUpdate()
    {
        if (_thisColor.a!=0 && Vector2.Distance( Camera.current.transform.position,this.transform.position)<5)
        {
            _thisColor = new Color(0,0,0,0);
            _spriteRenderer.color = _thisColor;
        } else if(_thisColor.a != 255)
        {
            _thisColor = Color.white;
            _spriteRenderer.color = _thisColor;
        }
    }
}
