using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SGearItem : SItem
{
    [SerializeField]
    protected int health = 0;

    [SerializeField]
    protected int armor = 0;

    [SerializeField]
    protected int dex = 0;

    [SerializeField]
    protected int magic = 0;

    [SerializeField]
    protected int knowledge = 0;

    public SGearItem()
    {
        _stackCap = 1;
    }
}
