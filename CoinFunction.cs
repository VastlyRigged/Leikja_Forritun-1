using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.GetComponent<PlayerScript>() += 1;
            Destroy(gameObject);
        }
    }
}
