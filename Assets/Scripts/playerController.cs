using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject startMenu;
    public GameObject playerStanding;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        playerStanding.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (!startMenu.activeSelf) 
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
    
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            playerStanding.SetActive(true);
        }
    }
}
