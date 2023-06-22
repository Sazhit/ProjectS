using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoringHealth : Health
{
    [SerializeField] private float _recoveryTime;

    private float timer;

    private void FixedUpdate()
    {
        RegenerateHealth();
    }

    private void RegenerateHealth()
    {
        if (CurrentHealth < _maxHealth)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= _recoveryTime)
            {
                CurrentHealth += _healthRecoveryRate;
                CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, _maxHealth);
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
