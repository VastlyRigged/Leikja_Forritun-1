using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform M_Player;
    public float speed;
    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        M_Player = GameObject.FindWithTag("Player").transform;
        nav.speed = speed;
        StartCoroutine(SpeedBoost());
    }

    // Update is called once per frame
    void Update()
    {
        if (M_Player.GetComponent<PlayerScript>().isDead == false)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = M_Player.position;
        }
    }
    IEnumerator SpeedBoost()
    {
        nav.speed = speed * 3;
        yield return new WaitForSeconds(2);
        nav.speed = speed;
    }
}
