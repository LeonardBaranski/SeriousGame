using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowsController : MonoBehaviour
{
    public float force = 20;
    public GameObject arrow;
    public GameObject startMenu;
    public GameObject horseman;
    public Sprite horseman_idle;
    public Sprite horseman_aiming;
    public Sprite horseman_shot;
    public Transform spawn;
    public Transform crosshair;
    public float fireRate = 1f;
    private float lastShot = 0f;
    private Slider slider;


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
            if (!startMenu.activeSelf)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    horseman.GetComponent<SpriteRenderer>().sprite = horseman_aiming;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    horseman.GetComponent<SpriteRenderer>().sprite = horseman_shot;
                    StartCoroutine(resetHorseman());
                    SetForce();
                    ShootArrow();
                    lastShot = Time.time;
                    Debug.Log(force);
                }
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

        GameObject clone = Instantiate(arrow, spawn.position, spawn.rotation * Quaternion.Euler(0f, 180f, 0f));
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = fromSpawnToCross * GetForce() * -1;
        slider.value = 1;
        Destroy(clone, 2f);
    }

    IEnumerator resetHorseman()
    {
        yield return new WaitForSeconds(fireRate);
        horseman.GetComponent<SpriteRenderer>().sprite = horseman_idle;
    }
}

