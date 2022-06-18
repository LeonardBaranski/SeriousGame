using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingameController : MonoBehaviour
{
    public playerController playerController;
    public scoreController scoreController;
    public bool gamePaused = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!gamePaused)
            {
                Time.timeScale = 0f;
                gamePaused = true;
            } else {
                Time.timeScale = 1f;
                gamePaused = false;
            }
            
        }
    }

    
    public void resetLevel()
    {
        scoreController.gameOver = false;
        playerController.levelDone = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
    }
}
