using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Confirm : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    [ReadOnly] public string selectMap;
    [SerializeField] private bool yes;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (yes == false)
        {
            transform.parent.parent.parent.gameObject.SetActive(false);    
        }
        else
        {
            Debug.Log(selectMap);
            SceneManager.LoadScene(selectMap);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (yes == false)
        {
            transform.parent.parent.parent.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(selectMap);
            SceneManager.LoadScene(selectMap);
        }
    }
}
