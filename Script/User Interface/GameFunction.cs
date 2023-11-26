using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameFunction : MonoBehaviour
{
    public GameObject goUI; //Stands for game over User Interface
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        goUI = GameObject.Find("GameOverUI");
        goUI.SetActive(false);
    }
    public void GameOver()
    {
        goUI.SetActive(true);
        gameObject.GetComponent<SpawnZombies>().inAction = false;
        Camera.main.cullingMask = layer;
        StartCoroutine(DisablePlayer());
        SpawnZombies sz = GameObject.Find("EventSystem").GetComponent<SpawnZombies>();
        Debug.Log("Count:" + sz.allZombies.Count);
        for (int i = 0; i < sz.allZombies.Count; i++)
        {
            int item = (sz.allZombies.Count - 1) - i;
            sz.allZombies[item].GetComponent<ZombieScript>().givePointsOnDeath = false;
            Destroy(sz.allZombies[item]);
        } 

    }
    private IEnumerator DisablePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Destroy(player);
    }
}
