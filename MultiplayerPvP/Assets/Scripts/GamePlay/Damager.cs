using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debugers;

public abstract class Damager : MonoBehaviour
{
    public float damage;
    public void Damage(Damageable damageable) 
    { 
        damageable.Damage(damage);
        DebugController.Instance.NewOutput(this.gameObject.name + " - Damaged: " + damage);
    }
}
