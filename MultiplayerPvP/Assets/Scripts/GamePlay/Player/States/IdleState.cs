using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Character/Idle")]
    public class IdleState : OpenStateBehavior
    {
        public override void Init(UserStateController parent)
        {
            base.Init(parent);
            //Debug.Log("Idle Entered");
        }

        public override void CaptureInput()
        {
            base.CaptureInput();
        }

        public override void ChangeState()
        {
            base.ChangeState();
            Debug.Log("_input: " + _input);
            if (_input != Vector2.zero)
            {
                _runner.SetState(typeof(WalkState));
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
