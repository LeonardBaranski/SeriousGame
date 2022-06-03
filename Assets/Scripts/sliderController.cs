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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(sliderBar.value + "LOL");
            if (sliderBar.value < targetProgress)
            {
                sliderBar.value += fillSpeed * Time.deltaTime;
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = sliderBar.value + newProgress;
    }
}
