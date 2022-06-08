using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;
    public playerController levelOver;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate () 
    {
       if (!levelOver.levelDone)
       {
           unlockPlayer();
       }
    }

    void unlockPlayer()
    {
        transform.position = player.transform.position + new Vector3(7, 0, -10);
    }
}


