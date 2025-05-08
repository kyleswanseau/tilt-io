using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Bullet : MonoBehaviour, IAttack
{
    private static BulletPool _pool;
    private static float _speed = 100f;

    private void Start()
    {
        if (null == _pool)
        {
            _pool = FindFirstObjectByType<BulletPool>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Border>())
        {
            Despawn();
        }
        else if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().Despawn();
        }
    }

    public void Spawn(Vector3 position, float rotation)
    {
        transform.eulerAngles = new Vector3(0f, 0f, rotation);
        Vector2 moveVector = new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad));
        Vector2 displacement = Vector2.Perpendicular(moveVector);
        transform.position = position + new Vector3(displacement.x, displacement.y, 0f);
        GetComponent<Rigidbody2D>().linearVelocity = (Vector2.Perpendicular(moveVector.normalized)) * _speed;
    }

    public void Despawn()
    {
        _pool.Release(this);
    }
}
