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
        corners[0] = cam.ScreenToWorldPoint(new Vector2(0, 0));
        corners[1] = cam.ScreenToWorldPoint(new Vector2(width, 0));
        corners[2] = cam.ScreenToWorldPoint(new Vector2(width, height));
        corners[3] = cam.ScreenToWorldPoint(new Vector2(0, height));
        corners[4] = cam.ScreenToWorldPoint(new Vector2(0, 0));
        edgeCollider.points = corners;
    }
}
