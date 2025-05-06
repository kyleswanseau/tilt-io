using UnityEngine;

public class BlastPower : Power
{
    private static float _speed = 12f;

    protected override void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Border>())
        {
            Despawn();
        }
    }

    public override void Use(Vector2 position, float rotation)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.position = position;
        transform.eulerAngles = new Vector3(0f, 0f, rotation);
        Spawn();
    }

    public override void Trigger()
    {

    }

    public override void Spawn()
    {
        float rotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 moveVector = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        GetComponent<Rigidbody2D>().linearVelocity = (Vector2.Perpendicular(moveVector.normalized)) * _speed;
    }

    public override void Despawn()
    {
        Destroy(gameObject);
    }
}
