using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolComponent : MonoBehaviour
{
    public GameObject prefab;

    protected ObjectPool<GameObject> pool;
    protected bool collectionCheck = true;
    protected int defaultSize = 50;
    protected int maxSize = 200;

    protected void Awake()
    {
        pool = new ObjectPool<GameObject>(
            PoolAdd,
            PoolPop,
            PoolPush,
            PoolDestroy,
            collectionCheck,
            defaultSize,
            maxSize
            );
    }

    private GameObject PoolAdd()
    {
        GameObject newObject = Instantiate(prefab);
        return newObject;
    }

    private void PoolPop(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void PoolPush(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void PoolDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void Release(GameObject obj)
    {
        pool.Release(obj);
    }

    public void Clear()
    {
        pool.Clear();
    }

    public void Dispose()
    {
        pool.Dispose();
    }

    public int CountAll()
    {
        return pool.CountAll;
    }

    public int CountActive()
    {
        return pool.CountActive;
    }

    public int CountInactive()
    {
        return pool.CountInactive;
    }
}
