using UnityEngine;
using UnityEngine.Pool;

public class PowerupPool : MonoBehaviour
{
    [SerializeField] private Powerup _prefab;
    protected ObjectPool<Powerup> _pool;
    protected bool _collectionCheck = true;
    protected int _defaultSize = 5;
    protected int _maxSize = 10;

    protected void Awake()
    {
        _pool = new ObjectPool<Powerup>(
            PoolAdd,
            PoolPop,
            PoolPush,
            PoolDestroy,
            _collectionCheck,
            _defaultSize,
            _maxSize
            );
    }

    private Powerup PoolAdd()
    {
        Powerup newPowerup = Instantiate(_prefab);
        return newPowerup;
    }

    private void PoolPop(Powerup powerup)
    {

    }

    private void PoolPush(Powerup powerup)
    {

    }

    private void PoolDestroy(Powerup powerup)
    {
        powerup.Despawn();
        Destroy(powerup);
    }

    public Powerup Get(EPowerup type, Vector2 position)
    {
        Powerup powerup = _pool.Get();
        powerup.Spawn(type, position);
        return powerup;
    }

    public void Release(Powerup powerup)
    {
        powerup.Despawn();
        _pool.Release(powerup);
    }

    public void Clear()
    {
        _pool.Clear();
    }

    public void Dispose()
    {
        _pool.Dispose();
    }

    public int CountAll()
    {
        return _pool.CountAll;
    }

    public int CountActive()
    {
        return _pool.CountActive;
    }

    public int CountInactive()
    {
        return _pool.CountInactive;
    }
}
