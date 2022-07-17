using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 normalPos;
    
    void Start()
    {
        normalPos = gameObject.GetComponent<RectTransform>().position;

    }

    


    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.move(gameObject, new Vector2(normalPos.x, normalPos.y + 150), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.move(gameObject, new Vector2(normalPos.x, normalPos.y), 0.3f);
    }
}
