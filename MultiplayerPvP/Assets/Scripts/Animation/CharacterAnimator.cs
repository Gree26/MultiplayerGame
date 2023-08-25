using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    public enum CharacterState
    {
        IDLE,
        RUN,
        ATTACK,
        CHARGEIDLE,
        CHARGEMOVE
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
            //Debug.Log("Updating direction");
            var newDierction = _currentDirection != value;
            var previousDirection = _currentDirection;
            _currentDirection = value;
            // Is the value given a new value? 
            if (newDierction)
                NewDirection(previousDirection);
        }
    }

    private CharacterState _state = CharacterState.IDLE;

    public CharacterState State
    {
        set
        {
            var newValue = _state != value;
            _state = value;
            if (newValue)
                AnimationStateChnge();
        }
    }

    [SerializeField]
    private MonoAnimationor _body;

    [SerializeField]
    private MonoAnimationor _helmet;

    [SerializeField]
    private MonoAnimationor _chest;

    [SerializeField]
    private MonoAnimationor _legs;

    [SerializeField]
    private MonoAnimationor _weapon;

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
    private SLightWeaponItem _weaponItem;

    private Vector2Int _direction = Vector2Int.right;

    private List<Sprite> _characterIdle, _characterMove, _characterAttack, _characterChargeIdle, _characterChargeMove;
    private List<Sprite> _helmetIdle, _helmetMove, _helmetAttack, _helmetChargeIdle, _helmetChargeMove;
    private List<Sprite> _chestIdle, _chestMove, _chestAttack, _chestChargeIdle, _chestChargeMove;
    private List<Sprite> _legsIdle, _legsMove, _legsAttack, _legsChargeIdle, _legsChargeMove;
    private List<Sprite> _weaponIdle, _weaponMove, _weaponAttack, _weaponChargeIdle, _weaponChargeMove;

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
                State = CharacterState.IDLE;
                break;
        }
        UpdateAnimation(false);
    }

    private void UpdateAnimation(bool reset)
    {
        switch (_state)
        {
            case CharacterState.IDLE:
                _body.NewAnimation(_characterIdle, false);
                _chest.NewAnimation(_chestIdle, false);
                _helmet.NewAnimation(_helmetIdle, false);
                _legs.NewAnimation(_legsIdle, false);
                _weapon.NewAnimation(_weaponIdle, false);
                break;
            case CharacterState.RUN:
                _body.NewAnimation(_characterMove, false);
                _chest.NewAnimation(_chestMove, false);
                _helmet.NewAnimation(_helmetMove, false);
                _legs.NewAnimation(_legsMove, false);
                _weapon.NewAnimation(_weaponMove, false);
                break;
            case CharacterState.ATTACK:
                _body.NewAnimation(_characterAttack, false);
                _chest.NewAnimation(_chestAttack, false);
                _helmet.NewAnimation(_helmetAttack, false);
                _legs.NewAnimation(_legsAttack, false);
                _weapon.NewAnimation(_weaponAttack, false);
                break;
            case CharacterState.CHARGEIDLE:
                _body.NewAnimation(_characterChargeIdle, false);
                _chest.NewAnimation(_chestChargeIdle, false);
                _helmet.NewAnimation(_helmetChargeIdle, false);
                _legs.NewAnimation(_legsChargeIdle, false);
                _weapon.NewAnimation(_weaponChargeIdle, false);
                break;
            case CharacterState.CHARGEMOVE:
                _body.NewAnimation(_characterChargeMove, false);
                _chest.NewAnimation(_chestChargeMove, false);
                _helmet.NewAnimation(_helmetChargeMove, false);
                _legs.NewAnimation(_legsChargeMove, false);
                _weapon.NewAnimation(_weaponChargeMove, false);
                break;

        }
    }

    private void NorthAnimations()
    {
        _characterIdle = character?.NorthIdle;
        _characterMove = character?.NorthMove;
        _characterAttack = character?.NorthAttack;
        _characterChargeIdle = character?.NorthIdleChargeAttack;
        _characterChargeMove = character?.NorthMoveChargeAttack;

        _helmetIdle = _helmetItem?.NorthIdle;
        _helmetMove = _helmetItem?.NorthMove;
        _helmetAttack = _helmetItem?.NorthAttack;
        _helmetChargeIdle = _helmetItem?.NorthChargeIdle;
        _helmetChargeMove = _helmetItem?.NorthChargeMove;

        _chestIdle = _chestItem?.NorthIdle;
        _chestMove = _chestItem?.NorthMove;
        _chestAttack = _chestItem?.NorthAttack;
        _chestChargeIdle = _chestItem?.NorthChargeIdle;
        _chestChargeMove = _chestItem?.NorthChargeMove;

        _legsIdle = _legItem?.NorthIdle;
        _legsMove = _legItem?.NorthMove;
        _legsAttack = _legItem?.NorthAttack;
        _legsChargeIdle = _legItem?.NorthChargeIdle;
        _legsChargeMove = _legItem?.NorthChargeMove;

        _weaponIdle = _weaponItem?.NorthIdle;
        _weaponMove = _weaponItem?.NorthMove;
        _weaponAttack = _weaponItem?.NorthAttack;
        _weaponChargeIdle = _weaponItem?.NorthChargeIdle;
        _weaponChargeMove = _weaponItem?.NorthChargeMove;
    }
    private void EastAnimations()
    {
        _characterIdle = character?.EastIdle;
        _characterMove = character?.EastMove;
        _characterAttack = character?.EastAttack;
        _characterChargeIdle = character?.EastIdleChargeAttack;
        _characterChargeMove = character?.EastMoveChargeAttack;

        _helmetIdle = _helmetItem?.EastIdle;
        _helmetMove = _helmetItem?.EastMove;
        _helmetAttack = _helmetItem?.EastAttack;
        _helmetChargeIdle = _helmetItem?.EastChargeIdle;
        _helmetChargeMove = _helmetItem?.EastChargeMove;

        _chestIdle = _chestItem?.EastIdle;
        _chestMove = _chestItem?.EastMove;
        _chestAttack = _chestItem?.EastAttack;
        _chestChargeIdle = _chestItem?.EastChargeIdle;
        _chestChargeMove = _chestItem?.EastChargeMove;

        _legsIdle = _legItem?.EastIdle;
        _legsMove = _legItem?.EastMove;
        _legsAttack = _legItem?.EastAttack;
        _legsChargeIdle = _legItem?.EastChargeIdle;
        _legsChargeMove = _legItem?.EastChargeMove;

        _weaponIdle = _weaponItem?.EastIdle;
        _weaponMove = _weaponItem?.EastMove;
        _weaponAttack = _weaponItem?.EastAttack;
        _weaponChargeIdle = _weaponItem?.EastChargeIdle;
        _weaponChargeMove = _weaponItem?.EastChargeMove;
    }
    private void SouthAnimations()
    {
        _characterIdle = character?.SouthIdle;
        _characterMove = character?.SouthMove;
        _characterAttack = character?.SouthAttack;
        _characterChargeIdle = character?.SouthIdleChargeAttack;
        _characterChargeMove = character?.SouthMoveChargeAttack;

        _helmetIdle = _helmetItem?.SouthIdle;
        _helmetMove = _helmetItem?.SouthMove;
        _helmetAttack = _helmetItem?.SouthAttack;
        _helmetChargeIdle = _helmetItem?.SouthChargeIdle;
        _helmetChargeMove = _helmetItem?.SouthChargeMove;

        _chestIdle = _chestItem?.SouthIdle;
        _chestMove = _chestItem?.SouthMove;
        _chestAttack = _chestItem?.SouthAttack;
        _chestChargeIdle = _chestItem?.SouthChargeIdle;
        _chestChargeMove = _chestItem?.SouthChargeMove;

        _legsIdle = _legItem?.SouthIdle;
        _legsMove = _legItem?.SouthMove;
        _legsAttack = _legItem?.SouthAttack;
        _legsChargeIdle = _legItem?.SouthChargeIdle;
        _legsChargeMove = _legItem?.SouthChargeMove;

        _weaponIdle = _weaponItem?.SouthIdle;
        _weaponMove = _weaponItem?.SouthMove;
        _weaponAttack = _weaponItem?.SouthAttack;
        _weaponChargeIdle = _weaponItem?.SouthChargeIdle;
        _weaponChargeMove = _weaponItem?.SouthChargeMove;
    }
    private void WestAnimations()
    {
        _characterIdle = character?.WestIdle;
        _characterMove = character?.WestMove;
        _characterAttack = character?.WestAttack;
        _characterChargeIdle = character?.WestIdleChargeAttack;
        _characterChargeMove = character?.WestMoveChargeAttack;

        _helmetIdle = _helmetItem?.WestIdle;
        _helmetMove = _helmetItem?.WestMove;
        _helmetAttack = _helmetItem?.WestAttack;
        _helmetChargeIdle = _helmetItem?.WestChargeIdle;
        _helmetChargeMove = _helmetItem?.WestChargeMove;

        _chestIdle = _chestItem?.WestIdle;
        _chestMove = _chestItem?.WestMove;
        _chestAttack = _chestItem?.WestAttack;
        _chestChargeIdle = _chestItem?.WestChargeIdle;
        _chestChargeMove = _chestItem?.WestChargeMove;

        _legsIdle = _legItem?.WestIdle;
        _legsMove = _legItem?.WestMove;
        _legsAttack = _legItem?.WestAttack;
        _legsChargeIdle = _legItem?.WestChargeIdle;
        _legsChargeMove = _legItem?.WestChargeMove;

        _weaponIdle = _weaponItem?.WestIdle;
        _weaponMove = _weaponItem?.WestMove;
        _weaponAttack = _weaponItem?.WestAttack;
        _weaponChargeIdle = _weaponItem?.WestChargeIdle;
        _weaponChargeMove = _weaponItem?.WestChargeMove;
    }


    private void AnimationStateChnge()
    {
        switch (_state)
        {
            case CharacterState.IDLE:
                _body.NewAnimation(_characterIdle, true);
                _chest.NewAnimation(_chestIdle, true);
                _helmet.NewAnimation(_helmetIdle, true);
                _legs.NewAnimation(_legsIdle, true);
                _weapon.NewAnimation(_weaponIdle, true);
                break;
            case CharacterState.RUN:
                _body.NewAnimation(_characterMove, true);
                _chest.NewAnimation(_chestMove, true);
                _helmet.NewAnimation(_helmetMove, true);
                _legs.NewAnimation(_legsMove, true);
                _weapon.NewAnimation(_weaponMove, true);
                break;
            case CharacterState.ATTACK:
                _body.NewAnimation(_characterAttack, true);
                _chest.NewAnimation(_chestAttack, true);
                _helmet.NewAnimation(_helmetAttack, true);
                _legs.NewAnimation(_legsAttack, true);
                _weapon.NewAnimation(_weaponAttack, true);
                break;
            case CharacterState.CHARGEIDLE:
                _body.NewAnimation(_characterChargeIdle, true);
                _chest.NewAnimation(_chestChargeIdle, true);
                _helmet.NewAnimation(_helmetChargeIdle, true);
                _legs.NewAnimation(_legsChargeIdle, true);
                _weapon.NewAnimation(_weaponChargeIdle, true);
                break;
            case CharacterState.CHARGEMOVE:
                _body.NewAnimation(_characterChargeMove, true);
                _chest.NewAnimation(_chestChargeMove, true);
                _helmet.NewAnimation(_helmetChargeMove, true);
                _legs.NewAnimation(_legsChargeMove, true);
                _weapon.NewAnimation(_weaponChargeMove, true);
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
            await Task.Delay(150);

            _body?.NextFrame();
            _helmet?.NextFrame();
            _chest?.NextFrame();
            _legs?.NextFrame();
            _weapon?.NextFrame();
        }
    }
}
