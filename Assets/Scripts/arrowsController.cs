using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowsController : MonoBehaviour
{
    public float force = 20;
    public GameObject arrow;
    public Transform spawn;
    public Transform crosshair;
    public float maxForce = 30;
    public float minForce = 1;
    public float chargingIntervall = .2f;
    public float chargingIncrement = 3f;


    // Start is called before the first frame update
    void Start()
    {
        force = minForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("IncreaseForce", 0, chargingIntervall);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("IncreaseForce");
                ShootArrow();
                force = minForce;
                Debug.Log(force);
            }
        }
    }


    private void IncreaseForce()
    {
        if (force < maxForce)
        {
            force += chargingIncrement;
            Debug.Log(force);
        }
    }

    private void ShootArrow()
    {
        Vector3 spawnPos = spawn.position;
        Vector3 crosshairPos = crosshair.position;
        Vector3 fromSpawnToCross = spawnPos - crosshairPos;
        fromSpawnToCross.Normalize();

        GameObject clone = Instantiate(arrow, spawn.position, spawn.rotation * Quaternion.Euler(0f, 180f, 0f));
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = fromSpawnToCross * force * -1;
        Destroy(clone, 2f);
    }
}

