using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateCards : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Canvas Canvas;
    public float hasRun;
    public Transform Transform;
   
    

    private void Update()
    {

        for (int i = 0; i < playerInventory.DiceScriptableObjects.Count; i++)
        {
            if (hasRun < playerInventory.AddressableKeysDice.Count)
            {
                if (playerInventory.DiceScriptableObjects[i].Contains(playerInventory.AddressableKeysDice[i]))
                {
                    GameObject go = Instantiate(playerInventory.DicePrefabs[i],
                        new Vector3(Transform.position.x + i * 135, 20, 0),
                        Quaternion.identity);

                    go.transform.parent = Canvas.transform;

                    hasRun++;

                }
            }
        }


    }

   
}
