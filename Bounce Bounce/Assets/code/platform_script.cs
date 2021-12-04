using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Up is in the positive z axis
    // Right is in the positive x axis
    void Update()
    {
        if(Input.GetKey("up"))
        {
            transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("down"))
        {
            transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("left"))
        {
            transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        }

        if(Input.GetKey("right"))
        {
            transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
        }
    }
}
