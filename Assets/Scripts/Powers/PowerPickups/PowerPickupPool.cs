using UnityEngine;
using UnityEngine.Pool;

// Wrapper for object pools
public class PowerPickupPool : MonoBehaviour
{
    [SerializeField] private PowerPickup _prefab;
    private ObjectPool<PowerPickup> _pool;
    private bool _collectionCheck = true;
    private int _defaultSize = 5;
    private int _maxSize = 10;

    private void Awake()
    {
        _pool = new ObjectPool<PowerPickup>(
            PoolAdd,
            PoolPop,
            PoolPush,
            PoolDestroy,
            _collectionCheck,
            _defaultSize,
            _maxSize
            );
    }

    private PowerPickup PoolAdd()
    {
        PowerPickup powerPickup = Instantiate(_prefab);
        return powerPickup;
    }

    private void PoolPop(PowerPickup powerPickup)
    {

    }

    private void PoolPush(PowerPickup powerPickup)
    {

    }

    private void PoolDestroy(PowerPickup powerPickup)
    {
        Destroy(powerPickup);
    }

    public PowerPickup Get()
    {
        return _pool.Get();
    }

    public void Release(PowerPickup powerPickup)
    {
        _pool.Release(powerPickup);
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
