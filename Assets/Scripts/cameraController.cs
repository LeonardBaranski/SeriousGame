using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void Update () 
    {
        transform.position = player.transform.position + new Vector3(5, 0, -10);
    }
}
