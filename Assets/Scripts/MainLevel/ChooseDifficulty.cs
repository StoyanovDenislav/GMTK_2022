using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDifficulty : MonoBehaviour
{
    public string difficulty;


    public void Easy()
    {
        difficulty = "Easy";
        SaveSystem.SaveDifficulty(this);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hard()
    {
        difficulty = "Hard";
        SaveSystem.SaveDifficulty(this);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}