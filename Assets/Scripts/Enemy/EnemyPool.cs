using UnityEngine;
using UnityEngine.Pool;

// Wrapper for object pools
public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    protected ObjectPool<Enemy> _pool;
    protected bool _collectionCheck = true;
    protected int _defaultSize = 100;
    protected int _maxSize = 1000;

    protected void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            PoolAdd,
            PoolPop,
            PoolPush,
            PoolDestroy,
            _collectionCheck,
            _defaultSize,
            _maxSize
            );
    }

    private Enemy PoolAdd()
    {
        Enemy enemy = Instantiate(_prefab);
        return enemy;
    }

    private void PoolPop(Enemy enemy)
    {

    }

    private void PoolPush(Enemy enemy)
    {

    }

    private void PoolDestroy(Enemy enemy)
    {
        Destroy(enemy);
    }

    public Enemy Get()
    {
        return _pool.Get();
    }

    public void Release(Enemy enemy)
    {
        _pool.Release(enemy);
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
