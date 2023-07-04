using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Basic", order = 1)]
public class SItem : ScriptableObject
{
    /// <summary>
    /// Contains Every item with its name. 
    /// </summary>
    protected static Dictionary<string, SItem> items = new Dictionary<string, SItem>();

    [SerializeField]
    protected string _itemName = "[PH]";

    [SerializeField]
    protected SItemRarity _rarity;

    [SerializeField]
    private Sprite icon;

    private static int id = 0;

    public string itemName
    {
        get => _itemName;
    }

    public SItemRarity Rarity
    {
        get => _rarity;
    }

    [SerializeField]
    protected List<Sprite> _itemImage;
    public List<Sprite> itemImage
    {
        get => _itemImage;
    }

    protected int _stackCap = 999;

    public int StackCap()
    {
        return _stackCap;
    }

    private void Awake()
    {
        if (items.ContainsKey(_itemName))
        {
            Debug.LogError("Item Name Already Exists! Item Name: " + _itemName + " already exists on item " + items[_itemName]);
        }

        items.Add(_itemName, this);
    }

    /// <summary>
    /// Creates a Drop with this 
    /// </summary>
    /// <param name="position"></param>
    public void CreateDrop(Vector3 position)
    {
        // Potentially could be a buffer overflow issue but for now ima just use this.
        id++;
        GameObject go1 = new GameObject();
        go1.name = "Drop - " + id;
        go1.transform.position = position;
        SpriteRenderer go1Renderer = go1.AddComponent<SpriteRenderer>();
        go1Renderer.sprite = icon;
    }
}
