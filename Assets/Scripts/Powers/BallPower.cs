using UnityEngine;

public class BallPower : Power
{
    private static float _speed = 5f;
    private static float _activeDuration = 20f;
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
        transform.eulerAngles = new Vector3(0f, 0f, rotation);
        Vector2 moveVector = new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad));
        Vector3 displacement = new Vector3(moveVector.x * 0.5f, moveVector.y * 0.5f, 0f);
        transform.position = position + displacement;
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
}
