using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairController : MonoBehaviour
{
    public float upDownSpeed = 10f;
    public float height = .13f;
    public float startY = -0.14f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var posi = transform.position;
        var newY = startY + height*Mathf.Sin(Time.time * upDownSpeed);
        transform.position = new Vector3(posi.x, newY, posi.z);
    }
}
