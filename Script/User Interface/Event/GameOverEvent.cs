using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
public class GameOverEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public Options select;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (select == Options.Reset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (select == Options.Reset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    [Serializable]
    public enum Options
    {
        Reset, MainMenu
    }
}
