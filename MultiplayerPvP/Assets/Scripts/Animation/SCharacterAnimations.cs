using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Characters/Basic", order = 1)]
public class SCharacterAnimations : ScriptableObject
{


    #region NORTH
    [Header("North")]
    [SerializeField]
    private List<Sprite> _northIdle;
    public List<Sprite> NorthIdle
    {
        get
        {
            return GenerateNewList(_northIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _northMove;

    public List<Sprite> NorthMove
    {
        get
        {
            return GenerateNewList(_northMove);
        }
    }

    [SerializeField]
    private List<Sprite> _northAttack;

    public List<Sprite> NorthAttack
    {
        get
        {
            return GenerateNewList(_northAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _northIdleChargeAttack;

    public List<Sprite> NorthIdleChargeAttack
    {
        get
        {
            return GenerateNewList(_northIdleChargeAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _northMoveChargeAttack;

    public List<Sprite> NorthMoveChargeAttack
    {
        get
        {
            return GenerateNewList(_northMoveChargeAttack);
        }
    }
    #endregion

    #region East
    [Header("East")]
    [SerializeField]
    private List<Sprite> _eastIdle;
    public List<Sprite> EastIdle
    {
        get
        {
            return GenerateNewList(_eastIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _eastMove;

    public List<Sprite> EastMove
    {
        get
        {
            return GenerateNewList(_eastMove);
        }
    }

    [SerializeField]
    private List<Sprite> _eastAttack;

    public List<Sprite> EastAttack
    {
        get
        {
            return GenerateNewList(_eastAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _eastIdleChargeAttack;

    public List<Sprite> EastIdleChargeAttack
    {
        get
        {
            return GenerateNewList(_eastIdleChargeAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _eastMoveChargeAttack;

    public List<Sprite> EastMoveChargeAttack
    {
        get
        {
            return GenerateNewList(_eastMoveChargeAttack);
        }
    }
    #endregion

    #region South
    [Header("South")]
    [SerializeField]
    private List<Sprite> _southIdle;
    public List<Sprite> SouthIdle
    {
        get
        {
            return GenerateNewList(_southIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _southMove;

    public List<Sprite> SouthMove
    {
        get
        {
            return GenerateNewList(_southMove);
        }
    }

    [SerializeField]
    private List<Sprite> _southAttack;

    public List<Sprite> SouthAttack
    {
        get
        {
            return GenerateNewList(_southAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _southIdleChargeAttack;

    public List<Sprite> SouthIdleChargeAttack
    {
        get
        {
            return GenerateNewList(_southIdleChargeAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _southMoveChargeAttack;

    public List<Sprite> SouthMoveChargeAttack
    {
        get
        {
            return GenerateNewList(_southMoveChargeAttack);
        }
    }
    #endregion

    #region West
    [Header("West")]
    [SerializeField]
    private List<Sprite> _westIdle;
    public List<Sprite> WestIdle
    {
        get
        {
            return GenerateNewList(_westIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _westMove;

    public List<Sprite> WestMove
    {
        get
        {
            return GenerateNewList(_westMove);
        }
    }

    [SerializeField]
    private List<Sprite> _westAttack;

    public List<Sprite> WestAttack
    {
        get
        {
            return GenerateNewList(_westAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _westIdleChargeAttack;

    public List<Sprite> WestIdleChargeAttack
    {
        get
        {
            return GenerateNewList(_westIdleChargeAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _westMoveChargeAttack;

    public List<Sprite> WestMoveChargeAttack
    {
        get
        {
            return GenerateNewList(_westMoveChargeAttack);
        }
    }
    #endregion

    private List<Sprite> GenerateNewList(List<Sprite> oldList)
    {
        List<Sprite> newList = new List<Sprite>();

        foreach (Sprite spr in oldList)
        {
            newList.Add(spr);
        }

        return newList;
    }
}
