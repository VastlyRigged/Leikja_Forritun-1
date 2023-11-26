using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color color;
    [ReadOnly] public Color defaultColor; 
    [SerializeField] private Image target;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Image i = target;
        i.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image i = target;
        i.color = defaultColor;
    }

    private void Start()
    {
        defaultColor = target.GetComponent<Image>().color;
    }
}
