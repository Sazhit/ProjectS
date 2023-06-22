using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IncreaseAttributes increaseAttributes))
        {
            increaseAttributes.Attributes();
        }

        if (collision.TryGetComponent(out ShieldShot shieldShot))
        {
            shieldShot.IsShoot = true;
        }

        if (collision.TryGetComponent(out Health damage))
        {
            damage.ApplyDamage(20f);
        }

        if (collision.TryGetComponent(out Shield shieldStrength))
        {
            shieldStrength.ApplyDamage(20f);
        }
    }
}
