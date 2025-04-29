using System;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    private static System.Random rng = new System.Random();
    private static PowerupPool _pool;
    private float _lastSpawn = 0f;
    private float _nextSpawn = 0f;

    private void Start()
    {
        if (null == _pool)
        {
            _pool = FindFirstObjectByType<PowerupPool>();
        }
        ResetCooldown();
    }

    private void FixedUpdate()
    {
        if (_lastSpawn + _nextSpawn <= Time.time)
        {
            if (_pool.CountActive() < 4)
            {
                EPowerup randPowerup = (EPowerup) (rng.Next(Enum.GetNames(typeof(EPowerup)).Length - 1) + 1);
                float randx = (float) (rng.NextDouble() * 0.8f + 0.1f);
                float randy = (float) (rng.NextDouble() * 0.8f + 0.1f);
                Vector3 pos3 = Camera.main.ViewportToWorldPoint(new Vector3(randx, randy, 0f));
                Vector2 pos2 = new Vector2(pos3.x, pos3.y);
                _pool.Get(randPowerup, pos2);
            }
            _lastSpawn = Time.time;
            ResetCooldown();
        }
    }

    private void ResetCooldown()
    {
        _nextSpawn = (float) (rng.NextDouble() * 10f + 5f);
    }
}
