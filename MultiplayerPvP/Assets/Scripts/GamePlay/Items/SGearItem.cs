using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SGearItem : SItem
{
    [SerializeField]
    public int health { get; private set; } = 0;

    [SerializeField]
    public int armor { get; private set; } = 0;

    [SerializeField]
    public int chaos { get; private set; } = 0;

    [SerializeField]
    public int order { get; private set; } = 0;

    [SerializeField]
    public int creation { get; private set; } = 0;

    [SerializeField]
    public int destruction { get; private set; } = 0;

    public override int GetStackCap()
    {
        return 1;
    }
}
