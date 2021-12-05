using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    public float speed = 10f;

    private static float size_change_time;
    private static float speed_change_time;
    private Vector3 large_size = new Vector3(4, 0.5f, 4);
    private Vector3 normal_size = new Vector3(3, 0.5f, 3);
    private Vector3 small_size = new Vector3(2, 0.5f, 2);


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        size_change_time = 0f;
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
        
        //Revert to normal size after 5 seconds of size change
        if(Time.time - size_change_time >= 7f){
            turn_normal();
        }

        //Revert to normal speed after 5 seconds of speed change
        if(Time.time - size_change_time >= 4f){
            normal_speed();
        }

        if(Input.GetKey("up") && transform.position.z < 9.45 - (size.z/2))
        {
            speed_up();
            transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("down") && transform.position.z > -9.45 + (size.z/2))
        {
           
            transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
        }

        if(Input.GetKey("left") && transform.position.x > -8.95 + (size.x/2))
        {
            transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);
        }

        if(Input.GetKey("right") && transform.position.x < 8.95 - (size.z/2))
        {
            transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
        }

    }

    public void turn_small(){
        size_change_time = Time.time;
        transform.localScale = small_size;
    }

    public void turn_normal(){
        transform.localScale = normal_size;
    }
    
    public void turn_large(){
        size_change_time = Time.time;
        transform.localScale = large_size;
    }

    public void speed_up(){
        speed_change_time = Time.time;
        speed = 15f;
    }

    public void normal_speed(){
        speed = 10f;
    }
}
