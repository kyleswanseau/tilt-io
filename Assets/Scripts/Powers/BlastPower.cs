using UnityEngine;

public class BlastPower : Power
{
    private static float _speed = 15f;
    private static float _activeDuration = 5f;
    private float _timer;

    protected override void FixedUpdate()
    {
        if (_timer > _activeDuration)
        {
            Despawn();
        }
        else
        {
            _timer += Time.fixedDeltaTime;
        }
    }

    public override void Use(Vector3 position, float rotation)
    {
        transform.position = position;
        transform.eulerAngles = new Vector3(0f, 0f, rotation);
        Spawn();
    }

    public override void Trigger()
    {

    }

    public override void Spawn()
    {
        _timer = 0f;
        float rotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 moveVector = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        GetComponent<Rigidbody2D>().linearVelocity = (Vector2.Perpendicular(moveVector.normalized)) * _speed;
    }

    public override void Despawn()
    {
        Destroy(gameObject);
    }
}
