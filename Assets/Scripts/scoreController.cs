using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    private Text scoreLabel;
    public int score;
    public int highScore;
    public bool gameOver;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GameObject.Find("ScoreText").GetComponent<Text>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
        showHighScore();
        if (Time.timeScale == 0)
        {
            GameOver();
        }
    }

    public void SetScore()
    {
        score += 1;
    }

    public void ShowScore()
    {
        scoreLabel.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        showHighScore();
    }

    void showHighScore()
    {
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
}
