using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 normalPos;
    float speed = 2;
    void Start()
    {
        normalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = Vector2.Lerp(new Vector2(normalPos.x, normalPos.y),
            new Vector2(normalPos.x, normalPos.y + 100), speed );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = Vector2.Lerp(new Vector2(normalPos.x, normalPos.y + 100),
            new Vector2(normalPos.x, normalPos.y), speed );
    }
}
