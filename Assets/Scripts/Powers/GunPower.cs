using UnityEngine;
using UnityEngine.InputSystem;

public class GunPower : Power
{
    private static InputAction _attackAction;
    private static BulletPool _bulletPool;
    private static int _maxBullets = 5;
    private int _bullets;

    private void Start()
    {
        if (null == _bulletPool)
        {
            _bulletPool = FindFirstObjectByType<BulletPool>();
        }
        if (null == _attackAction)
        {
            _attackAction = InputSystem.actions.FindAction("Attack");
        }
    }

    private void Update()
    {
        if (_attackAction.WasPressedThisFrame())
        {
            Trigger();
        }
    }

    protected override void FixedUpdate()
    {

    }

    public override void Use(Vector3 position, float rotation)
    {
        Spawn();
    }

    public override void Trigger()
    {
        Bullet bullet = _bulletPool.Get();
        bullet.Spawn(transform.position, transform.eulerAngles.z);
        _bullets--;
        if (_bullets <= 0)
        {
            Despawn();
        }
    }

    public override void Spawn()
    {
        transform.position = Player.player.transform.position;
        transform.parent = Player.player.transform;
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localEulerAngles = Vector3.zero;
        _bullets = _maxBullets;
    }
}
