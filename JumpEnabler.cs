using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allow Player to jump again.
public class JumpEnabler : MonoBehaviour
{
    private PlayerScript ps;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.GetComponent<PlayerScript>())
        {
            ps = transform.parent.GetComponent<PlayerScript>();
        }
        else
        {
            Debug.LogWarning("JumpEnabler: " + transform.parent.name + " does not contain 'PlayerScript'.");
            this.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (ps.canJump == false) { ps.canJump = true; }
        }
    }
}
