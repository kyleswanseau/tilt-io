using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Camera cam;
    Vector2 playerPos;
    Vector2 cursorPos;

    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        playerPos = cam.WorldToScreenPoint(transform.position);
        cursorPos = (Vector2) Input.mousePosition;
        float moveMag = (float) System.Math.Floor(Vector2.Distance(cursorPos, playerPos));
        moveMag = (moveMag > 200f ? 200f : moveMag > 10f ? moveMag : 0f);
        Vector2 moveVector = cursorPos - playerPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);
        transform.eulerAngles = new Vector3(0f, 0f, moveAngle);
        transform.Translate(Vector2.up * (moveMag / 500f));
    }
}
