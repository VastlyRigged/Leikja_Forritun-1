using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZombieScript : MonoBehaviour
{
    public int HP = 3;
    public Material[] mat = new Material[2];
    bool quitting = false;
    private bool canDestroy = true;
    [HideInInspector] public bool givePointsOnDeath = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && HP > 0)
        {
            if(collision.gameObject.GetComponent<PlayerScript>().isDead == false)
            {
                collision.gameObject.GetComponent<PlayerScript>().hp = 0;
            }
            
        }
    }
    private void Update()
    {

        if (HP <= 0)
        {
            gameObject.GetComponent<EnemyAI>().speed = 0;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (canDestroy == true)
            {
                Destroy(gameObject);
            }

        }
    }
    void OnApplicationQuit()
    {
        quitting = true;
    }
    void OnDestroy()
    {
        if (quitting == true) { return; }
        Debug.Log("Destroyed");
        SpawnZombies sz = GameObject.Find("EventSystem").GetComponent<SpawnZombies>();
        sz.current -= 1;
        Debug.Log("");
        sz.allZombies.Remove(gameObject);
        if (givePointsOnDeath == true)
        {
            
            GameObject.Find("Scoreboard").GetComponent<ScoreScript>().Score += 1;
        }
        StopAllCoroutines();
        
        

    }
    public IEnumerator HitIndicator()
    {
        canDestroy = false;
        gameObject.GetComponent<MeshRenderer>().material = mat[1];
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<MeshRenderer>().material = mat[0];
        canDestroy = true;
        
    }
}
