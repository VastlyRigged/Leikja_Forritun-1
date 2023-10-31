using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerScript ps;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float startDelay = 2;
    public float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(ps.gameOver == false) {Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); }
        
    }
}
