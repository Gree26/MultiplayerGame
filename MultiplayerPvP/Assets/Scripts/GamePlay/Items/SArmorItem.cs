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
    private List<Sprite> _northDrink;

    public List<Sprite> NorthDrink
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northDrink);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _northDodge;

    public List<Sprite> NorthDodge
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_northDodge);

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
    private List<Sprite> _eastDrink;

    public List<Sprite> EastDrink
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastDrink);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _eastDodge;

    public List<Sprite> EastDodge
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_eastDodge);

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
    private List<Sprite> _southDrink;
    public List<Sprite> SouthDrink
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southDrink);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _southDodge;
    public List<Sprite> SouthDodge
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_southDodge);

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
    private List<Sprite> _westDrink;
    public List<Sprite> WestDrink
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westDrink);

            return newList;
        }
    }

    [SerializeField]
    private List<Sprite> _westDodge;
    public List<Sprite> WestDodge
    {
        get
        {
            List<Sprite> newList = GenerateNewList(_westDodge);

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