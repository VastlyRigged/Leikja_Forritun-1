using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnablerCollider : MonoBehaviour
{
    private PlayerScript ps;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.GetComponent<PlayerScript>() != null)
        {
            ps = transform.parent.GetComponent<PlayerScript>();
        }
        else
        {
            Debug.LogError(transform.parent.name + " has no 'PlayerScript' component.");
            gameObject.GetComponent<PlayerScript>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (ps != null)
            {
                ps.canJump = true;
                ps.dirtParticle.Play();
                
            }
            else
            {
                Debug.LogError(transform.parent.name + " has no 'PlayerScript' component.");
                gameObject.GetComponent<PlayerScript>().enabled = false;
            }
        }
    }
}
