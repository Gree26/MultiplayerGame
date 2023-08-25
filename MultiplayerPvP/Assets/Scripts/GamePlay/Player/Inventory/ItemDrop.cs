using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private SItem _item;
    [SerializeField]
    private int _total;

    //private Coroutine _magnetMove;
    //GameObject _follow;

    public ItemDrop(SItem item, int amount)
    {
        _item = item;
        _total = amount;
    }

    private void OnValidate()
    {
        this.GetComponent<SpriteRenderer>().sprite = _item.itemImage;
    }

    public ItemStack GetItemStack()
    {
        return new ItemStack(_item, _total);
    }

    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (_magnetMove!=null && collision.gameObject.tag=="Magnet")
        //{
        //    Debug.Log("Magnet entered");
        //    _magnetMove = StartCoroutine(MoveTowards(collision.gameObject));
        //}
    }

    //private IEnumerator MoveTowards(GameObject target)
    //{
        //_follow = target;
        //while (_follow != null)
        //{
        //    Vector2 offset = this.transform.position - target.transform.position;
        //    this.transform.position = (Vector2)this.transform.position+offset.normalized * 0.1f;
        //    yield return null;
        //}
    //}
}
