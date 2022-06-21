using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowsController : MonoBehaviour
{
    public float force = 20;
    public GameObject arrow;
    public GameObject horseman;
    public Sprite horseman_idle;
    public Sprite horseman_aiming;
    public Sprite horseman_shot;
    public Transform spawn;
    public Transform crosshair;
    public float fireRate = 1f;
    private float lastShot = 0f;
    private Slider slider;

    public AudioSource bowDraw;
    public AudioSource arrowShoot;

    private bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireRate + lastShot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                horseman.GetComponent<SpriteRenderer>().sprite = horseman_aiming;
                if(!played){
                    bowDraw.Play();
                    played = true;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                played = false;
                horseman.GetComponent<SpriteRenderer>().sprite = horseman_shot;
                StartCoroutine(resetHorseman());
                SetForce();
                arrowShoot.Play();
                ShootArrow();
                lastShot = Time.time;
                Debug.Log(force);
            }
        }
    }

    private void SetForce()
    {
        
        force = slider.value;
        Debug.Log("VALUE IST:" + force);
    }

    private float GetForce()
    {
        return force;
    }


    private void ShootArrow()
    {
        Vector3 spawnPos = spawn.position;
        Vector3 crosshairPos = crosshair.position;
        Vector3 fromSpawnToCross = spawnPos - crosshairPos;
        fromSpawnToCross.Normalize();

        GameObject clone = Instantiate(arrow, spawn.position, Quaternion.Euler(0f, 0f, 10f));
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = fromSpawnToCross * GetForce() * -1;
        slider.value = 1;
        Destroy(clone, 4f);
    }

    IEnumerator resetHorseman()
    {
        yield return new WaitForSeconds(fireRate);
        horseman.GetComponent<SpriteRenderer>().sprite = horseman_idle;
    }

    
}

