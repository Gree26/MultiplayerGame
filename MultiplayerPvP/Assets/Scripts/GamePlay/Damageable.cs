using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debugers;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float _initialHealth;

    [Space(5)]

    //[SerializeField] private unityEve

    private float _currentHealth;

    private void OnEnable() => _currentHealth = _initialHealth;

    public void Damage(float damage)
    {
        if (damage == 0)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _initialHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        DebugController.Instance.NewOutput(this.gameObject.name + " was killed.");
        Destroy(this.gameObject);
    }
}
