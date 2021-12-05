using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow_script : MonoBehaviour
{
    private GameObject platform;
    private platform_script plat_script;

    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindWithTag("platform_small");
        plat_script = platform.GetComponent<platform_script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "platform_small")
        {
            plat_script.turn_large();
            Destroy(gameObject);
        }
    }
}
