using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    private Text scoreLabel;
    public int score;
    public int highscore;

    // Start is called before the first frame update
    void Awake()
    {
        scoreLabel = GameObject.Find("ScoreText").GetComponent<Text>();

        //highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    public void SetScore()
    {
        score += 1;
    }

    public void ShowScore()
    {
        scoreLabel.text = "Score: " + score;
    }
}
