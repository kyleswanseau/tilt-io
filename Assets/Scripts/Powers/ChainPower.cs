using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class ChainPower : Power
{
    private static InputAction _attackAction;
    private static float _maxAngularVelocity = 1800f;
    private Vector2 _lastPlayerAngle;
    private Rigidbody2D _rb;
    private static float _activeDuration = 15f;
    private float _timer;

    private void Start()
    {
        if (null == _attackAction)
        {
            _attackAction = InputSystem.actions.FindAction("Attack");
        }
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = (Vector2)Player.player.transform.position;
        if (_attackAction.WasPressedThisFrame())
        {
            Trigger();
        }
    }

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

        float rotation = Player.player.transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 faceVector = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        Vector2 currentPlayerAngle = Vector2.Perpendicular(faceVector.normalized);
        float angle = Vector2.SignedAngle(currentPlayerAngle, _lastPlayerAngle);
        _rb.AddTorque(-angle);
        if (_rb.angularVelocity > _maxAngularVelocity)
        {
            _rb.angularVelocity = _maxAngularVelocity;
        }
        else if (_rb.angularVelocity < -_maxAngularVelocity)
        {
            _rb.angularVelocity = -_maxAngularVelocity;
        }
        _lastPlayerAngle = currentPlayerAngle;
    }

    public override void Use(Vector3 position, float rotation)
    {
        Spawn();
    }

    public override void Trigger()
    {

    }

    public override void Spawn()
    {
        _timer = 0f;
        transform.position = Player.player.transform.position;
        float rotation = Player.player.transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 faceVector = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        Vector2 _lastPlayerAngle = Vector2.Perpendicular(faceVector.normalized);
    }

    public override void Despawn()
    {
        Destroy(gameObject);
    }
}
