using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayFPS : MonoBehaviour
{
    public float unit;
    [SerializeField]
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        float current = 0;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        current = FramesPerSecond.DetermineFPS();
        tmp.text = "FPS: " + current.ToString();
        StartCoroutine(Wait());
        
    }
}
