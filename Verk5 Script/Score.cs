using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI tm;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ConsumePoint", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = "Score: " + points;
    }
    private void ConsumePoint()
    {
        points -= 1;
    }
}
