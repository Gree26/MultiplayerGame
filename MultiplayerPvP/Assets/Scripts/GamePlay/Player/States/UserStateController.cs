using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

public class UserStateController : StateRunner<UserStateController>
{
    [HideInInspector]
    public DefaultInputActionBinding DefaultInputActionBinding;

    [HideInInspector]
    public CharacterAnimator MyAnimator;

    private float _moveSpeed = 5f;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField]
    private float _dodgeDelay = 0.5f;
    private bool _canDodge = true;
    /// <summary>
    /// Is the player not on ddoge cool down.
    /// </summary>
    public bool CanDodge { get { return _canDodge; } }

    private Vector2 _direction = Vector2.right;

    /// <summary>
    /// Shows the last direction inputed while moving. Used for dodging, blocking, etc. 
    /// </summary>
    public Vector2 Direction { get { return _direction; } set { if (value != Vector2.zero) _direction = value; } }

    protected override void Awake()
    {
        MyAnimator = this.GetComponent<CharacterAnimator>();
        DefaultInputActionBinding = new DefaultInputActionBinding();
        base.Awake();
    }

    /// <summary>
    /// Calling this will start the delay countdown for the dodge.
    /// </summary>
    public void StartDodgeCooldown()
    {
        if (_canDodge)
        {
            StartCoroutine(DodgeCoolDown());
        }
    }

    private IEnumerator DodgeCoolDown()
    {
        _canDodge = false;

        yield return new WaitForSeconds(_dodgeDelay);

        _canDodge = true;
    }
}
