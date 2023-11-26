using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public string tittle;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = tittle + ": " + Score;
    }
}
