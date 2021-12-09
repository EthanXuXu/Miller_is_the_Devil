using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_script : MonoBehaviour
{
    private GameObject platform;
    private platform_script plat_script;

    private GameObject game_manager;
    private game_manager manager_script;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindWithTag("platform_small");
        plat_script = platform.GetComponent<platform_script>();
        
        game_manager = GameObject.FindWithTag("game_manager");
        manager_script = game_manager.GetComponent<game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = manager_script.get_powerup_speed();
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);
        
        //If the shrink power up falls 2 meters below the platform its destroyed
        if(transform.position.y <= -2){
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform_small")
        {
            plat_script.speed_up();
            Destroy(gameObject);
        }
    }
}
