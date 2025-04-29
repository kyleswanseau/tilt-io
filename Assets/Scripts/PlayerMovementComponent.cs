using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _cursorPos;

    public Vector2 playerPos { get; private set; }

    private void Start()
    {
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        // Get positions of player model and mouse cursor
        playerPos = _cam.WorldToScreenPoint(transform.position);
        _cursorPos = (Vector2)Input.mousePosition;

        // Compute movement speed as function of distance to cursor
        float moveMag = (float)System.Math.Floor(Vector2.Distance(_cursorPos, playerPos));
        moveMag = (moveMag > 200f ? 200f : moveMag > 10f ? moveMag : 0f);

        // Compute movement direction
        Vector2 moveVector = _cursorPos - playerPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);

        // Rotate and translate player model
        transform.eulerAngles = new Vector3(0f, 0f, moveAngle);
        transform.Translate(Vector2.up * (moveMag / 500f));
    }
}
