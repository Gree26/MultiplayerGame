using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Basic", order = 1)]
public class SItem : ScriptableObject
{
    /// <summary>
    /// Contains Every item with its name. 
    /// </summary>
    protected static Dictionary<short, SItem> items = new Dictionary<short, SItem>();

    [SerializeField]
    protected string _itemName = "[PH]";

    [SerializeField]
    protected SItemRarity _rarity;

    [SerializeField]
    private Sprite icon;

    //This exists so that I can clear it from the dictionary if the value chagened and add a new one
    private short _myId = -1;

    [SerializeField]
    private short _id = -1;

    public short Id
    {
        get => _id;
    }

    public string itemName
    {
        get => _itemName;
    }

    public SItemRarity Rarity
    {
        get => _rarity;
    }

    [SerializeField]
    protected Sprite _itemImage;
    public Sprite itemImage
    {
        get => _itemImage;
    }

    protected int _stackCap = 999;

    public int GetStackCap()
    {
        return _stackCap;
    }

    private void OnValidate()
    {
        // Value was not changed for the ID
        if (_id == _myId)
        {
            return;
        }

        if (_id < 0)
        {
            Debug.LogError("SItem: " + itemName +  " | ID CANNOT BE NEGATIVE.");
            return;
        }

        if(items.ContainsKey(_id)&& items[_id] != this)
        {
            Debug.LogError("SItem: " + itemName + " | ID EXISTS ALREADY FOR " + items[_id].itemName + ".");
            return;
        }

        if (_myId >= 0)
        {
            items.Remove(_myId);
        }

        _myId = _id;

        items.Add(_id,this);
    }

    /// <summary>
    /// Creates a Drop with this 
    /// </summary>
    /// <param name="position"></param>
    public void CreateDrop(Vector3 position)
    {
        GameObject go1 = new GameObject();
        go1.name = "Drop - " + _id;
        go1.transform.position = position;
        SpriteRenderer go1Renderer = go1.AddComponent<SpriteRenderer>();
        go1Renderer.sprite = icon;
    }
}
