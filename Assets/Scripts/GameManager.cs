using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    // Start is called before the first frame update
    void Awake()
    {
        startMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        startMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
