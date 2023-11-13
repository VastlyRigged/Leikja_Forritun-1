using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    public bool finale = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(finale == false) { GameObject.Find("EventSystem").GetComponent<Skipti>().Endurræsa(); }
            else { SceneManager.LoadScene(0); }
        }
    }
}
