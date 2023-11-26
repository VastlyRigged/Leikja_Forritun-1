using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().hp = 0;
        }
    }
}
