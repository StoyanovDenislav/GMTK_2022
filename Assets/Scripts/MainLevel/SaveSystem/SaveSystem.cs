using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public static class SaveSystem
{
    public static void SavePlayer(PlayerInventory playerInventory) {
       

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dat";
        FileStream fileStream = new FileStream(path, FileMode.Create);
    
        InventoryData allData = new InventoryData(playerInventory);
        
        binaryFormatter.Serialize(fileStream, allData);
        
        fileStream.Close();


    }


    public static InventoryData LoadPlayer() {

        string path = Application.persistentDataPath + "/player.dat";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            InventoryData data = binaryFormatter.Deserialize(fileStream) as InventoryData;

            fileStream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in: " + path);

            return null;

        }


    }
    
    



}