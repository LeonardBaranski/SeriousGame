using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreController : MonoBehaviour
{
    private Text scoreLabel;
    public int score;
    public int highScore;
    public bool gameOver;
    public Canvas ingameCanvas;
    public Text highScoreText;
    public GameObject resetLevelButton;
    public GameObject returnToMenuButton;
    public Canvas endScreenCanvas;
    public Text endScoreLabel;
    public Text endHighScore;
    public playerController endGame;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GameObject.Find("ScoreText").GetComponent<Text>();

        levelName = SceneManager.GetActiveScene().name;
        highScore = PlayerPrefs.GetInt("HighScore" + levelName, 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
        showHighScore();
        if (endGame.levelDone)
        {
            returnToMenuButton.GetComponent<Button>().interactable = false;
            resetLevelButton.GetComponent<Button>().interactable = false;
            StartCoroutine(waitForEnd());
        }
    }

    public void SetScore(int targetPoints)
    {
        score += targetPoints;
    }

    public void ShowScore()
    {
        scoreLabel.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("GAMEOVER");
        //highScore = PlayerPrefs.GetInt("HighScore", 0);

        endScoreLabel.text = "Punktzahl: " + score;
        endHighScore.text = "Highscore: " + highScore;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore" + levelName, highScore);
            endHighScore.text = "Neuer Highscore!";
        }
        showHighScore();
        ingameCanvas.GetComponent<Canvas>().enabled = false;
        endScreenCanvas.GetComponent<Canvas>().enabled = true;
    }

    void showHighScore()
    {
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    private IEnumerator waitForEnd()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        GameOver();
    }
}
