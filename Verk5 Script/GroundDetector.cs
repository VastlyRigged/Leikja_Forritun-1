using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public RubyController rc;
    public LayerMask layer;
    private void Start()
    {
        rc = transform.parent.GetComponent<RubyController>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            rc.canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.gameObject.layer == 9)
        {
            rc.canJump = false;
        }
    }
}
