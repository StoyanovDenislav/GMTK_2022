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
            if (hasRun < playerInventory.DiceScriptableObjects.Count)
            {
                for (int x = 0; x < playerInventory.AddressableKeysDice.Count; x++)
                {
                    if (playerInventory.DiceScriptableObjects[i] == playerInventory.DicePrefabs[x].name)
                    {
                        GameObject go = Instantiate(playerInventory.DicePrefabs[x],
                            new Vector3(Transform.position.x + i * 230, 20, 0),
                            Quaternion.identity);

                        go.transform.localScale = new Vector2(2, 2);

                        go.transform.parent = Canvas.transform;

                        hasRun++;

                    }
                }
            }
        }

    }

   
}
