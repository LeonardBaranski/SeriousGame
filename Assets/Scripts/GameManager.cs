using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startTargetImage;

    // Start is called before the first frame update
    void Awake()
    {
        startTargetImage.SetActive(false);
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
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SampleScene");
    }
}
