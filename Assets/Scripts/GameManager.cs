using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startTargetImage;
    public GameObject canvas;
    public GameObject skipCanvas;
    public GameObject startMenu;
    public GameObject titleText1, titleText2;
    public GameObject startText1, startText2;
    public Camera playerCam;

    public float waitAtStart = 1.5f;
    public bool scrolling = true;
    public float scrollSpeed = 4;
    public float startXpos = 0f;
    public float endXpos = 235.01f;
    public float distance;
    public float spareDistance = 0;
    public float travelledRatio = 0;
    public float startYpos = 0f;
    public float endYpos = 0.573f;
    public float yDistance;
    public float startCamSize = 7.3f;
    public float endCamSize = 6.43f;
    public float sizeDifference;
    public float fadeInTime = 2.0f;
    public float cropTime = 8.0f;
    public bool cropping = false;
    public float txtColVal = 0.196f;

    // Start is called before the first frame update
    void Awake()
    {
        startTargetImage.SetActive(false);
        canvas.GetComponent<Canvas>().enabled = false;
        distance = endXpos - startXpos;
        yDistance = endYpos - startYpos;
        sizeDifference = endCamSize - startCamSize;
        titleText1.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 0f);
        titleText2.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 0f);
        startText1.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 0f);
        startText2.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 0f);
        startMenu.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0f);

        scrolling = false;
        StartCoroutine(startScrolling());
    }

    private IEnumerator startScrolling()
    {
        yield return new WaitForSeconds(waitAtStart);
        scrolling = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scrolling)
        {
            Vector3 camPos = playerCam.transform.position;

            camPos.x += scrollSpeed * Time.deltaTime;
            playerCam.transform.position = camPos;

            spareDistance = distance - camPos.x;
            travelledRatio = 1 - spareDistance / distance;
            
            float newYPos = startYpos + travelledRatio * yDistance;
            float newCamSize = startCamSize + travelledRatio * sizeDifference;

            camPos = playerCam.transform.position;
            camPos.y = newYPos;
            playerCam.transform.position = camPos;
            
            playerCam.orthographicSize = newCamSize;

            if (camPos.x >= endXpos) 
            {
                scrolling = false;
                StartCoroutine(fadeInMenu());
                camPos.x = endXpos;
                camPos.y = endYpos;
                playerCam.transform.position = camPos;
                playerCam.orthographicSize = endCamSize;
            }
        } 
    }

    private IEnumerator fadeInMenu()
    {
        canvas.GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        skipCanvas.GetComponent<Canvas>().enabled = false;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeInTime)
        {
            Color newColor = new Color(txtColVal, txtColVal, txtColVal, Mathf.Lerp(0f,1f,t));
            Color startMenuColor = new Color(1, 1, 1, Mathf.Lerp(0f,1f,t));
            startMenu.GetComponent<UnityEngine.UI.Image>().color = startMenuColor;
            titleText1.GetComponent<UnityEngine.UI.Text>().color = newColor;
            titleText2.GetComponent<UnityEngine.UI.Text>().color = newColor;
            yield return null;
        }
        startMenu.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
        titleText1.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 1);
        titleText2.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 1);

        yield return new WaitForSeconds(1f);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeInTime)
        {
            Color newColor = new Color(txtColVal, txtColVal, txtColVal, Mathf.Lerp(0f,1f,t));
            startText1.GetComponent<UnityEngine.UI.Text>().color = newColor;
            startText2.GetComponent<UnityEngine.UI.Text>().color = newColor;
            yield return null;
        }
        startText1.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 1);
        startText2.GetComponent<UnityEngine.UI.Text>().color = new Color(txtColVal, txtColVal, txtColVal, 1);

    }

    public void skipIntro()
    {
        StartCoroutine(fadeInMenu());
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

        SceneManager.LoadScene("SampleScene 1");
    }
}
