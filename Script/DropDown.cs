using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is let the GameObject it is on to set RigidBody to Dynamic before destroying itself after few seconds. 
public class DropDown : MonoBehaviour
{
    [SerializeField] private string tagTarget;
    private Rigidbody rb;
    public Material material;
    public bool flipGravity;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Rigidbody>()) //In case the game object does not have Rigidbody.
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        else //Else, it warns the developer of this stupid oversight and disable this script.
        {
            Debug.LogWarning("DropDown: " + gameObject.name + " does not contain 'Rigidbody'.");
            this.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagTarget))
        {
            StartCoroutine(InitiateFunction());
        }
    }
    IEnumerator InitiateFunction()
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        yield return new WaitForSeconds(0.35f); //Give a player some reasonably time to react.
        rb.isKinematic = false;
        if(flipGravity == true)
        {
            InvokeRepeating(nameof(GoUp), 0.1f, Time.deltaTime);
        }
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    void GoUp()
    {
        rb.AddForce(-Physics.gravity);
    }
}
