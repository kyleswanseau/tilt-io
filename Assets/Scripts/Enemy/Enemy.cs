using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private const float _speed = 5f;
    [SerializeField] private const float _maxSpeed = 50f;
    [SerializeField] private const float _minAggroDistance = 40f;
    [SerializeField] private const float _maxAggroDistance = 100f;
    [SerializeField] private const float _aggroMult = 10f;

    private Camera _cam;
    private Player _player;
    private Vector2 _playerPos;
    private Vector2 _myPos;
    private Rigidbody2D _rb;

    private void Start()
    {
        _cam = Camera.main;
        _player = Player.player;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get positions of player model and this enemy
        _playerPos = _player.playerPos;
        _myPos = _cam.WorldToScreenPoint(transform.position);

        // Compute movement speed as function of distance to player
        float distanceToPlayer = (float)System.Math.Floor(Vector2.Distance(_myPos, _playerPos));
        float moveMag = 
            (distanceToPlayer > _maxAggroDistance ? 
            _aggroMult : distanceToPlayer > _minAggroDistance ? 
            (1f - (distanceToPlayer - _minAggroDistance) / (_maxAggroDistance - _minAggroDistance)) *
            _aggroMult + _aggroMult : _aggroMult * 2);
        
        // Compute movement direction
        Vector2 moveVector = _playerPos - _myPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);

        // Rotate and translate this enemy
        _rb.rotation = moveAngle;
        _rb.linearVelocity = moveVector.normalized * (moveMag * _speed / 100f);
        //transform.eulerAngles = new Vector3(0f, 0f, moveAngle);
        //transform.Translate(Vector2.up * (moveMag / 500f));

        // WIP code that stretches enemies when they move faster
        /*
        if (moveMag > aggroMult)
        {
            Vector3 baseScale = new Vector3(0.2f, 0.2f, 1f);
            Vector3 chaseScale = new Vector3(1f, moveMag / aggroMult, 1f);
            transform.localScale = Vector3.Scale(baseScale, chaseScale);
        }
        */
        //Debug.Log(moveMag / aggroMult);
    }
}
