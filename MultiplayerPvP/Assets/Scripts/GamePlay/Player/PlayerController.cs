using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterAnimator))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float speedMultiplier = 5f;
    [HideInInspector]
    public DefaultInputActionBinding DefaultInputActionBinding;

    private CharacterAnimator myAnimator;

    private Vector2 _inputVector = Vector2.zero;

    private List<InteractionBehavior> objectsToBeInteracted = new List<InteractionBehavior>();

    [SerializeField]
    private float _dodgeSpeed = 0.1f;
    [SerializeField]
    private float _dodgeMoveSpeedModifier = 2.5f;
    private float _dodgeModifier = 0;
    private bool _dodging = false;
    private Coroutine _dodgingCoroutine;


    // -- NEW STUFF -- \\
    private float _moveSpeed = 5f;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField]
    private float _dodgeDelay = 0.5f;
    private bool _canDodge = true;
    /// <summary>
    /// Is the player not on ddoge cool down.
    /// </summary>
    public bool CanDodge { get { return _canDodge; } }

    private Vector2 _lastDirection = Vector2.right;

    /// <summary>
    /// Shows the last direction inputed while moving. Used for dodging, blocking, etc. 
    /// </summary>
    public Vector2 LastDirection { get { return _lastDirection; } set { if (value != Vector2.zero) _lastDirection = value; } }

    [SerializeField]
    private float _attackSpeed = 0.1f;
    private Coroutine _attackCoroutine;

    [HideInInspector]
    public Vector2 InputVector
    {
        get { return _inputVector; }
        set
        {
            bool changed = (value != InputVector);
            _inputVector = value;
            if (changed)
            {
                DirectionChanged();
            }
        }
    }

    private Action UpdateEvent;

    //[SerializeField]
    //private List<GameObject> _lookAtObjects;

    private void Awake()
    {
        _input = this.GetComponent<PlayerInput>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
        myAnimator = this.GetComponent<CharacterAnimator>();
        DefaultInputActionBinding = new DefaultInputActionBinding();

        DefaultInputActionBinding.Player.Enable();
        DefaultInputActionBinding.Player.Dodge.started += DodgePressed;
        //defaultInputActionBinding.Player.Movement.performed += MoveInDirection;
        //defaultInputActionBinding.Player.Attack.performed += AttackPerformed;
        //defaultInputActionBinding.Player.Movement.performed += MovementPerformed;
    }

    private void Update()
    {
        InputVector = DefaultInputActionBinding.Player.Movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + (InputVector * (speedMultiplier + _dodgeModifier) * Time.fixedDeltaTime));
    }

    /// <summary>
    /// Invoked when there is a new value for the input vector
    /// </summary>
    private void DirectionChanged()
    {
        Vector2Int inputVector = Vector2Int.zero;

        inputVector = new Vector2Int((int)((_inputVector.x == 0) ? 0:_inputVector.x/Mathf.Abs(_inputVector.x)), (int)((_inputVector.y == 0) ? 0 : (_inputVector.y / Mathf.Abs(_inputVector.y))));

        if (_inputVector.Equals(Vector2.zero))
        {
            myAnimator.Direction = inputVector;
            myAnimator.State = CharacterAnimator.CharacterState.IDLE;
        }
        else
        {
            myAnimator.Direction = inputVector;
            myAnimator.State = CharacterAnimator.CharacterState.RUN;
        }
    }

    private void InteractPressed()
    {
        if (objectsToBeInteracted.Count == 0)
        {
            return;
        }

        //objectsToBeInteracted
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

    private void DodgePressed(InputAction.CallbackContext context)
    {
        if (_dodgingCoroutine != null || _attackCoroutine != null)
        {
            return;
        }

        //Debug.Log("Dodge Pressed");

        _dodgingCoroutine = StartCoroutine(PerformDodge());
    }

    private IEnumerator PerformDodge()
    {
        int loops = 0;
        _dodgeModifier = _dodgeMoveSpeedModifier;
        //myAnimator.Dodge();
        while (loops < 10)
        {
            _dodgeModifier = _dodgeMoveSpeedModifier * (10-loops);
            yield return new WaitForSeconds(_dodgeSpeed / 10);

            loops++;
        }
        _dodgeModifier = 0;

        _dodgingCoroutine = null;
    }

    /// <summary>
    /// Used to add an interactable when in range. accessed by interactable script.
    /// </summary>
    /// <param name="interactionBehavior"></param>
    public void NewInteractableInRange(InteractionBehavior interactionBehavior)
    {
        objectsToBeInteracted.Add(interactionBehavior);
    }
    /// <summary>
    /// Used to remove an interactable when in range. accessed by interactable script.
    /// </summary>
    /// <param name="interactionBehavior"></param>
    public void RemoveInteractable (InteractionBehavior interactionBehavior)
    {
        objectsToBeInteracted.Remove(interactionBehavior);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable interactionObject;
        if (!collision.gameObject.TryGetComponent<Interactable>(out interactionObject))
        {
            return;
        }

        NewInteractableInRange(interactionObject.behavior);

        //EnterInteractionRange.Invoke();
        //PlayerInventory.OnHotbarSelectedItemChange += RefreshUI;
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        Interactable interactionObject;
        if (!collision.gameObject.TryGetComponent<Interactable>(out interactionObject))
        {
            return;
        }

        RemoveInteractable(interactionObject.behavior);

        //ExitInteractionRange.Invoke();
    }
}
