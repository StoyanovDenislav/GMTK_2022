using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyGet : MonoBehaviour
{
    public string difficulty;
    public static DifficultyGet diff;

    void Start()
    {
        if (diff)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);

            DifficultyData difficultyData = SaveSystem.LoadDifficulty();

            difficulty = difficultyData.diff;

            diff = this;
        }
    }
}