using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public scoreController scoreController;
    public float moveSpeed = 5;

    public float upDownSpeed = 10f;
    public float height = .13f;
    public float startY = -0.14f;
    public Canvas endScreenCanvas;

    public bool levelDone;

    // Start is called before the first frame update
    void Start()
    {
        levelDone = false;
        endScreenCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.x += moveSpeed * Time.deltaTime;
    
        transform.position = pos;
    }

    void Update()
    {
        var posi = transform.position;
        var newY = startY + height*Mathf.Sin(Time.time * upDownSpeed);
        transform.position = new Vector3(posi.x, newY, posi.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            levelDone = true;
        }
    }
}
