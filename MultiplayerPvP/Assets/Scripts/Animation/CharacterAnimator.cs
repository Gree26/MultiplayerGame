using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    public enum CharacterUpperState
    {
        IDLE,
        RUN,
        DRINK,
        DODGE,
        ATTACK
    }

    public enum CharacterLowerState
    {
        IDLE,
        ATTACK,
        RUN,
        DODGE
    }

    public enum AttackType
    {
        LIGHT,
        HEAVY
    }

    public enum MoveDirection
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    private MoveDirection _currentDirection = MoveDirection.EAST;

    public MoveDirection CurrentDirection
    {
        set
        {
            Debug.Log("Updating direction");
            var newDierction = _currentDirection != value;
            var previousDirection = _currentDirection;
            _currentDirection = value;
            // Is the value given a new value? 
            if (newDierction)
                NewDirection(previousDirection);
        }
    }

    private CharacterUpperState _upperState = CharacterUpperState.IDLE;

    public CharacterUpperState UpperState
    {
        set
        {
            var newValue = _upperState != value;
            _upperState = value;
            if (newValue)
                UpperAnimationStateChnge();
        }
    }

    private CharacterLowerState _lowerState = CharacterLowerState.IDLE;

    public CharacterLowerState LowerState
    {
        set
        {
            var newValue = _lowerState != value;
            _lowerState = value;
            if (newValue)
                LowerAnimationStateChnge();
        }
    }

    [SerializeField]
    private MonoAnimationor _upperBody;

    [SerializeField]
    private MonoAnimationor _lowerBody;

    [SerializeField]
    private MonoAnimationor _helmet;

    [SerializeField]
    private MonoAnimationor _chest;

    [SerializeField]
    private MonoAnimationor _legs;

    [SerializeField]
    private MonoAnimationor _lightWeapon;

    [SerializeField]
    private MonoAnimationor _heavyWeapon;

    CancellationTokenSource cts;

    // Gear/Player Animations 
    [SerializeField]
    private SCharacterAnimations character;
    [SerializeField]
    private SHelmetItem _helmetItem;
    [SerializeField]
    private SChestItem _chestItem;
    [SerializeField]
    private SLegItem _legItem;
    [SerializeField]
    private SLightWeaponItem _lightWeaponItem;
    [SerializeField]
    private SHeavyWeaponItem _heavyWeaponItem;

    private Vector2Int _direction = Vector2Int.right;

    private List<Sprite> _characterUpperIdle, _characterUpperMove, _characterUpperDrink, _characterUpperAttack, _characterUpperDodge;
    private List<Sprite> _characterLowerIdle, _characterLowerMove, _characterLowerDrink, _characterLowerAttack, _characterLowerDodge;
    private List<Sprite> _helmetIdle, _helmetMove, _helmetDrink, _helmetAttack, _helmetDodge;
    private List<Sprite> _chestIdle, _chestMove, _chestDrink, _chestAttack, _chestDodge;
    private List<Sprite> _legsIdle, _legsMove, _legsDrink, _legsAttack, _legsDodge;
    private List<Sprite> _lwIdle, _lwMove, _lwDrink, _lwAttack, _lwDodge;
    private List<Sprite> _hwIdle, _hwMove, _hwDrink, _hwAttack, _hwDodge;

    public Vector2Int Direction 
    {
        set
        {
            Vector2Int newValue = new Vector2Int(((value.x != 0) ? value.x / Mathf.Abs(value.x) : 0), ((value.y != 0) ? value.y / Mathf.Abs(value.y) : 0));
            bool isNew = newValue != _direction;
            _direction = newValue;

            if (isNew && newValue!=Vector2Int.zero)
            {
                NewDirection(_direction);
            }
        }
    }

    private void Awake()
    {
        NewDirection(Vector2Int.right);
        AsyncAnimationHandler();
        UpdateAnimation(true);
    }

    private void NewDirection(Vector2Int inputDirection)
    {
        if (inputDirection.x >= 1)
        {
            CurrentDirection = MoveDirection.EAST;
            return;
        }

        if (inputDirection.x <= -1)
        {
            CurrentDirection = MoveDirection.WEST;
            return;
        }

        if (inputDirection.y > 0)
        {
            CurrentDirection = MoveDirection.NORTH;
            return;
        }

        if (inputDirection.y < 0)
        {
            CurrentDirection = MoveDirection.SOUTH;
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="previousDirection"></param>
    private void NewDirection(MoveDirection previousDirection)
    {
        switch (_currentDirection)
        {
            case MoveDirection.NORTH:
                NorthAnimations();
                break;
            case MoveDirection.EAST:
                EastAnimations();
                break;
            case MoveDirection.SOUTH:
                SouthAnimations();
                break;
            case MoveDirection.WEST:
                WestAnimations();
                break;
            default:
                UpperState = CharacterUpperState.IDLE;
                LowerState = CharacterLowerState.IDLE;
                break;
        }
        UpdateAnimation(false);
    }

    private void UpdateAnimation(bool reset)
    {
        switch (_upperState)
        {
            case CharacterUpperState.IDLE:
                _upperBody.NewAnimation(_characterUpperIdle, false);
                _chest.NewAnimation(_chestIdle, false);
                _helmet.NewAnimation(_helmetIdle, false);
                _lightWeapon.NewAnimation(_lwIdle, false);
                break;
            case CharacterUpperState.RUN:
                _upperBody.NewAnimation(_characterUpperMove, false);
                _chest.NewAnimation(_chestMove, false);
                _helmet.NewAnimation(_helmetMove, false);
                _lightWeapon.NewAnimation(_lwMove, false);
                break;
            case CharacterUpperState.DODGE:
                _upperBody.NewAnimation(_characterUpperDodge, false);
                _chest.NewAnimation(_chestDodge, false);
                _helmet.NewAnimation(_helmetDodge, false);
                _lightWeapon.NewAnimation(_lwDodge, false);
                break;
            case CharacterUpperState.DRINK:
                _upperBody.NewAnimation(_characterUpperDrink, false);
                _chest.NewAnimation(_chestDrink, false);
                _helmet.NewAnimation(_helmetDrink, false);
                _lightWeapon.NewAnimation(_lwDrink, false);
                break;
            case CharacterUpperState.ATTACK:
                _upperBody.NewAnimation(_characterUpperAttack, false);
                _chest.NewAnimation(_characterUpperAttack, false);
                _helmet.NewAnimation(_characterUpperAttack, false);
                _lightWeapon.NewAnimation(_characterUpperAttack, false);
                break;
        }

        switch (_lowerState)
        {
            case CharacterLowerState.IDLE:
                _lowerBody.NewAnimation(_characterLowerIdle, false);
                _legs.NewAnimation(_legsIdle, false);
                break;
            case CharacterLowerState.RUN:
                _lowerBody.NewAnimation(_characterLowerMove, false);
                _legs.NewAnimation(_legsMove, false);
                break;
            case CharacterLowerState.DODGE:
                _lowerBody.NewAnimation(_characterLowerDodge, false);
                _legs.NewAnimation(_legsDodge, false);
                break;
            case CharacterLowerState.ATTACK:
                _lowerBody.NewAnimation(_characterLowerAttack, false);
                _legs.NewAnimation(_legsAttack, false);
                break;
        }
    }

    private void NorthAnimations()
    {
        _characterUpperIdle = character?.NorthUpperIdle;
        _characterUpperMove = character?.NorthUpperMove;
        _characterUpperDrink = character?.NorthUpperDrink;
        _characterUpperDodge = character?.NorthUpperDodge;
        _characterUpperAttack = character?.NorthUpperAttack;

        _characterLowerIdle = character?.NorthLowerIdle;
        _characterLowerMove = character?.NorthLowerMove;
        _characterLowerDrink = character?.NorthLowerDrink;
        _characterLowerDodge = character?.NorthLowerDodge;
        _characterLowerAttack = character?.NorthLowerAttack;

        _helmetIdle = _helmetItem?.NorthIdle;
        _helmetMove = _helmetItem?.NorthMove;
        _helmetDrink = _helmetItem?.NorthDrink;
        _helmetAttack = _helmetItem?.NorthAttack;
        _helmetDodge = _helmetItem?.NorthDodge;

        _chestIdle = _chestItem?.NorthIdle;
        _chestMove = _chestItem?.NorthMove;
        _chestDrink = _chestItem?.NorthDrink;
        _chestAttack = _chestItem?.NorthAttack;
        _chestDodge = _chestItem?.NorthDodge;

        _legsIdle = _legItem?.NorthIdle;
        _legsMove = _legItem?.NorthMove;
        _legsDrink = _legItem?.NorthDrink;
        _legsAttack = _legItem?.NorthAttack;
        _legsDodge = _legItem?.NorthDodge;

        _lwIdle = _lightWeaponItem?.NorthIdle;
        _lwMove = _lightWeaponItem?.NorthMove;
        _lwDrink = _lightWeaponItem?.NorthDrink;
        _lwAttack = _lightWeaponItem?.NorthAttack;
        _lwDodge = _lightWeaponItem?.NorthDodge;

        //_hwIdle = _heavyWeaponItem?.NorthIdle;
        //_hwMove = _heavyWeaponItem?.NorthMove;
        //_hwDrink = _heavyWeaponItem?.NorthDrink;
        //_hwAttack = _heavyWeaponItem?.NorthAttack;
        //_hwDodge = _heavyWeaponItem?.NorthDodge;
    }
    private void EastAnimations()
    {
        _characterUpperIdle = character?.EastUpperIdle;
        _characterUpperMove = character?.EastUpperMove;
        _characterUpperDrink = character?.EastUpperDrink;
        _characterUpperDodge = character?.EastUpperDodge;
        _characterUpperAttack = character?.EastUpperAttack;

        _characterLowerIdle = character?.EastLowerIdle;
        _characterLowerMove = character?.EastLowerMove;
        _characterLowerDrink = character?.EastLowerDrink;
        _characterLowerDodge = character?.EastLowerDodge;
        _characterLowerAttack = character?.EastLowerAttack;

        _helmetIdle = _helmetItem?.EastIdle;
        _helmetMove = _helmetItem?.EastMove;
        _helmetDrink = _helmetItem?.EastDrink;
        _helmetAttack = _helmetItem?.EastAttack;
        _helmetDodge = _helmetItem?.EastDodge;

        _chestIdle = _chestItem?.EastIdle;
        _chestMove = _chestItem?.EastMove;
        _chestDrink = _chestItem?.EastDrink;
        _chestAttack = _chestItem?.EastAttack;
        _chestDodge = _chestItem?.EastDodge;

        _legsIdle = _legItem?.EastIdle;
        _legsMove = _legItem?.EastMove;
        _legsDrink = _legItem?.EastDrink;
        _legsAttack = _legItem?.EastAttack;
        _legsDodge = _legItem?.EastDodge;

        _lwIdle = _lightWeaponItem?.EastIdle;
        _lwMove = _lightWeaponItem?.EastMove;
        _lwDrink = _lightWeaponItem?.EastDrink;
        _lwAttack = _lightWeaponItem?.EastAttack;
        _lwDodge = _lightWeaponItem?.EastDodge;

        //_hwIdle = _heavyWeaponItem?.EastIdle;
        //_hwMove = _heavyWeaponItem?.EastMove;
        //_hwDrink = _heavyWeaponItem?.EastDrink;
        //_hwAttack = _heavyWeaponItem?.EastAttack;
        //_hwDodge = _heavyWeaponItem?.EastDodge;
    }
    private void SouthAnimations()
    {
        _characterUpperIdle = character?.SouthUpperIdle;
        _characterUpperMove = character?.SouthUpperMove;
        _characterUpperDrink = character?.SouthUpperDrink;
        _characterUpperDodge = character?.SouthUpperDodge;
        _characterUpperAttack = character?.SouthUpperAttack;

        _characterLowerIdle = character?.SouthLowerIdle;
        _characterLowerMove = character?.SouthLowerMove;
        _characterLowerDrink = character?.SouthLowerDrink;
        _characterLowerDodge = character?.SouthLowerDodge;
        _characterLowerAttack = character?.SouthLowerAttack;

        _helmetIdle = _helmetItem?.SouthIdle;
        _helmetMove = _helmetItem?.SouthMove;
        _helmetDrink = _helmetItem?.SouthDrink;
        _helmetAttack = _helmetItem?.SouthAttack;
        _helmetDodge = _helmetItem?.SouthDodge;

        _chestIdle = _chestItem?.SouthIdle;
        _chestMove = _chestItem?.SouthMove;
        _chestDrink = _chestItem?.SouthDrink;
        _chestAttack = _chestItem?.SouthAttack;
        _chestDodge = _chestItem?.SouthDodge;

        _legsIdle = _legItem?.SouthIdle;
        _legsMove = _legItem?.SouthMove;
        _legsDrink = _legItem?.SouthDrink;
        _legsAttack = _legItem?.SouthAttack;
        _legsDodge = _legItem?.SouthDodge;

        _lwIdle = _lightWeaponItem?.SouthIdle;
        _lwMove = _lightWeaponItem?.SouthMove;
        _lwDrink = _lightWeaponItem?.SouthDrink;
        _lwAttack = _lightWeaponItem?.SouthAttack;
        _lwDodge = _lightWeaponItem?.SouthDodge;

        //_hwIdle = _heavyWeaponItem?.SouthIdle;
        //_hwMove = _heavyWeaponItem?.SouthMove;
        //_hwDrink = _heavyWeaponItem?.SouthDrink;
        //_hwAttack = _heavyWeaponItem?.SouthAttack;
        //_hwDodge = _heavyWeaponItem?.SouthDodge;
    }
    private void WestAnimations()
    {
        _characterUpperIdle = character?.WestUpperIdle;
        _characterUpperMove = character?.WestUpperMove;
        _characterUpperDrink = character?.WestUpperDrink;
        _characterUpperDodge = character?.WestUpperDodge;
        _characterUpperAttack = character?.WestUpperAttack;

        _characterLowerIdle = character?.WestLowerIdle;
        _characterLowerMove = character?.WestLowerMove;
        _characterLowerDrink = character?.WestLowerDrink;
        _characterLowerDodge = character?.WestLowerDodge;
        _characterLowerAttack = character?.WestLowerAttack;

        _helmetIdle = _helmetItem?.WestIdle;
        _helmetMove = _helmetItem?.WestMove;
        _helmetDrink = _helmetItem?.WestDrink;
        _helmetAttack = _helmetItem?.WestAttack;
        _helmetDodge = _helmetItem?.WestDodge;

        _chestIdle = _chestItem?.WestIdle;
        _chestMove = _chestItem?.WestMove;
        _chestDrink = _chestItem?.WestDrink;
        _chestAttack = _chestItem?.WestAttack;
        _chestDodge = _chestItem?.WestDodge;

        _legsIdle = _legItem?.WestIdle;
        _legsMove = _legItem?.WestMove;
        _legsDrink = _legItem?.WestDrink;
        _legsAttack = _legItem?.WestAttack;
        _legsDodge = _legItem?.WestDodge;

        _lwIdle = _lightWeaponItem?.WestIdle;
        _lwMove = _lightWeaponItem?.WestMove;
        _lwDrink = _lightWeaponItem?.WestDrink;
        _lwAttack = _lightWeaponItem?.WestAttack;
        _lwDodge = _lightWeaponItem?.WestDodge;

        //_hwIdle = _heavyWeaponItem?.WestIdle;
        //_hwMove = _heavyWeaponItem?.WestMove;
        //_hwDrink = _heavyWeaponItem?.WestDrink;
        //_hwAttack = _heavyWeaponItem?.WestAttack;
        //_hwDodge = _heavyWeaponItem?.WestDodge;
    }


    private void UpperAnimationStateChnge()
    {
        switch (_upperState)
        {
            case CharacterUpperState.IDLE:
                _upperBody.NewAnimation(_characterUpperIdle, true);
                _chest.NewAnimation(_chestIdle, true);
                _helmet.NewAnimation(_helmetIdle, true);
                _lightWeapon.NewAnimation(_lwIdle, true);
                break;
            case CharacterUpperState.RUN:
                _upperBody.NewAnimation(_characterUpperMove, true);
                _chest.NewAnimation(_chestMove, true);
                _helmet.NewAnimation(_helmetMove, true);
                _lightWeapon.NewAnimation(_lwMove, true);
                break;
            case CharacterUpperState.DODGE:
                _upperBody.NewAnimation(_characterUpperDodge, true);
                _chest.NewAnimation(_chestDodge, true);
                _helmet.NewAnimation(_helmetDodge, true);
                _lightWeapon.NewAnimation(_lwDodge, true);
                break;
            case CharacterUpperState.DRINK:
                _upperBody.NewAnimation(_characterUpperDrink, true);
                _chest.NewAnimation(_chestDrink, true);
                _helmet.NewAnimation(_helmetDrink, true);
                _lightWeapon.NewAnimation(_lwDrink, true);
                break;
            case CharacterUpperState.ATTACK:
                _upperBody.NewAnimation(_characterUpperAttack, true);
                _chest.NewAnimation(_characterUpperAttack, true);
                _helmet.NewAnimation(_characterUpperAttack, true);
                _lightWeapon.NewAnimation(_characterUpperAttack, true);
                break;
        }
    }

    private void LowerAnimationStateChnge()
    {
        
        switch (_lowerState)
        {
            case CharacterLowerState.IDLE:
                _lowerBody.NewAnimation(_characterLowerIdle, true);
                _legs.NewAnimation(_legsIdle, true);
                break;
            case CharacterLowerState.RUN:
                _lowerBody.NewAnimation(_characterLowerMove, true);
                _legs.NewAnimation(_legsMove, true);
                break;
            case CharacterLowerState.DODGE:
                _lowerBody.NewAnimation(_characterLowerDodge, true);
                _legs.NewAnimation(_legsDodge, true);
                break;
            case CharacterLowerState.ATTACK:
                _lowerBody.NewAnimation(_characterLowerAttack, true);
                _legs.NewAnimation(_legsAttack, true);
                break;
        }
    }
    private void OnApplicationQuit()
    {
        AsyncAnimationHandler();
    }

    private async void AsyncAnimationHandler()
    {
        if (cts == null)
        {
            cts = new CancellationTokenSource();
            try
            {
                await PlayAnimation(cts.Token);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                cts = null;
            }
        }
        else
        {
            cts.Cancel();
            cts = null;
        }
    }

    async Task PlayAnimation(CancellationToken token)
    {
        while (Application.isPlaying)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(100);

            _upperBody.NextFrame();
            _lowerBody.NextFrame();
            _helmet.NextFrame();
            _chest.NextFrame();
            _legs.NextFrame();
            _lightWeapon.NextFrame();
        }
    }

    /*
    
    public void NewGear(SHelmetItem helmet, SChestItem chest, SLegItem legs, SLightWeaponItem lightWeapon, SHeavyWeaponItem heavyWeapon)
    {
        _helmetItem = helmet;
        _chestItem = chest;
        _legItem = legs;
        _lightWeaponItem = lightWeapon;
        //_heavyWeaponItem = heavyWeapon;
        UpdateAllBody();
    }

    public void IsMoving(bool isMoving)
    {
        bool newValue = _moving != isMoving;

        _moving = isMoving;

        if (newValue)
        {
            //Debug.Log("New Value for move: " + isMoving);
            UpdateAllBody();
        }
    }

    private void UpdateAllBody()
    {
        if (_dodging)
        {
            
            _upperBody.NewAnimation(_characterUpperDodge);
            _lowerBody.NewAnimation(_characterLowerDodge);
            _chest.NewAnimation(_chestDodge);
            _helmet.NewAnimation(_helmetDodge);
            _legs.NewAnimation(_legsDodge);
            _lightWeapon.NewAnimation(_lwDodge);
            //_heavyWeapon.NewAnimation(_hwDodge);
            return;
        }

        if (_lightAttacking)
        {
            _upperBody.NewAnimation(_characterUpperAttack);
            _chest.NewAnimation(_chestAttack);
            _helmet.NewAnimation(_helmetAttack);
            _lightWeapon.NewAnimation(_lwAttack);
            //_heavyWeapon.NewAnimation(_hwAttack);
            UpdateLowerBody();
            return;
        }

        if (_drinking)
        {
            _upperBody.NewAnimation(_characterUpperDrink);
            _chest.NewAnimation(_chestDrink);
            _helmet.NewAnimation(_helmetDrink);
            _lightWeapon.NewAnimation(_lwDrink);
            //_heavyWeapon.NewAnimation(_hwDrink);
            UpdateLowerBody();
            return;
        }

        UpdateLowerBody();
        UpdateUpperBody();
    }

    private void UpdateLowerBody()
    {
        if (_moving)
        {
            _lowerBody.NewAnimation(_characterLowerMove);
            _legs.NewAnimation(_legsMove);
            return;
        }
        _lowerBody.NewAnimation(_characterLowerIdle);
        _legs.NewAnimation(_legsIdle);
    }

    private void UpdateUpperBody()
    {
        if (_moving)
        {
            _upperBody.NewAnimation(_characterUpperMove);
            _chest.NewAnimation(_chestMove);
            _helmet.NewAnimation(_helmetMove);
            _lightWeapon.NewAnimation(_lwMove);
            //_heavyWeapon.NewAnimation(_hwMove);
            return;
        }
        _upperBody.NewAnimation(_characterUpperIdle);
        _chest.NewAnimation(_chestIdle);
        _helmet.NewAnimation(_helmetIdle);
        _lightWeapon.NewAnimation(_lwIdle);
        //_heavyWeapon.NewAnimation(_hwIdle);
    }

    public void IsHeavyAttack(bool isAttacking)
    {
        bool newValue = _lightAttacking != isAttacking;

        _lightAttacking = isAttacking;

        if (newValue)
        {
            UpdateLowerBody();
        }
    }

    public void LightAttack()
    {
        bool newValue = _lightAttacking != true;

        _lightAttacking = true;

        if (newValue)
        {
            UpdateLowerBody();
        }
    }

    public void Dodge()
    {
        _dodging = true;
        UpdateAllBody();
    }

    

    //private List<Sprite> _characterUpperIdle, _characterUpperMove, _characterUpperDrink, _characterUpperAttack, _characterUpperDodge;
    //private List<Sprite> _characterLowerIdle, _characterLowerMove, _characterLowerDrink, _characterLowerAttack, _characterLowerDodge;
    //private List<Sprite> _helmetIdle, _helmetMove, _helmetDrink, _helmetAttack, _helmetDodge;
    //private List<Sprite> _chestIdle, _chestMove, _chestDrink, _chestAttack, _chestDodge;
    //private List<Sprite> _legsIdle, _legsMove, _legsDrink, _legsAttack, _legsDodge;
    //private List<Sprite> _lwIdle, _lwMove, _lwDrink, _lwAttack, _lwDodge;

    private void NewDirection(Vector2Int newDirection)
    {
        if (newDirection == Vector2Int.zero)
        {
            return;
        }

        //Debug.Log("New Drection: " + newDirection);

        if (newDirection == Vector2.up)
        {
            _characterUpperIdle = character?.NorthUpperIdle;
            _characterUpperMove = character?.NorthUpperMove;
            _characterUpperDrink = character?.NorthUpperDrink;
            _characterUpperDodge = character?.NorthUpperDodge;
            _characterUpperAttack = character?.NorthUpperAttack;

            _characterLowerIdle = character?.NorthLowerIdle;
            _characterLowerMove = character?.NorthLowerMove;
            _characterLowerDrink = character?.NorthLowerDrink;
            _characterLowerDodge = character?.NorthLowerDodge;
            _characterLowerAttack = character?.NorthLowerAttack;

            _helmetIdle = _helmetItem?.NorthIdle;
            _helmetMove = _helmetItem?.NorthMove;
            _helmetDrink = _helmetItem?.NorthDrink;
            _helmetAttack = _helmetItem?.NorthAttack;
            _helmetDodge = _helmetItem?.NorthDodge;

            _chestIdle = _chestItem?.NorthIdle;
            _chestMove = _chestItem?.NorthMove;
            _chestDrink = _chestItem?.NorthDrink;
            _chestAttack = _chestItem?.NorthAttack;
            _chestDodge = _chestItem?.NorthDodge;

            _legsIdle = _legItem?.NorthIdle;
            _legsMove = _legItem?.NorthMove;
            _legsDrink = _legItem?.NorthDrink;
            _legsAttack = _legItem?.NorthAttack;
            _legsDodge = _legItem?.NorthDodge;

            _lwIdle = _lightWeaponItem?.NorthIdle;
            _lwMove = _lightWeaponItem?.NorthMove;
            _lwDrink = _lightWeaponItem?.NorthDrink;
            _lwAttack = _lightWeaponItem?.NorthAttack;
            _lwDodge = _lightWeaponItem?.NorthDodge;

            //_hwIdle = _heavyWeaponItem?.NorthIdle;
            //_hwMove = _heavyWeaponItem?.NorthMove;
            //_hwDrink = _heavyWeaponItem?.NorthDrink;
            //_hwAttack = _heavyWeaponItem?.NorthAttack;
            //_hwDodge = _heavyWeaponItem?.NorthDodge;
        }

        else if (newDirection == Vector2.down)
        {
            _characterUpperIdle = character?.SouthUpperIdle;
            _characterUpperMove = character?.SouthUpperMove;
            _characterUpperDrink = character?.SouthUpperDrink;
            _characterUpperDodge = character?.SouthUpperDodge;
            _characterUpperAttack = character?.SouthUpperAttack;

            _characterLowerIdle = character?.SouthLowerIdle;
            _characterLowerMove = character?.SouthLowerMove;
            _characterLowerDrink = character?.SouthLowerDrink;
            _characterLowerDodge = character?.SouthLowerDodge;
            _characterLowerAttack = character?.SouthLowerAttack;

            _helmetIdle = _helmetItem?.SouthIdle;
            _helmetMove = _helmetItem?.SouthMove;
            _helmetDrink = _helmetItem?.SouthDrink;
            _helmetAttack = _helmetItem?.SouthAttack;
            _helmetDodge = _helmetItem?.SouthDodge;

            _chestIdle = _chestItem?.SouthIdle;
            _chestMove = _chestItem?.SouthMove;
            _chestDrink = _chestItem?.SouthDrink;
            _chestAttack = _chestItem?.SouthAttack;
            _chestDodge = _chestItem?.SouthDodge;

            _legsIdle = _legItem?.SouthIdle;
            _legsMove = _legItem?.SouthMove;
            _legsDrink = _legItem?.SouthDrink;
            _legsAttack = _legItem?.SouthAttack;
            _legsDodge = _legItem?.SouthDodge;

            _lwIdle = _lightWeaponItem?.SouthIdle;
            _lwMove = _lightWeaponItem?.SouthMove;
            _lwDrink = _lightWeaponItem?.SouthDrink;
            _lwAttack = _lightWeaponItem?.SouthAttack;
            _lwDodge = _lightWeaponItem?.SouthDodge;

            //_hwIdle = _heavyWeaponItem?.SouthIdle;
            //_hwMove = _heavyWeaponItem?.SouthMove;
            //_hwDrink = _heavyWeaponItem?.SouthDrink;
            //_hwAttack = _heavyWeaponItem?.SouthAttack;
            //_hwDodge = _heavyWeaponItem?.SouthDodge;
        }

        else if (newDirection == Vector2.right)
        {
            _characterUpperIdle = character?.EastUpperIdle;
            _characterUpperMove = character?.EastUpperMove;
            _characterUpperDrink = character?.EastUpperDrink;
            _characterUpperDodge = character?.EastUpperDodge;
            _characterUpperAttack = character?.EastUpperAttack;

            _characterLowerIdle = character?.EastLowerIdle;
            _characterLowerMove = character?.EastLowerMove;
            _characterLowerDrink = character?.EastLowerDrink;
            _characterLowerDodge = character?.EastLowerDodge;
            _characterLowerAttack = character?.EastLowerAttack;

            _helmetIdle = _helmetItem?.EastIdle;
            _helmetMove = _helmetItem?.EastMove;
            _helmetDrink = _helmetItem?.EastDrink;
            _helmetAttack = _helmetItem?.EastAttack;
            _helmetDodge = _helmetItem?.EastDodge;

            _chestIdle = _chestItem?.EastIdle;
            _chestMove = _chestItem?.EastMove;
            _chestDrink = _chestItem?.EastDrink;
            _chestAttack = _chestItem?.EastAttack;
            _chestDodge = _chestItem?.EastDodge;

            _legsIdle = _legItem?.EastIdle;
            _legsMove = _legItem?.EastMove;
            _legsDrink = _legItem?.EastDrink;
            _legsAttack = _legItem?.EastAttack;
            _legsDodge = _legItem?.EastDodge;

            _lwIdle = _lightWeaponItem?.EastIdle;
            _lwMove = _lightWeaponItem?.EastMove;
            _lwDrink = _lightWeaponItem?.EastDrink;
            _lwAttack = _lightWeaponItem?.EastAttack;
            _lwDodge = _lightWeaponItem?.EastDodge;

            //_hwIdle = _heavyWeaponItem?.EastIdle;
            //_hwMove = _heavyWeaponItem?.EastMove;
            //_hwDrink = _heavyWeaponItem?.EastDrink;
            //_hwAttack = _heavyWeaponItem?.EastAttack;
            //_hwDodge = _heavyWeaponItem?.EastDodge;
        }

        else if (newDirection == Vector2.left)
        {
            _characterUpperIdle = character?.WestUpperIdle;
            _characterUpperMove = character?.WestUpperMove;
            _characterUpperDrink = character?.WestUpperDrink;
            _characterUpperDodge = character?.WestUpperDodge;
            _characterUpperAttack = character?.WestUpperAttack;

            _characterLowerIdle = character?.WestLowerIdle;
            _characterLowerMove = character?.WestLowerMove;
            _characterLowerDrink = character?.WestLowerDrink;
            _characterLowerDodge = character?.WestLowerDodge;
            _characterLowerAttack = character?.WestLowerAttack;

            _helmetIdle = _helmetItem?.WestIdle;
            _helmetMove = _helmetItem?.WestMove;
            _helmetDrink = _helmetItem?.WestDrink;
            _helmetAttack = _helmetItem?.WestAttack;
            _helmetDodge = _helmetItem?.WestDodge;

            _chestIdle = _chestItem?.WestIdle;
            _chestMove = _chestItem?.WestMove;
            _chestDrink = _chestItem?.WestDrink;
            _chestAttack = _chestItem?.WestAttack;
            _chestDodge = _chestItem?.WestDodge;

            _legsIdle = _legItem?.WestIdle;
            _legsMove = _legItem?.WestMove;
            _legsDrink = _legItem?.WestDrink;
            _legsAttack = _legItem?.WestAttack;
            _legsDodge = _legItem?.WestDodge;

            _lwIdle = _lightWeaponItem?.WestIdle;
            _lwMove = _lightWeaponItem?.WestMove;
            _lwDrink = _lightWeaponItem?.WestDrink;
            _lwAttack = _lightWeaponItem?.WestAttack;
            _lwDodge = _lightWeaponItem?.WestDodge;

            //_hwIdle = _heavyWeaponItem?.WestIdle;
            //_hwMove = _heavyWeaponItem?.WestMove;
            //_hwDrink = _heavyWeaponItem?.WestDrink;
            //_hwAttack = _heavyWeaponItem?.WestAttack;
            //_hwDodge = _heavyWeaponItem?.WestDodge;
        }
        UpdateAllBody();
    }

    private void UpdateSprites()
    {

    }

    
    */
}
