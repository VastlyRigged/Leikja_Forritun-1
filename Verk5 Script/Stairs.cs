using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            RubyController rc = collision.gameObject.GetComponent<RubyController>();
            if (Input.GetKeyDown(KeyCode.W)) 
            {
                rc.climping = true;
            }
            if(rc.climping == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rc.climping = false;
                }
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            RubyController rc = collision.gameObject.GetComponent<RubyController>();
            rc.climping = false;
        }
    }
}
