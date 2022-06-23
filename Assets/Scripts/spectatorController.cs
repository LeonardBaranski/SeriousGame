using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spectatorController : MonoBehaviour
{
    scoreController scoreValue;

    public int targetPoints = 2;
    public int hittingSpectator = -1;

    public GameObject targetSlicedPrefab;
    public float explosionForce = 5f;
    
    public AudioSource grunt;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreDisplay;
        scoreDisplay = GameObject.Find("ScoreController");
        scoreValue = scoreDisplay.GetComponent<scoreController>();
    }

    /* public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Arrow"))
        {
            scoreValue.SetScore(targetPoints);
            Destroy(col.gameObject);
            CreateSlicedTarget();
        }
    } */

    public void OnTriggerEnter2D(Collider2D trg)
    {
        if (trg.gameObject.tag.Equals("Arrow"))
        {
            grunt.Play();
            scoreValue.SetScore(hittingSpectator);
            Destroy(trg.gameObject);
            StartCoroutine("FlashSpectator");
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

    private IEnumerator FlashSpectator()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        yield return new WaitForSeconds(.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
}
