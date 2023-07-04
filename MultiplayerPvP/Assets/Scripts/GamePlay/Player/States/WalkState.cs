using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Character/Walk")]
    public class WalkState : OpenStateBehavior
    {
        [SerializeField]
        private float _moveSpeed = 1;
        private float _moveSpeedModifier = 0;

        public override void Init(UserStateController parent)
        {
            base.Init(parent);
            Debug.Log("Walk Entered");
        }

        public override void CaptureInput()
        {
            base.CaptureInput();
            if (_input == Vector2.zero)
            {
                _runner.SetState(typeof(IdleState));
            }
        }

        public override void ChangeState()
        {
            base.ChangeState();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            _rigidbody.MovePosition(_rigidbody.position + (_input * (_moveSpeed + _moveSpeedModifier) * Time.fixedDeltaTime));
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
