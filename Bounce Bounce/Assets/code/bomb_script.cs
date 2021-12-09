using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_script : MonoBehaviour
{
    private GameObject platform;
    private platform_script plat_script;

    public GameObject explosion_prefab;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindWithTag("platform_small");
        plat_script = platform.GetComponent<platform_script>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the shrink power up falls 2 meters below the platform its destroyed
        if(transform.position.y <= -2){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform_small")
        {
            Instantiate(explosion_prefab, transform.position, Quaternion.identity);
            plat_script.disable_platform();

            FindObjectOfType<AudioManager>().Play("Explode");
            Destroy(gameObject);
        }
    }
}
