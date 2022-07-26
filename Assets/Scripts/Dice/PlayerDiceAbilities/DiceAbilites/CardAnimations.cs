using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 normalPos;
    private PlayerInventory playerInventory;
    public bool cardUsed = false;


    void Start()
    {
        normalPos = gameObject.GetComponent<RectTransform>().position;
        playerInventory = FindObjectOfType<PlayerInventory>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.move(gameObject, new Vector2(normalPos.x, normalPos.y + 250), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.move(gameObject, new Vector2(normalPos.x, normalPos.y), 0.3f);
    }

    public IEnumerator Anims()
    {
        normalPos = Vector2.Lerp(new Vector2(normalPos.x, normalPos.y),
            new Vector2((float) Screen.width / 2, (float) Screen.height / 2), 1f);


        yield return new WaitForSeconds(2);

        for (int i = 0; i < playerInventory.DiceScriptableObjects.Count; i++)
        {
            if (playerInventory.DiceScriptableObjects[i] == gameObject.name)
            {
                playerInventory.DiceScriptableObjects.RemoveAt(i);
                Destroy(gameObject);
                SaveSystem.SavePlayer(playerInventory);

                break;
            }
        }
    }
}