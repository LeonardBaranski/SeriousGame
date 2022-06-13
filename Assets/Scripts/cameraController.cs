using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;
    public playerController levelOver;

    private float yPos;

    void Awake()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
       if (!levelOver.levelDone)
       {
           unlockPlayer();
       }
    }

    void LateUpdate()
    {
        if(!levelOver.levelDone)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }

    void unlockPlayer()
    {
        transform.position = player.transform.position + new Vector3(7, 0, -10);
    }
}


