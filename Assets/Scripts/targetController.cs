using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{   
    scoreController scoreValue;
    
    public int targetPoints = 1;
    public GameObject targetSlicedPrefab;
    public float explosionForce = 5f;

    public AudioSource impactSound;

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

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            scoreValue.SetScore(targetPoints);
            impactSound.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);
            CreateSlicedTarget();
        }
    }

    public void CreateSlicedTarget()
    {
        GameObject inst = Instantiate(targetSlicedPrefab, gameObject.transform.position, transform.rotation);
        Rigidbody[] rbonsliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rbonsliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(100,200), transform.position, 0f, explosionForce);
        }

        Destroy(inst.gameObject, 1.5f);
    }
}
