using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectionController : MonoBehaviour
{
    public string level1name;
    public int level1highscore = 0;
    public Text level1display;
    public string level2name;
    public int level2highscore = 0;
    public Text level2display;
    public string level3name;
    public int level3highscore = 0;
    public Text level3display;

    // Start is called before the first frame update
    void Start()
    {
        level1highscore = PlayerPrefs.GetInt("HighScore" + level1name, 0);
        level2highscore = PlayerPrefs.GetInt("HighScore" + level2name, 0);
        level3highscore = PlayerPrefs.GetInt("HighScore" + level3name, 0);

        if (level1highscore <= 0) {
            level1highscore = 0;
        }
        if (level2highscore <= 0) {
            level2highscore = 0;
        }
        if (level3highscore <= 0) {
            level3highscore = 0;
        }
        level1display.text = "Highscore: " + level1highscore;
        level2display.text = "Highscore: " + level2highscore;
        level3display.text = "Highscore: " + level3highscore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playPrologue()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void playLevel1()
    {
        SceneManager.LoadScene(level1name);
    }
    
    public void playLevel2()
    {
        SceneManager.LoadScene(level2name);
    }
    
    public void playLevel3()
    {
        //SceneManager.LoadScene(level3name);
        Debug.Log("Coming Soon");
    }
    
    public void playCredits()
    {
        //SceneManager.LoadScene("Credits");
        Debug.Log("Insert Credits here");
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
