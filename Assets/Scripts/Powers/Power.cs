using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public abstract class Power : MonoBehaviour, IAttack
{
    protected abstract void FixedUpdate();

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public abstract void Use(Vector2 position, float rotation);

    public abstract void Spawn();

    public abstract void Despawn();

    public static Type EnumToType(EPower power)
    {
        switch (power)
        {
            case EPower.NONE: return null;
            case EPower.BALL: return typeof(BallPower);
            case EPower.BLAST: return typeof(BlastPower);
            case EPower.BOMB: return typeof(BombPower);
            case EPower.CHAIN: return typeof(ChainPower);
            case EPower.GUN: return typeof(GunPower);
            case EPower.SHIELD: return typeof(ShieldPower);
            default: return null;
        }
    }

    public static Enum TypeToEnum(Type type)
    {
        if (type == null) return EPower.NONE;
        else if (type == typeof(BallPower)) return EPower.BALL;
        else if (type == typeof(BlastPower)) return EPower.BLAST;
        else if (type == typeof(BombPower)) return EPower.BOMB;
        else if (type == typeof(ChainPower)) return EPower.CHAIN;
        else if (type == typeof(GunPower)) return EPower.GUN;
        else if (type == typeof(ShieldPower)) return EPower.SHIELD;
        else return EPower.NONE;
    }
}