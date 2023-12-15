using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;
public class MarkSpawn : MonoBehaviour
{
    public bool inAction = true;
    public int maximum;
    [SerializeField] [ReadOnly] private int timesSpawned = 0;
    public float cooldown = 2;
    [ReadOnly] public int current;
    [SerializeField] [ReadOnly] private List<Transform> SpawnPoints;
    public GameObject zombieModel;
    [ReadOnly] public List<GameObject> allZombies;
    // Start is called before the first frame update
    void Start()
    {
        Transform spt = GameObject.FindWithTag("Points").transform;
        SpawnPoints = spt.GetAllDeepChildren();
        StartCoroutine(Spawn());
    }

    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        if (inAction == true && current <= maximum)
        {
            int picked = UnityEngine.Random.Range(1, SpawnPoints.Count - 1);
            Vector3 spawnLocation = SpawnPoints[picked].position;
            GameObject zombie = Instantiate(zombieModel);
            zombie.transform.position = spawnLocation;
            current += 1;
            timesSpawned += 1;
            zombie.name = "Zombie " + timesSpawned;
            allZombies.Add(zombie);
        }
        StartCoroutine(Spawn());
    }
}
