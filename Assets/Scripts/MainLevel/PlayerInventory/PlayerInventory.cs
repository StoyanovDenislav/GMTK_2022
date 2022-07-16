using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerInventory : MonoBehaviour
{ 
    public List<string> DiceScriptableObjects = new List<string>();
    public List<string> AddressableKeysDice = new List<string>();
   public List<GameObject> DicePrefabs = new List<GameObject>();
   [SerializeField] private AsyncOperationHandle<IList<GameObject>> loadHandle;
   private float maxCards = 3f;
  

   private void Awake()
   {
       InventoryData inventoryData = SaveSystem.LoadPlayer();

       DiceScriptableObjects = inventoryData.DiceScriptableObjects;
       
       LoadAddressablesForItems();
      
   }

   void Start()
   {
       DiceScriptableObjects.Sort();
       AddressableKeysDice.Sort();
       DicePrefabs.OrderBy(o => o.name).ToList();



   }
   
   
    
    public void LoadAddressablesForItems()
    {
       
        loadHandle = Addressables.LoadAssetsAsync<GameObject>(
            AddressableKeysDice,
            addressable => {
                DicePrefabs.Add(addressable);


            }, Addressables.MergeMode.Union, // How to combine multiple labels 
            false); // Whether to fail and release if any asset fails to load
        

        
    }

    public void LoadHandle_Completed(AsyncOperationHandle<IList<GameObject>> operation)
    {
        if (operation.Status != AsyncOperationStatus.Succeeded)
            Debug.LogWarning("Some assets did not load.");
    }

    

    void OnTriggerEnter2D(Collider2D colliderHit)
    {
        if (DiceScriptableObjects.Count < 3)
        {

            DiceScriptableObjects.Add(colliderHit.gameObject.GetComponent<DiceScriptableObjectPickup>()
                .DiceScriptableObject.path);

            SaveSystem.SavePlayer(this);

            Destroy(colliderHit.gameObject);
        }

    }
    

    }

    

