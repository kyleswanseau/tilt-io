using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;

    private void FixedUpdate()
    {
        if (Mathf.Floor(Time.fixedTime) < Mathf.Floor(Time.fixedTime + Time.fixedDeltaTime))
        {
            AddTimeScore();
        }
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDeathEvent += AddEnemyScore;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeathEvent -= AddEnemyScore;
    }

    private void AddTimeScore()
    {
        _score += 10;
        UpdateScore();
    }

    private void AddEnemyScore(Enemy enemy)
    {
        _score += 50;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
    }
}
