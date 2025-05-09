using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    private static string path = "data.txt";
    [SerializeField] private Image[] _scorePanels;
    [SerializeField] private TextMeshProUGUI[] _nameLabels;
    [SerializeField] private TextMeshProUGUI[] _scoreLabels;
    private Dictionary<string, int> _scores = new Dictionary<string, int>();
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private TextMeshProUGUI _scoreField;
    private Score _myScore;

    private void Start()
    {
        _myScore = Score.instance;
        if (!File.Exists(path))
        {
            using (StreamWriter streamWriter = File.CreateText(path)) { }
        }
        using (StreamReader streamReader = new StreamReader(path))
        {
            string data = streamReader.ReadToEnd();
            string[] raw = data.Split(',', '\n');
            if (raw.Length > 1)
            {
                for (int i = 0; i < raw.Length - 1; i += 2)
                {
                    _scores.Add(raw[i], int.Parse(raw[i + 1]));
                }
            }
        }
        if (_myScore.username == "")
        {
            _myScore.username = _nameField.text;
        }
        else
        {
            _nameField.text = _myScore.username;
            if (_scores.ContainsKey(_myScore.username))
            {
                int highscore = _scores[_myScore.username];
                if (_myScore.score > highscore)
                {
                    _scores[_myScore.username] = _myScore.score;
                }
            }
            else
            {
                _scores.Add(_myScore.username, _myScore.score);
            }
        }
        UpdateScores();
        _scoreField.text = _scores[_myScore.username].ToString();
    }

    public void ChangeName()
    {
        _myScore.username = _nameField.text;
        if (_scores.ContainsKey(_myScore.username))
        {
            _scoreField.text = _scores[_myScore.username].ToString();
        }
        else
        {
            _scoreField.text = 0.ToString();
        }
    }

    private void UpdateScores()
    {
        var sortedScores = _scores.OrderByDescending(score => score.Value);
        var topScores = sortedScores.Take(5);
        for (int i = 0; i < 5; i++)
        {
            if (i < topScores.Count())
            {
                _nameLabels[i].text = topScores.ElementAt(i).Key;
                _scoreLabels[i].text = topScores.ElementAt(i).Value.ToString();
            }
            else
            {
                _scorePanels[i].gameObject.SetActive(false);
            }
        }
    }

    public void Play()
    {
        using (StreamWriter streamWriter = new StreamWriter(path, false))
        {
            foreach (var item in _scores)
            {
                streamWriter.WriteLine(item.Key + "," + item.Value.ToString());
            }
        }
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        using (StreamWriter streamWriter = new StreamWriter(path, false))
        {
            foreach (var item in _scores)
            {
                streamWriter.WriteLine(item.Key + "," + item.Value.ToString());
            }
        }
        Application.Quit();
    }
}
