using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _scoreText;
    private static int _timeScore = 10;
    private int _score = 0;
    private Queue<int> _queue = new Queue<int>();

    private void Awake()
    {
        if (null != instance && this != instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Floor(Time.fixedTime) < Mathf.Floor(Time.fixedTime + Time.fixedDeltaTime))
        {
            QueueScore(_timeScore);
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i < _queue.Count; i++)
        {
            _score += _queue.Dequeue();
        }
        _scoreText.text = _score.ToString();
    }

    public void QueueScore(int score)
    {
        _queue.Enqueue(score);
    }

    public int GetScore()
    {
        return _score;
    }
}
