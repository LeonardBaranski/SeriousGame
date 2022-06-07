using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetController : MonoBehaviour
{
    public Text scoreLabel;
    public int score;
    public int highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        //highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        showScore();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            score += 1;
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

    public void showScore()
    {
        scoreLabel.text = "Score: " + score;
    }
}
