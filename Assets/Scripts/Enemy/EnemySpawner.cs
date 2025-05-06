using UnityEngine;

[RequireComponent (typeof(EnemyPool))]

public class EnemySpawner : MonoBehaviour
{
    private static System.Random rng = new System.Random();
    [SerializeField] private float _maxSpawnInterval = 3f;
    [SerializeField] private float _minSpawnInterval = 0.3f;
    [SerializeField] private float _spawnIntervalDelta = 0.03f;
    private float _timer = 0f;
    private EnemyPool _pool;

    private void Start()
    {
        _pool = GetComponent<EnemyPool>();
    }

    private void FixedUpdate()
    {
        // Periodically spawn enemies
        if (_timer > Mathf.Max(_maxSpawnInterval - _spawnIntervalDelta * Time.fixedTime, _minSpawnInterval))
        {
            SpawnEnemy();
            _timer = 0f;
        }
        _timer += Time.fixedDeltaTime;
    }

    private void SpawnEnemy()
    {
        float xRand = (float)(rng.NextDouble() * 0.9f + 0.05f);
        float yRand = (float)(rng.NextDouble() * 0.9f + 0.05f);
        Vector3 pos3 = Camera.main.ViewportToWorldPoint(new Vector3(xRand, yRand, 0f));
        Vector2 pos2 = new Vector2(pos3.x, pos3.y);
        Enemy enemy = _pool.Get();
        enemy.Spawn(pos2);
    }
}
