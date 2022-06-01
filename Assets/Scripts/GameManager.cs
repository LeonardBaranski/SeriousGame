using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject startTargetImage;

    // Start is called before the first frame update
    void Awake()
    {
        startMenuPanel.SetActive(true);
        startTargetImage.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(start());
    }

    private IEnumerator start()
    {
        startTargetImage.SetActive(true);
        Time.timeScale = 1;
        yield return new WaitForSeconds(2f);

        startMenuPanel.SetActive(false);
    }
}
