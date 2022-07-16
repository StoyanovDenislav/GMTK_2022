using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateCards : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Canvas Canvas;
    public float hasRun;
   
    

    private void LateUpdate()
    {
      
        for (int i = 0; i < playerInventory.DicePrefabs.Count; i++)
        {
            if (hasRun < playerInventory.DicePrefabs.Count)
            {
                if (playerInventory.DicePrefabs[i].ToString().Contains(playerInventory.DiceScriptableObjects[i]))
                {
                    GameObject go = Instantiate(playerInventory.DicePrefabs[i].gameObject, new Vector3(playerInventory.DicePrefabs[i].gameObject.transform.position.x + i * 20, 100, 0), Quaternion.identity);

                    go.transform.parent = Canvas.transform;

                    hasRun++;

                }
            }

            

           
        }
       
        
    }

   
}
