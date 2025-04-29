using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Powerup : MonoBehaviour
{
    private static PowerupPool _pool;
    private static Sprite[] _icons;
    [SerializeField] private EPowerup _powerup;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _icons = new Sprite[Enum.GetNames(typeof(EPowerup)).Length];
        _icons[0] = Resources.Load<Sprite>("Sprites/NonePower");
        _icons[1] = Resources.Load<Sprite>("Sprites/BallPower");
        _icons[2] = Resources.Load<Sprite>("Sprites/BlastPower");
        _icons[3] = Resources.Load<Sprite>("Sprites/BombPower");
        _icons[4] = Resources.Load<Sprite>("Sprites/ChainPower");
        _icons[5] = Resources.Load<Sprite>("Sprites/GunPower");
        _icons[6] = Resources.Load<Sprite>("Sprites/ShieldPower");
    }

    private void Start()
    {
        if (null == _pool)
        {
            _pool = FindFirstObjectByType<PowerupPool>();
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementComponent>())
        {
            Debug.Log("boop");
            _pool.Release(this);
        }
    }

    public void Spawn(EPowerup type, Vector2 position)
    {
        _powerup = type;
        _spriteRenderer.sprite = _icons[(int) _powerup];
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        _powerup = EPowerup.None;
        gameObject.SetActive(false);
    }
}
