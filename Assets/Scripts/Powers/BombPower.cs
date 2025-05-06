using UnityEngine;

public class BombPower : Power
{
    private static float _explosionDelay = 3f;
    private static float _explosionLength = 1f;
    private float _timer;
    private bool _isExploding;
    [SerializeField] private TextMesh _textMesh;
    [SerializeField] private ExplosionBehaviour _explosion;

    private void Start()
    {

    }

    protected override void FixedUpdate()
    {
        if (!_isExploding)
        {
            if (_timer < _explosionDelay)
            {
                _textMesh.text = Mathf.CeilToInt(_explosionDelay - _timer).ToString();
                _timer += Time.fixedDeltaTime;
            }
            else
            {
                Explode();
            }
        }
        else
        {
            if (_timer < _explosionLength)
            {
                _timer += Time.fixedDeltaTime;
            }
            else
            {
                Despawn();
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        }
    }

    public override void Use(Vector2 position, float rotation)
    {
        transform.position = position;
        Spawn();
    }

    public override void Spawn()
    {
        _timer = 0f;
        _isExploding = false;
        _textMesh.text = Mathf.CeilToInt(_explosionDelay - _timer).ToString();
        gameObject.SetActive(true);
    }

    public override void Despawn()
    {
        _timer = 0f;
        gameObject.SetActive(false);
        Destroy(this);
    }

    private void Explode()
    {
        _timer = 0f;
        _isExploding = true;
        _textMesh.gameObject.SetActive(false);
        _explosion.gameObject.SetActive(true);
    }
}
