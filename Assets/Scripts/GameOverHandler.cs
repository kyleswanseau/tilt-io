using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Image gameoverPanel;

    public void GameOver()
    {
        Time.timeScale = 0f;
        int score = FindFirstObjectByType<ScoreHandler>().GetScore();
        Score.instance.score = score;
        gameoverPanel.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
