using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PowerPickup : MonoBehaviour
{
    private static PowerPickupPool _pool;
    private static Sprite[] _icons;
    [SerializeField] private EPower _power;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _icons = new Sprite[Enum.GetNames(typeof(EPower)).Length];
        _icons[0] = Resources.Load<Sprite>("Sprites/PowerPickups/NonePower");
        _icons[1] = Resources.Load<Sprite>("Sprites/PowerPickups/BallPower");
        _icons[2] = Resources.Load<Sprite>("Sprites/PowerPickups/BlastPower");
        _icons[3] = Resources.Load<Sprite>("Sprites/PowerPickups/BombPower");
        _icons[4] = Resources.Load<Sprite>("Sprites/PowerPickups/ChainPower");
        _icons[5] = Resources.Load<Sprite>("Sprites/PowerPickups/GunPower");
        _icons[6] = Resources.Load<Sprite>("Sprites/PowerPickups/ShieldPower");
    }

    private void Start()
    {
        if (null == _pool)
        {
            _pool = FindFirstObjectByType<PowerPickupPool>();
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Spawn(EPower type, Vector2 position)
    {
        _power = type;
        _spriteRenderer.sprite = _icons[(int) _power];
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        _power = EPower.NONE;
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    public static Sprite[] GetSprites()
    {
        return _icons;
    }

    public EPower GetPowerEnum()
    {
        return _power;
    }
}
