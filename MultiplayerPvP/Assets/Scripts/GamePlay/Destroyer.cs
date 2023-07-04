using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    /// <summary>
    /// Invoke to destroy This game object.
    /// </summary>
    public void DestroyThis() => Destroy(this.gameObject);
}
