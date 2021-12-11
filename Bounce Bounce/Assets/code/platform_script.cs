using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    public float speed = 10f;

    private static float size_change_time;
    private static float speed_change_time;
    private static float bomb_change_time;
    private static bool disabled;

    private Vector3 large_size = new Vector3(4, 3, 4);
    private Vector3 normal_size = new Vector3(3, 3, 3);
    private Vector3 small_size = new Vector3(2, 3, 2);


    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        size_change_time = 0f;
        speed_change_time = 0f;
        bomb_change_time = 0f;
        disabled = false;
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
        
        //Revert to normal size after 7 seconds of size change
        if(Time.time - size_change_time >= 7f){
            turn_normal();
        }

        //Revert to normal speed after 7 seconds of speed change
        if(Time.time - speed_change_time >= 7f){
            normal_speed();
        }

        //Revert to normal speed after 5 seconds of being disabled
        if(Time.time - bomb_change_time >= 3f){
            disabled = false;
        }

        if(!disabled)
        {
            if(Input.GetKey("up") && transform.position.z < 9.45 - (size.z/2))
            {
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

    }

    /*
    When a shrink powerup hits the platform scale down the object
    by 33% on the x and z axes
    */
    public void turn_small(){
        size_change_time = Time.time;
        transform.localScale = small_size;
    }

    /*
    Return platform to normal size
    */
    public void turn_normal(){
        transform.localScale = normal_size;
    }
    
    /*
    When a grow powerup hits the platform scale up the object
    by 33% on the x and z axes
    */
    public void turn_large(){
        size_change_time = Time.time;
        transform.localScale = large_size;
    }

    /*
    When a speed powerup hits the platform increase movement
    speed by 50%
    */
    public void speed_up(){
        speed_change_time = Time.time;
        speed = 15f;
    }

    /*
    Return to normal speed
    */
    public void normal_speed(){
        speed = 10f;
    }

    /*
    When a bomb hits the platform disable movement
    */
    public void disable_platform(){
        bomb_change_time = Time.time;
        disabled = true;
    }
}
