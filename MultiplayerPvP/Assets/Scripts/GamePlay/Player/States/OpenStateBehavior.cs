using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStateBehavior : State<UserStateController>
{
    protected Rigidbody2D _rigidbody;
    protected Vector2 _input = Vector2.zero;
    protected bool _dodgePressed = false;

    protected CharacterAnimator _myAnimator;

    public override void Init(UserStateController parent)
    {
        base.Init(parent);
        InputHandler.MoveInputUpdated += NewInput;
        _myAnimator = parent.MyAnimator;
        if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody2D>();
    }

    public override void CaptureInput()
    {

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

    private void NewInput(Vector2 input)
    {
        _input = input;
    }
}
