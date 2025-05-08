using UnityEngine;
using UnityEngine.Pool;

// Wrapper for object pools
public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    private ObjectPool<Bullet> _pool;
    private bool _collectionCheck = true;
    private int _defaultSize = 5;
    private int _maxSize = 10;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            PoolAdd,
            PoolPop,
            PoolPush,
            PoolDestroy,
            _collectionCheck,
            _defaultSize,
            _maxSize
            );
    }

    private Bullet PoolAdd()
    {
        Bullet bullet = Instantiate(_prefab);
        return bullet;
    }

    private void PoolPop(Bullet bullet)
    {

    }

    private void PoolPush(Bullet bullet)
    {

    }

    private void PoolDestroy(Bullet bullet)
    {
        Destroy(bullet);
    }

    public Bullet Get()
    {
        return _pool.Get();
    }

    public void Release(Bullet bullet)
    {
        _pool.Release(bullet);
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
