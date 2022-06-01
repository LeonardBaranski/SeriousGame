using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject startMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (!startMenu.activeSelf) {
            pos.x += moveSpeed * Time.deltaTime;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        /*if (Input.GetKey ("a")) {
            pos.x -= moveSpeed * Time.deltaTime;   
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }*/

        transform.position = pos;
    }
}
