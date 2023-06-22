using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamage
{
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float _healthRecoveryRate;

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > 0)
                _currentHealth = value;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
