using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float force = 20;
    public GameObject arrow;
    public Transform spawn;
    public Transform crosshair;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootArrow();
        }
    }

    public void shootArrow()
    {
        Vector3 spawnPos = spawn.position;
        Vector3 crosshairPos = crosshair.position;
        Vector3 fromSpawnToCross = spawnPos - crosshairPos;
        fromSpawnToCross.Normalize();

        GameObject clone = Instantiate(arrow, spawn.position, spawn.rotation * Quaternion.Euler(0f, 180f, 0f));
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.velocity = fromSpawnToCross * force * -1;
    }
}
