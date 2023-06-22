using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill
{
    [Header("GameObject")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("Strength")]
    [SerializeField] private float _durability;

    [Header("Settinge")]
    [SerializeField] protected float duration;

    protected GameObject shieldProjectile;
    
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (shieldProjectile == null) return;

        MoveShield();
        CurrentShield();
    }
    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player) && shieldProjectile == null;
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        shieldProjectile = Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
        Destroy(shieldProjectile, duration);
    }

    private void MoveShield()
    {
        var mousePos = Input.mousePosition;
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        shieldProjectile.transform.position = transform.position;

        Vector3 direction = mousePos - transform.position;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shieldProjectile.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void ApplyDamage(float damage)
    {
        _durability -= damage;
    }

    public void CurrentShield()
    {
        if (_durability <= 0)
        {
            shieldProjectile.SetActive(false);
        }
    }
}
