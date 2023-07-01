using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shield : Skill
{
    [Header("GameObject")]
    [SerializeField] private GameObject projectilePrefab;

    [Header("Strength")]
    [SerializeField] private float _durability;

    [Header("Settinge")]
    [SerializeField] protected float duration;
    [SerializeField] private bool _isShield;

    protected GameObject shieldProjectile;
    
    private Camera mainCam;

    private ObjectPool<GameObject> projectilePool;

    private void Start()
    {
        mainCam = Camera.main;

        projectilePool = new ObjectPool<GameObject>(() =>
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(true);
            return obj;
        });
    }

    private void Update()
    {
        if (shieldProjectile == null) return;

        MoveShield();
        CurrentShield();
    }
    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player) && _isShield;
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        shieldProjectile = projectilePool.Get();
        shieldProjectile.transform.position = player.transform.position;
        shieldProjectile.SetActive(true);
        _isShield = false;
    }

    public override void DoNotUse(PlayerController player)
    {
        base.DoNotUse(player);

        projectilePool.Release(shieldProjectile);
        shieldProjectile.SetActive(false);
        _isShield = true;
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
