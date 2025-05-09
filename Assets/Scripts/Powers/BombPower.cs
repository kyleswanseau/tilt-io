using UnityEngine;

public class BombPower : Power
{
    private static float _explosionDelay = 3f;
    private static float _explosionLength = 1f;
    private float _timer;
    private bool _isExploding;
    [SerializeField] private TextMesh _textMesh;
    [SerializeField] private Explosion _explosion;

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

    public override void Use(Vector3 position, float rotation)
    {
        transform.position = position;
        Spawn();
    }

    public override void Trigger()
    {
        
    }

    public override void Spawn()
    {
        _timer = 0f;
        _isExploding = false;
        _textMesh.text = Mathf.CeilToInt(_explosionDelay - _timer).ToString();
    }

    private void Explode()
    {
        _timer = 0f;
        _isExploding = true;
        _textMesh.gameObject.SetActive(false);
        _explosion.gameObject.SetActive(true);
    }
}
