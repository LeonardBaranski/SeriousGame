using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{   
    scoreController scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreDisplay;
        scoreDisplay = GameObject.Find("ScoreController");
        scoreValue = scoreDisplay.GetComponent<scoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            scoreValue.SetScore();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
