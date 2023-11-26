using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    public int hp;
    [ReadOnly] public bool isDead;
    private AudioSource a;
    public float cooldownTime;
    [SerializeField] [ReadOnly] private bool waitForFiring = false;
    [SerializeField] private GameObject muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        a = gameObject.GetComponent<AudioSource>();
        muzzleFlash.SetActive(false);
    }
    bool fix = false;
    // Update is called once per frame
    void Update()
    {

        if (fix == false && isDead == true)
        {
            RunAftermath();
            fix = true;
        }
        if (fix == false && hp <= 0)
        {
            isDead = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (waitForFiring == false)
            {
                Shoot();
            }            
        }
    }
    void RunAftermath()
    {
        GameFunction gf = FindObjectOfType<GameFunction>();
        Debug.Log(gf.gameObject.name);
        a.Play();
        StopAllCoroutines();
        gf.GameOver();
        
    }
    void Shoot()
    {
        Debug.Log("Bang");
        StartCoroutine(WaitForFiring());
        StartCoroutine(MuzzleFlash());
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            
            if (hit.transform.gameObject.layer == 8)
            {
                Debug.Log("Hit, " + hit.transform.GetComponent<ZombieScript>().HP + " HP left.");
                hit.transform.GetComponent<ZombieScript>().HP -= 1;
                StartCoroutine(hit.transform.GetComponent<ZombieScript>().HitIndicator());
                
            }
        }
        
    }
    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
    }
    IEnumerator WaitForFiring()
    {
        waitForFiring = true;
        yield return new WaitForSeconds(cooldownTime);
        waitForFiring = false;
    }
}
