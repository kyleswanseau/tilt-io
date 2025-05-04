using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(InventoryComponent))]

public class Player : MonoBehaviour
{
    [SerializeField] private const float _speed = 10f;
    [SerializeField] private const float _maxSpeed = 500f;
    private Camera _cam;
    private Vector2 _cursorPos;
    private Rigidbody2D _rb;
    private InventoryComponent _inventory;

    public static Player player { get; private set; }
    public Vector2 playerPos { get; private set; }

    private void Awake()
    {
        if (null != player && this != player)
        {
            Destroy(this);
        }
        else
        {
            player = this;
        }
    }

    private void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<InventoryComponent>();
    }

    private void FixedUpdate()
    {
        // Get positions of player model and mouse cursor
        playerPos = _cam.WorldToScreenPoint(transform.position);
        _cursorPos = (Vector2)Input.mousePosition;

        // Compute movement speed as function of distance to cursor
        float moveMag = (float)System.Math.Floor(Vector2.Distance(_cursorPos, playerPos));
        moveMag = (moveMag > _maxSpeed ? _maxSpeed : moveMag > 10f ? moveMag : 0f);

        // Compute movement direction
        Vector2 moveVector = _cursorPos - playerPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);

        // Rotate and translate player model
        _rb.rotation = moveAngle;
        _rb.linearVelocity = moveVector.normalized * (moveMag * _speed / 100f);
    }
}
