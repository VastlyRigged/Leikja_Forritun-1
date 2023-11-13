using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public float jumpForce = 1000;
    private Rigidbody rb;
    public bool canJump = true;
    public bool gameOver = false;
    public static int score = 1;
    public TextMeshProUGUI countText;

    void Start()
    {
        Debug.Log("byrja");
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(countText != null)
        {
            SetCountText();
        }
        if (Input.GetKey(KeyCode.W))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.S))// til baka
        {
            transform.position += -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.A))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space) && canJump == true && gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            canJump = false;
        }
        //hér rétti ég playerinn við ef hann dettur
        //sný player
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey(KeyCode.G))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey(KeyCode.Q))// ef ýtt er á q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (transform.position.y <= -1 || Input.GetKeyDown(KeyCode.K))
        {
            Endurræsa();
        }
        
    }
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hlutur"))
        {
            score += 1;
            SetCountText();
        }
    }

     void SetCountText()
     {
         countText.text = "Stig: " + score.ToString();

         if (score <= 0)
         {
             this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
             countText.text = "Dauður " + score.ToString()+" stigum";

             StartCoroutine(Bida());

         }

     }
     IEnumerator Bida()
     {
         yield return new WaitForSeconds(2);
         Endurræsa();
     }

     public void Byrja()
     {
         SceneManager.LoadScene(1);
     }
     public void Endurræsa()
     {
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         SceneManager.LoadScene(0);//Level_1
    }
    
}
