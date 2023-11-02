using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Rarity", order = 5)]
public class SItemRarity : ScriptableObject
{
    public string Name { get; private set; }
    public Material Material { get; private set; }
}
