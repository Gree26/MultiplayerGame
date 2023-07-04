using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private GameObject _lightAttack;

    [SerializeField]
    private GameObject _heavyAttack;

    [ContextMenuItem("Light Attack", "Light attack attributes.")]
    [SerializeField]
    private string name = "DEFAULT";

    private DefaultInputActionBinding defaultInputActionBinding;
    private PlayerInput _input;

    private Vector2 _inputVector = Vector2.zero;


    private float _weaponRotationOffset = 0f;

    float lookAt = 0f;

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

    private void OnEnable()
    {
        //defaultInputActionBinding.Player.PressAttack.performed += Tapped;
        defaultInputActionBinding.Player.PressAttack.started += StartCharge;
        defaultInputActionBinding.Player.PressAttack.performed += Charged;
        defaultInputActionBinding.Player.PressAttack.canceled += Canceled;
        defaultInputActionBinding.Player.Enable();
    }

    private void Canceled(InputAction.CallbackContext obj)
    {

    }
    private void Charged(InputAction.CallbackContext obj) => Debug.Log("Holding Charged!");
    private void StartCharge(InputAction.CallbackContext obj) => Debug.Log("Holding Started Charging...");
    //private void Tapped(InputAction.CallbackContext obj) => Debug.Log("Tapped");


    private void Awake()
    {
        _input = this.GetComponent<PlayerInput>();
        defaultInputActionBinding = new DefaultInputActionBinding();

        //defaultInputActionBinding.Player.Attack.performed += LightAttackPerformed;

        defaultInputActionBinding.Player.PressAttack.performed += context =>
        {
           if (context.interaction is TapInteraction)
            {
                Debug.Log("Light Attack");
                VisableWeapon(true);
            }
            if (context.interaction is SlowTapInteraction)
            {
                Debug.Log("Heavy Attack");
                VisableWeapon(false);
            }
        };

        //defaultInputActionBinding.Player.Movement.performed += MovementPerformed;
        VisableWeapon(true);
    }

    private void FixedUpdate()
    {
        InputVector = defaultInputActionBinding.Player.Movement.ReadValue<Vector2>();
        DirectionChanged();
    }

    /// <summary>
    /// Handle input from new input system for attacks
    /// </summary>
    /// <param name="context"></param>
    private void LightAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private void VisableWeapon(bool isLight)
    {
        _lightAttack.SetActive(isLight);
        _heavyAttack.SetActive(!isLight);
    }

    private void DirectionChanged()
    {
        if (InputVector == Vector2.zero)
            return;

        //float x = Mathf.Abs( InputVector.x);
        //mousePosition -= this.transform.position;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        float x = Mathf.Abs(InputVector.x);
        float y = Mathf.Abs(InputVector.y);
        //if (mousePos.x-this.transform.position.x == 0 && mousePos.y - this.transform.position.y == 0)
            //return;

        //float x = mousePosition.x - this.transform.position.x;
        //float y = mousePosition.y - this.transform.position.y;



        //var lookAt = InputVector.x, InputVector.y, this.transform.position.z;
        //float lookAt = (x!=0)? ((Mathf.Atan(y/x)) * 180 / Mathf.PI) : (y>0)? 90 : -90;
        float lookAt = ((Mathf.Atan(y / x)) * 180 / Mathf.PI);

        if (x < 0)
        {
            lookAt += 180f;
            _lightAttack.transform.localScale = new Vector3(_lightAttack.transform.localScale.x, -Mathf.Abs( _lightAttack.transform.localScale.y), _lightAttack.transform.localScale.z);
            _heavyAttack.transform.localScale = new Vector3(_heavyAttack.transform.localScale.x, -Mathf.Abs(_heavyAttack.transform.localScale.y), _heavyAttack.transform.localScale.z);
        }
        else
        {
            _lightAttack.transform.localScale = new Vector3(_lightAttack.transform.localScale.x, Mathf.Abs(_lightAttack.transform.localScale.y), _lightAttack.transform.localScale.z);
            _heavyAttack.transform.localScale = new Vector3(_heavyAttack.transform.localScale.x, Mathf.Abs(_heavyAttack.transform.localScale.y), _heavyAttack.transform.localScale.z);
        }

        //if (lookAt == 90 || lookAt == -90)
          //  lookAt = (this.transform.localScale.x > 0) ? lookAt : -lookAt;

        Vector3 zAxis = new Vector3(0,0,1);

        //Debug.Log("Look at rotation: " + lookAt);

        _lightAttack.transform.rotation = Quaternion.Euler( zAxis * (lookAt + _weaponRotationOffset));

        _heavyAttack.transform.rotation = Quaternion.Euler( zAxis * (lookAt + _weaponRotationOffset));
    }
}
