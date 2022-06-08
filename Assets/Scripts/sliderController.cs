using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderController : MonoBehaviour
{
    private Slider sliderBar;

    public float fillSpeed = 10f;
    private float targetProgress = 0;
    public float maxForce = 33f;

    private float fireRate = 1f;
    private float lastShot = 0f;

    public playerController levelOver;

    // Start is called before the first frame update
    void Awake()
    {
        sliderBar = gameObject.GetComponent<Slider>();
        sliderBar.value = 1;
    }

    void Start()
    {
        IncrementProgress(maxForce);
    }

    // Update is called once per frame
    void Update()
    {
        IsGameRunning();
        if (Time.time > fireRate + lastShot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (sliderBar.value < targetProgress)
                {
                    sliderBar.value += fillSpeed * Time.deltaTime;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                lastShot = Time.time;
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = sliderBar.value + newProgress;
    }

    void IsGameRunning()
    {
        if (levelOver.levelDone)
        {
            gameObject.SetActive(false);
        }
    }
}
