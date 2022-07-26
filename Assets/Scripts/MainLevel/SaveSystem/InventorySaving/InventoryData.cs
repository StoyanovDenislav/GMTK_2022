using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public List<string> DiceScriptableObjects = new List<string>();

    public InventoryData(PlayerInventory pl)
    {
        DiceScriptableObjects = pl.DiceScriptableObjects;
    }
}

[System.Serializable]
public class DifficultyData
{
    public string diff;

    public DifficultyData(ChooseDifficulty chooseDifficulty)
    {
        diff = chooseDifficulty.difficulty;
    }
}