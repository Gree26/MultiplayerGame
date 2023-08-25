using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SArmorItem : SGearItem
{
    #region NORTH
    [SerializeField]
    private List<Sprite> _northIdle;
    public List<Sprite> NorthIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _northMove;

    public List<Sprite> NorthMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northMove);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _northAttack;

    public List<Sprite> NorthAttack
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northAttack);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _northChargeIdle;

    public List<Sprite> NorthChargeIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northChargeIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _northChargeMove;

    public List<Sprite> NorthChargeMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northChargeMove);

            return newList;
        }
    }
    #endregion

    #region EAST
    [SerializeField]
    private List<Sprite> _eastIdle;
    public List<Sprite> EastIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _eastMove;

    public List<Sprite> EastMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastMove);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _eastAttack;

    public List<Sprite> EastAttack
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastAttack);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _eastChargeIdle;

    public List<Sprite> EastChargeIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastChargeIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _eastChargeMove;

    public List<Sprite> EastChargeMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastChargeMove);

            return newList;
        }
    }
    #endregion

    #region SOUTH
    [SerializeField]
    private List<Sprite> _southIdle;
    public List<Sprite> SouthIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _southMove;
    public List<Sprite> SouthMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southMove);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _southAttack;
    public List<Sprite> SouthAttack
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southAttack);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _southChargeIdle;
    public List<Sprite> SouthChargeIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southChargeIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _southChargeMove;
    public List<Sprite> SouthChargeMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southChargeMove);

            return newList;
        }
    }
    #endregion

    #region WEST
    [SerializeField]
    private List<Sprite> _westIdle;
    public List<Sprite> WestIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _westMove;
    public List<Sprite> WestMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westMove);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _westAttack;
    public List<Sprite> WestAttack
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westAttack);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _westChargeIdle;
    public List<Sprite> WestChargeIdle
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westChargeIdle);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _westChargeMove;
    public List<Sprite> WestChargeMove
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westChargeMove);

            return newList;
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