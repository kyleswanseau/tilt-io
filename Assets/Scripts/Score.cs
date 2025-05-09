using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance { get; private set; }
    public string username { get; set; } = "";
    public int score { get; set; } = 0;

    private void Awake()
    {
        if (null != instance && this != instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
