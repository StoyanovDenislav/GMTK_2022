using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public List<DiceScriptableObject> DiceScriptableObjects = new List<DiceScriptableObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colliderHit)
    {
       
        DiceScriptableObjects.Add(colliderHit.gameObject.GetComponent<DiceScriptableObjectPickup>().DiceScriptableObject);

        Destroy(colliderHit.gameObject);
    }

   /* void OnTriggerEnter2D(Collider2D colliderHit)
    {
        

      




    }*/

    }

    

