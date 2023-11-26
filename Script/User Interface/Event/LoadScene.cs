using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadScene : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] private string mapName;
    [SerializeField] private Confirm c;
    [SerializeField] private GameObject cgo;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        cgo.SetActive(true);
        cgo.transform.FindDeepChild("Tittle").GetComponent<TextMeshProUGUI>().text = "Are you sure want to play in " + mapName + "?";
        c.selectMap = mapName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
        cgo.SetActive(true);
        cgo.transform.FindDeepChild("Tittle").GetComponent<TextMeshProUGUI>().text = "Are you sure want to play in " + mapName + "?";
        c.selectMap = mapName;
    }

    private void Start()
    {
        if(cgo.activeInHierarchy == true)
        {
            cgo.SetActive(false);
        }
    }

}
