using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float speed = 3.5f;
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        //Randomize the dircation of spinning.
        if (RandomBool(0.5f) == true) //X axis
        {
            rot = new(speed, rot.y, rot.z);
        }
        else
        {
            rot = new(-speed, rot.y, rot.z);
        }
        if (RandomBool(0.5f) == true) //Y axis
        {
            rot = new(rot.x, speed, rot.z);
        }
        else
        {
            rot = new(rot.x, -speed, rot.z);
        }
        if (RandomBool(0.5f) == true) //Z axis
        {
            rot = new(rot.x, rot.y, speed);
        }
        else
        {
            rot = new(rot.x, rot.y, -speed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //rb.angularVelocity = rot;
        transform.Rotate(rot.x * Time.deltaTime, rot.y * Time.deltaTime, rot.z * Time.deltaTime);
    }
    private bool RandomBool(float chanceValue)
    {
        if (Random.value > chanceValue)
        {
            return true;
        }
        return false;
    }
}
