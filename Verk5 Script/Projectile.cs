using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;
    public Vector2 dir;
    public float f;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Launch(dir, f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + other.gameObject);
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
        
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
