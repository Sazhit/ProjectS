using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    [SerializeField] private float _force;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _ignoreLayerCollisionTime;
    [SerializeField] private bool _isDashing;

    public bool IsDashing { get => _isDashing; set => _isDashing = value; }
    public float Force { get => _force; set => _force = value; }

    public const int LAYER_PLAYER = 3;
    public const int LAYER_ENEMY = 9;

    public override bool CanUse(PlayerController player)
    {
        return base.CanUse(player) && IsDashing;
    }

    public override void Use(PlayerController player)
    {
        base.Use(player);

        var moveX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveX.magnitude > 1f)
        {
            moveX = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            player.Rb2D.AddForce(moveX * Force, ForceMode2D.Impulse);
        }
        else
        {
            moveX = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            player.Rb2D.AddForce(moveX * Force, ForceMode2D.Impulse);
        }

        StartCoroutine(Cooldown());

        _isDashing = false;
    }

    IEnumerator Cooldown()
    {
        Physics2D.IgnoreLayerCollision(LAYER_PLAYER, LAYER_ENEMY, true);
        yield return new WaitForSeconds(_ignoreLayerCollisionTime);
        Physics2D.IgnoreLayerCollision(LAYER_PLAYER, LAYER_ENEMY, false);
        yield return new WaitForSeconds(_cooldown);
        _isDashing = true;
    }

}
