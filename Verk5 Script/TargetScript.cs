using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        GameObject es = GameObject.Find("EventSystem");
        es.GetComponent<MarkSpawn>().current -= 1;
        es.GetComponent<Score>().points += 4;
    }
}
