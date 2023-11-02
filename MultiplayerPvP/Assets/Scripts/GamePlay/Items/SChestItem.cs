using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Chest Item", order = 3)]
public class SChestItem : SArmorItem
{
    public override string GetItemTypeName()
    {
        return "Chest Armor";
    }
}
