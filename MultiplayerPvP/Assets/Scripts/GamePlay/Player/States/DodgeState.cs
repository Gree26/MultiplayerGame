using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Character/Dodge")]
public class DodgeState : State<UserStateController>
{
    [SerializeField]
    private int _dodgeIFrames = 25;

    private int _currentFrame = 0;

    private CharacterAnimator _myAnimator;

    public override void Init(UserStateController parent)
    {
        base.Init(parent);
        parent.StartDodgeCooldown();
        _myAnimator = parent.MyAnimator;
        _myAnimator.UpperState = CharacterAnimator.CharacterUpperState.DODGE;
        _myAnimator.LowerState = CharacterAnimator.CharacterLowerState.DODGE;
        Debug.Log("Dodge Entered");
    }

    public override void CaptureInput()
    {
        
    }

    public override void ChangeState()
    {
        if (_currentFrame > _dodgeIFrames)
        {
            _runner.SetState(typeof(IdleState));
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
        _currentFrame++;
    }
}