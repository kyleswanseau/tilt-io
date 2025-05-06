using System;
using UnityEngine;

[RequireComponent(typeof(PowerPickupPool))]

public class PowerPickupSpawner : MonoBehaviour
{
    private static System.Random rng = new System.Random();
    private static PowerPickupPool _pool;
    private float _lastSpawn = 0f;
    private float _nextSpawn = 0f;

    private void Start()
    {
        if (null == _pool)
        {
            _pool = GetComponent<PowerPickupPool>();
        }
        ResetCooldown();
    }

    private void FixedUpdate()
    {
        if (_lastSpawn + _nextSpawn <= Time.fixedTime)
        {
            if (_pool.CountActive() < 4)
            {
                SpawnPowerPickup();
            }
            _lastSpawn = Time.fixedTime;
            ResetCooldown();
        }
    }

    private void SpawnPowerPickup()
    {
        EPower randPowerPickup = (EPower)(rng.Next(Enum.GetNames(typeof(EPower)).Length - 1) + 1);
        float xRand = (float)(rng.NextDouble() * 0.8f + 0.1f);
        float yRand = (float)(rng.NextDouble() * 0.8f + 0.1f);
        Vector3 pos3 = Camera.main.ViewportToWorldPoint(new Vector3(xRand, yRand, 0f));
        Vector2 pos2 = new Vector2(pos3.x, pos3.y);
        PowerPickup powerPickup = _pool.Get();
        powerPickup.Spawn(randPowerPickup, pos2);
    }

    private void ResetCooldown()
    {
        _nextSpawn = (float)(rng.NextDouble() * 10f + 5f);
    }
}
