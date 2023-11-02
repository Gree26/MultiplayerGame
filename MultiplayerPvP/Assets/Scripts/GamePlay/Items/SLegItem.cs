using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Leg Item", order = 4)]
public class SLegItem : SArmorItem
{
    public override string GetItemTypeName()
    {
        return "Leg Armor";
    }
}
