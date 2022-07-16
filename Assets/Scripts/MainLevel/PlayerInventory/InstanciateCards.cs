using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateCards : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Canvas Canvas;

   
    

    private void LateUpdate()
    {
      
        for (int i = 0; i < playerInventory.DicePrefabs.Count; i++)
        {
            if (playerInventory.DicePrefabs[i].ToString().Contains(playerInventory.DiceScriptableObjects[i]))
            {
               GameObject go = Instantiate(playerInventory.DicePrefabs[i], new Vector3(0, 0, 0), Quaternion.identity);

               go.transform.parent = Canvas.transform;
               
               break;


            }

           
        }
       
        
    }

   
}
