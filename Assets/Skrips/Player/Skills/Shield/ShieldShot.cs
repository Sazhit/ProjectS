using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShot : Shield
{
    [SerializeField] protected GameObject _spherePrefab;
    protected GameObject sphereProjectile;

    [SerializeField] protected float shootForce = 10f;
    [SerializeField] private float _distance;

    public bool IsShoot;

    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player) && IsShoot;
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        var direction = (mousePos - shieldProjectile.transform.position).normalized;
        sphereProjectile = Instantiate(_spherePrefab, shieldProjectile.transform.position + direction * _distance, Quaternion.identity);

        Rigidbody2D rb = sphereProjectile.GetComponent<Rigidbody2D>();

        rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
        Destroy(sphereProjectile, duration);
    }
}
