using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_script : MonoBehaviour
{
    private GameObject game_manager;
    private game_manager manager_script;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {   
        game_manager = GameObject.FindWithTag("game_manager");
        manager_script = game_manager.GetComponent<game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = manager_script.get_ball_speed();
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);

        //If the balls falls 2 meters below the platform its destroyed and number of lives decreased
        if(transform.position.y <= -2){
            manager_script.decrease_lives();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform_small")
        {
            manager_script.increase_score();
            Destroy(gameObject);
        }
    }
}
