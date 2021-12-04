using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 large_size = new Vector3(4, 0.5f, 4);
    private Vector3 normal_size = new Vector3(3, 0.5f, 3);
    private Vector3 small_size = new Vector3(2, 0.5f, 2);


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    // Up is in the positive z axis
    // Right is in the positive x axis
    void Update()
    {
        Vector3 size = GetComponent<Renderer>().bounds.size;
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f + (size.x/2), 9f - (size.x/2)), 
            transform.position.y, 
            Mathf.Clamp(transform.position.z, -9.5f + (size.z/2), 9.5f - (size.z/2)));

        if(Input.GetKey("up") && transform.position.z != 9.5 - (size.z/2))
        {
            transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("down") && transform.position.z != -9.5 + (size.z/2))
        {
            transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("left") && transform.position.x != -9 + (size.x/2))
        {
            transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        }

        if(Input.GetKey("right") && transform.position.x != 9 - (size.z/2))
        {
            transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
        }

    }
}
