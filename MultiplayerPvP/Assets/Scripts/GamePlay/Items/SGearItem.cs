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
    protected int chaos = 0;

    [SerializeField]
    protected int order = 0;

    [SerializeField]
    protected int creation = 0;

    [SerializeField]
    protected int destruction = 0;

    public override int GetStackCap()
    {
        return 1;
    }
}
