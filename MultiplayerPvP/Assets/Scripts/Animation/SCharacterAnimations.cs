using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSprites", menuName = "Characters/Basic", order = 1)]
public class SCharacterAnimations : ScriptableObject
{
    #region NORTH
    [Header("Upper Body")]
    [SerializeField]
    private List<Sprite> _northUpperIdle;
    public List<Sprite> NorthUpperIdle
    {
        get
        {
            return GenerateNewList(_northUpperIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _northUpperMove;

    public List<Sprite> NorthUpperMove
    {
        get
        {
            return GenerateNewList(_northUpperMove);
        }
    }

    [SerializeField]
    private List<Sprite> _northUpperAttack;

    public List<Sprite> NorthUpperAttack
    {
        get
        {
            return GenerateNewList(_northUpperAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _northUpperDrink;

    public List<Sprite> NorthUpperDrink
    {
        get
        {
            return GenerateNewList(_northUpperDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _northUpperDodge;

    public List<Sprite> NorthUpperDodge
    {
        get
        {
            return GenerateNewList(_northUpperDodge);
        }
    }

    [Header("Lower Body")]

    [SerializeField]
    private List<Sprite> _northLowerIdle;
    public List<Sprite> NorthLowerIdle
    {
        get
        {
            return GenerateNewList(_northLowerIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _northLowerMove;

    public List<Sprite> NorthLowerMove
    {
        get
        {
            return GenerateNewList(_northLowerMove);
        }
    }

    [SerializeField]
    private List<Sprite> _northLowerAttack;

    public List<Sprite> NorthLowerAttack
    {
        get
        {
            return GenerateNewList(_northLowerAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _northLowerDrink;

    public List<Sprite> NorthLowerDrink
    {
        get
        {
            return GenerateNewList(_northLowerDrink);
        }
    }

    

    [SerializeField]
    private List<Sprite> _northLowerDodge;

    public List<Sprite> NorthLowerDodge
    {
        get
        {
            return GenerateNewList(_northLowerDodge);
        }
    }
    #endregion

    #region EAST
    [Header("Upper Body")]
    [SerializeField]
    private List<Sprite> _eastUpperIdle;
    public List<Sprite> EastUpperIdle
    {
        get
        {
            return GenerateNewList(_eastUpperIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _eastUpperMove;

    public List<Sprite> EastUpperMove
    {
        get
        {
            return GenerateNewList(_eastUpperMove);
        }
    }

    [SerializeField]
    private List<Sprite> _eastUpperAttack;

    public List<Sprite> EastUpperAttack
    {
        get
        {
            return GenerateNewList(_eastUpperAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _eastUpperDrink;

    public List<Sprite> EastUpperDrink
    {
        get
        {
            return GenerateNewList(_eastUpperDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _eastUpperDodge;

    public List<Sprite> EastUpperDodge
    {
        get
        {
            return GenerateNewList(_eastUpperDodge);
        }
    }


    [Header("Lower Body")]

    [SerializeField]
    private List<Sprite> _eastLowerIdle;
    public List<Sprite> EastLowerIdle
    {
        get
        {
            return GenerateNewList(_eastLowerIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _eastLowerMove;

    public List<Sprite> EastLowerMove
    {
        get
        {
            return GenerateNewList(_eastLowerMove);
        }
    }

    [SerializeField]
    private List<Sprite> _eastLowerAttack;

    public List<Sprite> EastLowerAttack
    {
        get
        {
            return GenerateNewList(_eastLowerAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _eastLowerDrink;

    public List<Sprite> EastLowerDrink
    {
        get
        {
            return GenerateNewList(_eastLowerDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _eastLowerDodge;

    public List<Sprite> EastLowerDodge
    {
        get
        {
            return GenerateNewList(_eastLowerDodge);
        }
    }
    #endregion

    #region SOUTH
    [Header("Upper Body")]
    [SerializeField]
    private List<Sprite> _southUpperIdle;
    public List<Sprite> SouthUpperIdle
    {
        get
        {
            return GenerateNewList(_southUpperIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _southUpperMove;

    public List<Sprite> SouthUpperMove
    {
        get
        {
            return GenerateNewList(_southUpperMove);
        }
    }

    [SerializeField]
    private List<Sprite> _southUpperAttack;

    public List<Sprite> SouthUpperAttack
    {
        get
        {
            return GenerateNewList(_southUpperAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _southUpperDrink;

    public List<Sprite> SouthUpperDrink
    {
        get
        {
            return GenerateNewList(_southUpperDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _southUpperDodge;

    public List<Sprite> SouthUpperDodge
    {
        get
        {
            return GenerateNewList(_southUpperDodge);
        }
    }

    [Header("Lower Body")]

    [SerializeField]
    private List<Sprite> _southLowerIdle;
    public List<Sprite> SouthLowerIdle
    {
        get
        {
            return GenerateNewList(_southLowerIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _southLowerMove;

    public List<Sprite> SouthLowerMove
    {
        get
        {
            return GenerateNewList(_southLowerMove);
        }
    }

    [SerializeField]
    private List<Sprite> _southLowerAttack;

    public List<Sprite> SouthLowerAttack
    {
        get
        {
            return GenerateNewList(_southLowerAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _southLowerDrink;

    public List<Sprite> SouthLowerDrink
    {
        get
        {
            return GenerateNewList(_southLowerDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _southLowerDodge;

    public List<Sprite> SouthLowerDodge
    {
        get
        {
            return GenerateNewList(_southLowerDodge);
        }
    }
    #endregion

    #region WEST
    [Header("Upper Body")]
    [SerializeField]
    private List<Sprite> _westUpperIdle;
    public List<Sprite> WestUpperIdle
    {
        get
        {
            return GenerateNewList(_westUpperIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _westUpperMove;

    public List<Sprite> WestUpperMove
    {
        get
        {
            return GenerateNewList(_westUpperMove);
        }
    }

    [SerializeField]
    private List<Sprite> _westUpperAttack;

    public List<Sprite> WestUpperAttack
    {
        get
        {
            return GenerateNewList(_westUpperAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _westUpperDrink;

    public List<Sprite> WestUpperDrink
    {
        get
        {
            return GenerateNewList(_westUpperDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _westUpperDodge;

    public List<Sprite> WestUpperDodge
    {
        get
        {
            return GenerateNewList(_westUpperDodge);
        }
    }

    [Header("Lower Body")]

    [SerializeField]
    private List<Sprite> _westLowerIdle;
    public List<Sprite> WestLowerIdle
    {
        get
        {
            return GenerateNewList(_westLowerIdle);
        }
    }

    [SerializeField]
    private List<Sprite> _westLowerMove;

    public List<Sprite> WestLowerMove
    {
        get
        {
            return GenerateNewList(_westLowerMove);
        }
    }

    [SerializeField]
    private List<Sprite> _westLowerAttack;

    public List<Sprite> WestLowerAttack
    {
        get
        {
            return GenerateNewList(_westLowerAttack);
        }
    }

    [SerializeField]
    private List<Sprite> _westLowerDrink;

    public List<Sprite> WestLowerDrink
    {
        get
        {
            return GenerateNewList(_westLowerDrink);
        }
    }

    [SerializeField]
    private List<Sprite> _westLowerDodge;

    public List<Sprite> WestLowerDodge
    {
        get
        {
            return GenerateNewList(_westLowerDodge);
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
