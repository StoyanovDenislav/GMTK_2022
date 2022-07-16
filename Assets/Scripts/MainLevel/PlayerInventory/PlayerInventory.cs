using System;
using System.Collections;
using System.Collections.Generic;
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

  

   private void Awake()
   {
       LoadAddressablesForItems();
   }

   void Start()
   {
    //  InventoryData inventoryData = SaveSystem.LoadPlayer();

//       DiceScriptableObjects = inventoryData.DiceScriptableObjects;
       
       
           

          




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

    // Update is called once per frame
    void Update()
    { 
        /*for (int i = 0; i < DiceScriptableObjects.Count; i++)
        {
            if (DiceScriptableObjects.Contains(DicePrefabs[i].name))
            {
                
                Instantiate(DicePrefabs[i].gameObject, new Vector3(20,20,20), Quaternion.identity);
            }
        }*/
        
      
    }

    void OnTriggerEnter2D(Collider2D colliderHit)
    {
       
        DiceScriptableObjects.Add(colliderHit.gameObject.GetComponent<DiceScriptableObjectPickup>().DiceScriptableObject.path);
        
       SaveSystem.SavePlayer(this);
        
        Destroy(colliderHit.gameObject);
        
    }
    

    }

    

