using UnityEngine;

[RequireComponent (typeof(EdgeCollider2D))]

public class Border : MonoBehaviour
{
    private void Start()
    {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();
        Camera cam = Camera.main;
        int width = Screen.width;
        int height = Screen.height;
        Vector2[] corners = new Vector2[5];
        corners[0] = cam.ScreenToWorldPoint(new Vector2(0, 0)) + new Vector3(-1f, -1f, 0f);
        corners[1] = cam.ScreenToWorldPoint(new Vector2(width, 0)) + new Vector3(1f, -1f, 0f);
        corners[2] = cam.ScreenToWorldPoint(new Vector2(width, height)) + new Vector3(1f, 1f, 0f);
        corners[3] = cam.ScreenToWorldPoint(new Vector2(0, height)) + new Vector3(-1f, 1f, 0f);
        corners[4] = cam.ScreenToWorldPoint(new Vector2(0, 0)) + new Vector3(-1f, -1f, 0f);
        edgeCollider.points = corners;
    }
}
