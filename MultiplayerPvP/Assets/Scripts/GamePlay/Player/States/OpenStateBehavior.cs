using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStateBehavior : State<UserStateController>
{
    protected Rigidbody2D _rigidbody;
    protected Vector2 _input;
    protected DefaultInputActionBinding _defaultInputActionBinding;
    protected bool _dodgePressed = false;

    protected CharacterAnimator _myAnimator;

    public override void Init(UserStateController parent)
    {
        base.Init(parent);
        _myAnimator = parent.MyAnimator;
        if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody2D>();
        if (_defaultInputActionBinding == null) _defaultInputActionBinding = parent.DefaultInputActionBinding;
    }

    public override void CaptureInput()
    {
        _input = _defaultInputActionBinding.Player.Movement.ReadValue<Vector2>();
        _dodgePressed = _defaultInputActionBinding.Player.Dodge.ReadValue<bool>();
    }

    public override void ChangeState()
    {
        if (_dodgePressed && _runner.CanDodge)
        {
            _runner.SetState(typeof(DodgeState));
        }
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        
    }
}
