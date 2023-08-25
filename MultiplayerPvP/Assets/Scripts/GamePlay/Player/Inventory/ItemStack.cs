using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stores stack info for inventory slots
/// </summary>
internal struct ItemStack
{
    private int _total;
    private int _maxStack;
    private SItem _item;

    public ItemStack(SItem item)
    {
        _item = item;
        _maxStack = item.GetStackCap();
        _total = 1;
    }

    public ItemStack(SItem item, int stackCount)
    {
        _item = item;
        _maxStack = item.GetStackCap();
        if (stackCount <= _maxStack)
            _total = stackCount;
        else if (stackCount <= 0)
            _total = 1;
        else
            _total = _maxStack;
    }

    /// <summary>
    /// Get the total items in this stack.
    /// </summary>
    /// <returns></returns>
    public int GetTotal()
    {
        return _total;
    }

    /// <summary>
    /// Get the max stack size.
    /// </summary>
    /// <returns></returns>
    public int GetMax()
    {
        return _maxStack;
    }

    /// <summary>
    /// The Item that this is a stack of. 
    /// </summary>
    /// <returns></returns>
    public SItem GetItem()
    {
        return _item;
    }

    public bool IsFull()
    {
        return _total >= _maxStack;
    }
}
