using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScriptableObjectPickup : MonoBehaviour
{
    public DiceScriptableObject DiceScriptableObject;

    private void Start()
    {
        InventoryData inventoryData = SaveSystem.LoadPlayer();

        if (inventoryData.DiceScriptableObjects.Count == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = DiceScriptableObject.sprite;
        }
        else
        {
            for (int i = 0; i < inventoryData.DiceScriptableObjects.Count; i++)
            {
                if (DiceScriptableObject.path == inventoryData.DiceScriptableObjects[i])
                {
                    gameObject.SetActive(false);
                }
            
                else  gameObject.GetComponent<SpriteRenderer>().sprite = DiceScriptableObject.sprite;
            
           
            }
        }

       

        
    }
}
